using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200161D RID: 5661
	public class GuildEmblemAttrItem : MonoBehaviour
	{
		// Token: 0x0600DE31 RID: 56881 RVA: 0x003875B2 File Offset: 0x003859B2
		private void Start()
		{
		}

		// Token: 0x0600DE32 RID: 56882 RVA: 0x003875B4 File Offset: 0x003859B4
		private void OnDestroy()
		{
		}

		// Token: 0x0600DE33 RID: 56883 RVA: 0x003875B6 File Offset: 0x003859B6
		private void Update()
		{
		}

		// Token: 0x0600DE34 RID: 56884 RVA: 0x003875B8 File Offset: 0x003859B8
		private string GetColorString(string text, string color)
		{
			return TR.Value("common_color_text", "#" + color, text);
		}

		// Token: 0x0600DE35 RID: 56885 RVA: 0x003875D0 File Offset: 0x003859D0
		public static string GetStageLvPath(int iEmblemLv)
		{
			if (GuildEmblemAttrItem.lvPath == null)
			{
				return string.Empty;
			}
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(iEmblemLv, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.stageLevel > GuildEmblemAttrItem.lvPath.Length || tableItem.stageLevel <= 0)
			{
				return string.Empty;
			}
			return GuildEmblemAttrItem.lvPath[tableItem.stageLevel - 1];
		}

		// Token: 0x0600DE36 RID: 56886 RVA: 0x00387644 File Offset: 0x00385A44
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
		}

		// Token: 0x0600DE37 RID: 56887 RVA: 0x003876D4 File Offset: 0x00385AD4
		private string GetAttrValueStr(List<string> skillDesList, string attrName)
		{
			if (skillDesList == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < skillDesList.Count; i++)
			{
				string[] array = skillDesList[i].Split(new char[]
				{
					':'
				});
				if (array.Length >= 2)
				{
					string b = array[0];
					string result = array[1];
					if (attrName == b)
					{
						return result;
					}
				}
			}
			return string.Empty;
		}

		// Token: 0x0600DE38 RID: 56888 RVA: 0x00387748 File Offset: 0x00385B48
		private void UpdateAttrs(int iEmblemLv)
		{
			if (this.attrParent == null)
			{
				return;
			}
			if (this.attrTemplate == null)
			{
				return;
			}
			for (int i = 0; i < this.attrParent.transform.childCount; i++)
			{
				GameObject gameObject = this.attrParent.transform.GetChild(i).gameObject;
				Object.Destroy(gameObject);
			}
			int emblemSkillID = DataManager<GuildDataManager>.GetInstance().GetEmblemSkillID();
			List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(emblemSkillID, (byte)iEmblemLv, FightTypeLabel.PVE);
			List<string> skillDesList2 = null;
			if (this.isLevelUp)
			{
				skillDesList2 = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(emblemSkillID, (byte)(iEmblemLv - 1), FightTypeLabel.PVE);
			}
			for (int j = 0; j < skillDesList.Count; j++)
			{
				string[] array = skillDesList[j].Split(new char[]
				{
					':'
				});
				if (array.Length >= 2)
				{
					string text = array[0];
					string text2 = array[1];
					int num = 0;
					int.TryParse(text2, out num);
					if (num != 0)
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(this.attrTemplate.gameObject);
						Utility.AttachTo(gameObject2, this.attrParent, false);
						gameObject2.CustomActive(true);
						ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
						if (component != null)
						{
							StaticUtility.SafeSetText(component, "attrName", text + ":");
							StaticUtility.SafeSetText(component, "attrValue", text2);
							StaticUtility.SafeSetVisible<Image>(component, "up", false);
							if (this.isLevelUp)
							{
								string attrValueStr = this.GetAttrValueStr(skillDesList2, text);
								int num2 = 0;
								int num3 = 0;
								int.TryParse(attrValueStr, out num2);
								int.TryParse(text2, out num3);
								StaticUtility.SafeSetVisible<Image>(component, "up", num3 > num2);
							}
						}
					}
				}
			}
			if (this.scrollRect != null)
			{
				this.scrollRect.verticalNormalizedPosition = 1f;
			}
		}

		// Token: 0x0400839C RID: 33692
		[SerializeField]
		private Image name;

		// Token: 0x0400839D RID: 33693
		[SerializeField]
		private Image stageLv;

		// Token: 0x0400839E RID: 33694
		[SerializeField]
		private GameObject attrTemplate;

		// Token: 0x0400839F RID: 33695
		[SerializeField]
		private GameObject attrParent;

		// Token: 0x040083A0 RID: 33696
		[SerializeField]
		private bool isLevelUp;

		// Token: 0x040083A1 RID: 33697
		[SerializeField]
		private ScrollRect scrollRect;

		// Token: 0x040083A2 RID: 33698
		private static string[] lvPath = new string[]
		{
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_yi",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_er",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_san",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_si",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_wu",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_liu",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_qi",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_ba",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_jiu",
			"UI/Image/Packed/p_UI_Badge.png:UI_Badge_shi"
		};
	}
}
