namespace RevitRibbon.API.GQLControllers
{
    public struct InvalidId
    {
        public InvalidId(int id, string message)
        {
            Id = id;
            Message = message;
        }

        public int Id { get; set; }
        public string Message { get; set; }
    }
}