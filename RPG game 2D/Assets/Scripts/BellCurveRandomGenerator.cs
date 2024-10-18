using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCurveRandomGenerator : MonoBehaviour
{
    public int sampleCount = 10;

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
    private int GenerateBellCurveRandom(float min, float max, float peak)
    {
        float randomValue = Random.Range(0f, 1f);
        if (peak == (min + max) / 2)
        {
            randomValue = Mathf.Pow(randomValue, 2);
        }
        else
        {
            if (randomValue < 0.5f)
            {
                randomValue = Mathf.Lerp(min, peak, Mathf.Pow(randomValue * 2f, 2)); 
            }
            else
            {
                randomValue = Mathf.Lerp(peak, max, Mathf.Pow((randomValue - 0.5f) * 2f, 2));
            }
        }
        int finalValue = Mathf.Clamp(Mathf.RoundToInt(randomValue), Mathf.RoundToInt(min), Mathf.RoundToInt(max));

        return finalValue;
    }
}



