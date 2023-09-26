using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D actionArrow;

    private void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void OnMouseEnter()
    {
        Cursor.SetCursor(actionArrow, Vector2.zero, CursorMode.ForceSoftware);

    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
