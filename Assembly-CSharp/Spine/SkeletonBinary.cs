using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Spine
{
	// Token: 0x020049D1 RID: 18897
	public class SkeletonBinary
	{
		// Token: 0x0601B392 RID: 111506 RVA: 0x0085D969 File Offset: 0x0085BD69
		public SkeletonBinary(params Atlas[] atlasArray) : this(new AtlasAttachmentLoader(atlasArray))
		{
		}

		// Token: 0x0601B393 RID: 111507 RVA: 0x0085D978 File Offset: 0x0085BD78
		public SkeletonBinary(AttachmentLoader attachmentLoader)
		{
			if (attachmentLoader == null)
			{
				throw new ArgumentNullException("attachmentLoader");
			}
			this.attachmentLoader = attachmentLoader;
			this.Scale = 1f;
		}

		// Token: 0x170023BF RID: 9151
		// (get) Token: 0x0601B394 RID: 111508 RVA: 0x0085D9C6 File Offset: 0x0085BDC6
		// (set) Token: 0x0601B395 RID: 111509 RVA: 0x0085D9CE File Offset: 0x0085BDCE
		public float Scale { get; set; }

		// Token: 0x0601B396 RID: 111510 RVA: 0x0085D9D8 File Offset: 0x0085BDD8
		public SkeletonData ReadSkeletonData(string path)
		{
			SkeletonData result;
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				SkeletonData skeletonData = this.ReadSkeletonData(fileStream);
				skeletonData.name = Path.GetFileNameWithoutExtension(path);
				result = skeletonData;
			}
			return result;
		}

		// Token: 0x0601B397 RID: 111511 RVA: 0x0085DA28 File Offset: 0x0085BE28
		public static string GetVersionString(Stream input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			string @string;
			try
			{
				int num = SkeletonBinary.ReadVarint(input, true);
				if (num > 1)
				{
					input.Position += (long)(num - 1);
				}
				num = SkeletonBinary.ReadVarint(input, true);
				if (num <= 1)
				{
					throw new ArgumentException("Stream does not contain a valid binary Skeleton Data.", "input");
				}
				num--;
				byte[] bytes = new byte[num];
				SkeletonBinary.ReadFully(input, bytes, 0, num);
				@string = Encoding.UTF8.GetString(bytes, 0, num);
			}
			catch (Exception arg)
			{
				throw new ArgumentException("Stream does not contain a valid binary Skeleton Data.\n" + arg, "input");
			}
			return @string;
		}

		// Token: 0x0601B398 RID: 111512 RVA: 0x0085DAD4 File Offset: 0x0085BED4
		public SkeletonData ReadSkeletonData(Stream input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			float scale = this.Scale;
			SkeletonData skeletonData = new SkeletonData();
			skeletonData.hash = this.ReadString(input);
			if (skeletonData.hash.Length == 0)
			{
				skeletonData.hash = null;
			}
			skeletonData.version = this.ReadString(input);
			if (skeletonData.version.Length == 0)
			{
				skeletonData.version = null;
			}
			skeletonData.width = this.ReadFloat(input);
			skeletonData.height = this.ReadFloat(input);
			bool flag = SkeletonBinary.ReadBoolean(input);
			if (flag)
			{
				skeletonData.fps = this.ReadFloat(input);
				skeletonData.imagesPath = this.ReadString(input);
				if (skeletonData.imagesPath.Length == 0)
				{
					skeletonData.imagesPath = null;
				}
			}
			int i = 0;
			int num = SkeletonBinary.ReadVarint(input, true);
			while (i < num)
			{
				string name = this.ReadString(input);
				BoneData parent = (i != 0) ? skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)] : null;
				BoneData boneData = new BoneData(i, name, parent);
				boneData.rotation = this.ReadFloat(input);
				boneData.x = this.ReadFloat(input) * scale;
				boneData.y = this.ReadFloat(input) * scale;
				boneData.scaleX = this.ReadFloat(input);
				boneData.scaleY = this.ReadFloat(input);
				boneData.shearX = this.ReadFloat(input);
				boneData.shearY = this.ReadFloat(input);
				boneData.length = this.ReadFloat(input) * scale;
				boneData.transformMode = SkeletonBinary.TransformModeValues[SkeletonBinary.ReadVarint(input, true)];
				if (flag)
				{
					SkeletonBinary.ReadInt(input);
				}
				skeletonData.bones.Add(boneData);
				i++;
			}
			int j = 0;
			int num2 = SkeletonBinary.ReadVarint(input, true);
			while (j < num2)
			{
				string name2 = this.ReadString(input);
				BoneData boneData2 = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				SlotData slotData = new SlotData(j, name2, boneData2);
				int num3 = SkeletonBinary.ReadInt(input);
				slotData.r = (float)(((long)num3 & (long)((ulong)-16777216)) >> 24) / 255f;
				slotData.g = (float)((num3 & 16711680) >> 16) / 255f;
				slotData.b = (float)((num3 & 65280) >> 8) / 255f;
				slotData.a = (float)(num3 & 255) / 255f;
				int num4 = SkeletonBinary.ReadInt(input);
				if (num4 != -1)
				{
					slotData.hasSecondColor = true;
					slotData.r2 = (float)((num4 & 16711680) >> 16) / 255f;
					slotData.g2 = (float)((num4 & 65280) >> 8) / 255f;
					slotData.b2 = (float)(num4 & 255) / 255f;
				}
				slotData.attachmentName = this.ReadString(input);
				slotData.blendMode = (BlendMode)SkeletonBinary.ReadVarint(input, true);
				skeletonData.slots.Add(slotData);
				j++;
			}
			int k = 0;
			int num5 = SkeletonBinary.ReadVarint(input, true);
			while (k < num5)
			{
				IkConstraintData ikConstraintData = new IkConstraintData(this.ReadString(input));
				ikConstraintData.order = SkeletonBinary.ReadVarint(input, true);
				int l = 0;
				int num6 = SkeletonBinary.ReadVarint(input, true);
				while (l < num6)
				{
					ikConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					l++;
				}
				ikConstraintData.target = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				ikConstraintData.mix = this.ReadFloat(input);
				ikConstraintData.bendDirection = (int)SkeletonBinary.ReadSByte(input);
				skeletonData.ikConstraints.Add(ikConstraintData);
				k++;
			}
			int m = 0;
			int num7 = SkeletonBinary.ReadVarint(input, true);
			while (m < num7)
			{
				TransformConstraintData transformConstraintData = new TransformConstraintData(this.ReadString(input));
				transformConstraintData.order = SkeletonBinary.ReadVarint(input, true);
				int n = 0;
				int num8 = SkeletonBinary.ReadVarint(input, true);
				while (n < num8)
				{
					transformConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					n++;
				}
				transformConstraintData.target = skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)];
				transformConstraintData.local = SkeletonBinary.ReadBoolean(input);
				transformConstraintData.relative = SkeletonBinary.ReadBoolean(input);
				transformConstraintData.offsetRotation = this.ReadFloat(input);
				transformConstraintData.offsetX = this.ReadFloat(input) * scale;
				transformConstraintData.offsetY = this.ReadFloat(input) * scale;
				transformConstraintData.offsetScaleX = this.ReadFloat(input);
				transformConstraintData.offsetScaleY = this.ReadFloat(input);
				transformConstraintData.offsetShearY = this.ReadFloat(input);
				transformConstraintData.rotateMix = this.ReadFloat(input);
				transformConstraintData.translateMix = this.ReadFloat(input);
				transformConstraintData.scaleMix = this.ReadFloat(input);
				transformConstraintData.shearMix = this.ReadFloat(input);
				skeletonData.transformConstraints.Add(transformConstraintData);
				m++;
			}
			int num9 = 0;
			int num10 = SkeletonBinary.ReadVarint(input, true);
			while (num9 < num10)
			{
				PathConstraintData pathConstraintData = new PathConstraintData(this.ReadString(input));
				pathConstraintData.order = SkeletonBinary.ReadVarint(input, true);
				int num11 = 0;
				int num12 = SkeletonBinary.ReadVarint(input, true);
				while (num11 < num12)
				{
					pathConstraintData.bones.Add(skeletonData.bones.Items[SkeletonBinary.ReadVarint(input, true)]);
					num11++;
				}
				pathConstraintData.target = skeletonData.slots.Items[SkeletonBinary.ReadVarint(input, true)];
				pathConstraintData.positionMode = (PositionMode)Enum.GetValues(typeof(PositionMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.spacingMode = (SpacingMode)Enum.GetValues(typeof(SpacingMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.rotateMode = (RotateMode)Enum.GetValues(typeof(RotateMode)).GetValue(SkeletonBinary.ReadVarint(input, true));
				pathConstraintData.offsetRotation = this.ReadFloat(input);
				pathConstraintData.position = this.ReadFloat(input);
				if (pathConstraintData.positionMode == PositionMode.Fixed)
				{
					pathConstraintData.position *= scale;
				}
				pathConstraintData.spacing = this.ReadFloat(input);
				if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
				{
					pathConstraintData.spacing *= scale;
				}
				pathConstraintData.rotateMix = this.ReadFloat(input);
				pathConstraintData.translateMix = this.ReadFloat(input);
				skeletonData.pathConstraints.Add(pathConstraintData);
				num9++;
			}
			Skin skin = this.ReadSkin(input, skeletonData, "default", flag);
			if (skin != null)
			{
				skeletonData.defaultSkin = skin;
				skeletonData.skins.Add(skin);
			}
			int num13 = 0;
			int num14 = SkeletonBinary.ReadVarint(input, true);
			while (num13 < num14)
			{
				skeletonData.skins.Add(this.ReadSkin(input, skeletonData, this.ReadString(input), flag));
				num13++;
			}
			int num15 = 0;
			int count = this.linkedMeshes.Count;
			while (num15 < count)
			{
				SkeletonJson.LinkedMesh linkedMesh = this.linkedMeshes[num15];
				Skin skin2 = (linkedMesh.skin != null) ? skeletonData.FindSkin(linkedMesh.skin) : skeletonData.DefaultSkin;
				if (skin2 == null)
				{
					throw new Exception("Skin not found: " + linkedMesh.skin);
				}
				Attachment attachment = skin2.GetAttachment(linkedMesh.slotIndex, linkedMesh.parent);
				if (attachment == null)
				{
					throw new Exception("Parent mesh not found: " + linkedMesh.parent);
				}
				linkedMesh.mesh.ParentMesh = (MeshAttachment)attachment;
				linkedMesh.mesh.UpdateUVs();
				num15++;
			}
			this.linkedMeshes.Clear();
			int num16 = 0;
			int num17 = SkeletonBinary.ReadVarint(input, true);
			while (num16 < num17)
			{
				EventData eventData = new EventData(this.ReadString(input));
				eventData.Int = SkeletonBinary.ReadVarint(input, false);
				eventData.Float = this.ReadFloat(input);
				eventData.String = this.ReadString(input);
				skeletonData.events.Add(eventData);
				num16++;
			}
			int num18 = 0;
			int num19 = SkeletonBinary.ReadVarint(input, true);
			while (num18 < num19)
			{
				this.ReadAnimation(this.ReadString(input), input, skeletonData);
				num18++;
			}
			skeletonData.bones.TrimExcess();
			skeletonData.slots.TrimExcess();
			skeletonData.skins.TrimExcess();
			skeletonData.events.TrimExcess();
			skeletonData.animations.TrimExcess();
			skeletonData.ikConstraints.TrimExcess();
			skeletonData.pathConstraints.TrimExcess();
			return skeletonData;
		}

		// Token: 0x0601B399 RID: 111513 RVA: 0x0085E39C File Offset: 0x0085C79C
		private Skin ReadSkin(Stream input, SkeletonData skeletonData, string skinName, bool nonessential)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			if (num == 0)
			{
				return null;
			}
			Skin skin = new Skin(skinName);
			for (int i = 0; i < num; i++)
			{
				int slotIndex = SkeletonBinary.ReadVarint(input, true);
				int j = 0;
				int num2 = SkeletonBinary.ReadVarint(input, true);
				while (j < num2)
				{
					string text = this.ReadString(input);
					Attachment attachment = this.ReadAttachment(input, skeletonData, skin, slotIndex, text, nonessential);
					if (attachment != null)
					{
						skin.AddAttachment(slotIndex, text, attachment);
					}
					j++;
				}
			}
			return skin;
		}

		// Token: 0x0601B39A RID: 111514 RVA: 0x0085E428 File Offset: 0x0085C828
		private Attachment ReadAttachment(Stream input, SkeletonData skeletonData, Skin skin, int slotIndex, string attachmentName, bool nonessential)
		{
			float scale = this.Scale;
			string text = this.ReadString(input);
			if (text == null)
			{
				text = attachmentName;
			}
			switch (input.ReadByte())
			{
			case 0:
			{
				string text2 = this.ReadString(input);
				float rotation = this.ReadFloat(input);
				float num = this.ReadFloat(input);
				float num2 = this.ReadFloat(input);
				float scaleX = this.ReadFloat(input);
				float scaleY = this.ReadFloat(input);
				float num3 = this.ReadFloat(input);
				float num4 = this.ReadFloat(input);
				int num5 = SkeletonBinary.ReadInt(input);
				if (text2 == null)
				{
					text2 = text;
				}
				RegionAttachment regionAttachment = this.attachmentLoader.NewRegionAttachment(skin, text, text2);
				if (regionAttachment == null)
				{
					return null;
				}
				regionAttachment.Path = text2;
				regionAttachment.x = num * scale;
				regionAttachment.y = num2 * scale;
				regionAttachment.scaleX = scaleX;
				regionAttachment.scaleY = scaleY;
				regionAttachment.rotation = rotation;
				regionAttachment.width = num3 * scale;
				regionAttachment.height = num4 * scale;
				regionAttachment.r = (float)(((long)num5 & (long)((ulong)-16777216)) >> 24) / 255f;
				regionAttachment.g = (float)((num5 & 16711680) >> 16) / 255f;
				regionAttachment.b = (float)((num5 & 65280) >> 8) / 255f;
				regionAttachment.a = (float)(num5 & 255) / 255f;
				regionAttachment.UpdateOffset();
				return regionAttachment;
			}
			case 1:
			{
				int num6 = SkeletonBinary.ReadVarint(input, true);
				SkeletonBinary.Vertices vertices = this.ReadVertices(input, num6);
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				BoundingBoxAttachment boundingBoxAttachment = this.attachmentLoader.NewBoundingBoxAttachment(skin, text);
				if (boundingBoxAttachment == null)
				{
					return null;
				}
				boundingBoxAttachment.worldVerticesLength = num6 << 1;
				boundingBoxAttachment.vertices = vertices.vertices;
				boundingBoxAttachment.bones = vertices.bones;
				return boundingBoxAttachment;
			}
			case 2:
			{
				string text3 = this.ReadString(input);
				int num7 = SkeletonBinary.ReadInt(input);
				int num8 = SkeletonBinary.ReadVarint(input, true);
				float[] regionUVs = this.ReadFloatArray(input, num8 << 1, 1f);
				int[] triangles = this.ReadShortArray(input);
				SkeletonBinary.Vertices vertices2 = this.ReadVertices(input, num8);
				int num9 = SkeletonBinary.ReadVarint(input, true);
				int[] edges = null;
				float num10 = 0f;
				float num11 = 0f;
				if (nonessential)
				{
					edges = this.ReadShortArray(input);
					num10 = this.ReadFloat(input);
					num11 = this.ReadFloat(input);
				}
				if (text3 == null)
				{
					text3 = text;
				}
				MeshAttachment meshAttachment = this.attachmentLoader.NewMeshAttachment(skin, text, text3);
				if (meshAttachment == null)
				{
					return null;
				}
				meshAttachment.Path = text3;
				meshAttachment.r = (float)(((long)num7 & (long)((ulong)-16777216)) >> 24) / 255f;
				meshAttachment.g = (float)((num7 & 16711680) >> 16) / 255f;
				meshAttachment.b = (float)((num7 & 65280) >> 8) / 255f;
				meshAttachment.a = (float)(num7 & 255) / 255f;
				meshAttachment.bones = vertices2.bones;
				meshAttachment.vertices = vertices2.vertices;
				meshAttachment.WorldVerticesLength = num8 << 1;
				meshAttachment.triangles = triangles;
				meshAttachment.regionUVs = regionUVs;
				meshAttachment.UpdateUVs();
				meshAttachment.HullLength = num9 << 1;
				if (nonessential)
				{
					meshAttachment.Edges = edges;
					meshAttachment.Width = num10 * scale;
					meshAttachment.Height = num11 * scale;
				}
				return meshAttachment;
			}
			case 3:
			{
				string text4 = this.ReadString(input);
				int num12 = SkeletonBinary.ReadInt(input);
				string skin2 = this.ReadString(input);
				string parent = this.ReadString(input);
				bool inheritDeform = SkeletonBinary.ReadBoolean(input);
				float num13 = 0f;
				float num14 = 0f;
				if (nonessential)
				{
					num13 = this.ReadFloat(input);
					num14 = this.ReadFloat(input);
				}
				if (text4 == null)
				{
					text4 = text;
				}
				MeshAttachment meshAttachment2 = this.attachmentLoader.NewMeshAttachment(skin, text, text4);
				if (meshAttachment2 == null)
				{
					return null;
				}
				meshAttachment2.Path = text4;
				meshAttachment2.r = (float)(((long)num12 & (long)((ulong)-16777216)) >> 24) / 255f;
				meshAttachment2.g = (float)((num12 & 16711680) >> 16) / 255f;
				meshAttachment2.b = (float)((num12 & 65280) >> 8) / 255f;
				meshAttachment2.a = (float)(num12 & 255) / 255f;
				meshAttachment2.inheritDeform = inheritDeform;
				if (nonessential)
				{
					meshAttachment2.Width = num13 * scale;
					meshAttachment2.Height = num14 * scale;
				}
				this.linkedMeshes.Add(new SkeletonJson.LinkedMesh(meshAttachment2, skin2, slotIndex, parent));
				return meshAttachment2;
			}
			case 4:
			{
				bool closed = SkeletonBinary.ReadBoolean(input);
				bool constantSpeed = SkeletonBinary.ReadBoolean(input);
				int num15 = SkeletonBinary.ReadVarint(input, true);
				SkeletonBinary.Vertices vertices3 = this.ReadVertices(input, num15);
				float[] array = new float[num15 / 3];
				int i = 0;
				int num16 = array.Length;
				while (i < num16)
				{
					array[i] = this.ReadFloat(input) * scale;
					i++;
				}
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				PathAttachment pathAttachment = this.attachmentLoader.NewPathAttachment(skin, text);
				if (pathAttachment == null)
				{
					return null;
				}
				pathAttachment.closed = closed;
				pathAttachment.constantSpeed = constantSpeed;
				pathAttachment.worldVerticesLength = num15 << 1;
				pathAttachment.vertices = vertices3.vertices;
				pathAttachment.bones = vertices3.bones;
				pathAttachment.lengths = array;
				return pathAttachment;
			}
			case 5:
			{
				float rotation2 = this.ReadFloat(input);
				float num17 = this.ReadFloat(input);
				float num18 = this.ReadFloat(input);
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				PointAttachment pointAttachment = this.attachmentLoader.NewPointAttachment(skin, text);
				if (pointAttachment == null)
				{
					return null;
				}
				pointAttachment.x = num17 * scale;
				pointAttachment.y = num18 * scale;
				pointAttachment.rotation = rotation2;
				return pointAttachment;
			}
			case 6:
			{
				int num19 = SkeletonBinary.ReadVarint(input, true);
				int num20 = SkeletonBinary.ReadVarint(input, true);
				SkeletonBinary.Vertices vertices4 = this.ReadVertices(input, num20);
				if (nonessential)
				{
					SkeletonBinary.ReadInt(input);
				}
				ClippingAttachment clippingAttachment = this.attachmentLoader.NewClippingAttachment(skin, text);
				if (clippingAttachment == null)
				{
					return null;
				}
				clippingAttachment.EndSlot = skeletonData.slots.Items[num19];
				clippingAttachment.worldVerticesLength = num20 << 1;
				clippingAttachment.vertices = vertices4.vertices;
				clippingAttachment.bones = vertices4.bones;
				return clippingAttachment;
			}
			default:
				return null;
			}
		}

		// Token: 0x0601B39B RID: 111515 RVA: 0x0085EA58 File Offset: 0x0085CE58
		private SkeletonBinary.Vertices ReadVertices(Stream input, int vertexCount)
		{
			float scale = this.Scale;
			int num = vertexCount << 1;
			SkeletonBinary.Vertices vertices = new SkeletonBinary.Vertices();
			if (!SkeletonBinary.ReadBoolean(input))
			{
				vertices.vertices = this.ReadFloatArray(input, num, scale);
				return vertices;
			}
			ExposedList<float> exposedList = new ExposedList<float>(num * 3 * 3);
			ExposedList<int> exposedList2 = new ExposedList<int>(num * 3);
			for (int i = 0; i < vertexCount; i++)
			{
				int num2 = SkeletonBinary.ReadVarint(input, true);
				exposedList2.Add(num2);
				for (int j = 0; j < num2; j++)
				{
					exposedList2.Add(SkeletonBinary.ReadVarint(input, true));
					exposedList.Add(this.ReadFloat(input) * scale);
					exposedList.Add(this.ReadFloat(input) * scale);
					exposedList.Add(this.ReadFloat(input));
				}
			}
			vertices.vertices = exposedList.ToArray();
			vertices.bones = exposedList2.ToArray();
			return vertices;
		}

		// Token: 0x0601B39C RID: 111516 RVA: 0x0085EB3C File Offset: 0x0085CF3C
		private float[] ReadFloatArray(Stream input, int n, float scale)
		{
			float[] array = new float[n];
			if (scale == 1f)
			{
				for (int i = 0; i < n; i++)
				{
					array[i] = this.ReadFloat(input);
				}
			}
			else
			{
				for (int j = 0; j < n; j++)
				{
					array[j] = this.ReadFloat(input) * scale;
				}
			}
			return array;
		}

		// Token: 0x0601B39D RID: 111517 RVA: 0x0085EB9C File Offset: 0x0085CF9C
		private int[] ReadShortArray(Stream input)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (input.ReadByte() << 8 | input.ReadByte());
			}
			return array;
		}

		// Token: 0x0601B39E RID: 111518 RVA: 0x0085EBE0 File Offset: 0x0085CFE0
		private void ReadAnimation(string name, Stream input, SkeletonData skeletonData)
		{
			ExposedList<Timeline> exposedList = new ExposedList<Timeline>();
			float scale = this.Scale;
			float num = 0f;
			int i = 0;
			int num2 = SkeletonBinary.ReadVarint(input, true);
			while (i < num2)
			{
				int slotIndex = SkeletonBinary.ReadVarint(input, true);
				int j = 0;
				int num3 = SkeletonBinary.ReadVarint(input, true);
				while (j < num3)
				{
					int num4 = input.ReadByte();
					int num5 = SkeletonBinary.ReadVarint(input, true);
					if (num4 != 0)
					{
						if (num4 != 1)
						{
							if (num4 == 2)
							{
								TwoColorTimeline twoColorTimeline = new TwoColorTimeline(num5);
								twoColorTimeline.slotIndex = slotIndex;
								for (int k = 0; k < num5; k++)
								{
									float time = this.ReadFloat(input);
									int num6 = SkeletonBinary.ReadInt(input);
									float r = (float)(((long)num6 & (long)((ulong)-16777216)) >> 24) / 255f;
									float g = (float)((num6 & 16711680) >> 16) / 255f;
									float b = (float)((num6 & 65280) >> 8) / 255f;
									float a = (float)(num6 & 255) / 255f;
									int num7 = SkeletonBinary.ReadInt(input);
									float r2 = (float)((num7 & 16711680) >> 16) / 255f;
									float g2 = (float)((num7 & 65280) >> 8) / 255f;
									float b2 = (float)(num7 & 255) / 255f;
									twoColorTimeline.SetFrame(k, time, r, g, b, a, r2, g2, b2);
									if (k < num5 - 1)
									{
										this.ReadCurve(input, k, twoColorTimeline);
									}
								}
								exposedList.Add(twoColorTimeline);
								num = Math.Max(num, twoColorTimeline.frames[(twoColorTimeline.FrameCount - 1) * 8]);
							}
						}
						else
						{
							ColorTimeline colorTimeline = new ColorTimeline(num5);
							colorTimeline.slotIndex = slotIndex;
							for (int l = 0; l < num5; l++)
							{
								float time2 = this.ReadFloat(input);
								int num8 = SkeletonBinary.ReadInt(input);
								float r3 = (float)(((long)num8 & (long)((ulong)-16777216)) >> 24) / 255f;
								float g3 = (float)((num8 & 16711680) >> 16) / 255f;
								float b3 = (float)((num8 & 65280) >> 8) / 255f;
								float a2 = (float)(num8 & 255) / 255f;
								colorTimeline.SetFrame(l, time2, r3, g3, b3, a2);
								if (l < num5 - 1)
								{
									this.ReadCurve(input, l, colorTimeline);
								}
							}
							exposedList.Add(colorTimeline);
							num = Math.Max(num, colorTimeline.frames[(colorTimeline.FrameCount - 1) * 5]);
						}
					}
					else
					{
						AttachmentTimeline attachmentTimeline = new AttachmentTimeline(num5);
						attachmentTimeline.slotIndex = slotIndex;
						for (int m = 0; m < num5; m++)
						{
							attachmentTimeline.SetFrame(m, this.ReadFloat(input), this.ReadString(input));
						}
						exposedList.Add(attachmentTimeline);
						num = Math.Max(num, attachmentTimeline.frames[num5 - 1]);
					}
					j++;
				}
				i++;
			}
			int n = 0;
			int num9 = SkeletonBinary.ReadVarint(input, true);
			while (n < num9)
			{
				int boneIndex = SkeletonBinary.ReadVarint(input, true);
				int num10 = 0;
				int num11 = SkeletonBinary.ReadVarint(input, true);
				while (num10 < num11)
				{
					int num12 = input.ReadByte();
					int num13 = SkeletonBinary.ReadVarint(input, true);
					switch (num12)
					{
					case 0:
					{
						RotateTimeline rotateTimeline = new RotateTimeline(num13);
						rotateTimeline.boneIndex = boneIndex;
						for (int num14 = 0; num14 < num13; num14++)
						{
							rotateTimeline.SetFrame(num14, this.ReadFloat(input), this.ReadFloat(input));
							if (num14 < num13 - 1)
							{
								this.ReadCurve(input, num14, rotateTimeline);
							}
						}
						exposedList.Add(rotateTimeline);
						num = Math.Max(num, rotateTimeline.frames[(num13 - 1) * 2]);
						break;
					}
					case 1:
					case 2:
					case 3:
					{
						float num15 = 1f;
						TranslateTimeline translateTimeline;
						if (num12 == 2)
						{
							translateTimeline = new ScaleTimeline(num13);
						}
						else if (num12 == 3)
						{
							translateTimeline = new ShearTimeline(num13);
						}
						else
						{
							translateTimeline = new TranslateTimeline(num13);
							num15 = scale;
						}
						translateTimeline.boneIndex = boneIndex;
						for (int num16 = 0; num16 < num13; num16++)
						{
							translateTimeline.SetFrame(num16, this.ReadFloat(input), this.ReadFloat(input) * num15, this.ReadFloat(input) * num15);
							if (num16 < num13 - 1)
							{
								this.ReadCurve(input, num16, translateTimeline);
							}
						}
						exposedList.Add(translateTimeline);
						num = Math.Max(num, translateTimeline.frames[(num13 - 1) * 3]);
						break;
					}
					}
					num10++;
				}
				n++;
			}
			int num17 = 0;
			int num18 = SkeletonBinary.ReadVarint(input, true);
			while (num17 < num18)
			{
				int ikConstraintIndex = SkeletonBinary.ReadVarint(input, true);
				int num19 = SkeletonBinary.ReadVarint(input, true);
				IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(num19);
				ikConstraintTimeline.ikConstraintIndex = ikConstraintIndex;
				for (int num20 = 0; num20 < num19; num20++)
				{
					ikConstraintTimeline.SetFrame(num20, this.ReadFloat(input), this.ReadFloat(input), (int)SkeletonBinary.ReadSByte(input));
					if (num20 < num19 - 1)
					{
						this.ReadCurve(input, num20, ikConstraintTimeline);
					}
				}
				exposedList.Add(ikConstraintTimeline);
				num = Math.Max(num, ikConstraintTimeline.frames[(num19 - 1) * 3]);
				num17++;
			}
			int num21 = 0;
			int num22 = SkeletonBinary.ReadVarint(input, true);
			while (num21 < num22)
			{
				int transformConstraintIndex = SkeletonBinary.ReadVarint(input, true);
				int num23 = SkeletonBinary.ReadVarint(input, true);
				TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(num23);
				transformConstraintTimeline.transformConstraintIndex = transformConstraintIndex;
				for (int num24 = 0; num24 < num23; num24++)
				{
					transformConstraintTimeline.SetFrame(num24, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
					if (num24 < num23 - 1)
					{
						this.ReadCurve(input, num24, transformConstraintTimeline);
					}
				}
				exposedList.Add(transformConstraintTimeline);
				num = Math.Max(num, transformConstraintTimeline.frames[(num23 - 1) * 5]);
				num21++;
			}
			int num25 = 0;
			int num26 = SkeletonBinary.ReadVarint(input, true);
			while (num25 < num26)
			{
				int num27 = SkeletonBinary.ReadVarint(input, true);
				PathConstraintData pathConstraintData = skeletonData.pathConstraints.Items[num27];
				int num28 = 0;
				int num29 = SkeletonBinary.ReadVarint(input, true);
				while (num28 < num29)
				{
					int num30 = (int)SkeletonBinary.ReadSByte(input);
					int num31 = SkeletonBinary.ReadVarint(input, true);
					if (num30 != 0 && num30 != 1)
					{
						if (num30 == 2)
						{
							PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(num31);
							pathConstraintMixTimeline.pathConstraintIndex = num27;
							for (int num32 = 0; num32 < num31; num32++)
							{
								pathConstraintMixTimeline.SetFrame(num32, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
								if (num32 < num31 - 1)
								{
									this.ReadCurve(input, num32, pathConstraintMixTimeline);
								}
							}
							exposedList.Add(pathConstraintMixTimeline);
							num = Math.Max(num, pathConstraintMixTimeline.frames[(num31 - 1) * 3]);
						}
					}
					else
					{
						float num33 = 1f;
						PathConstraintPositionTimeline pathConstraintPositionTimeline;
						if (num30 == 1)
						{
							pathConstraintPositionTimeline = new PathConstraintSpacingTimeline(num31);
							if (pathConstraintData.spacingMode == SpacingMode.Length || pathConstraintData.spacingMode == SpacingMode.Fixed)
							{
								num33 = scale;
							}
						}
						else
						{
							pathConstraintPositionTimeline = new PathConstraintPositionTimeline(num31);
							if (pathConstraintData.positionMode == PositionMode.Fixed)
							{
								num33 = scale;
							}
						}
						pathConstraintPositionTimeline.pathConstraintIndex = num27;
						for (int num34 = 0; num34 < num31; num34++)
						{
							pathConstraintPositionTimeline.SetFrame(num34, this.ReadFloat(input), this.ReadFloat(input) * num33);
							if (num34 < num31 - 1)
							{
								this.ReadCurve(input, num34, pathConstraintPositionTimeline);
							}
						}
						exposedList.Add(pathConstraintPositionTimeline);
						num = Math.Max(num, pathConstraintPositionTimeline.frames[(num31 - 1) * 2]);
					}
					num28++;
				}
				num25++;
			}
			int num35 = 0;
			int num36 = SkeletonBinary.ReadVarint(input, true);
			while (num35 < num36)
			{
				Skin skin = skeletonData.skins.Items[SkeletonBinary.ReadVarint(input, true)];
				int num37 = 0;
				int num38 = SkeletonBinary.ReadVarint(input, true);
				while (num37 < num38)
				{
					int slotIndex2 = SkeletonBinary.ReadVarint(input, true);
					int num39 = 0;
					int num40 = SkeletonBinary.ReadVarint(input, true);
					while (num39 < num40)
					{
						VertexAttachment vertexAttachment = (VertexAttachment)skin.GetAttachment(slotIndex2, this.ReadString(input));
						bool flag = vertexAttachment.bones != null;
						float[] vertices = vertexAttachment.vertices;
						int num41 = (!flag) ? vertices.Length : (vertices.Length / 3 * 2);
						int num42 = SkeletonBinary.ReadVarint(input, true);
						DeformTimeline deformTimeline = new DeformTimeline(num42);
						deformTimeline.slotIndex = slotIndex2;
						deformTimeline.attachment = vertexAttachment;
						for (int num43 = 0; num43 < num42; num43++)
						{
							float time3 = this.ReadFloat(input);
							int num44 = SkeletonBinary.ReadVarint(input, true);
							float[] array;
							if (num44 == 0)
							{
								array = ((!flag) ? vertices : new float[num41]);
							}
							else
							{
								array = new float[num41];
								int num45 = SkeletonBinary.ReadVarint(input, true);
								num44 += num45;
								if (scale == 1f)
								{
									for (int num46 = num45; num46 < num44; num46++)
									{
										array[num46] = this.ReadFloat(input);
									}
								}
								else
								{
									for (int num47 = num45; num47 < num44; num47++)
									{
										array[num47] = this.ReadFloat(input) * scale;
									}
								}
								if (!flag)
								{
									int num48 = 0;
									int num49 = array.Length;
									while (num48 < num49)
									{
										array[num48] += vertices[num48];
										num48++;
									}
								}
							}
							deformTimeline.SetFrame(num43, time3, array);
							if (num43 < num42 - 1)
							{
								this.ReadCurve(input, num43, deformTimeline);
							}
						}
						exposedList.Add(deformTimeline);
						num = Math.Max(num, deformTimeline.frames[num42 - 1]);
						num39++;
					}
					num37++;
				}
				num35++;
			}
			int num50 = SkeletonBinary.ReadVarint(input, true);
			if (num50 > 0)
			{
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(num50);
				int count = skeletonData.slots.Count;
				for (int num51 = 0; num51 < num50; num51++)
				{
					float time4 = this.ReadFloat(input);
					int num52 = SkeletonBinary.ReadVarint(input, true);
					int[] array2 = new int[count];
					for (int num53 = count - 1; num53 >= 0; num53--)
					{
						array2[num53] = -1;
					}
					int[] array3 = new int[count - num52];
					int num54 = 0;
					int num55 = 0;
					for (int num56 = 0; num56 < num52; num56++)
					{
						int num57 = SkeletonBinary.ReadVarint(input, true);
						while (num54 != num57)
						{
							array3[num55++] = num54++;
						}
						array2[num54 + SkeletonBinary.ReadVarint(input, true)] = num54++;
					}
					while (num54 < count)
					{
						array3[num55++] = num54++;
					}
					for (int num58 = count - 1; num58 >= 0; num58--)
					{
						if (array2[num58] == -1)
						{
							array2[num58] = array3[--num55];
						}
					}
					drawOrderTimeline.SetFrame(num51, time4, array2);
				}
				exposedList.Add(drawOrderTimeline);
				num = Math.Max(num, drawOrderTimeline.frames[num50 - 1]);
			}
			int num59 = SkeletonBinary.ReadVarint(input, true);
			if (num59 > 0)
			{
				EventTimeline eventTimeline = new EventTimeline(num59);
				for (int num60 = 0; num60 < num59; num60++)
				{
					float time5 = this.ReadFloat(input);
					EventData eventData = skeletonData.events.Items[SkeletonBinary.ReadVarint(input, true)];
					eventTimeline.SetFrame(num60, new Event(time5, eventData)
					{
						Int = SkeletonBinary.ReadVarint(input, false),
						Float = this.ReadFloat(input),
						String = ((!SkeletonBinary.ReadBoolean(input)) ? eventData.String : this.ReadString(input))
					});
				}
				exposedList.Add(eventTimeline);
				num = Math.Max(num, eventTimeline.frames[num59 - 1]);
			}
			exposedList.TrimExcess();
			skeletonData.animations.Add(new Animation(name, exposedList, num));
		}

		// Token: 0x0601B39F RID: 111519 RVA: 0x0085F7F0 File Offset: 0x0085DBF0
		private void ReadCurve(Stream input, int frameIndex, CurveTimeline timeline)
		{
			int num = input.ReadByte();
			if (num != 1)
			{
				if (num == 2)
				{
					timeline.SetCurve(frameIndex, this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input), this.ReadFloat(input));
				}
			}
			else
			{
				timeline.SetStepped(frameIndex);
			}
		}

		// Token: 0x0601B3A0 RID: 111520 RVA: 0x0085F84C File Offset: 0x0085DC4C
		private static sbyte ReadSByte(Stream input)
		{
			int num = input.ReadByte();
			if (num == -1)
			{
				throw new EndOfStreamException();
			}
			return (sbyte)num;
		}

		// Token: 0x0601B3A1 RID: 111521 RVA: 0x0085F86F File Offset: 0x0085DC6F
		private static bool ReadBoolean(Stream input)
		{
			return input.ReadByte() != 0;
		}

		// Token: 0x0601B3A2 RID: 111522 RVA: 0x0085F880 File Offset: 0x0085DC80
		private float ReadFloat(Stream input)
		{
			this.buffer[3] = (byte)input.ReadByte();
			this.buffer[2] = (byte)input.ReadByte();
			this.buffer[1] = (byte)input.ReadByte();
			this.buffer[0] = (byte)input.ReadByte();
			return BitConverter.ToSingle(this.buffer, 0);
		}

		// Token: 0x0601B3A3 RID: 111523 RVA: 0x0085F8D5 File Offset: 0x0085DCD5
		private static int ReadInt(Stream input)
		{
			return (input.ReadByte() << 24) + (input.ReadByte() << 16) + (input.ReadByte() << 8) + input.ReadByte();
		}

		// Token: 0x0601B3A4 RID: 111524 RVA: 0x0085F8FC File Offset: 0x0085DCFC
		private static int ReadVarint(Stream input, bool optimizePositive)
		{
			int num = input.ReadByte();
			int num2 = num & 127;
			if ((num & 128) != 0)
			{
				num = input.ReadByte();
				num2 |= (num & 127) << 7;
				if ((num & 128) != 0)
				{
					num = input.ReadByte();
					num2 |= (num & 127) << 14;
					if ((num & 128) != 0)
					{
						num = input.ReadByte();
						num2 |= (num & 127) << 21;
						if ((num & 128) != 0)
						{
							num2 |= (input.ReadByte() & 127) << 28;
						}
					}
				}
			}
			return (!optimizePositive) ? (num2 >> 1 ^ -(num2 & 1)) : num2;
		}

		// Token: 0x0601B3A5 RID: 111525 RVA: 0x0085F99C File Offset: 0x0085DD9C
		private string ReadString(Stream input)
		{
			int num = SkeletonBinary.ReadVarint(input, true);
			if (num == 0)
			{
				return null;
			}
			if (num != 1)
			{
				num--;
				byte[] array = this.buffer;
				if (array.Length < num)
				{
					array = new byte[num];
				}
				SkeletonBinary.ReadFully(input, array, 0, num);
				return Encoding.UTF8.GetString(array, 0, num);
			}
			return string.Empty;
		}

		// Token: 0x0601B3A6 RID: 111526 RVA: 0x0085F9FC File Offset: 0x0085DDFC
		private static void ReadFully(Stream input, byte[] buffer, int offset, int length)
		{
			while (length > 0)
			{
				int num = input.Read(buffer, offset, length);
				if (num <= 0)
				{
					throw new EndOfStreamException();
				}
				offset += num;
				length -= num;
			}
		}

		// Token: 0x04012F95 RID: 77717
		public const int BONE_ROTATE = 0;

		// Token: 0x04012F96 RID: 77718
		public const int BONE_TRANSLATE = 1;

		// Token: 0x04012F97 RID: 77719
		public const int BONE_SCALE = 2;

		// Token: 0x04012F98 RID: 77720
		public const int BONE_SHEAR = 3;

		// Token: 0x04012F99 RID: 77721
		public const int SLOT_ATTACHMENT = 0;

		// Token: 0x04012F9A RID: 77722
		public const int SLOT_COLOR = 1;

		// Token: 0x04012F9B RID: 77723
		public const int SLOT_TWO_COLOR = 2;

		// Token: 0x04012F9C RID: 77724
		public const int PATH_POSITION = 0;

		// Token: 0x04012F9D RID: 77725
		public const int PATH_SPACING = 1;

		// Token: 0x04012F9E RID: 77726
		public const int PATH_MIX = 2;

		// Token: 0x04012F9F RID: 77727
		public const int CURVE_LINEAR = 0;

		// Token: 0x04012FA0 RID: 77728
		public const int CURVE_STEPPED = 1;

		// Token: 0x04012FA1 RID: 77729
		public const int CURVE_BEZIER = 2;

		// Token: 0x04012FA3 RID: 77731
		private AttachmentLoader attachmentLoader;

		// Token: 0x04012FA4 RID: 77732
		private byte[] buffer = new byte[32];

		// Token: 0x04012FA5 RID: 77733
		private List<SkeletonJson.LinkedMesh> linkedMeshes = new List<SkeletonJson.LinkedMesh>();

		// Token: 0x04012FA6 RID: 77734
		public static readonly TransformMode[] TransformModeValues = new TransformMode[]
		{
			TransformMode.Normal,
			TransformMode.OnlyTranslation,
			TransformMode.NoRotationOrReflection,
			TransformMode.NoScale,
			TransformMode.NoScaleOrReflection
		};

		// Token: 0x020049D2 RID: 18898
		internal class Vertices
		{
			// Token: 0x04012FA7 RID: 77735
			public int[] bones;

			// Token: 0x04012FA8 RID: 77736
			public float[] vertices;
		}
	}
}
