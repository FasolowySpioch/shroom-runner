using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MovementSpeed = 3;
    private Vector2 MovementInput;

    private Vector2 movementInput;
    void Start()
    {
        transform.position = new Vector3(0f,-2f,0f); //starting possition
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x =  Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementInput.x, movementInput.y, 0f) * Time.deltaTime * MovementSpeed;

    }
}
