using System;

namespace JOS.SystemTextJsonPolymorphism.Generic;

public abstract class Hamburger
{
    protected Hamburger(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public abstract Ingredients Ingredients { get; }
}

public abstract class Hamburger<T> : Hamburger where T : Ingredients
{
    protected Hamburger(string name, T ingredients) : base(name)
    {
        Ingredients = ingredients;
    }

    public override T Ingredients { get; }
}

public class Cheeseburger : Hamburger<CheeseburgerIngredients>
{
    public Cheeseburger(Cheese cheese) : base("Cheeseburger", new CheeseburgerIngredients(cheese))
    {
    }
}

public class BigMac : Hamburger<BigMacIngredients>
{
    public BigMac () : base("Big Mac", new BigMacIngredients())
    {
    }
}

public abstract class Ingredients
{
    public abstract string Name { get; }
}

public class CheeseburgerIngredients : Ingredients
{
    public CheeseburgerIngredients(Cheese cheese)
    {
        Cheese = cheese;
    }

    public override string Name => "Cheeseburger Ingredients";
    public Cheese Cheese { get; }
}

public class BigMacIngredients : Ingredients
{
    public override string Name => "Big Mac Ingredients";
}

[Flags]
public enum Cheese
{
    Cheddar = 1,
    Emmentaler = 2,
    Gouda = 4
}
