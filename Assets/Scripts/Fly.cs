using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float height = 3;
    public float speed = 2;
    void Update()
    {
        

        var y = Mathf.Sin(Time.time * speed) * height;

        y = Mathf.Abs(y);

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
