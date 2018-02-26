using UnityEngine;
using System.Collections;

public class DodajObjekte : MonoBehaviour
{

    public GameObject napad;
    public GameObject odbrana;
    public GameObject gg_raketa;
    public int x_odbrana;
    public int y_odbrana;
    public int[] x_napad;
    public int[] y_napad;
    public int[] x_gadja;
    public int[] y_gadja;
    public int[] ugao;

    private int nameNumber = 0;
    private int upadoh = 0;
    private int rocket_no = 0;



    void Start()
    {

        Spawn_Deff();

        for (int i = 0; i < x_napad.Length; i++)
        {
            Spawn_Att(x_napad[i], y_napad[i], ugao[i]);

        }


    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[0], 4, y_napad[0]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[0]);
            raketa.SendMessage("setPP", new Vector3(x_napad[0], 4, y_napad[0]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[0], 0, y_gadja[0]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[1], 4, y_napad[1]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[1]);
            raketa.SendMessage("setPP", new Vector3(x_napad[1], 4, y_napad[1]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[1], 0, y_gadja[1]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[2], 4, y_napad[2]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[2]);
            raketa.SendMessage("setPP", new Vector3(x_napad[2], 4, y_napad[2]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[2], 0, y_gadja[2]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[3], 4, y_napad[3]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[3]);
            raketa.SendMessage("setPP", new Vector3(x_napad[3], 4, y_napad[3]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[3], 0, y_gadja[3]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[4], 4, y_napad[4]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[4]);
            raketa.SendMessage("setPP", new Vector3(x_napad[4], 4, y_napad[4]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[4], 0, y_gadja[4]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[5], 4, y_napad[5]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[5]);
            raketa.SendMessage("setPP", new Vector3(x_napad[5], 4, y_napad[5]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[5], 0, y_gadja[5]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[6], 4, y_napad[6]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[6]);
            raketa.SendMessage("setPP", new Vector3(x_napad[6], 4, y_napad[6]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[6], 0, y_gadja[6]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[7], 4, y_napad[7]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[7]);
            raketa.SendMessage("setPP", new Vector3(x_napad[7], 4, y_napad[7]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[7], 0, y_gadja[7]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[8], 4, y_napad[8]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[8]);
            raketa.SendMessage("setPP", new Vector3(x_napad[8], 4, y_napad[8]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[8], 0, y_gadja[8]));
        }
        else if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            GameObject raketa = Instantiate(gg_raketa, new Vector3(x_napad[9], 4, y_napad[9]), Quaternion.Euler(0, -90, 0)) as GameObject;
            raketa.SendMessage("setUgao", ugao[9]);
            raketa.SendMessage("setPP", new Vector3(x_napad[9], 4, y_napad[9]));
            raketa.SendMessage("setCilj", new Vector3(x_gadja[9], 0, y_gadja[9]));
        }


    }
    void Spawn_Deff()
    {

        if (x_odbrana < -200 || x_odbrana > -100)
        {

            x_odbrana = -150;

        }

        if (y_odbrana < -200 || y_odbrana > 200)
        {

            y_odbrana = 0;

        }

        odbrana.transform.position = new Vector3(x_odbrana, 0, y_odbrana);
    }

    void Spawn_Att(int x, int y, int ugao)
    {



        if (x < 0 || x > 100)
        {

            x = 50 + upadoh;
            upadoh += 5;

        }

        if (y < -200 || y > 200)
        {

            y = 0;

        }


        if (ugao < 1 || y > 89)
        {

            y = 45;

        }


        GameObject napad_clone = Instantiate(napad, new Vector3(x, 0, y), Quaternion.Euler(0, 180, 0)) as GameObject;
        napad_clone.name = "Attack" + nameNumber;
        napad_clone.SendMessage("setID", nameNumber);
        napad_clone.SendMessage("setHitX", x_gadja[nameNumber]);
        napad_clone.SendMessage("setHitY", y_gadja[nameNumber]);
        napad_clone.SendMessage("setX", x);
        napad_clone.SendMessage("setY", y);
        napad_clone.SendMessage("setAngle", ugao);
        nameNumber++;



    }
}