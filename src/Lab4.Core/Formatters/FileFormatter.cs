namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;

public class FileFormatter : IFileFormatter
{
    private readonly string _directoryPrefix;
    private readonly string _filePrefix;
    private readonly string _horizontalDelimiter;
    private readonly int _width;

    private FileFormatter(string directoryPrefix, string filePrefix, string horizontalDelimiter, int width)
    {
        _directoryPrefix = directoryPrefix;
        _filePrefix = filePrefix;
        _horizontalDelimiter = horizontalDelimiter;
        _width = width;
    }

    public string FormatDirectory(string name, int depth)
    {
        return $"{string.Join(" ", Enumerable.Repeat(string.Empty, depth * _width))}" +
               $"{string.Join(_horizontalDelimiter, Enumerable.Repeat(string.Empty, _width))}{_directoryPrefix}: {name}";
    }

    public string FormatFile(string name, int depth)
    {
        return $"{string.Join(" ", Enumerable.Repeat(string.Empty, depth * _width))}" +
               $"{string.Join(_horizontalDelimiter, Enumerable.Repeat(string.Empty, _width))}{_filePrefix}: {name}";
    }

    public class Builder
    {
        private string _directoryPrefix = "D";
        private string _filePrefix = "F";
        private string _horizontalDelimiter = "-";
        private int _width = 4;

        public Builder WithDirectoryPrefix(string directoryPrefix)
        {
            _directoryPrefix = directoryPrefix;
            return this;
        }

        public Builder WithFilePrefix(string filePrefix)
        {
            _filePrefix = filePrefix;
            return this;
        }

        public Builder WithHorizontalDelimiter(string delimiter)
        {
            _horizontalDelimiter = delimiter;
            return this;
        }

        public Builder WithWidth(int width)
        {
            _width = width;
            return this;
        }

        public FileFormatter Build()
        {
            return new FileFormatter(_directoryPrefix, _filePrefix, _horizontalDelimiter,  _width);
        }
    }
}