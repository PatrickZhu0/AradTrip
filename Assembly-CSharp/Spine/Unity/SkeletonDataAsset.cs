using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E6 RID: 18918
	public class SkeletonDataAsset : ScriptableObject
	{
		// Token: 0x17002419 RID: 9241
		// (get) Token: 0x0601B4AB RID: 111787 RVA: 0x00866722 File Offset: 0x00864B22
		public bool IsLoaded
		{
			get
			{
				return this.skeletonData != null;
			}
		}

		// Token: 0x0601B4AC RID: 111788 RVA: 0x00866730 File Offset: 0x00864B30
		private void Reset()
		{
			this.Clear();
		}

		// Token: 0x0601B4AD RID: 111789 RVA: 0x00866738 File Offset: 0x00864B38
		public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAsset atlasAsset, bool initialize, float scale = 0.01f)
		{
			return SkeletonDataAsset.CreateRuntimeInstance(skeletonDataFile, new AtlasAsset[]
			{
				atlasAsset
			}, initialize, scale);
		}

		// Token: 0x0601B4AE RID: 111790 RVA: 0x0086674C File Offset: 0x00864B4C
		public static SkeletonDataAsset CreateRuntimeInstance(TextAsset skeletonDataFile, AtlasAsset[] atlasAssets, bool initialize, float scale = 0.01f)
		{
			SkeletonDataAsset skeletonDataAsset = ScriptableObject.CreateInstance<SkeletonDataAsset>();
			skeletonDataAsset.Clear();
			skeletonDataAsset.skeletonJSON = skeletonDataFile;
			skeletonDataAsset.atlasAssets = atlasAssets;
			skeletonDataAsset.scale = scale;
			if (initialize)
			{
				skeletonDataAsset.GetSkeletonData(true);
			}
			return skeletonDataAsset;
		}

		// Token: 0x0601B4AF RID: 111791 RVA: 0x00866789 File Offset: 0x00864B89
		public void Clear()
		{
			this.skeletonData = null;
			this.stateData = null;
		}

		// Token: 0x0601B4B0 RID: 111792 RVA: 0x0086679C File Offset: 0x00864B9C
		public SkeletonData GetSkeletonData(bool quiet)
		{
			if (this.skeletonJSON == null)
			{
				if (!quiet)
				{
					Debug.LogError("Skeleton JSON file not set for SkeletonData asset: " + base.name, this);
				}
				this.Clear();
				return null;
			}
			if (this.skeletonData != null)
			{
				return this.skeletonData;
			}
			Atlas[] atlasArray = this.GetAtlasArray();
			AttachmentLoader attachmentLoader2;
			if (atlasArray.Length == 0)
			{
				AttachmentLoader attachmentLoader = new RegionlessAttachmentLoader();
				attachmentLoader2 = attachmentLoader;
			}
			else
			{
				attachmentLoader2 = new AtlasAttachmentLoader(atlasArray);
			}
			AttachmentLoader attachmentLoader3 = attachmentLoader2;
			float num = this.scale;
			bool flag = this.skeletonJSON.name.ToLower().Contains(".skel");
			SkeletonData sd;
			try
			{
				if (flag)
				{
					sd = SkeletonDataAsset.ReadSkeletonData(this.skeletonJSON.bytes, attachmentLoader3, num);
				}
				else
				{
					sd = SkeletonDataAsset.ReadSkeletonData(this.skeletonJSON.text, attachmentLoader3, num);
				}
			}
			catch (Exception ex)
			{
				if (!quiet)
				{
					Debug.LogError(string.Concat(new string[]
					{
						"Error reading skeleton JSON file for SkeletonData asset: ",
						base.name,
						"\n",
						ex.Message,
						"\n",
						ex.StackTrace
					}), this);
				}
				return null;
			}
			this.InitializeWithData(sd);
			return this.skeletonData;
		}

		// Token: 0x0601B4B1 RID: 111793 RVA: 0x008668E8 File Offset: 0x00864CE8
		internal void InitializeWithData(SkeletonData sd)
		{
			this.skeletonData = sd;
			this.stateData = new AnimationStateData(this.skeletonData);
			this.FillStateData();
		}

		// Token: 0x0601B4B2 RID: 111794 RVA: 0x00866908 File Offset: 0x00864D08
		internal Atlas[] GetAtlasArray()
		{
			List<Atlas> list = new List<Atlas>(this.atlasAssets.Length);
			for (int i = 0; i < this.atlasAssets.Length; i++)
			{
				AtlasAsset atlasAsset = this.atlasAssets[i];
				if (!(atlasAsset == null))
				{
					Atlas atlas = atlasAsset.GetAtlas();
					if (atlas != null)
					{
						list.Add(atlas);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x0601B4B3 RID: 111795 RVA: 0x00866978 File Offset: 0x00864D78
		internal static SkeletonData ReadSkeletonData(byte[] bytes, AttachmentLoader attachmentLoader, float scale)
		{
			MemoryStream input = new MemoryStream(bytes);
			SkeletonBinary skeletonBinary = new SkeletonBinary(attachmentLoader)
			{
				Scale = scale
			};
			return skeletonBinary.ReadSkeletonData(input);
		}

		// Token: 0x0601B4B4 RID: 111796 RVA: 0x008669A4 File Offset: 0x00864DA4
		internal static SkeletonData ReadSkeletonData(string text, AttachmentLoader attachmentLoader, float scale)
		{
			StringReader reader = new StringReader(text);
			SkeletonJson skeletonJson = new SkeletonJson(attachmentLoader)
			{
				Scale = scale
			};
			return skeletonJson.ReadSkeletonData(reader);
		}

		// Token: 0x0601B4B5 RID: 111797 RVA: 0x008669D0 File Offset: 0x00864DD0
		public void FillStateData()
		{
			if (this.stateData != null)
			{
				this.stateData.defaultMix = this.defaultMix;
				int i = 0;
				int num = this.fromAnimation.Length;
				while (i < num)
				{
					if (this.fromAnimation[i].Length != 0 && this.toAnimation[i].Length != 0)
					{
						this.stateData.SetMix(this.fromAnimation[i], this.toAnimation[i], this.duration[i]);
					}
					i++;
				}
			}
		}

		// Token: 0x0601B4B6 RID: 111798 RVA: 0x00866A60 File Offset: 0x00864E60
		public AnimationStateData GetAnimationStateData()
		{
			if (this.stateData != null)
			{
				return this.stateData;
			}
			this.GetSkeletonData(false);
			return this.stateData;
		}

		// Token: 0x0401301D RID: 77853
		public AtlasAsset[] atlasAssets = new AtlasAsset[0];

		// Token: 0x0401301E RID: 77854
		public float scale = 0.01f;

		// Token: 0x0401301F RID: 77855
		public TextAsset skeletonJSON;

		// Token: 0x04013020 RID: 77856
		[SpineAnimation("", "", false, false)]
		public string[] fromAnimation = new string[0];

		// Token: 0x04013021 RID: 77857
		[SpineAnimation("", "", false, false)]
		public string[] toAnimation = new string[0];

		// Token: 0x04013022 RID: 77858
		public float[] duration = new float[0];

		// Token: 0x04013023 RID: 77859
		public float defaultMix;

		// Token: 0x04013024 RID: 77860
		public RuntimeAnimatorController controller;

		// Token: 0x04013025 RID: 77861
		private SkeletonData skeletonData;

		// Token: 0x04013026 RID: 77862
		private AnimationStateData stateData;
	}
}
