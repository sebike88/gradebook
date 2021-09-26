using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        // Fact is called "Attribute" - data attached to the method
        [Fact]
        public void getBookReturnsDifferentObjects()
        {
           var book1 = getBook("Book 1");
           var book2 = getBook("Book 2");

           Assert.Equal("Book 1", book1.Name);
           Assert.Equal("Book 2", book2.Name);
           Assert.NotSame(book1, book2);
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x  = GetInt();
            setInt(ref x);

            Assert.Equal(42, x);
        }

        private void setInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Sebi";
            string upper = MakeUppercase(name);

            Assert.Equal("Sebi", name);
            Assert.Equal("SEBI", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

    [Fact]
        public void CanSetNameFromReference()
        {
           var book1 = getBook("Book 1");
           SetName(book1, "New Name");

           Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void CSharpPassByRef()
        {
           var book1 = getBook("Book 1");
           GetBookSetNameReference(ref book1, "New Name");

           Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameReference(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
           var book1 = getBook("Book 1");
           GetBookSetName(book1, "New Name");

           Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
           var book1 = getBook("Book 1");
           var book2 = book1;

           Assert.Same(book1, book2);
           Assert.True(object.ReferenceEquals(book1, book2));
        }

        Book getBook(string name)
        {
            return new Book(name);
        }
  }
}
