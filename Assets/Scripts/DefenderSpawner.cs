using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner: MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();
        defender = buttons[0].DefenderPrefab;
        buttons[0].HighlightDefenderIcon();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
       
        AttemptToPlaceDefenderAt(GetSquareClicked());
       
    }
    public void SetSelectedDefender(Defender defender)
    {
        this.defender = defender;
    }


    private void AttemptToPlaceDefenderAt(Vector2 position)
    {
        var resourceDisplay = FindObjectOfType<ResourceDisplay>();
        int resourceAmmount = resourceDisplay.Resources;
        int defenderCost = defender.DefenderCost;

        if (resourceAmmount >= defenderCost)
        {
            SpawnDefender(position);
            resourceDisplay.SpendResources(defenderCost);
        
        }
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPosition = SnapToGrid(worldPos);
        return gridPosition;
    }
    private Vector2 SnapToGrid(Vector2 worldPosition)
    {
        float newX = Mathf.RoundToInt(worldPosition.x);
        float newY = Mathf.RoundToInt(worldPosition.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        Defender newDefender = Instantiate(defender, worldPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
