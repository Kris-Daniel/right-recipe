using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class DragManager : MonoBehaviour
{
    public bool HasDraggedItem { get; private set; }
    GameObject _draggedItem;

    public void SaveDraggedItem(GameObject draggedItem)
    {
        HasDraggedItem = true;
        _draggedItem = draggedItem;
    }

    public void RemoveDraggedItem(GameObject draggedItem)
    {
        HasDraggedItem = false;
        if (_draggedItem == draggedItem)
        {
            if(MainManager.Store.playerRecipe.state == EPlayerRecipeStates.PointerEnter)
                MainManager.Store.playerRecipe.AddToRecipeListContent(draggedItem);
            else
            {
                MainManager.Store.playerRecipe.RemoveFromRecipeListContent(draggedItem);
            }
            _draggedItem = null;
        }
    }

    void Test()
    {
        
    }
}