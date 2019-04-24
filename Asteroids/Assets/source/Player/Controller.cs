using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotaton = 5.0f;
    public float bulletSpeed = 125.0f;

    Vector2 moveDir;
    Vector2 rotatonDir;
    Rigidbody2D rBody;
    
    private void Start()
    {
        if (gameObject != null)
            rBody = GetComponent<Rigidbody2D>();

        //  initialize laser object
        Utilities.Instance.CreateGameObject("laser", "prefab/player/laser");
    }

    private void Update()
    {
        moveDir = Vector2.zero;
        rotatonDir = Vector2.zero;

        // ship movement ship with arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
            moveDir.y += 1;

        if (Input.GetKey(KeyCode.DownArrow))
            moveDir.y -= 1;

        if (Input.GetKey(KeyCode.RightArrow))
            moveDir.x += 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveDir.x -= 1;


        // rotate the ship left and right with A and D
        if (Input.GetKey(KeyCode.A))
            rotatonDir.x -= 1;

        if (Input.GetKey(KeyCode.D))
            rotatonDir.x += 1;

    }

    private void FixedUpdate()
    {
        // fire the ships weapon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // players weapon laser object
            GameObject laser = null;

            // instantiate the game object relative to the ship position and rotation
            Utilities.Instance.InstantiateGameObject(ref laser, "laser", 
                transform.GetChild(3).position, transform.rotation);

            // add relative force and speed
            laser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
        }

        // add force to the ship directional movement
        rBody.AddRelativeForce(moveDir.normalized * speed * Time.deltaTime);

        // add torque for ship rotation
        rBody.AddTorque(rotaton * -rotatonDir.normalized.x * Time.deltaTime);
    }

}
