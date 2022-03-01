using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200061E RID: 1566
	public class VoiceTable : IFlatbufferObject
	{
		// Token: 0x170017E8 RID: 6120
		// (get) Token: 0x060054F5 RID: 21749 RVA: 0x001041D8 File Offset: 0x001025D8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060054F6 RID: 21750 RVA: 0x001041E5 File Offset: 0x001025E5
		public static VoiceTable GetRootAsVoiceTable(ByteBuffer _bb)
		{
			return VoiceTable.GetRootAsVoiceTable(_bb, new VoiceTable());
		}

		// Token: 0x060054F7 RID: 21751 RVA: 0x001041F2 File Offset: 0x001025F2
		public static VoiceTable GetRootAsVoiceTable(ByteBuffer _bb, VoiceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060054F8 RID: 21752 RVA: 0x0010420E File Offset: 0x0010260E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060054F9 RID: 21753 RVA: 0x00104228 File Offset: 0x00102628
		public VoiceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170017E9 RID: 6121
		// (get) Token: 0x060054FA RID: 21754 RVA: 0x00104234 File Offset: 0x00102634
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1319156132 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017EA RID: 6122
		// (get) Token: 0x060054FB RID: 21755 RVA: 0x00104280 File Offset: 0x00102680
		public string VoicePath
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060054FC RID: 21756 RVA: 0x001042C2 File Offset: 0x001026C2
		public ArraySegment<byte>? GetVoicePathBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170017EB RID: 6123
		// (get) Token: 0x060054FD RID: 21757 RVA: 0x001042D0 File Offset: 0x001026D0
		public string VoiceContent
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060054FE RID: 21758 RVA: 0x00104312 File Offset: 0x00102712
		public ArraySegment<byte>? GetVoiceContentBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170017EC RID: 6124
		// (get) Token: 0x060054FF RID: 21759 RVA: 0x00104320 File Offset: 0x00102720
		public VoiceTable.eVoiceType VoiceType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (VoiceTable.eVoiceType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017ED RID: 6125
		// (get) Token: 0x06005500 RID: 21760 RVA: 0x00104364 File Offset: 0x00102764
		public int VoiceWeight
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1319156132 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170017EE RID: 6126
		// (get) Token: 0x06005501 RID: 21761 RVA: 0x001043B0 File Offset: 0x001027B0
		public int VoiceRate
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1319156132 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005502 RID: 21762 RVA: 0x001043FC File Offset: 0x001027FC
		public int VoiceUnitIDArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-1319156132 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170017EF RID: 6127
		// (get) Token: 0x06005503 RID: 21763 RVA: 0x0010444C File Offset: 0x0010284C
		public int VoiceUnitIDLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06005504 RID: 21764 RVA: 0x0010447F File Offset: 0x0010287F
		public ArraySegment<byte>? GetVoiceUnitIDBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170017F0 RID: 6128
		// (get) Token: 0x06005505 RID: 21765 RVA: 0x0010448E File Offset: 0x0010288E
		public FlatBufferArray<int> VoiceUnitID
		{
			get
			{
				if (this.VoiceUnitIDValue == null)
				{
					this.VoiceUnitIDValue = new FlatBufferArray<int>(new Func<int, int>(this.VoiceUnitIDArray), this.VoiceUnitIDLength);
				}
				return this.VoiceUnitIDValue;
			}
		}

		// Token: 0x170017F1 RID: 6129
		// (get) Token: 0x06005506 RID: 21766 RVA: 0x001044C0 File Offset: 0x001028C0
		public string VoiceTag
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005507 RID: 21767 RVA: 0x00104503 File Offset: 0x00102903
		public ArraySegment<byte>? GetVoiceTagBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x06005508 RID: 21768 RVA: 0x00104514 File Offset: 0x00102914
		public static Offset<VoiceTable> CreateVoiceTable(FlatBufferBuilder builder, int ID = 0, StringOffset VoicePathOffset = default(StringOffset), StringOffset VoiceContentOffset = default(StringOffset), VoiceTable.eVoiceType VoiceType = VoiceTable.eVoiceType.VoiceType_None, int VoiceWeight = 0, int VoiceRate = 0, VectorOffset VoiceUnitIDOffset = default(VectorOffset), StringOffset VoiceTagOffset = default(StringOffset))
		{
			builder.StartObject(8);
			VoiceTable.AddVoiceTag(builder, VoiceTagOffset);
			VoiceTable.AddVoiceUnitID(builder, VoiceUnitIDOffset);
			VoiceTable.AddVoiceRate(builder, VoiceRate);
			VoiceTable.AddVoiceWeight(builder, VoiceWeight);
			VoiceTable.AddVoiceType(builder, VoiceType);
			VoiceTable.AddVoiceContent(builder, VoiceContentOffset);
			VoiceTable.AddVoicePath(builder, VoicePathOffset);
			VoiceTable.AddID(builder, ID);
			return VoiceTable.EndVoiceTable(builder);
		}

		// Token: 0x06005509 RID: 21769 RVA: 0x0010456B File Offset: 0x0010296B
		public static void StartVoiceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0600550A RID: 21770 RVA: 0x00104574 File Offset: 0x00102974
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600550B RID: 21771 RVA: 0x0010457F File Offset: 0x0010297F
		public static void AddVoicePath(FlatBufferBuilder builder, StringOffset VoicePathOffset)
		{
			builder.AddOffset(1, VoicePathOffset.Value, 0);
		}

		// Token: 0x0600550C RID: 21772 RVA: 0x00104590 File Offset: 0x00102990
		public static void AddVoiceContent(FlatBufferBuilder builder, StringOffset VoiceContentOffset)
		{
			builder.AddOffset(2, VoiceContentOffset.Value, 0);
		}

		// Token: 0x0600550D RID: 21773 RVA: 0x001045A1 File Offset: 0x001029A1
		public static void AddVoiceType(FlatBufferBuilder builder, VoiceTable.eVoiceType VoiceType)
		{
			builder.AddInt(3, (int)VoiceType, 0);
		}

		// Token: 0x0600550E RID: 21774 RVA: 0x001045AC File Offset: 0x001029AC
		public static void AddVoiceWeight(FlatBufferBuilder builder, int VoiceWeight)
		{
			builder.AddInt(4, VoiceWeight, 0);
		}

		// Token: 0x0600550F RID: 21775 RVA: 0x001045B7 File Offset: 0x001029B7
		public static void AddVoiceRate(FlatBufferBuilder builder, int VoiceRate)
		{
			builder.AddInt(5, VoiceRate, 0);
		}

		// Token: 0x06005510 RID: 21776 RVA: 0x001045C2 File Offset: 0x001029C2
		public static void AddVoiceUnitID(FlatBufferBuilder builder, VectorOffset VoiceUnitIDOffset)
		{
			builder.AddOffset(6, VoiceUnitIDOffset.Value, 0);
		}

		// Token: 0x06005511 RID: 21777 RVA: 0x001045D4 File Offset: 0x001029D4
		public static VectorOffset CreateVoiceUnitIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06005512 RID: 21778 RVA: 0x00104611 File Offset: 0x00102A11
		public static void StartVoiceUnitIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005513 RID: 21779 RVA: 0x0010461C File Offset: 0x00102A1C
		public static void AddVoiceTag(FlatBufferBuilder builder, StringOffset VoiceTagOffset)
		{
			builder.AddOffset(7, VoiceTagOffset.Value, 0);
		}

		// Token: 0x06005514 RID: 21780 RVA: 0x00104630 File Offset: 0x00102A30
		public static Offset<VoiceTable> EndVoiceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<VoiceTable>(value);
		}

		// Token: 0x06005515 RID: 21781 RVA: 0x0010464A File Offset: 0x00102A4A
		public static void FinishVoiceTableBuffer(FlatBufferBuilder builder, Offset<VoiceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E9E RID: 7838
		private Table __p = new Table();

		// Token: 0x04001E9F RID: 7839
		private FlatBufferArray<int> VoiceUnitIDValue;

		// Token: 0x0200061F RID: 1567
		public enum eVoiceType
		{
			// Token: 0x04001EA1 RID: 7841
			VoiceType_None,
			// Token: 0x04001EA2 RID: 7842
			SELECTROLE,
			// Token: 0x04001EA3 RID: 7843
			GETROLE,
			// Token: 0x04001EA4 RID: 7844
			DUNGEONFINISH,
			// Token: 0x04001EA5 RID: 7845
			DUNGEONDEAD,
			// Token: 0x04001EA6 RID: 7846
			DUNGEONKILLPOWER,
			// Token: 0x04001EA7 RID: 7847
			DUNGEONCLEARROOM,
			// Token: 0x04001EA8 RID: 7848
			DUNGEONPOWERSKILL,
			// Token: 0x04001EA9 RID: 7849
			DIALOGBEGIN,
			// Token: 0x04001EAA RID: 7850
			DIALOGEND,
			// Token: 0x04001EAB RID: 7851
			NEWBIEGUIDE,
			// Token: 0x04001EAC RID: 7852
			ASIDE,
			// Token: 0x04001EAD RID: 7853
			BIRTHROLE
		}

		// Token: 0x02000620 RID: 1568
		public enum eCrypt
		{
			// Token: 0x04001EAF RID: 7855
			code = -1319156132
		}
	}
}
