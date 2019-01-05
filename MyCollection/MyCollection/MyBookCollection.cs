using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class Book
    {
        public string Content { get; set; }
        public string Author { get; set; }

        public Book(string content, string author)
        {
            Content = content;
            Author = author;
        }
    }

    public class MyBookCollection : IEnumerable, IEnumerator
    {
        public Book[] bookCollection = null;

        public MyBookCollection()
        {
            bookCollection = new Book[9];
            bookCollection[0] = new Book("Sherlock Holmes", "Arthur Conan-Doil");
            bookCollection[1] = new Book("To an unknown lady", "Andre Maurois");
            bookCollection[2] = new Book("Les Miserables", "Victor Hugo");
            bookCollection[3] = new Book("The Spy", "Fenimore Cooper");
            bookCollection[4] = new Book("The financier", "Theodore Dreiser");
            bookCollection[5] = new Book("The Genius", "Theodore Dreiser");
            bookCollection[6] = new Book("A Christmas carol", "Charles Dickens");
            bookCollection[7] = new Book("The moon and sixpece", "William Somerset Maugham");
            bookCollection[8] = new Book("Pride and prejudice", "Jane Austen");
        }

        public int position = -1;

        public bool MoveNext()
        {
            if (position < bookCollection.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return bookCollection[position]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}
