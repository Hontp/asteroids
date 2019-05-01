using UnityEngine;

public class Laser : Projectile
{

    // the lasers damage
    [SerializeField]
    private float damage = 10.0f;


    public override void Initialize()
    {
        // set the projectile sprite
        SetSprite("art/lasers/laserBlue01");


        // set the live time for the laser projectile
        LiveTime = 5.5f;


        base.Initialize();
    }

    /// <summary>
    /// get the laser damage
    /// </summary>
    public float GetDamage
    {
        get
        {
            return damage;
        }
    }

    public override void Update()
    {
        base.Update();
    }
}
