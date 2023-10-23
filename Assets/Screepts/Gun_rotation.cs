using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun_rotation : MonoBehaviour
{
    public float offset;
    public float maxRotation;
    public Player_move _mover;


    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(_mover.Direction*difference.y, _mover.Direction * difference.x) * Mathf.Rad2Deg;
        rotateZ = Mathf.Clamp(rotateZ, -maxRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
      
    }
}