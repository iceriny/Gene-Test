// See https://aka.ms/new-console-template for more information
using Gene_Test;
using System.Threading;
using U = Gene_Test.Utilities;

int sleepTime = 500;

Console.WriteLine("按任何键开始或重新生成。");
Thread.Sleep(sleepTime);
Console.WriteLine("回车键退出。");
Thread.Sleep(sleepTime);
Console.WriteLine("该程序提供两个默认对象。");
Thread.Sleep(sleepTime);

TestObject a = new("测试对象a", Color.white, 1.6, 3.2, 0.6);
TestObject b = new("测试对象b", Color.red, 1.8, 2.8, 0.5);
a.Print(ConsoleColor.Green);
b.Print(ConsoleColor.Green);
Thread.Sleep(sleepTime);
Console.WriteLine("每次生成模拟两个测试对象进行交配。");
Thread.Sleep(sleepTime);
Console.WriteLine("测试对象会有基因交换的过程，此算法将基因的表现抽象为一个n(该例子中是6)维向量，\n基因交换就是从两个对象基因所代表向量之间随机生成一个向量。");
Thread.Sleep(sleepTime);
Console.WriteLine("交配的对象提供的基因会有概率发生变异");
Thread.Sleep(sleepTime);
Console.WriteLine("基因变异则是某基因在其所代表的n维向量，在一定欧氏距离范围内的随机变化。");
Thread.Sleep(sleepTime);
Console.WriteLine("下面开始吧！");
Thread.Sleep(sleepTime);
Console.ReadKey();
var key = Console.ReadKey();
if (key.Key == ConsoleKey.Enter)
    goto end;



start:
a.Print(ConsoleColor.Green);
b.Print(ConsoleColor.Green);

var c =TestObject.Mating(a, b);
c.Name = "测试对象c";


ConsoleColor color;
if ((c.Size > b.Size || c.Size < a.Size) || (c.Speed > a.Speed || c.Speed < b.Speed) || (c.Preference > a.Preference || c.Preference < b.Preference))
    color = ConsoleColor.Red;
else
    color = ConsoleColor.DarkBlue;



c.Print(color);



key = Console.ReadKey();
if (key.Key != ConsoleKey.Enter)
{
    Console.Clear();
    goto start;
}
end:
Console.WriteLine("下次再来！");
Thread.Sleep(sleepTime * 2);