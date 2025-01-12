namespace KhakasKosmetika.API.Responses
{
    public record CategoryResponseOld
    (
        string id,
        string name,
        int depth,
        List<CategoryResponseOld> subcats
    );
}
