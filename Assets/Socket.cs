using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Socket : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter");

        if (other.GetComponent<SnapObject>().id == id) {
        Debug.Log($"OnTriggerEnter: {other.name}");
            other.GetComponent<SnapObject>().isMatched = true;
            other.gameObject.transform.position = this.transform.position;
            other.enabled = false;
        }
    }
}
