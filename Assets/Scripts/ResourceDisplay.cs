using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    int resources;
    TextMeshProUGUI resourcesText;

    public int Resources { get => resources; set => resources = value; }

    void Start()
    {
        resourcesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        if (resourcesText)
        {
            resourcesText.text = Resources.ToString();
        }
    }
    public void AddResources (int ammount)
    {
        Resources += ammount;
        UpdateDisplay();
    }

    public void SpendResources(int ammount)
    {
        if (Resources >= ammount)
        {
            Resources -= ammount;
            UpdateDisplay();
        }
    }
}

