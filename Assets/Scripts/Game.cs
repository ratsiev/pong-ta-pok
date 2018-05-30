using UnityEngine;

public class Game : MonoBehaviour {

    private GameObject playerOne;
    private GameObject playerTwo;
    private GameObject ball;
    private Creator creator;
    private Score score;

    void Awake() {
        creator = FindObjectOfType<Creator>();
        ball = Instantiate(creator.CreateBall(), transform);

        if (!playerOne)
            playerOne = Instantiate(creator.CreatePlayer(false, true), transform);
        if (!playerTwo)
            if (PlayerPrefs.GetString("Players") == "OnePlayer")
                playerTwo = Instantiate(creator.CreatePlayer(true), transform); // computer
            else
                playerTwo = Instantiate(creator.CreatePlayer(false), transform); // human       
        score = FindObjectOfType<Score>();
        score.NextRound += Score_NextRound;
    }

    private void Start() {
        ServeBall(playerOne.GetComponent<Bumper>().initialPosition);
        score.MaxScoreReached += Score_MaxScoreReached;
    }

    private void Score_NextRound(string obj) {
        if (obj == "PlayerOne")
            ServeBall(playerOne.GetComponent<Bumper>().initialPosition);
        else
            ServeBall(playerTwo.GetComponent<Bumper>().initialPosition);
    }

    private void ServeBall(Vector3 position) {
        ball.GetComponent<Ball>().Serve(position);
    }

    private void Score_MaxScoreReached(string obj) {
        score.NextRound -= Score_NextRound;
        score.enabled = false;
        ball.GetComponent<Ball>().enabled = false;
        playerOne.GetComponent<Bumper>().ResetBumper(false);
        playerTwo.GetComponent<Bumper>().ResetBumper(false);
    }

}
