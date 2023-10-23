using UnityEngine;

public class gil : MonoBehaviour
{
    private Rigidbody2D rb;
    public float destroyTime = 10f;

    private void Update()
    {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
            Destroy(gameObject, destroyTime);
        }
    }


