using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int XPos;
    int YPos;

    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        XPos = Mathf.RoundToInt(transform.position.x);
        YPos = Mathf.RoundToInt(transform.position.y);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            temp = GridManager.gemGrid[YPos - 1, XPos];
            GridManager.gemGrid[YPos - 1, XPos] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            temp = GridManager.gemGrid[YPos + 1, XPos];
            GridManager.gemGrid[YPos + 1, XPos] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            temp = GridManager.gemGrid[YPos, XPos - 1];
            GridManager.gemGrid[YPos, XPos - 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            temp = GridManager.gemGrid[YPos, XPos + 1];
            GridManager.gemGrid[YPos, XPos + 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(1, 0, 0);
        }
    }
}
