using System.Collections;
using UnityEngine;

public class FourAgent : GameAgent
{
    private readonly BitMask[] bitFours = new BitMask[4]
    {
        new BitMask(0b_00001111, new Size(4, 1)),                            // -
        new BitMask(0b_00000001_00000001_00000001_00000001, new Size(1, 4)), // |
        new BitMask(0b_00000001_00000010_00000100_00001000, new Size(4, 4)), // /
        new BitMask(0b_00001000_00000100_00000010_00000001, new Size(4, 4))  // \
    };

    public override void Heuristic(float[] actionsOut)
        => actionsOut[0] = game.input.x;

    protected override Position GetMove(float[] vectorAction)
    {
        Position position = new Position((int)vectorAction[0], 0);
        while (game.board.GetState(position) != 0)
            ++position.y;
        return position;             
    }

    protected override void UpdateActionMask(Position lastMove)
    {
        if (lastMove.y + 1 == game.board.size.y)
            actionMask.Add(lastMove.x);
    }

    protected override bool GetIsWin(int teamId)
    {
        for (int bitFourIndex = 0; bitFourIndex < bitFours.Length; ++bitFourIndex)
            for (Position position = new Position(0, 0); position.x <= game.board.size.x - bitFours[bitFourIndex].size.x; ++position.x)
                for (position.y = 0; position.y <= game.board.size.y - bitFours[bitFourIndex].size.y; ++position.y)
                {
                    ulong fourMask = bitFours[bitFourIndex].bits * BitMask.GetBitMask(position);
                    if ((game.board.GetBitMask(teamId).bits & fourMask) == fourMask)
                        return true;
                }
        return false;
    }

    protected override void ProcesWin()
        => StartCoroutine(EndGame(1, -1));

    protected override void ProcesDraw()
        => StartCoroutine(EndGame(0, 0));

    IEnumerator EndGame(float myReward, float opponentReward)
    {
        yield return new WaitForSeconds(1.0f);
        SetReward(myReward);
        EndEpisode();
        opponent.SetReward(opponentReward);
        opponent.EndEpisode();
    }
}