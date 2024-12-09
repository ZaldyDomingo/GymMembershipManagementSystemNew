using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembershipManagementSystem
{
    public class InvoiceGenerator
    {
        public static void GenerateInvoice(
            string firstName,
            string lastName,
            string address,
            string mobileNumber,
            decimal membershipFee,
            DateTime startDate,
            DateTime endDate,
            string savePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(savePath) || !Directory.Exists(Path.GetDirectoryName(savePath)))
                    throw new ArgumentException("Invalid save path specified.");

                // Create a new PDF document
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "C.H.C Gym Invoice";

                // Add a page
                PdfPage page = pdf.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Fonts
                XFont titleFont = new XFont("Arial", 20);
                XFont headerFont = new XFont("Arial", 14);
                XFont contentFont = new XFont("Arial", 12);
                XFont noteFont = new XFont("Arial", 10);

                // Gym Header
                gfx.DrawString("C.H.C Gym – Challenge Health Club Alaminos", headerFont, XBrushes.Black, new XPoint(50, 40));
                gfx.DrawString("Invoice", headerFont, XBrushes.Black, new XPoint(445, 40));
                gfx.DrawString("Fitness Gym Center", headerFont, XBrushes.Black, new XPoint(50, 60));
                gfx.DrawString("3rd Floor Nicanor (Montemayor) Building", contentFont, XBrushes.Black, new XPoint(50, 100));
                gfx.DrawString("Marcos Ave. Palamis Alaminos City.", contentFont, XBrushes.Black, new XPoint(50, 120));
                gfx.DrawString("Phone: 096-369-2697", contentFont, XBrushes.Black, new XPoint(50, 140));

                // Date
                gfx.DrawString($"Date: {startDate:yyyy-MM-dd}", contentFont, XBrushes.Black,new XPoint(page.Width.Point - 150, XUnit.FromPoint(60)));

                // Customer Information
                gfx.DrawString("For:", headerFont, XBrushes.Black, new XPoint(50, 180));
                gfx.DrawString($"{firstName} {lastName}", contentFont, XBrushes.Black, new XPoint(80, 180));
                gfx.DrawString(address, contentFont, XBrushes.Black, new XPoint(80, 200));
                gfx.DrawString(mobileNumber, contentFont, XBrushes.Black, new XPoint(80, 220));

                // Invoice Details Table
                gfx.DrawString("Description", headerFont, XBrushes.Black, new XPoint(50, 260));
                gfx.DrawString("Month", headerFont, XBrushes.Black, new XPoint(300, 260));
                gfx.DrawString("Amount", headerFont, XBrushes.Black, new XPoint(445, 260));

                gfx.DrawString("Gym Membership", contentFont, XBrushes.Black, new XPoint(50, 280));
                gfx.DrawString("1", contentFont, XBrushes.Black, new XPoint(300, 280));
                gfx.DrawString($"{membershipFee:C}", contentFont, XBrushes.Black, new XPoint(445, 280));

                // Summary
                gfx.DrawString("Total Membership transaction:", headerFont, XBrushes.Black, new XPoint(50, 320));
                gfx.DrawString($"Membership Fee: {membershipFee:C}", contentFont, XBrushes.Black, new XPoint(50, 340));
                gfx.DrawString($"Start date: {startDate:yyyy-MM-dd}", contentFont, XBrushes.Black, new XPoint(50, 360));
                gfx.DrawString($"End date: {endDate:yyyy-MM-dd}", contentFont, XBrushes.Black, new XPoint(50, 380));

                // Signature
                gfx.DrawString("__________________________", contentFont, XBrushes.Black, new XPoint(50, 420));
                gfx.DrawString("Signature over printed name", noteFont, XBrushes.Gray, new XPoint(50, 440));

                // Notes
                gfx.DrawString("Notes:", headerFont, XBrushes.Black, new XPoint(50, 480));
                gfx.DrawString("________________________________________________________________", headerFont, XBrushes.Black, new XPoint(50, 500));
                gfx.DrawString("Thank you for choosing our gym for your fitness needs!", noteFont, XBrushes.Black, new XPoint(50, 540));
                gfx.DrawString("From: C.H.C Gym – Challenge Health Club Alaminos", noteFont, XBrushes.Black, new XPoint(315, 570));

                // Save the PDF
                pdf.Save(savePath);
                pdf.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to generate invoice: {ex.Message}");
            }
        }
    }
}
