
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour, IObjectTag
{
    public List<T> prefabs { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; }

    private List<T> pool;

    private int currentFreeIndex;
    private bool allElementsActivated;
    private int spawnIndex;

    public PoolMono(List<T> prefabs, int count)
    {
        this.prefabs = prefabs;
        this.container = null;
        this.currentFreeIndex = 0;
        this.allElementsActivated = false;
    }

    public PoolMono(List<T> prefabs, int count, Transform container)
    {
        this.prefabs = prefabs;
        this.container = container;
        this.currentFreeIndex = 0;
        this.allElementsActivated = false;
    }

    public void CreatePool(int count)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
            spawnIndex++;
            if (spawnIndex >= prefabs.Count) spawnIndex = 0;
        }

        pool.Shuffle();
    }

    public T CreateObject(bool isActiveByDeafult = false)
    {        
        var randomPrefab = prefabs[spawnIndex];
        var createdObject = Object.Instantiate(randomPrefab, this.container);
      
        createdObject.gameObject.SetActive(isActiveByDeafult);       

        this.pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        if (allElementsActivated)
        {
            currentFreeIndex = 0;
            allElementsActivated = false;
        }

        for (int i = currentFreeIndex; i < pool.Count; i++)
        {
            var mono = pool[i];

            if (!mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(true);
                currentFreeIndex = i + 1;
                element = mono;
                return true;
            }
        }

        allElementsActivated = true;
        return HasFreeElement(out element);
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.autoExpand)
            return this.CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    public void ClearPool()
    {
        if (pool == null) return;

        foreach (var item in pool)
        {
            Object.Destroy(item?.gameObject);
        }

        pool = new List<T>();

        currentFreeIndex = 0;
        spawnIndex = 0;
        allElementsActivated = false;
    }
}
