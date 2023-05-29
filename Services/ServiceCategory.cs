using ReadBookMuds.Models;
using Microsoft.EntityFrameworkCore;

namespace ReadBookMuds.Services
{
    public partial class Service
    {
        public async Task<List<Category>> GetCategories()
        {
            var items = _context.Categories.ToList();
            return items;
        }
        public async Task<Category> GetSingleCategory(int id)
        {
            var categoy = _context.Categories.FirstOrDefault(i => i.Id == id);
            return categoy;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(category).State = EntityState.Detached;
                throw ;
            }
            return category;
        }
        public async Task<Category> DeleteCategory(Category category)
        {
            var IsExist = _context.Categories.FindAsync(category);
            if (IsExist != null)
            {
                throw new Exception("Category no longer exist");
            }
            _context.Categories.Remove(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Entry(category).State = EntityState.Detached;
                throw;
            }
            return category;
        }
        public async Task<Category> EditCategory(Category category)
        {
            var IsExist = _context.Categories.FindAsync(category);
            if (IsExist != null)
            {
                throw new Exception("Category no longer exist");
            }
            try
            {

                _context.Categories.Update(category);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _context.Entry(category).State = EntityState.Detached;
                throw;
            }
            return category;
        }
    }
}
