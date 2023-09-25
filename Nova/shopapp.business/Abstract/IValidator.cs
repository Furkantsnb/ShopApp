namespace shopapp.business.Abstract
{
    //Generic yapılanmasını kullandım
    public interface IValidator<T>
    {
        string ErrorMessage { get; set; }
        bool Validation(T entity);
    }
}
