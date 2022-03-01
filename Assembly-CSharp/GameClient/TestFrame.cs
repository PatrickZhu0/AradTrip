using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CFA RID: 7418
	internal class TestFrame : ClientFrame
	{
		// Token: 0x060123B4 RID: 74676 RVA: 0x0054E997 File Offset: 0x0054CD97
		public void Create(GameObject frame)
		{
			this.itemRoot = Utility.FindChild(frame, "ItemParent");
			this.name = Utility.FindComponent<Text>(frame, "ItemParent/Prefabs/Name", true);
			this.btnFuck = Utility.FindComponent<Button>(frame, "ItemParent/Prefabs/Button", true);
		}

		// Token: 0x060123B5 RID: 74677 RVA: 0x0054E9CE File Offset: 0x0054CDCE
		public void Destroy()
		{
			this.itemRoot = null;
			this.name = null;
			this.btnFuck.onClick.RemoveAllListeners();
			this.btnFuck = null;
		}

		// Token: 0x060123B6 RID: 74678 RVA: 0x0054E9F5 File Offset: 0x0054CDF5
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/ActiveFrame/TestFrame";
		}

		// Token: 0x060123B7 RID: 74679 RVA: 0x0054E9FC File Offset: 0x0054CDFC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.Create(this.frame);
		}

		// Token: 0x060123B8 RID: 74680 RVA: 0x0054EA10 File Offset: 0x0054CE10
		protected override void _OnCloseFrame()
		{
			this.Destroy();
			base._OnCloseFrame();
		}

		// Token: 0x0400BDAB RID: 48555
		private GameObject itemRoot;

		// Token: 0x0400BDAC RID: 48556
		private Text name;

		// Token: 0x0400BDAD RID: 48557
		private Button btnFuck;

		// Token: 0x02001CFB RID: 7419
		protected class ItemParent
		{
			// Token: 0x060123BA RID: 74682 RVA: 0x0054EA3C File Offset: 0x0054CE3C
			public GameObject GetParent(GameObject frame)
			{
				return Utility.FindChild(frame, this.strParentPath);
			}

			// Token: 0x060123BB RID: 74683 RVA: 0x0054EA4A File Offset: 0x0054CE4A
			public GameObject GetPrefab(GameObject parent)
			{
				return Utility.FindChild(parent, this.strPrefabPath);
			}

			// Token: 0x060123BC RID: 74684 RVA: 0x0054EA58 File Offset: 0x0054CE58
			public void Create(GameObject goLocal)
			{
				if (goLocal == null)
				{
					return;
				}
				this.name = Utility.FindComponent<Text>(goLocal, "Name", true);
				this.btnClick = Utility.FindComponent<Button>(goLocal, "Button", true);
				this.btnText = Utility.FindComponent<Text>(goLocal, "Button/Text", true);
			}

			// Token: 0x060123BD RID: 74685 RVA: 0x0054EAA8 File Offset: 0x0054CEA8
			public void Destroy(GameObject goLocal)
			{
				if (goLocal == null)
				{
					return;
				}
				this.name = null;
				this.btnClick.onClick.RemoveAllListeners();
				this.btnClick = null;
				this.btnText = null;
				this.strParentPath = null;
				this.strPrefabPath = null;
			}

			// Token: 0x0400BDAE RID: 48558
			public Text name;

			// Token: 0x0400BDAF RID: 48559
			public Button btnClick;

			// Token: 0x0400BDB0 RID: 48560
			public Text btnText;

			// Token: 0x0400BDB1 RID: 48561
			private string strParentPath = "ItemParent";

			// Token: 0x0400BDB2 RID: 48562
			private string strPrefabPath = "Prefabs";
		}
	}
}
