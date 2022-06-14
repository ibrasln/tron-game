using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovementController : MonoBehaviour
{

    Vector2 dir = Vector2.up;
    public KeyCode up, down, right, left;
    [SerializeField] GameObject tailPrefab, parentOfTails;
    public string tailTag;

    public enum directionStatus {dirUp, dirDown, dirLeft, dirRight};
    public directionStatus currentDirection;

    private void Start()
    {
        InvokeRepeating("Movement", .05f, .05f);
    }

    public void Movement()
    {

        //if (Input.GetKey(up))
        //{
        //    dir = Vector2.up;
        //    currentDirection = directionStatus.dirUp;
        //}
        //else if (Input.GetKey(down))
        //{
        //    dir = Vector2.down;
        //    currentDirection = directionStatus.dirDown;
        //}
        //else if (Input.GetKey(right))
        //{
        //    dir = Vector2.right;
        //    currentDirection = directionStatus.dirRight;
        //}
        //else if (Input.GetKey(left))
        //{
        //    dir = Vector2.left;
        //    currentDirection = directionStatus.dirLeft;
        //}

        // Player can't turn back!!
        switch (currentDirection)
        {
            case directionStatus.dirUp:
                CantTurnBack(down, Vector2.up, directionStatus.dirUp, left, right, Vector2.left, Vector2.right, directionStatus.dirLeft, directionStatus.dirRight);
                break;
            case directionStatus.dirDown:
                CantTurnBack(up, Vector2.down, directionStatus.dirDown, left, right, Vector2.left, Vector2.right, directionStatus.dirLeft, directionStatus.dirRight);
                break;
            case directionStatus.dirLeft:
                CantTurnBack(right, Vector2.left, directionStatus.dirLeft, up, down, Vector2.up, Vector2.down, directionStatus.dirUp, directionStatus.dirDown);
                break;
            case directionStatus.dirRight:
                CantTurnBack(left, Vector2.right, directionStatus.dirRight, up, down, Vector2.up, Vector2.down, directionStatus.dirUp, directionStatus.dirDown);
                break;
        }

        transform.Translate(dir);
        SpawnTail();
    }

    public void CantTurnBack(KeyCode negativeButton, Vector2 direction, directionStatus status, KeyCode otherButton1, KeyCode otherButton2, Vector2 otherDir1, Vector2 otherDir2, directionStatus otherStatus1, directionStatus otherStatus2)
    {

        

        if (Input.GetKey(negativeButton))
        {
            dir = direction;
            currentDirection = status;
            Debug.Log("Negatif!");
        }
        else if (Input.GetKey(otherButton1))
        {
            dir = otherDir1;
            currentDirection = otherStatus1;
            Debug.Log("Other1");
        }
        else if (Input.GetKey(otherButton2))
        {
            dir = otherDir2;
            currentDirection = otherStatus2;
            Debug.Log("Other2");
        }
    }

    public void SpawnTail()
    {
        GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
        tail.transform.parent = parentOfTails.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tailTag))
        {
            GameOver();
        }

        if (collision.CompareTag("Wall"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
        Destroy(parentOfTails);
        //Time.timeScale = 0;
    }

}
