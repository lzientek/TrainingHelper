using System.Windows.Navigation;

namespace TrainingHelper.PcClient
{
    public static class ApplicationHelper
    {
        private static NavigationService navigator;

        public static NavigationService NavigationService
        {
            set
            {
                navigator = value;
            }
            get
            {
                return navigator;
            }

        }

    }
}