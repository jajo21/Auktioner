using Auktioner.Models;
using System;
using System.Linq;
using Xunit;

namespace Auktioner.Tests
{
    public class AuktionerTests
    {
        [Fact]
        public void GetArticlesInStock() // Kontrollerar att det g�r att h�mta artiklar som inte �r s�lda
        {
            MockArticleRepository inventory = new();
            int actual = inventory.ArticlesInStock().Count();
            Assert.Equal(1, actual);
        }
    }
}
