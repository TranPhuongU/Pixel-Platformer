using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Awake()
    {
        // Lấy thành phần Inventory từ GameObject cha
        inventory = GetComponentInParent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            if (inventory != null)
            {
                inventory.isFull[i] = false;
            }
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpawnDropItem>().SpawnDropedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}