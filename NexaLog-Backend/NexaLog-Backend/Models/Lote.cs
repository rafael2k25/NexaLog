namespace NexaLog_Backend.Models
{
	public class Lote
	{
		public int IdLot { get; set; }
		public int QuantidadeLote { get; set; }

		public string CodLote { get; set; } = string.Empty;

		public DateTime DataValidade { get; set; }
		public DateTime DataFabricacao { get; set; }

		public int FkProdutoIdProduto { get; set; }
	}
}