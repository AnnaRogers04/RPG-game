using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BellCurveRandomGenerator : MonoBehaviour
{
    public int samplecount = 1000;

    void Start()
    {
        for(int i = 0; i <samplecount; i++)
        {
            int randomValue = GenerateBellCurveRandom(1, 6, 2);
      

        } 
        
    }

    int GenerateBellCurveRandom(int min, int max, float peak)
    {
        float randomValue = Random.Range(0f, 1f);
        float bellCurveValue = Mathf.Pow(randomValue, 2);


        float ScaledValue = Mathf.Lerp(min, max, bellCurveValue);
        int finalValue = Mathf.Clamp(Mathf.RoundToInt(ScaledValue), min, max);

        return finalValue;

    }

}
