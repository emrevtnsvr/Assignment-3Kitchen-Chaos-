using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laserenemy : MonoBehaviour
{
    [SerializeField] float damage = 50f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().CheckFail(damage);
            Destroy(transform.root.gameObject);
                
        }
          
    }
}
