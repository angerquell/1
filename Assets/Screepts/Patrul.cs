using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrul : MonoBehaviour
{
    public float Speed =  0f;
    public int position_distance;
    Transform player;
    public Transform position_point ; 
    public bool movien_right = true;
    public int StopDistance;
    bool chil = false;
    bool agres  = false;
    bool goback = false;
    private bool _isDead;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Death() => _isDead = true;

    void Update()
    {
        if (_isDead)
            return;
        {
            
        }
        if (Vector2.Distance(transform.position, position_point.position) < position_distance && agres == false) 
        
        {
            chil = true;
        }
        if (Vector2.Distance(transform.position, player.position) < StopDistance) {
            agres = true;
            chil = false;
            goback = false;
        }
        if (Vector2.Distance(transform.position, player.position) > StopDistance)
        {
            goback = true;
            agres = false;
        }
        if (chil == true)
        {
            Chil();
        }
        else if (agres == true)
        {
            Agres();
        }
        else if (goback == true)
        {
            GoBack();
        }
    }
    void Chil()
    {
     if(transform.position.x > position_point.position.x + position_distance) {

            movien_right = false;
        }
     else if (transform.position.x < position_point.position.x - position_distance)
        {

            movien_right = true;
        }

     if (movien_right)
        {
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x) * 1;
            transform.localScale = theScale;

        }
     else
        {
            transform.position = new Vector2(transform.position.x -  Speed * Time.deltaTime, transform.position.y);
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x) * -1;
            transform.localScale = theScale;
        }
         
    }

    void Agres()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        
    }
    void GoBack()
    {

        transform.position = Vector2.MoveTowards(transform.position, position_point.position, Speed * Time.deltaTime);
    }

}
