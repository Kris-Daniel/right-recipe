using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableVegetable : MonoBehaviour
{
    [SerializeField] GameObject border;

    public void ChangeScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void AddToDragManager()
    {
        var dragManager = MainManager.Store.dragManager;
        if (!dragManager.HasDraggedItem)
        {
            dragManager.SaveDraggedItem(gameObject);
        }
    }
    
    public void RemoveFromDragManager()
    {
        var dragManager = MainManager.Store.dragManager;
        if (dragManager.HasDraggedItem)
        {
            dragManager.RemoveDraggedItem(gameObject);
        }
    }

    public void ToggleBorder(bool isActive)
    {
        border.SetActive(isActive);
    }
    
}
