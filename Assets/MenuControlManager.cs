using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(0);
    }
}
