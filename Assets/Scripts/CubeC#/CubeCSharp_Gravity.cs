using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CubeCSharp_Gravity : MonoBehaviour
{
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
        } else
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        
        movement += velocity;   
        movement += Physics.gravity;
        movement *= Time.deltaTime;
        
        // Actually move the character  
        character.Move(movement);
    }
}