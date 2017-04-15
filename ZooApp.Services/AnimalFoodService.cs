using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{

    public class AnimalFoodService

    {
        ZooContext db = new ZooContext();
        //public List<ViewFoodTotal> GetViewFoodTotals()
        //{
        //    var animalFoods = db.AnimalFoods.Include(a => a.Animal).Include(a => a.Food);
        //    List<ViewFoodTotal> totals = new List<ViewFoodTotal>();

        //    foreach (AnimalFood animalFood in animalFoods)
        //    {
        //        ViewFoodTotal foodTotal = new ViewFoodTotal(animalFood);
        //        totals.Add(foodTotal);
        //    }
        //    List<ViewFoodTotal> result = new List<ViewFoodTotal>();
        //    var groupBy = totals.GroupBy(x => x.FoodName);
        //    foreach (IGrouping<string, ViewFoodTotal> foodTotals in groupBy)
        //    {
        //        double totalPrice = foodTotals.Sum(x => x.TotalPrice);
        //        double quantity = foodTotals.Sum(x => x.TotalQuantity);

        //        ViewFoodTotal foodTotal = new ViewFoodTotal()
        //        {
        //            FoodName = foodTotals.Key,
        //            FoodPrice = foodTotals.First().FoodPrice,
        //            TotalPrice = totalPrice,
        //            TotalQuantity = quantity
        //        };
        //        result.Add(foodTotal);
        //    }
        //    return result;
        //}
        //public List<ViewFoodTotal> GetViewFoodTotals()
        //{
        //    IQueryable<IGrouping<int, AnimalFood>> animalFoodGroups = db.AnimalFoods.GroupBy(x => x.AnimalId);

        //    IQueryable<ViewFoodTotal> foodTotals = from foodGroup in animalFoodGroups
        //        select new ViewFoodTotal()
        //        {
        //            FoodPrice = foodGroup.FirstOrDefault().Food.Price,
        //            FoodName = foodGroup.FirstOrDefault().Food.Name,
        //            TotalQuantity = foodGroup.Sum(x => x.Animal.Quantiry * x.Quantity),
        //            TotalPrice = foodGroup.Sum(x => x.Animal.Quantiry * x.Quantity) * foodGroup.FirstOrDefault().Food.Price
        //        };
        //    return foodTotals.ToList(); 
        //}
        public List<ViewFoodTotal> GetViewFoodTotals()
        {
            IQueryable<IGrouping<int, AnimalFood>> animalFoodGroups = db.AnimalFoods.GroupBy(x => x.FoodId);

            IQueryable<ViewFoodTotal> foodTotals = 
                from foodGroup in animalFoodGroups
                let totalQuantity = foodGroup.Sum(x => x.Animal.Quantiry * x.Quantity)
                let food = foodGroup.FirstOrDefault()
                select new ViewFoodTotal()
                {
                    FoodPrice = food.Food.Price,
                    FoodName = food.Food.Name,
                    TotalQuantity = totalQuantity,
                    TotalPrice = totalQuantity * food.Food.Price,
                    Id = food.Id,
                    FoodId = food.FoodId
                };
            return foodTotals.ToList();
        }


        public List<ViewFoodAnimalTotal> GetViewFoodTotalByFood(int foodId)
        {
            IQueryable<AnimalFood> animalFoods = db.AnimalFoods.Where(x => x.FoodId == foodId);
            var totals = animalFoods.Select(animalFood => new ViewFoodAnimalTotal()
            {
                Id = animalFood.Id,
                AnimalName = animalFood.Animal.Name,
                TotalQuantity = animalFood.Quantity * animalFood.Animal.Quantiry,
                TotalPrice = animalFood.Quantity * animalFood.Animal.Quantiry * animalFood.Food.Price,
        }).ToList();
            return totals;

        }
    }
}
