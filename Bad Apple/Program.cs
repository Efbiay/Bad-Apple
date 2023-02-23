using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using imgconv;
namespace BadApple{
    class Program
    {

        static void Main(string[] args)
        {
            FrameConverter converter = new FrameConverter();

            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string framesPath = Path.Combine(appPath, "frames");
            string binPath = Path.Combine(appPath, "bin");

       
            Debug.WriteLine("dsdfds");
            Console.WriteLine("İşlem seçin:");
            Console.WriteLine("1. Resimleri çevir");
            Console.WriteLine("2. Bin dosyalarını oynat");
            Console.WriteLine("3. Bin dosyasını test et");
            Console.WriteLine("4. Çıkış");

            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 4:
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Başlangıç noktası seçin");
                    int start = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Bitiş noktası seçin");
                    int end = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Resimleri çevirme işlemi başladı.");
                    for (int i = start; i <= end; i++)
                    {
                        string filePath = Path.Combine(framesPath, i.ToString() + ".png");
                        string outputpath = Path.Combine(binPath, i.ToString() + ".bin");
                        Console.WriteLine("Çeviriliyor: " + i.ToString() + ".png" + " => " + i.ToString() + ".bin");
                        converter.FrameToBinFile(filePath, outputpath);
                    }
                    Console.WriteLine("Resimleri çevirme işlemi tamamlandı.");
                    break;
                case 2:
                    Console.WriteLine("Başlangıç noktası seçin");
                    int start2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Bitiş noktası seçin");
                    int end2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Oynatma işlemi başladı.");

                    for (int i = start2; i <= end2; i++)
                    {
                        string[] file = File.ReadAllLines(Path.Combine(binPath, i.ToString() + ".bin"));
                        for (int j = 0; j < file.Length; j++)
                        {
                            for (int k = 0; k < file[j].Length; k++)
                            {
                                if (file[j][k] == '1')
                                {
                                    Console.Out.WriteAsync("#");
                                }
                                else
                                {
                                    Console.Out.WriteAsync(" ");
                                }
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        //System.Threading.Thread.Sleep(1000 / 30);
                        Console.Clear();
                    }
                    Console.WriteLine("Oynatma işlemi tamamlandı.");
                    break;

                   
                    

                case 3:
                    string[] file1 = File.ReadAllLines(Path.Combine(binPath, "150.bin"));
                    for (int i = 0; i < file1.Length; i++)
                    {
                        for (int j = 0; j < file1[i].Length; j++)
                        {
                            if (file1[i][j] == '1')
                            {
                                Console.Write("■");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }

                    break;


                










            }
            



        }
    }
}

