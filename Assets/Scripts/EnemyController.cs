using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject shot;
    public GameObject shotSpawn;

    Coroutine spawnerCoroutine = null;
    void Start()
    {
        spawnerCoroutine = StartCoroutine(SpawnerCoroutine());
    }
    private IEnumerator SpawnerCoroutine()
    {
        while (true)
        {
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            yield return new WaitForSeconds(1);
        }
    }

}
