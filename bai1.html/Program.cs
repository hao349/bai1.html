using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string thongBao = TaoThongBao();
        HienThiThongBao(thongBao);
    }

    static string TaoThongBao()
    {
        return "🌸 Co gang thi tot nhe, dung lam phu long chi gai Oanh! 📚💪";
    }

    static void HienThiThongBao(string thongBao)
    {
        foreach (char c in thongBao)
        {
            Console.Write(c);
            Thread.Sleep(100);
        }
        Console.WriteLine();
    }
}
