using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour
{
    private 
        Rigidbody2D rb;

    public
        float XMovement;
        float YMovement;
        float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        XMovement = Input.GetAxis("Horizontal") * speed;
        YMovement = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector2(XMovement,YMovement);
    }
}
