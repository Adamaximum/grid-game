using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    //public GridManager gm;

    //public SpriteRenderer _gemSR;

    //public Color[] rainbow;

    //public int randColor;

    int XPos;
    int YPos;
    
    public GameObject empty;

    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GridManager").GetComponent<GridManager>();
        //_gemSR = gameObject.GetComponent<SpriteRenderer>();

        //randColor = Random.Range(0, 6);

        //rainbow = new Color[6];

        //rainbow[0] = new Color(0.5803922f, 0, 0.827451f); //Violet
        //rainbow[1] = new Color(0, 0, 1); //Blue
        //rainbow[2] = new Color(0, 1, 0); //Green
        //rainbow[3] = new Color(1, 1, 0); //Yellow
        //rainbow[4] = new Color(1, 0.4980392f, 0); //Orange
        //rainbow[5] = new Color(1, 0, 0); //Red

        //_gemSR.color = rainbow[randColor];
    }

    // Update is called once per frame
    void Update()
    {
        XPos = Mathf.RoundToInt(transform.position.x);
        YPos = Mathf.RoundToInt(transform.position.y);

        StartCoroutine("ClearGrid");
    }

    IEnumerator ClearGrid()
    {
        yield return new WaitForSeconds(.0f);
        Refresher.isRefreshing = true;
        Destroy(this.gameObject);
    }
}
