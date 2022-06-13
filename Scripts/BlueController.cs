using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{

    // Tail'larýn oluþmasý düzeltilecek.
    // Duvarlara çarpýnca ölünecek.
    // Menü ekraný ayarlanacak.

    #region Variables
    Vector2 dir = Vector2.up;
    KeyCode blueRight = KeyCode.D;
    KeyCode blueLeft = KeyCode.A;
    KeyCode blueUp = KeyCode.W;
    KeyCode blueDown = KeyCode.S;
    #endregion
    [SerializeField] GameObject tailPrefab;

    private void Start()
    {
        InvokeRepeating("Movement", .1f, .1f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(blueUp))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(blueDown))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(blueLeft))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(blueRight))
        {
            dir = Vector2.right;
        }
    }

    public void Movement()
    {
        Vector2 lastPos = transform.position;

        transform.Translate(dir);

        Debug.Log("Tail created!");
        GameObject tail = Instantiate(tailPrefab, lastPos, Quaternion.identity);
        tail.transform.parent = GameObject.Find("BlueTails").transform;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tail"))
        {
            Destroy(gameObject);
            Destroy(GameObject.Find("BlueTails"));

        }
    }

}
