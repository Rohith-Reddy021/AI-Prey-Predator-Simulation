using UnityEngine.AI;
using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;
using BBUnity.Conditions;
using System.Collections.Generic;


[Condition("CustomConditions/WanderCondition")]
public class WanderCondition : GOCondition
{
    public override bool Check()
    { 
        if(gameObject.GetComponent<DeerManager>().FoodCollectables.Count==0 || gameObject.GetComponent<DeerManager>().WaterCollectables.Count==0){
        return true;
        }
        return false;
    }
}
