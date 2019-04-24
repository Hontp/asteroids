using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{ 
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

        base.Initialize();
    }


    public override void Update()
    {

        base.Update();
    }


}
