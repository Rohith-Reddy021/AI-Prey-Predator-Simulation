using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

[Condition("CustomConditions/ReproductionCondition")]
public class ReproductionCondition : GOCondition
{
    public override bool Check()
    { 
        if(gameObject.GetComponent<DeerManager>().Food==false && gameObject.GetComponent<DeerManager>().Drink==false){
            return true;
        }
        return false;
    }
}
