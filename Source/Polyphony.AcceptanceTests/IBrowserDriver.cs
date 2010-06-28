using System;
using Selenium;

namespace Polyphony.AcceptanceTests
{
    public interface IBrowserDriver
    {
        void Start();
        void OpenUrl(string url);
        void Stop();
        bool IsTextPresent(string text);
    }

    public class SeleniumBrowserDriver : IBrowserDriver
    {
        private readonly ISelenium _selenium;

        public SeleniumBrowserDriver(ISelenium selenium)
        {
            _selenium = selenium;
        }

        public void Start()
        {
            _selenium.Start();
        }

        public void OpenUrl(string url)
        {
            _selenium.Open(url);
        }

        public void Stop()
        {
            _selenium.Stop();
        }

        public bool IsTextPresent(string text)
        {
            return _selenium.IsTextPresent(text);
        }
    }
}