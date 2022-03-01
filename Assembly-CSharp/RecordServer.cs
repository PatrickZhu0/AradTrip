using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using GameClient;
using LibZip;
using LitJson;
using Protocol;
using UnityEngine;

// Token: 0x020046C2 RID: 18114
public class RecordServer : Singleton<RecordServer>
{
	// Token: 0x17002131 RID: 8497
	// (get) Token: 0x06019AA1 RID: 105121 RVA: 0x008162AC File Offset: 0x008146AC
	// (set) Token: 0x06019AA0 RID: 105120 RVA: 0x008162A3 File Offset: 0x008146A3
	public FrameRandomImp FrameRandom
	{
		get
		{
			return this.mframeRandom;
		}
		set
		{
			this.mframeRandom = value;
		}
	}

	// Token: 0x17002132 RID: 8498
	// (get) Token: 0x06019AA2 RID: 105122 RVA: 0x008162B4 File Offset: 0x008146B4
	// (set) Token: 0x06019AA3 RID: 105123 RVA: 0x008162BC File Offset: 0x008146BC
	public bool HaveSaveRecordBattle
	{
		get
		{
			return this.m_HaveSaveRecordBattle;
		}
		set
		{
			this.m_HaveSaveRecordBattle = value;
		}
	}

	// Token: 0x06019AA4 RID: 105124 RVA: 0x008162C5 File Offset: 0x008146C5
	public void SetLogicServer(LogicServer logic)
	{
		this.mLogicServer = logic;
		if (this.m_markSys != null)
		{
			this.m_markSys.SetLogicServer(logic);
		}
	}

	// Token: 0x06019AA5 RID: 105125 RVA: 0x008162E5 File Offset: 0x008146E5
	public void Mark(uint id)
	{
		if (this.m_markSys != null)
		{
			this.m_markSys.Mark(id);
		}
	}

	// Token: 0x06019AA6 RID: 105126 RVA: 0x008162FF File Offset: 0x008146FF
	public void MarkInt(uint id, params int[] paramData)
	{
		if (this.m_markSys == null)
		{
			return;
		}
		this.m_markSys.MarkInt(id, paramData);
	}

	// Token: 0x06019AA7 RID: 105127 RVA: 0x0081631A File Offset: 0x0081471A
	public void MarkString(uint id, params string[] paramData)
	{
		if (this.m_markSys == null)
		{
			return;
		}
		this.m_markSys.MarkString(id, paramData);
	}

	// Token: 0x06019AA8 RID: 105128 RVA: 0x00816335 File Offset: 0x00814735
	public void Mark(uint id, int[] paramData, params string[] paramDataStr)
	{
		if (this.m_markSys == null)
		{
			return;
		}
		this.m_markSys.Mark(id, paramData, paramDataStr);
	}

	// Token: 0x06019AA9 RID: 105129 RVA: 0x00816351 File Offset: 0x00814751
	public void Mark(uint id, string[] paramDataStr, params int[] paramData)
	{
		if (this.m_markSys == null)
		{
			return;
		}
		this.m_markSys.Mark(id, paramDataStr, paramData);
	}

	// Token: 0x06019AAA RID: 105130 RVA: 0x0081636D File Offset: 0x0081476D
	public void SetMarkFile(string fileName)
	{
		if (this.m_markSys != null)
		{
			this.m_markSys.Load(fileName);
		}
	}

	// Token: 0x06019AAB RID: 105131 RVA: 0x00816386 File Offset: 0x00814786
	public void BeginUpdate()
	{
		if (this.m_markSys != null)
		{
			this.m_markSys.BeginUpdate();
		}
	}

	// Token: 0x06019AAC RID: 105132 RVA: 0x0081639E File Offset: 0x0081479E
	public void EndUpdate()
	{
		if (this.m_markSys != null)
		{
			this.m_markSys.EndUpdate();
		}
	}

	// Token: 0x17002133 RID: 8499
	// (get) Token: 0x06019AAD RID: 105133 RVA: 0x008163B6 File Offset: 0x008147B6
	// (set) Token: 0x06019AAE RID: 105134 RVA: 0x008163BE File Offset: 0x008147BE
	public bool isLogicServerSaveRecordInTheEnd
	{
		get
		{
			return this.mIsLogicServerSaveRecordInTheEnd;
		}
		set
		{
			this.mIsLogicServerSaveRecordInTheEnd = value;
		}
	}

	// Token: 0x06019AAF RID: 105135 RVA: 0x008163C7 File Offset: 0x008147C7
	public RecordData GetRecordData()
	{
		return this.recordData;
	}

	// Token: 0x06019AB0 RID: 105136 RVA: 0x008163CF File Offset: 0x008147CF
	public override void Init()
	{
		base.Init();
		this.openRecordFunction = SwitchFunctionUtility.IsOpen(15);
	}

	// Token: 0x06019AB1 RID: 105137 RVA: 0x008163E4 File Offset: 0x008147E4
	public void StartRecord(BattleType type, eDungeonMode mode, string sessionID, bool IsRecordProcess, bool IsRecordReplay, bool needMark = true, bool isReplayMode = false)
	{
		Logger.LogForReplay("[RECORD]StartRecord", new object[0]);
		this.Clear();
		this.type = type;
		this.mode = mode;
		this.sessionID = sessionID;
		this.mIsRecordProcess = IsRecordProcess;
		this.mIsRecordReplay = IsRecordReplay;
		this.mIsRecording = true;
		this.bNeedUploadRecordFile = false;
		if (this.mIsRecordReplay)
		{
			this.recordData = new RecordData();
			this.recordData.sessionID = sessionID;
			this.recordData.clientVersion = Singleton<VersionManager>.GetInstance().ServerVersion();
		}
		this.timeAcc = 0;
		if (this.mIsRecordProcess)
		{
			if (needMark)
			{
				if (isReplayMode)
				{
					this.m_markSys = new RecordMarkSystem(RECORD_MODE.REPLAY, FrameSync.instance, Singleton<VersionManager>.GetInstance().Version(), sessionID, type, mode);
					this.m_markSys.SetRandom(this.FrameRandom);
				}
				else
				{
					this.m_markSys = new RecordMarkSystem(RECORD_MODE.RECORD, FrameSync.instance, Singleton<VersionManager>.GetInstance().Version(), sessionID, type, mode);
					this.m_markSys.SetRandom(this.FrameRandom);
				}
			}
		}
		else
		{
			this.contentRecorder = null;
		}
	}

	// Token: 0x06019AB2 RID: 105138 RVA: 0x00816500 File Offset: 0x00814900
	public void MarkRecordFileNeedUpload()
	{
		this.bNeedUploadRecordFile = true;
	}

