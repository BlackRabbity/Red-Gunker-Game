using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
    //[SerializeField] private List<MeshFilter> meshFilters;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Grid grid;

    [ContextMenu("MergeMeshes")]
    private void MergeMeshes()
    {
        MeshFilter[] meshFilters = grid.GetComponentsInChildren<MeshFilter>(true);
        var merge = new CombineInstance[meshFilters.Length];
        for(int i=0; i< meshFilters.Length; i++)
        {
            merge[i].mesh = meshFilters[i].sharedMesh;
            merge[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        var mesh = new Mesh();
        mesh.CombineMeshes(merge);
        meshFilter.mesh = mesh;
    }
}
