using System;
using System.Collections.Generic;
using System.Text;
using GamePool;
using UnityEngine;

// Token: 0x02000CD8 RID: 3288
public class GeAttachManager
{
	// Token: 0x060086EF RID: 34543 RVA: 0x0017B27A File Offset: 0x0017967A
	public List<GeAttach> GetAttachList()
	{
		return this.m_AttachmentList;
	}

	// Token: 0x060086F0 RID: 34544 RVA: 0x0017B284 File Offset: 0x00179684
	public void AddAttachNode(string nodeName, GameObject nodeObj, bool rebind = false)
	{
		GeAttachManager.GeAttachNodeDesc attchNodeDesc = this.GetAttchNodeDesc(nodeName);
		if (GeAttachManager.sInvalidAttachNodeDesc.nodeName != attchNodeDesc.nodeName && GeAttachManager.sInvalidAttachNodeDesc.attachNode != attchNodeDesc.attachNode)
		{
			if (rebind)
			{
				attchNodeDesc.attachNode = nodeObj;
			}
			return;
		}
		this.m_AttachNodeDescList.Add(new GeAttachManager.GeAttachNodeDesc(nodeName, nodeObj));
	}

	// Token: 0x060086F1 RID: 34545 RVA: 0x0017B2F8 File Offset: 0x001796F8
	public GeAttachManager.GeAttachNodeDesc GetAttchNodeDesc(string nodeName)
	{
		for (int i = 0; i < this.m_AttachNodeDescList.Count; i++)
		{
			if (nodeName == this.m_AttachNodeDescList[i].nodeName)
			{
				return this.m_AttachNodeDescList[i];
			}
		}
		return GeAttachManager.sInvalidAttachNodeDesc;
	}

	// Token: 0x060086F2 RID: 34546 RVA: 0x0017B354 File Offset: 0x00179754
	public void RefreshAttachNode(GameObject skeletonRoot, bool bIsForce = false, bool needRebind = false)
	{
		if (this.airMode)
		{
			return;
		}
		if (skeletonRoot == null)
		{
			return;
		}
		if (this.m_RootNode != skeletonRoot)
		{
			this.m_RootNode = skeletonRoot;
			this.m_IsAttachNodeListDirty = true;
		}
		if (!bIsForce && !this.m_IsAttachNodeListDirty)
		{
			return;
		}
		this.m_AttachNodeDescList.Clear();
		string text = "None";
		this.m_AttachNodeDescList.Add(new GeAttachManager.GeAttachNodeDesc(text, null));
		StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
		GameObject gameObject = this._FindSkeletonObject(skeletonRoot);
		if (null == gameObject)
		{
			gameObject = skeletonRoot;
		}
		List<Transform> list = ListPool<Transform>.Get();
		gameObject.GetComponentsInChildren<Transform>(list);
		for (int i = 0; i < list.Count; i++)
		{
			Transform transform = list[i];
			if (transform.gameObject.CompareTag("Dummy"))
			{
				MyExtensionMethods.Clear(stringBuilder);
				stringBuilder.AppendFormat("[actor]{0}", transform.gameObject.name);
				text = stringBuilder.ToString();
				this.AddAttachNode(text, transform.gameObject, needRebind);
			}
		}
		for (int j = 0; j < this.m_AttachmentList.Count; j++)
		{
			GeAttach geAttach = this.m_AttachmentList[j];
			if (!geAttach.NeedDestroy)
			{
				GameObject root = geAttach.Root;
				if (!(null == root))
				{
					root.GetComponentsInChildren<Transform>(list);
					for (int k = 0; k < list.Count; k++)
					{
						Transform transform2 = list[k];
						if (transform2.gameObject.CompareTag("Dummy"))
						{
							MyExtensionMethods.Clear(stringBuilder);
							stringBuilder.AppendFormat("[{0}]{1}", geAttach.Name, transform2.gameObject.name);
							text = stringBuilder.ToString();
							this.AddAttachNode(text, transform2.gameObject, needRebind);
						}
					}
					if (needRebind && !geAttach.Rebind(this.GetAttchNodeDesc(geAttach.AttachNodeName).attachNode))
					{
						geAttach.Destroy();
					}
				}
			}
		}
		ListPool<Transform>.Release(list);
		StringBuilderCache.Release(stringBuilder);
		this.m_IsAttachNodeListDirty = false;
	}

