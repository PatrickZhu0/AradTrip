using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

// Token: 0x0200011F RID: 287
public class ExceptionManager : Singleton<ExceptionManager>
{
	// Token: 0x17000088 RID: 136
	// (get) Token: 0x06000679 RID: 1657 RVA: 0x00026868 File Offset: 0x00024C68
	public string LoggerFilePath
	{
		get
		{
			return this.loggerFilePath;
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x00026870 File Offset: 0x00024C70
	public override void Init()
	{
		this.loggerFilePath = ExceptionManager.GetLogFolderPath();
		this.defaultListener.LogFileName = this.GetLogPath("CriticalExceptionLog");
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00026893 File Offset: 0x00024C93
	public override void UnInit()
	{
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x00026898 File Offset: 0x00024C98
	public void Fail(string str)
	{
		this.defaultListener.Fail(string.Format("[{0}]:{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"), str));
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x000268D0 File Offset: 0x00024CD0
	public void OnExceptionCatch(string message, string stacktrace, LogType type)
	{
		object obj = this.logBuffLocker;
		lock (obj)
		{
			if (type == 4 || type == null)
			{
				DateTime now = DateTime.Now;
				string text = string.Format("{0}-{1}-{2} {3}:{4}:{5}", new object[]
				{
					now.Year,
					now.Month,
					now.Day,
					now.Hour,
					now.Minute,
					now.Second
				});
				string text2 = string.Concat(new string[]
				{
					"{\r\n\"message\":\"",
					message.Replace("\r\n", string.Empty),
					"\",\r\n\"stacktrace\":\"",
					stacktrace.Replace("\r\n", string.Empty),
					"\",\r\n\"time\":\"",
					text,
					"\"\r\n\"device\":\""
				});
				if (Application.platform == 8)
				{
					text2 += "iPhone\"";
				}
				else if (Application.platform == 11)
				{
					text2 += "Android\"";
				}
				else
				{
					text2 += "PC Unity Editor\"";
				}
				text2 += "\r\n}";
				if (type == 4)
				{
					this.Fail(string.Format("{0}", text2));
				}
				if (this.logBuffer.Count > 250)
				{
					for (int i = 0; i < this.logBuffer.Count - 250; i++)
					{
						this.logBuffer.RemoveAt(0);
					}
				}
				this.logBuffer.Add(text2);
				if (this.logBuffer.Count > 0)
				{
					if (this.logBuffer.Count >= 50)
					{
						string logPath = this.GetLogPath("Exception");
						try
						{
							FileStream fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
							StreamWriter streamWriter = new StreamWriter(fileStream);
							streamWriter.Flush();
							streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
							for (int j = 0; j < this.logBuffer.Count; j++)
							{
								streamWriter.WriteLine(this.logBuffer[j]);
							}
							streamWriter.Flush();
							fileStream.Flush();
							streamWriter.Close();
							fileStream.Close();
							fileStream.Dispose();
							this.logBuffer.Clear();
						}
						catch (Exception ex)
						{
							this.Fail(string.Format("OnExceptionCatch {0}\n{1}\n", ex.ToString(), text2));
						}
					}
				}
			}
		}
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00026BA8 File Offset: 0x00024FA8
	public void RecordLog(string log)
	{
		object obj = this.logBuffLocker;
		lock (obj)
		{
			if (this.logBuffer.Count > 250)
			{
				for (int i = 0; i < this.logBuffer.Count - 250; i++)
				{
					this.logBuffer.RemoveAt(0);
				}
			}
			this.logBuffer.Add(log);
			if (this.logBuffer.Count > 0)
			{
				if (this.logBuffer.Count >= 50)
				{
					string logPath = this.GetLogPath("Exception");
					try
					{
						using (FileStream fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write))
						{
							using (StreamWriter streamWriter = new StreamWriter(fileStream))
							{
								streamWriter.Flush();
								streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
								for (int j = 0; j < this.logBuffer.Count; j++)
								{
									streamWriter.WriteLine(this.logBuffer[j]);
								}
								streamWriter.Flush();
								fileStream.Flush();
								streamWriter.Close();
								fileStream.Close();
							}
						}
						this.logBuffer.Clear();
					}
					catch (Exception ex)
					{
						this.Fail(string.Format("PrintLogToFile {0} failed {1}", logPath, ex.Message));
					}
				}
			}
		}
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x00026D88 File Offset: 0x00025188
	public void SaveLog()
	{
		if (this.logBuffer.Count <= 0)
		{
			return;
		}
		string logPath = this.GetLogPath("Exception");
		object obj = this.logBuffLocker;
		lock (obj)
		{
			FileStream fileStream = null;
			StreamWriter streamWriter = null;
			try
			{
				fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
				streamWriter = new StreamWriter(fileStream);
				streamWriter.Flush();
				streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
				for (int i = 0; i < this.logBuffer.Count; i++)
				{
					streamWriter.WriteLine(this.logBuffer[i]);
				}
				streamWriter.Flush();
				fileStream.Flush();
				streamWriter.Close();
				fileStream.Close();
				streamWriter = null;
				fileStream = null;
				this.logBuffer.Clear();
			}
			catch (Exception ex)
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter = null;
				}
				if (fileStream != null)
				{
					fileStream.Close();
					fileStream = null;
				}
				this.Fail(string.Format("PrintLogToFile {0} failed {1}", logPath, ex.Message));
			}
		}
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x00026EAC File Offset: 0x000252AC
	public void PrintPreloadRes(List<string> contents)
	{
		string text = this.LoggerFilePath + "preload.txt";
		object obj = this.preloadLocker;
		lock (obj)
		{
			try
			{
				FileStream fileStream = new FileStream(text, FileMode.Append, FileAccess.Write);
				StreamWriter streamWriter = new StreamWriter(fileStream);
				streamWriter.Flush();
				streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
				for (int i = 0; i < contents.Count; i++)
				{
					streamWriter.WriteLine(contents[i]);
				}
				streamWriter.Flush();
				fileStream.Flush();
				streamWriter.Close();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("PrintPreloadRes {0} failed {1}", new object[]
				{
					text,
					ex.Message
				});
			}
		}
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00026F90 File Offset: 0x00025390
	public void PrintABPackage(string ab)
	{
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x00026F94 File Offset: 0x00025394
	public void PrintLogToFile(bool force = false)
	{
		object obj = this.logBuffLocker;
		lock (obj)
		{
			if (this.logBuffer.Count > 0)
			{
				if (force || this.logBuffer.Count >= 50)
				{
					string logPath = this.GetLogPath("Exception");
					try
					{
						FileStream fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
						StreamWriter streamWriter = new StreamWriter(fileStream);
						streamWriter.Flush();
						streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
						for (int i = 0; i < this.logBuffer.Count; i++)
						{
							streamWriter.WriteLine(this.logBuffer[i]);
						}
						streamWriter.Flush();
						fileStream.Flush();
						streamWriter.Close();
						fileStream.Close();
						this.logBuffer.Clear();
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("PrintLogToFile {0} failed {1}", new object[]
						{
							logPath,
							ex.Message
						});
					}
				}
			}
		}
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x000270BC File Offset: 0x000254BC
	public static string GetLogFolderPath()
	{
		string text = null;
		if (Application.platform == 8)
		{
			text = ExceptionManager.GetPersistentDataPath() + "/";
		}
		else if (Application.platform == 11)
		{
			text = ExceptionManager.GetPersistentDataPath() + "/";
		}
		else if (Application.platform == 2)
		{
			text = Application.dataPath + "/";
		}
		else
		{
			text = Application.dataPath;
			text = text.Substring(0, text.LastIndexOf('/')) + "/GameLog/";
		}
		if (!Directory.Exists(text))
		{
			try
			{
				Directory.CreateDirectory(text);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("GetLogFolderPath CreateDirectory {0} failed {1}", new object[]
				{
					text,
					ex.Message
				});
			}
		}
		return text;
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00027198 File Offset: 0x00025598
	public string GetLogPath(string strLogType)
	{
		string str = this.LoggerFilePath;
		DateTime now = DateTime.Now;
		string str2 = string.Format("{0}-{1}-{2}-{3}.txt", new object[]
		{
			strLogType,
			now.Year,
			now.Month,
			now.Day
		});
		return str + str2;
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x000271FB File Offset: 0x000255FB
	private static string GetPersistentDataPath()
	{
		return Application.persistentDataPath;
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x00027204 File Offset: 0x00025604
	public void Upload(string fieldName, string url, string fileName)
	{
		if (HttpClient.Instance == null)
		{
			return;
		}
		if (File.Exists(fieldName))
		{
			HttpClient.Instance.BeginPostRequest();
			byte[] content = File.ReadAllBytes(fieldName);
			HttpClient.Instance.AddBinary("dump", content, fileName);
			HttpClient.Instance.PostRequest(url, null);
		}
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x00027260 File Offset: 0x00025660
	public void UploadAll()
	{
		string url = "ftp://daemon:xampp@192.168.0.103/dnf/ios/";
		string logPath = this.GetLogPath("Exception");
		this.Upload(logPath, url, "exception.dump");
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x0002728C File Offset: 0x0002568C
	public void RecordLogTime(string logTime)
	{
		object obj = this.logBuffTimeLocker;
		lock (obj)
		{
			if (this.logTimeBuffer.Count > 250)
			{
				for (int i = 0; i < this.logTimeBuffer.Count - 250; i++)
				{
					this.logTimeBuffer.RemoveAt(0);
				}
			}
			this.logTimeBuffer.Add(logTime);
			if (this.logTimeBuffer.Count > 0)
			{
				if (this.logTimeBuffer.Count >= 50)
				{
					string strLogType = this.openFrameTime;
					string logPath = this.GetLogPath(strLogType);
					try
					{
						FileStream fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
						StreamWriter streamWriter = new StreamWriter(fileStream);
						streamWriter.Flush();
						streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
						for (int j = 0; j < this.logTimeBuffer.Count; j++)
						{
							streamWriter.WriteLine(this.logTimeBuffer[j]);
						}
						streamWriter.Flush();
						fileStream.Flush();
						streamWriter.Close();
						fileStream.Close();
						fileStream.Dispose();
						this.logTimeBuffer.Clear();
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("PrintLogToFile {0} failed {1}", new object[]
						{
							logPath,
							ex.ToString()
						});
					}
				}
			}
		}
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00027428 File Offset: 0x00025828
	public void PrintLogToFileTime(bool force = false, string openFramePath = null)
	{
		object obj = this.logBuffTimeLocker;
		lock (obj)
		{
			if (this.logTimeBuffer.Count > 0)
			{
				if (force || this.logTimeBuffer.Count >= 50)
				{
					string strLogType = this.openFrameTime;
					if (openFramePath != null)
					{
						strLogType = openFramePath;
					}
					string logPath = this.GetLogPath(strLogType);
					try
					{
						FileStream fileStream = new FileStream(logPath, FileMode.Append, FileAccess.Write);
						StreamWriter streamWriter = new StreamWriter(fileStream);
						streamWriter.Flush();
						streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
						for (int i = 0; i < this.logTimeBuffer.Count; i++)
						{
							streamWriter.WriteLine(this.logTimeBuffer[i]);
						}
						streamWriter.Flush();
						fileStream.Flush();
						streamWriter.Close();
						fileStream.Close();
						fileStream.Dispose();
						this.logTimeBuffer.Clear();
					}
					catch (Exception ex)
					{
						Logger.LogErrorFormat("PrintLogToFile {0} failed {1}", new object[]
						{
							logPath,
							ex.Message
						});
					}
				}
			}
		}
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x00027580 File Offset: 0x00025980
	public void PrintOpenFrameTime(string frameName, float beginTime, float endTime, float costTime)
	{
		if (!this.isShowOpenFrameTime)
		{
			return;
		}
		if (frameName != this.specialFrameName)
		{
			return;
		}
		string logTime = string.Format("Frame Opened    {0}", frameName);
		string logTime2 = string.Format("Begin Time      {0}", beginTime);
		string logTime3 = string.Format("End Time        {0}", endTime);
		string logTime4 = string.Format("Cost Time       {0}", costTime);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime2);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime3);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime4);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().PrintLogToFileTime(true, frameName);
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00027660 File Offset: 0x00025A60
	public void PrintOpenFrameTime(string frameName, float loadGameObjectCostTime, float totalCostTime)
	{
		if (!this.isShowOpenFrameTime)
		{
			return;
		}
		if (!this.IsFrameOpendNeedRecord(frameName))
		{
			return;
		}
		float num = loadGameObjectCostTime / totalCostTime;
		float num2 = totalCostTime - loadGameObjectCostTime;
		string logTime = string.Format("OpenFrame Total Cost Time                {0:0.0000}", totalCostTime);
		string logTime2 = string.Format("LoadGameObject Cost Time                 {0:0.0000} and Percent is {1:P2}", loadGameObjectCostTime, num);
		string logTime3 = string.Format("InitFrame Cost Time                      {0:0.0000}", num2);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime2);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime3);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().PrintLogToFileTime(true, frameName);
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x00027734 File Offset: 0x00025B34
	public void PrintFrameTimeOneFile(string frameName, float loadGameObjectCostTime, float totalCostTime)
	{
		if (!this.isShowOpenFrameTime)
		{
			return;
		}
		if (!this.IsFrameOpendNeedRecord("AllFrames"))
		{
			return;
		}
		float num = loadGameObjectCostTime / totalCostTime;
		float num2 = totalCostTime - loadGameObjectCostTime;
		string logTime = string.Format("{1} OpenFrame Total Cost Time                {0:0.0000}", totalCostTime, frameName);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(logTime);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().RecordLogTime(string.Empty);
		Singleton<ExceptionManager>.GetInstance().PrintLogToFileTime(true, "AllFrames");
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x000277CF File Offset: 0x00025BCF
	private bool IsFrameOpendNeedRecord(string frameName)
	{
		return true;
	}

	// Token: 0x04000544 RID: 1348
	private List<string> logBuffer = new List<string>();

	// Token: 0x04000545 RID: 1349
	private const int MAX_LOG_NUM = 250;

	// Token: 0x04000546 RID: 1350
	private const int WRITE_LOG_NUM = 50;

	// Token: 0x04000547 RID: 1351
	private List<string> abPackageBuffer = new List<string>();

	// Token: 0x04000548 RID: 1352
	private readonly object preloadLocker = new object();

	// Token: 0x04000549 RID: 1353
	private readonly object logBuffLocker = new object();

	// Token: 0x0400054A RID: 1354
	private readonly object logBuffTimeLocker = new object();

	// Token: 0x0400054B RID: 1355
	private DefaultTraceListener defaultListener = new DefaultTraceListener();

	// Token: 0x0400054C RID: 1356
	private string loggerFilePath = string.Empty;

	// Token: 0x0400054D RID: 1357
	private List<string> logTimeBuffer = new List<string>();

	// Token: 0x0400054E RID: 1358
	private bool isShowOpenFrameTime = true;

	// Token: 0x0400054F RID: 1359
	private string specialFrameName = "SkillTreeFrame";

	// Token: 0x04000550 RID: 1360
	private string openFrameTime = "OpenFrameTime";

	// Token: 0x04000551 RID: 1361
	private readonly string[] _openFrameRecordList = new string[]
	{
		"SkillTreeFrame",
		"PackageNewFrame",
		"AuctionFrame",
		"ActiveFuliFrame",
		"SettingPanel"
	};
}
