using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    private float timer = 0.5f, xBounds = 2.5f;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomEnemy], new Vector2(Random.Range(-xBounds, xBounds), transform.position.y), transform.rotation);
        yield return new WaitForSeconds(timer);
        StartCoroutine(Spawn());
    }
}
