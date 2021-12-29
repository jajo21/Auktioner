using Auktioner.Models;
using System;
using System.Linq;
using Xunit;

namespace Auktioner.Tests
{
    public class AuktionerTests
    {
        [Fact]
        public void GetArticlesInStock() // Kontrollerar att det går att hämta artiklar som inte är sålda
        {
            MockArticleRepository inventory = new();
            int actual = inventory.ArticlesInStock().Count();
            Assert.Equal(1, actual);
        }
    }
}
