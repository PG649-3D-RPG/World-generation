using UnityEngine;
using System;
using System.Linq;

public class Generate2DDungeon : MonoBehaviour
{
    [Header("Space Partitioning")]
    public int width = 256;
    public int depth = 256;
    public SPTreeT.PartitionMode partitionMode;
    public int minPartitionWidth = 16;
    public int minPartitionDepth = 16;
    [Header("Room Placement")]
    public int leftRightMinMargin = 1;
    public int leftRightMaxMargin = 5;
    public int frontBackMinMargin = 1;
    public int frontBackMaxMargin = 5;
    public int roomPlacementProbability = 100;
    [Header("Corridors")]
    public float minCorridorWidth = 1;
    public float maxCorridorWidth = 1;
    void Start()
    {
        int[] size = new int[] {width,depth};
        int[] minSize = new int[] {minPartitionWidth,minPartitionDepth};
        Tuple<int,int>[] minMaxMargin = new Tuple<int,int>[] {new Tuple<int,int> (leftRightMinMargin,leftRightMaxMargin), new Tuple<int,int> (frontBackMinMargin,frontBackMaxMargin)};
        SPTreeT spTree;
        switch(partitionMode){
            case SPTreeT.PartitionMode.KDTreeRandom:
                spTree = new SPTreeT(size, SPTreeT.KDTreeRandom(minSize));
                break;
            case SPTreeT.PartitionMode.QuadTreeUniform:
                spTree = new SPTreeT(size, SPTreeT.QuadTreeUniform(), SPTreeT.StopMinSize(minSize));
                break;
            default:
                spTree = new SPTreeT(size, SPTreeT.KDTreeRandom(minSize));
                break;
        }
        DungeonTreeT dTree = new DungeonTreeT(spTree);
        dTree.Root.Node.FHeight = DungeonTreeNode.fHeight2DMinMax(3,4);
        dTree.Root.Node.MinMaxMargin = minMaxMargin;
        dTree.PlaceRooms(roomPlacementProbability);
        dTree.ToGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
