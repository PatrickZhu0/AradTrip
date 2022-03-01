using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200118E RID: 4494
	internal class BeTownNPC : BeBaseActor
	{
		// Token: 0x0600ABF9 RID: 44025 RVA: 0x0024E0C4 File Offset: 0x0024C4C4
		public BeTownNPC(BeTownNPCData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x0600ABFA RID: 44026 RVA: 0x0024E0F1 File Offset: 0x0024C4F1
		public void AddActorPostLoadCommand(PostLoadCommand async)
		{
			if (this._geActor != null)
			{
				this._geActor.PushPostLoadCommand(async);
			}
		}

		// Token: 0x0600ABFB RID: 44027 RVA: 0x0024E10C File Offset: 0x0024C50C
		public override void InitGeActor(GeSceneEx geScene)
		{
			if (geScene == null)
			{
				return;
			}
			try
			{
				if (this._geActor == null)
				{
					BeTownNPCData beTownNPCData = this._data as BeTownNPCData;
					NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(beTownNPCData.NpcID, string.Empty, string.Empty);
					this._geScene = geScene;
					string name = string.Empty;
					if (tableItem.Function == NpcTable.eFunction.Townstatue || tableItem.Function == NpcTable.eFunction.guildGuardStatue)
					{
						this._geActor = geScene.CreateActor(beTownNPCData.ResourceID, 0, tableItem.Height, false, false, true, false);
						if (!string.IsNullOrEmpty(beTownNPCData.StatueName))
						{
							name = beTownNPCData.StatueName;
						}
					}
					else
					{
						if (EngineConfig.useTMEngine)
						{
							this._geActor = geScene.CreateActorAsyncEx(beTownNPCData.ResourceID, 0, tableItem.Height, false, false, true, null);
						}
						else
						{
							this._geActor = geScene.CreateActorAsync(beTownNPCData.ResourceID, 0, tableItem.Height, false, false, true);
						}
						name = beTownNPCData.Name;
					}
					if (this._geActor != null)
					{
						base.ActorData.MoveData.TransformDirty = true;
						this.UpdateGeActor(0f);
						this._geActor.AddNpcInteraction(beTownNPCData.NpcID, beTownNPCData.GUID);
						float nameLocalPosY = 0f;
						if (tableItem.NameLocalPosY > 0)
						{
							nameLocalPosY = (float)tableItem.NameLocalPosY / 1000f;
						}
						this._geActor.AddNPCFunction(name, beTownNPCData.NameColor, 0, null, nameLocalPosY);
						if (tableItem != null)
						{
							if (beTownNPCData.avatorInfo != null)
							{
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, beTownNPCData.avatorInfo.equipItemIds, beTownNPCData.JobID, (int)beTownNPCData.avatorInfo.weaponStrengthen, this._geActor, false, 0, false);
							}
							this._geActor.SuitAvatar(true, false, 0);
							this._geActor.AddNpcVoiceComponent(beTownNPCData.NpcID);
							this._geActor.AddNpcArrowComponent();
							this.AddComponentDialog(beTownNPCData);
						}
						else
						{
							Logger.LogError("[BeTownNPC] npcItem is null");
						}
					}
				}
			}
			catch (Exception ex)
			{
				this._geActor = null;
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600ABFC RID: 44028 RVA: 0x0024E338 File Offset: 0x0024C738
		protected virtual void AddComponentDialog(BeTownNPCData townData)
		{
			if (townData != null && this.mNeedShowDialogNPCIdList.Contains(townData.NpcID))
			{
				this._geActor.PushPostLoadCommand(delegate
				{
					this._geActor.AddComponentDialog(townData.NpcID, NpcDialogComponent.IdBelong2.IdBelong2_NpcTable);
				});
			}
		}

		// Token: 0x0600ABFD RID: 44029 RVA: 0x0024E398 File Offset: 0x0024C798
		public override void Update(float deltaTime)
		{
			if (this._geActor != null)
			{
				this._geActor.Update(0, 0, 0f, 0);
				this._geActor.UpdateNpcInteraction(deltaTime);
				this._geActor.UpdateDialogComponet(deltaTime);
				this._geActor.UpdateVoiceComponent(deltaTime);
			}
			base.Update(deltaTime);
		}

		// Token: 0x04006075 RID: 24693
		private List<int> mNeedShowDialogNPCIdList = new List<int>
		{
			2095
		};
	}
}
