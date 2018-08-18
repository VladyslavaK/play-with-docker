using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Infrastructure
{
    public static class ContextExtension {
        public static long InsertOrUpdate<UEntity>(this DbContext context, UEntity entity) where UEntity : Entity
        {
            context.Entry(entity).State = entity.Id == 0 ?
                                           EntityState.Added :
                                           EntityState.Modified;
           return context.SaveChanges();
        }
    }
}