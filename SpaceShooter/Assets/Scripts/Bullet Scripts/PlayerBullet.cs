using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    private GameController gameController;

    void Start()
	{
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Destroy(gameObject, 3f);
	}
    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            int score = 100;
            gameController.AddScore(score);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}
