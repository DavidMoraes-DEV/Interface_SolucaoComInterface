namespace SolucaoComInterface.Services
{
    interface ITaxService //Por convenção da linguagem C# toda interface é colocada na frente de seu nome o "I" para facilitar em sua identificação
    {
        double Tax(double amount); //A interface define apenas o contrato
    }
}
