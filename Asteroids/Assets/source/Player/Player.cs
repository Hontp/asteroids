using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    // list of player projectile
    List<GameObject> projectiles = new List<GameObject>();

    private const int MAX_BULLET = 10;

    public override void Initialize()
    {
        //set the player's ship components
        SetSprite("hull", "art/ship/hull");
        SetSprite("leftWing", "art/ship/leftWing");
        SetSprite("rightWing", "art/ship/rightWing");

        //set the players HP
        ShipsHealth = 100;

        //set the players starting position
        transform.position = new Vector3(0, -3);


        // create projectiles
        Utilities.Instance.CreateGameObject("laser", "prefab/player/laser");

        // instantiate projectile
        for (int i = 0; i < MAX_BULLET; i++)
        {
            GameObject obj = null;

            Utilities.Instance.InstantiateGameObject(ref obj, "laser", transform.GetChild(3).position);
            obj.SetActive(false);

            projectiles.Add(obj);
        }

            base.Initialize();
    }

    /// <summary>
    /// get the projectile list
    /// </summary>
    public List<GameObject> GetProjectile
    {
        get
        {
            return projectiles;
        }
    }


    public override void Update()
    {

        base.Update();
    }


}
