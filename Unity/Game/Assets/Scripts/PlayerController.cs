using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private 
        //Rigidbody2D rb;
        Vector2 targetPos;
        bool moving;
        bool selected;

    public
        float speed = 2f;
        static List<PlayerController> moveableTroops = new List<PlayerController>();

    private void Movement()
    {
        if(Input.GetMouseButtonDown(1) && selected) // If right click move to target // Maybe add array to take multiple inputs and loop through them sequentially
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

    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        foreach(PlayerController obj in moveableTroops)
        {
            if(obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moveableTroops.Add(this);
        targetPos = transform.position;
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
