using Event;


void Print(object sender, char key)
{
    Console.Clear();
    Console.WriteLine(key);
}

Read r = new Read();
r.OnKeyPressed += Print;
r.Run();