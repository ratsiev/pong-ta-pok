using UnityEngine;

public class Computer : Bumper {

    private Vector2 movement;

    private GameObject ball;
    private BallPosition ballPosition;

    protected override void Start() {
        base.Start();
        controller = GetComponent<BumperController>();

        if (!ball)
            ball = GameObject.FindGameObjectWithTag("Ball");

        ballPosition = new BallPosition(ball.GetComponent<CircleCollider2D>().bounds.center, GetComponent<BoxCollider2D>().bounds.center);
    }

    private void Update() {
        ballPosition.Update(ball.transform.localPosition, transform.position);

        if (ball.GetComponent<Ball>().IsMoving()) {
            if (ball.GetComponent<Ball>().MovingRight()) {

                if (ballPosition.up)
                    Debug.Log("Up");
                else if (!ballPosition.up)
                    Debug.Log("Down");

                if (ballPosition.right)
                    Debug.Log("Right");
                else if (!ballPosition.right)
                    Debug.Log("Left");

            } else {
                GoToInitialPosition();
            }
        }
    }

    private void GoToInitialPosition() {
        controller.Move((initialPosition - transform.position).normalized);
    }

    public override void ResetBumper(bool enable) {
        base.ResetBumper(enable);
        enabled = enable;
    }

    private struct BallPosition {
        public bool up;
        public bool right;

        public BallPosition(Vector2 ballPosition, Vector2 computerPosition) {
            up = ballPosition.y >= computerPosition.y;
            right = ballPosition.x >= computerPosition.x;
        }

        public void Update(Vector2 ballPosition, Vector2 computerPosition) {
            up = ballPosition.y >= computerPosition.y;
            right = ballPosition.x >= computerPosition.x;
        }
    }

}
