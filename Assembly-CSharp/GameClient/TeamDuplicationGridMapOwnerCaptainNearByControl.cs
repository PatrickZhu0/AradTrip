using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C66 RID: 7270
	public class TeamDuplicationGridMapOwnerCaptainNearByControl : MonoBehaviour
	{
		// Token: 0x06011DD0 RID: 73168 RVA: 0x0053AAD5 File Offset: 0x00538ED5
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011DD1 RID: 73169 RVA: 0x0053AADD File Offset: 0x00538EDD
		private void ClearData()
		{
			if (this._nearByFlagList != null)
			{
				this._nearByFlagList.Clear();
				this._nearByFlagList = null;
			}
		}

		// Token: 0x06011DD2 RID: 73170 RVA: 0x0053AAFC File Offset: 0x00538EFC
		private void InitNearByFlagList(int listNumber)
		{
			this._nearByFlagList = new List<GameObject>();
			for (int i = 0; i < listNumber; i++)
			{
				this._nearByFlagList.Add(null);
			}
		}

		// Token: 0x06011DD3 RID: 73171 RVA: 0x0053AB34 File Offset: 0x00538F34
		public void UpdateOwnerCaptainNearByControl(List<TeamDuplicationGridMapGridItem> nearByGridItemList)
		{
			if (this.nearByFlagGo == null)
			{
				return;
			}
			int count = nearByGridItemList.Count;
			if (this._nearByFlagList == null)
			{
				this.InitNearByFlagList(count);
			}
			for (int i = 0; i < count; i++)
			{
				TeamDuplicationGridMapGridItem teamDuplicationGridMapGridItem = nearByGridItemList[i];
				if (teamDuplicationGridMapGridItem == null)
				{
					this.UpdateOwnerCaptainNearByOneGridItem(null, i, false);
				}
				else
				{
					this.UpdateOwnerCaptainNearByOneGridItem(teamDuplicationGridMapGridItem, i, true);
				}
			}
		}

		// Token: 0x06011DD4 RID: 73172 RVA: 0x0053ABAC File Offset: 0x00538FAC
		public void UpdateOwnerCaptainNearByOneGridItem(TeamDuplicationGridMapGridItem gridItem, int index, bool isShow)
		{
			if (this._nearByFlagList == null || this._nearByFlagList.Count <= 0)
			{
				return;
			}
			if (index >= this._nearByFlagList.Count)
			{
				return;
			}
			GameObject gameObject = this._nearByFlagList[index];
			if (isShow && gridItem != null)
			{
				if (gameObject == null)
				{
					gameObject = this.CreateOneNearByFlag(index);
				}
				GameObject upRoot = gridItem.GetUpRoot();
				this.SetNewByFlagParentRoot(gameObject, upRoot);
				CommonUtility.UpdateGameObjectVisible(gameObject, true);
			}
			else
			{
				this.ResetNearByFlagParentRoot(gameObject);
				CommonUtility.UpdateGameObjectVisible(gameObject, false);
			}
		}

		// Token: 0x06011DD5 RID: 73173 RVA: 0x0053AC44 File Offset: 0x00539044
		private GameObject CreateOneNearByFlag(int index)
		{
			if (this.nearByFlagGo == null)
			{
				return null;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(this.nearByFlagGo);
			this._nearByFlagList[index] = gameObject;
			if (gameObject != null)
			{
				gameObject.name = gameObject.name + "_" + (index + 1);
			}
			return gameObject;
		}

		// Token: 0x06011DD6 RID: 73174 RVA: 0x0053ACA8 File Offset: 0x005390A8
		private void SetNewByFlagParentRoot(GameObject flagGo, GameObject parentRoot)
		{
			if (flagGo == null)
			{
				return;
			}
			if (parentRoot == null)
			{
				return;
			}
			flagGo.transform.SetParent(parentRoot.transform, false);
		}

		// Token: 0x06011DD7 RID: 73175 RVA: 0x0053ACD6 File Offset: 0x005390D6
		private void ResetNearByFlagParentRoot(GameObject curNearByFlagGo)
		{
			if (curNearByFlagGo == null)
			{
				return;
			}
			if (this.nearByFlagParentRoot == null)
			{
				return;
			}
			curNearByFlagGo.transform.SetParent(this.nearByFlagParentRoot.transform, false);
		}

		// Token: 0x0400BA20 RID: 47648
		private List<GameObject> _nearByFlagList;

		// Token: 0x0400BA21 RID: 47649
		[Space(10f)]
		[Header("NearByFlagRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject nearByFlagParentRoot;

		// Token: 0x0400BA22 RID: 47650
		[SerializeField]
		private GameObject nearByFlagGo;
	}
}
