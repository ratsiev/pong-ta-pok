using UnityEngine;

public class Game : MonoBehaviour {

    [HideInInspector] public GameObject playerOne;
    [HideInInspector] public GameObject playerTwo;
    [HideInInspector] public GameObject ball;
    private Creator objectCreator;
    private GameObject servedPlayer;

    void Awake() {
        objectCreator = GetComponent<Creator>();
        ball = Instantiate(objectCreator.CreateBall(), transform);
        if (!playerOne)
            playerOne = CreatePlayer(false, true);
        if (!playerTwo)
            if (PlayerPrefs.GetString("Players") == "OnePlayer")
                playerTwo = CreatePlayer(true); // computer
            else
                playerTwo = CreatePlayer(false); // human

        servedPlayer = playerOne;
    }

    private void Update() {
        // if ball stops moving, destroy and instantiate again, the opponent of the player who let the ball stop wins a point, then serve the ball
        // if ball goes through ring, game ends and the one who scored wins
        // if ball touches outer walls, destroy and instantiate again, the opponent of the player who let the ball pass wins a point, then serve the ball
    }

    private GameObject CreatePlayer(bool isComputer = false, bool isBumperOne = false) {
        GameObject player = isComputer ? objectCreator.CreateBumper(isComputer, !isBumperOne) : objectCreator.CreateBumper(false, !isBumperOne);
        if (!isComputer)
            player.GetComponent<Human>().isBumpOne = isBumperOne;
        return Instantiate(player, transform);
    }

    private void ServeBall() {
        if (servedPlayer == playerTwo)
            ball.GetComponent<Ball>().Serve(playerOne.transform.position);
        else
            ball.GetComponent<Ball>().Serve(playerTwo.transform.position);
    }

}
