using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x02004A25 RID: 18981
	public static class SkeletonExtensions
	{
		// Token: 0x0601B6B1 RID: 112305 RVA: 0x00874CE8 File Offset: 0x008730E8
		public static bool IsWeighted(this VertexAttachment va)
		{
			return va.bones != null && va.bones.Length > 0;
		}

		// Token: 0x0601B6B2 RID: 112306 RVA: 0x00874D03 File Offset: 0x00873103
		public static bool IsRenderable(this Attachment a)
		{
			return a is IHasRendererObject;
		}

		// Token: 0x0601B6B3 RID: 112307 RVA: 0x00874D0E File Offset: 0x0087310E
		public static bool InheritsRotation(this TransformMode mode)
		{
			return ((long)mode & 1L) == 0L;
		}

		// Token: 0x0601B6B4 RID: 112308 RVA: 0x00874D19 File Offset: 0x00873119
		public static bool InheritsScale(this TransformMode mode)
		{
			return ((long)mode & 2L) == 0L;
		}

		// Token: 0x0601B6B5 RID: 112309 RVA: 0x00874D24 File Offset: 0x00873124
		internal static void SetPropertyToSetupPose(this Skeleton skeleton, int propertyID)
		{
			int num = propertyID >> 24;
			TimelineType timelineType = (TimelineType)num;
			int num2 = propertyID - (num << 24);
			switch (timelineType)
			{
			case TimelineType.Rotate:
			{
				Bone bone = skeleton.bones.Items[num2];
				bone.rotation = bone.data.rotation;
				break;
			}
			case TimelineType.Translate:
			{
				Bone bone = skeleton.bones.Items[num2];
				bone.x = bone.data.x;
				bone.y = bone.data.y;
				break;
			}
			case TimelineType.Scale:
			{
				Bone bone = skeleton.bones.Items[num2];
				bone.scaleX = bone.data.scaleX;
				bone.scaleY = bone.data.scaleY;
				break;
			}
			case TimelineType.Shear:
			{
				Bone bone = skeleton.bones.Items[num2];
				bone.shearX = bone.data.shearX;
				bone.shearY = bone.data.shearY;
				break;
			}
			case TimelineType.Attachment:
				skeleton.SetSlotAttachmentToSetupPose(num2);
				break;
			case TimelineType.Color:
				skeleton.slots.Items[num2].SetColorToSetupPose();
				break;
			case TimelineType.Deform:
				skeleton.slots.Items[num2].attachmentVertices.Clear(true);
				break;
			case TimelineType.DrawOrder:
				skeleton.SetDrawOrderToSetupPose();
				break;
			case TimelineType.IkConstraint:
			{
				IkConstraint ikConstraint = skeleton.ikConstraints.Items[num2];
				ikConstraint.mix = ikConstraint.data.mix;
				ikConstraint.bendDirection = ikConstraint.data.bendDirection;
				break;
			}
			case TimelineType.TransformConstraint:
			{
				TransformConstraint transformConstraint = skeleton.transformConstraints.Items[num2];
				TransformConstraintData data = transformConstraint.data;
				transformConstraint.rotateMix = data.rotateMix;
				transformConstraint.translateMix = data.translateMix;
				transformConstraint.scaleMix = data.scaleMix;
				transformConstraint.shearMix = data.shearMix;
				break;
			}
			case TimelineType.PathConstraintPosition:
			{
				PathConstraint pathConstraint = skeleton.pathConstraints.Items[num2];
				pathConstraint.position = pathConstraint.data.position;
				break;
			}
			case TimelineType.PathConstraintSpacing:
			{
				PathConstraint pathConstraint = skeleton.pathConstraints.Items[num2];
				pathConstraint.spacing = pathConstraint.data.spacing;
				break;
			}
			case TimelineType.PathConstraintMix:
			{
				PathConstraint pathConstraint = skeleton.pathConstraints.Items[num2];
				pathConstraint.rotateMix = pathConstraint.data.rotateMix;
				pathConstraint.translateMix = pathConstraint.data.translateMix;
				break;
			}
			case TimelineType.TwoColor:
				skeleton.slots.Items[num2].SetColorToSetupPose();
				break;
			}
		}

		// Token: 0x0601B6B6 RID: 112310 RVA: 0x00874FC4 File Offset: 0x008733C4
		public static void SetDrawOrderToSetupPose(this Skeleton skeleton)
		{
			Slot[] items = skeleton.slots.Items;
			int count = skeleton.slots.Count;
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			drawOrder.Clear(false);
			drawOrder.GrowIfNeeded(count);
			Array.Copy(items, drawOrder.Items, count);
		}

		// Token: 0x0601B6B7 RID: 112311 RVA: 0x0087500C File Offset: 0x0087340C
		public static void SetColorToSetupPose(this Slot slot)
		{
			slot.r = slot.data.r;
			slot.g = slot.data.g;
			slot.b = slot.data.b;
			slot.a = slot.data.a;
			slot.r2 = slot.data.r2;
			slot.g2 = slot.data.g2;
			slot.b2 = slot.data.b2;
		}

		// Token: 0x0601B6B8 RID: 112312 RVA: 0x00875090 File Offset: 0x00873490
		public static void SetAttachmentToSetupPose(this Slot slot)
		{
			SlotData data = slot.data;
			slot.Attachment = slot.bone.skeleton.GetAttachment(data.name, data.attachmentName);
		}

		// Token: 0x0601B6B9 RID: 112313 RVA: 0x008750C8 File Offset: 0x008734C8
		public static void SetSlotAttachmentToSetupPose(this Skeleton skeleton, int slotIndex)
		{
			Slot slot = skeleton.slots.Items[slotIndex];
			string attachmentName = slot.data.attachmentName;
			if (string.IsNullOrEmpty(attachmentName))
			{
				slot.Attachment = null;
			}
			else
			{
				Attachment attachment = skeleton.GetAttachment(slotIndex, attachmentName);
				slot.Attachment = attachment;
			}
		}

		// Token: 0x0601B6BA RID: 112314 RVA: 0x00875118 File Offset: 0x00873518
		public static void PoseWithAnimation(this Skeleton skeleton, string animationName, float time, bool loop = false)
		{
			Animation animation = skeleton.data.FindAnimation(animationName);
			if (animation == null)
			{
				return;
			}
			animation.Apply(skeleton, 0f, time, loop, null, 1f, MixPose.Setup, MixDirection.In);
		}

		// Token: 0x0601B6BB RID: 112315 RVA: 0x00875150 File Offset: 0x00873550
		public static void PoseSkeleton(this Animation animation, Skeleton skeleton, float time, bool loop = false)
		{
			animation.Apply(skeleton, 0f, time, loop, null, 1f, MixPose.Setup, MixDirection.In);
		}

		// Token: 0x0601B6BC RID: 112316 RVA: 0x00875174 File Offset: 0x00873574
		public static void SetKeyedItemsToSetupPose(this Animation animation, Skeleton skeleton)
		{
			animation.Apply(skeleton, 0f, 0f, false, null, 0f, MixPose.Setup, MixDirection.Out);
		}

		// Token: 0x0601B6BD RID: 112317 RVA: 0x0087519C File Offset: 0x0087359C
		public static void FindNamesForSlot(this Skin skin, string slotName, SkeletonData skeletonData, List<string> results)
		{
			int slotIndex = skeletonData.FindSlotIndex(slotName);
			skin.FindNamesForSlot(slotIndex, results);
		}

		// Token: 0x0601B6BE RID: 112318 RVA: 0x008751BC File Offset: 0x008735BC
		public static void FindAttachmentsForSlot(this Skin skin, string slotName, SkeletonData skeletonData, List<Attachment> results)
		{
			int slotIndex = skeletonData.FindSlotIndex(slotName);
			skin.FindAttachmentsForSlot(slotIndex, results);
		}
	}
}
