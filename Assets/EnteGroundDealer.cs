using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteGroundDealer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D charRb;
    [SerializeField] private EnteController ente;
    [SerializeField] private Collider2D goodSoil;
    private bool isOnGoodSoil = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)&&isOnGoodSoil)
        {
            if(ente.isCarryingTheSeed()&&goodSoil != null)
            {
                goodSoil.gameObject.GetComponent<SeedOnGroundDeal>().startGrowing();
                ente.useTheSeed();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("GroundWaitForSeed"))
        {
            isOnGoodSoil = true;
            goodSoil = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("GroundWaitForSeed"))
        {
            isOnGoodSoil = false;
            goodSoil = null;
        }
    }
}
