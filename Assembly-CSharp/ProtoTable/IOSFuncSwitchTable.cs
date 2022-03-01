using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200049A RID: 1178
	public class IOSFuncSwitchTable : IFlatbufferObject
	{
		// Token: 0x17000E86 RID: 3718
		// (get) Token: 0x06003965 RID: 14693 RVA: 0x000C242C File Offset: 0x000C082C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003966 RID: 14694 RVA: 0x000C2439 File Offset: 0x000C0839
		public static IOSFuncSwitchTable GetRootAsIOSFuncSwitchTable(ByteBuffer _bb)
		{
			return IOSFuncSwitchTable.GetRootAsIOSFuncSwitchTable(_bb, new IOSFuncSwitchTable());
		}

		// Token: 0x06003967 RID: 14695 RVA: 0x000C2446 File Offset: 0x000C0846
		public static IOSFuncSwitchTable GetRootAsIOSFuncSwitchTable(ByteBuffer _bb, IOSFuncSwitchTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003968 RID: 14696 RVA: 0x000C2462 File Offset: 0x000C0862
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003969 RID: 14697 RVA: 0x000C247C File Offset: 0x000C087C
		public IOSFuncSwitchTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E87 RID: 3719
		// (get) Token: 0x0600396A RID: 14698 RVA: 0x000C2488 File Offset: 0x000C0888
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1359211187 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E88 RID: 3720
		// (get) Token: 0x0600396B RID: 14699 RVA: 0x000C24D4 File Offset: 0x000C08D4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600396C RID: 14700 RVA: 0x000C2516 File Offset: 0x000C0916
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000E89 RID: 3721
		// (get) Token: 0x0600396D RID: 14701 RVA: 0x000C2524 File Offset: 0x000C0924
		public IOSFuncSwitchTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (IOSFuncSwitchTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E8A RID: 3722
		// (get) Token: 0x0600396E RID: 14702 RVA: 0x000C2568 File Offset: 0x000C0968
		public int Value
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1359211187 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600396F RID: 14703 RVA: 0x000C25B2 File Offset: 0x000C09B2
		public static Offset<IOSFuncSwitchTable> CreateIOSFuncSwitchTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), IOSFuncSwitchTable.eType Type = IOSFuncSwitchTable.eType.NONE, int Value = 0)
		{
			builder.StartObject(4);
			IOSFuncSwitchTable.AddValue(builder, Value);
			IOSFuncSwitchTable.AddType(builder, Type);
			IOSFuncSwitchTable.AddName(builder, NameOffset);
			IOSFuncSwitchTable.AddID(builder, ID);
			return IOSFuncSwitchTable.EndIOSFuncSwitchTable(builder);
		}

		// Token: 0x06003970 RID: 14704 RVA: 0x000C25DE File Offset: 0x000C09DE
		public static void StartIOSFuncSwitchTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003971 RID: 14705 RVA: 0x000C25E7 File Offset: 0x000C09E7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003972 RID: 14706 RVA: 0x000C25F2 File Offset: 0x000C09F2
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003973 RID: 14707 RVA: 0x000C2603 File Offset: 0x000C0A03
		public static void AddType(FlatBufferBuilder builder, IOSFuncSwitchTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003974 RID: 14708 RVA: 0x000C260E File Offset: 0x000C0A0E
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(3, Value, 0);
		}

		// Token: 0x06003975 RID: 14709 RVA: 0x000C261C File Offset: 0x000C0A1C
		public static Offset<IOSFuncSwitchTable> EndIOSFuncSwitchTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<IOSFuncSwitchTable>(value);
		}

		// Token: 0x06003976 RID: 14710 RVA: 0x000C2636 File Offset: 0x000C0A36
		public static void FinishIOSFuncSwitchTableBuffer(FlatBufferBuilder builder, Offset<IOSFuncSwitchTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001625 RID: 5669
		private Table __p = new Table();

		// Token: 0x0200049B RID: 1179
		public enum eType
		{
			// Token: 0x04001627 RID: 5671
			NONE,
			// Token: 0x04001628 RID: 5672
			SEVEN_AWARDS,
			// Token: 0x04001629 RID: 5673
			GAME_CDK,
			// Token: 0x0400162A RID: 5674
			GAME_SERVICE,
			// Token: 0x0400162B RID: 5675
			SERVICE_LIST,
			// Token: 0x0400162C RID: 5676
			PAY_CHANNEL_CHANGE,
			// Token: 0x0400162D RID: 5677
			LIMITTIME_GIFT,
			// Token: 0x0400162E RID: 5678
			LIMITTIME_ACTIVITY,
			// Token: 0x0400162F RID: 5679
			ADS_PUSH,
			// Token: 0x04001630 RID: 5680
			LIMITTIME_JAR,
			// Token: 0x04001631 RID: 5681
			SHARE_TEXT_CHANGE,
			// Token: 0x04001632 RID: 5682
			SELECT_CREATE_ROLE_TAB,
			// Token: 0x04001633 RID: 5683
			MAINTAIN_TIPS,
			// Token: 0x04001634 RID: 5684
			GAME_WAIGUA,
			// Token: 0x04001635 RID: 5685
			Bounty_League
		}

		// Token: 0x0200049C RID: 1180
		public enum eCrypt
		{
			// Token: 0x04001637 RID: 5687
			code = 1359211187
		}
	}
}
