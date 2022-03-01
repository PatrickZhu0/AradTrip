using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D04 RID: 3332
public class GeSuitPartManager
{
	// Token: 0x0600881F RID: 34847 RVA: 0x001833DC File Offset: 0x001817DC
	public bool Init(DModelData modelData, GameObject actorNode, GameObject avatarObject)
	{
		if (null != actorNode)
		{
			this.m_AvatarObject = avatarObject;
			Utility.AttachTo(this.m_AvatarObject, actorNode, false);
			for (int i = 0; i < 6; i++)
			{
				this.m_SuitPartDescList.Add(new GeSuitPartManager.GeSuitPartDesc(new DAssetObject(null, string.Empty), (EModelPartChannel)i));
				this.m_SuitPartList.Add(new GeSuitPartManager.SuitPartModelDesc());
			}
			int num = 0;
			int num2 = modelData.partsChunk.Length;
			for (int j = 0; j < num2; j++)
			{
				int partChannel = (int)modelData.partsChunk[j].partChannel;
				if (partChannel < this.m_SuitPartDescList.Count)
				{
					this.m_SuitPartDescList[partChannel].m_SuitPartAsset = modelData.partsChunk[j].partAsset;
					this.m_SuitPartList[partChannel].m_MeshObject = Singleton<CGameObjectPool>.instance.GetGameObject(modelData.partsChunk[j].partAsset.m_AssetPath, enResourceType.BattleScene, 0U);
					this.m_NeedRebakeMesh = true;
					if (null != this.m_SuitPartList[partChannel].m_MeshObject)
					{
						this.m_RenderMeshList.Add(this.m_SuitPartList[partChannel].m_MeshObject);
						this.m_SuitPartList[partChannel].m_MeshObject.transform.SetParent(this.m_AvatarObject.transform, false);
					}
					num++;
				}
			}
		}
		else
		{
			Logger.LogError("actor node can not be null!");
		}
		return false;
	}

	// Token: 0x06008820 RID: 34848 RVA: 0x00183560 File Offset: 0x00181960
	public void Deinit()
	{
		for (int i = 0; i < this.m_SuitPartList.Count; i++)
		{
			GeSuitPartManager.SuitPartModelDesc suitPartModelDesc = this.m_SuitPartList[i];
			if (suitPartModelDesc != null && null != suitPartModelDesc.m_MeshObject)
			{
				SkinnedMeshRenderer[] meshRendererList = suitPartModelDesc.m_MeshRendererList;
				if (meshRendererList != null)
				{
					for (int j = 0; j < meshRendererList.Length; j++)
					{
						if (null != meshRendererList[j])
						{
							meshRendererList[j].gameObject.SetActive(true);
						}
					}
				}
				GameObject[] boneAll = suitPartModelDesc.m_BoneAll;
				if (boneAll != null)
				{
					for (int k = 0; k < boneAll.Length; k++)
					{
						if (null != boneAll[k])
						{
							boneAll[k].SetActive(true);
						}
					}
				}
				suitPartModelDesc.m_MeshObject.transform.SetParent(null, false);
				Singleton<CGameObjectPool>.instance.RecycleGameObject(suitPartModelDesc.m_MeshObject);
				suitPartModelDesc.m_MeshObject = null;
				suitPartModelDesc.m_MeshRendererList = null;
				suitPartModelDesc.m_BoneAll = null;
			}
		}
		if (null != this.m_AvatarObject)
		{
			Object.Destroy(this.m_AvatarObject);
			this.m_AvatarObject = null;
		}
	}

	// Token: 0x06008821 RID: 34849 RVA: 0x00183688 File Offset: 0x00181A88
	public bool ChangeSuitParts(EModelPartChannel suitPartChannel, DAssetObject assertObj)
	{
		if (suitPartChannel < (EModelPartChannel)this.m_SuitPartDescList.Count)
		{
			if ((1 << (int)suitPartChannel & this.m_BakedMask) != 0)
			{
				if (this.m_AvatarObject)
				{
					Object.Destroy(this.m_AvatarObject);
				}
				this.m_RenderMeshList.Clear();
			}
			GeSuitPartManager.GeSuitPartDesc geSuitPartDesc = this.m_SuitPartDescList[(int)suitPartChannel];
			geSuitPartDesc.m_SuitPartAsset = assertObj;
			GeSuitPartManager.SuitPartModelDesc suitPartModelDesc = this.m_SuitPartList[(int)suitPartChannel];
			if (suitPartModelDesc != null)
			{
				SkinnedMeshRenderer[] meshRendererList = suitPartModelDesc.m_MeshRendererList;
				if (meshRendererList != null)
				{
					for (int i = 0; i < meshRendererList.Length; i++)
					{
						if (null != meshRendererList[i])
						{
							meshRendererList[i].gameObject.SetActive(true);
						}
					}
				}
				GameObject[] boneAll = suitPartModelDesc.m_BoneAll;
				if (boneAll != null)
				{
					for (int j = 0; j < boneAll.Length; j++)
					{
						if (null != boneAll[j])
						{
							boneAll[j].SetActive(true);
						}
					}
				}
				Singleton<CGameObjectPool>.instance.RecycleGameObject(suitPartModelDesc.m_MeshObject);
				suitPartModelDesc.m_MeshObject = Singleton<CGameObjectPool>.instance.GetGameObject(geSuitPartDesc.m_SuitPartAsset.m_AssetPath, enResourceType.BattleScene, 0U);
				suitPartModelDesc.m_MeshRendererList = null;
				suitPartModelDesc.m_BoneAll = null;
				this.m_RenderMeshList.Add(suitPartModelDesc.m_MeshObject);
			}
			this.m_NeedRebakeMesh = true;
			return true;
		}
		return false;
	}

