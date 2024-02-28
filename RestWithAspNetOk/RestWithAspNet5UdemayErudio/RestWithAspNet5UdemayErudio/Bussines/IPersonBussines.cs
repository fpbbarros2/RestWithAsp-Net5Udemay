using RestWithAspNet5UdemayErudio.Data.Vo;

namespace RestWithAspNet5UdemayErudio.Bussines
{
    public interface IPersonBussines
    {
        PersonVo Create(PersonVo person);
        PersonVo FindByID(long id);
        List<PersonVo> FindAll();
        PersonVo Update(PersonVo person);
        void Delete(long id);
    }
}
