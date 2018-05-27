using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ScoreUI : MonoBehaviour {

    private Score score;
    public Dictionary<string, Text> scoreBoard;

    void Start() {
        scoreBoard = new Dictionary<string, Text>();        
        scoreBoard.Add("PlayerOne", transform.Find("PlayerOne").GetComponent<Text>());
        scoreBoard.Add("PlayerTwo", transform.Find("PlayerTwo").GetComponent<Text>());
        foreach(KeyValuePair<string,Text> playerScore in scoreBoard) {
            playerScore.Value.fontSize = Screen.height / 8;
        }
        score = FindObjectOfType<Score>();
        GetComponent<HorizontalLayoutGroup>().padding.top = Screen.height / 50;
        score.ScoreChanged += Score_ScoreChanged;
    }

    private void Score_ScoreChanged(string player, int score) {
        scoreBoard[player].text = score.ToString();
    }
}
