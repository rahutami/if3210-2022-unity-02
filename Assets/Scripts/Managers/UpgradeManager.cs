using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static bool canUpgrade = false;
    public static int numberOfBullets = 1;
    public static int rateOfFire = 1;
    public static int angleBetweenBullets = 0;
    public Slider rofSlider;
    public Image rofImage;
    public Slider diagSlider;
    public Image diagImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canUpgrade)
        {
            // Update the UI to 100%
            rofSlider.value = 100;
            rofImage.color = flashColour;
            diagSlider.value = 100;
            diagImage.color = flashColour;
            // Wait for 'r' to be pressed, than update rateOfFire
            if (Input.GetKeyDown(KeyCode.R))
            {
                rateOfFire += 10;
                canUpgrade = false;
            }
            // Wait for 't' to be pressed, then update numberOfBullets and angleBetweenBullets
            if (Input.GetKeyDown(KeyCode.T))
            {
                numberOfBullets += 2;
                angleBetweenBullets = (int)(360 / numberOfBullets);
                canUpgrade = false;
            }
        }
        else {
            // Update the UI to 0%
            rofSlider.value = 0;
            rofImage.color = Color.clear;
            diagSlider.value = 0;
            diagImage.color = Color.clear;
        }
    }
}
