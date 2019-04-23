using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    public override void Initialize()
    {
        // set the projectile sprite
        SetSprite("art/lasers/laserBlue01");

        base.Initialize();
    }


    public override void Update()
    {

 
        base.Update();
    }
}
