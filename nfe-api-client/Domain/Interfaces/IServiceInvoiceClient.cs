using ServiceInvoice.Domain.Common;
using ServiceInvoice.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceInvoice.Domain.Interfaces
{
    interface IServiceInvoiceClient
    {
        /// <summary>Emitir uma Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da nota fiscal de serviço</param>
        /// <returns>Nota Fiscal de Serviço foi enviada com sucesso para fila de emissão</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<ServiceInvoiceResource>> PostAsync(string company_id, Models.ServiceInvoice item, CancellationToken cancellationToken);

        /// <summary>Obter os detalhes de uma Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<ServiceInvoiceResource>> GetOneAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>Listar as Notas Fiscais de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="pageCount">Items por página</param>
        /// <param name="pageIndex">Número da página</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<ServiceInvoiceResource>> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken);

        /// <summary>Cancelar uma Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Nota fiscal cancelada com sucesso</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<ServiceInvoiceResource>> DeleteAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>Enviar email para o Tomador com a Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<string>> SendEmailAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>URL para Download do PDF da Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<string>> GetDocumentPdfUrlAsync(string company_id, string invoiceId, CancellationToken cancellationToken);

        /// <summary>Bytes para gerar o PDF da Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<byte[]>> GetDocumentPdfBytesAsync(string company_id, string invoiceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Download do XML da Nota Fiscal de Serviço (NFSe)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="invoiceId">ID da Nota Fiscal de Serviço (NFSe)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Result<string>> GetDocumentXmlAsync(string company_id, string invoiceId, CancellationToken cancellationToken);
    }
}
