namespace NexaLog_Backend.Models
{
	public class Produto
	{
		public int IdProduto { get; set; }
		public string Nome { get; set; } = string.Empty;
		public DateTime DataCadastro { get; set; }
		public int Quantidade { get; set; }
		public string Descricao { get; set; } = string.Empty;
	}
}