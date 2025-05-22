using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class HomeManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text welcomeText;      
    public TMP_Text challengeText;     
    public Image challengeImage;    
    public Button viewDetailsButton; 

    [Header("Challenge Sprites")]
    public Sprite[] challengeSprites;  
    public Sprite defaultSprite;    

    void Start()
    {
        
        var auth = FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null)
        {
            string name = string.IsNullOrEmpty(auth.CurrentUser.DisplayName)
                ? auth.CurrentUser.Email.Split('@')[0]
                : auth.CurrentUser.DisplayName;
            welcomeText.text = $"Hi, {name}!";
        }
        else
        {
            welcomeText.text = "Hi there!";
        }

     
        int dayNum = SequentialChallengeProvider.GetDayNumber();
        string challenge = SequentialChallengeProvider.GetChallengeText();
        challengeText.text = $"Day {dayNum}: {challenge}";

        
        if (dayNum - 1 >= 0 && dayNum - 1 < challengeSprites.Length)
            challengeImage.sprite = challengeSprites[dayNum - 1];
        else
            challengeImage.sprite = defaultSprite;

        
        viewDetailsButton.onClick.RemoveAllListeners();
        viewDetailsButton.onClick.AddListener(ViewDetails);
    }

    
    public void ViewDetails()
    {
        SceneManager.LoadScene("ChallengeScene");
    }
}
