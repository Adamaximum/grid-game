using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject gem0;
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;
    public GameObject gem5;
    public GameObject player;
    public GameObject empty;

    public GameObject particles;

    public GameObject[] gemColors;

    public GameObject tempGem;

    public static GameObject[,] gemGrid;

    public int COLS = 5;
    public int ROWS = 7;

    AudioSource matchSound;
    
    // Start is called before the first frame update
    void Start()
    {
        matchSound = gameObject.GetComponent<AudioSource>();

        gemGrid = new GameObject[ROWS, COLS];

        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (y == 3 && x == 2)
                {
                    gemGrid[y, x] = player;
                    Instantiate(player, new Vector3(x, y), Quaternion.identity);
                }
                else
                {
                    gemGrid[y, x] = gemColors[Random.Range(0, gemColors.Length)];
                    Instantiate(gemGrid[y, x], new Vector3(x, y), Quaternion.identity);
                }
            }
        }
        CheckMatchStart();
        StartCoroutine("GridFaller");
    }

    void CheckMatchStart()
    {
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (x > 0 && x < COLS - 1) //Columns: blocks left or right
                {
                    if ((gemGrid[y, x].tag == gemGrid[y, x + 1].tag) && (gemGrid[y, x].tag == gemGrid[y, x - 1].tag))
                    {
                        gemGrid[y, x] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y, x + 1] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y, x - 1] = gemColors[Random.Range(0, gemColors.Length)];

                        Refresher.isRefreshing = true;
                    }
                }

                if (y > 0 && y < ROWS - 1) //Rows: blocks up or down
                {
                    if ((gemGrid[y, x].tag == gemGrid[y + 1, x].tag) && (gemGrid[y, x].tag == gemGrid[y - 1, x].tag))
                    {
                        gemGrid[y, x] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y + 1, x] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y - 1, x] = gemColors[Random.Range(0, gemColors.Length)];

                        Refresher.isRefreshing = true;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckMatchUpdate();

        RefreshRow();

        if (Refresher.isRefreshing)
        {
            RefreshGrid();
        }
    }

    IEnumerator GridFaller()
    {
        GridFall();
        yield return new WaitForSeconds(.25f);
        StartCoroutine("GridFaller");
    }

    void CheckMatchUpdate()
    {
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (x > 0 && x < COLS - 1) //X Values
                {
                    if ((gemGrid[y, x].tag == gemGrid[y, x + 1].tag) && (gemGrid[y, x].tag == gemGrid[y, x - 1].tag) && (gemGrid[y, x].tag != "empty"))
                    {
                        ValTracker.moves = 6;
                        ValTracker.score += 3;

                        Instantiate(particles, new Vector3(x, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x + 1, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x - 1, y), Quaternion.identity);

                        matchSound.Play();

                        if (x == 1) //Column 1
                        {
                            if (gemGrid[y, x].tag == gemGrid[y, x + 2].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y, x + 2] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y, x + 3].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y, x + 3] = empty;
                                }
                            }
                        }
                        if (x == 2) //Column 2
                        {
                            if (gemGrid[y, x].tag == gemGrid[y, x + 2].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y, x + 2] = empty;
                            }
                            if (gemGrid[y, x].tag == gemGrid[y, x - 2].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y, x - 2] = empty;
                            }
                        }
                        if (x == 3) //Column 3
                        {
                            if (gemGrid[y, x].tag == gemGrid[y, x - 2].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y, x - 2] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y, x - 3].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y, x - 3] = empty;
                                }
                            }
                        }
                        gemGrid[y, x] = empty;
                        gemGrid[y, x + 1] = empty;
                        gemGrid[y, x - 1] = empty;
                    }
                }

                if (y > 0 && y < ROWS - 1) //Y Values
                {
                    if ((gemGrid[y, x].tag == gemGrid[y + 1, x].tag) && (gemGrid[y, x].tag == gemGrid[y - 1, x].tag) && (gemGrid[y, x].tag != "empty"))
                    {
                        ValTracker.moves = 6;
                        ValTracker.score += 3;

                        Instantiate(particles, new Vector3(x, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x, y + 1), Quaternion.identity);
                        Instantiate(particles, new Vector3(x, y - 1), Quaternion.identity);

                        matchSound.Play();

                        if (y == 1) //Row 1
                        {
                            if (gemGrid[y, x].tag == gemGrid[y + 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y + 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y + 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y + 3, x] = empty;

                                    if (gemGrid[y, x].tag == gemGrid[y + 4, x].tag)
                                    {
                                        ValTracker.score += 1;
                                        gemGrid[y + 4, x] = empty;

                                        if (gemGrid[y, x].tag == gemGrid[y + 5, x].tag)
                                        {
                                            ValTracker.score += 1;
                                            gemGrid[y + 5, x] = empty;
                                        }
                                    }
                                }
                            }
                        }

                        if (y == 2) //Row 2
                        {
                            if (gemGrid[y, x].tag == gemGrid[y + 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y + 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y + 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y + 3, x] = empty;

                                    if (gemGrid[y, x].tag == gemGrid[y + 4, x].tag)
                                    {
                                        ValTracker.score += 1;
                                        gemGrid[y + 4, x] = empty;
                                    }
                                }
                            }
                            if (gemGrid[y, x].tag == gemGrid[y - 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y - 2, x] = empty;
                            }
                        }

                        if (y == 3) //Row 3
                        {
                            if (gemGrid[y, x].tag == gemGrid[y + 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y + 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y + 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y + 3, x] = empty;
                                }
                            }
                            if (gemGrid[y, x].tag == gemGrid[y - 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y - 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y - 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y - 3, x] = empty;
                                }
                            }
                        }

                        if (y == 4) //Row 4
                        {
                            if (gemGrid[y, x].tag == gemGrid[y + 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y + 2, x] = empty;
                            }

                            if (gemGrid[y, x].tag == gemGrid[y - 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y - 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y - 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y - 3, x] = empty;

                                    if (gemGrid[y, x].tag == gemGrid[y - 4, x].tag)
                                    {
                                        ValTracker.score += 1;
                                        gemGrid[y - 4, x] = empty;
                                    }
                                }
                            }
                        }

                        if (y == 5) //Row 5
                        {
                            if (gemGrid[y, x].tag == gemGrid[y - 2, x].tag)
                            {
                                ValTracker.score += 1;
                                gemGrid[y - 2, x] = empty;

                                if (gemGrid[y, x].tag == gemGrid[y - 3, x].tag)
                                {
                                    ValTracker.score += 1;
                                    gemGrid[y - 3, x] = empty;

                                    if (gemGrid[y, x].tag == gemGrid[y - 4, x].tag)
                                    {
                                        ValTracker.score += 1;
                                        gemGrid[y - 4, x] = empty;

                                        if (gemGrid[y, x].tag == gemGrid[y - 5, x].tag)
                                        {
                                            ValTracker.score += 1;
                                            gemGrid[y - 5, x] = empty;
                                        }
                                    }
                                }
                            }
                        }

                        gemGrid[y, x] = empty;
                        gemGrid[y + 1, x] = empty;
                        gemGrid[y - 1, x] = empty;
                    }
                }
            }
        }
    }

    void GridFall()
    {
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (y > 0)
                {
                    if (gemGrid[y - 1, x].tag == "empty" && gemGrid[y, x].tag != "empty" && gemGrid[y, x].tag != "Player")
                    {
                        tempGem = gemGrid[y, x];
                        gemGrid[y, x] = gemGrid[y - 1, x];
                        gemGrid[y - 1, x] = tempGem;
                    }
                }
            }
        }
    }

    void RefreshRow()
    {
        for (int x = 0; x < COLS; x++)
        {
            if (gemGrid[ROWS - 1, x].tag == "empty")
            {
                gemGrid[ROWS - 1, x] = gemColors[Random.Range(0, gemColors.Length)];
            }
        }
    }

    void RefreshGrid()
    {
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (gemGrid[y,x].tag == "Player")
                {

                }
                else
                {
                    Instantiate(gemGrid[y, x], new Vector3(x, y), Quaternion.identity);
                }
            }
        }
        Refresher.isRefreshing = false;
    }
}
//ATD, you the real MVP.