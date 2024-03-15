using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorInteractable door;

    public void PickupKey()
    {
        door.SetDoorUnlockable();
        Destroy(this.gameObject);
    }
}
