namespace MirrorMakerIICore.Infra
{
    public interface IProgress
    {
        double Progress { get; }
        string Current { get; }
    }

    public interface IProgressEx : IProgress
    {
        void SetCurrent(string txt);
    }
}
