using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    /*public class GridHolder
    {
        public Grid grid;

        public Grid get()
        {
            return grid;
        }

        public void set(Grid InGrid)
        {
            grid = InGrid;
        }
    }*/

    public static int verticalCellsHolder = 30;

    public static Vector3 originPositionHolder = new Vector3(-30, -10);

    public static Grid GridHolder { get; set; }

    public static Mesh MeshHolder { get; set; }


}
