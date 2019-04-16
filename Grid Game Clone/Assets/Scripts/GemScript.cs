using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    int XPos;
    int YPos;
    
    public GameObject empty;

    // Start is called before the first frame update
    void Start()
    {
        
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
