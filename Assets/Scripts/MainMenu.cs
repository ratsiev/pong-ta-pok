using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text mainText;
    public Button[] buttons;

    void Start() {
        mainText.fontSize = Screen.width / 8;
        foreach (Button button in buttons) {
            button.GetComponentInChildren<Text>().fontSize = Screen.width / 16;
        }
    }

    public void SetPlayers(string players) {
        PlayerPrefs.SetString("Players", players);
        SceneManager.LoadScene("Game");
    }

}
