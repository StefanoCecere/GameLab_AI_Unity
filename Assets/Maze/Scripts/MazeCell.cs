using UnityEngine;
namespace catlike.maze
{
    public class MazeCell : MonoBehaviour
    {

        public IntVector2 coordinates;

        public MazeRoom room;

        private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

        private int initializedEdgeCount;

        public bool IsFullyInitialized
        {
            get
            {
                return initializedEdgeCount == MazeDirections.Count;
            }
        }

        public MazeDirection RandomUninitializedDirection
        {
            get
            {
                int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
                for (int i = 0; i < MazeDirections.Count; i++)
                {
                    if (edges[i] == null)
                    {
                        if (skips == 0)
                        {
                            return (MazeDirection)i;
                        }
                        skips -= 1;
                    }
                }
                throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
            }
        }

        public void Initialize(MazeRoom room)
        {
            room.Add(this);
            transform.GetChild(0).GetComponent<Renderer>().material = room.settings.floorMaterial;
        }

        public MazeCellEdge GetEdge(MazeDirection direction)
        {
            return edges[(int)direction];
        }

        public void SetEdge(MazeDirection direction, MazeCellEdge edge)
        {
            edges[(int)direction] = edge;
            initializedEdgeCount += 1;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnPlayerEntered()
        {
            room.Show();
            for (int i = 0; i < edges.Length; i++)
            {
                edges[i].OnPlayerEntered();
            }
        }

        public void OnPlayerExited()
        {
            room.Hide();
            for (int i = 0; i < edges.Length; i++)
            {
                edges[i].OnPlayerExited();
            }
        }
    }
}