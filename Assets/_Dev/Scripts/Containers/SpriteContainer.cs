using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Enums;
using _Dev.Scripts.Systems.ServiceLocator;
using UnityEngine;
using ItemSkill = _Dev.Scripts.Enums.SkillType;

namespace _Dev.Scripts
{
    public static class SpriteContainer
    {
        private static readonly SpriteProvider _spriteProvider = ServiceLocator.Instance.Get<SpriteProvider>();

        private static readonly Dictionary<SpriteId, Sprite> _spriteDataBySpriteId = new()
        {
            { SpriteId.Invalid, _spriteProvider.InValid },
            { SpriteId.Red, _spriteProvider.Red },
            { SpriteId.Blue, _spriteProvider.Blue },
            { SpriteId.Green, _spriteProvider.Green },
            { SpriteId.Yellow, _spriteProvider.Yellow },
            { SpriteId.Purple, _spriteProvider.Purple },
            { SpriteId.Pink, _spriteProvider.Pink },
            { SpriteId.RedBasicBomb, _spriteProvider.RedBasicBomb },
            { SpriteId.RedTwoDirectionalRocket, _spriteProvider.RedTwoDirectionalRocket },
            { SpriteId.RedDisco, _spriteProvider.RedDisco },
            { SpriteId.BlueBasicBomb, _spriteProvider.BlueBasicBomb },
            { SpriteId.BlueTwoDirectionalRocket, _spriteProvider.BlueTwoDirectionalRocket },
            { SpriteId.BlueDisco, _spriteProvider.BlueDisco },
            { SpriteId.GreenBasicBomb, _spriteProvider.GreenBasicBomb },
            { SpriteId.GreenTwoDirectionalRocket, _spriteProvider.GreenTwoDirectionalRocket },
            { SpriteId.GreenDisco, _spriteProvider.GreenDisco },
            { SpriteId.YellowBasicBomb, _spriteProvider.YellowBasicBomb },
            { SpriteId.YellowTwoDirectionalRocket, _spriteProvider.YellowTwoDirectionalRocket },
            { SpriteId.YellowDisco, _spriteProvider.YellowDisco },
            { SpriteId.PurpleBasicBomb, _spriteProvider.PurpleBasicBomb },
            { SpriteId.PurpleTwoDirectionalRocket, _spriteProvider.PurpleTwoDirectionalRocket },
            { SpriteId.PurpleDisco, _spriteProvider.PurpleDisco },
            { SpriteId.PinkBasicBomb, _spriteProvider.PinkBasicBomb },
            { SpriteId.PinkTwoDirectionalRocket, _spriteProvider.PinkTwoDirectionalRocket },
            { SpriteId.PinkDisco, _spriteProvider.PinkDisco },
        };

        private static readonly Dictionary<ItemType, Sprite> _spriteDataByItemType = new()
        {
            { ItemType.Invalid, _spriteProvider.InValid },
            { ItemType.Empty, _spriteProvider.InValid },
            { ItemType.Red, _spriteProvider.Red },
            { ItemType.Blue, _spriteProvider.Blue },
            { ItemType.Green, _spriteProvider.Green },
            { ItemType.Yellow, _spriteProvider.Yellow },
            { ItemType.Purple, _spriteProvider.Purple },
            { ItemType.Pink, _spriteProvider.Pink },
        };

        private static readonly Dictionary<ItemType, SpriteId> _spriteIdByItemType = new()
        {
            { ItemType.Invalid, SpriteId.Invalid },
            { ItemType.Empty, SpriteId.Invalid },
            { ItemType.Red, SpriteId.Red },
            { ItemType.Blue, SpriteId.Blue },
            { ItemType.Green, SpriteId.Green },
            { ItemType.Yellow, SpriteId.Yellow },
            { ItemType.Purple, SpriteId.Purple },
            { ItemType.Pink, SpriteId.Pink },
        };

        private static readonly Dictionary<(ItemType, ItemSkill), SpriteId> _specificItemSpriteByType = new()
        {
            { (ItemType.Red, ItemSkill.BasicBomb), SpriteId.RedBasicBomb },
            { (ItemType.Red, ItemSkill.TwoDirectionalRocket), SpriteId.RedTwoDirectionalRocket },
            { (ItemType.Red, ItemSkill.Disco), SpriteId.RedDisco },
            { (ItemType.Blue, ItemSkill.BasicBomb), SpriteId.BlueBasicBomb },
            { (ItemType.Blue, ItemSkill.TwoDirectionalRocket), SpriteId.BlueTwoDirectionalRocket },
            { (ItemType.Blue, ItemSkill.Disco), SpriteId.BlueDisco },
            { (ItemType.Green, ItemSkill.BasicBomb), SpriteId.GreenBasicBomb },
            { (ItemType.Green, ItemSkill.TwoDirectionalRocket), SpriteId.GreenTwoDirectionalRocket },
            { (ItemType.Green, ItemSkill.Disco), SpriteId.GreenDisco },
            { (ItemType.Yellow, ItemSkill.BasicBomb), SpriteId.YellowBasicBomb },
            { (ItemType.Yellow, ItemSkill.TwoDirectionalRocket), SpriteId.YellowTwoDirectionalRocket },
            { (ItemType.Yellow, ItemSkill.Disco), SpriteId.YellowDisco },
            { (ItemType.Purple, ItemSkill.BasicBomb), SpriteId.PurpleBasicBomb },
            { (ItemType.Purple, ItemSkill.TwoDirectionalRocket), SpriteId.PurpleTwoDirectionalRocket },
            { (ItemType.Purple, ItemSkill.Disco), SpriteId.PurpleDisco },
            { (ItemType.Pink, ItemSkill.BasicBomb), SpriteId.PinkBasicBomb },
            { (ItemType.Pink, ItemSkill.TwoDirectionalRocket), SpriteId.PinkTwoDirectionalRocket },
            { (ItemType.Pink, ItemSkill.Disco), SpriteId.PinkDisco }
        };

        public static bool TryGetSpecificSprite((ItemType type, ItemSkill skill) key, out Sprite sprite)
        {
            var id = GetSpriteIdByItemType(key.type);

            if (!_specificItemSpriteByType.TryGetValue(key, out var spriteId))
            {
                sprite = GetSpriteBySpriteId(id);
                return false;
            }

            sprite = GetSpriteBySpriteId(spriteId);
            return true;
        }

        private static Sprite GetSpriteBySpriteId(SpriteId spriteId)
        {
            return _spriteDataBySpriteId.TryGetValue(spriteId, out var sprite) ? sprite : _spriteProvider.InValid;
        }

        public static Sprite GetSpriteByItemType(ItemType itemType)
        {
            return _spriteDataByItemType.TryGetValue(itemType, out var sprite) ? sprite : _spriteProvider.InValid;
        }

        private static SpriteId GetSpriteIdByItemType(ItemType itemType)
        {
            return _spriteIdByItemType.GetValueOrDefault(itemType, SpriteId.Invalid);
        }
    }
}