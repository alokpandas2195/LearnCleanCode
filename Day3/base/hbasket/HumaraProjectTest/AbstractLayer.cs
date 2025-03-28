
using hamaraBasket;

namespace HumaraProjectTest
{
    public class AbstractLayer
    {
        HamaraBasket hamaraBasket;
        public AbstractLayer(HamaraBasket theHamaraBasket)
        {
            hamaraBasket = theHamaraBasket;
        }

        public void UpdateQuality()
        {
            hamaraBasket.UpdateQuality();
        }
    }
}