	// Token: 0x060086F3 RID: 34547 RVA: 0x0017B584 File Offset: 0x00179984
	public GameObject GetAttchNodeDescWithRareName(string nodeRareName)
	{
		string value = "None";
		if (!nodeRareName.Equals(value))
		{
			return this.GetAttchNodeDesc("[actor]" + nodeRareName).attachNode;
		}
		return this.GetAttchNodeDesc(nodeRareName).attachNode;
	}

	// Token: 0x060086F4 RID: 34548 RVA: 0x0017B5CC File Offset: 0x001799CC
	public GeAttach GetAttachment(string name, string node = null)
	{
		GeAttach result = null;
		if (name == null)
		{
			return result;
		}
		for (int i = 0; i < this.m_AttachmentList.Count; i++)
		{
			if (name == this.m_AttachmentList[i].Name)
			{
				if (string.IsNullOrEmpty(node) || this.m_AttachmentList[i].AttachNodeName.Equals(node))
				{
					return this.m_AttachmentList[i];
				}
			}
		}
		return null;
	}

	// Token: 0x060086F5 RID: 34549 RVA: 0x0017B658 File Offset: 0x00179A58
	public GeAttach AddAttachment(string attachmentName, string attachRes, string attachNode, bool copyInPool = true, bool asyncLoad = true, bool highPriority = false)
	{
		if (this.airMode)
		{
			return null;
		}
		GeAttach geAttach = this.GetAttachment(attachmentName, attachNode);
		bool flag = false;
		if (geAttach == null)
		{
			geAttach = new GeAttach(attachmentName);
			flag = true;
		}
		geAttach.Create(attachRes, this.GetAttchNodeDesc(attachNode).attachNode, attachNode, copyInPool, asyncLoad, highPriority);
		if (flag)
		{
			this.m_AttachmentList.Add(geAttach);
		}
		this.m_IsAttachNodeListDirty = true;
		return geAttach;
	}

