//itextsharp nugget

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace UCABPagaloTodoMS.Infrastructure.services;

public class GenerarPDF
{

    public void GenerarDocumento()
    {
        FileStream fs = new FileStream(@"Ruta del documento (ej: C:\Users\Usuario\Documents\PDFGenerado.pdf)", FileMode.Create);
        Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7); //Tipo de hoja "Carta" , margenes 5,5,7,7
        PdfWriter pw = PdfWriter.GetInstance(doc, fs);

        doc.Open();

        //Titulo y autor
        doc.AddAuthor("UCABPagaloTodo");
        doc.AddTitle("PDF Generado");

        //Fuente del doc
        Font standarFont = new iTextSharp.text.Font(Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

        //Encabezado
        doc.Add(new Paragraph("Titulo del documento"));
        doc.Add(Chunk.NEWLINE); //Agg una linea al doc

        //Encabezado de columnas
        PdfPTable tblEjemplo = new PdfPTable(2);
        tblEjemplo.WidthPercentage = 100;

        //Titulos de las columnas
        PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
        clNombre.BorderWidth = 0;
        clNombre.BorderWidthBottom = 0.75f;

        //Titulos de las columnas
        PdfPCell clInformacion = new PdfPCell(new Phrase("Informacion", standarFont));
        clInformacion.BorderWidth = 0;
        clInformacion.BorderWidthBottom = 0.75f;

        //Agregarlas a la tabla
        tblEjemplo.AddCell(clNombre);
        tblEjemplo.AddCell(clInformacion)

        //Agregando Datos
        /*
        foreach (var consumidor in lista)
        {
            clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
            clNombre.BorderWidth = 0;

            PdfPCell clInformacion = new PdfPCell(new Phrase("Informacion", standarFont));
            clInformacion.BorderWidth = 0;

            tblEjemplo.AddCell(clNombre);
            tblEjemplo.AddCell(clInformacion);

        }
        */

        //Agregarlas a documento
        doc.Add(tblEjemplo);

        doc.Close();
        pw.Close();

    }
}
