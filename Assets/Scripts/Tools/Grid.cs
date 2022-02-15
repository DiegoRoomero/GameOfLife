using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int[,] gridArray;
    //private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        //debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {

                //debugTextArray[x, y] = Utilities.CreateWorldText(null, gridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 30, Color.clear, TextAnchor.MiddleCenter);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.black, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.black, 100f);

            }

        }

        //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.black, 100f);
        //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.black, 100f);
    
    }

    public int getXLength()
    {
        return gridArray.GetLength(0);
    }

    public int getYLength()
    {
        return gridArray.GetLength(1);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }
    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            //debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {

            return -1;

        }

    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    public bool GridFull(){

        bool b = true;
        for (int x = 0; x<gridArray.GetLength(0); x++)
        {
            for (int y = 0; y<gridArray.GetLength(1); y++)
            {
                if(gridArray[x,y]==0){
                    b = false;
                }
            }


        }
        return b;


    }
    public int AliveNeighbours(int x, int y)
    {

        int LeftX;
        int RightX;
        int BelowY;
        int AboveY;

        int counter = 0;


        //We need to make the gridArray circular
        if(x == 0) { LeftX = gridArray.GetLength(0) - 1; }
        else{ LeftX = x - 1; }

        if (x == gridArray.GetLength(0) -1) { RightX = 0; }
        else { RightX = x + 1; }

        if (y == 0) { BelowY = gridArray.GetLength(1) - 1; }
        else { BelowY = y - 1; }

        if (y == gridArray.GetLength(1) - 1) { AboveY = 0; }
        else { AboveY = y + 1; }


        //We check all neighbours

        if(gridArray[LeftX, BelowY] == 1) { counter += 1; }

        if(gridArray[LeftX, y] == 1) { counter += 1; }

        if (gridArray[LeftX, AboveY] == 1) { counter += 1; }

        if (gridArray[x, AboveY] == 1) { counter += 1; }

        if (gridArray[RightX, AboveY] == 1) { counter += 1; }

        if (gridArray[RightX, y] == 1) { counter += 1; }

        if (gridArray[RightX, BelowY] == 1) { counter += 1; }

        if (gridArray[x, BelowY] == 1) { counter += 1; }


        return counter;
        


    }




}