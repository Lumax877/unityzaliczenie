using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class There_and_back : MonoBehaviour
{
    public List<Transform> targetPoints;
    public float speed = 5f;

    private List<Transform> waypoints;
    private int currentindex = 0;
    private bool forward = true;

    void Start()
    {
        waypoints = new List<Transform>(targetPoints);
    }

    void Update()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        MovePlatform(waypoints[currentindex].position);

        if (transform.position == waypoints[currentindex].position)
        {
            if (forward)
            {
                currentindex++;
            }
            else
            {
                currentindex--;
            }

            if (currentindex >= waypoints.Count)
            {
                currentindex = waypoints.Count - 2;
                forward = false;
            }
            else if (currentindex < 0)
            {
                currentindex = 1;
                forward = true;
            }
        }
    }

    void MovePlatform(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
