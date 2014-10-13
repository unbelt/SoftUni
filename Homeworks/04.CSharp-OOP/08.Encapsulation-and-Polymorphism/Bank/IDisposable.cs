namespace Bank
{
    using System;

    public interface IDisposable
    {
        Account Withdraw(decimal value);
    }
}