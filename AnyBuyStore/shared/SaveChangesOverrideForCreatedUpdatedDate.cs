//using AnyBuyStore.Data.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;

//namespace AnyBuyStore.shared
//{
//    public class SaveChangesOverrideForCreatedUpdatedDate
//    {
//        public override int SaveChanges()
//        {
//            var entries = ChangeTracker
//                .Entries()
//                .Where(e => e.Entity is BaseEntity && (
//                        e.State == EntityState.Added
//                        || e.State == EntityState.Modified));

//            foreach (var entityEntry in entries)
//            {
//                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

//                if (entityEntry.State == EntityState.Added)
//                {
//                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
//                }
//            }

//            return base.SaveChanges();
//        }
//    }
//}
