using GuildedRose;
using System.Collections.Generic;
using Xunit;

namespace GuildedRole.UnitTests
{
    public class GildedRoseTests
    {
        [Fact]
        public void Test1()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}
