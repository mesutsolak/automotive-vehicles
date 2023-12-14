namespace AutomotiveBrands.Client.Models.Response.AutomotiveBrands
{
    public sealed record BaseAutomotiveBrandsResponse<T>
    {
        public bool Succeeded { get; init; }
        public T Data { get; init; }
        public List<string> Errors { get; init; }
    }
}
