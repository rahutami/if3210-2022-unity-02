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
