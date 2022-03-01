using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004BA RID: 1210
	public class ItemTable : IFlatbufferObject
	{
		// Token: 0x17000EF8 RID: 3832
		// (get) Token: 0x06003AF6 RID: 15094 RVA: 0x000C5A74 File Offset: 0x000C3E74
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003AF7 RID: 15095 RVA: 0x000C5A81 File Offset: 0x000C3E81
		public static ItemTable GetRootAsItemTable(ByteBuffer _bb)
		{
			return ItemTable.GetRootAsItemTable(_bb, new ItemTable());
		}

		// Token: 0x06003AF8 RID: 15096 RVA: 0x000C5A8E File Offset: 0x000C3E8E
		public static ItemTable GetRootAsItemTable(ByteBuffer _bb, ItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003AF9 RID: 15097 RVA: 0x000C5AAA File Offset: 0x000C3EAA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003AFA RID: 15098 RVA: 0x000C5AC4 File Offset: 0x000C3EC4
		public ItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EF9 RID: 3833
		// (get) Token: 0x06003AFB RID: 15099 RVA: 0x000C5AD0 File Offset: 0x000C3ED0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EFA RID: 3834
		// (get) Token: 0x06003AFC RID: 15100 RVA: 0x000C5B1C File Offset: 0x000C3F1C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003AFD RID: 15101 RVA: 0x000C5B5E File Offset: 0x000C3F5E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000EFB RID: 3835
		// (get) Token: 0x06003AFE RID: 15102 RVA: 0x000C5B6C File Offset: 0x000C3F6C
		public int IdSequence
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EFC RID: 3836
		// (get) Token: 0x06003AFF RID: 15103 RVA: 0x000C5BB8 File Offset: 0x000C3FB8
		public ItemTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(10);
				return (ItemTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EFD RID: 3837
		// (get) Token: 0x06003B00 RID: 15104 RVA: 0x000C5BFC File Offset: 0x000C3FFC
		public string TypeName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B01 RID: 15105 RVA: 0x000C5C3F File Offset: 0x000C403F
		public ArraySegment<byte>? GetTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000EFE RID: 3838
		// (get) Token: 0x06003B02 RID: 15106 RVA: 0x000C5C50 File Offset: 0x000C4050
		public ItemTable.eEPrompt EPrompt
		{
			get
			{
				int num = this.__p.__offset(14);
				return (ItemTable.eEPrompt)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EFF RID: 3839
		// (get) Token: 0x06003B03 RID: 15107 RVA: 0x000C5C94 File Offset: 0x000C4094
		public ItemTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ItemTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F00 RID: 3840
		// (get) Token: 0x06003B04 RID: 15108 RVA: 0x000C5CD8 File Offset: 0x000C40D8
		public string SubTypeName
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B05 RID: 15109 RVA: 0x000C5D1B File Offset: 0x000C411B
		public ArraySegment<byte>? GetSubTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000F01 RID: 3841
		// (get) Token: 0x06003B06 RID: 15110 RVA: 0x000C5D2C File Offset: 0x000C412C
		public ItemTable.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (ItemTable.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F02 RID: 3842
		// (get) Token: 0x06003B07 RID: 15111 RVA: 0x000C5D70 File Offset: 0x000C4170
		public string ThirdTypeName
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B08 RID: 15112 RVA: 0x000C5DB3 File Offset: 0x000C41B3
		public ArraySegment<byte>? GetThirdTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x06003B09 RID: 15113 RVA: 0x000C5DC4 File Offset: 0x000C41C4
		public int OccuArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F03 RID: 3843
		// (get) Token: 0x06003B0A RID: 15114 RVA: 0x000C5E14 File Offset: 0x000C4214
		public int OccuLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B0B RID: 15115 RVA: 0x000C5E47 File Offset: 0x000C4247
		public ArraySegment<byte>? GetOccuBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000F04 RID: 3844
		// (get) Token: 0x06003B0C RID: 15116 RVA: 0x000C5E56 File Offset: 0x000C4256
		public FlatBufferArray<int> Occu
		{
			get
			{
				if (this.OccuValue == null)
				{
					this.OccuValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuArray), this.OccuLength);
				}
				return this.OccuValue;
			}
		}

		// Token: 0x06003B0D RID: 15117 RVA: 0x000C5E88 File Offset: 0x000C4288
		public int Occu2Array(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x06003B0E RID: 15118 RVA: 0x000C5ED8 File Offset: 0x000C42D8
		public int Occu2Length
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B0F RID: 15119 RVA: 0x000C5F0B File Offset: 0x000C430B
		public ArraySegment<byte>? GetOccu2Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000F06 RID: 3846
		// (get) Token: 0x06003B10 RID: 15120 RVA: 0x000C5F1A File Offset: 0x000C431A
		public FlatBufferArray<int> Occu2
		{
			get
			{
				if (this.Occu2Value == null)
				{
					this.Occu2Value = new FlatBufferArray<int>(new Func<int, int>(this.Occu2Array), this.Occu2Length);
				}
				return this.Occu2Value;
			}
		}

		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x06003B11 RID: 15121 RVA: 0x000C5F4C File Offset: 0x000C434C
		public ItemTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(28);
				return (ItemTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x06003B12 RID: 15122 RVA: 0x000C5F90 File Offset: 0x000C4390
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F09 RID: 3849
		// (get) Token: 0x06003B13 RID: 15123 RVA: 0x000C5FDC File Offset: 0x000C43DC
		public int NeedLevel
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F0A RID: 3850
		// (get) Token: 0x06003B14 RID: 15124 RVA: 0x000C6028 File Offset: 0x000C4428
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F0B RID: 3851
		// (get) Token: 0x06003B15 RID: 15125 RVA: 0x000C6074 File Offset: 0x000C4474
		public int BaseAttackSpeedRate
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F0C RID: 3852
		// (get) Token: 0x06003B16 RID: 15126 RVA: 0x000C60C0 File Offset: 0x000C44C0
		public ItemTable.eCanUse CanUse
		{
			get
			{
				int num = this.__p.__offset(38);
				return (ItemTable.eCanUse)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F0D RID: 3853
		// (get) Token: 0x06003B17 RID: 15127 RVA: 0x000C6104 File Offset: 0x000C4504
		public bool CanTrade
		{
			get
			{
				int num = this.__p.__offset(40);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F0E RID: 3854
		// (get) Token: 0x06003B18 RID: 15128 RVA: 0x000C6150 File Offset: 0x000C4550
		public ItemTable.eOwner Owner
		{
			get
			{
				int num = this.__p.__offset(42);
				return (ItemTable.eOwner)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F0F RID: 3855
		// (get) Token: 0x06003B19 RID: 15129 RVA: 0x000C6194 File Offset: 0x000C4594
		public bool IsSeal
		{
			get
			{
				int num = this.__p.__offset(44);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F10 RID: 3856
		// (get) Token: 0x06003B1A RID: 15130 RVA: 0x000C61E0 File Offset: 0x000C45E0
		public int SealMax
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F11 RID: 3857
		// (get) Token: 0x06003B1B RID: 15131 RVA: 0x000C622C File Offset: 0x000C462C
		public bool IsDecompose
		{
			get
			{
				int num = this.__p.__offset(48);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F12 RID: 3858
		// (get) Token: 0x06003B1C RID: 15132 RVA: 0x000C6278 File Offset: 0x000C4678
		public int SellItemID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F13 RID: 3859
		// (get) Token: 0x06003B1D RID: 15133 RVA: 0x000C62C4 File Offset: 0x000C46C4
		public int Price
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F14 RID: 3860
		// (get) Token: 0x06003B1E RID: 15134 RVA: 0x000C6310 File Offset: 0x000C4710
		public int CdGroup
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F15 RID: 3861
		// (get) Token: 0x06003B1F RID: 15135 RVA: 0x000C635C File Offset: 0x000C475C
		public int CoolTime
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F16 RID: 3862
		// (get) Token: 0x06003B20 RID: 15136 RVA: 0x000C63A8 File Offset: 0x000C47A8
		public int TimeLeft
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F17 RID: 3863
		// (get) Token: 0x06003B21 RID: 15137 RVA: 0x000C63F4 File Offset: 0x000C47F4
		public int MaxNum
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F18 RID: 3864
		// (get) Token: 0x06003B22 RID: 15138 RVA: 0x000C6440 File Offset: 0x000C4840
		public string EffectDescription
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B23 RID: 15139 RVA: 0x000C6483 File Offset: 0x000C4883
		public ArraySegment<byte>? GetEffectDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x17000F19 RID: 3865
		// (get) Token: 0x06003B24 RID: 15140 RVA: 0x000C6494 File Offset: 0x000C4894
		public string Description
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B25 RID: 15141 RVA: 0x000C64D7 File Offset: 0x000C48D7
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x06003B26 RID: 15142 RVA: 0x000C64E8 File Offset: 0x000C48E8
		public int ComeLinkArray(int j)
		{
			int num = this.__p.__offset(66);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F1A RID: 3866
		// (get) Token: 0x06003B27 RID: 15143 RVA: 0x000C6538 File Offset: 0x000C4938
		public int ComeLinkLength
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B28 RID: 15144 RVA: 0x000C656B File Offset: 0x000C496B
		public ArraySegment<byte>? GetComeLinkBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x17000F1B RID: 3867
		// (get) Token: 0x06003B29 RID: 15145 RVA: 0x000C657A File Offset: 0x000C497A
		public FlatBufferArray<int> ComeLink
		{
			get
			{
				if (this.ComeLinkValue == null)
				{
					this.ComeLinkValue = new FlatBufferArray<int>(new Func<int, int>(this.ComeLinkArray), this.ComeLinkLength);
				}
				return this.ComeLinkValue;
			}
		}

		// Token: 0x06003B2A RID: 15146 RVA: 0x000C65AC File Offset: 0x000C49AC
		public int RelationIDArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F1C RID: 3868
		// (get) Token: 0x06003B2B RID: 15147 RVA: 0x000C65FC File Offset: 0x000C49FC
		public int RelationIDLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B2C RID: 15148 RVA: 0x000C662F File Offset: 0x000C4A2F
		public ArraySegment<byte>? GetRelationIDBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x17000F1D RID: 3869
		// (get) Token: 0x06003B2D RID: 15149 RVA: 0x000C663E File Offset: 0x000C4A3E
		public FlatBufferArray<int> RelationID
		{
			get
			{
				if (this.RelationIDValue == null)
				{
					this.RelationIDValue = new FlatBufferArray<int>(new Func<int, int>(this.RelationIDArray), this.RelationIDLength);
				}
				return this.RelationIDValue;
			}
		}

		// Token: 0x17000F1E RID: 3870
		// (get) Token: 0x06003B2E RID: 15150 RVA: 0x000C6670 File Offset: 0x000C4A70
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B2F RID: 15151 RVA: 0x000C66B3 File Offset: 0x000C4AB3
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x17000F1F RID: 3871
		// (get) Token: 0x06003B30 RID: 15152 RVA: 0x000C66C4 File Offset: 0x000C4AC4
		public string ModelPath
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B31 RID: 15153 RVA: 0x000C6707 File Offset: 0x000C4B07
		public ArraySegment<byte>? GetModelPathBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x06003B32 RID: 15154 RVA: 0x000C6718 File Offset: 0x000C4B18
		public string Path2Array(int j)
		{
			int num = this.__p.__offset(74);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000F20 RID: 3872
		// (get) Token: 0x06003B33 RID: 15155 RVA: 0x000C6760 File Offset: 0x000C4B60
		public int Path2Length
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000F21 RID: 3873
		// (get) Token: 0x06003B34 RID: 15156 RVA: 0x000C6793 File Offset: 0x000C4B93
		public FlatBufferArray<string> Path2
		{
			get
			{
				if (this.Path2Value == null)
				{
					this.Path2Value = new FlatBufferArray<string>(new Func<int, string>(this.Path2Array), this.Path2Length);
				}
				return this.Path2Value;
			}
		}

		// Token: 0x17000F22 RID: 3874
		// (get) Token: 0x06003B35 RID: 15157 RVA: 0x000C67C4 File Offset: 0x000C4BC4
		public int OnUseBuffId
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F23 RID: 3875
		// (get) Token: 0x06003B36 RID: 15158 RVA: 0x000C6810 File Offset: 0x000C4C10
		public int OnGetBuffId
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F24 RID: 3876
		// (get) Token: 0x06003B37 RID: 15159 RVA: 0x000C685C File Offset: 0x000C4C5C
		public bool CanDungeonUse
		{
			get
			{
				int num = this.__p.__offset(80);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F25 RID: 3877
		// (get) Token: 0x06003B38 RID: 15160 RVA: 0x000C68A8 File Offset: 0x000C4CA8
		public bool CanPKUse
		{
			get
			{
				int num = this.__p.__offset(82);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F26 RID: 3878
		// (get) Token: 0x06003B39 RID: 15161 RVA: 0x000C68F4 File Offset: 0x000C4CF4
		public int RecommendPrice
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F27 RID: 3879
		// (get) Token: 0x06003B3A RID: 15162 RVA: 0x000C6940 File Offset: 0x000C4D40
		public ItemTable.eComeType ComeType
		{
			get
			{
				int num = this.__p.__offset(86);
				return (ItemTable.eComeType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F28 RID: 3880
		// (get) Token: 0x06003B3B RID: 15163 RVA: 0x000C6984 File Offset: 0x000C4D84
		public string ComeDesc
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B3C RID: 15164 RVA: 0x000C69C7 File Offset: 0x000C4DC7
		public ArraySegment<byte>? GetComeDescBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x17000F29 RID: 3881
		// (get) Token: 0x06003B3D RID: 15165 RVA: 0x000C69D8 File Offset: 0x000C4DD8
		public int ResID
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F2A RID: 3882
		// (get) Token: 0x06003B3E RID: 15166 RVA: 0x000C6A24 File Offset: 0x000C4E24
		public int Tag
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F2B RID: 3883
		// (get) Token: 0x06003B3F RID: 15167 RVA: 0x000C6A70 File Offset: 0x000C4E70
		public int SuitID
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F2C RID: 3884
		// (get) Token: 0x06003B40 RID: 15168 RVA: 0x000C6ABC File Offset: 0x000C4EBC
		public int EquipPropID
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003B41 RID: 15169 RVA: 0x000C6B08 File Offset: 0x000C4F08
		public int MutexBuffArray(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F2D RID: 3885
		// (get) Token: 0x06003B42 RID: 15170 RVA: 0x000C6B58 File Offset: 0x000C4F58
		public int MutexBuffLength
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B43 RID: 15171 RVA: 0x000C6B8B File Offset: 0x000C4F8B
		public ArraySegment<byte>? GetMutexBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x17000F2E RID: 3886
		// (get) Token: 0x06003B44 RID: 15172 RVA: 0x000C6B9A File Offset: 0x000C4F9A
		public FlatBufferArray<int> MutexBuff
		{
			get
			{
				if (this.MutexBuffValue == null)
				{
					this.MutexBuffValue = new FlatBufferArray<int>(new Func<int, int>(this.MutexBuffArray), this.MutexBuffLength);
				}
				return this.MutexBuffValue;
			}
		}

		// Token: 0x17000F2F RID: 3887
		// (get) Token: 0x06003B45 RID: 15173 RVA: 0x000C6BCC File Offset: 0x000C4FCC
		public bool CanAnnounce
		{
			get
			{
				int num = this.__p.__offset(100);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000F30 RID: 3888
		// (get) Token: 0x06003B46 RID: 15174 RVA: 0x000C6C18 File Offset: 0x000C5018
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B47 RID: 15175 RVA: 0x000C6C5B File Offset: 0x000C505B
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x17000F31 RID: 3889
		// (get) Token: 0x06003B48 RID: 15176 RVA: 0x000C6C6C File Offset: 0x000C506C
		public int bNeedJump
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F32 RID: 3890
		// (get) Token: 0x06003B49 RID: 15177 RVA: 0x000C6CB8 File Offset: 0x000C50B8
		public int FunctionID
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F33 RID: 3891
		// (get) Token: 0x06003B4A RID: 15178 RVA: 0x000C6D04 File Offset: 0x000C5104
		public ItemTable.eUseLimiteType UseLimiteType
		{
			get
			{
				int num = this.__p.__offset(108);
				return (ItemTable.eUseLimiteType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F34 RID: 3892
		// (get) Token: 0x06003B4B RID: 15179 RVA: 0x000C6D48 File Offset: 0x000C5148
		public int UseLimiteValue
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F35 RID: 3893
		// (get) Token: 0x06003B4C RID: 15180 RVA: 0x000C6D94 File Offset: 0x000C5194
		public int Abandon
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F36 RID: 3894
		// (get) Token: 0x06003B4D RID: 15181 RVA: 0x000C6DE0 File Offset: 0x000C51E0
		public int PackageID
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F37 RID: 3895
		// (get) Token: 0x06003B4E RID: 15182 RVA: 0x000C6E2C File Offset: 0x000C522C
		public int OldTitle
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F38 RID: 3896
		// (get) Token: 0x06003B4F RID: 15183 RVA: 0x000C6E78 File Offset: 0x000C5278
		public int ForbidAuctionCopy
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003B50 RID: 15184 RVA: 0x000C6EC4 File Offset: 0x000C52C4
		public string RenewInfoArray(int j)
		{
			int num = this.__p.__offset(120);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000F39 RID: 3897
		// (get) Token: 0x06003B51 RID: 15185 RVA: 0x000C6F0C File Offset: 0x000C530C
		public int RenewInfoLength
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000F3A RID: 3898
		// (get) Token: 0x06003B52 RID: 15186 RVA: 0x000C6F3F File Offset: 0x000C533F
		public FlatBufferArray<string> RenewInfo
		{
			get
			{
				if (this.RenewInfoValue == null)
				{
					this.RenewInfoValue = new FlatBufferArray<string>(new Func<int, string>(this.RenewInfoArray), this.RenewInfoLength);
				}
				return this.RenewInfoValue;
			}
		}

		// Token: 0x17000F3B RID: 3899
		// (get) Token: 0x06003B53 RID: 15187 RVA: 0x000C6F70 File Offset: 0x000C5370
		public int AuctionMinPrice
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F3C RID: 3900
		// (get) Token: 0x06003B54 RID: 15188 RVA: 0x000C6FBC File Offset: 0x000C53BC
		public int AuctionMaxPrice
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F3D RID: 3901
		// (get) Token: 0x06003B55 RID: 15189 RVA: 0x000C7008 File Offset: 0x000C5408
		public int CanMasterGive
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F3E RID: 3902
		// (get) Token: 0x06003B56 RID: 15190 RVA: 0x000C7054 File Offset: 0x000C5454
		public int GetLimitNum
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003B57 RID: 15191 RVA: 0x000C70A4 File Offset: 0x000C54A4
		public int jarGiftConsumeItemArray(int j)
		{
			int num = this.__p.__offset(130);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F3F RID: 3903
		// (get) Token: 0x06003B58 RID: 15192 RVA: 0x000C70F4 File Offset: 0x000C54F4
		public int jarGiftConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B59 RID: 15193 RVA: 0x000C712A File Offset: 0x000C552A
		public ArraySegment<byte>? GetJarGiftConsumeItemBytes()
		{
			return this.__p.__vector_as_arraysegment(130);
		}

		// Token: 0x17000F40 RID: 3904
		// (get) Token: 0x06003B5A RID: 15194 RVA: 0x000C713C File Offset: 0x000C553C
		public FlatBufferArray<int> jarGiftConsumeItem
		{
			get
			{
				if (this.jarGiftConsumeItemValue == null)
				{
					this.jarGiftConsumeItemValue = new FlatBufferArray<int>(new Func<int, int>(this.jarGiftConsumeItemArray), this.jarGiftConsumeItemLength);
				}
				return this.jarGiftConsumeItemValue;
			}
		}

		// Token: 0x17000F41 RID: 3905
		// (get) Token: 0x06003B5B RID: 15195 RVA: 0x000C716C File Offset: 0x000C556C
		public string doubleCheckDesc
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B5C RID: 15196 RVA: 0x000C71B2 File Offset: 0x000C55B2
		public ArraySegment<byte>? GetDoubleCheckDescBytes()
		{
			return this.__p.__vector_as_arraysegment(132);
		}

		// Token: 0x17000F42 RID: 3906
		// (get) Token: 0x06003B5D RID: 15197 RVA: 0x000C71C4 File Offset: 0x000C55C4
		public int IsTransparentFashion
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F43 RID: 3907
		// (get) Token: 0x06003B5E RID: 15198 RVA: 0x000C7214 File Offset: 0x000C5614
		public string Inlaidhole1
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B5F RID: 15199 RVA: 0x000C725A File Offset: 0x000C565A
		public ArraySegment<byte>? GetInlaidhole1Bytes()
		{
			return this.__p.__vector_as_arraysegment(136);
		}

		// Token: 0x17000F44 RID: 3908
		// (get) Token: 0x06003B60 RID: 15200 RVA: 0x000C726C File Offset: 0x000C566C
		public string Inlaidhole2
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B61 RID: 15201 RVA: 0x000C72B2 File Offset: 0x000C56B2
		public ArraySegment<byte>? GetInlaidhole2Bytes()
		{
			return this.__p.__vector_as_arraysegment(138);
		}

		// Token: 0x17000F45 RID: 3909
		// (get) Token: 0x06003B62 RID: 15202 RVA: 0x000C72C4 File Offset: 0x000C56C4
		public int StrenTicketDataIndex
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F46 RID: 3910
		// (get) Token: 0x06003B63 RID: 15203 RVA: 0x000C7314 File Offset: 0x000C5714
		public int BeadLevel
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F47 RID: 3911
		// (get) Token: 0x06003B64 RID: 15204 RVA: 0x000C7364 File Offset: 0x000C5764
		public int BeadType
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F48 RID: 3912
		// (get) Token: 0x06003B65 RID: 15205 RVA: 0x000C73B4 File Offset: 0x000C57B4
		public int IsTreas
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F49 RID: 3913
		// (get) Token: 0x06003B66 RID: 15206 RVA: 0x000C7404 File Offset: 0x000C5804
		public int TradeCD1
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F4A RID: 3914
		// (get) Token: 0x06003B67 RID: 15207 RVA: 0x000C7454 File Offset: 0x000C5854
		public int TradeCD2
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003B68 RID: 15208 RVA: 0x000C74A4 File Offset: 0x000C58A4
		public int LvAdaptationArray(int j)
		{
			int num = this.__p.__offset(152);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F4B RID: 3915
		// (get) Token: 0x06003B69 RID: 15209 RVA: 0x000C74F4 File Offset: 0x000C58F4
		public int LvAdaptationLength
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003B6A RID: 15210 RVA: 0x000C752A File Offset: 0x000C592A
		public ArraySegment<byte>? GetLvAdaptationBytes()
		{
			return this.__p.__vector_as_arraysegment(152);
		}

		// Token: 0x17000F4C RID: 3916
		// (get) Token: 0x06003B6B RID: 15211 RVA: 0x000C753C File Offset: 0x000C593C
		public FlatBufferArray<int> LvAdaptation
		{
			get
			{
				if (this.LvAdaptationValue == null)
				{
					this.LvAdaptationValue = new FlatBufferArray<int>(new Func<int, int>(this.LvAdaptationArray), this.LvAdaptationLength);
				}
				return this.LvAdaptationValue;
			}
		}

		// Token: 0x17000F4D RID: 3917
		// (get) Token: 0x06003B6C RID: 15212 RVA: 0x000C756C File Offset: 0x000C596C
		public int DescriptionLink
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F4E RID: 3918
		// (get) Token: 0x06003B6D RID: 15213 RVA: 0x000C75BC File Offset: 0x000C59BC
		public int IsRecordLog
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F4F RID: 3919
		// (get) Token: 0x06003B6E RID: 15214 RVA: 0x000C760C File Offset: 0x000C5A0C
		public int DiscountCouponProp
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F50 RID: 3920
		// (get) Token: 0x06003B6F RID: 15215 RVA: 0x000C765C File Offset: 0x000C5A5C
		public int NewTitleId
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F51 RID: 3921
		// (get) Token: 0x06003B70 RID: 15216 RVA: 0x000C76AC File Offset: 0x000C5AAC
		public int ExpireTime
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F52 RID: 3922
		// (get) Token: 0x06003B71 RID: 15217 RVA: 0x000C76FC File Offset: 0x000C5AFC
		public int TransactionsNum
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F53 RID: 3923
		// (get) Token: 0x06003B72 RID: 15218 RVA: 0x000C774C File Offset: 0x000C5B4C
		public string prohibitOps
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B73 RID: 15219 RVA: 0x000C7792 File Offset: 0x000C5B92
		public ArraySegment<byte>? GetProhibitOpsBytes()
		{
			return this.__p.__vector_as_arraysegment(166);
		}

		// Token: 0x17000F54 RID: 3924
		// (get) Token: 0x06003B74 RID: 15220 RVA: 0x000C77A4 File Offset: 0x000C5BA4
		public int UseLinmit
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F55 RID: 3925
		// (get) Token: 0x06003B75 RID: 15221 RVA: 0x000C77F4 File Offset: 0x000C5BF4
		public int IsSpeicMagic
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F56 RID: 3926
		// (get) Token: 0x06003B76 RID: 15222 RVA: 0x000C7844 File Offset: 0x000C5C44
		public string presentItems
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B77 RID: 15223 RVA: 0x000C788A File Offset: 0x000C5C8A
		public ArraySegment<byte>? GetPresentItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(172);
		}

		// Token: 0x17000F57 RID: 3927
		// (get) Token: 0x06003B78 RID: 15224 RVA: 0x000C789C File Offset: 0x000C5C9C
		public string presentItemsLimit
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003B79 RID: 15225 RVA: 0x000C78E2 File Offset: 0x000C5CE2
		public ArraySegment<byte>? GetPresentItemsLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(174);
		}

		// Token: 0x06003B7A RID: 15226 RVA: 0x000C78F4 File Offset: 0x000C5CF4
		public static Offset<ItemTable> CreateItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int IdSequence = 0, ItemTable.eType Type = ItemTable.eType.Type_None, StringOffset TypeNameOffset = default(StringOffset), ItemTable.eEPrompt EPrompt = ItemTable.eEPrompt.EPT_NONE, ItemTable.eSubType SubType = ItemTable.eSubType.ST_NONE, StringOffset SubTypeNameOffset = default(StringOffset), ItemTable.eThirdType ThirdType = ItemTable.eThirdType.TT_NONE, StringOffset ThirdTypeNameOffset = default(StringOffset), VectorOffset OccuOffset = default(VectorOffset), VectorOffset Occu2Offset = default(VectorOffset), ItemTable.eColor Color = ItemTable.eColor.CL_NONE, int Color2 = 0, int NeedLevel = 0, int MaxLevel = 0, int BaseAttackSpeedRate = 0, ItemTable.eCanUse CanUse = ItemTable.eCanUse.CanNot, bool CanTrade = false, ItemTable.eOwner Owner = ItemTable.eOwner.Owner_None, bool IsSeal = false, int SealMax = 0, bool IsDecompose = false, int SellItemID = 0, int Price = 0, int CdGroup = 0, int CoolTime = 0, int TimeLeft = 0, int MaxNum = 0, StringOffset EffectDescriptionOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), VectorOffset ComeLinkOffset = default(VectorOffset), VectorOffset RelationIDOffset = default(VectorOffset), StringOffset IconOffset = default(StringOffset), StringOffset ModelPathOffset = default(StringOffset), VectorOffset Path2Offset = default(VectorOffset), int OnUseBuffId = 0, int OnGetBuffId = 0, bool CanDungeonUse = false, bool CanPKUse = false, int RecommendPrice = 0, ItemTable.eComeType ComeType = ItemTable.eComeType.CT_SHOP, StringOffset ComeDescOffset = default(StringOffset), int ResID = 0, int Tag = 0, int SuitID = 0, int EquipPropID = 0, VectorOffset MutexBuffOffset = default(VectorOffset), bool CanAnnounce = false, StringOffset LinkInfoOffset = default(StringOffset), int bNeedJump = 0, int FunctionID = 0, ItemTable.eUseLimiteType UseLimiteType = ItemTable.eUseLimiteType.NOLIMITE, int UseLimiteValue = 0, int Abandon = 0, int PackageID = 0, int OldTitle = 0, int ForbidAuctionCopy = 0, VectorOffset RenewInfoOffset = default(VectorOffset), int AuctionMinPrice = 0, int AuctionMaxPrice = 0, int CanMasterGive = 0, int GetLimitNum = 0, VectorOffset jarGiftConsumeItemOffset = default(VectorOffset), StringOffset doubleCheckDescOffset = default(StringOffset), int IsTransparentFashion = 0, StringOffset Inlaidhole1Offset = default(StringOffset), StringOffset Inlaidhole2Offset = default(StringOffset), int StrenTicketDataIndex = 0, int BeadLevel = 0, int BeadType = 0, int IsTreas = 0, int TradeCD1 = 0, int TradeCD2 = 0, VectorOffset LvAdaptationOffset = default(VectorOffset), int DescriptionLink = 0, int IsRecordLog = 0, int DiscountCouponProp = 0, int NewTitleId = 0, int ExpireTime = 0, int TransactionsNum = 0, StringOffset prohibitOpsOffset = default(StringOffset), int UseLinmit = 0, int IsSpeicMagic = 0, StringOffset presentItemsOffset = default(StringOffset), StringOffset presentItemsLimitOffset = default(StringOffset))
		{
			builder.StartObject(86);
			ItemTable.AddPresentItemsLimit(builder, presentItemsLimitOffset);
			ItemTable.AddPresentItems(builder, presentItemsOffset);
			ItemTable.AddIsSpeicMagic(builder, IsSpeicMagic);
			ItemTable.AddUseLinmit(builder, UseLinmit);
			ItemTable.AddProhibitOps(builder, prohibitOpsOffset);
			ItemTable.AddTransactionsNum(builder, TransactionsNum);
			ItemTable.AddExpireTime(builder, ExpireTime);
			ItemTable.AddNewTitleId(builder, NewTitleId);
			ItemTable.AddDiscountCouponProp(builder, DiscountCouponProp);
			ItemTable.AddIsRecordLog(builder, IsRecordLog);
			ItemTable.AddDescriptionLink(builder, DescriptionLink);
			ItemTable.AddLvAdaptation(builder, LvAdaptationOffset);
			ItemTable.AddTradeCD2(builder, TradeCD2);
			ItemTable.AddTradeCD1(builder, TradeCD1);
			ItemTable.AddIsTreas(builder, IsTreas);
			ItemTable.AddBeadType(builder, BeadType);
			ItemTable.AddBeadLevel(builder, BeadLevel);
			ItemTable.AddStrenTicketDataIndex(builder, StrenTicketDataIndex);
			ItemTable.AddInlaidhole2(builder, Inlaidhole2Offset);
			ItemTable.AddInlaidhole1(builder, Inlaidhole1Offset);
			ItemTable.AddIsTransparentFashion(builder, IsTransparentFashion);
			ItemTable.AddDoubleCheckDesc(builder, doubleCheckDescOffset);
			ItemTable.AddJarGiftConsumeItem(builder, jarGiftConsumeItemOffset);
			ItemTable.AddGetLimitNum(builder, GetLimitNum);
			ItemTable.AddCanMasterGive(builder, CanMasterGive);
			ItemTable.AddAuctionMaxPrice(builder, AuctionMaxPrice);
			ItemTable.AddAuctionMinPrice(builder, AuctionMinPrice);
			ItemTable.AddRenewInfo(builder, RenewInfoOffset);
			ItemTable.AddForbidAuctionCopy(builder, ForbidAuctionCopy);
			ItemTable.AddOldTitle(builder, OldTitle);
			ItemTable.AddPackageID(builder, PackageID);
			ItemTable.AddAbandon(builder, Abandon);
			ItemTable.AddUseLimiteValue(builder, UseLimiteValue);
			ItemTable.AddUseLimiteType(builder, UseLimiteType);
			ItemTable.AddFunctionID(builder, FunctionID);
			ItemTable.AddBNeedJump(builder, bNeedJump);
			ItemTable.AddLinkInfo(builder, LinkInfoOffset);
			ItemTable.AddMutexBuff(builder, MutexBuffOffset);
			ItemTable.AddEquipPropID(builder, EquipPropID);
			ItemTable.AddSuitID(builder, SuitID);
			ItemTable.AddTag(builder, Tag);
			ItemTable.AddResID(builder, ResID);
			ItemTable.AddComeDesc(builder, ComeDescOffset);
			ItemTable.AddComeType(builder, ComeType);
			ItemTable.AddRecommendPrice(builder, RecommendPrice);
			ItemTable.AddOnGetBuffId(builder, OnGetBuffId);
			ItemTable.AddOnUseBuffId(builder, OnUseBuffId);
			ItemTable.AddPath2(builder, Path2Offset);
			ItemTable.AddModelPath(builder, ModelPathOffset);
			ItemTable.AddIcon(builder, IconOffset);
			ItemTable.AddRelationID(builder, RelationIDOffset);
			ItemTable.AddComeLink(builder, ComeLinkOffset);
			ItemTable.AddDescription(builder, DescriptionOffset);
			ItemTable.AddEffectDescription(builder, EffectDescriptionOffset);
			ItemTable.AddMaxNum(builder, MaxNum);
			ItemTable.AddTimeLeft(builder, TimeLeft);
			ItemTable.AddCoolTime(builder, CoolTime);
			ItemTable.AddCdGroup(builder, CdGroup);
			ItemTable.AddPrice(builder, Price);
			ItemTable.AddSellItemID(builder, SellItemID);
			ItemTable.AddSealMax(builder, SealMax);
			ItemTable.AddOwner(builder, Owner);
			ItemTable.AddCanUse(builder, CanUse);
			ItemTable.AddBaseAttackSpeedRate(builder, BaseAttackSpeedRate);
			ItemTable.AddMaxLevel(builder, MaxLevel);
			ItemTable.AddNeedLevel(builder, NeedLevel);
			ItemTable.AddColor2(builder, Color2);
			ItemTable.AddColor(builder, Color);
			ItemTable.AddOccu2(builder, Occu2Offset);
			ItemTable.AddOccu(builder, OccuOffset);
			ItemTable.AddThirdTypeName(builder, ThirdTypeNameOffset);
			ItemTable.AddThirdType(builder, ThirdType);
			ItemTable.AddSubTypeName(builder, SubTypeNameOffset);
			ItemTable.AddSubType(builder, SubType);
			ItemTable.AddEPrompt(builder, EPrompt);
			ItemTable.AddTypeName(builder, TypeNameOffset);
			ItemTable.AddType(builder, Type);
			ItemTable.AddIdSequence(builder, IdSequence);
			ItemTable.AddName(builder, NameOffset);
			ItemTable.AddID(builder, ID);
			ItemTable.AddCanAnnounce(builder, CanAnnounce);
			ItemTable.AddCanPKUse(builder, CanPKUse);
			ItemTable.AddCanDungeonUse(builder, CanDungeonUse);
			ItemTable.AddIsDecompose(builder, IsDecompose);
			ItemTable.AddIsSeal(builder, IsSeal);
			ItemTable.AddCanTrade(builder, CanTrade);
			return ItemTable.EndItemTable(builder);
		}

		// Token: 0x06003B7B RID: 15227 RVA: 0x000C7BBC File Offset: 0x000C5FBC
		public static void StartItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(86);
		}

		// Token: 0x06003B7C RID: 15228 RVA: 0x000C7BC6 File Offset: 0x000C5FC6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003B7D RID: 15229 RVA: 0x000C7BD1 File Offset: 0x000C5FD1
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003B7E RID: 15230 RVA: 0x000C7BE2 File Offset: 0x000C5FE2
		public static void AddIdSequence(FlatBufferBuilder builder, int IdSequence)
		{
			builder.AddInt(2, IdSequence, 0);
		}

		// Token: 0x06003B7F RID: 15231 RVA: 0x000C7BED File Offset: 0x000C5FED
		public static void AddType(FlatBufferBuilder builder, ItemTable.eType Type)
		{
			builder.AddInt(3, (int)Type, 0);
		}

		// Token: 0x06003B80 RID: 15232 RVA: 0x000C7BF8 File Offset: 0x000C5FF8
		public static void AddTypeName(FlatBufferBuilder builder, StringOffset TypeNameOffset)
		{
			builder.AddOffset(4, TypeNameOffset.Value, 0);
		}

		// Token: 0x06003B81 RID: 15233 RVA: 0x000C7C09 File Offset: 0x000C6009
		public static void AddEPrompt(FlatBufferBuilder builder, ItemTable.eEPrompt EPrompt)
		{
			builder.AddInt(5, (int)EPrompt, 0);
		}

		// Token: 0x06003B82 RID: 15234 RVA: 0x000C7C14 File Offset: 0x000C6014
		public static void AddSubType(FlatBufferBuilder builder, ItemTable.eSubType SubType)
		{
			builder.AddInt(6, (int)SubType, 0);
		}

		// Token: 0x06003B83 RID: 15235 RVA: 0x000C7C1F File Offset: 0x000C601F
		public static void AddSubTypeName(FlatBufferBuilder builder, StringOffset SubTypeNameOffset)
		{
			builder.AddOffset(7, SubTypeNameOffset.Value, 0);
		}

		// Token: 0x06003B84 RID: 15236 RVA: 0x000C7C30 File Offset: 0x000C6030
		public static void AddThirdType(FlatBufferBuilder builder, ItemTable.eThirdType ThirdType)
		{
			builder.AddInt(8, (int)ThirdType, 0);
		}

		// Token: 0x06003B85 RID: 15237 RVA: 0x000C7C3B File Offset: 0x000C603B
		public static void AddThirdTypeName(FlatBufferBuilder builder, StringOffset ThirdTypeNameOffset)
		{
			builder.AddOffset(9, ThirdTypeNameOffset.Value, 0);
		}

		// Token: 0x06003B86 RID: 15238 RVA: 0x000C7C4D File Offset: 0x000C604D
		public static void AddOccu(FlatBufferBuilder builder, VectorOffset OccuOffset)
		{
			builder.AddOffset(10, OccuOffset.Value, 0);
		}

		// Token: 0x06003B87 RID: 15239 RVA: 0x000C7C60 File Offset: 0x000C6060
		public static VectorOffset CreateOccuVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003B88 RID: 15240 RVA: 0x000C7C9D File Offset: 0x000C609D
		public static void StartOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003B89 RID: 15241 RVA: 0x000C7CA8 File Offset: 0x000C60A8
		public static void AddOccu2(FlatBufferBuilder builder, VectorOffset Occu2Offset)
		{
			builder.AddOffset(11, Occu2Offset.Value, 0);
		}

		// Token: 0x06003B8A RID: 15242 RVA: 0x000C7CBC File Offset: 0x000C60BC
		public static VectorOffset CreateOccu2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003B8B RID: 15243 RVA: 0x000C7CF9 File Offset: 0x000C60F9
		public static void StartOccu2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003B8C RID: 15244 RVA: 0x000C7D04 File Offset: 0x000C6104
		public static void AddColor(FlatBufferBuilder builder, ItemTable.eColor Color)
		{
			builder.AddInt(12, (int)Color, 0);
		}

		// Token: 0x06003B8D RID: 15245 RVA: 0x000C7D10 File Offset: 0x000C6110
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(13, Color2, 0);
		}

		// Token: 0x06003B8E RID: 15246 RVA: 0x000C7D1C File Offset: 0x000C611C
		public static void AddNeedLevel(FlatBufferBuilder builder, int NeedLevel)
		{
			builder.AddInt(14, NeedLevel, 0);
		}

		// Token: 0x06003B8F RID: 15247 RVA: 0x000C7D28 File Offset: 0x000C6128
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(15, MaxLevel, 0);
		}

		// Token: 0x06003B90 RID: 15248 RVA: 0x000C7D34 File Offset: 0x000C6134
		public static void AddBaseAttackSpeedRate(FlatBufferBuilder builder, int BaseAttackSpeedRate)
		{
			builder.AddInt(16, BaseAttackSpeedRate, 0);
		}

		// Token: 0x06003B91 RID: 15249 RVA: 0x000C7D40 File Offset: 0x000C6140
		public static void AddCanUse(FlatBufferBuilder builder, ItemTable.eCanUse CanUse)
		{
			builder.AddInt(17, (int)CanUse, 0);
		}

		// Token: 0x06003B92 RID: 15250 RVA: 0x000C7D4C File Offset: 0x000C614C
		public static void AddCanTrade(FlatBufferBuilder builder, bool CanTrade)
		{
			builder.AddBool(18, CanTrade, false);
		}

		// Token: 0x06003B93 RID: 15251 RVA: 0x000C7D58 File Offset: 0x000C6158
		public static void AddOwner(FlatBufferBuilder builder, ItemTable.eOwner Owner)
		{
			builder.AddInt(19, (int)Owner, 0);
		}

		// Token: 0x06003B94 RID: 15252 RVA: 0x000C7D64 File Offset: 0x000C6164
		public static void AddIsSeal(FlatBufferBuilder builder, bool IsSeal)
		{
			builder.AddBool(20, IsSeal, false);
		}

		// Token: 0x06003B95 RID: 15253 RVA: 0x000C7D70 File Offset: 0x000C6170
		public static void AddSealMax(FlatBufferBuilder builder, int SealMax)
		{
			builder.AddInt(21, SealMax, 0);
		}

		// Token: 0x06003B96 RID: 15254 RVA: 0x000C7D7C File Offset: 0x000C617C
		public static void AddIsDecompose(FlatBufferBuilder builder, bool IsDecompose)
		{
			builder.AddBool(22, IsDecompose, false);
		}

		// Token: 0x06003B97 RID: 15255 RVA: 0x000C7D88 File Offset: 0x000C6188
		public static void AddSellItemID(FlatBufferBuilder builder, int SellItemID)
		{
			builder.AddInt(23, SellItemID, 0);
		}

		// Token: 0x06003B98 RID: 15256 RVA: 0x000C7D94 File Offset: 0x000C6194
		public static void AddPrice(FlatBufferBuilder builder, int Price)
		{
			builder.AddInt(24, Price, 0);
		}

		// Token: 0x06003B99 RID: 15257 RVA: 0x000C7DA0 File Offset: 0x000C61A0
		public static void AddCdGroup(FlatBufferBuilder builder, int CdGroup)
		{
			builder.AddInt(25, CdGroup, 0);
		}

		// Token: 0x06003B9A RID: 15258 RVA: 0x000C7DAC File Offset: 0x000C61AC
		public static void AddCoolTime(FlatBufferBuilder builder, int CoolTime)
		{
			builder.AddInt(26, CoolTime, 0);
		}

		// Token: 0x06003B9B RID: 15259 RVA: 0x000C7DB8 File Offset: 0x000C61B8
		public static void AddTimeLeft(FlatBufferBuilder builder, int TimeLeft)
		{
			builder.AddInt(27, TimeLeft, 0);
		}

		// Token: 0x06003B9C RID: 15260 RVA: 0x000C7DC4 File Offset: 0x000C61C4
		public static void AddMaxNum(FlatBufferBuilder builder, int MaxNum)
		{
			builder.AddInt(28, MaxNum, 0);
		}

		// Token: 0x06003B9D RID: 15261 RVA: 0x000C7DD0 File Offset: 0x000C61D0
		public static void AddEffectDescription(FlatBufferBuilder builder, StringOffset EffectDescriptionOffset)
		{
			builder.AddOffset(29, EffectDescriptionOffset.Value, 0);
		}

		// Token: 0x06003B9E RID: 15262 RVA: 0x000C7DE2 File Offset: 0x000C61E2
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(30, DescriptionOffset.Value, 0);
		}

		// Token: 0x06003B9F RID: 15263 RVA: 0x000C7DF4 File Offset: 0x000C61F4
		public static void AddComeLink(FlatBufferBuilder builder, VectorOffset ComeLinkOffset)
		{
			builder.AddOffset(31, ComeLinkOffset.Value, 0);
		}

		// Token: 0x06003BA0 RID: 15264 RVA: 0x000C7E08 File Offset: 0x000C6208
		public static VectorOffset CreateComeLinkVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BA1 RID: 15265 RVA: 0x000C7E45 File Offset: 0x000C6245
		public static void StartComeLinkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x000C7E50 File Offset: 0x000C6250
		public static void AddRelationID(FlatBufferBuilder builder, VectorOffset RelationIDOffset)
		{
			builder.AddOffset(32, RelationIDOffset.Value, 0);
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x000C7E64 File Offset: 0x000C6264
		public static VectorOffset CreateRelationIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BA4 RID: 15268 RVA: 0x000C7EA1 File Offset: 0x000C62A1
		public static void StartRelationIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BA5 RID: 15269 RVA: 0x000C7EAC File Offset: 0x000C62AC
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(33, IconOffset.Value, 0);
		}

		// Token: 0x06003BA6 RID: 15270 RVA: 0x000C7EBE File Offset: 0x000C62BE
		public static void AddModelPath(FlatBufferBuilder builder, StringOffset ModelPathOffset)
		{
			builder.AddOffset(34, ModelPathOffset.Value, 0);
		}

		// Token: 0x06003BA7 RID: 15271 RVA: 0x000C7ED0 File Offset: 0x000C62D0
		public static void AddPath2(FlatBufferBuilder builder, VectorOffset Path2Offset)
		{
			builder.AddOffset(35, Path2Offset.Value, 0);
		}

		// Token: 0x06003BA8 RID: 15272 RVA: 0x000C7EE4 File Offset: 0x000C62E4
		public static VectorOffset CreatePath2Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BA9 RID: 15273 RVA: 0x000C7F2A File Offset: 0x000C632A
		public static void StartPath2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BAA RID: 15274 RVA: 0x000C7F35 File Offset: 0x000C6335
		public static void AddOnUseBuffId(FlatBufferBuilder builder, int OnUseBuffId)
		{
			builder.AddInt(36, OnUseBuffId, 0);
		}

		// Token: 0x06003BAB RID: 15275 RVA: 0x000C7F41 File Offset: 0x000C6341
		public static void AddOnGetBuffId(FlatBufferBuilder builder, int OnGetBuffId)
		{
			builder.AddInt(37, OnGetBuffId, 0);
		}

		// Token: 0x06003BAC RID: 15276 RVA: 0x000C7F4D File Offset: 0x000C634D
		public static void AddCanDungeonUse(FlatBufferBuilder builder, bool CanDungeonUse)
		{
			builder.AddBool(38, CanDungeonUse, false);
		}

		// Token: 0x06003BAD RID: 15277 RVA: 0x000C7F59 File Offset: 0x000C6359
		public static void AddCanPKUse(FlatBufferBuilder builder, bool CanPKUse)
		{
			builder.AddBool(39, CanPKUse, false);
		}

		// Token: 0x06003BAE RID: 15278 RVA: 0x000C7F65 File Offset: 0x000C6365
		public static void AddRecommendPrice(FlatBufferBuilder builder, int RecommendPrice)
		{
			builder.AddInt(40, RecommendPrice, 0);
		}

		// Token: 0x06003BAF RID: 15279 RVA: 0x000C7F71 File Offset: 0x000C6371
		public static void AddComeType(FlatBufferBuilder builder, ItemTable.eComeType ComeType)
		{
			builder.AddInt(41, (int)ComeType, 0);
		}

		// Token: 0x06003BB0 RID: 15280 RVA: 0x000C7F7D File Offset: 0x000C637D
		public static void AddComeDesc(FlatBufferBuilder builder, StringOffset ComeDescOffset)
		{
			builder.AddOffset(42, ComeDescOffset.Value, 0);
		}

		// Token: 0x06003BB1 RID: 15281 RVA: 0x000C7F8F File Offset: 0x000C638F
		public static void AddResID(FlatBufferBuilder builder, int ResID)
		{
			builder.AddInt(43, ResID, 0);
		}

		// Token: 0x06003BB2 RID: 15282 RVA: 0x000C7F9B File Offset: 0x000C639B
		public static void AddTag(FlatBufferBuilder builder, int Tag)
		{
			builder.AddInt(44, Tag, 0);
		}

		// Token: 0x06003BB3 RID: 15283 RVA: 0x000C7FA7 File Offset: 0x000C63A7
		public static void AddSuitID(FlatBufferBuilder builder, int SuitID)
		{
			builder.AddInt(45, SuitID, 0);
		}

		// Token: 0x06003BB4 RID: 15284 RVA: 0x000C7FB3 File Offset: 0x000C63B3
		public static void AddEquipPropID(FlatBufferBuilder builder, int EquipPropID)
		{
			builder.AddInt(46, EquipPropID, 0);
		}

		// Token: 0x06003BB5 RID: 15285 RVA: 0x000C7FBF File Offset: 0x000C63BF
		public static void AddMutexBuff(FlatBufferBuilder builder, VectorOffset MutexBuffOffset)
		{
			builder.AddOffset(47, MutexBuffOffset.Value, 0);
		}

		// Token: 0x06003BB6 RID: 15286 RVA: 0x000C7FD4 File Offset: 0x000C63D4
		public static VectorOffset CreateMutexBuffVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BB7 RID: 15287 RVA: 0x000C8011 File Offset: 0x000C6411
		public static void StartMutexBuffVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BB8 RID: 15288 RVA: 0x000C801C File Offset: 0x000C641C
		public static void AddCanAnnounce(FlatBufferBuilder builder, bool CanAnnounce)
		{
			builder.AddBool(48, CanAnnounce, false);
		}

		// Token: 0x06003BB9 RID: 15289 RVA: 0x000C8028 File Offset: 0x000C6428
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(49, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06003BBA RID: 15290 RVA: 0x000C803A File Offset: 0x000C643A
		public static void AddBNeedJump(FlatBufferBuilder builder, int bNeedJump)
		{
			builder.AddInt(50, bNeedJump, 0);
		}

		// Token: 0x06003BBB RID: 15291 RVA: 0x000C8046 File Offset: 0x000C6446
		public static void AddFunctionID(FlatBufferBuilder builder, int FunctionID)
		{
			builder.AddInt(51, FunctionID, 0);
		}

		// Token: 0x06003BBC RID: 15292 RVA: 0x000C8052 File Offset: 0x000C6452
		public static void AddUseLimiteType(FlatBufferBuilder builder, ItemTable.eUseLimiteType UseLimiteType)
		{
			builder.AddInt(52, (int)UseLimiteType, 0);
		}

		// Token: 0x06003BBD RID: 15293 RVA: 0x000C805E File Offset: 0x000C645E
		public static void AddUseLimiteValue(FlatBufferBuilder builder, int UseLimiteValue)
		{
			builder.AddInt(53, UseLimiteValue, 0);
		}

		// Token: 0x06003BBE RID: 15294 RVA: 0x000C806A File Offset: 0x000C646A
		public static void AddAbandon(FlatBufferBuilder builder, int Abandon)
		{
			builder.AddInt(54, Abandon, 0);
		}

		// Token: 0x06003BBF RID: 15295 RVA: 0x000C8076 File Offset: 0x000C6476
		public static void AddPackageID(FlatBufferBuilder builder, int PackageID)
		{
			builder.AddInt(55, PackageID, 0);
		}

		// Token: 0x06003BC0 RID: 15296 RVA: 0x000C8082 File Offset: 0x000C6482
		public static void AddOldTitle(FlatBufferBuilder builder, int OldTitle)
		{
			builder.AddInt(56, OldTitle, 0);
		}

		// Token: 0x06003BC1 RID: 15297 RVA: 0x000C808E File Offset: 0x000C648E
		public static void AddForbidAuctionCopy(FlatBufferBuilder builder, int ForbidAuctionCopy)
		{
			builder.AddInt(57, ForbidAuctionCopy, 0);
		}

		// Token: 0x06003BC2 RID: 15298 RVA: 0x000C809A File Offset: 0x000C649A
		public static void AddRenewInfo(FlatBufferBuilder builder, VectorOffset RenewInfoOffset)
		{
			builder.AddOffset(58, RenewInfoOffset.Value, 0);
		}

		// Token: 0x06003BC3 RID: 15299 RVA: 0x000C80AC File Offset: 0x000C64AC
		public static VectorOffset CreateRenewInfoVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BC4 RID: 15300 RVA: 0x000C80F2 File Offset: 0x000C64F2
		public static void StartRenewInfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BC5 RID: 15301 RVA: 0x000C80FD File Offset: 0x000C64FD
		public static void AddAuctionMinPrice(FlatBufferBuilder builder, int AuctionMinPrice)
		{
			builder.AddInt(59, AuctionMinPrice, 0);
		}

		// Token: 0x06003BC6 RID: 15302 RVA: 0x000C8109 File Offset: 0x000C6509
		public static void AddAuctionMaxPrice(FlatBufferBuilder builder, int AuctionMaxPrice)
		{
			builder.AddInt(60, AuctionMaxPrice, 0);
		}

		// Token: 0x06003BC7 RID: 15303 RVA: 0x000C8115 File Offset: 0x000C6515
		public static void AddCanMasterGive(FlatBufferBuilder builder, int CanMasterGive)
		{
			builder.AddInt(61, CanMasterGive, 0);
		}

		// Token: 0x06003BC8 RID: 15304 RVA: 0x000C8121 File Offset: 0x000C6521
		public static void AddGetLimitNum(FlatBufferBuilder builder, int GetLimitNum)
		{
			builder.AddInt(62, GetLimitNum, 0);
		}

		// Token: 0x06003BC9 RID: 15305 RVA: 0x000C812D File Offset: 0x000C652D
		public static void AddJarGiftConsumeItem(FlatBufferBuilder builder, VectorOffset jarGiftConsumeItemOffset)
		{
			builder.AddOffset(63, jarGiftConsumeItemOffset.Value, 0);
		}

		// Token: 0x06003BCA RID: 15306 RVA: 0x000C8140 File Offset: 0x000C6540
		public static VectorOffset CreateJarGiftConsumeItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BCB RID: 15307 RVA: 0x000C817D File Offset: 0x000C657D
		public static void StartJarGiftConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BCC RID: 15308 RVA: 0x000C8188 File Offset: 0x000C6588
		public static void AddDoubleCheckDesc(FlatBufferBuilder builder, StringOffset doubleCheckDescOffset)
		{
			builder.AddOffset(64, doubleCheckDescOffset.Value, 0);
		}

		// Token: 0x06003BCD RID: 15309 RVA: 0x000C819A File Offset: 0x000C659A
		public static void AddIsTransparentFashion(FlatBufferBuilder builder, int IsTransparentFashion)
		{
			builder.AddInt(65, IsTransparentFashion, 0);
		}

		// Token: 0x06003BCE RID: 15310 RVA: 0x000C81A6 File Offset: 0x000C65A6
		public static void AddInlaidhole1(FlatBufferBuilder builder, StringOffset Inlaidhole1Offset)
		{
			builder.AddOffset(66, Inlaidhole1Offset.Value, 0);
		}

		// Token: 0x06003BCF RID: 15311 RVA: 0x000C81B8 File Offset: 0x000C65B8
		public static void AddInlaidhole2(FlatBufferBuilder builder, StringOffset Inlaidhole2Offset)
		{
			builder.AddOffset(67, Inlaidhole2Offset.Value, 0);
		}

		// Token: 0x06003BD0 RID: 15312 RVA: 0x000C81CA File Offset: 0x000C65CA
		public static void AddStrenTicketDataIndex(FlatBufferBuilder builder, int StrenTicketDataIndex)
		{
			builder.AddInt(68, StrenTicketDataIndex, 0);
		}

		// Token: 0x06003BD1 RID: 15313 RVA: 0x000C81D6 File Offset: 0x000C65D6
		public static void AddBeadLevel(FlatBufferBuilder builder, int BeadLevel)
		{
			builder.AddInt(69, BeadLevel, 0);
		}

		// Token: 0x06003BD2 RID: 15314 RVA: 0x000C81E2 File Offset: 0x000C65E2
		public static void AddBeadType(FlatBufferBuilder builder, int BeadType)
		{
			builder.AddInt(70, BeadType, 0);
		}

		// Token: 0x06003BD3 RID: 15315 RVA: 0x000C81EE File Offset: 0x000C65EE
		public static void AddIsTreas(FlatBufferBuilder builder, int IsTreas)
		{
			builder.AddInt(71, IsTreas, 0);
		}

		// Token: 0x06003BD4 RID: 15316 RVA: 0x000C81FA File Offset: 0x000C65FA
		public static void AddTradeCD1(FlatBufferBuilder builder, int TradeCD1)
		{
			builder.AddInt(72, TradeCD1, 0);
		}

		// Token: 0x06003BD5 RID: 15317 RVA: 0x000C8206 File Offset: 0x000C6606
		public static void AddTradeCD2(FlatBufferBuilder builder, int TradeCD2)
		{
			builder.AddInt(73, TradeCD2, 0);
		}

		// Token: 0x06003BD6 RID: 15318 RVA: 0x000C8212 File Offset: 0x000C6612
		public static void AddLvAdaptation(FlatBufferBuilder builder, VectorOffset LvAdaptationOffset)
		{
			builder.AddOffset(74, LvAdaptationOffset.Value, 0);
		}

		// Token: 0x06003BD7 RID: 15319 RVA: 0x000C8224 File Offset: 0x000C6624
		public static VectorOffset CreateLvAdaptationVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003BD8 RID: 15320 RVA: 0x000C8261 File Offset: 0x000C6661
		public static void StartLvAdaptationVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003BD9 RID: 15321 RVA: 0x000C826C File Offset: 0x000C666C
		public static void AddDescriptionLink(FlatBufferBuilder builder, int DescriptionLink)
		{
			builder.AddInt(75, DescriptionLink, 0);
		}

		// Token: 0x06003BDA RID: 15322 RVA: 0x000C8278 File Offset: 0x000C6678
		public static void AddIsRecordLog(FlatBufferBuilder builder, int IsRecordLog)
		{
			builder.AddInt(76, IsRecordLog, 0);
		}

		// Token: 0x06003BDB RID: 15323 RVA: 0x000C8284 File Offset: 0x000C6684
		public static void AddDiscountCouponProp(FlatBufferBuilder builder, int DiscountCouponProp)
		{
			builder.AddInt(77, DiscountCouponProp, 0);
		}

		// Token: 0x06003BDC RID: 15324 RVA: 0x000C8290 File Offset: 0x000C6690
		public static void AddNewTitleId(FlatBufferBuilder builder, int NewTitleId)
		{
			builder.AddInt(78, NewTitleId, 0);
		}

		// Token: 0x06003BDD RID: 15325 RVA: 0x000C829C File Offset: 0x000C669C
		public static void AddExpireTime(FlatBufferBuilder builder, int ExpireTime)
		{
			builder.AddInt(79, ExpireTime, 0);
		}

		// Token: 0x06003BDE RID: 15326 RVA: 0x000C82A8 File Offset: 0x000C66A8
		public static void AddTransactionsNum(FlatBufferBuilder builder, int TransactionsNum)
		{
			builder.AddInt(80, TransactionsNum, 0);
		}

		// Token: 0x06003BDF RID: 15327 RVA: 0x000C82B4 File Offset: 0x000C66B4
		public static void AddProhibitOps(FlatBufferBuilder builder, StringOffset prohibitOpsOffset)
		{
			builder.AddOffset(81, prohibitOpsOffset.Value, 0);
		}

		// Token: 0x06003BE0 RID: 15328 RVA: 0x000C82C6 File Offset: 0x000C66C6
		public static void AddUseLinmit(FlatBufferBuilder builder, int UseLinmit)
		{
			builder.AddInt(82, UseLinmit, 0);
		}

		// Token: 0x06003BE1 RID: 15329 RVA: 0x000C82D2 File Offset: 0x000C66D2
		public static void AddIsSpeicMagic(FlatBufferBuilder builder, int IsSpeicMagic)
		{
			builder.AddInt(83, IsSpeicMagic, 0);
		}

		// Token: 0x06003BE2 RID: 15330 RVA: 0x000C82DE File Offset: 0x000C66DE
		public static void AddPresentItems(FlatBufferBuilder builder, StringOffset presentItemsOffset)
		{
			builder.AddOffset(84, presentItemsOffset.Value, 0);
		}

		// Token: 0x06003BE3 RID: 15331 RVA: 0x000C82F0 File Offset: 0x000C66F0
		public static void AddPresentItemsLimit(FlatBufferBuilder builder, StringOffset presentItemsLimitOffset)
		{
			builder.AddOffset(85, presentItemsLimitOffset.Value, 0);
		}

		// Token: 0x06003BE4 RID: 15332 RVA: 0x000C8304 File Offset: 0x000C6704
		public static Offset<ItemTable> EndItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemTable>(value);
		}

		// Token: 0x06003BE5 RID: 15333 RVA: 0x000C831E File Offset: 0x000C671E
		public static void FinishItemTableBuffer(FlatBufferBuilder builder, Offset<ItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001692 RID: 5778
		private Table __p = new Table();

		// Token: 0x04001693 RID: 5779
		private FlatBufferArray<int> OccuValue;

		// Token: 0x04001694 RID: 5780
		private FlatBufferArray<int> Occu2Value;

		// Token: 0x04001695 RID: 5781
		private FlatBufferArray<int> ComeLinkValue;

		// Token: 0x04001696 RID: 5782
		private FlatBufferArray<int> RelationIDValue;

		// Token: 0x04001697 RID: 5783
		private FlatBufferArray<string> Path2Value;

		// Token: 0x04001698 RID: 5784
		private FlatBufferArray<int> MutexBuffValue;

		// Token: 0x04001699 RID: 5785
		private FlatBufferArray<string> RenewInfoValue;

		// Token: 0x0400169A RID: 5786
		private FlatBufferArray<int> jarGiftConsumeItemValue;

		// Token: 0x0400169B RID: 5787
		private FlatBufferArray<int> LvAdaptationValue;

		// Token: 0x020004BB RID: 1211
		public enum eType
		{
			// Token: 0x0400169D RID: 5789
			Type_None,
			// Token: 0x0400169E RID: 5790
			EQUIP,
			// Token: 0x0400169F RID: 5791
			EXPENDABLE,
			// Token: 0x040016A0 RID: 5792
			MATERIAL,
			// Token: 0x040016A1 RID: 5793
			TASK,
			// Token: 0x040016A2 RID: 5794
			FASHION,
			// Token: 0x040016A3 RID: 5795
			INCOME,
			// Token: 0x040016A4 RID: 5796
			ENERGY,
			// Token: 0x040016A5 RID: 5797
			FUCKTITTLE,
			// Token: 0x040016A6 RID: 5798
			VirtualPack,
			// Token: 0x040016A7 RID: 5799
			PET,
			// Token: 0x040016A8 RID: 5800
			HEAD_FRAME = 12,
			// Token: 0x040016A9 RID: 5801
			ITEM_NEWTITLE = 14,
			// Token: 0x040016AA RID: 5802
			SKILL_CHIJI = 13,
			// Token: 0x040016AB RID: 5803
			ITEM_INSCRIPTION = 15,
			// Token: 0x040016AC RID: 5804
			ITEM_MONOPOLY_CARD = 17
		}

		// Token: 0x020004BC RID: 1212
		public enum eEPrompt
		{
			// Token: 0x040016AE RID: 5806
			EPT_NONE,
			// Token: 0x040016AF RID: 5807
			EPT_NEW_EQUIP,
			// Token: 0x040016B0 RID: 5808
			EPT_RED_POINT
		}

		// Token: 0x020004BD RID: 1213
		public enum eSubType
		{
			// Token: 0x040016B2 RID: 5810
			ST_NONE,
			// Token: 0x040016B3 RID: 5811
			WEAPON,
			// Token: 0x040016B4 RID: 5812
			HEAD,
			// Token: 0x040016B5 RID: 5813
			CHEST,
			// Token: 0x040016B6 RID: 5814
			BELT,
			// Token: 0x040016B7 RID: 5815
			LEG,
			// Token: 0x040016B8 RID: 5816
			BOOT,
			// Token: 0x040016B9 RID: 5817
			RING,
			// Token: 0x040016BA RID: 5818
			NECKLASE,
			// Token: 0x040016BB RID: 5819
			BRACELET,
			// Token: 0x040016BC RID: 5820
			TITLE,
			// Token: 0x040016BD RID: 5821
			FASHION_HAIR,
			// Token: 0x040016BE RID: 5822
			FASHION_HEAD,
			// Token: 0x040016BF RID: 5823
			FASHION_SASH,
			// Token: 0x040016C0 RID: 5824
			FASHION_CHEST,
			// Token: 0x040016C1 RID: 5825
			FASHION_LEG,
			// Token: 0x040016C2 RID: 5826
			FASHION_EPAULET,
			// Token: 0x040016C3 RID: 5827
			GOLD,
			// Token: 0x040016C4 RID: 5828
			POINT,
			// Token: 0x040016C5 RID: 5829
			EXP,
			// Token: 0x040016C6 RID: 5830
			DRUG,
			// Token: 0x040016C7 RID: 5831
			WARRIOR_SOUL = 22,
			// Token: 0x040016C8 RID: 5832
			DUEL_COIN,
			// Token: 0x040016C9 RID: 5833
			MATERIAL_JINGPO,
			// Token: 0x040016CA RID: 5834
			EnchantmentsCard,
			// Token: 0x040016CB RID: 5835
			ResurrectionCcurrency,
			// Token: 0x040016CC RID: 5836
			BindGOLD,
			// Token: 0x040016CD RID: 5837
			BindPOINT,
			// Token: 0x040016CE RID: 5838
			GiftPackage,
			// Token: 0x040016CF RID: 5839
			GuildContri,
			// Token: 0x040016D0 RID: 5840
			SP,
			// Token: 0x040016D1 RID: 5841
			EnergyStone,
			// Token: 0x040016D2 RID: 5842
			Coupon,
			// Token: 0x040016D3 RID: 5843
			MonthCard,
			// Token: 0x040016D4 RID: 5844
			Jar,
			// Token: 0x040016D5 RID: 5845
			GiftBox,
			// Token: 0x040016D6 RID: 5846
			FatigueDrug,
			// Token: 0x040016D7 RID: 5847
			Drawing,
			// Token: 0x040016D8 RID: 5848
			Fragment,
			// Token: 0x040016D9 RID: 5849
			VipExp,
			// Token: 0x040016DA RID: 5850
			ExperiencePill,
			// Token: 0x040016DB RID: 5851
			GoldJarPoint,
			// Token: 0x040016DC RID: 5852
			MagicJarPoint,
			// Token: 0x040016DD RID: 5853
			PetEgg,
			// Token: 0x040016DE RID: 5854
			ST_FASHION_COMPOSER,
			// Token: 0x040016DF RID: 5855
			MoneyManageCard,
			// Token: 0x040016E0 RID: 5856
			Hp = 50,
			// Token: 0x040016E1 RID: 5857
			Mp,
			// Token: 0x040016E2 RID: 5858
			HpMp,
			// Token: 0x040016E3 RID: 5859
			ChangeName,
			// Token: 0x040016E4 RID: 5860
			Bead,
			// Token: 0x040016E5 RID: 5861
			MagicBox,
			// Token: 0x040016E6 RID: 5862
			MagicHammer,
			// Token: 0x040016E7 RID: 5863
			Param,
			// Token: 0x040016E8 RID: 5864
			ST_JAR_GIFT,
			// Token: 0x040016E9 RID: 5865
			ChargeActivityScore = 60,
			// Token: 0x040016EA RID: 5866
			ST_ADD_VIP_POINT,
			// Token: 0x040016EB RID: 5867
			AttributeDrug,
			// Token: 0x040016EC RID: 5868
			ST_APPOINTMENT_COIN = 70,
			// Token: 0x040016ED RID: 5869
			LOTTERY_COIN,
			// Token: 0x040016EE RID: 5870
			Perfect_washing,
			// Token: 0x040016EF RID: 5871
			ST_CONSUME_JAR_GIFT,
			// Token: 0x040016F0 RID: 5872
			ST_PRIMARY_RAFFLE_TICKETS,
			// Token: 0x040016F1 RID: 5873
			ST_MIDDLE_RAFFLE_TICKETS,
			// Token: 0x040016F2 RID: 5874
			ST_SENIOR_RAFFLE_TICKETS,
			// Token: 0x040016F3 RID: 5875
			ST_MASTER_ACADEMIC_VALUE = 78,
			// Token: 0x040016F4 RID: 5876
			ST_MASTER_GOODTEACH_VALUE,
			// Token: 0x040016F5 RID: 5877
			ST_RETURN_TOKEN,
			// Token: 0x040016F6 RID: 5878
			FASHION_WEAPON,
			// Token: 0x040016F7 RID: 5879
			ST_CHANGE_FASHION_ACTIVE_TICKET,
			// Token: 0x040016F8 RID: 5880
			ST_DRESS_INTEGRAL_VALUE,
			// Token: 0x040016F9 RID: 5881
			ST_WEAPON_LEASE_TICKET,
			// Token: 0x040016FA RID: 5882
			ST_EXTENSIBLE_ROLE_CARD,
			// Token: 0x040016FB RID: 5883
			ST_UP_LEVEL_BOOK,
			// Token: 0x040016FC RID: 5884
			ST_BLESS_CRYSTAL_VALUE,
			// Token: 0x040016FD RID: 5885
			ST_INHERIT_BLESS_VALUE,
			// Token: 0x040016FE RID: 5886
			ST_PEARL_HAMMER,
			// Token: 0x040016FF RID: 5887
			ST_DIAMOND_HAMMER,
			// Token: 0x04001700 RID: 5888
			ST_GOLD_REWARD_VALUE,
			// Token: 0x04001701 RID: 5889
			FASHION_AURAS,
			// Token: 0x04001702 RID: 5890
			DiscountCoupon,
			// Token: 0x04001703 RID: 5891
			ST_NEW_TITLE,
			// Token: 0x04001704 RID: 5892
			ChijiHp,
			// Token: 0x04001705 RID: 5893
			ChijiMoveSpeed,
			// Token: 0x04001706 RID: 5894
			ChijiGrenade,
			// Token: 0x04001707 RID: 5895
			ChijiBuff,
			// Token: 0x04001708 RID: 5896
			ST_ASSIST_EQUIP,
			// Token: 0x04001709 RID: 5897
			ST_MAGICSTONE_EQUIP,
			// Token: 0x0400170A RID: 5898
			ST_EARRINGS_EQUIP,
			// Token: 0x0400170B RID: 5899
			ST_ZENGFU_MATERIAL,
			// Token: 0x0400170C RID: 5900
			ST_ZENGFU_ACTIVATE,
			// Token: 0x0400170D RID: 5901
			ST_ZENGFU_CLEANUP,
			// Token: 0x0400170E RID: 5902
			ST_ZENGFU_CHANGE,
			// Token: 0x0400170F RID: 5903
			ST_ZENGFU_CREATE,
			// Token: 0x04001710 RID: 5904
			ST_ZENGFU_OVERLOAD,
			// Token: 0x04001711 RID: 5905
			ST_ZENGFU_PROTECT,
			// Token: 0x04001712 RID: 5906
			ST_ZENGFU_AMPLIFICATION,
			// Token: 0x04001713 RID: 5907
			ST_CHIJI_TRAP,
			// Token: 0x04001714 RID: 5908
			ST_ACHIEVEMENT_POINT,
			// Token: 0x04001715 RID: 5909
			ST_CHI_JI_COIN,
			// Token: 0x04001716 RID: 5910
			ST_STRENGTHEN_PROTECT,
			// Token: 0x04001717 RID: 5911
			ST_ZJSL_WZHJJJ_COIN,
			// Token: 0x04001718 RID: 5912
			ST_ZJSL_WZHGGG_COIN,
			// Token: 0x04001719 RID: 5913
			ST_MALL_POINT,
			// Token: 0x0400171A RID: 5914
			ST_INSCRIPTION,
			// Token: 0x0400171B RID: 5915
			ST_FLYUPITEM,
			// Token: 0x0400171C RID: 5916
			ST_ADVENTURE_COIN,
			// Token: 0x0400171D RID: 5917
			ST_VIRTUAL,
			// Token: 0x0400171E RID: 5918
			ST_WANSHENGJIE_VIRTUAL,
			// Token: 0x0400171F RID: 5919
			ST_ADVENTURE_PASS_EXP = 123,
			// Token: 0x04001720 RID: 5920
			ST_ADVENTURE_PASS_ACTIVATE_ITEM,
			// Token: 0x04001721 RID: 5921
			ST_FRIEND_PRESENT,
			// Token: 0x04001722 RID: 5922
			ST_HONOR_SCORE,
			// Token: 0x04001723 RID: 5923
			ST_SPRING_SCORE,
			// Token: 0x04001724 RID: 5924
			ST_CHIJI_SKILL,
			// Token: 0x04001725 RID: 5925
			ST_CHIJI_SHOP_COIN,
			// Token: 0x04001726 RID: 5926
			ST_HIRE_COIN,
			// Token: 0x04001727 RID: 5927
			ST_TEAM_COPY_CNT,
			// Token: 0x04001728 RID: 5928
			ST_HONOR_GUARD_CARD,
			// Token: 0x04001729 RID: 5929
			ST_ADVENTURE_KING,
			// Token: 0x0400172A RID: 5930
			ST_TEAM_COPY_DIFF_CNT = 140,
			// Token: 0x0400172B RID: 5931
			ST_MAGIC_DISCOUNT = 142,
			// Token: 0x0400172C RID: 5932
			ST_CHAMPION_COIN = 145,
			// Token: 0x0400172D RID: 5933
			ST_RANDOM_SHARPEN,
			// Token: 0x0400172E RID: 5934
			ST_STRENTH_LUCK,
			// Token: 0x0400172F RID: 5935
			ST_GIFT_RIGHT_CARD = 149,
			// Token: 0x04001730 RID: 5936
			ST_CREDIT_POINT,
			// Token: 0x04001731 RID: 5937
			ST_DEEP_TICKET,
			// Token: 0x04001732 RID: 5938
			ST_FANTASY_COIN = 154,
			// Token: 0x04001733 RID: 5939
			ST_MONOPOLY_CARD,
			// Token: 0x04001734 RID: 5940
			ST_MONOPOLY_ROLL,
			// Token: 0x04001735 RID: 5941
			ST_SECRET_SELL_COIN,
			// Token: 0x04001736 RID: 5942
			ST_MONOPOLY_BUFF,
			// Token: 0x04001737 RID: 5943
			ST_ANCIENT_TICKET,
			// Token: 0x04001738 RID: 5944
			ST_SORROW_MEMENTO,
			// Token: 0x04001739 RID: 5945
			ST_DEEP_CARD
		}

		// Token: 0x020004BE RID: 1214
		public enum eThirdType
		{
			// Token: 0x0400173B RID: 5947
			TT_NONE,
			// Token: 0x0400173C RID: 5948
			HUGESWORD,
			// Token: 0x0400173D RID: 5949
			KATANA,
			// Token: 0x0400173E RID: 5950
			SHORTSWORD,
			// Token: 0x0400173F RID: 5951
			BEAMSWORD,
			// Token: 0x04001740 RID: 5952
			BLUNT,
			// Token: 0x04001741 RID: 5953
			REVOLVER,
			// Token: 0x04001742 RID: 5954
			CROSSBOW,
			// Token: 0x04001743 RID: 5955
			HANDCANNON,
			// Token: 0x04001744 RID: 5956
			RIFLE,
			// Token: 0x04001745 RID: 5957
			PISTOL,
			// Token: 0x04001746 RID: 5958
			STAFF,
			// Token: 0x04001747 RID: 5959
			WAND,
			// Token: 0x04001748 RID: 5960
			SPEAR,
			// Token: 0x04001749 RID: 5961
			STICK,
			// Token: 0x0400174A RID: 5962
			BESOM,
			// Token: 0x0400174B RID: 5963
			GLOVE,
			// Token: 0x0400174C RID: 5964
			BIKAI,
			// Token: 0x0400174D RID: 5965
			CLAW,
			// Token: 0x0400174E RID: 5966
			OFG,
			// Token: 0x0400174F RID: 5967
			EAST_STICK,
			// Token: 0x04001750 RID: 5968
			SICKLE,
			// Token: 0x04001751 RID: 5969
			TOTEM,
			// Token: 0x04001752 RID: 5970
			AXE,
			// Token: 0x04001753 RID: 5971
			BEADS,
			// Token: 0x04001754 RID: 5972
			CROSS,
			// Token: 0x04001755 RID: 5973
			CLOTH = 51,
			// Token: 0x04001756 RID: 5974
			SKIN,
			// Token: 0x04001757 RID: 5975
			LIGHT,
			// Token: 0x04001758 RID: 5976
			HEAVY,
			// Token: 0x04001759 RID: 5977
			PLATE,
			// Token: 0x0400175A RID: 5978
			FASHION_JUNIOR = 100,
			// Token: 0x0400175B RID: 5979
			FASHION_SENIOR,
			// Token: 0x0400175C RID: 5980
			FASHION_FESTIVAL,
			// Token: 0x0400175D RID: 5981
			COMPOSER_JUNIOR,
			// Token: 0x0400175E RID: 5982
			COMPOSER_SENIOR,
			// Token: 0x0400175F RID: 5983
			ZENGFU_COLOR_PURPLE = 200,
			// Token: 0x04001760 RID: 5984
			ZENGFU_COLOR_PINKUP,
			// Token: 0x04001761 RID: 5985
			ZENGFU_COLOR_GREEN,
			// Token: 0x04001762 RID: 5986
			DisposableStrengItem,
			// Token: 0x04001763 RID: 5987
			DisposableIncreaseItem,
			// Token: 0x04001764 RID: 5988
			VoidCrackTicket,
			// Token: 0x04001765 RID: 5989
			SmallFatigueDrug = 300,
			// Token: 0x04001766 RID: 5990
			MiddleFatigueDrug,
			// Token: 0x04001767 RID: 5991
			BigFatigueDrug,
			// Token: 0x04001768 RID: 5992
			BatteDrug = 401,
			// Token: 0x04001769 RID: 5993
			ChangePlayerName = 500,
			// Token: 0x0400176A RID: 5994
			ChangeGuildName,
			// Token: 0x0400176B RID: 5995
			GoldTitle,
			// Token: 0x0400176C RID: 5996
			ChangeAdventureName,
			// Token: 0x0400176D RID: 5997
			ExtensibleRoleCard,
			// Token: 0x0400176E RID: 5998
			UpLevelBook,
			// Token: 0x0400176F RID: 5999
			IT_ITEM_CONVERTOR_SAME,
			// Token: 0x04001770 RID: 6000
			IT_ITEM_CONVERTOR_DIFF,
			// Token: 0x04001771 RID: 6001
			GoddessTear = 600,
			// Token: 0x04001772 RID: 6002
			LevelShow,
			// Token: 0x04001773 RID: 6003
			PowerGem = 611,
			// Token: 0x04001774 RID: 6004
			IntelligenceGem,
			// Token: 0x04001775 RID: 6005
			LivesGem,
			// Token: 0x04001776 RID: 6006
			SpiritGem,
			// Token: 0x04001777 RID: 6007
			CritsGem,
			// Token: 0x04001778 RID: 6008
			MagicGem,
			// Token: 0x04001779 RID: 6009
			PreciseGem,
			// Token: 0x0400177A RID: 6010
			RapidlyGem,
			// Token: 0x0400177B RID: 6011
			DischargeGem,
			// Token: 0x0400177C RID: 6012
			ElementGem,
			// Token: 0x0400177D RID: 6013
			SkillGem,
			// Token: 0x0400177E RID: 6014
			FashionGift,
			// Token: 0x0400177F RID: 6015
			HaloGift,
			// Token: 0x04001780 RID: 6016
			UseToSelf = 701,
			// Token: 0x04001781 RID: 6017
			UseToOther,
			// Token: 0x04001782 RID: 6018
			ChijiGiftPackage,
			// Token: 0x04001783 RID: 6019
			ST_CHIJI_MIANZHAN = 129,
			// Token: 0x04001784 RID: 6020
			RedInscription = 800,
			// Token: 0x04001785 RID: 6021
			YellowInscription,
			// Token: 0x04001786 RID: 6022
			BlueInscription,
			// Token: 0x04001787 RID: 6023
			DarkBlondInscription,
			// Token: 0x04001788 RID: 6024
			BrilliantGoldenInscription,
			// Token: 0x04001789 RID: 6025
			OrangeInscription,
			// Token: 0x0400178A RID: 6026
			GreenInscription,
			// Token: 0x0400178B RID: 6027
			VioletInscription
		}

		// Token: 0x020004BF RID: 1215
		public enum eColor
		{
			// Token: 0x0400178D RID: 6029
			CL_NONE,
			// Token: 0x0400178E RID: 6030
			WHITE,
			// Token: 0x0400178F RID: 6031
			BLUE,
			// Token: 0x04001790 RID: 6032
			PURPLE,
			// Token: 0x04001791 RID: 6033
			GREEN,
			// Token: 0x04001792 RID: 6034
			PINK,
			// Token: 0x04001793 RID: 6035
			YELLOW
		}

		// Token: 0x020004C0 RID: 1216
		public enum eCanUse
		{
			// Token: 0x04001795 RID: 6037
			CanNot,
			// Token: 0x04001796 RID: 6038
			UseOne,
			// Token: 0x04001797 RID: 6039
			UseTotal
		}

		// Token: 0x020004C1 RID: 1217
		public enum eOwner
		{
			// Token: 0x04001799 RID: 6041
			Owner_None,
			// Token: 0x0400179A RID: 6042
			NOTBIND,
			// Token: 0x0400179B RID: 6043
			ROLEBIND,
			// Token: 0x0400179C RID: 6044
			ACCBIND
		}

		// Token: 0x020004C2 RID: 1218
		public enum eComeType
		{
			// Token: 0x0400179E RID: 6046
			CT_SHOP,
			// Token: 0x0400179F RID: 6047
			CT_MISSION,
			// Token: 0x040017A0 RID: 6048
			CT_ACTIVITY
		}

		// Token: 0x020004C3 RID: 1219
		public enum eUseLimiteType
		{
			// Token: 0x040017A2 RID: 6050
			NOLIMITE,
			// Token: 0x040017A3 RID: 6051
			DAYLIMITE,
			// Token: 0x040017A4 RID: 6052
			VIPLIMITE,
			// Token: 0x040017A5 RID: 6053
			TEAMCOPYLIMITE,
			// Token: 0x040017A6 RID: 6054
			HONORLV,
			// Token: 0x040017A7 RID: 6055
			SUITLV,
			// Token: 0x040017A8 RID: 6056
			WEEK6LIMITE
		}

		// Token: 0x020004C4 RID: 1220
		public enum eCrypt
		{
			// Token: 0x040017AA RID: 6058
			code = 121260803
		}
	}
}
