using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;
using UnityEngine.AI;

[Action("CustomActions/CommunicationAction")]
public class CommAct : GOAction
{
    public override void OnStart()
    {
        var deerManager = gameObject.GetComponent<DeerManager>();

        if (gameObject.GetComponent<BearSensor>() != null)
        {
            var bearSensor = gameObject.GetComponent<BearSensor>();

            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, bearSensor.GetComponent<SphereCollider>().radius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    if (deerManager != null && hitCollider.gameObject.TryGetComponent(out DeerManager otherDeerManager))
                    {
                        foreach (var foodCollectable in deerManager.FoodCollectables)
                        {
                            otherDeerManager.AddFoodCollectable(foodCollectable);
                        }
                    }
                    break;
                }
            }
        }
        else
        {
            Collider[] goatColliders = Physics.OverlapSphere(gameObject.transform.position, gameObject.GetComponent<SphereCollider>().radius);

            foreach (var goatCollider in goatColliders)
            {
                if (goatCollider.CompareTag("Goat"))
                {
                    Animator goatAnimator = goatCollider.GetComponent<Animator>();
                    if (goatAnimator != null)
                    {
                        goatAnimator.Play("Run");
                    }
                }

                if (goatCollider.CompareTag("Player")){
                Vector3 directionToRun = goatCollider.transform.position - gameObject.transform.position;
                Vector3 runAwayDirection = gameObject.transform.position - directionToRun.normalized * 50f; 
                gameObject.GetComponent<NavMeshAgent>().SetDestination(runAwayDirection);
                }
            }
        }
    }
}
