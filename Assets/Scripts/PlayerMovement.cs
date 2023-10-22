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
        movementInput.Normalize();

        rb.velocity = movementInput * movementSpeed;
      }
      else if (!pc.isPlayer1 && pc.canMove)
      {
        movementInput.x = Input.GetAxisRaw("HorizontalTorch");
        movementInput.y = Input.GetAxisRaw("VerticalTorch");
        movementInput.Normalize();

        rb.velocity = movementInput * movementSpeed;
      }
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

  /*
    public void switchMoveStatus()
    {
      canMove = !canMove;
    }
  */
}
