using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LS.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

[System.Serializable]
public class WeightedRandom<T> : IValueSupplier<T>
{
    [SerializeField]
    SerializedDictionary<T, int> valueWeightDictionary = new();

    public T Value
    {
        get => GetRandom();
        set{Debug.LogWarning($"Tried to set value ({value}) of Weighted Random.");}
    }

    T GetRandom()
    {
        int random = (int)(Random.value * SumWeights);

        int sum = 0;
        foreach (var (value, weight) in valueWeightDictionary)
        {
            sum += weight;
            if (random < sum)
                return value;
        }

        //should not happen!
        Debug.LogError("WeightedRandom could not pick value. Returning default value.");
        return default;
    }

    int SumWeights {
        get{
            int sum = 0;
            foreach (int weight in valueWeightDictionary.Values)
                sum += weight;
            return sum;
        }
    }
}
