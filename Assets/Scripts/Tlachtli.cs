using System.Collections.Generic;
using UnityEngine;

public class Tlachtli : MonoBehaviour {

    public Creator objectCreator;
    private readonly bool horizontal = true;
    private readonly bool yPosition = true;
    private readonly bool xPosition = true;

    void Start() {

        // Create outer walls
        Instantiate(objectCreator.CreateWall("OuterWall", new Vector2(0, 10), 1.9f, horizontal, yPosition, xPosition), transform);
        Instantiate(objectCreator.CreateWall("OuterWall", new Vector2(0, 9.9f), 1.9f, horizontal, !yPosition, xPosition), transform);
        Instantiate(objectCreator.CreateWall("OuterWall", new Vector2(25, 0), 1.84f, !horizontal, yPosition, !xPosition), transform);
        Instantiate(objectCreator.CreateWall("OuterWall", new Vector2(25, 0), 1.84f, !horizontal, yPosition, xPosition), transform);


        // Create slopes    
        Instantiate(objectCreator.CreateWall("Wall", new Vector2(0, 2.7f), 1.6f, horizontal, yPosition, xPosition), transform);
        Instantiate(objectCreator.CreateWall("Wall", new Vector2(0, 2.7f), 1.6f, horizontal, !yPosition, xPosition), transform);

        Instantiate(objectCreator.CreateWall("Wall", new Vector2(4.9f, 3.912f), 0.272f, !horizontal, yPosition, xPosition), transform);
        Instantiate(objectCreator.CreateWall("Wall", new Vector2(4.9f, 3.912f), 0.272f, !horizontal, yPosition, !xPosition), transform);
        Instantiate(objectCreator.CreateWall("Wall", new Vector2(4.9f, 3.912f), 0.272f, !horizontal, !yPosition, xPosition), transform);
        Instantiate(objectCreator.CreateWall("Wall", new Vector2(4.9f, 3.912f), 0.272f, !horizontal, !yPosition, !xPosition), transform);

        // Create rings
        Instantiate(objectCreator.CreateRing(2.28f, yPosition), transform);
        Instantiate(objectCreator.CreateRing(2.28f, !yPosition), transform);

        // Create middle line
        Instantiate(objectCreator.CreateMiddleLine(1.2f), transform);
    }

}
