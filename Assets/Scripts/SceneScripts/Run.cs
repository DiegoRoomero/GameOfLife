using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    private Grid grid;
    private Mesh mesh;

    int verticalCells;
    int horizontalCells;
    Vector3 originPosition;
    int cellSize;
    int counter;

    // Start is called before the first frame update
    void Start()
    {

        verticalCells = DataHolder.verticalCellsHolder;
        originPosition = DataHolder.originPositionHolder;
        cellSize = 30 / verticalCells;
        horizontalCells = 2 * verticalCells;


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
        if (counter % 10==0)
        {
           
            grid = Utilities.RunConway(grid);
            mesh = Utilities.AderirMesh(grid, originPosition, cellSize);
            GetComponent<MeshFilter>().mesh = mesh;
        }

        counter++;
        


    }
}
