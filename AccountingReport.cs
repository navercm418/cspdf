using System;
using System.IO;
using System.Text;

class AccountingReport
{
    static void Main()
    {
        // Specify the output PDF file and the company logo path
        string pdfFilePath = "AccountingReport.pdf";
        string companyLogoPath = "company_logo.jpg";

        // Generate the PDF
        CreatePDF(pdfFilePath, companyLogoPath);
        Console.WriteLine("PDF generated successfully: " + pdfFilePath);
    }

    static void CreatePDF(string pdfPath, string imagePath)
    {
        // Open a file stream to create the PDF
        using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
        using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
        {
            // ====== PDF Header ======
            writer.WriteLine("%PDF-1.4");

            // ====== Define main objects ======
            writer.WriteLine("1 0 obj"); 
            writer.WriteLine("<< /Type /Catalog /Pages 2 0 R >>"); 
            writer.WriteLine("endobj");

            writer.WriteLine("2 0 obj"); 
            writer.WriteLine("<< /Type /Pages /Kids [3 0 R] /Count 1 >>"); 
            writer.WriteLine("endobj");

            // ====== Define Page ======
            writer.WriteLine("3 0 obj");
            writer.WriteLine("<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792]"); 
            writer.WriteLine("/Resources << /XObject << /Img1 5 0 R >> >> /Contents 4 0 R >>");
            writer.WriteLine(">>"); 
            writer.WriteLine("endobj");

            // ====== Page Contents: Logo, Report Title, Table ======
            writer.WriteLine("4 0 obj"); 
            writer.WriteLine("<< /Length 500 >>"); 
            writer.WriteLine("stream");

            // ---- Draw the company logo ----
            writer.WriteLine("q"); 
            writer.WriteLine("100 0 0 50 10 742 cm"); // Positioned at top-left (10px border)
            writer.WriteLine("/Img1 Do"); 
            writer.WriteLine("Q");

            // ---- Centered report title ----
            writer.WriteLine("BT /F1 16 Tf 200 720 Td (Accounting Report - Q1 2025) Tj ET");

            // ---- Draw table header ----
            writer.WriteLine("q");
            writer.WriteLine("0 0 0 rg"); // Set color to black
            writer.WriteLine("0.5 w"); // Set line thickness
            writer.WriteLine("100 600 400 20 re S"); // Draw header row
            writer.WriteLine("Q");

            // ---- Column titles ----
            string[] columnHeaders = { "ID", "Date", "Client", "Description", "Debit", "Credit", "Balance", "Tax", "Discount", "Net", "Approval", "Notes" };
            int xPos = 110; // Starting X position for columns

            writer.WriteLine("BT /F1 12 Tf");
            foreach (var header in columnHeaders)
            {
                writer.WriteLine($"{xPos} 605 Td ({header}) Tj");
                xPos += 35; // Move to next column
            }
            writer.WriteLine("ET");

            // ---- Draw table rows (Example Data) ----
            for (int row = 0; row < 10; row++) // Simulate 10 rows of data
            {
                writer.WriteLine("q");
                writer.WriteLine($"100 {580 - (row * 20)} 400 20 re S"); // Row positioning
                writer.WriteLine("Q");
            }

            // ---- Totals Row ----
            writer.WriteLine("q");
            writer.WriteLine("0 0 0 rg"); // Set black color
            writer.WriteLine("0.5 w"); // Line thickness
            writer.WriteLine("100 380 400 20 re S"); // Draw totals row
            writer.WriteLine("Q");

            writer.WriteLine("BT /F1 12 Tf 110 385 Td (Total Amount) Tj ET");

            writer.WriteLine("endstream");
            writer.WriteLine("endobj");

            // ====== Embed Company Logo ======
            byte[] imageData = File.ReadAllBytes(imagePath);
            writer.WriteLine($"5 0 obj");
            writer.WriteLine($"<< /Type /XObject /Subtype /Image /Width 100 /Height 50 /ColorSpace /DeviceRGB /BitsPerComponent 8 /Filter /DCTDecode /Length {imageData.Length} >>");
            writer.WriteLine("stream");
            fs.Write(imageData, 0, imageData.Length);
            writer.WriteLine("\nendstream");
            writer.WriteLine("endobj");

            // ====== Cross-reference table ======
            writer.WriteLine("xref");
            writer.WriteLine("0 6");
            writer.WriteLine("0000000000 65535 f");
            writer.WriteLine("0000000010 00000 n");
            writer.WriteLine("0000000050 00000 n");
            writer.WriteLine("0000000100 00000 n");
            writer.WriteLine("0000000150 00000 n");
            writer.WriteLine("0000000200 00000 n");

            // ====== PDF Trailer ======
            writer.WriteLine("trailer");
            writer.WriteLine("<< /Size 6 /Root 1 0 R >>");
            writer.WriteLine("startxref");
            writer.WriteLine("300");
            writer.WriteLine("%%EOF");
        }
    }
}
