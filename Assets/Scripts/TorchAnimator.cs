using UnityEngine;

public class TorchAnimator : MonoBehaviour
{
    [SerializeField] PlayerController player1, player2;
    private Animator anim1, anim2;
    [SerializeField] float torch_offsetX, torch_offsetY, gun_offsetX, gun_offsetY;
    [SerializeField] float speed;
    private Vector3 targetPos;
    private SpriteRenderer sprite;

    void Start()
    {
        anim1 = player1.GetComponent<Animator>();
        anim2 = player2.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    void Update()
    {
        if (GameManager.Instance.InSwapAnimation)
        {
            sprite.enabled = true;
            //Define the target position
            targetPos = new Vector3(gun_offsetX, gun_offsetY);
            if (player1.isCarrier)
                targetPos += player1.transform.position;
            else
                targetPos += player2.transform.position;
            //Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            //Check if current position is the target position
            if (transform.position == targetPos)
            {
                anim1.SetTrigger("swapFinish");
                anim2.SetTrigger("swapFinish");
                GameManager.Instance.InSwapAnimation = false;
                sprite.enabled = false;
            }
        }
        else
        {
            //Set the current position over the torch carrier
            targetPos = new Vector3(torch_offsetX, torch_offsetY);
            targetPos += GameManager.Instance.TorchPlayer.position;
            transform.position = targetPos;
        }
    }
}