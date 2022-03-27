using Collections;

Entity e1 = new Entity { Id = 1, ParentId = 0, Name = "Root entity" };


Entity e2 = new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"};


Entity e3 = new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"};


Entity e4 = new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"};


Entity e5 = new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"};

List<Entity> entities = new List<Entity> { e1, e2, e3, e4, e5 };

//check
foreach (var item in Entity.Sort(entities))
{
    foreach (var entity in item.Value)
    {
        Console.WriteLine($"{item.Key} {entity.Id}"); 
    }
    Console.WriteLine();
} 
