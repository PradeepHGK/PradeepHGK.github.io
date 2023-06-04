using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelButtons : MonoBehaviour
{
    [SerializeField] GameObject model;
    [SerializeField] GameObject _modelInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_modelInstantiated != null) {
            var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var newPos = new Vector3(camPos.x, camPos.y, 0);
            _modelInstantiated.transform.position = newPos;
        }
    }


    public void InstantiateSnapObject() {
        _modelInstantiated = Instantiate(model);
    }

    public void RemoveAddedModel() {
        Destroy(_modelInstantiated);
    }


}
