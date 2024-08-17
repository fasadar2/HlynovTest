
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Класс контроллер тегов.
/// </summary>
public class TagController
{
    /// <summary>
    /// Коллекция моделей тегов.
    /// </summary>
    private IEnumerable<TagModel> _tagModels;
    public IEnumerable<TagModel> TagModels
    { get => _tagModels; set => _tagModels = value; }
    /// <summary>
    /// Конструктор контроллера тегов.
    /// </summary>
    public TagController()
    {
        TagModels = new TagModel[] { };
    }
    /// <summary>
    /// Создание модели тегов и добавление ее в коллекцию.
    /// </summary>
    /// <param name="tagName"></param>
    public void AddTagModel(string tagName)
    {
        var tagModel = new TagModel(tagName);
        TagModels = TagModels.Append(tagModel);  
    }
    /// <summary>
    /// Получение словаря состоящего из пары название тега:значение тега
    /// </summary>
    /// <returns>Dictionary<string,string></returns>
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