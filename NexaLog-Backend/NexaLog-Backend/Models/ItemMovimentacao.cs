namespace NexaLog_Backend.Models
{
	public class ItemMovimentacao
	{
		public int FkProdutoIdProduto { get; set; }

		public int FkMovimentacaoIdMovimentacao { get; set; }

		public decimal Quantidade { get; set; }
	}
}