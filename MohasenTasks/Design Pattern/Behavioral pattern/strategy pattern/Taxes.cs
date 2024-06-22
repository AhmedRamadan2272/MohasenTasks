using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohasenTasks.Design_Pattern.Behavioral_pattern.strategy_pattern
{
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Profit { get; set; }
    }

    interface ITaxEngine
    {
        decimal CalculateTax(Company company);
    }

    class TaxStartupCompany : ITaxEngine
    {
        public decimal CalculateTax(Company company)
        {
            return company.Profit * 0.10m; // 10% tax rate
        }
    }

    class MediumCompany : ITaxEngine
    {
        public decimal CalculateTax(Company company)
        {
            return company.Profit * 0.20m; // 20% tax rate
        }
    }

    class Context
    {
        private ITaxEngine taxEngine;
        private Company company;

        public Context(ITaxEngine taxEngine, Company company)
        {
            this.taxEngine = taxEngine;
            this.company = company;
        }

        public decimal CalculateTax()
        {
            return taxEngine.CalculateTax(company);
        }
    }

    class Program
    {
        static void Main()
        {
            
            var company1 = new Company
            {
                Id = 1,
                Name = "شركه المرعبين المحدوده",
                Profit = 20000 // 20,000
            };

            Context context1 = new Context(new TaxStartupCompany(), company1);
            Console.WriteLine($"Tax for {company1.Name} equals {context1.CalculateTax()}");

            var company2 = new Company
            {
                Id = 2,
                Name = "شركه الفلسطينه لاباده القوارض",
                Profit = 1000000 // 1,000,000
            };

            Context context2 = new Context(new MediumCompany(), company2);
            Console.WriteLine($"Tax for {company2.Name} equals {context2.CalculateTax()}");
        }
    }
    
}
