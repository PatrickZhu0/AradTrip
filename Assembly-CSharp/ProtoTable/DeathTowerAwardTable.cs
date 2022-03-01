using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000371 RID: 881
	public class DeathTowerAwardTable : IFlatbufferObject
	{
		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06002586 RID: 9606 RVA: 0x000934DC File Offset: 0x000918DC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002587 RID: 9607 RVA: 0x000934E9 File Offset: 0x000918E9
		public static DeathTowerAwardTable GetRootAsDeathTowerAwardTable(ByteBuffer _bb)
		{
			return DeathTowerAwardTable.GetRootAsDeathTowerAwardTable(_bb, new DeathTowerAwardTable());
		}

		// Token: 0x06002588 RID: 9608 RVA: 0x000934F6 File Offset: 0x000918F6
		public static DeathTowerAwardTable GetRootAsDeathTowerAwardTable(ByteBuffer _bb, DeathTowerAwardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002589 RID: 9609 RVA: 0x00093512 File Offset: 0x00091912
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600258A RID: 9610 RVA: 0x0009352C File Offset: 0x0009192C
		public DeathTowerAwardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x0600258B RID: 9611 RVA: 0x00093538 File Offset: 0x00091938
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x0600258C RID: 9612 RVA: 0x00093584 File Offset: 0x00091984
		public int Floor
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x0600258D RID: 9613 RVA: 0x000935D0 File Offset: 0x000919D0
		public int exp
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x0600258E RID: 9614 RVA: 0x0009361C File Offset: 0x00091A1C
		public int WirrorSoul
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000822 RID: 2082
		// (get) Token: 0x0600258F RID: 9615 RVA: 0x00093668 File Offset: 0x00091A68
		public int Drop
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000823 RID: 2083
		// (get) Token: 0x06002590 RID: 9616 RVA: 0x000936B4 File Offset: 0x00091AB4
		public int AwardItem
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000824 RID: 2084
		// (get) Token: 0x06002591 RID: 9617 RVA: 0x00093700 File Offset: 0x00091B00
		public int AwardItemNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000825 RID: 2085
		// (get) Token: 0x06002592 RID: 9618 RVA: 0x0009374C File Offset: 0x00091B4C
		public int LimitLevel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-510387816 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002593 RID: 9619 RVA: 0x00093798 File Offset: 0x00091B98
		public static Offset<DeathTowerAwardTable> CreateDeathTowerAwardTable(FlatBufferBuilder builder, int ID = 0, int Floor = 0, int exp = 0, int WirrorSoul = 0, int Drop = 0, int AwardItem = 0, int AwardItemNum = 0, int LimitLevel = 0)
		{
			builder.StartObject(8);
			DeathTowerAwardTable.AddLimitLevel(builder, LimitLevel);
			DeathTowerAwardTable.AddAwardItemNum(builder, AwardItemNum);
			DeathTowerAwardTable.AddAwardItem(builder, AwardItem);
			DeathTowerAwardTable.AddDrop(builder, Drop);
			DeathTowerAwardTable.AddWirrorSoul(builder, WirrorSoul);
			DeathTowerAwardTable.AddExp(builder, exp);
			DeathTowerAwardTable.AddFloor(builder, Floor);
			DeathTowerAwardTable.AddID(builder, ID);
			return DeathTowerAwardTable.EndDeathTowerAwardTable(builder);
		}

		// Token: 0x06002594 RID: 9620 RVA: 0x000937EF File Offset: 0x00091BEF
		public static void StartDeathTowerAwardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x000937F8 File Offset: 0x00091BF8
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x00093803 File Offset: 0x00091C03
		public static void AddFloor(FlatBufferBuilder builder, int Floor)
		{
			builder.AddInt(1, Floor, 0);
		}

		// Token: 0x06002597 RID: 9623 RVA: 0x0009380E File Offset: 0x00091C0E
		public static void AddExp(FlatBufferBuilder builder, int exp)
		{
			builder.AddInt(2, exp, 0);
		}

		// Token: 0x06002598 RID: 9624 RVA: 0x00093819 File Offset: 0x00091C19
		public static void AddWirrorSoul(FlatBufferBuilder builder, int WirrorSoul)
		{
			builder.AddInt(3, WirrorSoul, 0);
		}

		// Token: 0x06002599 RID: 9625 RVA: 0x00093824 File Offset: 0x00091C24
		public static void AddDrop(FlatBufferBuilder builder, int Drop)
		{
			builder.AddInt(4, Drop, 0);
		}

		// Token: 0x0600259A RID: 9626 RVA: 0x0009382F File Offset: 0x00091C2F
		public static void AddAwardItem(FlatBufferBuilder builder, int AwardItem)
		{
			builder.AddInt(5, AwardItem, 0);
		}

		// Token: 0x0600259B RID: 9627 RVA: 0x0009383A File Offset: 0x00091C3A
		public static void AddAwardItemNum(FlatBufferBuilder builder, int AwardItemNum)
		{
			builder.AddInt(6, AwardItemNum, 0);
		}

		// Token: 0x0600259C RID: 9628 RVA: 0x00093845 File Offset: 0x00091C45
		public static void AddLimitLevel(FlatBufferBuilder builder, int LimitLevel)
		{
			builder.AddInt(7, LimitLevel, 0);
		}

		// Token: 0x0600259D RID: 9629 RVA: 0x00093850 File Offset: 0x00091C50
		public static Offset<DeathTowerAwardTable> EndDeathTowerAwardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DeathTowerAwardTable>(value);
		}

		// Token: 0x0600259E RID: 9630 RVA: 0x0009386A File Offset: 0x00091C6A
		public static void FinishDeathTowerAwardTableBuffer(FlatBufferBuilder builder, Offset<DeathTowerAwardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001175 RID: 4469
		private Table __p = new Table();

		// Token: 0x02000372 RID: 882
		public enum eCrypt
		{
			// Token: 0x04001177 RID: 4471
			code = -510387816
		}
	}
}
