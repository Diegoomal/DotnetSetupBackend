public class UnitTestPerson
{

    [Fact]
    public void CanCreatePerson()
    {
        // Arrange
        Person personToCreate = new Person() {
            Name = "Diego",
            Lastname = "Maldonado"
        };

        Facade facade = new Facade();
        
        // Act
        Result result = facade.Create(personToCreate);

        // Assert
        Assert.True(string.IsNullOrEmpty(result.Msg), $"Validation Error: {result.Msg}");

        Assert.NotNull(result.Entities);
        Assert.Single(result.Entities);

        IEntity entity = result.Entities.First();
        Assert.IsType<Person>(entity);

        Person createdPerson = (Person)entity;
        Assert.NotEqual(0, createdPerson.Id);

        // Pode adicionar mais verificações específicas sobre o objeto criado, se necessário
        Assert.Equal(personToCreate.Name, createdPerson.Name);
        Assert.Equal(personToCreate.Lastname, createdPerson.Lastname);
    }

    [Fact]
    public void CanReadPerson()
    {
        // // Arrange
        // var personToRead = new Person { Id = 1 };

        // var facade = new Facade();

        // // Act
        // Result result = facade.Read(personToRead);

        // // Assert
        // Assert.True(string.IsNullOrEmpty(result.Msg), $"Validation Error: {result.Msg}");

        // Assert.NotNull(result.Entities);
        // Assert.NotEmpty(result.Entities);

        // foreach (var entity in result.Entities) {

        //     Assert.IsType<Person>(entity);

        //     Person readPerson = (Person)entity;
        //     Assert.Equal(personToRead.Id, readPerson.Id);

        //     // Pode adicionar mais verificações específicas sobre o objeto lido, se necessário

        // }
    }

    [Fact]
    public void CanUpdatePerson()
    {
        // Arrange
        var personToUpdate = new Person {
            Id = 1,
            Name = "Diego",
            Lastname = "Maldonado"
        };

        var facade = new Facade();

        // Act
        Result result = facade.Update(personToUpdate);

        // Assert
        Assert.True(string.IsNullOrEmpty(result.Msg), $"Validation Error: {result.Msg}");

        Assert.NotNull(result.Entities);
        Assert.Single(result.Entities);

        IEntity entity = result.Entities.First();
        Assert.IsType<Person>(entity);

        Person updatedPerson = (Person)entity;
        Assert.Equal(personToUpdate.Id, updatedPerson.Id);

        // Pode adicionar mais verificações específicas sobre o objeto atualizado, se necessário
        Assert.Equal(personToUpdate.Name, updatedPerson.Name);
        Assert.Equal(personToUpdate.Lastname, updatedPerson.Lastname);
    }

    [Fact]
    public void CanDeletePerson()
    {
        // // Arrange
        // var personToDelete = new Person {
        //     Id = 1,
        //     Name = "Diego",
        //     Lastname = "Maldonado"
        // };

        // var facade = new Facade();

        // // Act
        // Result result = facade.Delete(personToDelete);

        // // Assert
        // Assert.True(string.IsNullOrEmpty(result.Msg), $"Validation Error: {result.Msg}");

        // Assert.NotNull(result.Entities);
        // Assert.NotEmpty(result.Entities);

        // foreach (var entity in result.Entities) {

        //     Assert.IsType<Person>(entity);

        //     Person deletedPerson = (Person)entity;
        //     Assert.Equal(personToDelete.Id, deletedPerson.Id);
        //     Assert.Equal("<deleted>", deletedPerson.Name);
        //     Assert.Equal("<deleted>", deletedPerson.Lastname);

        //     // Pode adicionar mais verificações específicas sobre o objeto excluído, se necessário
        // }
    }

}// class