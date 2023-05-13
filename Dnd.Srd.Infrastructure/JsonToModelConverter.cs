using AutoMapper;
using Dnd.Srd.Data.Profile;
using Newtonsoft.Json;

namespace Dnd.Srd.Infrastructure;

public class JsonToModelConverter
{
    public List<TModel> ConvertJsonToModels<TDto, TModel>(string jsonFilePath)
    {
        // Read the JSON file and deserialize it into a list of TDto objects
        var json = File.ReadAllText(jsonFilePath);
        var dtoList = JsonConvert.DeserializeObject<List<TDto>>(json);

        // Create a new list of TModel objects
        var modelList = new List<TModel>();

        // Create an automapper instance and configure it with the DndMapperProfile
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<DndMapperProfile>()).CreateMapper();

        // Loop through each TDto object and map it to a TModel object using the automapper
        foreach (var dto in dtoList)
        {
            var model = mapper.Map<TModel>(dto);
            modelList.Add(model);
        }

        // Return the list of TModel objects
        return modelList;
    }
}