	// Token: 0x06008822 RID: 34850 RVA: 0x001837E4 File Offset: 0x00181BE4
	public void Bake()
	{
		List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
		for (int i = 0; i < this.m_SuitPartList.Count; i++)
		{
			GeSuitPartManager.SuitPartModelDesc suitPartModelDesc = this.m_SuitPartList[i];
			if (suitPartModelDesc != null && null != suitPartModelDesc.m_MeshObject)
			{
				SkinnedMeshRenderer[] componentsInChildren = suitPartModelDesc.m_MeshObject.GetComponentsInChildren<SkinnedMeshRenderer>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					list.Add(componentsInChildren[j]);
				}
				suitPartModelDesc.m_MeshRendererList = componentsInChildren;
				Animation[] componentsInChildren2 = suitPartModelDesc.m_MeshObject.GetComponentsInChildren<Animation>();
				for (int k = 0; k < componentsInChildren2.Length; k++)
				{
					Object.Destroy(componentsInChildren2[k]);
				}
				List<GameObject> list2 = new List<GameObject>();
				int childCount = suitPartModelDesc.m_MeshObject.transform.childCount;
				for (int l = 0; l < childCount; l++)
				{
					GameObject gameObject = suitPartModelDesc.m_MeshObject.transform.GetChild(l).gameObject;
					if (null != gameObject && gameObject.name.Contains("BoneAll"))
					{
						list2.Add(gameObject);
						gameObject.SetActive(false);
					}
				}
				suitPartModelDesc.m_BoneAll = list2.ToArray();
			}
		}
		SkinnedMeshRenderer[] array = list.ToArray();
		List<Transform> list3 = new List<Transform>();
		this.m_AvatarObject.transform.rotation = Quaternion.identity;
		Transform[] componentsInChildren3 = this.m_AvatarObject.transform.GetChild(0).GetComponentsInChildren<Transform>();
		List<BoneWeight> list4 = new List<BoneWeight>();
		List<CombineInstance> list5 = new List<CombineInstance>();
		List<Texture2D> list6 = new List<Texture2D>();
		List<Texture2D> list7 = new List<Texture2D>();
		int num = 0;
		for (int m = 0; m < array.Length; m++)
		{
			num += array[m].sharedMesh.subMeshCount;
		}
		int[] array2 = new int[num];
		int num2 = 0;
		Material material = null;
		int num3 = 0;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
		{
			if (null == material)
			{
				material = new Material(skinnedMeshRenderer.material);
			}
			if (skinnedMeshRenderer.material.mainTexture != null)
			{
				Material[] materials = skinnedMeshRenderer.materials;
				for (int num4 = 0; num4 < materials.Length; num4++)
				{
					if (materials[num4].HasProperty("_MainTex"))
					{
						list6.Add(materials[num4].GetTexture("_MainTex") as Texture2D);
					}
					if (materials[num4].HasProperty("_BumpMap"))
					{
						list7.Add(materials[num4].GetTexture("_BumpMap") as Texture2D);
					}
				}
			}
			for (int num5 = 0; num5 < skinnedMeshRenderer.sharedMesh.subMeshCount; num5++)
			{
				foreach (BoneWeight item in skinnedMeshRenderer.sharedMesh.boneWeights)
				{
					item.boneIndex0 += num2;
					item.boneIndex1 += num2;
					item.boneIndex2 += num2;
					item.boneIndex3 += num2;
					list4.Add(item);
				}
				num2 += skinnedMeshRenderer.bones.Length;
				Transform[] bones = skinnedMeshRenderer.bones;
				for (int num7 = 0; num7 < bones.Length; num7++)
				{
					Transform item2 = this._FindSkeletonBone(componentsInChildren3, bones[num7]);
					list3.Add(item2);
				}
				CombineInstance item3 = default(CombineInstance);
				item3.mesh = skinnedMeshRenderer.sharedMesh;
				item3.subMeshIndex = num5;
				item3.transform = skinnedMeshRenderer.transform.localToWorldMatrix;
				list5.Add(item3);
				array2[num3++] = skinnedMeshRenderer.sharedMesh.vertexCount;
			}
			skinnedMeshRenderer.gameObject.SetActive(false);
		}
		List<Matrix4x4> list8 = new List<Matrix4x4>();
		for (int num8 = 0; num8 < list3.Count; num8++)
		{
			list8.Add(list3[num8].worldToLocalMatrix * this.m_AvatarObject.transform.worldToLocalMatrix);
		}
		SkinnedMeshRenderer skinnedMeshRenderer2 = this.m_AvatarObject.AddComponent<SkinnedMeshRenderer>();
		skinnedMeshRenderer2.sharedMesh = new Mesh();
		skinnedMeshRenderer2.sharedMesh.CombineMeshes(list5.ToArray(), true, true);
		Texture2D texture2D = new Texture2D(512, 512);
		Rect[] array3 = texture2D.PackTextures(list6.ToArray(), 0, 512);
		Texture2D texture2D2 = new Texture2D(512, 512, 5, false);
		Rect[] array4 = texture2D2.PackTextures(list7.ToArray(), 0, 512);
		Vector2[] uv = skinnedMeshRenderer2.sharedMesh.uv;
		Vector2[] array5 = new Vector2[uv.Length];
		int num9 = 0;
		int num10 = 0;
		for (int num11 = 0; num11 < array5.Length; num11++)
		{
			if (num9 < array3.Length)
			{
				if (num9 < array2.Length)
				{
					array5[num11].x = Mathf.Lerp(array3[num9].xMin, array3[num9].xMax, uv[num11].x);
					array5[num11].y = Mathf.Lerp(array3[num9].yMin, array3[num9].yMax, uv[num11].y);
					if (num11 >= array2[num9] + num10)
					{
						num10 += array2[num9];
						num9++;
					}
				}
			}
		}
		if (null != material)
		{
			if (material.HasProperty("_MainTex"))
			{
				material.SetTexture("_MainTex", texture2D);
			}
			if (material.HasProperty("_BumpMap"))
			{
				material.SetTexture("_BumpMap", texture2D2);
			}
		}
		skinnedMeshRenderer2.sharedMesh.uv = array5;
		skinnedMeshRenderer2.sharedMaterial = material;
		skinnedMeshRenderer2.rootBone = this.m_AvatarObject.transform;
		skinnedMeshRenderer2.bones = list3.ToArray();
		skinnedMeshRenderer2.sharedMesh.boneWeights = list4.ToArray();
		skinnedMeshRenderer2.sharedMesh.bindposes = list8.ToArray();
		skinnedMeshRenderer2.sharedMesh.RecalculateBounds();
		this.m_RenderMeshList.Clear();
		this.m_RenderMeshList.Add(this.m_AvatarObject);
		this.m_NeedRebakeMesh = false;
	}

	// Token: 0x06008823 RID: 34851 RVA: 0x00183E6C File Offset: 0x0018226C
	private Transform _FindSkeletonBone(Transform[] skeleton, Transform bone)
	{
		for (int i = 0; i < skeleton.Length; i++)
		{
			if (skeleton[i].name == bone.name)
			{
				return skeleton[i];
			}
		}
		return null;
	}

	// Token: 0x17001829 RID: 6185
	// (get) Token: 0x06008824 RID: 34852 RVA: 0x00183EAA File Offset: 0x001822AA
	public GameObject avatarObject
	{
		get
		{
			return this.m_AvatarObject;
		}
	}

	// Token: 0x1700182A RID: 6186
	// (get) Token: 0x06008825 RID: 34853 RVA: 0x00183EB2 File Offset: 0x001822B2
	public GameObject[] suitPartModel
	{
		get
		{
			return this.m_RenderMeshList.ToArray();
		}
	}

	// Token: 0x040041F4 RID: 16884
	protected List<GeSuitPartManager.SuitPartModelDesc> m_SuitPartList = new List<GeSuitPartManager.SuitPartModelDesc>();

	// Token: 0x040041F5 RID: 16885
	protected List<GeSuitPartManager.GeSuitPartDesc> m_SuitPartDescList = new List<GeSuitPartManager.GeSuitPartDesc>();

	// Token: 0x040041F6 RID: 16886
	protected bool m_NeedRebakeMesh = true;

	// Token: 0x040041F7 RID: 16887
	protected GameObject m_AvatarObject;

	// Token: 0x040041F8 RID: 16888
	protected int m_BakedMask;

	// Token: 0x040041F9 RID: 16889
	protected List<GameObject> m_RenderMeshList = new List<GameObject>();

	// Token: 0x02000D05 RID: 3333
	public class GeSuitPartDesc
	{
		// Token: 0x06008826 RID: 34854 RVA: 0x00183EBF File Offset: 0x001822BF
		public GeSuitPartDesc(DAssetObject a, EModelPartChannel c)
		{
			this.m_SuitPartAsset = a;
			this.m_SuitPartChannel = c;
		}

		// Token: 0x040041FA RID: 16890
		public DAssetObject m_SuitPartAsset;

		// Token: 0x040041FB RID: 16891
		public EModelPartChannel m_SuitPartChannel;
	}

	// Token: 0x02000D06 RID: 3334
	protected class SuitPartModelDesc
	{
		// Token: 0x040041FC RID: 16892
		public SkinnedMeshRenderer[] m_MeshRendererList;

		// Token: 0x040041FD RID: 16893
		public Animation[] m_Animation;

		// Token: 0x040041FE RID: 16894
		public GameObject[] m_BoneAll;

		// Token: 0x040041FF RID: 16895
		public GameObject m_MeshObject;
	}
}
