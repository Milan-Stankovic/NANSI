using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetDistance : MonoBehaviour {

    // Use this for initialization

    private float delay;
    private float distance;
    private List<GameObject> radarObjects;
    public List<float> udaljenost;

    void Start () {

        delay = GameObject.Find("Radar Camera").GetComponent<RadShow>().interval;
        distance = GameObject.Find("Radar Camera").GetComponent<RadShow>().switchDistance;
        InvokeRepeating("CalcDist", 0, delay);
    }
	
	// Update is called once per frame
    void CalcDist()
    {

        radarObjects = GameObject.Find("Radar Camera").GetComponent<RadShow>().radarObjects;
        udaljenost = new List<float>();
        foreach (GameObject m in radarObjects)
        {
            float dist = Vector3.Distance(m.transform.position, transform.position);
            udaljenost.Add(dist);

        }

    }
    


}
