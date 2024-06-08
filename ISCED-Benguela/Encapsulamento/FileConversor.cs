namespace ISCED_Benguela.Encapsulamento
{
    public class FileConversor
    {
        public static string ByteToString(byte[] ficheiro)
        {
            // Convertendo os bytes da imagem para base64
            string imagemBase64 = Convert.ToBase64String(ficheiro);
            // Construindo a URL de dados
            var imageDataUrl = $"data:image/PNG;base64,{imagemBase64}";
            return imageDataUrl;
        }
        public static string ByteToPdfString(byte[] ficheiro)
        {
            // Convertendo os bytes do PDF para base64
            string pdfBase64 = Convert.ToBase64String(ficheiro);
            // Construindo a URL de dados
            var pdfDataUrl = $"data:application/pdf;base64,{pdfBase64}";
            return pdfDataUrl;
        }
       
    }
}
