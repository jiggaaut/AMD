using DB.Entities;
using SharedKernel.Factories;

namespace SharedKernel.Models;

public class UserModel : BaseModel, IFactory<User>
{
    private readonly IKekModel _kekModel;
    public string Login { get; set; }
    public byte Type { get; set; }

    public string Keker => _kekModel.Keker;

    public UserModel(IKekModel kekModel)
    {
        _kekModel = kekModel;
    }

    public void Initialize(User user)
    {
        ID = user.ID;
        Login = user.Login;
        Type = user.Type;
    }
}