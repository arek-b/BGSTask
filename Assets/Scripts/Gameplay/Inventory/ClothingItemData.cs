using UnityEngine;

namespace Gameplay.Inventory
{
    [CreateAssetMenu(fileName = "ClothingData", menuName = "ScriptableObjects/ClothingItemData")]
    public class ClothingItemData : ScriptableObject
    {
        public string itemName;
        public int buyPrice;
        public int sellPrice;
        public Sprite icon;
        public ClothingType clothingType;
        public Sprite[] paperDollSprites;

        public enum ClothingType { Outfit = 0, Hat = 1 };
    }
}