using System;
using System.Collections.Generic;

namespace Spine.Unity.Modules.AttachmentTools
{
	// Token: 0x02004A06 RID: 18950
	public static class SkinUtilities
	{
		// Token: 0x0601B5A2 RID: 112034 RVA: 0x0086D7F8 File Offset: 0x0086BBF8
		public static Skin UnshareSkin(this Skeleton skeleton, bool includeDefaultSkin, bool unshareAttachments, AnimationState state = null)
		{
			Skin clonedSkin = skeleton.GetClonedSkin("cloned skin", includeDefaultSkin, unshareAttachments, true);
			skeleton.SetSkin(clonedSkin);
			if (state != null)
			{
				skeleton.SetToSetupPose();
				state.Apply(skeleton);
			}
			return clonedSkin;
		}

		// Token: 0x0601B5A3 RID: 112035 RVA: 0x0086D830 File Offset: 0x0086BC30
		public static Skin GetClonedSkin(this Skeleton skeleton, string newSkinName, bool includeDefaultSkin = false, bool cloneAttachments = false, bool cloneMeshesAsLinked = true)
		{
			Skin skin = new Skin(newSkinName);
			Skin defaultSkin = skeleton.data.DefaultSkin;
			Skin skin2 = skeleton.skin;
			if (includeDefaultSkin)
			{
				defaultSkin.CopyTo(skin, true, cloneAttachments, cloneMeshesAsLinked);
			}
			if (skin2 != null)
			{
				skin2.CopyTo(skin, true, cloneAttachments, cloneMeshesAsLinked);
			}
			return skin;
		}

		// Token: 0x0601B5A4 RID: 112036 RVA: 0x0086D87C File Offset: 0x0086BC7C
		public static Skin GetClone(this Skin original)
		{
			Skin skin = new Skin(original.name + " clone");
			Dictionary<Skin.AttachmentKeyTuple, Attachment> attachments = skin.Attachments;
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in original.Attachments)
			{
				attachments[keyValuePair.Key] = keyValuePair.Value;
			}
			return skin;
		}

		// Token: 0x0601B5A5 RID: 112037 RVA: 0x0086D904 File Offset: 0x0086BD04
		public static void SetAttachment(this Skin skin, string slotName, string keyName, Attachment attachment, Skeleton skeleton)
		{
			int num = skeleton.FindSlotIndex(slotName);
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			if (num == -1)
			{
				throw new ArgumentException(string.Format("Slot '{0}' does not exist in skeleton.", slotName), "slotName");
			}
			skin.AddAttachment(num, keyName, attachment);
		}

		// Token: 0x0601B5A6 RID: 112038 RVA: 0x0086D958 File Offset: 0x0086BD58
		public static Attachment GetAttachment(this Skin skin, string slotName, string keyName, Skeleton skeleton)
		{
			int num = skeleton.FindSlotIndex(slotName);
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			if (num == -1)
			{
				throw new ArgumentException(string.Format("Slot '{0}' does not exist in skeleton.", slotName), "slotName");
			}
			return skin.GetAttachment(num, keyName);
		}

		// Token: 0x0601B5A7 RID: 112039 RVA: 0x0086D9A8 File Offset: 0x0086BDA8
		public static void SetAttachment(this Skin skin, int slotIndex, string keyName, Attachment attachment)
		{
			skin.AddAttachment(slotIndex, keyName, attachment);
		}

		// Token: 0x0601B5A8 RID: 112040 RVA: 0x0086D9B4 File Offset: 0x0086BDB4
		public static bool RemoveAttachment(this Skin skin, string slotName, string keyName, Skeleton skeleton)
		{
			int num = skeleton.FindSlotIndex(slotName);
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			if (num == -1)
			{
				throw new ArgumentException(string.Format("Slot '{0}' does not exist in skeleton.", slotName), "slotName");
			}
			return skin.RemoveAttachment(num, keyName);
		}

		// Token: 0x0601B5A9 RID: 112041 RVA: 0x0086DA04 File Offset: 0x0086BE04
		public static bool RemoveAttachment(this Skin skin, int slotIndex, string keyName)
		{
			return skin.Attachments.Remove(new Skin.AttachmentKeyTuple(slotIndex, keyName));
		}

		// Token: 0x0601B5AA RID: 112042 RVA: 0x0086DA18 File Offset: 0x0086BE18
		public static void Clear(this Skin skin)
		{
			skin.Attachments.Clear();
		}

		// Token: 0x0601B5AB RID: 112043 RVA: 0x0086DA25 File Offset: 0x0086BE25
		public static void Append(this Skin destination, Skin source)
		{
			source.CopyTo(destination, true, false, true);
		}

		// Token: 0x0601B5AC RID: 112044 RVA: 0x0086DA34 File Offset: 0x0086BE34
		public static void CopyTo(this Skin source, Skin destination, bool overwrite, bool cloneAttachments, bool cloneMeshesAsLinked = true)
		{
			Dictionary<Skin.AttachmentKeyTuple, Attachment> attachments = source.Attachments;
			Dictionary<Skin.AttachmentKeyTuple, Attachment> attachments2 = destination.Attachments;
			if (cloneAttachments)
			{
				if (overwrite)
				{
					foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in attachments)
					{
						attachments2[keyValuePair.Key] = keyValuePair.Value.GetClone(cloneMeshesAsLinked);
					}
				}
				else
				{
					foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair2 in attachments)
					{
						if (!attachments2.ContainsKey(keyValuePair2.Key))
						{
							attachments2.Add(keyValuePair2.Key, keyValuePair2.Value.GetClone(cloneMeshesAsLinked));
						}
					}
				}
			}
			else if (overwrite)
			{
				foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair3 in attachments)
				{
					attachments2[keyValuePair3.Key] = keyValuePair3.Value;
				}
			}
			else
			{
				foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair4 in attachments)
				{
					if (!attachments2.ContainsKey(keyValuePair4.Key))
					{
						attachments2.Add(keyValuePair4.Key, keyValuePair4.Value);
					}
				}
			}
		}
	}
}
