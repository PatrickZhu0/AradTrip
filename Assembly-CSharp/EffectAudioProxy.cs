using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class EffectAudioProxy : MonoBehaviour
{
	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000544 RID: 1348 RVA: 0x00023493 File Offset: 0x00021893
	// (set) Token: 0x06000545 RID: 1349 RVA: 0x0002349B File Offset: 0x0002189B
	public EffectAudioProxy.EffAudioDesc[] EffAudioDescList
	{
		get
		{
			return this.m_EffAudioDescList;
		}
		set
		{
			this.m_EffAudioDescList = value;
		}
	}

	// Token: 0x06000546 RID: 1350 RVA: 0x000234A4 File Offset: 0x000218A4
	private void Start()
	{
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x000234A6 File Offset: 0x000218A6
	private void OnEnable()
	{
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x000234A8 File Offset: 0x000218A8
	private void OnDisable()
	{
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x000234AC File Offset: 0x000218AC
	private void OnDestroy()
	{
		int i = 0;
		int count = this.m_AudioHandleList.Count;
		while (i < count)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.m_AudioHandleList[i]);
			i++;
		}
		this.m_AudioHandleList.Clear();
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x000234F8 File Offset: 0x000218F8
	public bool TriggerAudio(EffectAudioProxy.AudioTigger tiggerType, int trggierID = -1)
	{
		if (tiggerType == EffectAudioProxy.AudioTigger.OnCall)
		{
			if (EffectAudioProxy.INVALID_CALL_ID == trggierID)
			{
				return false;
			}
			this._CheckTrigger(EffectAudioProxy.AudioTigger.OnCall, trggierID);
		}
		else
		{
			this._CheckTrigger(tiggerType, -1);
		}
		return true;
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x00023524 File Offset: 0x00021924
	private void Update()
	{
		this.m_CurTimeMS += (int)(1000f * Time.deltaTime);
		int i = 0;
		int count = this.m_UIAudioTriggerList.Count;
		while (i < count)
		{
			EffectAudioProxy.EffAudioTrigger effAudioTrigger = this.m_UIAudioTriggerList[i];
			if (effAudioTrigger == null || effAudioTrigger.m_EffAudioDesc == null)
			{
				this.m_UIAudioTriggerList.RemoveAt(i);
				break;
			}
			if (this.m_CurTimeMS - effAudioTrigger.m_TimeStampMS > effAudioTrigger.m_EffAudioDesc.m_TimeDelayMS)
			{
				this.m_UIAudioTriggerList.RemoveAt(i);
				this.m_AudioHandleList.Add(MonoSingleton<AudioManager>.instance.PlaySound(effAudioTrigger.m_EffAudioDesc.m_AudioRes, effAudioTrigger.m_EffAudioDesc.m_AudioType, effAudioTrigger.m_EffAudioDesc.m_Volume, effAudioTrigger.m_EffAudioDesc.m_Loop, null, false, false, null, 1f));
				effAudioTrigger.m_TimeStampMS = 0;
				effAudioTrigger.m_EffAudioDesc = null;
				this.m_UIIdleTriggerList.Add(effAudioTrigger);
				break;
			}
			i++;
		}
	}

	// Token: 0x0600054C RID: 1356 RVA: 0x0002362C File Offset: 0x00021A2C
	private void _CheckTrigger(EffectAudioProxy.AudioTigger triggerType, int triggerID = -1)
	{
		int i = 0;
		int num = this.m_EffAudioDescList.Length;
		while (i < num)
		{
			EffectAudioProxy.EffAudioDesc effAudioDesc = this.m_EffAudioDescList[i];
			if (effAudioDesc != null)
			{
				if (effAudioDesc.m_Trigger == triggerType && effAudioDesc.m_CallID == triggerID)
				{
					if (effAudioDesc.m_TimeDelayMS == 0)
					{
						this.m_AudioHandleList.Add(MonoSingleton<AudioManager>.instance.PlaySound(effAudioDesc.m_AudioRes, effAudioDesc.m_AudioType, effAudioDesc.m_Volume, effAudioDesc.m_Loop, null, false, false, null, 1f));
					}
					else
					{
						EffectAudioProxy.EffAudioTrigger effAudioTrigger = this._AllocTrigger();
						effAudioTrigger.m_EffAudioDesc = effAudioDesc;
						effAudioTrigger.m_TimeStampMS = this.m_CurTimeMS;
						this.m_UIAudioTriggerList.Add(effAudioTrigger);
					}
				}
			}
			i++;
		}
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x000236EC File Offset: 0x00021AEC
	private EffectAudioProxy.EffAudioTrigger _AllocTrigger()
	{
		if (this.m_UIIdleTriggerList.Count > 0)
		{
			EffectAudioProxy.EffAudioTrigger result = this.m_UIIdleTriggerList[0];
			this.m_UIIdleTriggerList.RemoveAt(0);
			return result;
		}
		return new EffectAudioProxy.EffAudioTrigger();
	}

	// Token: 0x040004B1 RID: 1201
	protected static readonly int INVALID_CALL_ID = -1;

	// Token: 0x040004B2 RID: 1202
	protected static readonly string INVALID_TAG = string.Empty;

	// Token: 0x040004B3 RID: 1203
	[SerializeField]
	protected EffectAudioProxy.EffAudioDesc[] m_EffAudioDescList = new EffectAudioProxy.EffAudioDesc[0];

	// Token: 0x040004B4 RID: 1204
	private List<uint> m_AudioHandleList = new List<uint>();

	// Token: 0x040004B5 RID: 1205
	protected List<EffectAudioProxy.EffAudioTrigger> m_UIAudioTriggerList = new List<EffectAudioProxy.EffAudioTrigger>();

	// Token: 0x040004B6 RID: 1206
	protected List<EffectAudioProxy.EffAudioTrigger> m_UIIdleTriggerList = new List<EffectAudioProxy.EffAudioTrigger>();

	// Token: 0x040004B7 RID: 1207
	protected int m_CurTimeMS;

	// Token: 0x020000F9 RID: 249
	public enum AudioTigger
	{
		// Token: 0x040004B9 RID: 1209
		None,
		// Token: 0x040004BA RID: 1210
		OnCall,
		// Token: 0x040004BB RID: 1211
		OnPlay
	}

	// Token: 0x020000FA RID: 250
	[Serializable]
	public class EffAudioDesc
	{
		// Token: 0x040004BC RID: 1212
		public string m_AudioRes;

		// Token: 0x040004BD RID: 1213
		public string m_AudioTag = EffectAudioProxy.INVALID_TAG;

		// Token: 0x040004BE RID: 1214
		public AudioType m_AudioType;

		// Token: 0x040004BF RID: 1215
		public bool m_Loop;

		// Token: 0x040004C0 RID: 1216
		public EffectAudioProxy.AudioTigger m_Trigger;

		// Token: 0x040004C1 RID: 1217
		public int m_TimeDelayMS;

		// Token: 0x040004C2 RID: 1218
		public float m_Volume = 1f;

		// Token: 0x040004C3 RID: 1219
		public int m_CallID = EffectAudioProxy.INVALID_CALL_ID;
	}

	// Token: 0x020000FB RID: 251
	protected class EffAudioTrigger
	{
		// Token: 0x040004C4 RID: 1220
		public EffectAudioProxy.EffAudioDesc m_EffAudioDesc;

		// Token: 0x040004C5 RID: 1221
		public int m_TimeStampMS;
	}
}
