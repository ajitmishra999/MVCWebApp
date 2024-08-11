﻿namespace SuperMarketApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
           new Category {CategoryId=1,Name="Beverage", Description="Beverage Items"},
           new Category {CategoryId=2,Name="Bakery", Description="Bakery Items"},
           new Category {CategoryId=3,Name="Suppliment", Description="Suppliment Items"}
        };

        public static void AddCategory(Category category)
        {
            if (_categories != null && _categories.Count()>0)
            {
                var maxId = _categories.Max(c => c.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            if (_categories == null)
            {
                _categories = new List<Category>();
            }
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;
            var updateToCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (updateToCategory != null)
            {
                updateToCategory.Name = category.Name;
                updateToCategory.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category= _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
