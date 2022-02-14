using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    // Made by Diego Romero Iregui

    private Grid grid;
    private Mesh mesh;

    private int verticalCells = 6;
    private int horizontalCells;

    private int x, y;
    private int xtemp, ytemp;

    Vector3 coord;
    private float cellSize;
    private Vector3 originPosition = new Vector3(-30, -10);

    private List<Vector3> visitedCells = new List<Vector3>();
    
    private void Start()
    {

        //Icon boxes

        Utilities.MakeBox(new Vector3(-9, -17), new Vector3(-9, -13), new Vector3(-2, -13), new Vector3(-2, -17));
        Utilities.MakeBox(new Vector3(9, -17), new Vector3(9, -13), new Vector3(2, -13), new Vector3(2, -17));


        horizontalCells = 2 * verticalCells;
        cellSize = 30 / verticalCells;

        grid = new Grid(horizontalCells, verticalCells,cellSize, originPosition);
        mesh = Utilities.AderirMesh(grid, originPosition, cellSize);
        GetComponent<MeshFilter>().mesh = mesh;

        xtemp = -1;
        ytemp = -1;

    }

    private void Update()
    {

        if (Input.GetAxis("Fire1") > 0f)
        {

            //Debug.Log(xtemp + " " + ytemp);
           

            if (grid.GetValue(Utilities.GetMouseWorldPositíon()) == 0)
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
            else if (grid.GetValue(Utilities.GetMouseWorldPositíon()) == 1)
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

        visitedCells.Clear();

        if(Input.GetMouseButtonDown(0) && Utilities.RunButtonClicked(Utilities.GetMouseWorldPositíon())){
            DataHolder.GridHolder = grid;
            

            DataHolder.MeshHolder = mesh;
            Loader.Load(Loader.Scene.Run);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(Utilities.GetMouseWorldPositíon()));
        }


    }

}
