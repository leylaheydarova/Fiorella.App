using AutoMapper;
using Fiorella.App.Dtos.Position;
using Fiorella.App.Models;

namespace Fiorella.App.Profiles
{
    public class PositionMap:Profile
    {
        public PositionMap()
        {
            CreateMap<PositionPostDto, Position>();
            CreateMap<PositionUpdateDto, Position>();
            CreateMap<Position, PositionGetDto>();
        }
    }
}
