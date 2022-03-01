using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

// Token: 0x02000102 RID: 258
public class VoiceManager : Singleton<VoiceManager>
{
	// Token: 0x0600056C RID: 1388 RVA: 0x00023ED4 File Offset: 0x000222D4
	public override void Init()
	{
		Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<VoiceTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			VoiceTable voiceTable = keyValuePair.Value as VoiceTable;
			if (voiceTable != null)
			{
				List<VoiceTable> list = this._getVoiceListByType(voiceTable.VoiceType);
				if (list == null)
				{
					list = new List<VoiceTable>();
					this.mCacheVoices.Add(list);
				}
				if (list != null)
				{
					list.Add(voiceTable);
				}
			}
		}
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x00023F7C File Offset: 0x0002237C
	public override void UnInit()
	{
		this.mCacheVoices.Clear();
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x00023F8C File Offset: 0x0002238C
	private List<VoiceTable> _getVoiceListByType(VoiceTable.eVoiceType type)
	{
		for (int i = 0; i < this.mCacheVoices.Count; i++)
		{
			if (this.mCacheVoices[i] != null && this.mCacheVoices[i].Count > 0 && this.mCacheVoices[i][0].VoiceType == type)
			{
				return this.mCacheVoices[i];
			}
		}
		return null;
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x00024008 File Offset: 0x00022408
	private List<VoiceManager.VoiceNode> _getAllVoiceRes(VoiceTable.eVoiceType type, int id)
	{
		List<VoiceManager.VoiceNode> list = new List<VoiceManager.VoiceNode>();
		List<VoiceTable> list2 = this._getVoiceListByType(type);
		if (list2 != null)
		{
			for (int i = 0; i < list2.Count; i++)
			{
				for (int j = 0; j < list2[i].VoiceUnitID.Count; j++)
				{
					if (list2[i].VoiceUnitID[j] == id)
					{
						list.Add(new VoiceManager.VoiceNode
						{
							path = list2[i].VoicePath,
							rate = list2[i].VoiceRate,
							weight = list2[i].VoiceWeight
						});
						break;
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x000240C8 File Offset: 0x000224C8
	private List<VoiceManager.VoiceNode> _getAllVoiceRes(VoiceTable.eVoiceType type, string tag)
	{
		List<VoiceManager.VoiceNode> list = new List<VoiceManager.VoiceNode>();
		List<VoiceTable> list2 = this._getVoiceListByType(type);
		if (list2 != null)
		{
			for (int i = 0; i < list2.Count; i++)
			{
				if (list2[i].VoiceTag == tag)
				{
					list.Add(new VoiceManager.VoiceNode
					{
						path = list2[i].VoicePath,
						rate = list2[i].VoiceRate,
						weight = list2[i].VoiceWeight
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0002415C File Offset: 0x0002255C
	private bool _playSingleVoiceSound(VoiceManager.VoiceNode res)
	{
		this.StopAllVoice();
		if (res == null)
		{
			return false;
		}
		if (!string.IsNullOrEmpty(res.path))
		{
			int num = Random.Range(1, 1000);
			if (num <= res.rate)
			{
				uint item = MonoSingleton<AudioManager>.instance.PlaySound(res.path, AudioType.AudioVoice, 1f, false, null, false, false, null, 1f);
				this.mCachePlayMusic.Add(item);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x000241D0 File Offset: 0x000225D0
	private bool _playVoiceSound(List<VoiceManager.VoiceNode> list)
	{
		if (list != null)
		{
			List<int> list2 = new List<int>();
			list2.Add(0);
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				list2.Add(list2[i] + list[i].weight);
				num += list[i].weight;
			}
			int num2 = Random.Range(0, num);
			for (int j = 0; j < list.Count; j++)
			{
				if (num2 < list2[j + 1] && num2 >= list2[j])
				{
					return this._playSingleVoiceSound(list[j]);
				}
			}
		}
		return false;
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x00024283 File Offset: 0x00022683
	public void PlayVoice(VoiceTable.eVoiceType type, int id)
	{
		this._playVoiceSound(this._getAllVoiceRes(type, id));
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x00024294 File Offset: 0x00022694
	private int _getResIDByMonsterID(int id)
	{
		UnitTable tableItem = Singleton<TableManager>.instance.GetTableItem<UnitTable>(id, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Mode;
		}
		return -1;
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x000242C8 File Offset: 0x000226C8
	public void PlayVoiceByMonsterID(VoiceTable.eVoiceType type, int id)
	{
		int id2 = this._getResIDByMonsterID(id);
		this._playVoiceSound(this._getAllVoiceRes(type, id2));
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x000242EC File Offset: 0x000226EC
	public void PlayVoice(VoiceTable.eVoiceType type, string tag)
	{
		this._playVoiceSound(this._getAllVoiceRes(type, tag));
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x000242FD File Offset: 0x000226FD
	public void PlayVoiceByOccupation(VoiceTable.eVoiceType type, int occ)
	{
		this.PlayVoice(type, VoiceManager._getUnitResIDByOccupation(occ));
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0002430C File Offset: 0x0002270C
	public void StopAllVoice()
	{
		for (int i = 0; i < this.mCachePlayMusic.Count; i++)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.mCachePlayMusic[i]);
		}
		this.mCachePlayMusic.Clear();
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x00024358 File Offset: 0x00022758
	private static int _getUnitResIDByOccupation(int occupation)
	{
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(occupation, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Mode;
		}
		return -1;
	}

	// Token: 0x040004E8 RID: 1256
	private List<List<VoiceTable>> mCacheVoices = new List<List<VoiceTable>>();

	// Token: 0x040004E9 RID: 1257
	private List<uint> mCachePlayMusic = new List<uint>();

	// Token: 0x02000103 RID: 259
	private class VoiceNode
	{
		// Token: 0x040004EA RID: 1258
		public string path = string.Empty;

		// Token: 0x040004EB RID: 1259
		public int rate;

		// Token: 0x040004EC RID: 1260
		public int weight;
	}
}
