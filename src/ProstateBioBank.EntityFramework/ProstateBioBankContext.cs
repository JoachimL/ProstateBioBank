using System.Data.Entity;

public class ProstateBioBankContext : DbContext
{
    static ProstateBioBankContext()
    {
        //Database.SetInitializer(new DropCreateDatabaseAlways<ProstateBioBankContext>());
    }

    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public ProstateBioBankContext()
        : base("name=ProstateBioBankContext")
    {
    }

    public virtual DbSet<ProstateBioBank.Domain.ProductType> ProductTypes { get; set; }

    public virtual DbSet<ProstateBioBank.Domain.Patient> Patients { get; set; }

    //public virtual DbSet<ProstateBioBank.Domain.Biopsy> Biopsies { get; set; }

    //public virtual DbSet<ProstateBioBank.Domain.Alequot> Alequots { get; set; }

    //public virtual DbSet<ProstateBioBank.Domain.Product> Products { get; set; }

}
