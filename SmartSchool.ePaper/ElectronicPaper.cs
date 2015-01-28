using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSchool.ePaper
{
    public class ElectronicPaper : IEnumerable<PaperItem>
    {
        private List<PaperItem> _papers;

        /// <summary>
        /// 電子報表。
        /// </summary>
        public ElectronicPaper()
        {
            _meta_data = new Metadata();
            _papers = new List<PaperItem>();
        }

        /// <summary>
        /// 電子報表。
        /// </summary>
        /// <param name="name">電子報表名稱。</param>
        /// <param name="schoolYear">學年度。</param>
        /// <param name="semester">學期。</param>
        /// <param name="viewerType">檢視人類型。</param>
        public ElectronicPaper(string name, string schoolYear, string semester, ViewerType viewerType)
        {
            _name = name;
            _school_year = schoolYear;
            _semester = semester;
            _viewer_type = viewerType;
            _meta_data = new Metadata();
            _papers = new List<PaperItem>();
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _school_year;
        public string SchoolYear
        {
            get { return _school_year; }
            set { _school_year = value; }
        }

        private string _semester;
        public string Semester
        {
            get { return _semester; }
            set { _semester = value; }
        }

        private ViewerType _viewer_type;
        public ViewerType ViewerType
        {
            get { return _viewer_type; }
        }

        private IProgressReceiver _progres_receiver;
        /// <summary>
        /// 如果想要取得處理進度，請實作介面，並指定到此屬性。
        /// </summary>
        public IProgressReceiver ProgressReceiver
        {
            get { return _progres_receiver; }
            set { _progres_receiver = value; }
        }

        public void Append(PaperItem paper)
        {
            _papers.Add(paper);
        }

        /// <summary>
        /// 註解，自動儲存到 Metadata 中。
        /// </summary>
        public string Comment
        {
            get
            {
                if (Metadata.ContainsKey("Comment"))
                    return Metadata["Comment"];
                else
                    return string.Empty;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (Metadata.ContainsKey("Comment"))
                        Metadata.Remove("Comment");

                    return;
                }

                if (Metadata.ContainsKey("Comment"))
                    Metadata["Comment"] = value;
                else
                    Metadata.Add("Comment", value);
            }
        }

        private Metadata _meta_data;
        /// <summary>
        /// 額外需要儲存的資料。
        /// </summary>
        public Metadata Metadata
        {
            get { return _meta_data; }
        }

        #region IEnumerable<PaperTarget> 成員

        IEnumerator<PaperItem> IEnumerable<PaperItem>.GetEnumerator()
        {
            return _papers.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成員

        public System.Collections.IEnumerator GetEnumerator()
        {
            return _papers.GetEnumerator();
        }

        #endregion
    }
}