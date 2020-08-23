using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefferencesController: MonoBehaviour
{
    [SerializeField] float defaultDifficulty = 2;
    [SerializeField] Slider difficultySlider;

    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 3f;
   
    public void SetDifficultyToDefault()
    {
        difficultySlider.value = defaultDifficulty;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty value out of range");
        }
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
