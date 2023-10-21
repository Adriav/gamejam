using System.Collections;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    private Torch torch;

    void Start()
    {
        torch = transform.GetComponentInChildren<Torch>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore commands if not the carrier or game is stopped
        if (!GetComponent<PlayerController>().isCarrier || GameManager.Instance.IsPaused || GameManager.Instance.IsGameOver)
            return;
        if (GetComponent<PlayerController>().isPlayer1)
        {
            if (Input.GetKeyDown(KeyCode.F))
                torch.DoSlash();
        }
        else
            if (Input.GetKeyDown(KeyCode.RightControl))
                torch.DoSlash();
    }

    public void SwitchCarrier()
    {
        bool newCarrierState = !GetComponent<PlayerController>().isCarrier;
        GetComponent<PlayerController>().isCarrier = newCarrierState;
        torch.DoSwap(newCarrierState);
    }

    public void DoTorchHit()
    {
        torch.DoHit();
    }

}
