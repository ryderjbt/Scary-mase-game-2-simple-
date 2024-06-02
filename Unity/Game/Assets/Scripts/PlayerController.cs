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
        float XMovement;
        float YMovement;

    private void Movement()
    {
        if(Input.GetMouseButtonDown(1) && selected) // If right click move to target // Maybe add array to take multiple inputs and loop through them sequentially
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        if(moving && (Vector2)transform.position != targetPos) // Makes sure object is moving and not at destiantion
        {
            XMovement = (targetPos.x - this.transform.position.x) * speed;
            YMovement = (targetPos.y - this.transform.position.y) * speed;
            rb.velocity = new Vector2(XMovement,YMovement);
        } else {
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
