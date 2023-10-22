using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim1,anim2; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.MoveBackground = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.MoveBackground)
        {
            //Animate players
            anim1.SetBool("nextWave",true);
            anim2.SetBool("nextWave",true);
            //Move background
            Vector3 newPos = transform.position;
            newPos.x -= Time.deltaTime * speed;
            transform.position = newPos;
        }
        else
        {
            anim1.SetBool("nextWave",false);
            anim2.SetBool("nextWave",false);
        }
    }
}
