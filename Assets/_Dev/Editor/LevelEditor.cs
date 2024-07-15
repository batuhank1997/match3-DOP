using _Dev.Interfaces;
using _Dev.Providers;
using _Dev.Scripts.Enums;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _Dev.Editor
{
    public class LevelEditor : OdinEditorWindow
    {
        public int X, Y;

        [TableMatrix(HorizontalTitle = "Level", SquareCells = true, ResizableColumns = true)]
        public Texture2D[,] LevelItemsDataMatrix;
        
        [TableMatrix(HorizontalTitle = "Usables Items", SquareCells = true, ResizableColumns = true), OnValueChanged(nameof(OnInventoryChanged))] 
        public Texture2D[,] Items;

        [MenuItem("Tools/Level Editor")]
        private static void OpenWindow()
        {
            GetWindow<LevelEditor>().Show();
        }
        
        [OnInspectorInit]
        private void CreateData()
        {
            InitItems();
            InitEmptyBoard();
        }
        
        [Button]
        public void ResetTable()
        {
            CreateData();
        }
        
        [Button]
        public void SaveLevel()
        {
            SaveLevelDataToJson();
        }

        private void SaveLevelDataToJson()
        {
            
        }

        private void OnInventoryChanged()
        {
            InitItems();
        }

        private void InitEmptyBoard()
        {
            LevelItemsDataMatrix = new Texture2D[X, Y];
            
            for (var x = 0; x < X; x++)
            {
                for (var y = 0; y < Y; y++)
                {
                    LevelItemsDataMatrix[x, y] = null;
                }
            }
        }

        private void InitItems()
        {
            var itemAssets = ServiceLocator.Instance.Get<SpriteProvider>().GetAllSprites();
                
            Items = new Texture2D[itemAssets.Length, 1];

            for (var i = 0; i < itemAssets.Length; i++)
            {
                if (itemAssets[i] == null)
                    continue;
                
                Items[i, 0] = itemAssets[i].texture;
            }
        }
    }
}