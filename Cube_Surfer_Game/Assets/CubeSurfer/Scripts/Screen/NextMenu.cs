using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMenu : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
