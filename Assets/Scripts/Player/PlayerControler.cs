using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float movementSpeed = 3;
    [SerializeField] GameObject refPlayerBullet;
    [SerializeField] GameObject firePositionChange;
    [SerializeField] Transform emptyWeaponDirector;
    [SerializeField] Transform firePosition;
    private Vector2 movementInput;
    private Camera cameraMain;

    private Animator playerAnimator; //Connection to animator

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -2f, 0f); //starting possition
        playerAnimator = GetComponent<Animator>();
        cameraMain = Camera.main; //reference to main camera
    }

    // Update is called once per frame
    void Update()
    {
        //Player changing postion on the map
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        movementInput.Normalize();
        playerRigidbody.velocity = movementInput * movementSpeed;


        //Mouse postition:
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = cameraMain.WorldToScreenPoint(transform.localPosition); 

        //Angle to shooting
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float shootAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        emptyWeaponDirector.rotation = Quaternion.Euler(0, 0, shootAngle);

        //Overall player animations variables
        if (movementInput != Vector2.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        Debug.Log("Movement speed = " + playerRigidbody.velocity.magnitude);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(refPlayerBullet, firePosition.position, firePosition.rotation);
            playerAnimator.SetBool("isShooting", true);
        }
        else {
            playerAnimator.SetBool("isShooting", false);
        }
    }
}
