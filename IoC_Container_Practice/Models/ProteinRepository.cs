using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoC_Container_Practice.Models
{
    public class Protein
    {
        public int Total { get; set; }
        public int Goal { get; set; }
        public DateTime Date { get; set; }
    }

    public class ProteinRepository : IProteinRepository
    {
        Protein Proteins = new Protein();
        
        public Protein GetData(DateTime date)
        {
            return Proteins;
        }

        public void SetTotal(DateTime date, int value)
        {
            Proteins.Total = value;
        }

        public void SetGoal(DateTime date, int value)
        {
            Proteins.Goal = value;
        }
    }
}