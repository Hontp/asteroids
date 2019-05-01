using UnityEngine;

public class Hull : MonoBehaviour
{
    // the hp of the Hull
    [SerializeField]
    private float hullHP = 0;


    private ParticleSystem leftDebris;
    private ParticleSystem rightDebris;

    /// <summary>
    /// initialize the debris particle system and set them to off state
    /// </summary>
    private void Start()
    {
        foreach ( Transform debris in transform)
        {
            if ( debris.transform.name == "leftDebris")
            {
                leftDebris = debris.transform.GetComponent<ParticleSystem>();

                ParticleSystem.EmissionModule emission = leftDebris.emission;
                emission.enabled = false;
            }
            else if ( debris.transform.name == "rightDebris")
            {
                rightDebris = debris.transform.GetComponent<ParticleSystem>();

                ParticleSystem.EmissionModule emission = rightDebris.emission;
                emission.enabled = false;
            }
        }
    }

    /// <summary>
    /// get / set the hull hp
    /// </summary>
    public float HullHP
    {
        get
        {
            return hullHP;
        }
        set
        {
            hullHP = value;
        }
    }

    /// <summary>
    /// set the state of the particle emitter on/ off
    /// </summary>
    /// <param name="emitterName">emitter name</param>
    /// <param name="flag">the state of emitter on/ off</param>
    public void SetParticleEmitterActive(string emitterName, bool flag)
    {
        if (flag && emitterName == "leftDebris")
        {

            ParticleSystem.EmissionModule emission = leftDebris.emission;
            emission.enabled = flag;
        }
        else if ( flag && emitterName == "rightDebris")
        {

            ParticleSystem.EmissionModule emission = rightDebris.emission;
            emission.enabled = flag;
        }
    }


    /// <summary>
    /// check for collsion with the laser
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            hullHP -= collision.GetComponent<Laser>().GetDamage;

            //  if the hull hp is zero then destory the entire ship
            if (hullHP <= 0)
            {
                // if the hull is destoryed then ship is also destoryed
                Destroy(transform.parent.gameObject);
            }

            // destory the laser
            Destroy(collision.gameObject);
        }      
    }
}
