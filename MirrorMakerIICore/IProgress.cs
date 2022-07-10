namespace MirrorMakerIICore
{
    public interface IProgress
    {
        double Progress { get; }
        string Current { get; }
        void Cancel();
    }

    public interface IProgressEx : IProgress
    {
        void SetCurrent(string txt);
    }
}
