using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationBattleFormer : MonoBehaviour, IBattleFormation
{
    [SerializeField]
    List<Transform> placeLocations;

    public bool Applies(BattleContext context)
    {
        return true;
    }

    public void PlaceUnits(List<BattleUnit> characters)
    {
        for (int i = 0; i < characters.Count && i < placeLocations.Count; i++)
        {
            characters[i].transform.position = placeLocations[i].position;
        }
    }
}
