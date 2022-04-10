using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSpeed : MonoBehaviour
{
    public static int currentSpeed = 100;
    public static int maxSpeed = 500;
    public Slider speedSlider;
    public Image speedImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The following value is the current speed: " + currentSpeed);
        Debug.Log(PlayerSpeed.currentSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
