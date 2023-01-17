using UnityEngine;
using System.Collections.Generic;

namespace pgc
{
    public abstract class MeshGenerator : MonoBehaviour
    {
        abstract public void GenerateMesh(int[,] map, float squareSize);
    }
}