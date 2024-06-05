using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private 
        Rigidbody2D rb;
        Vector2 targetPos;
        bool moving;
        bool selected;

    public
        float speed = 2f;
        static List<PlayerController> moveableTroops = new List<PlayerController>();
        Vector2 clickMovement;

    private void Movement()
    {
        if(Input.GetMouseButtonDown(1) && selected) // If right click move to target // Maybe add array to take multiple inputs and loop through them sequentially
        {
            rb.velocity = new Vector2(0,0);
            moving = false;
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        if(moving && (Vector2)transform.position != targetPos) // Makes sure object is moving and not at destiantion
        {
            clickMovement = (targetPos - (Vector2)transform.position).normalized;
            rb.velocity = (clickMovement) * speed; // Has jittering on location because may overlap target pos and then overadjusted
        } else { // Need better way of checking destination has been reached so that rb.velocity can be set back to 0
            rb.velocity = new Vector2(0,0); // Tried checking range like from player to location distance but did nothing dunno why
            moving = false; // If at target position stop moving
        }
    }

    private void OnMouseDown()
    {
        if (this.selected == true)
        {
            this.selected = false;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        } else {
            this.selected = true;
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        moveableTroops.Add(this);
        this.selected = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        targetPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
