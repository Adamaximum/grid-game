using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValTracker : MonoBehaviour
{
    public static int score = 0;
    public static int moves = 6;

    public static bool gameOver = false;

    public TextMeshProUGUI scoreNum;
    public TextMeshProUGUI moveNum;

    public TextMeshProUGUI instruct;

    // Start is called before the first frame update
    void Start()
    {
        scoreNum = GameObject.Find("ScoreNum").GetComponent<TextMeshProUGUI>();
        moveNum = GameObject.Find("MoveNum").GetComponent<TextMeshProUGUI>();
        instruct = GameObject.Find("Instruct").GetComponent<TextMeshProUGUI>();

        moves = 6;

        //Debug.Log(movesInit);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            scoreNum.text = score.ToString();
            moveNum.text = moves.ToString();
        }

        if (moves == 0)
        {
            instruct.text = "\n\nYou have failed to ascend!\n\nFinal Score: "+score.ToString()+"\n\nPress R to Restart.\n\nPress Esc to Quit.";
            moves = 0;
            gameOver = true;
        }
    }
}
