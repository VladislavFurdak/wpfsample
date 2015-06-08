using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReferenceData.BAL;
using ReferenceData.BAL.BusModels;
using Microsoft.Practices.Unity;
using System.Linq;

namespace ReferenceData.Tests
{
    [TestClass]
    public class BusTests
    {
        public static UnityContainer unityContainer;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            unityContainer = new UnityContainer();
            unityContainer.LoadConfiguration();
            MapperInitialization.Init();
        }

        [TestMethod]
        public void TestBusAdd()
        {
          var busUser = unityContainer.Resolve<IBusUser>();  
          var entity = new UserBusModel{FirstName ="FirstTest", SecondName ="SecondTest",CountryId = 1};
          var model = busUser.AddBusModel(entity);
          var result = busUser.Get(model.Id);
          Assert.AreNotEqual(model.Id, 0);
          Assert.AreEqual(result.FirstName, entity.FirstName);
          Assert.AreEqual(result.CountryId, entity.CountryId);
        }

        [TestMethod]
        public void TestBusGet()
        {
            var busUser = unityContainer.Resolve<IBusUser>();
            var list = busUser.GetAll().ToList();
            Assert.AreNotEqual(list.Count, 0);
        }
    }
}
