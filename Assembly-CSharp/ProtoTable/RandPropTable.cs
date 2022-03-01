using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200056C RID: 1388
	public class RandPropTable : IFlatbufferObject
	{
		// Token: 0x17001342 RID: 4930
		// (get) Token: 0x06004780 RID: 18304 RVA: 0x000E3BB4 File Offset: 0x000E1FB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004781 RID: 18305 RVA: 0x000E3BC1 File Offset: 0x000E1FC1
		public static RandPropTable GetRootAsRandPropTable(ByteBuffer _bb)
		{
			return RandPropTable.GetRootAsRandPropTable(_bb, new RandPropTable());
		}

		// Token: 0x06004782 RID: 18306 RVA: 0x000E3BCE File Offset: 0x000E1FCE
		public static RandPropTable GetRootAsRandPropTable(ByteBuffer _bb, RandPropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004783 RID: 18307 RVA: 0x000E3BEA File Offset: 0x000E1FEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004784 RID: 18308 RVA: 0x000E3C04 File Offset: 0x000E2004
		public RandPropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001343 RID: 4931
		// (get) Token: 0x06004785 RID: 18309 RVA: 0x000E3C10 File Offset: 0x000E2010
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (919218542 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001344 RID: 4932
		// (get) Token: 0x06004786 RID: 18310 RVA: 0x000E3C5C File Offset: 0x000E205C
		public RandPropTable.eRandType RandType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (RandPropTable.eRandType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001345 RID: 4933
		// (get) Token: 0x06004787 RID: 18311 RVA: 0x000E3CA0 File Offset: 0x000E20A0
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (919218542 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004788 RID: 18312 RVA: 0x000E3CE9 File Offset: 0x000E20E9
		public static Offset<RandPropTable> CreateRandPropTable(FlatBufferBuilder builder, int ID = 0, RandPropTable.eRandType RandType = RandPropTable.eRandType.RandType_None, int Weight = 0)
		{
			builder.StartObject(3);
			RandPropTable.AddWeight(builder, Weight);
			RandPropTable.AddRandType(builder, RandType);
			RandPropTable.AddID(builder, ID);
			return RandPropTable.EndRandPropTable(builder);
		}

		// Token: 0x06004789 RID: 18313 RVA: 0x000E3D0D File Offset: 0x000E210D
		public static void StartRandPropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600478A RID: 18314 RVA: 0x000E3D16 File Offset: 0x000E2116
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600478B RID: 18315 RVA: 0x000E3D21 File Offset: 0x000E2121
		public static void AddRandType(FlatBufferBuilder builder, RandPropTable.eRandType RandType)
		{
			builder.AddInt(1, (int)RandType, 0);
		}

		// Token: 0x0600478C RID: 18316 RVA: 0x000E3D2C File Offset: 0x000E212C
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(2, Weight, 0);
		}

		// Token: 0x0600478D RID: 18317 RVA: 0x000E3D38 File Offset: 0x000E2138
		public static Offset<RandPropTable> EndRandPropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RandPropTable>(value);
		}

		// Token: 0x0600478E RID: 18318 RVA: 0x000E3D52 File Offset: 0x000E2152
		public static void FinishRandPropTableBuffer(FlatBufferBuilder builder, Offset<RandPropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A4F RID: 6735
		private Table __p = new Table();

		// Token: 0x0200056D RID: 1389
		public enum eRandType
		{
			// Token: 0x04001A51 RID: 6737
			RandType_None,
			// Token: 0x04001A52 RID: 6738
			STR,
			// Token: 0x04001A53 RID: 6739
			STA,
			// Token: 0x04001A54 RID: 6740
			INT,
			// Token: 0x04001A55 RID: 6741
			SPR,
			// Token: 0x04001A56 RID: 6742
			HPMAX,
			// Token: 0x04001A57 RID: 6743
			MPMAX,
			// Token: 0x04001A58 RID: 6744
			HPREC,
			// Token: 0x04001A59 RID: 6745
			MPREC,
			// Token: 0x04001A5A RID: 6746
			HIT,
			// Token: 0x04001A5B RID: 6747
			DEX,
			// Token: 0x04001A5C RID: 6748
			PHYCRT,
			// Token: 0x04001A5D RID: 6749
			MGCCRT,
			// Token: 0x04001A5E RID: 6750
			ATKSPD,
			// Token: 0x04001A5F RID: 6751
			RDYSPD,
			// Token: 0x04001A60 RID: 6752
			MOVSPD,
			// Token: 0x04001A61 RID: 6753
			JUMP,
			// Token: 0x04001A62 RID: 6754
			HITREC
		}

		// Token: 0x0200056E RID: 1390
		public enum eCrypt
		{
			// Token: 0x04001A64 RID: 6756
			code = 919218542
		}
	}
}
