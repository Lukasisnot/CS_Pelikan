namespace InterfacesExample;

public class CarRepository : ICarRepository
{
    private readonly List<CarModel> _models;

    public CarRepository()
    {
        _models = new List<CarModel>();
    }

    public CarModel? Get(Guid Id)
    {
        foreach (var model in _models)
        {
            if (model.Id == Id) return model;
        }
        return null;
    }

    public List<CarModel> Get()
    {
        return _models;
    }

    public void Insert(CarModel model)
    {
        if (model == null) return;
        _models.Add(model);
    }

    public void Update(CarModel model)
    {
        for (int i = 0; i < _models.Count; i++)
        {
            if (model.Id == _models[i].Id)
            {
                _models[i] = model;
                return;
            }
        }
    }

    public void Delete(Guid Id)
    {
        foreach (var model in _models.ToArray())
        {
            if (model.Id == Id)
            {
                _models.Remove(model);
                return;
            }
        }
    }

    public int RecordCount()
    {
        return _models.Count;
    }
}