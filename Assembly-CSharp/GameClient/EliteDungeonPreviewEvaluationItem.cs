using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001540 RID: 5440
	public class EliteDungeonPreviewEvaluationItem : MonoBehaviour
	{
		// Token: 0x0600D477 RID: 54391 RVA: 0x003505AC File Offset: 0x0034E9AC
		private void Start()
		{
		}

		// Token: 0x0600D478 RID: 54392 RVA: 0x003505AE File Offset: 0x0034E9AE
		private void Update()
		{
		}

		// Token: 0x0600D479 RID: 54393 RVA: 0x003505B0 File Offset: 0x0034E9B0
		public void SetUp(object data, int index)
		{
			if (!(data is int))
			{
				return;
			}
			int dungeonID = (int)data;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.dungeonName.SafeSetText(tableItem.Name);
			if (EliteDungeonPreviewFrame.GetDungeonState(dungeonID) == ComChapterDungeonUnit.eState.Locked)
			{
				this.lockTip.CustomActive(true);
				this.evaluationRoot.CustomActive(false);
				this.gouflag.CustomActive(false);
				this.lockTip.SafeSetText(TR.Value("elite_dungeon_preview_unopen"));
			}
			else if (EliteDungeonPreviewFrame.GetDungeonState(dungeonID) == ComChapterDungeonUnit.eState.Unlock)
			{
				this.lockTip.CustomActive(true);
				this.evaluationRoot.CustomActive(false);
				this.gouflag.CustomActive(false);
				this.lockTip.SafeSetText(TR.Value("elite_dungeon_preview_unpass"));
			}
			else
			{
				this.lockTip.CustomActive(false);
				this.evaluationRoot.CustomActive(true);
				this.SetScore(EliteDungeonPreviewFrame.GetBestScore(dungeonID));
				this.gouflag.CustomActive(EliteDungeonPreviewFrame.HasSSS(dungeonID));
			}
			this.bg.CustomActive(index % 2 != 0);
			this.enterDungeon.SafeSetOnClickListener(delegate
			{
				List<int> currentChapterNormalDungeonIDs = EliteDungeonPreviewFrame.GetCurrentChapterNormalDungeonIDs();
				if (currentChapterNormalDungeonIDs == null)
				{
					return;
				}
				int num = currentChapterNormalDungeonIDs.FindIndex((int id) => id == dungeonID);
				if (num >= 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SelectEnterDungeon, num, null, null, null);
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<EliteDungeonPreviewFrame>(null, false);
				}
			});
			if (EliteDungeonPreviewFrame.GetDungeonState(dungeonID) == ComChapterDungeonUnit.eState.Locked)
			{
				this.enterDungeon.CustomActive(false);
			}
			else
			{
				this.enterDungeon.CustomActive(EliteDungeonPreviewFrame.GetDungeonState(dungeonID) == ComChapterDungeonUnit.eState.Unlock || EliteDungeonPreviewFrame.GetBestScore(dungeonID) != DungeonScore.SSS);
			}
		}

		// Token: 0x0600D47A RID: 54394 RVA: 0x00350768 File Offset: 0x0034EB68
		private void SetScore(DungeonScore score)
		{
			if (this.bind == null)
			{
				return;
			}
			GameObject gameObject = this.bind.GetGameObject("scoreImage0");
			GameObject gameObject2 = this.bind.GetGameObject("scoreImage1");
			GameObject gameObject3 = this.bind.GetGameObject("scoreImage2");
			gameObject.CustomActive(false);
			gameObject2.CustomActive(false);
			gameObject3.CustomActive(false);
			Image component = gameObject.GetComponent<Image>();
			Image component2 = gameObject2.GetComponent<Image>();
			Image component3 = gameObject3.GetComponent<Image>();
			this.bind.GetSprite("s", ref component);
			this.bind.GetSprite("s", ref component2);
			this.bind.GetSprite("s", ref component3);
			switch (score)
			{
			case DungeonScore.C:
			case DungeonScore.B:
			case DungeonScore.A:
			{
				gameObject.CustomActive(true);
				Image component4 = gameObject.GetComponent<Image>();
				this.bind.GetSprite("a", ref component4);
				break;
			}
			case DungeonScore.S:
				gameObject.CustomActive(true);
				break;
			case DungeonScore.SS:
				gameObject.CustomActive(true);
				gameObject2.CustomActive(true);
				break;
			case DungeonScore.SSS:
				gameObject.CustomActive(true);
				gameObject2.CustomActive(true);
				gameObject3.CustomActive(true);
				break;
			}
		}

		// Token: 0x04007C9C RID: 31900
		[SerializeField]
		private Text dungeonName;

		// Token: 0x04007C9D RID: 31901
		[SerializeField]
		private Text lockTip;

		// Token: 0x04007C9E RID: 31902
		[SerializeField]
		private Image gouflag;

		// Token: 0x04007C9F RID: 31903
		[SerializeField]
		private ComCommonBind bind;

		// Token: 0x04007CA0 RID: 31904
		[SerializeField]
		private GameObject evaluationRoot;

		// Token: 0x04007CA1 RID: 31905
		[SerializeField]
		private Image bg;

		// Token: 0x04007CA2 RID: 31906
		[SerializeField]
		private Button enterDungeon;
	}
}
