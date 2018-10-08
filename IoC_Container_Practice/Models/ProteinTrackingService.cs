using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoC_Container_Practice.Models
{
    public class ProteinTrackingService : IProteinTrackingService
    {
        private IProteinRepository repo;

        public ProteinTrackingService(IProteinRepository repo)
        {
            this.repo = repo;
        }

        public int Total
        {
            get { return repo.GetData(new DateTime().Date).Total; }
            set { repo.SetTotal(new DateTime().Date, value); }
        }

        public int Goal
        {
            get { return repo.GetData(new DateTime().Date).Goal; }
            set { repo.SetGoal(new DateTime().Date, value); }
        }

        public void AddProtein(int amount)
        {
            Total += amount;
        }
    }
}