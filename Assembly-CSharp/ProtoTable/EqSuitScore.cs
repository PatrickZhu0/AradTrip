using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003C3 RID: 963
	public class EqSuitScore : IFlatbufferObject
	{
		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06002B5A RID: 11098 RVA: 0x000A1778 File Offset: 0x0009FB78
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002B5B RID: 11099 RVA: 0x000A1785 File Offset: 0x0009FB85
		public static EqSuitScore GetRootAsEqSuitScore(ByteBuffer _bb)
		{
			return EqSuitScore.GetRootAsEqSuitScore(_bb, new EqSuitScore());
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x000A1792 File Offset: 0x0009FB92
		public static EqSuitScore GetRootAsEqSuitScore(ByteBuffer _bb, EqSuitScore obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002B5D RID: 11101 RVA: 0x000A17AE File Offset: 0x0009FBAE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002B5E RID: 11102 RVA: 0x000A17C8 File Offset: 0x0009FBC8
		public EqSuitScore __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x06002B5F RID: 11103 RVA: 0x000A17D4 File Offset: 0x0009FBD4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2140979931 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06002B60 RID: 11104 RVA: 0x000A1820 File Offset: 0x0009FC20
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2140979931 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06002B61 RID: 11105 RVA: 0x000A186C File Offset: 0x0009FC6C
		public int SuitNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2140979931 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06002B62 RID: 11106 RVA: 0x000A18B8 File Offset: 0x0009FCB8
		public int Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (2140979931 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06002B63 RID: 11107 RVA: 0x000A1904 File Offset: 0x0009FD04
		public int EquipsAttrID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (2140979931 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x000A194E File Offset: 0x0009FD4E
		public static Offset<EqSuitScore> CreateEqSuitScore(FlatBufferBuilder builder, int ID = 0, int Type = 0, int SuitNum = 0, int Level = 0, int EquipsAttrID = 0)
		{
			builder.StartObject(5);
			EqSuitScore.AddEquipsAttrID(builder, EquipsAttrID);
			EqSuitScore.AddLevel(builder, Level);
			EqSuitScore.AddSuitNum(builder, SuitNum);
			EqSuitScore.AddType(builder, Type);
			EqSuitScore.AddID(builder, ID);
			return EqSuitScore.EndEqSuitScore(builder);
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x000A1982 File Offset: 0x0009FD82
		public static void StartEqSuitScore(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x000A198B File Offset: 0x0009FD8B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x000A1996 File Offset: 0x0009FD96
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06002B68 RID: 11112 RVA: 0x000A19A1 File Offset: 0x0009FDA1
		public static void AddSuitNum(FlatBufferBuilder builder, int SuitNum)
		{
			builder.AddInt(2, SuitNum, 0);
		}

		// Token: 0x06002B69 RID: 11113 RVA: 0x000A19AC File Offset: 0x0009FDAC
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(3, Level, 0);
		}

		// Token: 0x06002B6A RID: 11114 RVA: 0x000A19B7 File Offset: 0x0009FDB7
		public static void AddEquipsAttrID(FlatBufferBuilder builder, int EquipsAttrID)
		{
			builder.AddInt(4, EquipsAttrID, 0);
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x000A19C4 File Offset: 0x0009FDC4
		public static Offset<EqSuitScore> EndEqSuitScore(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EqSuitScore>(value);
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x000A19DE File Offset: 0x0009FDDE
		public static void FinishEqSuitScoreBuffer(FlatBufferBuilder builder, Offset<EqSuitScore> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001287 RID: 4743
		private Table __p = new Table();

		// Token: 0x020003C4 RID: 964
		public enum eCrypt
		{
			// Token: 0x04001289 RID: 4745
			code = 2140979931
		}
	}
}
