using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049FE RID: 18942
	[Serializable]
	public class MeshGenerator
	{
		// Token: 0x1700242E RID: 9262
		// (get) Token: 0x0601B53C RID: 111932 RVA: 0x00868B75 File Offset: 0x00866F75
		public int VertexCount
		{
			get
			{
				return this.vertexBuffer.Count;
			}
		}

		// Token: 0x1700242F RID: 9263
		// (get) Token: 0x0601B53D RID: 111933 RVA: 0x00868B84 File Offset: 0x00866F84
		public MeshGeneratorBuffers Buffers
		{
			get
			{
				return new MeshGeneratorBuffers
				{
					vertexCount = this.VertexCount,
					vertexBuffer = this.vertexBuffer.Items,
					uvBuffer = this.uvBuffer.Items,
					colorBuffer = this.colorBuffer.Items,
					meshGenerator = this
				};
			}
		}

		// Token: 0x0601B53E RID: 111934 RVA: 0x00868BE8 File Offset: 0x00866FE8
		public static void GenerateSingleSubmeshInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Material material)
		{
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			int count = drawOrder.Count;
			instructionOutput.Clear();
			ExposedList<SubmeshInstruction> submeshInstructions = instructionOutput.submeshInstructions;
			submeshInstructions.Resize(1);
			instructionOutput.attachments.Resize(count);
			Attachment[] items = instructionOutput.attachments.Items;
			int num = 0;
			SubmeshInstruction submeshInstruction = new SubmeshInstruction
			{
				skeleton = skeleton,
				preActiveClippingSlotSource = -1,
				startSlot = 0,
				rawFirstVertexIndex = 0,
				material = material,
				forceSeparate = false,
				endSlot = count
			};
			bool hasActiveClipping = false;
			Slot[] items2 = drawOrder.Items;
			for (int i = 0; i < count; i++)
			{
				Slot slot = items2[i];
				Attachment attachment = slot.attachment;
				items[i] = attachment;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				int num2;
				int num3;
				if (regionAttachment != null)
				{
					num2 = 4;
					num3 = 6;
				}
				else
				{
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment != null)
					{
						num2 = meshAttachment.worldVerticesLength >> 1;
						num3 = meshAttachment.triangles.Length;
					}
					else
					{
						ClippingAttachment clippingAttachment = attachment as ClippingAttachment;
						if (clippingAttachment != null)
						{
							submeshInstruction.hasClipping = true;
							hasActiveClipping = true;
						}
						num2 = 0;
						num3 = 0;
					}
				}
				submeshInstruction.rawTriangleCount += num3;
				submeshInstruction.rawVertexCount += num2;
				num += num2;
			}
			instructionOutput.hasActiveClipping = hasActiveClipping;
			instructionOutput.rawVertexCount = num;
			submeshInstructions.Items[0] = submeshInstruction;
		}

		// Token: 0x0601B53F RID: 111935 RVA: 0x00868D60 File Offset: 0x00867160
		public static void GenerateSkeletonRendererInstruction(SkeletonRendererInstruction instructionOutput, Skeleton skeleton, Dictionary<Slot, Material> customSlotMaterials, List<Slot> separatorSlots, bool generateMeshOverride, bool immutableTriangles = false)
		{
			ExposedList<Slot> drawOrder = skeleton.drawOrder;
			int count = drawOrder.Count;
			instructionOutput.Clear();
			ExposedList<SubmeshInstruction> submeshInstructions = instructionOutput.submeshInstructions;
			instructionOutput.attachments.Resize(count);
			Attachment[] items = instructionOutput.attachments.Items;
			int num = 0;
			bool hasActiveClipping = false;
			SubmeshInstruction submeshInstruction = new SubmeshInstruction
			{
				skeleton = skeleton,
				preActiveClippingSlotSource = -1
			};
			bool flag = customSlotMaterials != null && customSlotMaterials.Count > 0;
			int num2 = (separatorSlots != null) ? separatorSlots.Count : 0;
			bool flag2 = num2 > 0;
			int num3 = -1;
			int preActiveClippingSlotSource = -1;
			SlotData slotData = null;
			int num4 = 0;
			Slot[] items2 = drawOrder.Items;
			for (int i = 0; i < count; i++)
			{
				Slot slot = items2[i];
				Attachment attachment = slot.attachment;
				items[i] = attachment;
				int num5 = 0;
				int num6 = 0;
				object obj = null;
				bool flag3 = false;
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				if (regionAttachment != null)
				{
					obj = regionAttachment.RendererObject;
					num5 = 4;
					num6 = 6;
				}
				else
				{
					MeshAttachment meshAttachment = attachment as MeshAttachment;
					if (meshAttachment != null)
					{
						obj = meshAttachment.RendererObject;
						num5 = meshAttachment.worldVerticesLength >> 1;
						num6 = meshAttachment.triangles.Length;
					}
					else
					{
						ClippingAttachment clippingAttachment = attachment as ClippingAttachment;
						if (clippingAttachment != null)
						{
							slotData = clippingAttachment.endSlot;
							num3 = i;
							submeshInstruction.hasClipping = true;
							hasActiveClipping = true;
						}
						flag3 = true;
					}
				}
				if (slotData != null && slot.data == slotData && i != num3)
				{
					slotData = null;
					num3 = -1;
				}
				if (flag2)
				{
					submeshInstruction.forceSeparate = false;
					for (int j = 0; j < num2; j++)
					{
						if (object.ReferenceEquals(slot, separatorSlots[j]))
						{
							submeshInstruction.forceSeparate = true;
							break;
						}
					}
				}
				if (flag3)
				{
					if (submeshInstruction.forceSeparate && generateMeshOverride)
					{
						submeshInstruction.endSlot = i;
						submeshInstruction.preActiveClippingSlotSource = preActiveClippingSlotSource;
						submeshInstructions.Resize(num4 + 1);
						submeshInstructions.Items[num4] = submeshInstruction;
						num4++;
						submeshInstruction.startSlot = i;
						preActiveClippingSlotSource = num3;
						submeshInstruction.rawTriangleCount = 0;
						submeshInstruction.rawVertexCount = 0;
						submeshInstruction.rawFirstVertexIndex = num;
						submeshInstruction.hasClipping = (num3 >= 0);
					}
				}
				else
				{
					Material material;
					if (flag)
					{
						if (!customSlotMaterials.TryGetValue(slot, out material))
						{
							material = (Material)((AtlasRegion)obj).page.rendererObject;
						}
					}
					else
					{
						material = (Material)((AtlasRegion)obj).page.rendererObject;
					}
					if (submeshInstruction.forceSeparate || (submeshInstruction.rawVertexCount > 0 && !object.ReferenceEquals(submeshInstruction.material, material)))
					{
						submeshInstruction.endSlot = i;
						submeshInstruction.preActiveClippingSlotSource = preActiveClippingSlotSource;
						submeshInstructions.Resize(num4 + 1);
						submeshInstructions.Items[num4] = submeshInstruction;
						num4++;
						submeshInstruction.startSlot = i;
						preActiveClippingSlotSource = num3;
						submeshInstruction.rawTriangleCount = 0;
						submeshInstruction.rawVertexCount = 0;
						submeshInstruction.rawFirstVertexIndex = num;
						submeshInstruction.hasClipping = (num3 >= 0);
					}
					submeshInstruction.material = material;
					submeshInstruction.rawTriangleCount += num6;
					submeshInstruction.rawVertexCount += num5;
					submeshInstruction.rawFirstVertexIndex = num;
					num += num5;
				}
			}
			if (submeshInstruction.rawVertexCount > 0)
			{
				submeshInstruction.endSlot = count;
				submeshInstruction.preActiveClippingSlotSource = preActiveClippingSlotSource;
				submeshInstruction.forceSeparate = false;
				submeshInstructions.Resize(num4 + 1);
				submeshInstructions.Items[num4] = submeshInstruction;
			}
			instructionOutput.hasActiveClipping = hasActiveClipping;
			instructionOutput.rawVertexCount = num;
			instructionOutput.immutableTriangles = immutableTriangles;
		}

		// Token: 0x0601B540 RID: 111936 RVA: 0x00869130 File Offset: 0x00867530
		public static void TryReplaceMaterials(ExposedList<SubmeshInstruction> workingSubmeshInstructions, Dictionary<Material, Material> customMaterialOverride)
		{
			SubmeshInstruction[] items = workingSubmeshInstructions.Items;
			for (int i = 0; i < workingSubmeshInstructions.Count; i++)
			{
				Material material = items[i].material;
				Material material2;
				if (customMaterialOverride.TryGetValue(material, out material2))
				{
					items[i].material = material2;
				}
			}
		}

		// Token: 0x0601B541 RID: 111937 RVA: 0x00869184 File Offset: 0x00867584
		public void Begin()
		{
			this.vertexBuffer.Clear(false);
			this.colorBuffer.Clear(false);
			this.uvBuffer.Clear(false);
			this.clipper.ClipEnd();
			this.meshBoundsMin.x = float.PositiveInfinity;
			this.meshBoundsMin.y = float.PositiveInfinity;
			this.meshBoundsMax.x = float.NegativeInfinity;
			this.meshBoundsMax.y = float.NegativeInfinity;
			this.meshBoundsThickness = 0f;
			this.submeshIndex = 0;
			this.submeshes.Count = 1;
		}

		// Token: 0x0601B542 RID: 111938 RVA: 0x00869220 File Offset: 0x00867620
		public void AddSubmesh(SubmeshInstruction instruction, bool updateTriangles = true)
		{
			MeshGenerator.Settings settings = this.settings;
			if (this.submeshes.Count - 1 < this.submeshIndex)
			{
				this.submeshes.Resize(this.submeshIndex + 1);
				if (this.submeshes.Items[this.submeshIndex] == null)
				{
					this.submeshes.Items[this.submeshIndex] = new ExposedList<int>();
				}
			}
			ExposedList<int> exposedList = this.submeshes.Items[this.submeshIndex];
			exposedList.Clear(false);
			Skeleton skeleton = instruction.skeleton;
			Slot[] items = skeleton.drawOrder.Items;
			Color32 color = default(Color32);
			float num = skeleton.a * 255f;
			float r = skeleton.r;
			float g = skeleton.g;
			float b = skeleton.b;
			Vector2 vector = this.meshBoundsMin;
			Vector2 vector2 = this.meshBoundsMax;
			float zSpacing = settings.zSpacing;
			bool pmaVertexColors = settings.pmaVertexColors;
			bool tintBlack = settings.tintBlack;
			bool flag = settings.useClipping && instruction.hasClipping;
			if (flag && instruction.preActiveClippingSlotSource >= 0)
			{
				Slot slot = items[instruction.preActiveClippingSlotSource];
				this.clipper.ClipStart(slot, slot.attachment as ClippingAttachment);
			}
			int i = instruction.startSlot;
			while (i < instruction.endSlot)
			{
				Slot slot2 = items[i];
				Attachment attachment = slot2.attachment;
				float z = zSpacing * (float)i;
				float[] array = this.tempVerts;
				Color color2 = default(Color);
				RegionAttachment regionAttachment = attachment as RegionAttachment;
				float[] array2;
				int[] array3;
				int num2;
				int num3;
				if (regionAttachment != null)
				{
					regionAttachment.ComputeWorldVertices(slot2.bone, array, 0, 2);
					array2 = regionAttachment.uvs;
					array3 = this.regionTriangles;
					color2.r = regionAttachment.r;
					color2.g = regionAttachment.g;
					color2.b = regionAttachment.b;
					color2.a = regionAttachment.a;
					num2 = 4;
					num3 = 6;
					goto IL_2CF;
				}
				MeshAttachment meshAttachment = attachment as MeshAttachment;
				if (meshAttachment != null)
				{
					int worldVerticesLength = meshAttachment.worldVerticesLength;
					if (array.Length < worldVerticesLength)
					{
						array = new float[worldVerticesLength];
						this.tempVerts = array;
					}
					meshAttachment.ComputeWorldVertices(slot2, 0, worldVerticesLength, array, 0, 2);
					array2 = meshAttachment.uvs;
					array3 = meshAttachment.triangles;
					color2.r = meshAttachment.r;
					color2.g = meshAttachment.g;
					color2.b = meshAttachment.b;
					color2.a = meshAttachment.a;
					num2 = worldVerticesLength >> 1;
					num3 = meshAttachment.triangles.Length;
					goto IL_2CF;
				}
				if (flag)
				{
					ClippingAttachment clippingAttachment = attachment as ClippingAttachment;
					if (clippingAttachment != null)
					{
						this.clipper.ClipStart(slot2, clippingAttachment);
						goto IL_7DB;
					}
				}
				this.clipper.ClipEnd(slot2);
				IL_7DB:
				i++;
				continue;
				IL_2CF:
				if (pmaVertexColors)
				{
					color.a = (byte)(num * slot2.a * color2.a);
					color.r = (byte)(r * slot2.r * color2.r * (float)color.a);
					color.g = (byte)(g * slot2.g * color2.g * (float)color.a);
					color.b = (byte)(b * slot2.b * color2.b * (float)color.a);
					if (slot2.data.blendMode == BlendMode.Additive)
					{
						color.a = 0;
					}
				}
				else
				{
					color.a = (byte)(num * slot2.a * color2.a);
					color.r = (byte)(r * slot2.r * color2.r * 255f);
					color.g = (byte)(g * slot2.g * color2.g * 255f);
					color.b = (byte)(b * slot2.b * color2.b * 255f);
				}
				if (flag && this.clipper.IsClipping)
				{
					this.clipper.ClipTriangles(array, num2 << 1, array3, num3, array2);
					array = this.clipper.clippedVertices.Items;
					num2 = this.clipper.clippedVertices.Count >> 1;
					array3 = this.clipper.clippedTriangles.Items;
					num3 = this.clipper.clippedTriangles.Count;
					array2 = this.clipper.clippedUVs.Items;
				}
				if (num2 != 0 && num3 != 0)
				{
					if (tintBlack)
					{
						this.AddAttachmentTintBlack(slot2.r2, slot2.g2, slot2.b2, num2);
					}
					int count = this.vertexBuffer.Count;
					int num4 = count + num2;
					if (num4 > this.vertexBuffer.Items.Length)
					{
						Array.Resize<Vector3>(ref this.vertexBuffer.Items, num4);
						Array.Resize<Vector2>(ref this.uvBuffer.Items, num4);
						Array.Resize<Color32>(ref this.colorBuffer.Items, num4);
					}
					this.vertexBuffer.Count = (this.uvBuffer.Count = (this.colorBuffer.Count = num4));
					Vector3[] items2 = this.vertexBuffer.Items;
					Vector2[] items3 = this.uvBuffer.Items;
					Color32[] items4 = this.colorBuffer.Items;
					if (count == 0)
					{
						for (int j = 0; j < num2; j++)
						{
							int num5 = count + j;
							int num6 = j << 1;
							float num7 = array[num6];
							float num8 = array[num6 + 1];
							items2[num5].x = num7;
							items2[num5].y = num8;
							items2[num5].z = z;
							items3[num5].x = array2[num6];
							items3[num5].y = array2[num6 + 1];
							items4[num5] = color;
							if (num7 < vector.x)
							{
								vector.x = num7;
							}
							if (num7 > vector2.x)
							{
								vector2.x = num7;
							}
							if (num8 < vector.y)
							{
								vector.y = num8;
							}
							if (num8 > vector2.y)
							{
								vector2.y = num8;
							}
						}
					}
					else
					{
						for (int k = 0; k < num2; k++)
						{
							int num9 = count + k;
							int num10 = k << 1;
							float num11 = array[num10];
							float num12 = array[num10 + 1];
							items2[num9].x = num11;
							items2[num9].y = num12;
							items2[num9].z = z;
							items3[num9].x = array2[num10];
							items3[num9].y = array2[num10 + 1];
							items4[num9] = color;
							if (num11 < vector.x)
							{
								vector.x = num11;
							}
							else if (num11 > vector2.x)
							{
								vector2.x = num11;
							}
							if (num12 < vector.y)
							{
								vector.y = num12;
							}
							else if (num12 > vector2.y)
							{
								vector2.y = num12;
							}
						}
					}
					if (updateTriangles)
					{
						int count2 = exposedList.Count;
						int num13 = count2 + num3;
						if (num13 > exposedList.Items.Length)
						{
							Array.Resize<int>(ref exposedList.Items, num13);
						}
						exposedList.Count = num13;
						int[] items5 = exposedList.Items;
						for (int l = 0; l < num3; l++)
						{
							items5[count2 + l] = array3[l] + count;
						}
					}
				}
				this.clipper.ClipEnd(slot2);
				goto IL_7DB;
			}
			this.clipper.ClipEnd();
			this.meshBoundsMin = vector;
			this.meshBoundsMax = vector2;
			this.meshBoundsThickness = (float)instruction.endSlot * zSpacing;
			int[] items6 = exposedList.Items;
			int m = exposedList.Count;
			int num14 = items6.Length;
			while (m < num14)
			{
				items6[m] = 0;
				m++;
			}
			this.submeshIndex++;
		}

		// Token: 0x0601B543 RID: 111939 RVA: 0x00869A88 File Offset: 0x00867E88
		public void BuildMesh(SkeletonRendererInstruction instruction, bool updateTriangles)
		{
			SubmeshInstruction[] items = instruction.submeshInstructions.Items;
			int i = 0;
			int count = instruction.submeshInstructions.Count;
			while (i < count)
			{
				this.AddSubmesh(items[i], updateTriangles);
				i++;
			}
		}

		// Token: 0x0601B544 RID: 111940 RVA: 0x00869AD4 File Offset: 0x00867ED4
		public void BuildMeshWithArrays(SkeletonRendererInstruction instruction, bool updateTriangles)
		{
			MeshGenerator.Settings settings = this.settings;
			int rawVertexCount = instruction.rawVertexCount;
			if (rawVertexCount > this.vertexBuffer.Items.Length)
			{
				Array.Resize<Vector3>(ref this.vertexBuffer.Items, rawVertexCount);
				Array.Resize<Vector2>(ref this.uvBuffer.Items, rawVertexCount);
				Array.Resize<Color32>(ref this.colorBuffer.Items, rawVertexCount);
			}
			this.vertexBuffer.Count = (this.uvBuffer.Count = (this.colorBuffer.Count = rawVertexCount));
			Color32 color = default(Color32);
			int num = 0;
			float[] array = this.tempVerts;
			Vector3 vector = this.meshBoundsMin;
			Vector3 vector2 = this.meshBoundsMax;
			Vector3[] items = this.vertexBuffer.Items;
			Vector2[] items2 = this.uvBuffer.Items;
			Color32[] items3 = this.colorBuffer.Items;
			int num2 = 0;
			int i = 0;
			int count = instruction.submeshInstructions.Count;
			while (i < count)
			{
				SubmeshInstruction submeshInstruction = instruction.submeshInstructions.Items[i];
				Skeleton skeleton = submeshInstruction.skeleton;
				Slot[] items4 = skeleton.drawOrder.Items;
				float num3 = skeleton.a * 255f;
				float r = skeleton.r;
				float g = skeleton.g;
				float b = skeleton.b;
				int endSlot = submeshInstruction.endSlot;
				int startSlot = submeshInstruction.startSlot;
				num2 = endSlot;
				if (settings.tintBlack)
				{
					int num4 = num;
					Vector2 vector3;
					vector3.y = 1f;
					if (this.uv2 == null)
					{
						this.uv2 = new ExposedList<Vector2>();
						this.uv3 = new ExposedList<Vector2>();
					}
					if (rawVertexCount > this.uv2.Items.Length)
					{
						Array.Resize<Vector2>(ref this.uv2.Items, rawVertexCount);
						Array.Resize<Vector2>(ref this.uv3.Items, rawVertexCount);
					}
					this.uv2.Count = (this.uv3.Count = rawVertexCount);
					Vector2[] items5 = this.uv2.Items;
					Vector2[] items6 = this.uv3.Items;
					for (int j = startSlot; j < endSlot; j++)
					{
						Slot slot = items4[j];
						Attachment attachment = slot.attachment;
						Vector2 vector4;
						vector4.x = slot.r2;
						vector4.y = slot.g2;
						vector3.x = slot.b2;
						RegionAttachment regionAttachment = attachment as RegionAttachment;
						if (regionAttachment != null)
						{
							items5[num4] = vector4;
							items5[num4 + 1] = vector4;
							items5[num4 + 2] = vector4;
							items5[num4 + 3] = vector4;
							items6[num4] = vector3;
							items6[num4 + 1] = vector3;
							items6[num4 + 2] = vector3;
							items6[num4 + 3] = vector3;
							num4 += 4;
						}
						else
						{
							MeshAttachment meshAttachment = attachment as MeshAttachment;
							if (meshAttachment != null)
							{
								int worldVerticesLength = meshAttachment.worldVerticesLength;
								for (int k = 0; k < worldVerticesLength; k += 2)
								{
									items5[num4] = vector4;
									items6[num4] = vector3;
									num4++;
								}
							}
						}
					}
				}
				for (int l = startSlot; l < endSlot; l++)
				{
					Slot slot2 = items4[l];
					Attachment attachment2 = slot2.attachment;
					float z = (float)l * settings.zSpacing;
					RegionAttachment regionAttachment2 = attachment2 as RegionAttachment;
					if (regionAttachment2 != null)
					{
						regionAttachment2.ComputeWorldVertices(slot2.bone, array, 0, 2);
						float num5 = array[0];
						float num6 = array[1];
						float num7 = array[2];
						float num8 = array[3];
						float num9 = array[4];
						float num10 = array[5];
						float num11 = array[6];
						float num12 = array[7];
						items[num].x = num5;
						items[num].y = num6;
						items[num].z = z;
						items[num + 1].x = num11;
						items[num + 1].y = num12;
						items[num + 1].z = z;
						items[num + 2].x = num7;
						items[num + 2].y = num8;
						items[num + 2].z = z;
						items[num + 3].x = num9;
						items[num + 3].y = num10;
						items[num + 3].z = z;
						if (settings.pmaVertexColors)
						{
							color.a = (byte)(num3 * slot2.a * regionAttachment2.a);
							color.r = (byte)(r * slot2.r * regionAttachment2.r * (float)color.a);
							color.g = (byte)(g * slot2.g * regionAttachment2.g * (float)color.a);
							color.b = (byte)(b * slot2.b * regionAttachment2.b * (float)color.a);
							if (slot2.data.blendMode == BlendMode.Additive)
							{
								color.a = 0;
							}
						}
						else
						{
							color.a = (byte)(num3 * slot2.a * regionAttachment2.a);
							color.r = (byte)(r * slot2.r * regionAttachment2.r * 255f);
							color.g = (byte)(g * slot2.g * regionAttachment2.g * 255f);
							color.b = (byte)(b * slot2.b * regionAttachment2.b * 255f);
						}
						items3[num] = color;
						items3[num + 1] = color;
						items3[num + 2] = color;
						items3[num + 3] = color;
						float[] uvs = regionAttachment2.uvs;
						items2[num].x = uvs[0];
						items2[num].y = uvs[1];
						items2[num + 1].x = uvs[6];
						items2[num + 1].y = uvs[7];
						items2[num + 2].x = uvs[2];
						items2[num + 2].y = uvs[3];
						items2[num + 3].x = uvs[4];
						items2[num + 3].y = uvs[5];
						if (num5 < vector.x)
						{
							vector.x = num5;
						}
						if (num5 > vector2.x)
						{
							vector2.x = num5;
						}
						if (num7 < vector.x)
						{
							vector.x = num7;
						}
						else if (num7 > vector2.x)
						{
							vector2.x = num7;
						}
						if (num9 < vector.x)
						{
							vector.x = num9;
						}
						else if (num9 > vector2.x)
						{
							vector2.x = num9;
						}
						if (num11 < vector.x)
						{
							vector.x = num11;
						}
						else if (num11 > vector2.x)
						{
							vector2.x = num11;
						}
						if (num6 < vector.y)
						{
							vector.y = num6;
						}
						if (num6 > vector2.y)
						{
							vector2.y = num6;
						}
						if (num8 < vector.y)
						{
							vector.y = num8;
						}
						else if (num8 > vector2.y)
						{
							vector2.y = num8;
						}
						if (num10 < vector.y)
						{
							vector.y = num10;
						}
						else if (num10 > vector2.y)
						{
							vector2.y = num10;
						}
						if (num12 < vector.y)
						{
							vector.y = num12;
						}
						else if (num12 > vector2.y)
						{
							vector2.y = num12;
						}
						num += 4;
					}
					else
					{
						MeshAttachment meshAttachment2 = attachment2 as MeshAttachment;
						if (meshAttachment2 != null)
						{
							int worldVerticesLength2 = meshAttachment2.worldVerticesLength;
							if (array.Length < worldVerticesLength2)
							{
								array = (this.tempVerts = new float[worldVerticesLength2]);
							}
							meshAttachment2.ComputeWorldVertices(slot2, array);
							if (settings.pmaVertexColors)
							{
								color.a = (byte)(num3 * slot2.a * meshAttachment2.a);
								color.r = (byte)(r * slot2.r * meshAttachment2.r * (float)color.a);
								color.g = (byte)(g * slot2.g * meshAttachment2.g * (float)color.a);
								color.b = (byte)(b * slot2.b * meshAttachment2.b * (float)color.a);
								if (slot2.data.blendMode == BlendMode.Additive)
								{
									color.a = 0;
								}
							}
							else
							{
								color.a = (byte)(num3 * slot2.a * meshAttachment2.a);
								color.r = (byte)(r * slot2.r * meshAttachment2.r * 255f);
								color.g = (byte)(g * slot2.g * meshAttachment2.g * 255f);
								color.b = (byte)(b * slot2.b * meshAttachment2.b * 255f);
							}
							float[] uvs2 = meshAttachment2.uvs;
							if (num == 0)
							{
								float num13 = array[0];
								float num14 = array[1];
								if (num13 < vector.x)
								{
									vector.x = num13;
								}
								if (num13 > vector2.x)
								{
									vector2.x = num13;
								}
								if (num14 < vector.y)
								{
									vector.y = num14;
								}
								if (num14 > vector2.y)
								{
									vector2.y = num14;
								}
							}
							for (int m = 0; m < worldVerticesLength2; m += 2)
							{
								float num15 = array[m];
								float num16 = array[m + 1];
								items[num].x = num15;
								items[num].y = num16;
								items[num].z = z;
								items3[num] = color;
								items2[num].x = uvs2[m];
								items2[num].y = uvs2[m + 1];
								if (num15 < vector.x)
								{
									vector.x = num15;
								}
								else if (num15 > vector2.x)
								{
									vector2.x = num15;
								}
								if (num16 < vector.y)
								{
									vector.y = num16;
								}
								else if (num16 > vector2.y)
								{
									vector2.y = num16;
								}
								num++;
							}
						}
					}
				}
				i++;
			}
			this.meshBoundsMin = vector;
			this.meshBoundsMax = vector2;
			this.meshBoundsThickness = (float)num2 * settings.zSpacing;
			if (updateTriangles)
			{
				int count2 = instruction.submeshInstructions.Count;
				if (this.submeshes.Count < count2)
				{
					this.submeshes.Resize(count2);
					int n = 0;
					int num17 = count2;
					while (n < num17)
					{
						ExposedList<int> exposedList = this.submeshes.Items[n];
						if (exposedList == null)
						{
							this.submeshes.Items[n] = new ExposedList<int>();
						}
						else
						{
							exposedList.Clear(false);
						}
						n++;
					}
				}
				SubmeshInstruction[] items7 = instruction.submeshInstructions.Items;
				int num18 = 0;
				for (int num19 = 0; num19 < count2; num19++)
				{
					SubmeshInstruction submeshInstruction2 = items7[num19];
					ExposedList<int> exposedList2 = this.submeshes.Items[num19];
					int rawTriangleCount = submeshInstruction2.rawTriangleCount;
					if (rawTriangleCount > exposedList2.Items.Length)
					{
						Array.Resize<int>(ref exposedList2.Items, rawTriangleCount);
					}
					else if (rawTriangleCount < exposedList2.Items.Length)
					{
						int[] items8 = exposedList2.Items;
						int num20 = rawTriangleCount;
						int num21 = items8.Length;
						while (num20 < num21)
						{
							items8[num20] = 0;
							num20++;
						}
					}
					exposedList2.Count = rawTriangleCount;
					int[] items9 = exposedList2.Items;
					int num22 = 0;
					Skeleton skeleton2 = submeshInstruction2.skeleton;
					Slot[] items10 = skeleton2.drawOrder.Items;
					int num23 = submeshInstruction2.startSlot;
					int endSlot2 = submeshInstruction2.endSlot;
					while (num23 < endSlot2)
					{
						Attachment attachment3 = items10[num23].attachment;
						if (attachment3 is RegionAttachment)
						{
							items9[num22] = num18;
							items9[num22 + 1] = num18 + 2;
							items9[num22 + 2] = num18 + 1;
							items9[num22 + 3] = num18 + 2;
							items9[num22 + 4] = num18 + 3;
							items9[num22 + 5] = num18 + 1;
							num22 += 6;
							num18 += 4;
						}
						else
						{
							MeshAttachment meshAttachment3 = attachment3 as MeshAttachment;
							if (meshAttachment3 != null)
							{
								int[] triangles = meshAttachment3.triangles;
								int num24 = 0;
								int num25 = triangles.Length;
								while (num24 < num25)
								{
									items9[num22] = num18 + triangles[num24];
									num24++;
									num22++;
								}
								num18 += meshAttachment3.worldVerticesLength >> 1;
							}
						}
						num23++;
					}
				}
			}
		}

		// Token: 0x0601B545 RID: 111941 RVA: 0x0086A88C File Offset: 0x00868C8C
		public void ScaleVertexData(float scale)
		{
			Vector3[] items = this.vertexBuffer.Items;
			int i = 0;
			int count = this.vertexBuffer.Count;
			while (i < count)
			{
				items[i] *= scale;
				i++;
			}
			this.meshBoundsMin *= scale;
			this.meshBoundsMax *= scale;
			this.meshBoundsThickness *= scale;
		}

		// Token: 0x0601B546 RID: 111942 RVA: 0x0086A910 File Offset: 0x00868D10
		private void AddAttachmentTintBlack(float r2, float g2, float b2, int vertexCount)
		{
			Vector2 vector;
			vector..ctor(r2, g2);
			Vector2 vector2;
			vector2..ctor(b2, 1f);
			int count = this.vertexBuffer.Count;
			int num = count + vertexCount;
			if (this.uv2 == null)
			{
				this.uv2 = new ExposedList<Vector2>();
				this.uv3 = new ExposedList<Vector2>();
			}
			if (num > this.uv2.Items.Length)
			{
				Array.Resize<Vector2>(ref this.uv2.Items, num);
				Array.Resize<Vector2>(ref this.uv3.Items, num);
			}
			this.uv2.Count = (this.uv3.Count = num);
			Vector2[] items = this.uv2.Items;
			Vector2[] items2 = this.uv3.Items;
			for (int i = 0; i < vertexCount; i++)
			{
				items[count + i] = vector;
				items2[count + i] = vector2;
			}
		}

		// Token: 0x0601B547 RID: 111943 RVA: 0x0086AA0C File Offset: 0x00868E0C
		public void FillVertexData(Mesh mesh)
		{
			Vector3[] items = this.vertexBuffer.Items;
			Vector2[] items2 = this.uvBuffer.Items;
			Color32[] items3 = this.colorBuffer.Items;
			int count = this.vertexBuffer.Count;
			int num = this.vertexBuffer.Items.Length;
			Vector3 zero = Vector3.zero;
			for (int i = count; i < num; i++)
			{
				items[i] = zero;
			}
			mesh.vertices = items;
			mesh.uv = items2;
			mesh.colors32 = items3;
			if (float.IsInfinity(this.meshBoundsMin.x))
			{
				mesh.bounds = default(Bounds);
			}
			else
			{
				Vector2 vector = (this.meshBoundsMax - this.meshBoundsMin) * 0.5f;
				Bounds bounds = default(Bounds);
				bounds.center = this.meshBoundsMin + vector;
				bounds.extents = new Vector3(vector.x, vector.y, this.meshBoundsThickness * 0.5f);
				mesh.bounds = bounds;
			}
			int count2 = this.vertexBuffer.Count;
			if (this.settings.addNormals)
			{
				int num2 = 0;
				if (this.normals == null)
				{
					this.normals = new Vector3[count2];
				}
				else
				{
					num2 = this.normals.Length;
				}
				if (num2 < count2)
				{
					Array.Resize<Vector3>(ref this.normals, count2);
					Vector3[] array = this.normals;
					for (int j = num2; j < count2; j++)
					{
						array[j] = Vector3.back;
					}
				}
				mesh.normals = this.normals;
			}
			if (this.settings.tintBlack && this.uv2 != null)
			{
				mesh.uv2 = this.uv2.Items;
				mesh.uv3 = this.uv3.Items;
			}
		}

		// Token: 0x0601B548 RID: 111944 RVA: 0x0086AC0C File Offset: 0x0086900C
		public void FillLateVertexData(Mesh mesh)
		{
			if (this.settings.calculateTangents)
			{
				int count = this.vertexBuffer.Count;
				ExposedList<int>[] items = this.submeshes.Items;
				int count2 = this.submeshes.Count;
				Vector3[] items2 = this.vertexBuffer.Items;
				Vector2[] items3 = this.uvBuffer.Items;
				MeshGenerator.SolveTangents2DEnsureSize(ref this.tangents, ref this.tempTanBuffer, count);
				for (int i = 0; i < count2; i++)
				{
					int[] items4 = items[i].Items;
					int count3 = items[i].Count;
					MeshGenerator.SolveTangents2DTriangles(this.tempTanBuffer, items4, count3, items2, items3, count);
				}
				MeshGenerator.SolveTangents2DBuffer(this.tangents, this.tempTanBuffer, count);
				mesh.tangents = this.tangents;
			}
		}

		// Token: 0x0601B549 RID: 111945 RVA: 0x0086ACD8 File Offset: 0x008690D8
		public void FillTriangles(Mesh mesh)
		{
			int count = this.submeshes.Count;
			ExposedList<int>[] items = this.submeshes.Items;
			mesh.subMeshCount = count;
			for (int i = 0; i < count; i++)
			{
				mesh.SetTriangles(items[i].Items, i, false);
			}
		}

		// Token: 0x0601B54A RID: 111946 RVA: 0x0086AD26 File Offset: 0x00869126
		public void FillTrianglesSingle(Mesh mesh)
		{
			mesh.SetTriangles(this.submeshes.Items[0].Items, 0, false);
		}

		// Token: 0x0601B54B RID: 111947 RVA: 0x0086AD44 File Offset: 0x00869144
		public void TrimExcess()
		{
			this.vertexBuffer.TrimExcess();
			this.uvBuffer.TrimExcess();
			this.colorBuffer.TrimExcess();
			if (this.uv2 != null)
			{
				this.uv2.TrimExcess();
			}
			if (this.uv3 != null)
			{
				this.uv3.TrimExcess();
			}
			int count = this.vertexBuffer.Count;
			if (this.normals != null)
			{
				Array.Resize<Vector3>(ref this.normals, count);
			}
			if (this.tangents != null)
			{
				Array.Resize<Vector4>(ref this.tangents, count);
			}
		}

		// Token: 0x0601B54C RID: 111948 RVA: 0x0086ADD8 File Offset: 0x008691D8
		internal static void SolveTangents2DEnsureSize(ref Vector4[] tangentBuffer, ref Vector2[] tempTanBuffer, int vertexCount)
		{
			if (tangentBuffer == null || tangentBuffer.Length < vertexCount)
			{
				tangentBuffer = new Vector4[vertexCount];
			}
			if (tempTanBuffer == null || tempTanBuffer.Length < vertexCount * 2)
			{
				tempTanBuffer = new Vector2[vertexCount * 2];
			}
		}

		// Token: 0x0601B54D RID: 111949 RVA: 0x0086AE10 File Offset: 0x00869210
		internal static void SolveTangents2DTriangles(Vector2[] tempTanBuffer, int[] triangles, int triangleCount, Vector3[] vertices, Vector2[] uvs, int vertexCount)
		{
			for (int i = 0; i < triangleCount; i += 3)
			{
				int num = triangles[i];
				int num2 = triangles[i + 1];
				int num3 = triangles[i + 2];
				Vector3 vector = vertices[num];
				Vector3 vector2 = vertices[num2];
				Vector3 vector3 = vertices[num3];
				Vector2 vector4 = uvs[num];
				Vector2 vector5 = uvs[num2];
				Vector2 vector6 = uvs[num3];
				float num4 = vector2.x - vector.x;
				float num5 = vector3.x - vector.x;
				float num6 = vector2.y - vector.y;
				float num7 = vector3.y - vector.y;
				float num8 = vector5.x - vector4.x;
				float num9 = vector6.x - vector4.x;
				float num10 = vector5.y - vector4.y;
				float num11 = vector6.y - vector4.y;
				float num12 = num8 * num11 - num9 * num10;
				float num13 = (num12 != 0f) ? (1f / num12) : 0f;
				Vector2 vector7;
				vector7.x = (num11 * num4 - num10 * num5) * num13;
				vector7.y = (num11 * num6 - num10 * num7) * num13;
				tempTanBuffer[num] = (tempTanBuffer[num2] = (tempTanBuffer[num3] = vector7));
				Vector2 vector8;
				vector8.x = (num8 * num5 - num9 * num4) * num13;
				vector8.y = (num8 * num7 - num9 * num6) * num13;
				tempTanBuffer[vertexCount + num] = (tempTanBuffer[vertexCount + num2] = (tempTanBuffer[vertexCount + num3] = vector8));
			}
		}

		// Token: 0x0601B54E RID: 111950 RVA: 0x0086B010 File Offset: 0x00869410
		internal static void SolveTangents2DBuffer(Vector4[] tangents, Vector2[] tempTanBuffer, int vertexCount)
		{
			Vector4 vector;
			vector.z = 0f;
			for (int i = 0; i < vertexCount; i++)
			{
				Vector2 vector2 = tempTanBuffer[i];
				float num = Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y);
				if ((double)num > 1E-05)
				{
					float num2 = 1f / num;
					vector2.x *= num2;
					vector2.y *= num2;
				}
				Vector2 vector3 = tempTanBuffer[vertexCount + i];
				vector.x = vector2.x;
				vector.y = vector2.y;
				vector.w = (float)((vector2.y * vector3.x <= vector2.x * vector3.y) ? -1 : 1);
				tangents[i] = vector;
			}
		}

		// Token: 0x0601B54F RID: 111951 RVA: 0x0086B114 File Offset: 0x00869514
		public static void FillMeshLocal(Mesh mesh, RegionAttachment regionAttachment)
		{
			if (mesh == null)
			{
				return;
			}
			if (regionAttachment == null)
			{
				return;
			}
			MeshGenerator.AttachmentVerts.Clear();
			float[] offset = regionAttachment.Offset;
			MeshGenerator.AttachmentVerts.Add(new Vector3(offset[0], offset[1]));
			MeshGenerator.AttachmentVerts.Add(new Vector3(offset[2], offset[3]));
			MeshGenerator.AttachmentVerts.Add(new Vector3(offset[4], offset[5]));
			MeshGenerator.AttachmentVerts.Add(new Vector3(offset[6], offset[7]));
			MeshGenerator.AttachmentUVs.Clear();
			float[] uvs = regionAttachment.UVs;
			MeshGenerator.AttachmentUVs.Add(new Vector2(uvs[2], uvs[3]));
			MeshGenerator.AttachmentUVs.Add(new Vector2(uvs[4], uvs[5]));
			MeshGenerator.AttachmentUVs.Add(new Vector2(uvs[6], uvs[7]));
			MeshGenerator.AttachmentUVs.Add(new Vector2(uvs[0], uvs[1]));
			MeshGenerator.AttachmentColors32.Clear();
			Color32 item = new Color(regionAttachment.r, regionAttachment.g, regionAttachment.b, regionAttachment.a);
			for (int i = 0; i < 4; i++)
			{
				MeshGenerator.AttachmentColors32.Add(item);
			}
			MeshGenerator.AttachmentIndices.Clear();
			MeshGenerator.AttachmentIndices.AddRange(new int[]
			{
				0,
				2,
				1,
				0,
				3,
				2
			});
			mesh.Clear();
			mesh.name = regionAttachment.Name;
			mesh.SetVertices(MeshGenerator.AttachmentVerts);
			mesh.SetUVs(0, MeshGenerator.AttachmentUVs);
			mesh.SetColors(MeshGenerator.AttachmentColors32);
			mesh.SetTriangles(MeshGenerator.AttachmentIndices, 0);
			mesh.RecalculateBounds();
			MeshGenerator.AttachmentVerts.Clear();
			MeshGenerator.AttachmentUVs.Clear();
			MeshGenerator.AttachmentColors32.Clear();
			MeshGenerator.AttachmentIndices.Clear();
		}

		// Token: 0x0601B550 RID: 111952 RVA: 0x0086B2DC File Offset: 0x008696DC
		public static void FillMeshLocal(Mesh mesh, MeshAttachment meshAttachment, SkeletonData skeletonData)
		{
			if (mesh == null)
			{
				return;
			}
			if (meshAttachment == null)
			{
				return;
			}
			int num = meshAttachment.WorldVerticesLength / 2;
			MeshGenerator.AttachmentVerts.Clear();
			if (meshAttachment.IsWeighted())
			{
				int worldVerticesLength = meshAttachment.WorldVerticesLength;
				int[] bones = meshAttachment.bones;
				int i = 0;
				float[] vertices = meshAttachment.vertices;
				int j = 0;
				int num2 = 0;
				while (j < worldVerticesLength)
				{
					float num3 = 0f;
					float num4 = 0f;
					int num5 = bones[i++];
					num5 += i;
					while (i < num5)
					{
						BoneMatrix boneMatrix = BoneMatrix.CalculateSetupWorld(skeletonData.bones.Items[bones[i]]);
						float num6 = vertices[num2];
						float num7 = vertices[num2 + 1];
						float num8 = vertices[num2 + 2];
						num3 += (num6 * boneMatrix.a + num7 * boneMatrix.b + boneMatrix.x) * num8;
						num4 += (num6 * boneMatrix.c + num7 * boneMatrix.d + boneMatrix.y) * num8;
						i++;
						num2 += 3;
					}
					MeshGenerator.AttachmentVerts.Add(new Vector3(num3, num4));
					j += 2;
				}
			}
			else
			{
				float[] vertices2 = meshAttachment.Vertices;
				Vector3 item = default(Vector3);
				for (int k = 0; k < num; k++)
				{
					int num9 = k * 2;
					item.x = vertices2[num9];
					item.y = vertices2[num9 + 1];
					MeshGenerator.AttachmentVerts.Add(item);
				}
			}
			float[] uvs = meshAttachment.uvs;
			Vector2 item2 = default(Vector2);
			Color32 item3 = new Color(meshAttachment.r, meshAttachment.g, meshAttachment.b, meshAttachment.a);
			MeshGenerator.AttachmentUVs.Clear();
			MeshGenerator.AttachmentColors32.Clear();
			for (int l = 0; l < num; l++)
			{
				int num10 = l * 2;
				item2.x = uvs[num10];
				item2.y = uvs[num10 + 1];
				MeshGenerator.AttachmentUVs.Add(item2);
				MeshGenerator.AttachmentColors32.Add(item3);
			}
			MeshGenerator.AttachmentIndices.Clear();
			MeshGenerator.AttachmentIndices.AddRange(meshAttachment.triangles);
			mesh.Clear();
			mesh.name = meshAttachment.Name;
			mesh.SetVertices(MeshGenerator.AttachmentVerts);
			mesh.SetUVs(0, MeshGenerator.AttachmentUVs);
			mesh.SetColors(MeshGenerator.AttachmentColors32);
			mesh.SetTriangles(MeshGenerator.AttachmentIndices, 0);
			mesh.RecalculateBounds();
			MeshGenerator.AttachmentVerts.Clear();
			MeshGenerator.AttachmentUVs.Clear();
			MeshGenerator.AttachmentColors32.Clear();
			MeshGenerator.AttachmentIndices.Clear();
		}

		// Token: 0x04013086 RID: 77958
		public MeshGenerator.Settings settings = MeshGenerator.Settings.Default;

		// Token: 0x04013087 RID: 77959
		private const float BoundsMinDefault = float.PositiveInfinity;

		// Token: 0x04013088 RID: 77960
		private const float BoundsMaxDefault = float.NegativeInfinity;

		// Token: 0x04013089 RID: 77961
		[NonSerialized]
		private readonly ExposedList<Vector3> vertexBuffer = new ExposedList<Vector3>(4);

		// Token: 0x0401308A RID: 77962
		[NonSerialized]
		private readonly ExposedList<Vector2> uvBuffer = new ExposedList<Vector2>(4);

		// Token: 0x0401308B RID: 77963
		[NonSerialized]
		private readonly ExposedList<Color32> colorBuffer = new ExposedList<Color32>(4);

		// Token: 0x0401308C RID: 77964
		[NonSerialized]
		private readonly ExposedList<ExposedList<int>> submeshes = new ExposedList<ExposedList<int>>
		{
			new ExposedList<int>(6)
		};

		// Token: 0x0401308D RID: 77965
		[NonSerialized]
		private Vector2 meshBoundsMin;

		// Token: 0x0401308E RID: 77966
		[NonSerialized]
		private Vector2 meshBoundsMax;

		// Token: 0x0401308F RID: 77967
		[NonSerialized]
		private float meshBoundsThickness;

		// Token: 0x04013090 RID: 77968
		[NonSerialized]
		private int submeshIndex;

		// Token: 0x04013091 RID: 77969
		[NonSerialized]
		private SkeletonClipping clipper = new SkeletonClipping();

		// Token: 0x04013092 RID: 77970
		[NonSerialized]
		private float[] tempVerts = new float[8];

		// Token: 0x04013093 RID: 77971
		[NonSerialized]
		private int[] regionTriangles = new int[]
		{
			0,
			1,
			2,
			2,
			3,
			0
		};

		// Token: 0x04013094 RID: 77972
		[NonSerialized]
		private Vector3[] normals;

		// Token: 0x04013095 RID: 77973
		[NonSerialized]
		private Vector4[] tangents;

		// Token: 0x04013096 RID: 77974
		[NonSerialized]
		private Vector2[] tempTanBuffer;

		// Token: 0x04013097 RID: 77975
		[NonSerialized]
		private ExposedList<Vector2> uv2;

		// Token: 0x04013098 RID: 77976
		[NonSerialized]
		private ExposedList<Vector2> uv3;

		// Token: 0x04013099 RID: 77977
		private static List<Vector3> AttachmentVerts = new List<Vector3>();

		// Token: 0x0401309A RID: 77978
		private static List<Vector2> AttachmentUVs = new List<Vector2>();

		// Token: 0x0401309B RID: 77979
		private static List<Color32> AttachmentColors32 = new List<Color32>();

		// Token: 0x0401309C RID: 77980
		private static List<int> AttachmentIndices = new List<int>();

		// Token: 0x020049FF RID: 18943
		[Serializable]
		public struct Settings
		{
			// Token: 0x17002430 RID: 9264
			// (get) Token: 0x0601B552 RID: 111954 RVA: 0x0086B5B4 File Offset: 0x008699B4
			public static MeshGenerator.Settings Default
			{
				get
				{
					return new MeshGenerator.Settings
					{
						pmaVertexColors = true,
						zSpacing = 0f,
						useClipping = true,
						tintBlack = false,
						calculateTangents = false,
						addNormals = false,
						immutableTriangles = false
					};
				}
			}

			// Token: 0x0401309D RID: 77981
			public bool useClipping;

			// Token: 0x0401309E RID: 77982
			[Space]
			[Range(-0.1f, 0f)]
			public float zSpacing;

			// Token: 0x0401309F RID: 77983
			[Space]
			[Header("Vertex Data")]
			public bool pmaVertexColors;

			// Token: 0x040130A0 RID: 77984
			public bool tintBlack;

			// Token: 0x040130A1 RID: 77985
			public bool calculateTangents;

			// Token: 0x040130A2 RID: 77986
			public bool addNormals;

			// Token: 0x040130A3 RID: 77987
			public bool immutableTriangles;
		}
	}
}
