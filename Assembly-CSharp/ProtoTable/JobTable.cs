using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004CC RID: 1228
	public class JobTable : IFlatbufferObject
	{
		// Token: 0x17000F9D RID: 3997
		// (get) Token: 0x06003CA0 RID: 15520 RVA: 0x000CA074 File Offset: 0x000C8474
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003CA1 RID: 15521 RVA: 0x000CA081 File Offset: 0x000C8481
		public static JobTable GetRootAsJobTable(ByteBuffer _bb)
		{
			return JobTable.GetRootAsJobTable(_bb, new JobTable());
		}

		// Token: 0x06003CA2 RID: 15522 RVA: 0x000CA08E File Offset: 0x000C848E
		public static JobTable GetRootAsJobTable(ByteBuffer _bb, JobTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003CA3 RID: 15523 RVA: 0x000CA0AA File Offset: 0x000C84AA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003CA4 RID: 15524 RVA: 0x000CA0C4 File Offset: 0x000C84C4
		public JobTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000F9E RID: 3998
		// (get) Token: 0x06003CA5 RID: 15525 RVA: 0x000CA0D0 File Offset: 0x000C84D0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F9F RID: 3999
		// (get) Token: 0x06003CA6 RID: 15526 RVA: 0x000CA11C File Offset: 0x000C851C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CA7 RID: 15527 RVA: 0x000CA15E File Offset: 0x000C855E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003CA8 RID: 15528 RVA: 0x000CA16C File Offset: 0x000C856C
		public string AwakenJobNameArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FA0 RID: 4000
		// (get) Token: 0x06003CA9 RID: 15529 RVA: 0x000CA1B4 File Offset: 0x000C85B4
		public int AwakenJobNameLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FA1 RID: 4001
		// (get) Token: 0x06003CAA RID: 15530 RVA: 0x000CA1E6 File Offset: 0x000C85E6
		public FlatBufferArray<string> AwakenJobName
		{
			get
			{
				if (this.AwakenJobNameValue == null)
				{
					this.AwakenJobNameValue = new FlatBufferArray<string>(new Func<int, string>(this.AwakenJobNameArray), this.AwakenJobNameLength);
				}
				return this.AwakenJobNameValue;
			}
		}

		// Token: 0x17000FA2 RID: 4002
		// (get) Token: 0x06003CAB RID: 15531 RVA: 0x000CA218 File Offset: 0x000C8618
		public int JobAttribute
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA3 RID: 4003
		// (get) Token: 0x06003CAC RID: 15532 RVA: 0x000CA264 File Offset: 0x000C8664
		public int JobType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA4 RID: 4004
		// (get) Token: 0x06003CAD RID: 15533 RVA: 0x000CA2B0 File Offset: 0x000C86B0
		public int prejob
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA5 RID: 4005
		// (get) Token: 0x06003CAE RID: 15534 RVA: 0x000CA2FC File Offset: 0x000C86FC
		public JobTable.esex sex
		{
			get
			{
				int num = this.__p.__offset(16);
				return (JobTable.esex)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA6 RID: 4006
		// (get) Token: 0x06003CAF RID: 15535 RVA: 0x000CA340 File Offset: 0x000C8740
		public int OppositeSexJob
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA7 RID: 4007
		// (get) Token: 0x06003CB0 RID: 15536 RVA: 0x000CA38C File Offset: 0x000C878C
		public int Open
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA8 RID: 4008
		// (get) Token: 0x06003CB1 RID: 15537 RVA: 0x000CA3D8 File Offset: 0x000C87D8
		public int AuctionJob
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FA9 RID: 4009
		// (get) Token: 0x06003CB2 RID: 15538 RVA: 0x000CA424 File Offset: 0x000C8824
		public int Diffcult
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FAA RID: 4010
		// (get) Token: 0x06003CB3 RID: 15539 RVA: 0x000CA470 File Offset: 0x000C8870
		public int ComboFactor
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FAB RID: 4011
		// (get) Token: 0x06003CB4 RID: 15540 RVA: 0x000CA4BC File Offset: 0x000C88BC
		public int Mode
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FAC RID: 4012
		// (get) Token: 0x06003CB5 RID: 15541 RVA: 0x000CA508 File Offset: 0x000C8908
		public string RecProperty
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CB6 RID: 15542 RVA: 0x000CA54B File Offset: 0x000C894B
		public ArraySegment<byte>? GetRecPropertyBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000FAD RID: 4013
		// (get) Token: 0x06003CB7 RID: 15543 RVA: 0x000CA55C File Offset: 0x000C895C
		public string RecDefence
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CB8 RID: 15544 RVA: 0x000CA59F File Offset: 0x000C899F
		public ArraySegment<byte>? GetRecDefenceBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000FAE RID: 4014
		// (get) Token: 0x06003CB9 RID: 15545 RVA: 0x000CA5B0 File Offset: 0x000C89B0
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FAF RID: 4015
		// (get) Token: 0x06003CBA RID: 15546 RVA: 0x000CA5FC File Offset: 0x000C89FC
		public string IdleAniName
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CBB RID: 15547 RVA: 0x000CA63F File Offset: 0x000C8A3F
		public ArraySegment<byte>? GetIdleAniNameBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000FB0 RID: 4016
		// (get) Token: 0x06003CBC RID: 15548 RVA: 0x000CA650 File Offset: 0x000C8A50
		public string WalkAniName
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CBD RID: 15549 RVA: 0x000CA693 File Offset: 0x000C8A93
		public ArraySegment<byte>? GetWalkAniNameBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000FB1 RID: 4017
		// (get) Token: 0x06003CBE RID: 15550 RVA: 0x000CA6A4 File Offset: 0x000C8AA4
		public string RunAniName
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CBF RID: 15551 RVA: 0x000CA6E7 File Offset: 0x000C8AE7
		public ArraySegment<byte>? GetRunAniNameBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17000FB2 RID: 4018
		// (get) Token: 0x06003CC0 RID: 15552 RVA: 0x000CA6F8 File Offset: 0x000C8AF8
		public string DeadAniName
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CC1 RID: 15553 RVA: 0x000CA73B File Offset: 0x000C8B3B
		public ArraySegment<byte>? GetDeadAniNameBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000FB3 RID: 4019
		// (get) Token: 0x06003CC2 RID: 15554 RVA: 0x000CA74C File Offset: 0x000C8B4C
		public int DefaultBoxRadius
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FB4 RID: 4020
		// (get) Token: 0x06003CC3 RID: 15555 RVA: 0x000CA798 File Offset: 0x000C8B98
		public string DefaultHitEffect
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CC4 RID: 15556 RVA: 0x000CA7DB File Offset: 0x000C8BDB
		public ArraySegment<byte>? GetDefaultHitEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000FB5 RID: 4021
		// (get) Token: 0x06003CC5 RID: 15557 RVA: 0x000CA7EC File Offset: 0x000C8BEC
		public int DefaultHitSFXID
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FB6 RID: 4022
		// (get) Token: 0x06003CC6 RID: 15558 RVA: 0x000CA838 File Offset: 0x000C8C38
		public int DefaultWeaponTag
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FB7 RID: 4023
		// (get) Token: 0x06003CC7 RID: 15559 RVA: 0x000CA884 File Offset: 0x000C8C84
		public int DefaultWeaponType
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FB8 RID: 4024
		// (get) Token: 0x06003CC8 RID: 15560 RVA: 0x000CA8D0 File Offset: 0x000C8CD0
		public string DefaultWeaponPath
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CC9 RID: 15561 RVA: 0x000CA913 File Offset: 0x000C8D13
		public ArraySegment<byte>? GetDefaultWeaponPathBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17000FB9 RID: 4025
		// (get) Token: 0x06003CCA RID: 15562 RVA: 0x000CA924 File Offset: 0x000C8D24
		public string DefaultWeaponLocator
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CCB RID: 15563 RVA: 0x000CA967 File Offset: 0x000C8D67
		public ArraySegment<byte>? GetDefaultWeaponLocatorBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17000FBA RID: 4026
		// (get) Token: 0x06003CCC RID: 15564 RVA: 0x000CA978 File Offset: 0x000C8D78
		public string InputConfigPath
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CCD RID: 15565 RVA: 0x000CA9BB File Offset: 0x000C8DBB
		public ArraySegment<byte>? GetInputConfigPathBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x06003CCE RID: 15566 RVA: 0x000CA9CC File Offset: 0x000C8DCC
		public int InitSkillsArray(int j)
		{
			int num = this.__p.__offset(60);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FBB RID: 4027
		// (get) Token: 0x06003CCF RID: 15567 RVA: 0x000CAA1C File Offset: 0x000C8E1C
		public int InitSkillsLength
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003CD0 RID: 15568 RVA: 0x000CAA4F File Offset: 0x000C8E4F
		public ArraySegment<byte>? GetInitSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x17000FBC RID: 4028
		// (get) Token: 0x06003CD1 RID: 15569 RVA: 0x000CAA5E File Offset: 0x000C8E5E
		public FlatBufferArray<int> InitSkills
		{
			get
			{
				if (this.InitSkillsValue == null)
				{
					this.InitSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.InitSkillsArray), this.InitSkillsLength);
				}
				return this.InitSkillsValue;
			}
		}

		// Token: 0x17000FBD RID: 4029
		// (get) Token: 0x06003CD2 RID: 15570 RVA: 0x000CAA90 File Offset: 0x000C8E90
		public int MaxSkillPanelIndex
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003CD3 RID: 15571 RVA: 0x000CAADC File Offset: 0x000C8EDC
		public int AwakenSkillsArray(int j)
		{
			int num = this.__p.__offset(64);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FBE RID: 4030
		// (get) Token: 0x06003CD4 RID: 15572 RVA: 0x000CAB2C File Offset: 0x000C8F2C
		public int AwakenSkillsLength
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003CD5 RID: 15573 RVA: 0x000CAB5F File Offset: 0x000C8F5F
		public ArraySegment<byte>? GetAwakenSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17000FBF RID: 4031
		// (get) Token: 0x06003CD6 RID: 15574 RVA: 0x000CAB6E File Offset: 0x000C8F6E
		public FlatBufferArray<int> AwakenSkills
		{
			get
			{
				if (this.AwakenSkillsValue == null)
				{
					this.AwakenSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.AwakenSkillsArray), this.AwakenSkillsLength);
				}
				return this.AwakenSkillsValue;
			}
		}

		// Token: 0x17000FC0 RID: 4032
		// (get) Token: 0x06003CD7 RID: 15575 RVA: 0x000CABA0 File Offset: 0x000C8FA0
		public int ProJobSkills
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003CD8 RID: 15576 RVA: 0x000CABEC File Offset: 0x000C8FEC
		public int PreJobDialogIDArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FC1 RID: 4033
		// (get) Token: 0x06003CD9 RID: 15577 RVA: 0x000CAC3C File Offset: 0x000C903C
		public int PreJobDialogIDLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003CDA RID: 15578 RVA: 0x000CAC6F File Offset: 0x000C906F
		public ArraySegment<byte>? GetPreJobDialogIDBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x17000FC2 RID: 4034
		// (get) Token: 0x06003CDB RID: 15579 RVA: 0x000CAC7E File Offset: 0x000C907E
		public FlatBufferArray<int> PreJobDialogID
		{
			get
			{
				if (this.PreJobDialogIDValue == null)
				{
					this.PreJobDialogIDValue = new FlatBufferArray<int>(new Func<int, int>(this.PreJobDialogIDArray), this.PreJobDialogIDLength);
				}
				return this.PreJobDialogIDValue;
			}
		}

		// Token: 0x17000FC3 RID: 4035
		// (get) Token: 0x06003CDC RID: 15580 RVA: 0x000CACB0 File Offset: 0x000C90B0
		public int FightID
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003CDD RID: 15581 RVA: 0x000CACFC File Offset: 0x000C90FC
		public int ToJobArray(int j)
		{
			int num = this.__p.__offset(72);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FC4 RID: 4036
		// (get) Token: 0x06003CDE RID: 15582 RVA: 0x000CAD4C File Offset: 0x000C914C
		public int ToJobLength
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003CDF RID: 15583 RVA: 0x000CAD7F File Offset: 0x000C917F
		public ArraySegment<byte>? GetToJobBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x17000FC5 RID: 4037
		// (get) Token: 0x06003CE0 RID: 15584 RVA: 0x000CAD8E File Offset: 0x000C918E
		public FlatBufferArray<int> ToJob
		{
			get
			{
				if (this.ToJobValue == null)
				{
					this.ToJobValue = new FlatBufferArray<int>(new Func<int, int>(this.ToJobArray), this.ToJobLength);
				}
				return this.ToJobValue;
			}
		}

		// Token: 0x17000FC6 RID: 4038
		// (get) Token: 0x06003CE1 RID: 15585 RVA: 0x000CADC0 File Offset: 0x000C91C0
		public int NormalAttackID
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FC7 RID: 4039
		// (get) Token: 0x06003CE2 RID: 15586 RVA: 0x000CAE0C File Offset: 0x000C920C
		public int ChijiNormalAttackID
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FC8 RID: 4040
		// (get) Token: 0x06003CE3 RID: 15587 RVA: 0x000CAE58 File Offset: 0x000C9258
		public int JumpAttackID
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FC9 RID: 4041
		// (get) Token: 0x06003CE4 RID: 15588 RVA: 0x000CAEA4 File Offset: 0x000C92A4
		public int RunAttackID
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FCA RID: 4042
		// (get) Token: 0x06003CE5 RID: 15589 RVA: 0x000CAEF0 File Offset: 0x000C92F0
		public int JumpAttackNum
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FCB RID: 4043
		// (get) Token: 0x06003CE6 RID: 15590 RVA: 0x000CAF3C File Offset: 0x000C933C
		public string AIConfig1
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CE7 RID: 15591 RVA: 0x000CAF7F File Offset: 0x000C937F
		public ArraySegment<byte>? GetAIConfig1Bytes()
		{
			return this.__p.__vector_as_arraysegment(84);
		}

		// Token: 0x17000FCC RID: 4044
		// (get) Token: 0x06003CE8 RID: 15592 RVA: 0x000CAF90 File Offset: 0x000C9390
		public string AIConfig2
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CE9 RID: 15593 RVA: 0x000CAFD3 File Offset: 0x000C93D3
		public ArraySegment<byte>? GetAIConfig2Bytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x17000FCD RID: 4045
		// (get) Token: 0x06003CEA RID: 15594 RVA: 0x000CAFE4 File Offset: 0x000C93E4
		public string AIConfig3
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CEB RID: 15595 RVA: 0x000CB027 File Offset: 0x000C9427
		public ArraySegment<byte>? GetAIConfig3Bytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x17000FCE RID: 4046
		// (get) Token: 0x06003CEC RID: 15596 RVA: 0x000CB038 File Offset: 0x000C9438
		public int AIKeepDistance
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FCF RID: 4047
		// (get) Token: 0x06003CED RID: 15597 RVA: 0x000CB084 File Offset: 0x000C9484
		public int CanCreateRole
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FD0 RID: 4048
		// (get) Token: 0x06003CEE RID: 15598 RVA: 0x000CB0D0 File Offset: 0x000C94D0
		public int ToJobGift
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FD1 RID: 4049
		// (get) Token: 0x06003CEF RID: 15599 RVA: 0x000CB11C File Offset: 0x000C951C
		public string JobCreateName
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CF0 RID: 15600 RVA: 0x000CB15F File Offset: 0x000C955F
		public ArraySegment<byte>? GetJobCreateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(96);
		}

		// Token: 0x17000FD2 RID: 4050
		// (get) Token: 0x06003CF1 RID: 15601 RVA: 0x000CB170 File Offset: 0x000C9570
		public string JobPortrayal
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CF2 RID: 15602 RVA: 0x000CB1B3 File Offset: 0x000C95B3
		public ArraySegment<byte>? GetJobPortrayalBytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x17000FD3 RID: 4051
		// (get) Token: 0x06003CF3 RID: 15603 RVA: 0x000CB1C4 File Offset: 0x000C95C4
		public string JobHalfBody
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CF4 RID: 15604 RVA: 0x000CB207 File Offset: 0x000C9607
		public ArraySegment<byte>? GetJobHalfBodyBytes()
		{
			return this.__p.__vector_as_arraysegment(100);
		}

		// Token: 0x17000FD4 RID: 4052
		// (get) Token: 0x06003CF5 RID: 15605 RVA: 0x000CB218 File Offset: 0x000C9618
		public string JobHead
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CF6 RID: 15606 RVA: 0x000CB25B File Offset: 0x000C965B
		public ArraySegment<byte>? GetJobHeadBytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x17000FD5 RID: 4053
		// (get) Token: 0x06003CF7 RID: 15607 RVA: 0x000CB26C File Offset: 0x000C966C
		public string JobBody
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CF8 RID: 15608 RVA: 0x000CB2AF File Offset: 0x000C96AF
		public ArraySegment<byte>? GetJobBodyBytes()
		{
			return this.__p.__vector_as_arraysegment(104);
		}

		// Token: 0x17000FD6 RID: 4054
		// (get) Token: 0x06003CF9 RID: 15609 RVA: 0x000CB2C0 File Offset: 0x000C96C0
		public string JobIcon
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003CFA RID: 15610 RVA: 0x000CB303 File Offset: 0x000C9703
		public ArraySegment<byte>? GetJobIconBytes()
		{
			return this.__p.__vector_as_arraysegment(106);
		}

		// Token: 0x06003CFB RID: 15611 RVA: 0x000CB314 File Offset: 0x000C9714
		public string SkillIconArray(int j)
		{
			int num = this.__p.__offset(108);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FD7 RID: 4055
		// (get) Token: 0x06003CFC RID: 15612 RVA: 0x000CB35C File Offset: 0x000C975C
		public int SkillIconLength
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FD8 RID: 4056
		// (get) Token: 0x06003CFD RID: 15613 RVA: 0x000CB38F File Offset: 0x000C978F
		public FlatBufferArray<string> SkillIcon
		{
			get
			{
				if (this.SkillIconValue == null)
				{
					this.SkillIconValue = new FlatBufferArray<string>(new Func<int, string>(this.SkillIconArray), this.SkillIconLength);
				}
				return this.SkillIconValue;
			}
		}

		// Token: 0x06003CFE RID: 15614 RVA: 0x000CB3C0 File Offset: 0x000C97C0
		public string JobDesArray(int j)
		{
			int num = this.__p.__offset(110);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FD9 RID: 4057
		// (get) Token: 0x06003CFF RID: 15615 RVA: 0x000CB408 File Offset: 0x000C9808
		public int JobDesLength
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FDA RID: 4058
		// (get) Token: 0x06003D00 RID: 15616 RVA: 0x000CB43B File Offset: 0x000C983B
		public FlatBufferArray<string> JobDes
		{
			get
			{
				if (this.JobDesValue == null)
				{
					this.JobDesValue = new FlatBufferArray<string>(new Func<int, string>(this.JobDesArray), this.JobDesLength);
				}
				return this.JobDesValue;
			}
		}

		// Token: 0x17000FDB RID: 4059
		// (get) Token: 0x06003D01 RID: 15617 RVA: 0x000CB46C File Offset: 0x000C986C
		public string JobSimpleDes
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D02 RID: 15618 RVA: 0x000CB4AF File Offset: 0x000C98AF
		public ArraySegment<byte>? GetJobSimpleDesBytes()
		{
			return this.__p.__vector_as_arraysegment(112);
		}

		// Token: 0x17000FDC RID: 4060
		// (get) Token: 0x06003D03 RID: 15619 RVA: 0x000CB4C0 File Offset: 0x000C98C0
		public string AwakeJobIcon
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D04 RID: 15620 RVA: 0x000CB503 File Offset: 0x000C9903
		public ArraySegment<byte>? GetAwakeJobIconBytes()
		{
			return this.__p.__vector_as_arraysegment(114);
		}

		// Token: 0x17000FDD RID: 4061
		// (get) Token: 0x06003D05 RID: 15621 RVA: 0x000CB514 File Offset: 0x000C9914
		public string AwakeJobName
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D06 RID: 15622 RVA: 0x000CB557 File Offset: 0x000C9957
		public ArraySegment<byte>? GetAwakeJobNameBytes()
		{
			return this.__p.__vector_as_arraysegment(116);
		}

		// Token: 0x17000FDE RID: 4062
		// (get) Token: 0x06003D07 RID: 15623 RVA: 0x000CB568 File Offset: 0x000C9968
		public string AwakeSkillName
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D08 RID: 15624 RVA: 0x000CB5AB File Offset: 0x000C99AB
		public ArraySegment<byte>? GetAwakeSkillNameBytes()
		{
			return this.__p.__vector_as_arraysegment(118);
		}

		// Token: 0x06003D09 RID: 15625 RVA: 0x000CB5BC File Offset: 0x000C99BC
		public string JobShowPathArray(int j)
		{
			int num = this.__p.__offset(120);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FDF RID: 4063
		// (get) Token: 0x06003D0A RID: 15626 RVA: 0x000CB604 File Offset: 0x000C9A04
		public int JobShowPathLength
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FE0 RID: 4064
		// (get) Token: 0x06003D0B RID: 15627 RVA: 0x000CB637 File Offset: 0x000C9A37
		public FlatBufferArray<string> JobShowPath
		{
			get
			{
				if (this.JobShowPathValue == null)
				{
					this.JobShowPathValue = new FlatBufferArray<string>(new Func<int, string>(this.JobShowPathArray), this.JobShowPathLength);
				}
				return this.JobShowPathValue;
			}
		}

		// Token: 0x17000FE1 RID: 4065
		// (get) Token: 0x06003D0C RID: 15628 RVA: 0x000CB668 File Offset: 0x000C9A68
		public string FirstPayWeapon
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D0D RID: 15629 RVA: 0x000CB6AB File Offset: 0x000C9AAB
		public ArraySegment<byte>? GetFirstPayWeaponBytes()
		{
			return this.__p.__vector_as_arraysegment(122);
		}

		// Token: 0x06003D0E RID: 15630 RVA: 0x000CB6BC File Offset: 0x000C9ABC
		public string PayItemsArray(int j)
		{
			int num = this.__p.__offset(124);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FE2 RID: 4066
		// (get) Token: 0x06003D0F RID: 15631 RVA: 0x000CB704 File Offset: 0x000C9B04
		public int PayItemsLength
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FE3 RID: 4067
		// (get) Token: 0x06003D10 RID: 15632 RVA: 0x000CB737 File Offset: 0x000C9B37
		public FlatBufferArray<string> PayItems
		{
			get
			{
				if (this.PayItemsValue == null)
				{
					this.PayItemsValue = new FlatBufferArray<string>(new Func<int, string>(this.PayItemsArray), this.PayItemsLength);
				}
				return this.PayItemsValue;
			}
		}

		// Token: 0x06003D11 RID: 15633 RVA: 0x000CB768 File Offset: 0x000C9B68
		public string AbilityChartArray(int j)
		{
			int num = this.__p.__offset(126);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000FE4 RID: 4068
		// (get) Token: 0x06003D12 RID: 15634 RVA: 0x000CB7B0 File Offset: 0x000C9BB0
		public int AbilityChartLength
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000FE5 RID: 4069
		// (get) Token: 0x06003D13 RID: 15635 RVA: 0x000CB7E3 File Offset: 0x000C9BE3
		public FlatBufferArray<string> AbilityChart
		{
			get
			{
				if (this.AbilityChartValue == null)
				{
					this.AbilityChartValue = new FlatBufferArray<string>(new Func<int, string>(this.AbilityChartArray), this.AbilityChartLength);
				}
				return this.AbilityChartValue;
			}
		}

		// Token: 0x17000FE6 RID: 4070
		// (get) Token: 0x06003D14 RID: 15636 RVA: 0x000CB814 File Offset: 0x000C9C14
		public string Video
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D15 RID: 15637 RVA: 0x000CB85A File Offset: 0x000C9C5A
		public ArraySegment<byte>? GetVideoBytes()
		{
			return this.__p.__vector_as_arraysegment(128);
		}

		// Token: 0x17000FE7 RID: 4071
		// (get) Token: 0x06003D16 RID: 15638 RVA: 0x000CB86C File Offset: 0x000C9C6C
		public string JobImage
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D17 RID: 15639 RVA: 0x000CB8B2 File Offset: 0x000C9CB2
		public ArraySegment<byte>? GetJobImageBytes()
		{
			return this.__p.__vector_as_arraysegment(130);
		}

		// Token: 0x17000FE8 RID: 4072
		// (get) Token: 0x06003D18 RID: 15640 RVA: 0x000CB8C4 File Offset: 0x000C9CC4
		public int OffSetXFriendInfo
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FE9 RID: 4073
		// (get) Token: 0x06003D19 RID: 15641 RVA: 0x000CB914 File Offset: 0x000C9D14
		public int SuitArmorType
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FEA RID: 4074
		// (get) Token: 0x06003D1A RID: 15642 RVA: 0x000CB964 File Offset: 0x000C9D64
		public string JobFashionImage
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D1B RID: 15643 RVA: 0x000CB9AA File Offset: 0x000C9DAA
		public ArraySegment<byte>? GetJobFashionImageBytes()
		{
			return this.__p.__vector_as_arraysegment(136);
		}

		// Token: 0x17000FEB RID: 4075
		// (get) Token: 0x06003D1C RID: 15644 RVA: 0x000CB9BC File Offset: 0x000C9DBC
		public string GoodsRecommendBG
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D1D RID: 15645 RVA: 0x000CBA02 File Offset: 0x000C9E02
		public ArraySegment<byte>? GetGoodsRecommendBGBytes()
		{
			return this.__p.__vector_as_arraysegment(138);
		}

		// Token: 0x17000FEC RID: 4076
		// (get) Token: 0x06003D1E RID: 15646 RVA: 0x000CBA14 File Offset: 0x000C9E14
		public int TownStatueFace
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FED RID: 4077
		// (get) Token: 0x06003D1F RID: 15647 RVA: 0x000CBA64 File Offset: 0x000C9E64
		public string Job_xuanjue_zhiye
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D20 RID: 15648 RVA: 0x000CBAAA File Offset: 0x000C9EAA
		public ArraySegment<byte>? GetJobXuanjueZhiyeBytes()
		{
			return this.__p.__vector_as_arraysegment(142);
		}

		// Token: 0x06003D21 RID: 15649 RVA: 0x000CBABC File Offset: 0x000C9EBC
		public int changeFinishShowSkillsArray(int j)
		{
			int num = this.__p.__offset(144);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FEE RID: 4078
		// (get) Token: 0x06003D22 RID: 15650 RVA: 0x000CBB0C File Offset: 0x000C9F0C
		public int changeFinishShowSkillsLength
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003D23 RID: 15651 RVA: 0x000CBB42 File Offset: 0x000C9F42
		public ArraySegment<byte>? GetChangeFinishShowSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(144);
		}

		// Token: 0x17000FEF RID: 4079
		// (get) Token: 0x06003D24 RID: 15652 RVA: 0x000CBB54 File Offset: 0x000C9F54
		public FlatBufferArray<int> changeFinishShowSkills
		{
			get
			{
				if (this.changeFinishShowSkillsValue == null)
				{
					this.changeFinishShowSkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.changeFinishShowSkillsArray), this.changeFinishShowSkillsLength);
				}
				return this.changeFinishShowSkillsValue;
			}
		}

		// Token: 0x17000FF0 RID: 4080
		// (get) Token: 0x06003D25 RID: 15653 RVA: 0x000CBB84 File Offset: 0x000C9F84
		public string LoadingPrefab
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D26 RID: 15654 RVA: 0x000CBBCA File Offset: 0x000C9FCA
		public ArraySegment<byte>? GetLoadingPrefabBytes()
		{
			return this.__p.__vector_as_arraysegment(146);
		}

		// Token: 0x17000FF1 RID: 4081
		// (get) Token: 0x06003D27 RID: 15655 RVA: 0x000CBBDC File Offset: 0x000C9FDC
		public string PKMatchShowPrefab
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D28 RID: 15656 RVA: 0x000CBC22 File Offset: 0x000CA022
		public ArraySegment<byte>? GetPKMatchShowPrefabBytes()
		{
			return this.__p.__vector_as_arraysegment(148);
		}

		// Token: 0x17000FF2 RID: 4082
		// (get) Token: 0x06003D29 RID: 15657 RVA: 0x000CBC34 File Offset: 0x000CA034
		public string PKResultPrefab
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D2A RID: 15658 RVA: 0x000CBC7A File Offset: 0x000CA07A
		public ArraySegment<byte>? GetPKResultPrefabBytes()
		{
			return this.__p.__vector_as_arraysegment(150);
		}

		// Token: 0x17000FF3 RID: 4083
		// (get) Token: 0x06003D2B RID: 15659 RVA: 0x000CBC8C File Offset: 0x000CA08C
		public string PKMatchResultHeadIconPath
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D2C RID: 15660 RVA: 0x000CBCD2 File Offset: 0x000CA0D2
		public ArraySegment<byte>? GetPKMatchResultHeadIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(152);
		}

		// Token: 0x17000FF4 RID: 4084
		// (get) Token: 0x06003D2D RID: 15661 RVA: 0x000CBCE4 File Offset: 0x000CA0E4
		public string ChangJobTaskPrompt
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D2E RID: 15662 RVA: 0x000CBD2A File Offset: 0x000CA12A
		public ArraySegment<byte>? GetChangJobTaskPromptBytes()
		{
			return this.__p.__vector_as_arraysegment(154);
		}

		// Token: 0x17000FF5 RID: 4085
		// (get) Token: 0x06003D2F RID: 15663 RVA: 0x000CBD3C File Offset: 0x000CA13C
		public int AppointmentRoleID
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FF6 RID: 4086
		// (get) Token: 0x06003D30 RID: 15664 RVA: 0x000CBD8C File Offset: 0x000CA18C
		public int JobSort
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FF7 RID: 4087
		// (get) Token: 0x06003D31 RID: 15665 RVA: 0x000CBDDC File Offset: 0x000CA1DC
		public int JobPortrayalPosX
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FF8 RID: 4088
		// (get) Token: 0x06003D32 RID: 15666 RVA: 0x000CBE2C File Offset: 0x000CA22C
		public int JobPortrayalPosY
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003D33 RID: 15667 RVA: 0x000CBE7C File Offset: 0x000CA27C
		public int FirstPayModelTransformArray(int j)
		{
			int num = this.__p.__offset(164);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FF9 RID: 4089
		// (get) Token: 0x06003D34 RID: 15668 RVA: 0x000CBECC File Offset: 0x000CA2CC
		public int FirstPayModelTransformLength
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003D35 RID: 15669 RVA: 0x000CBF02 File Offset: 0x000CA302
		public ArraySegment<byte>? GetFirstPayModelTransformBytes()
		{
			return this.__p.__vector_as_arraysegment(164);
		}

		// Token: 0x17000FFA RID: 4090
		// (get) Token: 0x06003D36 RID: 15670 RVA: 0x000CBF14 File Offset: 0x000CA314
		public FlatBufferArray<int> FirstPayModelTransform
		{
			get
			{
				if (this.FirstPayModelTransformValue == null)
				{
					this.FirstPayModelTransformValue = new FlatBufferArray<int>(new Func<int, int>(this.FirstPayModelTransformArray), this.FirstPayModelTransformLength);
				}
				return this.FirstPayModelTransformValue;
			}
		}

		// Token: 0x17000FFB RID: 4091
		// (get) Token: 0x06003D37 RID: 15671 RVA: 0x000CBF44 File Offset: 0x000CA344
		public int FashionMergeFastBuyID
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000FFC RID: 4092
		// (get) Token: 0x06003D38 RID: 15672 RVA: 0x000CBF94 File Offset: 0x000CA394
		public string ChangJobPromptButtonPos
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D39 RID: 15673 RVA: 0x000CBFDA File Offset: 0x000CA3DA
		public ArraySegment<byte>? GetChangJobPromptButtonPosBytes()
		{
			return this.__p.__vector_as_arraysegment(168);
		}

		// Token: 0x17000FFD RID: 4093
		// (get) Token: 0x06003D3A RID: 15674 RVA: 0x000CBFEC File Offset: 0x000CA3EC
		public string RecommendedAttribute
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D3B RID: 15675 RVA: 0x000CC032 File Offset: 0x000CA432
		public ArraySegment<byte>? GetRecommendedAttributeBytes()
		{
			return this.__p.__vector_as_arraysegment(170);
		}

		// Token: 0x06003D3C RID: 15676 RVA: 0x000CC044 File Offset: 0x000CA444
		public int RecommendedAttributeIndexArray(int j)
		{
			int num = this.__p.__offset(172);
			return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000FFE RID: 4094
		// (get) Token: 0x06003D3D RID: 15677 RVA: 0x000CC094 File Offset: 0x000CA494
		public int RecommendedAttributeIndexLength
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003D3E RID: 15678 RVA: 0x000CC0CA File Offset: 0x000CA4CA
		public ArraySegment<byte>? GetRecommendedAttributeIndexBytes()
		{
			return this.__p.__vector_as_arraysegment(172);
		}

		// Token: 0x17000FFF RID: 4095
		// (get) Token: 0x06003D3F RID: 15679 RVA: 0x000CC0DC File Offset: 0x000CA4DC
		public FlatBufferArray<int> RecommendedAttributeIndex
		{
			get
			{
				if (this.RecommendedAttributeIndexValue == null)
				{
					this.RecommendedAttributeIndexValue = new FlatBufferArray<int>(new Func<int, int>(this.RecommendedAttributeIndexArray), this.RecommendedAttributeIndexLength);
				}
				return this.RecommendedAttributeIndexValue;
			}
		}

		// Token: 0x17001000 RID: 4096
		// (get) Token: 0x06003D40 RID: 15680 RVA: 0x000CC10C File Offset: 0x000CA50C
		public int AttachMonsterResID
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001001 RID: 4097
		// (get) Token: 0x06003D41 RID: 15681 RVA: 0x000CC15C File Offset: 0x000CA55C
		public string CharacterCollectionPhoto
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D42 RID: 15682 RVA: 0x000CC1A2 File Offset: 0x000CA5A2
		public ArraySegment<byte>? GetCharacterCollectionPhotoBytes()
		{
			return this.__p.__vector_as_arraysegment(176);
		}

		// Token: 0x17001002 RID: 4098
		// (get) Token: 0x06003D43 RID: 15683 RVA: 0x000CC1B4 File Offset: 0x000CA5B4
		public string CharacterCollectionArtLetting
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D44 RID: 15684 RVA: 0x000CC1FA File Offset: 0x000CA5FA
		public ArraySegment<byte>? GetCharacterCollectionArtLettingBytes()
		{
			return this.__p.__vector_as_arraysegment(178);
		}

		// Token: 0x17001003 RID: 4099
		// (get) Token: 0x06003D45 RID: 15685 RVA: 0x000CC20C File Offset: 0x000CA60C
		public string AppointmentJobImage
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003D46 RID: 15686 RVA: 0x000CC252 File Offset: 0x000CA652
		public ArraySegment<byte>? GetAppointmentJobImageBytes()
		{
			return this.__p.__vector_as_arraysegment(180);
		}

		// Token: 0x17001004 RID: 4100
		// (get) Token: 0x06003D47 RID: 15687 RVA: 0x000CC264 File Offset: 0x000CA664
		public int BaseJobSort
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001005 RID: 4101
		// (get) Token: 0x06003D48 RID: 15688 RVA: 0x000CC2B4 File Offset: 0x000CA6B4
		public int EqualPvPSP
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001006 RID: 4102
		// (get) Token: 0x06003D49 RID: 15689 RVA: 0x000CC304 File Offset: 0x000CA704
		public int Height
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001007 RID: 4103
		// (get) Token: 0x06003D4A RID: 15690 RVA: 0x000CC354 File Offset: 0x000CA754
		public int ChiJiOccu
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? 0 : (487660145 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003D4B RID: 15691 RVA: 0x000CC3A4 File Offset: 0x000CA7A4
		public static Offset<JobTable> CreateJobTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset AwakenJobNameOffset = default(VectorOffset), int JobAttribute = 0, int JobType = 0, int prejob = 0, JobTable.esex sex = JobTable.esex.Male, int OppositeSexJob = 0, int Open = 0, int AuctionJob = 0, int Diffcult = 0, int ComboFactor = 0, int Mode = 0, StringOffset RecPropertyOffset = default(StringOffset), StringOffset RecDefenceOffset = default(StringOffset), int Weight = 0, StringOffset IdleAniNameOffset = default(StringOffset), StringOffset WalkAniNameOffset = default(StringOffset), StringOffset RunAniNameOffset = default(StringOffset), StringOffset DeadAniNameOffset = default(StringOffset), int DefaultBoxRadius = 0, StringOffset DefaultHitEffectOffset = default(StringOffset), int DefaultHitSFXID = 0, int DefaultWeaponTag = 0, int DefaultWeaponType = 0, StringOffset DefaultWeaponPathOffset = default(StringOffset), StringOffset DefaultWeaponLocatorOffset = default(StringOffset), StringOffset InputConfigPathOffset = default(StringOffset), VectorOffset InitSkillsOffset = default(VectorOffset), int MaxSkillPanelIndex = 0, VectorOffset AwakenSkillsOffset = default(VectorOffset), int ProJobSkills = 0, VectorOffset PreJobDialogIDOffset = default(VectorOffset), int FightID = 0, VectorOffset ToJobOffset = default(VectorOffset), int NormalAttackID = 0, int ChijiNormalAttackID = 0, int JumpAttackID = 0, int RunAttackID = 0, int JumpAttackNum = 0, StringOffset AIConfig1Offset = default(StringOffset), StringOffset AIConfig2Offset = default(StringOffset), StringOffset AIConfig3Offset = default(StringOffset), int AIKeepDistance = 0, int CanCreateRole = 0, int ToJobGift = 0, StringOffset JobCreateNameOffset = default(StringOffset), StringOffset JobPortrayalOffset = default(StringOffset), StringOffset JobHalfBodyOffset = default(StringOffset), StringOffset JobHeadOffset = default(StringOffset), StringOffset JobBodyOffset = default(StringOffset), StringOffset JobIconOffset = default(StringOffset), VectorOffset SkillIconOffset = default(VectorOffset), VectorOffset JobDesOffset = default(VectorOffset), StringOffset JobSimpleDesOffset = default(StringOffset), StringOffset AwakeJobIconOffset = default(StringOffset), StringOffset AwakeJobNameOffset = default(StringOffset), StringOffset AwakeSkillNameOffset = default(StringOffset), VectorOffset JobShowPathOffset = default(VectorOffset), StringOffset FirstPayWeaponOffset = default(StringOffset), VectorOffset PayItemsOffset = default(VectorOffset), VectorOffset AbilityChartOffset = default(VectorOffset), StringOffset VideoOffset = default(StringOffset), StringOffset JobImageOffset = default(StringOffset), int OffSetXFriendInfo = 0, int SuitArmorType = 0, StringOffset JobFashionImageOffset = default(StringOffset), StringOffset GoodsRecommendBGOffset = default(StringOffset), int TownStatueFace = 0, StringOffset Job_xuanjue_zhiyeOffset = default(StringOffset), VectorOffset changeFinishShowSkillsOffset = default(VectorOffset), StringOffset LoadingPrefabOffset = default(StringOffset), StringOffset PKMatchShowPrefabOffset = default(StringOffset), StringOffset PKResultPrefabOffset = default(StringOffset), StringOffset PKMatchResultHeadIconPathOffset = default(StringOffset), StringOffset ChangJobTaskPromptOffset = default(StringOffset), int AppointmentRoleID = 0, int JobSort = 0, int JobPortrayalPosX = 0, int JobPortrayalPosY = 0, VectorOffset FirstPayModelTransformOffset = default(VectorOffset), int FashionMergeFastBuyID = 0, StringOffset ChangJobPromptButtonPosOffset = default(StringOffset), StringOffset RecommendedAttributeOffset = default(StringOffset), VectorOffset RecommendedAttributeIndexOffset = default(VectorOffset), int AttachMonsterResID = 0, StringOffset CharacterCollectionPhotoOffset = default(StringOffset), StringOffset CharacterCollectionArtLettingOffset = default(StringOffset), StringOffset AppointmentJobImageOffset = default(StringOffset), int BaseJobSort = 0, int EqualPvPSP = 0, int Height = 0, int ChiJiOccu = 0)
		{
			builder.StartObject(93);
			JobTable.AddChiJiOccu(builder, ChiJiOccu);
			JobTable.AddHeight(builder, Height);
			JobTable.AddEqualPvPSP(builder, EqualPvPSP);
			JobTable.AddBaseJobSort(builder, BaseJobSort);
			JobTable.AddAppointmentJobImage(builder, AppointmentJobImageOffset);
			JobTable.AddCharacterCollectionArtLetting(builder, CharacterCollectionArtLettingOffset);
			JobTable.AddCharacterCollectionPhoto(builder, CharacterCollectionPhotoOffset);
			JobTable.AddAttachMonsterResID(builder, AttachMonsterResID);
			JobTable.AddRecommendedAttributeIndex(builder, RecommendedAttributeIndexOffset);
			JobTable.AddRecommendedAttribute(builder, RecommendedAttributeOffset);
			JobTable.AddChangJobPromptButtonPos(builder, ChangJobPromptButtonPosOffset);
			JobTable.AddFashionMergeFastBuyID(builder, FashionMergeFastBuyID);
			JobTable.AddFirstPayModelTransform(builder, FirstPayModelTransformOffset);
			JobTable.AddJobPortrayalPosY(builder, JobPortrayalPosY);
			JobTable.AddJobPortrayalPosX(builder, JobPortrayalPosX);
			JobTable.AddJobSort(builder, JobSort);
			JobTable.AddAppointmentRoleID(builder, AppointmentRoleID);
			JobTable.AddChangJobTaskPrompt(builder, ChangJobTaskPromptOffset);
			JobTable.AddPKMatchResultHeadIconPath(builder, PKMatchResultHeadIconPathOffset);
			JobTable.AddPKResultPrefab(builder, PKResultPrefabOffset);
			JobTable.AddPKMatchShowPrefab(builder, PKMatchShowPrefabOffset);
			JobTable.AddLoadingPrefab(builder, LoadingPrefabOffset);
			JobTable.AddChangeFinishShowSkills(builder, changeFinishShowSkillsOffset);
			JobTable.AddJobXuanjueZhiye(builder, Job_xuanjue_zhiyeOffset);
			JobTable.AddTownStatueFace(builder, TownStatueFace);
			JobTable.AddGoodsRecommendBG(builder, GoodsRecommendBGOffset);
			JobTable.AddJobFashionImage(builder, JobFashionImageOffset);
			JobTable.AddSuitArmorType(builder, SuitArmorType);
			JobTable.AddOffSetXFriendInfo(builder, OffSetXFriendInfo);
			JobTable.AddJobImage(builder, JobImageOffset);
			JobTable.AddVideo(builder, VideoOffset);
			JobTable.AddAbilityChart(builder, AbilityChartOffset);
			JobTable.AddPayItems(builder, PayItemsOffset);
			JobTable.AddFirstPayWeapon(builder, FirstPayWeaponOffset);
			JobTable.AddJobShowPath(builder, JobShowPathOffset);
			JobTable.AddAwakeSkillName(builder, AwakeSkillNameOffset);
			JobTable.AddAwakeJobName(builder, AwakeJobNameOffset);
			JobTable.AddAwakeJobIcon(builder, AwakeJobIconOffset);
			JobTable.AddJobSimpleDes(builder, JobSimpleDesOffset);
			JobTable.AddJobDes(builder, JobDesOffset);
			JobTable.AddSkillIcon(builder, SkillIconOffset);
			JobTable.AddJobIcon(builder, JobIconOffset);
			JobTable.AddJobBody(builder, JobBodyOffset);
			JobTable.AddJobHead(builder, JobHeadOffset);
			JobTable.AddJobHalfBody(builder, JobHalfBodyOffset);
			JobTable.AddJobPortrayal(builder, JobPortrayalOffset);
			JobTable.AddJobCreateName(builder, JobCreateNameOffset);
			JobTable.AddToJobGift(builder, ToJobGift);
			JobTable.AddCanCreateRole(builder, CanCreateRole);
			JobTable.AddAIKeepDistance(builder, AIKeepDistance);
			JobTable.AddAIConfig3(builder, AIConfig3Offset);
			JobTable.AddAIConfig2(builder, AIConfig2Offset);
			JobTable.AddAIConfig1(builder, AIConfig1Offset);
			JobTable.AddJumpAttackNum(builder, JumpAttackNum);
			JobTable.AddRunAttackID(builder, RunAttackID);
			JobTable.AddJumpAttackID(builder, JumpAttackID);
			JobTable.AddChijiNormalAttackID(builder, ChijiNormalAttackID);
			JobTable.AddNormalAttackID(builder, NormalAttackID);
			JobTable.AddToJob(builder, ToJobOffset);
			JobTable.AddFightID(builder, FightID);
			JobTable.AddPreJobDialogID(builder, PreJobDialogIDOffset);
			JobTable.AddProJobSkills(builder, ProJobSkills);
			JobTable.AddAwakenSkills(builder, AwakenSkillsOffset);
			JobTable.AddMaxSkillPanelIndex(builder, MaxSkillPanelIndex);
			JobTable.AddInitSkills(builder, InitSkillsOffset);
			JobTable.AddInputConfigPath(builder, InputConfigPathOffset);
			JobTable.AddDefaultWeaponLocator(builder, DefaultWeaponLocatorOffset);
			JobTable.AddDefaultWeaponPath(builder, DefaultWeaponPathOffset);
			JobTable.AddDefaultWeaponType(builder, DefaultWeaponType);
			JobTable.AddDefaultWeaponTag(builder, DefaultWeaponTag);
			JobTable.AddDefaultHitSFXID(builder, DefaultHitSFXID);
			JobTable.AddDefaultHitEffect(builder, DefaultHitEffectOffset);
			JobTable.AddDefaultBoxRadius(builder, DefaultBoxRadius);
			JobTable.AddDeadAniName(builder, DeadAniNameOffset);
			JobTable.AddRunAniName(builder, RunAniNameOffset);
			JobTable.AddWalkAniName(builder, WalkAniNameOffset);
			JobTable.AddIdleAniName(builder, IdleAniNameOffset);
			JobTable.AddWeight(builder, Weight);
			JobTable.AddRecDefence(builder, RecDefenceOffset);
			JobTable.AddRecProperty(builder, RecPropertyOffset);
			JobTable.AddMode(builder, Mode);
			JobTable.AddComboFactor(builder, ComboFactor);
			JobTable.AddDiffcult(builder, Diffcult);
			JobTable.AddAuctionJob(builder, AuctionJob);
			JobTable.AddOpen(builder, Open);
			JobTable.AddOppositeSexJob(builder, OppositeSexJob);
			JobTable.AddSex(builder, sex);
			JobTable.AddPrejob(builder, prejob);
			JobTable.AddJobType(builder, JobType);
			JobTable.AddJobAttribute(builder, JobAttribute);
			JobTable.AddAwakenJobName(builder, AwakenJobNameOffset);
			JobTable.AddName(builder, NameOffset);
			JobTable.AddID(builder, ID);
			return JobTable.EndJobTable(builder);
		}

		// Token: 0x06003D4C RID: 15692 RVA: 0x000CC6A4 File Offset: 0x000CAAA4
		public static void StartJobTable(FlatBufferBuilder builder)
		{
			builder.StartObject(93);
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x000CC6AE File Offset: 0x000CAAAE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003D4E RID: 15694 RVA: 0x000CC6B9 File Offset: 0x000CAAB9
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003D4F RID: 15695 RVA: 0x000CC6CA File Offset: 0x000CAACA
		public static void AddAwakenJobName(FlatBufferBuilder builder, VectorOffset AwakenJobNameOffset)
		{
			builder.AddOffset(2, AwakenJobNameOffset.Value, 0);
		}

		// Token: 0x06003D50 RID: 15696 RVA: 0x000CC6DC File Offset: 0x000CAADC
		public static VectorOffset CreateAwakenJobNameVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D51 RID: 15697 RVA: 0x000CC722 File Offset: 0x000CAB22
		public static void StartAwakenJobNameVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D52 RID: 15698 RVA: 0x000CC72D File Offset: 0x000CAB2D
		public static void AddJobAttribute(FlatBufferBuilder builder, int JobAttribute)
		{
			builder.AddInt(3, JobAttribute, 0);
		}

		// Token: 0x06003D53 RID: 15699 RVA: 0x000CC738 File Offset: 0x000CAB38
		public static void AddJobType(FlatBufferBuilder builder, int JobType)
		{
			builder.AddInt(4, JobType, 0);
		}

		// Token: 0x06003D54 RID: 15700 RVA: 0x000CC743 File Offset: 0x000CAB43
		public static void AddPrejob(FlatBufferBuilder builder, int prejob)
		{
			builder.AddInt(5, prejob, 0);
		}

		// Token: 0x06003D55 RID: 15701 RVA: 0x000CC74E File Offset: 0x000CAB4E
		public static void AddSex(FlatBufferBuilder builder, JobTable.esex sex)
		{
			builder.AddInt(6, (int)sex, 0);
		}

		// Token: 0x06003D56 RID: 15702 RVA: 0x000CC759 File Offset: 0x000CAB59
		public static void AddOppositeSexJob(FlatBufferBuilder builder, int OppositeSexJob)
		{
			builder.AddInt(7, OppositeSexJob, 0);
		}

		// Token: 0x06003D57 RID: 15703 RVA: 0x000CC764 File Offset: 0x000CAB64
		public static void AddOpen(FlatBufferBuilder builder, int Open)
		{
			builder.AddInt(8, Open, 0);
		}

		// Token: 0x06003D58 RID: 15704 RVA: 0x000CC76F File Offset: 0x000CAB6F
		public static void AddAuctionJob(FlatBufferBuilder builder, int AuctionJob)
		{
			builder.AddInt(9, AuctionJob, 0);
		}

		// Token: 0x06003D59 RID: 15705 RVA: 0x000CC77B File Offset: 0x000CAB7B
		public static void AddDiffcult(FlatBufferBuilder builder, int Diffcult)
		{
			builder.AddInt(10, Diffcult, 0);
		}

		// Token: 0x06003D5A RID: 15706 RVA: 0x000CC787 File Offset: 0x000CAB87
		public static void AddComboFactor(FlatBufferBuilder builder, int ComboFactor)
		{
			builder.AddInt(11, ComboFactor, 0);
		}

		// Token: 0x06003D5B RID: 15707 RVA: 0x000CC793 File Offset: 0x000CAB93
		public static void AddMode(FlatBufferBuilder builder, int Mode)
		{
			builder.AddInt(12, Mode, 0);
		}

		// Token: 0x06003D5C RID: 15708 RVA: 0x000CC79F File Offset: 0x000CAB9F
		public static void AddRecProperty(FlatBufferBuilder builder, StringOffset RecPropertyOffset)
		{
			builder.AddOffset(13, RecPropertyOffset.Value, 0);
		}

		// Token: 0x06003D5D RID: 15709 RVA: 0x000CC7B1 File Offset: 0x000CABB1
		public static void AddRecDefence(FlatBufferBuilder builder, StringOffset RecDefenceOffset)
		{
			builder.AddOffset(14, RecDefenceOffset.Value, 0);
		}

		// Token: 0x06003D5E RID: 15710 RVA: 0x000CC7C3 File Offset: 0x000CABC3
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(15, Weight, 0);
		}

		// Token: 0x06003D5F RID: 15711 RVA: 0x000CC7CF File Offset: 0x000CABCF
		public static void AddIdleAniName(FlatBufferBuilder builder, StringOffset IdleAniNameOffset)
		{
			builder.AddOffset(16, IdleAniNameOffset.Value, 0);
		}

		// Token: 0x06003D60 RID: 15712 RVA: 0x000CC7E1 File Offset: 0x000CABE1
		public static void AddWalkAniName(FlatBufferBuilder builder, StringOffset WalkAniNameOffset)
		{
			builder.AddOffset(17, WalkAniNameOffset.Value, 0);
		}

		// Token: 0x06003D61 RID: 15713 RVA: 0x000CC7F3 File Offset: 0x000CABF3
		public static void AddRunAniName(FlatBufferBuilder builder, StringOffset RunAniNameOffset)
		{
			builder.AddOffset(18, RunAniNameOffset.Value, 0);
		}

		// Token: 0x06003D62 RID: 15714 RVA: 0x000CC805 File Offset: 0x000CAC05
		public static void AddDeadAniName(FlatBufferBuilder builder, StringOffset DeadAniNameOffset)
		{
			builder.AddOffset(19, DeadAniNameOffset.Value, 0);
		}

		// Token: 0x06003D63 RID: 15715 RVA: 0x000CC817 File Offset: 0x000CAC17
		public static void AddDefaultBoxRadius(FlatBufferBuilder builder, int DefaultBoxRadius)
		{
			builder.AddInt(20, DefaultBoxRadius, 0);
		}

		// Token: 0x06003D64 RID: 15716 RVA: 0x000CC823 File Offset: 0x000CAC23
		public static void AddDefaultHitEffect(FlatBufferBuilder builder, StringOffset DefaultHitEffectOffset)
		{
			builder.AddOffset(21, DefaultHitEffectOffset.Value, 0);
		}

		// Token: 0x06003D65 RID: 15717 RVA: 0x000CC835 File Offset: 0x000CAC35
		public static void AddDefaultHitSFXID(FlatBufferBuilder builder, int DefaultHitSFXID)
		{
			builder.AddInt(22, DefaultHitSFXID, 0);
		}

		// Token: 0x06003D66 RID: 15718 RVA: 0x000CC841 File Offset: 0x000CAC41
		public static void AddDefaultWeaponTag(FlatBufferBuilder builder, int DefaultWeaponTag)
		{
			builder.AddInt(23, DefaultWeaponTag, 0);
		}

		// Token: 0x06003D67 RID: 15719 RVA: 0x000CC84D File Offset: 0x000CAC4D
		public static void AddDefaultWeaponType(FlatBufferBuilder builder, int DefaultWeaponType)
		{
			builder.AddInt(24, DefaultWeaponType, 0);
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x000CC859 File Offset: 0x000CAC59
		public static void AddDefaultWeaponPath(FlatBufferBuilder builder, StringOffset DefaultWeaponPathOffset)
		{
			builder.AddOffset(25, DefaultWeaponPathOffset.Value, 0);
		}

		// Token: 0x06003D69 RID: 15721 RVA: 0x000CC86B File Offset: 0x000CAC6B
		public static void AddDefaultWeaponLocator(FlatBufferBuilder builder, StringOffset DefaultWeaponLocatorOffset)
		{
			builder.AddOffset(26, DefaultWeaponLocatorOffset.Value, 0);
		}

		// Token: 0x06003D6A RID: 15722 RVA: 0x000CC87D File Offset: 0x000CAC7D
		public static void AddInputConfigPath(FlatBufferBuilder builder, StringOffset InputConfigPathOffset)
		{
			builder.AddOffset(27, InputConfigPathOffset.Value, 0);
		}

		// Token: 0x06003D6B RID: 15723 RVA: 0x000CC88F File Offset: 0x000CAC8F
		public static void AddInitSkills(FlatBufferBuilder builder, VectorOffset InitSkillsOffset)
		{
			builder.AddOffset(28, InitSkillsOffset.Value, 0);
		}

		// Token: 0x06003D6C RID: 15724 RVA: 0x000CC8A4 File Offset: 0x000CACA4
		public static VectorOffset CreateInitSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D6D RID: 15725 RVA: 0x000CC8E1 File Offset: 0x000CACE1
		public static void StartInitSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D6E RID: 15726 RVA: 0x000CC8EC File Offset: 0x000CACEC
		public static void AddMaxSkillPanelIndex(FlatBufferBuilder builder, int MaxSkillPanelIndex)
		{
			builder.AddInt(29, MaxSkillPanelIndex, 0);
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x000CC8F8 File Offset: 0x000CACF8
		public static void AddAwakenSkills(FlatBufferBuilder builder, VectorOffset AwakenSkillsOffset)
		{
			builder.AddOffset(30, AwakenSkillsOffset.Value, 0);
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x000CC90C File Offset: 0x000CAD0C
		public static VectorOffset CreateAwakenSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D71 RID: 15729 RVA: 0x000CC949 File Offset: 0x000CAD49
		public static void StartAwakenSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D72 RID: 15730 RVA: 0x000CC954 File Offset: 0x000CAD54
		public static void AddProJobSkills(FlatBufferBuilder builder, int ProJobSkills)
		{
			builder.AddInt(31, ProJobSkills, 0);
		}

		// Token: 0x06003D73 RID: 15731 RVA: 0x000CC960 File Offset: 0x000CAD60
		public static void AddPreJobDialogID(FlatBufferBuilder builder, VectorOffset PreJobDialogIDOffset)
		{
			builder.AddOffset(32, PreJobDialogIDOffset.Value, 0);
		}

		// Token: 0x06003D74 RID: 15732 RVA: 0x000CC974 File Offset: 0x000CAD74
		public static VectorOffset CreatePreJobDialogIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D75 RID: 15733 RVA: 0x000CC9B1 File Offset: 0x000CADB1
		public static void StartPreJobDialogIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D76 RID: 15734 RVA: 0x000CC9BC File Offset: 0x000CADBC
		public static void AddFightID(FlatBufferBuilder builder, int FightID)
		{
			builder.AddInt(33, FightID, 0);
		}

		// Token: 0x06003D77 RID: 15735 RVA: 0x000CC9C8 File Offset: 0x000CADC8
		public static void AddToJob(FlatBufferBuilder builder, VectorOffset ToJobOffset)
		{
			builder.AddOffset(34, ToJobOffset.Value, 0);
		}

		// Token: 0x06003D78 RID: 15736 RVA: 0x000CC9DC File Offset: 0x000CADDC
		public static VectorOffset CreateToJobVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D79 RID: 15737 RVA: 0x000CCA19 File Offset: 0x000CAE19
		public static void StartToJobVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D7A RID: 15738 RVA: 0x000CCA24 File Offset: 0x000CAE24
		public static void AddNormalAttackID(FlatBufferBuilder builder, int NormalAttackID)
		{
			builder.AddInt(35, NormalAttackID, 0);
		}

		// Token: 0x06003D7B RID: 15739 RVA: 0x000CCA30 File Offset: 0x000CAE30
		public static void AddChijiNormalAttackID(FlatBufferBuilder builder, int ChijiNormalAttackID)
		{
			builder.AddInt(36, ChijiNormalAttackID, 0);
		}

		// Token: 0x06003D7C RID: 15740 RVA: 0x000CCA3C File Offset: 0x000CAE3C
		public static void AddJumpAttackID(FlatBufferBuilder builder, int JumpAttackID)
		{
			builder.AddInt(37, JumpAttackID, 0);
		}

		// Token: 0x06003D7D RID: 15741 RVA: 0x000CCA48 File Offset: 0x000CAE48
		public static void AddRunAttackID(FlatBufferBuilder builder, int RunAttackID)
		{
			builder.AddInt(38, RunAttackID, 0);
		}

		// Token: 0x06003D7E RID: 15742 RVA: 0x000CCA54 File Offset: 0x000CAE54
		public static void AddJumpAttackNum(FlatBufferBuilder builder, int JumpAttackNum)
		{
			builder.AddInt(39, JumpAttackNum, 0);
		}

		// Token: 0x06003D7F RID: 15743 RVA: 0x000CCA60 File Offset: 0x000CAE60
		public static void AddAIConfig1(FlatBufferBuilder builder, StringOffset AIConfig1Offset)
		{
			builder.AddOffset(40, AIConfig1Offset.Value, 0);
		}

		// Token: 0x06003D80 RID: 15744 RVA: 0x000CCA72 File Offset: 0x000CAE72
		public static void AddAIConfig2(FlatBufferBuilder builder, StringOffset AIConfig2Offset)
		{
			builder.AddOffset(41, AIConfig2Offset.Value, 0);
		}

		// Token: 0x06003D81 RID: 15745 RVA: 0x000CCA84 File Offset: 0x000CAE84
		public static void AddAIConfig3(FlatBufferBuilder builder, StringOffset AIConfig3Offset)
		{
			builder.AddOffset(42, AIConfig3Offset.Value, 0);
		}

		// Token: 0x06003D82 RID: 15746 RVA: 0x000CCA96 File Offset: 0x000CAE96
		public static void AddAIKeepDistance(FlatBufferBuilder builder, int AIKeepDistance)
		{
			builder.AddInt(43, AIKeepDistance, 0);
		}

		// Token: 0x06003D83 RID: 15747 RVA: 0x000CCAA2 File Offset: 0x000CAEA2
		public static void AddCanCreateRole(FlatBufferBuilder builder, int CanCreateRole)
		{
			builder.AddInt(44, CanCreateRole, 0);
		}

		// Token: 0x06003D84 RID: 15748 RVA: 0x000CCAAE File Offset: 0x000CAEAE
		public static void AddToJobGift(FlatBufferBuilder builder, int ToJobGift)
		{
			builder.AddInt(45, ToJobGift, 0);
		}

		// Token: 0x06003D85 RID: 15749 RVA: 0x000CCABA File Offset: 0x000CAEBA
		public static void AddJobCreateName(FlatBufferBuilder builder, StringOffset JobCreateNameOffset)
		{
			builder.AddOffset(46, JobCreateNameOffset.Value, 0);
		}

		// Token: 0x06003D86 RID: 15750 RVA: 0x000CCACC File Offset: 0x000CAECC
		public static void AddJobPortrayal(FlatBufferBuilder builder, StringOffset JobPortrayalOffset)
		{
			builder.AddOffset(47, JobPortrayalOffset.Value, 0);
		}

		// Token: 0x06003D87 RID: 15751 RVA: 0x000CCADE File Offset: 0x000CAEDE
		public static void AddJobHalfBody(FlatBufferBuilder builder, StringOffset JobHalfBodyOffset)
		{
			builder.AddOffset(48, JobHalfBodyOffset.Value, 0);
		}

		// Token: 0x06003D88 RID: 15752 RVA: 0x000CCAF0 File Offset: 0x000CAEF0
		public static void AddJobHead(FlatBufferBuilder builder, StringOffset JobHeadOffset)
		{
			builder.AddOffset(49, JobHeadOffset.Value, 0);
		}

		// Token: 0x06003D89 RID: 15753 RVA: 0x000CCB02 File Offset: 0x000CAF02
		public static void AddJobBody(FlatBufferBuilder builder, StringOffset JobBodyOffset)
		{
			builder.AddOffset(50, JobBodyOffset.Value, 0);
		}

		// Token: 0x06003D8A RID: 15754 RVA: 0x000CCB14 File Offset: 0x000CAF14
		public static void AddJobIcon(FlatBufferBuilder builder, StringOffset JobIconOffset)
		{
			builder.AddOffset(51, JobIconOffset.Value, 0);
		}

		// Token: 0x06003D8B RID: 15755 RVA: 0x000CCB26 File Offset: 0x000CAF26
		public static void AddSkillIcon(FlatBufferBuilder builder, VectorOffset SkillIconOffset)
		{
			builder.AddOffset(52, SkillIconOffset.Value, 0);
		}

		// Token: 0x06003D8C RID: 15756 RVA: 0x000CCB38 File Offset: 0x000CAF38
		public static VectorOffset CreateSkillIconVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D8D RID: 15757 RVA: 0x000CCB7E File Offset: 0x000CAF7E
		public static void StartSkillIconVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D8E RID: 15758 RVA: 0x000CCB89 File Offset: 0x000CAF89
		public static void AddJobDes(FlatBufferBuilder builder, VectorOffset JobDesOffset)
		{
			builder.AddOffset(53, JobDesOffset.Value, 0);
		}

		// Token: 0x06003D8F RID: 15759 RVA: 0x000CCB9C File Offset: 0x000CAF9C
		public static VectorOffset CreateJobDesVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D90 RID: 15760 RVA: 0x000CCBE2 File Offset: 0x000CAFE2
		public static void StartJobDesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D91 RID: 15761 RVA: 0x000CCBED File Offset: 0x000CAFED
		public static void AddJobSimpleDes(FlatBufferBuilder builder, StringOffset JobSimpleDesOffset)
		{
			builder.AddOffset(54, JobSimpleDesOffset.Value, 0);
		}

		// Token: 0x06003D92 RID: 15762 RVA: 0x000CCBFF File Offset: 0x000CAFFF
		public static void AddAwakeJobIcon(FlatBufferBuilder builder, StringOffset AwakeJobIconOffset)
		{
			builder.AddOffset(55, AwakeJobIconOffset.Value, 0);
		}

		// Token: 0x06003D93 RID: 15763 RVA: 0x000CCC11 File Offset: 0x000CB011
		public static void AddAwakeJobName(FlatBufferBuilder builder, StringOffset AwakeJobNameOffset)
		{
			builder.AddOffset(56, AwakeJobNameOffset.Value, 0);
		}

		// Token: 0x06003D94 RID: 15764 RVA: 0x000CCC23 File Offset: 0x000CB023
		public static void AddAwakeSkillName(FlatBufferBuilder builder, StringOffset AwakeSkillNameOffset)
		{
			builder.AddOffset(57, AwakeSkillNameOffset.Value, 0);
		}

		// Token: 0x06003D95 RID: 15765 RVA: 0x000CCC35 File Offset: 0x000CB035
		public static void AddJobShowPath(FlatBufferBuilder builder, VectorOffset JobShowPathOffset)
		{
			builder.AddOffset(58, JobShowPathOffset.Value, 0);
		}

		// Token: 0x06003D96 RID: 15766 RVA: 0x000CCC48 File Offset: 0x000CB048
		public static VectorOffset CreateJobShowPathVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D97 RID: 15767 RVA: 0x000CCC8E File Offset: 0x000CB08E
		public static void StartJobShowPathVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D98 RID: 15768 RVA: 0x000CCC99 File Offset: 0x000CB099
		public static void AddFirstPayWeapon(FlatBufferBuilder builder, StringOffset FirstPayWeaponOffset)
		{
			builder.AddOffset(59, FirstPayWeaponOffset.Value, 0);
		}

		// Token: 0x06003D99 RID: 15769 RVA: 0x000CCCAB File Offset: 0x000CB0AB
		public static void AddPayItems(FlatBufferBuilder builder, VectorOffset PayItemsOffset)
		{
			builder.AddOffset(60, PayItemsOffset.Value, 0);
		}

		// Token: 0x06003D9A RID: 15770 RVA: 0x000CCCC0 File Offset: 0x000CB0C0
		public static VectorOffset CreatePayItemsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D9B RID: 15771 RVA: 0x000CCD06 File Offset: 0x000CB106
		public static void StartPayItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D9C RID: 15772 RVA: 0x000CCD11 File Offset: 0x000CB111
		public static void AddAbilityChart(FlatBufferBuilder builder, VectorOffset AbilityChartOffset)
		{
			builder.AddOffset(61, AbilityChartOffset.Value, 0);
		}

		// Token: 0x06003D9D RID: 15773 RVA: 0x000CCD24 File Offset: 0x000CB124
		public static VectorOffset CreateAbilityChartVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003D9E RID: 15774 RVA: 0x000CCD6A File Offset: 0x000CB16A
		public static void StartAbilityChartVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003D9F RID: 15775 RVA: 0x000CCD75 File Offset: 0x000CB175
		public static void AddVideo(FlatBufferBuilder builder, StringOffset VideoOffset)
		{
			builder.AddOffset(62, VideoOffset.Value, 0);
		}

		// Token: 0x06003DA0 RID: 15776 RVA: 0x000CCD87 File Offset: 0x000CB187
		public static void AddJobImage(FlatBufferBuilder builder, StringOffset JobImageOffset)
		{
			builder.AddOffset(63, JobImageOffset.Value, 0);
		}

		// Token: 0x06003DA1 RID: 15777 RVA: 0x000CCD99 File Offset: 0x000CB199
		public static void AddOffSetXFriendInfo(FlatBufferBuilder builder, int OffSetXFriendInfo)
		{
			builder.AddInt(64, OffSetXFriendInfo, 0);
		}

		// Token: 0x06003DA2 RID: 15778 RVA: 0x000CCDA5 File Offset: 0x000CB1A5
		public static void AddSuitArmorType(FlatBufferBuilder builder, int SuitArmorType)
		{
			builder.AddInt(65, SuitArmorType, 0);
		}

		// Token: 0x06003DA3 RID: 15779 RVA: 0x000CCDB1 File Offset: 0x000CB1B1
		public static void AddJobFashionImage(FlatBufferBuilder builder, StringOffset JobFashionImageOffset)
		{
			builder.AddOffset(66, JobFashionImageOffset.Value, 0);
		}

		// Token: 0x06003DA4 RID: 15780 RVA: 0x000CCDC3 File Offset: 0x000CB1C3
		public static void AddGoodsRecommendBG(FlatBufferBuilder builder, StringOffset GoodsRecommendBGOffset)
		{
			builder.AddOffset(67, GoodsRecommendBGOffset.Value, 0);
		}

		// Token: 0x06003DA5 RID: 15781 RVA: 0x000CCDD5 File Offset: 0x000CB1D5
		public static void AddTownStatueFace(FlatBufferBuilder builder, int TownStatueFace)
		{
			builder.AddInt(68, TownStatueFace, 0);
		}

		// Token: 0x06003DA6 RID: 15782 RVA: 0x000CCDE1 File Offset: 0x000CB1E1
		public static void AddJobXuanjueZhiye(FlatBufferBuilder builder, StringOffset JobXuanjueZhiyeOffset)
		{
			builder.AddOffset(69, JobXuanjueZhiyeOffset.Value, 0);
		}

		// Token: 0x06003DA7 RID: 15783 RVA: 0x000CCDF3 File Offset: 0x000CB1F3
		public static void AddChangeFinishShowSkills(FlatBufferBuilder builder, VectorOffset changeFinishShowSkillsOffset)
		{
			builder.AddOffset(70, changeFinishShowSkillsOffset.Value, 0);
		}

		// Token: 0x06003DA8 RID: 15784 RVA: 0x000CCE08 File Offset: 0x000CB208
		public static VectorOffset CreateChangeFinishShowSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DA9 RID: 15785 RVA: 0x000CCE45 File Offset: 0x000CB245
		public static void StartChangeFinishShowSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003DAA RID: 15786 RVA: 0x000CCE50 File Offset: 0x000CB250
		public static void AddLoadingPrefab(FlatBufferBuilder builder, StringOffset LoadingPrefabOffset)
		{
			builder.AddOffset(71, LoadingPrefabOffset.Value, 0);
		}

		// Token: 0x06003DAB RID: 15787 RVA: 0x000CCE62 File Offset: 0x000CB262
		public static void AddPKMatchShowPrefab(FlatBufferBuilder builder, StringOffset PKMatchShowPrefabOffset)
		{
			builder.AddOffset(72, PKMatchShowPrefabOffset.Value, 0);
		}

		// Token: 0x06003DAC RID: 15788 RVA: 0x000CCE74 File Offset: 0x000CB274
		public static void AddPKResultPrefab(FlatBufferBuilder builder, StringOffset PKResultPrefabOffset)
		{
			builder.AddOffset(73, PKResultPrefabOffset.Value, 0);
		}

		// Token: 0x06003DAD RID: 15789 RVA: 0x000CCE86 File Offset: 0x000CB286
		public static void AddPKMatchResultHeadIconPath(FlatBufferBuilder builder, StringOffset PKMatchResultHeadIconPathOffset)
		{
			builder.AddOffset(74, PKMatchResultHeadIconPathOffset.Value, 0);
		}

		// Token: 0x06003DAE RID: 15790 RVA: 0x000CCE98 File Offset: 0x000CB298
		public static void AddChangJobTaskPrompt(FlatBufferBuilder builder, StringOffset ChangJobTaskPromptOffset)
		{
			builder.AddOffset(75, ChangJobTaskPromptOffset.Value, 0);
		}

		// Token: 0x06003DAF RID: 15791 RVA: 0x000CCEAA File Offset: 0x000CB2AA
		public static void AddAppointmentRoleID(FlatBufferBuilder builder, int AppointmentRoleID)
		{
			builder.AddInt(76, AppointmentRoleID, 0);
		}

		// Token: 0x06003DB0 RID: 15792 RVA: 0x000CCEB6 File Offset: 0x000CB2B6
		public static void AddJobSort(FlatBufferBuilder builder, int JobSort)
		{
			builder.AddInt(77, JobSort, 0);
		}

		// Token: 0x06003DB1 RID: 15793 RVA: 0x000CCEC2 File Offset: 0x000CB2C2
		public static void AddJobPortrayalPosX(FlatBufferBuilder builder, int JobPortrayalPosX)
		{
			builder.AddInt(78, JobPortrayalPosX, 0);
		}

		// Token: 0x06003DB2 RID: 15794 RVA: 0x000CCECE File Offset: 0x000CB2CE
		public static void AddJobPortrayalPosY(FlatBufferBuilder builder, int JobPortrayalPosY)
		{
			builder.AddInt(79, JobPortrayalPosY, 0);
		}

		// Token: 0x06003DB3 RID: 15795 RVA: 0x000CCEDA File Offset: 0x000CB2DA
		public static void AddFirstPayModelTransform(FlatBufferBuilder builder, VectorOffset FirstPayModelTransformOffset)
		{
			builder.AddOffset(80, FirstPayModelTransformOffset.Value, 0);
		}

		// Token: 0x06003DB4 RID: 15796 RVA: 0x000CCEEC File Offset: 0x000CB2EC
		public static VectorOffset CreateFirstPayModelTransformVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DB5 RID: 15797 RVA: 0x000CCF29 File Offset: 0x000CB329
		public static void StartFirstPayModelTransformVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003DB6 RID: 15798 RVA: 0x000CCF34 File Offset: 0x000CB334
		public static void AddFashionMergeFastBuyID(FlatBufferBuilder builder, int FashionMergeFastBuyID)
		{
			builder.AddInt(81, FashionMergeFastBuyID, 0);
		}

		// Token: 0x06003DB7 RID: 15799 RVA: 0x000CCF40 File Offset: 0x000CB340
		public static void AddChangJobPromptButtonPos(FlatBufferBuilder builder, StringOffset ChangJobPromptButtonPosOffset)
		{
			builder.AddOffset(82, ChangJobPromptButtonPosOffset.Value, 0);
		}

		// Token: 0x06003DB8 RID: 15800 RVA: 0x000CCF52 File Offset: 0x000CB352
		public static void AddRecommendedAttribute(FlatBufferBuilder builder, StringOffset RecommendedAttributeOffset)
		{
			builder.AddOffset(83, RecommendedAttributeOffset.Value, 0);
		}

		// Token: 0x06003DB9 RID: 15801 RVA: 0x000CCF64 File Offset: 0x000CB364
		public static void AddRecommendedAttributeIndex(FlatBufferBuilder builder, VectorOffset RecommendedAttributeIndexOffset)
		{
			builder.AddOffset(84, RecommendedAttributeIndexOffset.Value, 0);
		}

		// Token: 0x06003DBA RID: 15802 RVA: 0x000CCF78 File Offset: 0x000CB378
		public static VectorOffset CreateRecommendedAttributeIndexVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DBB RID: 15803 RVA: 0x000CCFB5 File Offset: 0x000CB3B5
		public static void StartRecommendedAttributeIndexVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003DBC RID: 15804 RVA: 0x000CCFC0 File Offset: 0x000CB3C0
		public static void AddAttachMonsterResID(FlatBufferBuilder builder, int AttachMonsterResID)
		{
			builder.AddInt(85, AttachMonsterResID, 0);
		}

		// Token: 0x06003DBD RID: 15805 RVA: 0x000CCFCC File Offset: 0x000CB3CC
		public static void AddCharacterCollectionPhoto(FlatBufferBuilder builder, StringOffset CharacterCollectionPhotoOffset)
		{
			builder.AddOffset(86, CharacterCollectionPhotoOffset.Value, 0);
		}

		// Token: 0x06003DBE RID: 15806 RVA: 0x000CCFDE File Offset: 0x000CB3DE
		public static void AddCharacterCollectionArtLetting(FlatBufferBuilder builder, StringOffset CharacterCollectionArtLettingOffset)
		{
			builder.AddOffset(87, CharacterCollectionArtLettingOffset.Value, 0);
		}

		// Token: 0x06003DBF RID: 15807 RVA: 0x000CCFF0 File Offset: 0x000CB3F0
		public static void AddAppointmentJobImage(FlatBufferBuilder builder, StringOffset AppointmentJobImageOffset)
		{
			builder.AddOffset(88, AppointmentJobImageOffset.Value, 0);
		}

		// Token: 0x06003DC0 RID: 15808 RVA: 0x000CD002 File Offset: 0x000CB402
		public static void AddBaseJobSort(FlatBufferBuilder builder, int BaseJobSort)
		{
			builder.AddInt(89, BaseJobSort, 0);
		}

		// Token: 0x06003DC1 RID: 15809 RVA: 0x000CD00E File Offset: 0x000CB40E
		public static void AddEqualPvPSP(FlatBufferBuilder builder, int EqualPvPSP)
		{
			builder.AddInt(90, EqualPvPSP, 0);
		}

		// Token: 0x06003DC2 RID: 15810 RVA: 0x000CD01A File Offset: 0x000CB41A
		public static void AddHeight(FlatBufferBuilder builder, int Height)
		{
			builder.AddInt(91, Height, 0);
		}

		// Token: 0x06003DC3 RID: 15811 RVA: 0x000CD026 File Offset: 0x000CB426
		public static void AddChiJiOccu(FlatBufferBuilder builder, int ChiJiOccu)
		{
			builder.AddInt(92, ChiJiOccu, 0);
		}

		// Token: 0x06003DC4 RID: 15812 RVA: 0x000CD034 File Offset: 0x000CB434
		public static Offset<JobTable> EndJobTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<JobTable>(value);
		}

		// Token: 0x06003DC5 RID: 15813 RVA: 0x000CD04E File Offset: 0x000CB44E
		public static void FinishJobTableBuffer(FlatBufferBuilder builder, Offset<JobTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017C3 RID: 6083
		private Table __p = new Table();

		// Token: 0x040017C4 RID: 6084
		private FlatBufferArray<string> AwakenJobNameValue;

		// Token: 0x040017C5 RID: 6085
		private FlatBufferArray<int> InitSkillsValue;

		// Token: 0x040017C6 RID: 6086
		private FlatBufferArray<int> AwakenSkillsValue;

		// Token: 0x040017C7 RID: 6087
		private FlatBufferArray<int> PreJobDialogIDValue;

		// Token: 0x040017C8 RID: 6088
		private FlatBufferArray<int> ToJobValue;

		// Token: 0x040017C9 RID: 6089
		private FlatBufferArray<string> SkillIconValue;

		// Token: 0x040017CA RID: 6090
		private FlatBufferArray<string> JobDesValue;

		// Token: 0x040017CB RID: 6091
		private FlatBufferArray<string> JobShowPathValue;

		// Token: 0x040017CC RID: 6092
		private FlatBufferArray<string> PayItemsValue;

		// Token: 0x040017CD RID: 6093
		private FlatBufferArray<string> AbilityChartValue;

		// Token: 0x040017CE RID: 6094
		private FlatBufferArray<int> changeFinishShowSkillsValue;

		// Token: 0x040017CF RID: 6095
		private FlatBufferArray<int> FirstPayModelTransformValue;

		// Token: 0x040017D0 RID: 6096
		private FlatBufferArray<int> RecommendedAttributeIndexValue;

		// Token: 0x020004CD RID: 1229
		public enum esex
		{
			// Token: 0x040017D2 RID: 6098
			Male,
			// Token: 0x040017D3 RID: 6099
			Female
		}

		// Token: 0x020004CE RID: 1230
		public enum eCrypt
		{
			// Token: 0x040017D5 RID: 6101
			code = 487660145
		}
	}
}
