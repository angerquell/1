using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Switch_gun : MonoBehaviour
{
    public GameObject[] weapon;
    private int currentWeaponIndex = 0;
    void Start()
    {
        SwitchToWeapon(currentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToWeapon(0);

        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToWeapon(1);

        }

    }
    void SwitchToWeapon(int newIdex)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false); 
        }
        weapon[newIdex].SetActive(true);
        currentWeaponIndex = newIdex;
    }
}
