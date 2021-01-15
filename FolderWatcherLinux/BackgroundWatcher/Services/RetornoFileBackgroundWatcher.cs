using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDebitBackgroundServices.Services
{
    public class RetornoFileBackgroundWatcher : FileBackgroundWatcherBase
    {
        private string _workDirectory;
        private const string _autoDebitFolder = "AutoDebit";
        private const string _bankFolder = "BancoBrasil";
        private const string _retornoFolder = "Retorno";
        private const string _processedFilesFolder = "ProcessedFiles";
        private const int _taskTimeout = 600000;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _workDirectory = Path.Combine(Directory.GetCurrentDirectory(), _autoDebitFolder, _bankFolder);
            var directoryPath = Path.Combine(_workDirectory, _retornoFolder, _processedFilesFolder);
            Directory.CreateDirectory(directoryPath);

            try
            {
                var fileProvider = new PhysicalFileProvider(Path.Combine(directoryPath, ".."));
                
                var handleWatcherObjects = new HandleWatcherObjects
                {
                    _fileProvider = fileProvider,
                    _pattern = "*.*"
                };

                ProcessFileState(handleWatcherObjects);
                await Task.CompletedTask;
            }
            catch (Exception)
            {
            }
        }

        protected override void ProcessFileState(object watcherObjects)
        {
            base.ProcessFileState(watcherObjects);

            var remessaDirectoryPath = Path.Combine(_workDirectory, _retornoFolder);

            try
            {
                var directoryInfo = new DirectoryInfo(remessaDirectoryPath);
                ProcessRemessaFiles(directoryInfo).Wait();
            }
            catch (Exception e)
            {
            }
        }

        private async Task ProcessSingleRemessaFile(FileInfo fileInfo)
        {
            while (!CanRead(fileInfo.FullName)) ;

            var fullName = Path.Combine(fileInfo.DirectoryName, _processedFilesFolder, fileInfo.Name);

            using (var fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                fs.Close();
                //TODO validation of file ...

                if (File.Exists(fullName))
                    File.Delete(fullName);

                File.Move(fileInfo.FullName, fullName);

                await Task.CompletedTask;
            }
        }

        private async Task ProcessRemessaFiles(DirectoryInfo directoryInfo)
        {
            foreach (var fileInfo in directoryInfo.GetFiles())
                await ProcessSingleRemessaFile(fileInfo);
        }
    }
}
