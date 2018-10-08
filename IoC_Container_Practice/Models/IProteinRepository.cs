using System;

namespace IoC_Container_Practice.Models
{
    public interface IProteinRepository
    {
        Protein GetData(DateTime date);
        void SetGoal(DateTime date, int value);
        void SetTotal(DateTime date, int value);
    }
}