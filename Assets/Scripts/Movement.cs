using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 1f;
  

    public CharacterController controller;



    // Start is called before the first frame update
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

   

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
 

        controller.Move(new Vector3(inputX, 0, inputY) * movementSpeed * Time.deltaTime);
    }
}
