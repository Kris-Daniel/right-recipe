using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragEvents : MonoBehaviour
{

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
    
}
