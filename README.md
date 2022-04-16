# MirrorMakerII
Remake of my 2007 original tool Mirror Maker.

## Purpose
The Mirror Maker is a rsync-like app, with quirks.

* It supports one-way sync folder A --> folder B.
* It supports incremental nested backup of different depths. For example, if you have 7-level backup, and you run the tool daily, you will be able to restore files deleted up to a week ago.
* It supports 1-->1 as well as batch operations
* It can work over network mapped drives and network paths - anything Windows can CreateFile() on.
* It uses the Core of SizeScanner, which operates via NT-level functions, and thus is about 4 times faster than traditional file enumeration practices.
* It *will* have both console (done) and GUI
* It *will* have a convenient log viewer
* It *will* show progress in the taskbar, and when launched in automatic mode would not take the focus
