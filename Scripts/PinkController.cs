using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkController : MonoBehaviour
{

    #region Pink variables
    Vector2 dir = Vector2.up / 2;
    KeyCode pinkRight = KeyCode.RightArrow;
    KeyCode pinkLeft = KeyCode.LeftArrow;
    KeyCode pinkUp = KeyCode.UpArrow;
    KeyCode pinkDown = KeyCode.DownArrow;
    #endregion
    [SerializeField] GameObject tailPrefab;

    private void Start()
    {
        //InvokeRepeating("Movement", .1f, .1f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(pinkUp))
        {
            dir = Vector2.up / 2;
        }
        else if (Input.GetKey(pinkDown))
        {
            dir = Vector2.down / 2;
        }
        else if (Input.GetKey(pinkLeft))
        {
            dir = Vector2.left / 2;
        }
        else if (Input.GetKey(pinkRight))
        {
            dir = Vector2.right / 2;
        }
        Movement();
        
    }

    public void Movement()
    {
        Vector2 lastPos = transform.position;
        transform.Translate(dir);
        GameObject tail = Instantiate(tailPrefab, lastPos, Quaternion.identity);
        tail.transform.parent = GameObject.Find("PinkTails").transform;
    }
}
