using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using Unity.Notifications.Android;  

public class SettingsManager : MonoBehaviour
{
    [Header("UI References")]
    public Image profileImage;      
    public TMP_Text nameText;        
    public TMP_Text emailText;        
    public Button signOutButton;     
    public Toggle remindersToggle;   

    void Start()
    {
        
        var user = FirebaseAuth.DefaultInstance.CurrentUser;
        if (user != null)
        {
            string display = string.IsNullOrEmpty(user.DisplayName)
                ? user.Email.Split('@')[0]
                : user.DisplayName;
            nameText.text = display;
            emailText.text = user.Email;
        }
        else
        {
            nameText.text = "Guest";
            emailText.text = "";
        }

       
        signOutButton.onClick.RemoveAllListeners();
        signOutButton.onClick.AddListener(() =>
        {
            FirebaseAuth.DefaultInstance.SignOut();
            SceneManager.LoadScene("LoginScene");
        });

        
        bool wasOn = PlayerPrefs.GetInt("remindersOn", 0) == 1;
        remindersToggle.isOn = wasOn;

        
        remindersToggle.onValueChanged.RemoveAllListeners();
        remindersToggle.onValueChanged.AddListener((isOn) =>
        {
            PlayerPrefs.SetInt("remindersOn", isOn ? 1 : 0);
            PlayerPrefs.Save();

            if (isOn)
            {
                // Schedule daily notification at 9:00am
                NotificationManager.Initialize();
                NotificationManager.ScheduleDaily(
                    "DailyFit Challenge",
                    $"Today’s challenge: {SequentialChallengeProvider.GetChallengeText()}",
                    9, 0
                );
            }
            else
            {
                
                NotificationManager.CancelAll();
            }

            Debug.Log($"Daily reminders toggled: {isOn}");
        });

        
        if (wasOn)
        {
            NotificationManager.Initialize();
            NotificationManager.ScheduleDaily(
                "DailyFit Challenge",
                $"Today’s challenge: {SequentialChallengeProvider.GetChallengeText()}",
                9, 0
            );
        }
    }
}
