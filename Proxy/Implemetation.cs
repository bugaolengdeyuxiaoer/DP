using System;
using System.Collections.Generic;
using System.Threading;

namespace Proxy
{

    public interface IDocument
    {
        void DisplayDocument();
    }
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }

        public int AuthorID { get; private set; }

        public DateTimeOffset LastAccessed { get; private set; }
        private string _filename;

        public Document(string filename)
        {
            _filename = filename;
            LoadDocument(filename);
        }

        public void LoadDocument(string filename) {
            Console.WriteLine("Executing expensive action :loading a file from disk");
            Thread.Sleep(1000);

            Title = "An expensive document";
            Content = "Lots and lots of content";
            AuthorID = 1;
            LastAccessed = DateTimeOffset.UtcNow;
        }
        public void DisplayDocument()
        {
            Console.WriteLine($"Title {Title}, Content {Content}");
        }
    }

    public class DocumentProxy : IDocument
    {
        private string _filename;

        private Lazy<Document> _document;
        public DocumentProxy(string filename)
        {
            _filename = filename;
            _document = new Lazy<Document>(() => new Document(_filename));
        }

        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }
}
