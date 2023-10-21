using System.Collections;
using UnityEngine;

public class PlayerTorch : MonoBehaviour
{
    [SerializeField] public bool isCarrier;
    private Torch torch;
    [SerializeField] private bool player1 = true;

    void Start()
    {
        torch = transform.GetComponentInChildren<Torch>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ignore commands if not the carrier or game is stopped
        if (!isCarrier || GameManager.Instance.IsPaused || GameManager.Instance.IsGameOver)
            return;
        if (player1 && Input.GetKeyDown(KeyCode.F))
            torch.DoSlash();
        else if (!player1 && Input.GetKeyDown(KeyCode.RightControl))
            torch.DoSlash();
    }

    public void SwitchCarrier()
    {
        isCarrier = !isCarrier;
        torch.DoSwap(isCarrier);
    }

    public void DoTorchHit()
    {
        torch.DoHit();
    }

}
