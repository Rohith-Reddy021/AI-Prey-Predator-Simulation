using UnityEngine.AI;
using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;
using BBUnity.Conditions;
using System.Collections.Generic;


[Condition("CustomConditions/WaterCondition")]
public class DWaterCon : GOCondition
{
    public override bool Check()
    { 
        if(gameObject.GetComponent<DeerManager>().Drink){
        return gameObject.GetComponent<DeerManager>().WaterCollectables.Count > 0;
        }
        return false;
    }
}
