using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameClient;
using UnityEngine;

// Token: 0x020046C0 RID: 18112
public class RecordMarkSystem
{
	// Token: 0x06019A88 RID: 105096 RVA: 0x00814C98 File Offset: 0x00813098
	public RecordMarkSystem(RECORD_MODE mode, object inst, string version, string sessionId, BattleType type, eDungeonMode dungeonMode)
	{
		this.m_Mode = mode;
		this.m_DungoneMode = dungeonMode;
		this.m_battleType = type;
		this.m_sessionId = sessionId;
		this.m_version = version;
		byte[] array = StringHelper.StringToUTF8Bytes(this.m_version);
		this.m_versionStrLen = 2;
		if (array.Length > 0)
		{
			this.m_versionStrLen += array.Length - 1;
		}
		this.m_Inst = (inst as FrameSync);
	}

	// Token: 0x06019A89 RID: 105097 RVA: 0x00814D21 File Offset: 0x00813121
	public void SetRandom(FrameRandomImp rand)
	{
		this.m_frameRandom = rand;
	}

	// Token: 0x06019A8A RID: 105098 RVA: 0x00814D2A File Offset: 0x0081312A
	public void SetLogicServer(LogicServer inst)
	{
	}

	// Token: 0x06019A8B RID: 105099 RVA: 0x00814D2C File Offset: 0x0081312C
	public void BeginUpdate()
	{
		if (this.m_Mode != RECORD_MODE.REPLAY)
		{
			return;
		}
		if (this.m_ReplayFrameDatas == null)
		{
			return;
		}
		if (this.m_ReplayFrameDatas.ContainsKey(this.m_frameDataIndex))
		{
			this.m_curFrameData = this.m_ReplayFrameDatas[this.m_frameDataIndex];
		}
	}

	// Token: 0x06019A8C RID: 105100 RVA: 0x00814D80 File Offset: 0x00813180
	public void EndUpdate()
	{
		this.m_frameDataIndex += 1U;
		if (this.m_Mode != RECORD_MODE.RECORD)
		{
			this.m_curFrameData = null;
			return;
		}
		if (this.m_FrameDatas == null)
		{
			this.m_FrameDatas = new List<FrameMarkDataRunTime>();
		}
		if (this.m_curFrameData != null)
		{
			this.m_FrameDatas.Add(this.m_curFrameData);
		}
		this.m_curFrameData = null;
	}

	// Token: 0x06019A8D RID: 105101 RVA: 0x00814DE7 File Offset: 0x008131E7
	public uint GetCurFrame()
	{
		if (this.m_Inst == null)
		{
			return 0U;
		}
		return this.m_Inst.curFrame;
	}

