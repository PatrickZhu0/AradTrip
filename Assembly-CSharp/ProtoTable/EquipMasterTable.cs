using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003F5 RID: 1013
	public class EquipMasterTable : IFlatbufferObject
	{
		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06002E27 RID: 11815 RVA: 0x000A80AC File Offset: 0x000A64AC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002E28 RID: 11816 RVA: 0x000A80B9 File Offset: 0x000A64B9
		public static EquipMasterTable GetRootAsEquipMasterTable(ByteBuffer _bb)
		{
			return EquipMasterTable.GetRootAsEquipMasterTable(_bb, new EquipMasterTable());
		}

		// Token: 0x06002E29 RID: 11817 RVA: 0x000A80C6 File Offset: 0x000A64C6
		public static EquipMasterTable GetRootAsEquipMasterTable(ByteBuffer _bb, EquipMasterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002E2A RID: 11818 RVA: 0x000A80E2 File Offset: 0x000A64E2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002E2B RID: 11819 RVA: 0x000A80FC File Offset: 0x000A64FC
		public EquipMasterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06002E2C RID: 11820 RVA: 0x000A8108 File Offset: 0x000A6508
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06002E2D RID: 11821 RVA: 0x000A8154 File Offset: 0x000A6554
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06002E2E RID: 11822 RVA: 0x000A81A0 File Offset: 0x000A65A0
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06002E2F RID: 11823 RVA: 0x000A81EC File Offset: 0x000A65EC
		public int Part
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x06002E30 RID: 11824 RVA: 0x000A8238 File Offset: 0x000A6638
		public int MaterialType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002E31 RID: 11825 RVA: 0x000A8284 File Offset: 0x000A6684
		public int AtkArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x06002E32 RID: 11826 RVA: 0x000A82D4 File Offset: 0x000A66D4
		public int AtkLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x000A8307 File Offset: 0x000A6707
		public ArraySegment<byte>? GetAtkBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06002E34 RID: 11828 RVA: 0x000A8316 File Offset: 0x000A6716
		public FlatBufferArray<int> Atk
		{
			get
			{
				if (this.AtkValue == null)
				{
					this.AtkValue = new FlatBufferArray<int>(new Func<int, int>(this.AtkArray), this.AtkLength);
				}
				return this.AtkValue;
			}
		}

		// Token: 0x06002E35 RID: 11829 RVA: 0x000A8348 File Offset: 0x000A6748
		public int MagicAtkArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06002E36 RID: 11830 RVA: 0x000A8398 File Offset: 0x000A6798
		public int MagicAtkLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E37 RID: 11831 RVA: 0x000A83CB File Offset: 0x000A67CB
		public ArraySegment<byte>? GetMagicAtkBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06002E38 RID: 11832 RVA: 0x000A83DA File Offset: 0x000A67DA
		public FlatBufferArray<int> MagicAtk
		{
			get
			{
				if (this.MagicAtkValue == null)
				{
					this.MagicAtkValue = new FlatBufferArray<int>(new Func<int, int>(this.MagicAtkArray), this.MagicAtkLength);
				}
				return this.MagicAtkValue;
			}
		}

		// Token: 0x06002E39 RID: 11833 RVA: 0x000A840C File Offset: 0x000A680C
		public int DefArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06002E3A RID: 11834 RVA: 0x000A845C File Offset: 0x000A685C
		public int DefLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E3B RID: 11835 RVA: 0x000A848F File Offset: 0x000A688F
		public ArraySegment<byte>? GetDefBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x06002E3C RID: 11836 RVA: 0x000A849E File Offset: 0x000A689E
		public FlatBufferArray<int> Def
		{
			get
			{
				if (this.DefValue == null)
				{
					this.DefValue = new FlatBufferArray<int>(new Func<int, int>(this.DefArray), this.DefLength);
				}
				return this.DefValue;
			}
		}

		// Token: 0x06002E3D RID: 11837 RVA: 0x000A84D0 File Offset: 0x000A68D0
		public int MagicDefArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06002E3E RID: 11838 RVA: 0x000A8520 File Offset: 0x000A6920
		public int MagicDefLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E3F RID: 11839 RVA: 0x000A8553 File Offset: 0x000A6953
		public ArraySegment<byte>? GetMagicDefBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06002E40 RID: 11840 RVA: 0x000A8562 File Offset: 0x000A6962
		public FlatBufferArray<int> MagicDef
		{
			get
			{
				if (this.MagicDefValue == null)
				{
					this.MagicDefValue = new FlatBufferArray<int>(new Func<int, int>(this.MagicDefArray), this.MagicDefLength);
				}
				return this.MagicDefValue;
			}
		}

		// Token: 0x06002E41 RID: 11841 RVA: 0x000A8594 File Offset: 0x000A6994
		public int StrenthArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06002E42 RID: 11842 RVA: 0x000A85E4 File Offset: 0x000A69E4
		public int StrenthLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E43 RID: 11843 RVA: 0x000A8617 File Offset: 0x000A6A17
		public ArraySegment<byte>? GetStrenthBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x06002E44 RID: 11844 RVA: 0x000A8626 File Offset: 0x000A6A26
		public FlatBufferArray<int> Strenth
		{
			get
			{
				if (this.StrenthValue == null)
				{
					this.StrenthValue = new FlatBufferArray<int>(new Func<int, int>(this.StrenthArray), this.StrenthLength);
				}
				return this.StrenthValue;
			}
		}

		// Token: 0x06002E45 RID: 11845 RVA: 0x000A8658 File Offset: 0x000A6A58
		public int IntellectArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x06002E46 RID: 11846 RVA: 0x000A86A8 File Offset: 0x000A6AA8
		public int IntellectLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E47 RID: 11847 RVA: 0x000A86DB File Offset: 0x000A6ADB
		public ArraySegment<byte>? GetIntellectBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x06002E48 RID: 11848 RVA: 0x000A86EA File Offset: 0x000A6AEA
		public FlatBufferArray<int> Intellect
		{
			get
			{
				if (this.IntellectValue == null)
				{
					this.IntellectValue = new FlatBufferArray<int>(new Func<int, int>(this.IntellectArray), this.IntellectLength);
				}
				return this.IntellectValue;
			}
		}

		// Token: 0x06002E49 RID: 11849 RVA: 0x000A871C File Offset: 0x000A6B1C
		public int SpiritArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x06002E4A RID: 11850 RVA: 0x000A876C File Offset: 0x000A6B6C
		public int SpiritLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E4B RID: 11851 RVA: 0x000A879F File Offset: 0x000A6B9F
		public ArraySegment<byte>? GetSpiritBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x06002E4C RID: 11852 RVA: 0x000A87AE File Offset: 0x000A6BAE
		public FlatBufferArray<int> Spirit
		{
			get
			{
				if (this.SpiritValue == null)
				{
					this.SpiritValue = new FlatBufferArray<int>(new Func<int, int>(this.SpiritArray), this.SpiritLength);
				}
				return this.SpiritValue;
			}
		}

		// Token: 0x06002E4D RID: 11853 RVA: 0x000A87E0 File Offset: 0x000A6BE0
		public int StaminaArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x06002E4E RID: 11854 RVA: 0x000A8830 File Offset: 0x000A6C30
		public int StaminaLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E4F RID: 11855 RVA: 0x000A8863 File Offset: 0x000A6C63
		public ArraySegment<byte>? GetStaminaBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x06002E50 RID: 11856 RVA: 0x000A8872 File Offset: 0x000A6C72
		public FlatBufferArray<int> Stamina
		{
			get
			{
				if (this.StaminaValue == null)
				{
					this.StaminaValue = new FlatBufferArray<int>(new Func<int, int>(this.StaminaArray), this.StaminaLength);
				}
				return this.StaminaValue;
			}
		}

		// Token: 0x06002E51 RID: 11857 RVA: 0x000A88A4 File Offset: 0x000A6CA4
		public int HPMaxArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x06002E52 RID: 11858 RVA: 0x000A88F4 File Offset: 0x000A6CF4
		public int HPMaxLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E53 RID: 11859 RVA: 0x000A8927 File Offset: 0x000A6D27
		public ArraySegment<byte>? GetHPMaxBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x06002E54 RID: 11860 RVA: 0x000A8936 File Offset: 0x000A6D36
		public FlatBufferArray<int> HPMax
		{
			get
			{
				if (this.HPMaxValue == null)
				{
					this.HPMaxValue = new FlatBufferArray<int>(new Func<int, int>(this.HPMaxArray), this.HPMaxLength);
				}
				return this.HPMaxValue;
			}
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x000A8968 File Offset: 0x000A6D68
		public int MPMaxArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x06002E56 RID: 11862 RVA: 0x000A89B8 File Offset: 0x000A6DB8
		public int MPMaxLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E57 RID: 11863 RVA: 0x000A89EB File Offset: 0x000A6DEB
		public ArraySegment<byte>? GetMPMaxBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x06002E58 RID: 11864 RVA: 0x000A89FA File Offset: 0x000A6DFA
		public FlatBufferArray<int> MPMax
		{
			get
			{
				if (this.MPMaxValue == null)
				{
					this.MPMaxValue = new FlatBufferArray<int>(new Func<int, int>(this.MPMaxArray), this.MPMaxLength);
				}
				return this.MPMaxValue;
			}
		}

		// Token: 0x06002E59 RID: 11865 RVA: 0x000A8A2C File Offset: 0x000A6E2C
		public int HPRecoverArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B1D RID: 2845
		// (get) Token: 0x06002E5A RID: 11866 RVA: 0x000A8A7C File Offset: 0x000A6E7C
		public int HPRecoverLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E5B RID: 11867 RVA: 0x000A8AAF File Offset: 0x000A6EAF
		public ArraySegment<byte>? GetHPRecoverBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000B1E RID: 2846
		// (get) Token: 0x06002E5C RID: 11868 RVA: 0x000A8ABE File Offset: 0x000A6EBE
		public FlatBufferArray<int> HPRecover
		{
			get
			{
				if (this.HPRecoverValue == null)
				{
					this.HPRecoverValue = new FlatBufferArray<int>(new Func<int, int>(this.HPRecoverArray), this.HPRecoverLength);
				}
				return this.HPRecoverValue;
			}
		}

		// Token: 0x06002E5D RID: 11869 RVA: 0x000A8AF0 File Offset: 0x000A6EF0
		public int MPRecoverArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B1F RID: 2847
		// (get) Token: 0x06002E5E RID: 11870 RVA: 0x000A8B40 File Offset: 0x000A6F40
		public int MPRecoverLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E5F RID: 11871 RVA: 0x000A8B73 File Offset: 0x000A6F73
		public ArraySegment<byte>? GetMPRecoverBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x06002E60 RID: 11872 RVA: 0x000A8B82 File Offset: 0x000A6F82
		public FlatBufferArray<int> MPRecover
		{
			get
			{
				if (this.MPRecoverValue == null)
				{
					this.MPRecoverValue = new FlatBufferArray<int>(new Func<int, int>(this.MPRecoverArray), this.MPRecoverLength);
				}
				return this.MPRecoverValue;
			}
		}

		// Token: 0x06002E61 RID: 11873 RVA: 0x000A8BB4 File Offset: 0x000A6FB4
		public int AttackSpeedRateArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x06002E62 RID: 11874 RVA: 0x000A8C04 File Offset: 0x000A7004
		public int AttackSpeedRateLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E63 RID: 11875 RVA: 0x000A8C37 File Offset: 0x000A7037
		public ArraySegment<byte>? GetAttackSpeedRateBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x06002E64 RID: 11876 RVA: 0x000A8C46 File Offset: 0x000A7046
		public FlatBufferArray<int> AttackSpeedRate
		{
			get
			{
				if (this.AttackSpeedRateValue == null)
				{
					this.AttackSpeedRateValue = new FlatBufferArray<int>(new Func<int, int>(this.AttackSpeedRateArray), this.AttackSpeedRateLength);
				}
				return this.AttackSpeedRateValue;
			}
		}

		// Token: 0x06002E65 RID: 11877 RVA: 0x000A8C78 File Offset: 0x000A7078
		public int FireSpeedRateArray(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x06002E66 RID: 11878 RVA: 0x000A8CC8 File Offset: 0x000A70C8
		public int FireSpeedRateLength
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E67 RID: 11879 RVA: 0x000A8CFB File Offset: 0x000A70FB
		public ArraySegment<byte>? GetFireSpeedRateBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x06002E68 RID: 11880 RVA: 0x000A8D0A File Offset: 0x000A710A
		public FlatBufferArray<int> FireSpeedRate
		{
			get
			{
				if (this.FireSpeedRateValue == null)
				{
					this.FireSpeedRateValue = new FlatBufferArray<int>(new Func<int, int>(this.FireSpeedRateArray), this.FireSpeedRateLength);
				}
				return this.FireSpeedRateValue;
			}
		}

		// Token: 0x06002E69 RID: 11881 RVA: 0x000A8D3C File Offset: 0x000A713C
		public int MoveSpeedRateArray(int j)
		{
			int num = this.__p.__offset(42);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x06002E6A RID: 11882 RVA: 0x000A8D8C File Offset: 0x000A718C
		public int MoveSpeedRateLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E6B RID: 11883 RVA: 0x000A8DBF File Offset: 0x000A71BF
		public ArraySegment<byte>? GetMoveSpeedRateBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x06002E6C RID: 11884 RVA: 0x000A8DCE File Offset: 0x000A71CE
		public FlatBufferArray<int> MoveSpeedRate
		{
			get
			{
				if (this.MoveSpeedRateValue == null)
				{
					this.MoveSpeedRateValue = new FlatBufferArray<int>(new Func<int, int>(this.MoveSpeedRateArray), this.MoveSpeedRateLength);
				}
				return this.MoveSpeedRateValue;
			}
		}

		// Token: 0x06002E6D RID: 11885 RVA: 0x000A8E00 File Offset: 0x000A7200
		public int HitRateArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x06002E6E RID: 11886 RVA: 0x000A8E50 File Offset: 0x000A7250
		public int HitRateLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E6F RID: 11887 RVA: 0x000A8E83 File Offset: 0x000A7283
		public ArraySegment<byte>? GetHitRateBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000B28 RID: 2856
		// (get) Token: 0x06002E70 RID: 11888 RVA: 0x000A8E92 File Offset: 0x000A7292
		public FlatBufferArray<int> HitRate
		{
			get
			{
				if (this.HitRateValue == null)
				{
					this.HitRateValue = new FlatBufferArray<int>(new Func<int, int>(this.HitRateArray), this.HitRateLength);
				}
				return this.HitRateValue;
			}
		}

		// Token: 0x06002E71 RID: 11889 RVA: 0x000A8EC4 File Offset: 0x000A72C4
		public int AvoidRateArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B29 RID: 2857
		// (get) Token: 0x06002E72 RID: 11890 RVA: 0x000A8F14 File Offset: 0x000A7314
		public int AvoidRateLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E73 RID: 11891 RVA: 0x000A8F47 File Offset: 0x000A7347
		public ArraySegment<byte>? GetAvoidRateBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000B2A RID: 2858
		// (get) Token: 0x06002E74 RID: 11892 RVA: 0x000A8F56 File Offset: 0x000A7356
		public FlatBufferArray<int> AvoidRate
		{
			get
			{
				if (this.AvoidRateValue == null)
				{
					this.AvoidRateValue = new FlatBufferArray<int>(new Func<int, int>(this.AvoidRateArray), this.AvoidRateLength);
				}
				return this.AvoidRateValue;
			}
		}

		// Token: 0x06002E75 RID: 11893 RVA: 0x000A8F88 File Offset: 0x000A7388
		public int PhysicCritArray(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B2B RID: 2859
		// (get) Token: 0x06002E76 RID: 11894 RVA: 0x000A8FD8 File Offset: 0x000A73D8
		public int PhysicCritLength
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E77 RID: 11895 RVA: 0x000A900B File Offset: 0x000A740B
		public ArraySegment<byte>? GetPhysicCritBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x06002E78 RID: 11896 RVA: 0x000A901A File Offset: 0x000A741A
		public FlatBufferArray<int> PhysicCrit
		{
			get
			{
				if (this.PhysicCritValue == null)
				{
					this.PhysicCritValue = new FlatBufferArray<int>(new Func<int, int>(this.PhysicCritArray), this.PhysicCritLength);
				}
				return this.PhysicCritValue;
			}
		}

		// Token: 0x06002E79 RID: 11897 RVA: 0x000A904C File Offset: 0x000A744C
		public int MagicCritArray(int j)
		{
			int num = this.__p.__offset(50);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x06002E7A RID: 11898 RVA: 0x000A909C File Offset: 0x000A749C
		public int MagicCritLength
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E7B RID: 11899 RVA: 0x000A90CF File Offset: 0x000A74CF
		public ArraySegment<byte>? GetMagicCritBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x06002E7C RID: 11900 RVA: 0x000A90DE File Offset: 0x000A74DE
		public FlatBufferArray<int> MagicCrit
		{
			get
			{
				if (this.MagicCritValue == null)
				{
					this.MagicCritValue = new FlatBufferArray<int>(new Func<int, int>(this.MagicCritArray), this.MagicCritLength);
				}
				return this.MagicCritValue;
			}
		}

		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x06002E7D RID: 11901 RVA: 0x000A9110 File Offset: 0x000A7510
		public int IsMaster
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x000A915C File Offset: 0x000A755C
		public int SpasticityArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (1673379914 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x06002E7F RID: 11903 RVA: 0x000A91AC File Offset: 0x000A75AC
		public int SpasticityLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002E80 RID: 11904 RVA: 0x000A91DF File Offset: 0x000A75DF
		public ArraySegment<byte>? GetSpasticityBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x06002E81 RID: 11905 RVA: 0x000A91EE File Offset: 0x000A75EE
		public FlatBufferArray<int> Spasticity
		{
			get
			{
				if (this.SpasticityValue == null)
				{
					this.SpasticityValue = new FlatBufferArray<int>(new Func<int, int>(this.SpasticityArray), this.SpasticityLength);
				}
				return this.SpasticityValue;
			}
		}

		// Token: 0x06002E82 RID: 11906 RVA: 0x000A9220 File Offset: 0x000A7620
		public string DescsArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x06002E83 RID: 11907 RVA: 0x000A9268 File Offset: 0x000A7668
		public int DescsLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000B33 RID: 2867
		// (get) Token: 0x06002E84 RID: 11908 RVA: 0x000A929B File Offset: 0x000A769B
		public FlatBufferArray<string> Descs
		{
			get
			{
				if (this.DescsValue == null)
				{
					this.DescsValue = new FlatBufferArray<string>(new Func<int, string>(this.DescsArray), this.DescsLength);
				}
				return this.DescsValue;
			}
		}

		// Token: 0x06002E85 RID: 11909 RVA: 0x000A92CC File Offset: 0x000A76CC
		public static Offset<EquipMasterTable> CreateEquipMasterTable(FlatBufferBuilder builder, int ID = 0, int JobID = 0, int Quality = 0, int Part = 0, int MaterialType = 0, VectorOffset AtkOffset = default(VectorOffset), VectorOffset MagicAtkOffset = default(VectorOffset), VectorOffset DefOffset = default(VectorOffset), VectorOffset MagicDefOffset = default(VectorOffset), VectorOffset StrenthOffset = default(VectorOffset), VectorOffset IntellectOffset = default(VectorOffset), VectorOffset SpiritOffset = default(VectorOffset), VectorOffset StaminaOffset = default(VectorOffset), VectorOffset HPMaxOffset = default(VectorOffset), VectorOffset MPMaxOffset = default(VectorOffset), VectorOffset HPRecoverOffset = default(VectorOffset), VectorOffset MPRecoverOffset = default(VectorOffset), VectorOffset AttackSpeedRateOffset = default(VectorOffset), VectorOffset FireSpeedRateOffset = default(VectorOffset), VectorOffset MoveSpeedRateOffset = default(VectorOffset), VectorOffset HitRateOffset = default(VectorOffset), VectorOffset AvoidRateOffset = default(VectorOffset), VectorOffset PhysicCritOffset = default(VectorOffset), VectorOffset MagicCritOffset = default(VectorOffset), int IsMaster = 0, VectorOffset SpasticityOffset = default(VectorOffset), VectorOffset DescsOffset = default(VectorOffset))
		{
			builder.StartObject(27);
			EquipMasterTable.AddDescs(builder, DescsOffset);
			EquipMasterTable.AddSpasticity(builder, SpasticityOffset);
			EquipMasterTable.AddIsMaster(builder, IsMaster);
			EquipMasterTable.AddMagicCrit(builder, MagicCritOffset);
			EquipMasterTable.AddPhysicCrit(builder, PhysicCritOffset);
			EquipMasterTable.AddAvoidRate(builder, AvoidRateOffset);
			EquipMasterTable.AddHitRate(builder, HitRateOffset);
			EquipMasterTable.AddMoveSpeedRate(builder, MoveSpeedRateOffset);
			EquipMasterTable.AddFireSpeedRate(builder, FireSpeedRateOffset);
			EquipMasterTable.AddAttackSpeedRate(builder, AttackSpeedRateOffset);
			EquipMasterTable.AddMPRecover(builder, MPRecoverOffset);
			EquipMasterTable.AddHPRecover(builder, HPRecoverOffset);
			EquipMasterTable.AddMPMax(builder, MPMaxOffset);
			EquipMasterTable.AddHPMax(builder, HPMaxOffset);
			EquipMasterTable.AddStamina(builder, StaminaOffset);
			EquipMasterTable.AddSpirit(builder, SpiritOffset);
			EquipMasterTable.AddIntellect(builder, IntellectOffset);
			EquipMasterTable.AddStrenth(builder, StrenthOffset);
			EquipMasterTable.AddMagicDef(builder, MagicDefOffset);
			EquipMasterTable.AddDef(builder, DefOffset);
			EquipMasterTable.AddMagicAtk(builder, MagicAtkOffset);
			EquipMasterTable.AddAtk(builder, AtkOffset);
			EquipMasterTable.AddMaterialType(builder, MaterialType);
			EquipMasterTable.AddPart(builder, Part);
			EquipMasterTable.AddQuality(builder, Quality);
			EquipMasterTable.AddJobID(builder, JobID);
			EquipMasterTable.AddID(builder, ID);
			return EquipMasterTable.EndEquipMasterTable(builder);
		}

		// Token: 0x06002E86 RID: 11910 RVA: 0x000A93BC File Offset: 0x000A77BC
		public static void StartEquipMasterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(27);
		}

		// Token: 0x06002E87 RID: 11911 RVA: 0x000A93C6 File Offset: 0x000A77C6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002E88 RID: 11912 RVA: 0x000A93D1 File Offset: 0x000A77D1
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(1, JobID, 0);
		}

		// Token: 0x06002E89 RID: 11913 RVA: 0x000A93DC File Offset: 0x000A77DC
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(2, Quality, 0);
		}

		// Token: 0x06002E8A RID: 11914 RVA: 0x000A93E7 File Offset: 0x000A77E7
		public static void AddPart(FlatBufferBuilder builder, int Part)
		{
			builder.AddInt(3, Part, 0);
		}

		// Token: 0x06002E8B RID: 11915 RVA: 0x000A93F2 File Offset: 0x000A77F2
		public static void AddMaterialType(FlatBufferBuilder builder, int MaterialType)
		{
			builder.AddInt(4, MaterialType, 0);
		}

		// Token: 0x06002E8C RID: 11916 RVA: 0x000A93FD File Offset: 0x000A77FD
		public static void AddAtk(FlatBufferBuilder builder, VectorOffset AtkOffset)
		{
			builder.AddOffset(5, AtkOffset.Value, 0);
		}

		// Token: 0x06002E8D RID: 11917 RVA: 0x000A9410 File Offset: 0x000A7810
		public static VectorOffset CreateAtkVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E8E RID: 11918 RVA: 0x000A944D File Offset: 0x000A784D
		public static void StartAtkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E8F RID: 11919 RVA: 0x000A9458 File Offset: 0x000A7858
		public static void AddMagicAtk(FlatBufferBuilder builder, VectorOffset MagicAtkOffset)
		{
			builder.AddOffset(6, MagicAtkOffset.Value, 0);
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x000A946C File Offset: 0x000A786C
		public static VectorOffset CreateMagicAtkVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x000A94A9 File Offset: 0x000A78A9
		public static void StartMagicAtkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E92 RID: 11922 RVA: 0x000A94B4 File Offset: 0x000A78B4
		public static void AddDef(FlatBufferBuilder builder, VectorOffset DefOffset)
		{
			builder.AddOffset(7, DefOffset.Value, 0);
		}

		// Token: 0x06002E93 RID: 11923 RVA: 0x000A94C8 File Offset: 0x000A78C8
		public static VectorOffset CreateDefVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E94 RID: 11924 RVA: 0x000A9505 File Offset: 0x000A7905
		public static void StartDefVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E95 RID: 11925 RVA: 0x000A9510 File Offset: 0x000A7910
		public static void AddMagicDef(FlatBufferBuilder builder, VectorOffset MagicDefOffset)
		{
			builder.AddOffset(8, MagicDefOffset.Value, 0);
		}

		// Token: 0x06002E96 RID: 11926 RVA: 0x000A9524 File Offset: 0x000A7924
		public static VectorOffset CreateMagicDefVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E97 RID: 11927 RVA: 0x000A9561 File Offset: 0x000A7961
		public static void StartMagicDefVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E98 RID: 11928 RVA: 0x000A956C File Offset: 0x000A796C
		public static void AddStrenth(FlatBufferBuilder builder, VectorOffset StrenthOffset)
		{
			builder.AddOffset(9, StrenthOffset.Value, 0);
		}

		// Token: 0x06002E99 RID: 11929 RVA: 0x000A9580 File Offset: 0x000A7980
		public static VectorOffset CreateStrenthVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E9A RID: 11930 RVA: 0x000A95BD File Offset: 0x000A79BD
		public static void StartStrenthVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E9B RID: 11931 RVA: 0x000A95C8 File Offset: 0x000A79C8
		public static void AddIntellect(FlatBufferBuilder builder, VectorOffset IntellectOffset)
		{
			builder.AddOffset(10, IntellectOffset.Value, 0);
		}

		// Token: 0x06002E9C RID: 11932 RVA: 0x000A95DC File Offset: 0x000A79DC
		public static VectorOffset CreateIntellectVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002E9D RID: 11933 RVA: 0x000A9619 File Offset: 0x000A7A19
		public static void StartIntellectVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002E9E RID: 11934 RVA: 0x000A9624 File Offset: 0x000A7A24
		public static void AddSpirit(FlatBufferBuilder builder, VectorOffset SpiritOffset)
		{
			builder.AddOffset(11, SpiritOffset.Value, 0);
		}

		// Token: 0x06002E9F RID: 11935 RVA: 0x000A9638 File Offset: 0x000A7A38
		public static VectorOffset CreateSpiritVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EA0 RID: 11936 RVA: 0x000A9675 File Offset: 0x000A7A75
		public static void StartSpiritVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EA1 RID: 11937 RVA: 0x000A9680 File Offset: 0x000A7A80
		public static void AddStamina(FlatBufferBuilder builder, VectorOffset StaminaOffset)
		{
			builder.AddOffset(12, StaminaOffset.Value, 0);
		}

		// Token: 0x06002EA2 RID: 11938 RVA: 0x000A9694 File Offset: 0x000A7A94
		public static VectorOffset CreateStaminaVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EA3 RID: 11939 RVA: 0x000A96D1 File Offset: 0x000A7AD1
		public static void StartStaminaVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EA4 RID: 11940 RVA: 0x000A96DC File Offset: 0x000A7ADC
		public static void AddHPMax(FlatBufferBuilder builder, VectorOffset HPMaxOffset)
		{
			builder.AddOffset(13, HPMaxOffset.Value, 0);
		}

		// Token: 0x06002EA5 RID: 11941 RVA: 0x000A96F0 File Offset: 0x000A7AF0
		public static VectorOffset CreateHPMaxVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EA6 RID: 11942 RVA: 0x000A972D File Offset: 0x000A7B2D
		public static void StartHPMaxVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EA7 RID: 11943 RVA: 0x000A9738 File Offset: 0x000A7B38
		public static void AddMPMax(FlatBufferBuilder builder, VectorOffset MPMaxOffset)
		{
			builder.AddOffset(14, MPMaxOffset.Value, 0);
		}

		// Token: 0x06002EA8 RID: 11944 RVA: 0x000A974C File Offset: 0x000A7B4C
		public static VectorOffset CreateMPMaxVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x000A9789 File Offset: 0x000A7B89
		public static void StartMPMaxVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EAA RID: 11946 RVA: 0x000A9794 File Offset: 0x000A7B94
		public static void AddHPRecover(FlatBufferBuilder builder, VectorOffset HPRecoverOffset)
		{
			builder.AddOffset(15, HPRecoverOffset.Value, 0);
		}

		// Token: 0x06002EAB RID: 11947 RVA: 0x000A97A8 File Offset: 0x000A7BA8
		public static VectorOffset CreateHPRecoverVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EAC RID: 11948 RVA: 0x000A97E5 File Offset: 0x000A7BE5
		public static void StartHPRecoverVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EAD RID: 11949 RVA: 0x000A97F0 File Offset: 0x000A7BF0
		public static void AddMPRecover(FlatBufferBuilder builder, VectorOffset MPRecoverOffset)
		{
			builder.AddOffset(16, MPRecoverOffset.Value, 0);
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x000A9804 File Offset: 0x000A7C04
		public static VectorOffset CreateMPRecoverVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x000A9841 File Offset: 0x000A7C41
		public static void StartMPRecoverVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EB0 RID: 11952 RVA: 0x000A984C File Offset: 0x000A7C4C
		public static void AddAttackSpeedRate(FlatBufferBuilder builder, VectorOffset AttackSpeedRateOffset)
		{
			builder.AddOffset(17, AttackSpeedRateOffset.Value, 0);
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x000A9860 File Offset: 0x000A7C60
		public static VectorOffset CreateAttackSpeedRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x000A989D File Offset: 0x000A7C9D
		public static void StartAttackSpeedRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EB3 RID: 11955 RVA: 0x000A98A8 File Offset: 0x000A7CA8
		public static void AddFireSpeedRate(FlatBufferBuilder builder, VectorOffset FireSpeedRateOffset)
		{
			builder.AddOffset(18, FireSpeedRateOffset.Value, 0);
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x000A98BC File Offset: 0x000A7CBC
		public static VectorOffset CreateFireSpeedRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x000A98F9 File Offset: 0x000A7CF9
		public static void StartFireSpeedRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EB6 RID: 11958 RVA: 0x000A9904 File Offset: 0x000A7D04
		public static void AddMoveSpeedRate(FlatBufferBuilder builder, VectorOffset MoveSpeedRateOffset)
		{
			builder.AddOffset(19, MoveSpeedRateOffset.Value, 0);
		}

		// Token: 0x06002EB7 RID: 11959 RVA: 0x000A9918 File Offset: 0x000A7D18
		public static VectorOffset CreateMoveSpeedRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EB8 RID: 11960 RVA: 0x000A9955 File Offset: 0x000A7D55
		public static void StartMoveSpeedRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EB9 RID: 11961 RVA: 0x000A9960 File Offset: 0x000A7D60
		public static void AddHitRate(FlatBufferBuilder builder, VectorOffset HitRateOffset)
		{
			builder.AddOffset(20, HitRateOffset.Value, 0);
		}

		// Token: 0x06002EBA RID: 11962 RVA: 0x000A9974 File Offset: 0x000A7D74
		public static VectorOffset CreateHitRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EBB RID: 11963 RVA: 0x000A99B1 File Offset: 0x000A7DB1
		public static void StartHitRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EBC RID: 11964 RVA: 0x000A99BC File Offset: 0x000A7DBC
		public static void AddAvoidRate(FlatBufferBuilder builder, VectorOffset AvoidRateOffset)
		{
			builder.AddOffset(21, AvoidRateOffset.Value, 0);
		}

		// Token: 0x06002EBD RID: 11965 RVA: 0x000A99D0 File Offset: 0x000A7DD0
		public static VectorOffset CreateAvoidRateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EBE RID: 11966 RVA: 0x000A9A0D File Offset: 0x000A7E0D
		public static void StartAvoidRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EBF RID: 11967 RVA: 0x000A9A18 File Offset: 0x000A7E18
		public static void AddPhysicCrit(FlatBufferBuilder builder, VectorOffset PhysicCritOffset)
		{
			builder.AddOffset(22, PhysicCritOffset.Value, 0);
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x000A9A2C File Offset: 0x000A7E2C
		public static VectorOffset CreatePhysicCritVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x000A9A69 File Offset: 0x000A7E69
		public static void StartPhysicCritVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x000A9A74 File Offset: 0x000A7E74
		public static void AddMagicCrit(FlatBufferBuilder builder, VectorOffset MagicCritOffset)
		{
			builder.AddOffset(23, MagicCritOffset.Value, 0);
		}

		// Token: 0x06002EC3 RID: 11971 RVA: 0x000A9A88 File Offset: 0x000A7E88
		public static VectorOffset CreateMagicCritVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EC4 RID: 11972 RVA: 0x000A9AC5 File Offset: 0x000A7EC5
		public static void StartMagicCritVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EC5 RID: 11973 RVA: 0x000A9AD0 File Offset: 0x000A7ED0
		public static void AddIsMaster(FlatBufferBuilder builder, int IsMaster)
		{
			builder.AddInt(24, IsMaster, 0);
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x000A9ADC File Offset: 0x000A7EDC
		public static void AddSpasticity(FlatBufferBuilder builder, VectorOffset SpasticityOffset)
		{
			builder.AddOffset(25, SpasticityOffset.Value, 0);
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x000A9AF0 File Offset: 0x000A7EF0
		public static VectorOffset CreateSpasticityVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002EC8 RID: 11976 RVA: 0x000A9B2D File Offset: 0x000A7F2D
		public static void StartSpasticityVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002EC9 RID: 11977 RVA: 0x000A9B38 File Offset: 0x000A7F38
		public static void AddDescs(FlatBufferBuilder builder, VectorOffset DescsOffset)
		{
			builder.AddOffset(26, DescsOffset.Value, 0);
		}

		// Token: 0x06002ECA RID: 11978 RVA: 0x000A9B4C File Offset: 0x000A7F4C
		public static VectorOffset CreateDescsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002ECB RID: 11979 RVA: 0x000A9B92 File Offset: 0x000A7F92
		public static void StartDescsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002ECC RID: 11980 RVA: 0x000A9BA0 File Offset: 0x000A7FA0
		public static Offset<EquipMasterTable> EndEquipMasterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipMasterTable>(value);
		}

		// Token: 0x06002ECD RID: 11981 RVA: 0x000A9BBA File Offset: 0x000A7FBA
		public static void FinishEquipMasterTableBuffer(FlatBufferBuilder builder, Offset<EquipMasterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400137B RID: 4987
		private Table __p = new Table();

		// Token: 0x0400137C RID: 4988
		private FlatBufferArray<int> AtkValue;

		// Token: 0x0400137D RID: 4989
		private FlatBufferArray<int> MagicAtkValue;

		// Token: 0x0400137E RID: 4990
		private FlatBufferArray<int> DefValue;

		// Token: 0x0400137F RID: 4991
		private FlatBufferArray<int> MagicDefValue;

		// Token: 0x04001380 RID: 4992
		private FlatBufferArray<int> StrenthValue;

		// Token: 0x04001381 RID: 4993
		private FlatBufferArray<int> IntellectValue;

		// Token: 0x04001382 RID: 4994
		private FlatBufferArray<int> SpiritValue;

		// Token: 0x04001383 RID: 4995
		private FlatBufferArray<int> StaminaValue;

		// Token: 0x04001384 RID: 4996
		private FlatBufferArray<int> HPMaxValue;

		// Token: 0x04001385 RID: 4997
		private FlatBufferArray<int> MPMaxValue;

		// Token: 0x04001386 RID: 4998
		private FlatBufferArray<int> HPRecoverValue;

		// Token: 0x04001387 RID: 4999
		private FlatBufferArray<int> MPRecoverValue;

		// Token: 0x04001388 RID: 5000
		private FlatBufferArray<int> AttackSpeedRateValue;

		// Token: 0x04001389 RID: 5001
		private FlatBufferArray<int> FireSpeedRateValue;

		// Token: 0x0400138A RID: 5002
		private FlatBufferArray<int> MoveSpeedRateValue;

		// Token: 0x0400138B RID: 5003
		private FlatBufferArray<int> HitRateValue;

		// Token: 0x0400138C RID: 5004
		private FlatBufferArray<int> AvoidRateValue;

		// Token: 0x0400138D RID: 5005
		private FlatBufferArray<int> PhysicCritValue;

		// Token: 0x0400138E RID: 5006
		private FlatBufferArray<int> MagicCritValue;

		// Token: 0x0400138F RID: 5007
		private FlatBufferArray<int> SpasticityValue;

		// Token: 0x04001390 RID: 5008
		private FlatBufferArray<string> DescsValue;

		// Token: 0x020003F6 RID: 1014
		public enum eCrypt
		{
			// Token: 0x04001392 RID: 5010
			code = 1673379914
		}
	}
}
