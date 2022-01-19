using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private bool up = true;
    private int upNum = 0;
    private float eps = 1e-6f;

    private float yInit,yEnd;
    // Start is called before the first frame update
    void Start()
    {
        yInit = transform.position.y;
        yEnd = yInit + 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        var speedMov = 1.2f;
        var speedRotate=90.0f;
        var dt = Time.deltaTime;
        transform.Rotate(0,dt*speedRotate,0,Space.World);
        /*if (up)
        {
            transform.Translate(Vector3.up*dt*speedMov);
            if (transform.position.y > yEnd)
            {
                up = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up*dt*-speedMov);
            if (transform.position.y < yInit)
            {
                up = true;
            }
        }*/
        
    }
}
