using UnityEngine;
using System.Collections;

public class ID : MonoBehaviour {
    private int x;
    private int  y;
    private int angle;
    private int id;
    private int hit_x;
    private int hit_y;

	// Use this for initialization
	void Start () {
	
	}
    void setX(int x1)
    {
        x = x1;
    }

    void setY(int y1)
    {
        y = y1;
    }

    void setAngle(int a)
    {
        angle = a;
    }

    void setID(int i)
    {
        id = i;
    }
    void setHitX(int i)
    {
        hit_x = i;
    }
    void setHitY(int i)
    {
        hit_y = i;
    }

}
