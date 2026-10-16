namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho phiếu đăng ký tham gia sự kiện của thành viên.
/// </summary>
public class Registration
{
    public const string StatusPending = "Pending";
    public const string StatusConfirmed = "Confirmed";
    public const string StatusCancelled = "Cancelled";

    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public Guid EventId { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public string Status { get; private set; }

    private Registration(Guid id, Guid memberId, Guid eventId, DateTime registeredAt, string status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Factory method tạo phiếu đăng ký mới.
    /// </summary>
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty) throw new ArgumentException("MemberId không hợp lệ.", nameof(memberId));
        if (eventId == Guid.Empty) throw new ArgumentException("EventId không hợp lệ.", nameof(eventId));

        return new Registration(Guid.NewGuid(), memberId, eventId, DateTime.UtcNow, StatusPending);
    }

    /// <summary>
    /// Xác nhận phiếu đăng ký.
    /// </summary>
    public void Confirm()
    {
        if (Status == StatusCancelled)
            throw new InvalidOperationException("Không thể xác nhận phiếu đăng ký đã bị huỷ.");
        Status = StatusConfirmed;
    }

    /// <summary>
    /// Huỷ phiếu đăng ký.
    /// </summary>
    public void Cancel()
    {
        Status = StatusCancelled;
    }
}