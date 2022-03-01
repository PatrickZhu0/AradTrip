using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CFD RID: 3325
public class GeSceneObjManager : Singleton<GeSceneObjManager>
{
	// Token: 0x060087FF RID: 34815 RVA: 0x001824ED File Offset: 0x001808ED
	public override void Init()
	{
	}

	// Token: 0x06008800 RID: 34816 RVA: 0x001824EF File Offset: 0x001808EF
	public override void UnInit()
	{
	}

	// Token: 0x06008801 RID: 34817 RVA: 0x001824F1 File Offset: 0x001808F1
	public bool SetRefCamera(GameObject mainCamera)
	{
		if (null == mainCamera)
		{
			return false;
		}
		this.m_CameraNode = mainCamera;
		this.m_Camera = this.m_CameraNode.GetComponent<Camera>();
		return !(null == this.m_Camera);
	}

	// Token: 0x06008802 RID: 34818 RVA: 0x0018252D File Offset: 0x0018092D
	public void SetFocusEntity(GameObject goFocus)
	{
		this.m_FocusObj = goFocus;
	}

	// Token: 0x06008803 RID: 34819 RVA: 0x00182538 File Offset: 0x00180938
	public void AddOccludeObject(GameObject[] obj)
	{
		foreach (GameObject gameObject in obj)
		{
			if (!(null == gameObject))
			{
				List<Renderer> list = new List<Renderer>();
				list.AddRange(gameObject.GetComponentsInChildren<MeshRenderer>());
				list.AddRange(gameObject.GetComponentsInChildren<SkinnedMeshRenderer>());
				if (list.Count > 0)
				{
					this.RemoveOccludeObject(gameObject);
					GeSceneObjManager.GeOcclusionObjDesc geOcclusionObjDesc = new GeSceneObjManager.GeOcclusionObjDesc();
					geOcclusionObjDesc.m_RenderArray = new GeSceneObjManager.GeOcclusionMeshDesc[list.Count];
					geOcclusionObjDesc.m_Object = gameObject;
					geOcclusionObjDesc.m_AABBXMax = float.MinValue;
					geOcclusionObjDesc.m_AABBXMin = float.MaxValue;
					for (int j = 0; j < geOcclusionObjDesc.m_RenderArray.Length; j++)
					{
						GeSceneObjManager.GeOcclusionMeshDesc geOcclusionMeshDesc = new GeSceneObjManager.GeOcclusionMeshDesc();
						geOcclusionMeshDesc.m_MeshRender = list[j];
						geOcclusionMeshDesc.m_MatDescArray = new GeSceneObjManager.GeOcclusionMatDesc[list[j].materials.Length];
						for (int k = 0; k < list[j].materials.Length; k++)
						{
							GeSceneObjManager.GeOcclusionMatDesc geOcclusionMatDesc = new GeSceneObjManager.GeOcclusionMatDesc();
							geOcclusionMatDesc.m_OriginMaterial = list[j].materials[k];
							if (geOcclusionMatDesc.m_OriginMaterial.HasProperty(this.ALPHA_PARAM_NAME))
							{
								geOcclusionMatDesc.m_OriginAlpha = geOcclusionMatDesc.m_OriginMaterial.GetFloat(this.ALPHA_PARAM_NAME);
							}
							geOcclusionMatDesc.m_CurAlpha = geOcclusionMatDesc.m_OriginAlpha;
							geOcclusionMeshDesc.m_MatDescArray[k] = geOcclusionMatDesc;
						}
						geOcclusionObjDesc.m_AABBXMin = Mathf.Min(geOcclusionMeshDesc.m_MeshRender.bounds.min.x, geOcclusionObjDesc.m_AABBXMin);
						geOcclusionObjDesc.m_AABBXMax = Mathf.Max(geOcclusionMeshDesc.m_MeshRender.bounds.max.x, geOcclusionObjDesc.m_AABBXMax);
						geOcclusionObjDesc.m_RenderArray[j] = geOcclusionMeshDesc;
					}
					this.m_OcclusionDescList.Add(geOcclusionObjDesc);
				}
			}
		}
	}

