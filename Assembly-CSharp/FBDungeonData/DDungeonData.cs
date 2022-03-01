using System;
using FlatBuffers;

namespace FBDungeonData
{
	// Token: 0x02004AFC RID: 19196
	public sealed class DDungeonData : Table
	{
		// Token: 0x0601BF01 RID: 114433 RVA: 0x0088CE46 File Offset: 0x0088B246
		public static DDungeonData GetRootAsDDungeonData(ByteBuffer _bb)
		{
			return DDungeonData.GetRootAsDDungeonData(_bb, new DDungeonData());
		}

		// Token: 0x0601BF02 RID: 114434 RVA: 0x0088CE53 File Offset: 0x0088B253
		public static DDungeonData GetRootAsDDungeonData(ByteBuffer _bb, DDungeonData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF03 RID: 114435 RVA: 0x0088CE6F File Offset: 0x0088B26F
		public static bool DDungeonDataBufferHasIdentifier(ByteBuffer _bb)
		{
			return Table.__has_identifier(_bb, "DUNG");
		}

		// Token: 0x0601BF04 RID: 114436 RVA: 0x0088CE7C File Offset: 0x0088B27C
		public DDungeonData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170025FF RID: 9727
		// (get) Token: 0x0601BF05 RID: 114437 RVA: 0x0088CE90 File Offset: 0x0088B290
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002600 RID: 9728
		// (get) Token: 0x0601BF06 RID: 114438 RVA: 0x0088CEC0 File Offset: 0x0088B2C0
		public int Height
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 3 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002601 RID: 9729
		// (get) Token: 0x0601BF07 RID: 114439 RVA: 0x0088CEF4 File Offset: 0x0088B2F4
		public int Weidth
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 3 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002602 RID: 9730
		// (get) Token: 0x0601BF08 RID: 114440 RVA: 0x0088CF28 File Offset: 0x0088B328
		public int Startindex
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601BF09 RID: 114441 RVA: 0x0088CF5D File Offset: 0x0088B35D
		public DSceneDataConnect GetAreaconnectlist(int j)
		{
			return this.GetAreaconnectlist(new DSceneDataConnect(), j);
		}

		// Token: 0x0601BF0A RID: 114442 RVA: 0x0088CF6C File Offset: 0x0088B36C
		public DSceneDataConnect GetAreaconnectlist(DSceneDataConnect obj, int j)
		{
			int num = base.__offset(12);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002603 RID: 9731
		// (get) Token: 0x0601BF0B RID: 114443 RVA: 0x0088CFAC File Offset: 0x0088B3AC
		public int AreaconnectlistLength
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601BF0C RID: 114444 RVA: 0x0088CFD5 File Offset: 0x0088B3D5
		public static Offset<DDungeonData> CreateDDungeonData(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int height = 3, int weidth = 3, int startindex = 0, VectorOffset areaconnectlist = default(VectorOffset))
		{
			builder.StartObject(5);
			DDungeonData.AddAreaconnectlist(builder, areaconnectlist);
			DDungeonData.AddStartindex(builder, startindex);
			DDungeonData.AddWeidth(builder, weidth);
			DDungeonData.AddHeight(builder, height);
			DDungeonData.AddName(builder, name);
			return DDungeonData.EndDDungeonData(builder);
		}

		// Token: 0x0601BF0D RID: 114445 RVA: 0x0088D009 File Offset: 0x0088B409
		public static void StartDDungeonData(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0601BF0E RID: 114446 RVA: 0x0088D012 File Offset: 0x0088B412
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601BF0F RID: 114447 RVA: 0x0088D023 File Offset: 0x0088B423
		public static void AddHeight(FlatBufferBuilder builder, int height)
		{
			builder.AddInt(1, height, 3);
		}

		// Token: 0x0601BF10 RID: 114448 RVA: 0x0088D02E File Offset: 0x0088B42E
		public static void AddWeidth(FlatBufferBuilder builder, int weidth)
		{
			builder.AddInt(2, weidth, 3);
		}

		// Token: 0x0601BF11 RID: 114449 RVA: 0x0088D039 File Offset: 0x0088B439
		public static void AddStartindex(FlatBufferBuilder builder, int startindex)
		{
			builder.AddInt(3, startindex, 0);
		}

		// Token: 0x0601BF12 RID: 114450 RVA: 0x0088D044 File Offset: 0x0088B444
		public static void AddAreaconnectlist(FlatBufferBuilder builder, VectorOffset areaconnectlistOffset)
		{
			builder.AddOffset(4, areaconnectlistOffset.Value, 0);
		}

		// Token: 0x0601BF13 RID: 114451 RVA: 0x0088D058 File Offset: 0x0088B458
		public static VectorOffset CreateAreaconnectlistVector(FlatBufferBuilder builder, Offset<DSceneDataConnect>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601BF14 RID: 114452 RVA: 0x0088D09E File Offset: 0x0088B49E
		public static void StartAreaconnectlistVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601BF15 RID: 114453 RVA: 0x0088D0AC File Offset: 0x0088B4AC
		public static Offset<DDungeonData> EndDDungeonData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DDungeonData>(value);
		}

		// Token: 0x0601BF16 RID: 114454 RVA: 0x0088D0C6 File Offset: 0x0088B4C6
		public static void FinishDDungeonDataBuffer(FlatBufferBuilder builder, Offset<DDungeonData> offset)
		{
			builder.Finish(offset.Value, "DUNG");
		}
	}
}
