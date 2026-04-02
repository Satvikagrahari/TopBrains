using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.SharedKernel.Enums;
using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Domain.Interfaces;

namespace OrderService.Application.Services;

public class OrderAppService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IMapper _mapper;
    private readonly IInvoiceService _invoiceService;

    public OrderAppService(IOrderRepository orderRepo, IMapper mapper, IInvoiceService invoiceService)
    {
        _orderRepo = orderRepo;
        _mapper = mapper;
        _invoiceService = invoiceService;
    }

    public async Task<IEnumerable<OrderDto>> GetMyOrdersAsync(string userId)
    {
        var orders = await _orderRepo.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto?> GetByIdAsync(Guid id)
    {
        var order = await _orderRepo.GetByIdAsync(id);
        return order == null ? null : _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto?> GetByTrackingIdAsync(string trackingId)
    {
        var order = await _orderRepo.GetByTrackingIdAsync(trackingId);
        return order == null ? null : _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrderAsync(string userId, CreateOrderDto dto)
    {
        if (!dto.Items.Any())
            throw new Exception("Order must have at least one item.");

        var order = new Order
        {
            UserId = userId,
            CustomerName = dto.CustomerName,
            CustomerEmail = dto.CustomerEmail,
            CustomerPhone = dto.CustomerPhone,
            BillingAddress = dto.BillingAddress,
            BillingCity = dto.BillingCity,
            BillingState = dto.BillingState,
            BillingPinCode = dto.BillingPinCode,
            Status = OrderStatus.Pending,
            Items = dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity
            }).ToList()
        };

        order.TotalAmount = order.Items.Sum(i => i.SubTotal);
        var created = await _orderRepo.CreateAsync(order);
        return _mapper.Map<OrderDto>(created);
    }

    public async Task<bool> UpdateStatusAsync(Guid id, OrderStatus status) =>
        await _orderRepo.UpdateStatusAsync(id, status);

    public async Task<bool> CancelOrderAsync(Guid id, string userId)
    {
        var order = await _orderRepo.GetByIdAsync(id);
        if (order == null || order.UserId != userId) return false;
        if (order.Status == OrderStatus.Shipped || order.Status == OrderStatus.Delivered)
            throw new Exception("Cannot cancel a shipped or delivered order.");

        return await _orderRepo.UpdateStatusAsync(id, OrderStatus.Cancelled);
    }

    public async Task<byte[]> GenerateInvoiceAsync(Guid id)
    {
        var order = await _orderRepo.GetByIdAsync(id)
            ?? throw new Exception("Order not found.");
        return await _invoiceService.GeneratePdfAsync(order);
    }
}
