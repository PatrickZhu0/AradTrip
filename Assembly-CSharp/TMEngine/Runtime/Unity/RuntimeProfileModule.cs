using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x0200473B RID: 18235
	[DisallowMultipleComponent]
	public class RuntimeProfileModule : TMModuleComponent
	{
		// Token: 0x0601A31D RID: 107293 RVA: 0x0082306A File Offset: 0x0082146A
		protected override void Awake()
		{
			base.Awake();
			this.InitParams();
		}

		// Token: 0x0601A31E RID: 107294 RVA: 0x00823078 File Offset: 0x00821478
		private void InitParams()
		{
			if (this.AllSceneTex == null)
			{
				this.AllSceneTex = new List<Texture>();
				this.AllMaterials = new List<Material>();
			}
		}

		// Token: 0x17002251 RID: 8785
		// (get) Token: 0x0601A31F RID: 107295 RVA: 0x0082309B File Offset: 0x0082149B
		public bool IsObjRootNull
		{
			get
			{
				return this.ObjRoot == null;
			}
		}

		// Token: 0x0601A320 RID: 107296 RVA: 0x008230A9 File Offset: 0x008214A9
		public void CaptureSceneMemoryOnce()
		{
			this.InitParams();
			if (this.IsObjRootNull)
			{
				this.InitObjRoot();
				if (object.ReferenceEquals(this.ObjRoot, null))
				{
					return;
				}
			}
			this.CollectAllTexture(this.ObjRoot as GameObject);
		}

		// Token: 0x0601A321 RID: 107297 RVA: 0x008230E5 File Offset: 0x008214E5
		private void InitObjRoot()
		{
			this.ObjRoot = GameObject.Find("LogicRoot/SceneRoot");
		}

		// Token: 0x0601A322 RID: 107298 RVA: 0x008230F8 File Offset: 0x008214F8
		private void CollectAllTexture(GameObject go)
		{
			this.AllSceneTex.Clear();
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				Material[] sharedMaterials = renderer.sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (!object.ReferenceEquals(material, null))
					{
						this.AllMaterials.Add(material);
					}
				}
				if (renderer is SpriteRenderer)
				{
					SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
					if (!object.ReferenceEquals(spriteRenderer.sprite, null))
					{
						Texture2D texture = spriteRenderer.sprite.texture;
						if (!this.AllSceneTex.Contains(texture))
						{
							this.AllSceneTex.Add(texture);
						}
					}
				}
			}
		}

		// Token: 0x04012667 RID: 75367
		public Object ObjRoot;

		// Token: 0x04012668 RID: 75368
		public List<Texture> AllSceneTex;

		// Token: 0x04012669 RID: 75369
		[HideInInspector]
		public List<Material> AllMaterials;
	}
}
