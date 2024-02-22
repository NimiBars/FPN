using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private string _selectTag = "Selectable";
    private bool _isHighlighted = false;

    private Transform _selection;

    public TMP_Text nameDisplay;

    public float distanceFromItem = 3f;

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

            if(selection.CompareTag(_selectTag))
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
    }
}
