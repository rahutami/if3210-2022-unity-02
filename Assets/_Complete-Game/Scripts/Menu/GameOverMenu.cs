﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
