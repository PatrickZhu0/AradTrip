using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000378 RID: 888
	public class DestrucTable : IFlatbufferObject
	{
		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x060025FD RID: 9725 RVA: 0x00094630 File Offset: 0x00092A30
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x0009463D File Offset: 0x00092A3D
		public static DestrucTable GetRootAsDestrucTable(ByteBuffer _bb)
		{
			return DestrucTable.GetRootAsDestrucTable(_bb, new DestrucTable());
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x0009464A File Offset: 0x00092A4A
		public static DestrucTable GetRootAsDestrucTable(ByteBuffer _bb, DestrucTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002600 RID: 9728 RVA: 0x00094666 File Offset: 0x00092A66
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002601 RID: 9729 RVA: 0x00094680 File Offset: 0x00092A80
		public DestrucTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06002602 RID: 9730 RVA: 0x0009468C File Offset: 0x00092A8C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06002603 RID: 9731 RVA: 0x000946D8 File Offset: 0x00092AD8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002604 RID: 9732 RVA: 0x0009471A File Offset: 0x00092B1A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06002605 RID: 9733 RVA: 0x00094728 File Offset: 0x00092B28
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002606 RID: 9734 RVA: 0x0009476A File Offset: 0x00092B6A
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06002607 RID: 9735 RVA: 0x00094778 File Offset: 0x00092B78
		public DestrucTable.eCamp Camp
		{
			get
			{
				int num = this.__p.__offset(10);
				return (DestrucTable.eCamp)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06002608 RID: 9736 RVA: 0x000947BC File Offset: 0x00092BBC
		public int Mode
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06002609 RID: 9737 RVA: 0x00094808 File Offset: 0x00092C08
		public int Level
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x0600260A RID: 9738 RVA: 0x00094854 File Offset: 0x00092C54
		public string Hurt
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600260B RID: 9739 RVA: 0x00094897 File Offset: 0x00092C97
		public ArraySegment<byte>? GetHurtBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x0600260C RID: 9740 RVA: 0x000948A8 File Offset: 0x00092CA8
		public string DeadEffect
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600260D RID: 9741 RVA: 0x000948EB File Offset: 0x00092CEB
		public ArraySegment<byte>? GetDeadEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x0600260E RID: 9742 RVA: 0x000948FC File Offset: 0x00092CFC
		public int Exp
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x0600260F RID: 9743 RVA: 0x00094948 File Offset: 0x00092D48
		public int PrefixID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06002610 RID: 9744 RVA: 0x00094994 File Offset: 0x00092D94
		public int DropID
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06002611 RID: 9745 RVA: 0x000949E0 File Offset: 0x00092DE0
		public UnionCell IdleSplitCount
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06002612 RID: 9746 RVA: 0x00094A38 File Offset: 0x00092E38
		public int IdleCount
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06002613 RID: 9747 RVA: 0x00094A84 File Offset: 0x00092E84
		public int DestructHitCount
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1318618776 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06002614 RID: 9748 RVA: 0x00094AD0 File Offset: 0x00092ED0
		public DestrucTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(32);
				return (DestrucTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06002615 RID: 9749 RVA: 0x00094B14 File Offset: 0x00092F14
		public bool IsDestruct
		{
			get
			{
				int num = this.__p.__offset(34);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002616 RID: 9750 RVA: 0x00094B60 File Offset: 0x00092F60
		public static Offset<DestrucTable> CreateDestrucTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), DestrucTable.eCamp Camp = DestrucTable.eCamp.C_HERO, int Mode = 0, int Level = 0, StringOffset HurtOffset = default(StringOffset), StringOffset DeadEffectOffset = default(StringOffset), int Exp = 0, int PrefixID = 0, int DropID = 0, Offset<UnionCell> IdleSplitCountOffset = default(Offset<UnionCell>), int IdleCount = 0, int DestructHitCount = 0, DestrucTable.eType Type = DestrucTable.eType.NONE, bool IsDestruct = false)
		{
			builder.StartObject(16);
			DestrucTable.AddType(builder, Type);
			DestrucTable.AddDestructHitCount(builder, DestructHitCount);
			DestrucTable.AddIdleCount(builder, IdleCount);
			DestrucTable.AddIdleSplitCount(builder, IdleSplitCountOffset);
			DestrucTable.AddDropID(builder, DropID);
			DestrucTable.AddPrefixID(builder, PrefixID);
			DestrucTable.AddExp(builder, Exp);
			DestrucTable.AddDeadEffect(builder, DeadEffectOffset);
			DestrucTable.AddHurt(builder, HurtOffset);
			DestrucTable.AddLevel(builder, Level);
			DestrucTable.AddMode(builder, Mode);
			DestrucTable.AddCamp(builder, Camp);
			DestrucTable.AddDesc(builder, DescOffset);
			DestrucTable.AddName(builder, NameOffset);
			DestrucTable.AddID(builder, ID);
			DestrucTable.AddIsDestruct(builder, IsDestruct);
			return DestrucTable.EndDestrucTable(builder);
		}

		// Token: 0x06002617 RID: 9751 RVA: 0x00094BF8 File Offset: 0x00092FF8
		public static void StartDestrucTable(FlatBufferBuilder builder)
		{
			builder.StartObject(16);
		}

		// Token: 0x06002618 RID: 9752 RVA: 0x00094C02 File Offset: 0x00093002
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002619 RID: 9753 RVA: 0x00094C0D File Offset: 0x0009300D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600261A RID: 9754 RVA: 0x00094C1E File Offset: 0x0009301E
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x0600261B RID: 9755 RVA: 0x00094C2F File Offset: 0x0009302F
		public static void AddCamp(FlatBufferBuilder builder, DestrucTable.eCamp Camp)
		{
			builder.AddInt(3, (int)Camp, 0);
		}

		// Token: 0x0600261C RID: 9756 RVA: 0x00094C3A File Offset: 0x0009303A
		public static void AddMode(FlatBufferBuilder builder, int Mode)
		{
			builder.AddInt(4, Mode, 0);
		}

		// Token: 0x0600261D RID: 9757 RVA: 0x00094C45 File Offset: 0x00093045
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(5, Level, 0);
		}

		// Token: 0x0600261E RID: 9758 RVA: 0x00094C50 File Offset: 0x00093050
		public static void AddHurt(FlatBufferBuilder builder, StringOffset HurtOffset)
		{
			builder.AddOffset(6, HurtOffset.Value, 0);
		}

		// Token: 0x0600261F RID: 9759 RVA: 0x00094C61 File Offset: 0x00093061
		public static void AddDeadEffect(FlatBufferBuilder builder, StringOffset DeadEffectOffset)
		{
			builder.AddOffset(7, DeadEffectOffset.Value, 0);
		}

		// Token: 0x06002620 RID: 9760 RVA: 0x00094C72 File Offset: 0x00093072
		public static void AddExp(FlatBufferBuilder builder, int Exp)
		{
			builder.AddInt(8, Exp, 0);
		}

		// Token: 0x06002621 RID: 9761 RVA: 0x00094C7D File Offset: 0x0009307D
		public static void AddPrefixID(FlatBufferBuilder builder, int PrefixID)
		{
			builder.AddInt(9, PrefixID, 0);
		}

		// Token: 0x06002622 RID: 9762 RVA: 0x00094C89 File Offset: 0x00093089
		public static void AddDropID(FlatBufferBuilder builder, int DropID)
		{
			builder.AddInt(10, DropID, 0);
		}

		// Token: 0x06002623 RID: 9763 RVA: 0x00094C95 File Offset: 0x00093095
		public static void AddIdleSplitCount(FlatBufferBuilder builder, Offset<UnionCell> IdleSplitCountOffset)
		{
			builder.AddOffset(11, IdleSplitCountOffset.Value, 0);
		}

		// Token: 0x06002624 RID: 9764 RVA: 0x00094CA7 File Offset: 0x000930A7
		public static void AddIdleCount(FlatBufferBuilder builder, int IdleCount)
		{
			builder.AddInt(12, IdleCount, 0);
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x00094CB3 File Offset: 0x000930B3
		public static void AddDestructHitCount(FlatBufferBuilder builder, int DestructHitCount)
		{
			builder.AddInt(13, DestructHitCount, 0);
		}

		// Token: 0x06002626 RID: 9766 RVA: 0x00094CBF File Offset: 0x000930BF
		public static void AddType(FlatBufferBuilder builder, DestrucTable.eType Type)
		{
			builder.AddInt(14, (int)Type, 0);
		}

		// Token: 0x06002627 RID: 9767 RVA: 0x00094CCB File Offset: 0x000930CB
		public static void AddIsDestruct(FlatBufferBuilder builder, bool IsDestruct)
		{
			builder.AddBool(15, IsDestruct, false);
		}

		// Token: 0x06002628 RID: 9768 RVA: 0x00094CD8 File Offset: 0x000930D8
		public static Offset<DestrucTable> EndDestrucTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DestrucTable>(value);
		}

		// Token: 0x06002629 RID: 9769 RVA: 0x00094CF2 File Offset: 0x000930F2
		public static void FinishDestrucTableBuffer(FlatBufferBuilder builder, Offset<DestrucTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400118B RID: 4491
		private Table __p = new Table();

		// Token: 0x02000379 RID: 889
		public enum eCamp
		{
			// Token: 0x0400118D RID: 4493
			C_HERO,
			// Token: 0x0400118E RID: 4494
			C_ENEMY,
			// Token: 0x0400118F RID: 4495
			C_ENEMY2
		}

		// Token: 0x0200037A RID: 890
		public enum eType
		{
			// Token: 0x04001191 RID: 4497
			NONE,
			// Token: 0x04001192 RID: 4498
			CANDESTORY,
			// Token: 0x04001193 RID: 4499
			CANNOTDESTORY,
			// Token: 0x04001194 RID: 4500
			HAVETODESTRORY
		}

		// Token: 0x0200037B RID: 891
		public enum eCrypt
		{
			// Token: 0x04001196 RID: 4502
			code = 1318618776
		}
	}
}
