using System.Collections.Generic;

public class CurrencyRates {
  public string Disclaimer { get; set; }
  public string License { get; set; }
  public int TimeStamp { get; set; }
  public string Base { get; set; }
  public Dictionary<string, decimal> Rates { get; set; }
} 
