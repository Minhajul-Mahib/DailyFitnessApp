using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    public void GoToLoginScene() {
        SceneManager.LoadScene("LoginScene");
    }
}
