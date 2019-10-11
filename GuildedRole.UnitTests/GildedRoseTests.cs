using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GuildedRose;
using System.Collections.Generic;
using Xunit;

namespace GuildedRole.UnitTests
{
    public class GildedRoseTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void Test1()
        {
            CombinationApprovals.VerifyAllCombinations(
                DoQualityUpdate,
                new[] { "foo", },
                new[] { 0, },
                new[] { 0, });
        }

        private static Item DoQualityUpdate(string name, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            return Items[0];
        }
    }
}
