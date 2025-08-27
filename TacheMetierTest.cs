using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Legacy;
using TacheConsole.Interfaces;
using TacheConsole.Metier;
using TacheConsole.Models;
namespace TestTacheConsole
{
    public class TacheMetierTest
    {
        private Mock<ITacheRepo> _repo;

        private TacheMetier _metier;

        [SetUp]
        public void Setup()
        {
            _repo = new Mock<ITacheRepo>();

            _metier = new TacheMetier(_repo.Object);
        }

        private Taches CreateTask()
        {
            return new Taches
            {
                tacheId = 1,
                tacheCreation = DateTime.Now,
                tacheNom = "Tache 1",
                tacheDescription = "Tache de test"
            };
        }

        [Test]
        public void Should_Return_One_When_Created_Task_Succeed()
        {
            Taches unTache = CreateTask();

            _repo.Setup(r => r.InsertTask(unTache)).Returns(1);

            int result = _metier.InsertTask(unTache);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Should_Return_Zero_When_Created_Task_Failed()
        {
            Taches unTache = CreateTask();

            _repo.Setup(r => r.InsertTask(unTache)).Returns(0);

            int result = _metier.InsertTask(unTache);

          Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Should_Return_One_When_Updated_Task_Succeed()
        {
            Taches unTache = CreateTask();

            _repo.Setup(r => r.UpdateTask(It.IsAny<Taches>())).Returns(1);

            int result = _metier.UpdateTask(unTache);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Should_Return_One_When_Deleted_Task_Succeed()
        {
            Taches unTache = CreateTask();

            _repo.Setup(r => r.DeleteTask(unTache.tacheId)).Returns(1);

            int result = _metier.DeleteTask(unTache.tacheId);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Should_Return_Task_List()
        {
            List<Taches> desTaches = new List<Taches>
            {
                new Taches{ tacheId = 1 , tacheNom ="sdsds", tacheDescription="sdsdsd", tacheCreation = DateTime.Now},
                new Taches{ tacheId = 1 , tacheNom ="sdsds", tacheDescription="sdsdsd", tacheCreation = DateTime.Now},

            };

            _repo.Setup(r => r.GetAllTask()).Returns(desTaches);

            List<Taches> result = _metier.GetAllTask();

            Assert.That(result, Is.EqualTo(desTaches));
        }
    } 
}
