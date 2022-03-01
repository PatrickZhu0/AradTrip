using System;
using System.Collections.Generic;

namespace Spine.Unity.Modules.AnimationTools
{
	// Token: 0x02004A03 RID: 18947
	public static class AnimationTools
	{
		// Token: 0x0601B564 RID: 111972 RVA: 0x0086BC40 File Offset: 0x0086A040
		public static void MatchAnimationTimelines(IEnumerable<Animation> animations, SkeletonData skeletonData)
		{
			if (animations == null)
			{
				return;
			}
			if (skeletonData == null)
			{
				throw new ArgumentNullException("skeletonData", "Timelines can't be matched without a SkeletonData source.");
			}
			Dictionary<int, Timeline> dictionary = new Dictionary<int, Timeline>();
			foreach (Animation animation in animations)
			{
				foreach (Timeline timeline in animation.timelines)
				{
					if (!(timeline is EventTimeline))
					{
						int propertyId = timeline.PropertyId;
						if (!dictionary.ContainsKey(propertyId))
						{
							dictionary.Add(propertyId, AnimationTools.GetFillerTimeline(timeline, skeletonData));
						}
					}
				}
			}
			List<int> list = new List<int>(dictionary.Keys);
			HashSet<int> hashSet = new HashSet<int>();
			foreach (Animation animation2 in animations)
			{
				hashSet.Clear();
				foreach (Timeline timeline2 in animation2.timelines)
				{
					if (!(timeline2 is EventTimeline))
					{
						hashSet.Add(timeline2.PropertyId);
					}
				}
				ExposedList<Timeline> timelines = animation2.timelines;
				foreach (int num in list)
				{
					if (!hashSet.Contains(num))
					{
						timelines.Add(dictionary[num]);
					}
				}
			}
			dictionary.Clear();
			dictionary = null;
			list.Clear();
			list = null;
			hashSet.Clear();
			hashSet = null;
		}

		// Token: 0x0601B565 RID: 111973 RVA: 0x0086BE74 File Offset: 0x0086A274
		private static Timeline GetFillerTimeline(Timeline timeline, SkeletonData skeletonData)
		{
			int propertyId = timeline.PropertyId;
			switch (propertyId >> 24)
			{
			case 0:
				return AnimationTools.GetFillerTimeline((RotateTimeline)timeline, skeletonData);
			case 1:
				return AnimationTools.GetFillerTimeline((TranslateTimeline)timeline, skeletonData);
			case 2:
				return AnimationTools.GetFillerTimeline((ScaleTimeline)timeline, skeletonData);
			case 3:
				return AnimationTools.GetFillerTimeline((ShearTimeline)timeline, skeletonData);
			case 4:
				return AnimationTools.GetFillerTimeline((AttachmentTimeline)timeline, skeletonData);
			case 5:
				return AnimationTools.GetFillerTimeline((ColorTimeline)timeline, skeletonData);
			case 6:
				return AnimationTools.GetFillerTimeline((DeformTimeline)timeline, skeletonData);
			case 8:
				return AnimationTools.GetFillerTimeline((DrawOrderTimeline)timeline, skeletonData);
			case 9:
				return AnimationTools.GetFillerTimeline((IkConstraintTimeline)timeline, skeletonData);
			case 10:
				return AnimationTools.GetFillerTimeline((TransformConstraintTimeline)timeline, skeletonData);
			case 11:
				return AnimationTools.GetFillerTimeline((PathConstraintPositionTimeline)timeline, skeletonData);
			case 12:
				return AnimationTools.GetFillerTimeline((PathConstraintSpacingTimeline)timeline, skeletonData);
			case 13:
				return AnimationTools.GetFillerTimeline((PathConstraintMixTimeline)timeline, skeletonData);
			case 14:
				return AnimationTools.GetFillerTimeline((TwoColorTimeline)timeline, skeletonData);
			}
			return null;
		}

