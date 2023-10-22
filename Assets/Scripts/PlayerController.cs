using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerTorch carrier;
    private Animator animator;

    [Header("Player Status")]
    public bool isPlayer1;
    public bool canShoot;
    public bool isCarrier;
    public bool canMove;

    [Header("Swap cooldown")]
    private float coolDown = 0;
    [SerializeField] private float coolDownTime = 2f;

    [Header("Vulnerability")]
    [SerializeField] private float vulnerabilityDuration = 4f;
    

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration = 2f;
    private SpriteRenderer sprite;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        carrier = GetComponent<PlayerTorch>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("hasTorch", isCarrier);
        if (isCarrier)
        {
            GameManager.Instance.TorchPlayer = transform;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver || GameManager.Instance.IsPaused) return;
        if (GameManager.Instance.Player1Swap && GameManager.Instance.Player2Swap && !GameManager.Instance.PlayerVulnerable && coolDown <= 0)
        {
            SwitchRole();
            coolDown = coolDownTime;
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }

    private void SwitchRole()
    {
        //Set state for animator
        animator.SetBool("swapPose",false);
        if(isCarrier)
            animator.SetTrigger("swapThrow");
        animator.SetTrigger("swapFinish");
        //Swap the variables
        playerShoot.SwitchShoot();
        carrier.SwitchCarrier();
        animator.SetBool("hasTorch", isCarrier);
        if (isCarrier)
        {
            GameManager.Instance.TorchPlayer = transform;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            if (isCarrier)
            {
                carrier.DoTorchHit();
                StartCoroutine(Invulnerability());
            }
            else
            {
                StartCoroutine(InvulnerabilityShooter());
            }
            animator.SetTrigger("hurt");
            Destroy(other.gameObject);
        }

    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Color colorDefault = sprite.color;
        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(iFramesDuration);
        sprite.color = colorDefault;
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
    private IEnumerator InvulnerabilityShooter()
    {
        GameManager.Instance.PlayerVulnerable = true;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Color colorDefault = sprite.color;
        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(vulnerabilityDuration);
        sprite.color = colorDefault;
        Physics2D.IgnoreLayerCollision(6, 8, false);
        GameManager.Instance.PlayerVulnerable = false;
    }
}
