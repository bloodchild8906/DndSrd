using Dnd.Srd.Data.Models;
using Action = Dnd.Srd.Data.Models.Action;

namespace Dnd.Srd.Data.Profile;

public class DndMapperProfile : AutoMapper.Profile
{
    public DndMapperProfile()
    {
        CreateMap<AbilityScoreDto, AbilityScore>()
            .ForMember(dest => dest.Creature, opt => opt.Ignore());
        CreateMap<CharacterClassDto, CharacterClass>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.feature.id));
        CreateMap<CreatureDto, Creature>()
            .ForMember(dest => dest.AbilityScoreId, opt => opt.MapFrom(src => src.ability_scores.id))
            .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => src.actions))
            .ForMember(dest => dest.Conditions, opt => opt.MapFrom(src => src.conditions));
        CreateMap<RaceDto, Race>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.feature.id));
        CreateMap<SpellDto, Spell>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.feature.id));
        CreateMap<FeatureDto, Feature>()
            .ForMember(dest => dest.ActionId, opt => opt.MapFrom(src => src.action.id))
            .ForMember(dest => dest.Condition.Id, opt => opt.MapFrom(src => src.condition.id))
            .ForMember(dest => dest.CharacterClassId, opt => opt.MapFrom(src => src.character_class.id))
            .ForMember(dest => dest.RaceId, opt => opt.MapFrom(src => src.race.id))
            .ForMember(dest => dest.SpellId, opt => opt.MapFrom(src => src.spell.id));
        CreateMap<ActionDto, Action>()
            .ForMember(dest => dest.CreatureId, opt => opt.Ignore())
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.feature.id))
            .ForMember(dest => dest.EffectId, opt => opt.MapFrom(src => src.effect.id));
        CreateMap<ConditionDto, Condition>()
            .ForMember(dest => dest.CreatureId, opt => opt.Ignore())
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.feature.id));
        CreateMap<EffectDto, Effect>()
            .ForMember(dest => dest.Action.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ConditionId, opt => opt.Ignore());
    }
}