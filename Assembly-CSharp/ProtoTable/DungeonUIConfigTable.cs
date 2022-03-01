using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003B3 RID: 947
	public class DungeonUIConfigTable : IFlatbufferObject
	{
		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06002A4B RID: 10827 RVA: 0x0009EB20 File Offset: 0x0009CF20
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002A4C RID: 10828 RVA: 0x0009EB2D File Offset: 0x0009CF2D
		public static DungeonUIConfigTable GetRootAsDungeonUIConfigTable(ByteBuffer _bb)
		{
			return DungeonUIConfigTable.GetRootAsDungeonUIConfigTable(_bb, new DungeonUIConfigTable());
		}

		// Token: 0x06002A4D RID: 10829 RVA: 0x0009EB3A File Offset: 0x0009CF3A
		public static DungeonUIConfigTable GetRootAsDungeonUIConfigTable(ByteBuffer _bb, DungeonUIConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002A4E RID: 10830 RVA: 0x0009EB56 File Offset: 0x0009CF56
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002A4F RID: 10831 RVA: 0x0009EB70 File Offset: 0x0009CF70
		public DungeonUIConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06002A50 RID: 10832 RVA: 0x0009EB7C File Offset: 0x0009CF7C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (535724232 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002A51 RID: 10833 RVA: 0x0009EBC8 File Offset: 0x0009CFC8
		public DungeonUIConfigTable.eCommon CommonArray(int j)
		{
			int num = this.__p.__offset(6);
			return (DungeonUIConfigTable.eCommon)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06002A52 RID: 10834 RVA: 0x0009EC10 File Offset: 0x0009D010
		public int CommonLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002A53 RID: 10835 RVA: 0x0009EC42 File Offset: 0x0009D042
		public ArraySegment<byte>? GetCommonBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x06002A54 RID: 10836 RVA: 0x0009EC50 File Offset: 0x0009D050
		public FlatBufferArray<DungeonUIConfigTable.eCommon> Common
		{
			get
			{
				if (this.CommonValue == null)
				{
					this.CommonValue = new FlatBufferArray<DungeonUIConfigTable.eCommon>(new Func<int, DungeonUIConfigTable.eCommon>(this.CommonArray), this.CommonLength);
				}
				return this.CommonValue;
			}
		}

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x06002A55 RID: 10837 RVA: 0x0009EC80 File Offset: 0x0009D080
		public string ClassName
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A56 RID: 10838 RVA: 0x0009ECC2 File Offset: 0x0009D0C2
		public ArraySegment<byte>? GetClassNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x06002A57 RID: 10839 RVA: 0x0009ECD0 File Offset: 0x0009D0D0
		public string BackgroundPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A58 RID: 10840 RVA: 0x0009ED13 File Offset: 0x0009D113
		public ArraySegment<byte>? GetBackgroundPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06002A59 RID: 10841 RVA: 0x0009ED24 File Offset: 0x0009D124
		public string LeftPannelConfig
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A5A RID: 10842 RVA: 0x0009ED67 File Offset: 0x0009D167
		public ArraySegment<byte>? GetLeftPannelConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06002A5B RID: 10843 RVA: 0x0009ED78 File Offset: 0x0009D178
		public string RightPannelConfig
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A5C RID: 10844 RVA: 0x0009EDBB File Offset: 0x0009D1BB
		public ArraySegment<byte>? GetRightPannelConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06002A5D RID: 10845 RVA: 0x0009EDCC File Offset: 0x0009D1CC
		public string AreaDialogArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06002A5E RID: 10846 RVA: 0x0009EE14 File Offset: 0x0009D214
		public int AreaDialogLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06002A5F RID: 10847 RVA: 0x0009EE47 File Offset: 0x0009D247
		public FlatBufferArray<string> AreaDialog
		{
			get
			{
				if (this.AreaDialogValue == null)
				{
					this.AreaDialogValue = new FlatBufferArray<string>(new Func<int, string>(this.AreaDialogArray), this.AreaDialogLength);
				}
				return this.AreaDialogValue;
			}
		}

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06002A60 RID: 10848 RVA: 0x0009EE78 File Offset: 0x0009D278
		public string CharactorConfig
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A61 RID: 10849 RVA: 0x0009EEBB File Offset: 0x0009D2BB
		public ArraySegment<byte>? GetCharactorConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x06002A62 RID: 10850 RVA: 0x0009EECC File Offset: 0x0009D2CC
		public string AreaAfterDialogArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x06002A63 RID: 10851 RVA: 0x0009EF14 File Offset: 0x0009D314
		public int AreaAfterDialogLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x06002A64 RID: 10852 RVA: 0x0009EF47 File Offset: 0x0009D347
		public FlatBufferArray<string> AreaAfterDialog
		{
			get
			{
				if (this.AreaAfterDialogValue == null)
				{
					this.AreaAfterDialogValue = new FlatBufferArray<string>(new Func<int, string>(this.AreaAfterDialogArray), this.AreaAfterDialogLength);
				}
				return this.AreaAfterDialogValue;
			}
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x0009EF78 File Offset: 0x0009D378
		public static Offset<DungeonUIConfigTable> CreateDungeonUIConfigTable(FlatBufferBuilder builder, int ID = 0, VectorOffset CommonOffset = default(VectorOffset), StringOffset ClassNameOffset = default(StringOffset), StringOffset BackgroundPathOffset = default(StringOffset), StringOffset LeftPannelConfigOffset = default(StringOffset), StringOffset RightPannelConfigOffset = default(StringOffset), VectorOffset AreaDialogOffset = default(VectorOffset), StringOffset CharactorConfigOffset = default(StringOffset), VectorOffset AreaAfterDialogOffset = default(VectorOffset))
		{
			builder.StartObject(9);
			DungeonUIConfigTable.AddAreaAfterDialog(builder, AreaAfterDialogOffset);
			DungeonUIConfigTable.AddCharactorConfig(builder, CharactorConfigOffset);
			DungeonUIConfigTable.AddAreaDialog(builder, AreaDialogOffset);
			DungeonUIConfigTable.AddRightPannelConfig(builder, RightPannelConfigOffset);
			DungeonUIConfigTable.AddLeftPannelConfig(builder, LeftPannelConfigOffset);
			DungeonUIConfigTable.AddBackgroundPath(builder, BackgroundPathOffset);
			DungeonUIConfigTable.AddClassName(builder, ClassNameOffset);
			DungeonUIConfigTable.AddCommon(builder, CommonOffset);
			DungeonUIConfigTable.AddID(builder, ID);
			return DungeonUIConfigTable.EndDungeonUIConfigTable(builder);
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x0009EFD8 File Offset: 0x0009D3D8
		public static void StartDungeonUIConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06002A67 RID: 10855 RVA: 0x0009EFE2 File Offset: 0x0009D3E2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002A68 RID: 10856 RVA: 0x0009EFED File Offset: 0x0009D3ED
		public static void AddCommon(FlatBufferBuilder builder, VectorOffset CommonOffset)
		{
			builder.AddOffset(1, CommonOffset.Value, 0);
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0009F000 File Offset: 0x0009D400
		public static VectorOffset CreateCommonVector(FlatBufferBuilder builder, DungeonUIConfigTable.eCommon[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x0009F03D File Offset: 0x0009D43D
		public static void StartCommonVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0009F048 File Offset: 0x0009D448
		public static void AddClassName(FlatBufferBuilder builder, StringOffset ClassNameOffset)
		{
			builder.AddOffset(2, ClassNameOffset.Value, 0);
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x0009F059 File Offset: 0x0009D459
		public static void AddBackgroundPath(FlatBufferBuilder builder, StringOffset BackgroundPathOffset)
		{
			builder.AddOffset(3, BackgroundPathOffset.Value, 0);
		}

		// Token: 0x06002A6D RID: 10861 RVA: 0x0009F06A File Offset: 0x0009D46A
		public static void AddLeftPannelConfig(FlatBufferBuilder builder, StringOffset LeftPannelConfigOffset)
		{
			builder.AddOffset(4, LeftPannelConfigOffset.Value, 0);
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x0009F07B File Offset: 0x0009D47B
		public static void AddRightPannelConfig(FlatBufferBuilder builder, StringOffset RightPannelConfigOffset)
		{
			builder.AddOffset(5, RightPannelConfigOffset.Value, 0);
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x0009F08C File Offset: 0x0009D48C
		public static void AddAreaDialog(FlatBufferBuilder builder, VectorOffset AreaDialogOffset)
		{
			builder.AddOffset(6, AreaDialogOffset.Value, 0);
		}

		// Token: 0x06002A70 RID: 10864 RVA: 0x0009F0A0 File Offset: 0x0009D4A0
		public static VectorOffset CreateAreaDialogVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0009F0E6 File Offset: 0x0009D4E6
		public static void StartAreaDialogVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x0009F0F1 File Offset: 0x0009D4F1
		public static void AddCharactorConfig(FlatBufferBuilder builder, StringOffset CharactorConfigOffset)
		{
			builder.AddOffset(7, CharactorConfigOffset.Value, 0);
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x0009F102 File Offset: 0x0009D502
		public static void AddAreaAfterDialog(FlatBufferBuilder builder, VectorOffset AreaAfterDialogOffset)
		{
			builder.AddOffset(8, AreaAfterDialogOffset.Value, 0);
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x0009F114 File Offset: 0x0009D514
		public static VectorOffset CreateAreaAfterDialogVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A75 RID: 10869 RVA: 0x0009F15A File Offset: 0x0009D55A
		public static void StartAreaAfterDialogVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x0009F168 File Offset: 0x0009D568
		public static Offset<DungeonUIConfigTable> EndDungeonUIConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonUIConfigTable>(value);
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0009F182 File Offset: 0x0009D582
		public static void FinishDungeonUIConfigTableBuffer(FlatBufferBuilder builder, Offset<DungeonUIConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400124D RID: 4685
		private Table __p = new Table();

		// Token: 0x0400124E RID: 4686
		private FlatBufferArray<DungeonUIConfigTable.eCommon> CommonValue;

		// Token: 0x0400124F RID: 4687
		private FlatBufferArray<string> AreaDialogValue;

		// Token: 0x04001250 RID: 4688
		private FlatBufferArray<string> AreaAfterDialogValue;

		// Token: 0x020003B4 RID: 948
		public enum eCommon
		{
			// Token: 0x04001252 RID: 4690
			NONE,
			// Token: 0x04001253 RID: 4691
			GOLD,
			// Token: 0x04001254 RID: 4692
			FATIGUE,
			// Token: 0x04001255 RID: 4693
			TICKET,
			// Token: 0x04001256 RID: 4694
			DEADCOIN,
			// Token: 0x04001257 RID: 4695
			HELLTICKET
		}

		// Token: 0x020003B5 RID: 949
		public enum eCrypt
		{
			// Token: 0x04001259 RID: 4697
			code = 535724232
		}
	}
}
