using System.IO;

namespace TestNotepad
{
    public interface IArchiver
    {
        void CopyTo(Stream src, Stream dest);
        string Unzip(byte[] bytes);
        byte[] Zip(string str);
    }
}