		// Token: 0x0601B566 RID: 111974 RVA: 0x0086BF90 File Offset: 0x0086A390
		private static RotateTimeline GetFillerTimeline(RotateTimeline timeline, SkeletonData skeletonData)
		{
			RotateTimeline rotateTimeline = new RotateTimeline(1);
			rotateTimeline.boneIndex = timeline.boneIndex;
			rotateTimeline.SetFrame(0, 0f, 0f);
			return rotateTimeline;
		}

		// Token: 0x0601B567 RID: 111975 RVA: 0x0086BFC4 File Offset: 0x0086A3C4
		private static TranslateTimeline GetFillerTimeline(TranslateTimeline timeline, SkeletonData skeletonData)
		{
			TranslateTimeline translateTimeline = new TranslateTimeline(1);
			translateTimeline.boneIndex = timeline.boneIndex;
			translateTimeline.SetFrame(0, 0f, 0f, 0f);
			return translateTimeline;
		}

		// Token: 0x0601B568 RID: 111976 RVA: 0x0086BFFC File Offset: 0x0086A3FC
		private static ScaleTimeline GetFillerTimeline(ScaleTimeline timeline, SkeletonData skeletonData)
		{
			ScaleTimeline scaleTimeline = new ScaleTimeline(1);
			scaleTimeline.boneIndex = timeline.boneIndex;
			scaleTimeline.SetFrame(0, 0f, 0f, 0f);
			return scaleTimeline;
		}

		// Token: 0x0601B569 RID: 111977 RVA: 0x0086C034 File Offset: 0x0086A434
		private static ShearTimeline GetFillerTimeline(ShearTimeline timeline, SkeletonData skeletonData)
		{
			ShearTimeline shearTimeline = new ShearTimeline(1);
			shearTimeline.boneIndex = timeline.boneIndex;
			shearTimeline.SetFrame(0, 0f, 0f, 0f);
			return shearTimeline;
		}

		// Token: 0x0601B56A RID: 111978 RVA: 0x0086C06C File Offset: 0x0086A46C
		private static AttachmentTimeline GetFillerTimeline(AttachmentTimeline timeline, SkeletonData skeletonData)
		{
			AttachmentTimeline attachmentTimeline = new AttachmentTimeline(1);
			attachmentTimeline.slotIndex = timeline.slotIndex;
			SlotData slotData = skeletonData.slots.Items[attachmentTimeline.slotIndex];
			attachmentTimeline.SetFrame(0, 0f, slotData.attachmentName);
			return attachmentTimeline;
		}

		// Token: 0x0601B56B RID: 111979 RVA: 0x0086C0B4 File Offset: 0x0086A4B4
		private static ColorTimeline GetFillerTimeline(ColorTimeline timeline, SkeletonData skeletonData)
		{
			ColorTimeline colorTimeline = new ColorTimeline(1);
			colorTimeline.slotIndex = timeline.slotIndex;
			SlotData slotData = skeletonData.slots.Items[colorTimeline.slotIndex];
			colorTimeline.SetFrame(0, 0f, slotData.r, slotData.g, slotData.b, slotData.a);
			return colorTimeline;
		}

		// Token: 0x0601B56C RID: 111980 RVA: 0x0086C10C File Offset: 0x0086A50C
		private static TwoColorTimeline GetFillerTimeline(TwoColorTimeline timeline, SkeletonData skeletonData)
		{
			TwoColorTimeline twoColorTimeline = new TwoColorTimeline(1);
			twoColorTimeline.slotIndex = timeline.slotIndex;
			SlotData slotData = skeletonData.slots.Items[twoColorTimeline.slotIndex];
			twoColorTimeline.SetFrame(0, 0f, slotData.r, slotData.g, slotData.b, slotData.a, slotData.r2, slotData.g2, slotData.b2);
			return twoColorTimeline;
		}

