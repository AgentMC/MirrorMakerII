namespace MirrorMakerIICore.Infra
{
    internal class OperationSummary
    {
        public List<string>? FilesToDelete, FoldersToMaybeDelete, FoldersToMaybeCreate;
        public List<FileReference>? FilesToMove, FilesToCopy;
    }
}
