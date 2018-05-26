using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody2D rig;

    public GameObject LastToTouch { get; private set; }

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (!IsMoving())
            Debug.Log("NotMoving");
    }

    public bool IsMoving() {
        return !rig.IsSleeping();
    }

    public bool MovingRight() {
        return rig.velocity.x > 0;
    }

    public bool MovingUp() {
        return rig.velocity.y > 0;
    }

    public void Serve(Vector3 target) {
        rig.velocity = (target - transform.position).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Bumper>())
            LastToTouch = collision.gameObject;
        if (collision.collider.tag == "OuterWall")
            Debug.Log("Touched outer wall");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Ring" && GotThroughRing(collision.bounds))
            Debug.Log("Passed through ring");
    }

    private bool GotThroughRing(Bounds ringBounds) {
        Bounds ball = GetComponent<CircleCollider2D>().bounds;
        ringBounds = new Bounds(ringBounds.center, new Vector3(0.1f, ringBounds.size.y, ringBounds.size.z));
        return (ball.max.y < ringBounds.max.y && ball.min.y > ringBounds.min.y) && (ball.center.x > ringBounds.center.x || ball.center.x < ringBounds.center.x);
    }

}
