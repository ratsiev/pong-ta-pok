using UnityEngine;

public class Game : MonoBehaviour {

    [HideInInspector] public GameObject playerOne;
    [HideInInspector] public GameObject playerTwo;
    [HideInInspector] public GameObject ball;
    private Creator creator;
    private Score score;

    void Awake() {
        creator = FindObjectOfType<Creator>();
        ball = Instantiate(creator.CreateBall(), transform);
        ball.GetComponent<Ball>().TouchedWall += Game_TouchedWall;
        ball.GetComponent<Ball>().StoppedMoving += Game_StoppedMoving;

        if (!playerOne)
            playerOne = Instantiate(creator.CreatePlayer(false, true), transform);
        if (!playerTwo)
            if (PlayerPrefs.GetString("Players") == "OnePlayer")
                playerTwo = Instantiate(creator.CreatePlayer(true), transform); // computer
            else
                playerTwo = Instantiate(creator.CreatePlayer(false), transform); // human       
        score = FindObjectOfType<Score>();
    }

    private void Start() {
        ServeBall(playerOne);
        score.MaxScoreReached += Score_MaxScoreReached;
    }

    private void Update() {
        // if ball stops moving, destroy and instantiate again, the opponent of the player who let the ball stop wins a point, then serve the ball
        // if ball goes through ring, game ends and the one who scored wins
        // if ball touches outer walls, destroy and instantiate again, the opponent of the player who let the ball pass wins a point, then serve the ball
    }

    private void ServeBall(GameObject player) {
        ball.GetComponent<Ball>().Serve(player.transform.position);
    }

    private void Score_MaxScoreReached(string obj) {
        Debug.Log($"{obj} reached max score");
    }

    private void Game_StoppedMoving(object sender, BallEventArgs e) {
        Debug.Log("Ball stopped moving");
    }

    private void Game_TouchedWall(object sender, BallEventArgs e) {
        Debug.Log($"{e.LastPlayerToTouchBall.tag} scored a point");
    }

}
