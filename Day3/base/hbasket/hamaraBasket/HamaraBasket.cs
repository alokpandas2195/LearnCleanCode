using System.Collections.Generic;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        IList<Item> Items;
        public HamaraBasket(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Forest Honey":
                        // do not change anything
                        break;

                    case "Indian Wine":
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                        break;

                    case "Movie Tickets":
                        if (item.SellIn <= 0)
                        {
                            item.Quality = 0;
                        }
                        else if (item.Quality < 50)
                        {
                            item.Quality++;
                            if (item.SellIn <= 10 && item.Quality < 50)
                            {
                                item.Quality++;
                            }
                            if (item.SellIn <= 5 && item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                        break;

                    default:
                        if (item.Quality > 0)
                        {
                            item.Quality--;
                        }
                        item.SellIn--;
                        break;
                }
            }
        }

        /*public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Indian Wine" && Items[i].Name != "Movie Tickets")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Forest Honey")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Movie Tickets")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Forest Honey")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Indian Wine")
                    {
                        if (Items[i].Name != "Movie Tickets")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Forest Honey")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }*/
    }
}
