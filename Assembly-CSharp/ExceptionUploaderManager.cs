using System;
using System.Collections.Generic;
using System.IO;
using LibZip;
using LitJson;
using UnityEngine;

// Token: 0x02000120 RID: 288
public class ExceptionUploaderManager : Singleton<ExceptionUploaderManager>
{
	// Token: 0x0600068F RID: 1679 RVA: 0x000277FB File Offset: 0x00025BFB
	public void SetUploadUrlAndOpenID(string url, string openID)
	{
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x000277FD File Offset: 0x00025BFD
	public void TryCacheOneErrorLog()
	{
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x000277FF File Offset: 0x00025BFF
	public void TryCacheOneErrorLogWithoutLog()
	{
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00027801 File Offset: 0x00025C01
	public void TryUploadOneError()
	{
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00027804 File Offset: 0x00025C04
	private void _removeAllZipFiles()
	{
		try
		{
			string path = this._getRootPath();
			string[] files = Directory.GetFiles(path, "*.zip", SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				if (File.Exists(files[i]))
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[上传日志] 删除缓存*.zip 失败 {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00027884 File Offset: 0x00025C84
	private ExceptionUploaderManager.LogDescrible _getLogDescrible(string uploadConfPath)
	{
		ExceptionUploaderManager.LogDescrible result;
		if (!File.Exists(uploadConfPath))
		{
			result = this._createNewLogDesc();
		}
		else
		{
			result = this._loadExistLogDesc(uploadConfPath);
		}
		return result;
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x000278B4 File Offset: 0x00025CB4
	private ExceptionUploaderManager.LogDescrible _loadExistLogDesc(string uploadConfPath)
	{
		ExceptionUploaderManager.LogDescrible result = null;
		if (!File.Exists(uploadConfPath))
		{
			return null;
		}
		try
		{
			string json = File.ReadAllText(uploadConfPath);
			result = JsonMapper.ToObject<ExceptionUploaderManager.LogDescrible>(json);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[日志上传] 读取或转json失败 {0}", new object[]
			{
				uploadConfPath
			});
		}
		return result;
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x00027910 File Offset: 0x00025D10
	private ExceptionUploaderManager.LogDescrible _createNewLogDesc()
	{
		ExceptionUploaderManager.LogDescrible logDescrible = new ExceptionUploaderManager.LogDescrible();
		logDescrible.deviceID = SystemInfo.deviceUniqueIdentifier.ToString();
		logDescrible.deviceInfo = SystemInfo.deviceModel.ToString();
		logDescrible.deviceType = SystemInfo.deviceType.ToString();
		logDescrible.deviceName = SystemInfo.deviceName.ToString();
		logDescrible.deviceMemorySize = SystemInfo.systemMemorySize.ToString();
		logDescrible.deviceOperatSystem = SystemInfo.operatingSystem.ToString();
		logDescrible.deviceOperatSystemFamily = SystemInfo.operatingSystemFamily.ToString();
		logDescrible.devicePlatform = Application.platform.ToString();
		logDescrible.sdkChannel = Global.Settings.sdkChannel.ToString();
		logDescrible.openID = this.mOpenID;
		logDescrible.dataString = this._getTodayString();
		logDescrible.uploadUrl = this.mUploadUrl;
		logDescrible.uploadLogsPath = string.Empty;
		logDescrible.lastMoveLogTime = 0U;
		try
		{
			logDescrible.serverID = ClientApplication.adminServer.id.ToString();
		}
		catch (Exception ex)
		{
		}
		return logDescrible;
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x00027A54 File Offset: 0x00025E54
	private bool _canMoveExceptionLog(ExceptionUploaderManager.LogDescrible desc)
	{
		if (desc == null)
		{
			return false;
		}
		int num = (int)(Utility.GetCurrentTimeUnix() - desc.lastMoveLogTime - 3600U);
		return num >= 0;
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00027A83 File Offset: 0x00025E83
	private string _getUploadConfigPath()
	{
		return Path.Combine(this._getRootPath(), string.Format("{0}-{1}", this._getTodayString(), "upload.conf"));
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00027AA8 File Offset: 0x00025EA8
	private string _getCachePathWithCreate()
	{
		string text = Path.Combine(this._getRootPath(), this._getTodayString());
		this._makeDirExist(text);
		return text;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00027AD0 File Offset: 0x00025ED0
	private string _getTodayString()
	{
		DateTime now = DateTime.Now;
		return string.Format("{0}-{1}-{2}", now.Year, now.Month, now.Day);
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00027B14 File Offset: 0x00025F14
	private string _getYesterDayString()
	{
		DateTime dateTime = DateTime.Now.AddDays(-1.0);
		return string.Format("{0}-{1}-{2}", dateTime.Year, dateTime.Month, dateTime.Day);
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x00027B68 File Offset: 0x00025F68
	private string _getRootPath()
	{
		string text = string.Empty;
		text = Path.Combine(Application.persistentDataPath, "_log2upload_");
		this._makeDirExist(text);
		return text;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x00027B93 File Offset: 0x00025F93
	private void _makeDirExist(string path)
	{
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x00027BA8 File Offset: 0x00025FA8
	private string _getExcptionLogs()
	{
		string logFolderPath = ExceptionManager.GetLogFolderPath();
		DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);
		if (directoryInfo == null)
		{
			return string.Empty;
		}
		List<FileInfo> list = new List<FileInfo>(directoryInfo.GetFiles("Exception*", SearchOption.AllDirectories));
		list.Sort(delegate(FileInfo fst, FileInfo snd)
		{
			if (fst.LastWriteTime > snd.LastWriteTime)
			{
				return -1;
			}
			if (fst.LastWriteTime == snd.LastWriteTime)
			{
				return 0;
			}
			return 1;
		});
		if (list.Count > 0)
		{
			return list[0].FullName;
		}
		return string.Empty;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00027C24 File Offset: 0x00026024
	private void _compressAndUpload(string logDescFilePath, ExceptionUploaderManager.LogDescrible logDesc)
	{
		if (!File.Exists(logDescFilePath))
		{
			Logger.LogErrorFormat("[日志上传] 压缩上传 描述文件不存在 {0}", new object[]
			{
				logDescFilePath
			});
			return;
		}
		if (logDesc == null)
		{
			Logger.LogErrorFormat("[日志上传] 压缩上传 描述文件对象为空 {0}", new object[]
			{
				logDescFilePath
			});
			return;
		}
		if (!Directory.Exists(logDesc.uploadLogsPath))
		{
			Logger.LogErrorFormat("[日志上传] 压缩上传 日志路径不存在 {0}", new object[]
			{
				logDesc.uploadLogsPath
			});
			return;
		}
		List<string> list = new List<string>(Directory.GetFiles(logDesc.uploadLogsPath, "*", SearchOption.TopDirectoryOnly));
		if (list.Count <= 0)
		{
			return;
		}
		list.Add(logDescFilePath);
		string path = string.Format("{0}-{1}-{2}.zip", logDesc.dataString, logDesc.deviceID, logDesc.lastMoveLogTime).Replace(" ", "_");
		string text = Path.Combine(this._getRootPath(), path);
		if (!LibZipFileReader.CompressFiles(text, list.ToArray()))
		{
			Logger.LogErrorFormat("[日志上传] 压缩 失败 {0}", new object[]
			{
				text
			});
			return;
		}
		this._uploadHttpFile(logDesc, text);
		try
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (File.Exists(list[i]))
				{
					if (list[i] == logDescFilePath)
					{
						if (logDesc.dataString != this._getTodayString())
						{
							File.Delete(list[i]);
							Directory.Delete(logDesc.uploadLogsPath, true);
						}
						break;
					}
					File.Delete(list[i]);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[日志上传] 删除文件失败 {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00027DDC File Offset: 0x000261DC
	private void _uploadHttpFile(ExceptionUploaderManager.LogDescrible logDesc, string path)
	{
		if (logDesc == null)
		{
			return;
		}
		string fileName = Path.GetFileName(path);
		string text = string.Format("{0}?file={1}&dataString={2}&deviceId={3}&serverId{4}&lastMoveLogTime={5}", new object[]
		{
			logDesc.uploadUrl,
			fileName,
			logDesc.dataString,
			logDesc.deviceID,
			logDesc.serverID,
			logDesc.lastMoveLogTime
		}).Replace(" ", "_");
		Http.UploadFile(text, path);
		Debug.LogFormat("[上传日志] url {0} path: {1}", new object[]
		{
			text,
			path
		});
	}

	// Token: 0x04000552 RID: 1362
	protected string mUploadUrl = string.Empty;

	// Token: 0x04000553 RID: 1363
	protected string mOpenID = string.Empty;

	// Token: 0x04000554 RID: 1364
	private readonly object mLocker = new object();

	// Token: 0x04000555 RID: 1365
	private const uint kTime2Upload = 3600U;

	// Token: 0x04000556 RID: 1366
	private const string kFileRootDir = "_log2upload_";

	// Token: 0x04000557 RID: 1367
	private const string kConfigFileName = "upload.conf";

	// Token: 0x02000121 RID: 289
	protected class LogDescrible
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060006A3 RID: 1699 RVA: 0x00027EA7 File Offset: 0x000262A7
		// (set) Token: 0x060006A4 RID: 1700 RVA: 0x00027EAF File Offset: 0x000262AF
		public string deviceID { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00027EB8 File Offset: 0x000262B8
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x00027EC0 File Offset: 0x000262C0
		public string deviceInfo { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00027EC9 File Offset: 0x000262C9
		// (set) Token: 0x060006A8 RID: 1704 RVA: 0x00027ED1 File Offset: 0x000262D1
		public string deviceType { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x00027EDA File Offset: 0x000262DA
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x00027EE2 File Offset: 0x000262E2
		public string deviceName { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x00027EEB File Offset: 0x000262EB
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x00027EF3 File Offset: 0x000262F3
		public string deviceMemorySize { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x00027EFC File Offset: 0x000262FC
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x00027F04 File Offset: 0x00026304
		public string deviceOperatSystem { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x00027F0D File Offset: 0x0002630D
		// (set) Token: 0x060006B0 RID: 1712 RVA: 0x00027F15 File Offset: 0x00026315
		public string deviceOperatSystemFamily { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060006B1 RID: 1713 RVA: 0x00027F1E File Offset: 0x0002631E
		// (set) Token: 0x060006B2 RID: 1714 RVA: 0x00027F26 File Offset: 0x00026326
		public string devicePlatform { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060006B3 RID: 1715 RVA: 0x00027F2F File Offset: 0x0002632F
		// (set) Token: 0x060006B4 RID: 1716 RVA: 0x00027F37 File Offset: 0x00026337
		public string sdkChannel { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x00027F40 File Offset: 0x00026340
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x00027F48 File Offset: 0x00026348
		public string openID { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x00027F51 File Offset: 0x00026351
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x00027F59 File Offset: 0x00026359
		public string serverID { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x00027F62 File Offset: 0x00026362
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x00027F6A File Offset: 0x0002636A
		public string uploadUrl { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x00027F73 File Offset: 0x00026373
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x00027F7B File Offset: 0x0002637B
		public string uploadLogsPath { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x00027F84 File Offset: 0x00026384
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x00027F8C File Offset: 0x0002638C
		public string dataString { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x00027F95 File Offset: 0x00026395
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x00027F9D File Offset: 0x0002639D
		public uint lastMoveLogTime { get; set; }
	}
}
