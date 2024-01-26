using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public GameObject cubePrefab;
    public int poolSize = 10;

    private List<GameObject> cubePool;

    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    void InitializePool()
    {
        cubePool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            cube.SetActive(false);
            cubePool.Add(cube);
        }
    }

    public GameObject GetCube()
    {
        GameObject inactiveCube = cubePool.FirstOrDefault(cube => !cube.activeInHierarchy);

        if (inactiveCube != null)
        {
            inactiveCube.SetActive(true);
            return inactiveCube;
        }

        GameObject newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        cubePool.Add(newCube);
        return newCube;
    }

    public void ReturnCube(GameObject cube)
    {
        cube.SetActive(false);
        cube.transform.position = transform.position;
    }
}
