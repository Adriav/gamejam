using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meosn : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.CompareTag("Player")) {


            SceneManager.LoadScene("EndScreen");
            Debug.Log("FInal");
        
        }
    
    
    
    
    }// Start is called before the first frame update
}
