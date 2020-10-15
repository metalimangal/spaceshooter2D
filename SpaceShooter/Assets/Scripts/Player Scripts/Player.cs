using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f, xBounds = 2.5f;
    public Transform bulletPosition;
    public GameObject Bullet;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float ver = speed * Time.deltaTime * .5f;
        float hor = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(hor,ver));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xBounds, xBounds), transform.position.y);
    }

    IEnumerator Shoot()
    {
        Instantiate(Bullet, bulletPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy" || target.tag == "EnemyBullet")
        {
            Destroy(target.gameObject);
            gameObject.SetActive(false);
        }
    }
}
