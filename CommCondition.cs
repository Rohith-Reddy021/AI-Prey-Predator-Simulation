using UnityEngine;
using Pada1.BBCore;
using BBUnity.Conditions;

[Condition("CustomConditions/CommunicationCondition")]
public class CommCondition : GOCondition
{
    private BearSensor bearSensor;
    private DeerSensor deerSensor;

    public override bool Check()
    {
        if (gameObject.GetComponent<BearSensor>() != null)
            bearSensor = gameObject.GetComponent<BearSensor>();
        
        if (gameObject.GetComponent<DeerSensor>() != null)
            deerSensor = gameObject.GetComponent<DeerSensor>();

        if (bearSensor != null && bearSensor.comm)
        {
            return true;
        }

        if (deerSensor != null && deerSensor.comm)
        {
            return true;
        }
        
        return false;
    }
}