	// Token: 0x060086F6 RID: 34550 RVA: 0x0017B6C4 File Offset: 0x00179AC4
	public void SetAttachLayer(int layer)
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			GeAttach geAttach = this.m_AttachmentList[i];
			if (geAttach != null)
			{
				geAttach.SetLayer(layer);
			}
			i++;
		}
	}

	// Token: 0x060086F7 RID: 34551 RVA: 0x0017B70E File Offset: 0x00179B0E
	public void RemoveAttachment(GeAttach attachment)
	{
		if (attachment == null)
		{
			return;
		}
		this.m_IsAttachmentListDirty = true;
		attachment.Destroy();
	}

	// Token: 0x060086F8 RID: 34552 RVA: 0x0017B724 File Offset: 0x00179B24
	public void Update()
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			this.m_AttachmentList[i].UpdateAsync();
			i++;
		}
		if (this.m_IsAttachmentListDirty)
		{
			this._RemoveAttach();
			this.RefreshAttachNode(this.m_RootNode, false, false);
			this.m_IsAttachmentListDirty = false;
		}
	}

	// Token: 0x060086F9 RID: 34553 RVA: 0x0017B786 File Offset: 0x00179B86
	protected void _RemoveAttach()
	{
		this.m_AttachmentList.RemoveAll(delegate(GeAttach f)
		{
			if (f.NeedDestroy)
			{
				f.DestroyImm();
				return true;
			}
			return false;
		});
	}

	// Token: 0x060086FA RID: 34554 RVA: 0x0017B7B4 File Offset: 0x00179BB4
	public void ChangeAction(string name, float speed, bool loop = false)
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			if (this.m_AttachmentList[i] != null)
			{
				this.m_AttachmentList[i].PlayAction(name, speed, loop, 0f);
			}
			i++;
		}
	}

	// Token: 0x060086FB RID: 34555 RVA: 0x0017B810 File Offset: 0x00179C10
	public void StopAction()
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			if (this.m_AttachmentList[i] != null)
			{
				this.m_AttachmentList[i].StopAction();
			}
			i++;
		}
	}

	// Token: 0x060086FC RID: 34556 RVA: 0x0017B864 File Offset: 0x00179C64
	public void Pause()
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			if (this.m_AttachmentList[i] != null)
			{
				if (this.m_AttachmentList[i].AnimationManager != null)
				{
					this.m_AttachmentList[i].AnimationManager.Pause();
				}
			}
			i++;
		}
	}

	// Token: 0x060086FD RID: 34557 RVA: 0x0017B8D8 File Offset: 0x00179CD8
	public void Resume()
	{
		int i = 0;
		int count = this.m_AttachmentList.Count;
		while (i < count)
		{
			if (this.m_AttachmentList[i] != null)
			{
				if (this.m_AttachmentList[i].AnimationManager != null)
				{
					this.m_AttachmentList[i].AnimationManager.Resume();
				}
			}
			i++;
		}
	}

	// Token: 0x060086FE RID: 34558 RVA: 0x0017B94A File Offset: 0x00179D4A
	public void ClearAll()
	{
		this.m_AttachmentList.RemoveAll(delegate(GeAttach f)
		{
			f.DestroyImm();
			return true;
		});
		this.RefreshAttachNode(this.m_RootNode, false, false);
		this.m_IsAttachmentListDirty = false;
	}

	// Token: 0x060086FF RID: 34559 RVA: 0x0017B98C File Offset: 0x00179D8C
	public void ClearAttachmentOnNode(string attachNode)
	{
		bool bDirty = false;
		this.m_AttachmentList.RemoveAll(delegate(GeAttach f)
		{
			if (f.AttachNodeName == attachNode)
			{
				f.DestroyImm();
				bDirty = true;
				return true;
			}
			return false;
		});
		if (bDirty)
		{
			this.RefreshAttachNode(this.m_RootNode, false, false);
		}
	}

	// Token: 0x06008700 RID: 34560 RVA: 0x0017B9DE File Offset: 0x00179DDE
	public void Deinit()
	{
		this.ClearAll();
	}

	// Token: 0x06008701 RID: 34561 RVA: 0x0017B9E8 File Offset: 0x00179DE8
	private GameObject _FindSkeletonObject(GameObject parent)
	{
		if (null != parent && parent.name.Contains("boneall", StringComparison.OrdinalIgnoreCase))
		{
			return parent;
		}
		int childCount = parent.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			GameObject gameObject = parent.transform.GetChild(i).gameObject;
			GameObject gameObject2 = this._FindSkeletonObject(gameObject);
			if (null != gameObject2)
			{
				return gameObject2;
			}
		}
		return null;
	}

	// Token: 0x040040CD RID: 16589
	public static readonly GeAttachManager.GeAttachNodeDesc sInvalidAttachNodeDesc = new GeAttachManager.GeAttachNodeDesc(string.Empty, null);

	// Token: 0x040040CE RID: 16590
	protected List<GeAttachManager.GeAttachNodeDesc> m_AttachNodeDescList = new List<GeAttachManager.GeAttachNodeDesc>();

	// Token: 0x040040CF RID: 16591
	protected List<GeAttach> m_AttachmentList = new List<GeAttach>();

	// Token: 0x040040D0 RID: 16592
	protected bool m_IsAttachNodeListDirty = true;

	// Token: 0x040040D1 RID: 16593
	protected bool m_IsAttachmentListDirty;

	// Token: 0x040040D2 RID: 16594
	protected GameObject m_RootNode;

	// Token: 0x040040D3 RID: 16595
	public bool airMode;

	// Token: 0x02000CD9 RID: 3289
	public struct GeAttachNodeDesc
	{
		// Token: 0x06008705 RID: 34565 RVA: 0x0017BA93 File Offset: 0x00179E93
		public GeAttachNodeDesc(string name, GameObject attNode)
		{
			this.nodeName = name;
			this.attachNode = attNode;
		}

		// Token: 0x040040D6 RID: 16598
		public string nodeName;

		// Token: 0x040040D7 RID: 16599
		public GameObject attachNode;
	}
}
