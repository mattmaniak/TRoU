using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    
    public Material[] materials;
    
    Renderer _renderer;
    static bool _selected = false;

    public static bool Selected
    {
        get { return _selected; }

    }
    public static void Select()
    {
        _selected = true;
    }

    public static void Unselect()
    {
        _selected = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.sharedMaterial = materials[_selected ? 1 : 0];
    }
}
