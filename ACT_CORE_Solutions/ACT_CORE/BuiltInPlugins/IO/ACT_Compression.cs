using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCompress;
using SharpCompress.Archives.Zip;
using SharpCompress.Writers;
using ACT.Core.Extensions;
using SharpCompress.Archives;
using Org.BouncyCastle.Utilities.Encoders;
using SharpCompress.Readers;
using ACT.Core.Interfaces.IO;
using SharpCompress.Common;

namespace ACT.Core.BuiltInPlugins.IO
{
    public class ACT_Compression : ACT.Core.Interfaces.IO.I_Compression
    {
        private SharpCompress.Common.CompressionType? CheckAndReturnType(string CompressionType)
        {
            if (AvailableCompressionTypes.Contains(CompressionType) == false)
            {
                _.LogBasicInfo("Invalid Compression Type: " + CompressionType);
                return null;
            }
            SharpCompress.Common.CompressionType _CompressionType = (SharpCompress.Common.CompressionType)Enum.Parse(typeof(SharpCompress.Common.CompressionType), CompressionType);
            return _CompressionType;
        }



        public string[] AvailableCompressionTypes
        {
            get { return ACT_Status.SupportedCompressionTypes; }
        }

        #region Individual File Manipulation
        public void AddFileToZip(string FilePathToAdd, string ZipFilePath, string CompressionType)
        {
            throw new NotImplementedException();
        }
        public void RemoveFileFromZip(string VirtualFilePathToRemove, string ZipFilePath, string CompressionType)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Returns the Compressed Byte Array Including the additional information
        /// </summary>
        /// <param name="Data">Primary Data To Include</param>
        /// <param name="CompressionType">Type of Compression To Use</param>
        /// <param name="AdditionalInfo">Additional Byte[] Data</param>
        /// <returns>Null if Fails (Check Log), Exception Thrown on Severe Error, compresssed byte[]</returns>
        public byte[] CompressData(byte[] Data, string CompressionType, Dictionary<string, byte[]> AdditionalInfo)
        {

            string _tmpFilePath = ACT_Status.TempCompressionFilePath.EnsureDirectoryFormat();

            if (ACT.Core.ACT_Status.CheckPath(_tmpFilePath) == false)
            {
                var _ex = new DirectoryNotFoundException(_tmpFilePath);
                _.LogFatalError("Unable to CompressData in: ACT.Core.BuiltInPlugins.IO.ACT_Compression.CompressData(Byte[]...)", _ex);
                throw _ex;
            }

            _tmpFilePath += Guid.NewGuid().ToString().Replace("-", "").Substring(3, 18) + ".acd";

            try
            {
                using (var archive = ZipArchive.Create())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        memoryStream.Write(Data, 0, Data.Length);
                        archive.AddEntry("RawData", memoryStream, false);
                    }

                    // Foreacg String In AdditionalInfo
                    foreach (string tmpKey in AdditionalInfo.Keys)
                    {
                        if (AdditionalInfo[tmpKey] == null && AdditionalInfo[tmpKey].Length > 0)
                        {
                            archive.AddEntry(tmpKey, new MemoryStream(AdditionalInfo[tmpKey]), false);
                        }
                    }

                    SharpCompress.Common.CompressionType? _CompressionType = CheckAndReturnType(CompressionType);
                    if (_CompressionType != null)
                    {
                        _.LogBasicInfo("Compression Type Not Supported: " + CompressionType);
                        return null;
                    }

                    //reset memoryStream to be usable now
                    using (var tmpReturn = new MemoryStream())
                    {
                        archive.SaveTo(tmpReturn, new WriterOptions(_CompressionType.Value));
                        return tmpReturn.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                _.LogFatalError("Unable to CompressData in: ACT.Core.BuiltInPlugins.IO.ACT_Compression.CompressData(Byte[]...)", ex);
                throw;
            }
        }

