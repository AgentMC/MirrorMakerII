namespace MirrorMakerIICore.Infra
{
    internal class OperationSummary
    {
        public List<string>? FilesToDelete, FoldersToMaybeDelete, FoldersToMaybeCreate;
        public List<FileReference>? FilesToMove, FilesToCopy;
    }

    [System.Diagnostics.DebuggerDisplay("{From} ==> {To} ({FromReference})")]
    internal class FileReference
    {
        public string? From;
        public string? To;
        public string? FromReference;
    }
}
