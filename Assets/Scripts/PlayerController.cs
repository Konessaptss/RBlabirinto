using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidade;
    public TextMeshProUGUI countText;
    private int count;
    public Text winText;

    
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = " ";

    }


void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count = count + 1;	
            SetCountText();
            if (count >= 11) winText.text = "Vc venceu!";
        }
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
  
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);
    }

   
}
