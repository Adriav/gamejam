using System.Collections;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    private TorchHealth torch;
    private PlayerController controller;
    private Animator animator;

    [Header("Fire Bar")]
    [SerializeField] private FireBar firebar;
    [SerializeField] private float fireBarOffset_X;
    [SerializeField] private float fireBarOffset_Y;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        torch = transform.GetComponentInChildren<TorchHealth>();
        firebar.gameObject.SetActive(controller.isCarrier);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore commands if not the carrier or game is stopped
        if (GameManager.Instance.InMenu || !controller.isCarrier)
            return;
        if (controller.isPlayer1 && Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("swing");
            torch.DoSlash();
        }
        else if (!controller.isPlayer1 && Input.GetKeyDown(KeyCode.RightControl))
        {
            animator.SetTrigger("swing");
            torch.DoSlash();
        }
        //Update firebar
        firebar.SetFireAmount(torch.currentFuel);
        firebar.SetPosition(new Vector2(transform.position.x + fireBarOffset_X, transform.position.y + fireBarOffset_Y));
    }

    public void SwitchCarrier()
    {
        bool newCarrierState = !controller.isCarrier;
        controller.isCarrier = newCarrierState;
        torch.DoSwap();
        firebar.gameObject.SetActive(newCarrierState);
    }

    public void DoTorchHit()
    {
        torch.DoHit();
    }

}
