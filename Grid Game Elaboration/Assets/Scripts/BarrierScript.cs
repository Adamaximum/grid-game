using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    public float chaseSpeed = 0.01f;

    public static float YPos;

    bool test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        YPos = transform.position.y;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    test = true;
        //}

        //if (test == true)
        //{
            transform.position += new Vector3(0, chaseSpeed, 0);
        //}
    }
}
