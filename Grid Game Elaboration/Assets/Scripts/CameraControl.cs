using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float camSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ValTracker.gameOver == false)
        {
            transform.position += new Vector3(0, camSpeed, 0);
        }

        camSpeed += 0.00001f;
    }
}
