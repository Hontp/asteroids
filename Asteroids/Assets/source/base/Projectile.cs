﻿using UnityEngine;

public class Projectile : MonoBehaviour
{

    // renderer for the projectile
    private SpriteRenderer projRenderer;

    // the sprite for the projectile
    private Sprite projSprite;

    // the the life time of the projectile before it gets cleaned up
    private float liveTime = 3.0f;

    /// <summary>
    /// private start method gets the spritrenderer of the transform
    /// use initialize method to the initailize projectile specific code
    /// </summary>
    private void Start()
    {

        // get the sprite render for this projectile
        if (transform != null)
            projRenderer = GetComponent<SpriteRenderer>();


        Initialize();
    }

    /// <summary>
    /// get the render of the  projectile
    /// </summary>
    public SpriteRenderer GetRenderer
    {
        get
        {
            return projRenderer;
        }
    }

    /// <summary>
    /// set the sprite for this projectile
    /// </summary>
    /// <param name="projectilePath">the path to the projectile image</param>
    public void SetSprite( string projectilePath)
    {
        projSprite = Utilities.Instance.CreateSprite(projectilePath);
    }


    /// <summary>
    /// get the the sprite for this projectile
    /// </summary>
    public Sprite GetSprite
    {
        get
        {
            return projSprite;
        }
    }

    /// <summary>
    /// get set the live time for this projectile
    /// </summary>
    public float LiveTime
    {
        get
        {
            return liveTime;
        }
        set
        {
            liveTime = value;
        }
    }

    /// <summary>
    /// Initialize any projectile code in this method
    /// </summary>
    public virtual void Initialize() { }


    /// <summary>
    /// render the sprite for this projectile
    /// </summary>
    public virtual void Update()
    {
        // update the sprite of the projectile
        if (projSprite != null)
            projRenderer.sprite = projSprite;


        // clean up projectile after a certian amount of time
        Destroy(gameObject, liveTime);
        
    }
}
