using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000419 RID: 1049
	public class EquipmentRelationTable : IFlatbufferObject
	{
		// Token: 0x17000C2A RID: 3114
		// (get) Token: 0x06003205 RID: 12805 RVA: 0x000B1770 File Offset: 0x000AFB70
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003206 RID: 12806 RVA: 0x000B177D File Offset: 0x000AFB7D
		public static EquipmentRelationTable GetRootAsEquipmentRelationTable(ByteBuffer _bb)
		{
			return EquipmentRelationTable.GetRootAsEquipmentRelationTable(_bb, new EquipmentRelationTable());
		}

		// Token: 0x06003207 RID: 12807 RVA: 0x000B178A File Offset: 0x000AFB8A
		public static EquipmentRelationTable GetRootAsEquipmentRelationTable(ByteBuffer _bb, EquipmentRelationTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003208 RID: 12808 RVA: 0x000B17A6 File Offset: 0x000AFBA6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003209 RID: 12809 RVA: 0x000B17C0 File Offset: 0x000AFBC0
		public EquipmentRelationTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C2B RID: 3115
		// (get) Token: 0x0600320A RID: 12810 RVA: 0x000B17CC File Offset: 0x000AFBCC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1537414434 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C2C RID: 3116
		// (get) Token: 0x0600320B RID: 12811 RVA: 0x000B1818 File Offset: 0x000AFC18
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600320C RID: 12812 RVA: 0x000B185A File Offset: 0x000AFC5A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000C2D RID: 3117
		// (get) Token: 0x0600320D RID: 12813 RVA: 0x000B1868 File Offset: 0x000AFC68
		public EquipmentRelationTable.eItemType ItemType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (EquipmentRelationTable.eItemType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600320E RID: 12814 RVA: 0x000B18AC File Offset: 0x000AFCAC
		public int OccuArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1537414434 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C2E RID: 3118
		// (get) Token: 0x0600320F RID: 12815 RVA: 0x000B18FC File Offset: 0x000AFCFC
		public int OccuLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003210 RID: 12816 RVA: 0x000B192F File Offset: 0x000AFD2F
		public ArraySegment<byte>? GetOccuBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000C2F RID: 3119
		// (get) Token: 0x06003211 RID: 12817 RVA: 0x000B193E File Offset: 0x000AFD3E
		public FlatBufferArray<int> Occu
		{
			get
			{
				if (this.OccuValue == null)
				{
					this.OccuValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuArray), this.OccuLength);
				}
				return this.OccuValue;
			}
		}

		// Token: 0x17000C30 RID: 3120
		// (get) Token: 0x06003212 RID: 12818 RVA: 0x000B1970 File Offset: 0x000AFD70
		public int Priority
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1537414434 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C31 RID: 3121
		// (get) Token: 0x06003213 RID: 12819 RVA: 0x000B19BC File Offset: 0x000AFDBC
		public EquipmentRelationTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (EquipmentRelationTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003214 RID: 12820 RVA: 0x000B1A00 File Offset: 0x000AFE00
		public static Offset<EquipmentRelationTable> CreateEquipmentRelationTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), EquipmentRelationTable.eItemType ItemType = EquipmentRelationTable.eItemType.ItemType_None, VectorOffset OccuOffset = default(VectorOffset), int Priority = 0, EquipmentRelationTable.eSubType SubType = EquipmentRelationTable.eSubType.SubType_None)
		{
			builder.StartObject(6);
			EquipmentRelationTable.AddSubType(builder, SubType);
			EquipmentRelationTable.AddPriority(builder, Priority);
			EquipmentRelationTable.AddOccu(builder, OccuOffset);
			EquipmentRelationTable.AddItemType(builder, ItemType);
			EquipmentRelationTable.AddName(builder, NameOffset);
			EquipmentRelationTable.AddID(builder, ID);
			return EquipmentRelationTable.EndEquipmentRelationTable(builder);
		}

		// Token: 0x06003215 RID: 12821 RVA: 0x000B1A3C File Offset: 0x000AFE3C
		public static void StartEquipmentRelationTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06003216 RID: 12822 RVA: 0x000B1A45 File Offset: 0x000AFE45
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003217 RID: 12823 RVA: 0x000B1A50 File Offset: 0x000AFE50
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003218 RID: 12824 RVA: 0x000B1A61 File Offset: 0x000AFE61
		public static void AddItemType(FlatBufferBuilder builder, EquipmentRelationTable.eItemType ItemType)
		{
			builder.AddInt(2, (int)ItemType, 0);
		}

		// Token: 0x06003219 RID: 12825 RVA: 0x000B1A6C File Offset: 0x000AFE6C
		public static void AddOccu(FlatBufferBuilder builder, VectorOffset OccuOffset)
		{
			builder.AddOffset(3, OccuOffset.Value, 0);
		}

		// Token: 0x0600321A RID: 12826 RVA: 0x000B1A80 File Offset: 0x000AFE80
		public static VectorOffset CreateOccuVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600321B RID: 12827 RVA: 0x000B1ABD File Offset: 0x000AFEBD
		public static void StartOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600321C RID: 12828 RVA: 0x000B1AC8 File Offset: 0x000AFEC8
		public static void AddPriority(FlatBufferBuilder builder, int Priority)
		{
			builder.AddInt(4, Priority, 0);
		}

		// Token: 0x0600321D RID: 12829 RVA: 0x000B1AD3 File Offset: 0x000AFED3
		public static void AddSubType(FlatBufferBuilder builder, EquipmentRelationTable.eSubType SubType)
		{
			builder.AddInt(5, (int)SubType, 0);
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x000B1AE0 File Offset: 0x000AFEE0
		public static Offset<EquipmentRelationTable> EndEquipmentRelationTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipmentRelationTable>(value);
		}

		// Token: 0x0600321F RID: 12831 RVA: 0x000B1AFA File Offset: 0x000AFEFA
		public static void FinishEquipmentRelationTableBuffer(FlatBufferBuilder builder, Offset<EquipmentRelationTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001472 RID: 5234
		private Table __p = new Table();

		// Token: 0x04001473 RID: 5235
		private FlatBufferArray<int> OccuValue;

		// Token: 0x0200041A RID: 1050
		public enum eItemType
		{
			// Token: 0x04001475 RID: 5237
			ItemType_None,
			// Token: 0x04001476 RID: 5238
			CONGLINYOUXIADUI,
			// Token: 0x04001477 RID: 5239
			KUANGYEZHIXIN,
			// Token: 0x04001478 RID: 5240
			HUANGZUQISHITUAN,
			// Token: 0x04001479 RID: 5241
			ANYESHOUHUZHE,
			// Token: 0x0400147A RID: 5242
			XIAOYUANSHIGUANG,
			// Token: 0x0400147B RID: 5243
			BINGXUEQIYUAN,
			// Token: 0x0400147C RID: 5244
			YINENGZHE,
			// Token: 0x0400147D RID: 5245
			HEIQISHI,
			// Token: 0x0400147E RID: 5246
			BAISEXIANBING,
			// Token: 0x0400147F RID: 5247
			YINYUESHAONIAN,
			// Token: 0x04001480 RID: 5248
			HEIANSHITU,
			// Token: 0x04001481 RID: 5249
			QINGLIANGYIXIA,
			// Token: 0x04001482 RID: 5250
			JINJIDEYONGSHI,
			// Token: 0x04001483 RID: 5251
			FANGNIUWA,
			// Token: 0x04001484 RID: 5252
			YOUHONGMEIGUI,
			// Token: 0x04001485 RID: 5253
			JIDIBAIHU,
			// Token: 0x04001486 RID: 5254
			DONGRINUANYANGHONG,
			// Token: 0x04001487 RID: 5255
			DONGRINUANYANGQING,
			// Token: 0x04001488 RID: 5256
			SHENGDANSHIZHE,
			// Token: 0x04001489 RID: 5257
			GUANGXIUQINGMINGHONG,
			// Token: 0x0400148A RID: 5258
			GUANGXIUQINGMINGZI,
			// Token: 0x0400148B RID: 5259
			CHENGSHILIERENLAN,
			// Token: 0x0400148C RID: 5260
			CHENGSHILIERENBAI,
			// Token: 0x0400148D RID: 5261
			XINGCHENDAHAI,
			// Token: 0x0400148E RID: 5262
			ANYEMOYIHONG,
			// Token: 0x0400148F RID: 5263
			ANYEMOYIZI,
			// Token: 0x04001490 RID: 5264
			BAILINGXINGYU,
			// Token: 0x04001491 RID: 5265
			SHENGUANCIFUHONG,
			// Token: 0x04001492 RID: 5266
			SHENGUANCIFUZI,
			// Token: 0x04001493 RID: 5267
			TIANYEYUEHUA,
			// Token: 0x04001494 RID: 5268
			TIANZHOUGUANGYAO,
			// Token: 0x04001495 RID: 5269
			SHENGYAOLONGHUN,
			// Token: 0x04001496 RID: 5270
			KUWOPINSE,
			// Token: 0x04001497 RID: 5271
			KUXIA,
			// Token: 0x04001498 RID: 5272
			TOUMING,
			// Token: 0x04001499 RID: 5273
			ZHANGUOWUSHUANG,
			// Token: 0x0400149A RID: 5274
			WANSHENGJIE,
			// Token: 0x0400149B RID: 5275
			GUOQING,
			// Token: 0x0400149C RID: 5276
			GAOJIJIERI,
			// Token: 0x0400149D RID: 5277
			XIHAXUEYUAN,
			// Token: 0x0400149E RID: 5278
			SHENSHILIFU,
			// Token: 0x0400149F RID: 5279
			BAIYIN,
			// Token: 0x040014A0 RID: 5280
			HUANGJIN,
			// Token: 0x040014A1 RID: 5281
			DONGRILIANGE,
			// Token: 0x040014A2 RID: 5282
			DOUZHANTIANDI,
			// Token: 0x040014A3 RID: 5283
			MOYUFEIBAI,
			// Token: 0x040014A4 RID: 5284
			REXUEWUXIAN,
			// Token: 0x040014A5 RID: 5285
			SIYUESHIZHUANG,
			// Token: 0x040014A6 RID: 5286
			WEILAIZHANSHI,
			// Token: 0x040014A7 RID: 5287
			REXUEGUANLAN,
			// Token: 0x040014A8 RID: 5288
			EMOZHIWEN,
			// Token: 0x040014A9 RID: 5289
			GUOSHIWUSHUANG,
			// Token: 0x040014AA RID: 5290
			JIXIANGRUYI,
			// Token: 0x040014AB RID: 5291
			TIANQIONGSHOUHUZHE,
			// Token: 0x040014AC RID: 5292
			TIANSANLAN,
			// Token: 0x040014AD RID: 5293
			TIANSANJIN,
			// Token: 0x040014AE RID: 5294
			QIMIAODONGWU,
			// Token: 0x040014AF RID: 5295
			SHATANPAIDUI,
			// Token: 0x040014B0 RID: 5296
			XIHAHUANXIANG,
			// Token: 0x040014B1 RID: 5297
			CHIBANG = 100,
			// Token: 0x040014B2 RID: 5298
			QITA = 1000
		}

		// Token: 0x0200041B RID: 1051
		public enum eSubType
		{
			// Token: 0x040014B4 RID: 5300
			SubType_None,
			// Token: 0x040014B5 RID: 5301
			FASHION_HAIR = 11,
			// Token: 0x040014B6 RID: 5302
			FASHION_HEAD,
			// Token: 0x040014B7 RID: 5303
			FASHION_SASH,
			// Token: 0x040014B8 RID: 5304
			FASHION_CHEST,
			// Token: 0x040014B9 RID: 5305
			FASHION_LEG,
			// Token: 0x040014BA RID: 5306
			FASHION_EPAULET
		}

		// Token: 0x0200041C RID: 1052
		public enum eCrypt
		{
			// Token: 0x040014BC RID: 5308
			code = -1537414434
		}
	}
}
