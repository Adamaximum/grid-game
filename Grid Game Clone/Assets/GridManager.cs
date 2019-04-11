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

    public GameObject[] gemColors;

    public static GameObject[,] gemGrid;

    public const int COLS = 5;
    public const int ROWS = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        gemGrid = new GameObject[ROWS, COLS];

        for (int x = 0; x < ROWS; x++)
        {
            for (int y = 0; y < COLS; y++)
            {
                if (x == 3 && y == 2)
                {
                    gemGrid[x, y] = player;
                    Instantiate(player, new Vector3(y, x), Quaternion.identity);
                }
                else
                {
                    gemGrid[x, y] = gemColors[Random.Range(0, gemColors.Length)];
                    Instantiate(gemGrid[x, y], new Vector3(y, x), Quaternion.identity);
                }

                
            }
        }

        //InstantiateGems();

        for (int x = 0; x < ROWS; x++)
        {
            for (int y = 0; y < COLS; y++)
            {
                if (y > 0 && y < 4)
                {
                    if ((gemGrid[x, y].tag == gemGrid[x, y + 1].tag) && (gemGrid[x, y].tag == gemGrid[x, y - 1].tag))
                    {
                        gemGrid[x, y] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[x, y + 1] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[x, y - 1] = gemColors[Random.Range(0, gemColors.Length)];
                    }
                }

                if (x > 0 && x < 6)
                {
                    if ((gemGrid[x, y].tag == gemGrid[x + 1, y].tag) && (gemGrid[x, y].tag == gemGrid[x - 1, y].tag))
                    {
                        gemGrid[x, y] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[x + 1, y] = gemColors[Random.Range(0, gemColors.Length)];
                        gemGrid[x - 1, y] = gemColors[Random.Range(0, gemColors.Length)];
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
    void Update()
    {
        for(int x = 0; x < ROWS; x++)
        {
            for(int y = 0; y < COLS; y++)
            {

            }
        }
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
