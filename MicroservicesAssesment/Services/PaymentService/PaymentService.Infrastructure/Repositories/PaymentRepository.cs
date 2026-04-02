using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;
using PaymentService.Domain.Interfaces;
using PaymentService.Infrastructure.Data;

namespace PaymentService.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDbContext _db;
    public PaymentRepository(PaymentDbContext db) => _db = db;

    public async Task<Payment?> GetByIdAsync(Guid id) =>
        await _db.Payments.FindAsync(id);

    public async Task<Payment?> GetByOrderIdAsync(Guid orderId) =>
        await _db.Payments.FirstOrDefaultAsync(p => p.OrderId == orderId);

    public async Task<IEnumerable<Payment>> GetByUserIdAsync(string userId) =>
        await _db.Payments.Where(p => p.UserId == userId).OrderByDescending(p => p.CreatedAt).ToListAsync();

    public async Task<Payment> CreateAsync(Payment payment)
    {
        _db.Payments.Add(payment);
        await _db.SaveChangesAsync();
        return payment;
    }

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        _db.Payments.Update(payment);
        await _db.SaveChangesAsync();
        return payment;
    }
}
