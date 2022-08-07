using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int Score = 0;
    public Text ScoreTxT;


    private void Start()
    {
        //ScoreTxT = GetComponent<Text>();
        ScoreTxT.text = Score.ToString();
    }

    public void ScoreHit()
    {
        Score = Score + 1;
        ScoreTxT.text = Score.ToString();
    }
}
