using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float patrolDistance = 2f;
    public float changeDirectionInterval = 5f;
    private float initialPositionY;
    private int moveDirection = 1;
    private float timeSinceDirectionChange = 0f;
    private Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        initialPositionY = transform.position.y;
        timeSinceDirectionChange = Random.Range(0f, changeDirectionInterval);
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDirectionChange += Time.deltaTime;
        if (timeSinceDirectionChange >= changeDirectionInterval)
        {
            ChangeDirectionRandomly();
            timeSinceDirectionChange = 0f;
        }
        transform.Translate(Vector2.up * moveDirection * moveSpeed * Time.deltaTime);
      //  enemyAnimator.SetFloat(Vector2.up, initialPositionY);
        float distanceMoved = Mathf.Abs(transform.position.y - initialPositionY);
        if (distanceMoved >= patrolDistance)
        {
            ChangeDirection();
        }

    }

    private void ChangeDirection()
    {
        moveDirection *= -1;
    }

    private void ChangeDirectionRandomly()
    {
        moveDirection = Random.Range(0, changeDirectionInterval) == 0 ? -1 : 1;
    }



}
