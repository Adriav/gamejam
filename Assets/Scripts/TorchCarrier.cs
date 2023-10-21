using System.Collections;
using UnityEngine;

public class TorchCarrier : MonoBehaviour
{
    [SerializeField] public bool isCarrier;
    private Torch torch;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the Torch attached to the object if the player is carrying it
        if (isCarrier)
            torch = transform.GetChild(0).GetComponent<Torch>();
        else
            return;
        //Ignore commands if game is stopped
        if (GameManager.Instance.IsPaused || GameManager.Instance.IsGameOver)
            return;
        if (Input.GetKeyDown(KeyCode.G))
            torch.DoSlash();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCarrier && other.CompareTag("EnemyBullet"))
        {
            torch.DoHit();
            StartCoroutine(Invulnerability());
        }
    }

    public void SwapTorchCarrier()
    {
        isCarrier = !isCarrier;
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
}
