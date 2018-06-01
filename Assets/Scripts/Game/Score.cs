using UnityEngine;
using System;
using System.Linq;

public class Score : MonoBehaviour {

    public event Action<string, int> ScoreChanged;
    public event Action<string> MaxScoreReached;
    public event Action<string> NextRound;
    public readonly int maxScore = 10;
    private int playerOne = 0;
    private int playerTwo = 0;
    private GameObject ball;
    private Bumper[] players;

    private void Start() {
        ball = GameObject.FindGameObjectWithTag("Ball");
        players = FindObjectsOfType<Bumper>();
        ball.GetComponent<Ball>().StoppedMoving += Ball_StoppedMoving;
        ball.GetComponent<Ball>().PassedThroughRing += Ball_PassedThroughRing;
        players.ToList().ForEach(x => x.TouchedMiddleLine += Player_TouchedMiddleLine);
    }

    private void Player_TouchedMiddleLine(GameObject obj) {
        if (obj.tag == "PlayerOne")
            ScorePoint("PlayerTwo", ++playerTwo);
        else
            ScorePoint("PlayerOne", ++playerOne);
    }

    private void Ball_PassedThroughRing(object sender, BallEventArgs e) {
        if (!e.BallOnRightSide && e.LastPlayerToTouchBall.tag == "PlayerOne")
            ScorePoint(e.LastPlayerToTouchBall.tag, playerOne = maxScore);
        else if (e.BallOnRightSide && e.LastPlayerToTouchBall.tag == "PlayerTwo")
            ScorePoint(e.LastPlayerToTouchBall.tag, playerTwo = maxScore);

    }

    private void Ball_StoppedMoving(object sender, BallEventArgs e) {
        if (e.BallOnRightSide) {
            ScorePoint("PlayerOne", ++playerOne);
            NextRound?.Invoke("PlayerOne");
        } else {
            ScorePoint("PlayerTwo", ++playerTwo);
            NextRound?.Invoke("PlayerTwo");
        }
    }

    private void ScorePoint(string player, int refScore) {
        ScoreChanged?.Invoke(player, refScore);
        if (refScore >= maxScore) {
            ball.GetComponent<Ball>().StoppedMoving -= Ball_StoppedMoving;
            ball.GetComponent<Ball>().PassedThroughRing -= Ball_PassedThroughRing;
            MaxScoreReached?.Invoke(player);
        }
    }
}
