using UnityEngine.AI;
using Pada1.BBCore;
using BBUnity.Actions;
using BBUnity.Conditions;


[Condition("CustomConditions/FoodCondition")]
public class DFoodCon : GOCondition
{
    public override bool Check()
    {   
        if(gameObject.GetComponent<DeerManager>().Food){
        return gameObject.GetComponent<DeerManager>().FoodCollectables.Count > 0;
        }
        return false;
    }
}
