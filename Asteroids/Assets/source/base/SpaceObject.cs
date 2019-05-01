using System.Collections.Generic;
using UnityEngine;

public class SpaceObject : MonoBehaviour
{
    // renderer for this object
    private SpriteRenderer objRenderer;

    // the object for this sprite
    private Sprite objSprite;

    // the transform for this object
    private Transform objTransform;
    
    // object particle system
    private ParticleSystem objParticles;


    /// <summary>
    /// private start method gets the spritrenderer, transform, particle system and child objects
    /// use initialize method to the initailize the object specific code
    /// </summary>
    private void Start()
    {
        if (transform != null)
        {
            // get the object renderer
            objRenderer = GetComponent<SpriteRenderer>();

            // get the object transform
            objTransform = transform;

            // get the particle system for the object
            objParticles =  transform.GetChild(0).GetComponent<ParticleSystem>();

            // set particle system to off state
            ParticleSystem.EmissionModule emission = objParticles.emission;
            emission.enabled = false;
        }

        Initialize();
    }

    /// <summary>
    /// Set the state of the particle emitter
    /// </summary>
    /// <param name="state">toggle the emitter on / off</param>
    public void SetParticleEmitterActive(bool state)
    {
        ParticleSystem.EmissionModule emitter;

        if (objParticles != null)
        {
            emitter = objParticles.emission;

            emitter.enabled = state;
        }
    }
    /// <summary>
    /// get the renderer of this object
    /// </summary>
    public SpriteRenderer GetRenderer
    {
        get
        {
            return objRenderer;
        }
    }

    /// <summary>
    /// get the sprite for this object
    /// </summary>
    public Sprite GetSprite
    {
        get
        {
            return objSprite;
        }
    }

    /// <summary>
    /// get the object transform
    /// </summary>
    public Transform GetTransform
    {
        get
        {
            return objTransform;
        }
    }
 
    /// <summary>
    /// set the sprite for this object
    /// </summary>
    /// <param name="objectPath">the path to object image</param>
    public void SetSprite(string objectPath)
    {
        objSprite = Utilities.Instance.CreateSprite(objectPath);
    }

    /// <summary>
    /// Initialize any object specfic code here
    /// </summary>
    public virtual void Initialize() { }
   
    /// <summary>
    /// render this object
    /// </summary>
    public virtual void Update()
    {
        if (objSprite != null)
            objRenderer.sprite = objSprite;

    }
}
