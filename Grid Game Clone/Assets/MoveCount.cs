using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCount : MonoBehaviour
{
    public TextMeshPro moveNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveNum.text = ValTracker.moves.ToString();

        if(ValTracker.moves <= 2)
        {
            moveNum.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            moveNum.color = new Color32(0, 0, 0, 255);
        }
    }
}
