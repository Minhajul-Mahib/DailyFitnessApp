using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{

    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }


    public void GoToProgress()
    {
        SceneManager.LoadScene("ProgressScene");
    }


    public void GoToProfile()
    {
        SceneManager.LoadScene("ProfileScene");
    }


    public void GoToChallenge()
    {
        SceneManager.LoadScene("ChallengeScene");
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void GoToLogIn()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
