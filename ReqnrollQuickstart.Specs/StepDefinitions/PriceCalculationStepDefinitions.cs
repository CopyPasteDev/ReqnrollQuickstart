namespace ReqnrollQuickstart.Specs.StepDefinitions;

[Binding]
public class PriceCalculationStepDefinitions
{
    private readonly PriceCalculator _priceCalculator = new();
    private readonly Dictionary<string, int> _basket = new();
    private decimal _calculatedPrice;
    
    [Given("the client started shopping")]
    public void GivenTheClientStartedShopping()
    {
        _basket.Clear();
        _calculatedPrice = 0;
    }

    [Given("the client added {int} pcs of {string} to the basket")]
    public void GivenTheClientAddedPcsOfToTheBasket(int quantity, string product)
    {
        _basket[product] = quantity;
    }
    
    [Given("the client added")]
    public void GivenTheClientAdded(Table itemsTable)
    {
        var items = itemsTable.CreateSet<(string Product, int Quantity)>();
        foreach (var item in items)
        {
            _basket.Add(item.Product, item.Quantity);
        }
    }

    [When("the basket is prepared")]
    public void WhenTheBasketIsPrepared()
    {
        _calculatedPrice = _priceCalculator.CalculatePrice(_basket);
    }

    [Then("the basket price should be ${decimal}")]
    public void ThenTheBasketPriceShouldBe(decimal expectedPrice)
    {
        _calculatedPrice.Should().Be(expectedPrice);
    }
}