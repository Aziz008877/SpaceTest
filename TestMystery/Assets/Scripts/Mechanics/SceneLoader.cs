using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mechanics
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadLevel(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
