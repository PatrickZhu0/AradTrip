using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000275 RID: 629
	public class ActiveTable : IFlatbufferObject
	{
		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06001550 RID: 5456 RVA: 0x0006CB00 File Offset: 0x0006AF00
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x0006CB0D File Offset: 0x0006AF0D
		public static ActiveTable GetRootAsActiveTable(ByteBuffer _bb)
		{
			return ActiveTable.GetRootAsActiveTable(_bb, new ActiveTable());
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x0006CB1A File Offset: 0x0006AF1A
		public static ActiveTable GetRootAsActiveTable(ByteBuffer _bb, ActiveTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x0006CB36 File Offset: 0x0006AF36
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x0006CB50 File Offset: 0x0006AF50
		public ActiveTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06001555 RID: 5461 RVA: 0x0006CB5C File Offset: 0x0006AF5C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x06001556 RID: 5462 RVA: 0x0006CBA8 File Offset: 0x0006AFA8
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001557 RID: 5463 RVA: 0x0006CBEA File Offset: 0x0006AFEA
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06001558 RID: 5464 RVA: 0x0006CBF8 File Offset: 0x0006AFF8
		public int PreTaskId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06001559 RID: 5465 RVA: 0x0006CC44 File Offset: 0x0006B044
		public int NextTaskId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x0600155A RID: 5466 RVA: 0x0006CC90 File Offset: 0x0006B090
		public string Awards
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600155B RID: 5467 RVA: 0x0006CCD3 File Offset: 0x0006B0D3
		public ArraySegment<byte>? GetAwardsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x0600155C RID: 5468 RVA: 0x0006CCE4 File Offset: 0x0006B0E4
		public int VipLv
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x0600155D RID: 5469 RVA: 0x0006CD30 File Offset: 0x0006B130
		public string DanymicAwards
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600155E RID: 5470 RVA: 0x0006CD73 File Offset: 0x0006B173
		public ArraySegment<byte>? GetDanymicAwardsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x0600155F RID: 5471 RVA: 0x0006CD84 File Offset: 0x0006B184
		public int TemplateID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06001560 RID: 5472 RVA: 0x0006CDD0 File Offset: 0x0006B1D0
		public int SortPriority
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06001561 RID: 5473 RVA: 0x0006CE1C File Offset: 0x0006B21C
		public int SortPriority2
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06001562 RID: 5474 RVA: 0x0006CE68 File Offset: 0x0006B268
		public int TakeCost
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06001563 RID: 5475 RVA: 0x0006CEB4 File Offset: 0x0006B2B4
		public int Param1
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06001564 RID: 5476 RVA: 0x0006CF00 File Offset: 0x0006B300
		public int DungeonId
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x0006CF4C File Offset: 0x0006B34C
		public string InitDesc
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001566 RID: 5478 RVA: 0x0006CF8F File Offset: 0x0006B38F
		public ArraySegment<byte>? GetInitDescBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06001567 RID: 5479 RVA: 0x0006CFA0 File Offset: 0x0006B3A0
		public string PrefabKey
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0006CFE3 File Offset: 0x0006B3E3
		public ArraySegment<byte>? GetPrefabKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06001569 RID: 5481 RVA: 0x0006CFF4 File Offset: 0x0006B3F4
		public int DoesWorkToRedPoint
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600156A RID: 5482 RVA: 0x0006D040 File Offset: 0x0006B440
		public int RedPointWorkMode
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600156B RID: 5483 RVA: 0x0006D08C File Offset: 0x0006B48C
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x0006D0CF File Offset: 0x0006B4CF
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x0006D0E0 File Offset: 0x0006B4E0
		public int LinkLimitArray(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600156E RID: 5486 RVA: 0x0006D130 File Offset: 0x0006B530
		public int LinkLimitLength
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600156F RID: 5487 RVA: 0x0006D163 File Offset: 0x0006B563
		public ArraySegment<byte>? GetLinkLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06001570 RID: 5488 RVA: 0x0006D172 File Offset: 0x0006B572
		public FlatBufferArray<int> LinkLimit
		{
			get
			{
				if (this.LinkLimitValue == null)
				{
					this.LinkLimitValue = new FlatBufferArray<int>(new Func<int, int>(this.LinkLimitArray), this.LinkLimitLength);
				}
				return this.LinkLimitValue;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06001571 RID: 5489 RVA: 0x0006D1A4 File Offset: 0x0006B5A4
		public string UpdateDesc
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001572 RID: 5490 RVA: 0x0006D1E7 File Offset: 0x0006B5E7
		public ArraySegment<byte>? GetUpdateDescBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x06001573 RID: 5491 RVA: 0x0006D1F8 File Offset: 0x0006B5F8
		public int ReplaceIDArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06001574 RID: 5492 RVA: 0x0006D248 File Offset: 0x0006B648
		public int ReplaceIDLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001575 RID: 5493 RVA: 0x0006D27B File Offset: 0x0006B67B
		public ArraySegment<byte>? GetReplaceIDBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06001576 RID: 5494 RVA: 0x0006D28A File Offset: 0x0006B68A
		public FlatBufferArray<int> ReplaceID
		{
			get
			{
				if (this.ReplaceIDValue == null)
				{
					this.ReplaceIDValue = new FlatBufferArray<int>(new Func<int, int>(this.ReplaceIDArray), this.ReplaceIDLength);
				}
				return this.ReplaceIDValue;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06001577 RID: 5495 RVA: 0x0006D2BC File Offset: 0x0006B6BC
		public string Param0
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x0006D2FF File Offset: 0x0006B6FF
		public ArraySegment<byte>? GetParam0Bytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06001579 RID: 5497 RVA: 0x0006D310 File Offset: 0x0006B710
		public int LevelLimit
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x0600157A RID: 5498 RVA: 0x0006D35C File Offset: 0x0006B75C
		public int IsWorkWithFullLevel
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x0600157B RID: 5499 RVA: 0x0006D3A8 File Offset: 0x0006B7A8
		public int Abandon
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600157C RID: 5500 RVA: 0x0006D3F4 File Offset: 0x0006B7F4
		public string ConsumeItems
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600157D RID: 5501 RVA: 0x0006D437 File Offset: 0x0006B837
		public ArraySegment<byte>? GetConsumeItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600157E RID: 5502 RVA: 0x0006D448 File Offset: 0x0006B848
		public int TaskCycleCount
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x0600157F RID: 5503 RVA: 0x0006D494 File Offset: 0x0006B894
		public string TaskCycleKey
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001580 RID: 5504 RVA: 0x0006D4D7 File Offset: 0x0006B8D7
		public ArraySegment<byte>? GetTaskCycleKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06001581 RID: 5505 RVA: 0x0006D4E8 File Offset: 0x0006B8E8
		public string OverTaskNumKey
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001582 RID: 5506 RVA: 0x0006D52B File Offset: 0x0006B92B
		public ArraySegment<byte>? GetOverTaskNumKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06001583 RID: 5507 RVA: 0x0006D53C File Offset: 0x0006B93C
		public string FailedTaskNumKey
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x0006D57F File Offset: 0x0006B97F
		public ArraySegment<byte>? GetFailedTaskNumKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06001585 RID: 5509 RVA: 0x0006D590 File Offset: 0x0006B990
		public string ApplyChannel
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001586 RID: 5510 RVA: 0x0006D5D3 File Offset: 0x0006B9D3
		public ArraySegment<byte>? GetApplyChannelBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06001587 RID: 5511 RVA: 0x0006D5E4 File Offset: 0x0006B9E4
		public int Belong
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06001588 RID: 5512 RVA: 0x0006D630 File Offset: 0x0006BA30
		public string Param2
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001589 RID: 5513 RVA: 0x0006D673 File Offset: 0x0006BA73
		public ArraySegment<byte>? GetParam2Bytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x0600158A RID: 5514 RVA: 0x0006D684 File Offset: 0x0006BA84
		public int AccountTotalSubmitLimit
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-2128147130 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600158B RID: 5515 RVA: 0x0006D6D0 File Offset: 0x0006BAD0
		public static Offset<ActiveTable> CreateActiveTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), int PreTaskId = 0, int NextTaskId = 0, StringOffset AwardsOffset = default(StringOffset), int VipLv = 0, StringOffset DanymicAwardsOffset = default(StringOffset), int TemplateID = 0, int SortPriority = 0, int SortPriority2 = 0, int TakeCost = 0, int Param1 = 0, int DungeonId = 0, StringOffset InitDescOffset = default(StringOffset), StringOffset PrefabKeyOffset = default(StringOffset), int DoesWorkToRedPoint = 0, int RedPointWorkMode = 0, StringOffset LinkInfoOffset = default(StringOffset), VectorOffset LinkLimitOffset = default(VectorOffset), StringOffset UpdateDescOffset = default(StringOffset), VectorOffset ReplaceIDOffset = default(VectorOffset), StringOffset Param0Offset = default(StringOffset), int LevelLimit = 0, int IsWorkWithFullLevel = 0, int Abandon = 0, StringOffset ConsumeItemsOffset = default(StringOffset), int TaskCycleCount = 0, StringOffset TaskCycleKeyOffset = default(StringOffset), StringOffset OverTaskNumKeyOffset = default(StringOffset), StringOffset FailedTaskNumKeyOffset = default(StringOffset), StringOffset ApplyChannelOffset = default(StringOffset), int Belong = 0, StringOffset Param2Offset = default(StringOffset), int AccountTotalSubmitLimit = 0)
		{
			builder.StartObject(34);
			ActiveTable.AddAccountTotalSubmitLimit(builder, AccountTotalSubmitLimit);
			ActiveTable.AddParam2(builder, Param2Offset);
			ActiveTable.AddBelong(builder, Belong);
			ActiveTable.AddApplyChannel(builder, ApplyChannelOffset);
			ActiveTable.AddFailedTaskNumKey(builder, FailedTaskNumKeyOffset);
			ActiveTable.AddOverTaskNumKey(builder, OverTaskNumKeyOffset);
			ActiveTable.AddTaskCycleKey(builder, TaskCycleKeyOffset);
			ActiveTable.AddTaskCycleCount(builder, TaskCycleCount);
			ActiveTable.AddConsumeItems(builder, ConsumeItemsOffset);
			ActiveTable.AddAbandon(builder, Abandon);
			ActiveTable.AddIsWorkWithFullLevel(builder, IsWorkWithFullLevel);
			ActiveTable.AddLevelLimit(builder, LevelLimit);
			ActiveTable.AddParam0(builder, Param0Offset);
			ActiveTable.AddReplaceID(builder, ReplaceIDOffset);
			ActiveTable.AddUpdateDesc(builder, UpdateDescOffset);
			ActiveTable.AddLinkLimit(builder, LinkLimitOffset);
			ActiveTable.AddLinkInfo(builder, LinkInfoOffset);
			ActiveTable.AddRedPointWorkMode(builder, RedPointWorkMode);
			ActiveTable.AddDoesWorkToRedPoint(builder, DoesWorkToRedPoint);
			ActiveTable.AddPrefabKey(builder, PrefabKeyOffset);
			ActiveTable.AddInitDesc(builder, InitDescOffset);
			ActiveTable.AddDungeonId(builder, DungeonId);
			ActiveTable.AddParam1(builder, Param1);
			ActiveTable.AddTakeCost(builder, TakeCost);
			ActiveTable.AddSortPriority2(builder, SortPriority2);
			ActiveTable.AddSortPriority(builder, SortPriority);
			ActiveTable.AddTemplateID(builder, TemplateID);
			ActiveTable.AddDanymicAwards(builder, DanymicAwardsOffset);
			ActiveTable.AddVipLv(builder, VipLv);
			ActiveTable.AddAwards(builder, AwardsOffset);
			ActiveTable.AddNextTaskId(builder, NextTaskId);
			ActiveTable.AddPreTaskId(builder, PreTaskId);
			ActiveTable.AddDesc(builder, DescOffset);
			ActiveTable.AddID(builder, ID);
			return ActiveTable.EndActiveTable(builder);
		}

		// Token: 0x0600158C RID: 5516 RVA: 0x0006D7F8 File Offset: 0x0006BBF8
		public static void StartActiveTable(FlatBufferBuilder builder)
		{
			builder.StartObject(34);
		}

		// Token: 0x0600158D RID: 5517 RVA: 0x0006D802 File Offset: 0x0006BC02
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600158E RID: 5518 RVA: 0x0006D80D File Offset: 0x0006BC0D
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x0600158F RID: 5519 RVA: 0x0006D81E File Offset: 0x0006BC1E
		public static void AddPreTaskId(FlatBufferBuilder builder, int PreTaskId)
		{
			builder.AddInt(2, PreTaskId, 0);
		}

		// Token: 0x06001590 RID: 5520 RVA: 0x0006D829 File Offset: 0x0006BC29
		public static void AddNextTaskId(FlatBufferBuilder builder, int NextTaskId)
		{
			builder.AddInt(3, NextTaskId, 0);
		}

		// Token: 0x06001591 RID: 5521 RVA: 0x0006D834 File Offset: 0x0006BC34
		public static void AddAwards(FlatBufferBuilder builder, StringOffset AwardsOffset)
		{
			builder.AddOffset(4, AwardsOffset.Value, 0);
		}

		// Token: 0x06001592 RID: 5522 RVA: 0x0006D845 File Offset: 0x0006BC45
		public static void AddVipLv(FlatBufferBuilder builder, int VipLv)
		{
			builder.AddInt(5, VipLv, 0);
		}

		// Token: 0x06001593 RID: 5523 RVA: 0x0006D850 File Offset: 0x0006BC50
		public static void AddDanymicAwards(FlatBufferBuilder builder, StringOffset DanymicAwardsOffset)
		{
			builder.AddOffset(6, DanymicAwardsOffset.Value, 0);
		}

		// Token: 0x06001594 RID: 5524 RVA: 0x0006D861 File Offset: 0x0006BC61
		public static void AddTemplateID(FlatBufferBuilder builder, int TemplateID)
		{
			builder.AddInt(7, TemplateID, 0);
		}

		// Token: 0x06001595 RID: 5525 RVA: 0x0006D86C File Offset: 0x0006BC6C
		public static void AddSortPriority(FlatBufferBuilder builder, int SortPriority)
		{
			builder.AddInt(8, SortPriority, 0);
		}

		// Token: 0x06001596 RID: 5526 RVA: 0x0006D877 File Offset: 0x0006BC77
		public static void AddSortPriority2(FlatBufferBuilder builder, int SortPriority2)
		{
			builder.AddInt(9, SortPriority2, 0);
		}

		// Token: 0x06001597 RID: 5527 RVA: 0x0006D883 File Offset: 0x0006BC83
		public static void AddTakeCost(FlatBufferBuilder builder, int TakeCost)
		{
			builder.AddInt(10, TakeCost, 0);
		}

		// Token: 0x06001598 RID: 5528 RVA: 0x0006D88F File Offset: 0x0006BC8F
		public static void AddParam1(FlatBufferBuilder builder, int Param1)
		{
			builder.AddInt(11, Param1, 0);
		}

		// Token: 0x06001599 RID: 5529 RVA: 0x0006D89B File Offset: 0x0006BC9B
		public static void AddDungeonId(FlatBufferBuilder builder, int DungeonId)
		{
			builder.AddInt(12, DungeonId, 0);
		}

		// Token: 0x0600159A RID: 5530 RVA: 0x0006D8A7 File Offset: 0x0006BCA7
		public static void AddInitDesc(FlatBufferBuilder builder, StringOffset InitDescOffset)
		{
			builder.AddOffset(13, InitDescOffset.Value, 0);
		}

		// Token: 0x0600159B RID: 5531 RVA: 0x0006D8B9 File Offset: 0x0006BCB9
		public static void AddPrefabKey(FlatBufferBuilder builder, StringOffset PrefabKeyOffset)
		{
			builder.AddOffset(14, PrefabKeyOffset.Value, 0);
		}

		// Token: 0x0600159C RID: 5532 RVA: 0x0006D8CB File Offset: 0x0006BCCB
		public static void AddDoesWorkToRedPoint(FlatBufferBuilder builder, int DoesWorkToRedPoint)
		{
			builder.AddInt(15, DoesWorkToRedPoint, 0);
		}

		// Token: 0x0600159D RID: 5533 RVA: 0x0006D8D7 File Offset: 0x0006BCD7
		public static void AddRedPointWorkMode(FlatBufferBuilder builder, int RedPointWorkMode)
		{
			builder.AddInt(16, RedPointWorkMode, 0);
		}

		// Token: 0x0600159E RID: 5534 RVA: 0x0006D8E3 File Offset: 0x0006BCE3
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(17, LinkInfoOffset.Value, 0);
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x0006D8F5 File Offset: 0x0006BCF5
		public static void AddLinkLimit(FlatBufferBuilder builder, VectorOffset LinkLimitOffset)
		{
			builder.AddOffset(18, LinkLimitOffset.Value, 0);
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x0006D908 File Offset: 0x0006BD08
		public static VectorOffset CreateLinkLimitVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060015A1 RID: 5537 RVA: 0x0006D945 File Offset: 0x0006BD45
		public static void StartLinkLimitVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060015A2 RID: 5538 RVA: 0x0006D950 File Offset: 0x0006BD50
		public static void AddUpdateDesc(FlatBufferBuilder builder, StringOffset UpdateDescOffset)
		{
			builder.AddOffset(19, UpdateDescOffset.Value, 0);
		}

		// Token: 0x060015A3 RID: 5539 RVA: 0x0006D962 File Offset: 0x0006BD62
		public static void AddReplaceID(FlatBufferBuilder builder, VectorOffset ReplaceIDOffset)
		{
			builder.AddOffset(20, ReplaceIDOffset.Value, 0);
		}

		// Token: 0x060015A4 RID: 5540 RVA: 0x0006D974 File Offset: 0x0006BD74
		public static VectorOffset CreateReplaceIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0006D9B1 File Offset: 0x0006BDB1
		public static void StartReplaceIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0006D9BC File Offset: 0x0006BDBC
		public static void AddParam0(FlatBufferBuilder builder, StringOffset Param0Offset)
		{
			builder.AddOffset(21, Param0Offset.Value, 0);
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x0006D9CE File Offset: 0x0006BDCE
		public static void AddLevelLimit(FlatBufferBuilder builder, int LevelLimit)
		{
			builder.AddInt(22, LevelLimit, 0);
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0006D9DA File Offset: 0x0006BDDA
		public static void AddIsWorkWithFullLevel(FlatBufferBuilder builder, int IsWorkWithFullLevel)
		{
			builder.AddInt(23, IsWorkWithFullLevel, 0);
		}

		// Token: 0x060015A9 RID: 5545 RVA: 0x0006D9E6 File Offset: 0x0006BDE6
		public static void AddAbandon(FlatBufferBuilder builder, int Abandon)
		{
			builder.AddInt(24, Abandon, 0);
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0006D9F2 File Offset: 0x0006BDF2
		public static void AddConsumeItems(FlatBufferBuilder builder, StringOffset ConsumeItemsOffset)
		{
			builder.AddOffset(25, ConsumeItemsOffset.Value, 0);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0006DA04 File Offset: 0x0006BE04
		public static void AddTaskCycleCount(FlatBufferBuilder builder, int TaskCycleCount)
		{
			builder.AddInt(26, TaskCycleCount, 0);
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0006DA10 File Offset: 0x0006BE10
		public static void AddTaskCycleKey(FlatBufferBuilder builder, StringOffset TaskCycleKeyOffset)
		{
			builder.AddOffset(27, TaskCycleKeyOffset.Value, 0);
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0006DA22 File Offset: 0x0006BE22
		public static void AddOverTaskNumKey(FlatBufferBuilder builder, StringOffset OverTaskNumKeyOffset)
		{
			builder.AddOffset(28, OverTaskNumKeyOffset.Value, 0);
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0006DA34 File Offset: 0x0006BE34
		public static void AddFailedTaskNumKey(FlatBufferBuilder builder, StringOffset FailedTaskNumKeyOffset)
		{
			builder.AddOffset(29, FailedTaskNumKeyOffset.Value, 0);
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x0006DA46 File Offset: 0x0006BE46
		public static void AddApplyChannel(FlatBufferBuilder builder, StringOffset ApplyChannelOffset)
		{
			builder.AddOffset(30, ApplyChannelOffset.Value, 0);
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0006DA58 File Offset: 0x0006BE58
		public static void AddBelong(FlatBufferBuilder builder, int Belong)
		{
			builder.AddInt(31, Belong, 0);
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0006DA64 File Offset: 0x0006BE64
		public static void AddParam2(FlatBufferBuilder builder, StringOffset Param2Offset)
		{
			builder.AddOffset(32, Param2Offset.Value, 0);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0006DA76 File Offset: 0x0006BE76
		public static void AddAccountTotalSubmitLimit(FlatBufferBuilder builder, int AccountTotalSubmitLimit)
		{
			builder.AddInt(33, AccountTotalSubmitLimit, 0);
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0006DA84 File Offset: 0x0006BE84
		public static Offset<ActiveTable> EndActiveTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActiveTable>(value);
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0006DA9E File Offset: 0x0006BE9E
		public static void FinishActiveTableBuffer(FlatBufferBuilder builder, Offset<ActiveTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D80 RID: 3456
		private Table __p = new Table();

		// Token: 0x04000D81 RID: 3457
		private FlatBufferArray<int> LinkLimitValue;

		// Token: 0x04000D82 RID: 3458
		private FlatBufferArray<int> ReplaceIDValue;

		// Token: 0x02000276 RID: 630
		public enum eCrypt
		{
			// Token: 0x04000D84 RID: 3460
			code = -2128147130
		}
	}
}
