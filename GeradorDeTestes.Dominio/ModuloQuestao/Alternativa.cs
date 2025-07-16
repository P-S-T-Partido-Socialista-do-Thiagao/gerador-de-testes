namespace GeradorDeTestes.Dominio.ModuloQuestao;
public class Alternativa
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public bool Correta { get; set; }

    public Alternativa(string descricao, bool correta)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        Correta = correta;
    }
}
