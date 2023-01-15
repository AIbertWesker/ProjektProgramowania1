using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuchDoWaypoint : MonoBehaviour
{
    public Transform[] waypointy;

    [SerializeField]
    private float movementSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;
    public bool moveAllow = false;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypointy[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(moveAllow){ //to ma lapac z kontroli
            Move();
        }
    }

    private void Move()
    {
        if(waypointIndex <= waypointy.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointy[waypointIndex].transform.position, movementSpeed*Time.deltaTime);
            if(transform.position == waypointy[waypointIndex].transform.position)
            {
                waypointIndex = waypointIndex+1;
            }

            //testy
        }

    }
}
