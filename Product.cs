class Product
{
    static int count = 1000;
    public Product()
    {
        ProductId = ++count;
    }
    public int ProductId { get; private set; }
    public string ProductName { get; set; }
    private int _price;
    /// <summary>
    /// Gets or Sets the Price of the Product
    /// </summary>
    /// <exception cref="SampleConApp.InvalidPriceException"/>
    public int Price
    {
        get { return _price; }
        set
        {
            if (value < 100)
            {
                throw new InvalidPriceException("Price should be more than 100");
            }
            _price = value;
        }
    }
    public int Quantity { get; set; }
    public override string ToString()
    {
        return $"{ProductName}, {Price}, {Quantity}";
    }

    public override int GetHashCode()
    {
        return ProductName.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is Product)
        {
            var temp = obj as Product;
            return temp.ProductName == this.ProductName && temp.Price == this.Price;
        }
        else
            return false;
    }
}