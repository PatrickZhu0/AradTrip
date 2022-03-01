using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200033C RID: 828
	public class ChijiBuffTable : IFlatbufferObject
	{
		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x0600215E RID: 8542 RVA: 0x00088838 File Offset: 0x00086C38
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600215F RID: 8543 RVA: 0x00088845 File Offset: 0x00086C45
		public static ChijiBuffTable GetRootAsChijiBuffTable(ByteBuffer _bb)
		{
			return ChijiBuffTable.GetRootAsChijiBuffTable(_bb, new ChijiBuffTable());
		}

		// Token: 0x06002160 RID: 8544 RVA: 0x00088852 File Offset: 0x00086C52
		public static ChijiBuffTable GetRootAsChijiBuffTable(ByteBuffer _bb, ChijiBuffTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002161 RID: 8545 RVA: 0x0008886E File Offset: 0x00086C6E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002162 RID: 8546 RVA: 0x00088888 File Offset: 0x00086C88
		public ChijiBuffTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x06002163 RID: 8547 RVA: 0x00088894 File Offset: 0x00086C94
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x06002164 RID: 8548 RVA: 0x000888E0 File Offset: 0x00086CE0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002165 RID: 8549 RVA: 0x00088922 File Offset: 0x00086D22
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06002166 RID: 8550 RVA: 0x00088930 File Offset: 0x00086D30
		public string Description
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x00088972 File Offset: 0x00086D72
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06002168 RID: 8552 RVA: 0x00088980 File Offset: 0x00086D80
		public int IconSortOrder
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06002169 RID: 8553 RVA: 0x000889CC File Offset: 0x00086DCC
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600216A RID: 8554 RVA: 0x00088A0F File Offset: 0x00086E0F
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x0600216B RID: 8555 RVA: 0x00088A20 File Offset: 0x00086E20
		public int Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x0600216C RID: 8556 RVA: 0x00088A6C File Offset: 0x00086E6C
		public int WorkType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x0600216D RID: 8557 RVA: 0x00088AB8 File Offset: 0x00086EB8
		public int DispelType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x0600216E RID: 8558 RVA: 0x00088B04 File Offset: 0x00086F04
		public int IsQuickPressSupport
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x0600216F RID: 8559 RVA: 0x00088B50 File Offset: 0x00086F50
		public string EffectShaderName
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002170 RID: 8560 RVA: 0x00088B93 File Offset: 0x00086F93
		public ArraySegment<byte>? GetEffectShaderNameBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06002171 RID: 8561 RVA: 0x00088BA4 File Offset: 0x00086FA4
		public string HeadName
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x00088BE7 File Offset: 0x00086FE7
		public ArraySegment<byte>? GetHeadNameBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06002173 RID: 8563 RVA: 0x00088BF8 File Offset: 0x00086FF8
		public string HpBarName
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x00088C3B File Offset: 0x0008703B
		public ArraySegment<byte>? GetHpBarNameBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06002175 RID: 8565 RVA: 0x00088C4C File Offset: 0x0008704C
		public bool IsShowSpell
		{
			get
			{
				int num = this.__p.__offset(28);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06002176 RID: 8566 RVA: 0x00088C98 File Offset: 0x00087098
		public bool IsLowLevelShow
		{
			get
			{
				int num = this.__p.__offset(30);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06002177 RID: 8567 RVA: 0x00088CE4 File Offset: 0x000870E4
		public string BirthEffect
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002178 RID: 8568 RVA: 0x00088D27 File Offset: 0x00087127
		public ArraySegment<byte>? GetBirthEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06002179 RID: 8569 RVA: 0x00088D38 File Offset: 0x00087138
		public string BirthEffectLocate
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600217A RID: 8570 RVA: 0x00088D7B File Offset: 0x0008717B
		public ArraySegment<byte>? GetBirthEffectLocateBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x0600217B RID: 8571 RVA: 0x00088D8C File Offset: 0x0008718C
		public string EffectName
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600217C RID: 8572 RVA: 0x00088DCF File Offset: 0x000871CF
		public ArraySegment<byte>? GetEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x0600217D RID: 8573 RVA: 0x00088DE0 File Offset: 0x000871E0
		public string EffectLocateName
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x00088E23 File Offset: 0x00087223
		public ArraySegment<byte>? GetEffectLocateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x0600217F RID: 8575 RVA: 0x00088E34 File Offset: 0x00087234
		public bool EffectLoop
		{
			get
			{
				int num = this.__p.__offset(40);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06002180 RID: 8576 RVA: 0x00088E80 File Offset: 0x00087280
		public string EndEffect
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x00088EC3 File Offset: 0x000872C3
		public ArraySegment<byte>? GetEndEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06002182 RID: 8578 RVA: 0x00088ED4 File Offset: 0x000872D4
		public string EndEffectLocate
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002183 RID: 8579 RVA: 0x00088F17 File Offset: 0x00087317
		public ArraySegment<byte>? GetEndEffectLocateBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06002184 RID: 8580 RVA: 0x00088F28 File Offset: 0x00087328
		public string EffectConfigPath
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002185 RID: 8581 RVA: 0x00088F6B File Offset: 0x0008736B
		public ArraySegment<byte>? GetEffectConfigPathBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06002186 RID: 8582 RVA: 0x00088F7C File Offset: 0x0008737C
		public string HurtEffectName
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x00088FBF File Offset: 0x000873BF
		public ArraySegment<byte>? GetHurtEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06002188 RID: 8584 RVA: 0x00088FD0 File Offset: 0x000873D0
		public string HurtEffectLocateName
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002189 RID: 8585 RVA: 0x00089013 File Offset: 0x00087413
		public ArraySegment<byte>? GetHurtEffectLocateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x0600218A RID: 8586 RVA: 0x00089024 File Offset: 0x00087424
		public int SfxID
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x0600218B RID: 8587 RVA: 0x00089070 File Offset: 0x00087470
		public string BuffAIPath
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600218C RID: 8588 RVA: 0x000890B3 File Offset: 0x000874B3
		public ArraySegment<byte>? GetBuffAIPathBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x000890C4 File Offset: 0x000874C4
		public int TargetStateArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x0600218E RID: 8590 RVA: 0x00089114 File Offset: 0x00087514
		public int TargetStateLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x00089147 File Offset: 0x00087547
		public ArraySegment<byte>? GetTargetStateBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x06002190 RID: 8592 RVA: 0x00089156 File Offset: 0x00087556
		public FlatBufferArray<int> TargetState
		{
			get
			{
				if (this.TargetStateValue == null)
				{
					this.TargetStateValue = new FlatBufferArray<int>(new Func<int, int>(this.TargetStateArray), this.TargetStateLength);
				}
				return this.TargetStateValue;
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06002191 RID: 8593 RVA: 0x00089188 File Offset: 0x00087588
		public int Overlay
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x06002192 RID: 8594 RVA: 0x000891D4 File Offset: 0x000875D4
		public int OverlayLimit
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x06002193 RID: 8595 RVA: 0x00089220 File Offset: 0x00087620
		public int EffectDisOverlay
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06002194 RID: 8596 RVA: 0x0008926C File Offset: 0x0008766C
		public int TriggerInterval
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x000892B8 File Offset: 0x000876B8
		public int StateChangeArray(int j)
		{
			int num = this.__p.__offset(66);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06002196 RID: 8598 RVA: 0x00089308 File Offset: 0x00087708
		public int StateChangeLength
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x0008933B File Offset: 0x0008773B
		public ArraySegment<byte>? GetStateChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06002198 RID: 8600 RVA: 0x0008934A File Offset: 0x0008774A
		public FlatBufferArray<int> StateChange
		{
			get
			{
				if (this.StateChangeValue == null)
				{
					this.StateChangeValue = new FlatBufferArray<int>(new Func<int, int>(this.StateChangeArray), this.StateChangeLength);
				}
				return this.StateChangeValue;
			}
		}

		// Token: 0x06002199 RID: 8601 RVA: 0x0008937C File Offset: 0x0008777C
		public int AbilityChangeArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x0600219A RID: 8602 RVA: 0x000893CC File Offset: 0x000877CC
		public int AbilityChangeLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600219B RID: 8603 RVA: 0x000893FF File Offset: 0x000877FF
		public ArraySegment<byte>? GetAbilityChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x0600219C RID: 8604 RVA: 0x0008940E File Offset: 0x0008780E
		public FlatBufferArray<int> AbilityChange
		{
			get
			{
				if (this.AbilityChangeValue == null)
				{
					this.AbilityChangeValue = new FlatBufferArray<int>(new Func<int, int>(this.AbilityChangeArray), this.AbilityChangeLength);
				}
				return this.AbilityChangeValue;
			}
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x00089440 File Offset: 0x00087840
		public int ElementsArray(int j)
		{
			int num = this.__p.__offset(70);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x0600219E RID: 8606 RVA: 0x00089490 File Offset: 0x00087890
		public int ElementsLength
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x000894C3 File Offset: 0x000878C3
		public ArraySegment<byte>? GetElementsBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x060021A0 RID: 8608 RVA: 0x000894D2 File Offset: 0x000878D2
		public FlatBufferArray<int> Elements
		{
			get
			{
				if (this.ElementsValue == null)
				{
					this.ElementsValue = new FlatBufferArray<int>(new Func<int, int>(this.ElementsArray), this.ElementsLength);
				}
				return this.ElementsValue;
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x060021A1 RID: 8609 RVA: 0x00089504 File Offset: 0x00087904
		public UnionCell LightAttack
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x060021A2 RID: 8610 RVA: 0x0008955C File Offset: 0x0008795C
		public UnionCell FireAttack
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x060021A3 RID: 8611 RVA: 0x000895B4 File Offset: 0x000879B4
		public UnionCell IceAttack
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x060021A4 RID: 8612 RVA: 0x0008960C File Offset: 0x00087A0C
		public UnionCell DarkAttack
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x060021A5 RID: 8613 RVA: 0x00089664 File Offset: 0x00087A64
		public UnionCell LightDefence
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x060021A6 RID: 8614 RVA: 0x000896BC File Offset: 0x00087ABC
		public UnionCell FireDefence
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x060021A7 RID: 8615 RVA: 0x00089714 File Offset: 0x00087B14
		public UnionCell IceDefence
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x060021A8 RID: 8616 RVA: 0x0008976C File Offset: 0x00087B6C
		public UnionCell DarkDefence
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x060021A9 RID: 8617 RVA: 0x000897C4 File Offset: 0x00087BC4
		public int UseSkillIDsArray(int j)
		{
			int num = this.__p.__offset(88);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x060021AA RID: 8618 RVA: 0x00089814 File Offset: 0x00087C14
		public int UseSkillIDsLength
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060021AB RID: 8619 RVA: 0x00089847 File Offset: 0x00087C47
		public ArraySegment<byte>? GetUseSkillIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x00089856 File Offset: 0x00087C56
		public FlatBufferArray<int> UseSkillIDs
		{
			get
			{
				if (this.UseSkillIDsValue == null)
				{
					this.UseSkillIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.UseSkillIDsArray), this.UseSkillIDsLength);
				}
				return this.UseSkillIDsValue;
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x060021AD RID: 8621 RVA: 0x00089888 File Offset: 0x00087C88
		public int DispelBuffType
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060021AE RID: 8622 RVA: 0x000898D4 File Offset: 0x00087CD4
		public int TriggerBuffInfoIDsArray(int j)
		{
			int num = this.__p.__offset(92);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x060021AF RID: 8623 RVA: 0x00089924 File Offset: 0x00087D24
		public int TriggerBuffInfoIDsLength
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x00089957 File Offset: 0x00087D57
		public ArraySegment<byte>? GetTriggerBuffInfoIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x060021B1 RID: 8625 RVA: 0x00089966 File Offset: 0x00087D66
		public FlatBufferArray<int> TriggerBuffInfoIDs
		{
			get
			{
				if (this.TriggerBuffInfoIDsValue == null)
				{
					this.TriggerBuffInfoIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.TriggerBuffInfoIDsArray), this.TriggerBuffInfoIDsLength);
				}
				return this.TriggerBuffInfoIDsValue;
			}
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x060021B2 RID: 8626 RVA: 0x00089998 File Offset: 0x00087D98
		public int ExitRemoveTrigger
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060021B3 RID: 8627 RVA: 0x000899E4 File Offset: 0x00087DE4
		public int MechanismIDArray(int j)
		{
			int num = this.__p.__offset(96);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x060021B4 RID: 8628 RVA: 0x00089A34 File Offset: 0x00087E34
		public int MechanismIDLength
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x00089A67 File Offset: 0x00087E67
		public ArraySegment<byte>? GetMechanismIDBytes()
		{
			return this.__p.__vector_as_arraysegment(96);
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x060021B6 RID: 8630 RVA: 0x00089A76 File Offset: 0x00087E76
		public FlatBufferArray<int> MechanismID
		{
			get
			{
				if (this.MechanismIDValue == null)
				{
					this.MechanismIDValue = new FlatBufferArray<int>(new Func<int, int>(this.MechanismIDArray), this.MechanismIDLength);
				}
				return this.MechanismIDValue;
			}
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x060021B7 RID: 8631 RVA: 0x00089AA8 File Offset: 0x00087EA8
		public UnionCell hp
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x060021B8 RID: 8632 RVA: 0x00089B00 File Offset: 0x00087F00
		public UnionCell mp
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x060021B9 RID: 8633 RVA: 0x00089B58 File Offset: 0x00087F58
		public UnionCell hpRate
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x060021BA RID: 8634 RVA: 0x00089BB0 File Offset: 0x00087FB0
		public UnionCell mpRate
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x060021BB RID: 8635 RVA: 0x00089C08 File Offset: 0x00088008
		public UnionCell currentHpRate
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x060021BC RID: 8636 RVA: 0x00089C60 File Offset: 0x00088060
		public int currentHpRateControl
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x060021BD RID: 8637 RVA: 0x00089CAC File Offset: 0x000880AC
		public UnionCell baseAtk
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x060021BE RID: 8638 RVA: 0x00089D04 File Offset: 0x00088104
		public UnionCell baseInt
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x060021BF RID: 8639 RVA: 0x00089D5C File Offset: 0x0008815C
		public UnionCell sta
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x060021C0 RID: 8640 RVA: 0x00089DB4 File Offset: 0x000881B4
		public UnionCell spr
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x060021C1 RID: 8641 RVA: 0x00089E0C File Offset: 0x0008820C
		public UnionCell atkAddRate
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x060021C2 RID: 8642 RVA: 0x00089E64 File Offset: 0x00088264
		public UnionCell intAddRate
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x060021C3 RID: 8643 RVA: 0x00089EBC File Offset: 0x000882BC
		public UnionCell staAddRate
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x060021C4 RID: 8644 RVA: 0x00089F14 File Offset: 0x00088314
		public UnionCell sprAddRate
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x060021C5 RID: 8645 RVA: 0x00089F6C File Offset: 0x0008836C
		public UnionCell maxHp
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060021C6 RID: 8646 RVA: 0x00089FC4 File Offset: 0x000883C4
		public UnionCell maxMp
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060021C7 RID: 8647 RVA: 0x0008A020 File Offset: 0x00088420
		public UnionCell maxHpAddRate
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060021C8 RID: 8648 RVA: 0x0008A07C File Offset: 0x0008847C
		public UnionCell maxMpAddRate
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060021C9 RID: 8649 RVA: 0x0008A0D8 File Offset: 0x000884D8
		public UnionCell hpRecover
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060021CA RID: 8650 RVA: 0x0008A134 File Offset: 0x00088534
		public UnionCell mpRecover
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060021CB RID: 8651 RVA: 0x0008A190 File Offset: 0x00088590
		public UnionCell attack
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060021CC RID: 8652 RVA: 0x0008A1EC File Offset: 0x000885EC
		public UnionCell magicAttack
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060021CD RID: 8653 RVA: 0x0008A248 File Offset: 0x00088648
		public UnionCell defence
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060021CE RID: 8654 RVA: 0x0008A2A4 File Offset: 0x000886A4
		public UnionCell magicDefence
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060021CF RID: 8655 RVA: 0x0008A300 File Offset: 0x00088700
		public UnionCell attackSpeed
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060021D0 RID: 8656 RVA: 0x0008A35C File Offset: 0x0008875C
		public UnionCell spellSpeed
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060021D1 RID: 8657 RVA: 0x0008A3B8 File Offset: 0x000887B8
		public UnionCell moveSpeed
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060021D2 RID: 8658 RVA: 0x0008A414 File Offset: 0x00088814
		public UnionCell ciriticalAttack
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060021D3 RID: 8659 RVA: 0x0008A470 File Offset: 0x00088870
		public UnionCell ciriticalMagicAttack
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060021D4 RID: 8660 RVA: 0x0008A4CC File Offset: 0x000888CC
		public UnionCell dex
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060021D5 RID: 8661 RVA: 0x0008A528 File Offset: 0x00088928
		public UnionCell dodge
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060021D6 RID: 8662 RVA: 0x0008A584 File Offset: 0x00088984
		public UnionCell frozen
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060021D7 RID: 8663 RVA: 0x0008A5E0 File Offset: 0x000889E0
		public UnionCell hard
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060021D8 RID: 8664 RVA: 0x0008A63C File Offset: 0x00088A3C
		public UnionCell abnormalResist
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060021D9 RID: 8665 RVA: 0x0008A698 File Offset: 0x00088A98
		public UnionCell abnormalResist1
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x060021DA RID: 8666 RVA: 0x0008A6F4 File Offset: 0x00088AF4
		public UnionCell abnormalResist2
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x060021DB RID: 8667 RVA: 0x0008A750 File Offset: 0x00088B50
		public UnionCell abnormalResist3
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x060021DC RID: 8668 RVA: 0x0008A7AC File Offset: 0x00088BAC
		public UnionCell abnormalResist4
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x060021DD RID: 8669 RVA: 0x0008A808 File Offset: 0x00088C08
		public UnionCell abnormalResist5
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x060021DE RID: 8670 RVA: 0x0008A864 File Offset: 0x00088C64
		public UnionCell abnormalResist6
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x060021DF RID: 8671 RVA: 0x0008A8C0 File Offset: 0x00088CC0
		public UnionCell abnormalResist7
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x060021E0 RID: 8672 RVA: 0x0008A91C File Offset: 0x00088D1C
		public UnionCell abnormalResist8
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x060021E1 RID: 8673 RVA: 0x0008A978 File Offset: 0x00088D78
		public UnionCell abnormalResist9
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F1 RID: 1777
		// (get) Token: 0x060021E2 RID: 8674 RVA: 0x0008A9D4 File Offset: 0x00088DD4
		public UnionCell abnormalResist10
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x060021E3 RID: 8675 RVA: 0x0008AA30 File Offset: 0x00088E30
		public UnionCell abnormalResist11
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x060021E4 RID: 8676 RVA: 0x0008AA8C File Offset: 0x00088E8C
		public UnionCell abnormalResist12
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F4 RID: 1780
		// (get) Token: 0x060021E5 RID: 8677 RVA: 0x0008AAE8 File Offset: 0x00088EE8
		public UnionCell abnormalResist13
		{
			get
			{
				int num = this.__p.__offset(190);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x060021E6 RID: 8678 RVA: 0x0008AB44 File Offset: 0x00088F44
		public UnionCell criticalPercent
		{
			get
			{
				int num = this.__p.__offset(192);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x060021E7 RID: 8679 RVA: 0x0008ABA0 File Offset: 0x00088FA0
		public UnionCell cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(194);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x060021E8 RID: 8680 RVA: 0x0008ABFC File Offset: 0x00088FFC
		public UnionCell attackAddRate
		{
			get
			{
				int num = this.__p.__offset(196);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x0008AC58 File Offset: 0x00089058
		public UnionCell magicAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(198);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x060021EA RID: 8682 RVA: 0x0008ACB4 File Offset: 0x000890B4
		public UnionCell defenceAddRate
		{
			get
			{
				int num = this.__p.__offset(200);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x060021EB RID: 8683 RVA: 0x0008AD10 File Offset: 0x00089110
		public UnionCell magicDefenceAddRate
		{
			get
			{
				int num = this.__p.__offset(202);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x060021EC RID: 8684 RVA: 0x0008AD6C File Offset: 0x0008916C
		public UnionCell ignoreDefAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(204);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x060021ED RID: 8685 RVA: 0x0008ADC8 File Offset: 0x000891C8
		public UnionCell ignoreDefMagicAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(206);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x060021EE RID: 8686 RVA: 0x0008AE24 File Offset: 0x00089224
		public UnionCell attachAddDamageFix
		{
			get
			{
				int num = this.__p.__offset(208);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x060021EF RID: 8687 RVA: 0x0008AE80 File Offset: 0x00089280
		public UnionCell attachAddDamagePercent
		{
			get
			{
				int num = this.__p.__offset(210);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x060021F0 RID: 8688 RVA: 0x0008AEDC File Offset: 0x000892DC
		public UnionCell addDamageFix
		{
			get
			{
				int num = this.__p.__offset(212);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x060021F1 RID: 8689 RVA: 0x0008AF38 File Offset: 0x00089338
		public UnionCell addDamagePercent
		{
			get
			{
				int num = this.__p.__offset(214);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x060021F2 RID: 8690 RVA: 0x0008AF94 File Offset: 0x00089394
		public UnionCell reduceDamageFix
		{
			get
			{
				int num = this.__p.__offset(216);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x060021F3 RID: 8691 RVA: 0x0008AFF0 File Offset: 0x000893F0
		public int reduceDamageFixType
		{
			get
			{
				int num = this.__p.__offset(218);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x060021F4 RID: 8692 RVA: 0x0008B040 File Offset: 0x00089440
		public UnionCell reduceDamagePercent
		{
			get
			{
				int num = this.__p.__offset(220);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x060021F5 RID: 8693 RVA: 0x0008B09C File Offset: 0x0008949C
		public int reduceDamagePercentType
		{
			get
			{
				int num = this.__p.__offset(222);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x060021F6 RID: 8694 RVA: 0x0008B0EC File Offset: 0x000894EC
		public UnionCell reflectDamageFix
		{
			get
			{
				int num = this.__p.__offset(224);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x060021F7 RID: 8695 RVA: 0x0008B148 File Offset: 0x00089548
		public int reflectDamageFixType
		{
			get
			{
				int num = this.__p.__offset(226);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x060021F8 RID: 8696 RVA: 0x0008B198 File Offset: 0x00089598
		public UnionCell reflectDamagePercent
		{
			get
			{
				int num = this.__p.__offset(228);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x060021F9 RID: 8697 RVA: 0x0008B1F4 File Offset: 0x000895F4
		public int reflectDamagePercentType
		{
			get
			{
				int num = this.__p.__offset(230);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x060021FA RID: 8698 RVA: 0x0008B244 File Offset: 0x00089644
		public UnionCell level
		{
			get
			{
				int num = this.__p.__offset(232);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x060021FB RID: 8699 RVA: 0x0008B2A0 File Offset: 0x000896A0
		public UnionCell skill_mpCostReduceRate
		{
			get
			{
				int num = this.__p.__offset(234);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x060021FC RID: 8700 RVA: 0x0008B2FC File Offset: 0x000896FC
		public UnionCell skill_cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(236);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x060021FD RID: 8701 RVA: 0x0008B358 File Offset: 0x00089758
		public UnionCell skill_cdReduceValue
		{
			get
			{
				int num = this.__p.__offset(238);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060021FE RID: 8702 RVA: 0x0008B3B4 File Offset: 0x000897B4
		public UnionCell skill_speedAddFactor
		{
			get
			{
				int num = this.__p.__offset(240);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x060021FF RID: 8703 RVA: 0x0008B410 File Offset: 0x00089810
		public UnionCell skill_hitRateAdd
		{
			get
			{
				int num = this.__p.__offset(242);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06002200 RID: 8704 RVA: 0x0008B46C File Offset: 0x0008986C
		public UnionCell skill_criticalHitRateAdd
		{
			get
			{
				int num = this.__p.__offset(244);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06002201 RID: 8705 RVA: 0x0008B4C8 File Offset: 0x000898C8
		public UnionCell skill_attackAddRate
		{
			get
			{
				int num = this.__p.__offset(246);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06002202 RID: 8706 RVA: 0x0008B524 File Offset: 0x00089924
		public UnionCell skill_attackAdd
		{
			get
			{
				int num = this.__p.__offset(248);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06002203 RID: 8707 RVA: 0x0008B580 File Offset: 0x00089980
		public UnionCell skill_attackAddFix
		{
			get
			{
				int num = this.__p.__offset(250);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06002204 RID: 8708 RVA: 0x0008B5DC File Offset: 0x000899DC
		public UnionCell skill_hardAddRate
		{
			get
			{
				int num = this.__p.__offset(252);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x06002205 RID: 8709 RVA: 0x0008B638 File Offset: 0x00089A38
		public UnionCell skill_chargeReduceRate
		{
			get
			{
				int num = this.__p.__offset(254);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x06002206 RID: 8710 RVA: 0x0008B694 File Offset: 0x00089A94
		public UnionCell ResistMagic
		{
			get
			{
				int num = this.__p.__offset(256);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06002207 RID: 8711 RVA: 0x0008B6F0 File Offset: 0x00089AF0
		public UnionCell ai_warlike
		{
			get
			{
				int num = this.__p.__offset(258);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06002208 RID: 8712 RVA: 0x0008B74C File Offset: 0x00089B4C
		public UnionCell ai_sight
		{
			get
			{
				int num = this.__p.__offset(260);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06002209 RID: 8713 RVA: 0x0008B7A8 File Offset: 0x00089BA8
		public UnionCell ai_attackProb
		{
			get
			{
				int num = this.__p.__offset(262);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x0600220A RID: 8714 RVA: 0x0008B804 File Offset: 0x00089C04
		public int summon_monsterID
		{
			get
			{
				int num = this.__p.__offset(264);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x0600220B RID: 8715 RVA: 0x0008B854 File Offset: 0x00089C54
		public int summon_monsterLevel
		{
			get
			{
				int num = this.__p.__offset(266);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x0600220C RID: 8716 RVA: 0x0008B8A4 File Offset: 0x00089CA4
		public int summon_existTime
		{
			get
			{
				int num = this.__p.__offset(268);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x0600220D RID: 8717 RVA: 0x0008B8F4 File Offset: 0x00089CF4
		public int summon_posType
		{
			get
			{
				int num = this.__p.__offset(270);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x0008B944 File Offset: 0x00089D44
		public int summon_posType2Array(int j)
		{
			int num = this.__p.__offset(272);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x0600220F RID: 8719 RVA: 0x0008B994 File Offset: 0x00089D94
		public int summon_posType2Length
		{
			get
			{
				int num = this.__p.__offset(272);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x0008B9CA File Offset: 0x00089DCA
		public ArraySegment<byte>? GetSummonPosType2Bytes()
		{
			return this.__p.__vector_as_arraysegment(272);
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06002211 RID: 8721 RVA: 0x0008B9DC File Offset: 0x00089DDC
		public FlatBufferArray<int> summon_posType2
		{
			get
			{
				if (this.summon_posType2Value == null)
				{
					this.summon_posType2Value = new FlatBufferArray<int>(new Func<int, int>(this.summon_posType2Array), this.summon_posType2Length);
				}
				return this.summon_posType2Value;
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06002212 RID: 8722 RVA: 0x0008BA0C File Offset: 0x00089E0C
		public int summon_display
		{
			get
			{
				int num = this.__p.__offset(274);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06002213 RID: 8723 RVA: 0x0008BA5C File Offset: 0x00089E5C
		public int summon_num
		{
			get
			{
				int num = this.__p.__offset(276);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06002214 RID: 8724 RVA: 0x0008BAAC File Offset: 0x00089EAC
		public int summon_relation
		{
			get
			{
				int num = this.__p.__offset(278);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06002215 RID: 8725 RVA: 0x0008BAFC File Offset: 0x00089EFC
		public int summon_numLimit
		{
			get
			{
				int num = this.__p.__offset(280);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x0008BB4C File Offset: 0x00089F4C
		public int summon_entityArray(int j)
		{
			int num = this.__p.__offset(282);
			return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06002217 RID: 8727 RVA: 0x0008BB9C File Offset: 0x00089F9C
		public int summon_entityLength
		{
			get
			{
				int num = this.__p.__offset(282);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x0008BBD2 File Offset: 0x00089FD2
		public ArraySegment<byte>? GetSummonEntityBytes()
		{
			return this.__p.__vector_as_arraysegment(282);
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06002219 RID: 8729 RVA: 0x0008BBE4 File Offset: 0x00089FE4
		public FlatBufferArray<int> summon_entity
		{
			get
			{
				if (this.summon_entityValue == null)
				{
					this.summon_entityValue = new FlatBufferArray<int>(new Func<int, int>(this.summon_entityArray), this.summon_entityLength);
				}
				return this.summon_entityValue;
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x0600221A RID: 8730 RVA: 0x0008BC14 File Offset: 0x0008A014
		public int duplicate_percent
		{
			get
			{
				int num = this.__p.__offset(284);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x0600221B RID: 8731 RVA: 0x0008BC64 File Offset: 0x0008A064
		public int duplicate_max
		{
			get
			{
				int num = this.__p.__offset(286);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x0600221C RID: 8732 RVA: 0x0008BCB4 File Offset: 0x0008A0B4
		public UnionCell expAddRate
		{
			get
			{
				int num = this.__p.__offset(288);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x0600221D RID: 8733 RVA: 0x0008BD10 File Offset: 0x0008A110
		public UnionCell goldAddRate
		{
			get
			{
				int num = this.__p.__offset(290);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x0600221E RID: 8734 RVA: 0x0008BD6C File Offset: 0x0008A16C
		public int taskDropAddRate
		{
			get
			{
				int num = this.__p.__offset(292);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x0600221F RID: 8735 RVA: 0x0008BDBC File Offset: 0x0008A1BC
		public int PinkDropAddRate
		{
			get
			{
				int num = this.__p.__offset(294);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06002220 RID: 8736 RVA: 0x0008BE0C File Offset: 0x0008A20C
		public int ChestDropAddRate
		{
			get
			{
				int num = this.__p.__offset(296);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06002221 RID: 8737 RVA: 0x0008BE5C File Offset: 0x0008A25C
		public int durationType
		{
			get
			{
				int num = this.__p.__offset(298);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06002222 RID: 8738 RVA: 0x0008BEAC File Offset: 0x0008A2AC
		public int duration
		{
			get
			{
				int num = this.__p.__offset(300);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06002223 RID: 8739 RVA: 0x0008BEFC File Offset: 0x0008A2FC
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(302);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x0008BF42 File Offset: 0x0008A342
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(302);
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x0008BF54 File Offset: 0x0008A354
		public UnionCell ValueAArray(int j)
		{
			int num = this.__p.__offset(304);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06002226 RID: 8742 RVA: 0x0008BFB4 File Offset: 0x0008A3B4
		public int ValueALength
		{
			get
			{
				int num = this.__p.__offset(304);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06002227 RID: 8743 RVA: 0x0008BFEA File Offset: 0x0008A3EA
		public FlatBufferArray<UnionCell> ValueA
		{
			get
			{
				if (this.ValueAValue == null)
				{
					this.ValueAValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueAArray), this.ValueALength);
				}
				return this.ValueAValue;
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06002228 RID: 8744 RVA: 0x0008C01C File Offset: 0x0008A41C
		public string DescriptionB
		{
			get
			{
				int num = this.__p.__offset(306);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x0008C062 File Offset: 0x0008A462
		public ArraySegment<byte>? GetDescriptionBBytes()
		{
			return this.__p.__vector_as_arraysegment(306);
		}

		// Token: 0x0600222A RID: 8746 RVA: 0x0008C074 File Offset: 0x0008A474
		public UnionCell ValueBArray(int j)
		{
			int num = this.__p.__offset(308);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x0600222B RID: 8747 RVA: 0x0008C0D4 File Offset: 0x0008A4D4
		public int ValueBLength
		{
			get
			{
				int num = this.__p.__offset(308);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x0600222C RID: 8748 RVA: 0x0008C10A File Offset: 0x0008A50A
		public FlatBufferArray<UnionCell> ValueB
		{
			get
			{
				if (this.ValueBValue == null)
				{
					this.ValueBValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueBArray), this.ValueBLength);
				}
				return this.ValueBValue;
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x0600222D RID: 8749 RVA: 0x0008C13C File Offset: 0x0008A53C
		public string DescriptionC
		{
			get
			{
				int num = this.__p.__offset(310);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x0008C182 File Offset: 0x0008A582
		public ArraySegment<byte>? GetDescriptionCBytes()
		{
			return this.__p.__vector_as_arraysegment(310);
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x0008C194 File Offset: 0x0008A594
		public UnionCell ValueCArray(int j)
		{
			int num = this.__p.__offset(312);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06002230 RID: 8752 RVA: 0x0008C1F4 File Offset: 0x0008A5F4
		public int ValueCLength
		{
			get
			{
				int num = this.__p.__offset(312);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06002231 RID: 8753 RVA: 0x0008C22A File Offset: 0x0008A62A
		public FlatBufferArray<UnionCell> ValueC
		{
			get
			{
				if (this.ValueCValue == null)
				{
					this.ValueCValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueCArray), this.ValueCLength);
				}
				return this.ValueCValue;
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06002232 RID: 8754 RVA: 0x0008C25C File Offset: 0x0008A65C
		public string DescriptionD
		{
			get
			{
				int num = this.__p.__offset(314);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x0008C2A2 File Offset: 0x0008A6A2
		public ArraySegment<byte>? GetDescriptionDBytes()
		{
			return this.__p.__vector_as_arraysegment(314);
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x0008C2B4 File Offset: 0x0008A6B4
		public UnionCell ValueDArray(int j)
		{
			int num = this.__p.__offset(316);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06002235 RID: 8757 RVA: 0x0008C314 File Offset: 0x0008A714
		public int ValueDLength
		{
			get
			{
				int num = this.__p.__offset(316);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06002236 RID: 8758 RVA: 0x0008C34A File Offset: 0x0008A74A
		public FlatBufferArray<UnionCell> ValueD
		{
			get
			{
				if (this.ValueDValue == null)
				{
					this.ValueDValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueDArray), this.ValueDLength);
				}
				return this.ValueDValue;
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06002237 RID: 8759 RVA: 0x0008C37C File Offset: 0x0008A77C
		public string DescriptionE
		{
			get
			{
				int num = this.__p.__offset(318);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x0008C3C2 File Offset: 0x0008A7C2
		public ArraySegment<byte>? GetDescriptionEBytes()
		{
			return this.__p.__vector_as_arraysegment(318);
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x0008C3D4 File Offset: 0x0008A7D4
		public UnionCell ValueEArray(int j)
		{
			int num = this.__p.__offset(320);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x0600223A RID: 8762 RVA: 0x0008C434 File Offset: 0x0008A834
		public int ValueELength
		{
			get
			{
				int num = this.__p.__offset(320);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x0600223B RID: 8763 RVA: 0x0008C46A File Offset: 0x0008A86A
		public FlatBufferArray<UnionCell> ValueE
		{
			get
			{
				if (this.ValueEValue == null)
				{
					this.ValueEValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueEArray), this.ValueELength);
				}
				return this.ValueEValue;
			}
		}

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x0600223C RID: 8764 RVA: 0x0008C49C File Offset: 0x0008A89C
		public string DescriptionF
		{
			get
			{
				int num = this.__p.__offset(322);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x0008C4E2 File Offset: 0x0008A8E2
		public ArraySegment<byte>? GetDescriptionFBytes()
		{
			return this.__p.__vector_as_arraysegment(322);
		}

		// Token: 0x0600223E RID: 8766 RVA: 0x0008C4F4 File Offset: 0x0008A8F4
		public UnionCell ValueFArray(int j)
		{
			int num = this.__p.__offset(324);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x0600223F RID: 8767 RVA: 0x0008C554 File Offset: 0x0008A954
		public int ValueFLength
		{
			get
			{
				int num = this.__p.__offset(324);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06002240 RID: 8768 RVA: 0x0008C58A File Offset: 0x0008A98A
		public FlatBufferArray<UnionCell> ValueF
		{
			get
			{
				if (this.ValueFValue == null)
				{
					this.ValueFValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueFArray), this.ValueFLength);
				}
				return this.ValueFValue;
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06002241 RID: 8769 RVA: 0x0008C5BC File Offset: 0x0008A9BC
		public string DescriptionG
		{
			get
			{
				int num = this.__p.__offset(326);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x0008C602 File Offset: 0x0008AA02
		public ArraySegment<byte>? GetDescriptionGBytes()
		{
			return this.__p.__vector_as_arraysegment(326);
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x0008C614 File Offset: 0x0008AA14
		public UnionCell ValueGArray(int j)
		{
			int num = this.__p.__offset(328);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06002244 RID: 8772 RVA: 0x0008C674 File Offset: 0x0008AA74
		public int ValueGLength
		{
			get
			{
				int num = this.__p.__offset(328);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06002245 RID: 8773 RVA: 0x0008C6AA File Offset: 0x0008AAAA
		public FlatBufferArray<UnionCell> ValueG
		{
			get
			{
				if (this.ValueGValue == null)
				{
					this.ValueGValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.ValueGArray), this.ValueGLength);
				}
				return this.ValueGValue;
			}
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x06002246 RID: 8774 RVA: 0x0008C6DC File Offset: 0x0008AADC
		public int EffectTimes
		{
			get
			{
				int num = this.__p.__offset(330);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06002247 RID: 8775 RVA: 0x0008C72C File Offset: 0x0008AB2C
		public string ApplyDungeon
		{
			get
			{
				int num = this.__p.__offset(332);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x0008C772 File Offset: 0x0008AB72
		public ArraySegment<byte>? GetApplyDungeonBytes()
		{
			return this.__p.__vector_as_arraysegment(332);
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06002249 RID: 8777 RVA: 0x0008C784 File Offset: 0x0008AB84
		public int param1
		{
			get
			{
				int num = this.__p.__offset(334);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x0600224A RID: 8778 RVA: 0x0008C7D4 File Offset: 0x0008ABD4
		public int param2
		{
			get
			{
				int num = this.__p.__offset(336);
				return (num == 0) ? 0 : (-261708052 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600224B RID: 8779 RVA: 0x0008C821 File Offset: 0x0008AC21
		public static void StartChijiBuffTable(FlatBufferBuilder builder)
		{
			builder.StartObject(167);
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x0008C82E File Offset: 0x0008AC2E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x0008C839 File Offset: 0x0008AC39
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600224E RID: 8782 RVA: 0x0008C84A File Offset: 0x0008AC4A
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(2, DescriptionOffset.Value, 0);
		}

		// Token: 0x0600224F RID: 8783 RVA: 0x0008C85B File Offset: 0x0008AC5B
		public static void AddIconSortOrder(FlatBufferBuilder builder, int IconSortOrder)
		{
			builder.AddInt(3, IconSortOrder, 0);
		}

		// Token: 0x06002250 RID: 8784 RVA: 0x0008C866 File Offset: 0x0008AC66
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(4, IconOffset.Value, 0);
		}

		// Token: 0x06002251 RID: 8785 RVA: 0x0008C877 File Offset: 0x0008AC77
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(5, Type, 0);
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x0008C882 File Offset: 0x0008AC82
		public static void AddWorkType(FlatBufferBuilder builder, int WorkType)
		{
			builder.AddInt(6, WorkType, 0);
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x0008C88D File Offset: 0x0008AC8D
		public static void AddDispelType(FlatBufferBuilder builder, int DispelType)
		{
			builder.AddInt(7, DispelType, 0);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x0008C898 File Offset: 0x0008AC98
		public static void AddIsQuickPressSupport(FlatBufferBuilder builder, int IsQuickPressSupport)
		{
			builder.AddInt(8, IsQuickPressSupport, 0);
		}

		// Token: 0x06002255 RID: 8789 RVA: 0x0008C8A3 File Offset: 0x0008ACA3
		public static void AddEffectShaderName(FlatBufferBuilder builder, StringOffset EffectShaderNameOffset)
		{
			builder.AddOffset(9, EffectShaderNameOffset.Value, 0);
		}

		// Token: 0x06002256 RID: 8790 RVA: 0x0008C8B5 File Offset: 0x0008ACB5
		public static void AddHeadName(FlatBufferBuilder builder, StringOffset HeadNameOffset)
		{
			builder.AddOffset(10, HeadNameOffset.Value, 0);
		}

		// Token: 0x06002257 RID: 8791 RVA: 0x0008C8C7 File Offset: 0x0008ACC7
		public static void AddHpBarName(FlatBufferBuilder builder, StringOffset HpBarNameOffset)
		{
			builder.AddOffset(11, HpBarNameOffset.Value, 0);
		}

		// Token: 0x06002258 RID: 8792 RVA: 0x0008C8D9 File Offset: 0x0008ACD9
		public static void AddIsShowSpell(FlatBufferBuilder builder, bool IsShowSpell)
		{
			builder.AddBool(12, IsShowSpell, false);
		}

		// Token: 0x06002259 RID: 8793 RVA: 0x0008C8E5 File Offset: 0x0008ACE5
		public static void AddIsLowLevelShow(FlatBufferBuilder builder, bool IsLowLevelShow)
		{
			builder.AddBool(13, IsLowLevelShow, false);
		}

		// Token: 0x0600225A RID: 8794 RVA: 0x0008C8F1 File Offset: 0x0008ACF1
		public static void AddBirthEffect(FlatBufferBuilder builder, StringOffset BirthEffectOffset)
		{
			builder.AddOffset(14, BirthEffectOffset.Value, 0);
		}

		// Token: 0x0600225B RID: 8795 RVA: 0x0008C903 File Offset: 0x0008AD03
		public static void AddBirthEffectLocate(FlatBufferBuilder builder, StringOffset BirthEffectLocateOffset)
		{
			builder.AddOffset(15, BirthEffectLocateOffset.Value, 0);
		}

		// Token: 0x0600225C RID: 8796 RVA: 0x0008C915 File Offset: 0x0008AD15
		public static void AddEffectName(FlatBufferBuilder builder, StringOffset EffectNameOffset)
		{
			builder.AddOffset(16, EffectNameOffset.Value, 0);
		}

		// Token: 0x0600225D RID: 8797 RVA: 0x0008C927 File Offset: 0x0008AD27
		public static void AddEffectLocateName(FlatBufferBuilder builder, StringOffset EffectLocateNameOffset)
		{
			builder.AddOffset(17, EffectLocateNameOffset.Value, 0);
		}

		// Token: 0x0600225E RID: 8798 RVA: 0x0008C939 File Offset: 0x0008AD39
		public static void AddEffectLoop(FlatBufferBuilder builder, bool EffectLoop)
		{
			builder.AddBool(18, EffectLoop, false);
		}

		// Token: 0x0600225F RID: 8799 RVA: 0x0008C945 File Offset: 0x0008AD45
		public static void AddEndEffect(FlatBufferBuilder builder, StringOffset EndEffectOffset)
		{
			builder.AddOffset(19, EndEffectOffset.Value, 0);
		}

		// Token: 0x06002260 RID: 8800 RVA: 0x0008C957 File Offset: 0x0008AD57
		public static void AddEndEffectLocate(FlatBufferBuilder builder, StringOffset EndEffectLocateOffset)
		{
			builder.AddOffset(20, EndEffectLocateOffset.Value, 0);
		}

		// Token: 0x06002261 RID: 8801 RVA: 0x0008C969 File Offset: 0x0008AD69
		public static void AddEffectConfigPath(FlatBufferBuilder builder, StringOffset EffectConfigPathOffset)
		{
			builder.AddOffset(21, EffectConfigPathOffset.Value, 0);
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x0008C97B File Offset: 0x0008AD7B
		public static void AddHurtEffectName(FlatBufferBuilder builder, StringOffset HurtEffectNameOffset)
		{
			builder.AddOffset(22, HurtEffectNameOffset.Value, 0);
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x0008C98D File Offset: 0x0008AD8D
		public static void AddHurtEffectLocateName(FlatBufferBuilder builder, StringOffset HurtEffectLocateNameOffset)
		{
			builder.AddOffset(23, HurtEffectLocateNameOffset.Value, 0);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x0008C99F File Offset: 0x0008AD9F
		public static void AddSfxID(FlatBufferBuilder builder, int SfxID)
		{
			builder.AddInt(24, SfxID, 0);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x0008C9AB File Offset: 0x0008ADAB
		public static void AddBuffAIPath(FlatBufferBuilder builder, StringOffset BuffAIPathOffset)
		{
			builder.AddOffset(25, BuffAIPathOffset.Value, 0);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x0008C9BD File Offset: 0x0008ADBD
		public static void AddTargetState(FlatBufferBuilder builder, VectorOffset TargetStateOffset)
		{
			builder.AddOffset(26, TargetStateOffset.Value, 0);
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x0008C9D0 File Offset: 0x0008ADD0
		public static VectorOffset CreateTargetStateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x0008CA0D File Offset: 0x0008AE0D
		public static void StartTargetStateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002269 RID: 8809 RVA: 0x0008CA18 File Offset: 0x0008AE18
		public static void AddOverlay(FlatBufferBuilder builder, int Overlay)
		{
			builder.AddInt(27, Overlay, 0);
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x0008CA24 File Offset: 0x0008AE24
		public static void AddOverlayLimit(FlatBufferBuilder builder, int OverlayLimit)
		{
			builder.AddInt(28, OverlayLimit, 0);
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x0008CA30 File Offset: 0x0008AE30
		public static void AddEffectDisOverlay(FlatBufferBuilder builder, int EffectDisOverlay)
		{
			builder.AddInt(29, EffectDisOverlay, 0);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x0008CA3C File Offset: 0x0008AE3C
		public static void AddTriggerInterval(FlatBufferBuilder builder, int TriggerInterval)
		{
			builder.AddInt(30, TriggerInterval, 0);
		}

		// Token: 0x0600226D RID: 8813 RVA: 0x0008CA48 File Offset: 0x0008AE48
		public static void AddStateChange(FlatBufferBuilder builder, VectorOffset StateChangeOffset)
		{
			builder.AddOffset(31, StateChangeOffset.Value, 0);
		}

		// Token: 0x0600226E RID: 8814 RVA: 0x0008CA5C File Offset: 0x0008AE5C
		public static VectorOffset CreateStateChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x0008CA99 File Offset: 0x0008AE99
		public static void StartStateChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x0008CAA4 File Offset: 0x0008AEA4
		public static void AddAbilityChange(FlatBufferBuilder builder, VectorOffset AbilityChangeOffset)
		{
			builder.AddOffset(32, AbilityChangeOffset.Value, 0);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x0008CAB8 File Offset: 0x0008AEB8
		public static VectorOffset CreateAbilityChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x0008CAF5 File Offset: 0x0008AEF5
		public static void StartAbilityChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x0008CB00 File Offset: 0x0008AF00
		public static void AddElements(FlatBufferBuilder builder, VectorOffset ElementsOffset)
		{
			builder.AddOffset(33, ElementsOffset.Value, 0);
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x0008CB14 File Offset: 0x0008AF14
		public static VectorOffset CreateElementsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002275 RID: 8821 RVA: 0x0008CB51 File Offset: 0x0008AF51
		public static void StartElementsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002276 RID: 8822 RVA: 0x0008CB5C File Offset: 0x0008AF5C
		public static void AddLightAttack(FlatBufferBuilder builder, Offset<UnionCell> LightAttackOffset)
		{
			builder.AddOffset(34, LightAttackOffset.Value, 0);
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x0008CB6E File Offset: 0x0008AF6E
		public static void AddFireAttack(FlatBufferBuilder builder, Offset<UnionCell> FireAttackOffset)
		{
			builder.AddOffset(35, FireAttackOffset.Value, 0);
		}

		// Token: 0x06002278 RID: 8824 RVA: 0x0008CB80 File Offset: 0x0008AF80
		public static void AddIceAttack(FlatBufferBuilder builder, Offset<UnionCell> IceAttackOffset)
		{
			builder.AddOffset(36, IceAttackOffset.Value, 0);
		}

		// Token: 0x06002279 RID: 8825 RVA: 0x0008CB92 File Offset: 0x0008AF92
		public static void AddDarkAttack(FlatBufferBuilder builder, Offset<UnionCell> DarkAttackOffset)
		{
			builder.AddOffset(37, DarkAttackOffset.Value, 0);
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x0008CBA4 File Offset: 0x0008AFA4
		public static void AddLightDefence(FlatBufferBuilder builder, Offset<UnionCell> LightDefenceOffset)
		{
			builder.AddOffset(38, LightDefenceOffset.Value, 0);
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x0008CBB6 File Offset: 0x0008AFB6
		public static void AddFireDefence(FlatBufferBuilder builder, Offset<UnionCell> FireDefenceOffset)
		{
			builder.AddOffset(39, FireDefenceOffset.Value, 0);
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x0008CBC8 File Offset: 0x0008AFC8
		public static void AddIceDefence(FlatBufferBuilder builder, Offset<UnionCell> IceDefenceOffset)
		{
			builder.AddOffset(40, IceDefenceOffset.Value, 0);
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x0008CBDA File Offset: 0x0008AFDA
		public static void AddDarkDefence(FlatBufferBuilder builder, Offset<UnionCell> DarkDefenceOffset)
		{
			builder.AddOffset(41, DarkDefenceOffset.Value, 0);
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x0008CBEC File Offset: 0x0008AFEC
		public static void AddUseSkillIDs(FlatBufferBuilder builder, VectorOffset UseSkillIDsOffset)
		{
			builder.AddOffset(42, UseSkillIDsOffset.Value, 0);
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x0008CC00 File Offset: 0x0008B000
		public static VectorOffset CreateUseSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x0008CC3D File Offset: 0x0008B03D
		public static void StartUseSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002281 RID: 8833 RVA: 0x0008CC48 File Offset: 0x0008B048
		public static void AddDispelBuffType(FlatBufferBuilder builder, int DispelBuffType)
		{
			builder.AddInt(43, DispelBuffType, 0);
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x0008CC54 File Offset: 0x0008B054
		public static void AddTriggerBuffInfoIDs(FlatBufferBuilder builder, VectorOffset TriggerBuffInfoIDsOffset)
		{
			builder.AddOffset(44, TriggerBuffInfoIDsOffset.Value, 0);
		}

		// Token: 0x06002283 RID: 8835 RVA: 0x0008CC68 File Offset: 0x0008B068
		public static VectorOffset CreateTriggerBuffInfoIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x0008CCA5 File Offset: 0x0008B0A5
		public static void StartTriggerBuffInfoIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x0008CCB0 File Offset: 0x0008B0B0
		public static void AddExitRemoveTrigger(FlatBufferBuilder builder, int ExitRemoveTrigger)
		{
			builder.AddInt(45, ExitRemoveTrigger, 0);
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x0008CCBC File Offset: 0x0008B0BC
		public static void AddMechanismID(FlatBufferBuilder builder, VectorOffset MechanismIDOffset)
		{
			builder.AddOffset(46, MechanismIDOffset.Value, 0);
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x0008CCD0 File Offset: 0x0008B0D0
		public static VectorOffset CreateMechanismIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x0008CD0D File Offset: 0x0008B10D
		public static void StartMechanismIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002289 RID: 8841 RVA: 0x0008CD18 File Offset: 0x0008B118
		public static void AddHp(FlatBufferBuilder builder, Offset<UnionCell> hpOffset)
		{
			builder.AddOffset(47, hpOffset.Value, 0);
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x0008CD2A File Offset: 0x0008B12A
		public static void AddMp(FlatBufferBuilder builder, Offset<UnionCell> mpOffset)
		{
			builder.AddOffset(48, mpOffset.Value, 0);
		}

		// Token: 0x0600228B RID: 8843 RVA: 0x0008CD3C File Offset: 0x0008B13C
		public static void AddHpRate(FlatBufferBuilder builder, Offset<UnionCell> hpRateOffset)
		{
			builder.AddOffset(49, hpRateOffset.Value, 0);
		}

		// Token: 0x0600228C RID: 8844 RVA: 0x0008CD4E File Offset: 0x0008B14E
		public static void AddMpRate(FlatBufferBuilder builder, Offset<UnionCell> mpRateOffset)
		{
			builder.AddOffset(50, mpRateOffset.Value, 0);
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x0008CD60 File Offset: 0x0008B160
		public static void AddCurrentHpRate(FlatBufferBuilder builder, Offset<UnionCell> currentHpRateOffset)
		{
			builder.AddOffset(51, currentHpRateOffset.Value, 0);
		}

		// Token: 0x0600228E RID: 8846 RVA: 0x0008CD72 File Offset: 0x0008B172
		public static void AddCurrentHpRateControl(FlatBufferBuilder builder, int currentHpRateControl)
		{
			builder.AddInt(52, currentHpRateControl, 0);
		}

		// Token: 0x0600228F RID: 8847 RVA: 0x0008CD7E File Offset: 0x0008B17E
		public static void AddBaseAtk(FlatBufferBuilder builder, Offset<UnionCell> baseAtkOffset)
		{
			builder.AddOffset(53, baseAtkOffset.Value, 0);
		}

		// Token: 0x06002290 RID: 8848 RVA: 0x0008CD90 File Offset: 0x0008B190
		public static void AddBaseInt(FlatBufferBuilder builder, Offset<UnionCell> baseIntOffset)
		{
			builder.AddOffset(54, baseIntOffset.Value, 0);
		}

		// Token: 0x06002291 RID: 8849 RVA: 0x0008CDA2 File Offset: 0x0008B1A2
		public static void AddSta(FlatBufferBuilder builder, Offset<UnionCell> staOffset)
		{
			builder.AddOffset(55, staOffset.Value, 0);
		}

		// Token: 0x06002292 RID: 8850 RVA: 0x0008CDB4 File Offset: 0x0008B1B4
		public static void AddSpr(FlatBufferBuilder builder, Offset<UnionCell> sprOffset)
		{
			builder.AddOffset(56, sprOffset.Value, 0);
		}

		// Token: 0x06002293 RID: 8851 RVA: 0x0008CDC6 File Offset: 0x0008B1C6
		public static void AddAtkAddRate(FlatBufferBuilder builder, Offset<UnionCell> atkAddRateOffset)
		{
			builder.AddOffset(57, atkAddRateOffset.Value, 0);
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x0008CDD8 File Offset: 0x0008B1D8
		public static void AddIntAddRate(FlatBufferBuilder builder, Offset<UnionCell> intAddRateOffset)
		{
			builder.AddOffset(58, intAddRateOffset.Value, 0);
		}

		// Token: 0x06002295 RID: 8853 RVA: 0x0008CDEA File Offset: 0x0008B1EA
		public static void AddStaAddRate(FlatBufferBuilder builder, Offset<UnionCell> staAddRateOffset)
		{
			builder.AddOffset(59, staAddRateOffset.Value, 0);
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x0008CDFC File Offset: 0x0008B1FC
		public static void AddSprAddRate(FlatBufferBuilder builder, Offset<UnionCell> sprAddRateOffset)
		{
			builder.AddOffset(60, sprAddRateOffset.Value, 0);
		}

		// Token: 0x06002297 RID: 8855 RVA: 0x0008CE0E File Offset: 0x0008B20E
		public static void AddMaxHp(FlatBufferBuilder builder, Offset<UnionCell> maxHpOffset)
		{
			builder.AddOffset(61, maxHpOffset.Value, 0);
		}

		// Token: 0x06002298 RID: 8856 RVA: 0x0008CE20 File Offset: 0x0008B220
		public static void AddMaxMp(FlatBufferBuilder builder, Offset<UnionCell> maxMpOffset)
		{
			builder.AddOffset(62, maxMpOffset.Value, 0);
		}

		// Token: 0x06002299 RID: 8857 RVA: 0x0008CE32 File Offset: 0x0008B232
		public static void AddMaxHpAddRate(FlatBufferBuilder builder, Offset<UnionCell> maxHpAddRateOffset)
		{
			builder.AddOffset(63, maxHpAddRateOffset.Value, 0);
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x0008CE44 File Offset: 0x0008B244
		public static void AddMaxMpAddRate(FlatBufferBuilder builder, Offset<UnionCell> maxMpAddRateOffset)
		{
			builder.AddOffset(64, maxMpAddRateOffset.Value, 0);
		}

		// Token: 0x0600229B RID: 8859 RVA: 0x0008CE56 File Offset: 0x0008B256
		public static void AddHpRecover(FlatBufferBuilder builder, Offset<UnionCell> hpRecoverOffset)
		{
			builder.AddOffset(65, hpRecoverOffset.Value, 0);
		}

		// Token: 0x0600229C RID: 8860 RVA: 0x0008CE68 File Offset: 0x0008B268
		public static void AddMpRecover(FlatBufferBuilder builder, Offset<UnionCell> mpRecoverOffset)
		{
			builder.AddOffset(66, mpRecoverOffset.Value, 0);
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x0008CE7A File Offset: 0x0008B27A
		public static void AddAttack(FlatBufferBuilder builder, Offset<UnionCell> attackOffset)
		{
			builder.AddOffset(67, attackOffset.Value, 0);
		}

		// Token: 0x0600229E RID: 8862 RVA: 0x0008CE8C File Offset: 0x0008B28C
		public static void AddMagicAttack(FlatBufferBuilder builder, Offset<UnionCell> magicAttackOffset)
		{
			builder.AddOffset(68, magicAttackOffset.Value, 0);
		}

		// Token: 0x0600229F RID: 8863 RVA: 0x0008CE9E File Offset: 0x0008B29E
		public static void AddDefence(FlatBufferBuilder builder, Offset<UnionCell> defenceOffset)
		{
			builder.AddOffset(69, defenceOffset.Value, 0);
		}

		// Token: 0x060022A0 RID: 8864 RVA: 0x0008CEB0 File Offset: 0x0008B2B0
		public static void AddMagicDefence(FlatBufferBuilder builder, Offset<UnionCell> magicDefenceOffset)
		{
			builder.AddOffset(70, magicDefenceOffset.Value, 0);
		}

		// Token: 0x060022A1 RID: 8865 RVA: 0x0008CEC2 File Offset: 0x0008B2C2
		public static void AddAttackSpeed(FlatBufferBuilder builder, Offset<UnionCell> attackSpeedOffset)
		{
			builder.AddOffset(71, attackSpeedOffset.Value, 0);
		}

		// Token: 0x060022A2 RID: 8866 RVA: 0x0008CED4 File Offset: 0x0008B2D4
		public static void AddSpellSpeed(FlatBufferBuilder builder, Offset<UnionCell> spellSpeedOffset)
		{
			builder.AddOffset(72, spellSpeedOffset.Value, 0);
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x0008CEE6 File Offset: 0x0008B2E6
		public static void AddMoveSpeed(FlatBufferBuilder builder, Offset<UnionCell> moveSpeedOffset)
		{
			builder.AddOffset(73, moveSpeedOffset.Value, 0);
		}

		// Token: 0x060022A4 RID: 8868 RVA: 0x0008CEF8 File Offset: 0x0008B2F8
		public static void AddCiriticalAttack(FlatBufferBuilder builder, Offset<UnionCell> ciriticalAttackOffset)
		{
			builder.AddOffset(74, ciriticalAttackOffset.Value, 0);
		}

		// Token: 0x060022A5 RID: 8869 RVA: 0x0008CF0A File Offset: 0x0008B30A
		public static void AddCiriticalMagicAttack(FlatBufferBuilder builder, Offset<UnionCell> ciriticalMagicAttackOffset)
		{
			builder.AddOffset(75, ciriticalMagicAttackOffset.Value, 0);
		}

		// Token: 0x060022A6 RID: 8870 RVA: 0x0008CF1C File Offset: 0x0008B31C
		public static void AddDex(FlatBufferBuilder builder, Offset<UnionCell> dexOffset)
		{
			builder.AddOffset(76, dexOffset.Value, 0);
		}

		// Token: 0x060022A7 RID: 8871 RVA: 0x0008CF2E File Offset: 0x0008B32E
		public static void AddDodge(FlatBufferBuilder builder, Offset<UnionCell> dodgeOffset)
		{
			builder.AddOffset(77, dodgeOffset.Value, 0);
		}

		// Token: 0x060022A8 RID: 8872 RVA: 0x0008CF40 File Offset: 0x0008B340
		public static void AddFrozen(FlatBufferBuilder builder, Offset<UnionCell> frozenOffset)
		{
			builder.AddOffset(78, frozenOffset.Value, 0);
		}

		// Token: 0x060022A9 RID: 8873 RVA: 0x0008CF52 File Offset: 0x0008B352
		public static void AddHard(FlatBufferBuilder builder, Offset<UnionCell> hardOffset)
		{
			builder.AddOffset(79, hardOffset.Value, 0);
		}

		// Token: 0x060022AA RID: 8874 RVA: 0x0008CF64 File Offset: 0x0008B364
		public static void AddAbnormalResist(FlatBufferBuilder builder, Offset<UnionCell> abnormalResistOffset)
		{
			builder.AddOffset(80, abnormalResistOffset.Value, 0);
		}

		// Token: 0x060022AB RID: 8875 RVA: 0x0008CF76 File Offset: 0x0008B376
		public static void AddAbnormalResist1(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist1Offset)
		{
			builder.AddOffset(81, abnormalResist1Offset.Value, 0);
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x0008CF88 File Offset: 0x0008B388
		public static void AddAbnormalResist2(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist2Offset)
		{
			builder.AddOffset(82, abnormalResist2Offset.Value, 0);
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x0008CF9A File Offset: 0x0008B39A
		public static void AddAbnormalResist3(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist3Offset)
		{
			builder.AddOffset(83, abnormalResist3Offset.Value, 0);
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x0008CFAC File Offset: 0x0008B3AC
		public static void AddAbnormalResist4(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist4Offset)
		{
			builder.AddOffset(84, abnormalResist4Offset.Value, 0);
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x0008CFBE File Offset: 0x0008B3BE
		public static void AddAbnormalResist5(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist5Offset)
		{
			builder.AddOffset(85, abnormalResist5Offset.Value, 0);
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x0008CFD0 File Offset: 0x0008B3D0
		public static void AddAbnormalResist6(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist6Offset)
		{
			builder.AddOffset(86, abnormalResist6Offset.Value, 0);
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x0008CFE2 File Offset: 0x0008B3E2
		public static void AddAbnormalResist7(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist7Offset)
		{
			builder.AddOffset(87, abnormalResist7Offset.Value, 0);
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x0008CFF4 File Offset: 0x0008B3F4
		public static void AddAbnormalResist8(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist8Offset)
		{
			builder.AddOffset(88, abnormalResist8Offset.Value, 0);
		}

		// Token: 0x060022B3 RID: 8883 RVA: 0x0008D006 File Offset: 0x0008B406
		public static void AddAbnormalResist9(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist9Offset)
		{
			builder.AddOffset(89, abnormalResist9Offset.Value, 0);
		}

		// Token: 0x060022B4 RID: 8884 RVA: 0x0008D018 File Offset: 0x0008B418
		public static void AddAbnormalResist10(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist10Offset)
		{
			builder.AddOffset(90, abnormalResist10Offset.Value, 0);
		}

		// Token: 0x060022B5 RID: 8885 RVA: 0x0008D02A File Offset: 0x0008B42A
		public static void AddAbnormalResist11(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist11Offset)
		{
			builder.AddOffset(91, abnormalResist11Offset.Value, 0);
		}

		// Token: 0x060022B6 RID: 8886 RVA: 0x0008D03C File Offset: 0x0008B43C
		public static void AddAbnormalResist12(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist12Offset)
		{
			builder.AddOffset(92, abnormalResist12Offset.Value, 0);
		}

		// Token: 0x060022B7 RID: 8887 RVA: 0x0008D04E File Offset: 0x0008B44E
		public static void AddAbnormalResist13(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist13Offset)
		{
			builder.AddOffset(93, abnormalResist13Offset.Value, 0);
		}

		// Token: 0x060022B8 RID: 8888 RVA: 0x0008D060 File Offset: 0x0008B460
		public static void AddCriticalPercent(FlatBufferBuilder builder, Offset<UnionCell> criticalPercentOffset)
		{
			builder.AddOffset(94, criticalPercentOffset.Value, 0);
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x0008D072 File Offset: 0x0008B472
		public static void AddCdReduceRate(FlatBufferBuilder builder, Offset<UnionCell> cdReduceRateOffset)
		{
			builder.AddOffset(95, cdReduceRateOffset.Value, 0);
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x0008D084 File Offset: 0x0008B484
		public static void AddAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> attackAddRateOffset)
		{
			builder.AddOffset(96, attackAddRateOffset.Value, 0);
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x0008D096 File Offset: 0x0008B496
		public static void AddMagicAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> magicAttackAddRateOffset)
		{
			builder.AddOffset(97, magicAttackAddRateOffset.Value, 0);
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x0008D0A8 File Offset: 0x0008B4A8
		public static void AddDefenceAddRate(FlatBufferBuilder builder, Offset<UnionCell> defenceAddRateOffset)
		{
			builder.AddOffset(98, defenceAddRateOffset.Value, 0);
		}

		// Token: 0x060022BD RID: 8893 RVA: 0x0008D0BA File Offset: 0x0008B4BA
		public static void AddMagicDefenceAddRate(FlatBufferBuilder builder, Offset<UnionCell> magicDefenceAddRateOffset)
		{
			builder.AddOffset(99, magicDefenceAddRateOffset.Value, 0);
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x0008D0CC File Offset: 0x0008B4CC
		public static void AddIgnoreDefAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> ignoreDefAttackAddRateOffset)
		{
			builder.AddOffset(100, ignoreDefAttackAddRateOffset.Value, 0);
		}

		// Token: 0x060022BF RID: 8895 RVA: 0x0008D0DE File Offset: 0x0008B4DE
		public static void AddIgnoreDefMagicAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> ignoreDefMagicAttackAddRateOffset)
		{
			builder.AddOffset(101, ignoreDefMagicAttackAddRateOffset.Value, 0);
		}

		// Token: 0x060022C0 RID: 8896 RVA: 0x0008D0F0 File Offset: 0x0008B4F0
		public static void AddAttachAddDamageFix(FlatBufferBuilder builder, Offset<UnionCell> attachAddDamageFixOffset)
		{
			builder.AddOffset(102, attachAddDamageFixOffset.Value, 0);
		}

		// Token: 0x060022C1 RID: 8897 RVA: 0x0008D102 File Offset: 0x0008B502
		public static void AddAttachAddDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> attachAddDamagePercentOffset)
		{
			builder.AddOffset(103, attachAddDamagePercentOffset.Value, 0);
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x0008D114 File Offset: 0x0008B514
		public static void AddAddDamageFix(FlatBufferBuilder builder, Offset<UnionCell> addDamageFixOffset)
		{
			builder.AddOffset(104, addDamageFixOffset.Value, 0);
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x0008D126 File Offset: 0x0008B526
		public static void AddAddDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> addDamagePercentOffset)
		{
			builder.AddOffset(105, addDamagePercentOffset.Value, 0);
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x0008D138 File Offset: 0x0008B538
		public static void AddReduceDamageFix(FlatBufferBuilder builder, Offset<UnionCell> reduceDamageFixOffset)
		{
			builder.AddOffset(106, reduceDamageFixOffset.Value, 0);
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x0008D14A File Offset: 0x0008B54A
		public static void AddReduceDamageFixType(FlatBufferBuilder builder, int reduceDamageFixType)
		{
			builder.AddInt(107, reduceDamageFixType, 0);
		}

		// Token: 0x060022C6 RID: 8902 RVA: 0x0008D156 File Offset: 0x0008B556
		public static void AddReduceDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> reduceDamagePercentOffset)
		{
			builder.AddOffset(108, reduceDamagePercentOffset.Value, 0);
		}

		// Token: 0x060022C7 RID: 8903 RVA: 0x0008D168 File Offset: 0x0008B568
		public static void AddReduceDamagePercentType(FlatBufferBuilder builder, int reduceDamagePercentType)
		{
			builder.AddInt(109, reduceDamagePercentType, 0);
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x0008D174 File Offset: 0x0008B574
		public static void AddReflectDamageFix(FlatBufferBuilder builder, Offset<UnionCell> reflectDamageFixOffset)
		{
			builder.AddOffset(110, reflectDamageFixOffset.Value, 0);
		}

		// Token: 0x060022C9 RID: 8905 RVA: 0x0008D186 File Offset: 0x0008B586
		public static void AddReflectDamageFixType(FlatBufferBuilder builder, int reflectDamageFixType)
		{
			builder.AddInt(111, reflectDamageFixType, 0);
		}

		// Token: 0x060022CA RID: 8906 RVA: 0x0008D192 File Offset: 0x0008B592
		public static void AddReflectDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> reflectDamagePercentOffset)
		{
			builder.AddOffset(112, reflectDamagePercentOffset.Value, 0);
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x0008D1A4 File Offset: 0x0008B5A4
		public static void AddReflectDamagePercentType(FlatBufferBuilder builder, int reflectDamagePercentType)
		{
			builder.AddInt(113, reflectDamagePercentType, 0);
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x0008D1B0 File Offset: 0x0008B5B0
		public static void AddLevel(FlatBufferBuilder builder, Offset<UnionCell> levelOffset)
		{
			builder.AddOffset(114, levelOffset.Value, 0);
		}

		// Token: 0x060022CD RID: 8909 RVA: 0x0008D1C2 File Offset: 0x0008B5C2
		public static void AddSkillMpCostReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillMpCostReduceRateOffset)
		{
			builder.AddOffset(115, skillMpCostReduceRateOffset.Value, 0);
		}

		// Token: 0x060022CE RID: 8910 RVA: 0x0008D1D4 File Offset: 0x0008B5D4
		public static void AddSkillCdReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillCdReduceRateOffset)
		{
			builder.AddOffset(116, skillCdReduceRateOffset.Value, 0);
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x0008D1E6 File Offset: 0x0008B5E6
		public static void AddSkillCdReduceValue(FlatBufferBuilder builder, Offset<UnionCell> skillCdReduceValueOffset)
		{
			builder.AddOffset(117, skillCdReduceValueOffset.Value, 0);
		}

		// Token: 0x060022D0 RID: 8912 RVA: 0x0008D1F8 File Offset: 0x0008B5F8
		public static void AddSkillSpeedAddFactor(FlatBufferBuilder builder, Offset<UnionCell> skillSpeedAddFactorOffset)
		{
			builder.AddOffset(118, skillSpeedAddFactorOffset.Value, 0);
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x0008D20A File Offset: 0x0008B60A
		public static void AddSkillHitRateAdd(FlatBufferBuilder builder, Offset<UnionCell> skillHitRateAddOffset)
		{
			builder.AddOffset(119, skillHitRateAddOffset.Value, 0);
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x0008D21C File Offset: 0x0008B61C
		public static void AddSkillCriticalHitRateAdd(FlatBufferBuilder builder, Offset<UnionCell> skillCriticalHitRateAddOffset)
		{
			builder.AddOffset(120, skillCriticalHitRateAddOffset.Value, 0);
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x0008D22E File Offset: 0x0008B62E
		public static void AddSkillAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddRateOffset)
		{
			builder.AddOffset(121, skillAttackAddRateOffset.Value, 0);
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x0008D240 File Offset: 0x0008B640
		public static void AddSkillAttackAdd(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddOffset)
		{
			builder.AddOffset(122, skillAttackAddOffset.Value, 0);
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x0008D252 File Offset: 0x0008B652
		public static void AddSkillAttackAddFix(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddFixOffset)
		{
			builder.AddOffset(123, skillAttackAddFixOffset.Value, 0);
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x0008D264 File Offset: 0x0008B664
		public static void AddSkillHardAddRate(FlatBufferBuilder builder, Offset<UnionCell> skillHardAddRateOffset)
		{
			builder.AddOffset(124, skillHardAddRateOffset.Value, 0);
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x0008D276 File Offset: 0x0008B676
		public static void AddSkillChargeReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillChargeReduceRateOffset)
		{
			builder.AddOffset(125, skillChargeReduceRateOffset.Value, 0);
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x0008D288 File Offset: 0x0008B688
		public static void AddResistMagic(FlatBufferBuilder builder, Offset<UnionCell> ResistMagicOffset)
		{
			builder.AddOffset(126, ResistMagicOffset.Value, 0);
		}

		// Token: 0x060022D9 RID: 8921 RVA: 0x0008D29A File Offset: 0x0008B69A
		public static void AddAiWarlike(FlatBufferBuilder builder, Offset<UnionCell> aiWarlikeOffset)
		{
			builder.AddOffset(127, aiWarlikeOffset.Value, 0);
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x0008D2AC File Offset: 0x0008B6AC
		public static void AddAiSight(FlatBufferBuilder builder, Offset<UnionCell> aiSightOffset)
		{
			builder.AddOffset(128, aiSightOffset.Value, 0);
		}

		// Token: 0x060022DB RID: 8923 RVA: 0x0008D2C1 File Offset: 0x0008B6C1
		public static void AddAiAttackProb(FlatBufferBuilder builder, Offset<UnionCell> aiAttackProbOffset)
		{
			builder.AddOffset(129, aiAttackProbOffset.Value, 0);
		}

		// Token: 0x060022DC RID: 8924 RVA: 0x0008D2D6 File Offset: 0x0008B6D6
		public static void AddSummonMonsterID(FlatBufferBuilder builder, int summonMonsterID)
		{
			builder.AddInt(130, summonMonsterID, 0);
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x0008D2E5 File Offset: 0x0008B6E5
		public static void AddSummonMonsterLevel(FlatBufferBuilder builder, int summonMonsterLevel)
		{
			builder.AddInt(131, summonMonsterLevel, 0);
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x0008D2F4 File Offset: 0x0008B6F4
		public static void AddSummonExistTime(FlatBufferBuilder builder, int summonExistTime)
		{
			builder.AddInt(132, summonExistTime, 0);
		}

		// Token: 0x060022DF RID: 8927 RVA: 0x0008D303 File Offset: 0x0008B703
		public static void AddSummonPosType(FlatBufferBuilder builder, int summonPosType)
		{
			builder.AddInt(133, summonPosType, 0);
		}

		// Token: 0x060022E0 RID: 8928 RVA: 0x0008D312 File Offset: 0x0008B712
		public static void AddSummonPosType2(FlatBufferBuilder builder, VectorOffset summonPosType2Offset)
		{
			builder.AddOffset(134, summonPosType2Offset.Value, 0);
		}

		// Token: 0x060022E1 RID: 8929 RVA: 0x0008D328 File Offset: 0x0008B728
		public static VectorOffset CreateSummonPosType2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060022E2 RID: 8930 RVA: 0x0008D365 File Offset: 0x0008B765
		public static void StartSummonPosType2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060022E3 RID: 8931 RVA: 0x0008D370 File Offset: 0x0008B770
		public static void AddSummonDisplay(FlatBufferBuilder builder, int summonDisplay)
		{
			builder.AddInt(135, summonDisplay, 0);
		}

		// Token: 0x060022E4 RID: 8932 RVA: 0x0008D37F File Offset: 0x0008B77F
		public static void AddSummonNum(FlatBufferBuilder builder, int summonNum)
		{
			builder.AddInt(136, summonNum, 0);
		}

		// Token: 0x060022E5 RID: 8933 RVA: 0x0008D38E File Offset: 0x0008B78E
		public static void AddSummonRelation(FlatBufferBuilder builder, int summonRelation)
		{
			builder.AddInt(137, summonRelation, 0);
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x0008D39D File Offset: 0x0008B79D
		public static void AddSummonNumLimit(FlatBufferBuilder builder, int summonNumLimit)
		{
			builder.AddInt(138, summonNumLimit, 0);
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x0008D3AC File Offset: 0x0008B7AC
		public static void AddSummonEntity(FlatBufferBuilder builder, VectorOffset summonEntityOffset)
		{
			builder.AddOffset(139, summonEntityOffset.Value, 0);
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x0008D3C4 File Offset: 0x0008B7C4
		public static VectorOffset CreateSummonEntityVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x0008D401 File Offset: 0x0008B801
		public static void StartSummonEntityVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x0008D40C File Offset: 0x0008B80C
		public static void AddDuplicatePercent(FlatBufferBuilder builder, int duplicatePercent)
		{
			builder.AddInt(140, duplicatePercent, 0);
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x0008D41B File Offset: 0x0008B81B
		public static void AddDuplicateMax(FlatBufferBuilder builder, int duplicateMax)
		{
			builder.AddInt(141, duplicateMax, 0);
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x0008D42A File Offset: 0x0008B82A
		public static void AddExpAddRate(FlatBufferBuilder builder, Offset<UnionCell> expAddRateOffset)
		{
			builder.AddOffset(142, expAddRateOffset.Value, 0);
		}

		// Token: 0x060022ED RID: 8941 RVA: 0x0008D43F File Offset: 0x0008B83F
		public static void AddGoldAddRate(FlatBufferBuilder builder, Offset<UnionCell> goldAddRateOffset)
		{
			builder.AddOffset(143, goldAddRateOffset.Value, 0);
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x0008D454 File Offset: 0x0008B854
		public static void AddTaskDropAddRate(FlatBufferBuilder builder, int taskDropAddRate)
		{
			builder.AddInt(144, taskDropAddRate, 0);
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x0008D463 File Offset: 0x0008B863
		public static void AddPinkDropAddRate(FlatBufferBuilder builder, int PinkDropAddRate)
		{
			builder.AddInt(145, PinkDropAddRate, 0);
		}

		// Token: 0x060022F0 RID: 8944 RVA: 0x0008D472 File Offset: 0x0008B872
		public static void AddChestDropAddRate(FlatBufferBuilder builder, int ChestDropAddRate)
		{
			builder.AddInt(146, ChestDropAddRate, 0);
		}

		// Token: 0x060022F1 RID: 8945 RVA: 0x0008D481 File Offset: 0x0008B881
		public static void AddDurationType(FlatBufferBuilder builder, int durationType)
		{
			builder.AddInt(147, durationType, 0);
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x0008D490 File Offset: 0x0008B890
		public static void AddDuration(FlatBufferBuilder builder, int duration)
		{
			builder.AddInt(148, duration, 0);
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x0008D49F File Offset: 0x0008B89F
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(149, DescriptionAOffset.Value, 0);
		}

		// Token: 0x060022F4 RID: 8948 RVA: 0x0008D4B4 File Offset: 0x0008B8B4
		public static void AddValueA(FlatBufferBuilder builder, VectorOffset ValueAOffset)
		{
			builder.AddOffset(150, ValueAOffset.Value, 0);
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x0008D4CC File Offset: 0x0008B8CC
		public static VectorOffset CreateValueAVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x0008D512 File Offset: 0x0008B912
		public static void StartValueAVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060022F7 RID: 8951 RVA: 0x0008D51D File Offset: 0x0008B91D
		public static void AddDescriptionB(FlatBufferBuilder builder, StringOffset DescriptionBOffset)
		{
			builder.AddOffset(151, DescriptionBOffset.Value, 0);
		}

		// Token: 0x060022F8 RID: 8952 RVA: 0x0008D532 File Offset: 0x0008B932
		public static void AddValueB(FlatBufferBuilder builder, VectorOffset ValueBOffset)
		{
			builder.AddOffset(152, ValueBOffset.Value, 0);
		}

		// Token: 0x060022F9 RID: 8953 RVA: 0x0008D548 File Offset: 0x0008B948
		public static VectorOffset CreateValueBVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060022FA RID: 8954 RVA: 0x0008D58E File Offset: 0x0008B98E
		public static void StartValueBVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x0008D599 File Offset: 0x0008B999
		public static void AddDescriptionC(FlatBufferBuilder builder, StringOffset DescriptionCOffset)
		{
			builder.AddOffset(153, DescriptionCOffset.Value, 0);
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x0008D5AE File Offset: 0x0008B9AE
		public static void AddValueC(FlatBufferBuilder builder, VectorOffset ValueCOffset)
		{
			builder.AddOffset(154, ValueCOffset.Value, 0);
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x0008D5C4 File Offset: 0x0008B9C4
		public static VectorOffset CreateValueCVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x0008D60A File Offset: 0x0008BA0A
		public static void StartValueCVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060022FF RID: 8959 RVA: 0x0008D615 File Offset: 0x0008BA15
		public static void AddDescriptionD(FlatBufferBuilder builder, StringOffset DescriptionDOffset)
		{
			builder.AddOffset(155, DescriptionDOffset.Value, 0);
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x0008D62A File Offset: 0x0008BA2A
		public static void AddValueD(FlatBufferBuilder builder, VectorOffset ValueDOffset)
		{
			builder.AddOffset(156, ValueDOffset.Value, 0);
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x0008D640 File Offset: 0x0008BA40
		public static VectorOffset CreateValueDVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x0008D686 File Offset: 0x0008BA86
		public static void StartValueDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x0008D691 File Offset: 0x0008BA91
		public static void AddDescriptionE(FlatBufferBuilder builder, StringOffset DescriptionEOffset)
		{
			builder.AddOffset(157, DescriptionEOffset.Value, 0);
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x0008D6A6 File Offset: 0x0008BAA6
		public static void AddValueE(FlatBufferBuilder builder, VectorOffset ValueEOffset)
		{
			builder.AddOffset(158, ValueEOffset.Value, 0);
		}

		// Token: 0x06002305 RID: 8965 RVA: 0x0008D6BC File Offset: 0x0008BABC
		public static VectorOffset CreateValueEVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002306 RID: 8966 RVA: 0x0008D702 File Offset: 0x0008BB02
		public static void StartValueEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x0008D70D File Offset: 0x0008BB0D
		public static void AddDescriptionF(FlatBufferBuilder builder, StringOffset DescriptionFOffset)
		{
			builder.AddOffset(159, DescriptionFOffset.Value, 0);
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x0008D722 File Offset: 0x0008BB22
		public static void AddValueF(FlatBufferBuilder builder, VectorOffset ValueFOffset)
		{
			builder.AddOffset(160, ValueFOffset.Value, 0);
		}

		// Token: 0x06002309 RID: 8969 RVA: 0x0008D738 File Offset: 0x0008BB38
		public static VectorOffset CreateValueFVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600230A RID: 8970 RVA: 0x0008D77E File Offset: 0x0008BB7E
		public static void StartValueFVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600230B RID: 8971 RVA: 0x0008D789 File Offset: 0x0008BB89
		public static void AddDescriptionG(FlatBufferBuilder builder, StringOffset DescriptionGOffset)
		{
			builder.AddOffset(161, DescriptionGOffset.Value, 0);
		}

		// Token: 0x0600230C RID: 8972 RVA: 0x0008D79E File Offset: 0x0008BB9E
		public static void AddValueG(FlatBufferBuilder builder, VectorOffset ValueGOffset)
		{
			builder.AddOffset(162, ValueGOffset.Value, 0);
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x0008D7B4 File Offset: 0x0008BBB4
		public static VectorOffset CreateValueGVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x0008D7FA File Offset: 0x0008BBFA
		public static void StartValueGVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x0008D805 File Offset: 0x0008BC05
		public static void AddEffectTimes(FlatBufferBuilder builder, int EffectTimes)
		{
			builder.AddInt(163, EffectTimes, 0);
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x0008D814 File Offset: 0x0008BC14
		public static void AddApplyDungeon(FlatBufferBuilder builder, StringOffset ApplyDungeonOffset)
		{
			builder.AddOffset(164, ApplyDungeonOffset.Value, 0);
		}

		// Token: 0x06002311 RID: 8977 RVA: 0x0008D829 File Offset: 0x0008BC29
		public static void AddParam1(FlatBufferBuilder builder, int param1)
		{
			builder.AddInt(165, param1, 0);
		}

		// Token: 0x06002312 RID: 8978 RVA: 0x0008D838 File Offset: 0x0008BC38
		public static void AddParam2(FlatBufferBuilder builder, int param2)
		{
			builder.AddInt(166, param2, 0);
		}

		// Token: 0x06002313 RID: 8979 RVA: 0x0008D848 File Offset: 0x0008BC48
		public static Offset<ChijiBuffTable> EndChijiBuffTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiBuffTable>(value);
		}

		// Token: 0x06002314 RID: 8980 RVA: 0x0008D862 File Offset: 0x0008BC62
		public static void FinishChijiBuffTableBuffer(FlatBufferBuilder builder, Offset<ChijiBuffTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001002 RID: 4098
		private Table __p = new Table();

		// Token: 0x04001003 RID: 4099
		private FlatBufferArray<int> TargetStateValue;

		// Token: 0x04001004 RID: 4100
		private FlatBufferArray<int> StateChangeValue;

		// Token: 0x04001005 RID: 4101
		private FlatBufferArray<int> AbilityChangeValue;

		// Token: 0x04001006 RID: 4102
		private FlatBufferArray<int> ElementsValue;

		// Token: 0x04001007 RID: 4103
		private FlatBufferArray<int> UseSkillIDsValue;

		// Token: 0x04001008 RID: 4104
		private FlatBufferArray<int> TriggerBuffInfoIDsValue;

		// Token: 0x04001009 RID: 4105
		private FlatBufferArray<int> MechanismIDValue;

		// Token: 0x0400100A RID: 4106
		private FlatBufferArray<int> summon_posType2Value;

		// Token: 0x0400100B RID: 4107
		private FlatBufferArray<int> summon_entityValue;

		// Token: 0x0400100C RID: 4108
		private FlatBufferArray<UnionCell> ValueAValue;

		// Token: 0x0400100D RID: 4109
		private FlatBufferArray<UnionCell> ValueBValue;

		// Token: 0x0400100E RID: 4110
		private FlatBufferArray<UnionCell> ValueCValue;

		// Token: 0x0400100F RID: 4111
		private FlatBufferArray<UnionCell> ValueDValue;

		// Token: 0x04001010 RID: 4112
		private FlatBufferArray<UnionCell> ValueEValue;

		// Token: 0x04001011 RID: 4113
		private FlatBufferArray<UnionCell> ValueFValue;

		// Token: 0x04001012 RID: 4114
		private FlatBufferArray<UnionCell> ValueGValue;

		// Token: 0x0200033D RID: 829
		public enum eCrypt
		{
			// Token: 0x04001014 RID: 4116
			code = -261708052
		}
	}
}
