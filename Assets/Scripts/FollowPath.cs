using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public List<Vector3> path;

    private Vector3 target;

    public float speed = 5;

    private int currentPoint = 0;

    private bool reverse = false;

    private void Start()
    {
        target = path[currentPoint];
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 0.3f)
        {
            /*if (currentPoint > path.Count)
            {
                currentPoint = 0;
            }
            */
            if (reverse == false)
            {
                
                if (currentPoint > path.Count)
                {
                    reverse = true;
                }
                target = path[++currentPoint];
            }
            if (reverse == true)
            {
                
                if (currentPoint < 0)
                {
                    reverse = false;
                }
                target = path[--currentPoint];
            }



        }
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < path.Count - 1; i++)
        {
            Gizmos.DrawLine(path[i], path[i + 1]);
        }
    }
}

