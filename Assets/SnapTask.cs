using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapTask : BaseTask, IBeginDragHandler, IEndDragHandler
{
    public SnapObject SnapObject;
    public Socket SnapSocket;

    [SerializeField] GameObject _modelInstantiated;

    public Material _SocketMaterial;
    private Vector3 mousePost;

    private void Start()
    {
        TaskType = Tasks.Snap;
    }

    private void OnMouseDown()
    {
        mousePost = Input.mousePosition - Camera.main.WorldToScreenPoint(SnapObject.transform.position);
    } 

    // Update is called once per frame
    void Update()
    {
        //if (_modelInstantiated != null)
        //{
        //    var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePost);
        //    var newPos = new Vector3(camPos.x, camPos.y, 0);
        //    _modelInstantiated.transform.position = newPos;
        //}


        if (_modelInstantiated != null)
        {
            var mousPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + SnapObject.transform.position.z);
            var newPos = Camera.main.ScreenToWorldPoint(mousPos);

            _modelInstantiated.transform.position = newPos;
        }
    }


    public void InstantiateSnapObject()
    {
        //_modelInstantiated = Instantiate(model);

        if (SnapObject.GetComponent<Collider>().enabled && istaskActive) {
            _modelInstantiated = SnapObject.gameObject;
            SnapObject.gameObject.SetActive(true);
        }
    }

    public void RemoveAddedModel()
    {
        //Destroy(_modelInstantiated);

        _modelInstantiated = null;
        if ( SnapObject.isMatched)
        {
            SnapObject.GetComponent<Collider>().enabled = false;
            SnapObject.gameObject.SetActive(true);
            SnapSocket.gameObject.SetActive(false);
            //OnTaskEnd.Invoke();

            TasksList.OnTaskEnd.Invoke();

            transform.GetChild(0).GetComponent<Image>().sprite = null;
        }
        else
        {
            SnapObject.gameObject.SetActive(false);
            transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (!SnapObject.isMatched)
            RemoveAddedModel();
        

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!SnapObject.isMatched) {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
            InstantiateSnapObject();
        }
    }

    public override void AutoCompleteTask()
    {
        base.AutoCompleteTask();
    }
}
