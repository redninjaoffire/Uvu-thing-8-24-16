using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class poweruppickup : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Pickup destroy;
    private int count;

    void Start ()
    {
        Pickup = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "Victory";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        Powerup.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collision other) 
    {
        if (other.Powerup.CompareTag ( "Pick Up"))
        {
            other.Powerup.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 50)
        {
            winText.text = "Victory!";
        }
    }
}