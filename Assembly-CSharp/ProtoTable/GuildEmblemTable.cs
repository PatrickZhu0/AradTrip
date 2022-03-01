using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000477 RID: 1143
	public class GuildEmblemTable : IFlatbufferObject
	{
		// Token: 0x17000DDB RID: 3547
		// (get) Token: 0x06003742 RID: 14146 RVA: 0x000BD5A8 File Offset: 0x000BB9A8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003743 RID: 14147 RVA: 0x000BD5B5 File Offset: 0x000BB9B5
		public static GuildEmblemTable GetRootAsGuildEmblemTable(ByteBuffer _bb)
		{
			return GuildEmblemTable.GetRootAsGuildEmblemTable(_bb, new GuildEmblemTable());
		}

		// Token: 0x06003744 RID: 14148 RVA: 0x000BD5C2 File Offset: 0x000BB9C2
		public static GuildEmblemTable GetRootAsGuildEmblemTable(ByteBuffer _bb, GuildEmblemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003745 RID: 14149 RVA: 0x000BD5DE File Offset: 0x000BB9DE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003746 RID: 14150 RVA: 0x000BD5F8 File Offset: 0x000BB9F8
		public GuildEmblemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DDC RID: 3548
		// (get) Token: 0x06003747 RID: 14151 RVA: 0x000BD604 File Offset: 0x000BBA04
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DDD RID: 3549
		// (get) Token: 0x06003748 RID: 14152 RVA: 0x000BD650 File Offset: 0x000BBA50
		public int needHonourLevel
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x000BD69C File Offset: 0x000BBA9C
		public int costIdArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DDE RID: 3550
		// (get) Token: 0x0600374A RID: 14154 RVA: 0x000BD6E8 File Offset: 0x000BBAE8
		public int costIdLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600374B RID: 14155 RVA: 0x000BD71A File Offset: 0x000BBB1A
		public ArraySegment<byte>? GetCostIdBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000DDF RID: 3551
		// (get) Token: 0x0600374C RID: 14156 RVA: 0x000BD728 File Offset: 0x000BBB28
		public FlatBufferArray<int> costId
		{
			get
			{
				if (this.costIdValue == null)
				{
					this.costIdValue = new FlatBufferArray<int>(new Func<int, int>(this.costIdArray), this.costIdLength);
				}
				return this.costIdValue;
			}
		}

		// Token: 0x0600374D RID: 14157 RVA: 0x000BD758 File Offset: 0x000BBB58
		public int costNumArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DE0 RID: 3552
		// (get) Token: 0x0600374E RID: 14158 RVA: 0x000BD7A8 File Offset: 0x000BBBA8
		public int costNumLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x000BD7DB File Offset: 0x000BBBDB
		public ArraySegment<byte>? GetCostNumBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000DE1 RID: 3553
		// (get) Token: 0x06003750 RID: 14160 RVA: 0x000BD7EA File Offset: 0x000BBBEA
		public FlatBufferArray<int> costNum
		{
			get
			{
				if (this.costNumValue == null)
				{
					this.costNumValue = new FlatBufferArray<int>(new Func<int, int>(this.costNumArray), this.costNumLength);
				}
				return this.costNumValue;
			}
		}

		// Token: 0x06003751 RID: 14161 RVA: 0x000BD81C File Offset: 0x000BBC1C
		public int useEqualArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000DE2 RID: 3554
		// (get) Token: 0x06003752 RID: 14162 RVA: 0x000BD86C File Offset: 0x000BBC6C
		public int useEqualLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x000BD89F File Offset: 0x000BBC9F
		public ArraySegment<byte>? GetUseEqualBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000DE3 RID: 3555
		// (get) Token: 0x06003754 RID: 14164 RVA: 0x000BD8AE File Offset: 0x000BBCAE
		public FlatBufferArray<int> useEqual
		{
			get
			{
				if (this.useEqualValue == null)
				{
					this.useEqualValue = new FlatBufferArray<int>(new Func<int, int>(this.useEqualArray), this.useEqualLength);
				}
				return this.useEqualValue;
			}
		}

		// Token: 0x17000DE4 RID: 3556
		// (get) Token: 0x06003755 RID: 14165 RVA: 0x000BD8E0 File Offset: 0x000BBCE0
		public string name
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x000BD923 File Offset: 0x000BBD23
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000DE5 RID: 3557
		// (get) Token: 0x06003757 RID: 14167 RVA: 0x000BD934 File Offset: 0x000BBD34
		public string namePath
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x000BD977 File Offset: 0x000BBD77
		public ArraySegment<byte>? GetNamePathBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000DE6 RID: 3558
		// (get) Token: 0x06003759 RID: 14169 RVA: 0x000BD988 File Offset: 0x000BBD88
		public int stageLevel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DE7 RID: 3559
		// (get) Token: 0x0600375A RID: 14170 RVA: 0x000BD9D4 File Offset: 0x000BBDD4
		public string iconPath
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x000BDA17 File Offset: 0x000BBE17
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000DE8 RID: 3560
		// (get) Token: 0x0600375C RID: 14172 RVA: 0x000BDA28 File Offset: 0x000BBE28
		public int TitleId
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1527387525 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x000BDA74 File Offset: 0x000BBE74
		public static Offset<GuildEmblemTable> CreateGuildEmblemTable(FlatBufferBuilder builder, int ID = 0, int needHonourLevel = 0, VectorOffset costIdOffset = default(VectorOffset), VectorOffset costNumOffset = default(VectorOffset), VectorOffset useEqualOffset = default(VectorOffset), StringOffset nameOffset = default(StringOffset), StringOffset namePathOffset = default(StringOffset), int stageLevel = 0, StringOffset iconPathOffset = default(StringOffset), int TitleId = 0)
		{
			builder.StartObject(10);
			GuildEmblemTable.AddTitleId(builder, TitleId);
			GuildEmblemTable.AddIconPath(builder, iconPathOffset);
			GuildEmblemTable.AddStageLevel(builder, stageLevel);
			GuildEmblemTable.AddNamePath(builder, namePathOffset);
			GuildEmblemTable.AddName(builder, nameOffset);
			GuildEmblemTable.AddUseEqual(builder, useEqualOffset);
			GuildEmblemTable.AddCostNum(builder, costNumOffset);
			GuildEmblemTable.AddCostId(builder, costIdOffset);
			GuildEmblemTable.AddNeedHonourLevel(builder, needHonourLevel);
			GuildEmblemTable.AddID(builder, ID);
			return GuildEmblemTable.EndGuildEmblemTable(builder);
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x000BDADC File Offset: 0x000BBEDC
		public static void StartGuildEmblemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0600375F RID: 14175 RVA: 0x000BDAE6 File Offset: 0x000BBEE6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003760 RID: 14176 RVA: 0x000BDAF1 File Offset: 0x000BBEF1
		public static void AddNeedHonourLevel(FlatBufferBuilder builder, int needHonourLevel)
		{
			builder.AddInt(1, needHonourLevel, 0);
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x000BDAFC File Offset: 0x000BBEFC
		public static void AddCostId(FlatBufferBuilder builder, VectorOffset costIdOffset)
		{
			builder.AddOffset(2, costIdOffset.Value, 0);
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x000BDB10 File Offset: 0x000BBF10
		public static VectorOffset CreateCostIdVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003763 RID: 14179 RVA: 0x000BDB4D File Offset: 0x000BBF4D
		public static void StartCostIdVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003764 RID: 14180 RVA: 0x000BDB58 File Offset: 0x000BBF58
		public static void AddCostNum(FlatBufferBuilder builder, VectorOffset costNumOffset)
		{
			builder.AddOffset(3, costNumOffset.Value, 0);
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x000BDB6C File Offset: 0x000BBF6C
		public static VectorOffset CreateCostNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x000BDBA9 File Offset: 0x000BBFA9
		public static void StartCostNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003767 RID: 14183 RVA: 0x000BDBB4 File Offset: 0x000BBFB4
		public static void AddUseEqual(FlatBufferBuilder builder, VectorOffset useEqualOffset)
		{
			builder.AddOffset(4, useEqualOffset.Value, 0);
		}

		// Token: 0x06003768 RID: 14184 RVA: 0x000BDBC8 File Offset: 0x000BBFC8
		public static VectorOffset CreateUseEqualVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x000BDC05 File Offset: 0x000BC005
		public static void StartUseEqualVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600376A RID: 14186 RVA: 0x000BDC10 File Offset: 0x000BC010
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(5, nameOffset.Value, 0);
		}

		// Token: 0x0600376B RID: 14187 RVA: 0x000BDC21 File Offset: 0x000BC021
		public static void AddNamePath(FlatBufferBuilder builder, StringOffset namePathOffset)
		{
			builder.AddOffset(6, namePathOffset.Value, 0);
		}

		// Token: 0x0600376C RID: 14188 RVA: 0x000BDC32 File Offset: 0x000BC032
		public static void AddStageLevel(FlatBufferBuilder builder, int stageLevel)
		{
			builder.AddInt(7, stageLevel, 0);
		}

		// Token: 0x0600376D RID: 14189 RVA: 0x000BDC3D File Offset: 0x000BC03D
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset iconPathOffset)
		{
			builder.AddOffset(8, iconPathOffset.Value, 0);
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x000BDC4E File Offset: 0x000BC04E
		public static void AddTitleId(FlatBufferBuilder builder, int TitleId)
		{
			builder.AddInt(9, TitleId, 0);
		}

		// Token: 0x0600376F RID: 14191 RVA: 0x000BDC5C File Offset: 0x000BC05C
		public static Offset<GuildEmblemTable> EndGuildEmblemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildEmblemTable>(value);
		}

		// Token: 0x06003770 RID: 14192 RVA: 0x000BDC76 File Offset: 0x000BC076
		public static void FinishGuildEmblemTableBuffer(FlatBufferBuilder builder, Offset<GuildEmblemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015D2 RID: 5586
		private Table __p = new Table();

		// Token: 0x040015D3 RID: 5587
		private FlatBufferArray<int> costIdValue;

		// Token: 0x040015D4 RID: 5588
		private FlatBufferArray<int> costNumValue;

		// Token: 0x040015D5 RID: 5589
		private FlatBufferArray<int> useEqualValue;

		// Token: 0x02000478 RID: 1144
		public enum eCrypt
		{
			// Token: 0x040015D7 RID: 5591
			code = -1527387525
		}
	}
}
