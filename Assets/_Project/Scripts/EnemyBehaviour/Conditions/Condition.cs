using System;

public class Condition
{
    public Func<bool> Test;
    public Condition(Func<bool> test)
    {
        Test = test;
    }
}
