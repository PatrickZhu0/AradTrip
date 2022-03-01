using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x020049D0 RID: 18896
	public class Skeleton
	{
		// Token: 0x0601B35A RID: 111450 RVA: 0x0085C5AC File Offset: 0x0085A9AC
		public Skeleton(SkeletonData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			this.data = data;
			this.bones = new ExposedList<Bone>(data.bones.Count);
			foreach (BoneData boneData in data.bones)
			{
				Bone item;
				if (boneData.parent == null)
				{
					item = new Bone(boneData, this, null);
				}
				else
				{
					Bone bone = this.bones.Items[boneData.parent.index];
					item = new Bone(boneData, this, bone);
					bone.children.Add(item);
				}
				this.bones.Add(item);
			}
			this.slots = new ExposedList<Slot>(data.slots.Count);
			this.drawOrder = new ExposedList<Slot>(data.slots.Count);
			foreach (SlotData slotData in data.slots)
			{
				Bone bone2 = this.bones.Items[slotData.boneData.index];
				Slot item2 = new Slot(slotData, bone2);
				this.slots.Add(item2);
				this.drawOrder.Add(item2);
			}
			this.ikConstraints = new ExposedList<IkConstraint>(data.ikConstraints.Count);
			foreach (IkConstraintData ikConstraintData in data.ikConstraints)
			{
				this.ikConstraints.Add(new IkConstraint(ikConstraintData, this));
			}
			this.transformConstraints = new ExposedList<TransformConstraint>(data.transformConstraints.Count);
			foreach (TransformConstraintData transformConstraintData in data.transformConstraints)
			{
				this.transformConstraints.Add(new TransformConstraint(transformConstraintData, this));
			}
			this.pathConstraints = new ExposedList<PathConstraint>(data.pathConstraints.Count);
			foreach (PathConstraintData pathConstraintData in data.pathConstraints)
			{
				this.pathConstraints.Add(new PathConstraint(pathConstraintData, this));
			}
			this.UpdateCache();
			this.UpdateWorldTransform();
		}

		// Token: 0x170023AC RID: 9132
		// (get) Token: 0x0601B35B RID: 111451 RVA: 0x0085C8D8 File Offset: 0x0085ACD8
		public SkeletonData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170023AD RID: 9133
		// (get) Token: 0x0601B35C RID: 111452 RVA: 0x0085C8E0 File Offset: 0x0085ACE0
		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x170023AE RID: 9134
		// (get) Token: 0x0601B35D RID: 111453 RVA: 0x0085C8E8 File Offset: 0x0085ACE8
		public ExposedList<IUpdatable> UpdateCacheList
		{
			get
			{
				return this.updateCache;
			}
		}

		// Token: 0x170023AF RID: 9135
		// (get) Token: 0x0601B35E RID: 111454 RVA: 0x0085C8F0 File Offset: 0x0085ACF0
		public ExposedList<Slot> Slots
		{
			get
			{
				return this.slots;
			}
		}

		// Token: 0x170023B0 RID: 9136
		// (get) Token: 0x0601B35F RID: 111455 RVA: 0x0085C8F8 File Offset: 0x0085ACF8
		public ExposedList<Slot> DrawOrder
		{
			get
			{
				return this.drawOrder;
			}
		}

		// Token: 0x170023B1 RID: 9137
		// (get) Token: 0x0601B360 RID: 111456 RVA: 0x0085C900 File Offset: 0x0085AD00
		public ExposedList<IkConstraint> IkConstraints
		{
			get
			{
				return this.ikConstraints;
			}
		}

		// Token: 0x170023B2 RID: 9138
		// (get) Token: 0x0601B361 RID: 111457 RVA: 0x0085C908 File Offset: 0x0085AD08
		public ExposedList<PathConstraint> PathConstraints
		{
			get
			{
				return this.pathConstraints;
			}
		}

		// Token: 0x170023B3 RID: 9139
		// (get) Token: 0x0601B362 RID: 111458 RVA: 0x0085C910 File Offset: 0x0085AD10
		public ExposedList<TransformConstraint> TransformConstraints
		{
			get
			{
				return this.transformConstraints;
			}
		}

		// Token: 0x170023B4 RID: 9140
		// (get) Token: 0x0601B363 RID: 111459 RVA: 0x0085C918 File Offset: 0x0085AD18
		// (set) Token: 0x0601B364 RID: 111460 RVA: 0x0085C920 File Offset: 0x0085AD20
		public Skin Skin
		{
			get
			{
				return this.skin;
			}
			set
			{
				this.skin = value;
			}
		}

		// Token: 0x170023B5 RID: 9141
		// (get) Token: 0x0601B365 RID: 111461 RVA: 0x0085C929 File Offset: 0x0085AD29
		// (set) Token: 0x0601B366 RID: 111462 RVA: 0x0085C931 File Offset: 0x0085AD31
		public float R
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x170023B6 RID: 9142
		// (get) Token: 0x0601B367 RID: 111463 RVA: 0x0085C93A File Offset: 0x0085AD3A
		// (set) Token: 0x0601B368 RID: 111464 RVA: 0x0085C942 File Offset: 0x0085AD42
		public float G
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170023B7 RID: 9143
		// (get) Token: 0x0601B369 RID: 111465 RVA: 0x0085C94B File Offset: 0x0085AD4B
		// (set) Token: 0x0601B36A RID: 111466 RVA: 0x0085C953 File Offset: 0x0085AD53
		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170023B8 RID: 9144
		// (get) Token: 0x0601B36B RID: 111467 RVA: 0x0085C95C File Offset: 0x0085AD5C
		// (set) Token: 0x0601B36C RID: 111468 RVA: 0x0085C964 File Offset: 0x0085AD64
		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170023B9 RID: 9145
		// (get) Token: 0x0601B36D RID: 111469 RVA: 0x0085C96D File Offset: 0x0085AD6D
		// (set) Token: 0x0601B36E RID: 111470 RVA: 0x0085C975 File Offset: 0x0085AD75
		public float Time
		{
			get
			{
				return this.time;
			}
			set
			{
				this.time = value;
			}
		}

		// Token: 0x170023BA RID: 9146
		// (get) Token: 0x0601B36F RID: 111471 RVA: 0x0085C97E File Offset: 0x0085AD7E
		// (set) Token: 0x0601B370 RID: 111472 RVA: 0x0085C986 File Offset: 0x0085AD86
		public float X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x170023BB RID: 9147
		// (get) Token: 0x0601B371 RID: 111473 RVA: 0x0085C98F File Offset: 0x0085AD8F
		// (set) Token: 0x0601B372 RID: 111474 RVA: 0x0085C997 File Offset: 0x0085AD97
		public float Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x170023BC RID: 9148
		// (get) Token: 0x0601B373 RID: 111475 RVA: 0x0085C9A0 File Offset: 0x0085ADA0
		// (set) Token: 0x0601B374 RID: 111476 RVA: 0x0085C9A8 File Offset: 0x0085ADA8
		public bool FlipX
		{
			get
			{
				return this.flipX;
			}
			set
			{
				this.flipX = value;
			}
		}

		// Token: 0x170023BD RID: 9149
		// (get) Token: 0x0601B375 RID: 111477 RVA: 0x0085C9B1 File Offset: 0x0085ADB1
		// (set) Token: 0x0601B376 RID: 111478 RVA: 0x0085C9B9 File Offset: 0x0085ADB9
		public bool FlipY
		{
			get
			{
				return this.flipY;
			}
			set
			{
				this.flipY = value;
			}
		}

		// Token: 0x170023BE RID: 9150
		// (get) Token: 0x0601B377 RID: 111479 RVA: 0x0085C9C2 File Offset: 0x0085ADC2
		public Bone RootBone
		{
			get
			{
				return (this.bones.Count != 0) ? this.bones.Items[0] : null;
			}
		}

		// Token: 0x0601B378 RID: 111480 RVA: 0x0085C9E8 File Offset: 0x0085ADE8
		public void UpdateCache()
		{
			ExposedList<IUpdatable> exposedList = this.updateCache;
			exposedList.Clear(true);
			this.updateCacheReset.Clear(true);
			ExposedList<Bone> exposedList2 = this.bones;
			int i = 0;
			int count = exposedList2.Count;
			while (i < count)
			{
				exposedList2.Items[i].sorted = false;
				i++;
			}
			ExposedList<IkConstraint> exposedList3 = this.ikConstraints;
			ExposedList<TransformConstraint> exposedList4 = this.transformConstraints;
			ExposedList<PathConstraint> exposedList5 = this.pathConstraints;
			int count2 = this.IkConstraints.Count;
			int count3 = exposedList4.Count;
			int count4 = exposedList5.Count;
			int num = count2 + count3 + count4;
			int j = 0;
			IL_160:
			while (j < num)
			{
				for (int k = 0; k < count2; k++)
				{
					IkConstraint ikConstraint = exposedList3.Items[k];
					if (ikConstraint.data.order == j)
					{
						this.SortIkConstraint(ikConstraint);
						IL_15A:
						j++;
						goto IL_160;
					}
				}
				for (int l = 0; l < count3; l++)
				{
					TransformConstraint transformConstraint = exposedList4.Items[l];
					if (transformConstraint.data.order == j)
					{
						this.SortTransformConstraint(transformConstraint);
						goto IL_15A;
					}
				}
				for (int m = 0; m < count4; m++)
				{
					PathConstraint pathConstraint = exposedList5.Items[m];
					if (pathConstraint.data.order == j)
					{
						this.SortPathConstraint(pathConstraint);
						break;
					}
				}
				goto IL_15A;
			}
			int n = 0;
			int count5 = exposedList2.Count;
			while (n < count5)
			{
				this.SortBone(exposedList2.Items[n]);
				n++;
			}
		}

		// Token: 0x0601B379 RID: 111481 RVA: 0x0085CB8C File Offset: 0x0085AF8C
		private void SortIkConstraint(IkConstraint constraint)
		{
			Bone target = constraint.target;
			this.SortBone(target);
			ExposedList<Bone> exposedList = constraint.bones;
			Bone bone = exposedList.Items[0];
			this.SortBone(bone);
			if (exposedList.Count > 1)
			{
				Bone item = exposedList.Items[exposedList.Count - 1];
				if (!this.updateCache.Contains(item))
				{
					this.updateCacheReset.Add(item);
				}
			}
			this.updateCache.Add(constraint);
			Skeleton.SortReset(bone.children);
			exposedList.Items[exposedList.Count - 1].sorted = true;
		}

		// Token: 0x0601B37A RID: 111482 RVA: 0x0085CC24 File Offset: 0x0085B024
		private void SortPathConstraint(PathConstraint constraint)
		{
			Slot target = constraint.target;
			int index = target.data.index;
			Bone bone = target.bone;
			if (this.skin != null)
			{
				this.SortPathConstraintAttachment(this.skin, index, bone);
			}
			if (this.data.defaultSkin != null && this.data.defaultSkin != this.skin)
			{
				this.SortPathConstraintAttachment(this.data.defaultSkin, index, bone);
			}
			int i = 0;
			int count = this.data.skins.Count;
			while (i < count)
			{
				this.SortPathConstraintAttachment(this.data.skins.Items[i], index, bone);
				i++;
			}
			Attachment attachment = target.attachment;
			if (attachment is PathAttachment)
			{
				this.SortPathConstraintAttachment(attachment, bone);
			}
			ExposedList<Bone> exposedList = constraint.bones;
			int count2 = exposedList.Count;
			for (int j = 0; j < count2; j++)
			{
				this.SortBone(exposedList.Items[j]);
			}
			this.updateCache.Add(constraint);
			for (int k = 0; k < count2; k++)
			{
				Skeleton.SortReset(exposedList.Items[k].children);
			}
			for (int l = 0; l < count2; l++)
			{
				exposedList.Items[l].sorted = true;
			}
		}

		// Token: 0x0601B37B RID: 111483 RVA: 0x0085CD90 File Offset: 0x0085B190
		private void SortTransformConstraint(TransformConstraint constraint)
		{
			this.SortBone(constraint.target);
			ExposedList<Bone> exposedList = constraint.bones;
			int count = exposedList.Count;
			if (constraint.data.local)
			{
				for (int i = 0; i < count; i++)
				{
					Bone bone = exposedList.Items[i];
					this.SortBone(bone.parent);
					if (!this.updateCache.Contains(bone))
					{
						this.updateCacheReset.Add(bone);
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					this.SortBone(exposedList.Items[j]);
				}
			}
			this.updateCache.Add(constraint);
			for (int k = 0; k < count; k++)
			{
				Skeleton.SortReset(exposedList.Items[k].children);
			}
			for (int l = 0; l < count; l++)
			{
				exposedList.Items[l].sorted = true;
			}
		}

		// Token: 0x0601B37C RID: 111484 RVA: 0x0085CE90 File Offset: 0x0085B290
		private void SortPathConstraintAttachment(Skin skin, int slotIndex, Bone slotBone)
		{
			foreach (KeyValuePair<Skin.AttachmentKeyTuple, Attachment> keyValuePair in skin.Attachments)
			{
				if (keyValuePair.Key.slotIndex == slotIndex)
				{
					this.SortPathConstraintAttachment(keyValuePair.Value, slotBone);
				}
			}
		}

		// Token: 0x0601B37D RID: 111485 RVA: 0x0085CF08 File Offset: 0x0085B308
		private void SortPathConstraintAttachment(Attachment attachment, Bone slotBone)
		{
			if (!(attachment is PathAttachment))
			{
				return;
			}
			int[] array = ((PathAttachment)attachment).bones;
			if (array == null)
			{
				this.SortBone(slotBone);
			}
			else
			{
				ExposedList<Bone> exposedList = this.bones;
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					int num2 = array[i++];
					num2 += i;
					while (i < num2)
					{
						this.SortBone(exposedList.Items[array[i++]]);
					}
				}
			}
		}

		// Token: 0x0601B37E RID: 111486 RVA: 0x0085CF88 File Offset: 0x0085B388
		private void SortBone(Bone bone)
		{
			if (bone.sorted)
			{
				return;
			}
			Bone parent = bone.parent;
			if (parent != null)
			{
				this.SortBone(parent);
			}
			bone.sorted = true;
			this.updateCache.Add(bone);
		}

		// Token: 0x0601B37F RID: 111487 RVA: 0x0085CFC8 File Offset: 0x0085B3C8
		private static void SortReset(ExposedList<Bone> bones)
		{
			Bone[] items = bones.Items;
			int i = 0;
			int count = bones.Count;
			while (i < count)
			{
				Bone bone = items[i];
				if (bone.sorted)
				{
					Skeleton.SortReset(bone.children);
				}
				bone.sorted = false;
				i++;
			}
		}

		// Token: 0x0601B380 RID: 111488 RVA: 0x0085D018 File Offset: 0x0085B418
		public void UpdateWorldTransform()
		{
			ExposedList<Bone> exposedList = this.updateCacheReset;
			Bone[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone = items[i];
				bone.ax = bone.x;
				bone.ay = bone.y;
				bone.arotation = bone.rotation;
				bone.ascaleX = bone.scaleX;
				bone.ascaleY = bone.scaleY;
				bone.ashearX = bone.shearX;
				bone.ashearY = bone.shearY;
				bone.appliedValid = true;
				i++;
			}
			IUpdatable[] items2 = this.updateCache.Items;
			int j = 0;
			int count2 = this.updateCache.Count;
			while (j < count2)
			{
				items2[j].Update();
				j++;
			}
		}

		// Token: 0x0601B381 RID: 111489 RVA: 0x0085D0F6 File Offset: 0x0085B4F6
		public void SetToSetupPose()
		{
			this.SetBonesToSetupPose();
			this.SetSlotsToSetupPose();
		}

		// Token: 0x0601B382 RID: 111490 RVA: 0x0085D104 File Offset: 0x0085B504
		public void SetBonesToSetupPose()
		{
			Bone[] items = this.bones.Items;
			int i = 0;
			int count = this.bones.Count;
			while (i < count)
			{
				items[i].SetToSetupPose();
				i++;
			}
			IkConstraint[] items2 = this.ikConstraints.Items;
			int j = 0;
			int count2 = this.ikConstraints.Count;
			while (j < count2)
			{
				IkConstraint ikConstraint = items2[j];
				ikConstraint.bendDirection = ikConstraint.data.bendDirection;
				ikConstraint.mix = ikConstraint.data.mix;
				j++;
			}
			TransformConstraint[] items3 = this.transformConstraints.Items;
			int k = 0;
			int count3 = this.transformConstraints.Count;
			while (k < count3)
			{
				TransformConstraint transformConstraint = items3[k];
				TransformConstraintData transformConstraintData = transformConstraint.data;
				transformConstraint.rotateMix = transformConstraintData.rotateMix;
				transformConstraint.translateMix = transformConstraintData.translateMix;
				transformConstraint.scaleMix = transformConstraintData.scaleMix;
				transformConstraint.shearMix = transformConstraintData.shearMix;
				k++;
			}
			PathConstraint[] items4 = this.pathConstraints.Items;
			int l = 0;
			int count4 = this.pathConstraints.Count;
			while (l < count4)
			{
				PathConstraint pathConstraint = items4[l];
				PathConstraintData pathConstraintData = pathConstraint.data;
				pathConstraint.position = pathConstraintData.position;
				pathConstraint.spacing = pathConstraintData.spacing;
				pathConstraint.rotateMix = pathConstraintData.rotateMix;
				pathConstraint.translateMix = pathConstraintData.translateMix;
				l++;
			}
		}

		// Token: 0x0601B383 RID: 111491 RVA: 0x0085D294 File Offset: 0x0085B694
		public void SetSlotsToSetupPose()
		{
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			this.drawOrder.Clear(true);
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				this.drawOrder.Add(items[i]);
				i++;
			}
			int j = 0;
			int count2 = exposedList.Count;
			while (j < count2)
			{
				items[j].SetToSetupPose();
				j++;
			}
		}

		// Token: 0x0601B384 RID: 111492 RVA: 0x0085D30C File Offset: 0x0085B70C
		public Bone FindBone(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<Bone> exposedList = this.bones;
			Bone[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone = items[i];
				if (bone.data.name == boneName)
				{
					return bone;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B385 RID: 111493 RVA: 0x0085D378 File Offset: 0x0085B778
		public int FindBoneIndex(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<Bone> exposedList = this.bones;
			Bone[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (items[i].data.name == boneName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0601B386 RID: 111494 RVA: 0x0085D3E0 File Offset: 0x0085B7E0
		public Slot FindSlot(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Slot slot = items[i];
				if (slot.data.name == slotName)
				{
					return slot;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B387 RID: 111495 RVA: 0x0085D44C File Offset: 0x0085B84C
		public int FindSlotIndex(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			Slot[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (items[i].data.name.Equals(slotName))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0601B388 RID: 111496 RVA: 0x0085D4B4 File Offset: 0x0085B8B4
		public void SetSkin(string skinName)
		{
			Skin skin = this.data.FindSkin(skinName);
			if (skin == null)
			{
				throw new ArgumentException("Skin not found: " + skinName, "skinName");
			}
			this.SetSkin(skin);
		}

		// Token: 0x0601B389 RID: 111497 RVA: 0x0085D4F4 File Offset: 0x0085B8F4
		public void SetSkin(Skin newSkin)
		{
			if (newSkin != null)
			{
				if (this.skin != null)
				{
					newSkin.AttachAll(this, this.skin);
				}
				else
				{
					ExposedList<Slot> exposedList = this.slots;
					int i = 0;
					int count = exposedList.Count;
					while (i < count)
					{
						Slot slot = exposedList.Items[i];
						string attachmentName = slot.data.attachmentName;
						if (attachmentName != null)
						{
							Attachment attachment = newSkin.GetAttachment(i, attachmentName);
							if (attachment != null)
							{
								slot.Attachment = attachment;
							}
						}
						i++;
					}
				}
			}
			this.skin = newSkin;
		}

		// Token: 0x0601B38A RID: 111498 RVA: 0x0085D582 File Offset: 0x0085B982
		public Attachment GetAttachment(string slotName, string attachmentName)
		{
			return this.GetAttachment(this.data.FindSlotIndex(slotName), attachmentName);
		}

		// Token: 0x0601B38B RID: 111499 RVA: 0x0085D598 File Offset: 0x0085B998
		public Attachment GetAttachment(int slotIndex, string attachmentName)
		{
			if (attachmentName == null)
			{
				throw new ArgumentNullException("attachmentName", "attachmentName cannot be null.");
			}
			if (this.skin != null)
			{
				Attachment attachment = this.skin.GetAttachment(slotIndex, attachmentName);
				if (attachment != null)
				{
					return attachment;
				}
			}
			return (this.data.defaultSkin == null) ? null : this.data.defaultSkin.GetAttachment(slotIndex, attachmentName);
		}

		// Token: 0x0601B38C RID: 111500 RVA: 0x0085D604 File Offset: 0x0085BA04
		public void SetAttachment(string slotName, string attachmentName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<Slot> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Slot slot = exposedList.Items[i];
				if (slot.data.name == slotName)
				{
					Attachment attachment = null;
					if (attachmentName != null)
					{
						attachment = this.GetAttachment(i, attachmentName);
						if (attachment == null)
						{
							throw new Exception("Attachment not found: " + attachmentName + ", for slot: " + slotName);
						}
					}
					slot.Attachment = attachment;
					return;
				}
				i++;
			}
			throw new Exception("Slot not found: " + slotName);
		}

		// Token: 0x0601B38D RID: 111501 RVA: 0x0085D6B0 File Offset: 0x0085BAB0
		public IkConstraint FindIkConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<IkConstraint> exposedList = this.ikConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				IkConstraint ikConstraint = exposedList.Items[i];
				if (ikConstraint.data.name == constraintName)
				{
					return ikConstraint;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B38E RID: 111502 RVA: 0x0085D718 File Offset: 0x0085BB18
		public TransformConstraint FindTransformConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<TransformConstraint> exposedList = this.transformConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				TransformConstraint transformConstraint = exposedList.Items[i];
				if (transformConstraint.data.name == constraintName)
				{
					return transformConstraint;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B38F RID: 111503 RVA: 0x0085D780 File Offset: 0x0085BB80
		public PathConstraint FindPathConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<PathConstraint> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				PathConstraint pathConstraint = exposedList.Items[i];
				if (pathConstraint.data.name.Equals(constraintName))
				{
					return pathConstraint;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B390 RID: 111504 RVA: 0x0085D7E5 File Offset: 0x0085BBE5
		public void Update(float delta)
		{
			this.time += delta;
		}

		// Token: 0x0601B391 RID: 111505 RVA: 0x0085D7F8 File Offset: 0x0085BBF8
		public void GetBounds(out float x, out float y, out float width, out float height, ref float[] vertexBuffer)
		{
			float[] array = vertexBuffer;
			array = (array ?? new float[8]);
			Slot[] items = this.drawOrder.Items;
			float num = 2.1474836E+09f;
			float num2 = 2.1474836E+09f;
			float num3 = -2.1474836E+09f;
			float num4 = -2.1474836E+09f;
			int i = 0;
			int count = this.drawOrder.Count;
			while (i < count)
			{
				Slot slot = items[i];
				int num5 = 0;
				float[] array2 = null;
				Attachment attachment = slot.attachment;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				if (regionAttachment != null)
				{
					num5 = 8;
					array2 = array;
					if (array2.Length < 8)
					{
						array = (array2 = new float[8]);
					}
					regionAttachment.ComputeWorldVertices(slot.bone, array, 0, 2);
				}
				else
				{
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment != null)
					{
						MeshAttachment meshAttachment2 = meshAttachment;
						num5 = meshAttachment2.WorldVerticesLength;
						array2 = array;
						if (array2.Length < num5)
						{
							array = (array2 = new float[num5]);
						}
						meshAttachment2.ComputeWorldVertices(slot, 0, num5, array, 0, 2);
					}
				}
				if (array2 != null)
				{
					for (int j = 0; j < num5; j += 2)
					{
						float val = array2[j];
						float val2 = array2[j + 1];
						num = Math.Min(num, val);
						num2 = Math.Min(num2, val2);
						num3 = Math.Max(num3, val);
						num4 = Math.Max(num4, val2);
					}
				}
				i++;
			}
			x = num;
			y = num2;
			width = num3 - num;
			height = num4 - num2;
			vertexBuffer = array;
		}

		// Token: 0x04012F82 RID: 77698
		internal SkeletonData data;

		// Token: 0x04012F83 RID: 77699
		internal ExposedList<Bone> bones;

		// Token: 0x04012F84 RID: 77700
		internal ExposedList<Slot> slots;

		// Token: 0x04012F85 RID: 77701
		internal ExposedList<Slot> drawOrder;

		// Token: 0x04012F86 RID: 77702
		internal ExposedList<IkConstraint> ikConstraints;

		// Token: 0x04012F87 RID: 77703
		internal ExposedList<TransformConstraint> transformConstraints;

		// Token: 0x04012F88 RID: 77704
		internal ExposedList<PathConstraint> pathConstraints;

		// Token: 0x04012F89 RID: 77705
		internal ExposedList<IUpdatable> updateCache = new ExposedList<IUpdatable>();

		// Token: 0x04012F8A RID: 77706
		internal ExposedList<Bone> updateCacheReset = new ExposedList<Bone>();

		// Token: 0x04012F8B RID: 77707
		internal Skin skin;

		// Token: 0x04012F8C RID: 77708
		internal float r = 1f;

		// Token: 0x04012F8D RID: 77709
		internal float g = 1f;

		// Token: 0x04012F8E RID: 77710
		internal float b = 1f;

		// Token: 0x04012F8F RID: 77711
		internal float a = 1f;

		// Token: 0x04012F90 RID: 77712
		internal float time;

		// Token: 0x04012F91 RID: 77713
		internal bool flipX;

		// Token: 0x04012F92 RID: 77714
		internal bool flipY;

		// Token: 0x04012F93 RID: 77715
		internal float x;

		// Token: 0x04012F94 RID: 77716
		internal float y;
	}
}
