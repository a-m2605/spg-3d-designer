using UnityEngine;

public class Walls : MonoBehaviour
{
    public float width = 100;
    public float height = 15;
    public float depth = 1;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[8]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(width, height, 0),
            new Vector3(0, height, 0),
            new Vector3(0, 0, depth),
            new Vector3(width, 0, depth),
            new Vector3(width, height, depth),
            new Vector3(0, height, depth)
        };

        int[] triangles = new int[36]
        {
            0, 2, 1, //front
            0, 3, 2,
            2, 3, 6, //top
            3, 7, 6,
            1, 2, 6, //right
            1, 6, 5,
            0, 7, 3, //left
            0, 4, 7,
            4, 5, 6, //back
            4, 6, 7,
            0, 1, 5, //bottom
            0, 5, 4
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        transform.Translate(new Vector3(0, 15, 0));

        //create a second wall
        GameObject wall2 = new GameObject("wall2");
        wall2.AddComponent<MeshFilter>();
        wall2.AddComponent<MeshRenderer>();
        wall2.AddComponent<BoxCollider>();
        MeshFilter meshFilter2 = wall2.GetComponent<MeshFilter>();
        MeshRenderer renderer2 = wall2.GetComponent<MeshRenderer>();
        MeshRenderer renderer1 = gameObject.GetComponent<MeshRenderer>();
        renderer1.material.mainTexture = Resources.Load<Texture>("flaking-plaster1-unity/flaking-plaster_albedo");
        renderer2.material = renderer1.material; // You can also change the material if needed
        meshFilter2.mesh = meshFilter.mesh;  // assign the first wall's mesh to the second one
        wall2.transform.position = new Vector3(width - 21, -2, -1);  // Change the position if needed
        wall2.transform.Rotate(new Vector3(0, 90, 0)); // Rotate the wall to 90 degrees

        //create a second wall
        GameObject wall3 = new GameObject("wall2");
        wall3.AddComponent<MeshFilter>();
        wall3.AddComponent<MeshRenderer>();
        wall3.AddComponent<BoxCollider>();
        MeshFilter meshFilter3 = wall3.GetComponent<MeshFilter>();
        MeshRenderer renderer3 = wall3.GetComponent<MeshRenderer>();
        //MeshRenderer renderer1 = gameObject.GetComponent<MeshRenderer>();
        renderer3.material = renderer1.material; // You can also change the material if needed
        meshFilter3.mesh = meshFilter.mesh;  // assign the first wall's mesh to the second one
        wall3.transform.position = new Vector3(width - 121, -2, -1);  // Change the position if needed
        wall3.transform.Rotate(new Vector3(0, 90, 0)); // Rotate the wall to 90 degrees

        //create a second wall
        GameObject wall4 = new GameObject("wall2");
        wall4.AddComponent<MeshFilter>();
        wall4.AddComponent<MeshRenderer>();
        wall4.AddComponent<BoxCollider>();
        MeshFilter meshFilter4 = wall4.GetComponent<MeshFilter>();
        MeshRenderer renderer4 = wall4.GetComponent<MeshRenderer>();
        //MeshRenderer renderer1 = gameObject.GetComponent<MeshRenderer>();
        renderer4.material = renderer1.material; // You can also change the material if needed
        meshFilter4.mesh = meshFilter.mesh;  // assign the first wall's mesh to the second one
        wall4.transform.position = new Vector3(width - 121, -2, -101);  // Change the position if needed
        //wall4.transform.Rotate(new Vector3(0, 90, 0)); // Rotate the wall to 90 degrees
    }
}


