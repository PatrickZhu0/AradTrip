using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x020049D9 RID: 18905
	public class Skin
	{
		// Token: 0x0601B40F RID: 111631 RVA: 0x00864081 File Offset: 0x00862481
		public Skin(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		// Token: 0x170023DF RID: 9183
		// (get) Token: 0x0601B410 RID: 111632 RVA: 0x008640B6 File Offset: 0x008624B6
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170023E0 RID: 9184
		// (get) Token: 0x0601B411 RID: 111633 RVA: 0x008640BE File Offset: 0x008624BE
		public Dictionary<Skin.AttachmentKeyTuple, Attachment> Attachments
		{
			get
			{
				return this.attachments;
			}
		}

		// Token: 0x0601B412 RID: 111634 RVA: 0x008640C6 File Offset: 0x008624C6
		public void AddAttachment(int slotIndex, string name, Attachment attachment)
		{
			if (attachment == null)
			{
				throw new ArgumentNullException("attachment", "attachment cannot be null.");
			}
			this.attachments[new Skin.AttachmentKeyTuple(slotIndex, name)] = attachment;
		}

		// Token: 0x0601B413 RID: 111635 RVA: 0x008640F4 File Offset: 0x008624F4
		public Attachment GetAttachment(int slotIndex, string name)
		{
			Attachment result;
			this.attachments.TryGetValue(new Skin.AttachmentKeyTuple(slotIndex, name), out result);
			return result;
		}

		// Token: 0x0601B414 RID: 111636 RVA: 0x00864118 File Offset: 0x00862518
		public void FindNamesForSlot(int slotIndex, List<string> names)
		{
			if (names == null)
			{
				throw new ArgumentNullException("names", "names cannot be null.");
			}
			foreach (Skin.AttachmentKeyTuple attachmentKeyTuple in this.attachments.Keys)
			{
				if (attachmentKeyTuple.slotIndex == slotIndex)
				{
					names.Add(attachmentKeyTuple.name);
				}
			}
		}

		// Token: 0x0601B415 RID: 111637 RVA: 0x008641A4 File Offset: 0x008625A4
		public void FindAttachmentsForSlot(int slotIndex, List<Attachment> attachments)
		{
			if (attachments == null)
			{
				throw new ArgumentNullException("attachments", "attachments cannot be null.");
			}
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in this.attachments)
			{
				if (keyValuePair.Key.slotIndex == slotIndex)
				{
					attachments.Add(keyValuePair.Value);
				}
			}
		}

		// Token: 0x0601B416 RID: 111638 RVA: 0x00864234 File Offset: 0x00862634
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x0601B417 RID: 111639 RVA: 0x0086423C File Offset: 0x0086263C
		internal void AttachAll(Skeleton skeleton, Skin oldSkin)
		{
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in oldSkin.attachments)
			{
				int slotIndex = keyValuePair.Key.slotIndex;
				Slot slot = skeleton.slots.Items[slotIndex];
				if (slot.Attachment == keyValuePair.Value)
				{
					Attachment attachment = this.GetAttachment(slotIndex, keyValuePair.Key.name);
					if (attachment != null)
					{
						slot.Attachment = attachment;
					}
				}
			}
		}

		// Token: 0x04012FD2 RID: 77778
		internal string name;

		// Token: 0x04012FD3 RID: 77779
		private Dictionary<Skin.AttachmentKeyTuple, Attachment> attachments = new Dictionary<Skin.AttachmentKeyTuple, Attachment>(Skin.AttachmentKeyTupleComparer.Instance);

		// Token: 0x020049DA RID: 18906
		public struct AttachmentKeyTuple
		{
			// Token: 0x0601B418 RID: 111640 RVA: 0x008642EC File Offset: 0x008626EC
			public AttachmentKeyTuple(int slotIndex, string name)
			{
				this.slotIndex = slotIndex;
				this.name = name;
				this.nameHashCode = this.name.GetHashCode();
			}

			// Token: 0x04012FD4 RID: 77780
			public readonly int slotIndex;

			// Token: 0x04012FD5 RID: 77781
			public readonly string name;

			// Token: 0x04012FD6 RID: 77782
			internal readonly int nameHashCode;
		}

		// Token: 0x020049DB RID: 18907
		private class AttachmentKeyTupleComparer : IEqualityComparer<Skin.AttachmentKeyTuple>
		{
			// Token: 0x0601B41A RID: 111642 RVA: 0x00864315 File Offset: 0x00862715
			bool IEqualityComparer<Skin.AttachmentKeyTuple>.Equals(Skin.AttachmentKeyTuple o1, Skin.AttachmentKeyTuple o2)
			{
				return o1.slotIndex == o2.slotIndex && o1.nameHashCode == o2.nameHashCode && string.Equals(o1.name, o2.name, StringComparison.Ordinal);
			}

			// Token: 0x0601B41B RID: 111643 RVA: 0x00864354 File Offset: 0x00862754
			int IEqualityComparer<Skin.AttachmentKeyTuple>.GetHashCode(Skin.AttachmentKeyTuple o)
			{
				return o.slotIndex;
			}

			// Token: 0x04012FD7 RID: 77783
			internal static readonly Skin.AttachmentKeyTupleComparer Instance = new Skin.AttachmentKeyTupleComparer();
		}
	}
}
