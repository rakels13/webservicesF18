using System.Linq;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Repositories.Interfaces;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CleanThatCode.Community.Tests
{
    [TestClass]
    public class PostRepositoryTests
    {
        private IPostRepository _postRepository;
        private Mock<ICleanThatCodeDbContext> _dbContextMock = new Mock<ICleanThatCodeDbContext>();

        [TestInitialize]
        public void Initialize()
        {
            _dbContextMock.Setup(method => method.Posts).Returns(
                FizzWare.NBuilder.Builder<Post>
                .CreateListOfSize(3)
                .TheFirst(1).With(x => x.Title = "Grayskull").With(x => x.Author= "He-Man")
                .TheLast(1).With(x => x.Title = "Hack the planet!").With(x => x.Author= "Richard Stallman")
                .Build());

            _postRepository = new PostRepository(_dbContextMock.Object);
        }

        [TestMethod]
        public void GetAllPosts_NoFilter_ShouldContainAListOfThree()
        {
            //Act
            var posts = _postRepository.GetAllPosts("", "");
            //Assert
            Assert.AreEqual(3, posts.Count());
        }
        [TestMethod]
        public void GetAllPosts_FilteredByTitle_ShouldContainAListOfTwo()
        {
            //Act
            var postsByTitle = _postRepository.GetAllPosts("Grayskull","");
            //Assert
            Assert.AreEqual(2,postsByTitle.Count());
        }
        [TestMethod]
        public void GetAllPosts_FilteredByAuthor_ShouldContainAListOfOne()
        {
            //Act
            var postsByAuthor = _postRepository.GetAllPosts("","Stallman");
            //Assert
            Assert.AreEqual(1,postsByAuthor.Count());
        }

    }
}