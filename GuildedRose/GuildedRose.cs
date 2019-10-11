using System;
using System.Collections.Generic;

namespace GuildedRose
{
    public class GildedRose
    {
        private static readonly IReadOnlyDictionary<string, Action<Item>> itemUpdaters = new Dictionary<string, Action<Item>>
        {
            ["Aged Brie"] = DoUpdateQualityForAgedBrie,
            ["Backstage passes to a TAFKAL80ETC concert"] = DoUpdateQualityForBackStagepasses,
            ["Sulfuras, Hand of Ragnaros"] = DoUpdateQualityForSulfuras,
        };

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                DoUpdateQuality(Items[i]);
            }
        }

        private static void DoUpdateQuality(Item item)
        {
            if (itemUpdaters.ContainsKey(item.Name))
            {
                itemUpdaters[item.Name](item);
            }
            else
            {
                DoUpdateQualityForEverythingElse(item);
            }
        }

        #region Item updaters

        private static void DoUpdateQualityForEverythingElse(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        private static void DoUpdateQualityForSulfuras(Item item)
        {
        }

        private static void DoUpdateQualityForBackStagepasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        private static void DoUpdateQualityForAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        #endregion Item updaters
    }
}