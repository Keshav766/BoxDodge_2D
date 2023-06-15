using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    [SerializeField] float playerSpeed = 10f;


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckTapInput();

    }

    void CheckTapInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0)
            {
                playerRB.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
            else
            {
                playerRB.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(0);
        }
    }
}
