using System.Collections;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    private Torch torch;
    private PlayerController controller;

    [Header("Fire Bar")]
    [SerializeField] private FireBar firebar;
    [SerializeField] private float fireBarOffset_X;
    [SerializeField] private float fireBarOffset_Y;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        torch = transform.GetComponentInChildren<Torch>();
        torch.SetVisible(controller.isCarrier);
        firebar.gameObject.SetActive(controller.isCarrier);
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore commands if not the carrier or game is stopped
        if (GameManager.Instance.InMenu || !controller.isCarrier)
            return;
        if (controller.isPlayer1 && Input.GetKeyDown(KeyCode.F))
            torch.DoSlash();
        else if (!controller.isPlayer1 && Input.GetKeyDown(KeyCode.RightControl))
            torch.DoSlash();
        //Update firebar
        firebar.SetFireAmount(torch.currentFuel);
        firebar.SetPosition(new Vector2(transform.position.x + fireBarOffset_X, transform.position.y + fireBarOffset_Y));
    }

    public void SwitchCarrier()
    {
        bool newCarrierState = !controller.isCarrier;
        controller.isCarrier = newCarrierState;
        torch.DoSwap(newCarrierState);
        firebar.gameObject.SetActive(newCarrierState);
    }

    public void DoTorchHit()
    {
        torch.DoHit();
    }

}
