using UnityEngine;

/// <summary>
/// Asteroid class
/// </summary>
public class Asteroid : SpaceObject
{

    public float asteroidHP = 100.0f;


    public override void Initialize()
    {
        // set the sprite for asteroid
        SetSprite("art/asteroids/meteorGrey_big1");
        
        base.Initialize();    
    }


    /// <summary>
    /// spawn the asteroid fragments after its destoryed
    /// </summary>
    /// <param name="num">the number of fragments to spawn</param>
    private void SpawnFragments( int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject child = null;

            // spawn asteroid fragments
            Utilities.Instance.InstantiateGameObject(ref child, "fragment", 
                transform.position, transform.rotation);

            // give the fragment momentum
            child.GetComponent<Rigidbody2D>().
                AddRelativeForce(transform.position * 1.5f);

            // add rotation
            child.GetComponent<Rigidbody2D>().AddTorque(1.5f);
        }
    }

    /// <summary>
    /// check for collison with a projectile
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            // turn partilce emitter for damage
            SetParticleEmitterActive(true);

            // apply damage to asteroid
            asteroidHP -= collision.GetComponent<Laser>().GetDamage;


            if (asteroidHP <= 0)
            {

                // spawn 2 fragments
                SpawnFragments(2);
               
                // destory the oringal asteroid
                Destroy(gameObject);
            }

            // destory laser
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// check for collision with player or other aesteroids
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO: implement destory ship part
        // collison with an anoter asteroid add more spin and force
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

            if ( collider.gameObject.tag == "playerLeftWing")
            {
                collider.gameObject.GetComponent<Wing>().WingHP -= 3.5f;
            }
            else if (collider.gameObject.tag == "playerRightWing")
            {
                collider.gameObject.GetComponent<Wing>().WingHP -= 3.5f;
            }
            else if ( collider.gameObject.tag == "playerHull")
            {
                collider.gameObject.GetComponent<Hull>().HullHP -= 3.5f;
            }
        }
        
    }


    public override void Update()
    {
        base.Update();
    }
}
