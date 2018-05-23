using UnityEngine;

public class Game : MonoBehaviour {

    [HideInInspector] public GameObject playerOne;
    [HideInInspector] public GameObject playerTwo;
    [HideInInspector] public GameObject ball;
    private Creator objectCreator;

    void Start() {
        objectCreator = GetComponent<Creator>();
        playerOne = objectCreator.CreateBumper(false);
        playerOne.GetComponent<BumperController>().isBumpOne = true;
        playerOne.AddComponent<Player>();
        Instantiate(playerOne, transform);
        ball = Instantiate(objectCreator.CreateBall(), transform);
    }

}
