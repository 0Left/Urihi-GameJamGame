using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBasicBehavior : MonoBehaviour
{
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
