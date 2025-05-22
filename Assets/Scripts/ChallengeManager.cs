using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text titleText;
    public TMP_Text descText;
    public Image challengeImage;
    public Button completeButton;
    public Button backButton;          

    [Header("Challenge Sprites (in same order)")]
    public Sprite[] challengeSprites;    
    public Sprite defaultSprite;

    void Start()
    {
        
        int dayNum = SequentialChallengeProvider.GetDayNumber();
        string challenge = SequentialChallengeProvider.GetChallengeText();

        
        titleText.text = $"Day {dayNum}: {challenge}";
        descText.text = $"Complete \"{challenge}\" today!";

      
        if (dayNum - 1 < challengeSprites.Length)
            challengeImage.sprite = challengeSprites[dayNum - 1];
        else
            challengeImage.sprite = defaultSprite;

        
        completeButton.onClick.RemoveAllListeners();
        completeButton.onClick.AddListener(MarkComplete);

        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(GoBackHome);
    }

    
    public void MarkComplete()
    {
        int dayNum = SequentialChallengeProvider.GetDayNumber();
        PlayerPrefs.SetInt($"day{dayNum}_completed", 1);
        PlayerPrefs.Save();
        completeButton.GetComponentInChildren<TMP_Text>().text = "✅ Completed";
    }

   
    public void GoBackHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
