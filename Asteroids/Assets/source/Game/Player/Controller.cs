using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotaton = 5.0f;

    Vector2 moveDir;
    Vector2 rotatonDir;
    Rigidbody2D rBody;

    Player player;    
    
    private void Start()
    {
        if (gameObject != null)
        {
            rBody = GetComponent<Rigidbody2D>();

            player = GetComponent<Player>();
           
        }      
    }

    private void Update()
    {
        moveDir = Vector2.zero;
        rotatonDir = Vector2.zero;

        player.LeftBooster.ActivateBooster(false);
        player.RightBooster.ActivateBooster(false);


        // ship movement ship with arrow keys
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.LeftBooster.ActivateBooster(true);
            player.RightBooster.ActivateBooster(true);


            moveDir.y += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.y -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.LeftBooster.ActivateBooster(true);
            player.RightBooster.ActivateBooster(true);

            moveDir.x += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.LeftBooster.ActivateBooster(true);
            player.RightBooster.ActivateBooster(true);

            moveDir.x -= 1;
        }

        // rotate the ship left and right with Z and X
        if (Input.GetKey(KeyCode.Z))
            rotatonDir.x -= 1;

        if (Input.GetKey(KeyCode.X))
            rotatonDir.x += 1;

    }

    private void FixedUpdate()
    {
        // fire the ships weapon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.FireWeapon();  
        }

        // add force to the ship directional movement
        rBody.AddRelativeForce(moveDir.normalized * speed * Time.deltaTime);

        // add torque for ship rotation
        rBody.AddTorque(rotaton * -rotatonDir.normalized.x * Time.deltaTime);
    }

}
