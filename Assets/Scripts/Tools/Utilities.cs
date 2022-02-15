using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{

    // Create Text in the World
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontsize = 40,
         Color? color = null, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 1)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontsize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize,
        Color color, TextAnchor textAnchor, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 1)
    {

        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    // Get Mouse Position in World with Z = 0f
    public static Vector3 GetMouseWorldPositíon()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    public static Mesh CreateMeshTriangle(Vector3 vertx0, Vector3 vertx1, Vector3 vertx2)
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = vertx0;
        vertices[1] = vertx1;
        vertices[2] = vertx2;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }

    public static Mesh CreateMeshSquare(Vector3 vertx0, Vector3 vertx1, Vector3 vertx2,Vector3 vertx3)
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = vertx0;
        vertices[1] = vertx1;
        vertices[2] = vertx2;
        vertices[3] = vertx3;

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }
    public static Mesh AderirMesh(Grid grid, Vector3 originPosition, float cellSize)
    {

        Mesh mesh = new Mesh();
        int numOfCells = grid.getXLength() * grid.getYLength();
        Vector3[] vertices = new Vector3[4 * numOfCells + 19];
        Vector2[] uv = new Vector2[4 * numOfCells + 19];
        int[] triangles = new int[6 * numOfCells + 27];

        int i = 0;
        int j = 0;

        int color;

        float posX;
        float posY;

        for (int x = 0; x < grid.getXLength(); x++)
        {
            for (int y = 0; y < grid.getYLength(); y++)
            {
                
                posX = x * cellSize + originPosition[0];
                posY = y * cellSize + originPosition[1];

                if(grid.GetValue(x, y) == 0)
                {
                    color = 1;
                }
                else { color = 0; }
                


                vertices[i] = new Vector3(posX, posY);
                vertices[i+1] = new Vector3(posX, posY + cellSize);
                vertices[i+2] = new Vector3(posX + cellSize, posY + cellSize);
                vertices[i+3] = new Vector3(posX + cellSize, posY);

                uv[i] = new Vector2(color, 0);
                uv[i+1] = new Vector2(color, 0);
                uv[i+2] = new Vector2(color, 0);
                uv[i+3] = new Vector2(color, 0);

                triangles[j] = i;
                triangles[j+1] = i+1;
                triangles[j+2] = i+2;

                triangles[j+3] = i;
                triangles[j+4] = i+2;
                triangles[j+5] = i+3;

                i += 4;
                j += 6;

            }


        }

        //BUTTONS

        //Play button triangle
        vertices[4 * numOfCells] = new Vector3(4, -16);
        vertices[4 * numOfCells + 1] = new Vector3(4, -14);
        vertices[4 * numOfCells + 2] = new Vector3(7, -15);

        uv[4*numOfCells] = new Vector2(0, 0);
        uv[4*numOfCells + 1] = new Vector2(0, 0);
        uv[4*numOfCells + 2] = new Vector2(0, 0);

        triangles[6*numOfCells] = 4*numOfCells;
        triangles[6*numOfCells + 1] = 4*numOfCells +1;
        triangles[6*numOfCells + 2] = 4*numOfCells + 2;

        //Pause Button

        //First Bar
        vertices[4 * numOfCells + 3] = new Vector3(-5, -16);
        vertices[4 * numOfCells + 4] = new Vector3(-5, -14);
        vertices[4 * numOfCells + 5] = new Vector3(-4, -14);
        vertices[4 * numOfCells + 6] = new Vector3(-4, -16);

        uv[4 * numOfCells + 3] = new Vector2(0, 0);
        uv[4 * numOfCells + 4] = new Vector2(0, 0);
        uv[4 * numOfCells + 5] = new Vector2(0, 0);
        uv[4 * numOfCells + 6] = new Vector2(0, 0);

        triangles[6 * numOfCells + 3] = 4 * numOfCells + 3;
        triangles[6 * numOfCells + 4] = 4 * numOfCells + 4;
        triangles[6 * numOfCells + 5] = 4 * numOfCells + 5;

        triangles[6 * numOfCells + 6] = 4 * numOfCells + 3;
        triangles[6 * numOfCells + 7] = 4 * numOfCells + 5;
        triangles[6 * numOfCells + 8] = 4 * numOfCells + 6;


        //Second Bar
        vertices[4 * numOfCells + 7] = new Vector3(-7, -16);
        vertices[4 * numOfCells + 8] = new Vector3(-7, -14);
        vertices[4 * numOfCells + 9] = new Vector3(-6, -14);
        vertices[4 * numOfCells + 10] = new Vector3(-6, -16);

        uv[4 * numOfCells + 7] = new Vector2(0, 0);
        uv[4 * numOfCells + 8] = new Vector2(0, 0);
        uv[4 * numOfCells + 9] = new Vector2(0, 0);
        uv[4 * numOfCells + 10] = new Vector2(0, 0);

        triangles[6 * numOfCells + 9] = 4 * numOfCells + 7;
        triangles[6 * numOfCells + 10] = 4 * numOfCells + 8;
        triangles[6 * numOfCells + 11] = 4 * numOfCells + 9;

        triangles[6 * numOfCells + 12] = 4 * numOfCells + 7;
        triangles[6 * numOfCells + 13] = 4 * numOfCells + 9;
        triangles[6 * numOfCells + 14] = 4 * numOfCells + 10;

        //Clear Button (X)

        //First Bar
        vertices[4 * numOfCells + 11] = new Vector3(-16, -16);
        vertices[4 * numOfCells + 12] = new Vector3(-18, -14);
        vertices[4 * numOfCells + 13] = new Vector3(-17, -14);
        vertices[4 * numOfCells + 14] = new Vector3(-15, -16);

        uv[4 * numOfCells + 11] = new Vector2(0, 0);
        uv[4 * numOfCells + 12] = new Vector2(0, 0);
        uv[4 * numOfCells + 13] = new Vector2(0, 0);
        uv[4 * numOfCells + 14] = new Vector2(0, 0);

        triangles[6 * numOfCells + 15] = 4 * numOfCells + 11;
        triangles[6 * numOfCells + 16] = 4 * numOfCells + 12;
        triangles[6 * numOfCells + 17] = 4 * numOfCells + 13;

        triangles[6 * numOfCells + 18] = 4 * numOfCells + 11;
        triangles[6 * numOfCells + 19] = 4 * numOfCells + 13;
        triangles[6 * numOfCells + 20] = 4 * numOfCells + 14;

        //Second Bar
        vertices[4 * numOfCells + 15] = new Vector3(-18, -16);
        vertices[4 * numOfCells + 16] = new Vector3(-16, -14);
        vertices[4 * numOfCells + 17] = new Vector3(-15, -14);
        vertices[4 * numOfCells + 18] = new Vector3(-17, -16);

        uv[4 * numOfCells + 15] = new Vector2(0, 0);
        uv[4 * numOfCells + 16] = new Vector2(0, 0);
        uv[4 * numOfCells + 17] = new Vector2(0, 0);
        uv[4 * numOfCells + 18] = new Vector2(0, 0);

        triangles[6 * numOfCells + 21] = 4 * numOfCells + 15;
        triangles[6 * numOfCells + 22] = 4 * numOfCells + 16;
        triangles[6 * numOfCells + 23] = 4 * numOfCells + 17;

        triangles[6 * numOfCells + 24] = 4 * numOfCells + 15;
        triangles[6 * numOfCells + 25] = 4 * numOfCells + 17;
        triangles[6 * numOfCells + 26] = 4 * numOfCells + 18;



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }
    public static Mesh UpdateColors(Mesh mesh, int verticalCells, int x, int y, int c)
    {
        int i = 4*x * verticalCells;
        i += 4 * y;
        
        Vector2[] uv = mesh.uv;

        uv[i] = new Vector2(c, 0);
        uv[i+1] = new Vector2(c, 0);
        uv[i+2] = new Vector2(c, 0);
        uv[i+3] = new Vector2(c, 0);

        mesh.uv = uv;

        return mesh;
    }

    public static void MakeBox(Vector3 vrtx1, Vector3 vrtx2, Vector3 vrtx3, Vector3 vrtx4)
    {
        Debug.DrawLine(vrtx1, vrtx2, Color.white, 100f);
        Debug.DrawLine(vrtx2, vrtx3, Color.white, 100f);
        Debug.DrawLine(vrtx3, vrtx4, Color.white, 100f);
        Debug.DrawLine(vrtx4, vrtx1, Color.white, 100f);
    }

    public static bool RunButtonClicked(Vector3 vector)
    {
        float x = vector[0];
        float y = vector[1];
        
        if(x >= 2 && x <= 9 && y<= -13 && y >= -17)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    public static bool PauseButtonClicked(Vector3 vector)
    {
        float x = vector[0];
        float y = vector[1];

        if (x >= -9 && x <= -2 && y <= -13 && y >= -17)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static Grid RunConway(Grid grid)
    {
        int verticalCells = DataHolder.verticalCellsHolder;
        int horizontalCells = 2 * verticalCells;
        Vector3 originPosition = DataHolder.originPositionHolder;
        int cellSize = 30 / verticalCells;
        

        Grid Newgrid = new Grid(horizontalCells, verticalCells, cellSize, originPosition);
        int AN;

        for (int x = 0; x < grid.getXLength(); x++)
        {
            for (int y = 0; y < grid.getYLength(); y++)
            {
                int ValorActual = grid.GetValue(x, y);

                if(ValorActual == 0)
                {
                    if(grid.AliveNeighbours(x,y) == 3)
                    {
                        Newgrid.SetValue(x, y, 1);
                       
                    }
                    
                }

                else
                {
                    AN = grid.AliveNeighbours(x, y);
                    //Debug.Log(AN);
                    if ( AN != 3 && AN != 2)
                    {
                        Newgrid.SetValue(x, y, 0);
                    }
                    else
                    {
                        Newgrid.SetValue(x, y, 1);
                    }
                }

            }
        }
        //Debug.Log("----");

        return Newgrid;
    }
}
