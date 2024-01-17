using _Dev.Scripts.Data;
using Unity.Burst.Intrinsics;

namespace _Dev.Scripts.GameUtilities
{
    public static class CellUtility
    {
        public static bool IsCellEmpty(this Cell cell)
        {
            return cell.ItemData.ItemType == ItemType.Empty;
        }

    }
}