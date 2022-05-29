using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Movement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 1;
    public float distanceTravelled;

    float yDifference = 0;
    bool moveDown = false;
    bool moveUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveUp = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveUp = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDown = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveDown = false;
        }

        if (moveUp && transform.position.y < 300.0f) {
            // adjust y position by 1
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
            yDifference += 0.02f;
        }
        else if (moveDown && transform.position.y > 1.0f) {
            // adjust y position by 1
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.02f, this.transform.position.z);
            yDifference -= 0.02f;
        }
        else {
            //float yPos = transform.position.y;
            var temp = pathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.position = new Vector3(temp.x, temp.y, temp.z);
        }
    }
}

// if the user does not press the up or down keys, the character will move along the path
// if the user presses the up key, the character will move along the path with the y position increased by 1
// if the user presses the down key, the character will move along the path with the y position decreased by 1
