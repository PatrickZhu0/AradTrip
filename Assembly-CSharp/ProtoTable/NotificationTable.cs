using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000530 RID: 1328
	public class NotificationTable : IFlatbufferObject
	{
		// Token: 0x17001228 RID: 4648
		// (get) Token: 0x0600441A RID: 17434 RVA: 0x000DC060 File Offset: 0x000DA460
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600441B RID: 17435 RVA: 0x000DC06D File Offset: 0x000DA46D
		public static NotificationTable GetRootAsNotificationTable(ByteBuffer _bb)
		{
			return NotificationTable.GetRootAsNotificationTable(_bb, new NotificationTable());
		}

		// Token: 0x0600441C RID: 17436 RVA: 0x000DC07A File Offset: 0x000DA47A
		public static NotificationTable GetRootAsNotificationTable(ByteBuffer _bb, NotificationTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600441D RID: 17437 RVA: 0x000DC096 File Offset: 0x000DA496
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600441E RID: 17438 RVA: 0x000DC0B0 File Offset: 0x000DA4B0
		public NotificationTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001229 RID: 4649
		// (get) Token: 0x0600441F RID: 17439 RVA: 0x000DC0BC File Offset: 0x000DA4BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-870402045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700122A RID: 4650
		// (get) Token: 0x06004420 RID: 17440 RVA: 0x000DC108 File Offset: 0x000DA508
		public string Content
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004421 RID: 17441 RVA: 0x000DC14A File Offset: 0x000DA54A
		public ArraySegment<byte>? GetContentBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700122B RID: 4651
		// (get) Token: 0x06004422 RID: 17442 RVA: 0x000DC158 File Offset: 0x000DA558
		public string weekday
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004423 RID: 17443 RVA: 0x000DC19A File Offset: 0x000DA59A
		public ArraySegment<byte>? GetWeekdayBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700122C RID: 4652
		// (get) Token: 0x06004424 RID: 17444 RVA: 0x000DC1A8 File Offset: 0x000DA5A8
		public int hour
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-870402045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700122D RID: 4653
		// (get) Token: 0x06004425 RID: 17445 RVA: 0x000DC1F4 File Offset: 0x000DA5F4
		public int minute
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-870402045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700122E RID: 4654
		// (get) Token: 0x06004426 RID: 17446 RVA: 0x000DC240 File Offset: 0x000DA640
		public int NeedClose
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-870402045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004427 RID: 17447 RVA: 0x000DC28A File Offset: 0x000DA68A
		public static Offset<NotificationTable> CreateNotificationTable(FlatBufferBuilder builder, int ID = 0, StringOffset ContentOffset = default(StringOffset), StringOffset weekdayOffset = default(StringOffset), int hour = 0, int minute = 0, int NeedClose = 0)
		{
			builder.StartObject(6);
			NotificationTable.AddNeedClose(builder, NeedClose);
			NotificationTable.AddMinute(builder, minute);
			NotificationTable.AddHour(builder, hour);
			NotificationTable.AddWeekday(builder, weekdayOffset);
			NotificationTable.AddContent(builder, ContentOffset);
			NotificationTable.AddID(builder, ID);
			return NotificationTable.EndNotificationTable(builder);
		}

		// Token: 0x06004428 RID: 17448 RVA: 0x000DC2C6 File Offset: 0x000DA6C6
		public static void StartNotificationTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004429 RID: 17449 RVA: 0x000DC2CF File Offset: 0x000DA6CF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600442A RID: 17450 RVA: 0x000DC2DA File Offset: 0x000DA6DA
		public static void AddContent(FlatBufferBuilder builder, StringOffset ContentOffset)
		{
			builder.AddOffset(1, ContentOffset.Value, 0);
		}

		// Token: 0x0600442B RID: 17451 RVA: 0x000DC2EB File Offset: 0x000DA6EB
		public static void AddWeekday(FlatBufferBuilder builder, StringOffset weekdayOffset)
		{
			builder.AddOffset(2, weekdayOffset.Value, 0);
		}

		// Token: 0x0600442C RID: 17452 RVA: 0x000DC2FC File Offset: 0x000DA6FC
		public static void AddHour(FlatBufferBuilder builder, int hour)
		{
			builder.AddInt(3, hour, 0);
		}

		// Token: 0x0600442D RID: 17453 RVA: 0x000DC307 File Offset: 0x000DA707
		public static void AddMinute(FlatBufferBuilder builder, int minute)
		{
			builder.AddInt(4, minute, 0);
		}

		// Token: 0x0600442E RID: 17454 RVA: 0x000DC312 File Offset: 0x000DA712
		public static void AddNeedClose(FlatBufferBuilder builder, int NeedClose)
		{
			builder.AddInt(5, NeedClose, 0);
		}

		// Token: 0x0600442F RID: 17455 RVA: 0x000DC320 File Offset: 0x000DA720
		public static Offset<NotificationTable> EndNotificationTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NotificationTable>(value);
		}

		// Token: 0x06004430 RID: 17456 RVA: 0x000DC33A File Offset: 0x000DA73A
		public static void FinishNotificationTableBuffer(FlatBufferBuilder builder, Offset<NotificationTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001953 RID: 6483
		private Table __p = new Table();

		// Token: 0x02000531 RID: 1329
		public enum eCrypt
		{
			// Token: 0x04001955 RID: 6485
			code = -870402045
		}
	}
}
