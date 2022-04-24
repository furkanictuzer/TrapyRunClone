#if UNITY_EDITOR


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.EditorCoroutines.Editor;

public class PathCreator : MonoSingleton<PathCreator>
{
    [SerializeField] private GameObject cubePrefab;
    [Space]
    [Range(0,200)]
    public int pathLength;
    [Range(0,15)]
    public int pathWidth;

    private int _currentPathLength = 0;

    public List<GameObject> pathCubes = new List<GameObject>();
    

    private void OnValidate()
    {
        if (cubePrefab == null) return;
        
        if (pathLength * pathWidth > pathCubes.Count)
        {
            Debug.Log("Increase");
            
            CreatePath();
        }
        else if (pathCubes.Count > pathLength * pathWidth)
        {
            Debug.Log("Decrease");
            
            DestroyPath();
        }

    }

    private void CreatePath()
    {
        for (var i = _currentPathLength; i < pathLength; i++)
        {
            for (var j = -pathWidth/2; j < pathWidth -pathWidth/2; j++)
            {
                var cubePos = new Vector3(j, 0, i);

                var go = Instantiate(cubePrefab, cubePos, Quaternion.identity, transform);
                
                pathCubes.Add(go);
            }
        }

        _currentPathLength = pathLength;
    }

    private void DestroyPath()
    {
        var cubeCount = pathLength * pathWidth;
        
        for (var i = pathCubes.Count - 1; i >= cubeCount; i--)
        {
            var go = pathCubes[pathCubes.Count-1];
            
            pathCubes.RemoveAt(i);
            
            EditorCoroutineUtility.StartCoroutine(DestroyObject(go), this);
        }
        
        _currentPathLength = pathLength;
    }

    private IEnumerator DestroyObject(GameObject go)
    {
        yield return new WaitForEndOfFrame();
        
        DestroyImmediate(go);
    }
}
#endif