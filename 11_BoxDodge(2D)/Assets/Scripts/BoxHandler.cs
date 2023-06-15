using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHandler : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < -6f)
        {
            FindAnyObjectByType<GameManager>().score += 1;
            Destroy(gameObject);
        }
    }
}
