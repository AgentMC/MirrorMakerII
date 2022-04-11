namespace MirrorMakerII
{
    internal interface IProgress
    {
        double Progress { get; }
        string Current { get; }
    }

    internal interface IProgressEx : IProgress
    {
        void SetCurrent(string txt);
    }
}
