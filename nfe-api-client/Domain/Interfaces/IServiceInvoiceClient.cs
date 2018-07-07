using nfe.api.client.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace nfe.api.client.Domain.Interfaces
{
    interface IServiceInvoiceClient
    {
        /// <summary>Emitir uma Nota Fiscal de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da nota fiscal de serviço</param>
        /// <returns>Nota Fiscal de Serviços foi enviada com sucesso para fila de emissão</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Invoice> PostAsync(string company_id, string apiKey, Invoice item, CancellationToken cancellationToken);

        /// <summary>Obter os detalhes de uma Nota Fiscal de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Invoice> GetOneAsync(string company_id, string id, CancellationToken cancellationToken);

        /// <summary>Listar as Notas Fiscais de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="pageCount">Items por página</param>
        /// <param name="pageIndex">Número da página</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<Invoice> GetAsync(string company_id, int? pageCount, int? pageIndex, CancellationToken cancellationToken);

        /// <summary>Cancelar uma Nota Fiscal de Serviços (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Nota fiscal cancelada com sucesso</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> DeleteAsync(string company_id, string id, string api_Key, CancellationToken cancellationToken);

        /// <summary>Enviar email para o Tomador com a Nota Fiscal de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> SendEmailAsync(string company_id, string id, CancellationToken cancellationToken);

        /// <summary>Download do PDF da Nota Fiscal de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> GetDocumentPdfAsync(string company_id, string id, CancellationToken cancellationToken);

        /// <summary>Download do XML da Nota Fiscal de Serviço (NFSE)</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="id">ID da Nota Fiscal de Serviço (NFSE)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> GetDocumentXmlAsync(string company_id, string id, CancellationToken cancellationToken);
    }
}
