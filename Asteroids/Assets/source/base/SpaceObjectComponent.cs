using UnityEngine;


/// <summary>
/// Container class for a space object that is other than a ship, this class stores the renderer, 
/// sprite and transform of the object
/// </summary>
public class SpaceObjectComponent
{
    private SpriteRenderer objRenderer;
    private Transform objTransform;
    private Sprite objSprite;

    /// <summary>
    /// get / set the SpriteRenderer for this object
    /// </summary>
    public SpriteRenderer ObjectRenderer
    {
        get
        {
            return objRenderer;
        }
        set
        {
            objRenderer = value;
        }
    }

    /// <summary>
    /// get / set the Transform for this object 
    /// </summary>
    public Transform ObjectTransform
    {
        get
        {
            return objTransform;
        }
        set
        {
            objTransform = value;
        }
    }

    /// <summary>
    /// get /set the sprite for this object
    /// </summary>
    public Sprite ObjectSprite
    {
        get
        {
            return objSprite;
        }
        set
        {
            objSprite = value;
        }
    }


}
