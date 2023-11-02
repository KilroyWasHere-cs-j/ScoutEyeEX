using SE.Model;
using System.Collections.ObjectModel;

namespace SE.ViewModel
{
    public class DataViewModel
    {
        public ObservableCollection<DataModel> SocialMedia { get; set; }
        public DataViewModel()
        {
            SocialMedia = new ObservableCollection<DataModel>
            {
                new DataModel { Name = "Facebook", ID = "Facebook" },
                new DataModel { Name = "Twitter", ID = "Twitter" },
                new DataModel { Name = "Instagram", ID = "Instagram" },
                new DataModel { Name = "LinkedIn", ID = "LinkedIn" },
                new DataModel { Name = "YouTube", ID = "YouTube" },
                new DataModel { Name = "Pinterest", ID = "Pinterest" },
            };
        }
    }
}