        /// <summary>
        /// Compress File To Byte Array
        /// </summary>
        /// <param name="FileToCompress"></param>
        /// <param name="CompressionType"></param>
        /// <param name="AdditionalInfo"></param>
        /// <returns>byte[] On Success - Null or Exception on Failure</returns>
        public bool CompressFile(string FileToCompress, string DestinationFileName, string CompressionType)
        {
            if (FileToCompress.NullOrEmpty() || FileToCompress.FileExists() == false)
            {
                _.LogFatalError("Unable to CompressData in: ACT.Core.BuiltInPlugins.IO.ACT_Compression.CompressData(string FileToCompress...)", new FileNotFoundException(FileToCompress + " - Doesn't Exist"));
                return false;
            }

            var _FileBytes = System.IO.File.ReadAllBytes(FileToCompress);

            try
            {
                var _FileOutputBytes = CompressData(_FileBytes, CompressionType, new Dictionary<string, byte[]>());

                try
                {
                    using (BinaryWriter bwStream = new BinaryWriter(new FileStream(DestinationFileName, FileMode.OpenOrCreate)))
                    {
                        bwStream.Write(_FileOutputBytes, 0, _FileOutputBytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    _.LogFatalError("Unable to Write Binary Data to the File: " + DestinationFileName , ex);
                    throw;
                }
            }
            catch(Exception ex)
            {
                _.LogFatalError("Unable to Write Binary Data to the File: " + DestinationFileName, ex);
                throw;
            }

            return true;
        }

        /// <summary>
        /// Compress a Folder to a Byte Array
        /// </summary>
        /// <param name="FolderToCompress"></param>
        /// <param name="CompressionType"></param>
        /// <param name="AdditionalInfo"></param>
        /// <returns></returns>
        public byte[] CompressFolder(string FolderToCompress, string CompressionType, Dictionary<string, byte[]> AdditionalInfo)
        {
            SharpCompress.Common.CompressionType? _CompressionType = CheckAndReturnType(CompressionType);

            if (_CompressionType != null)
            {
                _.LogBasicInfo("Compression Type Not Supported: " + CompressionType);
                return null;
            }

            if (FolderToCompress.NullOrEmpty() || FolderToCompress.DirectoryExists(false) == false)
            {
                _.LogBasicInfo("Folder Missing Or Security Denied: " + FolderToCompress);
                return null;
            }

            try
            {
                using (var archive = ZipArchive.Create())
                {
                    WriterOptions _tmpNew = new WriterOptions(_CompressionType.Value);
                    byte[] _tmpReturn = null;

                    archive.AddAllFromDirectory(FolderToCompress.EnsureDirectoryFormat());

                    // Foreacg String In AdditionalInfo
                    foreach (string tmpKey in AdditionalInfo.Keys)
                    {
                        if (AdditionalInfo[tmpKey] != null || AdditionalInfo[tmpKey].Length > 0)
                        {
                            archive.AddEntry(tmpKey, new MemoryStream(AdditionalInfo[tmpKey]), false);
                        }
                    }

                    using (var memStream = new MemoryStream())
                    {
                        archive.SaveTo(memStream, _tmpNew);
                        _tmpReturn = memStream.ToArray();
                    }

                    return _tmpReturn;
                }
            }
            catch (Exception ex)
            {
                _.LogFatalError("Serious error compressing the folder: " + FolderToCompress + " - Using Compressing Type: " + CompressionType, ex);
                return null;
            }
        }

        /// <summary>
        /// Compress Folder Into a File as Specified
        /// </summary>
        /// <param name="FolderToCompress"></param>
        /// <param name="OutputFileNameFullPath"></param>
        /// <param name="CompressionType"></param>
        /// <param name="AdditionalInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CompressFolder(string FolderToCompress, string OutputFileNameFullPath, string CompressionType, Dictionary<string, byte[]> AdditionalInfo)
        {
            var _tmpByteArray = CompressFolder(FolderToCompress, CompressionType, AdditionalInfo);

            if (_tmpByteArray == null || _tmpByteArray.Length == 0) { return false; }

            var _BasePath = OutputFileNameFullPath.GetDirectoryFromFileLocation().EnsureDirectoryFormat(true);

            if (_BasePath.DirectoryExists(true) == false)
            {
                _.LogFatalError("Unable To Write To the Directory", new DirectoryNotFoundException("Unable To Locate and / Or Create: " + _BasePath));
                return false;
            }


            try
            {
                using (BinaryWriter bwStream = new BinaryWriter(new FileStream(OutputFileNameFullPath, FileMode.OpenOrCreate)))
                {
                    bwStream.Write(_tmpByteArray, 0, _tmpByteArray.Length);
                }
            }
            catch (Exception ex)
            {
                _.LogFatalError("Unable to Write Binary Data to the File: " + OutputFileNameFullPath, ex);
                throw;
            }

            return true;

        }

        /// <summary>
        /// Decompress the CompressionType
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="CompressionType"></param>
        /// <param name="AdditionalInfo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] DeCompressData(byte[] Data, string CompressionType)
        {
            byte[] _tmpReturn;

            using (var memstream = new MemoryStream(Data))
            {
                using (var outMemStream = new MemoryStream())
                {
                    using (var reader = ReaderFactory.Open(memstream))
                    {
                        while (reader.MoveToNextEntry())
                        {
                            reader.WriteEntryTo(outMemStream);

                        }
                    }

                    _tmpReturn = outMemStream.ToArray();
                }
            }

            return _tmpReturn;
        }

        /// <summary>
        /// Decompress a Archive to a Folder
        /// </summary>
        /// <param name="FileToDeCompress"></param>
        /// <param name="Destination"></param>
        /// <param name="CompressionType"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeCompressFileToDisk(string FileToDeCompress, string Destination, string CompressionType)
        {
            int _tmpReturn = 0;
            using (Stream stream = File.OpenRead(FileToDeCompress))
            {
                using (var reader = ReaderFactory.Open(stream))
                {
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            Console.WriteLine(reader.Entry.Key);
                            reader.WriteEntryToDirectory(Destination.EnsureDirectoryFormat(), new ExtractionOptions()
                            {                                
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                            _tmpReturn++;
                        }
                    }
                }
            }

            return _tmpReturn;
        }

        byte[] I_Compression.CompressFile(string FileToCompress, string CompressionType)
        {
            throw new NotImplementedException();
        }
    }
}
