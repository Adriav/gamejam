using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float movementSpeed = 5f;
  private Rigidbody2D rb;
  private Vector2 movementInput;
  public bool player2 = false;
  // Start is called before the first frame update
  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (player2)
    {
      movementInput.x = Input.GetAxisRaw("HorizontalTorch");
      movementInput.y = Input.GetAxisRaw("VerticalTorch");
      movementInput.Normalize();

      rb.velocity = movementInput * movementSpeed;
    }
    else
    {
      movementInput.x = Input.GetAxisRaw("Horizontal");
      movementInput.y = Input.GetAxisRaw("Vertical");
      movementInput.Normalize();
  
      rb.velocity = movementInput * movementSpeed;
    }

  }
}
