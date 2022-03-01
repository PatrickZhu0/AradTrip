using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000277 RID: 631
	public class ActivityDungeonTable : IFlatbufferObject
	{
		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x0006DAC0 File Offset: 0x0006BEC0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x0006DACD File Offset: 0x0006BECD
		public static ActivityDungeonTable GetRootAsActivityDungeonTable(ByteBuffer _bb)
		{
			return ActivityDungeonTable.GetRootAsActivityDungeonTable(_bb, new ActivityDungeonTable());
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x0006DADA File Offset: 0x0006BEDA
		public static ActivityDungeonTable GetRootAsActivityDungeonTable(ByteBuffer _bb, ActivityDungeonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0006DAF6 File Offset: 0x0006BEF6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060015BA RID: 5562 RVA: 0x0006DB10 File Offset: 0x0006BF10
		public ActivityDungeonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x060015BB RID: 5563 RVA: 0x0006DB1C File Offset: 0x0006BF1C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x0006DB68 File Offset: 0x0006BF68
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015BD RID: 5565 RVA: 0x0006DBAA File Offset: 0x0006BFAA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x060015BE RID: 5566 RVA: 0x0006DBB8 File Offset: 0x0006BFB8
		public int ActivityIDArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x060015BF RID: 5567 RVA: 0x0006DC04 File Offset: 0x0006C004
		public int ActivityIDLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x0006DC36 File Offset: 0x0006C036
		public ArraySegment<byte>? GetActivityIDBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x060015C1 RID: 5569 RVA: 0x0006DC44 File Offset: 0x0006C044
		public FlatBufferArray<int> ActivityID
		{
			get
			{
				if (this.ActivityIDValue == null)
				{
					this.ActivityIDValue = new FlatBufferArray<int>(new Func<int, int>(this.ActivityIDArray), this.ActivityIDLength);
				}
				return this.ActivityIDValue;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x0006DC74 File Offset: 0x0006C074
		public string ImagePath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015C3 RID: 5571 RVA: 0x0006DCB7 File Offset: 0x0006C0B7
		public ArraySegment<byte>? GetImagePathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x060015C4 RID: 5572 RVA: 0x0006DCC8 File Offset: 0x0006C0C8
		public string OpenTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x0006DD0B File Offset: 0x0006C10B
		public ArraySegment<byte>? GetOpenTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x060015C6 RID: 5574 RVA: 0x0006DD1C File Offset: 0x0006C11C
		public bool ShowModeFlag
		{
			get
			{
				int num = this.__p.__offset(14);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x060015C7 RID: 5575 RVA: 0x0006DD68 File Offset: 0x0006C168
		public string ModeBoardPath
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x0006DDAB File Offset: 0x0006C1AB
		public ArraySegment<byte>? GetModeBoardPathBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x060015C9 RID: 5577 RVA: 0x0006DDBC File Offset: 0x0006C1BC
		public string ModeIconPath
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0006DDFF File Offset: 0x0006C1FF
		public ArraySegment<byte>? GetModeIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x060015CB RID: 5579 RVA: 0x0006DE10 File Offset: 0x0006C210
		public string Mode
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0006DE53 File Offset: 0x0006C253
		public ArraySegment<byte>? GetModeBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x060015CD RID: 5581 RVA: 0x0006DE64 File Offset: 0x0006C264
		public ActivityDungeonTable.eActivityType ActivityType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (ActivityDungeonTable.eActivityType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x0006DEA8 File Offset: 0x0006C2A8
		public string ActivityTypeDesc
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x0006DEEB File Offset: 0x0006C2EB
		public ArraySegment<byte>? GetActivityTypeDescBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060015D0 RID: 5584 RVA: 0x0006DEFC File Offset: 0x0006C2FC
		public string SingleTabIcon
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x0006DF3F File Offset: 0x0006C33F
		public ArraySegment<byte>? GetSingleTabIconBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060015D2 RID: 5586 RVA: 0x0006DF50 File Offset: 0x0006C350
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060015D3 RID: 5587 RVA: 0x0006DF9C File Offset: 0x0006C39C
		public string CollectDataPath
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015D4 RID: 5588 RVA: 0x0006DFDF File Offset: 0x0006C3DF
		public ArraySegment<byte>? GetCollectDataPathBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060015D5 RID: 5589 RVA: 0x0006DFF0 File Offset: 0x0006C3F0
		public bool ShowCount
		{
			get
			{
				int num = this.__p.__offset(32);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060015D6 RID: 5590 RVA: 0x0006E03C File Offset: 0x0006C43C
		public string ShowCountDesc
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0006E07F File Offset: 0x0006C47F
		public ArraySegment<byte>? GetShowCountDescBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060015D8 RID: 5592 RVA: 0x0006E090 File Offset: 0x0006C490
		public ActivityDungeonTable.eDropType DropType
		{
			get
			{
				int num = this.__p.__offset(36);
				return (ActivityDungeonTable.eDropType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060015D9 RID: 5593 RVA: 0x0006E0D4 File Offset: 0x0006C4D4
		public int DropItemsArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x0006E124 File Offset: 0x0006C524
		public int DropItemsLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060015DB RID: 5595 RVA: 0x0006E157 File Offset: 0x0006C557
		public ArraySegment<byte>? GetDropItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x0006E166 File Offset: 0x0006C566
		public FlatBufferArray<int> DropItems
		{
			get
			{
				if (this.DropItemsValue == null)
				{
					this.DropItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.DropItemsArray), this.DropItemsLength);
				}
				return this.DropItemsValue;
			}
		}

		// Token: 0x060015DD RID: 5597 RVA: 0x0006E198 File Offset: 0x0006C598
		public int DropShow1Array(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x0006E1E8 File Offset: 0x0006C5E8
		public int DropShow1Length
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060015DF RID: 5599 RVA: 0x0006E21B File Offset: 0x0006C61B
		public ArraySegment<byte>? GetDropShow1Bytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x0006E22A File Offset: 0x0006C62A
		public FlatBufferArray<int> DropShow1
		{
			get
			{
				if (this.DropShow1Value == null)
				{
					this.DropShow1Value = new FlatBufferArray<int>(new Func<int, int>(this.DropShow1Array), this.DropShow1Length);
				}
				return this.DropShow1Value;
			}
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x0006E25C File Offset: 0x0006C65C
		public int DropShow2Array(int j)
		{
			int num = this.__p.__offset(42);
			return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060015E2 RID: 5602 RVA: 0x0006E2AC File Offset: 0x0006C6AC
		public int DropShow2Length
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x0006E2DF File Offset: 0x0006C6DF
		public ArraySegment<byte>? GetDropShow2Bytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060015E4 RID: 5604 RVA: 0x0006E2EE File Offset: 0x0006C6EE
		public FlatBufferArray<int> DropShow2
		{
			get
			{
				if (this.DropShow2Value == null)
				{
					this.DropShow2Value = new FlatBufferArray<int>(new Func<int, int>(this.DropShow2Array), this.DropShow2Length);
				}
				return this.DropShow2Value;
			}
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x0006E320 File Offset: 0x0006C720
		public int DropShow3Array(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060015E6 RID: 5606 RVA: 0x0006E370 File Offset: 0x0006C770
		public int DropShow3Length
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x0006E3A3 File Offset: 0x0006C7A3
		public ArraySegment<byte>? GetDropShow3Bytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x0006E3B2 File Offset: 0x0006C7B2
		public FlatBufferArray<int> DropShow3
		{
			get
			{
				if (this.DropShow3Value == null)
				{
					this.DropShow3Value = new FlatBufferArray<int>(new Func<int, int>(this.DropShow3Array), this.DropShow3Length);
				}
				return this.DropShow3Value;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060015E9 RID: 5609 RVA: 0x0006E3E4 File Offset: 0x0006C7E4
		public int TabPriority
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x0006E430 File Offset: 0x0006C830
		public string TabName
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x0006E473 File Offset: 0x0006C873
		public ArraySegment<byte>? GetTabNameBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060015EC RID: 5612 RVA: 0x0006E484 File Offset: 0x0006C884
		public int SubPriority
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060015ED RID: 5613 RVA: 0x0006E4D0 File Offset: 0x0006C8D0
		public ActivityDungeonTable.eSubItemOpenType SubItemOpenType
		{
			get
			{
				int num = this.__p.__offset(52);
				return (ActivityDungeonTable.eSubItemOpenType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x0006E514 File Offset: 0x0006C914
		public ActivityDungeonTable.eSubNameType SubNameType
		{
			get
			{
				int num = this.__p.__offset(54);
				return (ActivityDungeonTable.eSubNameType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060015EF RID: 5615 RVA: 0x0006E558 File Offset: 0x0006C958
		public string SubName
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015F0 RID: 5616 RVA: 0x0006E59B File Offset: 0x0006C99B
		public ArraySegment<byte>? GetSubNameBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060015F1 RID: 5617 RVA: 0x0006E5AC File Offset: 0x0006C9AC
		public ActivityDungeonTable.eDescriptionType DescriptionType
		{
			get
			{
				int num = this.__p.__offset(58);
				return (ActivityDungeonTable.eDescriptionType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x0006E5F0 File Offset: 0x0006C9F0
		public string Description
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x0006E633 File Offset: 0x0006CA33
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060015F4 RID: 5620 RVA: 0x0006E644 File Offset: 0x0006CA44
		public string ExtraDescription
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0006E687 File Offset: 0x0006CA87
		public ArraySegment<byte>? GetExtraDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x0006E698 File Offset: 0x0006CA98
		public string PlayDescription
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015F7 RID: 5623 RVA: 0x0006E6DB File Offset: 0x0006CADB
		public ArraySegment<byte>? GetPlayDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060015F8 RID: 5624 RVA: 0x0006E6EC File Offset: 0x0006CAEC
		public string GoLinkInfo
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060015F9 RID: 5625 RVA: 0x0006E72F File Offset: 0x0006CB2F
		public ArraySegment<byte>? GetGoLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x0006E740 File Offset: 0x0006CB40
		public int DailyActivityType
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (1582105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060015FB RID: 5627 RVA: 0x0006E78C File Offset: 0x0006CB8C
		public static Offset<ActivityDungeonTable> CreateActivityDungeonTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset ActivityIDOffset = default(VectorOffset), StringOffset ImagePathOffset = default(StringOffset), StringOffset OpenTimeOffset = default(StringOffset), bool ShowModeFlag = false, StringOffset ModeBoardPathOffset = default(StringOffset), StringOffset ModeIconPathOffset = default(StringOffset), StringOffset ModeOffset = default(StringOffset), ActivityDungeonTable.eActivityType ActivityType = ActivityDungeonTable.eActivityType.None, StringOffset ActivityTypeDescOffset = default(StringOffset), StringOffset SingleTabIconOffset = default(StringOffset), int DungeonID = 0, StringOffset CollectDataPathOffset = default(StringOffset), bool ShowCount = false, StringOffset ShowCountDescOffset = default(StringOffset), ActivityDungeonTable.eDropType DropType = ActivityDungeonTable.eDropType.DropType_None, VectorOffset DropItemsOffset = default(VectorOffset), VectorOffset DropShow1Offset = default(VectorOffset), VectorOffset DropShow2Offset = default(VectorOffset), VectorOffset DropShow3Offset = default(VectorOffset), int TabPriority = 0, StringOffset TabNameOffset = default(StringOffset), int SubPriority = 0, ActivityDungeonTable.eSubItemOpenType SubItemOpenType = ActivityDungeonTable.eSubItemOpenType.SubItemOpenType_None, ActivityDungeonTable.eSubNameType SubNameType = ActivityDungeonTable.eSubNameType.SubNameType_None, StringOffset SubNameOffset = default(StringOffset), ActivityDungeonTable.eDescriptionType DescriptionType = ActivityDungeonTable.eDescriptionType.DescriptionType_None, StringOffset DescriptionOffset = default(StringOffset), StringOffset ExtraDescriptionOffset = default(StringOffset), StringOffset PlayDescriptionOffset = default(StringOffset), StringOffset GoLinkInfoOffset = default(StringOffset), int DailyActivityType = 0)
		{
			builder.StartObject(33);
			ActivityDungeonTable.AddDailyActivityType(builder, DailyActivityType);
			ActivityDungeonTable.AddGoLinkInfo(builder, GoLinkInfoOffset);
			ActivityDungeonTable.AddPlayDescription(builder, PlayDescriptionOffset);
			ActivityDungeonTable.AddExtraDescription(builder, ExtraDescriptionOffset);
			ActivityDungeonTable.AddDescription(builder, DescriptionOffset);
			ActivityDungeonTable.AddDescriptionType(builder, DescriptionType);
			ActivityDungeonTable.AddSubName(builder, SubNameOffset);
			ActivityDungeonTable.AddSubNameType(builder, SubNameType);
			ActivityDungeonTable.AddSubItemOpenType(builder, SubItemOpenType);
			ActivityDungeonTable.AddSubPriority(builder, SubPriority);
			ActivityDungeonTable.AddTabName(builder, TabNameOffset);
			ActivityDungeonTable.AddTabPriority(builder, TabPriority);
			ActivityDungeonTable.AddDropShow3(builder, DropShow3Offset);
			ActivityDungeonTable.AddDropShow2(builder, DropShow2Offset);
			ActivityDungeonTable.AddDropShow1(builder, DropShow1Offset);
			ActivityDungeonTable.AddDropItems(builder, DropItemsOffset);
			ActivityDungeonTable.AddDropType(builder, DropType);
			ActivityDungeonTable.AddShowCountDesc(builder, ShowCountDescOffset);
			ActivityDungeonTable.AddCollectDataPath(builder, CollectDataPathOffset);
			ActivityDungeonTable.AddDungeonID(builder, DungeonID);
			ActivityDungeonTable.AddSingleTabIcon(builder, SingleTabIconOffset);
			ActivityDungeonTable.AddActivityTypeDesc(builder, ActivityTypeDescOffset);
			ActivityDungeonTable.AddActivityType(builder, ActivityType);
			ActivityDungeonTable.AddMode(builder, ModeOffset);
			ActivityDungeonTable.AddModeIconPath(builder, ModeIconPathOffset);
			ActivityDungeonTable.AddModeBoardPath(builder, ModeBoardPathOffset);
			ActivityDungeonTable.AddOpenTime(builder, OpenTimeOffset);
			ActivityDungeonTable.AddImagePath(builder, ImagePathOffset);
			ActivityDungeonTable.AddActivityID(builder, ActivityIDOffset);
			ActivityDungeonTable.AddName(builder, NameOffset);
			ActivityDungeonTable.AddID(builder, ID);
			ActivityDungeonTable.AddShowCount(builder, ShowCount);
			ActivityDungeonTable.AddShowModeFlag(builder, ShowModeFlag);
			return ActivityDungeonTable.EndActivityDungeonTable(builder);
		}

		// Token: 0x060015FC RID: 5628 RVA: 0x0006E8AC File Offset: 0x0006CCAC
		public static void StartActivityDungeonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(33);
		}

		// Token: 0x060015FD RID: 5629 RVA: 0x0006E8B6 File Offset: 0x0006CCB6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x0006E8C1 File Offset: 0x0006CCC1
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0006E8D2 File Offset: 0x0006CCD2
		public static void AddActivityID(FlatBufferBuilder builder, VectorOffset ActivityIDOffset)
		{
			builder.AddOffset(2, ActivityIDOffset.Value, 0);
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x0006E8E4 File Offset: 0x0006CCE4
		public static VectorOffset CreateActivityIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x0006E921 File Offset: 0x0006CD21
		public static void StartActivityIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x0006E92C File Offset: 0x0006CD2C
		public static void AddImagePath(FlatBufferBuilder builder, StringOffset ImagePathOffset)
		{
			builder.AddOffset(3, ImagePathOffset.Value, 0);
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x0006E93D File Offset: 0x0006CD3D
		public static void AddOpenTime(FlatBufferBuilder builder, StringOffset OpenTimeOffset)
		{
			builder.AddOffset(4, OpenTimeOffset.Value, 0);
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x0006E94E File Offset: 0x0006CD4E
		public static void AddShowModeFlag(FlatBufferBuilder builder, bool ShowModeFlag)
		{
			builder.AddBool(5, ShowModeFlag, false);
		}

		// Token: 0x06001605 RID: 5637 RVA: 0x0006E959 File Offset: 0x0006CD59
		public static void AddModeBoardPath(FlatBufferBuilder builder, StringOffset ModeBoardPathOffset)
		{
			builder.AddOffset(6, ModeBoardPathOffset.Value, 0);
		}

		// Token: 0x06001606 RID: 5638 RVA: 0x0006E96A File Offset: 0x0006CD6A
		public static void AddModeIconPath(FlatBufferBuilder builder, StringOffset ModeIconPathOffset)
		{
			builder.AddOffset(7, ModeIconPathOffset.Value, 0);
		}

		// Token: 0x06001607 RID: 5639 RVA: 0x0006E97B File Offset: 0x0006CD7B
		public static void AddMode(FlatBufferBuilder builder, StringOffset ModeOffset)
		{
			builder.AddOffset(8, ModeOffset.Value, 0);
		}

		// Token: 0x06001608 RID: 5640 RVA: 0x0006E98C File Offset: 0x0006CD8C
		public static void AddActivityType(FlatBufferBuilder builder, ActivityDungeonTable.eActivityType ActivityType)
		{
			builder.AddInt(9, (int)ActivityType, 0);
		}

		// Token: 0x06001609 RID: 5641 RVA: 0x0006E998 File Offset: 0x0006CD98
		public static void AddActivityTypeDesc(FlatBufferBuilder builder, StringOffset ActivityTypeDescOffset)
		{
			builder.AddOffset(10, ActivityTypeDescOffset.Value, 0);
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x0006E9AA File Offset: 0x0006CDAA
		public static void AddSingleTabIcon(FlatBufferBuilder builder, StringOffset SingleTabIconOffset)
		{
			builder.AddOffset(11, SingleTabIconOffset.Value, 0);
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0006E9BC File Offset: 0x0006CDBC
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(12, DungeonID, 0);
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0006E9C8 File Offset: 0x0006CDC8
		public static void AddCollectDataPath(FlatBufferBuilder builder, StringOffset CollectDataPathOffset)
		{
			builder.AddOffset(13, CollectDataPathOffset.Value, 0);
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0006E9DA File Offset: 0x0006CDDA
		public static void AddShowCount(FlatBufferBuilder builder, bool ShowCount)
		{
			builder.AddBool(14, ShowCount, false);
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x0006E9E6 File Offset: 0x0006CDE6
		public static void AddShowCountDesc(FlatBufferBuilder builder, StringOffset ShowCountDescOffset)
		{
			builder.AddOffset(15, ShowCountDescOffset.Value, 0);
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x0006E9F8 File Offset: 0x0006CDF8
		public static void AddDropType(FlatBufferBuilder builder, ActivityDungeonTable.eDropType DropType)
		{
			builder.AddInt(16, (int)DropType, 0);
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x0006EA04 File Offset: 0x0006CE04
		public static void AddDropItems(FlatBufferBuilder builder, VectorOffset DropItemsOffset)
		{
			builder.AddOffset(17, DropItemsOffset.Value, 0);
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x0006EA18 File Offset: 0x0006CE18
		public static VectorOffset CreateDropItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x0006EA55 File Offset: 0x0006CE55
		public static void StartDropItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x0006EA60 File Offset: 0x0006CE60
		public static void AddDropShow1(FlatBufferBuilder builder, VectorOffset DropShow1Offset)
		{
			builder.AddOffset(18, DropShow1Offset.Value, 0);
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x0006EA74 File Offset: 0x0006CE74
		public static VectorOffset CreateDropShow1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x0006EAB1 File Offset: 0x0006CEB1
		public static void StartDropShow1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x0006EABC File Offset: 0x0006CEBC
		public static void AddDropShow2(FlatBufferBuilder builder, VectorOffset DropShow2Offset)
		{
			builder.AddOffset(19, DropShow2Offset.Value, 0);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x0006EAD0 File Offset: 0x0006CED0
		public static VectorOffset CreateDropShow2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x0006EB0D File Offset: 0x0006CF0D
		public static void StartDropShow2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x0006EB18 File Offset: 0x0006CF18
		public static void AddDropShow3(FlatBufferBuilder builder, VectorOffset DropShow3Offset)
		{
			builder.AddOffset(20, DropShow3Offset.Value, 0);
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x0006EB2C File Offset: 0x0006CF2C
		public static VectorOffset CreateDropShow3Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x0006EB69 File Offset: 0x0006CF69
		public static void StartDropShow3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x0006EB74 File Offset: 0x0006CF74
		public static void AddTabPriority(FlatBufferBuilder builder, int TabPriority)
		{
			builder.AddInt(21, TabPriority, 0);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x0006EB80 File Offset: 0x0006CF80
		public static void AddTabName(FlatBufferBuilder builder, StringOffset TabNameOffset)
		{
			builder.AddOffset(22, TabNameOffset.Value, 0);
		}

		// Token: 0x0600161E RID: 5662 RVA: 0x0006EB92 File Offset: 0x0006CF92
		public static void AddSubPriority(FlatBufferBuilder builder, int SubPriority)
		{
			builder.AddInt(23, SubPriority, 0);
		}

		// Token: 0x0600161F RID: 5663 RVA: 0x0006EB9E File Offset: 0x0006CF9E
		public static void AddSubItemOpenType(FlatBufferBuilder builder, ActivityDungeonTable.eSubItemOpenType SubItemOpenType)
		{
			builder.AddInt(24, (int)SubItemOpenType, 0);
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x0006EBAA File Offset: 0x0006CFAA
		public static void AddSubNameType(FlatBufferBuilder builder, ActivityDungeonTable.eSubNameType SubNameType)
		{
			builder.AddInt(25, (int)SubNameType, 0);
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x0006EBB6 File Offset: 0x0006CFB6
		public static void AddSubName(FlatBufferBuilder builder, StringOffset SubNameOffset)
		{
			builder.AddOffset(26, SubNameOffset.Value, 0);
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x0006EBC8 File Offset: 0x0006CFC8
		public static void AddDescriptionType(FlatBufferBuilder builder, ActivityDungeonTable.eDescriptionType DescriptionType)
		{
			builder.AddInt(27, (int)DescriptionType, 0);
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x0006EBD4 File Offset: 0x0006CFD4
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(28, DescriptionOffset.Value, 0);
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x0006EBE6 File Offset: 0x0006CFE6
		public static void AddExtraDescription(FlatBufferBuilder builder, StringOffset ExtraDescriptionOffset)
		{
			builder.AddOffset(29, ExtraDescriptionOffset.Value, 0);
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x0006EBF8 File Offset: 0x0006CFF8
		public static void AddPlayDescription(FlatBufferBuilder builder, StringOffset PlayDescriptionOffset)
		{
			builder.AddOffset(30, PlayDescriptionOffset.Value, 0);
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x0006EC0A File Offset: 0x0006D00A
		public static void AddGoLinkInfo(FlatBufferBuilder builder, StringOffset GoLinkInfoOffset)
		{
			builder.AddOffset(31, GoLinkInfoOffset.Value, 0);
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x0006EC1C File Offset: 0x0006D01C
		public static void AddDailyActivityType(FlatBufferBuilder builder, int DailyActivityType)
		{
			builder.AddInt(32, DailyActivityType, 0);
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x0006EC28 File Offset: 0x0006D028
		public static Offset<ActivityDungeonTable> EndActivityDungeonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivityDungeonTable>(value);
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x0006EC42 File Offset: 0x0006D042
		public static void FinishActivityDungeonTableBuffer(FlatBufferBuilder builder, Offset<ActivityDungeonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D85 RID: 3461
		private Table __p = new Table();

		// Token: 0x04000D86 RID: 3462
		private FlatBufferArray<int> ActivityIDValue;

		// Token: 0x04000D87 RID: 3463
		private FlatBufferArray<int> DropItemsValue;

		// Token: 0x04000D88 RID: 3464
		private FlatBufferArray<int> DropShow1Value;

		// Token: 0x04000D89 RID: 3465
		private FlatBufferArray<int> DropShow2Value;

		// Token: 0x04000D8A RID: 3466
		private FlatBufferArray<int> DropShow3Value;

		// Token: 0x02000278 RID: 632
		public enum eActivityType
		{
			// Token: 0x04000D8C RID: 3468
			None,
			// Token: 0x04000D8D RID: 3469
			TimeLimit,
			// Token: 0x04000D8E RID: 3470
			Daily,
			// Token: 0x04000D8F RID: 3471
			Reward
		}

		// Token: 0x02000279 RID: 633
		public enum eDropType
		{
			// Token: 0x04000D91 RID: 3473
			DropType_None,
			// Token: 0x04000D92 RID: 3474
			DungeonDrop,
			// Token: 0x04000D93 RID: 3475
			CustomDrop
		}

		// Token: 0x0200027A RID: 634
		public enum eSubItemOpenType
		{
			// Token: 0x04000D95 RID: 3477
			SubItemOpenType_None,
			// Token: 0x04000D96 RID: 3478
			DungeonFrame,
			// Token: 0x04000D97 RID: 3479
			CommonFrame
		}

		// Token: 0x0200027B RID: 635
		public enum eSubNameType
		{
			// Token: 0x04000D99 RID: 3481
			SubNameType_None,
			// Token: 0x04000D9A RID: 3482
			DungeonName,
			// Token: 0x04000D9B RID: 3483
			CustomName
		}

		// Token: 0x0200027C RID: 636
		public enum eDescriptionType
		{
			// Token: 0x04000D9D RID: 3485
			DescriptionType_None,
			// Token: 0x04000D9E RID: 3486
			DungeonDescription,
			// Token: 0x04000D9F RID: 3487
			CustomDescription
		}

		// Token: 0x0200027D RID: 637
		public enum eCrypt
		{
			// Token: 0x04000DA1 RID: 3489
			code = 1582105103
		}
	}
}
