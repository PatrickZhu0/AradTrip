using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Tenmove;
using UnityEngine;
using UnityEngine.Networking;

namespace GameClient
{
	// Token: 0x02001CC7 RID: 7367
	public class UploadLog
	{
		// Token: 0x17001DC4 RID: 7620
		// (get) Token: 0x06012127 RID: 74023 RVA: 0x0054A132 File Offset: 0x00548532
		public static UploadLog Instance
		{
			get
			{
				if (UploadLog.instance == null)
				{
					UploadLog.instance = new UploadLog();
				}
				return UploadLog.instance;
			}
		}

		// Token: 0x06012128 RID: 74024 RVA: 0x0054A150 File Offset: 0x00548550
		private void _Clear()
		{
			string path = Path.Combine(Singleton<ExceptionManager>.instance.LoggerFilePath, UploadLog.CRASH_LOG_SUB_PATH);
			if (Directory.Exists(path))
			{
				foreach (string path2 in Directory.GetFiles(path))
				{
					File.Delete(path2);
				}
			}
			this.mLogInfos = null;
			if (this.ZipFileInfos != null)
			{
				this.ZipFileInfos.Clear();
				this.ZipFileInfos = null;
			}
			this.mCurrentZipFileIdx = 0;
		}

		// Token: 0x17001DC5 RID: 7621
		// (get) Token: 0x06012129 RID: 74025 RVA: 0x0054A1CD File Offset: 0x005485CD
		// (set) Token: 0x0601212A RID: 74026 RVA: 0x0054A1D5 File Offset: 0x005485D5
		public UploadingCompressState State { get; private set; }

		// Token: 0x17001DC6 RID: 7622
		// (get) Token: 0x0601212B RID: 74027 RVA: 0x0054A1DE File Offset: 0x005485DE
		// (set) Token: 0x0601212C RID: 74028 RVA: 0x0054A1E6 File Offset: 0x005485E6
		public string FilePathRoot { get; private set; }

		// Token: 0x17001DC7 RID: 7623
		// (get) Token: 0x0601212D RID: 74029 RVA: 0x0054A1EF File Offset: 0x005485EF
		// (set) Token: 0x0601212E RID: 74030 RVA: 0x0054A1F7 File Offset: 0x005485F7
		public string ZipFileRoot { get; private set; }

		// Token: 0x17001DC8 RID: 7624
		// (get) Token: 0x0601212F RID: 74031 RVA: 0x0054A200 File Offset: 0x00548600
		// (set) Token: 0x06012130 RID: 74032 RVA: 0x0054A208 File Offset: 0x00548608
		public IList<UploadLog.UploadZipFileInfo> ZipFileInfos { get; private set; }

		// Token: 0x06012131 RID: 74033 RVA: 0x0054A214 File Offset: 0x00548614
		public void Upload()
		{
			Debug.Log(Application.persistentDataPath);
			this.State = UploadingCompressState.None;
			this.mLogInfos = new UploadLog.UploadLogInfo[]
			{
				new UploadLog.UploadLogInfo(UploadLogType.Exception, new string[]
				{
					UploadLog.EXCEPTION_LOG_PATTERN
				}, null),
				new UploadLog.UploadLogInfo(UploadLogType.Crash, null, new string[]
				{
					Path.Combine(Singleton<ExceptionManager>.instance.LoggerFilePath, UploadLog.CRASH_LOG_SUB_PATH)
				})
			};
			string crashpath = Path.Combine(Singleton<ExceptionManager>.instance.LoggerFilePath, UploadLog.CRASH_LOG_SUB_PATH);
			if (this.IsVaildCrash(crashpath))
			{
				this._Start(Singleton<ExceptionManager>.instance.LoggerFilePath, this.mLogInfos);
			}
		}

