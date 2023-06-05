using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class TasksList : MonoBehaviour
{
    [SerializeField] int CurrentTaskIndex;

    [Space] BaseTask CurrentTask;

    [SerializeField] Button NextButton;
    [SerializeField] Button PreviousButton;


    public List<BaseTask> TotalTask;

    public static Action OnTaskEnd;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTaskIndex = 0;
        TotalTask = FindObjectsOfType<BaseTask>().ToList();
        TotalTask.Reverse();

        TotalTask.First().istaskActive = true;
        CurrentTask = TotalTask.First();
        CurrentTask.GetComponent<SnapTask>().SnapSocket.GetComponent<Outline>().enabled = true;

        OnTaskEnd += ChangeTaskStatus;
    }

    private void OnDisable()
    {
        OnTaskEnd -= ChangeTaskStatus;
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

    public void ChangeTaskStatus() {

        try
        {
            CurrentTaskIndex++;

            if(CurrentTaskIndex <= TotalTask.Count) {
            CurrentTask = TotalTask[CurrentTaskIndex];
            CurrentTask.istaskActive = true;

            //CurrentTask.OnTaskEnd.AddListener(() => ChangeTaskStatus());

            CurrentTask.GetComponent<SnapTask>().SnapSocket.GetComponent<Outline>().enabled = true;
            //CurrentTask.GetComponent<SnapTask>().SnapSocket.GetComponent<MeshRenderer>().material = CurrentTask.GetComponent<SnapTask>()._SocketMaterial;
            Debug.Log("On Task End");
            }
        }
        catch (Exception ex)
        {

        }
    }
}
