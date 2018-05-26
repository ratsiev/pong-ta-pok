using UnityEngine;
using System.Collections;
using System.Linq;

public class EventManager : MonoBehaviour {

    private Ball ball;
    private Bumper[] players;
    private Score score;

    void Start() {
        ball = FindObjectOfType<Ball>();
        players = FindObjectsOfType<Bumper>();
        score = FindObjectOfType<Score>();

        ball.TouchedWall += Ball_TouchedWall;
        ball.PassedThroughRing += Ball_PassedThroughRing;
        ball.StoppedMoving += Ball_StoppedMoving;
        players.ToList().ForEach(x => x.TouchedMiddleLine += Player_TouchedMiddleLine);
    }

    private void Player_TouchedMiddleLine(GameObject obj) {
        if (obj.tag == "PlayerOne")
            score.PlayerScored("PlayerTwo");
        else
            score.PlayerScored("PlayerOne");
    }

    private void Ball_StoppedMoving() {
        if (ball.OnRightSide())
            score.PlayerScored("PlayerOne");
        else
            score.PlayerScored("PlayerTwo");
    }

    private void Ball_PassedThroughRing(GameObject obj) {
        if (!ball.OnRightSide() && obj.tag == "PlayerOne")
            score.PlayerScored("PlayerOne");
        else if (ball.OnRightSide() && obj.tag == "PlayerTwo")
            score.PlayerScored("PlayerTwo");
    }

    private void Ball_TouchedWall(GameObject obj) {
        if (obj.tag == "PlayerOne")
            score.PlayerScored("PlayerOne");
        else
            score.PlayerScored("PlayerTwo");
    }

}
