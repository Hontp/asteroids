using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10.0f;


    private void Update()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            moveDir.y += 1;

        if (Input.GetKey(KeyCode.DownArrow))
            moveDir.y -= 1;

        if (Input.GetKey(KeyCode.RightArrow))
            moveDir.x += 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            moveDir.x -= 1;

        transform.Translate(moveDir.normalized * speed * Time.deltaTime);
        
    }
    
}
