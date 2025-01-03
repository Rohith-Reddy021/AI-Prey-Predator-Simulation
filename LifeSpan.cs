using UnityEngine;
using UnityEngine.AI;

public class LifeSpan : MonoBehaviour
{
    private float timer = 120f;
    private float checkInterval = 45f;
    private bool hasFood = false;
    private float speedReductionInterval = 1f;
    private NavMeshAgent agent;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CheckForFoodRoutine());
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 30f)
        {
            StartCoroutine(ReduceSpeedOverTime());
        }

        if (timer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private System.Collections.IEnumerator CheckForFoodRoutine()
    {
        yield return new WaitForSeconds(checkInterval);

        while (timer > 0f)
        {
            if (!hasFood)
            {
                Destroy(gameObject);
                yield break;
            }
            else{
                hasFood = false;
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    private System.Collections.IEnumerator ReduceSpeedOverTime()
    {
        while (timer > 0f && timer <= 30f)
        {
            if (agent != null)
            {
                agent.speed = Mathf.Max(0, agent.speed - 0.0007f);
            }
            
            yield return new WaitForSeconds(speedReductionInterval);
        }
    }

    public void SetFoodAvailability(bool foodAvailable)
    {
        hasFood = foodAvailable;
    }
}
