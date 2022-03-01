using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BF9 RID: 7161
	public class TaskAward : ClientFrame
	{
		// Token: 0x060118CF RID: 71887 RVA: 0x0051BA34 File Offset: 0x00519E34
		private void _UpdateItemAwardObjects()
		{
			if (this.m_kData != null)
			{
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.m_kData.iID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.m_kTitle.text = tableItem.TaskName;
				}
				this.m_akAwardItemObjects.RecycleAllObject();
				for (int i = 0; i < this.m_kData.awards.Count; i++)
				{
					this.m_akAwardItemObjects.Create(new object[]
					{
						this.m_goParent,
						this.m_goPrefab,
						this.m_kData.awards[i],
						this
					});
				}
			}
		}

		// Token: 0x060118D0 RID: 71888 RVA: 0x0051BAEB File Offset: 0x00519EEB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mission/MissionComplete";
		}

		// Token: 0x060118D1 RID: 71889 RVA: 0x0051BAF4 File Offset: 0x00519EF4
		protected override void _OnOpenFrame()
		{
			this.m_kData = (this.userData as TaskAward.TaskAwardData);
			this.m_akAwardItemObjects.Clear();
			this.m_goParent = Utility.FindChild(this.frame, "Di/AwardArray");
			this.m_goPrefab = Utility.FindChild(this.frame, "Di/AwardArray/AwardItem");
			this.m_goPrefab.CustomActive(false);
			this._UpdateItemAwardObjects();
			MonoSingleton<AudioManager>.instance.PlaySound(10);
		}

		// Token: 0x060118D2 RID: 71890 RVA: 0x0051BB68 File Offset: 0x00519F68
		protected override void _OnCloseFrame()
		{
			this.m_akAwardItemObjects.Clear();
		}

		// Token: 0x060118D3 RID: 71891 RVA: 0x0051BB78 File Offset: 0x00519F78
		[UIEventHandle("BtnOK")]
		private void OnClickOk()
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.m_kData.iID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				base.Close(false);
				Logger.LogErrorFormat("can not find mission with id = {0} in missiontable !!", new object[]
				{
					this.m_kData.iID
				});
				return;
			}
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (!DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)this.m_kData.iID, out singleMissionInfo))
			{
				base.Close(false);
				return;
			}
			if (Utility.IsNormalMission((uint)this.m_kData.iID) && singleMissionInfo.status == 2)
			{
				DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.m_kData.iID, (TaskSubmitType)tableItem.FinishType, (uint)tableItem.MissionFinishNpc);
			}
			base.Close(false);
		}

		// Token: 0x0400B695 RID: 46741
		private TaskAward.TaskAwardData m_kData;

		// Token: 0x0400B696 RID: 46742
		[UIControl("Title", typeof(Text), 0)]
		private Text m_kTitle;

		// Token: 0x0400B697 RID: 46743
		private CachedObjectListManager<TaskAward.AwardItemObject> m_akAwardItemObjects = new CachedObjectListManager<TaskAward.AwardItemObject>();

		// Token: 0x0400B698 RID: 46744
		private GameObject m_goParent;

		// Token: 0x0400B699 RID: 46745
		private GameObject m_goPrefab;

		// Token: 0x02001BFA RID: 7162
		public class TaskAwardData
		{
			// Token: 0x0400B69A RID: 46746
			public int iID;

			// Token: 0x0400B69B RID: 46747
			public List<AwardItemData> awards;
		}

		// Token: 0x02001BFB RID: 7163
		private class AwardItemObject : CachedObject
		{
			// Token: 0x060118D6 RID: 71894 RVA: 0x0051BC58 File Offset: 0x0051A058
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.data = (AwardItemData)param[2];
				this.THIS = (param[3] as TaskAward);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.comItem = this.THIS.CreateComItem(Utility.FindChild(this.goLocal, "AwardIcon"));
					this.awardDesc = Utility.FindComponent<Text>(this.goLocal, "AwardDesc", true);
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x060118D7 RID: 71895 RVA: 0x0051BD15 File Offset: 0x0051A115
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x060118D8 RID: 71896 RVA: 0x0051BD1D File Offset: 0x0051A11D
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060118D9 RID: 71897 RVA: 0x0051BD3C File Offset: 0x0051A13C
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060118DA RID: 71898 RVA: 0x0051BD5B File Offset: 0x0051A15B
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060118DB RID: 71899 RVA: 0x0051BD64 File Offset: 0x0051A164
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060118DC RID: 71900 RVA: 0x0051BD6D File Offset: 0x0051A16D
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x060118DD RID: 71901 RVA: 0x0051BD70 File Offset: 0x0051A170
			private void _UpdateItem()
			{
				this.awardDesc.text = null;
				this.itemData = ItemDataManager.CreateItemDataFromTable(this.data.ID, 100, 0);
				if (this.itemData != null)
				{
					this.itemData.Count = this.data.Num;
					string text;
					if (this.itemData.Type == ItemTable.eType.INCOME)
					{
						text = string.Format("<color={0}>{1}{2}</color>", this.itemData.Quality.ToString().ToLower(), this.itemData.Count, this.itemData.Name);
					}
					else if (this.itemData.Count > 1)
					{
						text = string.Format("<color={0}>{1}X{2}</color>", this.itemData.Quality.ToString().ToLower(), this.itemData.Name, this.itemData.Count);
					}
					else
					{
						text = string.Format("<color={0}>{1}</color>", this.itemData.Quality.ToString().ToLower(), this.itemData.Name);
					}
					this.awardDesc.text = text;
				}
				this.itemData.Count = 1;
				this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this._OnItemClicked));
			}

			// Token: 0x060118DE RID: 71902 RVA: 0x0051BED9 File Offset: 0x0051A2D9
			private void _OnItemClicked(GameObject obj, ItemData item)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}

			// Token: 0x0400B69C RID: 46748
			protected GameObject goLocal;

			// Token: 0x0400B69D RID: 46749
			protected GameObject goParent;

			// Token: 0x0400B69E RID: 46750
			protected GameObject goPrefab;

			// Token: 0x0400B69F RID: 46751
			private ComItem comItem;

			// Token: 0x0400B6A0 RID: 46752
			private Text awardDesc;

			// Token: 0x0400B6A1 RID: 46753
			private AwardItemData data;

			// Token: 0x0400B6A2 RID: 46754
			private ItemData itemData;

			// Token: 0x0400B6A3 RID: 46755
			private TaskAward THIS;
		}
	}
}
