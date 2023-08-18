using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace LearnWild.Tests
{
    public class CourseServiceTests
    {
        private ApplicationDbContext _dbContext = null!;
        private ICourceService _courseService = null!;
        private DatabaseSeeder _databaseSeeder = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("LearnWildInMemory-" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();
            _courseService = new CourseService(_dbContext);
            _databaseSeeder = new DatabaseSeeder(_dbContext);

            _databaseSeeder.Seed();
        }

        [Test]
        public async Task CreateCourseAsyncShouldSave()
        {
            string courseId = DatabaseSeeder.Course.Id.ToString();

            var model = new CourseFormModel()
            {
                Title = "Second Course",
                Description = "Second description",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(5),
                Active = true,
                CategoryId = DatabaseSeeder.Category.Id,
                TypeId = DatabaseSeeder.CourseType.Id,
                Credits = 100,
                Price = null,
                TeacherId = DatabaseSeeder.Teacher.Id.ToString()
            };
            var creatorId = DatabaseSeeder.Teacher.Id.ToString();

            await _courseService.CreateCourseAsync(model, creatorId);

            Assert.IsTrue(_dbContext.Courses.Any(c => c.Id != DatabaseSeeder.Course.Id));
            Assert.That(_dbContext.Courses.Count(), Is.EqualTo(2));
        }


        [Test]
        public async Task EditCourseAsyncShouldSaveChanges()
        {
            string courseId = DatabaseSeeder.Course.Id.ToString();

            var model = new CourseFormModel()
            {
                Title = "Second Course",
                Description = "Second description",
                Start = DateTime.UtcNow,
                End = DateTime.UtcNow.AddDays(5),
                Active = true,
                CategoryId = DatabaseSeeder.Category.Id,
                TypeId = DatabaseSeeder.CourseType.Id,
                Credits = 80,
                Price = 520,
                TeacherId = DatabaseSeeder.Teacher.Id.ToString()
            };

            await _courseService.EditCourseAsync(model, courseId);

            var updatedCourse = _dbContext.Courses.Find(Guid.Parse(courseId));

            Assert.IsTrue(updatedCourse!.Title == model.Title);
            Assert.IsTrue(updatedCourse!.Description == model.Description);
            Assert.IsTrue(updatedCourse!.Start == model.Start);
            Assert.IsTrue(updatedCourse!.End == model.End);
            Assert.IsTrue(updatedCourse!.MaxCredits == model.Credits);
            Assert.IsTrue(updatedCourse!.Price == model.Price);
        }

        [Test]
        public void EditCourseAsyncShouldThrowWhenNotFound()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _courseService.EditCourseAsync(new CourseFormModel(), Guid.Empty.ToString()));
        }

        [Test]
        public async Task ExistsAsyncShouldReturnTrueWhenExists()
        {
            string courseId = DatabaseSeeder.Course.Id.ToString();

            bool result = await _courseService.ExistsAsync(courseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetByIdAsyncShouldReturnValidDataWhenFound()
        {
            string courseId = DatabaseSeeder.Course.Id.ToString();

            var result = await _courseService.GetByIdAsync(courseId);

            Assert.IsTrue(result!.Id == DatabaseSeeder.Course.Id.ToString());
            Assert.IsTrue(result!.Title == DatabaseSeeder.Course.Title);
        }

        [Test]
        public async Task GetByIdAsyncShouldReturnNullWhenNotFound()
        {
            var result = await _courseService.GetByIdAsync(Guid.Empty.ToString());

            Assert.IsNull(result);
        }

        [TestCase(true, ExpectedResult = true)]
        [TestCase(false, ExpectedResult = false)]
        public async Task<bool> IsActiveAsyncShouldReturnTrueWhenCourseFoundAndActive(bool active)
        {
            var course = _dbContext.Courses.Find(DatabaseSeeder.Course.Id);
            course!.Active = active;
            _dbContext.SaveChanges();

            return await _courseService.IsActiveAsync(course.Id.ToString());
        }

        [Test]
        public async Task IsActiveAsyncShouldReturnFalseWhenNotCourseFound()
        {
            Assert.IsFalse(await _courseService.IsActiveAsync(Guid.Empty.ToString()));
        }

        [Test]
        public async Task GetCourseTitleAsyncShouldReturnTitleWhenFound()
        {
            var title = await _courseService.GetCourseTitleAsync(DatabaseSeeder.Course.Id.ToString());
            Assert.IsTrue(title == DatabaseSeeder.Course.Title );
        }

        [Test]
        public async Task GetCourseTitleAsyncShouldReturnEmptyStringWhenNotFound()
        {
            var title = await _courseService.GetCourseTitleAsync(Guid.Empty.ToString());
            Assert.IsEmpty(title);
        }

    }
}