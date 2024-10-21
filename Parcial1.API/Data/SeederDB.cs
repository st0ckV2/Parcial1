
using Microsoft.EntityFrameworkCore;
using Parcial1.Shared.Entities;

namespace Parcial1.API.Data
{
    public class SeederDB
    {
        private readonly DataContext dataContext;

        public SeederDB(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckBranchesAsync();
            await CheckAssignmentsAsync();
            await CheckEmployeesAsync();
            await CheckCustomersAsync();
            await CheckSalesAsync();
            await CheckSalesDetailsAsync();
            await CheckSupliersAsync();
            await CheckPurchasesAsync();
            await CheckPurchaseDetailsAsync();
            await CheckProductsAsync();
        }

        //Branches, Assignments & Employes
        private async Task CheckBranchesAsync()
        {
            if (!dataContext.Branches.Any())
            {
                dataContext.Branches.Add(new Branch { Name = "Palenque", Location = "Avenida #13" });
                dataContext.Branches.Add(new Branch { Name = "D'Sofi", Location = "Avenida #21" });
                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckAssignmentsAsync()
        {
            if (!dataContext.Assignments.Any())
            {
                var branch = await dataContext.Branches.FirstOrDefaultAsync(x => x.Name == "Palenque");
                if (branch != null)
                {
                    dataContext.Assignments.Add(new Assignment { branchID = 0, employeeID = 0, startDate = "10/03/2024", endDate = "10/04/2024", Branch = branch });
                    dataContext.Assignments.Add(new Assignment { branchID = 0, employeeID = 1, startDate = "10/04/2024", endDate = "10/05/2024", Branch = branch });
                }
                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckEmployeesAsync()
        {
            if (!dataContext.Employees.Any())
            {
                dataContext.Employees.Add(new Employee { name = "Bruno Mars", position = "Seller", hireDate = "13/02/2024" });
                dataContext.Employees.Add(new Employee { name = "Alex Turner", position = "Seller", hireDate = "04/12/2023" });
                await dataContext.SaveChangesAsync();
            }
        }




        //Customers, Sales & salesDetails
        private async Task CheckCustomersAsync()
        {
            if (!dataContext.Customers.Any())
            {
                dataContext.Customers.Add(new Customer { name = "Juan Pérez", contactInfo = "2221234567" });
                dataContext.Customers.Add(new Customer { name = "Lorenz Flake", contactInfo = "2227654321" });
                dataContext.Customers.Add(new Customer { name = "Tom Cruise", contactInfo = "2221726354" });
                await dataContext.SaveChangesAsync();
            }
        }
        /*private async Task CheckSalesAsync()
        {
            if (!dataContext.Sales.Any())
            {
                var customer = await dataContext.Customers.FirstOrDefaultAsync(x => x.Id == 1);
                if (customer != null)
                {
                    dataContext.Sales.Add(new Sale { customerID = 1, employeeID = 1, date = "12/06/2024", totalAmount = 750 });
                }
            }
        }*/
        private async Task CheckSalesAsync()
        {
            if (!dataContext.Sales.Any())
            {
                dataContext.Sales.Add(new Sale { customerID= 1, employeeID= 1, date="12/06/2024", totalAmount=750 });
                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckSalesDetailsAsync()
        {
            if (!dataContext.SalesDetails.Any())
            {
                var sale = await dataContext.Sales.FirstOrDefaultAsync(x => x.Id == 1);
                if (sale != null)
                {
                    dataContext.SalesDetails.Add(new SalesDetail { saleID = sale.Id, productID = 1, quantity = 1, uintPrice = 200 });
                    dataContext.SalesDetails.Add(new SalesDetail { saleID = sale.Id, productID = 2, quantity = 3, uintPrice = 50 });
                    dataContext.SalesDetails.Add(new SalesDetail { saleID = sale.Id, productID = 3, quantity = 1, uintPrice = 300 });
                    dataContext.SalesDetails.Add(new SalesDetail { saleID = sale.Id, productID = 4, quantity = 1, uintPrice = 100 });
                }
                await dataContext.SaveChangesAsync();
            }
        }

        


        //SUpliers, Purchases & purchasesDetails
        private async Task CheckSupliersAsync()
        {
            if (!dataContext.Supliers.Any())
            {
                dataContext.Supliers.Add(new Suplier { name = "Suplier WH1000XM5", contactInfo = "2221234567" });
                dataContext.Supliers.Add(new Suplier { name = "Suplier WH1000XM6", contactInfo = "2222390345" });
                dataContext.Supliers.Add(new Suplier { name = "Suplier WH1000XM7", contactInfo = "2221230978" });
                await dataContext.SaveChangesAsync();
            }
        }
        /*private async Task CheckPurchasesAsync()
        {
            if (!dataContext.Purchases.Any())
            {
                var suplier = await dataContext.Supliers.FirstOrDefaultAsync(x => x.name == "Suplier WH1000XM5");
                if (suplier != null)
                {
                    dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/08/2024", totalAmount = 10300 });
                    dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/09/2024", totalAmount = 9700 });
                    dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/10/2024", totalAmount = 10800 });
                }
                await dataContext.SaveChangesAsync();
            }
        }*/
        private async Task CheckPurchasesAsync()
        {
            if (!dataContext.Purchases.Any())
            {
                dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/08/2024", totalAmount = 10300 });
                dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/09/2024", totalAmount = 9700 });
                dataContext.Purchases.Add(new Purchase { suplierID = 1, date = "10/10/2024", totalAmount = 10800 });
                await dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckPurchaseDetailsAsync()
        {
            if (!dataContext.PurchaseDetails.Any())
            {
                var purchase = await dataContext.Purchases.FirstOrDefaultAsync(x => x.Id==1);
                if (purchase != null)
                {
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 1784, quantity = 4, unitPrice = 200 });
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 0893, quantity = 1, unitPrice = 400 });
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 7543, quantity = 6, unitPrice = 70 });
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 9832, quantity = 3, unitPrice = 150 });
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 2355, quantity = 4, unitPrice = 200 });
                    dataContext.PurchaseDetails.Add(new PurchaseDetail { purchaseID = purchase.Id, productID = 2362, quantity = 1, unitPrice = 450 });
                }
                await dataContext.SaveChangesAsync();
            }
        }


        //Products
        private async Task CheckProductsAsync()
        {
            if (!dataContext.Products.Any())
            {
                dataContext.Products.Add(new Product { name = "Blusa Sencilla Blanca", description = "Blusa sencilla de color blanco", price = 100, size = "M", stockQuantity = 3 });
                dataContext.Products.Add(new Product { name = "Pantalón De Mezclilla Azul", description = "Pantalón de mezclilla de color azul", price = 250, size = "C", stockQuantity = 4 });
                dataContext.Products.Add(new Product { name = "Camisa De Vestir A Cuadroz Azules", description = "Una camisa azul de vestir a cuadros con botones", price = 170, size = "44", stockQuantity = 1 });
                dataContext.Products.Add(new Product { name = "Palazzo", description = "Un conjutno de palazzo color amarillo", price = 100, size = "C", stockQuantity = 1 });
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
   