using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public static int currentPower = 100;
    public static int maxPower = 500;
    public Slider powerSlider;                                 // Reference to the UI's health bar.
    public Image powerImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The following value is the current power: " + currentPower);
        Debug.Log(currentPower);
    }

    // Update is called once per frame
    void Update()
    {
        // store the old currentPower value
        int oldPower = currentPower;

        // check if currentPower has just been changed
        if (oldPower != currentPower)
        {
            // if so, update the UI
            powerSlider.value = currentPower;
            powerImage.color = flashColour;
        }
        else
        {
            // otherwise, transition the colour back to clear
            powerImage.color = Color.Lerp(powerImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }
}
