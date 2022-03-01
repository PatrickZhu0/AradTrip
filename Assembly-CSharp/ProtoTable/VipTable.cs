using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200061C RID: 1564
	public class VipTable : IFlatbufferObject
	{
		// Token: 0x170017D4 RID: 6100
		// (get) Token: 0x060054B7 RID: 21687 RVA: 0x0010379C File Offset: 0x00101B9C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060054B8 RID: 21688 RVA: 0x001037A9 File Offset: 0x00101BA9
		public static VipTable GetRootAsVipTable(ByteBuffer _bb)
		{
			return VipTable.GetRootAsVipTable(_bb, new VipTable());
		}

		// Token: 0x060054B9 RID: 21689 RVA: 0x001037B6 File Offset: 0x00101BB6
		public static VipTable GetRootAsVipTable(ByteBuffer _bb, VipTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060054BA RID: 21690 RVA: 0x001037D2 File Offset: 0x00101BD2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060054BB RID: 21691 RVA: 0x001037EC File Offset: 0x00101BEC
		public VipTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170017D5 RID: 6101
		// (get) Token: 0x060054BC RID: 21692 RVA: 0x001037F8 File Offset: 0x00101BF8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (501515545 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017D6 RID: 6102
		// (get) Token: 0x060054BD RID: 21693 RVA: 0x00103844 File Offset: 0x00101C44
		public int GiftID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (501515545 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017D7 RID: 6103
		// (get) Token: 0x060054BE RID: 21694 RVA: 0x00103890 File Offset: 0x00101C90
		public int TotalRmb
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (501515545 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060054BF RID: 21695 RVA: 0x001038DC File Offset: 0x00101CDC
		public string GiftItemsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017D8 RID: 6104
		// (get) Token: 0x060054C0 RID: 21696 RVA: 0x00103924 File Offset: 0x00101D24
		public int GiftItemsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017D9 RID: 6105
		// (get) Token: 0x060054C1 RID: 21697 RVA: 0x00103957 File Offset: 0x00101D57
		public FlatBufferArray<string> GiftItems
		{
			get
			{
				if (this.GiftItemsValue == null)
				{
					this.GiftItemsValue = new FlatBufferArray<string>(new Func<int, string>(this.GiftItemsArray), this.GiftItemsLength);
				}
				return this.GiftItemsValue;
			}
		}

		// Token: 0x170017DA RID: 6106
		// (get) Token: 0x060054C2 RID: 21698 RVA: 0x00103988 File Offset: 0x00101D88
		public int GiftPrePrice
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (501515545 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017DB RID: 6107
		// (get) Token: 0x060054C3 RID: 21699 RVA: 0x001039D4 File Offset: 0x00101DD4
		public int GiftDiscountPrice
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (501515545 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060054C4 RID: 21700 RVA: 0x00103A20 File Offset: 0x00101E20
		public string ArtifactJarDicountRateArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017DC RID: 6108
		// (get) Token: 0x060054C5 RID: 21701 RVA: 0x00103A68 File Offset: 0x00101E68
		public int ArtifactJarDicountRateLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017DD RID: 6109
		// (get) Token: 0x060054C6 RID: 21702 RVA: 0x00103A9B File Offset: 0x00101E9B
		public FlatBufferArray<string> ArtifactJarDicountRate
		{
			get
			{
				if (this.ArtifactJarDicountRateValue == null)
				{
					this.ArtifactJarDicountRateValue = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDicountRateArray), this.ArtifactJarDicountRateLength);
				}
				return this.ArtifactJarDicountRateValue;
			}
		}

		// Token: 0x060054C7 RID: 21703 RVA: 0x00103ACC File Offset: 0x00101ECC
		public string ArtifactJarDiscountProbArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017DE RID: 6110
		// (get) Token: 0x060054C8 RID: 21704 RVA: 0x00103B14 File Offset: 0x00101F14
		public int ArtifactJarDiscountProbLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017DF RID: 6111
		// (get) Token: 0x060054C9 RID: 21705 RVA: 0x00103B47 File Offset: 0x00101F47
		public FlatBufferArray<string> ArtifactJarDiscountProb
		{
			get
			{
				if (this.ArtifactJarDiscountProbValue == null)
				{
					this.ArtifactJarDiscountProbValue = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDiscountProbArray), this.ArtifactJarDiscountProbLength);
				}
				return this.ArtifactJarDiscountProbValue;
			}
		}

		// Token: 0x060054CA RID: 21706 RVA: 0x00103B78 File Offset: 0x00101F78
		public string ArtifactJarDiscountEffectTimesArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017E0 RID: 6112
		// (get) Token: 0x060054CB RID: 21707 RVA: 0x00103BC0 File Offset: 0x00101FC0
		public int ArtifactJarDiscountEffectTimesLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017E1 RID: 6113
		// (get) Token: 0x060054CC RID: 21708 RVA: 0x00103BF3 File Offset: 0x00101FF3
		public FlatBufferArray<string> ArtifactJarDiscountEffectTimes
		{
			get
			{
				if (this.ArtifactJarDiscountEffectTimesValue == null)
				{
					this.ArtifactJarDiscountEffectTimesValue = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDiscountEffectTimesArray), this.ArtifactJarDiscountEffectTimesLength);
				}
				return this.ArtifactJarDiscountEffectTimesValue;
			}
		}

		// Token: 0x060054CD RID: 21709 RVA: 0x00103C24 File Offset: 0x00102024
		public string ArtifactJarDiscountETProbArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017E2 RID: 6114
		// (get) Token: 0x060054CE RID: 21710 RVA: 0x00103C6C File Offset: 0x0010206C
		public int ArtifactJarDiscountETProbLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017E3 RID: 6115
		// (get) Token: 0x060054CF RID: 21711 RVA: 0x00103C9F File Offset: 0x0010209F
		public FlatBufferArray<string> ArtifactJarDiscountETProb
		{
			get
			{
				if (this.ArtifactJarDiscountETProbValue == null)
				{
					this.ArtifactJarDiscountETProbValue = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDiscountETProbArray), this.ArtifactJarDiscountETProbLength);
				}
				return this.ArtifactJarDiscountETProbValue;
			}
		}

		// Token: 0x060054D0 RID: 21712 RVA: 0x00103CD0 File Offset: 0x001020D0
		public string ArtifactJarDiscountEffectTimes1Array(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017E4 RID: 6116
		// (get) Token: 0x060054D1 RID: 21713 RVA: 0x00103D18 File Offset: 0x00102118
		public int ArtifactJarDiscountEffectTimes1Length
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017E5 RID: 6117
		// (get) Token: 0x060054D2 RID: 21714 RVA: 0x00103D4B File Offset: 0x0010214B
		public FlatBufferArray<string> ArtifactJarDiscountEffectTimes1
		{
			get
			{
				if (this.ArtifactJarDiscountEffectTimes1Value == null)
				{
					this.ArtifactJarDiscountEffectTimes1Value = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDiscountEffectTimes1Array), this.ArtifactJarDiscountEffectTimes1Length);
				}
				return this.ArtifactJarDiscountEffectTimes1Value;
			}
		}

		// Token: 0x060054D3 RID: 21715 RVA: 0x00103D7C File Offset: 0x0010217C
		public string ArtifactJarDiscountETProb1Array(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170017E6 RID: 6118
		// (get) Token: 0x060054D4 RID: 21716 RVA: 0x00103DC4 File Offset: 0x001021C4
		public int ArtifactJarDiscountETProb1Length
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170017E7 RID: 6119
		// (get) Token: 0x060054D5 RID: 21717 RVA: 0x00103DF7 File Offset: 0x001021F7
		public FlatBufferArray<string> ArtifactJarDiscountETProb1
		{
			get
			{
				if (this.ArtifactJarDiscountETProb1Value == null)
				{
					this.ArtifactJarDiscountETProb1Value = new FlatBufferArray<string>(new Func<int, string>(this.ArtifactJarDiscountETProb1Array), this.ArtifactJarDiscountETProb1Length);
				}
				return this.ArtifactJarDiscountETProb1Value;
			}
		}

		// Token: 0x060054D6 RID: 21718 RVA: 0x00103E28 File Offset: 0x00102228
		public static Offset<VipTable> CreateVipTable(FlatBufferBuilder builder, int ID = 0, int GiftID = 0, int TotalRmb = 0, VectorOffset GiftItemsOffset = default(VectorOffset), int GiftPrePrice = 0, int GiftDiscountPrice = 0, VectorOffset ArtifactJarDicountRateOffset = default(VectorOffset), VectorOffset ArtifactJarDiscountProbOffset = default(VectorOffset), VectorOffset ArtifactJarDiscountEffectTimesOffset = default(VectorOffset), VectorOffset ArtifactJarDiscountETProbOffset = default(VectorOffset), VectorOffset ArtifactJarDiscountEffectTimes1Offset = default(VectorOffset), VectorOffset ArtifactJarDiscountETProb1Offset = default(VectorOffset))
		{
			builder.StartObject(12);
			VipTable.AddArtifactJarDiscountETProb1(builder, ArtifactJarDiscountETProb1Offset);
			VipTable.AddArtifactJarDiscountEffectTimes1(builder, ArtifactJarDiscountEffectTimes1Offset);
			VipTable.AddArtifactJarDiscountETProb(builder, ArtifactJarDiscountETProbOffset);
			VipTable.AddArtifactJarDiscountEffectTimes(builder, ArtifactJarDiscountEffectTimesOffset);
			VipTable.AddArtifactJarDiscountProb(builder, ArtifactJarDiscountProbOffset);
			VipTable.AddArtifactJarDicountRate(builder, ArtifactJarDicountRateOffset);
			VipTable.AddGiftDiscountPrice(builder, GiftDiscountPrice);
			VipTable.AddGiftPrePrice(builder, GiftPrePrice);
			VipTable.AddGiftItems(builder, GiftItemsOffset);
			VipTable.AddTotalRmb(builder, TotalRmb);
			VipTable.AddGiftID(builder, GiftID);
			VipTable.AddID(builder, ID);
			return VipTable.EndVipTable(builder);
		}

		// Token: 0x060054D7 RID: 21719 RVA: 0x00103EA0 File Offset: 0x001022A0
		public static void StartVipTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x060054D8 RID: 21720 RVA: 0x00103EAA File Offset: 0x001022AA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060054D9 RID: 21721 RVA: 0x00103EB5 File Offset: 0x001022B5
		public static void AddGiftID(FlatBufferBuilder builder, int GiftID)
		{
			builder.AddInt(1, GiftID, 0);
		}

		// Token: 0x060054DA RID: 21722 RVA: 0x00103EC0 File Offset: 0x001022C0
		public static void AddTotalRmb(FlatBufferBuilder builder, int TotalRmb)
		{
			builder.AddInt(2, TotalRmb, 0);
		}

		// Token: 0x060054DB RID: 21723 RVA: 0x00103ECB File Offset: 0x001022CB
		public static void AddGiftItems(FlatBufferBuilder builder, VectorOffset GiftItemsOffset)
		{
			builder.AddOffset(3, GiftItemsOffset.Value, 0);
		}

		// Token: 0x060054DC RID: 21724 RVA: 0x00103EDC File Offset: 0x001022DC
		public static VectorOffset CreateGiftItemsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054DD RID: 21725 RVA: 0x00103F22 File Offset: 0x00102322
		public static void StartGiftItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054DE RID: 21726 RVA: 0x00103F2D File Offset: 0x0010232D
		public static void AddGiftPrePrice(FlatBufferBuilder builder, int GiftPrePrice)
		{
			builder.AddInt(4, GiftPrePrice, 0);
		}

		// Token: 0x060054DF RID: 21727 RVA: 0x00103F38 File Offset: 0x00102338
		public static void AddGiftDiscountPrice(FlatBufferBuilder builder, int GiftDiscountPrice)
		{
			builder.AddInt(5, GiftDiscountPrice, 0);
		}

		// Token: 0x060054E0 RID: 21728 RVA: 0x00103F43 File Offset: 0x00102343
		public static void AddArtifactJarDicountRate(FlatBufferBuilder builder, VectorOffset ArtifactJarDicountRateOffset)
		{
			builder.AddOffset(6, ArtifactJarDicountRateOffset.Value, 0);
		}

		// Token: 0x060054E1 RID: 21729 RVA: 0x00103F54 File Offset: 0x00102354
		public static VectorOffset CreateArtifactJarDicountRateVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054E2 RID: 21730 RVA: 0x00103F9A File Offset: 0x0010239A
		public static void StartArtifactJarDicountRateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054E3 RID: 21731 RVA: 0x00103FA5 File Offset: 0x001023A5
		public static void AddArtifactJarDiscountProb(FlatBufferBuilder builder, VectorOffset ArtifactJarDiscountProbOffset)
		{
			builder.AddOffset(7, ArtifactJarDiscountProbOffset.Value, 0);
		}

		// Token: 0x060054E4 RID: 21732 RVA: 0x00103FB8 File Offset: 0x001023B8
		public static VectorOffset CreateArtifactJarDiscountProbVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054E5 RID: 21733 RVA: 0x00103FFE File Offset: 0x001023FE
		public static void StartArtifactJarDiscountProbVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054E6 RID: 21734 RVA: 0x00104009 File Offset: 0x00102409
		public static void AddArtifactJarDiscountEffectTimes(FlatBufferBuilder builder, VectorOffset ArtifactJarDiscountEffectTimesOffset)
		{
			builder.AddOffset(8, ArtifactJarDiscountEffectTimesOffset.Value, 0);
		}

		// Token: 0x060054E7 RID: 21735 RVA: 0x0010401C File Offset: 0x0010241C
		public static VectorOffset CreateArtifactJarDiscountEffectTimesVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054E8 RID: 21736 RVA: 0x00104062 File Offset: 0x00102462
		public static void StartArtifactJarDiscountEffectTimesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054E9 RID: 21737 RVA: 0x0010406D File Offset: 0x0010246D
		public static void AddArtifactJarDiscountETProb(FlatBufferBuilder builder, VectorOffset ArtifactJarDiscountETProbOffset)
		{
			builder.AddOffset(9, ArtifactJarDiscountETProbOffset.Value, 0);
		}

		// Token: 0x060054EA RID: 21738 RVA: 0x00104080 File Offset: 0x00102480
		public static VectorOffset CreateArtifactJarDiscountETProbVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054EB RID: 21739 RVA: 0x001040C6 File Offset: 0x001024C6
		public static void StartArtifactJarDiscountETProbVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054EC RID: 21740 RVA: 0x001040D1 File Offset: 0x001024D1
		public static void AddArtifactJarDiscountEffectTimes1(FlatBufferBuilder builder, VectorOffset ArtifactJarDiscountEffectTimes1Offset)
		{
			builder.AddOffset(10, ArtifactJarDiscountEffectTimes1Offset.Value, 0);
		}

		// Token: 0x060054ED RID: 21741 RVA: 0x001040E4 File Offset: 0x001024E4
		public static VectorOffset CreateArtifactJarDiscountEffectTimes1Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054EE RID: 21742 RVA: 0x0010412A File Offset: 0x0010252A
		public static void StartArtifactJarDiscountEffectTimes1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054EF RID: 21743 RVA: 0x00104135 File Offset: 0x00102535
		public static void AddArtifactJarDiscountETProb1(FlatBufferBuilder builder, VectorOffset ArtifactJarDiscountETProb1Offset)
		{
			builder.AddOffset(11, ArtifactJarDiscountETProb1Offset.Value, 0);
		}

		// Token: 0x060054F0 RID: 21744 RVA: 0x00104148 File Offset: 0x00102548
		public static VectorOffset CreateArtifactJarDiscountETProb1Vector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060054F1 RID: 21745 RVA: 0x0010418E File Offset: 0x0010258E
		public static void StartArtifactJarDiscountETProb1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060054F2 RID: 21746 RVA: 0x0010419C File Offset: 0x0010259C
		public static Offset<VipTable> EndVipTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<VipTable>(value);
		}

		// Token: 0x060054F3 RID: 21747 RVA: 0x001041B6 File Offset: 0x001025B6
		public static void FinishVipTableBuffer(FlatBufferBuilder builder, Offset<VipTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E94 RID: 7828
		private Table __p = new Table();

		// Token: 0x04001E95 RID: 7829
		private FlatBufferArray<string> GiftItemsValue;

		// Token: 0x04001E96 RID: 7830
		private FlatBufferArray<string> ArtifactJarDicountRateValue;

		// Token: 0x04001E97 RID: 7831
		private FlatBufferArray<string> ArtifactJarDiscountProbValue;

		// Token: 0x04001E98 RID: 7832
		private FlatBufferArray<string> ArtifactJarDiscountEffectTimesValue;

		// Token: 0x04001E99 RID: 7833
		private FlatBufferArray<string> ArtifactJarDiscountETProbValue;

		// Token: 0x04001E9A RID: 7834
		private FlatBufferArray<string> ArtifactJarDiscountEffectTimes1Value;

		// Token: 0x04001E9B RID: 7835
		private FlatBufferArray<string> ArtifactJarDiscountETProb1Value;

		// Token: 0x0200061D RID: 1565
		public enum eCrypt
		{
			// Token: 0x04001E9D RID: 7837
			code = 501515545
		}
	}
}
