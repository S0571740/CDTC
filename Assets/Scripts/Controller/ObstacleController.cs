using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private static List<GameObject> obstacles;

    void Start()
    {
        obstacles = new List<GameObject>();
        addAndInactivate("Turbine");
        addAndInactivate("WreckingBall");
    }

    private void addAndInactivate(string name){
        GameObject obj = GameObject.Find(name);
        obstacles.Add(obj);
        obj.SetActive(false);
    }

    public static GameObject getRandomObject()
    {
        return obstacles[Random.Range(0, obstacles.Count)];
    }
}