		// Token: 0x0601B56D RID: 111981 RVA: 0x0086C178 File Offset: 0x0086A578
		private static DeformTimeline GetFillerTimeline(DeformTimeline timeline, SkeletonData skeletonData)
		{
			DeformTimeline deformTimeline = new DeformTimeline(1);
			deformTimeline.slotIndex = timeline.slotIndex;
			deformTimeline.attachment = timeline.attachment;
			SlotData slotData = skeletonData.slots.Items[deformTimeline.slotIndex];
			if (deformTimeline.attachment.IsWeighted())
			{
				deformTimeline.SetFrame(0, 0f, new float[deformTimeline.attachment.vertices.Length]);
			}
			else
			{
				deformTimeline.SetFrame(0, 0f, deformTimeline.attachment.vertices.Clone() as float[]);
			}
			return deformTimeline;
		}

		// Token: 0x0601B56E RID: 111982 RVA: 0x0086C20C File Offset: 0x0086A60C
		private static DrawOrderTimeline GetFillerTimeline(DrawOrderTimeline timeline, SkeletonData skeletonData)
		{
			DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(1);
			drawOrderTimeline.SetFrame(0, 0f, null);
			return drawOrderTimeline;
		}

		// Token: 0x0601B56F RID: 111983 RVA: 0x0086C230 File Offset: 0x0086A630
		private static IkConstraintTimeline GetFillerTimeline(IkConstraintTimeline timeline, SkeletonData skeletonData)
		{
			IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(1);
			IkConstraintData ikConstraintData = skeletonData.ikConstraints.Items[timeline.ikConstraintIndex];
			ikConstraintTimeline.SetFrame(0, 0f, ikConstraintData.mix, ikConstraintData.bendDirection);
			return ikConstraintTimeline;
		}

		// Token: 0x0601B570 RID: 111984 RVA: 0x0086C270 File Offset: 0x0086A670
		private static TransformConstraintTimeline GetFillerTimeline(TransformConstraintTimeline timeline, SkeletonData skeletonData)
		{
			TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(1);
			TransformConstraintData transformConstraintData = skeletonData.transformConstraints.Items[timeline.transformConstraintIndex];
			transformConstraintTimeline.SetFrame(0, 0f, transformConstraintData.rotateMix, transformConstraintData.translateMix, transformConstraintData.scaleMix, transformConstraintData.shearMix);
			return transformConstraintTimeline;
		}

		// Token: 0x0601B571 RID: 111985 RVA: 0x0086C2BC File Offset: 0x0086A6BC
		private static PathConstraintPositionTimeline GetFillerTimeline(PathConstraintPositionTimeline timeline, SkeletonData skeletonData)
		{
			PathConstraintPositionTimeline pathConstraintPositionTimeline = new PathConstraintPositionTimeline(1);
			PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[timeline.pathConstraintIndex];
			pathConstraintPositionTimeline.SetFrame(0, 0f, pathConstraintData.position);
			return pathConstraintPositionTimeline;
		}

		// Token: 0x0601B572 RID: 111986 RVA: 0x0086C2F8 File Offset: 0x0086A6F8
		private static PathConstraintSpacingTimeline GetFillerTimeline(PathConstraintSpacingTimeline timeline, SkeletonData skeletonData)
		{
			PathConstraintSpacingTimeline pathConstraintSpacingTimeline = new PathConstraintSpacingTimeline(1);
			PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[timeline.pathConstraintIndex];
			pathConstraintSpacingTimeline.SetFrame(0, 0f, pathConstraintData.spacing);
			return pathConstraintSpacingTimeline;
		}

		// Token: 0x0601B573 RID: 111987 RVA: 0x0086C334 File Offset: 0x0086A734
		private static PathConstraintMixTimeline GetFillerTimeline(PathConstraintMixTimeline timeline, SkeletonData skeletonData)
		{
			PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(1);
			PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[timeline.pathConstraintIndex];
			pathConstraintMixTimeline.SetFrame(0, 0f, pathConstraintData.rotateMix, pathConstraintData.translateMix);
			return pathConstraintMixTimeline;
		}
	}
}
