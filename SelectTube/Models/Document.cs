namespace SelectTube.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }

    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int CandidateId { get; set; }
        public int ProcessId { get; set; }
    }
}

