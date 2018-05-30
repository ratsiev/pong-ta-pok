using System;
using UnityEngine;

public class BallEventArgs : EventArgs {

    public GameObject LastPlayerToTouchBall { get; private set; }
    public bool BallOnRightSide { get; private set; }

    public BallEventArgs(GameObject player, float ballPosition) {
        LastPlayerToTouchBall = player;
        BallOnRightSide = ballPosition > GameObject.FindGameObjectWithTag("MiddleLine").transform.position.x;
    }

}