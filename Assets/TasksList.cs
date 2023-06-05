using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class TasksList : MonoBehaviour
{
    [SerializeField] int CurrentTaskIndex;

    [Space]

    [SerializeField] Button NextButton;
    [SerializeField] Button PreviousButton;


    public List<BaseTask> TotalTask;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTaskIndex = 0;
        TotalTask = FindObjectsOfType<BaseTask>().ToList();
        //TotalTask.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickNextButton() {

    }

    public void OnClickPreviousButton()
    {

    }
}
