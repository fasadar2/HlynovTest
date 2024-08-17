using System.Windows;
using System.Windows.Controls;


public class TagModel
{
    private Label _viewName;
    private TextBox _textControl;
    private string _tagName;
    public Label ViewName { get => _viewName; set => _viewName = value; }
    public string TagName { get => _tagName; set => _tagName = value; }
    public TextBox TextControl { get => _textControl; set => _textControl = value; }
    public string GetTextControlValue { get => _textControl.Text; }

    public TagModel(string tagName)
    {
        TextControl = new TextBox 
        { 
            Width = 200,
            Margin = new Thickness(5)
            
        };
        ViewName = new Label
        {
            Content = tagName
        };
        TagName = tagName;
    }
}