	// Token: 0x06019AB3 RID: 105139 RVA: 0x00816509 File Offset: 0x00814909
	public void StartRecordProcess()
	{
		this.mIsRecordProcess = true;
		this.mIsRecordReplay = false;
		this.contentRecorder = StringBuilderCache.Acquire(1048576);
		this.contentRecorder.AppendFormat("[Normal Battle Log]SessionID:{0} \n", this.sessionID);
	}

	// Token: 0x06019AB4 RID: 105140 RVA: 0x00816540 File Offset: 0x00814940
	public void RecordSequence(uint sequence)
	{
		if (this.contentRecorder != null)
		{
			this.contentRecorder.AppendFormat("[{0}]", sequence);
		}
	}

	// Token: 0x06019AB5 RID: 105141 RVA: 0x00816564 File Offset: 0x00814964
	public void RecordProcessPlayerInfo(IDungeonPlayerDataManager playMgr)
	{
		List<BattlePlayer> allPlayers = playMgr.GetAllPlayers();
		BattlePlayer mainPlayer = playMgr.GetMainPlayer();
		if (this.m_markSys != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				stringBuilder.AppendFormat("Seat:{0} Name:{1} Lv:{2} occ:{3} zoneId:{4} accid:{5}", new object[]
				{
					battlePlayer.playerInfo.seat,
					battlePlayer.playerInfo.name,
					battlePlayer.playerInfo.level,
					(ActorOccupation)battlePlayer.playerInfo.occupation,
					battlePlayer.playerInfo.zoneId,
					battlePlayer.playerInfo.accid
				});
			}
			this.m_markSys.MarkString(15658734U, new string[]
			{
				stringBuilder.ToString()
			});
		}
		if (this.contentRecorder != null)
		{
			this.contentRecorder.Append("F[-]");
			for (int j = 0; j < allPlayers.Count; j++)
			{
				BattlePlayer battlePlayer2 = allPlayers[j];
				this.contentRecorder.AppendFormat("Seat:{0} Name:{1} Lv:{2} occ:{3} zoneId:{4} accid:{5}", new object[]
				{
					battlePlayer2.playerInfo.seat,
					battlePlayer2.playerInfo.name,
					battlePlayer2.playerInfo.level,
					(ActorOccupation)battlePlayer2.playerInfo.occupation,
					battlePlayer2.playerInfo.zoneId,
					battlePlayer2.playerInfo.accid
				});
			}
			this.contentRecorder.Append("\n");
		}
	}

	// Token: 0x06019AB6 RID: 105142 RVA: 0x00816730 File Offset: 0x00814B30
	private void FlushFile(string path, ref StringBuilder content)
	{
		if (content == null)
		{
			return;
		}
		StreamWriter streamWriter = null;
		if (File.Exists(path))
		{
			try
			{
				streamWriter = new StreamWriter(path, true);
				streamWriter.Write(content.ToString());
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter = null;
				}
				Logger.LogErrorFormat("Flush file failed!!!!!!:{0} reason {1} \n", new object[]
				{
					path,
					ex.ToString()
				});
			}
		}
		else
		{
			try
			{
				streamWriter = new StreamWriter(path);
				streamWriter.Write(content.ToString());
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch (Exception ex2)
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
					streamWriter = null;
				}
				Logger.LogErrorFormat("Flush file failed!!!!!!:{0} reason {1} \n", new object[]
				{
					path,
					ex2.ToString()
				});
			}
		}
		MyExtensionMethods.Clear(content);
	}

	// Token: 0x06019AB7 RID: 105143 RVA: 0x00816828 File Offset: 0x00814C28
	public void FlushProcess()
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder != null)
		{
			string arg = string.Format("s{0}_{1}_{2}process.txt", this.sessionID, this.type, this.mode);
			string fileName = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg);
			string path = RecordData.GenPath(fileName);
			this.FlushFile(path, ref this.contentRecorder);
		}
		if (this.contentRecorder2 != null)
		{
			string arg2 = string.Format("s{0}_{1}_{2}process_receive_package.txt", this.sessionID, this.type, this.mode);
			string fileName2 = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg2);
			string path2 = RecordData.GenPath(fileName2);
			this.FlushFile(path2, ref this.contentRecorder2);
		}
		if (this.m_markSys != null)
		{
			string path3 = RecordData.GenPath(BeUtility.Format("{0}.mark", this.sessionID));
			this.m_markSys.Flush(path3, RecordData.buffer);
		}
	}

	// Token: 0x06019AB8 RID: 105144 RVA: 0x0081695B File Offset: 0x00814D5B
	private void SafeRelease(ref StringBuilder s)
	{
		if (s != null)
		{
			StringBuilderCache.Release(s);
			s = null;
		}
	}

	// Token: 0x06019AB9 RID: 105145 RVA: 0x00816970 File Offset: 0x00814D70
	public void CreateCR2()
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder2 == null)
		{
			this.contentRecorder2 = StringBuilderCache.Acquire(1048576);
			this.contentRecorder2.AppendFormat("Version:{0} sessionID:{1} \n", Singleton<VersionManager>.GetInstance().Version(), this.sessionID);
		}
	}

	// Token: 0x06019ABA RID: 105146 RVA: 0x008169C5 File Offset: 0x00814DC5
	public bool IsProcessRecord()
	{
		return this.openRecordFunction && this.mIsRecordProcess;
	}

	// Token: 0x06019ABB RID: 105147 RVA: 0x008169DA File Offset: 0x00814DDA
	public bool IsReplayRecord(bool force = false)
	{
		if (!this.openRecordFunction)
		{
			return false;
		}
		if (force)
		{
			this.mIsRecordReplay = true;
		}
		return this.mIsRecordReplay;
	}

	// Token: 0x06019ABC RID: 105148 RVA: 0x008169FC File Offset: 0x00814DFC
	public void EndRecord(string reason)
	{
		Logger.LogForReplay("[RECORD]EndRecord", new object[0]);
		bool flag = this.mIsRecordReplay;
		bool flag2 = this.mIsRecordProcess;
		if (this.mIsRecordReplay)
		{
			this._saveRecordReplay(false);
			this.mIsRecordReplay = false;
		}
		this.EndRecordProcess();
		this.mIsRecording = false;
		this.SaveReconnectCmd();
		if (this.mLogicServer != null)
		{
			this.mLogicServer = null;
		}
		if (flag || flag2)
		{
			this._CompressAndDeleteOldFile();
		}
		this._compressFilsAndUpload();
	}

	// Token: 0x06019ABD RID: 105149 RVA: 0x00816A80 File Offset: 0x00814E80
	public void EndLiveShowRecord()
	{
		Logger.LogForReplay("[RECORD]EndRecord", new object[0]);
		bool flag = this.mIsRecordReplay;
		bool flag2 = this.mIsRecordProcess;
		if (this.mIsRecordReplay)
		{
			this._saveRecordReplay(true);
			this.mIsRecordReplay = false;
		}
		this.EndRecordProcess();
		this.mIsRecording = false;
		this.SaveReconnectCmd();
	}

	// Token: 0x06019ABE RID: 105150 RVA: 0x00816AD8 File Offset: 0x00814ED8
	private void _SaveSkillBar()
	{
		List<SkillBarGrid> list = DataManager<SkillDataManager>.GetInstance().GetPvpSkillBar();
		if (list.Count >= 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null)
				{
				}
			}
		}
		list = DataManager<SkillDataManager>.GetInstance().GetPveSkillBar();
		if (list.Count >= 0)
		{
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] != null)
				{
				}
			}
		}
	}

	// Token: 0x06019ABF RID: 105151 RVA: 0x00816B59 File Offset: 0x00814F59
	[Conditional("MG_TEST")]
	private void _SaveMgTestInfo()
	{
	}

	// Token: 0x06019AC0 RID: 105152 RVA: 0x00816B5B File Offset: 0x00814F5B
	private void SaveSkillBtnClick()
	{
	}

	// Token: 0x06019AC1 RID: 105153 RVA: 0x00816B60 File Offset: 0x00814F60
	public int GetCurrentRecordSize()
	{
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[_CompressAndDeleteOldFile] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			return 0;
		}
		string text = this.sessionID.ToString();
		string path = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_upload.zip", new object[]
		{
			Global.Settings.sdkChannel,
			ClientApplication.adminServer.id,
			text,
			this.type,
			this.mode,
			this.mLastRecordTimeStamp
		});
		string text2 = Path.Combine(rootPath, path);
		if (!File.Exists(text2))
		{
			string[] files = Directory.GetFiles(rootPath);
			string value = string.Format("{0}_{1}_{2}_{3}_{4}_", new object[]
			{
				Global.Settings.sdkChannel,
				ClientApplication.adminServer.id,
				text,
				this.type,
				this.mode
			});
			for (int i = 0; i < files.Length; i++)
			{
				string extension = Path.GetExtension(files[i]);
				if (extension.CompareTo(".zip") == 0)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
					if (fileNameWithoutExtension.Contains(value))
					{
						FileInfo fileInfo = new FileInfo(files[i]);
						return (int)fileInfo.Length;
					}
				}
			}
			return 0;
		}
		FileInfo fileInfo2 = new FileInfo(text2);
		return (int)fileInfo2.Length;
	}

	// Token: 0x06019AC2 RID: 105154 RVA: 0x00816CE8 File Offset: 0x008150E8
	public int GetPkRecordSize(string sessionId)
	{
		string path = string.Format("{0}_{1}_{2}_pvp_upload.zip", Global.Settings.sdkChannel, ClientApplication.adminServer.id, sessionId);
		string rootPath = RecordData.GetRootPath();
		string text = Path.Combine(rootPath, path);
		if (!File.Exists(text))
		{
			return 0;
		}
		FileInfo fileInfo = new FileInfo(text);
		return (int)fileInfo.Length;
	}

	// Token: 0x06019AC3 RID: 105155 RVA: 0x00816D48 File Offset: 0x00815148
	public bool UpLoadCurrentRecordFile(ref string errorReason, int type, string desc)
	{
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[_CompressAndDeleteOldFile] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			errorReason = "找不到文件路径";
			return false;
		}
		string text = this.sessionID.ToString();
		string text2 = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_upload.zip", new object[]
		{
			Global.Settings.sdkChannel,
			ClientApplication.adminServer.id,
			text,
			this.type,
			this.mode,
			this.mLastRecordTimeStamp
		});
		string text3 = Path.Combine(rootPath, text2);
		if (!File.Exists(text3))
		{
			string[] files = Directory.GetFiles(rootPath);
			string value = string.Format("{0}_{1}_{2}_{3}_{4}_", new object[]
			{
				Global.Settings.sdkChannel,
				ClientApplication.adminServer.id,
				text,
				this.type,
				this.mode
			});
			bool flag = false;
			for (int i = 0; i < files.Length; i++)
			{
				string extension = Path.GetExtension(files[i]);
				if (extension.CompareTo(".zip") == 0)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
					if (fileNameWithoutExtension.Contains(value))
					{
						text3 = files[i];
						text2 = fileNameWithoutExtension;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				errorReason = "找不到文件 或者已经上传过了";
				return false;
			}
		}
		string fileName = Path.GetFileName(text3);
		try
		{
			Http.UploadFile(string.Format("http://{0}/replay?file={1}", Global.RECORDLOG_GET_ADDRESS, fileName), text3);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("UploadLastFile occur error reason {0}", new object[]
			{
				ex.Message
			});
			errorReason = "上传失败";
			return false;
		}
		RecordServer.UploadInfo uploadInfo = new RecordServer.UploadInfo
		{
			platform = "Android",
			channel = Global.Settings.sdkChannel.ToString(),
			zone_id = DataManager<PlayerBaseData>.GetInstance().ZoneID.ToString(),
			zone_name = ClientApplication.adminServer.name,
			player_name = DataManager<PlayerBaseData>.GetInstance().Name,
			player_id = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(),
			version = Singleton<VersionManager>.GetInstance().Version(),
			replay = text2,
			record_type = type.ToString(),
			content = desc
		};
		if (uploadInfo != null)
		{
			try
			{
				string content = JsonMapper.ToJson(uploadInfo);
				Http.SendPostRequest(string.Format("http://{0}/desc", Global.RECORDLOG_POST_ADDRESS), content, null);
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat("UploadLastFile occur error reason {0}", new object[]
				{
					ex2.Message
				});
				errorReason = "输入用户信息失败";
				return false;
			}
		}
		try
		{
			File.Delete(text3);
		}
		catch (Exception ex3)
		{
			return true;
		}
		return true;
	}

	// Token: 0x06019AC4 RID: 105156 RVA: 0x00817084 File Offset: 0x00815484
	public bool UpLoadRecordFile(string fileName, ref string errorReason, int type, string desc)
	{
		string text = string.Format("{0}_{1}_{2}_pvp_upload.zip", Global.Settings.sdkChannel, ClientApplication.adminServer.id, fileName);
		string rootPath = RecordData.GetRootPath();
		string text2 = Path.Combine(rootPath, text);
		if (!File.Exists(text2))
		{
			errorReason = "找不到文件";
			return false;
		}
		string fileName2 = Path.GetFileName(text2);
		try
		{
			Http.UploadFile(string.Format("http://{0}/replay?file={1}", Global.RECORDLOG_GET_ADDRESS, fileName2), text2);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("UploadLastFile occur error reason {0}", new object[]
			{
				ex.Message
			});
			errorReason = "上传失败";
			return false;
		}
		RecordServer.UploadInfo uploadInfo = new RecordServer.UploadInfo
		{
			platform = "Android",
			channel = Global.Settings.sdkChannel.ToString(),
			zone_id = DataManager<PlayerBaseData>.GetInstance().ZoneID.ToString(),
			zone_name = ClientApplication.adminServer.name,
			player_name = DataManager<PlayerBaseData>.GetInstance().Name,
			player_id = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(),
			replay = text,
			version = Singleton<VersionManager>.GetInstance().Version(),
			record_type = type.ToString(),
			content = desc
		};
		if (uploadInfo != null)
		{
			string content = JsonMapper.ToJson(uploadInfo);
			try
			{
				Http.SendPostRequest(string.Format("http://{0}/desc", Global.RECORDLOG_POST_ADDRESS), content, null);
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat("UpLoadRecordFile occur error reason {0}", new object[]
				{
					ex2.Message
				});
				errorReason = "输入用户信息失败";
				return false;
			}
		}
		try
		{
			File.Delete(text2);
		}
		catch (Exception ex3)
		{
			return true;
		}
		return true;
	}

	// Token: 0x06019AC5 RID: 105157 RVA: 0x0081728C File Offset: 0x0081568C
	private void _CompressAndDeleteOldFile()
	{
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[_CompressAndDeleteOldFile] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			return;
		}
		string[] files = Directory.GetFiles(rootPath);
		string text = this.sessionID.ToString();
		string text2 = Utility.GetCurrentTimeUnix().ToString();
		this.mLastRecordTimeStamp = text2;
		this.cacheFilesList.Clear();
		List<string> list = new List<string>();
		for (int i = 0; i < files.Length; i++)
		{
			if (!files[i].EndsWith(".zip") && files[i].Contains(text))
			{
				this.cacheFilesList.Add(files[i]);
			}
			string extension = Path.GetExtension(files[i]);
			if (extension.CompareTo(".zip") == 0)
			{
				list.Add(files[i]);
			}
		}
		try
		{
			string path = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_upload.zip", new object[]
			{
				Global.Settings.sdkChannel,
				ClientApplication.adminServer.id,
				text,
				this.type,
				this.mode,
				text2
			});
			string text3 = Path.Combine(rootPath, path);
			if (!LibZipFileReader.CompressFiles(text3, this.cacheFilesList.ToArray()))
			{
				Logger.LogErrorFormat("[_CompressAndDeleteOldFile] CompressFiles fail {0}", new object[]
				{
					text3
				});
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[_CompressAndDeleteOldFile Exception] CompressFiles fail {0}", new object[]
			{
				ex.Message
			});
		}
		try
		{
			for (int j = 0; j < list.Count; j++)
			{
				File.Delete(list[j]);
			}
		}
		catch (Exception ex2)
		{
			Logger.LogErrorFormat("[_CompressAndDeleteOldFile Exception] DeleteZipFile fail ", new object[0]);
		}
	}

	// Token: 0x06019AC6 RID: 105158 RVA: 0x00817488 File Offset: 0x00815888
	private void _saveRecordReplay(bool isInBattleRecord = false)
	{
		if (this.recordData == null)
		{
			return;
		}
		this.recordData.Serialization(isInBattleRecord);
		if (isInBattleRecord)
		{
			return;
		}
		this.recordData.playerInfo = null;
		this.recordData.resultInfo = null;
		this.recordData.endReq = null;
		this.recordData.frameInfo.Clear();
		this.recordData.replayFile = null;
		this.recordData = null;
	}

	// Token: 0x06019AC7 RID: 105159 RVA: 0x008174FB File Offset: 0x008158FB
	public void LogicServerSaveRecordAndReplay()
	{
	}

	// Token: 0x06019AC8 RID: 105160 RVA: 0x00817500 File Offset: 0x00815900
	private void _compressFilsAndUpload()
	{
		if (!this.bNeedUploadRecordFile)
		{
			return;
		}
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[_compressFilsAndUpload] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			return;
		}
		string[] files = Directory.GetFiles(rootPath);
		string text = this.sessionID.ToString();
		string text2 = Utility.GetCurrentTimeUnix().ToString();
		this.cacheFilesList.Clear();
		for (int i = 0; i < files.Length; i++)
		{
			if (!files[i].EndsWith(".zip") && files[i].Contains(text))
			{
				this.cacheFilesList.Add(files[i]);
			}
		}
		string path = string.Format("{0}_{1}_{2}_{3}.zip", new object[]
		{
			text,
			this.type,
			this.mode,
			text2
		});
		string text3 = Path.Combine(rootPath, path);
		Debug.LogFormat("[_compressFilsAndUpload] try compress File {0}", new object[]
		{
			text3
		});
		if (LibZipFileReader.CompressFiles(text3, this.cacheFilesList.ToArray()))
		{
			this._uploadHttpFile(text3);
			for (int j = 0; j < this.cacheFilesList.Count; j++)
			{
				if (File.Exists(this.cacheFilesList[j]))
				{
					File.Delete(this.cacheFilesList[j]);
				}
			}
		}
		else
		{
			Logger.LogErrorFormat("[_compressFilsAndUpload] CompressFiles fail {0}", new object[]
			{
				text3
			});
		}
	}

	// Token: 0x06019AC9 RID: 105161 RVA: 0x00817692 File Offset: 0x00815A92
	public void EndRecordProcess()
	{
		if (this.mIsRecordProcess)
		{
			this._saveRecordProcess();
			this.mIsRecordProcess = false;
		}
	}

	// Token: 0x06019ACA RID: 105162 RVA: 0x008176AC File Offset: 0x00815AAC
	private void _saveRecordProcess()
	{
		if (this.m_markSys != null)
		{
			string path = RecordData.GenPath(BeUtility.Format("{0}.mark", this.sessionID));
			this.m_markSys.Save(path, RecordData.buffer);
			this.m_markSys = null;
		}
		this.SaveProcess();
		this.SafeRelease(ref this.contentRecorder);
		this.SafeRelease(ref this.contentRecorder2);
	}

	// Token: 0x06019ACB RID: 105163 RVA: 0x00817710 File Offset: 0x00815B10
	public void RecordStartTime(uint startTime)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.startTime = startTime;
		Logger.LogForReplay("[RECORD]RecordStartTime:{0}", new object[]
		{
			startTime
		});
	}

	// Token: 0x06019ACC RID: 105164 RVA: 0x00817743 File Offset: 0x00815B43
	public void RecordPlayerInfo(WorldNotifyRaceStart info)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.playerInfo = info;
		this.recordData.raceType = (RaceType)info.raceType;
		Logger.LogForReplay("[RECORD]RecordPlayerInfo", new object[0]);
	}

	// Token: 0x06019ACD RID: 105165 RVA: 0x0081777E File Offset: 0x00815B7E
	public void RecordDungoenInfo(SceneDungeonStartRes info)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.dungeonInfo = info;
	}

	// Token: 0x06019ACE RID: 105166 RVA: 0x00817798 File Offset: 0x00815B98
	public void RecordDungeonID(int dungeonID)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.pvpDungeonID = dungeonID;
		Logger.LogForReplay("[RECORD]RecordDungeonID:{0}", new object[]
		{
			this.recordData.pvpDungeonID
		});
	}

	// Token: 0x06019ACF RID: 105167 RVA: 0x008177D8 File Offset: 0x00815BD8
	public void RecordStartFrame()
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.startFrame = FrameSync.instance.curFrame;
		Logger.LogForReplay("[RECORD]RecordStartFrame:{0}", new object[]
		{
			this.recordData.startFrame
		});
	}

	// Token: 0x06019AD0 RID: 105168 RVA: 0x0081782C File Offset: 0x00815C2C
	public void RecordServerFrames(Frame[] frames)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		if (frames == null || frames.Length <= 0)
		{
			return;
		}
		RecordFrameData recordFrameData = new RecordFrameData(frames, this.timeAcc);
		if (recordFrameData == null)
		{
			Logger.LogErrorFormat("[ERROR]create RecordFrameData failed!!!!", new object[0]);
			return;
		}
		this.recordData.frameInfo.Add(recordFrameData);
		Logger.LogForReplay("[RECORD]RecordServerFrames tickTime:{0}", new object[]
		{
			this.timeAcc
		});
	}

	// Token: 0x06019AD1 RID: 105169 RVA: 0x008178A8 File Offset: 0x00815CA8
	public void RecordResult(SceneMatchPkRaceEnd ret)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		Logger.LogForReplay("[RECORD]RecordResult", new object[0]);
	}

	// Token: 0x06019AD2 RID: 105170 RVA: 0x008178C6 File Offset: 0x00815CC6
	public void RecordEndReq(RelaySvrEndGameReq req, int duration)
	{
		if (!this.mIsRecordReplay)
		{
			return;
		}
		this.recordData.endReq = req;
		this.recordData.duration = duration;
		Logger.LogForReplay("[RECORD]RecordEndReq", new object[0]);
	}

	// Token: 0x06019AD3 RID: 105171 RVA: 0x008178FC File Offset: 0x00815CFC
	public void Update(int delta)
	{
		if (this.mIsRecordProcess)
		{
			this.timeAcc += delta;
		}
	}

	// Token: 0x06019AD4 RID: 105172 RVA: 0x00817918 File Offset: 0x00815D18
	public void Clear()
	{
		this.mIsRecordProcess = false;
		this.mIsRecordReplay = false;
		this.mIsRecording = false;
		this.recordData = null;
		if (this.mLogicServer != null)
		{
			this.mLogicServer = null;
		}
		this.SafeRelease(ref this.contentRecorder);
		this.SafeRelease(ref this.contentRecorder2);
		this.SafeRelease(ref this.reconnectRecorder);
	}

	// Token: 0x06019AD5 RID: 105173 RVA: 0x00817978 File Offset: 0x00815D78
	[Conditional("RECORD_FILE")]
	public void RecordProcess(string content)
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder == null)
		{
			return;
		}
		this.contentRecorder.Append(this.GetFrameInfo());
		this.contentRecorder.Append(content);
		this.contentRecorder.Append("\n");
	}

	// Token: 0x06019AD6 RID: 105174 RVA: 0x008179D0 File Offset: 0x00815DD0
	[Conditional("RECORD_FILE")]
	public void RecordProcess(string format, params object[] args)
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder == null)
		{
			return;
		}
		this.contentRecorder.Append(this.GetFrameInfo());
		this.contentRecorder.AppendFormat(format, args);
		this.contentRecorder.Append("\n");
	}

	// Token: 0x06019AD7 RID: 105175 RVA: 0x00817A28 File Offset: 0x00815E28
	public void RecordProcess2(string content)
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder2 == null)
		{
			this.CreateCR2();
		}
		this.contentRecorder2.Append(this.GetFrameInfo());
		this.contentRecorder2.Append(content);
		this.contentRecorder2.Append("\n");
	}

	// Token: 0x06019AD8 RID: 105176 RVA: 0x00817A82 File Offset: 0x00815E82
	public void RecordProcess2(string format, params object[] args)
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (this.contentRecorder2 == null)
		{
			this.CreateCR2();
		}
		this.contentRecorder2.AppendFormat(format, args);
		this.contentRecorder2.Append("\n");
	}

	// Token: 0x06019AD9 RID: 105177 RVA: 0x00817AC0 File Offset: 0x00815EC0
	public string GetFrameInfo()
	{
		if (FrameSync.instance == null)
		{
			return string.Format("T[{0}]F[-]R[{1},{2}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"), this.FrameRandom.callNum, this.FrameRandom.GetSeed());
		}
		if (FrameSync.instance.svrFrame != FrameSync.instance.endFrame || FrameSync.instance.svrFrame != FrameSync.instance.lastSvrFrame)
		{
			return string.Format("T[{0}]S[{1}-{2}-{3}]F[{4}]R[{5},{6}]", new object[]
			{
				DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"),
				FrameSync.instance.lastSvrFrame,
				FrameSync.instance.svrFrame,
				FrameSync.instance.endFrame,
				FrameSync.instance.curFrame,
				this.FrameRandom.callNum,
				this.FrameRandom.GetSeed()
			});
		}
		return string.Format("T[{0}]S[{1}]F[{2}]R[{3},{4}]", new object[]
		{
			DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"),
			FrameSync.instance.lastSvrFrame,
			FrameSync.instance.curFrame,
			this.FrameRandom.callNum,
			this.FrameRandom.GetSeed()
		});
	}

	// Token: 0x06019ADA RID: 105178 RVA: 0x00817C4C File Offset: 0x0081604C
	public static string GetStackTraceModelName()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame[] frames = stackTrace.GetFrames();
		string text = "ResponseWrite,ResponseWriteError,";
		string text2 = string.Empty;
		string text3 = string.Empty;
		for (int i = 1; i < frames.Length; i++)
		{
			if (frames[i].GetILOffset() == -1)
			{
				break;
			}
			text3 = frames[i].GetMethod().Name;
			if (!text.Contains(text3))
			{
				text2 = string.Concat(new string[]
				{
					frames[i].GetMethod().ReflectedType.FullName,
					".",
					text3,
					"()->",
					text2
				});
			}
		}
		return text2.TrimEnd(new char[]
		{
			'-',
			'>'
		});
	}

	// Token: 0x06019ADB RID: 105179 RVA: 0x00817D21 File Offset: 0x00816121
	public void CopyProcess(ref string dstLogger)
	{
		dstLogger = string.Empty;
		if (this.contentRecorder != null)
		{
			dstLogger = this.contentRecorder.ToString();
		}
	}

	// Token: 0x06019ADC RID: 105180 RVA: 0x00817D42 File Offset: 0x00816142
	public void CopyProcess2(ref string dstLogger)
	{
		dstLogger = string.Empty;
		if (this.contentRecorder2 != null)
		{
			dstLogger = this.contentRecorder2.ToString();
		}
	}

	// Token: 0x06019ADD RID: 105181 RVA: 0x00817D64 File Offset: 0x00816164
	public static void SaveProcessWithProfiler(string sessionID, string logContent, string logContent2)
	{
		if (string.IsNullOrEmpty(sessionID) || logContent == null || logContent2 == null)
		{
			return;
		}
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Directory.CreateDirectory(rootPath);
		}
		string text = rootPath + "Profiler/";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		DateTime now = DateTime.Now;
		string arg = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", new object[]
		{
			now.Year,
			now.Month,
			now.Day,
			now.Hour,
			now.Minute,
			now.Second
		});
		string text2 = Path.Combine(text, string.Format("s{0}_{1}_process.txt", sessionID, arg));
		string path = Path.Combine(text, string.Format("s{0}_{1}_process_receive_package.txt", sessionID, arg));
		RecordServer.SaveLogFile(logContent2, path);
	}

	// Token: 0x06019ADE RID: 105182 RVA: 0x00817E60 File Offset: 0x00816260
	public static void SaveLogFile(string log, string path)
	{
		if (log == null)
		{
			return;
		}
		StreamWriter streamWriter = null;
		try
		{
			streamWriter = new StreamWriter(path);
			streamWriter.Write(log);
			streamWriter.Flush();
			streamWriter.Close();
			streamWriter = null;
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("save file failed!!!!!!:{0} reason {1} \n", new object[]
			{
				path,
				ex.ToString()
			});
			if (streamWriter != null)
			{
				streamWriter.Close();
			}
			streamWriter = null;
		}
	}

	// Token: 0x06019ADF RID: 105183 RVA: 0x00817ED8 File Offset: 0x008162D8
	private void SaveProcess()
	{
		string text = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}process.txt", this.sessionID, this.type, this.mode)));
		if (this.contentRecorder != null)
		{
			string arg = string.Format("s{0}_{1}_{2}process.txt", this.sessionID, this.type, this.mode);
			string fileName = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg);
			string path = RecordData.GenPath(fileName);
			this.FlushFile(path, ref this.contentRecorder);
			this.SafeRelease(ref this.contentRecorder);
		}
		string text2 = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}process_receive_package.txt", this.sessionID, this.type, this.mode)));
		if (this.contentRecorder2 != null)
		{
			string arg2 = string.Format("s{0}_{1}_{2}process_receive_package.txt", this.sessionID, this.type, this.mode);
			string fileName2 = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg2);
			string path2 = RecordData.GenPath(fileName2);
			this.FlushFile(path2, ref this.contentRecorder2);
			this.SafeRelease(ref this.contentRecorder2);
		}
	}

	// Token: 0x06019AE0 RID: 105184 RVA: 0x00818048 File Offset: 0x00816448
	public void EndRecordInBattleOnError()
	{
		this._saveRecordReplay(true);
		this.SaveProcessInBattle();
	}

	// Token: 0x06019AE1 RID: 105185 RVA: 0x00818058 File Offset: 0x00816458
	private void AddExceptionFile(List<string> mFileList)
	{
		DateTime now = DateTime.Now;
		DirectoryInfo directoryInfo = new DirectoryInfo(ExceptionManager.GetLogFolderPath());
		foreach (FileInfo fileInfo in directoryInfo.GetFiles())
		{
			if (fileInfo != null && fileInfo.FullName.Contains("Exception"))
			{
				mFileList.Add(fileInfo.FullName);
			}
		}
	}

	// Token: 0x06019AE2 RID: 105186 RVA: 0x008180C4 File Offset: 0x008164C4
	public bool EndRecordInBattle(ref string reason, int type, string desc)
	{
		if (!this.mIsRecordReplay && !this.mIsRecordProcess)
		{
			reason = "受限";
			return false;
		}
		this.SaveSkillBtnClick();
		this._saveRecordReplay(true);
		this.SaveProcessInBattle();
		this.SaveReconnectCmdInBattle();
		string text = this.sessionID.ToString();
		string text2 = Utility.GetCurrentTimeUnix().ToString();
		this.cacheFilesList.Clear();
		List<string> list = new List<string>();
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[EndRecordInBattle] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			return false;
		}
		string[] files = Directory.GetFiles(rootPath);
		string value = ".zip";
		string value2 = "_InBattle";
		for (int i = 0; i < files.Length; i++)
		{
			if (!files[i].EndsWith(value) && files[i].Contains(value2))
			{
				this.cacheFilesList.Add(files[i]);
			}
		}
		string text3 = string.Format("{0}_{1}_{2}_{3}_{4}_{5}_InBattle_upload.zip", new object[]
		{
			Global.Settings.sdkChannel,
			ClientApplication.adminServer.id,
			text,
			this.type,
			this.mode,
			text2
		});
		string text4 = Path.Combine(rootPath, text3);
		if (LibZipFileReader.CompressFiles(text4, this.cacheFilesList.ToArray()))
		{
			for (int j = 0; j < this.cacheFilesList.Count; j++)
			{
				if (File.Exists(this.cacheFilesList[j]) && !this.cacheFilesList[j].Contains("Exception"))
				{
					File.Delete(this.cacheFilesList[j]);
				}
			}
			this.cacheFilesList.Clear();
			if (!File.Exists(text4))
			{
				string[] files2 = Directory.GetFiles(rootPath);
				string value3 = "_InBattle_upload.zip";
				bool flag = false;
				for (int k = 0; k < files.Length; k++)
				{
					string extension = Path.GetExtension(files[k]);
					if (extension.CompareTo(".zip") == 0)
					{
						string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[k]);
						if (fileNameWithoutExtension.Contains(value3))
						{
							text4 = files[k];
							text3 = fileNameWithoutExtension;
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					reason = "找不到文件 或者已经上传过了";
					return false;
				}
			}
			string fileName = Path.GetFileName(text4);
			try
			{
				Http.UploadFile(string.Format("http://{0}/replay?file={1}", Global.RECORDLOG_GET_ADDRESS, fileName), text4);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("UploadLastFile occur error reason {0}", new object[]
				{
					ex.Message
				});
				reason = "上传失败";
				return false;
			}
			RecordServer.UploadInfo uploadInfo = new RecordServer.UploadInfo
			{
				platform = "Android",
				channel = Global.Settings.sdkChannel.ToString(),
				zone_id = DataManager<PlayerBaseData>.GetInstance().ZoneID.ToString(),
				zone_name = ClientApplication.adminServer.name,
				player_name = DataManager<PlayerBaseData>.GetInstance().Name,
				player_id = DataManager<PlayerBaseData>.GetInstance().RoleID.ToString(),
				replay = text3,
				version = Singleton<VersionManager>.GetInstance().Version(),
				record_type = type.ToString(),
				content = desc
			};
			if (uploadInfo != null)
			{
				string content = JsonMapper.ToJson(uploadInfo);
				try
				{
					Http.SendPostRequest(string.Format("http://{0}/desc", Global.RECORDLOG_POST_ADDRESS), content, null);
				}
				catch (Exception ex2)
				{
					Logger.LogErrorFormat("UploadBattleInFightFile occur error reason {0}", new object[]
					{
						ex2.Message
					});
					reason = "输入用户信息失败";
					return false;
				}
			}
			try
			{
				File.Delete(text4);
			}
			catch (Exception ex3)
			{
				return true;
			}
			return true;
		}
		Logger.LogErrorFormat("[EndRecordInBattle] CompressFiles fail {0}", new object[]
		{
			text4
		});
		reason = "压缩失败";
		for (int l = 0; l < this.cacheFilesList.Count; l++)
		{
			if (File.Exists(this.cacheFilesList[l]) && !this.cacheFilesList.Contains("Exception"))
			{
				File.Delete(this.cacheFilesList[l]);
			}
		}
		this.cacheFilesList.Clear();
		return false;
	}

	// Token: 0x06019AE3 RID: 105187 RVA: 0x00818584 File Offset: 0x00816984
	public void SaveProcessInBattle()
	{
		if (this.m_markSys != null)
		{
			string srcPath = RecordData.GenPath(BeUtility.Format("{0}.mark", this.sessionID));
			string dstPath = RecordData.GenPath(BeUtility.Format("{0}_InBattle.mark", this.sessionID));
			this.m_markSys.SaveInBattle(srcPath, dstPath, RecordData.buffer);
		}
		string pathInBattle = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}_InBattle_process.txt", this.sessionID, this.type, this.mode)));
		if (this.contentRecorder != null)
		{
			string arg = string.Format("s{0}_{1}_{2}process.txt", this.sessionID, this.type, this.mode);
			string fileName = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg);
			string path = RecordData.GenPath(fileName);
			this.FlushFile(path, ref this.contentRecorder);
			this.CopyFileInBattle(path, pathInBattle);
		}
		string pathInBattle2 = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}_InBattle_process_receive_package.txt", this.sessionID, this.type, this.mode)));
		if (this.contentRecorder2 != null)
		{
			string arg2 = string.Format("s{0}_{1}_{2}process_receive_package.txt", this.sessionID, this.type, this.mode);
			string fileName2 = string.Format("{0}_{1}", (Singleton<VersionManager>.GetInstance() == null) ? 0 : Singleton<VersionManager>.GetInstance().ClientShortVersion(), arg2);
			string path2 = RecordData.GenPath(fileName2);
			this.FlushFile(path2, ref this.contentRecorder2);
			this.CopyFileInBattle(path2, pathInBattle2);
		}
	}

	// Token: 0x06019AE4 RID: 105188 RVA: 0x0081873C File Offset: 0x00816B3C
	public void SaveRecordReplayInBattle()
	{
		this._saveRecordReplay(true);
	}

	// Token: 0x06019AE5 RID: 105189 RVA: 0x00818745 File Offset: 0x00816B45
	private void CopyFileInBattle(string path, string pathInBattle)
	{
		if (File.Exists(path))
		{
			File.Copy(path, pathInBattle, true);
		}
	}

	// Token: 0x06019AE6 RID: 105190 RVA: 0x0081875C File Offset: 0x00816B5C
	private void SaveReconnectCmdInBattle()
	{
		if (this.reconnectRecorder != null)
		{
			string text = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}_InBattle_ReconnectPackage.txt", this.sessionID, this.type, this.mode)));
			try
			{
				FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
				StreamWriter streamWriter = new StreamWriter(fileStream);
				streamWriter.Write(this.reconnectRecorder.ToString());
				streamWriter.Flush();
				streamWriter.Close();
				fileStream.Close();
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("SaveReconnectCmdInBattle save file failed!!!!!!:{0} reason {1}\n", new object[]
				{
					text,
					ex.ToString()
				});
			}
		}
	}

	// Token: 0x06019AE7 RID: 105191 RVA: 0x00818814 File Offset: 0x00816C14
	private void SaveFileInBattle(StringBuilder contentRecorder, string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		binaryWriter.Write(contentRecorder.ToString());
		binaryWriter.Flush();
		fileStream.Flush();
		binaryWriter.Close();
		fileStream.Close();
		fileStream.Dispose();
	}

	// Token: 0x06019AE8 RID: 105192 RVA: 0x0081885C File Offset: 0x00816C5C
	private void saveToFile(StringBuilder contentRecorder, string path)
	{
		StreamWriter streamWriter = null;
		try
		{
			streamWriter = new StreamWriter(path);
			streamWriter.Write(contentRecorder.ToString());
			streamWriter.Flush();
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("save file failed!!!!!!:{0} reason {1} \n", new object[]
			{
				path,
				ex.ToString()
			});
			if (streamWriter != null)
			{
				streamWriter.Close();
				streamWriter = null;
			}
		}
	}

	// Token: 0x06019AE9 RID: 105193 RVA: 0x008188D0 File Offset: 0x00816CD0
	private string _getUploadUrl()
	{
		byte b = byte.MaxValue;
		int num = -1;
		if (BattleMain.instance != null)
		{
			IDungeonPlayerDataManager playerManager = BattleMain.instance.GetPlayerManager();
			if (playerManager != null)
			{
				BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
				if (mainPlayer != null)
				{
					b = mainPlayer.playerInfo.seat;
				}
				num = playerManager.GetAllPlayers().Count;
			}
		}
		return string.Format("http://192.168.2.22:60000/race?session={0}&seat={1}&type={2}&allseat={3}", new object[]
		{
			this.sessionID,
			b,
			this.type,
			num
		});
	}

	// Token: 0x06019AEA RID: 105194 RVA: 0x00818968 File Offset: 0x00816D68
	private void _uploadHttpFile(string path)
	{
		string fileName = Path.GetFileName(path);
		Http.UploadFile("http://39.108.138.140:59965?file=" + fileName, path);
	}

	// Token: 0x06019AEB RID: 105195 RVA: 0x00818990 File Offset: 0x00816D90
	public void SaveReconnectCmd()
	{
		if (this.reconnectRecorder != null)
		{
			string text = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}ReconnectPackage.txt", this.sessionID, this.type, this.mode)));
			if (this.reconnectWriter == null)
			{
				try
				{
					this.reconnectWriter = new StreamWriter(text);
					this.reconnectWriter.Write(this.reconnectRecorder.ToString());
					this.reconnectWriter.Flush();
					this.reconnectWriter.Close();
					this.reconnectWriter = null;
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("SaveReconnectCmd save file failed!!!!!!:{0} Reason {1}\n", new object[]
					{
						text,
						ex.Message
					});
					if (this.reconnectWriter != null)
					{
						this.reconnectWriter.Close();
					}
					this.reconnectWriter = null;
				}
				this.SafeRelease(ref this.reconnectRecorder);
			}
			else
			{
				try
				{
					this.reconnectWriter.Write(this.reconnectRecorder.ToString());
					this.reconnectWriter.Flush();
					this.reconnectWriter.Close();
					this.reconnectWriter = null;
				}
				catch (Exception ex2)
				{
					Logger.LogErrorFormat("SaveReconnectCmd2 save file failed!!!!!!:{0} Reason {1}\n", new object[]
					{
						text,
						ex2.Message
					});
					if (this.reconnectWriter != null)
					{
						this.reconnectWriter.Close();
					}
					this.reconnectWriter = null;
				}
				this.SafeRelease(ref this.reconnectRecorder);
			}
		}
	}

	// Token: 0x06019AEC RID: 105196 RVA: 0x00818B1C File Offset: 0x00816F1C
	[Conditional("MG_TEST")]
	public void PushReconnectCmd(string cmdStr)
	{
		if (!this.mIsRecordProcess)
		{
			return;
		}
		if (!this.mIsRecording)
		{
			return;
		}
		if (cmdStr.Equals(string.Empty))
		{
			return;
		}
		if (this.reconnectRecorder == null)
		{
			this.reconnectRecorder = StringBuilderCache.Acquire(16384);
			this.reconnectRecorder.AppendFormat("sessionID:{0} \n", this.sessionID);
		}
		this.reconnectRecorder.Append(string.Format("[{0}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms")));
		this.reconnectRecorder.Append(cmdStr);
		this.reconnectRecorder.Append("\n");
		if (this.reconnectRecorder.Length > 100000)
		{
			string text = RecordData.GenPath(RecordData.GenFileName(string.Format("s{0}_{1}_{2}ReconnectPackage.txt", this.sessionID, this.type, this.mode)));
			if (this.reconnectWriter == null)
			{
				try
				{
					this.reconnectWriter = new StreamWriter(text);
					this.reconnectWriter.Write(this.reconnectRecorder.ToString());
					this.reconnectWriter.Flush();
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("PushReconnectCmd save file failed!!!!!!:{0} reason {1}\n ", new object[]
					{
						text,
						ex.ToString()
					});
					if (this.reconnectWriter != null)
					{
						this.reconnectWriter.Close();
					}
					this.reconnectWriter = null;
				}
				this.SafeRelease(ref this.reconnectRecorder);
			}
			else
			{
				try
				{
					this.reconnectWriter.Write(this.reconnectRecorder.ToString());
					this.reconnectWriter.Flush();
				}
				catch (Exception ex2)
				{
					Logger.LogErrorFormat("PushReconnectCmd2 save file failed!!!!!!:{0} reason {1}\n", new object[]
					{
						text,
						ex2.ToString()
					});
					if (this.reconnectWriter != null)
					{
						this.reconnectWriter.Close();
					}
					this.reconnectWriter = null;
				}
				this.SafeRelease(ref this.reconnectRecorder);
			}
		}
	}

	// Token: 0x040124AE RID: 74926
	protected FrameRandomImp mframeRandom;

	// Token: 0x040124AF RID: 74927
	private RecordData recordData;

	// Token: 0x040124B0 RID: 74928
	private bool mIsRecordProcess;

	// Token: 0x040124B1 RID: 74929
	private int timeAcc;

	// Token: 0x040124B2 RID: 74930
	private StringBuilder contentRecorder;

	// Token: 0x040124B3 RID: 74931
	private StringBuilder contentRecorder2;

	// Token: 0x040124B4 RID: 74932
	private bool mIsRecordReplay;

	// Token: 0x040124B5 RID: 74933
	public string sessionID = string.Empty;

	// Token: 0x040124B6 RID: 74934
	protected BattleType type;

	// Token: 0x040124B7 RID: 74935
	protected eDungeonMode mode;

	// Token: 0x040124B8 RID: 74936
	private bool bNeedUploadRecordFile;

	// Token: 0x040124B9 RID: 74937
	private bool openRecordFunction = true;

	// Token: 0x040124BA RID: 74938
	private bool mIsRecording;

	// Token: 0x040124BB RID: 74939
	private List<string> cacheFilesList = new List<string>();

	// Token: 0x040124BC RID: 74940
	public BattleType battleType = BattleType.None;

	// Token: 0x040124BD RID: 74941
	private StringBuilder reconnectRecorder;

	// Token: 0x040124BE RID: 74942
	private bool mIsLogicServerSaveRecordInTheEnd;

	// Token: 0x040124BF RID: 74943
	private LogicServer mLogicServer;

	// Token: 0x040124C0 RID: 74944
	protected bool m_HaveSaveRecordBattle;

	// Token: 0x040124C1 RID: 74945
	private RecordMarkSystem m_markSys;

	// Token: 0x040124C2 RID: 74946
	private string mLastRecordTimeStamp = string.Empty;

	// Token: 0x040124C3 RID: 74947
	private StreamWriter reconnectWriter;

	// Token: 0x020046C3 RID: 18115
	public class UploadInfo
	{
		// Token: 0x040124C4 RID: 74948
		public string platform;

		// Token: 0x040124C5 RID: 74949
		public string channel;

		// Token: 0x040124C6 RID: 74950
		public string zone_id;

		// Token: 0x040124C7 RID: 74951
		public string zone_name;

		// Token: 0x040124C8 RID: 74952
		public string player_name;

		// Token: 0x040124C9 RID: 74953
		public string player_id;

		// Token: 0x040124CA RID: 74954
		public string version;

		// Token: 0x040124CB RID: 74955
		public string replay;

		// Token: 0x040124CC RID: 74956
		public string record_type;

		// Token: 0x040124CD RID: 74957
		public string content;
	}
}
