using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020001F4 RID: 500
	public class ComScriptBinder : MonoBehaviour
	{
		// Token: 0x06001001 RID: 4097 RVA: 0x00053FC9 File Offset: 0x000523C9
		private void Awake()
		{
			if (this.useBinarySearch)
			{
				if (this.scriptItems.Length > 0)
				{
					Array.Sort<ScriptBinderItem>(this.scriptItems);
				}
				if (this.scriptStatus.Length > 0)
				{
					Array.Sort<ScriptStateItem>(this.scriptStatus);
				}
			}
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00054008 File Offset: 0x00052408
		protected int findItemLabel(int label)
		{
			if (this.useBinarySearch)
			{
				return Array.BinarySearch(this.scriptItems, label);
			}
			return label;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00054028 File Offset: 0x00052428
		protected int findStatusLabel(int label)
		{
			if (this.useBinarySearch)
			{
				return Array.BinarySearch(this.scriptStatus, label);
			}
			return label;
		}

		// Token: 0x06001004 RID: 4100 RVA: 0x00054048 File Offset: 0x00052448
		public void SetText(int label, string value)
		{
			int num = this.findItemLabel(label);
			if (num >= 0 && num < this.scriptItems.Length)
			{
				Text text = this.scriptItems[num].component as Text;
				if (null != text)
				{
					text.text = value;
					return;
				}
			}
			Logger.LogErrorFormat("ComScriptBinder SetText label = {0} error !!!", new object[]
			{
				label
			});
		}

		// Token: 0x06001005 RID: 4101 RVA: 0x000540B4 File Offset: 0x000524B4
		public void SetAction(int label)
		{
			int num = this.findStatusLabel(label);
			if (num >= 0 && num < this.scriptStatus.Length && this.scriptStatus[num].action != null)
			{
				this.scriptStatus[num].action.Invoke();
				return;
			}
			Logger.LogErrorFormat("ComScriptBinder SetAction label = {0} is failed!!!", new object[]
			{
				label
			});
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x0005411C File Offset: 0x0005251C
		public void SetText(int label, int argumentsIndex)
		{
			if (argumentsIndex >= 0 && argumentsIndex < this.argumentsString.Length)
			{
				this.SetText(label, this.argumentsString[argumentsIndex]);
				return;
			}
			Logger.LogErrorFormat("ComScriptBinder SetText argumentsIndex = {0} is out of range !!!", new object[]
			{
				argumentsIndex
			});
		}

		// Token: 0x06001007 RID: 4103 RVA: 0x0005415C File Offset: 0x0005255C
		public void SetImage(int label, string value)
		{
			int num = this.findItemLabel(label);
			if (num >= 0 && num < this.scriptItems.Length)
			{
				Image image = this.scriptItems[num].component as Image;
				if (null != image)
				{
					image.sprite = (Singleton<AssetLoader>.instance.LoadRes(value, typeof(Sprite), true, 0U).obj as Sprite);
					return;
				}
			}
			Logger.LogErrorFormat("ComScriptBinder SetImage label = {0} error !!!", new object[]
			{
				label
			});
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x000541E6 File Offset: 0x000525E6
		public void SetImage(int label, int argumentsIndex)
		{
			if (argumentsIndex >= 0 && argumentsIndex < this.argumentsString.Length)
			{
				this.SetImage(label, this.argumentsString[argumentsIndex]);
				return;
			}
			Logger.LogErrorFormat("ComScriptBinder SetText argumentsIndex = {0} is out of range !!!", new object[]
			{
				argumentsIndex
			});
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x00054228 File Offset: 0x00052628
		public T GetScript<T>(int label) where T : Component
		{
			int num = this.findItemLabel(label);
			if (num >= 0 && num < this.scriptItems.Length)
			{
				return this.scriptItems[num].component as T;
			}
			Logger.LogErrorFormat("ComScriptBinder GetScript label = {0} error !!!", new object[]
			{
				label
			});
			return (T)((object)null);
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0005428C File Offset: 0x0005268C
		public Object GetObject(int label)
		{
			int num = this.findItemLabel(label);
			if (num >= 0 && num < this.scriptItems.Length)
			{
				return this.scriptItems[num].component;
			}
			return null;
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x000542C8 File Offset: 0x000526C8
		public int GetIntArgv(int index)
		{
			if (index >= 0 && index < this.argumentsInt.Length)
			{
				return this.argumentsInt[index];
			}
			Logger.LogErrorFormat("GetIntArgv index ={0} is out of range len = {1}!", new object[]
			{
				index,
				this.argumentsInt.Length
			});
			return 0;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x00054320 File Offset: 0x00052720
		public string GetStringArgv(int index)
		{
			if (index >= 0 && index < this.argumentsString.Length)
			{
				return this.argumentsString[index];
			}
			Logger.LogErrorFormat("GetStringArgv index = {0} is out of range len = {1}!", new object[]
			{
				index,
				this.argumentsString.Length
			});
			return string.Empty;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0005437C File Offset: 0x0005277C
		public float GetFloatArgv(int index)
		{
			if (index >= 0 && index < this.argumentsFloat.Length)
			{
				return this.argumentsFloat[index];
			}
			Logger.LogErrorFormat("GetFloatArgv index = {0} is out of range len = {1}!", new object[]
			{
				index,
				this.argumentsFloat.Length
			});
			return 0f;
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x000543D5 File Offset: 0x000527D5
		public void RegisterEvent(EUIEventID id, ClientEventSystem.UIEventHandler handle)
		{
			if (this.mRegistertedEvents == null)
			{
				this.mRegistertedEvents = new List<KeyValuePair<EUIEventID, ClientEventSystem.UIEventHandler>>(16);
			}
			UIEventSystem.GetInstance().RegisterEventHandler(id, handle);
			this.mRegistertedEvents.Add(new KeyValuePair<EUIEventID, ClientEventSystem.UIEventHandler>(id, handle));
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00054410 File Offset: 0x00052810
		public void UnRegisterEvent(EUIEventID id, ClientEventSystem.UIEventHandler handle)
		{
			if (this.mRegistertedEvents != null)
			{
				for (int i = 0; i < this.mRegistertedEvents.Count; i++)
				{
					if (id == this.mRegistertedEvents[i].Key && handle == this.mRegistertedEvents[i].Value)
					{
						UIEventSystem.GetInstance().UnRegisterEventHandler(id, handle);
						this.mRegistertedEvents.RemoveAt(i--);
						break;
					}
				}
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x000544A0 File Offset: 0x000528A0
		public void RegisterButtonEvent(int label, UnityAction callback)
		{
			Button button = this.GetObject(label) as Button;
			if (null != button && callback != null)
			{
				button.onClick.AddListener(callback);
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x000544D8 File Offset: 0x000528D8
		public void UnRegisterButtonEvent(int label, UnityAction callback)
		{
			Button button = this.GetObject(label) as Button;
			if (null != button && callback != null)
			{
				button.onClick.RemoveListener(callback);
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00054510 File Offset: 0x00052910
		public void RegisterToggleEvent(int label, UnityAction<bool> callback)
		{
			Toggle toggle = this.GetObject(label) as Toggle;
			if (null != toggle)
			{
				toggle.onValueChanged.AddListener(callback);
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00054544 File Offset: 0x00052944
		public void UnRegisterToggleEvent(int label, UnityAction<bool> callback)
		{
			Toggle toggle = this.GetObject(label) as Toggle;
			if (null != toggle)
			{
				toggle.onValueChanged.RemoveListener(callback);
			}
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x00054576 File Offset: 0x00052976
		public void OnClickLinkInfo(string argv)
		{
			if (!string.IsNullOrEmpty(argv))
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(argv, null, false);
			}
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00054590 File Offset: 0x00052990
		private void OnDestroy()
		{
			if (this.mRegistertedEvents != null)
			{
				for (int i = 0; i < this.mRegistertedEvents.Count; i++)
				{
					UIEventSystem.GetInstance().UnRegisterEventHandler(this.mRegistertedEvents[i].Key, this.mRegistertedEvents[i].Value);
				}
				this.mRegistertedEvents.Clear();
			}
			for (int j = 0; j < this.scriptItems.Length; j++)
			{
				ScriptBinderItem scriptBinderItem = this.scriptItems[j];
				if (scriptBinderItem != null)
				{
					if (scriptBinderItem.component is Button)
					{
						(scriptBinderItem.component as Button).onClick.RemoveAllListeners();
					}
					else if (scriptBinderItem.component is Toggle)
					{
						(scriptBinderItem.component as Toggle).onValueChanged.RemoveAllListeners();
					}
				}
				this.scriptItems[j] = null;
			}
		}

		// Token: 0x04000AF8 RID: 2808
		protected bool useBinarySearch = true;

		// Token: 0x04000AF9 RID: 2809
		[HideInInspector]
		public string labelSpace = string.Empty;

		// Token: 0x04000AFA RID: 2810
		public string[] argumentsString = new string[0];

		// Token: 0x04000AFB RID: 2811
		public int[] argumentsInt = new int[0];

		// Token: 0x04000AFC RID: 2812
		public float[] argumentsFloat = new float[0];

		// Token: 0x04000AFD RID: 2813
		[HideInInspector]
		public ScriptBinderItem[] scriptItems = new ScriptBinderItem[0];

		// Token: 0x04000AFE RID: 2814
		[HideInInspector]
		public ScriptStateItem[] scriptStatus = new ScriptStateItem[0];

		// Token: 0x04000AFF RID: 2815
		private List<KeyValuePair<EUIEventID, ClientEventSystem.UIEventHandler>> mRegistertedEvents;
	}
}
