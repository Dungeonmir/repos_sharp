
using practCsharp9_10;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Film filmik = new Film("Cheburaska i druzia", "Potapych", DateTime.Now, Format.Cinema,new Actor[0]);
Console.WriteLine( filmik.ToShortString());

Person ilia = new Person("Илья", "Потапыч", DateTime.Now);
Person kuzia = new Person("Кузя", "Мурка", DateTime.Now);
Actor roger = new Actor("Второстепенный герой", ilia, 1000);
Actor coria = new Actor("Главный герой", kuzia, 1500);

filmik.AddActors(roger, coria);
Console.WriteLine(filmik.ToString());

Console.WriteLine(filmik.ActorBestFee.ToString());