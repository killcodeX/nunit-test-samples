using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePageTests;

    public class Input
    {
        private IWebElement InputElement;
        // help to initalize element
        public Input(IWebElement elem)
        {
            InputElement = elem;
        }

        public void FillInput(string text)
        {
            InputElement.Clear();
            InputElement.SendKeys(text);
        }
    }

