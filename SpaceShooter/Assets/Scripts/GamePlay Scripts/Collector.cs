using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public float height;
    void Start()
    {
        height = GameObject.FindGameObjectWithTag("BG").GetComponent<BoxCollider2D>().size.y;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            Vector2 tempPos = target.transform.position;

            tempPos.y += height * 3;

            target.transform.position = tempPos;
        }
        else if (target.tag == "Enemy" || target.tag == "EnemyBullet")
        {
            Destroy(target.gameObject);
        }
    }
}
