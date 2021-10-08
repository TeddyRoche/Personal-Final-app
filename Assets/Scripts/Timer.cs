using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;
    public int secondsLeft = 30;
    public GameObject Enemy;
    [SerializeField] Text countDownText;

    void Start()
    {

            
        
            currentTime = startingTime;
        
        
    }

    void Update()
    {
        
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0.00");

        
        if (currentTime <= 60)
        {
            countDownText.color = Color.green;
        }
        if (currentTime <= 30)
        {
            countDownText.color = Color.yellow;
        }
        if (currentTime <= 10)
        {
            countDownText.color = Color.red;
            
        }
        if (currentTime <= 0)
        {
            SceneManager.LoadScene(3);
        }
        




    }

}
