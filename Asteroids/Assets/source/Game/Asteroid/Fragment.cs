using UnityEngine;

/// <summary>
/// asteroid fragment class
/// </summary>
public class Fragment : SpaceObject
{

    // fragment hp
    public float fragmentHP = 50.0f;

    /// <summary>
    /// initialize the fragment object, set th srpite amd particle emitter to true
    /// </summary>
    public override void Initialize()
    {
        // set the sprite for asteroid
        SetSprite("art/asteroids/meteorGrey_med1");

        // set the particle emitter to active
        SetParticleEmitterActive(true);

        base.Initialize();
    }

    /// <summary>
    /// check for collision with the laster projectile
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            // turn partilce emitter for damage
            SetParticleEmitterActive(true);

            // apply damage to asteroid
            fragmentHP -= collision.GetComponent<Laser>().GetDamage;


            // destory the fragment
            if (fragmentHP <= 0)
            {
                // add point to player score
                Utilities.Instance.PlayerScore = 1;

                Destroy(gameObject);
            }
            // destory the laser
            Destroy(collision.gameObject);
        }       
    }

    /// <summary>
    /// check for collision with other asteroids and the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: implement destory ship part
        // collison with an anoter fragment add more spin and force
        if (collision.gameObject.tag == "asteroid")
        {

            //add force the asteroid
            collision.gameObject.GetComponent<Rigidbody2D>().
                AddRelativeForce(transform.position * 1.5f);

            // add spin to the asteroid
            collision.gameObject.GetComponent<Rigidbody2D>().AddTorque(1.5f);
        }
        else
        {
            // get the contact points for child objects
            Collider2D collider = collision.contacts[0].collider;

            if (collider.gameObject.tag == "playerLeftWing")
            {
                collider.gameObject.GetComponent<Wing>().WingHP -= 1.5f;

                if (collider.gameObject.GetComponent<Wing>().WingHP <= 0)
                    Destroy(collider.gameObject);                
            }
            else if (collider.gameObject.tag == "playerRightWing")
            {
                collider.gameObject.GetComponent<Wing>().WingHP -= 1.5f;

                if (collider.gameObject.GetComponent<Wing>().WingHP <= 0)
                    Destroy(collider.gameObject);                
            }
            else if (collider.gameObject.tag == "playerHull")
            {
                collider.gameObject.GetComponent<Hull>().HullHP -= 1.5f;

                if (collider.gameObject.GetComponent<Hull>().HullHP <= 0)
                {
                    Destroy(collider.transform.parent.gameObject);

                    Utilities.Instance.IsPlayerDead = true;

                }

            }
        }
    }

    public override void Update()
    {
        base.Update();
    }

}
