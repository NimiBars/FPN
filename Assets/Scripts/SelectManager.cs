using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private Transform _selection;
    public float distanceFromItem = 3f;

    private void Update()
    {
        if (_selection != null)
        {
            if (_selection.GetComponent<Interactable>() != null)
            {
                _selection.GetComponent<Interactable>().HideItemInteractable();
            }
            _selection = null;
        }

        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward *
            distanceFromItem, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,
            out hit, distanceFromItem))
        {
            var selection = hit.transform;

            if (selection.GetComponent<Interactable>() != null)
            {
                selection.GetComponent<Interactable>().ShowItemInteractable();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (selection.GetComponent<DoorInteractable>() != null)
                {
                    selection.GetComponent<DoorInteractable>().DoorInteraction();
                }
                if (selection.GetComponent<Key>() != null)
                {
                    selection.GetComponent<Key>().PickupKey();
                }
            }
            _selection = selection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //hasKey = true;
            Destroy(other.gameObject);
        }
    }
}
