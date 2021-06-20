using System;
using System.Windows;
using System.Windows.Controls;

namespace Burger_Customiser.Pages {

    public class NavigationButton : Button {
        public Action<Button> ExecuteClickAction { get; }

        public NavigationButton(string text, Action<Button> onclick, Style defaultStyle = null) {
            defaultStyle ??= Application.Current.FindResource("DefaultButton") as Style;
            Style = defaultStyle;

            ExecuteClickAction = onclick;

            Content = text;
        }
    }
}