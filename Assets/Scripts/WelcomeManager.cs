using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeManager : MonoBehaviour
{
    public void LoadLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
