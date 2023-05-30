using Override;

Money price = new Money(100, 25);
Goods goods = new Goods("Test goods", DateTime.Parse("2022-01-01"), price, 10, 1234);

Console.WriteLine(goods.GetTotalCost()); 
goods.ChangePrice(new Money(80, 0));
Console.WriteLine(goods.GetTotalCost()); 
goods.ChangeQuantity(5);
Console.WriteLine(goods.GetTotalCost()); 
goods.DiscountExpiredGoods();
Console.WriteLine(goods.GetTotalCost()); 

Money m1 = new Money(100, 50);
Money m2 = new Money(50, 25);
Console.WriteLine(m1 + m2); 
Console.WriteLine(m1 - m2); 
Console.WriteLine(m1 / 3); 
Console.WriteLine(m1 * 1.5); 
Console.WriteLine(m2 == new Money(50, 25)); 
Console.WriteLine(m1 != new Money(100, 75)); 
Console.WriteLine(m1 > m2); 
Console.WriteLine(m1 <= m2); 

