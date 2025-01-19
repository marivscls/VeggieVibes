using System.ComponentModel;

namespace VeggieVibes.Domain.Enums;

public enum Allergen
{
    [Description("Contém glúten")]
    Gluten = 1,

    [Description("Contém nozes")]
    Nuts = 2,

    [Description("Contém soja")]
    Soy = 3,

    [Description("Contém laticínios")]
    Dairy = 4,

    [Description("Contém ovos")]
    Eggs = 5
}