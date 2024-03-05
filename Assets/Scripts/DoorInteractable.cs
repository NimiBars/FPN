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

    void DisableText()
    {
        doorText.SetActive(false);
    }
}
