using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200143A RID: 5178
	public class ArtifactJarDailyRewardView : MonoBehaviour
	{
		// Token: 0x0600C900 RID: 51456 RVA: 0x0030DD1E File Offset: 0x0030C11E
		public void InitView()
		{
			this._InitComUIList();
			this._InitToggle();
			this._InitActivityUI();
			this.jarToggleDataArr[this.mCurToggleIndex].SetToggleIsOn(true);
		}

		// Token: 0x0600C901 RID: 51457 RVA: 0x0030DD48 File Offset: 0x0030C148
		public void UpdateRecord(int jarId)
		{
			if (jarId == this.mCurJarId)
			{
				this.artifactRecordDic = DataManager<ArtifactDataManager>.GetInstance().getArtifactRecordDic();
				if (this.artifactRecordDic.ContainsKey(jarId))
				{
					if (this.artifactRecordDic[jarId].Count == 0)
					{
						this.mEmptyTips.CustomActive(true);
					}
					else
					{
						this.mEmptyTips.CustomActive(false);
					}
					this.mRecordComUIList.SetElementAmount(this.artifactRecordDic[jarId].Count);
				}
				else
				{
					this.mRecordComUIList.SetElementAmount(0);
					this.mEmptyTips.CustomActive(true);
				}
			}
		}

		// Token: 0x0600C902 RID: 51458 RVA: 0x0030DDEE File Offset: 0x0030C1EE
		private void _InitToggle()
		{
			this.allJarData = DataManager<ArtifactDataManager>.GetInstance().getArtiFactJarBuyData();
			this.jarToggleDataArr = new ArtifactJarToggleView[this.allJarData.Count];
			this.mToggleComUIList.SetElementAmount(this.allJarData.Count);
		}

		// Token: 0x0600C903 RID: 51459 RVA: 0x0030DE2C File Offset: 0x0030C22C
		private void _InitComUIList()
		{
			this.mToggleComUIList.Initialize();
			this.mToggleComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.allJarData.Count)
				{
					ArtifactJarToggleView component = item.GetComponent<ArtifactJarToggleView>();
					if (component != null)
					{
						component.SetCallback(new ArtifactJarToggleView.Callback(this.toggleCallBack));
						component.Init(this.allJarData[item.m_index]);
						this.jarToggleDataArr[item.m_index] = component;
					}
				}
			};
			this.mToggleComUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.allJarData.Count)
				{
					ArtifactJarToggleView component = item.GetComponent<ArtifactJarToggleView>();
					if (component != null)
					{
						component.Dispose();
					}
				}
			};
			this.mRecordComUIList.Initialize();
			this.mRecordComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && this.artifactRecordDic.ContainsKey(this.mCurJarId) && item.m_index < this.artifactRecordDic[this.mCurJarId].Count)
				{
					ArtifactJarLotteryRecord artifactJarLotteryRecord = this.artifactRecordDic[this.mCurJarId][item.m_index];
					if (artifactJarLotteryRecord != null)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID((int)artifactJarLotteryRecord.itemId);
						if (commonItemTableDataByID != null)
						{
							string dateTimeHaveMonthToSecond = Function.GetDateTimeHaveMonthToSecond((int)artifactJarLotteryRecord.recordTime);
							string arg = string.Format(" {{I 0 {0} 0}}", artifactJarLotteryRecord.itemId);
							item.gameObject.GetComponent<LinkParse>().SetText(TR.Value("artifact_jar_record", artifactJarLotteryRecord.serverName, artifactJarLotteryRecord.playerName, dateTimeHaveMonthToSecond, arg), true);
						}
					}
				}
			};
		}

		// Token: 0x0600C904 RID: 51460 RVA: 0x0030DE94 File Offset: 0x0030C294
		private void _InitActivityUI()
		{
			OpActivityData artifactAwardActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactAwardActData();
			if (artifactAwardActData != null)
			{
				this.mDes.text = artifactAwardActData.desc;
			}
		}

		// Token: 0x0600C905 RID: 51461 RVA: 0x0030DEC4 File Offset: 0x0030C2C4
		private void SaveJarReward(ArtifactJarBuy jarData)
		{
			if (!this.jarRewardDic.ContainsKey((int)jarData.jarId))
			{
				List<ArtifactJarLotteryTable> list = new List<ArtifactJarLotteryTable>();
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ArtifactJarLotteryTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ArtifactJarLotteryTable artifactJarLotteryTable = keyValuePair.Value as ArtifactJarLotteryTable;
					if (artifactJarLotteryTable.JarId == (int)jarData.jarId)
					{
						list.Add(artifactJarLotteryTable);
					}
				}
				this.jarRewardDic[(int)jarData.jarId] = list;
			}
		}

		// Token: 0x0600C906 RID: 51462 RVA: 0x0030DF50 File Offset: 0x0030C350
		private void SendJarRecord(ArtifactJarBuy jarData)
		{
			DataManager<ArtifactDataManager>.GetInstance().SendArtifactJarRecord((int)jarData.jarId);
			this.mEmptyTips.CustomActive(true);
		}

		// Token: 0x0600C907 RID: 51463 RVA: 0x0030DF70 File Offset: 0x0030C370
		private void UpdateUI(ArtifactJarBuy jarData)
		{
			JarBonus jarBonusData = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>((int)jarData.jarId, string.Empty, string.Empty);
			if (jarBonusData != null)
			{
				this.mJarName.text = jarBonusData.Name;
				this.mRecordTitleText.text = string.Format("{0}派奖记录", jarBonusData.Name);
				ETCImageLoader.LoadSprite(ref this.mJarIcon, jarBonusData.JarImage, true);
				this.mJarTips.text = string.Format(TR.Value("artifact_jar_tips"), jarBonusData.ActifactJarRewardTime);
			}
			if (jarData.buyCnt >= jarData.totalCnt)
			{
				this.mFinished.CustomActive(true);
			}
			else
			{
				this.mFinished.CustomActive(false);
			}
			if (jarData.buyCnt >= jarData.totalCnt)
			{
				this.mJarCount.text = string.Format(TR.Value("artifact_jar_finish_tips"), jarData.totalCnt, jarData.totalCnt);
				this.mJarFinished.CustomActive(true);
			}
			else
			{
				this.mJarFinished.CustomActive(false);
				this.mJarCount.text = string.Format(TR.Value("artifact_jar_unfinish_tips"), jarData.buyCnt, jarData.totalCnt);
			}
			this.mPreviewReward.onClick.RemoveAllListeners();
			this.mPreviewReward.onClick.AddListener(delegate()
			{
				ArtifactJarRewardData artifactJarRewardData = new ArtifactJarRewardData();
				artifactJarRewardData.itemList = DataManager<ArtifactDataManager>.GetInstance().GetArtifactJarLotteryRewards((uint)this.mCurJarId);
				if (jarBonusData != null)
				{
					artifactJarRewardData.desc = string.Format(TR.Value("artifact_jar_preview_tips"), jarBonusData.ActifactJarRewardTime);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ArtifactJarRewardPreviewFrame>(FrameLayer.Middle, artifactJarRewardData, string.Empty);
			});
			this.mBoxBtn.onClick.RemoveAllListeners();
			this.mBoxBtn.onClick.AddListener(delegate()
			{
				ArtifactJarRewardData artifactJarRewardData = new ArtifactJarRewardData();
				artifactJarRewardData.itemList = DataManager<ArtifactDataManager>.GetInstance().GetArtifactJarLotteryRewards((uint)this.mCurJarId);
				if (jarBonusData != null)
				{
					artifactJarRewardData.desc = string.Format(TR.Value("artifact_jar_preview_tips"), jarBonusData.ActifactJarRewardTime);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ArtifactJarRewardPreviewFrame>(FrameLayer.Middle, artifactJarRewardData, string.Empty);
			});
			if ((long)this.mCurJarId == (long)((ulong)this.allJarData[0].jarId))
			{
				this.mLeftBtn.CustomActive(false);
			}
			else
			{
				this.mLeftBtn.CustomActive(true);
			}
			if ((long)this.mCurJarId == (long)((ulong)this.allJarData[this.allJarData.Count - 1].jarId) || !this.jarToggleDataArr[this.mCurToggleIndex + 1].canPreviewJar())
			{
				this.mRightBtn.CustomActive(false);
			}
			else
			{
				this.mRightBtn.CustomActive(true);
			}
			this.mLeftBtn.onClick.RemoveAllListeners();
			this.mLeftBtn.onClick.AddListener(delegate()
			{
				for (int i = 0; i < this.allJarData.Count; i++)
				{
					if ((ulong)this.allJarData[i].jarId == (ulong)((long)this.mCurJarId) && i != 0)
					{
						this.jarToggleDataArr[i - 1].SetToggleIsOn(true);
						break;
					}
				}
			});
			this.mRightBtn.onClick.RemoveAllListeners();
			this.mRightBtn.onClick.AddListener(delegate()
			{
				for (int i = 0; i < this.allJarData.Count; i++)
				{
					if ((ulong)this.allJarData[i].jarId == (ulong)((long)this.mCurJarId) && i != this.allJarData.Count - 1)
					{
						this.jarToggleDataArr[i + 1].SetToggleIsOn(true);
						break;
					}
				}
			});
			OpActivityData artifactAwardActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactAwardActData();
			if (DataManager<ArtifactDataManager>.GetInstance().IsArtifactActivityOpen())
			{
				this.mShowStateGo.CustomActive(true);
				this.mFinishedNeedHide.CustomActive(false);
			}
			else
			{
				this.mShowStateGo.CustomActive(false);
				this.mFinishedNeedHide.CustomActive(true);
			}
		}

		// Token: 0x0600C908 RID: 51464 RVA: 0x0030E284 File Offset: 0x0030C684
		private void toggleCallBack(ArtifactJarBuy jarData)
		{
			this.mCurJarId = (int)jarData.jarId;
			for (int i = 0; i < this.allJarData.Count; i++)
			{
				if ((ulong)this.allJarData[i].jarId == (ulong)((long)this.mCurJarId))
				{
					this.mCurToggleIndex = i;
				}
			}
			this.SendJarRecord(jarData);
			this.SaveJarReward(jarData);
			this.UpdateUI(jarData);
		}

		// Token: 0x040073F1 RID: 29681
		[SerializeField]
		private Button closeBtn;

		// Token: 0x040073F2 RID: 29682
		[SerializeField]
		private Text mDes;

		// Token: 0x040073F3 RID: 29683
		[SerializeField]
		private ComUIListScript mToggleComUIList;

		// Token: 0x040073F4 RID: 29684
		[SerializeField]
		private ComUIListScript mRecordComUIList;

		// Token: 0x040073F5 RID: 29685
		[Space(5f)]
		[SerializeField]
		private Button mLeftBtn;

		// Token: 0x040073F6 RID: 29686
		[SerializeField]
		private Button mRightBtn;

		// Token: 0x040073F7 RID: 29687
		[SerializeField]
		private Image mJarIcon;

		// Token: 0x040073F8 RID: 29688
		[SerializeField]
		private Text mJarName;

		// Token: 0x040073F9 RID: 29689
		[SerializeField]
		private Text mJarTips;

		// Token: 0x040073FA RID: 29690
		[SerializeField]
		private Text mJarCount;

		// Token: 0x040073FB RID: 29691
		[SerializeField]
		private GameObject mJarFinished;

		// Token: 0x040073FC RID: 29692
		[SerializeField]
		private GameObject mFinished;

		// Token: 0x040073FD RID: 29693
		[SerializeField]
		private GameObject mFinishedNeedHide;

		// Token: 0x040073FE RID: 29694
		[SerializeField]
		private GameObject mShowStateGo;

		// Token: 0x040073FF RID: 29695
		[SerializeField]
		private Button mPreviewReward;

		// Token: 0x04007400 RID: 29696
		[SerializeField]
		private Button mBoxBtn;

		// Token: 0x04007401 RID: 29697
		[Space(5f)]
		[SerializeField]
		private Text mRecordTitleText;

		// Token: 0x04007402 RID: 29698
		[SerializeField]
		private GameObject mEmptyTips;

		// Token: 0x04007403 RID: 29699
		private ArtifactJarToggleView[] jarToggleDataArr;

		// Token: 0x04007404 RID: 29700
		private List<ArtifactJarBuy> allJarData = new List<ArtifactJarBuy>();

		// Token: 0x04007405 RID: 29701
		private Dictionary<int, List<ArtifactJarLotteryTable>> jarRewardDic = new Dictionary<int, List<ArtifactJarLotteryTable>>();

		// Token: 0x04007406 RID: 29702
		private Dictionary<int, List<ArtifactJarLotteryRecord>> artifactRecordDic = new Dictionary<int, List<ArtifactJarLotteryRecord>>();

		// Token: 0x04007407 RID: 29703
		private int mCurJarId;

		// Token: 0x04007408 RID: 29704
		private int mCurToggleIndex;
	}
}
