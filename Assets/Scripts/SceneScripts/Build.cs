using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    // Made by Diego Romero Iregui

    private Grid grid;
    private Mesh mesh;

    private int verticalCells = DataHolder.verticalCellsHolder;
    private int horizontalCells;

    private int x, y;
    private int xtemp, ytemp;

    Vector3 coord;
    private float cellSize;
    private Vector3 originPosition = DataHolder.originPositionHolder;

    
    private void Start()
    {

        //Icon boxes
        Utilities.MakeBox(new Vector3(-21, -17), new Vector3(-21, -13), new Vector3(-13, -13), new Vector3(-13, -17));
        Utilities.MakeBox(new Vector3(-9, -17), new Vector3(-9, -13), new Vector3(-2, -13), new Vector3(-2, -17));
        Utilities.MakeBox(new Vector3(9, -17), new Vector3(9, -13), new Vector3(2, -13), new Vector3(2, -17));
        Utilities.MakeBox(new Vector3(21, -17), new Vector3(21, -13), new Vector3(13, -13), new Vector3(13, -17));

        TextMesh debugTextArray = new TextMesh();
        debugTextArray = Utilities.CreateWorldText(null, "P / E", new Vector3(17, -15), 30, Color.white, TextAnchor.MiddleCenter);



        horizontalCells = 2 * verticalCells;
        cellSize = 30 / verticalCells;

        if (DataHolder.GridHolder is null)
        { 

            grid = new Grid(horizontalCells, verticalCells, cellSize, originPosition);
            
        }
        else
        {
            grid = DataHolder.GridHolder;
        }

        mesh = Utilities.AdherirMesh(grid, originPosition, cellSize);
        GetComponent<MeshFilter>().mesh = mesh;


        xtemp = -1;
        ytemp = -1;

        if(DataHolder.ModeHolder is null)
        {
            DataHolder.ModeHolder = "p";
        }
        

    }

    private void Update()
    {

        if (Input.GetAxis("Fire1") > 0f)
        {

            //Debug.Log(xtemp + " " + ytemp);
           

            if (grid.GetValue(Utilities.GetMouseWorldPositíon()) == 0 && DataHolder.ModeHolder == "p")
            {

                grid.GetXY(Utilities.GetMouseWorldPositíon(), out x, out y);

                if(x!=xtemp || y != ytemp)
                {
                    grid.SetValue(Utilities.GetMouseWorldPositíon(), 1);


                    coord = new Vector3(x, y) * cellSize + originPosition;

                    mesh = Utilities.UpdateColors(mesh, verticalCells, x, y, 0);
                    GetComponent<MeshFilter>().mesh = mesh;

                    xtemp = x;
                    ytemp = y;

                }


            }
            else if (grid.GetValue(Utilities.GetMouseWorldPositíon()) == 1 && DataHolder.ModeHolder == "e")
            {

                grid.GetXY(Utilities.GetMouseWorldPositíon(), out x, out y);

                if (x != xtemp || y != ytemp)
                {

                    grid.SetValue(Utilities.GetMouseWorldPositíon(), 0);

                    coord = new Vector3(x, y) * cellSize + originPosition;

                    mesh = Utilities.UpdateColors(mesh, verticalCells, x, y, 1);
                    GetComponent<MeshFilter>().mesh = mesh;

                    xtemp = x;
                    ytemp = y;
                }
            }

            
        }


        if(Input.GetMouseButtonDown(0) && Utilities.RunButtonClicked(Utilities.GetMouseWorldPositíon())){
            DataHolder.GridHolder = grid;
            

            DataHolder.MeshHolder = mesh;
            Loader.Load(Loader.Scene.Run);
        }

        if (Input.GetMouseButtonDown(0) && Utilities.ClearButtonClicked(Utilities.GetMouseWorldPositíon()))
        {
            DataHolder.GridHolder = new Grid(horizontalCells, verticalCells, cellSize, originPosition); ;


            DataHolder.MeshHolder = Utilities.AdherirMesh(DataHolder.GridHolder, originPosition, cellSize);
            Loader.Load(Loader.Scene.Build);
        }

        if (Input.GetMouseButtonDown(0) && Utilities.SwitchModeButtonClicked(Utilities.GetMouseWorldPositíon()))
        {
            if(DataHolder.ModeHolder == "p")
            {
                DataHolder.ModeHolder = "e";
            }
            else { DataHolder.ModeHolder = "p"; }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(Utilities.GetMouseWorldPositíon()));
        }


    }

}
