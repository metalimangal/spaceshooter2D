using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float offset;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player.activeInHierarchy)
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
    }
}
