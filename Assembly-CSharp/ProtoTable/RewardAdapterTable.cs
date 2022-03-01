using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000585 RID: 1413
	public class RewardAdapterTable : IFlatbufferObject
	{
		// Token: 0x1700139E RID: 5022
		// (get) Token: 0x06004895 RID: 18581 RVA: 0x000E62DC File Offset: 0x000E46DC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004896 RID: 18582 RVA: 0x000E62E9 File Offset: 0x000E46E9
		public static RewardAdapterTable GetRootAsRewardAdapterTable(ByteBuffer _bb)
		{
			return RewardAdapterTable.GetRootAsRewardAdapterTable(_bb, new RewardAdapterTable());
		}

		// Token: 0x06004897 RID: 18583 RVA: 0x000E62F6 File Offset: 0x000E46F6
		public static RewardAdapterTable GetRootAsRewardAdapterTable(ByteBuffer _bb, RewardAdapterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004898 RID: 18584 RVA: 0x000E6312 File Offset: 0x000E4712
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004899 RID: 18585 RVA: 0x000E632C File Offset: 0x000E472C
		public RewardAdapterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700139F RID: 5023
		// (get) Token: 0x0600489A RID: 18586 RVA: 0x000E6338 File Offset: 0x000E4738
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1699960114 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013A0 RID: 5024
		// (get) Token: 0x0600489B RID: 18587 RVA: 0x000E6384 File Offset: 0x000E4784
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600489C RID: 18588 RVA: 0x000E63C6 File Offset: 0x000E47C6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170013A1 RID: 5025
		// (get) Token: 0x0600489D RID: 18589 RVA: 0x000E63D4 File Offset: 0x000E47D4
		public string Level1
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600489E RID: 18590 RVA: 0x000E6416 File Offset: 0x000E4816
		public ArraySegment<byte>? GetLevel1Bytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170013A2 RID: 5026
		// (get) Token: 0x0600489F RID: 18591 RVA: 0x000E6424 File Offset: 0x000E4824
		public string Level2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048A0 RID: 18592 RVA: 0x000E6467 File Offset: 0x000E4867
		public ArraySegment<byte>? GetLevel2Bytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170013A3 RID: 5027
		// (get) Token: 0x060048A1 RID: 18593 RVA: 0x000E6478 File Offset: 0x000E4878
		public string Level3
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048A2 RID: 18594 RVA: 0x000E64BB File Offset: 0x000E48BB
		public ArraySegment<byte>? GetLevel3Bytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170013A4 RID: 5028
		// (get) Token: 0x060048A3 RID: 18595 RVA: 0x000E64CC File Offset: 0x000E48CC
		public string Level4
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048A4 RID: 18596 RVA: 0x000E650F File Offset: 0x000E490F
		public ArraySegment<byte>? GetLevel4Bytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170013A5 RID: 5029
		// (get) Token: 0x060048A5 RID: 18597 RVA: 0x000E6520 File Offset: 0x000E4920
		public string Level5
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048A6 RID: 18598 RVA: 0x000E6563 File Offset: 0x000E4963
		public ArraySegment<byte>? GetLevel5Bytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170013A6 RID: 5030
		// (get) Token: 0x060048A7 RID: 18599 RVA: 0x000E6574 File Offset: 0x000E4974
		public string Level6
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048A8 RID: 18600 RVA: 0x000E65B7 File Offset: 0x000E49B7
		public ArraySegment<byte>? GetLevel6Bytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170013A7 RID: 5031
		// (get) Token: 0x060048A9 RID: 18601 RVA: 0x000E65C8 File Offset: 0x000E49C8
		public string Level7
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048AA RID: 18602 RVA: 0x000E660B File Offset: 0x000E4A0B
		public ArraySegment<byte>? GetLevel7Bytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170013A8 RID: 5032
		// (get) Token: 0x060048AB RID: 18603 RVA: 0x000E661C File Offset: 0x000E4A1C
		public string Level8
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048AC RID: 18604 RVA: 0x000E665F File Offset: 0x000E4A5F
		public ArraySegment<byte>? GetLevel8Bytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x170013A9 RID: 5033
		// (get) Token: 0x060048AD RID: 18605 RVA: 0x000E6670 File Offset: 0x000E4A70
		public string Level9
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048AE RID: 18606 RVA: 0x000E66B3 File Offset: 0x000E4AB3
		public ArraySegment<byte>? GetLevel9Bytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170013AA RID: 5034
		// (get) Token: 0x060048AF RID: 18607 RVA: 0x000E66C4 File Offset: 0x000E4AC4
		public string Level10
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048B0 RID: 18608 RVA: 0x000E6707 File Offset: 0x000E4B07
		public ArraySegment<byte>? GetLevel10Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170013AB RID: 5035
		// (get) Token: 0x060048B1 RID: 18609 RVA: 0x000E6718 File Offset: 0x000E4B18
		public string Level11
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048B2 RID: 18610 RVA: 0x000E675B File Offset: 0x000E4B5B
		public ArraySegment<byte>? GetLevel11Bytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170013AC RID: 5036
		// (get) Token: 0x060048B3 RID: 18611 RVA: 0x000E676C File Offset: 0x000E4B6C
		public string Level12
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048B4 RID: 18612 RVA: 0x000E67AF File Offset: 0x000E4BAF
		public ArraySegment<byte>? GetLevel12Bytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170013AD RID: 5037
		// (get) Token: 0x060048B5 RID: 18613 RVA: 0x000E67C0 File Offset: 0x000E4BC0
		public string Level13
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048B6 RID: 18614 RVA: 0x000E6803 File Offset: 0x000E4C03
		public ArraySegment<byte>? GetLevel13Bytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170013AE RID: 5038
		// (get) Token: 0x060048B7 RID: 18615 RVA: 0x000E6814 File Offset: 0x000E4C14
		public string Level14
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048B8 RID: 18616 RVA: 0x000E6857 File Offset: 0x000E4C57
		public ArraySegment<byte>? GetLevel14Bytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170013AF RID: 5039
		// (get) Token: 0x060048B9 RID: 18617 RVA: 0x000E6868 File Offset: 0x000E4C68
		public string Level15
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048BA RID: 18618 RVA: 0x000E68AB File Offset: 0x000E4CAB
		public ArraySegment<byte>? GetLevel15Bytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170013B0 RID: 5040
		// (get) Token: 0x060048BB RID: 18619 RVA: 0x000E68BC File Offset: 0x000E4CBC
		public string Level16
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048BC RID: 18620 RVA: 0x000E68FF File Offset: 0x000E4CFF
		public ArraySegment<byte>? GetLevel16Bytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170013B1 RID: 5041
		// (get) Token: 0x060048BD RID: 18621 RVA: 0x000E6910 File Offset: 0x000E4D10
		public string Level17
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048BE RID: 18622 RVA: 0x000E6953 File Offset: 0x000E4D53
		public ArraySegment<byte>? GetLevel17Bytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170013B2 RID: 5042
		// (get) Token: 0x060048BF RID: 18623 RVA: 0x000E6964 File Offset: 0x000E4D64
		public string Level18
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048C0 RID: 18624 RVA: 0x000E69A7 File Offset: 0x000E4DA7
		public ArraySegment<byte>? GetLevel18Bytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170013B3 RID: 5043
		// (get) Token: 0x060048C1 RID: 18625 RVA: 0x000E69B8 File Offset: 0x000E4DB8
		public string Level19
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048C2 RID: 18626 RVA: 0x000E69FB File Offset: 0x000E4DFB
		public ArraySegment<byte>? GetLevel19Bytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170013B4 RID: 5044
		// (get) Token: 0x060048C3 RID: 18627 RVA: 0x000E6A0C File Offset: 0x000E4E0C
		public string Level20
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048C4 RID: 18628 RVA: 0x000E6A4F File Offset: 0x000E4E4F
		public ArraySegment<byte>? GetLevel20Bytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170013B5 RID: 5045
		// (get) Token: 0x060048C5 RID: 18629 RVA: 0x000E6A60 File Offset: 0x000E4E60
		public string Level21
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048C6 RID: 18630 RVA: 0x000E6AA3 File Offset: 0x000E4EA3
		public ArraySegment<byte>? GetLevel21Bytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170013B6 RID: 5046
		// (get) Token: 0x060048C7 RID: 18631 RVA: 0x000E6AB4 File Offset: 0x000E4EB4
		public string Level22
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048C8 RID: 18632 RVA: 0x000E6AF7 File Offset: 0x000E4EF7
		public ArraySegment<byte>? GetLevel22Bytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x170013B7 RID: 5047
		// (get) Token: 0x060048C9 RID: 18633 RVA: 0x000E6B08 File Offset: 0x000E4F08
		public string Level23
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048CA RID: 18634 RVA: 0x000E6B4B File Offset: 0x000E4F4B
		public ArraySegment<byte>? GetLevel23Bytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x170013B8 RID: 5048
		// (get) Token: 0x060048CB RID: 18635 RVA: 0x000E6B5C File Offset: 0x000E4F5C
		public string Level24
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048CC RID: 18636 RVA: 0x000E6B9F File Offset: 0x000E4F9F
		public ArraySegment<byte>? GetLevel24Bytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x170013B9 RID: 5049
		// (get) Token: 0x060048CD RID: 18637 RVA: 0x000E6BB0 File Offset: 0x000E4FB0
		public string Level25
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048CE RID: 18638 RVA: 0x000E6BF3 File Offset: 0x000E4FF3
		public ArraySegment<byte>? GetLevel25Bytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170013BA RID: 5050
		// (get) Token: 0x060048CF RID: 18639 RVA: 0x000E6C04 File Offset: 0x000E5004
		public string Level26
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048D0 RID: 18640 RVA: 0x000E6C47 File Offset: 0x000E5047
		public ArraySegment<byte>? GetLevel26Bytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170013BB RID: 5051
		// (get) Token: 0x060048D1 RID: 18641 RVA: 0x000E6C58 File Offset: 0x000E5058
		public string Level27
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048D2 RID: 18642 RVA: 0x000E6C9B File Offset: 0x000E509B
		public ArraySegment<byte>? GetLevel27Bytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x170013BC RID: 5052
		// (get) Token: 0x060048D3 RID: 18643 RVA: 0x000E6CAC File Offset: 0x000E50AC
		public string Level28
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048D4 RID: 18644 RVA: 0x000E6CEF File Offset: 0x000E50EF
		public ArraySegment<byte>? GetLevel28Bytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x170013BD RID: 5053
		// (get) Token: 0x060048D5 RID: 18645 RVA: 0x000E6D00 File Offset: 0x000E5100
		public string Level29
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048D6 RID: 18646 RVA: 0x000E6D43 File Offset: 0x000E5143
		public ArraySegment<byte>? GetLevel29Bytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x170013BE RID: 5054
		// (get) Token: 0x060048D7 RID: 18647 RVA: 0x000E6D54 File Offset: 0x000E5154
		public string Level30
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048D8 RID: 18648 RVA: 0x000E6D97 File Offset: 0x000E5197
		public ArraySegment<byte>? GetLevel30Bytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x170013BF RID: 5055
		// (get) Token: 0x060048D9 RID: 18649 RVA: 0x000E6DA8 File Offset: 0x000E51A8
		public string Level31
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048DA RID: 18650 RVA: 0x000E6DEB File Offset: 0x000E51EB
		public ArraySegment<byte>? GetLevel31Bytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x170013C0 RID: 5056
		// (get) Token: 0x060048DB RID: 18651 RVA: 0x000E6DFC File Offset: 0x000E51FC
		public string Level32
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048DC RID: 18652 RVA: 0x000E6E3F File Offset: 0x000E523F
		public ArraySegment<byte>? GetLevel32Bytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x170013C1 RID: 5057
		// (get) Token: 0x060048DD RID: 18653 RVA: 0x000E6E50 File Offset: 0x000E5250
		public string Level33
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048DE RID: 18654 RVA: 0x000E6E93 File Offset: 0x000E5293
		public ArraySegment<byte>? GetLevel33Bytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x170013C2 RID: 5058
		// (get) Token: 0x060048DF RID: 18655 RVA: 0x000E6EA4 File Offset: 0x000E52A4
		public string Level34
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048E0 RID: 18656 RVA: 0x000E6EE7 File Offset: 0x000E52E7
		public ArraySegment<byte>? GetLevel34Bytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x170013C3 RID: 5059
		// (get) Token: 0x060048E1 RID: 18657 RVA: 0x000E6EF8 File Offset: 0x000E52F8
		public string Level35
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048E2 RID: 18658 RVA: 0x000E6F3B File Offset: 0x000E533B
		public ArraySegment<byte>? GetLevel35Bytes()
		{
			return this.__p.__vector_as_arraysegment(76);
		}

		// Token: 0x170013C4 RID: 5060
		// (get) Token: 0x060048E3 RID: 18659 RVA: 0x000E6F4C File Offset: 0x000E534C
		public string Level36
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048E4 RID: 18660 RVA: 0x000E6F8F File Offset: 0x000E538F
		public ArraySegment<byte>? GetLevel36Bytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x170013C5 RID: 5061
		// (get) Token: 0x060048E5 RID: 18661 RVA: 0x000E6FA0 File Offset: 0x000E53A0
		public string Level37
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048E6 RID: 18662 RVA: 0x000E6FE3 File Offset: 0x000E53E3
		public ArraySegment<byte>? GetLevel37Bytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x170013C6 RID: 5062
		// (get) Token: 0x060048E7 RID: 18663 RVA: 0x000E6FF4 File Offset: 0x000E53F4
		public string Level38
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048E8 RID: 18664 RVA: 0x000E7037 File Offset: 0x000E5437
		public ArraySegment<byte>? GetLevel38Bytes()
		{
			return this.__p.__vector_as_arraysegment(82);
		}

		// Token: 0x170013C7 RID: 5063
		// (get) Token: 0x060048E9 RID: 18665 RVA: 0x000E7048 File Offset: 0x000E5448
		public string Level39
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048EA RID: 18666 RVA: 0x000E708B File Offset: 0x000E548B
		public ArraySegment<byte>? GetLevel39Bytes()
		{
			return this.__p.__vector_as_arraysegment(84);
		}

		// Token: 0x170013C8 RID: 5064
		// (get) Token: 0x060048EB RID: 18667 RVA: 0x000E709C File Offset: 0x000E549C
		public string Level40
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048EC RID: 18668 RVA: 0x000E70DF File Offset: 0x000E54DF
		public ArraySegment<byte>? GetLevel40Bytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x170013C9 RID: 5065
		// (get) Token: 0x060048ED RID: 18669 RVA: 0x000E70F0 File Offset: 0x000E54F0
		public string Level41
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048EE RID: 18670 RVA: 0x000E7133 File Offset: 0x000E5533
		public ArraySegment<byte>? GetLevel41Bytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x170013CA RID: 5066
		// (get) Token: 0x060048EF RID: 18671 RVA: 0x000E7144 File Offset: 0x000E5544
		public string Level42
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048F0 RID: 18672 RVA: 0x000E7187 File Offset: 0x000E5587
		public ArraySegment<byte>? GetLevel42Bytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x170013CB RID: 5067
		// (get) Token: 0x060048F1 RID: 18673 RVA: 0x000E7198 File Offset: 0x000E5598
		public string Level43
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048F2 RID: 18674 RVA: 0x000E71DB File Offset: 0x000E55DB
		public ArraySegment<byte>? GetLevel43Bytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x170013CC RID: 5068
		// (get) Token: 0x060048F3 RID: 18675 RVA: 0x000E71EC File Offset: 0x000E55EC
		public string Level44
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048F4 RID: 18676 RVA: 0x000E722F File Offset: 0x000E562F
		public ArraySegment<byte>? GetLevel44Bytes()
		{
			return this.__p.__vector_as_arraysegment(94);
		}

		// Token: 0x170013CD RID: 5069
		// (get) Token: 0x060048F5 RID: 18677 RVA: 0x000E7240 File Offset: 0x000E5640
		public string Level45
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048F6 RID: 18678 RVA: 0x000E7283 File Offset: 0x000E5683
		public ArraySegment<byte>? GetLevel45Bytes()
		{
			return this.__p.__vector_as_arraysegment(96);
		}

		// Token: 0x170013CE RID: 5070
		// (get) Token: 0x060048F7 RID: 18679 RVA: 0x000E7294 File Offset: 0x000E5694
		public string Level46
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048F8 RID: 18680 RVA: 0x000E72D7 File Offset: 0x000E56D7
		public ArraySegment<byte>? GetLevel46Bytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x170013CF RID: 5071
		// (get) Token: 0x060048F9 RID: 18681 RVA: 0x000E72E8 File Offset: 0x000E56E8
		public string Level47
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048FA RID: 18682 RVA: 0x000E732B File Offset: 0x000E572B
		public ArraySegment<byte>? GetLevel47Bytes()
		{
			return this.__p.__vector_as_arraysegment(100);
		}

		// Token: 0x170013D0 RID: 5072
		// (get) Token: 0x060048FB RID: 18683 RVA: 0x000E733C File Offset: 0x000E573C
		public string Level48
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048FC RID: 18684 RVA: 0x000E737F File Offset: 0x000E577F
		public ArraySegment<byte>? GetLevel48Bytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x170013D1 RID: 5073
		// (get) Token: 0x060048FD RID: 18685 RVA: 0x000E7390 File Offset: 0x000E5790
		public string Level49
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060048FE RID: 18686 RVA: 0x000E73D3 File Offset: 0x000E57D3
		public ArraySegment<byte>? GetLevel49Bytes()
		{
			return this.__p.__vector_as_arraysegment(104);
		}

		// Token: 0x170013D2 RID: 5074
		// (get) Token: 0x060048FF RID: 18687 RVA: 0x000E73E4 File Offset: 0x000E57E4
		public string Level50
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004900 RID: 18688 RVA: 0x000E7427 File Offset: 0x000E5827
		public ArraySegment<byte>? GetLevel50Bytes()
		{
			return this.__p.__vector_as_arraysegment(106);
		}

		// Token: 0x170013D3 RID: 5075
		// (get) Token: 0x06004901 RID: 18689 RVA: 0x000E7438 File Offset: 0x000E5838
		public string Level51
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004902 RID: 18690 RVA: 0x000E747B File Offset: 0x000E587B
		public ArraySegment<byte>? GetLevel51Bytes()
		{
			return this.__p.__vector_as_arraysegment(108);
		}

		// Token: 0x170013D4 RID: 5076
		// (get) Token: 0x06004903 RID: 18691 RVA: 0x000E748C File Offset: 0x000E588C
		public string Level52
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004904 RID: 18692 RVA: 0x000E74CF File Offset: 0x000E58CF
		public ArraySegment<byte>? GetLevel52Bytes()
		{
			return this.__p.__vector_as_arraysegment(110);
		}

		// Token: 0x170013D5 RID: 5077
		// (get) Token: 0x06004905 RID: 18693 RVA: 0x000E74E0 File Offset: 0x000E58E0
		public string Level53
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004906 RID: 18694 RVA: 0x000E7523 File Offset: 0x000E5923
		public ArraySegment<byte>? GetLevel53Bytes()
		{
			return this.__p.__vector_as_arraysegment(112);
		}

		// Token: 0x170013D6 RID: 5078
		// (get) Token: 0x06004907 RID: 18695 RVA: 0x000E7534 File Offset: 0x000E5934
		public string Level54
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004908 RID: 18696 RVA: 0x000E7577 File Offset: 0x000E5977
		public ArraySegment<byte>? GetLevel54Bytes()
		{
			return this.__p.__vector_as_arraysegment(114);
		}

		// Token: 0x170013D7 RID: 5079
		// (get) Token: 0x06004909 RID: 18697 RVA: 0x000E7588 File Offset: 0x000E5988
		public string Level55
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600490A RID: 18698 RVA: 0x000E75CB File Offset: 0x000E59CB
		public ArraySegment<byte>? GetLevel55Bytes()
		{
			return this.__p.__vector_as_arraysegment(116);
		}

		// Token: 0x170013D8 RID: 5080
		// (get) Token: 0x0600490B RID: 18699 RVA: 0x000E75DC File Offset: 0x000E59DC
		public string Level56
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600490C RID: 18700 RVA: 0x000E761F File Offset: 0x000E5A1F
		public ArraySegment<byte>? GetLevel56Bytes()
		{
			return this.__p.__vector_as_arraysegment(118);
		}

		// Token: 0x170013D9 RID: 5081
		// (get) Token: 0x0600490D RID: 18701 RVA: 0x000E7630 File Offset: 0x000E5A30
		public string Level57
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600490E RID: 18702 RVA: 0x000E7673 File Offset: 0x000E5A73
		public ArraySegment<byte>? GetLevel57Bytes()
		{
			return this.__p.__vector_as_arraysegment(120);
		}

		// Token: 0x170013DA RID: 5082
		// (get) Token: 0x0600490F RID: 18703 RVA: 0x000E7684 File Offset: 0x000E5A84
		public string Level58
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004910 RID: 18704 RVA: 0x000E76C7 File Offset: 0x000E5AC7
		public ArraySegment<byte>? GetLevel58Bytes()
		{
			return this.__p.__vector_as_arraysegment(122);
		}

		// Token: 0x170013DB RID: 5083
		// (get) Token: 0x06004911 RID: 18705 RVA: 0x000E76D8 File Offset: 0x000E5AD8
		public string Level59
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004912 RID: 18706 RVA: 0x000E771B File Offset: 0x000E5B1B
		public ArraySegment<byte>? GetLevel59Bytes()
		{
			return this.__p.__vector_as_arraysegment(124);
		}

		// Token: 0x170013DC RID: 5084
		// (get) Token: 0x06004913 RID: 18707 RVA: 0x000E772C File Offset: 0x000E5B2C
		public string Level60
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004914 RID: 18708 RVA: 0x000E776F File Offset: 0x000E5B6F
		public ArraySegment<byte>? GetLevel60Bytes()
		{
			return this.__p.__vector_as_arraysegment(126);
		}

		// Token: 0x170013DD RID: 5085
		// (get) Token: 0x06004915 RID: 18709 RVA: 0x000E7780 File Offset: 0x000E5B80
		public string Level61
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004916 RID: 18710 RVA: 0x000E77C6 File Offset: 0x000E5BC6
		public ArraySegment<byte>? GetLevel61Bytes()
		{
			return this.__p.__vector_as_arraysegment(128);
		}

		// Token: 0x170013DE RID: 5086
		// (get) Token: 0x06004917 RID: 18711 RVA: 0x000E77D8 File Offset: 0x000E5BD8
		public string Level62
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004918 RID: 18712 RVA: 0x000E781E File Offset: 0x000E5C1E
		public ArraySegment<byte>? GetLevel62Bytes()
		{
			return this.__p.__vector_as_arraysegment(130);
		}

		// Token: 0x170013DF RID: 5087
		// (get) Token: 0x06004919 RID: 18713 RVA: 0x000E7830 File Offset: 0x000E5C30
		public string Level63
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600491A RID: 18714 RVA: 0x000E7876 File Offset: 0x000E5C76
		public ArraySegment<byte>? GetLevel63Bytes()
		{
			return this.__p.__vector_as_arraysegment(132);
		}

		// Token: 0x170013E0 RID: 5088
		// (get) Token: 0x0600491B RID: 18715 RVA: 0x000E7888 File Offset: 0x000E5C88
		public string Level64
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600491C RID: 18716 RVA: 0x000E78CE File Offset: 0x000E5CCE
		public ArraySegment<byte>? GetLevel64Bytes()
		{
			return this.__p.__vector_as_arraysegment(134);
		}

		// Token: 0x170013E1 RID: 5089
		// (get) Token: 0x0600491D RID: 18717 RVA: 0x000E78E0 File Offset: 0x000E5CE0
		public string Level65
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600491E RID: 18718 RVA: 0x000E7926 File Offset: 0x000E5D26
		public ArraySegment<byte>? GetLevel65Bytes()
		{
			return this.__p.__vector_as_arraysegment(136);
		}

		// Token: 0x0600491F RID: 18719 RVA: 0x000E7938 File Offset: 0x000E5D38
		public static Offset<RewardAdapterTable> CreateRewardAdapterTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset Level1Offset = default(StringOffset), StringOffset Level2Offset = default(StringOffset), StringOffset Level3Offset = default(StringOffset), StringOffset Level4Offset = default(StringOffset), StringOffset Level5Offset = default(StringOffset), StringOffset Level6Offset = default(StringOffset), StringOffset Level7Offset = default(StringOffset), StringOffset Level8Offset = default(StringOffset), StringOffset Level9Offset = default(StringOffset), StringOffset Level10Offset = default(StringOffset), StringOffset Level11Offset = default(StringOffset), StringOffset Level12Offset = default(StringOffset), StringOffset Level13Offset = default(StringOffset), StringOffset Level14Offset = default(StringOffset), StringOffset Level15Offset = default(StringOffset), StringOffset Level16Offset = default(StringOffset), StringOffset Level17Offset = default(StringOffset), StringOffset Level18Offset = default(StringOffset), StringOffset Level19Offset = default(StringOffset), StringOffset Level20Offset = default(StringOffset), StringOffset Level21Offset = default(StringOffset), StringOffset Level22Offset = default(StringOffset), StringOffset Level23Offset = default(StringOffset), StringOffset Level24Offset = default(StringOffset), StringOffset Level25Offset = default(StringOffset), StringOffset Level26Offset = default(StringOffset), StringOffset Level27Offset = default(StringOffset), StringOffset Level28Offset = default(StringOffset), StringOffset Level29Offset = default(StringOffset), StringOffset Level30Offset = default(StringOffset), StringOffset Level31Offset = default(StringOffset), StringOffset Level32Offset = default(StringOffset), StringOffset Level33Offset = default(StringOffset), StringOffset Level34Offset = default(StringOffset), StringOffset Level35Offset = default(StringOffset), StringOffset Level36Offset = default(StringOffset), StringOffset Level37Offset = default(StringOffset), StringOffset Level38Offset = default(StringOffset), StringOffset Level39Offset = default(StringOffset), StringOffset Level40Offset = default(StringOffset), StringOffset Level41Offset = default(StringOffset), StringOffset Level42Offset = default(StringOffset), StringOffset Level43Offset = default(StringOffset), StringOffset Level44Offset = default(StringOffset), StringOffset Level45Offset = default(StringOffset), StringOffset Level46Offset = default(StringOffset), StringOffset Level47Offset = default(StringOffset), StringOffset Level48Offset = default(StringOffset), StringOffset Level49Offset = default(StringOffset), StringOffset Level50Offset = default(StringOffset), StringOffset Level51Offset = default(StringOffset), StringOffset Level52Offset = default(StringOffset), StringOffset Level53Offset = default(StringOffset), StringOffset Level54Offset = default(StringOffset), StringOffset Level55Offset = default(StringOffset), StringOffset Level56Offset = default(StringOffset), StringOffset Level57Offset = default(StringOffset), StringOffset Level58Offset = default(StringOffset), StringOffset Level59Offset = default(StringOffset), StringOffset Level60Offset = default(StringOffset), StringOffset Level61Offset = default(StringOffset), StringOffset Level62Offset = default(StringOffset), StringOffset Level63Offset = default(StringOffset), StringOffset Level64Offset = default(StringOffset), StringOffset Level65Offset = default(StringOffset))
		{
			builder.StartObject(67);
			RewardAdapterTable.AddLevel65(builder, Level65Offset);
			RewardAdapterTable.AddLevel64(builder, Level64Offset);
			RewardAdapterTable.AddLevel63(builder, Level63Offset);
			RewardAdapterTable.AddLevel62(builder, Level62Offset);
			RewardAdapterTable.AddLevel61(builder, Level61Offset);
			RewardAdapterTable.AddLevel60(builder, Level60Offset);
			RewardAdapterTable.AddLevel59(builder, Level59Offset);
			RewardAdapterTable.AddLevel58(builder, Level58Offset);
			RewardAdapterTable.AddLevel57(builder, Level57Offset);
			RewardAdapterTable.AddLevel56(builder, Level56Offset);
			RewardAdapterTable.AddLevel55(builder, Level55Offset);
			RewardAdapterTable.AddLevel54(builder, Level54Offset);
			RewardAdapterTable.AddLevel53(builder, Level53Offset);
			RewardAdapterTable.AddLevel52(builder, Level52Offset);
			RewardAdapterTable.AddLevel51(builder, Level51Offset);
			RewardAdapterTable.AddLevel50(builder, Level50Offset);
			RewardAdapterTable.AddLevel49(builder, Level49Offset);
			RewardAdapterTable.AddLevel48(builder, Level48Offset);
			RewardAdapterTable.AddLevel47(builder, Level47Offset);
			RewardAdapterTable.AddLevel46(builder, Level46Offset);
			RewardAdapterTable.AddLevel45(builder, Level45Offset);
			RewardAdapterTable.AddLevel44(builder, Level44Offset);
			RewardAdapterTable.AddLevel43(builder, Level43Offset);
			RewardAdapterTable.AddLevel42(builder, Level42Offset);
			RewardAdapterTable.AddLevel41(builder, Level41Offset);
			RewardAdapterTable.AddLevel40(builder, Level40Offset);
			RewardAdapterTable.AddLevel39(builder, Level39Offset);
			RewardAdapterTable.AddLevel38(builder, Level38Offset);
			RewardAdapterTable.AddLevel37(builder, Level37Offset);
			RewardAdapterTable.AddLevel36(builder, Level36Offset);
			RewardAdapterTable.AddLevel35(builder, Level35Offset);
			RewardAdapterTable.AddLevel34(builder, Level34Offset);
			RewardAdapterTable.AddLevel33(builder, Level33Offset);
			RewardAdapterTable.AddLevel32(builder, Level32Offset);
			RewardAdapterTable.AddLevel31(builder, Level31Offset);
			RewardAdapterTable.AddLevel30(builder, Level30Offset);
			RewardAdapterTable.AddLevel29(builder, Level29Offset);
			RewardAdapterTable.AddLevel28(builder, Level28Offset);
			RewardAdapterTable.AddLevel27(builder, Level27Offset);
			RewardAdapterTable.AddLevel26(builder, Level26Offset);
			RewardAdapterTable.AddLevel25(builder, Level25Offset);
			RewardAdapterTable.AddLevel24(builder, Level24Offset);
			RewardAdapterTable.AddLevel23(builder, Level23Offset);
			RewardAdapterTable.AddLevel22(builder, Level22Offset);
			RewardAdapterTable.AddLevel21(builder, Level21Offset);
			RewardAdapterTable.AddLevel20(builder, Level20Offset);
			RewardAdapterTable.AddLevel19(builder, Level19Offset);
			RewardAdapterTable.AddLevel18(builder, Level18Offset);
			RewardAdapterTable.AddLevel17(builder, Level17Offset);
			RewardAdapterTable.AddLevel16(builder, Level16Offset);
			RewardAdapterTable.AddLevel15(builder, Level15Offset);
			RewardAdapterTable.AddLevel14(builder, Level14Offset);
			RewardAdapterTable.AddLevel13(builder, Level13Offset);
			RewardAdapterTable.AddLevel12(builder, Level12Offset);
			RewardAdapterTable.AddLevel11(builder, Level11Offset);
			RewardAdapterTable.AddLevel10(builder, Level10Offset);
			RewardAdapterTable.AddLevel9(builder, Level9Offset);
			RewardAdapterTable.AddLevel8(builder, Level8Offset);
			RewardAdapterTable.AddLevel7(builder, Level7Offset);
			RewardAdapterTable.AddLevel6(builder, Level6Offset);
			RewardAdapterTable.AddLevel5(builder, Level5Offset);
			RewardAdapterTable.AddLevel4(builder, Level4Offset);
			RewardAdapterTable.AddLevel3(builder, Level3Offset);
			RewardAdapterTable.AddLevel2(builder, Level2Offset);
			RewardAdapterTable.AddLevel1(builder, Level1Offset);
			RewardAdapterTable.AddName(builder, NameOffset);
			RewardAdapterTable.AddID(builder, ID);
			return RewardAdapterTable.EndRewardAdapterTable(builder);
		}

		// Token: 0x06004920 RID: 18720 RVA: 0x000E7B68 File Offset: 0x000E5F68
		public static void StartRewardAdapterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(67);
		}

		// Token: 0x06004921 RID: 18721 RVA: 0x000E7B72 File Offset: 0x000E5F72
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004922 RID: 18722 RVA: 0x000E7B7D File Offset: 0x000E5F7D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004923 RID: 18723 RVA: 0x000E7B8E File Offset: 0x000E5F8E
		public static void AddLevel1(FlatBufferBuilder builder, StringOffset Level1Offset)
		{
			builder.AddOffset(2, Level1Offset.Value, 0);
		}

		// Token: 0x06004924 RID: 18724 RVA: 0x000E7B9F File Offset: 0x000E5F9F
		public static void AddLevel2(FlatBufferBuilder builder, StringOffset Level2Offset)
		{
			builder.AddOffset(3, Level2Offset.Value, 0);
		}

		// Token: 0x06004925 RID: 18725 RVA: 0x000E7BB0 File Offset: 0x000E5FB0
		public static void AddLevel3(FlatBufferBuilder builder, StringOffset Level3Offset)
		{
			builder.AddOffset(4, Level3Offset.Value, 0);
		}

		// Token: 0x06004926 RID: 18726 RVA: 0x000E7BC1 File Offset: 0x000E5FC1
		public static void AddLevel4(FlatBufferBuilder builder, StringOffset Level4Offset)
		{
			builder.AddOffset(5, Level4Offset.Value, 0);
		}

		// Token: 0x06004927 RID: 18727 RVA: 0x000E7BD2 File Offset: 0x000E5FD2
		public static void AddLevel5(FlatBufferBuilder builder, StringOffset Level5Offset)
		{
			builder.AddOffset(6, Level5Offset.Value, 0);
		}

		// Token: 0x06004928 RID: 18728 RVA: 0x000E7BE3 File Offset: 0x000E5FE3
		public static void AddLevel6(FlatBufferBuilder builder, StringOffset Level6Offset)
		{
			builder.AddOffset(7, Level6Offset.Value, 0);
		}

		// Token: 0x06004929 RID: 18729 RVA: 0x000E7BF4 File Offset: 0x000E5FF4
		public static void AddLevel7(FlatBufferBuilder builder, StringOffset Level7Offset)
		{
			builder.AddOffset(8, Level7Offset.Value, 0);
		}

		// Token: 0x0600492A RID: 18730 RVA: 0x000E7C05 File Offset: 0x000E6005
		public static void AddLevel8(FlatBufferBuilder builder, StringOffset Level8Offset)
		{
			builder.AddOffset(9, Level8Offset.Value, 0);
		}

		// Token: 0x0600492B RID: 18731 RVA: 0x000E7C17 File Offset: 0x000E6017
		public static void AddLevel9(FlatBufferBuilder builder, StringOffset Level9Offset)
		{
			builder.AddOffset(10, Level9Offset.Value, 0);
		}

		// Token: 0x0600492C RID: 18732 RVA: 0x000E7C29 File Offset: 0x000E6029
		public static void AddLevel10(FlatBufferBuilder builder, StringOffset Level10Offset)
		{
			builder.AddOffset(11, Level10Offset.Value, 0);
		}

		// Token: 0x0600492D RID: 18733 RVA: 0x000E7C3B File Offset: 0x000E603B
		public static void AddLevel11(FlatBufferBuilder builder, StringOffset Level11Offset)
		{
			builder.AddOffset(12, Level11Offset.Value, 0);
		}

		// Token: 0x0600492E RID: 18734 RVA: 0x000E7C4D File Offset: 0x000E604D
		public static void AddLevel12(FlatBufferBuilder builder, StringOffset Level12Offset)
		{
			builder.AddOffset(13, Level12Offset.Value, 0);
		}

		// Token: 0x0600492F RID: 18735 RVA: 0x000E7C5F File Offset: 0x000E605F
		public static void AddLevel13(FlatBufferBuilder builder, StringOffset Level13Offset)
		{
			builder.AddOffset(14, Level13Offset.Value, 0);
		}

		// Token: 0x06004930 RID: 18736 RVA: 0x000E7C71 File Offset: 0x000E6071
		public static void AddLevel14(FlatBufferBuilder builder, StringOffset Level14Offset)
		{
			builder.AddOffset(15, Level14Offset.Value, 0);
		}

		// Token: 0x06004931 RID: 18737 RVA: 0x000E7C83 File Offset: 0x000E6083
		public static void AddLevel15(FlatBufferBuilder builder, StringOffset Level15Offset)
		{
			builder.AddOffset(16, Level15Offset.Value, 0);
		}

		// Token: 0x06004932 RID: 18738 RVA: 0x000E7C95 File Offset: 0x000E6095
		public static void AddLevel16(FlatBufferBuilder builder, StringOffset Level16Offset)
		{
			builder.AddOffset(17, Level16Offset.Value, 0);
		}

		// Token: 0x06004933 RID: 18739 RVA: 0x000E7CA7 File Offset: 0x000E60A7
		public static void AddLevel17(FlatBufferBuilder builder, StringOffset Level17Offset)
		{
			builder.AddOffset(18, Level17Offset.Value, 0);
		}

		// Token: 0x06004934 RID: 18740 RVA: 0x000E7CB9 File Offset: 0x000E60B9
		public static void AddLevel18(FlatBufferBuilder builder, StringOffset Level18Offset)
		{
			builder.AddOffset(19, Level18Offset.Value, 0);
		}

		// Token: 0x06004935 RID: 18741 RVA: 0x000E7CCB File Offset: 0x000E60CB
		public static void AddLevel19(FlatBufferBuilder builder, StringOffset Level19Offset)
		{
			builder.AddOffset(20, Level19Offset.Value, 0);
		}

		// Token: 0x06004936 RID: 18742 RVA: 0x000E7CDD File Offset: 0x000E60DD
		public static void AddLevel20(FlatBufferBuilder builder, StringOffset Level20Offset)
		{
			builder.AddOffset(21, Level20Offset.Value, 0);
		}

		// Token: 0x06004937 RID: 18743 RVA: 0x000E7CEF File Offset: 0x000E60EF
		public static void AddLevel21(FlatBufferBuilder builder, StringOffset Level21Offset)
		{
			builder.AddOffset(22, Level21Offset.Value, 0);
		}

		// Token: 0x06004938 RID: 18744 RVA: 0x000E7D01 File Offset: 0x000E6101
		public static void AddLevel22(FlatBufferBuilder builder, StringOffset Level22Offset)
		{
			builder.AddOffset(23, Level22Offset.Value, 0);
		}

		// Token: 0x06004939 RID: 18745 RVA: 0x000E7D13 File Offset: 0x000E6113
		public static void AddLevel23(FlatBufferBuilder builder, StringOffset Level23Offset)
		{
			builder.AddOffset(24, Level23Offset.Value, 0);
		}

		// Token: 0x0600493A RID: 18746 RVA: 0x000E7D25 File Offset: 0x000E6125
		public static void AddLevel24(FlatBufferBuilder builder, StringOffset Level24Offset)
		{
			builder.AddOffset(25, Level24Offset.Value, 0);
		}

		// Token: 0x0600493B RID: 18747 RVA: 0x000E7D37 File Offset: 0x000E6137
		public static void AddLevel25(FlatBufferBuilder builder, StringOffset Level25Offset)
		{
			builder.AddOffset(26, Level25Offset.Value, 0);
		}

		// Token: 0x0600493C RID: 18748 RVA: 0x000E7D49 File Offset: 0x000E6149
		public static void AddLevel26(FlatBufferBuilder builder, StringOffset Level26Offset)
		{
			builder.AddOffset(27, Level26Offset.Value, 0);
		}

		// Token: 0x0600493D RID: 18749 RVA: 0x000E7D5B File Offset: 0x000E615B
		public static void AddLevel27(FlatBufferBuilder builder, StringOffset Level27Offset)
		{
			builder.AddOffset(28, Level27Offset.Value, 0);
		}

		// Token: 0x0600493E RID: 18750 RVA: 0x000E7D6D File Offset: 0x000E616D
		public static void AddLevel28(FlatBufferBuilder builder, StringOffset Level28Offset)
		{
			builder.AddOffset(29, Level28Offset.Value, 0);
		}

		// Token: 0x0600493F RID: 18751 RVA: 0x000E7D7F File Offset: 0x000E617F
		public static void AddLevel29(FlatBufferBuilder builder, StringOffset Level29Offset)
		{
			builder.AddOffset(30, Level29Offset.Value, 0);
		}

		// Token: 0x06004940 RID: 18752 RVA: 0x000E7D91 File Offset: 0x000E6191
		public static void AddLevel30(FlatBufferBuilder builder, StringOffset Level30Offset)
		{
			builder.AddOffset(31, Level30Offset.Value, 0);
		}

		// Token: 0x06004941 RID: 18753 RVA: 0x000E7DA3 File Offset: 0x000E61A3
		public static void AddLevel31(FlatBufferBuilder builder, StringOffset Level31Offset)
		{
			builder.AddOffset(32, Level31Offset.Value, 0);
		}

		// Token: 0x06004942 RID: 18754 RVA: 0x000E7DB5 File Offset: 0x000E61B5
		public static void AddLevel32(FlatBufferBuilder builder, StringOffset Level32Offset)
		{
			builder.AddOffset(33, Level32Offset.Value, 0);
		}

		// Token: 0x06004943 RID: 18755 RVA: 0x000E7DC7 File Offset: 0x000E61C7
		public static void AddLevel33(FlatBufferBuilder builder, StringOffset Level33Offset)
		{
			builder.AddOffset(34, Level33Offset.Value, 0);
		}

		// Token: 0x06004944 RID: 18756 RVA: 0x000E7DD9 File Offset: 0x000E61D9
		public static void AddLevel34(FlatBufferBuilder builder, StringOffset Level34Offset)
		{
			builder.AddOffset(35, Level34Offset.Value, 0);
		}

		// Token: 0x06004945 RID: 18757 RVA: 0x000E7DEB File Offset: 0x000E61EB
		public static void AddLevel35(FlatBufferBuilder builder, StringOffset Level35Offset)
		{
			builder.AddOffset(36, Level35Offset.Value, 0);
		}

		// Token: 0x06004946 RID: 18758 RVA: 0x000E7DFD File Offset: 0x000E61FD
		public static void AddLevel36(FlatBufferBuilder builder, StringOffset Level36Offset)
		{
			builder.AddOffset(37, Level36Offset.Value, 0);
		}

		// Token: 0x06004947 RID: 18759 RVA: 0x000E7E0F File Offset: 0x000E620F
		public static void AddLevel37(FlatBufferBuilder builder, StringOffset Level37Offset)
		{
			builder.AddOffset(38, Level37Offset.Value, 0);
		}

		// Token: 0x06004948 RID: 18760 RVA: 0x000E7E21 File Offset: 0x000E6221
		public static void AddLevel38(FlatBufferBuilder builder, StringOffset Level38Offset)
		{
			builder.AddOffset(39, Level38Offset.Value, 0);
		}

		// Token: 0x06004949 RID: 18761 RVA: 0x000E7E33 File Offset: 0x000E6233
		public static void AddLevel39(FlatBufferBuilder builder, StringOffset Level39Offset)
		{
			builder.AddOffset(40, Level39Offset.Value, 0);
		}

		// Token: 0x0600494A RID: 18762 RVA: 0x000E7E45 File Offset: 0x000E6245
		public static void AddLevel40(FlatBufferBuilder builder, StringOffset Level40Offset)
		{
			builder.AddOffset(41, Level40Offset.Value, 0);
		}

		// Token: 0x0600494B RID: 18763 RVA: 0x000E7E57 File Offset: 0x000E6257
		public static void AddLevel41(FlatBufferBuilder builder, StringOffset Level41Offset)
		{
			builder.AddOffset(42, Level41Offset.Value, 0);
		}

		// Token: 0x0600494C RID: 18764 RVA: 0x000E7E69 File Offset: 0x000E6269
		public static void AddLevel42(FlatBufferBuilder builder, StringOffset Level42Offset)
		{
			builder.AddOffset(43, Level42Offset.Value, 0);
		}

		// Token: 0x0600494D RID: 18765 RVA: 0x000E7E7B File Offset: 0x000E627B
		public static void AddLevel43(FlatBufferBuilder builder, StringOffset Level43Offset)
		{
			builder.AddOffset(44, Level43Offset.Value, 0);
		}

		// Token: 0x0600494E RID: 18766 RVA: 0x000E7E8D File Offset: 0x000E628D
		public static void AddLevel44(FlatBufferBuilder builder, StringOffset Level44Offset)
		{
			builder.AddOffset(45, Level44Offset.Value, 0);
		}

		// Token: 0x0600494F RID: 18767 RVA: 0x000E7E9F File Offset: 0x000E629F
		public static void AddLevel45(FlatBufferBuilder builder, StringOffset Level45Offset)
		{
			builder.AddOffset(46, Level45Offset.Value, 0);
		}

		// Token: 0x06004950 RID: 18768 RVA: 0x000E7EB1 File Offset: 0x000E62B1
		public static void AddLevel46(FlatBufferBuilder builder, StringOffset Level46Offset)
		{
			builder.AddOffset(47, Level46Offset.Value, 0);
		}

		// Token: 0x06004951 RID: 18769 RVA: 0x000E7EC3 File Offset: 0x000E62C3
		public static void AddLevel47(FlatBufferBuilder builder, StringOffset Level47Offset)
		{
			builder.AddOffset(48, Level47Offset.Value, 0);
		}

		// Token: 0x06004952 RID: 18770 RVA: 0x000E7ED5 File Offset: 0x000E62D5
		public static void AddLevel48(FlatBufferBuilder builder, StringOffset Level48Offset)
		{
			builder.AddOffset(49, Level48Offset.Value, 0);
		}

		// Token: 0x06004953 RID: 18771 RVA: 0x000E7EE7 File Offset: 0x000E62E7
		public static void AddLevel49(FlatBufferBuilder builder, StringOffset Level49Offset)
		{
			builder.AddOffset(50, Level49Offset.Value, 0);
		}

		// Token: 0x06004954 RID: 18772 RVA: 0x000E7EF9 File Offset: 0x000E62F9
		public static void AddLevel50(FlatBufferBuilder builder, StringOffset Level50Offset)
		{
			builder.AddOffset(51, Level50Offset.Value, 0);
		}

		// Token: 0x06004955 RID: 18773 RVA: 0x000E7F0B File Offset: 0x000E630B
		public static void AddLevel51(FlatBufferBuilder builder, StringOffset Level51Offset)
		{
			builder.AddOffset(52, Level51Offset.Value, 0);
		}

		// Token: 0x06004956 RID: 18774 RVA: 0x000E7F1D File Offset: 0x000E631D
		public static void AddLevel52(FlatBufferBuilder builder, StringOffset Level52Offset)
		{
			builder.AddOffset(53, Level52Offset.Value, 0);
		}

		// Token: 0x06004957 RID: 18775 RVA: 0x000E7F2F File Offset: 0x000E632F
		public static void AddLevel53(FlatBufferBuilder builder, StringOffset Level53Offset)
		{
			builder.AddOffset(54, Level53Offset.Value, 0);
		}

		// Token: 0x06004958 RID: 18776 RVA: 0x000E7F41 File Offset: 0x000E6341
		public static void AddLevel54(FlatBufferBuilder builder, StringOffset Level54Offset)
		{
			builder.AddOffset(55, Level54Offset.Value, 0);
		}

		// Token: 0x06004959 RID: 18777 RVA: 0x000E7F53 File Offset: 0x000E6353
		public static void AddLevel55(FlatBufferBuilder builder, StringOffset Level55Offset)
		{
			builder.AddOffset(56, Level55Offset.Value, 0);
		}

		// Token: 0x0600495A RID: 18778 RVA: 0x000E7F65 File Offset: 0x000E6365
		public static void AddLevel56(FlatBufferBuilder builder, StringOffset Level56Offset)
		{
			builder.AddOffset(57, Level56Offset.Value, 0);
		}

		// Token: 0x0600495B RID: 18779 RVA: 0x000E7F77 File Offset: 0x000E6377
		public static void AddLevel57(FlatBufferBuilder builder, StringOffset Level57Offset)
		{
			builder.AddOffset(58, Level57Offset.Value, 0);
		}

		// Token: 0x0600495C RID: 18780 RVA: 0x000E7F89 File Offset: 0x000E6389
		public static void AddLevel58(FlatBufferBuilder builder, StringOffset Level58Offset)
		{
			builder.AddOffset(59, Level58Offset.Value, 0);
		}

		// Token: 0x0600495D RID: 18781 RVA: 0x000E7F9B File Offset: 0x000E639B
		public static void AddLevel59(FlatBufferBuilder builder, StringOffset Level59Offset)
		{
			builder.AddOffset(60, Level59Offset.Value, 0);
		}

		// Token: 0x0600495E RID: 18782 RVA: 0x000E7FAD File Offset: 0x000E63AD
		public static void AddLevel60(FlatBufferBuilder builder, StringOffset Level60Offset)
		{
			builder.AddOffset(61, Level60Offset.Value, 0);
		}

		// Token: 0x0600495F RID: 18783 RVA: 0x000E7FBF File Offset: 0x000E63BF
		public static void AddLevel61(FlatBufferBuilder builder, StringOffset Level61Offset)
		{
			builder.AddOffset(62, Level61Offset.Value, 0);
		}

		// Token: 0x06004960 RID: 18784 RVA: 0x000E7FD1 File Offset: 0x000E63D1
		public static void AddLevel62(FlatBufferBuilder builder, StringOffset Level62Offset)
		{
			builder.AddOffset(63, Level62Offset.Value, 0);
		}

		// Token: 0x06004961 RID: 18785 RVA: 0x000E7FE3 File Offset: 0x000E63E3
		public static void AddLevel63(FlatBufferBuilder builder, StringOffset Level63Offset)
		{
			builder.AddOffset(64, Level63Offset.Value, 0);
		}

		// Token: 0x06004962 RID: 18786 RVA: 0x000E7FF5 File Offset: 0x000E63F5
		public static void AddLevel64(FlatBufferBuilder builder, StringOffset Level64Offset)
		{
			builder.AddOffset(65, Level64Offset.Value, 0);
		}

		// Token: 0x06004963 RID: 18787 RVA: 0x000E8007 File Offset: 0x000E6407
		public static void AddLevel65(FlatBufferBuilder builder, StringOffset Level65Offset)
		{
			builder.AddOffset(66, Level65Offset.Value, 0);
		}

		// Token: 0x06004964 RID: 18788 RVA: 0x000E801C File Offset: 0x000E641C
		public static Offset<RewardAdapterTable> EndRewardAdapterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RewardAdapterTable>(value);
		}

		// Token: 0x06004965 RID: 18789 RVA: 0x000E8036 File Offset: 0x000E6436
		public static void FinishRewardAdapterTableBuffer(FlatBufferBuilder builder, Offset<RewardAdapterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AB1 RID: 6833
		private Table __p = new Table();

		// Token: 0x02000586 RID: 1414
		public enum eCrypt
		{
			// Token: 0x04001AB3 RID: 6835
			code = -1699960114
		}
	}
}
