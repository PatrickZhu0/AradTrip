using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001741 RID: 5953
	internal class LowArmyHintItem : CachedNormalObject<LowArmyHintItemData>
	{
		// Token: 0x0600E9DE RID: 59870 RVA: 0x003DEFD0 File Offset: 0x003DD3D0
		public override void Initialize()
		{
			this.title = Utility.FindComponent<Text>(this.goLocal, "Record/Title", true);
			this.goLParent = Utility.FindChild(this.goLocal, "Record/Attributes");
			this.goLPrefab = Utility.FindChild(this.goLocal, "Record/Attributes/Attribute");
			this.goLPrefab.CustomActive(false);
		}

		// Token: 0x0600E9DF RID: 59871 RVA: 0x003DF02C File Offset: 0x003DD42C
		public override void UnInitialize()
		{
			this.title = null;
			this.goLParent = null;
			this.goLPrefab = null;
		}

		// Token: 0x0600E9E0 RID: 59872 RVA: 0x003DF044 File Offset: 0x003DD444
		public override void OnUpdate()
		{
			if (base.Value != null && base.Value.itemData != null)
			{
				if (null != this.title)
				{
					string arg = string.Empty;
					ItemData.QualityInfo qualityInfo = base.Value.itemData.GetQualityInfo();
					if (qualityInfo != null)
					{
						if (base.Value.itemData.StrengthenLevel > 0)
						{
							arg = TR.Value("super_link_item_name", base.Value.itemData.StrengthenLevel, base.Value.itemData.Name);
						}
						else
						{
							arg = base.Value.itemData.Name;
						}
						this.title.text = string.Format("<color={0}>[{1}]</color>", qualityInfo.ColStr, arg);
					}
				}
				List<string> masterAttrDescs = base.Value.itemData.GetMasterAttrDescs(false);
				for (int i = 0; i < masterAttrDescs.Count; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.goLPrefab);
					Utility.AttachTo(gameObject, this.goLParent, false);
					gameObject.CustomActive(true);
					Text component = gameObject.GetComponent<Text>();
					if (null != component)
					{
						Match match = this.m_regex.Match(masterAttrDescs[i]);
						if (match.Success)
						{
							component.text = string.Format("{0}{1}{2}{3}", new object[]
							{
								masterAttrDescs[i].Substring(0, match.Index),
								"<color=#ff0000ff>",
								match.Groups[1].Value,
								"</color>"
							});
						}
						else
						{
							component.text = masterAttrDescs[i];
						}
					}
				}
			}
		}

		// Token: 0x04008DD3 RID: 36307
		private Text title;

		// Token: 0x04008DD4 RID: 36308
		private GameObject goLPrefab;

		// Token: 0x04008DD5 RID: 36309
		private GameObject goLParent;

		// Token: 0x04008DD6 RID: 36310
		private Regex m_regex = new Regex("([\\+\\-]*\\d+\\.*\\d*%*$)");
	}
}
