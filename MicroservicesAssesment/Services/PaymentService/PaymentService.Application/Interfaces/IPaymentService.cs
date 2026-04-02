using System;
using System.Collections.Generic;
using System.Text;
using PaymentService.Application.DTOs;

namespace PaymentService.Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponseDto> InitiatePaymentAsync(string userId, PaymentRequestDto dto);
    Task<bool> VerifyPaymentAsync(string razorpayOrderId, VerifyPaymentDto dto);
    Task<PaymentResponseDto?> GetByOrderIdAsync(Guid orderId);
    Task<IEnumerable<PaymentResponseDto>> GetMyPaymentsAsync(string userId);
}
