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
        ServeBall(playerOne);
        score.MaxScoreReached += Score_MaxScoreReached;
    }

    private void Score_NextRound(string obj) {
        if (obj == "PlayerOne")
            ServeBall(playerOne);
        else
            ServeBall(playerTwo);
    }

    private void ServeBall(GameObject player) {
        ball.GetComponent<Ball>().Serve(player.transform.position);
    }

    private void Score_MaxScoreReached(string obj) {
        score.NextRound -= Score_NextRound;
        score.enabled = false;
        ball.GetComponent<Ball>().enabled = false;
        playerOne.GetComponent<Bumper>().ResetBumper();
        playerTwo.GetComponent<Bumper>().ResetBumper();
        Debug.Log($"{obj} reached max score");
    }

}
