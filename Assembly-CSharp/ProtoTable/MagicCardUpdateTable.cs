using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004E5 RID: 1253
	public class MagicCardUpdateTable : IFlatbufferObject
	{
		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06003FA0 RID: 16288 RVA: 0x000D18BC File Offset: 0x000CFCBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003FA1 RID: 16289 RVA: 0x000D18C9 File Offset: 0x000CFCC9
		public static MagicCardUpdateTable GetRootAsMagicCardUpdateTable(ByteBuffer _bb)
		{
			return MagicCardUpdateTable.GetRootAsMagicCardUpdateTable(_bb, new MagicCardUpdateTable());
		}

		// Token: 0x06003FA2 RID: 16290 RVA: 0x000D18D6 File Offset: 0x000CFCD6
		public static MagicCardUpdateTable GetRootAsMagicCardUpdateTable(ByteBuffer _bb, MagicCardUpdateTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003FA3 RID: 16291 RVA: 0x000D18F2 File Offset: 0x000CFCF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003FA4 RID: 16292 RVA: 0x000D190C File Offset: 0x000CFD0C
		public MagicCardUpdateTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x06003FA5 RID: 16293 RVA: 0x000D1918 File Offset: 0x000CFD18
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (356485126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x06003FA6 RID: 16294 RVA: 0x000D1964 File Offset: 0x000CFD64
		public int MagicCardID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (356485126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010AF RID: 4271
		// (get) Token: 0x06003FA7 RID: 16295 RVA: 0x000D19B0 File Offset: 0x000CFDB0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003FA8 RID: 16296 RVA: 0x000D19F2 File Offset: 0x000CFDF2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170010B0 RID: 4272
		// (get) Token: 0x06003FA9 RID: 16297 RVA: 0x000D1A00 File Offset: 0x000CFE00
		public int MinLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (356485126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010B1 RID: 4273
		// (get) Token: 0x06003FAA RID: 16298 RVA: 0x000D1A4C File Offset: 0x000CFE4C
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (356485126 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003FAB RID: 16299 RVA: 0x000D1A98 File Offset: 0x000CFE98
		public string UpgradeMaterials_1Array(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010B2 RID: 4274
		// (get) Token: 0x06003FAC RID: 16300 RVA: 0x000D1AE0 File Offset: 0x000CFEE0
		public int UpgradeMaterials_1Length
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010B3 RID: 4275
		// (get) Token: 0x06003FAD RID: 16301 RVA: 0x000D1B13 File Offset: 0x000CFF13
		public FlatBufferArray<string> UpgradeMaterials_1
		{
			get
			{
				if (this.UpgradeMaterials_1Value == null)
				{
					this.UpgradeMaterials_1Value = new FlatBufferArray<string>(new Func<int, string>(this.UpgradeMaterials_1Array), this.UpgradeMaterials_1Length);
				}
				return this.UpgradeMaterials_1Value;
			}
		}

		// Token: 0x06003FAE RID: 16302 RVA: 0x000D1B44 File Offset: 0x000CFF44
		public string BaseRate_1Array(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010B4 RID: 4276
		// (get) Token: 0x06003FAF RID: 16303 RVA: 0x000D1B8C File Offset: 0x000CFF8C
		public int BaseRate_1Length
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010B5 RID: 4277
		// (get) Token: 0x06003FB0 RID: 16304 RVA: 0x000D1BBF File Offset: 0x000CFFBF
		public FlatBufferArray<string> BaseRate_1
		{
			get
			{
				if (this.BaseRate_1Value == null)
				{
					this.BaseRate_1Value = new FlatBufferArray<string>(new Func<int, string>(this.BaseRate_1Array), this.BaseRate_1Length);
				}
				return this.BaseRate_1Value;
			}
		}

		// Token: 0x06003FB1 RID: 16305 RVA: 0x000D1BF0 File Offset: 0x000CFFF0
		public string UpgradeMaterials_2Array(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010B6 RID: 4278
		// (get) Token: 0x06003FB2 RID: 16306 RVA: 0x000D1C38 File Offset: 0x000D0038
		public int UpgradeMaterials_2Length
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x06003FB3 RID: 16307 RVA: 0x000D1C6B File Offset: 0x000D006B
		public FlatBufferArray<string> UpgradeMaterials_2
		{
			get
			{
				if (this.UpgradeMaterials_2Value == null)
				{
					this.UpgradeMaterials_2Value = new FlatBufferArray<string>(new Func<int, string>(this.UpgradeMaterials_2Array), this.UpgradeMaterials_2Length);
				}
				return this.UpgradeMaterials_2Value;
			}
		}

		// Token: 0x06003FB4 RID: 16308 RVA: 0x000D1C9C File Offset: 0x000D009C
		public string BaseRate_2Array(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x06003FB5 RID: 16309 RVA: 0x000D1CE4 File Offset: 0x000D00E4
		public int BaseRate_2Length
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x06003FB6 RID: 16310 RVA: 0x000D1D17 File Offset: 0x000D0117
		public FlatBufferArray<string> BaseRate_2
		{
			get
			{
				if (this.BaseRate_2Value == null)
				{
					this.BaseRate_2Value = new FlatBufferArray<string>(new Func<int, string>(this.BaseRate_2Array), this.BaseRate_2Length);
				}
				return this.BaseRate_2Value;
			}
		}

		// Token: 0x06003FB7 RID: 16311 RVA: 0x000D1D48 File Offset: 0x000D0148
		public string UpgradeMaterials_3Array(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x06003FB8 RID: 16312 RVA: 0x000D1D90 File Offset: 0x000D0190
		public int UpgradeMaterials_3Length
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010BB RID: 4283
		// (get) Token: 0x06003FB9 RID: 16313 RVA: 0x000D1DC3 File Offset: 0x000D01C3
		public FlatBufferArray<string> UpgradeMaterials_3
		{
			get
			{
				if (this.UpgradeMaterials_3Value == null)
				{
					this.UpgradeMaterials_3Value = new FlatBufferArray<string>(new Func<int, string>(this.UpgradeMaterials_3Array), this.UpgradeMaterials_3Length);
				}
				return this.UpgradeMaterials_3Value;
			}
		}

		// Token: 0x06003FBA RID: 16314 RVA: 0x000D1DF4 File Offset: 0x000D01F4
		public string BaseRate_3Array(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06003FBB RID: 16315 RVA: 0x000D1E3C File Offset: 0x000D023C
		public int BaseRate_3Length
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x06003FBC RID: 16316 RVA: 0x000D1E6F File Offset: 0x000D026F
		public FlatBufferArray<string> BaseRate_3
		{
			get
			{
				if (this.BaseRate_3Value == null)
				{
					this.BaseRate_3Value = new FlatBufferArray<string>(new Func<int, string>(this.BaseRate_3Array), this.BaseRate_3Length);
				}
				return this.BaseRate_3Value;
			}
		}

		// Token: 0x06003FBD RID: 16317 RVA: 0x000D1EA0 File Offset: 0x000D02A0
		public string LevelAddRateArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x06003FBE RID: 16318 RVA: 0x000D1EE8 File Offset: 0x000D02E8
		public int LevelAddRateLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06003FBF RID: 16319 RVA: 0x000D1F1B File Offset: 0x000D031B
		public FlatBufferArray<string> LevelAddRate
		{
			get
			{
				if (this.LevelAddRateValue == null)
				{
					this.LevelAddRateValue = new FlatBufferArray<string>(new Func<int, string>(this.LevelAddRateArray), this.LevelAddRateLength);
				}
				return this.LevelAddRateValue;
			}
		}

		// Token: 0x06003FC0 RID: 16320 RVA: 0x000D1F4C File Offset: 0x000D034C
		public string SameCardIDArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010C0 RID: 4288
		// (get) Token: 0x06003FC1 RID: 16321 RVA: 0x000D1F94 File Offset: 0x000D0394
		public int SameCardIDLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06003FC2 RID: 16322 RVA: 0x000D1FC7 File Offset: 0x000D03C7
		public FlatBufferArray<string> SameCardID
		{
			get
			{
				if (this.SameCardIDValue == null)
				{
					this.SameCardIDValue = new FlatBufferArray<string>(new Func<int, string>(this.SameCardIDArray), this.SameCardIDLength);
				}
				return this.SameCardIDValue;
			}
		}

		// Token: 0x06003FC3 RID: 16323 RVA: 0x000D1FF8 File Offset: 0x000D03F8
		public string SameCardAddRateArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170010C2 RID: 4290
		// (get) Token: 0x06003FC4 RID: 16324 RVA: 0x000D2040 File Offset: 0x000D0440
		public int SameCardAddRateLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170010C3 RID: 4291
		// (get) Token: 0x06003FC5 RID: 16325 RVA: 0x000D2073 File Offset: 0x000D0473
		public FlatBufferArray<string> SameCardAddRate
		{
			get
			{
				if (this.SameCardAddRateValue == null)
				{
					this.SameCardAddRateValue = new FlatBufferArray<string>(new Func<int, string>(this.SameCardAddRateArray), this.SameCardAddRateLength);
				}
				return this.SameCardAddRateValue;
			}
		}

		// Token: 0x170010C4 RID: 4292
		// (get) Token: 0x06003FC6 RID: 16326 RVA: 0x000D20A4 File Offset: 0x000D04A4
		public string UpConsume
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003FC7 RID: 16327 RVA: 0x000D20E7 File Offset: 0x000D04E7
		public ArraySegment<byte>? GetUpConsumeBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x06003FC8 RID: 16328 RVA: 0x000D20F8 File Offset: 0x000D04F8
		public static Offset<MagicCardUpdateTable> CreateMagicCardUpdateTable(FlatBufferBuilder builder, int ID = 0, int MagicCardID = 0, StringOffset NameOffset = default(StringOffset), int MinLevel = 0, int MaxLevel = 0, VectorOffset UpgradeMaterials_1Offset = default(VectorOffset), VectorOffset BaseRate_1Offset = default(VectorOffset), VectorOffset UpgradeMaterials_2Offset = default(VectorOffset), VectorOffset BaseRate_2Offset = default(VectorOffset), VectorOffset UpgradeMaterials_3Offset = default(VectorOffset), VectorOffset BaseRate_3Offset = default(VectorOffset), VectorOffset LevelAddRateOffset = default(VectorOffset), VectorOffset SameCardIDOffset = default(VectorOffset), VectorOffset SameCardAddRateOffset = default(VectorOffset), StringOffset UpConsumeOffset = default(StringOffset))
		{
			builder.StartObject(15);
			MagicCardUpdateTable.AddUpConsume(builder, UpConsumeOffset);
			MagicCardUpdateTable.AddSameCardAddRate(builder, SameCardAddRateOffset);
			MagicCardUpdateTable.AddSameCardID(builder, SameCardIDOffset);
			MagicCardUpdateTable.AddLevelAddRate(builder, LevelAddRateOffset);
			MagicCardUpdateTable.AddBaseRate3(builder, BaseRate_3Offset);
			MagicCardUpdateTable.AddUpgradeMaterials3(builder, UpgradeMaterials_3Offset);
			MagicCardUpdateTable.AddBaseRate2(builder, BaseRate_2Offset);
			MagicCardUpdateTable.AddUpgradeMaterials2(builder, UpgradeMaterials_2Offset);
			MagicCardUpdateTable.AddBaseRate1(builder, BaseRate_1Offset);
			MagicCardUpdateTable.AddUpgradeMaterials1(builder, UpgradeMaterials_1Offset);
			MagicCardUpdateTable.AddMaxLevel(builder, MaxLevel);
			MagicCardUpdateTable.AddMinLevel(builder, MinLevel);
			MagicCardUpdateTable.AddName(builder, NameOffset);
			MagicCardUpdateTable.AddMagicCardID(builder, MagicCardID);
			MagicCardUpdateTable.AddID(builder, ID);
			return MagicCardUpdateTable.EndMagicCardUpdateTable(builder);
		}

		// Token: 0x06003FC9 RID: 16329 RVA: 0x000D2188 File Offset: 0x000D0588
		public static void StartMagicCardUpdateTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x06003FCA RID: 16330 RVA: 0x000D2192 File Offset: 0x000D0592
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003FCB RID: 16331 RVA: 0x000D219D File Offset: 0x000D059D
		public static void AddMagicCardID(FlatBufferBuilder builder, int MagicCardID)
		{
			builder.AddInt(1, MagicCardID, 0);
		}

		// Token: 0x06003FCC RID: 16332 RVA: 0x000D21A8 File Offset: 0x000D05A8
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06003FCD RID: 16333 RVA: 0x000D21B9 File Offset: 0x000D05B9
		public static void AddMinLevel(FlatBufferBuilder builder, int MinLevel)
		{
			builder.AddInt(3, MinLevel, 0);
		}

		// Token: 0x06003FCE RID: 16334 RVA: 0x000D21C4 File Offset: 0x000D05C4
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(4, MaxLevel, 0);
		}

		// Token: 0x06003FCF RID: 16335 RVA: 0x000D21CF File Offset: 0x000D05CF
		public static void AddUpgradeMaterials1(FlatBufferBuilder builder, VectorOffset UpgradeMaterials1Offset)
		{
			builder.AddOffset(5, UpgradeMaterials1Offset.Value, 0);
		}

		// Token: 0x06003FD0 RID: 16336 RVA: 0x000D21E0 File Offset: 0x000D05E0
		public static VectorOffset CreateUpgradeMaterials1Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FD1 RID: 16337 RVA: 0x000D2226 File Offset: 0x000D0626
		public static void StartUpgradeMaterials1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FD2 RID: 16338 RVA: 0x000D2231 File Offset: 0x000D0631
		public static void AddBaseRate1(FlatBufferBuilder builder, VectorOffset BaseRate1Offset)
		{
			builder.AddOffset(6, BaseRate1Offset.Value, 0);
		}

		// Token: 0x06003FD3 RID: 16339 RVA: 0x000D2244 File Offset: 0x000D0644
		public static VectorOffset CreateBaseRate1Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FD4 RID: 16340 RVA: 0x000D228A File Offset: 0x000D068A
		public static void StartBaseRate1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FD5 RID: 16341 RVA: 0x000D2295 File Offset: 0x000D0695
		public static void AddUpgradeMaterials2(FlatBufferBuilder builder, VectorOffset UpgradeMaterials2Offset)
		{
			builder.AddOffset(7, UpgradeMaterials2Offset.Value, 0);
		}

		// Token: 0x06003FD6 RID: 16342 RVA: 0x000D22A8 File Offset: 0x000D06A8
		public static VectorOffset CreateUpgradeMaterials2Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FD7 RID: 16343 RVA: 0x000D22EE File Offset: 0x000D06EE
		public static void StartUpgradeMaterials2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FD8 RID: 16344 RVA: 0x000D22F9 File Offset: 0x000D06F9
		public static void AddBaseRate2(FlatBufferBuilder builder, VectorOffset BaseRate2Offset)
		{
			builder.AddOffset(8, BaseRate2Offset.Value, 0);
		}

		// Token: 0x06003FD9 RID: 16345 RVA: 0x000D230C File Offset: 0x000D070C
		public static VectorOffset CreateBaseRate2Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FDA RID: 16346 RVA: 0x000D2352 File Offset: 0x000D0752
		public static void StartBaseRate2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FDB RID: 16347 RVA: 0x000D235D File Offset: 0x000D075D
		public static void AddUpgradeMaterials3(FlatBufferBuilder builder, VectorOffset UpgradeMaterials3Offset)
		{
			builder.AddOffset(9, UpgradeMaterials3Offset.Value, 0);
		}

		// Token: 0x06003FDC RID: 16348 RVA: 0x000D2370 File Offset: 0x000D0770
		public static VectorOffset CreateUpgradeMaterials3Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FDD RID: 16349 RVA: 0x000D23B6 File Offset: 0x000D07B6
		public static void StartUpgradeMaterials3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FDE RID: 16350 RVA: 0x000D23C1 File Offset: 0x000D07C1
		public static void AddBaseRate3(FlatBufferBuilder builder, VectorOffset BaseRate3Offset)
		{
			builder.AddOffset(10, BaseRate3Offset.Value, 0);
		}

		// Token: 0x06003FDF RID: 16351 RVA: 0x000D23D4 File Offset: 0x000D07D4
		public static VectorOffset CreateBaseRate3Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FE0 RID: 16352 RVA: 0x000D241A File Offset: 0x000D081A
		public static void StartBaseRate3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FE1 RID: 16353 RVA: 0x000D2425 File Offset: 0x000D0825
		public static void AddLevelAddRate(FlatBufferBuilder builder, VectorOffset LevelAddRateOffset)
		{
			builder.AddOffset(11, LevelAddRateOffset.Value, 0);
		}

		// Token: 0x06003FE2 RID: 16354 RVA: 0x000D2438 File Offset: 0x000D0838
		public static VectorOffset CreateLevelAddRateVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FE3 RID: 16355 RVA: 0x000D247E File Offset: 0x000D087E
		public static void StartLevelAddRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FE4 RID: 16356 RVA: 0x000D2489 File Offset: 0x000D0889
		public static void AddSameCardID(FlatBufferBuilder builder, VectorOffset SameCardIDOffset)
		{
			builder.AddOffset(12, SameCardIDOffset.Value, 0);
		}

		// Token: 0x06003FE5 RID: 16357 RVA: 0x000D249C File Offset: 0x000D089C
		public static VectorOffset CreateSameCardIDVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FE6 RID: 16358 RVA: 0x000D24E2 File Offset: 0x000D08E2
		public static void StartSameCardIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FE7 RID: 16359 RVA: 0x000D24ED File Offset: 0x000D08ED
		public static void AddSameCardAddRate(FlatBufferBuilder builder, VectorOffset SameCardAddRateOffset)
		{
			builder.AddOffset(13, SameCardAddRateOffset.Value, 0);
		}

		// Token: 0x06003FE8 RID: 16360 RVA: 0x000D2500 File Offset: 0x000D0900
		public static VectorOffset CreateSameCardAddRateVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003FE9 RID: 16361 RVA: 0x000D2546 File Offset: 0x000D0946
		public static void StartSameCardAddRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003FEA RID: 16362 RVA: 0x000D2551 File Offset: 0x000D0951
		public static void AddUpConsume(FlatBufferBuilder builder, StringOffset UpConsumeOffset)
		{
			builder.AddOffset(14, UpConsumeOffset.Value, 0);
		}

		// Token: 0x06003FEB RID: 16363 RVA: 0x000D2564 File Offset: 0x000D0964
		public static Offset<MagicCardUpdateTable> EndMagicCardUpdateTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MagicCardUpdateTable>(value);
		}

		// Token: 0x06003FEC RID: 16364 RVA: 0x000D257E File Offset: 0x000D097E
		public static void FinishMagicCardUpdateTableBuffer(FlatBufferBuilder builder, Offset<MagicCardUpdateTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400180D RID: 6157
		private Table __p = new Table();

		// Token: 0x0400180E RID: 6158
		private FlatBufferArray<string> UpgradeMaterials_1Value;

		// Token: 0x0400180F RID: 6159
		private FlatBufferArray<string> BaseRate_1Value;

		// Token: 0x04001810 RID: 6160
		private FlatBufferArray<string> UpgradeMaterials_2Value;

		// Token: 0x04001811 RID: 6161
		private FlatBufferArray<string> BaseRate_2Value;

		// Token: 0x04001812 RID: 6162
		private FlatBufferArray<string> UpgradeMaterials_3Value;

		// Token: 0x04001813 RID: 6163
		private FlatBufferArray<string> BaseRate_3Value;

		// Token: 0x04001814 RID: 6164
		private FlatBufferArray<string> LevelAddRateValue;

		// Token: 0x04001815 RID: 6165
		private FlatBufferArray<string> SameCardIDValue;

		// Token: 0x04001816 RID: 6166
		private FlatBufferArray<string> SameCardAddRateValue;

		// Token: 0x020004E6 RID: 1254
		public enum eCrypt
		{
			// Token: 0x04001818 RID: 6168
			code = 356485126
		}
	}
}
