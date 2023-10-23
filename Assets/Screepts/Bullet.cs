using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Rigidbody2D rb; // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    { 
        Vrag vrag  = hitInfo.GetComponent<Vrag>();   
        if (vrag != null)
        {
            vrag.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
}
        
