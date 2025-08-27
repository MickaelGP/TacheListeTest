using TacheConsole;
using TacheConsole.Interfaces;
using TacheConsole.Metier;
using TacheConsole.Models;
using TacheConsole.Repository;
namespace TestTacheConsole
{
    public class Tests
    {
        private TacheMetier _metier;

        private int unId = 1;

        private DatabaseTest databaseTest = new DatabaseTest();
        [SetUp]
        public void Setup()
        {
            ITacheRepo repo = new TacheRepo();
            _metier = new TacheMetier(repo);
        }

        [Test, Order(1)]
        public void creatDb()
        {
            databaseTest.CreateDBTest();
            databaseTest.CreateTableTest();
            Assert.Pass();
        }

        [Test, Order(2)]
        public void Should_Return_One_When_Created_Task_Suceed()
        {
            Taches tache = new Taches
            {
                tacheNom ="blabla",
                tacheDescription ="blablabla",
                tacheCreation = DateTime.Now,
            };

            int resultat = _metier.InsertTask(tache);

            Assert.That(resultat, Is.EqualTo(1));
        }

        [Test, Order(4)]
        public void Should_Return_One_When_Updated_Task_Suceed()
        {
            Taches tache = new Taches
            {
                tacheId = 1,
            };
            tache.tacheTerminer = DateTime.Now;

            int  taches = _metier.UpdateTask(tache);

            Assert.That(taches, Is.EqualTo(1));
        }

        [Test, Order(6)]
        public void Should_Return_One_When_Delete_Task_Suceed()
        {
            int result = _metier.DeleteTask(this.unId);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test, Order(3)]
        public void Should_Return_Task_List()
        {
            List<Taches> result = _metier.GetAllTask();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test, Order(5)]
        public void Should_Retun_Single_Task()
        {
            Taches resultat  = _metier.GetTaskById(this.unId);

            Assert.That(resultat, Is.Not.Null);
            Assert.That(resultat.tacheNom, Is.EqualTo("blabla"));
        }

        [Test, Order(7)]
        public void Should_Drop_Database_Test()
        {
            databaseTest.DropDatabase();

            Assert.Pass();
        }
    }
}