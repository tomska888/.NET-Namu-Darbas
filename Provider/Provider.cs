using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Provider
{
    public class CatApi : ICatsListProvider
    {
        public async Task<IList<Breed>> GetBreeds()
        {
            string catBreedSearchText;
            using (HttpClient client = new HttpClient())
            {
                catBreedSearchText = (await client.GetStringAsync("https://api.thecatapi.com/v1/breeds"));
            }

            JArray catBreedSearch = JArray.Parse(catBreedSearchText);
            List<JToken> results = catBreedSearch.Children().ToList();

            List<Breed> breeds = new List<Breed>();
            foreach (JToken result in results)
            {
                Breed breed = result.ToObject<Breed>();
                breeds.Add(breed);
            }

            return breeds;
        }




        List<Breed> breeds = new List<Breed>();

        public CatApi() { }

        public CatApi(List<Breed> breeds)
        {
            this.breeds = breeds;
        }

        public IEnumerable<Breed> GetAllBreeds()
        {
            return breeds;
        }

        public async Task<IEnumerable<Breed>> GetAllBreedsAsync()
        {
            return await Task.FromResult(GetAllBreeds());
        }

        //public IHttpActionResult GetBreed(string id)
        //{
        //    var breed = breeds.FirstOrDefault((p) => p.Id == id);
        //    if (breed == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(breed);
        //}

        //public async Task<IHttpActionResult> GetBreedAsync(string id)
        //{
        //    return await Task.FromResult(GetBreed(id));
        //}

    }
}
    //testing testing
    //public string Add(string Id, string Name)
    //{
    //    string ID_Name = "Id" + " " + "Name";
    //    return ID_Name;
    //}
    //public double Substract(double num1, double num2)
    //{
    //    return num1 - num2;
    //}
    //public double divide(double num1, double num2)
    //{
    //    return num1 / num2;
    //}
    //public double Multiply(double num1, double num2)
    //{
    //    // To trace error while testing, writing + operator instead of * operator.  
    //    return num1 * num2;
    //}


    //public class FakeProvider : ICatsListProvider
    //{
    //    public Task<IList<Breed>> GetBreeds()
    //    {
    //        return new Task<IList<Breed>>() { new Breed { Id = "abcd", Name = "abecele",
    //            Origin = "Lithuania", Description = "abecele buvo lietuvoj",
    //            Wikipedia_Url = "https://en.wikipedia.org/" } }; ;
    //    }
    //}

    //public class CashingProvider : ICatsListProvider
    //{
    //    private readonly ICatsListProvider m_provider;
    //    private List<Breed> m_breeds = null;

    //    public CashingProvider(ICatsListProvider provider)
    //    {
    //        m_provider = provider;
    //    }
    //    public IList<Breed> GetBreeds()
    //    {
    //        if (m_breeds != null)
    //            return m_breeds;

    //        return m_breeds = m_provider.GetBreeds();
    //    }

    //    Task<IList<Breed>> ICatsListProvider.GetBreeds()
    //    {
    //        if (m_breeds != null)
    //            return m_breeds;

    //        return m_provider.GetBreeds();
    //    }
    //}

