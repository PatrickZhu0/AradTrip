using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005BD RID: 1469
	public class SkillDescriptionTable : IFlatbufferObject
	{
		// Token: 0x170014E8 RID: 5352
		// (get) Token: 0x06004C8B RID: 19595 RVA: 0x000EF600 File Offset: 0x000EDA00
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004C8C RID: 19596 RVA: 0x000EF60D File Offset: 0x000EDA0D
		public static SkillDescriptionTable GetRootAsSkillDescriptionTable(ByteBuffer _bb)
		{
			return SkillDescriptionTable.GetRootAsSkillDescriptionTable(_bb, new SkillDescriptionTable());
		}

		// Token: 0x06004C8D RID: 19597 RVA: 0x000EF61A File Offset: 0x000EDA1A
		public static SkillDescriptionTable GetRootAsSkillDescriptionTable(ByteBuffer _bb, SkillDescriptionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004C8E RID: 19598 RVA: 0x000EF636 File Offset: 0x000EDA36
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004C8F RID: 19599 RVA: 0x000EF650 File Offset: 0x000EDA50
		public SkillDescriptionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170014E9 RID: 5353
		// (get) Token: 0x06004C90 RID: 19600 RVA: 0x000EF65C File Offset: 0x000EDA5C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-426948431 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014EA RID: 5354
		// (get) Token: 0x06004C91 RID: 19601 RVA: 0x000EF6A8 File Offset: 0x000EDAA8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C92 RID: 19602 RVA: 0x000EF6EA File Offset: 0x000EDAEA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170014EB RID: 5355
		// (get) Token: 0x06004C93 RID: 19603 RVA: 0x000EF6F8 File Offset: 0x000EDAF8
		public string Description
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C94 RID: 19604 RVA: 0x000EF73A File Offset: 0x000EDB3A
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170014EC RID: 5356
		// (get) Token: 0x06004C95 RID: 19605 RVA: 0x000EF748 File Offset: 0x000EDB48
		public string DataText1
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C96 RID: 19606 RVA: 0x000EF78B File Offset: 0x000EDB8B
		public ArraySegment<byte>? GetDataText1Bytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170014ED RID: 5357
		// (get) Token: 0x06004C97 RID: 19607 RVA: 0x000EF79C File Offset: 0x000EDB9C
		public string DataNumber1
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C98 RID: 19608 RVA: 0x000EF7DF File Offset: 0x000EDBDF
		public ArraySegment<byte>? GetDataNumber1Bytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170014EE RID: 5358
		// (get) Token: 0x06004C99 RID: 19609 RVA: 0x000EF7F0 File Offset: 0x000EDBF0
		public string PVPDataNum1
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C9A RID: 19610 RVA: 0x000EF833 File Offset: 0x000EDC33
		public ArraySegment<byte>? GetPVPDataNum1Bytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170014EF RID: 5359
		// (get) Token: 0x06004C9B RID: 19611 RVA: 0x000EF844 File Offset: 0x000EDC44
		public string DataText2
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C9C RID: 19612 RVA: 0x000EF887 File Offset: 0x000EDC87
		public ArraySegment<byte>? GetDataText2Bytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170014F0 RID: 5360
		// (get) Token: 0x06004C9D RID: 19613 RVA: 0x000EF898 File Offset: 0x000EDC98
		public string DataNumber2
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C9E RID: 19614 RVA: 0x000EF8DB File Offset: 0x000EDCDB
		public ArraySegment<byte>? GetDataNumber2Bytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170014F1 RID: 5361
		// (get) Token: 0x06004C9F RID: 19615 RVA: 0x000EF8EC File Offset: 0x000EDCEC
		public string PVPDataNum2
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CA0 RID: 19616 RVA: 0x000EF92F File Offset: 0x000EDD2F
		public ArraySegment<byte>? GetPVPDataNum2Bytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170014F2 RID: 5362
		// (get) Token: 0x06004CA1 RID: 19617 RVA: 0x000EF940 File Offset: 0x000EDD40
		public string DataText3
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CA2 RID: 19618 RVA: 0x000EF983 File Offset: 0x000EDD83
		public ArraySegment<byte>? GetDataText3Bytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x170014F3 RID: 5363
		// (get) Token: 0x06004CA3 RID: 19619 RVA: 0x000EF994 File Offset: 0x000EDD94
		public string DataNumber3
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CA4 RID: 19620 RVA: 0x000EF9D7 File Offset: 0x000EDDD7
		public ArraySegment<byte>? GetDataNumber3Bytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170014F4 RID: 5364
		// (get) Token: 0x06004CA5 RID: 19621 RVA: 0x000EF9E8 File Offset: 0x000EDDE8
		public string PVPDataNum3
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CA6 RID: 19622 RVA: 0x000EFA2B File Offset: 0x000EDE2B
		public ArraySegment<byte>? GetPVPDataNum3Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170014F5 RID: 5365
		// (get) Token: 0x06004CA7 RID: 19623 RVA: 0x000EFA3C File Offset: 0x000EDE3C
		public string DataText4
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CA8 RID: 19624 RVA: 0x000EFA7F File Offset: 0x000EDE7F
		public ArraySegment<byte>? GetDataText4Bytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170014F6 RID: 5366
		// (get) Token: 0x06004CA9 RID: 19625 RVA: 0x000EFA90 File Offset: 0x000EDE90
		public string DataNumber4
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CAA RID: 19626 RVA: 0x000EFAD3 File Offset: 0x000EDED3
		public ArraySegment<byte>? GetDataNumber4Bytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170014F7 RID: 5367
		// (get) Token: 0x06004CAB RID: 19627 RVA: 0x000EFAE4 File Offset: 0x000EDEE4
		public string PVPDataNum4
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CAC RID: 19628 RVA: 0x000EFB27 File Offset: 0x000EDF27
		public ArraySegment<byte>? GetPVPDataNum4Bytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170014F8 RID: 5368
		// (get) Token: 0x06004CAD RID: 19629 RVA: 0x000EFB38 File Offset: 0x000EDF38
		public string DataText5
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x000EFB7B File Offset: 0x000EDF7B
		public ArraySegment<byte>? GetDataText5Bytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170014F9 RID: 5369
		// (get) Token: 0x06004CAF RID: 19631 RVA: 0x000EFB8C File Offset: 0x000EDF8C
		public string DataNumber5
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CB0 RID: 19632 RVA: 0x000EFBCF File Offset: 0x000EDFCF
		public ArraySegment<byte>? GetDataNumber5Bytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170014FA RID: 5370
		// (get) Token: 0x06004CB1 RID: 19633 RVA: 0x000EFBE0 File Offset: 0x000EDFE0
		public string PVPDataNum5
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CB2 RID: 19634 RVA: 0x000EFC23 File Offset: 0x000EE023
		public ArraySegment<byte>? GetPVPDataNum5Bytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170014FB RID: 5371
		// (get) Token: 0x06004CB3 RID: 19635 RVA: 0x000EFC34 File Offset: 0x000EE034
		public string DataText6
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CB4 RID: 19636 RVA: 0x000EFC77 File Offset: 0x000EE077
		public ArraySegment<byte>? GetDataText6Bytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170014FC RID: 5372
		// (get) Token: 0x06004CB5 RID: 19637 RVA: 0x000EFC88 File Offset: 0x000EE088
		public string DataNumber6
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CB6 RID: 19638 RVA: 0x000EFCCB File Offset: 0x000EE0CB
		public ArraySegment<byte>? GetDataNumber6Bytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170014FD RID: 5373
		// (get) Token: 0x06004CB7 RID: 19639 RVA: 0x000EFCDC File Offset: 0x000EE0DC
		public string PVPDataNum6
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CB8 RID: 19640 RVA: 0x000EFD1F File Offset: 0x000EE11F
		public ArraySegment<byte>? GetPVPDataNum6Bytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170014FE RID: 5374
		// (get) Token: 0x06004CB9 RID: 19641 RVA: 0x000EFD30 File Offset: 0x000EE130
		public string DataText7
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CBA RID: 19642 RVA: 0x000EFD73 File Offset: 0x000EE173
		public ArraySegment<byte>? GetDataText7Bytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170014FF RID: 5375
		// (get) Token: 0x06004CBB RID: 19643 RVA: 0x000EFD84 File Offset: 0x000EE184
		public string DataNumber7
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CBC RID: 19644 RVA: 0x000EFDC7 File Offset: 0x000EE1C7
		public ArraySegment<byte>? GetDataNumber7Bytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17001500 RID: 5376
		// (get) Token: 0x06004CBD RID: 19645 RVA: 0x000EFDD8 File Offset: 0x000EE1D8
		public string PVPDataNum7
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CBE RID: 19646 RVA: 0x000EFE1B File Offset: 0x000EE21B
		public ArraySegment<byte>? GetPVPDataNum7Bytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17001501 RID: 5377
		// (get) Token: 0x06004CBF RID: 19647 RVA: 0x000EFE2C File Offset: 0x000EE22C
		public string DataText8
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CC0 RID: 19648 RVA: 0x000EFE6F File Offset: 0x000EE26F
		public ArraySegment<byte>? GetDataText8Bytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17001502 RID: 5378
		// (get) Token: 0x06004CC1 RID: 19649 RVA: 0x000EFE80 File Offset: 0x000EE280
		public string DataNumber8
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CC2 RID: 19650 RVA: 0x000EFEC3 File Offset: 0x000EE2C3
		public ArraySegment<byte>? GetDataNumber8Bytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17001503 RID: 5379
		// (get) Token: 0x06004CC3 RID: 19651 RVA: 0x000EFED4 File Offset: 0x000EE2D4
		public string PVPDataNum8
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CC4 RID: 19652 RVA: 0x000EFF17 File Offset: 0x000EE317
		public ArraySegment<byte>? GetPVPDataNum8Bytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17001504 RID: 5380
		// (get) Token: 0x06004CC5 RID: 19653 RVA: 0x000EFF28 File Offset: 0x000EE328
		public string DataText9
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CC6 RID: 19654 RVA: 0x000EFF6B File Offset: 0x000EE36B
		public ArraySegment<byte>? GetDataText9Bytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17001505 RID: 5381
		// (get) Token: 0x06004CC7 RID: 19655 RVA: 0x000EFF7C File Offset: 0x000EE37C
		public string DataNumber9
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CC8 RID: 19656 RVA: 0x000EFFBF File Offset: 0x000EE3BF
		public ArraySegment<byte>? GetDataNumber9Bytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x17001506 RID: 5382
		// (get) Token: 0x06004CC9 RID: 19657 RVA: 0x000EFFD0 File Offset: 0x000EE3D0
		public string PVPDataNum9
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CCA RID: 19658 RVA: 0x000F0013 File Offset: 0x000EE413
		public ArraySegment<byte>? GetPVPDataNum9Bytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x17001507 RID: 5383
		// (get) Token: 0x06004CCB RID: 19659 RVA: 0x000F0024 File Offset: 0x000EE424
		public string DataText10
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CCC RID: 19660 RVA: 0x000F0067 File Offset: 0x000EE467
		public ArraySegment<byte>? GetDataText10Bytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17001508 RID: 5384
		// (get) Token: 0x06004CCD RID: 19661 RVA: 0x000F0078 File Offset: 0x000EE478
		public string DataNumber10
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CCE RID: 19662 RVA: 0x000F00BB File Offset: 0x000EE4BB
		public ArraySegment<byte>? GetDataNumber10Bytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x17001509 RID: 5385
		// (get) Token: 0x06004CCF RID: 19663 RVA: 0x000F00CC File Offset: 0x000EE4CC
		public string PVPDataNum10
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CD0 RID: 19664 RVA: 0x000F010F File Offset: 0x000EE50F
		public ArraySegment<byte>? GetPVPDataNum10Bytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x1700150A RID: 5386
		// (get) Token: 0x06004CD1 RID: 19665 RVA: 0x000F0120 File Offset: 0x000EE520
		public string DataText11
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CD2 RID: 19666 RVA: 0x000F0163 File Offset: 0x000EE563
		public ArraySegment<byte>? GetDataText11Bytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x1700150B RID: 5387
		// (get) Token: 0x06004CD3 RID: 19667 RVA: 0x000F0174 File Offset: 0x000EE574
		public string DataNumber11
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CD4 RID: 19668 RVA: 0x000F01B7 File Offset: 0x000EE5B7
		public ArraySegment<byte>? GetDataNumber11Bytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x1700150C RID: 5388
		// (get) Token: 0x06004CD5 RID: 19669 RVA: 0x000F01C8 File Offset: 0x000EE5C8
		public string PVPDataNum11
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CD6 RID: 19670 RVA: 0x000F020B File Offset: 0x000EE60B
		public ArraySegment<byte>? GetPVPDataNum11Bytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x1700150D RID: 5389
		// (get) Token: 0x06004CD7 RID: 19671 RVA: 0x000F021C File Offset: 0x000EE61C
		public string DataText12
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CD8 RID: 19672 RVA: 0x000F025F File Offset: 0x000EE65F
		public ArraySegment<byte>? GetDataText12Bytes()
		{
			return this.__p.__vector_as_arraysegment(76);
		}

		// Token: 0x1700150E RID: 5390
		// (get) Token: 0x06004CD9 RID: 19673 RVA: 0x000F0270 File Offset: 0x000EE670
		public string DataNumber12
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CDA RID: 19674 RVA: 0x000F02B3 File Offset: 0x000EE6B3
		public ArraySegment<byte>? GetDataNumber12Bytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x1700150F RID: 5391
		// (get) Token: 0x06004CDB RID: 19675 RVA: 0x000F02C4 File Offset: 0x000EE6C4
		public string PVPDataNum12
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004CDC RID: 19676 RVA: 0x000F0307 File Offset: 0x000EE707
		public ArraySegment<byte>? GetPVPDataNum12Bytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x17001510 RID: 5392
		// (get) Token: 0x06004CDD RID: 19677 RVA: 0x000F0318 File Offset: 0x000EE718
		public int DescType
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-426948431 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004CDE RID: 19678 RVA: 0x000F0364 File Offset: 0x000EE764
		public static Offset<SkillDescriptionTable> CreateSkillDescriptionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), StringOffset DataText1Offset = default(StringOffset), StringOffset DataNumber1Offset = default(StringOffset), StringOffset PVPDataNum1Offset = default(StringOffset), StringOffset DataText2Offset = default(StringOffset), StringOffset DataNumber2Offset = default(StringOffset), StringOffset PVPDataNum2Offset = default(StringOffset), StringOffset DataText3Offset = default(StringOffset), StringOffset DataNumber3Offset = default(StringOffset), StringOffset PVPDataNum3Offset = default(StringOffset), StringOffset DataText4Offset = default(StringOffset), StringOffset DataNumber4Offset = default(StringOffset), StringOffset PVPDataNum4Offset = default(StringOffset), StringOffset DataText5Offset = default(StringOffset), StringOffset DataNumber5Offset = default(StringOffset), StringOffset PVPDataNum5Offset = default(StringOffset), StringOffset DataText6Offset = default(StringOffset), StringOffset DataNumber6Offset = default(StringOffset), StringOffset PVPDataNum6Offset = default(StringOffset), StringOffset DataText7Offset = default(StringOffset), StringOffset DataNumber7Offset = default(StringOffset), StringOffset PVPDataNum7Offset = default(StringOffset), StringOffset DataText8Offset = default(StringOffset), StringOffset DataNumber8Offset = default(StringOffset), StringOffset PVPDataNum8Offset = default(StringOffset), StringOffset DataText9Offset = default(StringOffset), StringOffset DataNumber9Offset = default(StringOffset), StringOffset PVPDataNum9Offset = default(StringOffset), StringOffset DataText10Offset = default(StringOffset), StringOffset DataNumber10Offset = default(StringOffset), StringOffset PVPDataNum10Offset = default(StringOffset), StringOffset DataText11Offset = default(StringOffset), StringOffset DataNumber11Offset = default(StringOffset), StringOffset PVPDataNum11Offset = default(StringOffset), StringOffset DataText12Offset = default(StringOffset), StringOffset DataNumber12Offset = default(StringOffset), StringOffset PVPDataNum12Offset = default(StringOffset), int DescType = 0)
		{
			builder.StartObject(40);
			SkillDescriptionTable.AddDescType(builder, DescType);
			SkillDescriptionTable.AddPVPDataNum12(builder, PVPDataNum12Offset);
			SkillDescriptionTable.AddDataNumber12(builder, DataNumber12Offset);
			SkillDescriptionTable.AddDataText12(builder, DataText12Offset);
			SkillDescriptionTable.AddPVPDataNum11(builder, PVPDataNum11Offset);
			SkillDescriptionTable.AddDataNumber11(builder, DataNumber11Offset);
			SkillDescriptionTable.AddDataText11(builder, DataText11Offset);
			SkillDescriptionTable.AddPVPDataNum10(builder, PVPDataNum10Offset);
			SkillDescriptionTable.AddDataNumber10(builder, DataNumber10Offset);
			SkillDescriptionTable.AddDataText10(builder, DataText10Offset);
			SkillDescriptionTable.AddPVPDataNum9(builder, PVPDataNum9Offset);
			SkillDescriptionTable.AddDataNumber9(builder, DataNumber9Offset);
			SkillDescriptionTable.AddDataText9(builder, DataText9Offset);
			SkillDescriptionTable.AddPVPDataNum8(builder, PVPDataNum8Offset);
			SkillDescriptionTable.AddDataNumber8(builder, DataNumber8Offset);
			SkillDescriptionTable.AddDataText8(builder, DataText8Offset);
			SkillDescriptionTable.AddPVPDataNum7(builder, PVPDataNum7Offset);
			SkillDescriptionTable.AddDataNumber7(builder, DataNumber7Offset);
			SkillDescriptionTable.AddDataText7(builder, DataText7Offset);
			SkillDescriptionTable.AddPVPDataNum6(builder, PVPDataNum6Offset);
			SkillDescriptionTable.AddDataNumber6(builder, DataNumber6Offset);
			SkillDescriptionTable.AddDataText6(builder, DataText6Offset);
			SkillDescriptionTable.AddPVPDataNum5(builder, PVPDataNum5Offset);
			SkillDescriptionTable.AddDataNumber5(builder, DataNumber5Offset);
			SkillDescriptionTable.AddDataText5(builder, DataText5Offset);
			SkillDescriptionTable.AddPVPDataNum4(builder, PVPDataNum4Offset);
			SkillDescriptionTable.AddDataNumber4(builder, DataNumber4Offset);
			SkillDescriptionTable.AddDataText4(builder, DataText4Offset);
			SkillDescriptionTable.AddPVPDataNum3(builder, PVPDataNum3Offset);
			SkillDescriptionTable.AddDataNumber3(builder, DataNumber3Offset);
			SkillDescriptionTable.AddDataText3(builder, DataText3Offset);
			SkillDescriptionTable.AddPVPDataNum2(builder, PVPDataNum2Offset);
			SkillDescriptionTable.AddDataNumber2(builder, DataNumber2Offset);
			SkillDescriptionTable.AddDataText2(builder, DataText2Offset);
			SkillDescriptionTable.AddPVPDataNum1(builder, PVPDataNum1Offset);
			SkillDescriptionTable.AddDataNumber1(builder, DataNumber1Offset);
			SkillDescriptionTable.AddDataText1(builder, DataText1Offset);
			SkillDescriptionTable.AddDescription(builder, DescriptionOffset);
			SkillDescriptionTable.AddName(builder, NameOffset);
			SkillDescriptionTable.AddID(builder, ID);
			return SkillDescriptionTable.EndSkillDescriptionTable(builder);
		}

		// Token: 0x06004CDF RID: 19679 RVA: 0x000F04BC File Offset: 0x000EE8BC
		public static void StartSkillDescriptionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(40);
		}

		// Token: 0x06004CE0 RID: 19680 RVA: 0x000F04C6 File Offset: 0x000EE8C6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004CE1 RID: 19681 RVA: 0x000F04D1 File Offset: 0x000EE8D1
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004CE2 RID: 19682 RVA: 0x000F04E2 File Offset: 0x000EE8E2
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(2, DescriptionOffset.Value, 0);
		}

		// Token: 0x06004CE3 RID: 19683 RVA: 0x000F04F3 File Offset: 0x000EE8F3
		public static void AddDataText1(FlatBufferBuilder builder, StringOffset DataText1Offset)
		{
			builder.AddOffset(3, DataText1Offset.Value, 0);
		}

		// Token: 0x06004CE4 RID: 19684 RVA: 0x000F0504 File Offset: 0x000EE904
		public static void AddDataNumber1(FlatBufferBuilder builder, StringOffset DataNumber1Offset)
		{
			builder.AddOffset(4, DataNumber1Offset.Value, 0);
		}

		// Token: 0x06004CE5 RID: 19685 RVA: 0x000F0515 File Offset: 0x000EE915
		public static void AddPVPDataNum1(FlatBufferBuilder builder, StringOffset PVPDataNum1Offset)
		{
			builder.AddOffset(5, PVPDataNum1Offset.Value, 0);
		}

		// Token: 0x06004CE6 RID: 19686 RVA: 0x000F0526 File Offset: 0x000EE926
		public static void AddDataText2(FlatBufferBuilder builder, StringOffset DataText2Offset)
		{
			builder.AddOffset(6, DataText2Offset.Value, 0);
		}

		// Token: 0x06004CE7 RID: 19687 RVA: 0x000F0537 File Offset: 0x000EE937
		public static void AddDataNumber2(FlatBufferBuilder builder, StringOffset DataNumber2Offset)
		{
			builder.AddOffset(7, DataNumber2Offset.Value, 0);
		}

		// Token: 0x06004CE8 RID: 19688 RVA: 0x000F0548 File Offset: 0x000EE948
		public static void AddPVPDataNum2(FlatBufferBuilder builder, StringOffset PVPDataNum2Offset)
		{
			builder.AddOffset(8, PVPDataNum2Offset.Value, 0);
		}

		// Token: 0x06004CE9 RID: 19689 RVA: 0x000F0559 File Offset: 0x000EE959
		public static void AddDataText3(FlatBufferBuilder builder, StringOffset DataText3Offset)
		{
			builder.AddOffset(9, DataText3Offset.Value, 0);
		}

		// Token: 0x06004CEA RID: 19690 RVA: 0x000F056B File Offset: 0x000EE96B
		public static void AddDataNumber3(FlatBufferBuilder builder, StringOffset DataNumber3Offset)
		{
			builder.AddOffset(10, DataNumber3Offset.Value, 0);
		}

		// Token: 0x06004CEB RID: 19691 RVA: 0x000F057D File Offset: 0x000EE97D
		public static void AddPVPDataNum3(FlatBufferBuilder builder, StringOffset PVPDataNum3Offset)
		{
			builder.AddOffset(11, PVPDataNum3Offset.Value, 0);
		}

		// Token: 0x06004CEC RID: 19692 RVA: 0x000F058F File Offset: 0x000EE98F
		public static void AddDataText4(FlatBufferBuilder builder, StringOffset DataText4Offset)
		{
			builder.AddOffset(12, DataText4Offset.Value, 0);
		}

		// Token: 0x06004CED RID: 19693 RVA: 0x000F05A1 File Offset: 0x000EE9A1
		public static void AddDataNumber4(FlatBufferBuilder builder, StringOffset DataNumber4Offset)
		{
			builder.AddOffset(13, DataNumber4Offset.Value, 0);
		}

		// Token: 0x06004CEE RID: 19694 RVA: 0x000F05B3 File Offset: 0x000EE9B3
		public static void AddPVPDataNum4(FlatBufferBuilder builder, StringOffset PVPDataNum4Offset)
		{
			builder.AddOffset(14, PVPDataNum4Offset.Value, 0);
		}

		// Token: 0x06004CEF RID: 19695 RVA: 0x000F05C5 File Offset: 0x000EE9C5
		public static void AddDataText5(FlatBufferBuilder builder, StringOffset DataText5Offset)
		{
			builder.AddOffset(15, DataText5Offset.Value, 0);
		}

		// Token: 0x06004CF0 RID: 19696 RVA: 0x000F05D7 File Offset: 0x000EE9D7
		public static void AddDataNumber5(FlatBufferBuilder builder, StringOffset DataNumber5Offset)
		{
			builder.AddOffset(16, DataNumber5Offset.Value, 0);
		}

		// Token: 0x06004CF1 RID: 19697 RVA: 0x000F05E9 File Offset: 0x000EE9E9
		public static void AddPVPDataNum5(FlatBufferBuilder builder, StringOffset PVPDataNum5Offset)
		{
			builder.AddOffset(17, PVPDataNum5Offset.Value, 0);
		}

		// Token: 0x06004CF2 RID: 19698 RVA: 0x000F05FB File Offset: 0x000EE9FB
		public static void AddDataText6(FlatBufferBuilder builder, StringOffset DataText6Offset)
		{
			builder.AddOffset(18, DataText6Offset.Value, 0);
		}

		// Token: 0x06004CF3 RID: 19699 RVA: 0x000F060D File Offset: 0x000EEA0D
		public static void AddDataNumber6(FlatBufferBuilder builder, StringOffset DataNumber6Offset)
		{
			builder.AddOffset(19, DataNumber6Offset.Value, 0);
		}

		// Token: 0x06004CF4 RID: 19700 RVA: 0x000F061F File Offset: 0x000EEA1F
		public static void AddPVPDataNum6(FlatBufferBuilder builder, StringOffset PVPDataNum6Offset)
		{
			builder.AddOffset(20, PVPDataNum6Offset.Value, 0);
		}

		// Token: 0x06004CF5 RID: 19701 RVA: 0x000F0631 File Offset: 0x000EEA31
		public static void AddDataText7(FlatBufferBuilder builder, StringOffset DataText7Offset)
		{
			builder.AddOffset(21, DataText7Offset.Value, 0);
		}

		// Token: 0x06004CF6 RID: 19702 RVA: 0x000F0643 File Offset: 0x000EEA43
		public static void AddDataNumber7(FlatBufferBuilder builder, StringOffset DataNumber7Offset)
		{
			builder.AddOffset(22, DataNumber7Offset.Value, 0);
		}

		// Token: 0x06004CF7 RID: 19703 RVA: 0x000F0655 File Offset: 0x000EEA55
		public static void AddPVPDataNum7(FlatBufferBuilder builder, StringOffset PVPDataNum7Offset)
		{
			builder.AddOffset(23, PVPDataNum7Offset.Value, 0);
		}

		// Token: 0x06004CF8 RID: 19704 RVA: 0x000F0667 File Offset: 0x000EEA67
		public static void AddDataText8(FlatBufferBuilder builder, StringOffset DataText8Offset)
		{
			builder.AddOffset(24, DataText8Offset.Value, 0);
		}

		// Token: 0x06004CF9 RID: 19705 RVA: 0x000F0679 File Offset: 0x000EEA79
		public static void AddDataNumber8(FlatBufferBuilder builder, StringOffset DataNumber8Offset)
		{
			builder.AddOffset(25, DataNumber8Offset.Value, 0);
		}

		// Token: 0x06004CFA RID: 19706 RVA: 0x000F068B File Offset: 0x000EEA8B
		public static void AddPVPDataNum8(FlatBufferBuilder builder, StringOffset PVPDataNum8Offset)
		{
			builder.AddOffset(26, PVPDataNum8Offset.Value, 0);
		}

		// Token: 0x06004CFB RID: 19707 RVA: 0x000F069D File Offset: 0x000EEA9D
		public static void AddDataText9(FlatBufferBuilder builder, StringOffset DataText9Offset)
		{
			builder.AddOffset(27, DataText9Offset.Value, 0);
		}

		// Token: 0x06004CFC RID: 19708 RVA: 0x000F06AF File Offset: 0x000EEAAF
		public static void AddDataNumber9(FlatBufferBuilder builder, StringOffset DataNumber9Offset)
		{
			builder.AddOffset(28, DataNumber9Offset.Value, 0);
		}

		// Token: 0x06004CFD RID: 19709 RVA: 0x000F06C1 File Offset: 0x000EEAC1
		public static void AddPVPDataNum9(FlatBufferBuilder builder, StringOffset PVPDataNum9Offset)
		{
			builder.AddOffset(29, PVPDataNum9Offset.Value, 0);
		}

		// Token: 0x06004CFE RID: 19710 RVA: 0x000F06D3 File Offset: 0x000EEAD3
		public static void AddDataText10(FlatBufferBuilder builder, StringOffset DataText10Offset)
		{
			builder.AddOffset(30, DataText10Offset.Value, 0);
		}

		// Token: 0x06004CFF RID: 19711 RVA: 0x000F06E5 File Offset: 0x000EEAE5
		public static void AddDataNumber10(FlatBufferBuilder builder, StringOffset DataNumber10Offset)
		{
			builder.AddOffset(31, DataNumber10Offset.Value, 0);
		}

		// Token: 0x06004D00 RID: 19712 RVA: 0x000F06F7 File Offset: 0x000EEAF7
		public static void AddPVPDataNum10(FlatBufferBuilder builder, StringOffset PVPDataNum10Offset)
		{
			builder.AddOffset(32, PVPDataNum10Offset.Value, 0);
		}

		// Token: 0x06004D01 RID: 19713 RVA: 0x000F0709 File Offset: 0x000EEB09
		public static void AddDataText11(FlatBufferBuilder builder, StringOffset DataText11Offset)
		{
			builder.AddOffset(33, DataText11Offset.Value, 0);
		}

		// Token: 0x06004D02 RID: 19714 RVA: 0x000F071B File Offset: 0x000EEB1B
		public static void AddDataNumber11(FlatBufferBuilder builder, StringOffset DataNumber11Offset)
		{
			builder.AddOffset(34, DataNumber11Offset.Value, 0);
		}

		// Token: 0x06004D03 RID: 19715 RVA: 0x000F072D File Offset: 0x000EEB2D
		public static void AddPVPDataNum11(FlatBufferBuilder builder, StringOffset PVPDataNum11Offset)
		{
			builder.AddOffset(35, PVPDataNum11Offset.Value, 0);
		}

		// Token: 0x06004D04 RID: 19716 RVA: 0x000F073F File Offset: 0x000EEB3F
		public static void AddDataText12(FlatBufferBuilder builder, StringOffset DataText12Offset)
		{
			builder.AddOffset(36, DataText12Offset.Value, 0);
		}

		// Token: 0x06004D05 RID: 19717 RVA: 0x000F0751 File Offset: 0x000EEB51
		public static void AddDataNumber12(FlatBufferBuilder builder, StringOffset DataNumber12Offset)
		{
			builder.AddOffset(37, DataNumber12Offset.Value, 0);
		}

		// Token: 0x06004D06 RID: 19718 RVA: 0x000F0763 File Offset: 0x000EEB63
		public static void AddPVPDataNum12(FlatBufferBuilder builder, StringOffset PVPDataNum12Offset)
		{
			builder.AddOffset(38, PVPDataNum12Offset.Value, 0);
		}

		// Token: 0x06004D07 RID: 19719 RVA: 0x000F0775 File Offset: 0x000EEB75
		public static void AddDescType(FlatBufferBuilder builder, int DescType)
		{
			builder.AddInt(39, DescType, 0);
		}

		// Token: 0x06004D08 RID: 19720 RVA: 0x000F0784 File Offset: 0x000EEB84
		public static Offset<SkillDescriptionTable> EndSkillDescriptionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillDescriptionTable>(value);
		}

		// Token: 0x06004D09 RID: 19721 RVA: 0x000F079E File Offset: 0x000EEB9E
		public static void FinishSkillDescriptionTableBuffer(FlatBufferBuilder builder, Offset<SkillDescriptionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B83 RID: 7043
		private Table __p = new Table();

		// Token: 0x020005BE RID: 1470
		public enum eCrypt
		{
			// Token: 0x04001B85 RID: 7045
			code = -426948431
		}
	}
}
