using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KhakasKosmetika.API.Responses
{
    public record ProductResponce
    (
        string id,
        string name,
        string price,
        string description,
        string imageUrl,
        int amountOfImages,
        bool isFavourite,
        bool isInBasket,
        int amountInBasket
    );
}
