using UnityEngine;

public class Creator : MonoBehaviour {

    public GameObject ball;
    public GameObject wall;
    public GameObject bumper;
    public GameObject ring;
    public GameObject middleLine;

    private ScreenSize screen;

    void Awake() {
        screen = new ScreenSize(5);
    }

    public GameObject CreateMiddleLine(float lenght) {
        middleLine.transform.position = new Vector2(0, 0);
        middleLine.transform.localScale = new Vector3(0.1f, screen.height * lenght, 0.1f);
        return middleLine;
    }

    public GameObject CreateBall() {
        ball.transform.localScale = new Vector3(1 - screen.height / 3.5f, 1 - screen.height / 3.5f, 1 - screen.height / 3.5f);
        return ball;
    }

    public GameObject CreateBumper(bool right = true) {
        int multiplier = right ? 1 : -1;
        bumper.transform.localScale = new Vector3(0.4f, 1 - screen.height / 2.5f, 0.4f);
        bumper.transform.position = new Vector2((screen.width - screen.width / 4.5f) * multiplier, 0);
        return bumper;
    }

    public GameObject CreateRing(float position, bool up = true) {
        int multiplier = up ? 1 : -1;
        ring.transform.localScale = new Vector3(0.2f, 1 - screen.height / 3.2f, 0.8f);
        ring.transform.position = new Vector2(0, (screen.height - screen.height / position) * multiplier);
        return ring;
    }

    public GameObject CreateWall(string type, Vector2 position, float lenght, bool horizontal = true, bool vMult = true, bool hMult = true) {
        int verticalMultiplier = vMult ? 1 : -1;
        int horizontalMultiplier = hMult ? 1 : -1;
        float width = horizontal ? screen.width * lenght : 0.2f;
        float height = !horizontal ? screen.height * lenght : 0.2f;
        float yPosition = position.y == 0 ? 0 : (screen.height - screen.height / position.y) * verticalMultiplier;
        float xPosition = position.x == 0 ? 0 : (screen.width - screen.width / position.x) * horizontalMultiplier;
        wall.transform.localScale = new Vector3(width, height, 0.6f);
        wall.transform.position = new Vector2(xPosition, yPosition);
        return wall;
    }
}

public struct ScreenSize {
    public float width;
    public float height;

    public ScreenSize(int offset) {
        width = Camera.main.orthographicSize * Screen.width / Screen.height;
        height = Camera.main.orthographicSize;
        height -= height / offset;
    }
}
