using LawyerWebSite.Core.Entities;

namespace LawyerWebSite.Entities.Concrete.DTOs
{
    public class WorkAreaListDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string CategoryName { get; set; }
    }
}
