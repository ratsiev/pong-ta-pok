using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour {

    public Button playAgain;
    public Button reset;
    private int multiplier = 1;
    public Canvas menu;
    private Score score;

    void Start() {
        score = FindObjectOfType<Score>();
        score.MaxScoreReached += Score_MaxScoreReached;
        menu.enabled = false;
        transform.Find("Menu").transform.Find("MainText").GetComponent<Text>().fontSize = Screen.height / 5;
        playAgain.GetComponentInChildren<Text>().fontSize = Screen.height / 30;
        reset.GetComponentInChildren<Text>().fontSize = Screen.height / 30;
        GetComponent<HorizontalLayoutGroup>().padding.bottom = Screen.height / 4;
        GetComponent<HorizontalLayoutGroup>().padding.right = Screen.width / 3;
    }

    private void Score_MaxScoreReached(string winner) {       
        if (winner == "PlayerOne")
            multiplier = 1;
        else
            multiplier = -1;
        GetComponent<HorizontalLayoutGroup>().padding.right = Screen.width / 3 * multiplier;
        menu.enabled = true;
    }

    public void ButtonClicked(string scene) {
        SceneManager.LoadScene(scene);
    }

}
