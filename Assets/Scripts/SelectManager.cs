using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private string _selectTag;
    private bool _isHighlighted = false;
    private Transform _selection;
    public TMP_Text nameDisplay;
    public float distanceFromItem = 3f;


    // Door Stuffs
    public Animator doorAnimator;
    public GameObject doorText;
    public bool hasKey = false;
    private bool _isOpen = false;


    private void Update()
    {
        if (_selection != null)
        {
            nameDisplay.text = "";
            _isHighlighted = false;
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.DisableKeyword("_EMISSION");

            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceFromItem, Color.red);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceFromItem))
        {
            Debug.Log("test");

            var selection = hit.transform;

            if(selection.CompareTag("Selectable") || selection.CompareTag("Door"))
            {
                if (selection != _isHighlighted)
                {
                    _isHighlighted = true;
                    selection.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                    nameDisplay.text = selection.gameObject.name;
                }

                _selection = selection;
            }
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

        if (!hasKey)
        {
            doorText.SetActive(true);
            invoke("DisableText", 2f);
        }
        else
        {
            if (Physics.Raycast(rayOrigin, out hitInfo, distanceFromItem)) ;
            {
                var selection = hitInfo.transform;

                if (selection.gameObject.tag == "Door")
                {
                    if (!_isOpen)
                    {
                        doorAnimator.setTrigger("Open");
                        doorAnimator.ResetTrigger("Close");
                        _isOpen = true;
                    }
                    else
                    {
                        doorAnimator.setTrigger("Close");
                        doorAnimator.ResetTrigger("Open");
                        _isOpen = false;
                    }
                }
            }
        }
    }

    void DisableText()
    {
        doorText.SetActive(false);
    }
    
    private void OnTriggerEVent(Collider other)
    {
        if (other gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy.gameObject

        }
    }
}
