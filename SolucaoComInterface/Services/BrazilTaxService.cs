namespace SolucaoComInterface.Services
{
    class BrazilTaxService : ITaxService //É necessário declarar que a classe BrazilTaxService agora é um SubTipo da interface TaxService e isso é feito pelo mesmo símbolo de herança ":" porém não é uma declaração de herânça e sim uma realização de interface.
    {

        public double Tax (double amount) //A assinatura da método tem que ser compatível com a assinatura da interface.
        {
            if(amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }

    }
}
