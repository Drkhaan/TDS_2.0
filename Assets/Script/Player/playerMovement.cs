using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // variables move
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;

    //variables dash
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    float dashCounter;
    float dashCoolCounter;

    //variables mouse looking
    Vector2 mousePos;
    public Camera cam;

    [SerializeField] private TrailRenderer trail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //mouse looking

        mousePos = cam.ScreenToWorldPoint( Input.mousePosition );

        //dash
        rb.velocity = movement * activeMoveSpeed;

        if ( Input.GetKeyDown ( KeyCode.Space ))
        {
            if ( dashCoolCounter <=0 && dashCounter <=0 )
            {
                trail.emitting = true;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if ( dashCounter > 0 )
        {
            dashCounter -= Time.deltaTime;

            if ( dashCounter <=0 )
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;

                trail.emitting = false;
            }
        }

        if ( dashCoolCounter > 0 )
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate ()
    {
        //replaced moveSpeed by activeMoveSpeed
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);

        //mouse looking
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2( lookDir .y , lookDir.x ) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    

    
}
