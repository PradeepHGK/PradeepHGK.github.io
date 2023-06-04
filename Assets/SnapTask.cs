using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapTask : BaseTask, IBeginDragHandler, IEndDragHandler
{
    public SnapObject SnapObject;
    public Socket SnapSocket;

    [SerializeField] GameObject _modelInstantiated;


    private void Start()
    {
        TaskType = Tasks.Snap;
    }

    // Update is called once per frame
    void Update()
    {
        if (_modelInstantiated != null)
        {
            var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var newPos = new Vector3(camPos.x, camPos.y, 0);
            _modelInstantiated.transform.position = newPos;
        }
    }


    public void InstantiateSnapObject()
    {
        //_modelInstantiated = Instantiate(model);

        if (SnapObject.GetComponent<Collider>().enabled) {
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
        }
        else
        {
            SnapObject.gameObject.SetActive(false);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RemoveAddedModel();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        InstantiateSnapObject();
    }
}
