using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Bdd
{
    [Binding]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class LibrarySteps
    {
        private readonly LibraryApi libraryApi;

        public LibrarySteps(LibraryApi libraryApi)
        {
            this.libraryApi = libraryApi;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

        }

        [Given(@"the (.*) book is in the library")]
        public void GivenTheValidBookIsInTheLibrary(string isbn)
        {
            libraryApi.Books[isbn] = new Book { Isbn = isbn, Title = "The Book", Author = "me" };
        }

        [Given(@"there are these members")]
        public void GivenThereAreTheseMembers(Table table)
        {
            var memberSet = table.CreateSet<Member>();
            foreach (var member in memberSet)
            {
                libraryApi.AddMember(member);
            }
        }

        [Given(@"these books are in the library")]
        public void GivenTheseBooksAreInTheLibrary(Table table)
        {
            var books = table.CreateSet<Book>();
            foreach (var book in books)
            {
                libraryApi.AddBook(book);
            }
        }

        [When(@"(.*) checks out the (.*) book")]
        public void WhenRegChecksOutTheValidBook(string memberId, string isbn)
        {
            libraryApi.CheckOutBook(memberId, isbn);
        }

        [Then(@"the (.*) book appears in (.*)'s booklist")]
        public void ThenTheBookAppearsInMembersBooklist(string isbn, string memberId)
        {
            Assert.IsTrue(libraryApi.Member(memberId).BookList.Contains(libraryApi.Books[isbn]));
        }

        [Then(@"the (.*) book is not available")]
        public void ThenTheValidBookIsNotAvailable(string isbn)
        {
            Assert.IsFalse(libraryApi.GetBook(isbn).Available);
        }
    }

    public class Member
    {
        public IList<Book> BookList { get; } = new List<Book>();
        public string Id { get; set; }

        public void AddToBookList(Book book)
        {
            BookList.Add(book);
        }
    }

    public class Book
    {
        public bool Available { get; set; } = true;
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
