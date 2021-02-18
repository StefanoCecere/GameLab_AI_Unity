/// <summary>
/// 8x8 bitmask
/// </summary>
public class BitMask
{
    /// <summary>
    /// masks for columns
    /// </summary>
    private static readonly ulong[] columnMasks = new ulong[8]
    {
        0b_00000001_00000001_00000001_00000001_00000001_00000001_00000001_00000001,
        0b_00000010_00000010_00000010_00000010_00000010_00000010_00000010_00000010,
        0b_00000100_00000100_00000100_00000100_00000100_00000100_00000100_00000100,
        0b_00001000_00001000_00001000_00001000_00001000_00001000_00001000_00001000,
        0b_00010000_00010000_00010000_00010000_00010000_00010000_00010000_00010000,
        0b_00100000_00100000_00100000_00100000_00100000_00100000_00100000_00100000,
        0b_01000000_01000000_01000000_01000000_01000000_01000000_01000000_01000000,
        0b_10000000_10000000_10000000_10000000_10000000_10000000_10000000_10000000
    };

    /// <summary>
    /// masks for rows
    /// </summary>
    private static readonly ulong[] rowMasks = new ulong[8]
    {
        0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_11111111,
        0b_00000000_00000000_00000000_00000000_00000000_00000000_11111111_00000000,
        0b_00000000_00000000_00000000_00000000_00000000_11111111_00000000_00000000,
        0b_00000000_00000000_00000000_00000000_11111111_00000000_00000000_00000000,
        0b_00000000_00000000_00000000_11111111_00000000_00000000_00000000_00000000,
        0b_00000000_00000000_11111111_00000000_00000000_00000000_00000000_00000000,
        0b_00000000_11111111_00000000_00000000_00000000_00000000_00000000_00000000,
        0b_11111111_00000000_00000000_00000000_00000000_00000000_00000000_00000000
    };

    /// <summary>
    /// Bits of the mask
    /// </summary>
    public ulong bits;

    /// <summary>
    /// Size of the mask
    /// </summary>
    public Size size;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="bits"></param>
    /// <param name="size">Max 8x8</param>
    public BitMask(ulong bits, Size size)
    {
        this.bits = bits;
        this.size = size;
    }

    /// <summary>
    /// Get bit at position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool GetBit(Position position)
        => (bits & columnMasks[position.x] & rowMasks[position.y]) != 0;

    /// <summary>
    /// Set bit at position
    /// </summary>
    /// <param name="position"></param>
    /// <param name="bit"></param>
    public void SetBit(Position position, bool bit)
    {
        if (bit)
            bits |= GetBitMask(position);
        else
            bits &= ~GetBitMask(position);
    }

    /// <summary>
    /// Get bitMask for a certain position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static ulong GetBitMask(Position position)
        => columnMasks[position.x] & rowMasks[position.y];
}