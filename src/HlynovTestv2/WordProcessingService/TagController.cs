
using System.Collections.Generic;
using System.Linq;

public class TagController
{
    private IEnumerable<TagModel> _tagModels;
    public IEnumerable<TagModel> TagModels
    { get => _tagModels; set => _tagModels = value; }

    public TagController()
    {
        TagModels = new TagModel[] { };
    }

    public void AddTagModel(string tagName)
    {
        var tagModel = new TagModel(tagName);
        TagModels = TagModels.Append(tagModel);  
    } 
    public Dictionary<string,string> GetDictTagModel()
    {
        var dict = new Dictionary<string,string>();
        foreach (var tagModel in TagModels)
        {
            dict.Add(tagModel.TagName, tagModel.GetTextControlValue);
        }
        return dict;
    }
}