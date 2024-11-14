using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FruitSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] float spawningRate = 1f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float startingPointAtY;
    [SerializeField] float fruitSpeed = 2f;
    [SerializeField] float fruitLifetime = 10f;
 
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
            int fruitIndex = UnityEngine.Random.Range(0, fruits.Length);
            GameObject fruit = Instantiate(fruits[fruitIndex]);
            fruit.transform.position = new Vector2(xPoint, startingPointAtY);
            fruit.GetComponent<Rigidbody2D>().velocity = Vector2.down * fruitSpeed;
           if(GameManager.Instance.difficulty == GameManager.DIFFICULTY.easy){
                fruit.GetComponent<Rigidbody2D>().gravityScale = 0.1F;
            }else if (GameManager.Instance.difficulty == GameManager.DIFFICULTY.medium)
            {
                fruit.GetComponent<Rigidbody2D>().gravityScale = 0.5F;
            }
            else
            {
                fruit.GetComponent<Rigidbody2D>().gravityScale = 1;
            }

            Destroy(fruit, fruitLifetime);
            yield return new WaitForSeconds(1 /spawningRate);
        }
    }
}