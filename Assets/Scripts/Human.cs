using UnityEngine;

public class Human : Bumper {

    public bool isBumpOne;
    protected override void Start() {
        base.Start();
        controller = GetComponent<BumperController>();
    }

    void Update() {
        if (isBumpOne)
            controller.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        else
            controller.Move(new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")));

    }

}