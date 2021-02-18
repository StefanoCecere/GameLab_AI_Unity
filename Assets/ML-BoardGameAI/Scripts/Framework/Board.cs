using UnityEngine;

/// <summary>
/// Board (max 8x8, 2 players, 3 states: -1, 0, 1)
/// </summary>
public class Board
{
    private BitMask[] playerBitMasks;

    public Size size => playerBitMasks[0].size;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="width">amount of columns</param>
    /// <param name="height">amount of rows</param>
    public Board(int width, int height)
    {
        Size size = new Size(width, height);
        this.playerBitMasks = new BitMask[2] { new BitMask(0, size), new BitMask(0, size) };      
    }

    /// <summary>
    /// Gets the state (-1 / 0 / 1)
    /// </summary>
    /// <param name="position"></param>
    /// <returns>player 0: -1, clear = 0, player 1: 1</returns>
    public float GetState(Position position)
        => (playerBitMasks[0].GetBit(position) ? -1f : 0f)
         + (playerBitMasks[1].GetBit(position) ? +1f : 0f);

    /// <summary>
    /// Sets the state (-1 / 0 / 1)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="state">player 0: -1, clear = 0, player 1: 1</param>
    public void SetState(Position position, int state)
    {
        if (position.x < size.x && position.y < size.y)
            switch (state)
            {
                case -1:
                    playerBitMasks[0].SetBit(position, true);
                    break;
                case 0:
                    playerBitMasks[0].SetBit(position, false);
                    playerBitMasks[1].SetBit(position, false);
                    break;
                case +1:
                    playerBitMasks[1].SetBit(position, true);
                    break;
                default:
                    Debug.Log($"Board.SetState: Invalid state ({state})");
                    break;
            }
        else
            Debug.Log($"Board.SetState: position out of bounds ({position.x}, {position.y})");
    }

    /// <summary>
    /// Clears the board
    /// </summary>
    public void Clear()
    {
        playerBitMasks[0].bits = 0;
        playerBitMasks[1].bits = 0;
    }

    /// <summary>
    /// Return the bitMask for a player (-1 / 1)
    /// </summary>
    /// <param name="player">-1 / 1</param>
    /// <returns></returns>
    public BitMask GetBitMask(int player)
       => playerBitMasks[player == -1 ? 0 : 1];
}