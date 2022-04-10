using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPower : MonoBehaviour
{
    public static int currentPower = 100;
    public static int maxPower = 500;

    public Slider powerSlider;

    public Image powerImage;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The following value is the current power: " + currentPower);
        Debug.Log(currentPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
