using UnityEngine;

/// <summary>
/// modulize screen wrap functionality so it can be attached to any
/// gameobject, a quick way off adding screen wrapping to objects that need this functionality
/// </summary>
public class ScreenWrap : MonoBehaviour
{

    //constaints value left, right, top, bottom 
    private float[] constraints = new float[4];

    // buffer for how far the ship is off the screen before it appears on the other side
    private float buffer = 1.0f;

    // the constane Z-axis distance from the screen
    private float distance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // detect and calculate the screen constraints
        // left 
        constraints[0] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distance)).x;
        // right
        constraints[1] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distance)).x;

        // up
        constraints[2] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distance)).y;
        // down
        constraints[3] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distance)).y;

    }

    /// <summary>
    /// Method wrap the game object around the screen
    /// </summary>
    private void WrapScreen()
    {

        // wrap the left and right sides of the screen
        if (transform.position.x < constraints[0] - buffer)
            transform.position = new Vector3(constraints[1] + buffer, transform.position.y);

        if (transform.position.x > constraints[1] + buffer)
            transform.position = new Vector3(-constraints[1] - buffer, transform.position.y);


        // wrap the top and bottom sides of the screen
        if (transform.position.y < constraints[2] - buffer)
            transform.position = new Vector3(transform.position.x, constraints[3] + buffer);

        if (transform.position.y > constraints[3] + buffer)
            transform.position = new Vector3(transform.position.x, -constraints[3] - buffer);

    }

    /// <summary>
    /// set the buffer distance for the screen wrap
    /// </summary>
    public float SetBuffer
    {
        set
        {
            buffer = value;
        }
    }

    // call wrap screen function
    void Update()
    {
        WrapScreen();
    }
}
