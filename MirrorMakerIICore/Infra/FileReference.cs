namespace MirrorMakerIICore.Infra
{
    [System.Diagnostics.DebuggerDisplay("{From} ==> {To} ({FromReference})")]
    internal class FileReference
    {
        public string? From;
        public string? To;
        public string? FromReference;
    }
}
