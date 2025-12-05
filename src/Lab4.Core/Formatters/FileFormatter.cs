namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public class FileFormatter
{
    private readonly string _directoryPrefix;
    private readonly string _filePrefix;
    private readonly int _padding;

    private FileFormatter(string directoryPrefix, string filePrefix, int padding)
    {
        _directoryPrefix = directoryPrefix;
        _filePrefix = filePrefix;
        _padding = padding;
    }

    public string FormatDirectory(string name, int depth, int maxDepth)
    {
        if (depth > maxDepth || depth < 0) return string.Empty;

        return $"{string.Join(" ", Enumerable.Repeat(string.Empty, depth * (_padding + 1)))}{_directoryPrefix} {name}\n";
    }

    public string FormatFile(string name, int depth, int maxDepth)
    {
        if (depth > maxDepth || depth < 0) return string.Empty;

        return $"{string.Join(" ", Enumerable.Repeat(string.Empty, depth * (_padding + 1)))}{_filePrefix} {name}\n";
    }

    public class FileFormatterBuilder
    {
        private string _directoryPrefix = "D";
        private string _filePrefix = "F";
        private int _padding = 4;

        public FileFormatterBuilder WithDirectoryPrefix(string directoryPrefix)
        {
            _directoryPrefix = directoryPrefix;
            return this;
        }

        public FileFormatterBuilder WithFilePrefix(string filePrefix)
        {
            _filePrefix = filePrefix;
            return this;
        }

        public FileFormatterBuilder WithFilePrefix(int padding)
        {
            _padding = padding;
            return this;
        }

        public FileFormatter Build()
        {
            return new FileFormatter(_directoryPrefix, _filePrefix, _padding);
        }
    }
}