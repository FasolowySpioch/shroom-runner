using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerRigidbody;
    [SerializeField] float MovementSpeed = 3;
    private Vector2 MovementInput;

    private Animator PlayerAnimator; //Connection to animator

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f,-2f,0f); //starting possition
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player changing postion on the map
        MovementInput.x =  Input.GetAxisRaw("Horizontal");
        MovementInput.y = Input.GetAxisRaw("Vertical");
        PlayerRigidbody.velocity = MovementInput * MovementSpeed;

        //Overall player walking animations
        if (MovementInput != Vector2.zero) 
        {
            PlayerAnimator.SetBool("isWalking", true);
        }
        else 
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
    }
}
