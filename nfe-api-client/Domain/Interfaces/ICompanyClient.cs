using ServiceInvoice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nfe.api.client.Domain.Interfaces
{
    public interface ICompanyClient
    {
        /// <summary>Listar as empresas ativas de uma conta</summary>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<IEnumerable<LegalPerson>> GetAsync(System.Threading.CancellationToken cancellationToken);

        /// <summary>Criar uma empresa</summary>
        /// <param name="item">Dados da empresa</param>
        /// <returns>Sucesso na criação da empresa</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<LegalPerson> PostAsync(LegalPerson item, System.Threading.CancellationToken cancellationToken);

        /// <summary>Obter os detalhes de uma empresa</summary>
        /// <param name="company_id_or_tax_number">ID da empresa ou Inscrição Federal (CNPJ)</param>
        /// <returns>Sucesso na requisição</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<LegalPerson> GetOneAsync(string company_id_or_tax_number, System.Threading.CancellationToken cancellationToken);

        /// <summary>Atualizar uma empresa</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="item">Dados da empresa</param>
        /// <returns>Sucesso na atualização da empresa</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<LegalPerson> PutAsync(string company_id, LegalPerson item, System.Threading.CancellationToken cancellationToken);

        /// <summary>Excluir uma empresa</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <returns>Sucesso na remoção da empresa</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<object> DeleteAsync(string company_id, System.Threading.CancellationToken cancellationToken);

        /// <summary>Upload do certificado digital da empresa usando array de byte</summary>
        /// <param name="company_id">ID da empresa</param>
        /// <param name="file">Arquivo do certificado digital com extensao PFX ou P12</param>
        /// <param name="password">Senha do arquivo do certificado digital</param>
        /// <returns>Sucesso na atualização da empresa</returns>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        Task<string> CertificateUploadAsync(string company_id, byte[] file, string password, System.Threading.CancellationToken cancellationToken);
    }
}
