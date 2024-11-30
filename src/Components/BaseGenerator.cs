namespace RandomIdle;

public abstract class BaseGenerator(int level, BigDouble baseProduction, BigDouble baseCost, float costExponentBase)
{
    public int Level = level;
    public BigDouble BaseProduction = baseProduction;
    public BigDouble BaseCost = baseCost;
    public float CostExponentBase = costExponentBase;

    public string CurrencyName = "";
    public virtual BigDouble Currency { get; set; }

    public virtual BigDouble CalculateCost() => BaseCost.Multiply(new BigDouble(CostExponentBase).Pow(Level));

    public virtual BigDouble CalculateProduction() => BaseProduction.Multiply(new(Level));

    public abstract void Draw();

    public virtual bool TryBuy()
    {
        if (!Currencies.Water.GreaterOrEqual(CalculateCost())) return false;

        Buy();
        return true;
    }

    public virtual void Buy()
    {
        Currency = Currency.Subtract(CalculateCost());
        Level++;
    }

    public virtual void Update() {}
}