	// Token: 0x06019A8E RID: 105102 RVA: 0x00814E04 File Offset: 0x00813204
	public void DumpProcessFileFromMark(string path)
	{
		this.Load(path);
		Dictionary<uint, string> markReadableDic = this.GetMarkReadableDic();
		List<NodeRunTimeData> list = new List<NodeRunTimeData>();
		foreach (KeyValuePair<uint, FrameMarkDataRunTime> keyValuePair in this.m_ReplayFrameDatas)
		{
			FrameMarkDataRunTime value = keyValuePair.Value;
			foreach (KeyValuePair<uint, MarkDataRunTime> keyValuePair2 in value.m_FrameDatas)
			{
				MarkDataRunTime value2 = keyValuePair2.Value;
				for (int i = 0; i < value2.m_CallData.Count; i++)
				{
					NodeData nodeData = value2.m_CallData[i];
					List<NodeRunTimeData> list2 = list;
					NodeRunTimeData nodeRunTimeData = new NodeRunTimeData();
					nodeRunTimeData.totalCallNum = nodeData.totalCallNum;
					NodeRunTimeData nodeRunTimeData2 = nodeRunTimeData;
					Dictionary<uint, MarkDataRunTime>.Enumerator enumerator2;
					KeyValuePair<uint, MarkDataRunTime> keyValuePair3 = enumerator2.Current;
					nodeRunTimeData2.markId = keyValuePair3.Key;
					nodeRunTimeData.callNum = nodeData.callNum;
					nodeRunTimeData.timeStamp = nodeData.timeStamp;
					nodeRunTimeData.curFrame = value.curFrame;
					nodeRunTimeData.randSeed = nodeData.randSeed;
					nodeRunTimeData.randCallNum = nodeData.randCallNum;
					nodeRunTimeData.paramDatas = nodeData.paramDatas;
					nodeRunTimeData.paramStr = nodeData.paramStrings;
					list2.Add(nodeRunTimeData);
				}
			}
		}
		list.Sort(new Comparison<NodeRunTimeData>(this.SortByCallNum));
		StringBuilder stringBuilder = new StringBuilder(string.Format("[Normal Battle Log]Version:{0} SessionID:{1} BattleType:{2} DungeonMode:{3}\r\n", new object[]
		{
			this.m_version,
			this.m_sessionId,
			this.m_battleType,
			this.m_DungoneMode
		}));
		StringBuilder stringBuilder2 = new StringBuilder();
		for (int j = 0; j < list.Count; j++)
		{
			MyExtensionMethods.Clear(stringBuilder2);
			NodeRunTimeData nodeRunTimeData3 = list[j];
			string format = null;
			if (markReadableDic.TryGetValue(nodeRunTimeData3.markId, out format))
			{
				List<object> list3 = new List<object>();
				for (int k = 0; k < nodeRunTimeData3.paramDatas.Length; k++)
				{
					list3.Add(nodeRunTimeData3.paramDatas[k]);
				}
				for (int l = 0; l < nodeRunTimeData3.paramStr.Length; l++)
				{
					list3.Add(nodeRunTimeData3.paramStr[l]);
				}
				object[] args = list3.ToArray();
				stringBuilder2.AppendFormat(format, args);
			}
			else
			{
				for (int m = 0; m < nodeRunTimeData3.paramDatas.Length; m++)
				{
					stringBuilder2.Append(nodeRunTimeData3.paramDatas[m]);
					stringBuilder2.Append("|");
				}
				for (int n = 0; n < nodeRunTimeData3.paramStr.Length; n++)
				{
					stringBuilder2.Append(nodeRunTimeData3.paramStr[n]);
					stringBuilder2.Append("|");
				}
			}
			string str = string.Format("[{0}][{5}]T[{1}]C[{2}][0x{4:X}]F[{3}]R[{6},{7}]", new object[]
			{
				Utility.GetDateTimeByUnixTime(nodeRunTimeData3.timeStamp).ToString("yyyy-MM-dd HH:mm:ss:ms"),
				nodeRunTimeData3.totalCallNum,
				nodeRunTimeData3.callNum,
				nodeRunTimeData3.curFrame,
				nodeRunTimeData3.markId,
				nodeRunTimeData3.timeStamp,
				nodeRunTimeData3.randCallNum,
				nodeRunTimeData3.randSeed
			});
			stringBuilder.AppendLine(str + stringBuilder2.ToString());
		}
		TextWriter textWriter = null;
		string text = Path.GetFileNameWithoutExtension(path);
		string directoryName = Path.GetDirectoryName(path);
		text = string.Format("{0}/{1}_Process.txt", directoryName, text);
		try
		{
			textWriter = File.CreateText(text);
			textWriter.Write(stringBuilder.ToString());
			textWriter.Flush();
			textWriter.Close();
		}
		catch (Exception ex)
		{
			if (textWriter != null)
			{
				textWriter.Close();
				textWriter = null;
			}
			Logger.LogErrorFormat("[DumpMark] {0} failed {1}", new object[]
			{
				text,
				ex.ToString()
			});
		}
	}

