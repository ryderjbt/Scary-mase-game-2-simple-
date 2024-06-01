using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour
{
    private 
        Rigidbody2D rb;
        Vector2 targetPos;
        bool moving;

    public
        float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) // If right click move to target // Maybe add array to take multiple inputs and loop through them sequentially
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        if(moving && (Vector2)transform.position != targetPos) // Makes sure object is moving and not at destiantion
        {
            float step = speed * Time.deltaTime; // Makes sure speed is right for each computer
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step); // Moves to target
        } else {
            moving = false; // If at target position stop moving
        }
    }
}
