using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ControladorEsfera : MonoBehaviour
{

    public float speed;
    private int count;
    public TMP_Text text;
    public TMP_Text winText;

    
    void Start()
    {
        count = 0;
        updateCounter();
        winText.text = "";
        
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        GetComponent<Rigidbody>().AddForce(horizontal, 0, vertical * speed);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pickup")
        {
            Destroy(other.gameObject);
            count++;
            updateCounter();
        }
    }

    void updateCounter()
    {
        text.text = "Puntos: " + count;
        
        int numPickups = GameObject.FindGameObjectsWithTag("pickup").Length;
        if (numPickups == 1)
        {
            winText.text = "Has Ganado!";
        }
        {
            
        }
    }
}
