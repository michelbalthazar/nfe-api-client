using nfe.api.client.Domain.Models.Product;
using nfe.api.client.Domain.Models.Resource;
using ServiceInvoice.Domain.Common;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceInvoice.Domain.Interfaces
{
    interface IProductInvoiceClient
    {
        /// <summary>Emitir uma Nota Fiscal de Produto(NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da nota fiscal de produto</param>
        /// <returns>Nota Fiscal de Produto foi enviada com sucesso para fila de emissão</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<InvoiceResource>> PostAsync(string company_id, Invoice item, CancellationToken cancellationToken);

        /// <summary>Obter os detalhes de uma Nota Fiscal de Produto (NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Produto (NFe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<InvoiceResource>> GetOneAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>Listar as Notas Fiscais de Produto (NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="pageCount">Items por página</param>
        /// <param name="pageIndex">Número da página</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<InvoiceResource>> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken);

        /// <summary>Cancelar uma Nota Fiscal de Produto (NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Produto (NFe)</param>
        /// <returns>Nota fiscal cancelada com sucesso</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<InvoiceResource>> DeleteAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>URL para Download do PDF da Nota Fiscal de Produto (NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Produto (NFe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<string>> GetDocumentPdfUrlAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>Download do XML da Nota Fiscal de Produto (NFe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Produto (NFe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<string>> GetDocumentXmlAsync(string company_id, string invoiceId, CancellationToken cancellationToken);
    }
}
