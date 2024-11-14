using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[System.Serializable]

public class Boundary
{
      public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D physic;

    [SerializeField] int speed;

    

    public Boundary boundary;
    public GameObject shot;
    public GameObject shotSpawn;
   


    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
       
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Health>().CheckFail(10);
           // Destroy(transform.root.gameObject);
         
        }
    }

 


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
        }
    }


    void FixedUpdate()
    {
        float moveHorizantal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizantal, moveVertical);

        physic.velocity = movement * speed;


        float clampedX = Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax);
        float clampedY = Mathf.Clamp(physic.position.y, boundary.yMin, boundary.yMax);

        physic.position = new Vector2(clampedX, clampedY);
    }

}
