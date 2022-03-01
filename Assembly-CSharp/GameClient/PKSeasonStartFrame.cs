using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001992 RID: 6546
	internal class PKSeasonStartFrame : ClientFrame
	{
		// Token: 0x0600FECC RID: 65228 RVA: 0x00468311 File Offset: 0x00466711
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKSeasonStart";
		}

		// Token: 0x0600FECD RID: 65229 RVA: 0x00468318 File Offset: 0x00466718
		protected override void _OnOpenFrame()
		{
			this._InitSeasonName();
			this._InitPKRank();
			this._InitDesc();
		}

		// Token: 0x0600FECE RID: 65230 RVA: 0x0046832C File Offset: 0x0046672C
		protected override void _OnCloseFrame()
		{
			this._ClearSeasonName();
			this._ClearPKRank();
			this._ClearDesc();
		}

		// Token: 0x0600FECF RID: 65231 RVA: 0x00468340 File Offset: 0x00466740
		private void _InitSeasonName()
		{
			for (int i = 0; i < this.m_objDigitRoot.transform.childCount; i++)
			{
				this.m_objDigitRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
			int num = 0;
			int j = DataManager<SeasonDataManager>.GetInstance().seasonID;
			while (j > 0)
			{
				int num2 = j % 10;
				GameObject gameObject;
				if (num < this.m_objDigitRoot.transform.childCount)
				{
					gameObject = this.m_objDigitRoot.transform.GetChild(num).gameObject;
				}
				else
				{
					gameObject = Object.Instantiate<GameObject>(this.m_objDigitTemplate);
					gameObject.transform.SetParent(this.m_objDigitRoot.transform, false);
					gameObject.transform.SetAsFirstSibling();
				}
				gameObject.SetActive(true);
				Image component = gameObject.GetComponent<Image>();
				ETCImageLoader.LoadSprite(ref component, string.Format(this.m_strDigitPath, num2), true);
				j /= 10;
				num++;
			}
		}

		// Token: 0x0600FED0 RID: 65232 RVA: 0x00468443 File Offset: 0x00466843
		private void _ClearSeasonName()
		{
		}

		// Token: 0x0600FED1 RID: 65233 RVA: 0x00468448 File Offset: 0x00466848
		private void _InitPKRank()
		{
			this.m_comPKRank = ComPKRank.Create(this.m_objRankRoot);
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Initialize(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonExp);
			}
		}

		// Token: 0x0600FED2 RID: 65234 RVA: 0x00468496 File Offset: 0x00466896
		private void _ClearPKRank()
		{
			if (this.m_comPKRank != null)
			{
				this.m_comPKRank.Clear();
				this.m_comPKRank = null;
			}
		}

		// Token: 0x0600FED3 RID: 65235 RVA: 0x004684BB File Offset: 0x004668BB
		private void _InitDesc()
		{
			this.m_labDesc.text = TR.Value("pk_rank_season_start_desc", DataManager<SeasonDataManager>.GetInstance().GetRankName(DataManager<SeasonDataManager>.GetInstance().seasonLevel, true));
		}

		// Token: 0x0600FED4 RID: 65236 RVA: 0x004684E7 File Offset: 0x004668E7
		private void _ClearDesc()
		{
		}

		// Token: 0x0600FED5 RID: 65237 RVA: 0x004684E9 File Offset: 0x004668E9
		[UIEventHandle("Ok")]
		private void _OnConfirmClicked()
		{
			this.frameMgr.CloseFrame<PKSeasonStartFrame>(this, false);
		}

		// Token: 0x0400A0B6 RID: 41142
		[UIObject("TitleGroup/Name/Numbers")]
		private GameObject m_objDigitRoot;

		// Token: 0x0400A0B7 RID: 41143
		[UIObject("TitleGroup/Name/Numbers/Number")]
		private GameObject m_objDigitTemplate;

		// Token: 0x0400A0B8 RID: 41144
		[UIObject("RankRoot")]
		private GameObject m_objRankRoot;

		// Token: 0x0400A0B9 RID: 41145
		[UIControl("DescGroup/Text", null, 0)]
		private Text m_labDesc;

		// Token: 0x0400A0BA RID: 41146
		private string m_strDigitPath = "UI/Image/Packed/p_UI_SeasonNumber.png:UI_Season_Number_0{0}";

		// Token: 0x0400A0BB RID: 41147
		private ComPKRank m_comPKRank;
	}
}
