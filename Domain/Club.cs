namespace EduHub.Ch01.Domain;

/// <summary>
/// Đại diện cho Câu lạc bộ sinh viên.
/// </summary>
public class Club
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public List<Member> Members { get; private set; }

    private Club(Guid id, string name, string description, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Members = new List<Member>();
    }

    /// <summary>
    /// Factory method khởi tạo CLB mới.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống.", nameof(name));

        return new Club(Guid.NewGuid(), name.Trim(), description?.Trim() ?? string.Empty, DateTime.UtcNow);
    }

    /// <summary>
    /// Thêm một thành viên vào câu lạc bộ.
    /// </summary>
    public void AddMember(Member member)
    {
        ArgumentNullException.ThrowIfNull(member);
        if (!Members.Any(m => m.Id == member.Id))
        {
            Members.Add(member);
        }
    }

    /// <summary>
    /// Trả về tổng số lượng thành viên hiện tại của CLB.
    /// </summary>
    public int MemberCount() => Members.Count;
}