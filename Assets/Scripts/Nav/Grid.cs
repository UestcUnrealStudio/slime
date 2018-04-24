using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Node[,] grid;
    public LayerMask whatLayer;

    public float nodeRadius;

    public int gridHeight;
    public int gridWidth;

    private float nodeDiameter;

    // Use this for initialization
    void Start()
    {
        grid = new Node[gridWidth + 1, gridHeight + 1];
        nodeDiameter = nodeRadius * 2;
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateGrid()
    {
        Vector3 startpos = transform.position - new Vector3(gridWidth / 2, gridHeight / 2);
        for (int i = 0; i <= gridWidth; i++)
        {
            for (int j = 0; j <= gridHeight; j++)
            {
                Vector3 nowPos = startpos + new Vector3(i, j);
                bool canWalk = Physics.CheckSphere(nowPos, nodeRadius, whatLayer);
                grid[i, j] = new Node(nowPos, !canWalk);
            }
        }
    }

    public List<Node> GetNeighbour(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                Vector3 startPos = transform.position - new Vector3(gridWidth / 2, gridHeight / 2);
                int tempX = (int)node.GetPos().x + i - (int)startPos.x;
                int tempY = (int)node.GetPos().y + j - (int)startPos.y;

                if (tempX>=0&&tempX<=gridWidth&&tempY>=0&&tempY<=gridHeight)
                {
                    neighbours.Add(grid[tempX, tempY]);                
                }
            }
        }

        return neighbours;
    }


    void OnDrawGizmos()
    {
        if (grid == null)
        {
            return;
        }
        foreach (var node in grid)
        {
            Gizmos.color = node.canWalk ? Color.white : Color.red;
            Gizmos.DrawCube(node.GetPos(), Vector3.one * (nodeDiameter - 0.1f));
        }
    }
}
