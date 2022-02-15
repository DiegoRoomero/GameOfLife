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
        Utilities.MakeBox(new Vector3(-21, -17), new Vector3(-21, -13), new Vector3(-13, -13), new Vector3(-13, -17));
        Utilities.MakeBox(new Vector3(-9, -17), new Vector3(-9, -13), new Vector3(-2, -13), new Vector3(-2, -17));
        Utilities.MakeBox(new Vector3(9, -17), new Vector3(9, -13), new Vector3(2, -13), new Vector3(2, -17));
        Utilities.MakeBox(new Vector3(21, -17), new Vector3(21, -13), new Vector3(13, -13), new Vector3(13, -17));

        TextMesh debugTextArray = new TextMesh();
        debugTextArray = Utilities.CreateWorldText(null, "P / E", new Vector3(17, -15), 30, Color.white, TextAnchor.MiddleCenter);

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
            mesh = Utilities.AdherirMesh(grid, originPosition, cellSize);
            GetComponent<MeshFilter>().mesh = mesh;

            counter -= 10;
        }

        counter++;

        if (Input.GetMouseButtonDown(0) && Utilities.PauseButtonClicked(Utilities.GetMouseWorldPositíon()))
        {
            DataHolder.GridHolder = grid;


            DataHolder.MeshHolder = mesh;
            Loader.Load(Loader.Scene.Build);
        }

        if (Input.GetMouseButtonDown(0) && Utilities.ClearButtonClicked(Utilities.GetMouseWorldPositíon()))
        {
            DataHolder.GridHolder = new Grid(horizontalCells, verticalCells, cellSize, originPosition); ;


            DataHolder.MeshHolder = Utilities.AdherirMesh(DataHolder.GridHolder, originPosition, cellSize);
            Loader.Load(Loader.Scene.Build);
        }

        if (Input.GetMouseButtonDown(0) && Utilities.SwitchModeButtonClicked(Utilities.GetMouseWorldPositíon()))
        {
            if (DataHolder.ModeHolder == "p")
            {
                DataHolder.ModeHolder = "e";
            }
            else { DataHolder.ModeHolder = "p"; }

        }

    }
}
