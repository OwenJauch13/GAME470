using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
        public GameObject room;
        public Vector2 ofset;
    }

    public Vector2 size;
    public int startoPos = 0;

    List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        MapGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMap()
    {
         for (int i = 0; i < size.x; i ++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j + size.x)];
                if(currentCell.visited)
                {
                    //var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavier>;
                    //newRoom.UpdateRoom(currentCell.status);

                    //newRoom.namw += " " + i + j;
                }
            }
        }
    }

    void MapGenerator()
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startoPos;

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 1000)
        {
            k++;

            board[currentCell].visited = true;


            if(currentCell == board.Count - 1)
            {
                break;
            }

            //check the cells neighbors 
            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count ==0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                   currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];
                
                if (newCell > currentCell)
                {
                    //dowm or left 
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or right 
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }
            }
        }
        GenerateMap();
    }

    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell-size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        //check down neighbor
        if (cell + size.x >= 0 && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        //check left neighbor
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        //check right neighbor
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell +1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        return neighbors;
    }
}
