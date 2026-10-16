# EduHub - Quản lý Câu lạc bộ & Sự kiện sinh viên
Bài tập môn Phát triển phần mềm hướng đối tượng (IN4211)

# Mô tả thiết kế Domain
Hệ thống gồm 5 domain class chính:
- Member: Quản lý thông tin sinh viên tham gia CLB.
- Club: Quản lý thông tin CLB và danh sách thành viên.
- Event: Quản lý các sự kiện do CLB tổ chức kèm theo sức chứa (Capacity).
- Registration: Quản lý phiếu đăng ký tham gia sự kiện của thành viên với các trạng thái (Pending, Confirmed, Cancelled).
- CheckIn: Ghi nhận thời gian điểm danh thực tế khi thành viên tham gia sự kiện.

# Cách chạy ứng dụng
- Đảm bảo máy tính đã cài đặt .NET 10 SDK. 
- Mở terminal tại thư mục dự án và chạy lệnh: dotnet run