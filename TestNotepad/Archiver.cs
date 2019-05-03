using System.IO;
using System.IO.Compression;
using System.Text;

/* Реализовать текстовый редактор с возможностью сохранения/загрузки файлов в/из БД.
   В качестве БД желательно использовать SQLite, но непринципиально.
   Условия выполнения задания:
- Настройки подключения к базе в файле конфигурации приложения
- Разработать форму выбора файла для загрузки
Дополнительные задания:
- Обеспечить сжатие информации при хранении в БД средством любой ThirdParty библиотеки



- Загрузка файла из базы и сохранение в базу асинхронно
- Разработать форму ввода имени файла для сохранения
- Для форматов json и xml обеспечить подсветку синтаксиса и форматирование
 */
namespace TestNotepad
{
    public class Archiver : IArchiver
    {
        public void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];
            int cnt;
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
                dest.Write(bytes, 0, cnt);
        }
        public byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                    CopyTo(msi, gs);
                return mso.ToArray();
            }
        }
        public string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                    CopyTo(gs, mso);
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}
