using System;
using System.Collections.Generic;
using System.Text;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace OrderService.Infrastructure.Services;

public class InvoiceService : IInvoiceService
{
    public Task<byte[]> GeneratePdfAsync(Order order)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Header().Element(ComposeHeader);
                page.Content().Element(content => ComposeContent(content, order));
                page.Footer().AlignCenter().Text(t =>
                {
                    t.Span("Page "); t.CurrentPageNumber(); t.Span(" of "); t.TotalPages();
                });
            });
        });

        return Task.FromResult(pdf.GeneratePdf());
    }

    private void ComposeHeader(IContainer container)
    {
        container.Row(row =>
        {
            row.RelativeItem().Column(col =>
            {
                col.Item().Text("E-Commerce Platform").FontSize(20).Bold().FontColor(Colors.Blue.Medium);
                col.Item().Text("INVOICE").FontSize(14).FontColor(Colors.Grey.Darken2);
            });
        });
    }

    private void ComposeContent(IContainer container, Order order)
    {
        container.PaddingVertical(10).Column(col =>
        {
            col.Spacing(10);

            // Order Info
            col.Item().Row(row =>
            {
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text($"Invoice #: {order.TrackingId}").Bold();
                    c.Item().Text($"Date: {order.CreatedAt:dd MMM yyyy}");
                    c.Item().Text($"Status: {order.Status}");
                });
                row.RelativeItem().Column(c =>
                {
                    c.Item().Text("Bill To:").Bold();
                    c.Item().Text(order.CustomerName);
                    c.Item().Text(order.CustomerEmail);
                    c.Item().Text($"{order.BillingAddress}, {order.BillingCity}");
                    c.Item().Text($"{order.BillingState} - {order.BillingPinCode}");
                });
            });

            // Items Table
            col.Item().Table(table =>
            {
                table.ColumnsDefinition(cols =>
                {
                    cols.RelativeColumn(3);
                    cols.RelativeColumn();
                    cols.RelativeColumn();
                    cols.RelativeColumn();
                });

                // Header
                table.Header(header =>
                {
                    header.Cell().Background(Colors.Blue.Medium).Padding(5).Text("Product").FontColor(Colors.White).Bold();
                    header.Cell().Background(Colors.Blue.Medium).Padding(5).AlignCenter().Text("Qty").FontColor(Colors.White).Bold();
                    header.Cell().Background(Colors.Blue.Medium).Padding(5).AlignRight().Text("Unit Price").FontColor(Colors.White).Bold();
                    header.Cell().Background(Colors.Blue.Medium).Padding(5).AlignRight().Text("Subtotal").FontColor(Colors.White).Bold();
                });

                // Rows
                foreach (var item in order.Items)
                {
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.ProductName);
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignCenter().Text(item.Quantity.ToString());
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"₹{item.UnitPrice:F2}");
                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"₹{item.SubTotal:F2}");
                }
            });

            // Total
            col.Item().AlignRight().Text($"Total: ₹{order.TotalAmount:F2}").FontSize(14).Bold();
        });
    }
}
