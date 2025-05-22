using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    [Header("Prefabs & References")]
    public GameObject dayCardPrefab;  
    public Transform gridParent;     
    public Button homeButton;     

    void Start()
    {
        
        for (int i = gridParent.childCount - 1; i >= 0; i--)
        {
            Destroy(gridParent.GetChild(i).gameObject);
        }

        
        int totalDays = SequentialChallengeProvider.GetTotalDays();
        for (int day = 1; day <= totalDays; day++)
        {
            GameObject card = Instantiate(dayCardPrefab, gridParent);

            
            TMP_Text dayLabel = card.transform.Find("DayLabel").GetComponent<TMP_Text>();
            TMP_Text statusIcon = card.transform.Find("StatusIcon").GetComponent<TMP_Text>();

            
            dayLabel.text = $"Day {day}";
            bool completed = PlayerPrefs.GetInt($"day{day}_completed", 0) == 1;
            statusIcon.text = completed ? "V" : "X";
        }

        
        homeButton.onClick.RemoveAllListeners();
        homeButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HomeScene");
        });
    }
}
