using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DeerManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> floorAreas;  
    public List<GameObject> WaterCollectables = new();
    public List<GameObject> FoodCollectables = new();
    Animator animator;

    public bool Drink=true;
    public bool Wander=true;
    public bool Food=true;
    public bool isReproductionInProgress = false;


    public GameObject prefab;  
    public float spawnDistance = 2f;  
    GameObject object1;
    GameObject object2;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AddWaterCollectable(GameObject collectable)
    {
        if (!WaterCollectables.Contains(collectable))
        {
            WaterCollectables.Add(collectable);
        }
    }

    public void RemoveWaterCollectable(GameObject collectable)
    {
        if (WaterCollectables.Contains(collectable))
        {
            WaterCollectables.Remove(collectable);
        }
    }

    public void AddFoodCollectable(GameObject collectable)
    {
        if (!FoodCollectables.Contains(collectable))
        {
            FoodCollectables.Add(collectable);
        }
    }

    public void RemoveFoodCollectable(GameObject collectable)
    {
        if (FoodCollectables.Contains(collectable))
        {
            FoodCollectables.Remove(collectable);
        }
    }
    public List<GameObject> GetNavMeshAreas()
    {
        return floorAreas; 
    }

    private void Update()
    {
    FoodCollectables.RemoveAll(item => item == null);
    FoodCollectables = FoodCollectables
            .OrderBy(food => Vector3.Distance(transform.position, food.transform.position))
            .ToList();
    WaterCollectables = WaterCollectables
            .OrderBy(water => Vector3.Distance(transform.position, water.transform.position))
            .ToList();
    }

    public bool checkDistance(){
        if (Vector3.Distance(transform.position, FoodCollectables[0].transform.position) < 100f){
            Food=false;
            animator.Play("eat");
            GetComponent<LifeSpan>().SetFoodAvailability(true);
            StartCoroutine(FoodRoutine());
            return true;
        }
        return false;
    }

    public bool checkWaterDistance(){
        if (Vector3.Distance(transform.position, WaterCollectables[0].transform.position) < 200f){
            Drink=false;
            int stateHash = Animator.StringToHash("Water");
            if(animator.HasState(0,stateHash)){
                animator.Play("Water");
            }
            else{
            animator.Play("eat");
            }
            StartCoroutine(WaterRoutine());
            return true;
        }
        return false;
    }

    public void destination(){
        Wander=false;
        StartCoroutine(WanderRoutine());
    }

    private IEnumerator FoodRoutine()
    {
        yield return new WaitForSeconds(5f);
        Food = true;
        isReproductionInProgress = false;
    }
    private IEnumerator WaterRoutine()
    {
        yield return new WaitForSeconds(60f);
        Drink = true;
        isReproductionInProgress = false;
    }

    private IEnumerator WanderRoutine()
    {
        yield return new WaitForSeconds(10f);
        Wander = true;
    }

    public void Night(){
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        animator.Play("sit");
        StartCoroutine(NightRoutine());
    }

    private IEnumerator NightRoutine()
    {
        yield return new WaitForSeconds(5f);
        animator.Play("GoatSheep_walk_forward");
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        gameObject.GetComponent<BehaviorExecutor>().paused=false;
    }

    public void Reproduction()
    {
        Vector3 spawnPosition1 = gameObject.transform.position + new Vector3(spawnDistance, 0f, 0f);
        Vector3 spawnPosition2 = gameObject.transform.position + new Vector3(-spawnDistance, 0f, 0f);        
        object1 = GameObject.Instantiate(prefab, spawnPosition1, Quaternion.identity);
        object2 = GameObject.Instantiate(prefab, spawnPosition2, Quaternion.identity);
        IncreaseSphereColliderRadius(object1);
        IncreaseSphereColliderRadius(object2);
    }

    private void IncreaseSphereColliderRadius(GameObject obj)
    {
        obj.GetComponent<DeerManager>().Drink=true;
        obj.GetComponent<DeerManager>().Food=true;
        SphereCollider sphereCollider = obj.GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sphereCollider.radius += 1f; 
        }
        else
        {
            Debug.LogWarning("SphereCollider not found on " + obj.name);
        }
    }
}
