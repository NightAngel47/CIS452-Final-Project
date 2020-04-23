using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Rigidbody2D rb;

    public GameObject player;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;

        Debug.Log(player.transform.position.x);
        Debug.Log(transform.position.x);
        if(player.transform.position.x <= transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
        }

        if (player.transform.position.x > transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
        }


        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
