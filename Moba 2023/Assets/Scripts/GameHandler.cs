using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    private Renderer currRenderer;
    private Renderer oldRenderer;

    public Texture2D move;
    public Texture2D attack;

    private void Start()
    {
        
    }
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, LayerMask.GetMask("Terrain")))
        {
            if (hit.collider.tag == "Any Team")
            {
                Cursor.SetCursor(attack, Vector2.zero, CursorMode.Auto);
                if (currRenderer != null && currRenderer != hit.collider.transform.Find("Mesh").GetComponent<Renderer>())
                {
                    Hide();
                    currRenderer = hit.collider.transform.Find("Mesh").GetComponent<Renderer>();
                    Show();
                }
                currRenderer = hit.collider.transform.Find("Mesh").GetComponent<Renderer>();
                Show();
            }
            else
            {
                Cursor.SetCursor(move, Vector2.zero, CursorMode.Auto);
                Hide();
            }
                
        }
        else
        {
            Hide();
        }
    }

    public void Show()
    {
        if (currRenderer != null)
        {
            currRenderer.material.SetFloat("_Outline", 0.1f);
        }
    }

    public void Hide()
    {
        if (currRenderer != null)
        {
            currRenderer.material.SetFloat("_Outline", 0);
            currRenderer = null;
        }
    }
}
