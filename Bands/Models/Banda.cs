namespace Bands.Models;

public class Banda
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Album { get; set; }
    public List<string> Faixas { get; set; }
    public List<string> Tipo { get; set; } = [];
    public string Imagem { get; set; }
}
