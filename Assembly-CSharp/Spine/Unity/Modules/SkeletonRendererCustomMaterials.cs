using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A09 RID: 18953
	[ExecuteInEditMode]
	public class SkeletonRendererCustomMaterials : MonoBehaviour
	{
		// Token: 0x0601B5CD RID: 112077 RVA: 0x0086E934 File Offset: 0x0086CD34
		private void SetCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			for (int i = 0; i < this.customSlotMaterials.Count; i++)
			{
				SkeletonRendererCustomMaterials.SlotMaterialOverride slotMaterialOverride = this.customSlotMaterials[i];
				if (!slotMaterialOverride.overrideDisabled && !string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					Slot key = this.skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					this.skeletonRenderer.CustomSlotMaterials[key] = slotMaterialOverride.material;
				}
			}
		}

		// Token: 0x0601B5CE RID: 112078 RVA: 0x0086E9D8 File Offset: 0x0086CDD8
		private void RemoveCustomSlotMaterials()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			for (int i = 0; i < this.customSlotMaterials.Count; i++)
			{
				SkeletonRendererCustomMaterials.SlotMaterialOverride slotMaterialOverride = this.customSlotMaterials[i];
				if (!string.IsNullOrEmpty(slotMaterialOverride.slotName))
				{
					Slot key = this.skeletonRenderer.skeleton.FindSlot(slotMaterialOverride.slotName);
					Material material;
					if (this.skeletonRenderer.CustomSlotMaterials.TryGetValue(key, out material))
					{
						if (!(material != slotMaterialOverride.material))
						{
							this.skeletonRenderer.CustomSlotMaterials.Remove(key);
						}
					}
				}
			}
		}

		// Token: 0x0601B5CF RID: 112079 RVA: 0x0086EAA0 File Offset: 0x0086CEA0
		private void SetCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			for (int i = 0; i < this.customMaterialOverrides.Count; i++)
			{
				SkeletonRendererCustomMaterials.AtlasMaterialOverride atlasMaterialOverride = this.customMaterialOverrides[i];
				if (!atlasMaterialOverride.overrideDisabled)
				{
					this.skeletonRenderer.CustomMaterialOverride[atlasMaterialOverride.originalMaterial] = atlasMaterialOverride.replacementMaterial;
				}
			}
		}

		// Token: 0x0601B5D0 RID: 112080 RVA: 0x0086EB24 File Offset: 0x0086CF24
		private void RemoveCustomMaterialOverrides()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			for (int i = 0; i < this.customMaterialOverrides.Count; i++)
			{
				SkeletonRendererCustomMaterials.AtlasMaterialOverride atlasMaterialOverride = this.customMaterialOverrides[i];
				Material material;
				if (this.skeletonRenderer.CustomMaterialOverride.TryGetValue(atlasMaterialOverride.originalMaterial, out material))
				{
					if (!(material != atlasMaterialOverride.replacementMaterial))
					{
						this.skeletonRenderer.CustomMaterialOverride.Remove(atlasMaterialOverride.originalMaterial);
					}
				}
			}
		}

		// Token: 0x0601B5D1 RID: 112081 RVA: 0x0086EBC8 File Offset: 0x0086CFC8
		private void OnEnable()
		{
			if (this.skeletonRenderer == null)
			{
				this.skeletonRenderer = base.GetComponent<SkeletonRenderer>();
			}
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			this.skeletonRenderer.Initialize(false);
			this.SetCustomMaterialOverrides();
			this.SetCustomSlotMaterials();
		}

		// Token: 0x0601B5D2 RID: 112082 RVA: 0x0086EC26 File Offset: 0x0086D026
		private void OnDisable()
		{
			if (this.skeletonRenderer == null)
			{
				Debug.LogError("skeletonRenderer == null");
				return;
			}
			this.RemoveCustomMaterialOverrides();
			this.RemoveCustomSlotMaterials();
		}

		// Token: 0x040130C0 RID: 78016
		public SkeletonRenderer skeletonRenderer;

		// Token: 0x040130C1 RID: 78017
		[SerializeField]
		protected List<SkeletonRendererCustomMaterials.SlotMaterialOverride> customSlotMaterials = new List<SkeletonRendererCustomMaterials.SlotMaterialOverride>();

		// Token: 0x040130C2 RID: 78018
		[SerializeField]
		protected List<SkeletonRendererCustomMaterials.AtlasMaterialOverride> customMaterialOverrides = new List<SkeletonRendererCustomMaterials.AtlasMaterialOverride>();

		// Token: 0x02004A0A RID: 18954
		[Serializable]
		public struct SlotMaterialOverride : IEquatable<SkeletonRendererCustomMaterials.SlotMaterialOverride>
		{
			// Token: 0x0601B5D3 RID: 112083 RVA: 0x0086EC50 File Offset: 0x0086D050
			public bool Equals(SkeletonRendererCustomMaterials.SlotMaterialOverride other)
			{
				return this.overrideDisabled == other.overrideDisabled && this.slotName == other.slotName && this.material == other.material;
			}

			// Token: 0x040130C3 RID: 78019
			public bool overrideDisabled;

			// Token: 0x040130C4 RID: 78020
			[SpineSlot("", "", false, true, false)]
			public string slotName;

			// Token: 0x040130C5 RID: 78021
			public Material material;
		}

		// Token: 0x02004A0B RID: 18955
		[Serializable]
		public struct AtlasMaterialOverride : IEquatable<SkeletonRendererCustomMaterials.AtlasMaterialOverride>
		{
			// Token: 0x0601B5D4 RID: 112084 RVA: 0x0086EC90 File Offset: 0x0086D090
			public bool Equals(SkeletonRendererCustomMaterials.AtlasMaterialOverride other)
			{
				return this.overrideDisabled == other.overrideDisabled && this.originalMaterial == other.originalMaterial && this.replacementMaterial == other.replacementMaterial;
			}

			// Token: 0x040130C6 RID: 78022
			public bool overrideDisabled;

			// Token: 0x040130C7 RID: 78023
			public Material originalMaterial;

			// Token: 0x040130C8 RID: 78024
			public Material replacementMaterial;
		}
	}
}
