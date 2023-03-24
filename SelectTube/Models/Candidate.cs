namespace SelectTube.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LinkedinUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public CandidateStatus Status { get; set; }
        public List<CandidateDocument>? Documents { get; set; }
    }

    public enum CandidateStatus
    {
        InProcess,
        Discarded,
        Selected
    }

    public class CandidateDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}



