using System;
using System.Collections.Generic;
using System.IO;
using GameClient;
using Protocol;

// Token: 0x020046BB RID: 18107
public class RecordData
{
	// Token: 0x06019A78 RID: 105080 RVA: 0x00813F12 File Offset: 0x00812312
	public RecordData()
	{
		this.replayFile = new ReplayFile();
	}

	// Token: 0x06019A79 RID: 105081 RVA: 0x00813F38 File Offset: 0x00812338
	public void CopyData(RecordData data)
	{
		data.sessionID = this.sessionID;
		data.startTime = this.startTime;
		data.clientVersion = this.clientVersion;
		data.pvpDungeonID = this.pvpDungeonID;
		data.playerInfo = this.playerInfo;
		data.dungeonInfo = this.dungeonInfo;
		data.raceType = this.raceType;
		data.startFrame = this.startFrame;
		data.frameInfo = this.frameInfo;
		data.resultInfo = this.resultInfo;
		data.endReq = this.endReq;
		data.duration = this.duration;
		data.replayFile = this.replayFile;
	}

	// Token: 0x06019A7A RID: 105082 RVA: 0x00813FE1 File Offset: 0x008123E1
	public bool IsValid()
	{
		return !string.IsNullOrEmpty(this.sessionID);
	}

	// Token: 0x06019A7B RID: 105083 RVA: 0x00813FF8 File Offset: 0x008123F8
	public void SerializationWithProfile()
	{
		if (!this.IsValid())
		{
			return;
		}
		this.replayFile.header.version = this.clientVersion;
		this.replayFile.header.startTime = this.startTime;
		this.replayFile.header.sessionId = Convert.ToUInt64(this.sessionID);
		if (this.dungeonInfo != null)
		{
			this.replayFile.header.raceType = byte.MaxValue;
		}
		else if (this.raceType == RaceType.PK_3V3 || this.raceType == RaceType.ScoreWar || this.raceType == RaceType.PK_3V3_Melee)
		{
			this.replayFile.header.raceType = (byte)this.raceType;
		}
		else
		{
			this.replayFile.header.raceType = (byte)this.raceType;
		}
		this.replayFile.header.pkDungeonId = (uint)this.pvpDungeonID;
		this.replayFile.header.players = ((this.playerInfo != null) ? this.playerInfo.players : new RacePlayerInfo[0]);
		this.replayFile.header.duration = (uint)this.duration;
		int num = 0;
		for (int i = 0; i < this.frameInfo.Count; i++)
		{
			RecordFrameData recordFrameData = this.frameInfo[i];
			num += recordFrameData.serverFrames.Length;
		}
		this.replayFile.frames = new Frame[num];
		int num2 = 0;
		for (int j = 0; j < this.frameInfo.Count; j++)
		{
			Frame[] serverFrames = this.frameInfo[j].serverFrames;
			for (int k = 0; k < serverFrames.Length; k++)
			{
				this.replayFile.frames[num2++] = serverFrames[k];
			}
		}
		this.replayFile.results = new ReplayRaceResult[2];
		for (int l = 0; l < 2; l++)
		{
			ReplayRaceResult replayRaceResult = new ReplayRaceResult();
			if (this.endReq != null)
			{
				replayRaceResult.pos = this.endReq.end.infoes[l].pos;
				replayRaceResult.result = this.endReq.end.infoes[l].result;
				this.replayFile.results[l] = replayRaceResult;
			}
			else
			{
				replayRaceResult.result = 1;
				replayRaceResult.pos = (byte)l;
				this.replayFile.results[l] = replayRaceResult;
			}
		}
		if (this.replayFile.frames.Length > 2147483647)
		{
			Logger.LogErrorFormat("RecordData Serialization sessionid : {0} ,dungeonId : {1},raceType :{2} clientversion :{3} replay frameLength : {4} is out of MaxRange", new object[]
			{
				this.replayFile.header.sessionId,
				this.replayFile.header.pkDungeonId,
				this.replayFile.header.raceType,
				this.replayFile.header.version,
				this.replayFile.frames.Length
			});
		}
		int num3 = 0;
		try
		{
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
			string fileName = string.Format("{0}{1}_{2}", text, this.sessionID, arg);
			MapViewStream mapViewStream = new MapViewStream(fileName, RecordData.buffer, MapViewStream.FileAccessMode.Write, 0);
			this.replayFile.encode(mapViewStream, ref num3);
			if (this.dungeonInfo != null)
			{
				this.dungeonInfo.encode(mapViewStream, ref num3);
			}
			mapViewStream.Save();
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[RecordData] save file failed Exception {0}", new object[]
			{
				ex.Message
			});
		}
	}

	// Token: 0x06019A7C RID: 105084 RVA: 0x00814474 File Offset: 0x00812874
	public void Serialization(bool isInBattle = false)
	{
		Logger.LogForReplay("[RECORD]Start Serialization", new object[0]);
		this.replayFile.header.version = this.clientVersion;
		this.replayFile.header.startTime = this.startTime;
		this.replayFile.header.sessionId = Convert.ToUInt64(this.sessionID);
		if (this.dungeonInfo != null)
		{
			this.replayFile.header.raceType = byte.MaxValue;
		}
		else if (this.raceType == RaceType.PK_3V3 || this.raceType == RaceType.ScoreWar || this.raceType == RaceType.PK_3V3_Melee)
		{
			this.replayFile.header.raceType = (byte)this.raceType;
		}
		else
		{
			this.replayFile.header.raceType = (byte)this.raceType;
		}
		this.replayFile.header.pkDungeonId = (uint)this.pvpDungeonID;
		this.replayFile.header.players = ((this.playerInfo != null) ? this.playerInfo.players : new RacePlayerInfo[0]);
		this.replayFile.header.duration = (uint)this.duration;
		if (this.playerInfo != null)
		{
			this.replayFile.header.battleFlag = this.playerInfo.battleFlag;
		}
		else if (this.dungeonInfo != null)
		{
			this.replayFile.header.battleFlag = this.dungeonInfo.battleFlag;
		}
		int num = 0;
		for (int i = 0; i < this.frameInfo.Count; i++)
		{
			RecordFrameData recordFrameData = this.frameInfo[i];
			num += recordFrameData.serverFrames.Length;
		}
		this.replayFile.frames = new Frame[num];
		int num2 = 0;
		for (int j = 0; j < this.frameInfo.Count; j++)
		{
			Frame[] serverFrames = this.frameInfo[j].serverFrames;
			for (int k = 0; k < serverFrames.Length; k++)
			{
				this.replayFile.frames[num2++] = serverFrames[k];
			}
		}
		this.replayFile.results = new ReplayRaceResult[2];
		for (int l = 0; l < 2; l++)
		{
			ReplayRaceResult replayRaceResult = new ReplayRaceResult();
			if (this.endReq != null)
			{
				replayRaceResult.pos = this.endReq.end.infoes[l].pos;
				replayRaceResult.result = this.endReq.end.infoes[l].result;
				this.replayFile.results[l] = replayRaceResult;
			}
			else
			{
				replayRaceResult.result = 1;
				replayRaceResult.pos = (byte)l;
				this.replayFile.results[l] = replayRaceResult;
			}
		}
		if (this.replayFile.frames.Length > 2147483647)
		{
			Logger.LogErrorFormat("RecordData Serialization sessionid : {0} ,dungeonId : {1},raceType :{2} clientversion :{3} replay frameLength : {4} is out of MaxRange", new object[]
			{
				this.replayFile.header.sessionId,
				this.replayFile.header.pkDungeonId,
				this.replayFile.header.raceType,
				this.replayFile.header.version,
				this.replayFile.frames.Length
			});
		}
		int num3 = 0;
		string text = (!isInBattle) ? RecordData.GenPath(this.sessionID) : RecordData.GenPath(this.sessionID + "_InBattle");
		try
		{
			MapViewStream mapViewStream = new MapViewStream(text, RecordData.buffer, MapViewStream.FileAccessMode.Write, 0);
			this.replayFile.encode(mapViewStream, ref num3);
			if (this.dungeonInfo != null)
			{
				this.dungeonInfo.encode(mapViewStream, ref num3);
			}
			mapViewStream.Save();
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[RecordData] save file failed {0},Exception {1}", new object[]
			{
				text,
				ex.Message
			});
		}
		Logger.LogForReplay("[RECORD]End Serialization {0} pos:{1}", new object[]
		{
			this.sessionID,
			num3
		});
	}

	// Token: 0x06019A7D RID: 105085 RVA: 0x008148C8 File Offset: 0x00812CC8
	public void DeSerialiaction(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryReader binaryReader = new BinaryReader(fileStream);
		byte[] array = binaryReader.ReadBytes((int)fileStream.Length);
		Logger.LogForReplay("[RECORD]Start DeSerialiaction:{0} buffLen:{1}", new object[]
		{
			path,
			array.Length
		});
		int num = 0;
		this.replayFile.decode(array, ref num);
		if (this.replayFile.header.raceType == 255)
		{
			this.dungeonInfo = new SceneDungeonStartRes();
			this.dungeonInfo.decode(array, ref num);
		}
		binaryReader.Close();
		fileStream.Close();
		this.clientVersion = this.replayFile.header.version;
		this.startTime = this.replayFile.header.startTime;
		this.sessionID = this.replayFile.header.sessionId.ToString();
		this.pvpDungeonID = (int)this.replayFile.header.pkDungeonId;
		this.duration = (int)this.replayFile.header.duration;
		Logger.LogForReplay("[RECORD]End DeSerialiaction", new object[0]);
	}

	// Token: 0x06019A7E RID: 105086 RVA: 0x008149EC File Offset: 0x00812DEC
	public static string GenFileName(string subname = null)
	{
		DateTime now = DateTime.Now;
		string text = string.Format("{0}-{1}-{2}-{3}-{4}-{5}", new object[]
		{
			now.Year,
			now.Month,
			now.Day,
			now.Hour,
			now.Minute,
			now.Second
		});
		string result = string.Empty;
		if (subname == null)
		{
			result = string.Format("{3}", new object[]
			{
				text,
				DataManager<PlayerBaseData>.GetInstance().RoleID,
				Singleton<VersionManager>.GetInstance().ServerVersion(),
				(subname != null) ? subname : RecordData.RECORD_FILE_NAME
			});
		}
		else
		{
			result = string.Format("{0}_{1}_{2}_{3}", new object[]
			{
				text,
				DataManager<PlayerBaseData>.GetInstance().RoleID,
				Singleton<VersionManager>.GetInstance().ServerVersion(),
				(subname != null) ? subname : RecordData.RECORD_FILE_NAME
			});
		}
		return result;
	}

	// Token: 0x06019A7F RID: 105087 RVA: 0x00814B18 File Offset: 0x00812F18
	public static string GetRootPath()
	{
		return Utility.GetWriteablePath() + "RecordLog/";
	}

	// Token: 0x06019A80 RID: 105088 RVA: 0x00814B38 File Offset: 0x00812F38
	public static string GenPath(string fileName)
	{
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Directory.CreateDirectory(rootPath);
		}
		return rootPath + fileName;
	}

	// Token: 0x06019A81 RID: 105089 RVA: 0x00814B64 File Offset: 0x00812F64
	public static void SaveReplayFile(string sessionID, byte[] contents, int count, string format = "")
	{
		string text = RecordData.GenPath(sessionID + format);
		try
		{
			FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			binaryWriter.Write(contents, 0, count);
			binaryWriter.Flush();
			binaryWriter.Close();
			fileStream.Close();
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[RecordData] save file failed {0}", new object[]
			{
				text
			});
		}
	}

	// Token: 0x0401247B RID: 74875
	public static int BUFF_SIZE = 262144;

	// Token: 0x0401247C RID: 74876
	public static byte[] buffer = new byte[RecordData.BUFF_SIZE];

	// Token: 0x0401247D RID: 74877
	public static string RECORD_FILE_NAME = "record.bin";

	// Token: 0x0401247E RID: 74878
	public string sessionID;

	// Token: 0x0401247F RID: 74879
	public uint startTime;

	// Token: 0x04012480 RID: 74880
	public uint clientVersion;

	// Token: 0x04012481 RID: 74881
	public int pvpDungeonID;

	// Token: 0x04012482 RID: 74882
	public int duration = 30;

	// Token: 0x04012483 RID: 74883
	public WorldNotifyRaceStart playerInfo;

	// Token: 0x04012484 RID: 74884
	public SceneDungeonStartRes dungeonInfo;

	// Token: 0x04012485 RID: 74885
	public RaceType raceType;

	// Token: 0x04012486 RID: 74886
	public uint startFrame;

	// Token: 0x04012487 RID: 74887
	public List<RecordFrameData> frameInfo = new List<RecordFrameData>();

	// Token: 0x04012488 RID: 74888
	public SceneMatchPkRaceEnd resultInfo;

	// Token: 0x04012489 RID: 74889
	public RelaySvrEndGameReq endReq;

	// Token: 0x0401248A RID: 74890
	public ReplayFile replayFile;
}
