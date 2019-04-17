using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // stores the SpriteRenderers for all the ship parts
    private static Dictionary<string, SpriteRenderer> partRenderers = new Dictionary<string, SpriteRenderer>();

    // stores the part sprites
    private static Dictionary<string, Sprite> partSprites = new Dictionary<string, Sprite>();

    //constaints value left, right, top, bottom 
    private float[] constraints = new float[4];

    // buffer for how far the ship is off the screen before it appears on the other side
    private float buffer = 1.0f;

    // the constane Z-axis distance from the screen
    private float distance = 10f;

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

        // detect and calculate the screen constraints
        // left 
        constraints[0] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distance)).x;
        // right
        constraints[1] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distance)).x;

        // up
        constraints[2] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distance)).y;
        // down
        constraints[3] = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distance)).y;


        Initialize();
    }

    /// <summary>
    /// Method wrap the ship around the screen
    /// </summary>
   private void WrapScreen()
    {

        // wrap the left and right sides of the screen
        if (transform.position.x < constraints[0] - buffer)        
           transform.position = new Vector3(constraints[1] + buffer, transform.position.y);
        
        if (transform.position.x > constraints[1] + buffer)
            transform.position = new Vector3(-constraints[1] - buffer, transform.position.y);
        

        // wrap the top and bottom sides of the screen
        if (transform.position.y < constraints[2] - buffer)        
            transform.position = new Vector3(transform.position.x, constraints[3] + buffer);
        
        if (transform.position.y > constraints[3] + buffer)     
            transform.position = new Vector3(transform.position.x, -constraints[3] - buffer);
        
    }


    /// <summary>
    /// set the buffer distance for the screen wrap
    /// </summary>
    public float SetBuffer
    {
        set
        {
            buffer = value;
        }
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

            WrapScreen();
        }
    }

}

