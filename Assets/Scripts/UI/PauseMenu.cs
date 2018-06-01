using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Text mainText;
    public Button[] buttons;
    public Canvas menu;

    void Start() {
        menu.enabled = false;
        GetComponent<VerticalLayoutGroup>().padding.top = Screen.height / 9;
        menu.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width / 4, Screen.height / 2.5f);
        mainText.fontSize = (int)(menu.GetComponent<Image>().rectTransform.sizeDelta.x / 8);
        buttons.ToList().ForEach(x => x.GetComponentInChildren<Text>().fontSize = (int)(menu.GetComponent<Image>().rectTransform.sizeDelta.x / 10));
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
            menu.enabled = TogglePause();
    }

    public void ResumeGame() {
        menu.enabled = TogglePause();
    }

    public void MainMenu() {
        SceneManager.LoadScene("Main Title");
    }

    public void ExitGame() {
        Application.Quit();
    }

    private bool TogglePause() {
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            return false;
        } else {
            Time.timeScale = 0f;
            return true;
        }
    }


}
