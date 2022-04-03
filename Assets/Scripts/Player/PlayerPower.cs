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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The power of revelation");
        Debug.Log(maxPower);
        currentPower = startingPower;
        Debug.Log(startingPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
