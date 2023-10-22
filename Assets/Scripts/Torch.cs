using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHealth : MonoBehaviour
{
    [Header("Health Values")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float slashCost;
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
        }
        //Decrease the current heat
        currentFuel -= Time.deltaTime * timeLoss;
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
        currentFuel -= slashCost;
    }

    public void DoHit()
    {
        if (currentFuel > onHitValue)
            currentFuel = onHitValue;
        else
            GameManager.Instance.IsGameOver = true;
    }

    public void DoSwap(bool state)
    {
        currentFuel = maxHealth;
        SetVisible(state);
    }

    public void SetVisible(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }
}
