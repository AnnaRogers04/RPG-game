using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
public class BellCurveRandomGenerator : MonoBehaviour
{
    public int samplecount = 1000;

    void start()
    {
        for(int i = 0; i <samplecount; i++)
        {
            int randomValue = GenerateBellCurveRandom(1, 6, 2);
            debug.log(randomValue);

        } 
        
    }

    int GenerateBellCurveRandom(int min, int max, float peak)
    {
        float randomValue = randomValue.range(0f, 1f);
        float bellCurveValue = mathf.Pow(randomValue, 2);


        float ScaledValue = Mathf.lerp(min, max, bellCurveValue);
        int finalValue = mathf.Clamp(mathf,RoundToInt(ScaledValue), min, max);

        return finalValue;

    }

}
