using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksColor : MonoBehaviour
{
    [SerializeField] protected Material _material;
    private MeshRenderer _mesh;
    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    public void SetColor()
    {
        _mesh.material = _material;
    }
}
