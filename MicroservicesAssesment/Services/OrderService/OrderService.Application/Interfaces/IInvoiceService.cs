using System;
using System.Collections.Generic;
using System.Text;
using OrderService.Domain.Entities;

namespace OrderService.Application.Interfaces;

public interface IInvoiceService
{
    Task<byte[]> GeneratePdfAsync(Order order);
}
