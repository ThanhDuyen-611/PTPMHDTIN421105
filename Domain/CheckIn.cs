namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho bản ghi điểm danh khi thành viên tham gia sự kiện.
/// </summary>
public class CheckIn
{
    public Guid Id { get; private set; }
    public Guid RegistrationId { get; private set; }
    public DateTime CheckedInAt { get; private set; }
    public string Note { get; private set; }

    private CheckIn(Guid id, Guid registrationId, DateTime checkedInAt, string note)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Note = note;
    }

    /// <summary>
    /// Factory method tạo bản ghi check-in mới.
    /// </summary>
    public static CheckIn Create(Guid registrationId, string note = "On-time")
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException("RegistrationId không hợp lệ.", nameof(registrationId));

        return new CheckIn(Guid.NewGuid(), registrationId, DateTime.UtcNow, note ?? string.Empty);
    }

    /// <summary>
    /// Trả về chuỗi mô tả tóm tắt thông tin check-in.
    /// </summary>
    public string Summary()
    {
        return $"CheckIn ID: {Id} | Registration: {RegistrationId} | Time: {CheckedInAt:yyyy-MM-dd HH:mm:ss} | Note: {Note}";
    }
}