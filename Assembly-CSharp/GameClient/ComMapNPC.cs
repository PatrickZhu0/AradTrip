using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F03 RID: 3843
	internal class ComMapNPC : MonoBehaviour
	{
		// Token: 0x1700190E RID: 6414
		// (get) Token: 0x0600962E RID: 38446 RVA: 0x001C6B52 File Offset: 0x001C4F52
		public bool IsValid
		{
			get
			{
				return this.m_npcTable != null;
			}
		}

		// Token: 0x1700190F RID: 6415
		// (get) Token: 0x0600962F RID: 38447 RVA: 0x001C6B60 File Offset: 0x001C4F60
		public string NpcName
		{
			get
			{
				return (!this.IsValid) ? string.Empty : this.m_npcTable.NpcName;
			}
		}

		// Token: 0x17001910 RID: 6416
		// (get) Token: 0x06009630 RID: 38448 RVA: 0x001C6B82 File Offset: 0x001C4F82
		public string NpcIcon
		{
			get
			{
				return (!this.IsValid) ? string.Empty : this.m_npcTable.NpcIcon;
			}
		}

		// Token: 0x17001911 RID: 6417
		// (get) Token: 0x06009631 RID: 38449 RVA: 0x001C6BA4 File Offset: 0x001C4FA4
		public bool IsNormalNpc
		{
			get
			{
				return this.IsValid && (this.m_npcTable.Function == NpcTable.eFunction.none || this.m_npcTable.Function == NpcTable.eFunction.clicknpc);
			}
		}

		// Token: 0x06009632 RID: 38450 RVA: 0x001C6BD5 File Offset: 0x001C4FD5
		private void OnStart()
		{
			this.Setup();
		}

		// Token: 0x06009633 RID: 38451 RVA: 0x001C6BDD File Offset: 0x001C4FDD
		private void OnValidate()
		{
			if (AssetLoader.IsAssetManagerReady())
			{
				this.Setup();
			}
		}

		// Token: 0x06009634 RID: 38452 RVA: 0x001C6BF0 File Offset: 0x001C4FF0
		public void Setup()
		{
			this.m_npcTable = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this.NpcID, string.Empty, string.Empty);
			if (this.m_npcTable == null)
			{
				return;
			}
			if (this.imgFace != null)
			{
				ETCImageLoader.LoadSprite(ref this.imgFace, this.m_npcTable.NpcIcon, true);
			}
		}

		// Token: 0x04004D11 RID: 19729
		public int NpcID;

		// Token: 0x04004D12 RID: 19730
		public Image imgFace;

		// Token: 0x04004D13 RID: 19731
		private NpcTable m_npcTable;
	}
}
