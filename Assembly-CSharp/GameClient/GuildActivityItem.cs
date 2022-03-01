using System;
using System.Reflection;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015EB RID: 5611
	public class GuildActivityItem : MonoBehaviour
	{
		// Token: 0x0600DB9E RID: 56222 RVA: 0x0037561C File Offset: 0x00373A1C
		private void Start()
		{
		}

		// Token: 0x0600DB9F RID: 56223 RVA: 0x0037561E File Offset: 0x00373A1E
		private void OnDestroy()
		{
			this.id = 0;
		}

		// Token: 0x0600DBA0 RID: 56224 RVA: 0x00375627 File Offset: 0x00373A27
		private void OnDisable()
		{
			this.id = 0;
		}

		// Token: 0x0600DBA1 RID: 56225 RVA: 0x00375630 File Offset: 0x00373A30
		private void Update()
		{
			GuildActivityTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildActivityTable>(this.id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				MethodInfo methodInfoFromString = GuildActivityItem.GetMethodInfoFromString(tableItem.activityUnLockCallBack);
				if (methodInfoFromString != null && methodInfoFromString.ReturnType == typeof(bool))
				{
					bool flag = (bool)methodInfoFromString.Invoke(null, null);
					this.limit.CustomActive(!flag);
					this.btnGo.SafeSetGray(!flag, true);
					if (flag)
					{
						this.btnGoText.SafeSetText(tableItem.btnDefaultText);
					}
					else
					{
						this.btnGoText.SafeSetText(TR.Value("guild_activity_unlock"));
					}
				}
				MethodInfo methodInfoFromString2 = GuildActivityItem.GetMethodInfoFromString(tableItem.stateUpdateCallBack);
				if (methodInfoFromString2 != null && methodInfoFromString2.ReturnType == typeof(string))
				{
					string str = (string)methodInfoFromString2.Invoke(null, null);
					this.state.SafeSetText(str);
				}
				MethodInfo methodInfoFromString3 = GuildActivityItem.GetMethodInfoFromString(tableItem.redPointUpdateCallBack);
				if (methodInfoFromString3 != null && methodInfoFromString3.ReturnType == typeof(bool))
				{
					this.redPoint.CustomActive((bool)methodInfoFromString3.Invoke(null, null));
				}
			}
		}

		// Token: 0x0600DBA2 RID: 56226 RVA: 0x0037576C File Offset: 0x00373B6C
		private static MethodInfo GetMethodInfoFromString(string methodStr)
		{
			string[] array = methodStr.Split(new char[]
			{
				'.'
			});
			if (array != null && array.Length >= 2)
			{
				string text = array[array.Length - 1];
				string str = string.Empty;
				for (int i = 0; i < array.Length - 1; i++)
				{
					if (i != 0)
					{
						str += ".";
					}
					str += array[i];
				}
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Type type = executingAssembly.GetType(str);
				return type.GetMethod(text);
			}
			return null;
		}

		// Token: 0x0600DBA3 RID: 56227 RVA: 0x003757FC File Offset: 0x00373BFC
		public void SetUp(object data)
		{
			GuildActivityFrame.GuildActivityData guildActivityData = data as GuildActivityFrame.GuildActivityData;
			if (guildActivityData == null)
			{
				return;
			}
			this.id = guildActivityData.guildActivityTableID;
			GuildActivityTable guildActivityTable = Singleton<TableManager>.GetInstance().GetTableItem<GuildActivityTable>(guildActivityData.guildActivityTableID, string.Empty, string.Empty);
			if (guildActivityTable == null)
			{
				return;
			}
			this.icon.SafeSetImage(guildActivityTable.iconPath, false);
			this.name.SafeSetText(guildActivityTable.activityName);
			this.desc.SafeSetText(guildActivityTable.activityDesc);
			this.openTime.SafeSetText(guildActivityTable.openTime);
			this.limit.SafeSetText(guildActivityTable.activityUnLockConditon);
			this.btnGoText.SafeSetText(guildActivityTable.btnDefaultText);
			this.state.SafeSetText(string.Empty);
			this.limit.CustomActive(false);
			this.btnGo.SafeSetOnClickListener(delegate
			{
				MethodInfo methodInfoFromString = GuildActivityItem.GetMethodInfoFromString(guildActivityTable.btnCallBack);
				if (methodInfoFromString != null)
				{
					methodInfoFromString.Invoke(null, null);
				}
			});
		}

		// Token: 0x04008160 RID: 33120
		[SerializeField]
		private Image icon;

		// Token: 0x04008161 RID: 33121
		[SerializeField]
		private Text name;

		// Token: 0x04008162 RID: 33122
		[SerializeField]
		private Text desc;

		// Token: 0x04008163 RID: 33123
		[SerializeField]
		private Text openTime;

		// Token: 0x04008164 RID: 33124
		[SerializeField]
		private Text limit;

		// Token: 0x04008165 RID: 33125
		[SerializeField]
		private Text state;

		// Token: 0x04008166 RID: 33126
		[SerializeField]
		private Button btnGo;

		// Token: 0x04008167 RID: 33127
		[SerializeField]
		private Text btnGoText;

		// Token: 0x04008168 RID: 33128
		[SerializeField]
		private GameObject redPoint;

		// Token: 0x04008169 RID: 33129
		private int id;
	}
}
