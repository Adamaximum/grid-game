using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public const int COLS = 5;
    public const int ROWS = 7;
    int[,] _gems = new int[COLS,ROWS];
    public GameObject _gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //_gems[0,0] = 0;
        //_gems[0, 1] = 7;
        //_gems[0, 2] = 9;
        //_gems[1, 0] = 7;

        for (int x = 0; x < COLS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                int color = Random.Range(0, 6);
                _gems[x, y] = color;
            }
        }

        InstantiateGems();
    }

    void InstantiateGems()
    {
        for (int x = 0; x < COLS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                Debug.Log("Gem " + x + "," + y + ": " + _gems[x, y]);
                GameObject gem = GameObject.Instantiate(_gemPrefab);
                gem.transform.position = new Vector3((x-3)*1.5f, (y-1)*-1.5f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
