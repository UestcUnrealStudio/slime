using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node  {

    public int x;
    public int y;

    public int F;//预期总代价
    public int G;//从开始位置到此节点的代价
    public int H;//从当前位置到目标位置的预计代价

    public bool canWalk;//是否可以行走

    private Node parentNode;//父节点
    public void SetParentNode(Node parentNode)
    {
        this.parentNode = parentNode;
    }
    public Node GetParentNode()
    {
        return parentNode;
    }

    public void SetPos(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPos()
    {
        return new Vector2(x, y);
    }

    public Node(Vector2 pos,bool canWalk)
    {
        x = (int)pos.x;
        y = (int)pos.y;
        this.canWalk = canWalk;
    }

}
