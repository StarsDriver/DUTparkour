using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallObstacles : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
