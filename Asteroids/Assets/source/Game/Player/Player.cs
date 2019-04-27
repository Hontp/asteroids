using UnityEngine;

public class Player : Ship
{
 
    public float bulletSpeed = 125.0f;

    private Booster leftBooster;
    private Booster rightBooster;

    public override void Initialize()
    {
        //set the player's ship components
        SetSprite("hull", "art/ship/hull");
        SetSprite("leftWing", "art/ship/leftWing");
        SetSprite("rightWing", "art/ship/rightWing");
        SetSprite("centreGun", "art/ship/gun");

        // initialize the left and right booster engines
        leftBooster = GetTransform("leftWing").GetChild(0).GetComponent<Booster>();
        rightBooster = GetTransform("rightWing").GetChild(0).GetComponent<Booster>();


        //set the players HP
        ShipsHealth = 100;

        //set the players starting position
        transform.position = new Vector3(0, -3);


        //  create laser weapon object
        Utilities.Instance.CreateGameObject("laser", "prefab/player/laser");


        base.Initialize();
    }


    /// <summary>
    /// get the ships left booster engine
    /// </summary>
    public Booster LeftBooster
    {
        get
        {
            return leftBooster;
        }
    }


    /// <summary>
    /// get the the ships right booster engine
    /// </summary>
    public Booster RightBooster
    {
        get
        {
            return rightBooster;
        }
    }
   
    /// <summary>
    /// fire the ships weapon
    /// </summary>
    public void FireWeapon()
    {
        // players weapon laser object
        GameObject laser = null;

        // instantiate the game object relative to the ship position and rotation
        Utilities.Instance.InstantiateGameObject(ref laser, "laser",
            GetTransform("centreGun").GetChild(0).position, transform.rotation);

        // add relative force and speed
        laser.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed);
    }

    public override void Update()
    {

        base.Update();
    }


}
