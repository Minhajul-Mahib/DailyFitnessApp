using UnityEngine;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class AuthManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text statusText;

    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Register()
    {
        string email = emailInput.text.Trim();
        string pw = passwordInput.text;

        // Simple password length check
        if (pw.Length < 6)
        {
            statusText.text = "❌ Password must be at least 6 characters.";
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, pw)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    // Show the Firebase error
                    string msg = task.Exception.Flatten()
                                     .InnerExceptions[0].Message;
                    statusText.text = "❌ Registration failed: " + msg;
                }
                else
                {
                    // Store registration date
                    string today = DateTime.Now.ToString("yyyy-MM-dd");
                    PlayerPrefs.SetString("regDate", today);
                    PlayerPrefs.Save();

                    statusText.text = "✅ Registration successful!";
                    SceneManager.LoadScene("HomeScene");
                }
            });
    }

    public void Login()
    {
        string email = emailInput.text.Trim();
        string pw = passwordInput.text;

        auth.SignInWithEmailAndPasswordAsync(email, pw)
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted || task.IsCanceled)
                {
                    string msg = task.Exception.Flatten()
                                     .InnerExceptions[0].Message;
                    statusText.text = "❌ Login failed: " + msg;
                }
                else
                {
                    SceneManager.LoadScene("HomeScene");
                }
            });
    }
}
