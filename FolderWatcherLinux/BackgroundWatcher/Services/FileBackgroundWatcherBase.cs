using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDebitBackgroundServices.Services
{
    public class HandleWatcherObjects
    {
        public PhysicalFileProvider _fileProvider;
        public string _pattern;
    }
    public class FileBackgroundWatcherBase : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void WatchFileChanges(PhysicalFileProvider fileProvider, string pattern)
        {
            var changeToken = fileProvider.Watch(pattern);

            var handleWatcherObjects = new HandleWatcherObjects
            {
                _fileProvider = fileProvider,
                _pattern = pattern
            };

            changeToken.RegisterChangeCallback(ProcessFileState, handleWatcherObjects);
        }

        protected virtual void ProcessFileState(object watcherObjects)
        {
            var handleWatcherObjects = (HandleWatcherObjects)watcherObjects;
            WatchFileChanges(handleWatcherObjects._fileProvider, handleWatcherObjects._pattern);
        }

        protected bool CanRead(string path)
        {
            FileStream fs;

            try
            {
                Thread.Sleep(1000);
                fs = File.Open(path, FileMode.Open, FileAccess.Read);
                fs.Close();

                return true;
            }
            catch (SecurityException)
            {
                throw;
            }
            catch
            {
                return false;
            }
        }
    }
}
