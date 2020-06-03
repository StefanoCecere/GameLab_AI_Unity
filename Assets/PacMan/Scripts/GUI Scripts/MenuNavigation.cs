using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace PacMan
{
    public class MenuNavigation : MonoBehaviour
    {

        public void MainMenu()
        {
            SceneManager.LoadScene("menu");
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene("game");
        }

        public void HighScores()
        {
            SceneManager.LoadScene("scores");

        }

        public void Credits()
        {
            SceneManager.LoadScene("credits");
        }

        public void SourceCode()
        {
            Application.OpenURL("https://github.com/vilbeyli/Pacman-Clone/");
        }
    }
}