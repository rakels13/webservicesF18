using System.Linq;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Implementations;
using CleanThatCode.Community.Repositories.Interfaces;
using CleanThatCode.Community.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;

namespace CleanThatCode.Community.Tests
{   
    [TestClass]
    public class CommentRepositoryTests
    {
        private ICommentRepository _commentRepository;
        //private Mock<ICleanThatCodeDbContext> _dbContextMock = new Mock<ICleanThatCodeDbContext>();
        

        [TestInitialize]
        public void Initialize()
        {
            _commentRepository = new CommentRepository(new CleanThatCodeDbContextMock());
        }

        [TestMethod]
        public void GetAllCommentsByPostId_GivenWrongPostId_ShouldReturnNoComments()
        {
            //Arrange

            //Act
            var comments = _commentRepository.GetAllCommentsByPostId(-1);
            //Assert
            Assert.AreEqual(0, comments.Count());

        }
        
    }
}