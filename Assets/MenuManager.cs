using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void kontrolakIkusi()
    {
        SceneManager.LoadScene(2);
    }
}
