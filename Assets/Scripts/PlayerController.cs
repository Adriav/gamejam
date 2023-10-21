using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerShoot playerShoot; // Asigna el script PlayerShoot desde el Inspector
    public TorchCarrier carrier;
    public bool isCarrier;
    [SerializeField] private float vulnerabilityDuration = 4f;
    private bool isVulnerable = false;
    Collider other;
    private bool canShoot;
    private float coolDown = 0;
    public float coolDownTime = 2f;
    [SerializeField] private float iFramesDuration = 2f;
    private SpriteRenderer sprite;
    


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

    private void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
        carrier = GetComponent<TorchCarrier>();
        canShoot = playerShoot.canShoot;
        isCarrier = carrier.isCarrier;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void SwitchRole()
    {
        playerShoot.SwitchShoot();
        carrier.SwapTorchCarrier();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            if (isCarrier)
            {
                carrier.torch.DoHit();
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
