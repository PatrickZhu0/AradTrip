using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Tenmove;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CCC RID: 7372
	public class UploadingCompressFrame : ClientFrame
	{
		// Token: 0x0601213E RID: 74046 RVA: 0x0054ACA8 File Offset: 0x005490A8
		protected override void _bindExUI()
		{
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mLoadText = this.mBind.GetCom<Text>("loadText");
			this.mLoadSlider = this.mBind.GetCom<Slider>("loadSlider");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0601213F RID: 74047 RVA: 0x0054AD3C File Offset: 0x0054913C
		protected override void _unbindExUI()
		{
			this.mTitle = null;
			this.mLoadText = null;
			this.mLoadSlider = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x06012140 RID: 74048 RVA: 0x0054AD92 File Offset: 0x00549192
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<UploadingCompressFrame>(this, false);
		}

		// Token: 0x06012141 RID: 74049 RVA: 0x0054ADA1 File Offset: 0x005491A1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/UploadingCompressFrame/UploadingCompressFrame";
		}

		// Token: 0x06012142 RID: 74050 RVA: 0x0054ADA8 File Offset: 0x005491A8
		protected override void _OnOpenFrame()
		{
			Debug.Log(Application.persistentDataPath);
			this.State = UploadingCompressState.None;
			this.mLogInfos = new UploadingCompressFrame.UploadLogInfo[]
			{
				new UploadingCompressFrame.UploadLogInfo(UploadLogType.Exception, new string[]
				{
					UploadingCompressFrame.EXCEPTION_LOG_PATTERN
				}, null),
				new UploadingCompressFrame.UploadLogInfo(UploadLogType.Crash, null, new string[]
				{
					Path.Combine(Singleton<ExceptionManager>.instance.LoggerFilePath, UploadingCompressFrame.CRASH_LOG_SUB_PATH)
				})
			};
			this._Start(Singleton<ExceptionManager>.instance.LoggerFilePath, this.mLogInfos);
		}

		// Token: 0x06012143 RID: 74051 RVA: 0x0054AE27 File Offset: 0x00549227
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x06012144 RID: 74052 RVA: 0x0054AE2F File Offset: 0x0054922F
		private void _Clear()
		{
			this.mLogInfos = null;
			if (this.ZipFileInfos != null)
			{
				this.ZipFileInfos.Clear();
				this.ZipFileInfos = null;
			}
			this.mCurrentZipFileIdx = 0;
		}

		// Token: 0x17001DC9 RID: 7625
		// (get) Token: 0x06012145 RID: 74053 RVA: 0x0054AE5C File Offset: 0x0054925C
		// (set) Token: 0x06012146 RID: 74054 RVA: 0x0054AE64 File Offset: 0x00549264
		public UploadingCompressState State { get; private set; }

		// Token: 0x17001DCA RID: 7626
		// (get) Token: 0x06012147 RID: 74055 RVA: 0x0054AE6D File Offset: 0x0054926D
		// (set) Token: 0x06012148 RID: 74056 RVA: 0x0054AE75 File Offset: 0x00549275
		public string FilePathRoot { get; private set; }

		// Token: 0x17001DCB RID: 7627
		// (get) Token: 0x06012149 RID: 74057 RVA: 0x0054AE7E File Offset: 0x0054927E
		// (set) Token: 0x0601214A RID: 74058 RVA: 0x0054AE86 File Offset: 0x00549286
		public string ZipFileRoot { get; private set; }

		// Token: 0x17001DCC RID: 7628
		// (get) Token: 0x0601214B RID: 74059 RVA: 0x0054AE8F File Offset: 0x0054928F
		// (set) Token: 0x0601214C RID: 74060 RVA: 0x0054AE97 File Offset: 0x00549297
		public IList<UploadingCompressFrame.UploadZipFileInfo> ZipFileInfos { get; private set; }

		// Token: 0x0601214D RID: 74061 RVA: 0x0054AEA0 File Offset: 0x005492A0
		private void _Start(string filePathRoot, UploadingCompressFrame.UploadLogInfo[] uploadLogInfos)
		{
			this.FilePathRoot = filePathRoot;
			this.ZipFileRoot = this._getRootPath();
			this._InitFileInfos(uploadLogInfos);
			base.StartCoroutine(this._Process());
		}

		// Token: 0x0601214E RID: 74062 RVA: 0x0054AECC File Offset: 0x005492CC
		private void _Stop()
		{
			base.StopCoroutine(this._Process());
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

		// Token: 0x0601214F RID: 74063 RVA: 0x0054AF3C File Offset: 0x0054933C
		private string _getRootPath()
		{
			string empty = string.Empty;
			return Path.Combine(Application.persistentDataPath, this.skDirName);
		}

		// Token: 0x06012150 RID: 74064 RVA: 0x0054AF64 File Offset: 0x00549364
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

		// Token: 0x06012151 RID: 74065 RVA: 0x0054B154 File Offset: 0x00549554
		private void _InitFileInfos(UploadingCompressFrame.UploadLogInfo[] uploadLogInfos)
		{
			if (uploadLogInfos == null)
			{
				return;
			}
			if (this.ZipFileInfos == null)
			{
				this.ZipFileInfos = new List<UploadingCompressFrame.UploadZipFileInfo>();
			}
			foreach (UploadingCompressFrame.UploadLogInfo uploadLogInfo in uploadLogInfos)
			{
				if (uploadLogInfo != null)
				{
					string text = Path.Combine(this.ZipFileRoot, this._getZipFilePath(uploadLogInfo.logType));
					string[] filePaths = this._GetFilterFiles(uploadLogInfo);
					this.ZipFileInfos.Add(new UploadingCompressFrame.UploadZipFileInfo(text, filePaths));
					TMPathUtil.MakeParentRootExist(text);
				}
			}
		}

		// Token: 0x06012152 RID: 74066 RVA: 0x0054B1DC File Offset: 0x005495DC
		private string[] _GetFilterFiles(UploadingCompressFrame.UploadLogInfo logInfo)
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

		// Token: 0x06012153 RID: 74067 RVA: 0x0054B2EC File Offset: 0x005496EC
		private IEnumerator _Process()
		{
			if (this.ZipFileInfos == null || this.ZipFileInfos.Count <= 0)
			{
				Logger.LogErrorFormat("[CompressAndUploading] Compress Error", new object[0]);
				this._SetTitle("压缩出错");
				yield break;
			}
			while (this.mCurrentZipFileIdx < this.ZipFileInfos.Count)
			{
				UploadingCompressFrame.UploadZipFileInfo currentZipFileInfo = this.ZipFileInfos[this.mCurrentZipFileIdx];
				if (currentZipFileInfo == null)
				{
					this.mCurrentZipFileIdx++;
				}
				else
				{
					this.mWaitCompressFile = new WaitCompressFile(currentZipFileInfo.zipFilePath, this.FilePathRoot, currentZipFileInfo.filterFilePaths);
					this.State = UploadingCompressState.Compressing;
					this._SetTitle(string.Format("创建压缩文件:{0}", this.mCurrentZipFileIdx));
					while (this.mWaitCompressFile.MoveNext())
					{
						this._SetRate(this.mWaitCompressFile.Rate);
						yield return null;
					}
					if (!this.mWaitCompressFile.IsSuccessFinish())
					{
						this.State = UploadingCompressState.Error;
						Logger.LogErrorFormat("[CompressAndUploading] Compress Error", new object[0]);
						this._SetTitle("压缩出错");
					}
					else
					{
						this.mWaitCompressFile.DeleteCompressedFiles();
						this._SetTitle("压缩成功");
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
				this._SetTitle("开始上传");
				float time = 0f;
				ulong lastByte = 0UL;
				this.State = UploadingCompressState.Uploading;
				while (!this.mWaitUploadFile.isDone && time < 10f)
				{
					yield return null;
					float rate = this.mWaitUploadFile.uploadProgress / (float)zipFiles.Count + (float)i * 1f / (float)zipFiles.Count;
					this._SetRate(rate);
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
					this._SetTitle("上传超时");
					yield break;
				}
				if (this.mWaitUploadFile.isError)
				{
					this.State = UploadingCompressState.Error;
					Logger.LogErrorFormat("[CompressAndUploading] WebReqError {0}", new object[]
					{
						this.mWaitUploadFile.error
					});
					this._SetTitle("上传失败");
					yield break;
				}
				if (File.Exists(currentZipFilePath))
				{
					File.Delete(currentZipFilePath);
				}
			}
			this.State = UploadingCompressState.Finish;
			this._SetTitle("成功");
			yield break;
		}

		// Token: 0x06012154 RID: 74068 RVA: 0x0054B308 File Offset: 0x00549708
		private void _SetRate(float rate)
		{
			rate = Mathf.Clamp01(rate);
			if (null != this.mLoadSlider)
			{
				this.mLoadSlider.value = rate;
			}
			if (null != this.mLoadText)
			{
				this.mLoadText.text = string.Format("{0:0.00}%", rate * 100f);
			}
		}

		// Token: 0x06012155 RID: 74069 RVA: 0x0054B36C File Offset: 0x0054976C
		private void _SetTitle(string msg)
		{
			if (null == this.mTitle)
			{
				return;
			}
			this.mTitle.text = msg;
		}

		// Token: 0x0400BC92 RID: 48274
		private Text mTitle;

		// Token: 0x0400BC93 RID: 48275
		private Text mLoadText;

		// Token: 0x0400BC94 RID: 48276
		private Slider mLoadSlider;

		// Token: 0x0400BC95 RID: 48277
		private Button mClose;

		// Token: 0x0400BC96 RID: 48278
		private static readonly string EXCEPTION_LOG_PATTERN = "Exception*";

		// Token: 0x0400BC97 RID: 48279
		private static readonly string CRASH_LOG_SUB_PATH = "Crash/";

		// Token: 0x0400BC9C RID: 48284
		private UploadingCompressFrame.UploadLogInfo[] mLogInfos;

		// Token: 0x0400BC9D RID: 48285
		private int mCurrentZipFileIdx;

		// Token: 0x0400BC9E RID: 48286
		private WaitCompressFile mWaitCompressFile;

		// Token: 0x0400BC9F RID: 48287
		private UnityWebRequest mWaitUploadFile;

		// Token: 0x0400BCA0 RID: 48288
		private string skDirName = "_bug_report_root_";

		// Token: 0x02001CCD RID: 7373
		private class UploadLogInfo
		{
			// Token: 0x06012157 RID: 74071 RVA: 0x0054B3A2 File Offset: 0x005497A2
			public UploadLogInfo(UploadLogType type, string[] patterns, string[] subPaths)
			{
				this.logType = type;
				this.filePatterns = patterns;
				this.fileSubPaths = subPaths;
			}

			// Token: 0x0400BCA1 RID: 48289
			public UploadLogType logType;

			// Token: 0x0400BCA2 RID: 48290
			public string[] filePatterns;

			// Token: 0x0400BCA3 RID: 48291
			public string[] fileSubPaths;
		}

		// Token: 0x02001CCE RID: 7374
		public class UploadZipFileInfo
		{
			// Token: 0x06012158 RID: 74072 RVA: 0x0054B3BF File Offset: 0x005497BF
			public UploadZipFileInfo(string path, string[] filePaths)
			{
				this.zipFilePath = path;
				this.filterFilePaths = filePaths;
			}

			// Token: 0x0400BCA4 RID: 48292
			public string zipFilePath;

			// Token: 0x0400BCA5 RID: 48293
			public string[] filterFilePaths;
		}
	}
}
