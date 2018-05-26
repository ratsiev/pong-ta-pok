using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text playerOne;
    public Text playerTwo;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    void Start() {       
        playerOne.fontSize = Screen.height / 8;
        playerTwo.fontSize = Screen.height / 8;
        GetComponent<HorizontalLayoutGroup>().padding.top = Screen.height / 50;
        UpdateScoreText();
    }

    public void PlayerScored(string player) {
        if (player == "PlayerOne")
            playerOneScore++;
        else
            playerTwoScore++;
        UpdateScoreText();
    }


    private void UpdateScoreText() {
        playerOne.text = playerOneScore.ToString();
        playerTwo.text = playerTwoScore.ToString();
    }

}
