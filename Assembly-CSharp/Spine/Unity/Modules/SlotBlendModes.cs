using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Modules
{
	// Token: 0x02004A1B RID: 18971
	[DisallowMultipleComponent]
	public class SlotBlendModes : MonoBehaviour
	{
		// Token: 0x1700244F RID: 9295
		// (get) Token: 0x0601B659 RID: 112217 RVA: 0x00873625 File Offset: 0x00871A25
		internal static Dictionary<SlotBlendModes.MaterialTexturePair, Material> MaterialTable
		{
			get
			{
				if (SlotBlendModes.materialTable == null)
				{
					SlotBlendModes.materialTable = new Dictionary<SlotBlendModes.MaterialTexturePair, Material>();
				}
				return SlotBlendModes.materialTable;
			}
		}

		// Token: 0x0601B65A RID: 112218 RVA: 0x00873640 File Offset: 0x00871A40
		internal static Material GetMaterialFor(Material materialSource, Texture2D texture)
		{
			if (materialSource == null || texture == null)
			{
				return null;
			}
			Dictionary<SlotBlendModes.MaterialTexturePair, Material> dictionary = SlotBlendModes.MaterialTable;
			SlotBlendModes.MaterialTexturePair key = new SlotBlendModes.MaterialTexturePair
			{
				material = materialSource,
				texture2D = texture
			};
			Material material;
			if (!dictionary.TryGetValue(key, out material))
			{
				material = new Material(materialSource);
				material.name = "(Clone)" + texture.name + "-" + materialSource.name;
				material.mainTexture = texture;
				dictionary[key] = material;
			}
			return material;
		}

		// Token: 0x17002450 RID: 9296
		// (get) Token: 0x0601B65B RID: 112219 RVA: 0x008736CD File Offset: 0x00871ACD
		// (set) Token: 0x0601B65C RID: 112220 RVA: 0x008736D5 File Offset: 0x00871AD5
		public bool Applied { get; private set; }

		// Token: 0x0601B65D RID: 112221 RVA: 0x008736DE File Offset: 0x00871ADE
		private void Start()
		{
			if (!this.Applied)
			{
				this.Apply();
			}
		}

		// Token: 0x0601B65E RID: 112222 RVA: 0x008736F1 File Offset: 0x00871AF1
		private void OnDestroy()
		{
			if (this.Applied)
			{
				this.Remove();
			}
		}

		// Token: 0x0601B65F RID: 112223 RVA: 0x00873704 File Offset: 0x00871B04
		public void Apply()
		{
			this.GetTexture();
			if (this.texture == null)
			{
				return;
			}
			SkeletonRenderer component = base.GetComponent<SkeletonRenderer>();
			if (component == null)
			{
				return;
			}
			Dictionary<Slot, Material> customSlotMaterials = component.CustomSlotMaterials;
			foreach (Slot slot in component.Skeleton.Slots)
			{
				BlendMode blendMode = slot.data.blendMode;
				if (blendMode != BlendMode.Multiply)
				{
					if (blendMode == BlendMode.Screen)
					{
						if (this.screenMaterialSource != null)
						{
							customSlotMaterials[slot] = SlotBlendModes.GetMaterialFor(this.screenMaterialSource, this.texture);
						}
					}
				}
				else if (this.multiplyMaterialSource != null)
				{
					customSlotMaterials[slot] = SlotBlendModes.GetMaterialFor(this.multiplyMaterialSource, this.texture);
				}
			}
			this.Applied = true;
			component.LateUpdate();
		}

		// Token: 0x0601B660 RID: 112224 RVA: 0x0087381C File Offset: 0x00871C1C
		public void Remove()
		{
			this.GetTexture();
			if (this.texture == null)
			{
				return;
			}
			SkeletonRenderer component = base.GetComponent<SkeletonRenderer>();
			if (component == null)
			{
				return;
			}
			Dictionary<Slot, Material> customSlotMaterials = component.CustomSlotMaterials;
			foreach (Slot slot in component.Skeleton.Slots)
			{
				Material objA = null;
				BlendMode blendMode = slot.data.blendMode;
				if (blendMode != BlendMode.Multiply)
				{
					if (blendMode == BlendMode.Screen)
					{
						if (customSlotMaterials.TryGetValue(slot, out objA) && object.ReferenceEquals(objA, SlotBlendModes.GetMaterialFor(this.screenMaterialSource, this.texture)))
						{
							customSlotMaterials.Remove(slot);
						}
					}
				}
				else if (customSlotMaterials.TryGetValue(slot, out objA) && object.ReferenceEquals(objA, SlotBlendModes.GetMaterialFor(this.multiplyMaterialSource, this.texture)))
				{
					customSlotMaterials.Remove(slot);
				}
			}
			this.Applied = false;
			if (component.valid)
			{
				component.LateUpdate();
			}
		}

		// Token: 0x0601B661 RID: 112225 RVA: 0x00873958 File Offset: 0x00871D58
		public void GetTexture()
		{
			if (this.texture == null)
			{
				SkeletonRenderer component = base.GetComponent<SkeletonRenderer>();
				if (component == null)
				{
					return;
				}
				SkeletonDataAsset skeletonDataAsset = component.skeletonDataAsset;
				if (skeletonDataAsset == null)
				{
					return;
				}
				AtlasAsset atlasAsset = skeletonDataAsset.atlasAssets[0];
				if (atlasAsset == null)
				{
					return;
				}
				Material material = atlasAsset.materials[0];
				if (material == null)
				{
					return;
				}
				this.texture = (material.mainTexture as Texture2D);
			}
		}

		// Token: 0x0401315D RID: 78173
		private static Dictionary<SlotBlendModes.MaterialTexturePair, Material> materialTable;

		// Token: 0x0401315E RID: 78174
		public Material multiplyMaterialSource;

		// Token: 0x0401315F RID: 78175
		public Material screenMaterialSource;

		// Token: 0x04013160 RID: 78176
		private Texture2D texture;

		// Token: 0x02004A1C RID: 18972
		public struct MaterialTexturePair
		{
			// Token: 0x04013162 RID: 78178
			public Texture2D texture2D;

			// Token: 0x04013163 RID: 78179
			public Material material;
		}
	}
}
