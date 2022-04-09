using MirrorMakerII;

//string source = @"D:\hackd",
//       destination = @"Z:\Backup\Mike";
string source = @"D:\hackd\Pix",
       destination = @"C:\Temp";
int    backupLevel = 1;

MMLogger l = new(null);

l.Start(source, destination, backupLevel);

(var fsSrc, var fsDst) = Scanner.Scan(source, destination, l);
(var operation, var backupFolders) = Comparer.Compare(fsSrc, fsDst, l);
new OperationRunner(l).Run(operation, backupFolders, backupLevel, destination);
