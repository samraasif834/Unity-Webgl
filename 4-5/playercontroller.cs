using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
public class playercontroller : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text WinText;
    private Rigidbody rb;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        WinText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movemet = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movemet * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 8)
        {
            WinText.text = "you win";
        }
    }

}
