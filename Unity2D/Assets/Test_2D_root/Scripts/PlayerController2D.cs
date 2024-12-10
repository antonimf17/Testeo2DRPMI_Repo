using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem; //Libreria para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{
       //Referencias Generales  //SeriazlizedField hace que sea privado pero se vea en el inspector
           [SerializeField] Rigidbody2D playerRB; //Referencia al rigidbody del player
    [SerializeField] PlayerInput playerInput; //Referencia al gestor del input del jugador



    [Header("Movement Parameters")]
    private Vector2 moveInput; //Almacén del input del player
    public float Speed;
    

    [Header("Jump parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        //autoreferenciar componentes: nombre de variable = GetComponent()
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

       

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    void Movement()
    {
     playerRB.velocity = new Vector3(moveInput.x * Speed, playerRB.velocity.y, 0);
      
    }
  

    #region Input Events
    //Para Crear un evento
    //Se define Public sin tiop de dato (Void) y con una referencia al input (Callback.Context)
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        }
    }
        
    }







    #endregion















