using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        FindObjectOfType<LivesDisplay>().TakeLives();
        if (otherCollider)
        {
            Destroy(otherCollider.gameObject);
        }
    }
}
