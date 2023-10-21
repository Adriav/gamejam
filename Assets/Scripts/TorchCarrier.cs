using System.Collections;
using UnityEngine;

public class TorchCarrier : MonoBehaviour
{
    [SerializeField] public bool isCarrier;
    public Torch torch;



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
        if (Input.GetKeyDown(KeyCode.G))
            torch.DoSlash();
    }

    

    public void SwapTorchCarrier()
    {
        isCarrier = !isCarrier;
    }

    
}
