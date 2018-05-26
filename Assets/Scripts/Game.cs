using UnityEngine;

public class Game : MonoBehaviour {

    public delegate void PlayerScored(GameObject player);

    [HideInInspector] public GameObject playerOne;
    [HideInInspector] public GameObject playerTwo;
    [HideInInspector] public GameObject ball;
    private Creator creator;
    private GameObject servedPlayer;
    private Score score;

    void Awake() {
        creator = FindObjectOfType<Creator>();
        score = FindObjectOfType<Score>();
        ball = Instantiate(creator.CreateBall(), transform);
        if (!playerOne)
            playerOne = Instantiate(creator.CreatePlayer(false, true), transform);
        if (!playerTwo)
            if (PlayerPrefs.GetString("Players") == "OnePlayer")
                playerTwo = Instantiate(creator.CreatePlayer(true), transform); // computer
            else
                playerTwo = Instantiate(creator.CreatePlayer(false), transform); // human           
    }

    private void Start() {
        ServeBall(playerOne);
    }

    private void Update() {
        // if ball stops moving, destroy and instantiate again, the opponent of the player who let the ball stop wins a point, then serve the ball
        // if ball goes through ring, game ends and the one who scored wins
        // if ball touches outer walls, destroy and instantiate again, the opponent of the player who let the ball pass wins a point, then serve the ball
    }

    private void ServeBall(GameObject player) {
        ball.GetComponent<Ball>().Serve(player.transform.position);
        servedPlayer = player;
    }

}
