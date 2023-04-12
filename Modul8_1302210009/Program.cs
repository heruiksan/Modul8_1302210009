using Modul8_1302210009;
using System.Runtime.Intrinsics.X86;

internal class program
{
    private static void Main(string[] args)
    {
        BankTransferConfig b = new BankTransferConfig();

        if (b.config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }else if (b.config.lang.Equals("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        string transfer = Console.ReadLine();
        int jumTransfer = (int)Convert.ToInt32(transfer);


        int FEEtransfer = 0;
        if(jumTransfer<= b.config.transfer.threshold)
        {
            FEEtransfer = b.config.transfer.low_fee;
        }else if(jumTransfer >= b.config.transfer.threshold)
        {
            FEEtransfer = b.config.transfer.high_fee;
        }


    }
}

