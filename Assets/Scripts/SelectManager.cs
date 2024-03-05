using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceFromItem, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {

            var selection = hit.transform;

            if (selection.GetComponent<Interactable>() != null)
            {
                selection.GetComponent<Interactable>().HideItemInteractable();
            }

            _selection = selection;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DoorInteraction();
        }

    }

    void DoorInteraction()
    {
        Debug.Log("test");
        RayCastHit hitInfo;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray rayOrigin = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(rayOPrigin, out hitInfo, distanceFromItem))
        {
            if (!hasKey)
            {
                doorText.SetActive(true);
                invoke("DisableText", 2f);
            }
        }
    }


    
    private void OnTriggerEVent(Collider other)
    {
        if (other gameObject.tag == "Key")
        {
            //hasKey = true;
            Destroy.gameObject
        }
    }
}
