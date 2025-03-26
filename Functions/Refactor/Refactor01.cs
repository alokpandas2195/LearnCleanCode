public void ProcessOrder(Order order) 
{
    ValidateOrder(order);  
    order.Total = CalculateTotalItems(order.items);    

    if (order.Customer.IsPremium) 
    {
        order.Total = ApplyDiscount(order.Total, 10);
    }

    SaveToDataBase(order);
    SendConfirmationToEmail(order);
}

private bool ValidateOrder(Order order)
{
    if (order == null) throw new ArgumentNullException();
    if (order.Items.Count == 0) throw new InvalidOperationException("Empty order");
}

private decimal CalculateTotalItems(List<Item> items)
{
    decimal total = 0;
    foreach (var item in items) 
    {
        total += item.Price * item.Quantity;
        if (item.IsTaxable) 
        {
            total += item.Price * 0.1m; // 10% tax
        }
    }

    return total;
}

private decimal ApplyDiscount(decimal theGrossAmount, decimal theDiscountRate)
{
    return (theGrossAmount - theGrossAmount * (theDiscountRate / 100));

}

private void SaveToDataBase(Order order)
{    
    using (var aDataBase = new AppDbContext()) 
    {
        aDataBase.Orders.Add(order);
        aDataBase.SaveChanges();
    }
}

private void SendConfirmationToEmail(Order order)
{
    var emailService = new EmailService();
    emailService.Send(order.Customer.Email, "Order Confirmed", $"Total: ${order.Total}");
}
