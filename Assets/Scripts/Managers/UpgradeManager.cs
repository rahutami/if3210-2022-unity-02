using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static bool canUpgrade = false;
    public static int numberOfBullets = 3;
    public static int rateOfFire = 1;
    public static int angleBetweenBullets = 30;
    public Slider rofSlider;
    public Image rofImage;
    public Slider diagSlider;
    public Image diagImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // Start is called before the first frame update
    void Start()
    {
        // Init UI with 0
        rofSlider.value = 0;
        diagSlider.value = 0;
        rofImage.color = Color.clear;
        diagImage.color = Color.clear;
    }

    void UpgradeROF()
    {
        rofSlider.value = 0;
        rofImage.color = Color.clear;
        diagSlider.value = 0;
        diagImage.color = Color.clear;
        // False canUpgrade
        canUpgrade = false;
        // Increase rateOfFire
        rateOfFire += 10;
    }

    void UpgradeDiag() {
        rofSlider.value = 0;
        rofImage.color = Color.clear;
        diagSlider.value = 0;
        diagImage.color = Color.clear;
        // False canUpgrade
        canUpgrade = false;
        numberOfBullets += 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (canUpgrade && Input.GetKeyDown(KeyCode.R))
        {
            UpgradeROF();
        }
        else if (canUpgrade && Input.GetKeyDown(KeyCode.D))
        {
            UpgradeDiag();
        }
    }
}
