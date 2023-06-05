using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseTask : MonoBehaviour
{
    public int id;
    public string taskName;

    public bool istaskActive;

    public Tasks TaskType;

    private void Start()
    {
        id = UnityEngine.Random.Range(10000000, 999999999);
    }

    [Space]
    public UnityEvent OnTaskBegin;
    public Action OnTaskEnd;


    public virtual void AutoCompleteTask() {

    }


}

public enum Tasks {
    Base,
    Snap
}