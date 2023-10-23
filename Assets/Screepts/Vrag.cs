using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Vrag : MonoBehaviour
{
    public int heal = 100;
    public float Speed_del;
    public Animator animator;
    private Patrul _patrul;

    private void Awake()
    {
        _patrul = GetComponent<Patrul>();   
    }

    public void TakeDamage(int damage)
    {
        heal -= damage;
        if (heal < 0)
        {
            _patrul.Death();
           animator.SetBool("Died", true);
            Destroy(gameObject, Speed_del);
        }
    }
}
