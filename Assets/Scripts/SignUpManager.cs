using UnityEngine;
using UnityEngine.SceneManagement;

public class SignUpManager : MonoBehaviour
{
    public void GoToRegisterScene()
    {
        SceneManager.LoadScene("RegisterScene");
    }

}
