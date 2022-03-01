using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000D81 RID: 3457
public class MaskEx : Mask
{
	// Token: 0x06008C20 RID: 35872 RVA: 0x0019EF44 File Offset: 0x0019D344
	protected override void Start()
	{
		base.Start();
		RectTransform rectTransform = base.transform as RectTransform;
		this.m_MinX = rectTransform.rect.x + base.transform.position.x;
		this.m_MinY = rectTransform.rect.y + base.transform.position.y;
		this.m_MaxX = this.m_MinX + rectTransform.rect.width * rectTransform.lossyScale.x;
		this.m_MaxY = this.m_MinY + rectTransform.rect.height * rectTransform.lossyScale.y;
		this.Init();
	}

	// Token: 0x06008C21 RID: 35873 RVA: 0x0019F014 File Offset: 0x0019D414
	public void Init()
	{
		ParticleSystem[] componentsInChildren = base.transform.parent.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Renderer component = componentsInChildren[i].GetComponent<Renderer>();
			component.sharedMaterial.SetFloat("_MinX", this.m_MinX);
			component.sharedMaterial.SetFloat("_MinY", this.m_MinY);
			component.sharedMaterial.SetFloat("_MaxX", this.m_MaxX);
			component.sharedMaterial.SetFloat("_MaxY", this.m_MaxY);
		}
		MeshRenderer[] componentsInChildren2 = base.transform.parent.GetComponentsInChildren<MeshRenderer>();
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			Material[] materials = componentsInChildren2[j].materials;
			for (int k = 0; k < materials.Length; k++)
			{
				materials[k].SetFloat("_MinX", this.m_MinX);
				materials[k].SetFloat("_MinY", this.m_MinY);
				materials[k].SetFloat("_MaxX", this.m_MaxX);
				materials[k].SetFloat("_MaxY", this.m_MaxY);
			}
		}
	}

	// Token: 0x0400455C RID: 17756
	protected float m_MinX = -10f;

	// Token: 0x0400455D RID: 17757
	protected float m_MinY = -10f;

	// Token: 0x0400455E RID: 17758
	protected float m_MaxX = 10f;

	// Token: 0x0400455F RID: 17759
	protected float m_MaxY = 10f;
}
