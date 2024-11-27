namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        int prevRecordCount = carRepo.RecordCount();

        // Act
        carRepo.Insert(new CarModel("Enyaq", "Skoda"));
        int currRecordCount = carRepo.RecordCount();

        // Assert
        Assert.True(prevRecordCount < currRecordCount);
        Assert.NotEqual(prevRecordCount, currRecordCount);

    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        int prevRecordCount = carRepo.RecordCount();

        // Act
        carRepo.Insert(null);
        int currRecordCount = carRepo.RecordCount();

        // Assert
        Assert.True(prevRecordCount == currRecordCount);
        Assert.Equal(prevRecordCount, currRecordCount);
        
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        // Arrange
        int numberOfRecords = 2;
        IRespository<CarModel> carRepo = new CarRepository();

        for (int i = 0; i < numberOfRecords; i++)
        {
            carRepo.Insert(new CarModel($"Enyaq {i}", $"Skoda {i}"));
        }
                    
        // Act
        List<CarModel> modelRecords = carRepo.Get();

        // Assert
        for (int i = 0; i < numberOfRecords; i++)
        {
            Assert.NotNull(modelRecords[i]);
        }
        Assert.True(modelRecords.Count == numberOfRecords);
        Assert.Equal(modelRecords.Count, numberOfRecords);

    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        // Arrange
        int numberOfRecords = 2;
        IRespository<CarModel> carRepo = new CarRepository();
        List<CarModel> modelRecordsInserted = new List<CarModel>();

        for (int i = 0; i < numberOfRecords; i++)
        {
            CarModel car = new CarModel($"Enyaq {i}", $"Skoda {i}");
            carRepo.Insert(car);
            modelRecordsInserted.Add(car);
        }
        List<CarModel> modelRecordsFromRepo = carRepo.Get();
                    
        // Act
        CarModel firstModelGotById = carRepo.Get(modelRecordsInserted[0].Id);
        CarModel secondModelGotById = carRepo.Get(modelRecordsInserted[1].Id);

        // Assert
        Assert.NotNull(firstModelGotById);
        Assert.NotNull(secondModelGotById);

        Assert.Equal(firstModelGotById, modelRecordsInserted[0]);
        Assert.Equal(secondModelGotById, modelRecordsInserted[1]);
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
                    
        // Act
        CarModel firstModelGotById = carRepo.Get(new Guid());
        CarModel secondModelGotById = carRepo.Get(new Guid());

        // Assert
        Assert.Null(firstModelGotById);
        Assert.Null(secondModelGotById);
    }
    
    [Fact]
    public void UpdatingRecordWithId_ShouldChangeRecord()
    {
        // Arrange
        int numberOfRecords = 2;
        string newName = "Vaclav";
        string newBrand = "Bohata";
        IRespository<CarModel> carRepo = new CarRepository();

        // insert car
        CarModel car = new CarModel("a", "b");
        carRepo.Insert(car);
        Guid carId = car.Id;

        List<CarModel> modelRecordsFromRepo = carRepo.Get();

        // Act
        
        // get inserted car with id
        CarModel updatingCar = carRepo.Get(carId);
        
        // update name and brand on retrieved car
        updatingCar.Name = newName;
        updatingCar.Brand = newBrand;
        
        // call update with updated car
        carRepo.Update(updatingCar);

        // Assert
        Assert.Equal(carRepo.Get(carId).Name, newName);
        Assert.Equal(carRepo.Get(carId).Brand, newBrand);
    }
    
    [Fact]
    public void DeletingInsertedRecordWithId_WithTwoRecords_ShouldRemoveRecordsFromRepo()
    {
        // Arrange
        int numberOfRecords = 2;
        IRespository<CarModel> carRepo = new CarRepository();

        for (int i = 0; i < numberOfRecords; i++)
        {
            CarModel car = new CarModel($"Enyaq {i}", $"Skoda {i}");
            carRepo.Insert(car);
        }
        List<CarModel> modelRecordsFromRepo = carRepo.Get().ToList();
                    
        // Act
        carRepo.Delete(modelRecordsFromRepo[0].Id);
        carRepo.Delete(modelRecordsFromRepo[1].Id);

        // Assert
        Assert.True(carRepo.RecordCount() == 0);
        Assert.Equal(0, carRepo.RecordCount());
    }
    
    [Fact]
    public void DeletingNotExistingRecordWithId_ShouldRemoveRecordsFromRepo()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        Guid carId = new Guid();
        List<CarModel> prevRepo = carRepo.Get().ToList();
                    
        // Act
        carRepo.Delete(carId);
        List<CarModel> currRepo = carRepo.Get().ToList();

        // Assert
        Assert.Equal(prevRepo, currRepo);
    }
}