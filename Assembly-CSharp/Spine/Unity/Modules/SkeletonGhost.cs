using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A0C RID: 18956
	[RequireComponent(typeof(SkeletonRenderer))]
	public class SkeletonGhost : MonoBehaviour
	{
		// Token: 0x0601B5D6 RID: 112086 RVA: 0x0086ED40 File Offset: 0x0086D140
		private void Start()
		{
			if (this.ghostShader == null)
			{
				this.ghostShader = Shader.Find("Spine/Special/SkeletonGhost");
			}
			this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			this.meshFilter = base.GetComponent<MeshFilter>();
			this.meshRenderer = base.GetComponent<MeshRenderer>();
			this.nextSpawnTime = Time.time + this.spawnRate;
			this.pool = new SkeletonGhostRenderer[this.maximumGhosts];
			for (int i = 0; i < this.maximumGhosts; i++)
			{
				GameObject gameObject = new GameObject(base.gameObject.name + " Ghost", new Type[]
				{
					typeof(SkeletonGhostRenderer)
				});
				this.pool[i] = gameObject.GetComponent<SkeletonGhostRenderer>();
				gameObject.SetActive(false);
				gameObject.hideFlags = 1;
			}
			IAnimationStateComponent animationStateComponent = this.skeletonRenderer as IAnimationStateComponent;
			if (animationStateComponent != null)
			{
				animationStateComponent.AnimationState.Event += this.OnEvent;
			}
		}

		// Token: 0x0601B5D7 RID: 112087 RVA: 0x0086EE40 File Offset: 0x0086D240
		private void OnEvent(TrackEntry trackEntry, Event e)
		{
			if (e.Data.Name.Equals("Ghosting", StringComparison.Ordinal))
			{
				this.ghostingEnabled = (e.Int > 0);
				if (e.Float > 0f)
				{
					this.spawnRate = e.Float;
				}
				if (!string.IsNullOrEmpty(e.stringValue))
				{
					this.color = SkeletonGhost.HexToColor(e.String);
				}
			}
		}

		// Token: 0x0601B5D8 RID: 112088 RVA: 0x0086EEB4 File Offset: 0x0086D2B4
		private void Ghosting(float val)
		{
			this.ghostingEnabled = (val > 0f);
		}

		// Token: 0x0601B5D9 RID: 112089 RVA: 0x0086EEC4 File Offset: 0x0086D2C4
		private void Update()
		{
			if (!this.ghostingEnabled)
			{
				return;
			}
			if (Time.time >= this.nextSpawnTime)
			{
				GameObject gameObject = this.pool[this.poolIndex].gameObject;
				Material[] sharedMaterials = this.meshRenderer.sharedMaterials;
				for (int i = 0; i < sharedMaterials.Length; i++)
				{
					Material material = sharedMaterials[i];
					Material material2;
					if (!this.materialTable.ContainsKey(material))
					{
						material2 = new Material(material);
						material2.shader = this.ghostShader;
						material2.color = Color.white;
						if (material2.HasProperty("_TextureFade"))
						{
							material2.SetFloat("_TextureFade", this.textureFade);
						}
						this.materialTable.Add(material, material2);
					}
					else
					{
						material2 = this.materialTable[material];
					}
					sharedMaterials[i] = material2;
				}
				Transform transform = gameObject.transform;
				transform.parent = base.transform;
				this.pool[this.poolIndex].Initialize(this.meshFilter.sharedMesh, sharedMaterials, this.color, this.additive, this.fadeSpeed, this.meshRenderer.sortingLayerID, (!this.sortWithDistanceOnly) ? (this.meshRenderer.sortingOrder - 1) : this.meshRenderer.sortingOrder);
				transform.localPosition = new Vector3(0f, 0f, this.zOffset);
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				transform.parent = null;
				this.poolIndex++;
				if (this.poolIndex == this.pool.Length)
				{
					this.poolIndex = 0;
				}
				this.nextSpawnTime = Time.time + this.spawnRate;
			}
		}

		// Token: 0x0601B5DA RID: 112090 RVA: 0x0086F090 File Offset: 0x0086D490
		private void OnDestroy()
		{
			if (this.pool != null)
			{
				for (int i = 0; i < this.maximumGhosts; i++)
				{
					if (this.pool[i] != null)
					{
						this.pool[i].Cleanup();
					}
				}
			}
			foreach (Material material in this.materialTable.Values)
			{
				Object.Destroy(material);
			}
		}

		// Token: 0x0601B5DB RID: 112091 RVA: 0x0086F134 File Offset: 0x0086D534
		private static Color32 HexToColor(string hex)
		{
			if (hex.Length < 6)
			{
				return Color.magenta;
			}
			hex = hex.Replace("#", string.Empty);
			byte b = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte b2 = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b3 = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			byte b4 = byte.MaxValue;
			if (hex.Length == 8)
			{
				b4 = byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber);
			}
			return new Color32(b, b2, b3, b4);
		}

		// Token: 0x040130C9 RID: 78025
		private const HideFlags GhostHideFlags = 1;

		// Token: 0x040130CA RID: 78026
		private const string GhostingShaderName = "Spine/Special/SkeletonGhost";

		// Token: 0x040130CB RID: 78027
		public bool ghostingEnabled = true;

		// Token: 0x040130CC RID: 78028
		public float spawnRate = 0.05f;

		// Token: 0x040130CD RID: 78029
		public Color32 color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);

		// Token: 0x040130CE RID: 78030
		[Tooltip("Remember to set color alpha to 0 if Additive is true")]
		public bool additive = true;

		// Token: 0x040130CF RID: 78031
		public int maximumGhosts = 10;

		// Token: 0x040130D0 RID: 78032
		public float fadeSpeed = 10f;

		// Token: 0x040130D1 RID: 78033
		public Shader ghostShader;

		// Token: 0x040130D2 RID: 78034
		[Tooltip("0 is Color and Alpha, 1 is Alpha only.")]
		[Range(0f, 1f)]
		public float textureFade = 1f;

		// Token: 0x040130D3 RID: 78035
		[Header("Sorting")]
		public bool sortWithDistanceOnly;

		// Token: 0x040130D4 RID: 78036
		public float zOffset;

		// Token: 0x040130D5 RID: 78037
		private float nextSpawnTime;

		// Token: 0x040130D6 RID: 78038
		private SkeletonGhostRenderer[] pool;

		// Token: 0x040130D7 RID: 78039
		private int poolIndex;

		// Token: 0x040130D8 RID: 78040
		private SkeletonRenderer skeletonRenderer;

		// Token: 0x040130D9 RID: 78041
		private MeshRenderer meshRenderer;

		// Token: 0x040130DA RID: 78042
		private MeshFilter meshFilter;

		// Token: 0x040130DB RID: 78043
		private readonly Dictionary<Material, Material> materialTable = new Dictionary<Material, Material>();
	}
}
