using System.Collections.Generic;
using CleanThatCode.Community.Models.Entities;
using CleanThatCode.Community.Repositories.Data;
using CleanThatCode.Community.Repositories.Interfaces;

namespace CleanThatCode.Community.Tests.Mocks
{
    public class CleanThatCodeDbContextMock : ICleanThatCodeDbContext
    {
        private readonly ICommentRepository _commentRepository;

        public IEnumerable<Comment> Comments
        {
            get {
                return FakeData.Comments;
            }
        }

        public IEnumerable<Post> Posts
        {
            get {
                return FakeData.Posts;
            }
        }
    
    }
}