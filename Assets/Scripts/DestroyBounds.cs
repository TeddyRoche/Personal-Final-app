using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBounds : MonoBehaviour
{
    private float topBound = 100;
    private float lowerBound = -100;
    private float leftBound = 100;
    private float rightBound = -100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {

            Destroy(gameObject);
        }
        if (transform.position.x > leftBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < rightBound)
        {

            Destroy(gameObject);
        }
    }
}
