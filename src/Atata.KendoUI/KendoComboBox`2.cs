﻿using OpenQA.Selenium;

namespace Atata.KendoUI
{
    [ControlDefinition("span", ContainingClass = "k-combobox", ComponentTypeName = "combo box")]
    [IdXPathForLabel("[.//input[@aria-owns='{0}_listbox']]")]
    public class KendoComboBox<T, TOwner> : EditableField<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override T GetValue()
        {
            string valueAsString = Scope.Get(By.TagName("input").Input()).GetValue();
            return ConvertStringToValue(valueAsString);
        }

        protected override void SetValue(T value)
        {
            string valueAsString = ConvertValueToString(value);
            Scope.Get(By.TagName("input").Input()).FillInWith(valueAsString);
        }
    }
}
