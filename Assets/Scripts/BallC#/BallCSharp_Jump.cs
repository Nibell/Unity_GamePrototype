using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class BallCSharp_Jump : MonoBehaviour
{   
    private float jumpSpeed = 20;
    private float timer = 0.0f;
    private CharacterController character;
    private Vector3 velocity;
    private Vector3 movement = Vector3.zero;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        if (character.isGrounded)
        {
            velocity = Vector3.zero;
            timer += Time.deltaTime;
            if (timer > 0.10f)
            {
                BallJump();
                timer = 0.0f;
            }
        } else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        movement += velocity;
        movement += Physics.gravity;
        movement *= Time.deltaTime;

        character.Move(movement);
    }

    void BallJump()
    {
        velocity = character.velocity;
        velocity.y = jumpSpeed;
    }
   
}