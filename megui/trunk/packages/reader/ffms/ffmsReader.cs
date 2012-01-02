﻿// ****************************************************************************
// 
// Copyright (C) 2005-2012  Doom9 & al
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Windows.Forms;

using MeGUI.core.util;

namespace MeGUI
{
    public class ffmsFileFactory : IMediaFileFactory
    {

        #region IMediaFileFactory Members

        public IMediaFile Open(string file)
        {
            return new ffmsFile(file, null);
        }

        public int HandleLevel(string file)
        {
            if (file.ToLower().EndsWith(".ffindex"))
                return 12;
            return -1;
        }

        #endregion

        #region IIDable Members

        public string ID
        {
            get { return "ffms"; }
        }

        #endregion
    }

    /// <summary>
    /// Summary description for ffmsReader.
    /// </summary>
    public class ffmsFile : IMediaFile
    {
        private AvsFile reader;
        private string fileName;
        private MediaFileInfo info;

        /// <summary>
        /// initializes the ffms reader
        /// </summary>
        /// <param name="fileName">the FFMSIndex source file file that this reader will process</param>
        /// <param name="fileName">the FFMSIndex index file that this reader will process</param>
        public ffmsFile(string fileName, string indexFile)
        {
            string strScript = "";

            if (!fileName.ToLower().EndsWith(".ffindex") 
                && !String.IsNullOrEmpty(indexFile) 
                && !indexFile.ToLower().EndsWith(".ffindex"))
            {
                MessageBox.Show("No ffindex file: " + fileName, "Error processing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!String.IsNullOrEmpty(indexFile))
                this.fileName = fileName;
            else
                this.fileName = fileName.Substring(0, fileName.Length - 8);
            string strPath = Path.GetDirectoryName(MainForm.Instance.Settings.FFMSIndexPath);
            string strDLL = Path.Combine(strPath, "ffms2.dll");
            strScript = "LoadPlugin(\"" + strDLL + "\")\r\nFFVideoSource(\"" + this.fileName + "\"" + (!string.IsNullOrEmpty(indexFile) ? ", cachefile=\"" + indexFile + "\"" : String.Empty) + (MainForm.Instance.Settings.FFMSThreads > 0 ? ", threads=" + MainForm.Instance.Settings.FFMSThreads : String.Empty) + ")" + VideoUtil.getAssumeFPS(0, this.fileName);
            reader = AvsFile.ParseScript(strScript);
            info = reader.Info.Clone();
            if (File.Exists(this.fileName))
            {
                MediaInfoFile oInfo = new MediaInfoFile(this.fileName);
                info.DAR = oInfo.Info.DAR;
            }
        }

        #region properties
        public MediaFileInfo Info
        {
            get { return info; }
        }
        #endregion

        #region IMediaFile Members

        public bool CanReadVideo
        {
            get { return reader.CanReadVideo; }
        }

        public bool CanReadAudio
        {
            get { return false; }
        }

        public IVideoReader GetVideoReader()
        {
            return reader.GetVideoReader();
        }

        public IAudioReader GetAudioReader(int track)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            reader.Dispose();
        }

        #endregion
    }
}

