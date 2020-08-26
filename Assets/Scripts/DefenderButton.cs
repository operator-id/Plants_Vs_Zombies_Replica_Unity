using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    public Defender DefenderPrefab { get => defenderPrefab; set => defenderPrefab = value; }

    private void Start()
    {
        DisplayDefenderPriceOnButton();
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(125, 125, 125, 255);

        }
        HighlightDefenderIcon();
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(DefenderPrefab);

    }
    public void HighlightDefenderIcon()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void DisplayDefenderPriceOnButton()
    {
        TextMeshProUGUI costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text added");
        }
        else
        {
            costText.text = defenderPrefab.DefenderCost.ToString();
        }
    }
}
