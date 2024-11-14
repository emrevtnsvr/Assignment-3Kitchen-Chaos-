using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fastFood;
    [SerializeField] float spawningRate = 1f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float startingPointAtY;
    [SerializeField] float fastFoodSpeed = 2f;
    [SerializeField] float fastFoodlifeTime = 10f;
    [SerializeField] float damage = 50f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(transform.root.gameObject);

        }

    }

    Coroutine spawnerCoroutine = null;
    void Start()
    {
        spawnerCoroutine = StartCoroutine(SpawnerCoroutine());
    }

    private IEnumerator SpawnerCoroutine()
    {
        while (true)
        {
            float xPoint = UnityEngine.Random.Range(minX, maxX);
            int fastFoodIndex = UnityEngine.Random.Range(0, fastFood.Length);
            GameObject food = Instantiate(fastFood[fastFoodIndex]);
            food.transform.position = new Vector2(xPoint, startingPointAtY);
            food.GetComponent<Rigidbody2D>().gravityScale = 0.02F;
            Destroy(food, fastFoodlifeTime);
            yield return new WaitForSeconds(1 / spawningRate);
        }
    }
}
