using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerShoot playerShoot;
    private PlayerTorch carrier;

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
    private bool isVulnerable = false;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration = 2f;
    private SpriteRenderer sprite;

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        carrier = GetComponent<PlayerTorch>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.RightShift) && !isVulnerable && coolDown <= 0)
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
        playerShoot.SwitchShoot();
        carrier.SwitchCarrier();
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
        isVulnerable = true;
        Physics2D.IgnoreLayerCollision(6, 8, true);
        Color colorDefault = sprite.color;
        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(vulnerabilityDuration);
        sprite.color = colorDefault;
        Physics2D.IgnoreLayerCollision(6, 8, false);
        isVulnerable = false;
    }
}
