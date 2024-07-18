namespace Presentation.Interfaces
{
    public interface IRolePropertyEntryManager
    {
        /*   public string ChooseRole();*/
        public string GetDescription();
        public Task<string> ChooseDepartment();
        public Task<string> ChooseLocation();

    }
}