	// Token: 0x06019A8F RID: 105103 RVA: 0x0081522C File Offset: 0x0081362C
	private Dictionary<uint, string> GetMarkReadableDic()
	{
		Dictionary<uint, string> dictionary = new Dictionary<uint, string>();
		StreamReader streamReader = null;
		try
		{
			string path = Application.dataPath + "/Editor/RecordMarkDesc/ReadableMarkMap.txt";
			if (!File.Exists(path))
			{
				Logger.LogErrorFormat("请先生成水印描述问题件", new object[0]);
				return dictionary;
			}
			streamReader = new StreamReader(path);
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				string[] array = text.Split(new string[]
				{
					"|@@|"
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length >= 2)
				{
					uint num = Convert.ToUInt32(array[0], 16);
					if (dictionary.ContainsKey(num))
					{
						Logger.LogErrorFormat("has same mark id:{0} in desc file", new object[]
						{
							num
						});
					}
					else
					{
						dictionary.Add(num, array[array.Length - 1]);
					}
				}
			}
			streamReader.Close();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString());
			if (streamReader != null)
			{
				streamReader.Close();
			}
		}
		return dictionary;
	}

	// Token: 0x06019A90 RID: 105104 RVA: 0x00815338 File Offset: 0x00813738
	private int SortByCallNum(NodeRunTimeData a, NodeRunTimeData b)
	{
		int num = a.totalCallNum.CompareTo(b.totalCallNum);
		if (num == 0)
		{
			return a.callNum.CompareTo(b.callNum);
		}
		return num;
	}

	// Token: 0x06019A91 RID: 105105 RVA: 0x00815370 File Offset: 0x00813770
	public NodeData Mark(uint id)
	{
		NodeData nodeData;
		if (this.m_Mode == RECORD_MODE.RECORD)
		{
			if (this.m_curFrameData == null)
			{
				this.m_curFrameData = FrameMarkDataRunTimePool.Get();
				this.m_curFrameData.sequence = this.m_frameDataIndex;
				this.m_curFrameData.curFrame = this.GetCurFrame();
			}
			this.m_totalCallNum += 1U;
			if (!this.m_curFrameData.m_FrameDatas.ContainsKey(id))
			{
				this.m_curFrameData.m_FrameDatas.Add(id, MarkDataRunTimePool.Get());
			}
			MarkDataRunTime markDataRunTime = this.m_curFrameData.m_FrameDatas[id];
			markDataRunTime.curCallNum += 1U;
			nodeData = MarkNodeDataPool.Get();
			nodeData.callNum = markDataRunTime.curCallNum;
			nodeData.totalCallNum = this.m_totalCallNum;
			nodeData.randCallNum = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.callNum);
			nodeData.randSeed = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.GetSeed());
			nodeData.timeStamp = (ulong)Utility.GetTimeStamp();
			markDataRunTime.m_CallData.Add(nodeData);
		}
		else
		{
			nodeData = MarkNodeDataPool.Get();
		}
		return nodeData;
	}

	// Token: 0x06019A92 RID: 105106 RVA: 0x008154A4 File Offset: 0x008138A4
	public void Check(uint id, NodeData data)
	{
	}

	// Token: 0x06019A93 RID: 105107 RVA: 0x008154A8 File Offset: 0x008138A8
	private void _MarkAll(uint id, int[] datas, string[] datasStr)
	{
		if (this.m_Mode == RECORD_MODE.RECORD)
		{
			if (this.m_curFrameData == null)
			{
				this.m_curFrameData = FrameMarkDataRunTimePool.Get();
				this.m_curFrameData.sequence = this.m_frameDataIndex;
				this.m_curFrameData.curFrame = this.GetCurFrame();
			}
			this.m_totalCallNum += 1U;
			if (!this.m_curFrameData.m_FrameDatas.ContainsKey(id))
			{
				this.m_curFrameData.m_FrameDatas.Add(id, MarkDataRunTimePool.Get());
			}
			MarkDataRunTime markDataRunTime = this.m_curFrameData.m_FrameDatas[id];
			markDataRunTime.curCallNum += 1U;
			NodeData nodeData = MarkNodeDataPool.Get();
			nodeData.callNum = markDataRunTime.curCallNum;
			nodeData.totalCallNum = this.m_totalCallNum;
			nodeData.timeStamp = (ulong)Utility.GetTimeStamp();
			nodeData.randCallNum = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.callNum);
			nodeData.randSeed = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.GetSeed());
			nodeData.paramDatas = datas;
			nodeData.paramStrings = datasStr;
			markDataRunTime.m_CallData.Add(nodeData);
		}
	}

	// Token: 0x06019A94 RID: 105108 RVA: 0x008155E1 File Offset: 0x008139E1
	public void Mark(uint id, string[] dataStr, params int[] datas)
	{
		this._MarkAll(id, datas, dataStr);
	}

	// Token: 0x06019A95 RID: 105109 RVA: 0x008155EC File Offset: 0x008139EC
	public void Mark(uint id, int[] datas, params string[] datasStr)
	{
		this._MarkAll(id, datas, datasStr);
	}

	// Token: 0x06019A96 RID: 105110 RVA: 0x008155F8 File Offset: 0x008139F8
	public void MarkString(uint id, params string[] datas)
	{
		if (this.m_Mode == RECORD_MODE.RECORD)
		{
			if (this.m_curFrameData == null)
			{
				this.m_curFrameData = FrameMarkDataRunTimePool.Get();
				this.m_curFrameData.sequence = this.m_frameDataIndex;
				this.m_curFrameData.curFrame = this.GetCurFrame();
			}
			this.m_totalCallNum += 1U;
			if (!this.m_curFrameData.m_FrameDatas.ContainsKey(id))
			{
				this.m_curFrameData.m_FrameDatas.Add(id, MarkDataRunTimePool.Get());
			}
			MarkDataRunTime markDataRunTime = this.m_curFrameData.m_FrameDatas[id];
			markDataRunTime.curCallNum += 1U;
			NodeData nodeData = MarkNodeDataPool.Get();
			nodeData.callNum = markDataRunTime.curCallNum;
			nodeData.totalCallNum = this.m_totalCallNum;
			nodeData.timeStamp = (ulong)Utility.GetTimeStamp();
			nodeData.randCallNum = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.callNum);
			nodeData.randSeed = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.GetSeed());
			nodeData.paramStrings = datas;
			markDataRunTime.m_CallData.Add(nodeData);
		}
	}

	// Token: 0x06019A97 RID: 105111 RVA: 0x0081572C File Offset: 0x00813B2C
	private bool _CommonCheck(uint id, ref NodeData curNodeData)
	{
		if (this.m_curFrameData == null)
		{
			if (this.m_ReplayFrameDatas.ContainsKey(this.m_frameDataIndex))
			{
				this.m_curFrameData = this.m_ReplayFrameDatas[this.m_frameDataIndex];
			}
			if (this.m_curFrameData == null)
			{
				Logger.LogErrorFormat("m_curFrameData is null {0} {1} {2}", new object[]
				{
					id,
					this.m_frameDataIndex,
					this.m_totalCallNum
				});
				Debug.Break();
				return false;
			}
		}
		this.m_totalCallNum += 1U;
		if (!this.m_curFrameData.m_FrameDatas.ContainsKey(id))
		{
			Logger.LogErrorFormat("MarkId can not be finded {0} {1} {2}", new object[]
			{
				id,
				this.m_frameDataIndex,
				this.m_totalCallNum
			});
			Debug.Break();
			return false;
		}
		MarkDataRunTime markDataRunTime = this.m_curFrameData.m_FrameDatas[id];
		markDataRunTime.curCallNum += 1U;
		if ((ulong)markDataRunTime.curCallNum > (ulong)((long)markDataRunTime.m_CallData.Count))
		{
			Logger.LogErrorFormat("curCallNum larger {0} {1} {2} {3} {4}", new object[]
			{
				id,
				this.m_frameDataIndex,
				this.m_totalCallNum,
				markDataRunTime.curCallNum,
				markDataRunTime.m_CallData.Count
			});
			Debug.Break();
			return false;
		}
		curNodeData = markDataRunTime.m_CallData[(int)(markDataRunTime.curCallNum - 1U)];
		if (curNodeData.callNum != markDataRunTime.curCallNum)
		{
			Logger.LogErrorFormat("callNum is not equal {0} {1} {2} {3} {4}", new object[]
			{
				id,
				this.m_frameDataIndex,
				this.m_totalCallNum,
				curNodeData.callNum,
				markDataRunTime.curCallNum
			});
			Debug.Break();
			return false;
		}
		if (curNodeData.totalCallNum != this.m_totalCallNum)
		{
			Logger.LogErrorFormat("totalCallNum is not equal {0} {1} {2} {3} {4}", new object[]
			{
				this.m_totalCallNum,
				curNodeData.totalCallNum,
				curNodeData.callNum,
				this.m_frameDataIndex,
				id
			});
			Debug.Break();
			return false;
		}
		return true;
	}

	// Token: 0x06019A98 RID: 105112 RVA: 0x0081599C File Offset: 0x00813D9C
	public void MarkInt(uint id, params int[] datas)
	{
		if (this.m_Mode == RECORD_MODE.RECORD)
		{
			if (this.m_curFrameData == null)
			{
				this.m_curFrameData = FrameMarkDataRunTimePool.Get();
				this.m_curFrameData.sequence = this.m_frameDataIndex;
				this.m_curFrameData.curFrame = this.GetCurFrame();
			}
			this.m_totalCallNum += 1U;
			if (!this.m_curFrameData.m_FrameDatas.ContainsKey(id))
			{
				this.m_curFrameData.m_FrameDatas.Add(id, MarkDataRunTimePool.Get());
			}
			MarkDataRunTime markDataRunTime = this.m_curFrameData.m_FrameDatas[id];
			markDataRunTime.curCallNum += 1U;
			NodeData nodeData = MarkNodeDataPool.Get();
			nodeData.callNum = markDataRunTime.curCallNum;
			nodeData.totalCallNum = this.m_totalCallNum;
			nodeData.timeStamp = (ulong)Utility.GetCurrentTimeUnix();
			nodeData.randCallNum = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.callNum);
			nodeData.randSeed = ((this.m_frameRandom == null) ? 0U : this.m_frameRandom.GetSeed());
			nodeData.paramDatas = datas;
			markDataRunTime.m_CallData.Add(nodeData);
		}
	}

	// Token: 0x06019A99 RID: 105113 RVA: 0x00815AD0 File Offset: 0x00813ED0
	public void _WriteLeftFrameData(string path, byte[] buffer, List<FrameMarkDataRunTime> frameDatas, bool isInBattle)
	{
		FileStream fileStream = null;
		BinaryWriter binaryWriter = null;
		int fileOffset = 0;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
			binaryWriter = new BinaryWriter(fileStream);
			int offset = 10 + this.m_versionStrLen;
			binaryWriter.Seek(offset, SeekOrigin.Begin);
			fileOffset = (int)fileStream.Length;
			binaryWriter.Write(this.m_LastFrameCount + frameDatas.Count);
			binaryWriter.Flush();
			fileStream.Flush();
			binaryWriter.Close();
			fileStream.Close();
		}
		catch (Exception ex)
		{
			if (binaryWriter != null)
			{
				binaryWriter.Close();
				binaryWriter = null;
			}
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream = null;
			}
			Logger.LogErrorFormat("Flush file Failed {0}", new object[]
			{
				ex.ToString()
			});
			return;
		}
		MapViewStream mapViewStream = new MapViewStream(path, buffer, MapViewStream.FileAccessMode.Write, fileOffset);
		int num = 0;
		for (int i = 0; i < frameDatas.Count; i++)
		{
			FrameMarkDataRunTime frameMarkDataRunTime = frameDatas[i];
			FrameMarkData frameMarkData = (!isInBattle) ? FrameMarkDataPool.Get() : new FrameMarkData();
			frameMarkData.frame = frameMarkDataRunTime.curFrame;
			frameMarkData.sequence = frameMarkDataRunTime.sequence;
			frameMarkData.markDatas = new MarkData[frameMarkDataRunTime.m_FrameDatas.Count];
			Dictionary<uint, MarkDataRunTime>.Enumerator enumerator = frameMarkDataRunTime.m_FrameDatas.GetEnumerator();
			int num2 = 0;
			while (enumerator.MoveNext())
			{
				MarkData markData = (!isInBattle) ? MarkDataPool.Get() : new MarkData();
				MarkData markData2 = markData;
				KeyValuePair<uint, MarkDataRunTime> keyValuePair = enumerator.Current;
				markData2.id = keyValuePair.Key;
				frameMarkData.markDatas[num2] = markData;
				KeyValuePair<uint, MarkDataRunTime> keyValuePair2 = enumerator.Current;
				MarkDataRunTime value = keyValuePair2.Value;
				markData.markDatas = value.m_CallData.ToArray();
				num2++;
			}
			frameMarkData.encode(mapViewStream, ref num);
			if (!isInBattle)
			{
				FrameMarkDataPool.Release(frameMarkData);
			}
		}
		bool flag = mapViewStream.Save();
		if (flag && !isInBattle)
		{
			this.m_LastFrameCount += frameDatas.Count;
			for (int j = 0; j < frameDatas.Count; j++)
			{
				FrameMarkDataRunTimePool.Release(frameDatas[j]);
			}
			frameDatas.Clear();
		}
	}

	// Token: 0x06019A9A RID: 105114 RVA: 0x00815D04 File Offset: 0x00814104
	private void _WriteWholeFrameData(string path, byte[] buffer, List<FrameMarkDataRunTime> frameDatas, bool isInBattle)
	{
		MarkFileData markFileData = new MarkFileData();
		markFileData.markDatas = new FrameMarkData[frameDatas.Count];
		markFileData.version = this.m_version;
		markFileData.battleType = (byte)this.m_battleType;
		markFileData.dungeonMode = (byte)this.m_DungoneMode;
		markFileData.sessionId = Convert.ToUInt64(this.m_sessionId);
		for (int i = 0; i < frameDatas.Count; i++)
		{
			FrameMarkDataRunTime frameMarkDataRunTime = frameDatas[i];
			FrameMarkData frameMarkData = (!isInBattle) ? FrameMarkDataPool.Get() : new FrameMarkData();
			frameMarkData.frame = frameMarkDataRunTime.curFrame;
			frameMarkData.sequence = frameMarkDataRunTime.sequence;
			markFileData.markDatas[i] = frameMarkData;
			frameMarkData.markDatas = new MarkData[frameMarkDataRunTime.m_FrameDatas.Count];
			Dictionary<uint, MarkDataRunTime>.Enumerator enumerator = frameMarkDataRunTime.m_FrameDatas.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				MarkData markData = (!isInBattle) ? MarkDataPool.Get() : new MarkData();
				MarkData markData2 = markData;
				KeyValuePair<uint, MarkDataRunTime> keyValuePair = enumerator.Current;
				markData2.id = keyValuePair.Key;
				frameMarkData.markDatas[num] = markData;
				KeyValuePair<uint, MarkDataRunTime> keyValuePair2 = enumerator.Current;
				MarkDataRunTime value = keyValuePair2.Value;
				markData.markDatas = value.m_CallData.ToArray();
				num++;
			}
		}
		MapViewStream mapViewStream = new MapViewStream(path, buffer, MapViewStream.FileAccessMode.Write, 0);
		int num2 = 0;
		markFileData.encode(mapViewStream, ref num2);
		bool flag = mapViewStream.Save();
		if (flag && !isInBattle)
		{
			markFileData.Recycle();
			this.m_LastFrameCount = frameDatas.Count;
			for (int j = 0; j < frameDatas.Count; j++)
			{
				FrameMarkDataRunTimePool.Release(frameDatas[j]);
			}
			frameDatas.Clear();
		}
	}

	// Token: 0x06019A9B RID: 105115 RVA: 0x00815EC4 File Offset: 0x008142C4
	public void Flush(string path, byte[] buffer)
	{
		if (this.m_Mode == RECORD_MODE.REPLAY)
		{
			return;
		}
		if (this.m_FrameDatas == null || this.m_FrameDatas.Count <= 0)
		{
			return;
		}
		if (this.m_LastFrameCount > 0)
		{
			this._WriteLeftFrameData(path, buffer, this.m_FrameDatas, false);
		}
		else
		{
			this._WriteWholeFrameData(path, buffer, this.m_FrameDatas, false);
		}
	}

	// Token: 0x06019A9C RID: 105116 RVA: 0x00815F2C File Offset: 0x0081432C
	public void Save(string path, byte[] buffer)
	{
		if (this.m_Mode == RECORD_MODE.REPLAY)
		{
			return;
		}
		this.EndUpdate();
		if (this.m_FrameDatas == null || this.m_FrameDatas.Count <= 0)
		{
			return;
		}
		if (this.m_LastFrameCount > 0)
		{
			this._WriteLeftFrameData(path, buffer, this.m_FrameDatas, false);
		}
		else
		{
			this._WriteWholeFrameData(path, buffer, this.m_FrameDatas, false);
		}
		FrameMarkDataRunTimePool.Clear();
		FrameMarkDataPool.Clear();
		MarkDataRunTimePool.Clear();
		MarkDataPool.Clear();
		MarkNodeDataPool.Clear();
	}

	// Token: 0x06019A9D RID: 105117 RVA: 0x00815FB4 File Offset: 0x008143B4
	public void SaveInBattle(string srcPath, string dstPath, byte[] buffer)
	{
		List<FrameMarkDataRunTime> list = new List<FrameMarkDataRunTime>();
		if (this.m_FrameDatas != null)
		{
			list.AddRange(this.m_FrameDatas);
		}
		if (this.m_curFrameData != null)
		{
			list.Add(this.m_curFrameData);
		}
		try
		{
			if (File.Exists(dstPath))
			{
				File.Delete(dstPath);
			}
			if (File.Exists(srcPath))
			{
				File.Copy(srcPath, dstPath);
			}
			if (list != null && list.Count > 0)
			{
				if (this.m_LastFrameCount > 0)
				{
					this._WriteLeftFrameData(dstPath, buffer, list, true);
				}
				else
				{
					this._WriteWholeFrameData(dstPath, buffer, list, true);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("Save MarkFile In Battle Failed: {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x06019A9E RID: 105118 RVA: 0x00816088 File Offset: 0x00814488
	public void Load(string path)
	{
		if (!File.Exists(path))
		{
			return;
		}
		this.m_ReplayFrameDatas = new Dictionary<uint, FrameMarkDataRunTime>();
		FileStream fileStream = null;
		BinaryReader binaryReader = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			binaryReader = new BinaryReader(fileStream);
			byte[] buffer = binaryReader.ReadBytes((int)fileStream.Length);
			binaryReader.Close();
			fileStream.Close();
			binaryReader = null;
			fileStream = null;
			MarkFileData markFileData = new MarkFileData();
			int num = 0;
			markFileData.decode(buffer, ref num);
			this.m_battleType = (BattleType)markFileData.battleType;
			this.m_sessionId = markFileData.sessionId.ToString();
			this.m_DungoneMode = (eDungeonMode)markFileData.dungeonMode;
			this.m_version = markFileData.version;
			for (int i = 0; i < markFileData.markDatas.Length; i++)
			{
				FrameMarkData frameMarkData = markFileData.markDatas[i];
				FrameMarkDataRunTime frameMarkDataRunTime = new FrameMarkDataRunTime
				{
					curFrame = frameMarkData.frame,
					sequence = frameMarkData.sequence
				};
				this.m_ReplayFrameDatas.Add(frameMarkData.sequence, frameMarkDataRunTime);
				for (int j = 0; j < frameMarkData.markDatas.Length; j++)
				{
					MarkData markData = frameMarkData.markDatas[j];
					MarkDataRunTime markDataRunTime = new MarkDataRunTime();
					frameMarkDataRunTime.m_FrameDatas.Add(markData.id, markDataRunTime);
					for (int k = 0; k < markData.markDatas.Length; k++)
					{
						markDataRunTime.m_CallData.Add(markData.markDatas[k]);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("Read MarkData failed reason :{0}", new object[]
			{
				ex.ToString()
			});
			if (binaryReader != null)
			{
				binaryReader.Close();
				binaryReader = null;
			}
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream = null;
			}
		}
	}

	// Token: 0x0401249C RID: 74908
	private FrameMarkDataRunTime m_curFrameData;

	// Token: 0x0401249D RID: 74909
	private List<FrameMarkDataRunTime> m_FrameDatas;

	// Token: 0x0401249E RID: 74910
	private Dictionary<uint, FrameMarkDataRunTime> m_ReplayFrameDatas;

	// Token: 0x0401249F RID: 74911
	private int m_LastFrameCount;

	// Token: 0x040124A0 RID: 74912
	private uint m_totalCallNum;

	// Token: 0x040124A1 RID: 74913
	private RECORD_MODE m_Mode;

	// Token: 0x040124A2 RID: 74914
	private uint m_frameDataIndex;

	// Token: 0x040124A3 RID: 74915
	private string m_version = string.Empty;

	// Token: 0x040124A4 RID: 74916
	private int m_versionStrLen;

	// Token: 0x040124A5 RID: 74917
	private BattleType m_battleType;

	// Token: 0x040124A6 RID: 74918
	private eDungeonMode m_DungoneMode;

	// Token: 0x040124A7 RID: 74919
	private string m_sessionId = string.Empty;

	// Token: 0x040124A8 RID: 74920
	private FrameRandomImp m_frameRandom;

	// Token: 0x040124A9 RID: 74921
	private FrameSync m_Inst;
}
