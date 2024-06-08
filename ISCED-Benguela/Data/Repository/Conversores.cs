using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ISCED_Benguela.Data.Repository
{
    public class Conversores
    {
        public static async Task<byte[]> Conversores_for_bytesAsync(IFormFile file)
        {
            using(var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                return stream.ToArray();
            }
        }

        public static IActionResult GetFile(byte[] ficheiro, string extensao)
        {
            try
            {
                if (ficheiro == null)
                    return new NotFoundResult();

                string tipoMIME;

                // Define o tipo MIME com base na extensão
                if (extensao.Equals("pdf", StringComparison.OrdinalIgnoreCase))
                {
                    tipoMIME = "application/pdf";
                }
                else if (extensao.Equals("jpg", StringComparison.OrdinalIgnoreCase) ||
                         extensao.Equals("jpeg", StringComparison.OrdinalIgnoreCase) ||
                         extensao.Equals("png", StringComparison.OrdinalIgnoreCase) ||
                         extensao.Equals("gif", StringComparison.OrdinalIgnoreCase))
                {
                    tipoMIME = "image/" + extensao.ToLower();
                }
                else
                {
                    // Se não for uma imagem nem um PDF, assume-se que seja um tipo de arquivo genérico
                    tipoMIME = "application/octet-stream";
                }

                // Retorna o arquivo como um FileContentResult
                return new FileContentResult(ficheiro, tipoMIME)
                {
                    FileDownloadName = Guid.NewGuid() + "." + extensao
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
