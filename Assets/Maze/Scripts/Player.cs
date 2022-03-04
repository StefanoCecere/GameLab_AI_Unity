using UnityEngine;
namespace catlike.maze
{
    public class Player : MonoBehaviour
    {

        private MazeCell currentCell;

        private MazeDirection currentDirection;

        public void SetLocation(MazeCell cell)
        {
            if (currentCell != null)
            {
                currentCell.OnPlayerExited();
            }
            currentCell = cell;
            transform.localPosition = cell.transform.localPosition;
            currentCell.OnPlayerEntered();
        }

        private void Move(MazeDirection direction)
        {
            MazeCellEdge edge = currentCell.GetEdge(direction);
            if (edge is MazePassage)
            {
                SetLocation(edge.otherCell);
            }
        }

        private void Look(MazeDirection direction)
        {
            transform.localRotation = direction.ToRotation();
            currentDirection = direction;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(currentDirection);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(currentDirection.GetNextClockwise());
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(currentDirection.GetOpposite());
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(currentDirection.GetNextCounterclockwise());
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Look(currentDirection.GetNextCounterclockwise());
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Look(currentDirection.GetNextClockwise());
            }
        }
    }
}
