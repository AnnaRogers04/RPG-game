using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCurveRandomGenerator : MonoBehaviour
{
    public int sampleCount = 1000;

    private void Start()
    {
        for (int i = 0; i < sampleCount; i++)
        {
            int D6Dice = GenerateBellCurveRandom(1, 6, 2);
            int D12Dice = GenerateBellCurveRandom(1, 12, 8);
            int D20Dice = GenerateBellCurveRandom(1, 20, 12);
            Debug.Log($"Generated D6: {D6Dice}, D12: {D12Dice}, D20: {D20Dice}");
        } 
    }

    private int GenerateBellCurveRandom(int min, int max, float peak)
    {
        float randomValue = Random.Range(0, 1f);
        float bellCurveValue = Mathf.Pow(randomValue, peak);
        float scaledValue = Mathf.Lerp(min, max, bellCurveValue);
        int finalValue = Mathf.Clamp(Mathf.RoundToInt(scaledValue), min, max);
        return finalValue;
    }
}


