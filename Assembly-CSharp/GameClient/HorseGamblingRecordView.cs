using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001691 RID: 5777
	public class HorseGamblingRecordView : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C72 RID: 7282
		// (get) Token: 0x0600E2F3 RID: 58099 RVA: 0x003A5261 File Offset: 0x003A3661
		public List<string> StakeTitleNames
		{
			get
			{
				return this.mStakeTitleNames;
			}
		}

		// Token: 0x17001C73 RID: 7283
		// (get) Token: 0x0600E2F4 RID: 58100 RVA: 0x003A5269 File Offset: 0x003A3669
		public List<string> GameRecordTitleNames
		{
			get
			{
				return this.mGameRecordTitleNames;
			}
		}

		// Token: 0x17001C74 RID: 7284
		// (get) Token: 0x0600E2F5 RID: 58101 RVA: 0x003A5271 File Offset: 0x003A3671
		public List<string> ShooterRankTitleNames
		{
			get
			{
				return this.mShooterRankTitleNames;
			}
		}

		// Token: 0x17001C75 RID: 7285
		// (get) Token: 0x0600E2F6 RID: 58102 RVA: 0x003A5279 File Offset: 0x003A3679
		public List<string> ShooterRecordTitleNames
		{
			get
			{
				return this.mShooterRecordTitleNames;
			}
		}

		// Token: 0x17001C76 RID: 7286
		// (get) Token: 0x0600E2F7 RID: 58103 RVA: 0x003A5281 File Offset: 0x003A3681
		public string ItemBg1
		{
			get
			{
				return this.mItemBg1;
			}
		}

		// Token: 0x17001C77 RID: 7287
		// (get) Token: 0x0600E2F8 RID: 58104 RVA: 0x003A5289 File Offset: 0x003A3689
		public string ItemBg2
		{
			get
			{
				return this.mItemBg2;
			}
		}

		// Token: 0x17001C78 RID: 7288
		// (get) Token: 0x0600E2F9 RID: 58105 RVA: 0x003A5291 File Offset: 0x003A3691
		public string StakeItemPrefab
		{
			get
			{
				return this.mStakeItemPrefab;
			}
		}

		// Token: 0x17001C79 RID: 7289
		// (get) Token: 0x0600E2FA RID: 58106 RVA: 0x003A5299 File Offset: 0x003A3699
		public string GameRecordItemPrefab
		{
			get
			{
				return this.mGameRecordItemPrefab;
			}
		}

		// Token: 0x17001C7A RID: 7290
		// (get) Token: 0x0600E2FB RID: 58107 RVA: 0x003A52A1 File Offset: 0x003A36A1
		public string ShooterRankItemPrefab
		{
			get
			{
				return this.mShooterRankItemPrefab;
			}
		}

		// Token: 0x17001C7B RID: 7291
		// (get) Token: 0x0600E2FC RID: 58108 RVA: 0x003A52A9 File Offset: 0x003A36A9
		public string ShooterRecordItemPrefab
		{
			get
			{
				return this.mShooterHistoryItemPrefab;
			}
		}

		// Token: 0x17001C7C RID: 7292
		// (get) Token: 0x0600E2FD RID: 58109 RVA: 0x003A52B1 File Offset: 0x003A36B1
		public string StakeToggleName
		{
			get
			{
				return this.mStakeToggleName;
			}
		}

		// Token: 0x17001C7D RID: 7293
		// (get) Token: 0x0600E2FE RID: 58110 RVA: 0x003A52B9 File Offset: 0x003A36B9
		public string GameRecordToggleName
		{
			get
			{
				return this.mGameRecordToggleName;
			}
		}

		// Token: 0x17001C7E RID: 7294
		// (get) Token: 0x0600E2FF RID: 58111 RVA: 0x003A52C1 File Offset: 0x003A36C1
		public string ShooterRankToggleName
		{
			get
			{
				return this.mShooterRankToggleName;
			}
		}

		// Token: 0x17001C7F RID: 7295
		// (get) Token: 0x0600E300 RID: 58112 RVA: 0x003A52C9 File Offset: 0x003A36C9
		public string ShooterRecordToggleName
		{
			get
			{
				return this.mShooterRecordToggleName;
			}
		}

		// Token: 0x0600E301 RID: 58113 RVA: 0x003A52D4 File Offset: 0x003A36D4
		public void Init(string[] toggleNames, ComTabGroup.OnToggleValueChanged onValueChanged, ComUIListScript.OnItemVisiableDelegate onItemVisible, ComUIListScript.OnItemUpdateDelegate onItemUpdate, UnityAction onClose, int defaultSelectId = 0)
		{
			this.mListScript.onItemVisiable = onItemVisible;
			this.mListScript.OnItemUpdate = onItemUpdate;
			this.mButtonClose.SafeRemoveAllListener();
			this.mButtonClose.SafeAddOnClickListener(onClose);
			this.mTabGroup.Init(toggleNames, this.mTabPrefabPath, onValueChanged, null, defaultSelectId, null, null);
		}

		// Token: 0x0600E302 RID: 58114 RVA: 0x003A532C File Offset: 0x003A372C
		public void SetData(string titleName, List<string> titles, int dataCount, string itemPrefabPath)
		{
			this.mTextTitle.SafeSetText(titleName);
			for (int i = this.mTitleItems.Count - 1; i >= titles.Count - 1; i--)
			{
				this.mTitleItems[i].Dispose();
			}
			for (int j = 0; j < titles.Count; j++)
			{
				if (j > this.mTitleItems.Count - 1)
				{
					GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mTitleItemPrefabPath, true, 0U);
					if (gameObject != null)
					{
						HorseGamblingRecordTitleItem component = gameObject.GetComponent<HorseGamblingRecordTitleItem>();
						if (component != null)
						{
							component.Init(titles[j]);
							this.mTitleItems.Add(component);
						}
						gameObject.transform.SetParent(this.mRecordTitleRoot, false);
					}
				}
				else
				{
					this.mTitleItems[j].Init(titles[j]);
				}
			}
			this.mListScript.InitialLizeWithExternalElement(itemPrefabPath);
			this.mListScript.SetElementAmount(0);
			this.mListScript.CustomActive(false);
			this.mListScript.SetElementAmount(dataCount);
			this.mListScript.EnsureElementVisable(0);
			this.mListScript.CustomActive(true);
		}

		// Token: 0x0600E303 RID: 58115 RVA: 0x003A5468 File Offset: 0x003A3868
		public void UpdateData(int dataCount)
		{
			this.mListScript.UpdateElementAmount(dataCount);
		}

		// Token: 0x0600E304 RID: 58116 RVA: 0x003A5478 File Offset: 0x003A3878
		public void Dispose()
		{
			if (this.mTabGroup != null)
			{
				this.mTabGroup.Dispose();
			}
			this.mListScript.onItemVisiable = null;
			this.mListScript.OnItemUpdate = null;
			this.mButtonClose.SafeRemoveAllListener();
		}

		// Token: 0x040087D5 RID: 34773
		[SerializeField]
		private ComTabGroup mTabGroup;

		// Token: 0x040087D6 RID: 34774
		[SerializeField]
		private Transform mRecordTitleRoot;

		// Token: 0x040087D7 RID: 34775
		[SerializeField]
		private Text mTextTitle;

		// Token: 0x040087D8 RID: 34776
		[SerializeField]
		private Button mButtonClose;

		// Token: 0x040087D9 RID: 34777
		[SerializeField]
		private string mTitleItemPrefabPath = "UIFlatten/Prefabs/HorseGambling/HorseGamblingRecordTitleItem";

		// Token: 0x040087DA RID: 34778
		[SerializeField]
		private string mTabPrefabPath = "UIFlatten/Prefabs/HorseGambling/HorseGamblingRecordTitleItem";

		// Token: 0x040087DB RID: 34779
		[SerializeField]
		private string mStakeToggleName = "支援记录";

		// Token: 0x040087DC RID: 34780
		[SerializeField]
		private string mGameRecordToggleName = "比赛历史";

		// Token: 0x040087DD RID: 34781
		[SerializeField]
		private string mShooterRankToggleName = "选手排名";

		// Token: 0x040087DE RID: 34782
		[SerializeField]
		private string mShooterRecordToggleName = "选手战绩";

		// Token: 0x040087DF RID: 34783
		[SerializeField]
		private string mStakeItemPrefab = "UIFlatten/Prefabs/HorseGambling/HorseGamblingStakeRecordItem";

		// Token: 0x040087E0 RID: 34784
		[SerializeField]
		private string mGameRecordItemPrefab = "UIFlatten/Prefabs/HorseGambling/HorseGamblingGameRecordItem";

		// Token: 0x040087E1 RID: 34785
		[SerializeField]
		private string mShooterRankItemPrefab = "UIFlatten/Prefabs/HorseGambling/HorseGamblingGameRecordItem";

		// Token: 0x040087E2 RID: 34786
		[SerializeField]
		private string mShooterHistoryItemPrefab = "UIFlatten/Prefabs/HorseGambling/HorseGamblingShooterHistoryItem";

		// Token: 0x040087E3 RID: 34787
		[SerializeField]
		private string mItemBg1 = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_LieBiao_Bg_01";

		// Token: 0x040087E4 RID: 34788
		[SerializeField]
		private string mItemBg2 = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_LieBiao_Bg_02";

		// Token: 0x040087E5 RID: 34789
		[SerializeField]
		private List<string> mStakeTitleNames = new List<string>
		{
			"场次",
			"选手方案",
			"赔率",
			"支援数量",
			"方案盈利"
		};

		// Token: 0x040087E6 RID: 34790
		[SerializeField]
		private List<string> mGameRecordTitleNames = new List<string>
		{
			"场次",
			"冠军",
			"赔率",
			"最大奖金"
		};

		// Token: 0x040087E7 RID: 34791
		[SerializeField]
		private List<string> mShooterRankTitleNames = new List<string>
		{
			"排名",
			"选手名称",
			"比赛次数",
			"胜率"
		};

		// Token: 0x040087E8 RID: 34792
		[SerializeField]
		private List<string> mShooterRecordTitleNames = new List<string>
		{
			"场次",
			"选手名称",
			"赔率",
			"比赛结果"
		};

		// Token: 0x040087E9 RID: 34793
		[SerializeField]
		private ComUIListScript mListScript;

		// Token: 0x040087EA RID: 34794
		private readonly List<HorseGamblingRecordTitleItem> mTitleItems = new List<HorseGamblingRecordTitleItem>();
	}
}
