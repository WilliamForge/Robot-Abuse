using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    //list of materials need to apply high light.
    private List<Renderer> _renderers = new List<Renderer>();

    private void Start()
    {
       _renderers.AddRange(GetComponentsInChildren<Renderer>());
    }

    private void OnMouseEnter()
    {
        foreach (Renderer _r in _renderers)
        {
            _r.material.color = Color.blue;
        }
    }

    private void OnMouseExit()
    {
        foreach (Renderer _r in _renderers)
        {
            _r.material.color = Color.white;
        }
    }

}
