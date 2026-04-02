using System;
using System.Collections.Generic;
using System.Text;
using PaymentService.Domain.Entities;

namespace PaymentService.Domain.Interfaces;

public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(Guid id);
    Task<Payment?> GetByOrderIdAsync(Guid orderId);
    Task<IEnumerable<Payment>> GetByUserIdAsync(string userId);
    Task<Payment> CreateAsync(Payment payment);
    Task<Payment> UpdateAsync(Payment payment);
}
