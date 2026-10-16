using EduHub.Ch01.Domain;
namespace EduHub.Ch01;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==================================================");
        Console.WriteLine("          CHƯƠNG TRÌNH DEMO EDUHUB        ");
        Console.WriteLine("==================================================\n");

        try
        {
            // Bước 1: Tạo Câu lạc bộ
            Console.WriteLine("--- BƯỚC 1: TẠO CÂU LẠC BỘ ---");
            var techClub = Club.Create("Tech Club", "Câu lạc bộ Công nghệ thông tin Đại học Đồng Tháp");
            Console.WriteLine($"[Thành công] Đã tạo CLB: {techClub.Name} - Mô tả: {techClub.Description}");
            Console.WriteLine(new string('-', 50));

            // Bước 2: Thêm 3 thành viên vào CLB
            Console.WriteLine("\n--- BƯỚC 2: THÊM THÀNH VIÊN VÀO CLB ---");
            var m1 = Member.Create("Nguyễn Văn An", "an.nv@dthu.edu.vn", "0024412345");
            var m2 = Member.Create("Trần Thị Bình", "binh.tt@dthu.edu.vn", "0024413456");
            var m3 = Member.Create("Lê Hoàng Cường", "cuong.lh@dthu.edu.vn", "0024413456");

            techClub.AddMember(m1);
            techClub.AddMember(m2);
            techClub.AddMember(m3);

            Console.WriteLine($"- Đã thêm thành viên: {m1.Name} ({m1.StudentCode})");
            Console.WriteLine($"- Đã thêm thành viên: {m2.Name} ({m2.StudentCode})");
            Console.WriteLine($"- Đã thêm thành viên: {m3.Name} ({m3.StudentCode})");
            Console.WriteLine($"=> Tổng số thành viên hiện tại của CLB: {techClub.MemberCount()}");
            Console.WriteLine(new string('-', 50));

            // Bước 3: Tạo sự kiện cho CLB
            Console.WriteLine("\n--- BƯỚC 3: TẠO SỰ KIỆN ---");
            var aiWorkshop = Event.Create(techClub.Id, "Workshop Trí tuệ nhân tạo (AI)", DateTime.Now.AddDays(7), 50, true);
            Console.WriteLine($"[Thành công] Đã tạo sự kiện: {aiWorkshop.Title}");
            Console.WriteLine($"- Ngày tổ chức: {aiWorkshop.Date:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"- Sức chứa (Capacity): {aiWorkshop.Capacity}");
            Console.WriteLine(new string('-', 50));

            // Bước 4: Đăng ký tham gia sự kiện và Xác nhận (Confirm)
            Console.WriteLine("\n--- BƯỚC 4: ĐĂNG KÝ VÀ XÁC NHẬN THAM GIA ---");
            var reg1 = Registration.Create(m1.Id, aiWorkshop.Id);
            var reg2 = Registration.Create(m2.Id, aiWorkshop.Id);

            Console.WriteLine($"- {m1.Name} đã đăng ký. Trạng thái ban đầu: {reg1.Status}");
            Console.WriteLine($"- {m2.Name} đã đăng ký. Trạng thái ban đầu: {reg2.Status}");

            // Xác nhận phiếu đăng ký
            reg1.Confirm();
            reg2.Confirm();
            Console.WriteLine($"=> Sau khi gọi Confirm():");
            Console.WriteLine($"  + Phiếu của {m1.Name}: {reg1.Status}");
            Console.WriteLine($"  + Phiếu của {m2.Name}: {reg2.Status}");
            Console.WriteLine(new string('-', 50));

            // Bước 5: Thực hiện Check-in
            Console.WriteLine("\n--- BƯỚC 5: ĐIỂM DANH (CHECK-IN) ---");
            var checkIn1 = CheckIn.Create(reg1.Id, "Đến đúng giờ");
            Console.WriteLine($"[Thành công] {m1.Name} đã check-in.");
            Console.WriteLine(checkIn1.Summary());
            Console.WriteLine(new string('-', 50));

            // Bước 6: In báo cáo tham dự tổng kết
            Console.WriteLine("\n--- BƯỚC 6: BÁO CÁO TỔNG KẾT SỰ KIỆN ---");
            int totalRegistered = 2; // m1 và m2
            int totalCheckedIn = 1;  // m1 check-in
            Console.WriteLine($"Tên Sự Kiện: {aiWorkshop.Title}");
            Console.WriteLine($"- Tổng số lượng đăng ký : {totalRegistered}");
            Console.WriteLine($"- Tổng số lượng check-in : {totalCheckedIn}");
            Console.WriteLine($"- Danh sách tham gia chính thức:");
            Console.WriteLine($"  1. {m1.Name} ({m1.StudentCode}) - Trạng thái: Đã Check-in");
            Console.WriteLine($"  2. {m2.Name} ({m2.StudentCode}) - Trạng thái: Đã Xác nhận (Chưa check-in)");
            Console.WriteLine(new string('-', 50));

            // Bước 7: Thử nghiệm vi phạm luật nghiệp vụ
            Console.WriteLine("\n--- BƯỚC 7: KIỂM TRA NGOẠI LỆ (LUẬT NGHIỆP VỤ) ---");
            var reg3 = Registration.Create(m3.Id, aiWorkshop.Id);
            reg3.Cancel();
            Console.WriteLine($"- {m3.Name} đã huỷ phiếu đăng ký. Trạng thái: {reg3.Status}");
            Console.WriteLine("- Cố gắng gọi Confirm() trên phiếu đã huỷ...");

            reg3.Confirm(); // Sẽ văng ngoại lệ InvalidOperationException ở đây
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"[Bắt ngoại lệ thành công]: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Lỗi không mong muốn]: {ex.Message}");
        }

        Console.WriteLine("\n==================================================");
        Console.WriteLine("          KẾT THÚC CHƯƠNG TRÌNH DEMO              ");
        Console.WriteLine("==================================================");
    }
}