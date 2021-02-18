using Unity.MLAgents;
using Unity.MLAgents.Policies;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class Game : MonoBehaviour
{
    public Board board;

    [SerializeField] private Square squarePrefab;
    [SerializeField] public Agent[] agents = new Agent[2];

    [HideInInspector]
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    public int moveIndex;
    protected Position[] moves;
    protected Square[,] squares;
    public Position input;

    public void Start()
    {
        Clear();
        Agent startingAgent = agents[0];// Random.Range(0, agents.Length)];
        if (startingAgent.GetComponent<BehaviorParameters>().BehaviorType != BehaviorType.HeuristicOnly)
            startingAgent.RequestDecision();
    }

    /// <summary>
    /// Do a move
    /// </summary>
    /// <param name="position"></param>
    public void DoMove(Position position)
    {
        int player = moveIndex % 2 == 0 ? -1 : 1;
        board.SetState(position, player);
        moves[moveIndex++] = position;
        squares[position.x, position.y].Place(player);
    }

    /// <summary>
    /// Undo the last move
    /// </summary>
    public void UndoMove()
    {
        Position position = moves[--moveIndex];
        board.SetState(position, 0);
        squares[position.x, position.y].Clear();
    }

    protected void Reset()
        => gridLayoutGroup = GetComponent<GridLayoutGroup>();

    protected void Awake()
    {
        board = new Board(3, 3);
        moves = new Position[board.size.x * board.size.y];
        squares = new Square[board.size.x, board.size.y];

        Rect rect = (transform as RectTransform).rect;
        gridLayoutGroup.startCorner = GridLayoutGroup.Corner.LowerLeft;
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = board.size.x;
        gridLayoutGroup.cellSize = Vector2.one * Mathf.Min(rect.width / board.size.x, rect.height / board.size.y);

        for (Position position = new Position(0, 0); position.y < board.size.y; ++position.y)
            for (position.x = 0; position.x < board.size.x; ++position.x)
            {
                Position positionCopy = new Position(position.x, position.y);
                squares[position.x, position.y] = Instantiate(squarePrefab, transform).Init(() => HandleInput(positionCopy));
            }
    }

    protected void Update()
    {
        //Player can revert move using right mouse click
        if (Input.GetMouseButtonDown(1) && 0 < moveIndex)
            UndoMove();
    }

    private void Clear()
    {
        board.Clear();
        foreach (Square square in squares)
            square.Clear();
        moveIndex = 0;
    }

    private void HandleInput(Position position)
    {
        input = position;
        Agent agent = agents[moveIndex % 2];
        if (agent.GetComponent<BehaviorParameters>().BehaviorType == BehaviorType.HeuristicOnly)
            agent.RequestDecision();
    }
}