using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CalculateLocation : MonoBehaviour {

    // Use this for initialization
    private List<List<float>> udaljenosti;
    public List<Vector3> koordinate;
    private float[] x= new float[4];
    private float[] y= new float[4];
    private float[] z = new float[4];

    private List<float> udaljenost1;
    private List<float> udaljenost2;
    private List<float> udaljenost3;
    private List<float> udaljenost4;

    private float[] x_t = new float[4];
    private float[] y_t = new float[4];
    private float[] z_t = new float[4];

    private float[,] A;
    private float[] b;


    private float[] xs;
    private float[] ys;
    private float[] zs;


    private float delay;

    void Start () {

        delay = GameObject.Find("Radar Camera").GetComponent<RadShow>().interval;
        getSenzorPos();
        InvokeRepeating("CalcLoc", 2*delay, delay ); // pomeram malo 

        A = new float[3, 3];

        for (int i = 0; i < 3; i++)
        {
            A[i, 0] = 2 * (x[i + 1] - x[0]);
            A[i, 1] = 2 * (y[i + 1] - y[0]);
            A[i, 2] = 2 * (z[i + 1] - z[0]);

        }


        xs = new float[4];
        ys = new float[4];
        zs = new float[4];

        for (int i=0; i<4; i++)
        {
            xs[i] = x[i] * x[i];
            ys[i] = y[i] * y[i];
            zs[i] = z[i] * z[i];

        }






    }
    void getSenzorPos()
    {
        x[0] = GameObject.Find("Senzor1").transform.position.x;
        x[1] = GameObject.Find("Senzor2").transform.position.x;
        x[2] = GameObject.Find("Senzor3").transform.position.x;
        x[3] = GameObject.Find("Senzor4").transform.position.x;

        y[0] = GameObject.Find("Senzor1").transform.position.y;
        y[1] = GameObject.Find("Senzor2").transform.position.y;
        y[2] = GameObject.Find("Senzor3").transform.position.y;
        y[3] = GameObject.Find("Senzor4").transform.position.y;

        z[0] = GameObject.Find("Senzor1").transform.position.z;
        z[1] = GameObject.Find("Senzor2").transform.position.z;
        z[2] = GameObject.Find("Senzor3").transform.position.z;
        z[3] = GameObject.Find("Senzor4").transform.position.z;
    }
	
	// Update is called once per frame
	void CalcLoc()
    {
        udaljenosti = new List<List<float>>();
        udaljenost1 = new List<float>();
        udaljenost2 = new List<float>();
        udaljenost3 = new List<float>();
        udaljenost4 = new List<float>();

        udaljenost1 = GameObject.Find("Senzor1").GetComponent<GetDistance>().udaljenost;
        udaljenost2 = GameObject.Find("Senzor2").GetComponent<GetDistance>().udaljenost;
        udaljenost3 = GameObject.Find("Senzor3").GetComponent<GetDistance>().udaljenost;
        udaljenost4 = GameObject.Find("Senzor4").GetComponent<GetDistance>().udaljenost;

        for(int i=0; i<udaljenost1.Count; i++)
        {

            float r1 = udaljenost1[i];
            float r2 = udaljenost2[i];
            float r3 = udaljenost3[i];
            float r4 = udaljenost4[i];
            List<float> temp = new List<float>();
            temp.Add(r1);
            temp.Add(r2);
            temp.Add(r3);
            temp.Add(r4);
            udaljenosti.Add(temp);
        }

        
        Gauss();



    }
    void Gauss()
    {


       
        int s = udaljenosti.Count;
        b = new float [3];
       
        
        for(int i=0; i<s; i++) {
            List<float> temp = udaljenosti[i];

            b[0] = (temp[0] * temp[0] - xs[0] - temp[1] * temp[1] + xs[1] + ys[1] - ys[0] + zs[1] - zs[0]);
            b[1] = (temp[0] * temp[0] - xs[0] - temp[2] * temp[2] + xs[2] + ys[2] - ys[0] + zs[2] - zs[0]);
            b[2] = (temp[0] * temp[0] - xs[0] - temp[3] * temp[3] + xs[3] + ys[3] - ys[0] + zs[3] - zs[0]);
            gornjaTrougaona();
            resenjeGornjaTrougaona();



            //JOVANOVICU OVO MOZES KAO SEND MESSAGE (sporije valjda ali pokusaj sa ovim prvo ) 
            //   GameObject.Find("NAZIV OBJEKTA NA KOJI STAVLJAS SKRIPTU").SendMessage ("NAZIV METODE", koordinate ); // korodinate su List<Vector3>
            // metoda ti treba primati List<Vector3>

            // Druga opcija je da kod sebe periodicno pozivas preko  InvokeRepeating pogledaj gore kod mene u Startu, samo odlozi pozivanje 
            // Jer mora moja funkcija prvo da se pokrene da bi ti ista poslala, takodje moras paziti da ti ne salje prazne liste kada na pocetku nema raketa koje napadaju
            //Ovako bi pozivao : List<Vector3> JovanovicVektor = GameObject.Find("MainSenzor").GetComponent<CalculateLocation>().koordinate;
            // Daje ti prave x, y,z koordinate tj. po unity-u sta je x,y,z 

        }



    }

    void gornjaTrougaona()
    {
        int n = 3;
        float m = 3;
        for( int k =0; k<3; k++)
        {
            for(int i=k+1; i<n; i++)
            {
                m = A[i, k] / A[k, k];
                for (int j = k; j < m; j++)
                {
                    A[i, j] = A[i, j] - m * A[k, j];

                }
                b[i] = b[i] - m * b[k];
            }
        }

}

    void resenjeGornjaTrougaona() {

        int n = 3;
        float []x = { 0f, 0f, 0f };
        
        for(int i=2; i>-1; i--)
        {
            
            float s = 0;
            for(int k=i+1; k<n; k++)
            {

                s = s + A[i, k] * x[k];

            }
            x[i] = (b[i] - s) / A[i, i];

        }
        Vector3 tacka = new Vector3();
        tacka.x = x[0];
        tacka.y = x[1];
        tacka.z = x[2];

        koordinate.Add(tacka);

    }



   
}
