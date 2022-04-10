using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputField playerName;
    // Start is called before the first frame update
    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetZenMode(){
        GameMode.gameMode = "zen";
    }
    
    public void SetWaveMode(){
        GameMode.gameMode = "wave";
    }
    
    public void SetName(){
        GameMode.playerName = playerName.text;
        Debug.Log(GameMode.playerName);
        Debug.Log(GameMode.gameMode);
        SceneManager.LoadScene("_Complete-Game", LoadSceneMode.Single);
    }
}
