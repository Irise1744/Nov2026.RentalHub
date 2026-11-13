namespace Nov2026.Mvc.Models
{
    public class OwnersCreateRequestMmodel
    {
        public int OwnerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class OwnersUpsertRequestMmodel
    {
        public int OwnerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class OwnersUpdateRequestMmodel
    {

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

