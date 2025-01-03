using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

[Condition("CustomConditions/NightCondition")]
public class Night : GOCondition
{
    private DayNight dayNightScript;

    public override bool Check()
    { 
        if (dayNightScript == null)
        {
            GameObject directionalLight = GameObject.Find("Directional Light");
            if (directionalLight != null)
            {
                dayNightScript = directionalLight.GetComponent<DayNight>();
            }
        }
        return dayNightScript != null && dayNightScript.IsNight;
    }
}
