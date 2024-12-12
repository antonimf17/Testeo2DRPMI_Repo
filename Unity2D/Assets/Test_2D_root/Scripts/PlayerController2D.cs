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
    [SerializeField] Animator PlayerAnim; //Referencia para gestionar las transciones de animación


    [Header("Movement Parameters")]
    private Vector2 moveInput; //Almacén del input del player
    public float Speed;
    [SerializeField] bool isFacingRight;

    [Header("Jump parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        //autoreferenciar componentes: nombre de variable = GetComponent()
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        PlayerAnim = GetComponent<Animator>();
        isFacingRight = true;
       

    }

    // Update is called once per frame
    void Update()
    {
        OnAnimation();
        if (moveInput.x > 0 )
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if(moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    void Movement()
    {
     playerRB.velocity = new Vector3(moveInput.x * Speed, playerRB.velocity.y, 0);
      
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = a !nombre de bool (cambio al estado contrario)
    }
  
    void OnAnimation()
    {
        //Conector de valores generales con parámetros de cambio de animación
        PlayerAnim.SetBool("IsJumping", !isGrounded);
        if (moveInput.x > 0 || moveInput.x < 0) PlayerAnim.SetBool("IsRunning", true);
        else PlayerAnim.SetBool("IsRunning", false);
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















