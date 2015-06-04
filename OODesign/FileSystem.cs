/*
 Design a File System 
*/
class constants {
    int numberOfDataBlocks = 10;
    int dataBlockSize = 10;
};

class DataBlocks {
	char[,] data = new char [numberOfDataBlocks, dataBlockSize];
    int blockNumber, writeIndex;
};

class MetaData {
	DateTime createdTime;
	DateTime modifiedTime;
	DateTime lastAccessTime;
	
	int properties;
	int size;
};

class INode {
	MetaData info;
	LinkedList<DataBlocks> datablocks;
};

interface IFile {
	string name;
    private LinkedList<INode> nodes;
    private Dictionary<string, INode> fileINodeMap;

    bool create();
    int open();
    int write();
    void close();
}

class File : IFile {
    private string extension;

	bool create();
	int open();
	char[] read();
	int write();
    void close();
};

class Directory : IFile {
	LinkedList<IFile> children;

	bool create();
	int open();
	bool add(IFile file);
    bool remove(IFile file);
    bool rename(IFile file);
};

class FileSystem {
    Directory root;

    void initFileSystem() { }
    LinkeList<IFile> search(string searchString) { }
    void mount(FileSystem foo) { }
    void unmount(FileSystem foo) { }
};