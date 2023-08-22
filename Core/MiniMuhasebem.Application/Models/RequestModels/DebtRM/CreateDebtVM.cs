namespace MiniMuhasebem.Application.Models.RequestModels.DebtRM
{
    public class CreateDebtVM
    {
        public int? WholesalerId { get; set; }
        public decimal OrderDebt { get; set; }
    }
}
