using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float damage = 50f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(1);
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(transform.root.gameObject);
                
        }
          
    }
}
