using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] float defaultDifficulty = 2f;
    [SerializeField] Slider difficultySlider;

    private void Start()
    {
        difficultySlider.value = PlayerPrefferencesController.GetDifficulty();

    }

    public void SaveAndExit()
    {
        PlayerPrefferencesController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().QuitToMenu();
    }
    public void SetDifficultyToDefault()
    {
        difficultySlider.value = defaultDifficulty;
    }
}
