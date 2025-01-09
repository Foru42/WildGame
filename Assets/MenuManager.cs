using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(0);
    }
}
