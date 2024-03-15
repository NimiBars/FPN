using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour
{
    // Door Stuffs
    public Animator doorAnimator;
    public GameObject doorText;
    public bool hasKey = false;
    private bool _isOpen = false;

    public void DoorInteraction()
    {
        if (!hasKey)
        {
            if (!doorText.activeSelf)
                StartCoroutine(DisplayText());
        }
        else
        {
            if (!_isOpen)
            {
                doorAnimator.SetTrigger("Open");
                doorAnimator.ResetTrigger("Close");
                _isOpen = true;
            }
            else
            {
                doorAnimator.SetTrigger("Close");
                doorAnimator.ResetTrigger("Open");
                _isOpen = false;
            }
        }
    }

    public void SetDoorUnlockable()
    {
        hasKey = true;
    }

    IEnumerator DisplayText()
    {
        doorText.SetActive(true);
        yield return new WaitForSeconds(2);
        doorText.SetActive(false);
    }
}
