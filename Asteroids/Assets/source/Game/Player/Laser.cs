using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    public override void Initialize()
    {
        // set the projectile sprite
        SetSprite("art/lasers/laserBlue01");


        // set the live time for the laser projectile
        LiveTime = 5.5f;


        base.Initialize();
    }


    public override void Update()
    {
        base.Update();
    }
}
