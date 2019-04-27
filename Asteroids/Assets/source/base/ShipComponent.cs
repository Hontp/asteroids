﻿using UnityEngine;

/// <summary>
/// the ShipComponent class is a contianer thats stores a reference to the Transform, SpriteRenderer and the Sprite
/// of thisp particular part of the ship
/// </summary>
public class ShipComponent
{
    private Transform componentTransform;
    private SpriteRenderer componentRenderer;
    private Sprite componentSprite;


    /// <summary>
    /// get /set the ship component transform
    /// </summary>
    public Transform ComponentTransform
    {
        get
        {
            return componentTransform;
        }
        set
        {
            componentTransform = value;
        }
    }

    /// <summary>
    /// get / set the renberer for this component
    /// </summary>
    public SpriteRenderer ComponentRenderer
    {
        get
        {
            return componentRenderer;
        }
        set
        {
            componentRenderer = value;
        }
    }

    /// <summary>
    /// get / set the sprite for this component
    /// </summary>
    public Sprite ComponentSprite
    {
        get
        {
            return componentSprite;
        }
        set
        {
            componentSprite = value;
        }
    }


}
