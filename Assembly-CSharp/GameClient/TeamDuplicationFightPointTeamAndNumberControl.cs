using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C88 RID: 7304
	public class TeamDuplicationFightPointTeamAndNumberControl : MonoBehaviour
	{
		// Token: 0x06011E9B RID: 73371 RVA: 0x0053D5BC File Offset: 0x0053B9BC
		public void ClearControl()
		{
		}

		// Token: 0x06011E9C RID: 73372 RVA: 0x0053D5C0 File Offset: 0x0053B9C0
		public void UpdateFightPointTeamItemList(List<uint> teamIndexList)
		{
			this.ResetFightPointTeamItemList();
			if (teamIndexList == null || teamIndexList.Count <= 0)
			{
				return;
			}
			int count = teamIndexList.Count;
			if (count % 2 == 1)
			{
				CommonUtility.UpdateGameObjectVisible(this.fightPointTeamOddRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.fightPointTeamEvenRoot, true);
			}
			for (int i = 0; i < teamIndexList.Count; i++)
			{
				uint num = teamIndexList[i];
				if (num >= 1U && (ulong)num <= (ulong)((long)this.teamItemList.Count))
				{
					GameObject gameObject = this.teamItemList[(int)(num - 1U)];
					if (gameObject != null)
					{
						CommonUtility.UpdateGameObjectVisible(gameObject.gameObject, true);
						this._currentTeamItemList.Add(gameObject);
					}
				}
			}
			if (count == 1)
			{
				this.UpdateFightPointTeamPosition(this.fightPointTeamOddOnePositionList);
			}
			else if (count == 2)
			{
				this.UpdateFightPointTeamPosition(this.fightPointTeamEvenTwoPositionList);
			}
			else if (count == 3)
			{
				this.UpdateFightPointTeamPosition(this.fightPointTeamOddThreePositionList);
			}
			else if (count == 4)
			{
				this.UpdateFightPointTeamPosition(this.fightPointTeamEvenFourPositionList);
			}
		}

		// Token: 0x06011E9D RID: 73373 RVA: 0x0053D6DC File Offset: 0x0053BADC
		private void ResetFightPointTeamItemList()
		{
			this._currentTeamItemList.Clear();
			for (int i = 0; i < this.teamItemList.Count; i++)
			{
				GameObject gameObject = this.teamItemList[i];
				if (gameObject != null)
				{
					CommonUtility.UpdateGameObjectVisible(gameObject.gameObject, false);
				}
			}
			CommonUtility.UpdateGameObjectVisible(this.fightPointTeamOddRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.fightPointTeamEvenRoot, false);
		}

		// Token: 0x06011E9E RID: 73374 RVA: 0x0053D750 File Offset: 0x0053BB50
		private void UpdateFightPointTeamPosition(List<RectTransform> teamPositionList)
		{
			int num = 0;
			while (num < teamPositionList.Count && num < this._currentTeamItemList.Count)
			{
				RectTransform rectTransform = teamPositionList[num];
				GameObject gameObject = this._currentTeamItemList[num];
				if (!(rectTransform == null) && !(gameObject == null))
				{
					RectTransform rectTransform2 = gameObject.gameObject.transform as RectTransform;
					if (!(rectTransform2 == null))
					{
						rectTransform2.anchoredPosition = rectTransform.localPosition;
					}
				}
				num++;
			}
		}

		// Token: 0x06011E9F RID: 73375 RVA: 0x0053D7EC File Offset: 0x0053BBEC
		public void UpdateFightPointFightNumberItemList(int finishedNumber, int totalNumber)
		{
			this.ResetFightPointFightNumberItemList();
			if (totalNumber <= 1)
			{
				return;
			}
			int num = 0;
			while (num < this.fightPointNumberItemList.Count && num < totalNumber)
			{
				TeamDuplicationFightPointNumberItem teamDuplicationFightPointNumberItem = this.fightPointNumberItemList[num];
				CommonUtility.UpdateGameObjectVisible(teamDuplicationFightPointNumberItem.gameObject, true);
				if (num < finishedNumber)
				{
					teamDuplicationFightPointNumberItem.Init(true);
				}
				num++;
			}
		}

		// Token: 0x06011EA0 RID: 73376 RVA: 0x0053D854 File Offset: 0x0053BC54
		private void ResetFightPointFightNumberItemList()
		{
			for (int i = 0; i < this.fightPointNumberItemList.Count; i++)
			{
				TeamDuplicationFightPointNumberItem teamDuplicationFightPointNumberItem = this.fightPointNumberItemList[i];
				if (teamDuplicationFightPointNumberItem != null)
				{
					teamDuplicationFightPointNumberItem.Init(false);
					CommonUtility.UpdateGameObjectVisible(teamDuplicationFightPointNumberItem.gameObject, false);
				}
			}
		}

		// Token: 0x0400BAB2 RID: 47794
		private List<GameObject> _currentTeamItemList = new List<GameObject>();

		// Token: 0x0400BAB3 RID: 47795
		[Space(25f)]
		[Header("teamItem")]
		[Space(15f)]
		[SerializeField]
		private List<GameObject> teamItemList = new List<GameObject>();

		// Token: 0x0400BAB4 RID: 47796
		[Space(10f)]
		[Header("teamOddRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject fightPointTeamOddRoot;

		// Token: 0x0400BAB5 RID: 47797
		[SerializeField]
		private List<RectTransform> fightPointTeamOddOnePositionList = new List<RectTransform>();

		// Token: 0x0400BAB6 RID: 47798
		[SerializeField]
		private List<RectTransform> fightPointTeamOddThreePositionList = new List<RectTransform>();

		// Token: 0x0400BAB7 RID: 47799
		[Space(10f)]
		[Header("teamEvenRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject fightPointTeamEvenRoot;

		// Token: 0x0400BAB8 RID: 47800
		[SerializeField]
		private List<RectTransform> fightPointTeamEvenTwoPositionList = new List<RectTransform>();

		// Token: 0x0400BAB9 RID: 47801
		[SerializeField]
		private List<RectTransform> fightPointTeamEvenFourPositionList = new List<RectTransform>();

		// Token: 0x0400BABA RID: 47802
		[Space(25f)]
		[Header("fightPointNumber")]
		[Space(15f)]
		[SerializeField]
		private List<TeamDuplicationFightPointNumberItem> fightPointNumberItemList = new List<TeamDuplicationFightPointNumberItem>();
	}
}