/*using UnityEngine;
using System.Collections;

// This Unity script demonstrates how to create a Mesh (in this case a Cube) purely through code.
// Simply, create a new Scene, add this script to the Main Camera, and run.  

public class Walls : MonoBehaviour
{

    GameObject _cube;
    GameObject _cube1;


    void Start()
    {

        //1) Create an empty GameObject with the required Components
        _cube = new GameObject("Cube");
        _cube.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = _cube.AddComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;


        //Create a 'Cube' mesh...

        //2) Define the cube's dimensions
        float length = 50f;
        float width = 15f;
        float height = 1f;


        //3) Define the co-ordinates of each Corner of the cube 
        Vector3[] c = new Vector3[8];

        c[0] = new Vector3(-length * .5f, -width * .5f, height * .5f);
        c[1] = new Vector3(length * .5f, -width * .5f, height * .5f);
        c[2] = new Vector3(length * .5f, -width * .5f, -height * .5f);
        c[3] = new Vector3(-length * .5f, -width * .5f, -height * .5f);

        c[4] = new Vector3(-length * .5f, width * .5f, height * .5f);
        c[5] = new Vector3(length * .5f, width * .5f, height * .5f);
        c[6] = new Vector3(length * .5f, width * .5f, -height * .5f);
        c[7] = new Vector3(-length * .5f, width * .5f, -height * .5f);


        //4) Define the vertices that the cube is composed of:
        //I have used 16 vertices (4 vertices per side). 
        //This is because I want the vertices of each side to have separate normals.
        //(so the object renders light/shade correctly) 
        Vector3[] vertices = new Vector3[]
        {
            c[0], c[1], c[2], c[3], // Bottom
	        c[7], c[4], c[0], c[3], // Left
	        c[4], c[5], c[1], c[0], // Front
	        c[6], c[7], c[3], c[2], // Back
	        c[5], c[6], c[2], c[1], // Right
	        c[7], c[6], c[5], c[4]  // Top
        };


        //5) Define each vertex's Normal
        Vector3 up = Vector3.up;
        Vector3 down = Vector3.down;
        Vector3 forward = Vector3.forward;
        Vector3 back = Vector3.back;
        Vector3 left = Vector3.left;
        Vector3 right = Vector3.right;


        Vector3[] normals = new Vector3[]
        {
            down, down, down, down,             // Bottom
	        left, left, left, left,             // Left
	        forward, forward, forward, forward,	// Front
	        back, back, back, back,             // Back
	        right, right, right, right,         // Right
	        up, up, up, up	                    // Top
        };


        //6) Define each vertex's UV co-ordinates
        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        Vector2[] uvs = new Vector2[]
        {
            uv11, uv01, uv00, uv10, // Bottom
	        uv11, uv01, uv00, uv10, // Left
	        uv11, uv01, uv00, uv10, // Front
	        uv11, uv01, uv00, uv10, // Back	        
	        uv11, uv01, uv00, uv10, // Right 
	        uv11, uv01, uv00, uv10  // Top
        };


        //7) Define the Polygons (triangles) that make up the our Mesh (cube)
        //IMPORTANT: Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        //This means that a polygon's vertices must be defined in 
        //a clockwise order (relative to the camera) in order to be rendered/visible.
        int[] triangles = new int[]
        {
            3, 1, 0,        3, 2, 1,        // Bottom	
	        7, 5, 4,        7, 6, 5,        // Left
	        11, 9, 8,       11, 10, 9,      // Front
	        15, 13, 12,     15, 14, 13,     // Back
	        19, 17, 16,     19, 18, 17,	    // Right
	        23, 21, 20,     23, 22, 21,	    // Top
        };


        //8) Build the Mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.Optimize();
        //mesh.RecalculateNormals();

        _cube.transform.Translate(0f, 1f, -8f);

        //9) Give it a Material
        Material cubeMaterial = new Material(Shader.Find("Standard"));
        cubeMaterial.SetColor("_Color", new Color(0f, 0.7f, 0f)); //green main color
        _cube.GetComponent<Renderer>().material = cubeMaterial;


        //1) Create an empty GameObject with the required Components
        _cube1 = new GameObject("Cube");
        _cube1.AddComponent<MeshRenderer>();
        MeshFilter meshFilter1 = _cube.AddComponent<MeshFilter>();
        Mesh mesh1 = meshFilter1.mesh;
        //mesh1.Clear();
        mesh1.vertices = vertices;
        mesh1.triangles = triangles;
        mesh1.normals = normals;
        mesh1.uv = uvs;
        mesh1.Optimize();

        _cube1.transform.Translate(1f, 2f, 3f);
        _cube1.GetComponent<Renderer>().material = cubeMaterial;




    }

}*/

/*using UnityEngine;

public class Walls : MonoBehaviour
{
    public float width = 100;
    public float height = 25;
    public float depth = 1;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[8]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(width, height, 0),
            new Vector3(0, height, 0),
            new Vector3(0, 0, depth),
            new Vector3(width, 0, depth),
            new Vector3(width, height, depth),
            new Vector3(0, height, depth)
        };

        int[] triangles = new int[36]
        {
            0, 2, 1, //front
            0, 3, 2,
            2, 3, 6, //top
            3, 7, 6,
            1, 2, 6, //right
            1, 6, 5,
            0, 7, 3, //left
            0, 4, 7,
            4, 5, 6, //back
            4, 6, 7,
            0, 1, 5, //bottom
            0, 5, 4
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        //create a second wall
        GameObject wall2 = new GameObject("wall2");
        wall2.AddComponent<MeshFilter>();
        wall2.AddComponent<MeshRenderer>();
        wall2.AddComponent<BoxCollider>();
        MeshFilter meshFilter2 = wall2.GetComponent<MeshFilter>();
        MeshRenderer renderer2 = wall2.GetComponent<MeshRenderer>();
        renderer2.material = GetComponent<Renderer>().material; // You can also change the material if needed
        meshFilter2.mesh = mesh;
        wall2.transform.position = new Vector3(width + 0.1f, 0, 0);  // Change the position if needed
        wall2.transform.Rotate(new Vector3(0, 90, 0)); // Rotate the wall to 90 degrees
    }
}*/