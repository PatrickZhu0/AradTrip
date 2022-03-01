using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000245 RID: 581
[ExecuteInEditMode]
public class SetRenderQueue : MonoBehaviour
{
	// Token: 0x0600131E RID: 4894 RVA: 0x000667EC File Offset: 0x00064BEC
	private void Start()
	{
		this.mRd = base.GetComponentsInChildren<Renderer>();
		if (this.mRd != null && this.mRd.Length > 0)
		{
			int i = 0;
			int num = this.mRd.Length;
			while (i < num)
			{
				Renderer renderer = this.mRd[i];
				if (!(null == renderer))
				{
					if (renderer.sharedMaterials != null)
					{
						int j = 0;
						int num2 = renderer.sharedMaterials.Length;
						while (j < num2)
						{
							Material material = renderer.sharedMaterials[j];
							if (!(null == material))
							{
								this.mMatLst.Add(material);
							}
							j++;
						}
					}
				}
				i++;
			}
		}
	}

	// Token: 0x0600131F RID: 4895 RVA: 0x000668AC File Offset: 0x00064CAC
	private void Update()
	{
		if (this.mRd != null && this.mRd.Length > 0)
		{
			int i = 0;
			int count = this.mMatLst.Count;
			while (i < count)
			{
				Material material = this.mMatLst[i];
				if (!(null == material))
				{
					if (null != material.shader)
					{
						material.renderQueue = material.shader.renderQueue + this.mRendererQueue;
					}
				}
				i++;
			}
		}
	}

	// Token: 0x04000CD5 RID: 3285
	public int mRendererQueue;

	// Token: 0x04000CD6 RID: 3286
	private Renderer[] mRd;

	// Token: 0x04000CD7 RID: 3287
	private List<Material> mMatLst = new List<Material>();
}