	// Token: 0x06008804 RID: 34820 RVA: 0x00182724 File Offset: 0x00180B24
	public void RemoveOccludeObject(GameObject obj)
	{
		this.m_OcclusionDescList.RemoveAll(delegate(GeSceneObjManager.GeOcclusionObjDesc f)
		{
			if (null == f.m_Object)
			{
				return true;
			}
			if (obj == f.m_Object)
			{
				if (f.m_RenderArray != null)
				{
					for (int i = 0; i < f.m_RenderArray.Length; i++)
					{
						GeSceneObjManager.GeOcclusionMeshDesc geOcclusionMeshDesc = f.m_RenderArray[i];
						GeSceneObjManager.GeOcclusionMatDesc[] matDescArray = geOcclusionMeshDesc.m_MatDescArray;
						for (int j = 0; j < matDescArray.Length; j++)
						{
							if (matDescArray[j].m_OriginMaterial.HasProperty(this.ALPHA_PARAM_NAME))
							{
								matDescArray[j].m_OriginMaterial.SetFloat(this.ALPHA_PARAM_NAME, geOcclusionMeshDesc.m_MatDescArray[j].m_OriginAlpha);
							}
						}
						geOcclusionMeshDesc.m_MatDescArray = null;
						geOcclusionMeshDesc.m_MeshRender = null;
					}
				}
				return true;
			}
			return false;
		});
	}

	// Token: 0x06008805 RID: 34821 RVA: 0x0018275D File Offset: 0x00180B5D
	public void ClearAll()
	{
		this.m_OcclusionDescList.RemoveAll(delegate(GeSceneObjManager.GeOcclusionObjDesc f)
		{
			if (null == f.m_Object)
			{
				return true;
			}
			if (f.m_RenderArray != null)
			{
				for (int i = 0; i < f.m_RenderArray.Length; i++)
				{
					GeSceneObjManager.GeOcclusionMeshDesc geOcclusionMeshDesc = f.m_RenderArray[i];
					GeSceneObjManager.GeOcclusionMatDesc[] matDescArray = geOcclusionMeshDesc.m_MatDescArray;
					for (int j = 0; j < matDescArray.Length; j++)
					{
						if (matDescArray[j].m_OriginMaterial.HasProperty(this.ALPHA_PARAM_NAME))
						{
							matDescArray[j].m_OriginMaterial.SetFloat(this.ALPHA_PARAM_NAME, geOcclusionMeshDesc.m_MatDescArray[j].m_OriginAlpha);
						}
					}
					geOcclusionMeshDesc.m_MatDescArray = null;
					geOcclusionMeshDesc.m_MeshRender = null;
				}
			}
			return true;
		});
	}

