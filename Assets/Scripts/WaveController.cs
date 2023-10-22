using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (transform.childCount == 0)
    {
      GameManager.Instance.MoveBackground = true;
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("LimDer"))
    {
      GameManager.Instance.MoveBackground = false;
      ActivateEnemy();
    }
  }

  private void ActivateEnemy()
  {
    for (int i = 0; i < transform.childCount; i++)
    {
      transform.GetChild(i).GetComponent<EnemyLife>().ActivateEnemy();
    }
  }
}
