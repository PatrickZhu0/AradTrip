using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200161F RID: 5663
	public class GuildEmblemAttrShowItem : MonoBehaviour
	{
		// Token: 0x0600DE48 RID: 56904 RVA: 0x00387C5A File Offset: 0x0038605A
		private void Start()
		{
		}

		// Token: 0x0600DE49 RID: 56905 RVA: 0x00387C5C File Offset: 0x0038605C
		private void OnDestroy()
		{
		}

		// Token: 0x0600DE4A RID: 56906 RVA: 0x00387C5E File Offset: 0x0038605E
		private void Update()
		{
		}

		// Token: 0x0600DE4B RID: 56907 RVA: 0x00387C60 File Offset: 0x00386060
		public void SetUp(int iEmblemLv)
		{
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(iEmblemLv, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.name.SafeSetImage(tableItem.namePath, false);
			if (this.name != null)
			{
				this.name.SetNativeSize();
			}
			this.stageLv.SafeSetImage(GuildEmblemAttrItem.GetStageLvPath(iEmblemLv), false);
			if (this.stageLv != null)
			{
				this.stageLv.SetNativeSize();
			}
			this.UpdateAttrs(iEmblemLv);
			this.getNow.CustomActive(DataManager<GuildDataManager>.GetInstance().GetEmblemLv() == iEmblemLv);
			this.icon.SafeSetImage(DataManager<GuildDataManager>.GetInstance().GetEmblemIconPath(iEmblemLv), false);
		}

		// Token: 0x0600DE4C RID: 56908 RVA: 0x00387D1C File Offset: 0x0038611C
		private void UpdateAttrs(int iEmblemLv)
		{
			if (this.attrs == null)
			{
				return;
			}
			int emblemSkillID = DataManager<GuildDataManager>.GetInstance().GetEmblemSkillID();
			List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(emblemSkillID, (byte)iEmblemLv, FightTypeLabel.PVE);
			this.attrs.text = string.Empty;
			for (int i = 0; i < skillDesList.Count; i++)
			{
				string[] array = skillDesList[i].Split(new char[]
				{
					':'
				});
				if (array.Length >= 2)
				{
					string arg = array[0];
					string text = array[1];
					int num = 0;
					int.TryParse(text, out num);
					if (num != 0)
					{
						Text text2 = this.attrs;
						text2.text += string.Format("{0}+{1}", arg, text);
						Text text3 = this.attrs;
						text3.text += "  ";
					}
				}
			}
			this.attrs.color = Color.white;
			if (iEmblemLv == DataManager<GuildDataManager>.GetInstance().GetEmblemLv())
			{
				this.attrs.color = Color.green;
			}
		}

		// Token: 0x040083A7 RID: 33703
		[SerializeField]
		private Image name;

		// Token: 0x040083A8 RID: 33704
		[SerializeField]
		private Image stageLv;

		// Token: 0x040083A9 RID: 33705
		[SerializeField]
		private Text attrs;

		// Token: 0x040083AA RID: 33706
		[SerializeField]
		private Image getNext;

		// Token: 0x040083AB RID: 33707
		[SerializeField]
		private Image getNow;

		// Token: 0x040083AC RID: 33708
		[SerializeField]
		private Image icon;
	}
}
