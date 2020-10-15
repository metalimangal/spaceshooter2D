using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;

    public float speedX, speedY, bounds;
    private bool moveLeft;
    void Start()
    {
        StartCoroutine(Shoot());
        StartCoroutine(RandomStart());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Bounds();
    }

    void Movement()
    {
        Vector3 temp = transform.position;
        temp.y -= speedY * Time.deltaTime;
        transform.position = temp;
        Vector3 moveL = transform.position;
        if (moveLeft)
            moveL.x -= speedX * Time.deltaTime;
        else
            moveL.x += speedX * Time.deltaTime;
        transform.position = moveL;
    }

    void Bounds()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y);
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(Shoot());
    }

    IEnumerator RandomStart()
    {
        yield return new WaitForSeconds(0);
        if (transform.position.x > 0)
            moveLeft = true;
        else
            moveLeft = false;
    }
}
