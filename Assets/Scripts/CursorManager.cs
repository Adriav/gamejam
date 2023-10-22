using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
  public Texture2D cursor_normal;
  public Vector2 hotspot_normal;
  public Texture2D cursor_hover;
  public Vector2 hotspot_hover;
  // Start is called before the first frame update
  public void OnButtonEnter()
  {
    Cursor.SetCursor(cursor_hover, hotspot_hover, CursorMode.Auto);
  }

  public void OnButtonExit()
  {
    Cursor.SetCursor(cursor_normal, hotspot_normal, CursorMode.Auto);
  }
}
