using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int defenderCost = 100;

    public int DefenderCost { get => defenderCost; set => defenderCost = value; }

    public void AddResources(int ammount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(ammount); 
    }
}
