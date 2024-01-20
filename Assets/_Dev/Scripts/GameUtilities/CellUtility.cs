using _Dev.Scripts.Data;
using _Dev.Scripts.Enums;

namespace _Dev.Scripts.GameUtilities
{
    public static class CellUtility
    {
        public static bool IsCellEmpty(this Cell cell)
        {
            return cell.ItemData.ItemType == ItemType.Empty;
        }

        public static void BlastCell(this Cell cell)
        {
            cell.ItemData = new ItemData(ItemType.Empty);
        }
    }
}