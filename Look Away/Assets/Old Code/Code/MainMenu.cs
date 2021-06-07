using UnityEngine;
using UnityEngine.SceneManagement;

namespace Old_Code.Code
{
    public class MainMenu : MonoBehaviour
    {
        private readonly int _totalCoins;

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            PlayerPrefs.DeleteKey("Coin");
            PlayerPrefs.DeleteKey("TotalCoins");
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }
}