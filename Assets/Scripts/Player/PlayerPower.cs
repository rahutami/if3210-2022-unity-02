using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public int startingPower = 100;
    public int maxPower = 500;

    public int currentPower;

    public Slider powerSlider;

    public Image powerImage;

    // Create method to change currentPower
    public void ChangePower(int newPower)
    {
        // check if newPower is greater than maxPower
        if (newPower > maxPower)
        {
            // set currentPower to maxPower
            currentPower = maxPower;
        }
        else
        {
            // set currentPower to newPower
            currentPower = newPower;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentPower = startingPower;
        Debug.Log("Ini adalah nilai power");
        Debug.Log("Max power: " + maxPower);
        Debug.Log("Current power: " + currentPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
