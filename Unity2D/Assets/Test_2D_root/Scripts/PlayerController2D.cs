using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Referencias a las antiguas inputs
    public float horInput;



    //Referencias Generales  //SeriazlizedField hace que sea privado pero se vea en el inspector

    [SerializeField] Rigidbody2D playerRB; //Referencia al rigidbody del player

    [Header("Movement Parameters")]
    public float Speed;

    [Header("Jump parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        //autoreferenciar componentes: nombre de variable = GetComponent()
        playerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        Jump();

    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    void Movement()
    {
        playerRB.velocity = new Vector3(horInput * Speed, playerRB.velocity.y, 0);


    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }    


}



