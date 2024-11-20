using Mapster;
using Student.Domain.Contracts.Students;
using Student.Domain.Entities;

namespace Student.Application.Mapping
{
    internal class MappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Entities.Student, StudentResponse>()
                .Map(dest => dest.Nationality, src => src.Nationality.Name)
                .Map(dest => dest.Familys, src => src.FamilyMembers);

            config.NewConfig<FamilyMember, FamilyResponse>()
                .Map(dest => dest.Relationship, src => src.Relationship.Name);
        }
    }
}
