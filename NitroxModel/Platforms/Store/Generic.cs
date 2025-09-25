using System;
using System.IO;
using System.Threading.Tasks;
using NitroxModel.Discovery.Models;
using NitroxModel.Helper;
using NitroxModel.Platforms.OS.Shared;
using NitroxModel.Platforms.Store.Interfaces;

namespace NitroxModel.Platforms.Store;

public sealed class Generic : IGamePlatform
{
    public string Name => "Generic";
    public Platform Platform => Platform.NONE;

    public bool OwnsGame(string gameDirectory)
    {
        // Generic platform accepts any game directory as a fallback
        return Directory.Exists(gameDirectory);
    }

    public Task<ProcessEx> StartPlatformAsync()
    {
        // No platform to start for direct execution
        return Task.FromResult<ProcessEx>(null);
    }

    public string GetExeFile()
    {
        // No platform executable for direct execution
        return null;
    }

    public async Task<ProcessEx> StartGameAsync(string pathToGameExe, string launchArguments)
    {
        return await Task.FromResult(
            ProcessEx.Start(
                pathToGameExe,
                [(NitroxUser.LAUNCHER_PATH_ENV_KEY, NitroxUser.LauncherPath)],
                Path.GetDirectoryName(pathToGameExe),
                launchArguments
            )
        );
    }
}