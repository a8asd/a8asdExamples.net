using System.Collections.Generic;

namespace Bdd
{
    public class LibraryApi
    {
        public readonly Dictionary<string, Book> Books = new Dictionary<string, Book>();
        private readonly Dictionary<string, Member> members = new Dictionary<string, Member>();

        public Member AddMember(Member member)
        {
            return members[member.Id] = member;
        }

        public Book AddBook(Book book)
        {
            return Books[book.Isbn] = book;
        }

        public void CheckOutBook(string memberId, string isbn)
        {
            members[memberId].AddToBookList(Books[isbn]);
            Books[isbn].Available = false;
        }

        public Member Member(string memberId)
        {
            return members[memberId];
        }

        public Book GetBook(string isbn)
        {
            return Books[isbn];
        }
    }
}