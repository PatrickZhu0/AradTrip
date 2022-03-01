using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D01 RID: 3329
public class GeSimpleShadowManager : Singleton<GeSimpleShadowManager>
{
	// Token: 0x0600880C RID: 34828 RVA: 0x00182C00 File Offset: 0x00181000
	public sealed override void Init()
	{
	}

	// Token: 0x0600880D RID: 34829 RVA: 0x00182C02 File Offset: 0x00181002
	public sealed override void UnInit()
	{
	}

	// Token: 0x0600880E RID: 34830 RVA: 0x00182C04 File Offset: 0x00181004
	public void Update()
	{
		for (int i = 0; i < this.m_SimpleShadowDescList.Count; i++)
		{
			GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc = this.m_SimpleShadowDescList[i];
			if (geSimpleShadowDesc != null)
			{
				if (!(null == geSimpleShadowDesc.m_PlaneShadowObj))
				{
					if (geSimpleShadowDesc.m_PlaneShadowObj.activeInHierarchy)
					{
						if (!(null == geSimpleShadowDesc.m_PlaneGO))
						{
							Vector3 position = geSimpleShadowDesc.m_PlaneGO.transform.position;
							position.y = 0.05f + geSimpleShadowDesc.m_Plane.w;
							geSimpleShadowDesc.m_PlaneGO.transform.position = position;
							geSimpleShadowDesc.m_PlaneGO.transform.rotation = Quaternion.identity;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600880F RID: 34831 RVA: 0x00182CD8 File Offset: 0x001810D8
	public void AddShadowObject(GameObject[] go, Vector4 plane, Vector3 scale)
	{
		if (go != null && go.Length > 0)
		{
			GameObject gameObject = go[0];
			if (null == gameObject)
			{
				return;
			}
			string name = gameObject.name;
			Renderer renderer = null;
			int i = 0;
			int num = go.Length;
			while (i < num)
			{
				renderer = go[i].GetComponentInChildren<Renderer>();
				i++;
			}
			if (null == renderer)
			{
				return;
			}
			int num2 = -1;
			for (int j = 0; j < this.m_SimpleShadowDescList.Count; j++)
			{
				GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc = this.m_SimpleShadowDescList[j];
				if (null == geSimpleShadowDesc.m_PlaneShadowObj)
				{
					num2 = j;
					break;
				}
				if (geSimpleShadowDesc.m_PlaneShadowObj == gameObject)
				{
					break;
				}
			}
			if (num2 != -1)
			{
				if (this.m_SimpleShadowDescList[num2] != null)
				{
					GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc2 = this.m_SimpleShadowDescList[num2];
					geSimpleShadowDesc2.m_PlaneShadowObj = gameObject;
					if (null == geSimpleShadowDesc2.m_PlaneGO)
					{
						geSimpleShadowDesc2.m_PlaneGO = this._CreateShadowRes();
					}
					if (null != geSimpleShadowDesc2.m_PlaneGO)
					{
						geSimpleShadowDesc2.m_PlaneGO.SetActive(true);
						geSimpleShadowDesc2.m_PlaneGO.transform.localPosition = Vector3.zero;
						Vector3 position = gameObject.transform.position;
						position.y = 0.05f + plane.w;
						geSimpleShadowDesc2.m_PlaneGO.transform.position = position;
						geSimpleShadowDesc2.m_PlaneGO.transform.localScale = scale;
						geSimpleShadowDesc2.m_PlaneGO.transform.SetParent(geSimpleShadowDesc2.m_PlaneShadowObj.transform, true);
						geSimpleShadowDesc2.m_PlaneGO.transform.rotation = Quaternion.identity;
					}
					geSimpleShadowDesc2.m_Plane = plane;
				}
			}
			else
			{
				GameObject gameObject2 = this._CreateShadowRes();
				if (gameObject2 != null)
				{
					gameObject2.transform.localPosition = Vector3.zero;
					Vector3 position2 = gameObject.transform.position;
					position2.y = 0.05f + plane.w;
					gameObject2.transform.position = position2;
					gameObject2.transform.SetParent(gameObject.transform, true);
					Vector3 localScale = gameObject2.transform.localScale;
					gameObject2.transform.localScale = scale;
					this.m_SimpleShadowDescList.Add(new GeSimpleShadowManager.GeSimpleShadowDesc(gameObject, gameObject2, plane));
					gameObject2.transform.rotation = Quaternion.identity;
				}
			}
		}
	}

	// Token: 0x06008810 RID: 34832 RVA: 0x00182F57 File Offset: 0x00181357
	private GameObject _CreateShadowRes()
	{
		return Singleton<CGameObjectPool>.instance.GetGameObject("Actor/Other_ShadowPlane/p_ShadowPlane", enResourceType.BattleScene, 2U);
	}

	// Token: 0x06008811 RID: 34833 RVA: 0x00182F6A File Offset: 0x0018136A
	public GameObject GetShadowObj(GameObject go)
	{
		if (this.GetShadow(go) == null)
		{
			return null;
		}
		return this.GetShadow(go).m_PlaneGO;
	}

	// Token: 0x06008812 RID: 34834 RVA: 0x00182F88 File Offset: 0x00181388
	protected GeSimpleShadowManager.GeSimpleShadowDesc GetShadow(GameObject go)
	{
		if (go == null)
		{
			return null;
		}
		GeSimpleShadowManager.GeSimpleShadowDesc result = null;
		for (int i = 0; i < this.m_SimpleShadowDescList.Count; i++)
		{
			GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc = this.m_SimpleShadowDescList[i];
			if (geSimpleShadowDesc.m_PlaneShadowObj == go && geSimpleShadowDesc != null)
			{
				result = geSimpleShadowDesc;
				break;
			}
		}
		return result;
	}

	// Token: 0x06008813 RID: 34835 RVA: 0x00182FF0 File Offset: 0x001813F0
	public void RemoveShadowObject(GameObject[] go)
	{
		if (go == null)
		{
			return;
		}
		for (int i = 0; i < go.Length; i++)
		{
			for (int j = 0; j < this.m_SimpleShadowDescList.Count; j++)
			{
				GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc = this.m_SimpleShadowDescList[j];
				if (geSimpleShadowDesc.m_PlaneShadowObj == go[i])
				{
					this.m_ListDirtyCount++;
					geSimpleShadowDesc.m_PlaneShadowObj = null;
					if (null != geSimpleShadowDesc.m_PlaneGO)
					{
						Singleton<CGameObjectPool>.instance.RecycleGameObject(geSimpleShadowDesc.m_PlaneGO);
						geSimpleShadowDesc.m_PlaneGO = null;
					}
					break;
				}
			}
		}
	}

	// Token: 0x06008814 RID: 34836 RVA: 0x00183098 File Offset: 0x00181498
	public void ClearAll()
	{
		for (int i = 0; i < this.m_SimpleShadowDescList.Count; i++)
		{
			GeSimpleShadowManager.GeSimpleShadowDesc geSimpleShadowDesc = this.m_SimpleShadowDescList[i];
			if (null != geSimpleShadowDesc.m_PlaneGO)
			{
				geSimpleShadowDesc.m_PlaneGO.transform.SetParent(null);
				Singleton<CGameObjectPool>.instance.RecycleGameObject(geSimpleShadowDesc.m_PlaneGO);
				geSimpleShadowDesc.m_PlaneGO = null;
				geSimpleShadowDesc.m_PlaneShadowObj = null;
			}
		}
		this.m_SimpleShadowDescList.Clear();
	}

	// Token: 0x040041E3 RID: 16867
	protected List<GeSimpleShadowManager.GeSimpleShadowDesc> m_SimpleShadowDescList = new List<GeSimpleShadowManager.GeSimpleShadowDesc>();

	// Token: 0x040041E4 RID: 16868
	protected int m_ListDirtyCount;

	// Token: 0x02000D02 RID: 3330
	protected class GeSimpleShadowDesc
	{
		// Token: 0x06008815 RID: 34837 RVA: 0x00183119 File Offset: 0x00181519
		public GeSimpleShadowDesc(GameObject go, GameObject shadowGo, Vector4 plane)
		{
			this.m_PlaneShadowObj = go;
			this.m_Plane = plane;
			this.m_PlaneGO = shadowGo;
		}

		// Token: 0x040041E5 RID: 16869
		public GameObject m_PlaneShadowObj;

		// Token: 0x040041E6 RID: 16870
		public GameObject m_PlaneGO;

		// Token: 0x040041E7 RID: 16871
		public Vector4 m_Plane = new Vector4(0f, 1f, 0f, 0.03f);
	}
}
