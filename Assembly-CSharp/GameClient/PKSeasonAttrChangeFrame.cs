using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200198E RID: 6542
	internal class PKSeasonAttrChangeFrame : ClientFrame
	{
		// Token: 0x0600FE9E RID: 65182 RVA: 0x0046731B File Offset: 0x0046571B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKSeasonAttrChange";
		}

		// Token: 0x0600FE9F RID: 65183 RVA: 0x00467322 File Offset: 0x00465722
		protected override void _OnOpenFrame()
		{
			this._InitPKRank();
			this._InitDesc();
		}

		// Token: 0x0600FEA0 RID: 65184 RVA: 0x00467330 File Offset: 0x00465730
		protected override void _OnCloseFrame()
		{
			this._ClearPKRank();
			this._ClearDesc();
		}

		// Token: 0x0600FEA1 RID: 65185 RVA: 0x0046733E File Offset: 0x0046573E
		private void _InitPKRank()
		{
			this.m_comPKRank = ComPKRank.Create(this.m_objRankRoot);
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonAttrMappedSeasonID, 0);
			}
		}

		// Token: 0x0600FEA2 RID: 65186 RVA: 0x00467378 File Offset: 0x00465778
		private void _ClearPKRank()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Clear();
				this.m_comPKRank = null;
			}
		}

		// Token: 0x0600FEA3 RID: 65187 RVA: 0x004673A0 File Offset: 0x004657A0
		private void _InitDesc()
		{
			this.m_labMyAttrTitle.text = TR.Value("pk_rank_detail_attr_desc", DataManager<SeasonDataManager>.GetInstance().GetRankName(DataManager<SeasonDataManager>.GetInstance().seasonAttrMappedSeasonID, true));
			SeasonLevel seasonAttr = DataManager<SeasonDataManager>.GetInstance().GetSeasonAttr(DataManager<SeasonDataManager>.GetInstance().seasonAttrID);
			if (seasonAttr != null)
			{
				this.m_labMyAttrContent.text = seasonAttr.strFormatAttr;
			}
			else
			{
				this.m_labMyAttrContent.text = string.Empty;
			}
		}

		// Token: 0x0600FEA4 RID: 65188 RVA: 0x00467418 File Offset: 0x00465818
		private void _ClearDesc()
		{
		}

		// Token: 0x0600FEA5 RID: 65189 RVA: 0x0046741A File Offset: 0x0046581A
		[UIEventHandle("Ok")]
		private void _OnConfirmClicked()
		{
			this.frameMgr.CloseFrame<PKSeasonAttrChangeFrame>(this, false);
		}

		// Token: 0x0400A098 RID: 41112
		[UIObject("RankRoot")]
		private GameObject m_objRankRoot;

		// Token: 0x0400A099 RID: 41113
		[UIControl("Text_T", null, 0)]
		private Text m_labMyAttrTitle;

		// Token: 0x0400A09A RID: 41114
		[UIControl("Text_B", null, 0)]
		private Text m_labMyAttrContent;

		// Token: 0x0400A09B RID: 41115
		private ComPKRank m_comPKRank;
	}
}
