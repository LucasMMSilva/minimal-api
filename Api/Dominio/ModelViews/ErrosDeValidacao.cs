namespace MinimalApi.Dominio.ModelViews;

public struct ErrosDeValidacao
{
    private object value;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public ErrosDeValidacao(object value) : this()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        this.value = value;
    }

    public List<string> Mensagens { get; set; }
}