namespace RandomIdle;

public abstract class BaseGenerator(BigDouble baseProduction, BigDouble baseCost, float costExponentBase, float amount = 0f)
{
    public float Amount = amount;
    public BigDouble BaseProduction = baseProduction;
    public BigDouble BaseCost = baseCost;
    public float CostExponentBase = costExponentBase;
    public BigDouble ProductionMultiplier = new();

    public string CurrencyName = "";
    public virtual BigDouble Currency { get; set; }

    public virtual BigDouble CalculateCost(float? amount = null) => BaseCost.Multiply(new BigDouble(CostExponentBase).Pow(amount ?? Amount));

    public virtual BigDouble CalculateProduction(float? amount = null) => BaseProduction.Multiply((amount ?? Amount) * ProductionMultiplier);

    public abstract void Draw();

    /// <summary>
    /// Buys the generator only if player has enough currency
    /// </summary>
    /// <returns>True if generator was bought successfully, false otherwise</returns>
    public virtual bool TryBuy()
    {
        if (!Currency.GreaterOrEqual(CalculateCost())) return false;

        Buy();
        return true;
    }

    /// <summary>
    /// Buys the generator even if that'll make currency amount negative
    /// </summary>
    public virtual void Buy()
    {
        Currency = Currency.Subtract(CalculateCost());
        Amount++;
    }

    public virtual void BuyMax() { while (TryBuy()) {} }

    public virtual void Update() {}
}