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

    GameObject tempGem;

    public static GameObject[,] gemGrid;

    public const int COLS = 5;
    public const int ROWS = 7;
    
    // Start is called before the first frame update
    void Start()
    {
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
        //InstantiateGems();
        StartCoroutine("GridFaller");
    }

    void CheckMatchStart()
    {
        for (int y = 0; y < ROWS; y++)
        {
            for (int x = 0; x < COLS; x++)
            {
                if (x > 0 && x < 4)
                {
                    if ((gemGrid[y, x].tag == gemGrid[y, x + 1].tag) && (gemGrid[y, x].tag == gemGrid[y, x - 1].tag))
                    {
                        gemGrid[y, x] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y, x + 1] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[y, x - 1] = gemColors[Random.Range(0, gemColors.Length)];

                        Refresher.isRefreshing = true;
                    }
                }

                if (y > 0 && y < 6)
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

    //void InstantiateGems()
    //{
    //    for (int x = 0; x < COLS; x++)
    //    {
    //        for (int y = 0; y < ROWS; y++)
    //        {
    //            Debug.Log("Gem " + x + "," + y + ": " + _gemGrid[x, y]);
    //            GameObject gem = GameObject.Instantiate(_gemPrefab);
    //            gem.transform.position = new Vector3((x-3)*1.5f, (y-1)*-1.5f, 0);
    //        }
    //    }
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        CheckMatchUpdate();

        //GridFall();

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
                if (x > 0 && x < 4)
                {
                    if ((gemGrid[y, x].tag == gemGrid[y, x + 1].tag) && (gemGrid[y, x].tag == gemGrid[y, x - 1].tag) && (gemGrid[y, x].tag != "empty"))
                    {
                        ValTracker.moves = 6;
                        ValTracker.score += 3;

                        Instantiate(particles, new Vector3(x, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x + 1, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x - 1, y), Quaternion.identity);

                        if (x == 1)
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
                        if (x == 2)
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
                        if (x == 3)
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
                if (y > 0 && y < 6)
                {
                    if ((gemGrid[y, x].tag == gemGrid[y + 1, x].tag) && (gemGrid[y, x].tag == gemGrid[y - 1, x].tag) && (gemGrid[y, x].tag != "empty"))
                    {
                        ValTracker.moves = 6;
                        ValTracker.score += 3;

                        Instantiate(particles, new Vector3(x, y), Quaternion.identity);
                        Instantiate(particles, new Vector3(x, y + 1), Quaternion.identity);
                        Instantiate(particles, new Vector3(x, y - 1), Quaternion.identity);

                        if (y == 1)
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

                        if (y == 2)
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

                        if (y == 3)
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

                        if (y == 4)
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

                        if (y == 5)
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
            if (gemGrid[6, x].tag == "empty")
            {
                gemGrid[6, x] = gemColors[Random.Range(0, gemColors.Length)];
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
    //The demo code that doesn't work out of context

    //public void MakeGemsFall()
    //{
    //    for(int width = COLS-1; width>=0; width--)
    //    {
    //        for (int height = ROWS - 1; height >= 0; height--)
    //        {
    //            GameObject currentToken = tokens[width, height];
    //            int distance = 0;

    //            do
    //            {
    //                distance++;
    //                destination = tokens[width, height + distance];
    //            }
    //            while (destination == null);

    //            tokens[width, height] = null;
    //            tokens[width, height + distance] = currentToken;
    //        }
    //    }
    //}

    //int CheckColumn(GameObject currentCell, int width, int height)
    //{
    //    List<GameObject> matches = new List<GameObject>();
    //    for (int tempRow = height+1; tempRow < ROWS; height++)
    //    {
    //        GameObject tempCell = tokens[width, tempRow];
    //        if (tempCell.color == currentCell.color)
    //        {
    //            matches.Add(tempCell);
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }

    //    if (matches.Count > 3)
    //    {
    //        //do matching stuff
    //    }
    //}

    

    //public void CheckForMatches()
    //{
    //    GameObject currentCell;
    //    for(int width = 0; width <COLS; width++)
    //    {
    //        for (int height = 0; height < ROWS; height++)
    //        {
    //            currentCell tokens[COLS, ROWS];
    //            tempList = CheckColumn(currentCell, width, height);

    //            foreach (GameObject go in tempList)
    //            {
    //                gemsToDestroy.Add(go);
    //            }
    //        }
    //    }
    //}
}
