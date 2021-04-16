namespace AcessoConta.Api.Conta.Domain.Transferencia.ReadModel
{
    public class TrasnferenciaErroReadModel
    {
        public TrasnferenciaErroReadModel()
        { }

        public int Id { get;  set; }
        public string IdTransferencia { get;  set; }
        public string DescricaoErro { get;  set; }       
    }
}