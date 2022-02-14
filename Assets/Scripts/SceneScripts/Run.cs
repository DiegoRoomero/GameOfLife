using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    private Grid grid;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        //Icon boxes

        Utilities.MakeBox(new Vector3(-9, -17), new Vector3(-9, -13), new Vector3(-2, -13), new Vector3(-2, -17));
        Utilities.MakeBox(new Vector3(9, -17), new Vector3(9, -13), new Vector3(2, -13), new Vector3(2, -17));

        grid = DataHolder.GridHolder;
        mesh = DataHolder.MeshHolder;
        GetComponent<MeshFilter>().mesh = mesh;

    }

    // Update is called once per frame
    void Update()
    {
        /*int color;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {   

                color = Utilities.RunConway(grid, x, y);
            }
        }*/
    }
}
