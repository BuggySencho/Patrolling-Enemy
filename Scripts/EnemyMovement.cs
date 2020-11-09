using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float distanceToWaypoint = 0.5f;
    public Path path;
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
     private Waypoint target;

    private int index = 0;
    public bool playerFound;

    [SerializeField]
    private GameObject player;

    public void Awake()
    {
        path = GetComponent<Path>();
        target = path.waypoints[0];
    }

    public void Update()
    {
        if (!playerFound)
        {
            transform.Translate(Vector3.forward * speed / 100);
            transform.LookAt(target.transform);
            if (index >= path.waypoints.Length - 1)
            {
                index = 1;
            }   
        }
        else
        {
            Vector3 playerPos = player.transform.position;
            playerPos.y = transform.position.y;
            transform.LookAt(playerPos);
        }        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Waypoint>())
        {
            if (index < path.waypoints.Length -1)
            {
                target = path.GetNextWaypoint(index);
            }
             transform.LookAt(target.transform);
            index++;
        }

     /*   if (collision.gameObject.CompareTag("Player"))
        {
            playerFound = false;
        }   */
    }
}
