using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    public KeyCode up, down, left, right;
    public float speed;
    [SerializeField] GameObject tailPrefab, parentOfTails;
    Collider2D wall;
    Vector2 lastWallEnd;
    public string tailTag;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = Vector2.up * speed;
    }

    void Update()
    {

        if (Input.GetKey(up))
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(down))
        {
            rb.velocity = Vector2.down * speed;
        }
        else if (Input.GetKey(left))
        {
            rb.velocity = Vector2.left * speed;
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = Vector2.right * speed;
        }
        SpawnTail();
        fitColliderBetween(wall, lastWallEnd, transform.position);
    }

    void SpawnTail()
    {
        lastWallEnd = transform.position;
        GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
        wall = tail.GetComponent<Collider2D>();
        tail.transform.parent = parentOfTails.transform;

    }

    void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist + 1, 1);
        else
            co.transform.localScale = new Vector2(1, dist + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag(tailTag))
        {
            print($"Player {gameObject.name} Lost!");
            Destroy(gameObject);
        }
    }

}
