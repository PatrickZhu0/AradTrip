using System;

namespace Spine.Unity
{
	// Token: 0x02004A34 RID: 18996
	public class SpineAttachment : SpineAttributeBase
	{
		// Token: 0x0601B6F3 RID: 112371 RVA: 0x008764D8 File Offset: 0x008748D8
		public SpineAttachment(bool currentSkinOnly = true, bool returnAttachmentPath = false, bool placeholdersOnly = false, string slotField = "", string dataField = "", string skinField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			this.currentSkinOnly = currentSkinOnly;
			this.returnAttachmentPath = returnAttachmentPath;
			this.placeholdersOnly = placeholdersOnly;
			this.slotField = slotField;
			this.dataField = dataField;
			this.skinField = skinField;
			this.includeNone = includeNone;
			this.fallbackToTextField = fallbackToTextField;
		}

		// Token: 0x0601B6F4 RID: 112372 RVA: 0x0087653E File Offset: 0x0087493E
		public static SpineAttachment.Hierarchy GetHierarchy(string fullPath)
		{
			return new SpineAttachment.Hierarchy(fullPath);
		}

		// Token: 0x0601B6F5 RID: 112373 RVA: 0x00876548 File Offset: 0x00874948
		public static Attachment GetAttachment(string attachmentPath, SkeletonData skeletonData)
		{
			SpineAttachment.Hierarchy hierarchy = SpineAttachment.GetHierarchy(attachmentPath);
			return (!string.IsNullOrEmpty(hierarchy.name)) ? skeletonData.FindSkin(hierarchy.skin).GetAttachment(skeletonData.FindSlotIndex(hierarchy.slot), hierarchy.name) : null;
		}

		// Token: 0x0601B6F6 RID: 112374 RVA: 0x00876599 File Offset: 0x00874999
		public static Attachment GetAttachment(string attachmentPath, SkeletonDataAsset skeletonDataAsset)
		{
			return SpineAttachment.GetAttachment(attachmentPath, skeletonDataAsset.GetSkeletonData(true));
		}

		// Token: 0x0401319A RID: 78234
		public bool returnAttachmentPath;

		// Token: 0x0401319B RID: 78235
		public bool currentSkinOnly;

		// Token: 0x0401319C RID: 78236
		public bool placeholdersOnly;

		// Token: 0x0401319D RID: 78237
		public string skinField = string.Empty;

		// Token: 0x0401319E RID: 78238
		public string slotField = string.Empty;

		// Token: 0x02004A35 RID: 18997
		public struct Hierarchy
		{
			// Token: 0x0601B6F7 RID: 112375 RVA: 0x008765A8 File Offset: 0x008749A8
			public Hierarchy(string fullPath)
			{
				string[] array = fullPath.Split(new char[]
				{
					'/'
				}, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 0)
				{
					this.skin = string.Empty;
					this.slot = string.Empty;
					this.name = string.Empty;
					return;
				}
				if (array.Length < 2)
				{
					throw new Exception("Cannot generate Attachment Hierarchy from string! Not enough components! [" + fullPath + "]");
				}
				this.skin = array[0];
				this.slot = array[1];
				this.name = string.Empty;
				for (int i = 2; i < array.Length; i++)
				{
					this.name += array[i];
				}
			}

			// Token: 0x0401319F RID: 78239
			public string skin;

			// Token: 0x040131A0 RID: 78240
			public string slot;

			// Token: 0x040131A1 RID: 78241
			public string name;
		}
	}
}
