namespace AbstractFactory2
{
    /// <summary>
    /// The 'AbstractFactory' interface.
    /// </summary>
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }
}
