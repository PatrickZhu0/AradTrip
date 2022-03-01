using System;
using System.Text;
using System.Text.RegularExpressions;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000011 RID: 17
	public class ActiveVarReplace : MonoBehaviour
	{
		// Token: 0x06000057 RID: 87 RVA: 0x0000672C File Offset: 0x00004B2C
		private void Start()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			this._UpdateValue();
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000067D8 File Offset: 0x00004BD8
		private int _GetActiveKeyValue(string key, int iDef = 0)
		{
			int result = iDef;
			ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(this.iActiveID);
			if (childActiveData != null)
			{
				TaskPair taskPair = childActiveData.akActivityValues.Find((TaskPair x) => x.key == key);
				if (taskPair == null || int.TryParse(taskPair.value, out result))
				{
				}
			}
			return result;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000683C File Offset: 0x00004C3C
		private void _UpdateValue()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			for (int i = 0; i < this.keyValues.Length; i++)
			{
				KeyValueInfo keyValueInfo = this.keyValues[i];
				if (keyValueInfo != null)
				{
					MyExtensionMethods.Clear(stringBuilder);
					MatchCollection matchCollection = ActiveVarReplace.ms_regex_key_replace.Matches(keyValueInfo.Content);
					int num = 0;
					for (int j = 0; j < matchCollection.Count; j++)
					{
						if (matchCollection[j].Success)
						{
							stringBuilder.Append(keyValueInfo.Content.Substring(num, matchCollection[j].Index - num));
							ActiveVarRelpaceType eActiveVarRelpaceType = (ActiveVarRelpaceType)int.Parse(matchCollection[j].Groups[2].Value);
							ActiveVarRelpaceType activeVarRelpaceType = (ActiveVarRelpaceType)int.Parse(matchCollection[j].Groups[3].Value);
							int num2 = int.Parse(matchCollection[j].Groups[3].Value);
							bool flag = (num2 & int.MinValue) != 0;
							int b = 0;
							int b2 = 0;
							if (flag)
							{
								b = this._QueryValueByMask(matchCollection[j].Groups[4].Value, num2 & 255, 0);
								b2 = this._QueryValueByMask(matchCollection[j].Groups[5].Value, num2 >> 8 & 255, 0);
							}
							int num3 = this._QueryValue(matchCollection[j].Groups[1].Value, keyValueInfo.bFromCount, eActiveVarRelpaceType);
							if (flag)
							{
								num3 = IntMath.Max(num3, b);
								num3 = IntMath.Min(num3, b2);
							}
							switch (eActiveVarRelpaceType)
							{
							case ActiveVarRelpaceType.AVRT_NORMAL:
								stringBuilder.Append(num3.ToString());
								break;
							case ActiveVarRelpaceType.AVRT_ITEM_NAME:
							{
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty);
								if (tableItem != null)
								{
									stringBuilder.Append(tableItem.Name);
								}
								break;
							}
							case ActiveVarRelpaceType.AVRT_ITEM_ICON:
							{
								ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num3, string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									stringBuilder.Append(tableItem2.Icon);
								}
								break;
							}
							case ActiveVarRelpaceType.AVRT_SYSTEM_VALUE_ID:
							{
								SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num3, string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									stringBuilder.Append(tableItem3.Value);
								}
								else
								{
									stringBuilder.Append(0);
								}
								break;
							}
							case ActiveVarRelpaceType.AVRT_SYSTEM_VALUE_ITEM_NAME:
							{
								SystemValueTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(num3, string.Empty, string.Empty);
								if (tableItem4 != null)
								{
									ItemTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem4.Value, string.Empty, string.Empty);
									if (tableItem5 != null)
									{
										stringBuilder.Append(tableItem5.Name);
									}
								}
								break;
							}
							}
							num = matchCollection[j].Index + matchCollection[j].Length;
						}
					}
					stringBuilder.Append(keyValueInfo.Content.Substring(num, keyValueInfo.Content.Length - num));
					if (keyValueInfo.text != null)
					{
						keyValueInfo.text.text = stringBuilder.ToString();
					}
					if (keyValueInfo.img != null)
					{
						ETCImageLoader.LoadSprite(ref keyValueInfo.img, stringBuilder.ToString(), true);
					}
				}
			}
			StringBuilderCache.Release(stringBuilder);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00006BBC File Offset: 0x00004FBC
		private int _QueryValueByMask(string key, int zone, int iDef)
		{
			int num = iDef;
			if ((zone & 1) != 0)
			{
				int.TryParse(key, out num);
			}
			else if ((zone & 2) != 0)
			{
				num = this._GetActiveKeyValue(key, num);
			}
			else if ((zone & 4) != 0)
			{
				CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(key);
				if (countInfo != null)
				{
					num = (int)countInfo.value;
				}
			}
			else if ((zone & 8) != 0)
			{
				int id = 0;
				if (int.TryParse(key, out id))
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(id, string.Empty, string.Empty);
					if (tableItem != null)
					{
						num = tableItem.Value;
					}
				}
			}
			return num;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00006C58 File Offset: 0x00005058
		private int _QueryValue(string key, bool bFromCount, ActiveVarRelpaceType eActiveVarRelpaceType)
		{
			int num = 0;
			switch (eActiveVarRelpaceType)
			{
			case ActiveVarRelpaceType.AVRT_NORMAL:
			case ActiveVarRelpaceType.AVRT_ITEM_NAME:
			case ActiveVarRelpaceType.AVRT_ITEM_ICON:
				if (bFromCount)
				{
					CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(key);
					if (countInfo != null)
					{
						num = (int)countInfo.value;
					}
				}
				else
				{
					num = this._GetActiveKeyValue(key, num);
				}
				break;
			case ActiveVarRelpaceType.AVRT_SYSTEM_VALUE_ID:
				int.TryParse(key, out num);
				break;
			case ActiveVarRelpaceType.AVRT_SYSTEM_VALUE_ITEM_NAME:
				int.TryParse(key, out num);
				break;
			}
			return num;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00006CD5 File Offset: 0x000050D5
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			this._UpdateValue();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00006CDD File Offset: 0x000050DD
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			this._UpdateValue();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00006CE5 File Offset: 0x000050E5
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			if (data.activeItem.ID == this.iActiveID)
			{
				this._UpdateValue();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00006D03 File Offset: 0x00005103
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			this._UpdateValue();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006D0C File Offset: 0x0000510C
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance2.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance3.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x04000041 RID: 65
		public KeyValueInfo[] keyValues = new KeyValueInfo[0];

		// Token: 0x04000042 RID: 66
		public int iActiveID;

		// Token: 0x04000043 RID: 67
		private static Regex ms_regex_key_replace = new Regex("{key=([a-zA-Z0-9]+) type=([0-9]+) z=([0-9-]+) l=([a-zA-Z0-9]+) h=([a-zA-Z0-9]+)}", RegexOptions.Singleline);
	}
}
