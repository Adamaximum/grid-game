using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public const int COLS = 5;
    public const int ROWS = 3;
    int[,] _gems = new int[COLS,ROWS];
    public GameObject _gemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _gems[0,0] = 0;
        _gems[0, 1] = 7;
        _gems[0, 2] = 9;
        _gems[1, 0] = 7;

        for (int x = 0; x < COLS; x++)
        {
            for (int y = 0; y < ROWS; y++)
            {
                int color = Random.Range(0, 9);
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
                gem.transform.position = new Vector3(x, y, 0)*2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
