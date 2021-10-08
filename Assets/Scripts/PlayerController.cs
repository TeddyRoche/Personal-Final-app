using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera playerCamera;
    public GameObject BulletPrefab;


    // Update is called once per frame
    void Start()
    {
    }

    

    void Update()
    {


        

        if (Input.GetMouseButtonDown(0))
        {
            GameObject BulletObject = Instantiate (BulletPrefab);
            BulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            BulletObject.transform.forward = playerCamera.transform.forward;
            

        }
    }
}
