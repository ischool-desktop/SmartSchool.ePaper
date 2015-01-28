using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSchool.ePaper
{
    public class DispatcherProvider
    {
        private static Dictionary<string, IPaperDispatcher> _dispatchers;
        private static IPaperDispatcher _default_dispatcher;

        static DispatcherProvider()
        {
            _dispatchers = new Dictionary<string, IPaperDispatcher>(StringComparer.OrdinalIgnoreCase);
        }

        public static void Register(string identify, IPaperDispatcher dispatcher, bool isDefault)
        {
            if (_dispatchers.ContainsKey(identify))
                _dispatchers[identify] = dispatcher;
            else
                _dispatchers.Add(identify, dispatcher);

            if (isDefault)
                _default_dispatcher = dispatcher;
        }

        /// <summary>
        /// 使用預設的 Dispatcher 傳送資料。
        /// </summary>
        public static void Dispatch(ElectronicPaper ePaper)
        {
            if (_default_dispatcher != null)
                _default_dispatcher.Dispatch(ePaper);
            else
                throw new ArgumentException("未指定預設的 Dispatcher。");
        }

        /// <summary>
        /// 跟據特定的識別字串取得 Dispatcher。
        /// </summary>
        /// <param name="identify"></param>
        /// <returns></returns>
        public static IPaperDispatcher GetDispatcher(string identify)
        {
            if (_dispatchers.ContainsKey(identify))
                return _dispatchers[identify];
            else
                return null;
        }
    }
}
