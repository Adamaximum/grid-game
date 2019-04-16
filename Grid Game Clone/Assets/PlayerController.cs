using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int XPos;
    public int YPos;

    public GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        XPos = Mathf.RoundToInt(transform.position.x);
        YPos = Mathf.RoundToInt(transform.position.y);

        if(ValTracker.moves > 0)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            temp = GridManager.gemGrid[YPos - 1, XPos];
            GridManager.gemGrid[YPos - 1, XPos] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(0, -1, 0);
            ValTracker.moves -= 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            temp = GridManager.gemGrid[YPos + 1, XPos];
            GridManager.gemGrid[YPos + 1, XPos] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(0, 1, 0);
            ValTracker.moves -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            temp = GridManager.gemGrid[YPos, XPos - 1];
            GridManager.gemGrid[YPos, XPos - 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(-1, 0, 0);
            ValTracker.moves -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            temp = GridManager.gemGrid[YPos, XPos + 1];
            GridManager.gemGrid[YPos, XPos + 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(1, 0, 0);
            ValTracker.moves -= 1;
        }
    }
}
