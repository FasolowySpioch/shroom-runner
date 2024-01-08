using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerRigidbody;
    [SerializeField] float MovementSpeed = 3;
    private Vector2 MovementInput;
    private Camera CameraMain;

    private Animator PlayerAnimator; //Connection to animator

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -2f, 0f); //starting possition
        PlayerAnimator = GetComponent<Animator>();
        CameraMain = Camera.main; //reference to main camera
    }

    // Update is called once per frame
    void Update()
    {
        //Player changing postion on the map
        MovementInput.x = Input.GetAxisRaw("Horizontal");
        MovementInput.y = Input.GetAxisRaw("Vertical");
        MovementInput.Normalize();
        PlayerRigidbody.velocity = MovementInput * MovementSpeed;


        //Mouse postition:
        Vector3 MousePosition = Input.mousePosition;
        Vector3 ScreenPoint = CameraMain.WorldToScreenPoint(transform.localPosition); 

        //Angle to shooting
        Vector2 offset = new Vector2(MousePosition.x - ScreenPoint.x, ScreenPoint.y - MousePosition.y);
        float shootAngle = Mathf.Atan2(offset.y, offset.y) * Mathf.Rad2Deg;

        //Overall player animations variables
        if (MovementInput != Vector2.zero)
        {
            PlayerAnimator.SetBool("isWalking", true);
        }
        else
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
        Debug.Log("Movement speed = " + PlayerRigidbody.velocity.magnitude);

        //Aiming
        if (MousePosition.x < ScreenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
