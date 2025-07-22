namespace GeradorDeTestes.Dominio.ModuloQuestao;
public class Alternativa
{
    public Guid Id { get; set; }
    public string Descricao { get; set; }
    public Questao Questao { get; set; }
    public bool Correta { get; set; }

    public Alternativa(string descricao, Questao questao)
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
        Questao = questao;
    }
}
