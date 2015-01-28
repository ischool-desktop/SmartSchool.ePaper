using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace ElectronicPaper
{
    public static class PaperFormat
    {
        public const string Office2003Doc = "doc";

        public const string Office2003Xls = "xls";

        public const string AdobePdf = "pdf";
    }

    public class PaperItem
    {
        public PaperItem()
        {
            _metadata = new Metadata();
            _viewers = new List<string>();
        }

        public PaperItem(string format, Stream content, string viewerIdentify)
        {
            _metadata = new Metadata();
            _viewers = new List<string>();
            SetContent(format, content);
            AddViewer(viewerIdentify);
        }

        public void SetContent(string format, Stream content)
        {
            _format = format;

            content.Seek(0, SeekOrigin.Begin);
            byte[] data = new byte[content.Length];
            content.Read(data, 0, (int)content.Length);

            _content = Convert.ToBase64String(data);
        }

        private string _format;
        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }

        private string _content;
        /// <summary>
        /// 通常是以 Base64 編碼的二進位內容。
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public void AddViewer(string identify)
        {
            _viewers.Add(identify);
        }

        public List<string> _viewers;
        public IList<string> Viewers
        {
            get { return _viewers.AsReadOnly(); }
        }

        private Metadata _metadata;
        public Metadata Metadata
        {
            get { return _metadata; }
        }
    }
}