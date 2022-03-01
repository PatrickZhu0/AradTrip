using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200161E RID: 5662
	public class GuildEmblemAttrShowFrame : ClientFrame
	{
		// Token: 0x0600DE3B RID: 56891 RVA: 0x003879A2 File Offset: 0x00385DA2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildEmblemAttrShow";
		}

		// Token: 0x0600DE3C RID: 56892 RVA: 0x003879AC File Offset: 0x00385DAC
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.emblemLvs = new List<int>();
			int maxEmblemLv = DataManager<GuildDataManager>.GetInstance().GetMaxEmblemLv();
			for (int i = 0; i < maxEmblemLv; i++)
			{
				this.emblemLvs.Add(i + 1);
			}
			this.UpdateEmblemAttrs();
		}

		// Token: 0x0600DE3D RID: 56893 RVA: 0x003879FB File Offset: 0x00385DFB
		protected override void _OnCloseFrame()
		{
			this.emblemLvs = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE3E RID: 56894 RVA: 0x00387A0C File Offset: 0x00385E0C
		protected override void _bindExUI()
		{
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeSetOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildEmblemAttrShowFrame>(this, false);
			});
			this.attrsShow = this.mBind.GetCom<ComUIListScript>("attrsShow");
		}

		// Token: 0x0600DE3F RID: 56895 RVA: 0x00387A5C File Offset: 0x00385E5C
		protected override void _unbindExUI()
		{
			this.Close = null;
			this.attrsShow = null;
		}

		// Token: 0x0600DE40 RID: 56896 RVA: 0x00387A6C File Offset: 0x00385E6C
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DE41 RID: 56897 RVA: 0x00387A6E File Offset: 0x00385E6E
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600DE42 RID: 56898 RVA: 0x00387A70 File Offset: 0x00385E70
		private void UpdateEmblemAttrs()
		{
			if (this.attrsShow == null)
			{
				return;
			}
			if (this.emblemLvs == null)
			{
				return;
			}
			this.attrsShow.Initialize();
			this.attrsShow.onBindItem = delegate(GameObject go)
			{
				if (null != go)
				{
					return go.GetComponent<GuildEmblemAttrShowItem>();
				}
				return null;
			};
			this.attrsShow.onItemVisiable = delegate(ComUIListElementScript item)
			{
				GuildEmblemAttrShowItem guildEmblemAttrShowItem = item.gameObjectBindScript as GuildEmblemAttrShowItem;
				if (null != guildEmblemAttrShowItem && item.m_index < this.emblemLvs.Count)
				{
					guildEmblemAttrShowItem.SetUp(this.emblemLvs[item.m_index]);
				}
			};
			this.attrsShow.m_scrollRect.StopMovement();
			this.attrsShow.SetElementAmount(this.emblemLvs.Count);
			this.AdjustSrollBarValue(DataManager<GuildDataManager>.GetInstance().GetEmblemLv());
		}

		// Token: 0x0600DE43 RID: 56899 RVA: 0x00387B1C File Offset: 0x00385F1C
		private void AdjustSrollBarValue(int iEmblemLv)
		{
			if (this.attrsShow == null || this.attrsShow.m_scrollRect == null)
			{
				return;
			}
			int num = Math.Max(1, iEmblemLv);
			RectTransform component = this.attrsShow.GetComponent<RectTransform>();
			float num2 = (float)(num - 1) * ((this.attrsShow.contentSize.y + this.attrsShow.m_elementSpacing.y) / (float)this.attrsShow.m_elementAmount) / (this.attrsShow.contentSize.y - component.rect.height);
			this.attrsShow.m_scrollRect.verticalNormalizedPosition = 1f - num2;
		}

		// Token: 0x040083A3 RID: 33699
		private List<int> emblemLvs;

		// Token: 0x040083A4 RID: 33700
		private new Button Close;

		// Token: 0x040083A5 RID: 33701
		private ComUIListScript attrsShow;
	}
}
