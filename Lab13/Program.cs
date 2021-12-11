using System;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            SEIDiskInfo.action+= SEILog.WriteLog;
            SEIFileInfo.action += SEILog.WriteLog;
            SEIDirInfo.action += SEILog.WriteLog;
            SEIFileManager.action += SEILog.WriteLog;

            SEIDiskInfo.FreeSpaceOnDrive(@"D:\");
            SEIDiskInfo.FileSystemInfo(@"C:\");
            SEIDiskInfo.AllInfo();

            SEIFileInfo.FullPath(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt");
            SEIFileInfo.FileInfo(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt");
            SEIFileInfo.DataInfo(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt");

            SEIDirInfo.TimeOfCreate(@"C:\Users\Katerina\Desktop\BSTU\3s 2k");
            SEIDirInfo.NumberOfFiles(@"C:\Users\Katerina\Desktop\BSTU\3s 2k");
            SEIDirInfo.NumberOfSubdir(@"C:\Users\Katerina\Desktop\BSTU\3s 2k");
            SEIDirInfo.ListOfParentsDir(@"C:\Users\Katerina\Desktop\BSTU\3s 2k");

            SEIFileManager.Drivers(@"C:\");
            SEIFileManager.CopyFiles(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\", "");
            SEIFileManager.Archive(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Archivetest",
                @"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Unarchivetest");
            FindInfo();

            static void FindInfo()
            {
                var output = new StringBuilder();

                using (var stream = new StreamReader(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt"))
                {
                    var textline = "";
                    var isActual = false;
                    while (stream.EndOfStream == false)
                    {
                        isActual = false;
                        textline = stream.ReadLine();
                        if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                        {
                            isActual = true;
                            textline += "\n";
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                        while (textline != "------------------------------")
                        {
                            if (isActual)
                            {
                                textline += "\n";
                                output.AppendFormat(textline);
                            }

                            textline = stream.ReadLine();
                        }

                        if (isActual) output.AppendFormat("------------------------------\n");
                    }
                }

                using (var stream = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt"))
                {
                    stream.WriteLine(output.ToString());
                }
            }

        }
    }

    //1. Создать класс XXXLog.Он должен отвечать за работу с текстовым файлом
    //xxxlogfile.txt.в который записываются все действия пользователя и
    //соответственно методами записи в текстовый файл, чтения, поиска нужной
    //информации.
    //a.Используя данный класс выполните запись всех
    //последующих действиях пользователя с указанием действия,
    //детальной информации(имя файла, путь) и времени
    //(дата/время)
    public static class SEILog
    {
        public static void WriteLog(string message)
        {
            var sw = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\Log.txt", true);

            try
            {
                using (sw)
                {
                    sw.WriteLine($"{DateTime.Now.ToString()}\n{message}\n");
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    //2. Создать класс XXXDiskInfo c методами для вывода информации о
    //a.свободном месте на диске
    //b. Файловой системе
    //c.Для каждого существующего диска - имя, объем, доступный
    //объем, метка тома.
    //d.Продемонстрируйте работу класса
    public class SEIDiskInfo
    {
        public static event Action<string> action;
        public static void FreeSpaceOnDrive(string Name)
        {
            var Drives = DriveInfo.GetDrives().Single(x => x.Name == Name);
            Console.WriteLine($"Свободное место на диске {Drives.Name}: {Drives.AvailableFreeSpace} байт");
           action($"Свободное место на диске {Drives.Name}: {Drives.AvailableFreeSpace} байт");
        }
        public static void FileSystemInfo(string Name)
        {
            var Drives = DriveInfo.GetDrives().Single(x => x.Name == Name);
            Console.WriteLine($"Тип файловой системы и формат диска {Drives.Name}: {Drives.DriveType},{Drives.DriveFormat}");
            action($"Тип файловой системы и формат диска {Drives.Name}: {Drives.DriveType},{Drives.DriveFormat}");
        }
        public static void AllInfo()
        {
            var message = new StringBuilder("Информация о диске: \n");
            Console.WriteLine("[");
            message.AppendFormat("[ \n");
            foreach (var Drives in DriveInfo.GetDrives())
            {
                if(Drives.IsReady == false) { continue; }

                Console.WriteLine($"Имя: {Drives.Name}, объем: {Drives.TotalSize}, доступный объем: {Drives.AvailableFreeSpace}, метка тома: {Drives.VolumeLabel}");
                message.AppendFormat($"Имя: {Drives.Name}, объем: {Drives.TotalSize}, доступный объем: {Drives.AvailableFreeSpace}, метка тома: {Drives.VolumeLabel}");
            }
            Console.WriteLine("]");
            message.AppendFormat("\n]\n");
            action(message.ToString());
        }
    }
    //3. Создать класс XXXFileInfo c методами для вывода информации о
    //конкретном файле
    //a. Полный путь
    //b. Размер, расширение, имя
    //c. Дата создания, изменения
    //d. Продемонстрируйте работу класса

    public class SEIFileInfo
    {
        public static event Action<string> action;
        public static void FullPath(string path)
        {
            var file = new FileInfo(path);
            Console.WriteLine($"Полный путь {file.Name}: {file.FullName}");
            action($"Полный путь {file.Name}: {file.FullName}");
        }
        public static void FileInfo(string path)
        {
            var file = new FileInfo(path);
            Console.WriteLine($"Информация о файле {file.Name}: размер - {file.Length}, расширение - {file.Extension}");
            action($"Информация о файле {file.Name}: размер - {file.Length}, расширение - {file.Extension}");
        }

        public static void DataInfo(string path)
        {
            var file = new FileInfo(path);
            Console.WriteLine($"Дата создания: {file.CreationTime}, дата изменения : {file.LastWriteTime}");
            action($"Дата создания: {file.CreationTime}, дата изменения : {file.LastWriteTime}");
        }

    }
    //4. Создать класс XXXDirInfo c методами для вывода информации о конкретном
    //директории
    //a. Количестве файлов
    //b. Время создания
    //c. Количестве поддиректориев
    //d. Список родительских директориев
    //e. Продемонстрируйте работу класса

    public class SEIDirInfo
    {
        public static event Action<string> action;
        public static void NumberOfFiles(string path)
        {
            var dir = Directory.GetFiles(path);
            Console.WriteLine($"Количество файлов: {dir.Length}");
            action($"Количество файлов: {dir.Length}");
        }
        public static void TimeOfCreate(string path)
        {
            var dir = Directory.GetCreationTime(path);
            Console.WriteLine($"Время создания: {dir}");
            action($"Время создания: {dir}");
        }
        public static void NumberOfSubdir(string path)
        {
            var dir = Directory.GetDirectories(path);
            Console.WriteLine($"Количество поддиректориев: {dir.Length}");
            action($"Количество поддиректориев: {dir.Length}");
        }

        public static void ListOfParentsDir(string path)
        {
            var dir = Directory.GetParent(path);
            Console.WriteLine($"Список родительских директориев: {dir}");
            action($"Список родительских директориев: {dir}");
        }
    }

    //5. Создать класс XXXFileManager.Набор методов определите
    //самостоятельно. С его помощью выполнить следующие действия:
    //a.Прочитать список файлов и папок заданного диска.Создать
    //директорий XXXInspect, создать текстовый файл
    //xxxdirinfo.txt и сохранить туда информацию.Создать
    //копию файла и переименовать его. Удалить
    //первоначальный файл.
    //b.Создать еще один директорий XXXFiles.Скопировать в
    //него все файлы с заданным расширением из заданного
    //пользователем директория. Переместить XXXFiles в
    //XXXInspect.
    //c.Сделайте архив из файлов директория XXXFiles. 
    //Разархивируйте его в другой директорий.
    
    public class SEIFileManager
    {
        public static event Action<string> action;
        public static void Drivers(string Name)
        {
            Directory.CreateDirectory(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIInspect");
            var Drives = DriveInfo.GetDrives().Single(x => x.Name == Name);
            File.Create(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIdirinfo.txt").Close();
            using(var sw = new StreamWriter(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIInspect\SEIdirinfo.txt"))
            {
                sw.WriteLine("[Directories]\n");
                foreach (var directoryInfo in Drives.RootDirectory.GetDirectories()) { sw.WriteLine($"{directoryInfo.Name}\n"); }
                sw.WriteLine("[Files]\n");
                foreach (var fileInfo in Drives.RootDirectory.GetFiles()) { sw.WriteLine($"{fileInfo.Name}\n"); }
            }
            File.Copy(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIInspect\SEIdirinfo.txt",
            @"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIInspect\SEIdirinfoCopy.txt", true);
        }
        public static void CopyFiles(string path, string extension)
        {
            action($"Файловый менеджер скопировал {extension} фалйлы из {path}");
            var directory = new DirectoryInfo(path);
            Directory.CreateDirectory(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIFiles");

            foreach (var file in directory.GetFiles())
                if (file.Extension == extension)
                    file.CopyTo($@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIFiles\{file.Name}", true);
           // Directory.Delete(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIInspect\SEIFiles\", true);
            //Directory.Move(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\SEIFiles\",
            //    @"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\\13\SEIInspect\SEIFiles\");
        }

        public static void Archive(string pathFrom, string pathTo)
        {
           action($"Файловый менеджер архивировал файлы {pathFrom}");
            Directory.CreateDirectory(@"C:\Users\Katerina\Desktop\BSTU\3s 2k\ООП\13\13\13\UnarchiveTest\");

            if (!File.Exists($@"{pathFrom}.zip"))
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");

            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo);
        }

    }

    //6. Найдите и выведите сохраненную информацию в файле xxxlogfile.txt о
    //действиях пользователя за определенный день/ диапазон времени/по
    //ключевому слову.Посчитайте количество записей в нем.Удалите часть
    //информации, оставьте только записи за текущий час.
    


    //7. Обязательно обрабатывайте возможные ошибки. В случае с потоками
    //необходимо использовать конструкцию using. Если необходимо 
    //«построить» путь, то следует использовать методы класса Path
}
