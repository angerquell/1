using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float speed;
    public float speed_back;
    public Animator animator;
    public int Direction;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Move", true);
            animator.SetBool("Move_back", false);
            transform.Translate(transform.right * speed * Time.deltaTime);
            Vector3 theScale = transform.localScale;
            Direction = 1;
            theScale.x = Mathf.Abs(theScale.x) * Direction;  
            transform.localScale = theScale;
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            animator.SetBool("Move_back", true);
            animator.SetBool("Move", false);
            transform.Translate(-transform.right * speed_back * Time.deltaTime);
            Vector3 theScale = transform.localScale;
            Direction = -1;
            theScale.x = Mathf.Abs(theScale.x) * Direction;  
            transform.localScale = theScale;
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetBool("Move_back", false);

        }
    }
}
