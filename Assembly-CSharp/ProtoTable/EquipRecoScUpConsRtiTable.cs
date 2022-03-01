using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003FD RID: 1021
	public class EquipRecoScUpConsRtiTable : IFlatbufferObject
	{
		// Token: 0x17000B4C RID: 2892
		// (get) Token: 0x06002F15 RID: 12053 RVA: 0x000AA634 File Offset: 0x000A8A34
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F16 RID: 12054 RVA: 0x000AA641 File Offset: 0x000A8A41
		public static EquipRecoScUpConsRtiTable GetRootAsEquipRecoScUpConsRtiTable(ByteBuffer _bb)
		{
			return EquipRecoScUpConsRtiTable.GetRootAsEquipRecoScUpConsRtiTable(_bb, new EquipRecoScUpConsRtiTable());
		}

		// Token: 0x06002F17 RID: 12055 RVA: 0x000AA64E File Offset: 0x000A8A4E
		public static EquipRecoScUpConsRtiTable GetRootAsEquipRecoScUpConsRtiTable(ByteBuffer _bb, EquipRecoScUpConsRtiTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F18 RID: 12056 RVA: 0x000AA66A File Offset: 0x000A8A6A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F19 RID: 12057 RVA: 0x000AA684 File Offset: 0x000A8A84
		public EquipRecoScUpConsRtiTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B4D RID: 2893
		// (get) Token: 0x06002F1A RID: 12058 RVA: 0x000AA690 File Offset: 0x000A8A90
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1761517986 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F1B RID: 12059 RVA: 0x000AA6DC File Offset: 0x000A8ADC
		public string TimesSectionArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000B4E RID: 2894
		// (get) Token: 0x06002F1C RID: 12060 RVA: 0x000AA724 File Offset: 0x000A8B24
		public int TimesSectionLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000B4F RID: 2895
		// (get) Token: 0x06002F1D RID: 12061 RVA: 0x000AA756 File Offset: 0x000A8B56
		public FlatBufferArray<string> TimesSection
		{
			get
			{
				if (this.TimesSectionValue == null)
				{
					this.TimesSectionValue = new FlatBufferArray<string>(new Func<int, string>(this.TimesSectionArray), this.TimesSectionLength);
				}
				return this.TimesSectionValue;
			}
		}

		// Token: 0x17000B50 RID: 2896
		// (get) Token: 0x06002F1E RID: 12062 RVA: 0x000AA788 File Offset: 0x000A8B88
		public int Ratio
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1761517986 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F1F RID: 12063 RVA: 0x000AA7D1 File Offset: 0x000A8BD1
		public static Offset<EquipRecoScUpConsRtiTable> CreateEquipRecoScUpConsRtiTable(FlatBufferBuilder builder, int ID = 0, VectorOffset TimesSectionOffset = default(VectorOffset), int Ratio = 0)
		{
			builder.StartObject(3);
			EquipRecoScUpConsRtiTable.AddRatio(builder, Ratio);
			EquipRecoScUpConsRtiTable.AddTimesSection(builder, TimesSectionOffset);
			EquipRecoScUpConsRtiTable.AddID(builder, ID);
			return EquipRecoScUpConsRtiTable.EndEquipRecoScUpConsRtiTable(builder);
		}

		// Token: 0x06002F20 RID: 12064 RVA: 0x000AA7F5 File Offset: 0x000A8BF5
		public static void StartEquipRecoScUpConsRtiTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002F21 RID: 12065 RVA: 0x000AA7FE File Offset: 0x000A8BFE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F22 RID: 12066 RVA: 0x000AA809 File Offset: 0x000A8C09
		public static void AddTimesSection(FlatBufferBuilder builder, VectorOffset TimesSectionOffset)
		{
			builder.AddOffset(1, TimesSectionOffset.Value, 0);
		}

		// Token: 0x06002F23 RID: 12067 RVA: 0x000AA81C File Offset: 0x000A8C1C
		public static VectorOffset CreateTimesSectionVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002F24 RID: 12068 RVA: 0x000AA862 File Offset: 0x000A8C62
		public static void StartTimesSectionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002F25 RID: 12069 RVA: 0x000AA86D File Offset: 0x000A8C6D
		public static void AddRatio(FlatBufferBuilder builder, int Ratio)
		{
			builder.AddInt(2, Ratio, 0);
		}

		// Token: 0x06002F26 RID: 12070 RVA: 0x000AA878 File Offset: 0x000A8C78
		public static Offset<EquipRecoScUpConsRtiTable> EndEquipRecoScUpConsRtiTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipRecoScUpConsRtiTable>(value);
		}

		// Token: 0x06002F27 RID: 12071 RVA: 0x000AA892 File Offset: 0x000A8C92
		public static void FinishEquipRecoScUpConsRtiTableBuffer(FlatBufferBuilder builder, Offset<EquipRecoScUpConsRtiTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013AF RID: 5039
		private Table __p = new Table();

		// Token: 0x040013B0 RID: 5040
		private FlatBufferArray<string> TimesSectionValue;

		// Token: 0x020003FE RID: 1022
		public enum eCrypt
		{
			// Token: 0x040013B2 RID: 5042
			code = 1761517986
		}
	}
}
