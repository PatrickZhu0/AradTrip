using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000408 RID: 1032
	public class EquipStrColorRatioTable : IFlatbufferObject
	{
		// Token: 0x17000B68 RID: 2920
		// (get) Token: 0x06002F7F RID: 12159 RVA: 0x000AB2DC File Offset: 0x000A96DC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x000AB2E9 File Offset: 0x000A96E9
		public static EquipStrColorRatioTable GetRootAsEquipStrColorRatioTable(ByteBuffer _bb)
		{
			return EquipStrColorRatioTable.GetRootAsEquipStrColorRatioTable(_bb, new EquipStrColorRatioTable());
		}

		// Token: 0x06002F81 RID: 12161 RVA: 0x000AB2F6 File Offset: 0x000A96F6
		public static EquipStrColorRatioTable GetRootAsEquipStrColorRatioTable(ByteBuffer _bb, EquipStrColorRatioTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F82 RID: 12162 RVA: 0x000AB312 File Offset: 0x000A9712
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F83 RID: 12163 RVA: 0x000AB32C File Offset: 0x000A972C
		public EquipStrColorRatioTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B69 RID: 2921
		// (get) Token: 0x06002F84 RID: 12164 RVA: 0x000AB338 File Offset: 0x000A9738
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x06002F85 RID: 12165 RVA: 0x000AB384 File Offset: 0x000A9784
		public int Lv
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002F86 RID: 12166 RVA: 0x000AB3D0 File Offset: 0x000A97D0
		public int WhiteRatioArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x06002F87 RID: 12167 RVA: 0x000AB41C File Offset: 0x000A981C
		public int WhiteRatioLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F88 RID: 12168 RVA: 0x000AB44E File Offset: 0x000A984E
		public ArraySegment<byte>? GetWhiteRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x06002F89 RID: 12169 RVA: 0x000AB45C File Offset: 0x000A985C
		public FlatBufferArray<int> WhiteRatio
		{
			get
			{
				if (this.WhiteRatioValue == null)
				{
					this.WhiteRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.WhiteRatioArray), this.WhiteRatioLength);
				}
				return this.WhiteRatioValue;
			}
		}

		// Token: 0x06002F8A RID: 12170 RVA: 0x000AB48C File Offset: 0x000A988C
		public int BlueRatioArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x06002F8B RID: 12171 RVA: 0x000AB4DC File Offset: 0x000A98DC
		public int BlueRatioLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F8C RID: 12172 RVA: 0x000AB50F File Offset: 0x000A990F
		public ArraySegment<byte>? GetBlueRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x06002F8D RID: 12173 RVA: 0x000AB51E File Offset: 0x000A991E
		public FlatBufferArray<int> BlueRatio
		{
			get
			{
				if (this.BlueRatioValue == null)
				{
					this.BlueRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.BlueRatioArray), this.BlueRatioLength);
				}
				return this.BlueRatioValue;
			}
		}

		// Token: 0x06002F8E RID: 12174 RVA: 0x000AB550 File Offset: 0x000A9950
		public int PurpleRatioArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x06002F8F RID: 12175 RVA: 0x000AB5A0 File Offset: 0x000A99A0
		public int PurpleRatioLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F90 RID: 12176 RVA: 0x000AB5D3 File Offset: 0x000A99D3
		public ArraySegment<byte>? GetPurpleRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x06002F91 RID: 12177 RVA: 0x000AB5E2 File Offset: 0x000A99E2
		public FlatBufferArray<int> PurpleRatio
		{
			get
			{
				if (this.PurpleRatioValue == null)
				{
					this.PurpleRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.PurpleRatioArray), this.PurpleRatioLength);
				}
				return this.PurpleRatioValue;
			}
		}

		// Token: 0x06002F92 RID: 12178 RVA: 0x000AB614 File Offset: 0x000A9A14
		public int GreenRatioArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x06002F93 RID: 12179 RVA: 0x000AB664 File Offset: 0x000A9A64
		public int GreenRatioLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F94 RID: 12180 RVA: 0x000AB697 File Offset: 0x000A9A97
		public ArraySegment<byte>? GetGreenRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x06002F95 RID: 12181 RVA: 0x000AB6A6 File Offset: 0x000A9AA6
		public FlatBufferArray<int> GreenRatio
		{
			get
			{
				if (this.GreenRatioValue == null)
				{
					this.GreenRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.GreenRatioArray), this.GreenRatioLength);
				}
				return this.GreenRatioValue;
			}
		}

		// Token: 0x06002F96 RID: 12182 RVA: 0x000AB6D8 File Offset: 0x000A9AD8
		public int PinkRatioArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x06002F97 RID: 12183 RVA: 0x000AB728 File Offset: 0x000A9B28
		public int PinkRatioLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F98 RID: 12184 RVA: 0x000AB75B File Offset: 0x000A9B5B
		public ArraySegment<byte>? GetPinkRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x06002F99 RID: 12185 RVA: 0x000AB76A File Offset: 0x000A9B6A
		public FlatBufferArray<int> PinkRatio
		{
			get
			{
				if (this.PinkRatioValue == null)
				{
					this.PinkRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.PinkRatioArray), this.PinkRatioLength);
				}
				return this.PinkRatioValue;
			}
		}

		// Token: 0x06002F9A RID: 12186 RVA: 0x000AB79C File Offset: 0x000A9B9C
		public int YellowRatioArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-1294104621 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x06002F9B RID: 12187 RVA: 0x000AB7EC File Offset: 0x000A9BEC
		public int YellowRatioLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002F9C RID: 12188 RVA: 0x000AB81F File Offset: 0x000A9C1F
		public ArraySegment<byte>? GetYellowRatioBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x06002F9D RID: 12189 RVA: 0x000AB82E File Offset: 0x000A9C2E
		public FlatBufferArray<int> YellowRatio
		{
			get
			{
				if (this.YellowRatioValue == null)
				{
					this.YellowRatioValue = new FlatBufferArray<int>(new Func<int, int>(this.YellowRatioArray), this.YellowRatioLength);
				}
				return this.YellowRatioValue;
			}
		}

		// Token: 0x06002F9E RID: 12190 RVA: 0x000AB860 File Offset: 0x000A9C60
		public static Offset<EquipStrColorRatioTable> CreateEquipStrColorRatioTable(FlatBufferBuilder builder, int ID = 0, int Lv = 0, VectorOffset WhiteRatioOffset = default(VectorOffset), VectorOffset BlueRatioOffset = default(VectorOffset), VectorOffset PurpleRatioOffset = default(VectorOffset), VectorOffset GreenRatioOffset = default(VectorOffset), VectorOffset PinkRatioOffset = default(VectorOffset), VectorOffset YellowRatioOffset = default(VectorOffset))
		{
			builder.StartObject(8);
			EquipStrColorRatioTable.AddYellowRatio(builder, YellowRatioOffset);
			EquipStrColorRatioTable.AddPinkRatio(builder, PinkRatioOffset);
			EquipStrColorRatioTable.AddGreenRatio(builder, GreenRatioOffset);
			EquipStrColorRatioTable.AddPurpleRatio(builder, PurpleRatioOffset);
			EquipStrColorRatioTable.AddBlueRatio(builder, BlueRatioOffset);
			EquipStrColorRatioTable.AddWhiteRatio(builder, WhiteRatioOffset);
			EquipStrColorRatioTable.AddLv(builder, Lv);
			EquipStrColorRatioTable.AddID(builder, ID);
			return EquipStrColorRatioTable.EndEquipStrColorRatioTable(builder);
		}

		// Token: 0x06002F9F RID: 12191 RVA: 0x000AB8B7 File Offset: 0x000A9CB7
		public static void StartEquipStrColorRatioTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002FA0 RID: 12192 RVA: 0x000AB8C0 File Offset: 0x000A9CC0
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002FA1 RID: 12193 RVA: 0x000AB8CB File Offset: 0x000A9CCB
		public static void AddLv(FlatBufferBuilder builder, int Lv)
		{
			builder.AddInt(1, Lv, 0);
		}

		// Token: 0x06002FA2 RID: 12194 RVA: 0x000AB8D6 File Offset: 0x000A9CD6
		public static void AddWhiteRatio(FlatBufferBuilder builder, VectorOffset WhiteRatioOffset)
		{
			builder.AddOffset(2, WhiteRatioOffset.Value, 0);
		}

		// Token: 0x06002FA3 RID: 12195 RVA: 0x000AB8E8 File Offset: 0x000A9CE8
		public static VectorOffset CreateWhiteRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FA4 RID: 12196 RVA: 0x000AB925 File Offset: 0x000A9D25
		public static void StartWhiteRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FA5 RID: 12197 RVA: 0x000AB930 File Offset: 0x000A9D30
		public static void AddBlueRatio(FlatBufferBuilder builder, VectorOffset BlueRatioOffset)
		{
			builder.AddOffset(3, BlueRatioOffset.Value, 0);
		}

		// Token: 0x06002FA6 RID: 12198 RVA: 0x000AB944 File Offset: 0x000A9D44
		public static VectorOffset CreateBlueRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FA7 RID: 12199 RVA: 0x000AB981 File Offset: 0x000A9D81
		public static void StartBlueRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FA8 RID: 12200 RVA: 0x000AB98C File Offset: 0x000A9D8C
		public static void AddPurpleRatio(FlatBufferBuilder builder, VectorOffset PurpleRatioOffset)
		{
			builder.AddOffset(4, PurpleRatioOffset.Value, 0);
		}

		// Token: 0x06002FA9 RID: 12201 RVA: 0x000AB9A0 File Offset: 0x000A9DA0
		public static VectorOffset CreatePurpleRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FAA RID: 12202 RVA: 0x000AB9DD File Offset: 0x000A9DDD
		public static void StartPurpleRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FAB RID: 12203 RVA: 0x000AB9E8 File Offset: 0x000A9DE8
		public static void AddGreenRatio(FlatBufferBuilder builder, VectorOffset GreenRatioOffset)
		{
			builder.AddOffset(5, GreenRatioOffset.Value, 0);
		}

		// Token: 0x06002FAC RID: 12204 RVA: 0x000AB9FC File Offset: 0x000A9DFC
		public static VectorOffset CreateGreenRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FAD RID: 12205 RVA: 0x000ABA39 File Offset: 0x000A9E39
		public static void StartGreenRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FAE RID: 12206 RVA: 0x000ABA44 File Offset: 0x000A9E44
		public static void AddPinkRatio(FlatBufferBuilder builder, VectorOffset PinkRatioOffset)
		{
			builder.AddOffset(6, PinkRatioOffset.Value, 0);
		}

		// Token: 0x06002FAF RID: 12207 RVA: 0x000ABA58 File Offset: 0x000A9E58
		public static VectorOffset CreatePinkRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FB0 RID: 12208 RVA: 0x000ABA95 File Offset: 0x000A9E95
		public static void StartPinkRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FB1 RID: 12209 RVA: 0x000ABAA0 File Offset: 0x000A9EA0
		public static void AddYellowRatio(FlatBufferBuilder builder, VectorOffset YellowRatioOffset)
		{
			builder.AddOffset(7, YellowRatioOffset.Value, 0);
		}

		// Token: 0x06002FB2 RID: 12210 RVA: 0x000ABAB4 File Offset: 0x000A9EB4
		public static VectorOffset CreateYellowRatioVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002FB3 RID: 12211 RVA: 0x000ABAF1 File Offset: 0x000A9EF1
		public static void StartYellowRatioVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002FB4 RID: 12212 RVA: 0x000ABAFC File Offset: 0x000A9EFC
		public static Offset<EquipStrColorRatioTable> EndEquipStrColorRatioTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrColorRatioTable>(value);
		}

		// Token: 0x06002FB5 RID: 12213 RVA: 0x000ABB16 File Offset: 0x000A9F16
		public static void FinishEquipStrColorRatioTableBuffer(FlatBufferBuilder builder, Offset<EquipStrColorRatioTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001416 RID: 5142
		private Table __p = new Table();

		// Token: 0x04001417 RID: 5143
		private FlatBufferArray<int> WhiteRatioValue;

		// Token: 0x04001418 RID: 5144
		private FlatBufferArray<int> BlueRatioValue;

		// Token: 0x04001419 RID: 5145
		private FlatBufferArray<int> PurpleRatioValue;

		// Token: 0x0400141A RID: 5146
		private FlatBufferArray<int> GreenRatioValue;

		// Token: 0x0400141B RID: 5147
		private FlatBufferArray<int> PinkRatioValue;

		// Token: 0x0400141C RID: 5148
		private FlatBufferArray<int> YellowRatioValue;

		// Token: 0x02000409 RID: 1033
		public enum eCrypt
		{
			// Token: 0x0400141E RID: 5150
			code = -1294104621
		}
	}
}