	// Token: 0x06008806 RID: 34822 RVA: 0x00182778 File Offset: 0x00180B78
	public void Update()
	{
		if (null == this.m_FocusObj)
		{
			return;
		}
		Vector3 position = this.m_FocusObj.transform.position;
		if (null != this.m_Camera)
		{
			float num = this.m_Camera.transform.position.z - position.z;
			for (int i = 0; i < this.m_OcclusionDescList.Count; i++)
			{
				GeSceneObjManager.GeOcclusionObjDesc geOcclusionObjDesc = this.m_OcclusionDescList[i];
				if (geOcclusionObjDesc != null && !(null == geOcclusionObjDesc.m_Object))
				{
					float num2 = geOcclusionObjDesc.m_Object.transform.position.x - position.x;
					bool flag = geOcclusionObjDesc.m_AABBXMin < num2 && num2 < geOcclusionObjDesc.m_AABBXMax && this.m_Camera.transform.position.z - geOcclusionObjDesc.m_Object.transform.position.z > num;
					if (geOcclusionObjDesc.m_Fading)
					{
						bool flag2 = false;
						if (geOcclusionObjDesc.m_RenderArray != null)
						{
							for (int j = 0; j < geOcclusionObjDesc.m_RenderArray.Length; j++)
							{
								GeSceneObjManager.GeOcclusionMeshDesc geOcclusionMeshDesc = geOcclusionObjDesc.m_RenderArray[j];
								if (geOcclusionMeshDesc != null)
								{
									GeSceneObjManager.GeOcclusionMatDesc[] matDescArray = geOcclusionMeshDesc.m_MatDescArray;
									if (matDescArray != null)
									{
										for (int k = 0; k < matDescArray.Length; k++)
										{
											if (matDescArray[k] != null)
											{
												bool flag3 = true;
												matDescArray[k].m_CurAlpha += ((!geOcclusionObjDesc.m_Occluding) ? this.ALPHA_DELTA_SPEED : (-this.ALPHA_DELTA_SPEED));
												if (matDescArray[k].m_CurAlpha < matDescArray[k].m_OriginAlpha * this.ALPHA_MIN_VALUE)
												{
													matDescArray[k].m_CurAlpha = matDescArray[k].m_OriginAlpha * this.ALPHA_MIN_VALUE;
													flag3 = false;
												}
												if (matDescArray[k].m_CurAlpha > matDescArray[k].m_OriginAlpha)
												{
													matDescArray[k].m_CurAlpha = matDescArray[k].m_OriginAlpha;
													flag3 = false;
												}
												if (matDescArray[k].m_OriginMaterial.HasProperty(this.ALPHA_PARAM_NAME))
												{
													matDescArray[k].m_OriginMaterial.SetFloat(this.ALPHA_PARAM_NAME, matDescArray[k].m_CurAlpha);
												}
												flag2 = (flag2 || flag3);
											}
										}
									}
								}
							}
						}
						geOcclusionObjDesc.m_Fading = flag2;
					}
					else
					{
						geOcclusionObjDesc.m_Fading = (flag ^ geOcclusionObjDesc.m_Occluding);
					}
					geOcclusionObjDesc.m_Occluding = flag;
				}
			}
		}
	}

	// Token: 0x040041D1 RID: 16849
	protected readonly string ALPHA_PARAM_NAME = "_AlphaFactor";

	// Token: 0x040041D2 RID: 16850
	protected readonly float ALPHA_DELTA_SPEED = 0.05f;

	// Token: 0x040041D3 RID: 16851
	protected readonly float ALPHA_MIN_VALUE = 0.3f;

	// Token: 0x040041D4 RID: 16852
	protected List<GeSceneObjManager.GeOcclusionObjDesc> m_OcclusionDescList = new List<GeSceneObjManager.GeOcclusionObjDesc>();

	// Token: 0x040041D5 RID: 16853
	protected GameObject m_CameraNode;

	// Token: 0x040041D6 RID: 16854
	protected Camera m_Camera;

	// Token: 0x040041D7 RID: 16855
	protected GameObject m_FocusObj;

	// Token: 0x02000CFE RID: 3326
	protected class GeOcclusionMatDesc
	{
		// Token: 0x040041D8 RID: 16856
		public float m_OriginAlpha = 1f;

		// Token: 0x040041D9 RID: 16857
		public float m_CurAlpha = 1f;

		// Token: 0x040041DA RID: 16858
		public Material m_OriginMaterial;
	}

	// Token: 0x02000CFF RID: 3327
	protected class GeOcclusionMeshDesc
	{
		// Token: 0x040041DB RID: 16859
		public GeSceneObjManager.GeOcclusionMatDesc[] m_MatDescArray;

		// Token: 0x040041DC RID: 16860
		public Renderer m_MeshRender;
	}

	// Token: 0x02000D00 RID: 3328
	protected class GeOcclusionObjDesc
	{
		// Token: 0x040041DD RID: 16861
		public GeSceneObjManager.GeOcclusionMeshDesc[] m_RenderArray;

		// Token: 0x040041DE RID: 16862
		public float m_AABBXMax;

		// Token: 0x040041DF RID: 16863
		public float m_AABBXMin;

		// Token: 0x040041E0 RID: 16864
		public GameObject m_Object;

		// Token: 0x040041E1 RID: 16865
		public bool m_Fading;

		// Token: 0x040041E2 RID: 16866
		public bool m_Occluding;
	}
}
