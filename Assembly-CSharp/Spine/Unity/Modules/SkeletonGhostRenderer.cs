using System;
using System.Collections;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A0D RID: 18957
	public class SkeletonGhostRenderer : MonoBehaviour
	{
		// Token: 0x0601B5DD RID: 112093 RVA: 0x0086F1F3 File Offset: 0x0086D5F3
		private void Awake()
		{
			this.meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			this.meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}

		// Token: 0x0601B5DE RID: 112094 RVA: 0x0086F218 File Offset: 0x0086D618
		public void Initialize(Mesh mesh, Material[] materials, Color32 color, bool additive, float speed, int sortingLayerID, int sortingOrder)
		{
			base.StopAllCoroutines();
			base.gameObject.SetActive(true);
			this.meshRenderer.sharedMaterials = materials;
			this.meshRenderer.sortingLayerID = sortingLayerID;
			this.meshRenderer.sortingOrder = sortingOrder;
			this.meshFilter.sharedMesh = Object.Instantiate<Mesh>(mesh);
			this.colors = this.meshFilter.sharedMesh.colors32;
			if (color.a + color.r + color.g + color.b > 0)
			{
				for (int i = 0; i < this.colors.Length; i++)
				{
					this.colors[i] = color;
				}
			}
			this.fadeSpeed = speed;
			if (additive)
			{
				base.StartCoroutine(this.FadeAdditive());
			}
			else
			{
				base.StartCoroutine(this.Fade());
			}
		}

		// Token: 0x0601B5DF RID: 112095 RVA: 0x0086F302 File Offset: 0x0086D702
		private void CopyMesh(Mesh source, Mesh destination)
		{
		}

		// Token: 0x0601B5E0 RID: 112096 RVA: 0x0086F304 File Offset: 0x0086D704
		private IEnumerator Fade()
		{
			for (int t = 0; t < 500; t++)
			{
				bool breakout = true;
				for (int i = 0; i < this.colors.Length; i++)
				{
					Color32 c = this.colors[i];
					if (c.a > 0)
					{
						breakout = false;
					}
					this.colors[i] = Color32.Lerp(c, this.black, Time.deltaTime * this.fadeSpeed);
				}
				this.meshFilter.sharedMesh.colors32 = this.colors;
				if (breakout)
				{
					break;
				}
				yield return null;
			}
			Object.Destroy(this.meshFilter.sharedMesh);
			base.gameObject.SetActive(false);
			yield break;
		}

		// Token: 0x0601B5E1 RID: 112097 RVA: 0x0086F320 File Offset: 0x0086D720
		private IEnumerator FadeAdditive()
		{
			Color32 black = this.black;
			for (int t = 0; t < 500; t++)
			{
				bool breakout = true;
				for (int i = 0; i < this.colors.Length; i++)
				{
					Color32 c = this.colors[i];
					black.a = c.a;
					if (c.r > 0 || c.g > 0 || c.b > 0)
					{
						breakout = false;
					}
					this.colors[i] = Color32.Lerp(c, black, Time.deltaTime * this.fadeSpeed);
				}
				this.meshFilter.sharedMesh.colors32 = this.colors;
				if (breakout)
				{
					break;
				}
				yield return null;
			}
			Object.Destroy(this.meshFilter.sharedMesh);
			base.gameObject.SetActive(false);
			yield break;
		}

		// Token: 0x0601B5E2 RID: 112098 RVA: 0x0086F33C File Offset: 0x0086D73C
		public void Cleanup()
		{
			if (this.meshFilter != null && this.meshFilter.sharedMesh != null)
			{
				Object.Destroy(this.meshFilter.sharedMesh);
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x040130DC RID: 78044
		public float fadeSpeed = 10f;

		// Token: 0x040130DD RID: 78045
		private Color32[] colors;

		// Token: 0x040130DE RID: 78046
		private Color32 black = new Color32(0, 0, 0, 0);

		// Token: 0x040130DF RID: 78047
		private MeshFilter meshFilter;

		// Token: 0x040130E0 RID: 78048
		private MeshRenderer meshRenderer;
	}
}
