using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiller : MonoBehaviour
{
    public static GameObject[] refillRow;
    public GameObject[] gemColors;

    // Start is called before the first frame update
    void Start()
    {
        refillRow = new GameObject[5];
        for (int x = 0; x < 5; x++)
        {
            refillRow[x] = gemColors[Random.Range(0, gemColors.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
