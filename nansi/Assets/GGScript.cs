using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGScript : MonoBehaviour {
    private float ugao=45;
    private Vector3 x;
    private Vector3 pocetna_pozicija=new Vector3(0,0,0);
    private Vector3 cilj=new Vector3(0,0,0);
    private double time = 0;
    // Use this for initialization
    private double fuel_mass=1;
    private double ugasi=1.4;
    private double mass = 2;

    void Start()
    {
        Vector3 temp = new Vector3(cilj.x, Mathf.Tan(ugao / 360 * 2 * Mathf.PI) * Mathf.Sqrt(Mathf.Pow(cilj.x - pocetna_pozicija.x, 2) + Mathf.Pow(cilj.y - pocetna_pozicija.y, 2)), cilj.y);
        transform.LookAt(temp);
        x = new Vector3(cilj.x - pocetna_pozicija.x, Mathf.Tan(ugao / 360 * 2 * Mathf.PI) * Mathf.Sqrt(Mathf.Pow(cilj.x - pocetna_pozicija.x, 2) + Mathf.Pow(cilj.y - pocetna_pozicija.y, 2)), cilj.z - pocetna_pozicija.z);
        x.Normalize();

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = (float)mass;
        ugasi = kadDaUgasim();
        print(ugasi);
        GetComponent<Rigidbody>().AddForce(x, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        float temp = rb.mass;

        if (time < ugasi && temp > mass-fuel_mass)
        {
            temp -= (float)fuel_mass * Time.deltaTime / (float)2;
            rb.mass = temp;
            GetComponent<Rigidbody>().AddForce(x, ForceMode.Impulse);
        }
        transform.forward = GetComponent<Rigidbody>().velocity;
    }

    void setUgao(float i)
    {
        ugao = i;
    }
    void setPP(Vector3 pom)
    {
        pocetna_pozicija = pom;
    }
    void setCilj(Vector3 pom)
    {
        cilj = pom;
    }
    double kadDaUgasim()
    {
        double distance = Vector3.Distance(pocetna_pozicija, cilj);
        double g = 0.1605;
        double time = 0;
        double time_frame = 0.05;
        double sim_masa = mass;
        double Fx = x.x;
        double Fy = x.y-sim_masa*g;
        double Fz = x.z;

        double pos_x = pocetna_pozicija.x; 
        double pos_y = pocetna_pozicija.y;
        double pos_z = pocetna_pozicija.z;

        double a0x=Fx/sim_masa;
        double a0y=Fy/sim_masa;
        double a0z=Fz/sim_masa;

        double ax = Fx / sim_masa;
        double ay = Fy / sim_masa;
        double az = Fz / sim_masa;

        double vx = 0;
        double vy = 0;
        double vz = 0;

        double T=0;
        
        while (time<=2)
        {
            pos_x = time_frame * vx + (0.5 * Mathf.Pow((float)time_frame, 2) * ax);
            pos_y = time_frame * vy + (0.5 * Mathf.Pow((float)time_frame, 2) * ay);
            pos_z = time_frame * vz + (0.5 * Mathf.Pow((float)time_frame, 2) * az);

            a0x = ax;a0y = ay;a0z = az;

            Fx = x.x;
            Fy = x.y - sim_masa * g;
            Fz = x.z;

            ax = Fx / sim_masa;
            ay = Fy / sim_masa;
            az = Fz / sim_masa;

            double avx = (ax + a0x) / 2, avy = (ay + a0y) / 2, avz = (az + a0z) / 2;

            vx += avx * time_frame; vy += avy * time_frame; vz += avz * time_frame;
            T = 2 * vy / g + (-2 * vy + Mathf.Sqrt((float)(vy * vy - 8 * g * pos_y))) / (2 * g);
            print(T);
            print(Mathf.Sqrt((float)(vx * vx + vz * vz)) * T);
            if (Mathf.Sqrt((float)(vx *vx+vz*vz))*T>distance-Mathf.Sqrt((float)((pos_x-cilj.x)* (pos_x - cilj.x)+ (pos_x - cilj.x) * (pos_z - cilj.z))))
            {
                return time-time_frame;
            }
            sim_masa -= fuel_mass*(time_frame/2);
            time += time_frame;
        }


        return 2;
    }
}
