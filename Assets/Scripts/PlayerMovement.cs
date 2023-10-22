using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float movementSpeed = 5f;
  private Rigidbody2D rb;
  private Vector2 movementInput;
  private PlayerController pc;
  private Animator animator;
  private bool limiteSuperior = false;
  private bool limiteInferior = false;
  private bool limiteDerecha = false;
  private bool limiteIzquierda = false;

  // Start is called before the first frame update
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    pc = GetComponent<PlayerController>();
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!GameManager.Instance.IsGameOver && !GameManager.Instance.IsPaused)
    {
      if (pc.isPlayer1 && pc.canMove)
      {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (limiteSuperior && movementInput.y > 0) movementInput.y = 0;
        else if (limiteInferior && movementInput.y < 0) movementInput.y = 0;
        if (limiteDerecha && movementInput.x > 0) movementInput.x = 0;
        else if (limiteIzquierda && movementInput.x < 0) movementInput.x = 0;
        

        movementInput.Normalize();
        rb.velocity = movementInput * movementSpeed;
      }
      else if (!pc.isPlayer1 && pc.canMove)
      {
        
        movementInput.x = Input.GetAxisRaw("HorizontalTorch");
        movementInput.y = Input.GetAxisRaw("VerticalTorch");

        if (limiteSuperior && movementInput.y > 0) movementInput.y = 0;
        else if (limiteInferior && movementInput.y < 0) movementInput.y = 0;
        if (limiteDerecha && movementInput.x > 0) movementInput.x = 0;
        else if (limiteIzquierda && movementInput.x < 0) movementInput.x = 0;

        movementInput.Normalize();

        rb.velocity = movementInput * movementSpeed;
      }
    }
    else
    {
      rb.velocity = Vector2.zero;
      pc.canMove = false;
    }
    if (Input.GetKeyDown(KeyCode.G) && pc.isPlayer1)
      animator.SetBool("swapPose", true);
    // Jugador 1 presiona G y no se puede mover
    if (Input.GetKey(KeyCode.G) && pc.isPlayer1)
    {
      pc.canMove = false;
      rb.velocity = Vector2.zero;
    }
    // Jugador 1 libera G y ya se puede mover
    if (Input.GetKeyUp(KeyCode.G) && pc.isPlayer1)
    {
      pc.canMove = true;
      animator.SetBool("swapPose", false);
    }
    if (Input.GetKeyDown(KeyCode.RightShift) && !pc.isPlayer1)
      animator.SetBool("swapPose", true);
    // Jugador 2 presiona RShift y no se puede mover
    if (Input.GetKey(KeyCode.RightShift) && !pc.isPlayer1)
    {
      pc.canMove = false;
      rb.velocity = Vector2.zero;
    }
    // Jugador 2 libera RShift y ya se puede mover
    if (Input.GetKeyUp(KeyCode.RightShift) && !pc.isPlayer1)
    {
      pc.canMove = true;
      animator.SetBool("swapPose", false);
    }
    //Update Animator
    animator.SetFloat("movX", rb.velocity.x);
    animator.SetFloat("movY", rb.velocity.y);
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    String colliderTag = collider.tag;
    switch (colliderTag)
    {
      case "LimSup": 
        limiteSuperior = true;
        break;
      
      case "LimInf": 
        limiteInferior = true;
        break;
      
      case "LimDer": 
        limiteDerecha = true;
        break;

      case "LimIzq": 
        limiteIzquierda = true;
        break;

      default:
        break;
    }
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    String colliderTag = collider.tag;
    switch (colliderTag)
    {
      case "LimSup": 
        limiteSuperior = false;
        break;
      
      case "LimInf": 
        limiteInferior = false;
        break;
      
      case "LimDer": 
        limiteDerecha = false;
        break;

      case "LimIzq": 
        limiteIzquierda = false;
        break;

      default:
        break;
    }
  }

  /*
    public void switchMoveStatus()
    {
      canMove = !canMove;
    }
  */
}
