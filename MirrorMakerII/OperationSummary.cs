namespace MirrorMakerII
{
    internal class OperationSummary
    {
        public List<string>? FilesToDelete, FoldersToMaybeDelete, FoldersToMaybeCreate;
        public Dictionary<string, string>? FilesToMove, FilesToCopy;
    }
}
