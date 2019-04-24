 using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // stores the SpriteRenderers for all the ship parts
    private static Dictionary<string, SpriteRenderer> partRenderers = new Dictionary<string, SpriteRenderer>();

    // stores the part sprites
    private static Dictionary<string, Sprite> partSprites = new Dictionary<string, Sprite>();

   

    //ships HP
    [SerializeField]
    private float shipHP = 0;

    /// <summary>
    /// this start method is private, it initializes the all ships parts renderers and sprites 
    /// then calls the Initialize method, any ship code should go in Initialize instead 
    /// </summary>
    private void Start()
    {
        // get sprite renderer component from the all parts of the ship
        foreach ( Transform part in transform)
        {
            // skip to next loop if the part render is already present in this collection
            if (partRenderers.ContainsKey(part.name))
                break;

            if (part.name == "hull")
                partRenderers.Add("hull", part.GetComponent<SpriteRenderer>());
            else if (part.name == "leftWing")
                partRenderers.Add("leftWing", part.GetComponent<SpriteRenderer>());
            else if (part.name == "rightWing")
                partRenderers.Add("rightWing", part.GetComponent<SpriteRenderer>());
        }

       
        Initialize();
    }

   

    /// <summary>
    /// Get the Renderer for the ship part returns null if doesnt exist
    /// </summary>
    /// <param name="renderer">the reference to the renderer</param>
    /// <param name="rendererName">the renderer's name</param>
    public void GetRenderer(ref SpriteRenderer renderer, string rendererName)
    {
        renderer = null;

        if (partRenderers.ContainsKey(rendererName))
        {
            renderer = partRenderers[rendererName];
        }
    }
        
    
    /// <summary>
    /// Set the part sprite for the ship
    /// </summary>
    /// <param name="partName">set the name for this sprite</param>
    /// <param name="partPath">set the image of this part</param>
    public void SetSprite(string partName, string partPath)
    {        
       if(!partSprites.ContainsKey(partName))
        {
            Sprite part = Utilities.Instance.CreateSprite(partPath); 

            partSprites.Add(partName, part);
        }
       else
        {
            Debug.Log("This part already exists: " + partName);
        }
    }

    /// <summary>
    /// Get the part sprite of the ship
    /// </summary>
    /// <param>set get image used of sprite</param>
    public Sprite GetSprite(string partName)
    {
        
        Sprite part = null;

        if (partSprites.ContainsKey(partName))
        {
            part = partSprites[partName];
        }

        return part;
        
    }

    /// <summary>
    /// Get or Set the ships health
    /// </summary>
    public float ShipsHealth
    {
        get
        {
            return shipHP;
        }
        set
        {
            shipHP = value;
        }
    }

    /// <summary>
    /// Initialize any ship code in this method
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Update the sprite and renderers
    /// </summary>
    public virtual void Update()
    {
        // assign all ship parts to the renderer
        foreach (KeyValuePair<string, SpriteRenderer> renderer in partRenderers)
        {
            if (partSprites.ContainsKey(renderer.Key))
            {
                renderer.Value.sprite = partSprites[renderer.Key];
            }
        }
    }

}

