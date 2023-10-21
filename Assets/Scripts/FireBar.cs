using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{
    [SerializeField] float yOffset;
    private Image fireBarFill;

    // Start is called before the first frame update
    void Start()
    {
        fireBarFill = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void SetFireAmount(float amount)
    {
        fireBarFill.fillAmount = amount / 100;
    }
}
