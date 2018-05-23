using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 5f;
    private Rigidbody2D rig;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

}
