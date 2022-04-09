using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Transform respawnPoint;
    public MenuController menuController;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private AudioSource pop;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winTextObject.SetActive(false);
        pop = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            Respawn();
        }
    }

    void FixedUpdate ()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce (movement * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/5";
        if (count >= 5) 
        {
            winTextObject.SetActive(true);
            menuController.WinGame();
        }
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            pop.Play();
            SetCountText();
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyRespawn"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }
}
