# MirrorMakerII
Remake of my 2007 original tool Mirror Maker, just faster. The original MirrorMaker for at least a year was supporting an entire file server backups over certain government LAN. ON and OFF, I continued to use it in my home LAN, to backup files from several machines on the NAS. However it was written with 2007 realities in mind, so a few things were giving me a headache. It needed some _major_ corrections, but because it was written in VB.Net, the only way was to rewrite it from scratch.

## Purpose
The Mirror Maker is a rsync-like app, with quirks.

* It supports one-way sync folder A --> folder B.
* It supports incremental nested backup of different depths. For example, if you have 7-level backup, and you run the tool daily, you will be able to restore files deleted up to a week ago.
* It supports 1-->1 as well as batch operations
* It can work over network mapped drives and network paths - anything Windows can CreateFile() on.
* It uses the Core of SizeScanner, which operates via NT-level functions, and thus is about 4 times faster than traditional file enumeration practices.
* It has both console and GUI
* It has a convenient log viewer
* It shows progress in the taskbar, and when launched in automatic mode would not take the focus, and auto-close once done

## Risks
The current version of MMII is used on the daily basis in my home LAN backing up files across several machines. With the exception of manual cancellation change, it was running for two months without any issues. However, of course, the software is supplied "as is".

## Manual
https://github.com/AgentMC/MirrorMakerII/blob/bc1547ea8598cd2fe680439045ff6c661f55b896/MirrorMakerIICore/Infra/InputParameters.cs#L63
