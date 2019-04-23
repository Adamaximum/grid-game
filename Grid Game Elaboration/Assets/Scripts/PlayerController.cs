using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GridManager gm;
    CameraControl cc;
    ValTracker vt;

    int XPos;
    int YPos;

    public GameObject temp;

    AudioSource moveSound;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GridManager").GetComponent<GridManager>();
        cc = GameObject.Find("Main Camera").GetComponent<CameraControl>();
        vt = GameObject.Find("GridManager").GetComponent<ValTracker>();

        moveSound = gameObject.GetComponent<AudioSource>();

        StartCoroutine("PlayerFaller");
    }

    // Update is called once per frame
    void Update()
    {
        XPos = Mathf.RoundToInt(transform.position.x);
        YPos = Mathf.RoundToInt(transform.position.y);

        if (ValTracker.moves > 0 && YPos < 29)
        {
            MovePlayer();
        }

        if(cc.transform.position.y >= YPos + 3 || cc.transform.position.y <= YPos - 3)
        {
            ValTracker.moves = 0;
        }

        if (YPos == 29)
        {
            ValTracker.gameOver = true;
            vt.instruct.text = "\n\nYou have ascended!\n\nFinal Score: " + ValTracker.score.ToString() + "\n\nPress R to Restart.\n\nPress Esc to Quit.";
        }
    }

    IEnumerator PlayerFaller()
    {
        PlayerFall();
        yield return new WaitForSeconds(.25f);
        StartCoroutine("PlayerFaller");
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

            moveSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            temp = GridManager.gemGrid[YPos + 1, XPos];
            GridManager.gemGrid[YPos + 1, XPos] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(0, 1, 0);
            ValTracker.moves -= 1;

            moveSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            temp = GridManager.gemGrid[YPos, XPos - 1];
            GridManager.gemGrid[YPos, XPos - 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(-1, 0, 0);
            ValTracker.moves -= 1;

            moveSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            temp = GridManager.gemGrid[YPos, XPos + 1];
            GridManager.gemGrid[YPos, XPos + 1] = this.gameObject;
            GridManager.gemGrid[YPos, XPos] = temp;
            transform.position += new Vector3(1, 0, 0);
            ValTracker.moves -= 1;

            moveSound.Play();
        }
    }

    void PlayerFall()
    {
        for (int y = 0; y < gm.ROWS; y++)
        {
            for (int x = 0; x < gm.COLS; x++)
            {
                if (y > 0)
                {
                    if (GridManager.gemGrid[y - 1, x].tag == "empty" && GridManager.gemGrid[y, x].tag == "Player")
                    {
                        temp = GridManager.gemGrid[YPos - 1, XPos];
                        GridManager.gemGrid[YPos - 1, XPos] = this.gameObject;
                        GridManager.gemGrid[YPos, XPos] = temp;
                        transform.position += new Vector3(0, -1, 0);
                    }
                }
            }
        }
    }
}
