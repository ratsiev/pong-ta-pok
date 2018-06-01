using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text mainText;
    public Button[] buttons;

    void Start() {
        mainText.fontSize = Screen.width / 8;
        buttons.ToList().ForEach(x => x.GetComponentInChildren<Text>().fontSize = Screen.width / 16);
    }

    public void SetPlayers(string players) {
        PlayerPrefs.SetString("Players", players);
        SceneManager.LoadScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }

}
