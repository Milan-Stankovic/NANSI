using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadShow : MonoBehaviour
{

   
    public GameObject radarPrefab;
    List<GameObject> farObjects;
    public float switchDistance;
    public List<GameObject> radarObjects;
    public float interval;

    // Use this for initialization
    void Start()
    {
         
        radarObjects = new List<GameObject>();
        farObjects = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < radarObjects.Count; i++)
        {
            if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
            {
                farObjects[i].layer = LayerMask.NameToLayer("RadarL");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisi");
            }
            else
            {
                //switch back to radarObjects
                farObjects[i].layer = LayerMask.NameToLayer("Invisi");
                radarObjects[i].layer = LayerMask.NameToLayer("RadarL");
            }
        }
    }

    void addRadarObjects(GameObject m) // GRBA MORAS OVO POZVATI SA SEND MESSAGE CIM TI SE LANSIRA NEKA RAKETA PRIMER SEND MESSAGE-a imas u dodaj objekte
    {
       
            GameObject k = Instantiate(radarPrefab, m.transform.position, Quaternion.identity) as GameObject;
            radarObjects.Add(k);
            GameObject j = Instantiate(radarPrefab, m.transform.position, Quaternion.identity) as GameObject;
            farObjects.Add(j);
        
    }

    void removeRadarObjects(GameObject m) // A OVO MORAS POZVATI KADA SE UNISTI
    {

        radarObjects.Remove(m);
        farObjects.Remove(m);

    }

    void removeRadarObject()
    {




    }
}