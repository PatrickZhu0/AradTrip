using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001933 RID: 6451
	public class GridMapController : MonoBehaviour
	{
		// Token: 0x0600FAE4 RID: 64228 RVA: 0x0044BA9A File Offset: 0x00449E9A
		private void OnDestroy()
		{
			if (this.mapGridItemDataList != null)
			{
				this.mapGridItemDataList.Clear();
			}
			if (this.zillionaireGameGridItemList != null)
			{
				this.zillionaireGameGridItemList.Clear();
			}
			this.onMoveTargetItemClick = null;
			this.StopMoveCoroutine();
		}

		// Token: 0x0600FAE5 RID: 64229 RVA: 0x0044BAD8 File Offset: 0x00449ED8
		public void InitMap(List<MapGridItemData> mapGridItemDataList, OnMoveTargetItemClick click, int defaultPosition = 0)
		{
			if (mapGridItemDataList == null || click == null)
			{
				return;
			}
			if (mapGridItemDataList.Count <= 0)
			{
				return;
			}
			this.mapGridItemDataList = mapGridItemDataList;
			this.onMoveTargetItemClick = click;
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.gridItemPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			if (gameObject.GetComponent<ZillionaireGameGridItem>() == null)
			{
				Object.Destroy(gameObject);
				return;
			}
			for (int i = 0; i < mapGridItemDataList.Count; i++)
			{
				MapGridItemData mapGridItemData = mapGridItemDataList[i];
				if (mapGridItemData != null)
				{
					int index = i;
					this.OnAddGridItem(gameObject, index, mapGridItemData);
				}
			}
			this.SetTargetPosition(defaultPosition, this.targetGo);
			Object.Destroy(gameObject);
		}

		// Token: 0x0600FAE6 RID: 64230 RVA: 0x0044BB90 File Offset: 0x00449F90
		private void OnAddGridItem(GameObject go, int index, MapGridItemData mapGridItemData)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			Utility.AttachTo(gameObject, this.positionList[index], false);
			ZillionaireGameGridItem component = gameObject.GetComponent<ZillionaireGameGridItem>();
			if (component != null)
			{
				component.OnItemVisiable(mapGridItemData);
				this.zillionaireGameGridItemList.Add(component);
			}
		}

		// Token: 0x0600FAE7 RID: 64231 RVA: 0x0044BBE0 File Offset: 0x00449FE0
		public void RefreshGridMap(List<MapGridItemData> mapGridItemDataList, int defaultPosition = 0)
		{
			if (mapGridItemDataList == null)
			{
				return;
			}
			if (mapGridItemDataList.Count <= 0)
			{
				return;
			}
			this.mapGridItemDataList = mapGridItemDataList;
			for (int i = 0; i < mapGridItemDataList.Count; i++)
			{
				MapGridItemData mapGridItemData = mapGridItemDataList[i];
				if (i <= this.zillionaireGameGridItemList.Count)
				{
					ZillionaireGameGridItem zillionaireGameGridItem = this.zillionaireGameGridItemList[i];
					if (zillionaireGameGridItem != null)
					{
						zillionaireGameGridItem.OnItemVisiable(mapGridItemData);
					}
				}
			}
			this.SetTargetPosition(defaultPosition, this.targetGo);
		}

		// Token: 0x0600FAE8 RID: 64232 RVA: 0x0044BC68 File Offset: 0x0044A068
		public void SetTargetPosition(int position, GameObject targetGo)
		{
			if (position < 0)
			{
				return;
			}
			if (position > this.positionList.Count)
			{
				return;
			}
			GameObject parent = this.positionList[position];
			Utility.AttachTo(targetGo, parent, false);
		}

		// Token: 0x0600FAE9 RID: 64233 RVA: 0x0044BCA4 File Offset: 0x0044A0A4
		public void StartMovePosition(int curPosition, int targetPosition)
		{
			if (curPosition > this.positionList.Count || targetPosition > this.positionList.Count)
			{
				return;
			}
			this.StopMoveCoroutine();
			this.moveCoroutine = base.StartCoroutine(this.Move(curPosition, targetPosition));
		}

		// Token: 0x0600FAEA RID: 64234 RVA: 0x0044BCE4 File Offset: 0x0044A0E4
		private IEnumerator Move(int curPosition, int targetPosition)
		{
			this.OnSetMaskGo(true);
			for (int i = curPosition; i < this.positionList.Count; i++)
			{
				int position = i;
				this.SetTargetPosition(position, this.targetGo);
				if (position == targetPosition)
				{
					if (targetPosition < this.mapGridItemDataList.Count)
					{
						MapGridItemData mapGridItemData = this.mapGridItemDataList[targetPosition];
						if (mapGridItemData != null)
						{
							if (mapGridItemData.gridType == 5)
							{
								ZillionaireGameGridItem gridItem = this.zillionaireGameGridItemList[targetPosition];
								if (gridItem != null)
								{
									gridItem.CustomActive(false);
								}
								this.LoadCheckPointEffect(targetPosition);
								yield return Yielders.GetWaitForSeconds(this.enterDungeonTime);
							}
							else if (mapGridItemData.gridType == 4)
							{
								yield return Yielders.GetWaitForSeconds(this.turnTableTime);
							}
							else
							{
								yield return Yielders.GetWaitForSeconds(this.delayInvokTime);
							}
						}
						this.OnSetMaskGo(false);
						if (this.onMoveTargetItemClick != null)
						{
							this.onMoveTargetItemClick(mapGridItemData);
						}
					}
					break;
				}
				yield return Yielders.GetWaitForSeconds(this.moveSpeed);
			}
			yield break;
		}

		// Token: 0x0600FAEB RID: 64235 RVA: 0x0044BD0D File Offset: 0x0044A10D
		public void OnSetMaskGo(bool value)
		{
			if (this.maskGo != null)
			{
				this.maskGo.CustomActive(value);
			}
		}

		// Token: 0x0600FAEC RID: 64236 RVA: 0x0044BD2C File Offset: 0x0044A12C
		private void StopMoveCoroutine()
		{
			if (this.moveCoroutine != null)
			{
				base.StopCoroutine(this.moveCoroutine);
				this.moveCoroutine = null;
			}
		}

		// Token: 0x0600FAED RID: 64237 RVA: 0x0044BD4C File Offset: 0x0044A14C
		private void LoadCheckPointEffect(int position)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.checkPointEffectPath, true, 0U);
			if (gameObject != null)
			{
				this.SetTargetPosition(position, gameObject);
			}
		}

		// Token: 0x04009CBF RID: 40127
		[SerializeField]
		private List<GameObject> positionList = new List<GameObject>();

		// Token: 0x04009CC0 RID: 40128
		[SerializeField]
		private GameObject targetGo;

		// Token: 0x04009CC1 RID: 40129
		[SerializeField]
		private GameObject maskGo;

		// Token: 0x04009CC2 RID: 40130
		[Header("光标移动速度")]
		[SerializeField]
		private float moveSpeed = 1f;

		// Token: 0x04009CC3 RID: 40131
		[Header("延迟调用回调时间")]
		[SerializeField]
		private float delayInvokTime = 1f;

		// Token: 0x04009CC4 RID: 40132
		[Header("延迟调用回调进入地下城时间")]
		[SerializeField]
		private float enterDungeonTime = 1f;

		// Token: 0x04009CC5 RID: 40133
		[Header("延迟打开转盘时间")]
		[SerializeField]
		private float turnTableTime = 1f;

		// Token: 0x04009CC6 RID: 40134
		[SerializeField]
		private string gridItemPath = "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/GridItem";

		// Token: 0x04009CC7 RID: 40135
		[Header("关卡特效路径")]
		[SerializeField]
		private string checkPointEffectPath = "Effects/UI/Prefab/EffUI_Gongjian/Prefab/EffUI_Gongjian_zhandou01";

		// Token: 0x04009CC8 RID: 40136
		private List<MapGridItemData> mapGridItemDataList = new List<MapGridItemData>();

		// Token: 0x04009CC9 RID: 40137
		private List<ZillionaireGameGridItem> zillionaireGameGridItemList = new List<ZillionaireGameGridItem>();

		// Token: 0x04009CCA RID: 40138
		private OnMoveTargetItemClick onMoveTargetItemClick;

		// Token: 0x04009CCB RID: 40139
		private Coroutine moveCoroutine;
	}
}
