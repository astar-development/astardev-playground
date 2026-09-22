using Microsoft.EntityFrameworkCore;

namespace AStarDev.ControlDb.TestsUnit;

public class GivenAStarDevControlDbContext
{
    [Fact]
    public void when_creating_a_new_instance_it_is_created_without_error()
        => new ControlDbContext().ShouldNotBeNull();

    [Fact]
    public void when_creating_a_new_instance_it_is_created_by_extending_the_dbContext()
        => new ControlDbContext().ShouldBeAssignableTo<DbContext>();
}
