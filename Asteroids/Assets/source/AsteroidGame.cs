﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGame : MonoBehaviour
{

    GameObject player = null;
 
    // Start is called before the first frame update
    void Start()
    {

        Utilities.Instance.CreateGameObject("player", "prefab/player");
        Utilities.Instance.InstantiateGameObject(ref player, "player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
