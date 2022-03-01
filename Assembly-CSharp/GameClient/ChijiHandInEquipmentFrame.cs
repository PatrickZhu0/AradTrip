using System;

namespace GameClient
{
	// Token: 0x02001109 RID: 4361
	public class ChijiHandInEquipmentFrame : ClientFrame
	{
		// Token: 0x0600A549 RID: 42313 RVA: 0x002219DD File Offset: 0x0021FDDD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiHandInEquipmentFrame";
		}

		// Token: 0x0600A54A RID: 42314 RVA: 0x002219E4 File Offset: 0x0021FDE4
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				ChijiNpcData chijiNpcData = this.userData as ChijiNpcData;
				if (chijiNpcData != null)
				{
					this.NpcData.guid = chijiNpcData.guid;
					this.NpcData.npcTableId = chijiNpcData.npcTableId;
				}
			}
			if (this.mChijiHandInEquipmentView != null)
			{
				this.mChijiHandInEquipmentView.InitView(this.NpcData);
			}
		}

		// Token: 0x0600A54B RID: 42315 RVA: 0x00221A52 File Offset: 0x0021FE52
		protected override void _OnCloseFrame()
		{
			if (this.NpcData != null)
			{
				this.NpcData.guid = 0UL;
				this.NpcData.npcTableId = 0;
			}
			base._OnCloseFrame();
		}

		// Token: 0x0600A54C RID: 42316 RVA: 0x00221A7E File Offset: 0x0021FE7E
		protected override void _bindExUI()
		{
			this.mChijiHandInEquipmentView = this.mBind.GetCom<ChijiHandInEquipmentView>("ChijiHandInEquipmentView");
		}

		// Token: 0x0600A54D RID: 42317 RVA: 0x00221A96 File Offset: 0x0021FE96
		protected override void _unbindExUI()
		{
			this.mChijiHandInEquipmentView = null;
		}

		// Token: 0x04005C3C RID: 23612
		private ChijiNpcData NpcData = new ChijiNpcData();

		// Token: 0x04005C3D RID: 23613
		private ChijiHandInEquipmentView mChijiHandInEquipmentView;
	}
}
