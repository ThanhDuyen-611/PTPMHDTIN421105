# Sơ đồ lớp sơ bộ (Class Diagram) - EduHub
Sơ đồ thể hiện cấu trúc các domain classes và mối quan hệ giữa chúng trong hệ thống quản lý CLB EduHub.

```mermaid
classDiagram
    class Club {
        +Guid Id
        +string Name
        +string Description
        +DateTime CreatedAt
        +List~Member~ Members
        +Void AddMember(Member member)
        +Int MemberCount()
    }

    class Member {
        +Guid Id
        +string Name
        +string Email
        +string StudentCode
        +DateTime JoinedAt
        +Bool IsActive()
    }

    class Event {
        +Guid Id
        +Guid ClubId
        +string Title
        +DateTime Date
        +int Capacity
        +bool IsOnline
        +Bool HasCapacity(int registeredCount)
    }

    class Registration {
        +Guid Id
        +Guid MemberId
        +Guid EventId
        +DateTime RegisteredAt
        +string Status
        +Void Confirm()
        +Void Cancel()
    }

    class CheckIn {
        +Guid Id
        +Guid RegistrationId
        +DateTime CheckedInAt
        +string Note
        +String Summary()
    }

    Club "1" --> "*" Member : sở hữu / có
    Club "1" --> "*" Event : tổ chức
    Member "1" --> "*" Registration : thực hiện
    Event "1" --> "*" Registration : nhận
    Registration "1" --> "0..1" CheckIn : ghi nhận điểm danh