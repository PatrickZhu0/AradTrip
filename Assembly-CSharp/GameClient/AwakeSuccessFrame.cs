using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A2 RID: 5282
	internal class AwakeSuccessFrame : ClientFrame
	{
		// Token: 0x0600CCCE RID: 52430 RVA: 0x00324BF5 File Offset: 0x00322FF5
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
		}

		// Token: 0x0600CCCF RID: 52431 RVA: 0x00324BFD File Offset: 0x00322FFD
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600CCD0 RID: 52432 RVA: 0x00324C05 File Offset: 0x00323005
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/AwakeSuccessFrame";
		}

		// Token: 0x0600CCD1 RID: 52433 RVA: 0x00324C0C File Offset: 0x0032300C
		private void ClearData()
		{
		}

		// Token: 0x0600CCD2 RID: 52434 RVA: 0x00324C0E File Offset: 0x0032300E
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<AwakeSuccessFrame>(this, false);
		}

		// Token: 0x0600CCD3 RID: 52435 RVA: 0x00324C20 File Offset: 0x00323020
		private void InitInterface()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.JobPortrayal != string.Empty && tableItem.JobPortrayal != "-")
			{
				ETCImageLoader.LoadSprite(ref this.jobicon, tableItem.JobPortrayal, true);
			}
			this.CreateActor();
		}

		// Token: 0x0600CCD4 RID: 52436 RVA: 0x00324C98 File Offset: 0x00323098
		private void CreateActor()
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
				{
					DataManager<PlayerBaseData>.GetInstance().JobTableID
				});
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
					{
						tableItem.Mode
					});
				}
				else
				{
					this.avatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
					this.avatarRenderer.ChangeAction("Anim_Idle01", 1f, true);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.avatarRenderer, null, false);
				}
			}
		}

		// Token: 0x0400773D RID: 30525
		[UIControl("actorpos", typeof(GeAvatarRendererEx), 0)]
		private GeAvatarRendererEx avatarRenderer;

		// Token: 0x0400773E RID: 30526
		[UIControl("jobicon", null, 0)]
		protected Image jobicon;

		// Token: 0x0400773F RID: 30527
		[UIControl("actorpos", null, 0)]
		protected RawImage actorpos;
	}
}
