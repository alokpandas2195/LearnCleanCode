
// no need to modify the object being passed as argument
public decimal ComputeDiscountOnTotalAmount(Order order, decimal discountAmount)  
{  
    return order.total - discountAmount;
}  