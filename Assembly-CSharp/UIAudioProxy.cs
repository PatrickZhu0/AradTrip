using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x020000FE RID: 254
public class UIAudioProxy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600055A RID: 1370 RVA: 0x000238E8 File Offset: 0x00021CE8
	// (set) Token: 0x0600055B RID: 1371 RVA: 0x000238F0 File Offset: 0x00021CF0
	public UIAudioProxy.UIAudioDesc[] UIAudioDescList
	{
		get
		{
			return this.m_UIAudioDescList;
		}
		set
		{
			this.m_UIAudioDescList = value;
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x000238F9 File Offset: 0x00021CF9
	private void Start()
	{
		this.m_Gray = base.gameObject.transform.GetComponent<UIGray>();
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x00023911 File Offset: 0x00021D11
	private void OnEnable()
	{
		this._CheckTrigger(UIAudioProxy.AudioTigger.OnOpen, -1);
		if (this.eventEnable != null)
		{
			this.eventEnable.Invoke();
		}
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x00023931 File Offset: 0x00021D31
	private void OnDisable()
	{
		this._CheckTrigger(UIAudioProxy.AudioTigger.OnClose, -1);
		if (this.eventDisable != null)
		{
			this.eventDisable.Invoke();
		}
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x00023954 File Offset: 0x00021D54
	public void StopAudio(UIAudioProxy.AudioTigger triggerType)
	{
		if (triggerType >= UIAudioProxy.AudioTigger.None && triggerType < (UIAudioProxy.AudioTigger)this.m_type2Handles.Length && this.m_type2Handles[(int)triggerType] != null)
		{
			for (int i = 0; i < this.m_type2Handles[(int)triggerType].Count; i++)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.m_type2Handles[(int)triggerType][i]);
			}
			this.m_type2Handles[(int)triggerType].Clear();
		}
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x000239C8 File Offset: 0x00021DC8
	private void OnDestroy()
	{
		int i = 0;
		int count = this.m_AudioHandleList.Count;
		while (i < count)
		{
			MonoSingleton<AudioManager>.instance.Stop(this.m_AudioHandleList[i]);
			i++;
		}
		for (int j = 0; j < this.m_type2Handles.Length; j++)
		{
			if (this.m_type2Handles[j] != null)
			{
				this.m_type2Handles[j].Clear();
				this.m_type2Handles[j] = null;
			}
		}
		this.m_AudioHandleList.Clear();
		if (this.mOnCallList != null)
		{
			this.mOnCallList.Clear();
		}
		this.eventEnable = null;
		this.eventDisable = null;
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00023A74 File Offset: 0x00021E74
	public void TriggerAudio(int trggierID)
	{
		if (UIAudioProxy.INVALID_CALL_ID == trggierID)
		{
			return;
		}
		this._CheckTrigger(UIAudioProxy.AudioTigger.OnCall, trggierID);
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x00023A8C File Offset: 0x00021E8C
	public void StopTriggerAudio(int trggierID)
	{
		int num = 1;
		if (this.mOnCallList != null && trggierID != -1 && this.mOnCallList.ContainsKey(trggierID))
		{
			uint num2 = this.mOnCallList[trggierID];
			MonoSingleton<AudioManager>.instance.Stop(num2);
			this.mOnCallList.Remove(trggierID);
			if (num >= 0 && num < this.m_type2Handles.Length && this.m_type2Handles[num] != null)
			{
				this.m_type2Handles[num].Remove(num2);
			}
		}
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x00023B14 File Offset: 0x00021F14
	private void Update()
	{
		this.m_CurTimeMS += (int)(1000f * Time.deltaTime);
		int i = 0;
		int count = this.m_UIAudioTriggerList.Count;
		while (i < count)
		{
			UIAudioProxy.UIAudioTrigger uiaudioTrigger = this.m_UIAudioTriggerList[i];
			if (uiaudioTrigger == null || uiaudioTrigger.m_UIAudioDesc == null)
			{
				this.m_UIAudioTriggerList.RemoveAt(i);
				break;
			}
			if (this.m_CurTimeMS - uiaudioTrigger.m_TimeStampMS > uiaudioTrigger.m_UIAudioDesc.m_TimeDelayMS)
			{
				this.m_UIAudioTriggerList.RemoveAt(i);
				List<uint> list = this.m_type2Handles[(int)uiaudioTrigger.m_UIAudioDesc.m_Trigger];
				if (list == null)
				{
					list = new List<uint>();
					this.m_type2Handles[(int)uiaudioTrigger.m_UIAudioDesc.m_Trigger] = list;
				}
				uint item = MonoSingleton<AudioManager>.instance.PlaySound(uiaudioTrigger.m_UIAudioDesc.m_AudioRes, uiaudioTrigger.m_UIAudioDesc.m_AudioType, uiaudioTrigger.m_UIAudioDesc.m_Volume, uiaudioTrigger.m_UIAudioDesc.m_Loop, null, false, false, null, 1f);
				list.Add(item);
				this.m_AudioHandleList.Add(item);
				uiaudioTrigger.m_TimeStampMS = 0;
				uiaudioTrigger.m_UIAudioDesc = null;
				this.m_UIIdleTriggerList.Add(uiaudioTrigger);
				break;
			}
			i++;
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x00023C57 File Offset: 0x00022057
	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		if (null == this.m_Gray || !this.m_Gray.isActiveAndEnabled)
		{
			this._CheckTrigger(UIAudioProxy.AudioTigger.OnPointerDown, -1);
		}
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x00023C82 File Offset: 0x00022082
	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		if (null == this.m_Gray || !this.m_Gray.isActiveAndEnabled)
		{
			this._CheckTrigger(UIAudioProxy.AudioTigger.OnPointerUp, -1);
		}
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x00023CB0 File Offset: 0x000220B0
	private void _CheckTrigger(UIAudioProxy.AudioTigger triggerType, int triggerID = -1)
	{
		if (triggerType <= UIAudioProxy.AudioTigger.None || triggerType >= UIAudioProxy.AudioTigger.Count)
		{
			return;
		}
		int i = 0;
		int num = this.m_UIAudioDescList.Length;
		while (i < num)
		{
			UIAudioProxy.UIAudioDesc uiaudioDesc = this.m_UIAudioDescList[i];
			if (uiaudioDesc != null)
			{
				if (uiaudioDesc.m_Trigger == triggerType && uiaudioDesc.m_CallID == triggerID)
				{
					List<uint> list = this.m_type2Handles[(int)triggerType];
					if (list == null)
					{
						list = new List<uint>();
						this.m_type2Handles[(int)triggerType] = list;
					}
					if (uiaudioDesc.m_TimeDelayMS == 0)
					{
						uint num2 = MonoSingleton<AudioManager>.instance.PlaySound(uiaudioDesc.m_AudioRes, uiaudioDesc.m_AudioType, uiaudioDesc.m_Volume, uiaudioDesc.m_Loop, null, false, false, null, 1f);
						list.Add(num2);
						this.m_AudioHandleList.Add(num2);
						if (triggerType == UIAudioProxy.AudioTigger.OnCall && triggerID != -1 && this.eventEnable != null && this.eventDisable != null)
						{
							if (this.mOnCallList == null)
							{
								this.mOnCallList = new Dictionary<int, uint>();
							}
							if (this.mOnCallList.ContainsKey(triggerID))
							{
								MonoSingleton<AudioManager>.instance.Stop(this.mOnCallList[triggerID]);
								this.mOnCallList[triggerID] = num2;
							}
							else
							{
								this.mOnCallList.Add(triggerID, num2);
							}
						}
					}
					else
					{
						UIAudioProxy.UIAudioTrigger uiaudioTrigger = this._AllocTrigger();
						uiaudioTrigger.m_UIAudioDesc = uiaudioDesc;
						uiaudioTrigger.m_TimeStampMS = this.m_CurTimeMS;
						this.m_UIAudioTriggerList.Add(uiaudioTrigger);
					}
				}
			}
			i++;
		}
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x00023E30 File Offset: 0x00022230
	private UIAudioProxy.UIAudioTrigger _AllocTrigger()
	{
		if (this.m_UIIdleTriggerList.Count > 0)
		{
			UIAudioProxy.UIAudioTrigger result = this.m_UIIdleTriggerList[0];
			this.m_UIIdleTriggerList.RemoveAt(0);
			return result;
		}
		return new UIAudioProxy.UIAudioTrigger();
	}

	// Token: 0x040004CA RID: 1226
	protected static readonly int INVALID_CALL_ID = -1;

	// Token: 0x040004CB RID: 1227
	protected static readonly string INVALID_TAG = string.Empty;

	// Token: 0x040004CC RID: 1228
	[SerializeField]
	[HideInInspector]
	protected UIAudioProxy.UIAudioDesc[] m_UIAudioDescList = new UIAudioProxy.UIAudioDesc[0];

	// Token: 0x040004CD RID: 1229
	private List<uint> m_AudioHandleList = new List<uint>();

	// Token: 0x040004CE RID: 1230
	protected List<UIAudioProxy.UIAudioTrigger> m_UIAudioTriggerList = new List<UIAudioProxy.UIAudioTrigger>();

	// Token: 0x040004CF RID: 1231
	protected List<UIAudioProxy.UIAudioTrigger> m_UIIdleTriggerList = new List<UIAudioProxy.UIAudioTrigger>();

	// Token: 0x040004D0 RID: 1232
	private List<uint>[] m_type2Handles = new List<uint>[6];

	// Token: 0x040004D1 RID: 1233
	public UnityEvent eventEnable;

	// Token: 0x040004D2 RID: 1234
	public UnityEvent eventDisable;

	// Token: 0x040004D3 RID: 1235
	private Dictionary<int, uint> mOnCallList;

	// Token: 0x040004D4 RID: 1236
	protected int m_CurTimeMS;

	// Token: 0x040004D5 RID: 1237
	protected UIGray m_Gray;

	// Token: 0x020000FF RID: 255
	public enum AudioTigger
	{
		// Token: 0x040004D7 RID: 1239
		None,
		// Token: 0x040004D8 RID: 1240
		OnCall,
		// Token: 0x040004D9 RID: 1241
		OnOpen,
		// Token: 0x040004DA RID: 1242
		OnPointerDown,
		// Token: 0x040004DB RID: 1243
		OnClose,
		// Token: 0x040004DC RID: 1244
		OnPointerUp,
		// Token: 0x040004DD RID: 1245
		Count
	}

	// Token: 0x02000100 RID: 256
	[Serializable]
	public class UIAudioDesc
	{
		// Token: 0x040004DE RID: 1246
		public string m_AudioRes;

		// Token: 0x040004DF RID: 1247
		public string m_AudioTag = UIAudioProxy.INVALID_TAG;

		// Token: 0x040004E0 RID: 1248
		public AudioType m_AudioType;

		// Token: 0x040004E1 RID: 1249
		public bool m_Loop;

		// Token: 0x040004E2 RID: 1250
		public UIAudioProxy.AudioTigger m_Trigger;

		// Token: 0x040004E3 RID: 1251
		public int m_TimeDelayMS;

		// Token: 0x040004E4 RID: 1252
		public float m_Volume = 1f;

		// Token: 0x040004E5 RID: 1253
		public int m_CallID = UIAudioProxy.INVALID_CALL_ID;
	}

	// Token: 0x02000101 RID: 257
	protected class UIAudioTrigger
	{
		// Token: 0x040004E6 RID: 1254
		public UIAudioProxy.UIAudioDesc m_UIAudioDesc;

		// Token: 0x040004E7 RID: 1255
		public int m_TimeStampMS;
	}
}
