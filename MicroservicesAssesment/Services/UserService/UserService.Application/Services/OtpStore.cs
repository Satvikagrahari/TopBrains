
using UserService.Domain.Entities;

namespace UserService.Application.Services;

public class OtpStore
{
    private readonly List<OtpRecord> _records = new();

    public void Add(OtpRecord record) => _records.Add(record);

    public void RemoveAll(Predicate<OtpRecord> match) => _records.RemoveAll(match);

    public OtpRecord? Find(string userId, string otpCode, string purpose) =>
        _records.FirstOrDefault(o =>
            o.UserId == userId &&
            o.OtpCode == otpCode &&
            o.Purpose == purpose &&
            !o.IsUsed &&
            o.ExpiresAt > DateTime.UtcNow);
}