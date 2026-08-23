namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class PathResolver
{
    public string ConnectionPath { get; }

    public string CurrentPath { get; private set; }

    public PathResolver(string connectionPath)
    {
        ConnectionPath = NormalizePath(connectionPath);
        CurrentPath = "/";
    }

    public string NormalizePath(string path)
    {
        string[] pathParts = path.Split('/');
        var stack = new Stack<string>();

        foreach (string part in pathParts)
        {
            if (part == "." || string.IsNullOrEmpty(part))
                continue;

            if (part == "..")
            {
                if (stack.Count > 0 && stack.Peek() != "..")
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push("..");
                }

                continue;
            }

            stack.Push(part);
        }

        var normalizedPathParts = stack.ToList();
        normalizedPathParts.Reverse();

        string resultPath = string.Empty;
        if (normalizedPathParts.Count > 0)
            resultPath = normalizedPathParts[0];

        return normalizedPathParts
            .Skip(1)
            .Aggregate(resultPath, (current, part) => current + "/" + part);
    }

    public string ChangeFileName(string path, string newName)
    {
        return NormalizePath(GetFileDirectory(path) + '/' + newName);
    }

    public string ChangeFilePath(string sourcePath, string newDirectory)
    {
        return NormalizePath(newDirectory + '/' + GetFileName(sourcePath));
    }

    public bool PathOutOfSystem(string path)
    {
        string modifiedPath = path;
        if (!IsAbsolutePath(path))
            modifiedPath = CurrentPath + "/" + path;
        modifiedPath = NormalizePath(modifiedPath);

        string[] pathParts = modifiedPath.Split('/');

        return pathParts[0] == "..";
    }

    public bool IsAbsolutePath(string path) => path.StartsWith('/');

    public string ResolvePath(string path)
    {
        if (IsAbsolutePath(path))
            return NormalizePath(ResolveAbsolutePath(path));

        return NormalizePath(ResolveRelativePath(path));
    }

    public string ResolveAbsolutePath(string path) => ConnectionPath + path;

    public string ResolveRelativePath(string path) => ConnectionPath + CurrentPath + "/" + path;

    public string GetFileDirectory(string path) => path.Substring(0, path.LastIndexOf('/'));

    public string GetFileName(string path) => path.Substring(path.LastIndexOf('/') + 1);

    public void SetCurrentPath(string path)
    {
        string pathChange = "/" + NormalizePath(path);

        if (IsAbsolutePath(path))
        {
            CurrentPath = pathChange;
        }
        else
        {
            CurrentPath += pathChange;
        }
    }
}