using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Provider
{
    [TestClass]
    public class CatBreedTest
    {
        [TestMethod]
        public void GetAllBreeds_ShouldReturnAllBreeds()
        {
            var testBreeds = GetTestBreeds();
            var controller = new CatApi(testBreeds);

            var result = controller.GetAllBreeds() as List<Breed>;
            Assert.AreEqual(testBreeds.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllBreedsAsync_ShouldReturnAllBreeds()
        {
            var testBreeds = GetTestBreeds();
            var controller = new CatApi(testBreeds);

            var result = await controller.GetAllBreedsAsync() as List<Breed>;
            Assert.AreEqual(testBreeds.Count, result.Count);
        }

        //[TestMethod]
        //public void GetBreed_ShouldReturnCorrectBreed()
        //{
        //    var testBreeds = GetTestBreeds();
        //    var controller = new CatApi(testBreeds);

        //    var result = controller.GetBreed(4) as OkNegotiatedContentResult<Breed>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testBreeds[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public async Task GetBreedAsync_ShouldReturnCorrectBreed()
        //{
        //    var testBreeds = GetTestBreeds();
        //    var controller = new CatApi(testBreeds);

        //    var result = await controller.GetBreedAsync(4) as OkNegotiatedContentResult<Breed>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(testBreeds[3].Name, result.Content.Name);
        //}

        //[TestMethod]
        //public void GetBreed_ShouldNotFindProduct()
        //{
        //    var controller = new CatApi(GetTestBreeds());

        //    var result = controller.GetBreeds(999);
        //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        //}

        private List<Breed> GetTestBreeds()
        {
            var testBreeds = new List<Breed>();
            testBreeds.Add(new Breed { Id = "abc", Name = "Cat1", Origin = "USA", Description = "very good description1", Wikipedia_Url = "https://en.wikipedia.org/wiki/Abyssinian_(cat)"});
            testBreeds.Add(new Breed { Id = "sadf", Name = "Cat2", Origin = "GB", Description = "very good description2", Wikipedia_Url = "https://en.wikipedia.org/wiki/Aegean_cat" });
            testBreeds.Add(new Breed { Id = "kjvhb", Name = "Cat3", Origin = "Lithuania", Description = "very good description3", Wikipedia_Url = "https://en.wikipedia.org/wiki/American_Bobtail" });
            testBreeds.Add(new Breed { Id = "dsjkf", Name = "Cat4", Origin = "Poland", Description = "very good description4", Wikipedia_Url = "https://en.wikipedia.org/wiki/American_Curl" });

            return testBreeds;
        }
    }
}






























//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Provider;

//namespace CatBreedTest
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void Test_AddMethod()
//        {
//            CatApi bm = new CatApi();
//            string res = bm.Add("ID", "Name");
//            //Assert.AreEqual(res, 20);
//        }
//        [TestMethod]
//        public void Test_SubstractMethod()
//        {
//            CatApi bm = new CatApi();
//            double res = bm.Substract(10, 10);
//            Assert.AreEqual(res, 0);
//        }
//        [TestMethod]
//        public void Test_DivideMethod()
//        {
//            CatApi bm = new CatApi();
//            double res = bm.divide(10, 5);
//            Assert.AreEqual(res, 2);
//        }
//        [TestMethod]
//        public void Test_MultiplyMethod()
//        {
//            CatApi bm = new CatApi();
//            double res = bm.Multiply(10, 10);
//            Assert.AreEqual(res, 100);
//        }
//    }
//}
