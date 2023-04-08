using Microsoft.EntityFrameworkCore.Query;
using MovieStore_Domain.Entities;
using System.Linq.Expressions;

namespace MovieStore_Domain.Repository
{
    /// <summary>
    /// Repository Desing Pattern
    /// This pattern is a design pattern used to prevent code duplication and increase reusability when using     ORM tools that are in constant communication with the database, such as Entity Framework.<para/>
    ///In the Base Repository interface, it is aimed to be used for different classes by using the generic    structure.<para/>
    ///In addition, thanks to this pattern, we minimize the intervention to the database in the controls and force the developer to use only these commands.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
             
        
        
        /// <summary>
        /// Save New <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Add(TEntity entity);
        /// <summary>
        /// Update <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity);
        /// <summary>
        /// Delete <typeparamref name="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Delete(TEntity entity);

        Task<bool> Any(Expression<Func<TEntity, bool>> expression);  // Kayıt varsa true, yoksa false döner.
        Task<TEntity> GetDefault(Expression<Func<TEntity, bool>> expression); // Dinamik olarak where işlemi sağlar. Id ye göre getir.

        Task<List<TEntity>> GetDefaults(Expression<Func<TEntity, bool>> expression); // GenreId = 5 olan postları döndür. 

        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<TEntity, TResult>> select, //Select
            Expression<Func<TEntity,  bool>> where,     //Where
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, // Sıralama için kullanıyoruz.
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );

        //Çoklu Dönecek
        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<TEntity, TResult>> select, //Select
            Expression<Func<TEntity, bool>> where,     //Where
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, // Sıralama için kullanıyoruz.
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );


       Task<int> Save();
    }
}
