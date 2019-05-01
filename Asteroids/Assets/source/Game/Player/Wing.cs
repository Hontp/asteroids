using UnityEngine;

public class Wing : MonoBehaviour
{
    // the hp of the wing
    [SerializeField]
    private float wingHP = 0;

    /// <summary>
    /// get / set the wing hp
    /// </summary>
    public float WingHP
    {
        get
        {
            return wingHP;
        }
        set
        {
            wingHP = value;
        }
    }

    /// <summary>
    /// check for collsion with the laser
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "laser")
        {
            wingHP -= collision.GetComponent<Laser>().GetDamage;

            // destory the wing
            if (wingHP <= 0)
                Destroy(gameObject);

            // destory the laser
            Destroy(collision.gameObject);
        }        
    }

}