		// Token: 0x06012132 RID: 74034 RVA: 0x0054A2B4 File Offset: 0x005486B4
		private bool IsVaildCrash(string crashpath)
		{
			if (!Directory.Exists(crashpath))
			{
				return false;
			}
			string[] files = Directory.GetFiles(crashpath);
			if (files.Length > 10)
			{
				return false;
			}
			foreach (string fileName in files)
			{
				FileInfo fileInfo = new FileInfo(fileName);
				if (fileInfo.Length > this.MAX_DUMP_SIZE)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06012133 RID: 74035 RVA: 0x0054A318 File Offset: 0x00548718
		private void _Start(string filePathRoot, UploadLog.UploadLogInfo[] uploadLogInfos)
		{
			this.FilePathRoot = filePathRoot;
			this.ZipFileRoot = this._getRootPath();
			this._InitFileInfos(uploadLogInfos);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._Process());
		}

		// Token: 0x06012134 RID: 74036 RVA: 0x0054A348 File Offset: 0x00548748
		private void _Stop()
		{
			MonoSingleton<GameFrameWork>.instance.StopCoroutine(this._Process());
			if (this.State == UploadingCompressState.Compressing)
			{
				if (this.mWaitCompressFile != null)
				{
					this.mWaitCompressFile.Abort();
					this.mWaitCompressFile = null;
				}
			}
			else if (this.State == UploadingCompressState.Uploading && this.mWaitUploadFile != null)
			{
				this.mWaitUploadFile.Abort();
				this.mWaitUploadFile = null;
			}
		}

		// Token: 0x06012135 RID: 74037 RVA: 0x0054A3BC File Offset: 0x005487BC
		private string _getRootPath()
		{
			string empty = string.Empty;
			return Path.Combine(Application.persistentDataPath, this.skDirName);
		}

		// Token: 0x06012136 RID: 74038 RVA: 0x0054A3E4 File Offset: 0x005487E4
		private string _getZipFilePath(UploadLogType logType)
		{
			string text = "InvalidPlatform";
			string text2 = "InvalidSDKChannel";
			string text3 = "InvalidServerName";
			string text4 = "InvalidAccountID";
			string text5 = "InvalidRoleID";
			string currentDateTime = TMPathUtil.GetCurrentDateTime();
			string text6 = (logType <= UploadLogType.Exception) ? string.Empty : logType.ToString();
			try
			{
				text = Application.platform.ToString();
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat(ex.ToString(), new object[0]);
			}
			try
			{
				text2 = Global.Settings.sdkChannel.ToString();
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat(ex2.ToString(), new object[0]);
			}
			try
			{
				text3 = ClientApplication.playerinfo.serverID.ToString();
			}
			catch (Exception ex3)
			{
				Logger.LogErrorFormat(ex3.ToString(), new object[0]);
			}
			try
			{
				text4 = ClientApplication.playerinfo.accid.ToString();
			}
			catch (Exception ex4)
			{
				Logger.LogErrorFormat(ex4.ToString(), new object[0]);
			}
			try
			{
				text5 = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin().roleId.ToString();
			}
			catch (Exception ex5)
			{
				Logger.LogErrorFormat(ex5.ToString(), new object[0]);
			}
			string text7 = string.Format("{0}_{1}_{2}_{3}_{4}_{5}.zip", new object[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				currentDateTime
			});
			if (!string.IsNullOrEmpty(text6))
			{
				text7 = string.Format("{0}_{1}_{2}", text6, Singleton<VersionManager>.GetInstance().Version(), text7);
			}
			return text7;
		}

		// Token: 0x06012137 RID: 74039 RVA: 0x0054A5D4 File Offset: 0x005489D4
		private void _InitFileInfos(UploadLog.UploadLogInfo[] uploadLogInfos)
		{
			if (uploadLogInfos == null)
			{
				return;
			}
			if (this.ZipFileInfos == null)
			{
				this.ZipFileInfos = new List<UploadLog.UploadZipFileInfo>();
			}
			foreach (UploadLog.UploadLogInfo uploadLogInfo in uploadLogInfos)
			{
				if (uploadLogInfo != null)
				{
					string text = Path.Combine(this.ZipFileRoot, this._getZipFilePath(uploadLogInfo.logType));
					string[] filePaths = this._GetFilterFiles(uploadLogInfo);
					this.ZipFileInfos.Add(new UploadLog.UploadZipFileInfo(text, filePaths));
					TMPathUtil.MakeParentRootExist(text);
				}
			}
		}

		// Token: 0x06012138 RID: 74040 RVA: 0x0054A65C File Offset: 0x00548A5C
		private string[] _GetFilterFiles(UploadLog.UploadLogInfo logInfo)
		{
			if (logInfo == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(this.FilePathRoot) || !Directory.Exists(this.FilePathRoot))
			{
				return null;
			}
			List<string> list = new List<string>();
			if (logInfo.filePatterns != null)
			{
				for (int i = 0; i < logInfo.filePatterns.Length; i++)
				{
					string text = logInfo.filePatterns[i];
					if (!string.IsNullOrEmpty(text))
					{
						string[] files = TMFile.GetFiles(this.FilePathRoot, text, false);
						if (files != null && files.Length > 0)
						{
							list.AddRange(files);
						}
					}
				}
			}
			if (logInfo.fileSubPaths != null)
			{
				for (int j = 0; j < logInfo.fileSubPaths.Length; j++)
				{
					string text2 = logInfo.fileSubPaths[j];
					if (!string.IsNullOrEmpty(text2) && Directory.Exists(text2))
					{
						string[] files2 = TMFile.GetFiles(text2, "*", true);
						list.AddRange(files2);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x06012139 RID: 74041 RVA: 0x0054A76C File Offset: 0x00548B6C
		private IEnumerator _Process()
		{
			if (this.ZipFileInfos == null || this.ZipFileInfos.Count <= 0)
			{
				Logger.LogErrorFormat("[CompressAndUploading] Compress Error", new object[0]);
				yield break;
			}
			while (this.mCurrentZipFileIdx < this.ZipFileInfos.Count)
			{
				UploadLog.UploadZipFileInfo currentZipFileInfo = this.ZipFileInfos[this.mCurrentZipFileIdx];
				if (currentZipFileInfo == null)
				{
					this.mCurrentZipFileIdx++;
				}
				else
				{
					this.mWaitCompressFile = new WaitCompressFile(currentZipFileInfo.zipFilePath, this.FilePathRoot, currentZipFileInfo.filterFilePaths);
					this.State = UploadingCompressState.Compressing;
					while (this.mWaitCompressFile.MoveNext())
					{
						yield return null;
					}
					if (!this.mWaitCompressFile.IsSuccessFinish())
					{
						this.State = UploadingCompressState.Error;
						Logger.LogErrorFormat("[CompressAndUploading] Compress Error", new object[0]);
					}
					else
					{
						this.mWaitCompressFile.DeleteCompressedFiles();
					}
					this.mCurrentZipFileIdx++;
					yield return null;
				}
			}
			IList<string> zipFiles = TMFile.GetFiles(this.ZipFileRoot, "*.zip", true);
			for (int i = 0; i < zipFiles.Count; i++)
			{
				string currentZipFilePath = zipFiles[i];
				byte[] payload = TMFile.ReadAllBytes(currentZipFilePath);
				string url = string.Format("{0}?file={1}&dataString=fk&deviceId=fk&serverId=fk&lastMoveLogTime=fk", "http://39.108.138.140:59969", Path.GetFileName(currentZipFilePath));
				this.mWaitUploadFile = new UnityWebRequest(url, "POST");
				UploadHandler uploader = new UploadHandlerRaw(payload);
				this.mWaitUploadFile.SetRequestHeader("Content-Type", "application/json");
				this.mWaitUploadFile.uploadHandler = uploader;
				this.mWaitUploadFile.Send();
				float time = 0f;
				ulong lastByte = 0UL;
				this.State = UploadingCompressState.Uploading;
				while (!this.mWaitUploadFile.isDone && time < 10f)
				{
					yield return null;
					float rate = this.mWaitUploadFile.uploadProgress / (float)zipFiles.Count + (float)i * 1f / (float)zipFiles.Count;
					if (lastByte == this.mWaitUploadFile.uploadedBytes)
					{
						time += Time.deltaTime;
					}
					else
					{
						lastByte = this.mWaitUploadFile.uploadedBytes;
						time = 0f;
					}
				}
				if (!this.mWaitUploadFile.isDone && time >= 10f)
				{
					this.State = UploadingCompressState.Error;
					Logger.LogErrorFormat("[CompressAndUploading] WebReqError {0}", new object[]
					{
						this.mWaitUploadFile.error
					});
					yield break;
				}
				if (this.mWaitUploadFile.isError)
				{
					this.State = UploadingCompressState.Error;
					Logger.LogErrorFormat("[CompressAndUploading] WebReqError {0}", new object[]
					{
						this.mWaitUploadFile.error
					});
					yield break;
				}
				if (File.Exists(currentZipFilePath))
				{
					File.Delete(currentZipFilePath);
				}
			}
			this.State = UploadingCompressState.Finish;
			this._Clear();
			yield break;
		}

		// Token: 0x0400BC76 RID: 48246
		private static UploadLog instance;

		// Token: 0x0400BC77 RID: 48247
		private static readonly string EXCEPTION_LOG_PATTERN = "Exception*";

		// Token: 0x0400BC78 RID: 48248
		private static readonly string CRASH_LOG_SUB_PATH = "Crash/";

		// Token: 0x0400BC7D RID: 48253
		private UploadLog.UploadLogInfo[] mLogInfos;

		// Token: 0x0400BC7E RID: 48254
		private int mCurrentZipFileIdx;

		// Token: 0x0400BC7F RID: 48255
		private readonly long MAX_DUMP_SIZE = 3145728L;

		// Token: 0x0400BC80 RID: 48256
		private WaitCompressFile mWaitCompressFile;

		// Token: 0x0400BC81 RID: 48257
		private UnityWebRequest mWaitUploadFile;

		// Token: 0x0400BC82 RID: 48258
		private string skDirName = "_bug_report_root_";

		// Token: 0x02001CC8 RID: 7368
		private class UploadLogInfo
		{
			// Token: 0x0601213B RID: 74043 RVA: 0x0054A79D File Offset: 0x00548B9D
			public UploadLogInfo(UploadLogType type, string[] patterns, string[] subPaths)
			{
				this.logType = type;
				this.filePatterns = patterns;
				this.fileSubPaths = subPaths;
			}

			// Token: 0x0400BC83 RID: 48259
			public UploadLogType logType;

			// Token: 0x0400BC84 RID: 48260
			public string[] filePatterns;

			// Token: 0x0400BC85 RID: 48261
			public string[] fileSubPaths;
		}

		// Token: 0x02001CC9 RID: 7369
		public class UploadZipFileInfo
		{
			// Token: 0x0601213C RID: 74044 RVA: 0x0054A7BA File Offset: 0x00548BBA
			public UploadZipFileInfo(string path, string[] filePaths)
			{
				this.zipFilePath = path;
				this.filterFilePaths = filePaths;
			}

			// Token: 0x0400BC86 RID: 48262
			public string zipFilePath;

			// Token: 0x0400BC87 RID: 48263
			public string[] filterFilePaths;
		}
	}
}
