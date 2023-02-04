using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteSeedDealer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D charRb;
    [SerializeField] private EnteController ente;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seed"))
        {
            if (!ente.isCarryingTheSeed())
            {
                Destroy(other.gameObject);
                ente.recieveTheSeed();
            }
        }
    }
}
