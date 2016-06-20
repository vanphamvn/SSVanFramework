using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSVan.General_Functions
{
    public static class PDFHelper
    {
        /// <summary>
        /// Get text in a PDF file
        /// </summary>
        /// <param name="Filepath">The PDF file path</param>
        /// <returns>The text in the PDF file</returns>
        public static string GetPDFFileContent(string Filepath)
        {
            PdfReader reader = new PdfReader(Filepath);
            string text = PdfTextExtractor.GetTextFromPage(reader, 1);
            try { reader.Close(); }
            catch { }
            return text.Replace("\r\n", " ");
        }
    }
}
