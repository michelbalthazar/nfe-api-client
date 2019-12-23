using ServiceInvoice.Domain.Models;

namespace nfe.api.client.Domain.Models.Product
{
    public class PaymentDetail
    {
        /// <summary>
        /// Forma de pagamento (tPag)
        /// <remarks>
        ///     01 - Dinheiro (Cash)
        ///     02 - Cheque (Cheque)
        ///     03 - Cartão de Crédito (CreditCard)
        ///     04 - Cartão de Débito (DebitCard)
        ///     05 - Crédito Loja (StoreCredict)
        ///     10 - Vale Alimentação (FoodVouchers)
        ///     11 - Vale Refeição (MealVouchers)
        ///     12 - Vale Presente (GiftVouchers)
        ///     13 - Vale Combustível (FuelVouchers)
        ///     15 - Boleto Bancário (BankBill)
        ///     90 - Sem Pagamento (WithoutPayment)
        ///     99 - Outros (Others)
        /// </remarks>
        /// </summary>
        public PaymentMethod Method { get; set; }

        /// <summary>
        /// Valor do Pagamento (vPag)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Grupo de Cartões (card)
        /// </summary>
        public Card Card { get; set; }
    }
}