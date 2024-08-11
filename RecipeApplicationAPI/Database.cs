using MongoDB.Bson;
using MongoDB.Driver;
using RecipeApplicationAPI.Models;

namespace RecipeApplicationAPI
{
    public class Database
    {
        private IMongoDatabase GetDB()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("RecipiesDB");
            return db;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            var recipes = await GetDB().GetCollection<Recipe>("Recipes")
                .Find(r => true)
                .ToListAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipe(string id)
        {
            ObjectId _id = new ObjectId(id);

            var recipe = await GetDB().GetCollection<Recipe>("Recipes")
                .Find(r => r.Id == _id)
                .SingleOrDefaultAsync();

            return recipe;
        }

        public async Task SaveRecipe(string title, string instructions)
        {
            var recipe = new Recipe 
            { 
                Title = title, 
                Instructions = instructions 
            };

            await GetDB().GetCollection<Recipe>("Recipes")
                .InsertOneAsync(recipe);
        }

        public async Task DeleteRecipe(string id)
        {
            ObjectId _id = new ObjectId(id);

            await GetDB().GetCollection<Recipe>("Recipes")
                .DeleteOneAsync(r => r.Id == _id);
        }

        public async Task UpdateRecipe(string id, string title, string instructions)
        {
            ObjectId _id = new ObjectId(id);

            var update = Builders<Recipe>.Update
                .Set(r => r.Title, title)
                .Set(r => r.Instructions, instructions);

            await GetDB().GetCollection<Recipe>("Recipes")
                .UpdateOneAsync(r => r.Id == _id, update);
        }
    }
}
