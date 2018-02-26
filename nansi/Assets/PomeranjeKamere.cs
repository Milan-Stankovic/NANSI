using UnityEngine;
using System.Collections;

public class PomeranjeKamere : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //Set Cursor to not be visible
        
            
        Cursor.visible = true;
    }
    float X = 0;
    float Y = 0;

    void Update()
    {
        {
            int speed = 100;
         



            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(0, scroll * speed, 0);
      
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }

            
            if (Input.GetMouseButton(1))
            {

                            
               X += Input.GetAxis("Mouse X") * 100 * Time.deltaTime;
               Y += Input.GetAxis("Mouse Y") * 100 * Time.deltaTime;
               Y = Mathf.Clamp(Y, -45, 45);
                transform.localEulerAngles = new Vector3(-Y, X, 0);
            }



        }
    }



}