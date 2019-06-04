﻿using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Infrastructure.Selenium
{
    public class RadioGroup<T> : BaseElementRange, IRadioGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public RadioGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) : base(elements)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }

        public int Count
        {
            get
            {
                return Elements.Count;
            }
        }

        public T ReadSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);

            if (element == null)
            {
                return default(T);
            }

            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;
        }

        public T ReadValue(int index)
        {
            var element = Elements[index];
            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;

            // TODO: VC: Move getting common attributes into some element base
        }

        public bool HasSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public void Select(T key)
        {
            var mappedValue = _reverseMap[key];
            var element = Elements.Single(e => e.GetAttribute("value") == mappedValue);
            element.Click();
        }
    }
}