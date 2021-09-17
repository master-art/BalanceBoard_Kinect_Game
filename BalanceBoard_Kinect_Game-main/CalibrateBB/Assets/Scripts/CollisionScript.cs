using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject blastEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AICar"))
        {
            Destroy(Instantiate(blastEffect, transform.position, transform.rotation));
            Destroy(collision.gameObject);
        }
    }
}
