using System.Collections;
using UnityEngine;

public class TorchCarrier : MonoBehaviour
{
    [SerializeField] public bool isCarrier;
    public Torch torch;
    [SerializeField] private bool player1 = true;

    void Start()
    {
        
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
        if (player1 && Input.GetKeyDown(KeyCode.F))
            torch.DoSlash();
        else if(!player1 && Input.GetKeyDown(KeyCode.RightControl))
            torch.DoSlash();
    }

    

    public void SwapTorchCarrier()
    {
        isCarrier = !isCarrier;
    }

    
}
