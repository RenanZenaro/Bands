namespace Bands.Models

public class DetailsVM
{
    public Banda Anterior { get; set; }
    public Banda Atual { get; set; }
    public Banda Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}
