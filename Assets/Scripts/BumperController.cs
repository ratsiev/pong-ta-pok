using UnityEngine;

public class BumperController : MonoBehaviour {
  
    private readonly int speed = 300;
    Rigidbody2D rig;

    void Awake() {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movement) {
        rig.velocity = movement * speed * Time.deltaTime;
    }
}