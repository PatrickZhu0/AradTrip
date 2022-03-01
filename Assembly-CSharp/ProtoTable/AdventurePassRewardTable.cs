using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000291 RID: 657
	public class AdventurePassRewardTable : IFlatbufferObject
	{
		// Token: 0x1700034F RID: 847
		// (get) Token: 0x0600175A RID: 5978 RVA: 0x00071590 File Offset: 0x0006F990
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0007159D File Offset: 0x0006F99D
		public static AdventurePassRewardTable GetRootAsAdventurePassRewardTable(ByteBuffer _bb)
		{
			return AdventurePassRewardTable.GetRootAsAdventurePassRewardTable(_bb, new AdventurePassRewardTable());
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x000715AA File Offset: 0x0006F9AA
		public static AdventurePassRewardTable GetRootAsAdventurePassRewardTable(ByteBuffer _bb, AdventurePassRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x000715C6 File Offset: 0x0006F9C6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x000715E0 File Offset: 0x0006F9E0
		public AdventurePassRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x000715EC File Offset: 0x0006F9EC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-320472002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06001760 RID: 5984 RVA: 0x00071638 File Offset: 0x0006FA38
		public int Season
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-320472002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06001761 RID: 5985 RVA: 0x00071684 File Offset: 0x0006FA84
		public int Lv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-320472002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x000716D0 File Offset: 0x0006FAD0
		public string Normal
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x00071713 File Offset: 0x0006FB13
		public ArraySegment<byte>? GetNormalBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x00071724 File Offset: 0x0006FB24
		public string High
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x00071767 File Offset: 0x0006FB67
		public ArraySegment<byte>? GetHighBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06001766 RID: 5990 RVA: 0x00071778 File Offset: 0x0006FB78
		public int Exp
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-320472002 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x000717C2 File Offset: 0x0006FBC2
		public static Offset<AdventurePassRewardTable> CreateAdventurePassRewardTable(FlatBufferBuilder builder, int ID = 0, int Season = 0, int Lv = 0, StringOffset NormalOffset = default(StringOffset), StringOffset HighOffset = default(StringOffset), int Exp = 0)
		{
			builder.StartObject(6);
			AdventurePassRewardTable.AddExp(builder, Exp);
			AdventurePassRewardTable.AddHigh(builder, HighOffset);
			AdventurePassRewardTable.AddNormal(builder, NormalOffset);
			AdventurePassRewardTable.AddLv(builder, Lv);
			AdventurePassRewardTable.AddSeason(builder, Season);
			AdventurePassRewardTable.AddID(builder, ID);
			return AdventurePassRewardTable.EndAdventurePassRewardTable(builder);
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x000717FE File Offset: 0x0006FBFE
		public static void StartAdventurePassRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x00071807 File Offset: 0x0006FC07
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x00071812 File Offset: 0x0006FC12
		public static void AddSeason(FlatBufferBuilder builder, int Season)
		{
			builder.AddInt(1, Season, 0);
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x0007181D File Offset: 0x0006FC1D
		public static void AddLv(FlatBufferBuilder builder, int Lv)
		{
			builder.AddInt(2, Lv, 0);
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x00071828 File Offset: 0x0006FC28
		public static void AddNormal(FlatBufferBuilder builder, StringOffset NormalOffset)
		{
			builder.AddOffset(3, NormalOffset.Value, 0);
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x00071839 File Offset: 0x0006FC39
		public static void AddHigh(FlatBufferBuilder builder, StringOffset HighOffset)
		{
			builder.AddOffset(4, HighOffset.Value, 0);
		}

		// Token: 0x0600176E RID: 5998 RVA: 0x0007184A File Offset: 0x0006FC4A
		public static void AddExp(FlatBufferBuilder builder, int Exp)
		{
			builder.AddInt(5, Exp, 0);
		}

		// Token: 0x0600176F RID: 5999 RVA: 0x00071858 File Offset: 0x0006FC58
		public static Offset<AdventurePassRewardTable> EndAdventurePassRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventurePassRewardTable>(value);
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x00071872 File Offset: 0x0006FC72
		public static void FinishAdventurePassRewardTableBuffer(FlatBufferBuilder builder, Offset<AdventurePassRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DCB RID: 3531
		private Table __p = new Table();

		// Token: 0x02000292 RID: 658
		public enum eCrypt
		{
			// Token: 0x04000DCD RID: 3533
			code = -320472002
		}
	}
}
