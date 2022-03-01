using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001152 RID: 4434
	public class BeNPC : BeBaseFighter
	{
		// Token: 0x0600A936 RID: 43318 RVA: 0x0023B38A File Offset: 0x0023978A
		public BeNPC(BeNPCData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x0600A937 RID: 43319 RVA: 0x0023B394 File Offset: 0x00239794
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
					BeNPCData beNPCData = this._data as BeNPCData;
					NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(beNPCData.NpcID, string.Empty, string.Empty);
					this._geScene = geScene;
					string name = string.Empty;
					if (tableItem.Function == NpcTable.eFunction.Townstatue || tableItem.Function == NpcTable.eFunction.guildGuardStatue)
					{
						this._geActor = geScene.CreateActor(beNPCData.ResourceID, 0, tableItem.Height, false, false, true, false);
						if (!string.IsNullOrEmpty(beNPCData.StatueName))
						{
							name = beNPCData.StatueName;
						}
					}
					else
					{
						if (EngineConfig.useTMEngine)
						{
							this._geActor = geScene.CreateActorAsyncEx(beNPCData.ResourceID, 0, tableItem.Height, false, false, true, null);
						}
						else
						{
							this._geActor = geScene.CreateActorAsync(beNPCData.ResourceID, 0, tableItem.Height, false, false, true);
						}
						name = beNPCData.Name;
					}
					if (this._geActor != null)
					{
						base.ActorData.MoveData.TransformDirty = true;
						this.UpdateGeActor(0f);
						this._geActor.AddNpcInteraction(beNPCData.NpcID, beNPCData.GUID);
						float nameLocalPosY = 0f;
						if (tableItem.NameLocalPosY > 0)
						{
							nameLocalPosY = (float)tableItem.NameLocalPosY / 1000f;
						}
						this._geActor.AddNPCFunction(name, beNPCData.NameColor, 0, null, nameLocalPosY);
						if (tableItem != null)
						{
							if (beNPCData.avatorInfo != null)
							{
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, beNPCData.avatorInfo.equipItemIds, beNPCData.JobID, (int)beNPCData.avatorInfo.weaponStrengthen, this._geActor, false, 0, false);
							}
							this._geActor.SuitAvatar(true, false, 0);
							this._geActor.AddNpcVoiceComponent(beNPCData.NpcID);
							this._geActor.AddNpcArrowComponent();
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

		// Token: 0x0600A938 RID: 43320 RVA: 0x0023B5B8 File Offset: 0x002399B8
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
	}
}
