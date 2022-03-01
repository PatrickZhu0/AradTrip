using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000340 RID: 832
	public class ChijiItemTable : IFlatbufferObject
	{
		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06002342 RID: 9026 RVA: 0x0008E00C File Offset: 0x0008C40C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002343 RID: 9027 RVA: 0x0008E019 File Offset: 0x0008C419
		public static ChijiItemTable GetRootAsChijiItemTable(ByteBuffer _bb)
		{
			return ChijiItemTable.GetRootAsChijiItemTable(_bb, new ChijiItemTable());
		}

		// Token: 0x06002344 RID: 9028 RVA: 0x0008E026 File Offset: 0x0008C426
		public static ChijiItemTable GetRootAsChijiItemTable(ByteBuffer _bb, ChijiItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002345 RID: 9029 RVA: 0x0008E042 File Offset: 0x0008C442
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002346 RID: 9030 RVA: 0x0008E05C File Offset: 0x0008C45C
		public ChijiItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06002347 RID: 9031 RVA: 0x0008E068 File Offset: 0x0008C468
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06002348 RID: 9032 RVA: 0x0008E0B4 File Offset: 0x0008C4B4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002349 RID: 9033 RVA: 0x0008E0F6 File Offset: 0x0008C4F6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x0600234A RID: 9034 RVA: 0x0008E104 File Offset: 0x0008C504
		public int IdSequence
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x0600234B RID: 9035 RVA: 0x0008E150 File Offset: 0x0008C550
		public ChijiItemTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(10);
				return (ChijiItemTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x0008E194 File Offset: 0x0008C594
		public string TypeName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600234D RID: 9037 RVA: 0x0008E1D7 File Offset: 0x0008C5D7
		public ArraySegment<byte>? GetTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x0600234E RID: 9038 RVA: 0x0008E1E8 File Offset: 0x0008C5E8
		public ChijiItemTable.eEPrompt EPrompt
		{
			get
			{
				int num = this.__p.__offset(14);
				return (ChijiItemTable.eEPrompt)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x0600234F RID: 9039 RVA: 0x0008E22C File Offset: 0x0008C62C
		public ChijiItemTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ChijiItemTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06002350 RID: 9040 RVA: 0x0008E270 File Offset: 0x0008C670
		public string SubTypeName
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x0008E2B3 File Offset: 0x0008C6B3
		public ArraySegment<byte>? GetSubTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06002352 RID: 9042 RVA: 0x0008E2C4 File Offset: 0x0008C6C4
		public ChijiItemTable.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (ChijiItemTable.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06002353 RID: 9043 RVA: 0x0008E308 File Offset: 0x0008C708
		public string ThirdTypeName
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002354 RID: 9044 RVA: 0x0008E34B File Offset: 0x0008C74B
		public ArraySegment<byte>? GetThirdTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x06002355 RID: 9045 RVA: 0x0008E35C File Offset: 0x0008C75C
		public int OccuArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06002356 RID: 9046 RVA: 0x0008E3AC File Offset: 0x0008C7AC
		public int OccuLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002357 RID: 9047 RVA: 0x0008E3DF File Offset: 0x0008C7DF
		public ArraySegment<byte>? GetOccuBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06002358 RID: 9048 RVA: 0x0008E3EE File Offset: 0x0008C7EE
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

		// Token: 0x06002359 RID: 9049 RVA: 0x0008E420 File Offset: 0x0008C820
		public int Occu2Array(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x0600235A RID: 9050 RVA: 0x0008E470 File Offset: 0x0008C870
		public int Occu2Length
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x0008E4A3 File Offset: 0x0008C8A3
		public ArraySegment<byte>? GetOccu2Bytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x0600235C RID: 9052 RVA: 0x0008E4B2 File Offset: 0x0008C8B2
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

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x0600235D RID: 9053 RVA: 0x0008E4E4 File Offset: 0x0008C8E4
		public ChijiItemTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(28);
				return (ChijiItemTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x0600235E RID: 9054 RVA: 0x0008E528 File Offset: 0x0008C928
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x0600235F RID: 9055 RVA: 0x0008E574 File Offset: 0x0008C974
		public int NeedLevel
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06002360 RID: 9056 RVA: 0x0008E5C0 File Offset: 0x0008C9C0
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06002361 RID: 9057 RVA: 0x0008E60C File Offset: 0x0008CA0C
		public int BaseAttackSpeedRate
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06002362 RID: 9058 RVA: 0x0008E658 File Offset: 0x0008CA58
		public ChijiItemTable.eCanUse CanUse
		{
			get
			{
				int num = this.__p.__offset(38);
				return (ChijiItemTable.eCanUse)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06002363 RID: 9059 RVA: 0x0008E69C File Offset: 0x0008CA9C
		public bool CanTrade
		{
			get
			{
				int num = this.__p.__offset(40);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x06002364 RID: 9060 RVA: 0x0008E6E8 File Offset: 0x0008CAE8
		public ChijiItemTable.eOwner Owner
		{
			get
			{
				int num = this.__p.__offset(42);
				return (ChijiItemTable.eOwner)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06002365 RID: 9061 RVA: 0x0008E72C File Offset: 0x0008CB2C
		public bool IsSeal
		{
			get
			{
				int num = this.__p.__offset(44);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06002366 RID: 9062 RVA: 0x0008E778 File Offset: 0x0008CB78
		public int SealMax
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06002367 RID: 9063 RVA: 0x0008E7C4 File Offset: 0x0008CBC4
		public bool IsDecompose
		{
			get
			{
				int num = this.__p.__offset(48);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06002368 RID: 9064 RVA: 0x0008E810 File Offset: 0x0008CC10
		public int SellItemID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06002369 RID: 9065 RVA: 0x0008E85C File Offset: 0x0008CC5C
		public int Price
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x0600236A RID: 9066 RVA: 0x0008E8A8 File Offset: 0x0008CCA8
		public int CdGroup
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x0600236B RID: 9067 RVA: 0x0008E8F4 File Offset: 0x0008CCF4
		public int CoolTime
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x0600236C RID: 9068 RVA: 0x0008E940 File Offset: 0x0008CD40
		public int TimeLeft
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x0008E98C File Offset: 0x0008CD8C
		public int MaxNum
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x0600236E RID: 9070 RVA: 0x0008E9D8 File Offset: 0x0008CDD8
		public string EffectDescription
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600236F RID: 9071 RVA: 0x0008EA1B File Offset: 0x0008CE1B
		public ArraySegment<byte>? GetEffectDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06002370 RID: 9072 RVA: 0x0008EA2C File Offset: 0x0008CE2C
		public string Description
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002371 RID: 9073 RVA: 0x0008EA6F File Offset: 0x0008CE6F
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x0008EA80 File Offset: 0x0008CE80
		public int ComeLinkArray(int j)
		{
			int num = this.__p.__offset(66);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x0008EAD0 File Offset: 0x0008CED0
		public int ComeLinkLength
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002374 RID: 9076 RVA: 0x0008EB03 File Offset: 0x0008CF03
		public ArraySegment<byte>? GetComeLinkBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06002375 RID: 9077 RVA: 0x0008EB12 File Offset: 0x0008CF12
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

		// Token: 0x06002376 RID: 9078 RVA: 0x0008EB44 File Offset: 0x0008CF44
		public int RelationIDArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06002377 RID: 9079 RVA: 0x0008EB94 File Offset: 0x0008CF94
		public int RelationIDLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002378 RID: 9080 RVA: 0x0008EBC7 File Offset: 0x0008CFC7
		public ArraySegment<byte>? GetRelationIDBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06002379 RID: 9081 RVA: 0x0008EBD6 File Offset: 0x0008CFD6
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

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x0600237A RID: 9082 RVA: 0x0008EC08 File Offset: 0x0008D008
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x0008EC4B File Offset: 0x0008D04B
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x0600237C RID: 9084 RVA: 0x0008EC5C File Offset: 0x0008D05C
		public string ModelPath
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600237D RID: 9085 RVA: 0x0008EC9F File Offset: 0x0008D09F
		public ArraySegment<byte>? GetModelPathBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x0600237E RID: 9086 RVA: 0x0008ECB0 File Offset: 0x0008D0B0
		public string Path2Array(int j)
		{
			int num = this.__p.__offset(74);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x0008ECF8 File Offset: 0x0008D0F8
		public int Path2Length
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06002380 RID: 9088 RVA: 0x0008ED2B File Offset: 0x0008D12B
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

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06002381 RID: 9089 RVA: 0x0008ED5C File Offset: 0x0008D15C
		public int OnUseBuffId
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06002382 RID: 9090 RVA: 0x0008EDA8 File Offset: 0x0008D1A8
		public int OnGetBuffId
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x0008EDF4 File Offset: 0x0008D1F4
		public bool CanDungeonUse
		{
			get
			{
				int num = this.__p.__offset(80);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06002384 RID: 9092 RVA: 0x0008EE40 File Offset: 0x0008D240
		public bool CanPKUse
		{
			get
			{
				int num = this.__p.__offset(82);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06002385 RID: 9093 RVA: 0x0008EE8C File Offset: 0x0008D28C
		public int RecommendPrice
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06002386 RID: 9094 RVA: 0x0008EED8 File Offset: 0x0008D2D8
		public ChijiItemTable.eComeType ComeType
		{
			get
			{
				int num = this.__p.__offset(86);
				return (ChijiItemTable.eComeType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x0008EF1C File Offset: 0x0008D31C
		public string ComeDesc
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x0008EF5F File Offset: 0x0008D35F
		public ArraySegment<byte>? GetComeDescBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06002389 RID: 9097 RVA: 0x0008EF70 File Offset: 0x0008D370
		public int ResID
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x0008EFBC File Offset: 0x0008D3BC
		public int Tag
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x0600238B RID: 9099 RVA: 0x0008F008 File Offset: 0x0008D408
		public int SuitID
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x0600238C RID: 9100 RVA: 0x0008F054 File Offset: 0x0008D454
		public int EquipPropID
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600238D RID: 9101 RVA: 0x0008F0A0 File Offset: 0x0008D4A0
		public int MutexBuffArray(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x0008F0F0 File Offset: 0x0008D4F0
		public int MutexBuffLength
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x0008F123 File Offset: 0x0008D523
		public ArraySegment<byte>? GetMutexBuffBytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06002390 RID: 9104 RVA: 0x0008F132 File Offset: 0x0008D532
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

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06002391 RID: 9105 RVA: 0x0008F164 File Offset: 0x0008D564
		public bool CanAnnounce
		{
			get
			{
				int num = this.__p.__offset(100);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06002392 RID: 9106 RVA: 0x0008F1B0 File Offset: 0x0008D5B0
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002393 RID: 9107 RVA: 0x0008F1F3 File Offset: 0x0008D5F3
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(102);
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06002394 RID: 9108 RVA: 0x0008F204 File Offset: 0x0008D604
		public int bNeedJump
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06002395 RID: 9109 RVA: 0x0008F250 File Offset: 0x0008D650
		public int FunctionID
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06002396 RID: 9110 RVA: 0x0008F29C File Offset: 0x0008D69C
		public ChijiItemTable.eUseLimiteType UseLimiteType
		{
			get
			{
				int num = this.__p.__offset(108);
				return (ChijiItemTable.eUseLimiteType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x0008F2E0 File Offset: 0x0008D6E0
		public int UseLimiteValue
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06002398 RID: 9112 RVA: 0x0008F32C File Offset: 0x0008D72C
		public int Abandon
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06002399 RID: 9113 RVA: 0x0008F378 File Offset: 0x0008D778
		public int PackageID
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x0008F3C4 File Offset: 0x0008D7C4
		public int OldTitle
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x0600239B RID: 9115 RVA: 0x0008F410 File Offset: 0x0008D810
		public int ForbidAuctionCopy
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x0008F45C File Offset: 0x0008D85C
		public string RenewInfoArray(int j)
		{
			int num = this.__p.__offset(120);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x0600239D RID: 9117 RVA: 0x0008F4A4 File Offset: 0x0008D8A4
		public int RenewInfoLength
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x0600239E RID: 9118 RVA: 0x0008F4D7 File Offset: 0x0008D8D7
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

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x0600239F RID: 9119 RVA: 0x0008F508 File Offset: 0x0008D908
		public int AuctionMinPrice
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x060023A0 RID: 9120 RVA: 0x0008F554 File Offset: 0x0008D954
		public int AuctionMaxPrice
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x060023A1 RID: 9121 RVA: 0x0008F5A0 File Offset: 0x0008D9A0
		public int CanMasterGive
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x060023A2 RID: 9122 RVA: 0x0008F5EC File Offset: 0x0008D9EC
		public int GetLimitNum
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x0008F63C File Offset: 0x0008DA3C
		public int jarGiftConsumeItemArray(int j)
		{
			int num = this.__p.__offset(130);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x060023A4 RID: 9124 RVA: 0x0008F68C File Offset: 0x0008DA8C
		public int jarGiftConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x0008F6C2 File Offset: 0x0008DAC2
		public ArraySegment<byte>? GetJarGiftConsumeItemBytes()
		{
			return this.__p.__vector_as_arraysegment(130);
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060023A6 RID: 9126 RVA: 0x0008F6D4 File Offset: 0x0008DAD4
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

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x060023A7 RID: 9127 RVA: 0x0008F704 File Offset: 0x0008DB04
		public string doubleCheckDesc
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060023A8 RID: 9128 RVA: 0x0008F74A File Offset: 0x0008DB4A
		public ArraySegment<byte>? GetDoubleCheckDescBytes()
		{
			return this.__p.__vector_as_arraysegment(132);
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x060023A9 RID: 9129 RVA: 0x0008F75C File Offset: 0x0008DB5C
		public int IsTransparentFashion
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x060023AA RID: 9130 RVA: 0x0008F7AC File Offset: 0x0008DBAC
		public string Inlaidhole1
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x0008F7F2 File Offset: 0x0008DBF2
		public ArraySegment<byte>? GetInlaidhole1Bytes()
		{
			return this.__p.__vector_as_arraysegment(136);
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x060023AC RID: 9132 RVA: 0x0008F804 File Offset: 0x0008DC04
		public string Inlaidhole2
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060023AD RID: 9133 RVA: 0x0008F84A File Offset: 0x0008DC4A
		public ArraySegment<byte>? GetInlaidhole2Bytes()
		{
			return this.__p.__vector_as_arraysegment(138);
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060023AE RID: 9134 RVA: 0x0008F85C File Offset: 0x0008DC5C
		public int StrenTicketDataIndex
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x060023AF RID: 9135 RVA: 0x0008F8AC File Offset: 0x0008DCAC
		public int BeadLevel
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x060023B0 RID: 9136 RVA: 0x0008F8FC File Offset: 0x0008DCFC
		public int BeadType
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060023B1 RID: 9137 RVA: 0x0008F94C File Offset: 0x0008DD4C
		public int IsTreas
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060023B2 RID: 9138 RVA: 0x0008F99C File Offset: 0x0008DD9C
		public int TradeCD1
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x060023B3 RID: 9139 RVA: 0x0008F9EC File Offset: 0x0008DDEC
		public int TradeCD2
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x0008FA3C File Offset: 0x0008DE3C
		public int LvAdaptationArray(int j)
		{
			int num = this.__p.__offset(152);
			return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x060023B5 RID: 9141 RVA: 0x0008FA8C File Offset: 0x0008DE8C
		public int LvAdaptationLength
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x0008FAC2 File Offset: 0x0008DEC2
		public ArraySegment<byte>? GetLvAdaptationBytes()
		{
			return this.__p.__vector_as_arraysegment(152);
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x060023B7 RID: 9143 RVA: 0x0008FAD4 File Offset: 0x0008DED4
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

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x060023B8 RID: 9144 RVA: 0x0008FB04 File Offset: 0x0008DF04
		public int DescriptionLink
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x060023B9 RID: 9145 RVA: 0x0008FB54 File Offset: 0x0008DF54
		public int IsRecordLog
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x060023BA RID: 9146 RVA: 0x0008FBA4 File Offset: 0x0008DFA4
		public int DiscountCouponProp
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? 0 : (121260803 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x0008FBF4 File Offset: 0x0008DFF4
		public static Offset<ChijiItemTable> CreateChijiItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int IdSequence = 0, ChijiItemTable.eType Type = ChijiItemTable.eType.Type_None, StringOffset TypeNameOffset = default(StringOffset), ChijiItemTable.eEPrompt EPrompt = ChijiItemTable.eEPrompt.EPT_NONE, ChijiItemTable.eSubType SubType = ChijiItemTable.eSubType.ST_NONE, StringOffset SubTypeNameOffset = default(StringOffset), ChijiItemTable.eThirdType ThirdType = ChijiItemTable.eThirdType.TT_NONE, StringOffset ThirdTypeNameOffset = default(StringOffset), VectorOffset OccuOffset = default(VectorOffset), VectorOffset Occu2Offset = default(VectorOffset), ChijiItemTable.eColor Color = ChijiItemTable.eColor.CL_NONE, int Color2 = 0, int NeedLevel = 0, int MaxLevel = 0, int BaseAttackSpeedRate = 0, ChijiItemTable.eCanUse CanUse = ChijiItemTable.eCanUse.CanNot, bool CanTrade = false, ChijiItemTable.eOwner Owner = ChijiItemTable.eOwner.Owner_None, bool IsSeal = false, int SealMax = 0, bool IsDecompose = false, int SellItemID = 0, int Price = 0, int CdGroup = 0, int CoolTime = 0, int TimeLeft = 0, int MaxNum = 0, StringOffset EffectDescriptionOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), VectorOffset ComeLinkOffset = default(VectorOffset), VectorOffset RelationIDOffset = default(VectorOffset), StringOffset IconOffset = default(StringOffset), StringOffset ModelPathOffset = default(StringOffset), VectorOffset Path2Offset = default(VectorOffset), int OnUseBuffId = 0, int OnGetBuffId = 0, bool CanDungeonUse = false, bool CanPKUse = false, int RecommendPrice = 0, ChijiItemTable.eComeType ComeType = ChijiItemTable.eComeType.CT_SHOP, StringOffset ComeDescOffset = default(StringOffset), int ResID = 0, int Tag = 0, int SuitID = 0, int EquipPropID = 0, VectorOffset MutexBuffOffset = default(VectorOffset), bool CanAnnounce = false, StringOffset LinkInfoOffset = default(StringOffset), int bNeedJump = 0, int FunctionID = 0, ChijiItemTable.eUseLimiteType UseLimiteType = ChijiItemTable.eUseLimiteType.NOLIMITE, int UseLimiteValue = 0, int Abandon = 0, int PackageID = 0, int OldTitle = 0, int ForbidAuctionCopy = 0, VectorOffset RenewInfoOffset = default(VectorOffset), int AuctionMinPrice = 0, int AuctionMaxPrice = 0, int CanMasterGive = 0, int GetLimitNum = 0, VectorOffset jarGiftConsumeItemOffset = default(VectorOffset), StringOffset doubleCheckDescOffset = default(StringOffset), int IsTransparentFashion = 0, StringOffset Inlaidhole1Offset = default(StringOffset), StringOffset Inlaidhole2Offset = default(StringOffset), int StrenTicketDataIndex = 0, int BeadLevel = 0, int BeadType = 0, int IsTreas = 0, int TradeCD1 = 0, int TradeCD2 = 0, VectorOffset LvAdaptationOffset = default(VectorOffset), int DescriptionLink = 0, int IsRecordLog = 0, int DiscountCouponProp = 0)
		{
			builder.StartObject(78);
			ChijiItemTable.AddDiscountCouponProp(builder, DiscountCouponProp);
			ChijiItemTable.AddIsRecordLog(builder, IsRecordLog);
			ChijiItemTable.AddDescriptionLink(builder, DescriptionLink);
			ChijiItemTable.AddLvAdaptation(builder, LvAdaptationOffset);
			ChijiItemTable.AddTradeCD2(builder, TradeCD2);
			ChijiItemTable.AddTradeCD1(builder, TradeCD1);
			ChijiItemTable.AddIsTreas(builder, IsTreas);
			ChijiItemTable.AddBeadType(builder, BeadType);
			ChijiItemTable.AddBeadLevel(builder, BeadLevel);
			ChijiItemTable.AddStrenTicketDataIndex(builder, StrenTicketDataIndex);
			ChijiItemTable.AddInlaidhole2(builder, Inlaidhole2Offset);
			ChijiItemTable.AddInlaidhole1(builder, Inlaidhole1Offset);
			ChijiItemTable.AddIsTransparentFashion(builder, IsTransparentFashion);
			ChijiItemTable.AddDoubleCheckDesc(builder, doubleCheckDescOffset);
			ChijiItemTable.AddJarGiftConsumeItem(builder, jarGiftConsumeItemOffset);
			ChijiItemTable.AddGetLimitNum(builder, GetLimitNum);
			ChijiItemTable.AddCanMasterGive(builder, CanMasterGive);
			ChijiItemTable.AddAuctionMaxPrice(builder, AuctionMaxPrice);
			ChijiItemTable.AddAuctionMinPrice(builder, AuctionMinPrice);
			ChijiItemTable.AddRenewInfo(builder, RenewInfoOffset);
			ChijiItemTable.AddForbidAuctionCopy(builder, ForbidAuctionCopy);
			ChijiItemTable.AddOldTitle(builder, OldTitle);
			ChijiItemTable.AddPackageID(builder, PackageID);
			ChijiItemTable.AddAbandon(builder, Abandon);
			ChijiItemTable.AddUseLimiteValue(builder, UseLimiteValue);
			ChijiItemTable.AddUseLimiteType(builder, UseLimiteType);
			ChijiItemTable.AddFunctionID(builder, FunctionID);
			ChijiItemTable.AddBNeedJump(builder, bNeedJump);
			ChijiItemTable.AddLinkInfo(builder, LinkInfoOffset);
			ChijiItemTable.AddMutexBuff(builder, MutexBuffOffset);
			ChijiItemTable.AddEquipPropID(builder, EquipPropID);
			ChijiItemTable.AddSuitID(builder, SuitID);
			ChijiItemTable.AddTag(builder, Tag);
			ChijiItemTable.AddResID(builder, ResID);
			ChijiItemTable.AddComeDesc(builder, ComeDescOffset);
			ChijiItemTable.AddComeType(builder, ComeType);
			ChijiItemTable.AddRecommendPrice(builder, RecommendPrice);
			ChijiItemTable.AddOnGetBuffId(builder, OnGetBuffId);
			ChijiItemTable.AddOnUseBuffId(builder, OnUseBuffId);
			ChijiItemTable.AddPath2(builder, Path2Offset);
			ChijiItemTable.AddModelPath(builder, ModelPathOffset);
			ChijiItemTable.AddIcon(builder, IconOffset);
			ChijiItemTable.AddRelationID(builder, RelationIDOffset);
			ChijiItemTable.AddComeLink(builder, ComeLinkOffset);
			ChijiItemTable.AddDescription(builder, DescriptionOffset);
			ChijiItemTable.AddEffectDescription(builder, EffectDescriptionOffset);
			ChijiItemTable.AddMaxNum(builder, MaxNum);
			ChijiItemTable.AddTimeLeft(builder, TimeLeft);
			ChijiItemTable.AddCoolTime(builder, CoolTime);
			ChijiItemTable.AddCdGroup(builder, CdGroup);
			ChijiItemTable.AddPrice(builder, Price);
			ChijiItemTable.AddSellItemID(builder, SellItemID);
			ChijiItemTable.AddSealMax(builder, SealMax);
			ChijiItemTable.AddOwner(builder, Owner);
			ChijiItemTable.AddCanUse(builder, CanUse);
			ChijiItemTable.AddBaseAttackSpeedRate(builder, BaseAttackSpeedRate);
			ChijiItemTable.AddMaxLevel(builder, MaxLevel);
			ChijiItemTable.AddNeedLevel(builder, NeedLevel);
			ChijiItemTable.AddColor2(builder, Color2);
			ChijiItemTable.AddColor(builder, Color);
			ChijiItemTable.AddOccu2(builder, Occu2Offset);
			ChijiItemTable.AddOccu(builder, OccuOffset);
			ChijiItemTable.AddThirdTypeName(builder, ThirdTypeNameOffset);
			ChijiItemTable.AddThirdType(builder, ThirdType);
			ChijiItemTable.AddSubTypeName(builder, SubTypeNameOffset);
			ChijiItemTable.AddSubType(builder, SubType);
			ChijiItemTable.AddEPrompt(builder, EPrompt);
			ChijiItemTable.AddTypeName(builder, TypeNameOffset);
			ChijiItemTable.AddType(builder, Type);
			ChijiItemTable.AddIdSequence(builder, IdSequence);
			ChijiItemTable.AddName(builder, NameOffset);
			ChijiItemTable.AddID(builder, ID);
			ChijiItemTable.AddCanAnnounce(builder, CanAnnounce);
			ChijiItemTable.AddCanPKUse(builder, CanPKUse);
			ChijiItemTable.AddCanDungeonUse(builder, CanDungeonUse);
			ChijiItemTable.AddIsDecompose(builder, IsDecompose);
			ChijiItemTable.AddIsSeal(builder, IsSeal);
			ChijiItemTable.AddCanTrade(builder, CanTrade);
			return ChijiItemTable.EndChijiItemTable(builder);
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x0008FE7C File Offset: 0x0008E27C
		public static void StartChijiItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(78);
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x0008FE86 File Offset: 0x0008E286
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060023BE RID: 9150 RVA: 0x0008FE91 File Offset: 0x0008E291
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x0008FEA2 File Offset: 0x0008E2A2
		public static void AddIdSequence(FlatBufferBuilder builder, int IdSequence)
		{
			builder.AddInt(2, IdSequence, 0);
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x0008FEAD File Offset: 0x0008E2AD
		public static void AddType(FlatBufferBuilder builder, ChijiItemTable.eType Type)
		{
			builder.AddInt(3, (int)Type, 0);
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x0008FEB8 File Offset: 0x0008E2B8
		public static void AddTypeName(FlatBufferBuilder builder, StringOffset TypeNameOffset)
		{
			builder.AddOffset(4, TypeNameOffset.Value, 0);
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x0008FEC9 File Offset: 0x0008E2C9
		public static void AddEPrompt(FlatBufferBuilder builder, ChijiItemTable.eEPrompt EPrompt)
		{
			builder.AddInt(5, (int)EPrompt, 0);
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x0008FED4 File Offset: 0x0008E2D4
		public static void AddSubType(FlatBufferBuilder builder, ChijiItemTable.eSubType SubType)
		{
			builder.AddInt(6, (int)SubType, 0);
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x0008FEDF File Offset: 0x0008E2DF
		public static void AddSubTypeName(FlatBufferBuilder builder, StringOffset SubTypeNameOffset)
		{
			builder.AddOffset(7, SubTypeNameOffset.Value, 0);
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x0008FEF0 File Offset: 0x0008E2F0
		public static void AddThirdType(FlatBufferBuilder builder, ChijiItemTable.eThirdType ThirdType)
		{
			builder.AddInt(8, (int)ThirdType, 0);
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x0008FEFB File Offset: 0x0008E2FB
		public static void AddThirdTypeName(FlatBufferBuilder builder, StringOffset ThirdTypeNameOffset)
		{
			builder.AddOffset(9, ThirdTypeNameOffset.Value, 0);
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x0008FF0D File Offset: 0x0008E30D
		public static void AddOccu(FlatBufferBuilder builder, VectorOffset OccuOffset)
		{
			builder.AddOffset(10, OccuOffset.Value, 0);
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x0008FF20 File Offset: 0x0008E320
		public static VectorOffset CreateOccuVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x0008FF5D File Offset: 0x0008E35D
		public static void StartOccuVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x0008FF68 File Offset: 0x0008E368
		public static void AddOccu2(FlatBufferBuilder builder, VectorOffset Occu2Offset)
		{
			builder.AddOffset(11, Occu2Offset.Value, 0);
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x0008FF7C File Offset: 0x0008E37C
		public static VectorOffset CreateOccu2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x0008FFB9 File Offset: 0x0008E3B9
		public static void StartOccu2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x0008FFC4 File Offset: 0x0008E3C4
		public static void AddColor(FlatBufferBuilder builder, ChijiItemTable.eColor Color)
		{
			builder.AddInt(12, (int)Color, 0);
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x0008FFD0 File Offset: 0x0008E3D0
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(13, Color2, 0);
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x0008FFDC File Offset: 0x0008E3DC
		public static void AddNeedLevel(FlatBufferBuilder builder, int NeedLevel)
		{
			builder.AddInt(14, NeedLevel, 0);
		}

		// Token: 0x060023D0 RID: 9168 RVA: 0x0008FFE8 File Offset: 0x0008E3E8
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(15, MaxLevel, 0);
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x0008FFF4 File Offset: 0x0008E3F4
		public static void AddBaseAttackSpeedRate(FlatBufferBuilder builder, int BaseAttackSpeedRate)
		{
			builder.AddInt(16, BaseAttackSpeedRate, 0);
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x00090000 File Offset: 0x0008E400
		public static void AddCanUse(FlatBufferBuilder builder, ChijiItemTable.eCanUse CanUse)
		{
			builder.AddInt(17, (int)CanUse, 0);
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x0009000C File Offset: 0x0008E40C
		public static void AddCanTrade(FlatBufferBuilder builder, bool CanTrade)
		{
			builder.AddBool(18, CanTrade, false);
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x00090018 File Offset: 0x0008E418
		public static void AddOwner(FlatBufferBuilder builder, ChijiItemTable.eOwner Owner)
		{
			builder.AddInt(19, (int)Owner, 0);
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x00090024 File Offset: 0x0008E424
		public static void AddIsSeal(FlatBufferBuilder builder, bool IsSeal)
		{
			builder.AddBool(20, IsSeal, false);
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x00090030 File Offset: 0x0008E430
		public static void AddSealMax(FlatBufferBuilder builder, int SealMax)
		{
			builder.AddInt(21, SealMax, 0);
		}

		// Token: 0x060023D7 RID: 9175 RVA: 0x0009003C File Offset: 0x0008E43C
		public static void AddIsDecompose(FlatBufferBuilder builder, bool IsDecompose)
		{
			builder.AddBool(22, IsDecompose, false);
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x00090048 File Offset: 0x0008E448
		public static void AddSellItemID(FlatBufferBuilder builder, int SellItemID)
		{
			builder.AddInt(23, SellItemID, 0);
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x00090054 File Offset: 0x0008E454
		public static void AddPrice(FlatBufferBuilder builder, int Price)
		{
			builder.AddInt(24, Price, 0);
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x00090060 File Offset: 0x0008E460
		public static void AddCdGroup(FlatBufferBuilder builder, int CdGroup)
		{
			builder.AddInt(25, CdGroup, 0);
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x0009006C File Offset: 0x0008E46C
		public static void AddCoolTime(FlatBufferBuilder builder, int CoolTime)
		{
			builder.AddInt(26, CoolTime, 0);
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x00090078 File Offset: 0x0008E478
		public static void AddTimeLeft(FlatBufferBuilder builder, int TimeLeft)
		{
			builder.AddInt(27, TimeLeft, 0);
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x00090084 File Offset: 0x0008E484
		public static void AddMaxNum(FlatBufferBuilder builder, int MaxNum)
		{
			builder.AddInt(28, MaxNum, 0);
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x00090090 File Offset: 0x0008E490
		public static void AddEffectDescription(FlatBufferBuilder builder, StringOffset EffectDescriptionOffset)
		{
			builder.AddOffset(29, EffectDescriptionOffset.Value, 0);
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x000900A2 File Offset: 0x0008E4A2
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(30, DescriptionOffset.Value, 0);
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x000900B4 File Offset: 0x0008E4B4
		public static void AddComeLink(FlatBufferBuilder builder, VectorOffset ComeLinkOffset)
		{
			builder.AddOffset(31, ComeLinkOffset.Value, 0);
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x000900C8 File Offset: 0x0008E4C8
		public static VectorOffset CreateComeLinkVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x00090105 File Offset: 0x0008E505
		public static void StartComeLinkVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x00090110 File Offset: 0x0008E510
		public static void AddRelationID(FlatBufferBuilder builder, VectorOffset RelationIDOffset)
		{
			builder.AddOffset(32, RelationIDOffset.Value, 0);
		}

		// Token: 0x060023E4 RID: 9188 RVA: 0x00090124 File Offset: 0x0008E524
		public static VectorOffset CreateRelationIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060023E5 RID: 9189 RVA: 0x00090161 File Offset: 0x0008E561
		public static void StartRelationIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023E6 RID: 9190 RVA: 0x0009016C File Offset: 0x0008E56C
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(33, IconOffset.Value, 0);
		}

		// Token: 0x060023E7 RID: 9191 RVA: 0x0009017E File Offset: 0x0008E57E
		public static void AddModelPath(FlatBufferBuilder builder, StringOffset ModelPathOffset)
		{
			builder.AddOffset(34, ModelPathOffset.Value, 0);
		}

		// Token: 0x060023E8 RID: 9192 RVA: 0x00090190 File Offset: 0x0008E590
		public static void AddPath2(FlatBufferBuilder builder, VectorOffset Path2Offset)
		{
			builder.AddOffset(35, Path2Offset.Value, 0);
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x000901A4 File Offset: 0x0008E5A4
		public static VectorOffset CreatePath2Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x000901EA File Offset: 0x0008E5EA
		public static void StartPath2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x000901F5 File Offset: 0x0008E5F5
		public static void AddOnUseBuffId(FlatBufferBuilder builder, int OnUseBuffId)
		{
			builder.AddInt(36, OnUseBuffId, 0);
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x00090201 File Offset: 0x0008E601
		public static void AddOnGetBuffId(FlatBufferBuilder builder, int OnGetBuffId)
		{
			builder.AddInt(37, OnGetBuffId, 0);
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x0009020D File Offset: 0x0008E60D
		public static void AddCanDungeonUse(FlatBufferBuilder builder, bool CanDungeonUse)
		{
			builder.AddBool(38, CanDungeonUse, false);
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x00090219 File Offset: 0x0008E619
		public static void AddCanPKUse(FlatBufferBuilder builder, bool CanPKUse)
		{
			builder.AddBool(39, CanPKUse, false);
		}

		// Token: 0x060023EF RID: 9199 RVA: 0x00090225 File Offset: 0x0008E625
		public static void AddRecommendPrice(FlatBufferBuilder builder, int RecommendPrice)
		{
			builder.AddInt(40, RecommendPrice, 0);
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x00090231 File Offset: 0x0008E631
		public static void AddComeType(FlatBufferBuilder builder, ChijiItemTable.eComeType ComeType)
		{
			builder.AddInt(41, (int)ComeType, 0);
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x0009023D File Offset: 0x0008E63D
		public static void AddComeDesc(FlatBufferBuilder builder, StringOffset ComeDescOffset)
		{
			builder.AddOffset(42, ComeDescOffset.Value, 0);
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x0009024F File Offset: 0x0008E64F
		public static void AddResID(FlatBufferBuilder builder, int ResID)
		{
			builder.AddInt(43, ResID, 0);
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x0009025B File Offset: 0x0008E65B
		public static void AddTag(FlatBufferBuilder builder, int Tag)
		{
			builder.AddInt(44, Tag, 0);
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x00090267 File Offset: 0x0008E667
		public static void AddSuitID(FlatBufferBuilder builder, int SuitID)
		{
			builder.AddInt(45, SuitID, 0);
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x00090273 File Offset: 0x0008E673
		public static void AddEquipPropID(FlatBufferBuilder builder, int EquipPropID)
		{
			builder.AddInt(46, EquipPropID, 0);
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x0009027F File Offset: 0x0008E67F
		public static void AddMutexBuff(FlatBufferBuilder builder, VectorOffset MutexBuffOffset)
		{
			builder.AddOffset(47, MutexBuffOffset.Value, 0);
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x00090294 File Offset: 0x0008E694
		public static VectorOffset CreateMutexBuffVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x000902D1 File Offset: 0x0008E6D1
		public static void StartMutexBuffVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x000902DC File Offset: 0x0008E6DC
		public static void AddCanAnnounce(FlatBufferBuilder builder, bool CanAnnounce)
		{
			builder.AddBool(48, CanAnnounce, false);
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x000902E8 File Offset: 0x0008E6E8
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(49, LinkInfoOffset.Value, 0);
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x000902FA File Offset: 0x0008E6FA
		public static void AddBNeedJump(FlatBufferBuilder builder, int bNeedJump)
		{
			builder.AddInt(50, bNeedJump, 0);
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x00090306 File Offset: 0x0008E706
		public static void AddFunctionID(FlatBufferBuilder builder, int FunctionID)
		{
			builder.AddInt(51, FunctionID, 0);
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x00090312 File Offset: 0x0008E712
		public static void AddUseLimiteType(FlatBufferBuilder builder, ChijiItemTable.eUseLimiteType UseLimiteType)
		{
			builder.AddInt(52, (int)UseLimiteType, 0);
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x0009031E File Offset: 0x0008E71E
		public static void AddUseLimiteValue(FlatBufferBuilder builder, int UseLimiteValue)
		{
			builder.AddInt(53, UseLimiteValue, 0);
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x0009032A File Offset: 0x0008E72A
		public static void AddAbandon(FlatBufferBuilder builder, int Abandon)
		{
			builder.AddInt(54, Abandon, 0);
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x00090336 File Offset: 0x0008E736
		public static void AddPackageID(FlatBufferBuilder builder, int PackageID)
		{
			builder.AddInt(55, PackageID, 0);
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x00090342 File Offset: 0x0008E742
		public static void AddOldTitle(FlatBufferBuilder builder, int OldTitle)
		{
			builder.AddInt(56, OldTitle, 0);
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x0009034E File Offset: 0x0008E74E
		public static void AddForbidAuctionCopy(FlatBufferBuilder builder, int ForbidAuctionCopy)
		{
			builder.AddInt(57, ForbidAuctionCopy, 0);
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x0009035A File Offset: 0x0008E75A
		public static void AddRenewInfo(FlatBufferBuilder builder, VectorOffset RenewInfoOffset)
		{
			builder.AddOffset(58, RenewInfoOffset.Value, 0);
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x0009036C File Offset: 0x0008E76C
		public static VectorOffset CreateRenewInfoVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x000903B2 File Offset: 0x0008E7B2
		public static void StartRenewInfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x000903BD File Offset: 0x0008E7BD
		public static void AddAuctionMinPrice(FlatBufferBuilder builder, int AuctionMinPrice)
		{
			builder.AddInt(59, AuctionMinPrice, 0);
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x000903C9 File Offset: 0x0008E7C9
		public static void AddAuctionMaxPrice(FlatBufferBuilder builder, int AuctionMaxPrice)
		{
			builder.AddInt(60, AuctionMaxPrice, 0);
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x000903D5 File Offset: 0x0008E7D5
		public static void AddCanMasterGive(FlatBufferBuilder builder, int CanMasterGive)
		{
			builder.AddInt(61, CanMasterGive, 0);
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x000903E1 File Offset: 0x0008E7E1
		public static void AddGetLimitNum(FlatBufferBuilder builder, int GetLimitNum)
		{
			builder.AddInt(62, GetLimitNum, 0);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x000903ED File Offset: 0x0008E7ED
		public static void AddJarGiftConsumeItem(FlatBufferBuilder builder, VectorOffset jarGiftConsumeItemOffset)
		{
			builder.AddOffset(63, jarGiftConsumeItemOffset.Value, 0);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x00090400 File Offset: 0x0008E800
		public static VectorOffset CreateJarGiftConsumeItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x0009043D File Offset: 0x0008E83D
		public static void StartJarGiftConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x00090448 File Offset: 0x0008E848
		public static void AddDoubleCheckDesc(FlatBufferBuilder builder, StringOffset doubleCheckDescOffset)
		{
			builder.AddOffset(64, doubleCheckDescOffset.Value, 0);
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x0009045A File Offset: 0x0008E85A
		public static void AddIsTransparentFashion(FlatBufferBuilder builder, int IsTransparentFashion)
		{
			builder.AddInt(65, IsTransparentFashion, 0);
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x00090466 File Offset: 0x0008E866
		public static void AddInlaidhole1(FlatBufferBuilder builder, StringOffset Inlaidhole1Offset)
		{
			builder.AddOffset(66, Inlaidhole1Offset.Value, 0);
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x00090478 File Offset: 0x0008E878
		public static void AddInlaidhole2(FlatBufferBuilder builder, StringOffset Inlaidhole2Offset)
		{
			builder.AddOffset(67, Inlaidhole2Offset.Value, 0);
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x0009048A File Offset: 0x0008E88A
		public static void AddStrenTicketDataIndex(FlatBufferBuilder builder, int StrenTicketDataIndex)
		{
			builder.AddInt(68, StrenTicketDataIndex, 0);
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x00090496 File Offset: 0x0008E896
		public static void AddBeadLevel(FlatBufferBuilder builder, int BeadLevel)
		{
			builder.AddInt(69, BeadLevel, 0);
		}

		// Token: 0x06002413 RID: 9235 RVA: 0x000904A2 File Offset: 0x0008E8A2
		public static void AddBeadType(FlatBufferBuilder builder, int BeadType)
		{
			builder.AddInt(70, BeadType, 0);
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x000904AE File Offset: 0x0008E8AE
		public static void AddIsTreas(FlatBufferBuilder builder, int IsTreas)
		{
			builder.AddInt(71, IsTreas, 0);
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x000904BA File Offset: 0x0008E8BA
		public static void AddTradeCD1(FlatBufferBuilder builder, int TradeCD1)
		{
			builder.AddInt(72, TradeCD1, 0);
		}

		// Token: 0x06002416 RID: 9238 RVA: 0x000904C6 File Offset: 0x0008E8C6
		public static void AddTradeCD2(FlatBufferBuilder builder, int TradeCD2)
		{
			builder.AddInt(73, TradeCD2, 0);
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x000904D2 File Offset: 0x0008E8D2
		public static void AddLvAdaptation(FlatBufferBuilder builder, VectorOffset LvAdaptationOffset)
		{
			builder.AddOffset(74, LvAdaptationOffset.Value, 0);
		}

		// Token: 0x06002418 RID: 9240 RVA: 0x000904E4 File Offset: 0x0008E8E4
		public static VectorOffset CreateLvAdaptationVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x00090521 File Offset: 0x0008E921
		public static void StartLvAdaptationVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x0009052C File Offset: 0x0008E92C
		public static void AddDescriptionLink(FlatBufferBuilder builder, int DescriptionLink)
		{
			builder.AddInt(75, DescriptionLink, 0);
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x00090538 File Offset: 0x0008E938
		public static void AddIsRecordLog(FlatBufferBuilder builder, int IsRecordLog)
		{
			builder.AddInt(76, IsRecordLog, 0);
		}

		// Token: 0x0600241C RID: 9244 RVA: 0x00090544 File Offset: 0x0008E944
		public static void AddDiscountCouponProp(FlatBufferBuilder builder, int DiscountCouponProp)
		{
			builder.AddInt(77, DiscountCouponProp, 0);
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x00090550 File Offset: 0x0008E950
		public static Offset<ChijiItemTable> EndChijiItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChijiItemTable>(value);
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x0009056A File Offset: 0x0008E96A
		public static void FinishChijiItemTableBuffer(FlatBufferBuilder builder, Offset<ChijiItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001019 RID: 4121
		private Table __p = new Table();

		// Token: 0x0400101A RID: 4122
		private FlatBufferArray<int> OccuValue;

		// Token: 0x0400101B RID: 4123
		private FlatBufferArray<int> Occu2Value;

		// Token: 0x0400101C RID: 4124
		private FlatBufferArray<int> ComeLinkValue;

		// Token: 0x0400101D RID: 4125
		private FlatBufferArray<int> RelationIDValue;

		// Token: 0x0400101E RID: 4126
		private FlatBufferArray<string> Path2Value;

		// Token: 0x0400101F RID: 4127
		private FlatBufferArray<int> MutexBuffValue;

		// Token: 0x04001020 RID: 4128
		private FlatBufferArray<string> RenewInfoValue;

		// Token: 0x04001021 RID: 4129
		private FlatBufferArray<int> jarGiftConsumeItemValue;

		// Token: 0x04001022 RID: 4130
		private FlatBufferArray<int> LvAdaptationValue;

		// Token: 0x02000341 RID: 833
		public enum eType
		{
			// Token: 0x04001024 RID: 4132
			Type_None,
			// Token: 0x04001025 RID: 4133
			EQUIP,
			// Token: 0x04001026 RID: 4134
			EXPENDABLE,
			// Token: 0x04001027 RID: 4135
			MATERIAL,
			// Token: 0x04001028 RID: 4136
			TASK,
			// Token: 0x04001029 RID: 4137
			FASHION,
			// Token: 0x0400102A RID: 4138
			INCOME,
			// Token: 0x0400102B RID: 4139
			ENERGY,
			// Token: 0x0400102C RID: 4140
			FUCKTITTLE,
			// Token: 0x0400102D RID: 4141
			VirtualPack,
			// Token: 0x0400102E RID: 4142
			PET,
			// Token: 0x0400102F RID: 4143
			GUILD_BUFF,
			// Token: 0x04001030 RID: 4144
			HEAD_FRAME,
			// Token: 0x04001031 RID: 4145
			SKILL_CHIJI
		}

		// Token: 0x02000342 RID: 834
		public enum eEPrompt
		{
			// Token: 0x04001033 RID: 4147
			EPT_NONE,
			// Token: 0x04001034 RID: 4148
			EPT_NEW_EQUIP,
			// Token: 0x04001035 RID: 4149
			EPT_RED_POINT
		}

		// Token: 0x02000343 RID: 835
		public enum eSubType
		{
			// Token: 0x04001037 RID: 4151
			ST_NONE,
			// Token: 0x04001038 RID: 4152
			WEAPON,
			// Token: 0x04001039 RID: 4153
			HEAD,
			// Token: 0x0400103A RID: 4154
			CHEST,
			// Token: 0x0400103B RID: 4155
			BELT,
			// Token: 0x0400103C RID: 4156
			LEG,
			// Token: 0x0400103D RID: 4157
			BOOT,
			// Token: 0x0400103E RID: 4158
			RING,
			// Token: 0x0400103F RID: 4159
			NECKLASE,
			// Token: 0x04001040 RID: 4160
			BRACELET,
			// Token: 0x04001041 RID: 4161
			TITLE,
			// Token: 0x04001042 RID: 4162
			FASHION_HAIR,
			// Token: 0x04001043 RID: 4163
			FASHION_HEAD,
			// Token: 0x04001044 RID: 4164
			FASHION_SASH,
			// Token: 0x04001045 RID: 4165
			FASHION_CHEST,
			// Token: 0x04001046 RID: 4166
			FASHION_LEG,
			// Token: 0x04001047 RID: 4167
			FASHION_EPAULET,
			// Token: 0x04001048 RID: 4168
			GOLD,
			// Token: 0x04001049 RID: 4169
			POINT,
			// Token: 0x0400104A RID: 4170
			EXP,
			// Token: 0x0400104B RID: 4171
			DRUG,
			// Token: 0x0400104C RID: 4172
			WARRIOR_SOUL = 22,
			// Token: 0x0400104D RID: 4173
			DUEL_COIN,
			// Token: 0x0400104E RID: 4174
			MATERIAL_JINGPO,
			// Token: 0x0400104F RID: 4175
			EnchantmentsCard,
			// Token: 0x04001050 RID: 4176
			ResurrectionCcurrency,
			// Token: 0x04001051 RID: 4177
			BindGOLD,
			// Token: 0x04001052 RID: 4178
			BindPOINT,
			// Token: 0x04001053 RID: 4179
			GiftPackage,
			// Token: 0x04001054 RID: 4180
			GuildContri,
			// Token: 0x04001055 RID: 4181
			SP,
			// Token: 0x04001056 RID: 4182
			EnergyStone,
			// Token: 0x04001057 RID: 4183
			Coupon,
			// Token: 0x04001058 RID: 4184
			MonthCard,
			// Token: 0x04001059 RID: 4185
			Jar,
			// Token: 0x0400105A RID: 4186
			GiftBox,
			// Token: 0x0400105B RID: 4187
			FatigueDrug,
			// Token: 0x0400105C RID: 4188
			Drawing,
			// Token: 0x0400105D RID: 4189
			Fragment,
			// Token: 0x0400105E RID: 4190
			VipExp,
			// Token: 0x0400105F RID: 4191
			ExperiencePill,
			// Token: 0x04001060 RID: 4192
			GoldJarPoint,
			// Token: 0x04001061 RID: 4193
			MagicJarPoint,
			// Token: 0x04001062 RID: 4194
			PetEgg,
			// Token: 0x04001063 RID: 4195
			ST_FASHION_COMPOSER,
			// Token: 0x04001064 RID: 4196
			MoneyManageCard,
			// Token: 0x04001065 RID: 4197
			Hp = 50,
			// Token: 0x04001066 RID: 4198
			Mp,
			// Token: 0x04001067 RID: 4199
			HpMp,
			// Token: 0x04001068 RID: 4200
			ChangeName,
			// Token: 0x04001069 RID: 4201
			Bead,
			// Token: 0x0400106A RID: 4202
			MagicBox,
			// Token: 0x0400106B RID: 4203
			MagicHammer,
			// Token: 0x0400106C RID: 4204
			Param,
			// Token: 0x0400106D RID: 4205
			ST_JAR_GIFT,
			// Token: 0x0400106E RID: 4206
			ChargeActivityScore = 60,
			// Token: 0x0400106F RID: 4207
			ST_ADD_VIP_POINT,
			// Token: 0x04001070 RID: 4208
			AttributeDrug,
			// Token: 0x04001071 RID: 4209
			ST_APPOINTMENT_COIN = 70,
			// Token: 0x04001072 RID: 4210
			LOTTERY_COIN,
			// Token: 0x04001073 RID: 4211
			Perfect_washing,
			// Token: 0x04001074 RID: 4212
			ST_CONSUME_JAR_GIFT,
			// Token: 0x04001075 RID: 4213
			ST_PRIMARY_RAFFLE_TICKETS,
			// Token: 0x04001076 RID: 4214
			ST_MIDDLE_RAFFLE_TICKETS,
			// Token: 0x04001077 RID: 4215
			ST_SENIOR_RAFFLE_TICKETS,
			// Token: 0x04001078 RID: 4216
			ST_MASTER_ACADEMIC_VALUE = 78,
			// Token: 0x04001079 RID: 4217
			ST_MASTER_GOODTEACH_VALUE,
			// Token: 0x0400107A RID: 4218
			ST_RETURN_TOKEN,
			// Token: 0x0400107B RID: 4219
			FASHION_WEAPON,
			// Token: 0x0400107C RID: 4220
			ST_CHANGE_FASHION_ACTIVE_TICKET,
			// Token: 0x0400107D RID: 4221
			ST_DRESS_INTEGRAL_VALUE,
			// Token: 0x0400107E RID: 4222
			ST_WEAPON_LEASE_TICKET,
			// Token: 0x0400107F RID: 4223
			ST_EXTENSIBLE_ROLE_CARD,
			// Token: 0x04001080 RID: 4224
			ST_UP_LEVEL_BOOK,
			// Token: 0x04001081 RID: 4225
			ST_BLESS_CRYSTAL_VALUE,
			// Token: 0x04001082 RID: 4226
			ST_INHERIT_BLESS_VALUE,
			// Token: 0x04001083 RID: 4227
			ST_PEARL_HAMMER,
			// Token: 0x04001084 RID: 4228
			ST_DIAMOND_HAMMER,
			// Token: 0x04001085 RID: 4229
			ST_GOLD_REWARD_VALUE,
			// Token: 0x04001086 RID: 4230
			FASHION_AURAS,
			// Token: 0x04001087 RID: 4231
			DiscountCoupon,
			// Token: 0x04001088 RID: 4232
			ChijiHp = 95,
			// Token: 0x04001089 RID: 4233
			ChijiMoveSpeed,
			// Token: 0x0400108A RID: 4234
			ChijiGrenade,
			// Token: 0x0400108B RID: 4235
			ChijiBuff,
			// Token: 0x0400108C RID: 4236
			ST_CHIJI_TRAP = 110,
			// Token: 0x0400108D RID: 4237
			ST_CHIJI_SHOP_COIN = 129
		}

		// Token: 0x02000344 RID: 836
		public enum eThirdType
		{
			// Token: 0x0400108F RID: 4239
			TT_NONE,
			// Token: 0x04001090 RID: 4240
			HUGESWORD,
			// Token: 0x04001091 RID: 4241
			KATANA,
			// Token: 0x04001092 RID: 4242
			SHORTSWORD,
			// Token: 0x04001093 RID: 4243
			BEAMSWORD,
			// Token: 0x04001094 RID: 4244
			BLUNT,
			// Token: 0x04001095 RID: 4245
			REVOLVER,
			// Token: 0x04001096 RID: 4246
			CROSSBOW,
			// Token: 0x04001097 RID: 4247
			HANDCANNON,
			// Token: 0x04001098 RID: 4248
			RIFLE,
			// Token: 0x04001099 RID: 4249
			PISTOL,
			// Token: 0x0400109A RID: 4250
			STAFF,
			// Token: 0x0400109B RID: 4251
			WAND,
			// Token: 0x0400109C RID: 4252
			SPEAR,
			// Token: 0x0400109D RID: 4253
			STICK,
			// Token: 0x0400109E RID: 4254
			BESOM,
			// Token: 0x0400109F RID: 4255
			GLOVE,
			// Token: 0x040010A0 RID: 4256
			BIKAI,
			// Token: 0x040010A1 RID: 4257
			CLAW,
			// Token: 0x040010A2 RID: 4258
			OFG,
			// Token: 0x040010A3 RID: 4259
			EAST_STICK,
			// Token: 0x040010A4 RID: 4260
			SICKLE,
			// Token: 0x040010A5 RID: 4261
			TOTEM,
			// Token: 0x040010A6 RID: 4262
			AXE,
			// Token: 0x040010A7 RID: 4263
			BEADS,
			// Token: 0x040010A8 RID: 4264
			CROSS,
			// Token: 0x040010A9 RID: 4265
			CLOTH = 51,
			// Token: 0x040010AA RID: 4266
			SKIN,
			// Token: 0x040010AB RID: 4267
			LIGHT,
			// Token: 0x040010AC RID: 4268
			HEAVY,
			// Token: 0x040010AD RID: 4269
			PLATE,
			// Token: 0x040010AE RID: 4270
			FASHION_JUNIOR = 100,
			// Token: 0x040010AF RID: 4271
			FASHION_SENIOR,
			// Token: 0x040010B0 RID: 4272
			FASHION_FESTIVAL,
			// Token: 0x040010B1 RID: 4273
			COMPOSER_JUNIOR,
			// Token: 0x040010B2 RID: 4274
			COMPOSER_SENIOR,
			// Token: 0x040010B3 RID: 4275
			SmallFatigueDrug = 300,
			// Token: 0x040010B4 RID: 4276
			MiddleFatigueDrug,
			// Token: 0x040010B5 RID: 4277
			BigFatigueDrug,
			// Token: 0x040010B6 RID: 4278
			BatteDrug = 401,
			// Token: 0x040010B7 RID: 4279
			ChangePlayerName = 500,
			// Token: 0x040010B8 RID: 4280
			ChangeGuildName,
			// Token: 0x040010B9 RID: 4281
			GoldTitle,
			// Token: 0x040010BA RID: 4282
			ChangeAdventureName,
			// Token: 0x040010BB RID: 4283
			ExtensibleRoleCard,
			// Token: 0x040010BC RID: 4284
			UpLevelBook,
			// Token: 0x040010BD RID: 4285
			GoddessTear = 600,
			// Token: 0x040010BE RID: 4286
			PowerGem = 611,
			// Token: 0x040010BF RID: 4287
			IntelligenceGem,
			// Token: 0x040010C0 RID: 4288
			LivesGem,
			// Token: 0x040010C1 RID: 4289
			SpiritGem,
			// Token: 0x040010C2 RID: 4290
			CritsGem,
			// Token: 0x040010C3 RID: 4291
			MagicGem,
			// Token: 0x040010C4 RID: 4292
			PreciseGem,
			// Token: 0x040010C5 RID: 4293
			RapidlyGem,
			// Token: 0x040010C6 RID: 4294
			DischargeGem,
			// Token: 0x040010C7 RID: 4295
			ElementGem,
			// Token: 0x040010C8 RID: 4296
			SkillGem,
			// Token: 0x040010C9 RID: 4297
			UseToSelf = 701,
			// Token: 0x040010CA RID: 4298
			UseToOther,
			// Token: 0x040010CB RID: 4299
			ChijiGiftPackage,
			// Token: 0x040010CC RID: 4300
			ST_CHIJI_MIANZHAN = 129
		}

		// Token: 0x02000345 RID: 837
		public enum eColor
		{
			// Token: 0x040010CE RID: 4302
			CL_NONE,
			// Token: 0x040010CF RID: 4303
			WHITE,
			// Token: 0x040010D0 RID: 4304
			BLUE,
			// Token: 0x040010D1 RID: 4305
			PURPLE,
			// Token: 0x040010D2 RID: 4306
			GREEN,
			// Token: 0x040010D3 RID: 4307
			PINK,
			// Token: 0x040010D4 RID: 4308
			YELLOW
		}

		// Token: 0x02000346 RID: 838
		public enum eCanUse
		{
			// Token: 0x040010D6 RID: 4310
			CanNot,
			// Token: 0x040010D7 RID: 4311
			UseOne,
			// Token: 0x040010D8 RID: 4312
			UseTotal
		}

		// Token: 0x02000347 RID: 839
		public enum eOwner
		{
			// Token: 0x040010DA RID: 4314
			Owner_None,
			// Token: 0x040010DB RID: 4315
			NOTBIND,
			// Token: 0x040010DC RID: 4316
			ROLEBIND,
			// Token: 0x040010DD RID: 4317
			ACCBIND
		}

		// Token: 0x02000348 RID: 840
		public enum eComeType
		{
			// Token: 0x040010DF RID: 4319
			CT_SHOP,
			// Token: 0x040010E0 RID: 4320
			CT_MISSION,
			// Token: 0x040010E1 RID: 4321
			CT_ACTIVITY
		}

		// Token: 0x02000349 RID: 841
		public enum eUseLimiteType
		{
			// Token: 0x040010E3 RID: 4323
			NOLIMITE,
			// Token: 0x040010E4 RID: 4324
			DAYLIMITE,
			// Token: 0x040010E5 RID: 4325
			VIPLIMITE
		}

		// Token: 0x0200034A RID: 842
		public enum eCrypt
		{
			// Token: 0x040010E7 RID: 4327
			code = 121260803
		}
	}
}
