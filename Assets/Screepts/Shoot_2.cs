using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Shoot_2 : MonoBehaviour
{
    public Transform firepoint, gil_point;
    public GameObject gil;
    public int Damage;
    public LineRenderer line;
    public int Current_Bullet, Max_Bullet, Ammo;
    private bool isShooting = false;
    private float nextFireTime = 0.0f;
    public float fireRateAuto = 0.1f;
    public FireMode fireMode = FireMode.Single;
    public int Fire_mode = 1;
    public int Fire_m = 1;
    public Text displayText; 
    public float time_display = 1.0f;



    private void HideText()
    {
        displayText.text = "";
    }
   

    public Animator animator;
    
    public enum FireMode
    {
        Single,
        Auto 
    }

    private void Start()
    {
          
         Current_Bullet = Max_Bullet;   
         line.enabled = false;
    }

    void Update()
    {
        
        if (Current_Bullet > 0)
        {
            if (fireMode == FireMode.Single)
            {
                if (Input.GetButtonDown("Fire1") && !isShooting)
                {
                    Shoot();

                }
                else
                {
                    animator.SetBool("Reload", false);
                    animator.SetBool("fire", false);


                }
            }
            else if (fireMode == FireMode.Auto) {
                if (Input.GetKey(KeyCode.Mouse0) && !isShooting)
                {
                    Shoot();

                }
                else
                {
                    animator.SetBool("Reload", false);
                    animator.SetBool("fire", false);


                }
            }
        }
        
        if  (Input.GetKeyDown(KeyCode.R))
        {
            if (Current_Bullet < Max_Bullet && Ammo > 0)
            {
                animator.SetBool("Reload", true);
                Reload();
            }
             
        }
       
       if (Current_Bullet == 0)
       
        {
            animator.SetBool("fire", false);
        }
       if (Input.GetKeyDown(KeyCode.B))
        {
             
            
            if (Fire_mode == 1)
            {
                if (Fire_m == 1) {
                    fireMode = FireMode.Auto;
                    Fire_m = 0;
                    displayText.text = "Авто";
                    Invoke("HideText", time_display);
                }
                else if (Fire_m == 0)
                {
                    fireMode = FireMode.Single;
                    Fire_m = 1;
                    displayText.text = "Одиночные";
                    Invoke("HideText", time_display);
                }

            }
        }
        


    }
  

    private void Shoot()
    {

        if (fireMode == FireMode.Single)
        {
            GameObject item = Instantiate(gil, gil_point.position, Quaternion.identity);
            animator.SetBool("fire", true);
            Current_Bullet--;
            StartCoroutine(fire());
        }
        else if (fireMode == FireMode.Auto)
        {
            if (Time.time >= nextFireTime)
            {
                GameObject item = Instantiate(gil, gil_point.position, Quaternion.identity);
                Current_Bullet--;
                nextFireTime = Time.time + fireRateAuto;
                StartCoroutine(fire());
            }
        }
    }





    void Reload()
    {

        int ammm_reload = Max_Bullet - Current_Bullet;
        if (Ammo >= ammm_reload)
        {
            Ammo -= ammm_reload;
            Current_Bullet = Max_Bullet;
        }
        else if (Ammo > 0)
        {
            Current_Bullet += Ammo;
            Ammo = 0;
        }

        if (Ammo == 0)
        {
            animator.SetBool("Raload", false);

        }

    }


    IEnumerator fire()
    {
        isShooting = true;
       RaycastHit2D hitInfo =  Physics2D.Raycast(firepoint.position, firepoint.right);
        if (hitInfo)
        {
           Vrag vrag =  hitInfo.transform.GetComponent<Vrag>();
            
            if (vrag != null)
            {
                vrag.TakeDamage(Damage);
            }
            
            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, hitInfo.point);
        }
        else
        {
            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, firepoint.position+ firepoint.right * 100);
        }
        line.enabled = true; 
        yield return new WaitForSeconds(0.02f);
        line.enabled = false;  
        isShooting = false;
    }
}
