using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeed : MonoBehaviour
{
    public int startingSpeed = 100;
    public int maxSpeed = 500;

    public int currentSpeed;

    public Slider speedSlider;

    public Image speedImage;

    // Create method to change currentSpeed
    public void ChangeSpeed(int newSpeed)
    {
        // check if newSpeed is greater than maxSpeed
        if (newSpeed > maxSpeed)
        {
            // set currentSpeed to maxSpeed
            currentSpeed = maxSpeed;
        }
        else
        {
            // set currentSpeed to newSpeed
            currentSpeed = newSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Speed");
        Debug.Log(maxSpeed);
        currentSpeed = startingSpeed;
        Debug.Log(startingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
