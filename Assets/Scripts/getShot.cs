using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class getShot : MonoBehaviour
{
    public GameObject shot;
    public bool isEnenmyShot = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            Points.instance.AddPoints();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
            Points.instance.AddPoints();

        }
    }
    

        // Update is called once per frame
        void Update()
    {
        
    }
}
