using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    public void TakeDamage(float damage)
    
    {
        healthPoints = Mathf.Max(healthPoints - damage,0);
        if(healthPoints <= 0)
        {
            int randomGift = Random.Range(0, 5);
            if (randomGift == 0)
            {
                GameManager.Instance.GiveReward();
            }
            Destroy(gameObject);
        } 


    }
public void CheckFail(float damage)
    
    {
        healthPoints = Mathf.Max(healthPoints - damage,0);
        if(healthPoints <= 0)
        {
            Time.timeScale = 0f;
            GameManager.Instance.OnFail();
        } 
    }
    public void AddHealth(int health)
    {
        healthPoints += health;
    }
}



