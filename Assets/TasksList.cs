using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TasksList : MonoBehaviour
{

    public List<BaseTask> TotalTask;


    // Start is called before the first frame update
    void Start()
    {
        TotalTask = FindObjectsOfType<BaseTask>().ToList();
        TotalTask.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
