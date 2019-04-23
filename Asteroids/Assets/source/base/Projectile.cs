using UnityEngine;

public class Projectile : MonoBehaviour
{

    // renderer for the projectile
    private SpriteRenderer projRenderer;

    // the sprite for the projectile
    private Sprite projSprite;

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
    /// <param name="projectilePath"></param>
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
    /// Initialize any projectile code in this method
    /// </summary>
    public virtual void Initialize() { }


    /// <summary>
    /// update the sprite for this projectile
    /// </summary>
    public virtual void Update()
    {
        if (projSprite != null)
            projRenderer.sprite = projSprite;
    }
}
