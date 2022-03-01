using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014BD RID: 5309
	public class ChallengeChapterNormalControl : MonoBehaviour
	{
		// Token: 0x0600CDDC RID: 52700 RVA: 0x0032B6AE File Offset: 0x00329AAE
		private void Awake()
		{
		}

		// Token: 0x0600CDDD RID: 52701 RVA: 0x0032B6B0 File Offset: 0x00329AB0
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CDDE RID: 52702 RVA: 0x0032B6B8 File Offset: 0x00329AB8
		private void ClearData()
		{
			this._dungeonTable = null;
			this._dungeonId = 0;
		}

		// Token: 0x0600CDDF RID: 52703 RVA: 0x0032B6C8 File Offset: 0x00329AC8
		public void UpdateNormalControl(int dungeonId, DungeonTable dungeonTable)
		{
			this._dungeonId = dungeonId;
			this._dungeonTable = dungeonTable;
			if (this._dungeonTable == null)
			{
				return;
			}
			this.UpdateNormalView();
		}

		// Token: 0x0600CDE0 RID: 52704 RVA: 0x0032B6EC File Offset: 0x00329AEC
		private void UpdateNormalView()
		{
			if (this.chapterName != null)
			{
				this.chapterName.text = this._dungeonTable.Name;
			}
			if (this.chapterDescription != null)
			{
				this.chapterDescription.text = this._dungeonTable.Description;
			}
			if (this.chapterBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.chapterBackground, this._dungeonTable.TumbPath, true);
			}
			if (this.chapterLock != null)
			{
				bool bActive = ChallengeUtility.IsDungeonLock(this._dungeonId);
				this.chapterLock.gameObject.CustomActive(bActive);
			}
			this.UpdateLevelResistValue(this._dungeonId);
		}

		// Token: 0x0600CDE1 RID: 52705 RVA: 0x0032B7AC File Offset: 0x00329BAC
		private void UpdateLevelResistValue(int dungeonId)
		{
			int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(dungeonId);
			if (dungeonResistMagicValueById <= 0)
			{
				this.levelResistValueRoot.gameObject.CustomActive(false);
			}
			else
			{
				this.levelResistValueRoot.gameObject.CustomActive(true);
				this.levelResistValueNumber.text = dungeonResistMagicValueById.ToString();
				int dungeonMainPlayerResistMagicValue = DungeonUtility.GetDungeonMainPlayerResistMagicValue();
				int mainPlayerResistAddByBuff = BeUtility.GetMainPlayerResistAddByBuff();
				if (mainPlayerResistAddByBuff == 0)
				{
					if (dungeonResistMagicValueById > dungeonMainPlayerResistMagicValue)
					{
						this.ownerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_less"), dungeonMainPlayerResistMagicValue);
					}
					else
					{
						this.ownerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_normal"), dungeonMainPlayerResistMagicValue);
					}
				}
				else
				{
					int num = dungeonMainPlayerResistMagicValue - mainPlayerResistAddByBuff;
					if (dungeonResistMagicValueById > num)
					{
						this.ownerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_add_buff_less"), num, mainPlayerResistAddByBuff);
					}
					else
					{
						this.ownerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_add_buff_normal"), num, mainPlayerResistAddByBuff);
					}
				}
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					DungeonUtility.ShowResistMagicValueTips(dungeonResistMagicValueById);
				}
			}
			if (this.rebornLimitNumberValue != null)
			{
				this.rebornLimitNumberValue.text = DungeonUtility.GetDungeonRebornValue(dungeonId);
			}
			if (this._dungeonTable.SubType == DungeonTable.eSubType.S_DEVILDDOM)
			{
				if (this.helpAssistant != null)
				{
					this.helpAssistant.eType = HelpFrame.HelpType.HT_LEVEL_RESISTMAGIC;
				}
			}
			else if (this.helpAssistant != null)
			{
				this.helpAssistant.eType = HelpFrame.HelpType.HT_WEEKOFTENHELL_RESISTMAGIC;
			}
		}

		// Token: 0x0400782C RID: 30764
		private int _dungeonId;

		// Token: 0x0400782D RID: 30765
		private DungeonTable _dungeonTable;

		// Token: 0x0400782E RID: 30766
		[SerializeField]
		private Text chapterName;

		// Token: 0x0400782F RID: 30767
		[SerializeField]
		private Text chapterDescription;

		// Token: 0x04007830 RID: 30768
		[SerializeField]
		private Image chapterBackground;

		// Token: 0x04007831 RID: 30769
		[SerializeField]
		private GameObject chapterLock;

		// Token: 0x04007832 RID: 30770
		[Space(5f)]
		[Header("抗魔值")]
		[SerializeField]
		private GameObject levelResistValueRoot;

		// Token: 0x04007833 RID: 30771
		[SerializeField]
		private Text levelResistValueNumber;

		// Token: 0x04007834 RID: 30772
		[SerializeField]
		private Text ownerResistValueNumber;

		// Token: 0x04007835 RID: 30773
		[SerializeField]
		private Text rebornLimitNumberValue;

		// Token: 0x04007836 RID: 30774
		[SerializeField]
		private HelpAssistant helpAssistant;
	}
}
