using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace CompleteProject
{
    public class MainMenu : MonoBehaviour
    {
        public InputField playerNameInput;
        public static string playerName = "Shooter";
        // Start is called before the first frame update
        public void QuitGame(){
            Debug.Log("Quit");
            Application.Quit();
        }

        public void SetZenMode(){
            EnemyManager.gameMode = "zen";
        }
        
        public void SetWaveMode(){
            EnemyManager.gameMode = "wave";
        }
        
        public void SetName(){
            playerName = playerNameInput.text;
            Debug.Log(playerName);
            Debug.Log(EnemyManager.gameMode);
            SceneManager.LoadScene("_Complete-Game", LoadSceneMode.Single);
        }
    }
}
