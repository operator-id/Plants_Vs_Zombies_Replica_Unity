using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int damage = 1;
    TextMeshProUGUI livesText;
    const string LIVES_DEFAULT_TEXT = "Lives: ";

    public int LivesCount { get; set; }

    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        if (livesText)
        {
            livesText.text = LIVES_DEFAULT_TEXT + LivesCount.ToString();
        }
    }
  
    public void TakeLives()
    {
        LivesCount -= damage;
        UpdateDisplay();
        if (LivesCount <= 0)
        {
            Debug.Log("Level Lost");
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
