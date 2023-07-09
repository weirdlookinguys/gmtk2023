using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    private Transform currentPoint;
    private Vector2 direction;
    private Vector2 nextPosition;
    private float viewAngle;
    private float viewDist;
    public LayerMask viewMask;
    private Mesh mesh;
    private float startingAngle;
    private Vector3 origin;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

    }
    private void Update()
    {

        //Mesh Field of View
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = viewAngle / rayCount;

        Vector3[] verticies = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount * 3];

        verticies[0] = origin;
        //Debug.Log(verticies[0]);
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDist);
            //Debug.DrawRay(origin, GetVectorFromAngle(angle), Color.yellow);

            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDist;
            }
            else
            {
                vertex = raycastHit2D.point;
                //Debug.Log(raycastHit2D.collider);
            }

            verticies[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();
    }


    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetViewAngle(float a)
    {
        viewAngle = a;
    }
    public void SetViewDistance(float a)
    {
        viewDist = a;
    }
    public void SetDirection(Vector3 dir)
    {
        startingAngle = GetAngleFromVectorFloat(dir) + viewAngle / 2;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
