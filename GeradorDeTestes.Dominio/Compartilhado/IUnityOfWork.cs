namespace GeradorDeTestes.Dominio.Compartilhado;

public interface IUnityOfWork
{
    public void Commit();
    public void RollBack();
}
