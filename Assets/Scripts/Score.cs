using UnityEngine;
using System;
using System.Linq;

public class Score : MonoBehaviour {

    public event Action<string, int> ScoreChanged;
    public event Action<string> MaxScoreReached;

    public int maxScore = 5;
    private int playerOne = 0;
    private int playerTwo = 0;
    private GameObject ball;
    private Bumper[] players;

    private void Start() {
        ball = GameObject.FindGameObjectWithTag("Ball");
        players = FindObjectsOfType<Bumper>();
        ball.GetComponent<Ball>().TouchedWall += Ball_TouchedWall;
        ball.GetComponent<Ball>().StoppedMoving += Ball_StoppedMoving;
        ball.GetComponent<Ball>().PassedThroughRing += Ball_PassedThroughRing;
        players.ToList().ForEach(x => x.TouchedMiddleLine += Player_TouchedMiddleLine);
    }

    private void Player_TouchedMiddleLine(GameObject obj) {
        if (obj.tag == "PlayerOne")
            ScorePoint("PlayerTwo", ref playerTwo);
        else
            ScorePoint("PlayerOne", ref playerOne);

    }

    private void Ball_PassedThroughRing(object sender, BallEventArgs e) {
        if (!e.BallOnRightSide && e.LastPlayerToTouchBall.tag == "PlayerOne")
            ScorePoint(e.LastPlayerToTouchBall.tag, ref playerOne);
        else if (e.BallOnRightSide && e.LastPlayerToTouchBall.tag == "PlayerTwo")
            ScorePoint(e.LastPlayerToTouchBall.tag, ref playerTwo);

    }

    private void Ball_StoppedMoving(object sender, BallEventArgs e) {
        if (e.BallOnRightSide)
            ScorePoint("PlayerOne", ref playerOne);
        else
            ScorePoint("PlayerTwo", ref playerTwo);

    }

    private void Ball_TouchedWall(object sender, BallEventArgs e) {
        if (e.BallOnRightSide)
            ScorePoint("PlayerOne", ref playerOne);
        else
            ScorePoint("PlayerTwo", ref playerTwo);

    }

    private void ScorePoint(string player, ref int refScore) {
        ScoreChanged(player, ++refScore);
        if (refScore >= maxScore)
            MaxScoreReached(player);
    }
}
