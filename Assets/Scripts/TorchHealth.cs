using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchHealth : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float slashLoss;
    [SerializeField] private float timeLoss;
    [SerializeField] private float onHitValue;
    public float currentFuel;

    void Start()
    {
        currentFuel = maxHealth;
    }

    void Update()
    {
        //Game is in a menu
        if (GameManager.Instance.InMenu)
            return;
        //Check if loses
        if (currentFuel <= 0)
        {
            GameManager.Instance.IsGameOver = true;
            SceneManager.LoadScene("GameOverScreen 1");
        }
        else
        {
            //Decrease the current heat
            currentFuel -= Time.deltaTime * timeLoss;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
    }

    public void DoSlash()
    {
        currentFuel -= slashLoss;
    }

    public void DoHit()
    {
        if (currentFuel > onHitValue)
            currentFuel = onHitValue;
        else
            currentFuel = 0;
    }

    public void DoSwap()
    {
        currentFuel = maxHealth;
    }
}
