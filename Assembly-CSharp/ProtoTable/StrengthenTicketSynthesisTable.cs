using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005D5 RID: 1493
	public class StrengthenTicketSynthesisTable : IFlatbufferObject
	{
		// Token: 0x170015C6 RID: 5574
		// (get) Token: 0x06004F23 RID: 20259 RVA: 0x000F5D0C File Offset: 0x000F410C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F24 RID: 20260 RVA: 0x000F5D19 File Offset: 0x000F4119
		public static StrengthenTicketSynthesisTable GetRootAsStrengthenTicketSynthesisTable(ByteBuffer _bb)
		{
			return StrengthenTicketSynthesisTable.GetRootAsStrengthenTicketSynthesisTable(_bb, new StrengthenTicketSynthesisTable());
		}

		// Token: 0x06004F25 RID: 20261 RVA: 0x000F5D26 File Offset: 0x000F4126
		public static StrengthenTicketSynthesisTable GetRootAsStrengthenTicketSynthesisTable(ByteBuffer _bb, StrengthenTicketSynthesisTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F26 RID: 20262 RVA: 0x000F5D42 File Offset: 0x000F4142
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F27 RID: 20263 RVA: 0x000F5D5C File Offset: 0x000F415C
		public StrengthenTicketSynthesisTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015C7 RID: 5575
		// (get) Token: 0x06004F28 RID: 20264 RVA: 0x000F5D68 File Offset: 0x000F4168
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015C8 RID: 5576
		// (get) Token: 0x06004F29 RID: 20265 RVA: 0x000F5DB4 File Offset: 0x000F41B4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F2A RID: 20266 RVA: 0x000F5DF6 File Offset: 0x000F41F6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170015C9 RID: 5577
		// (get) Token: 0x06004F2B RID: 20267 RVA: 0x000F5E04 File Offset: 0x000F4204
		public int StrengthenLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015CA RID: 5578
		// (get) Token: 0x06004F2C RID: 20268 RVA: 0x000F5E50 File Offset: 0x000F4250
		public int Binding
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015CB RID: 5579
		// (get) Token: 0x06004F2D RID: 20269 RVA: 0x000F5E9C File Offset: 0x000F429C
		public int Amplitude
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F2E RID: 20270 RVA: 0x000F5EE8 File Offset: 0x000F42E8
		public string CostMaterialArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170015CC RID: 5580
		// (get) Token: 0x06004F2F RID: 20271 RVA: 0x000F5F30 File Offset: 0x000F4330
		public int CostMaterialLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015CD RID: 5581
		// (get) Token: 0x06004F30 RID: 20272 RVA: 0x000F5F63 File Offset: 0x000F4363
		public FlatBufferArray<string> CostMaterial
		{
			get
			{
				if (this.CostMaterialValue == null)
				{
					this.CostMaterialValue = new FlatBufferArray<string>(new Func<int, string>(this.CostMaterialArray), this.CostMaterialLength);
				}
				return this.CostMaterialValue;
			}
		}

		// Token: 0x170015CE RID: 5582
		// (get) Token: 0x06004F31 RID: 20273 RVA: 0x000F5F94 File Offset: 0x000F4394
		public int Lower
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015CF RID: 5583
		// (get) Token: 0x06004F32 RID: 20274 RVA: 0x000F5FE0 File Offset: 0x000F43E0
		public int Upper
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D0 RID: 5584
		// (get) Token: 0x06004F33 RID: 20275 RVA: 0x000F602C File Offset: 0x000F442C
		public int Mu
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D1 RID: 5585
		// (get) Token: 0x06004F34 RID: 20276 RVA: 0x000F6078 File Offset: 0x000F4478
		public int Sigmal
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D2 RID: 5586
		// (get) Token: 0x06004F35 RID: 20277 RVA: 0x000F60C4 File Offset: 0x000F44C4
		public int SynthProbOfPerfect
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D3 RID: 5587
		// (get) Token: 0x06004F36 RID: 20278 RVA: 0x000F6110 File Offset: 0x000F4510
		public int DisplayItemIndex
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (650780000 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F37 RID: 20279 RVA: 0x000F615C File Offset: 0x000F455C
		public static Offset<StrengthenTicketSynthesisTable> CreateStrengthenTicketSynthesisTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int StrengthenLv = 0, int Binding = 0, int Amplitude = 0, VectorOffset CostMaterialOffset = default(VectorOffset), int Lower = 0, int Upper = 0, int Mu = 0, int Sigmal = 0, int SynthProbOfPerfect = 0, int DisplayItemIndex = 0)
		{
			builder.StartObject(12);
			StrengthenTicketSynthesisTable.AddDisplayItemIndex(builder, DisplayItemIndex);
			StrengthenTicketSynthesisTable.AddSynthProbOfPerfect(builder, SynthProbOfPerfect);
			StrengthenTicketSynthesisTable.AddSigmal(builder, Sigmal);
			StrengthenTicketSynthesisTable.AddMu(builder, Mu);
			StrengthenTicketSynthesisTable.AddUpper(builder, Upper);
			StrengthenTicketSynthesisTable.AddLower(builder, Lower);
			StrengthenTicketSynthesisTable.AddCostMaterial(builder, CostMaterialOffset);
			StrengthenTicketSynthesisTable.AddAmplitude(builder, Amplitude);
			StrengthenTicketSynthesisTable.AddBinding(builder, Binding);
			StrengthenTicketSynthesisTable.AddStrengthenLv(builder, StrengthenLv);
			StrengthenTicketSynthesisTable.AddName(builder, NameOffset);
			StrengthenTicketSynthesisTable.AddID(builder, ID);
			return StrengthenTicketSynthesisTable.EndStrengthenTicketSynthesisTable(builder);
		}

		// Token: 0x06004F38 RID: 20280 RVA: 0x000F61D4 File Offset: 0x000F45D4
		public static void StartStrengthenTicketSynthesisTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06004F39 RID: 20281 RVA: 0x000F61DE File Offset: 0x000F45DE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004F3A RID: 20282 RVA: 0x000F61E9 File Offset: 0x000F45E9
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004F3B RID: 20283 RVA: 0x000F61FA File Offset: 0x000F45FA
		public static void AddStrengthenLv(FlatBufferBuilder builder, int StrengthenLv)
		{
			builder.AddInt(2, StrengthenLv, 0);
		}

		// Token: 0x06004F3C RID: 20284 RVA: 0x000F6205 File Offset: 0x000F4605
		public static void AddBinding(FlatBufferBuilder builder, int Binding)
		{
			builder.AddInt(3, Binding, 0);
		}

		// Token: 0x06004F3D RID: 20285 RVA: 0x000F6210 File Offset: 0x000F4610
		public static void AddAmplitude(FlatBufferBuilder builder, int Amplitude)
		{
			builder.AddInt(4, Amplitude, 0);
		}

		// Token: 0x06004F3E RID: 20286 RVA: 0x000F621B File Offset: 0x000F461B
		public static void AddCostMaterial(FlatBufferBuilder builder, VectorOffset CostMaterialOffset)
		{
			builder.AddOffset(5, CostMaterialOffset.Value, 0);
		}

		// Token: 0x06004F3F RID: 20287 RVA: 0x000F622C File Offset: 0x000F462C
		public static VectorOffset CreateCostMaterialVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004F40 RID: 20288 RVA: 0x000F6272 File Offset: 0x000F4672
		public static void StartCostMaterialVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004F41 RID: 20289 RVA: 0x000F627D File Offset: 0x000F467D
		public static void AddLower(FlatBufferBuilder builder, int Lower)
		{
			builder.AddInt(6, Lower, 0);
		}

		// Token: 0x06004F42 RID: 20290 RVA: 0x000F6288 File Offset: 0x000F4688
		public static void AddUpper(FlatBufferBuilder builder, int Upper)
		{
			builder.AddInt(7, Upper, 0);
		}

		// Token: 0x06004F43 RID: 20291 RVA: 0x000F6293 File Offset: 0x000F4693
		public static void AddMu(FlatBufferBuilder builder, int Mu)
		{
			builder.AddInt(8, Mu, 0);
		}

		// Token: 0x06004F44 RID: 20292 RVA: 0x000F629E File Offset: 0x000F469E
		public static void AddSigmal(FlatBufferBuilder builder, int Sigmal)
		{
			builder.AddInt(9, Sigmal, 0);
		}

		// Token: 0x06004F45 RID: 20293 RVA: 0x000F62AA File Offset: 0x000F46AA
		public static void AddSynthProbOfPerfect(FlatBufferBuilder builder, int SynthProbOfPerfect)
		{
			builder.AddInt(10, SynthProbOfPerfect, 0);
		}

		// Token: 0x06004F46 RID: 20294 RVA: 0x000F62B6 File Offset: 0x000F46B6
		public static void AddDisplayItemIndex(FlatBufferBuilder builder, int DisplayItemIndex)
		{
			builder.AddInt(11, DisplayItemIndex, 0);
		}

		// Token: 0x06004F47 RID: 20295 RVA: 0x000F62C4 File Offset: 0x000F46C4
		public static Offset<StrengthenTicketSynthesisTable> EndStrengthenTicketSynthesisTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StrengthenTicketSynthesisTable>(value);
		}

		// Token: 0x06004F48 RID: 20296 RVA: 0x000F62DE File Offset: 0x000F46DE
		public static void FinishStrengthenTicketSynthesisTableBuffer(FlatBufferBuilder builder, Offset<StrengthenTicketSynthesisTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BE1 RID: 7137
		private Table __p = new Table();

		// Token: 0x04001BE2 RID: 7138
		private FlatBufferArray<string> CostMaterialValue;

		// Token: 0x020005D6 RID: 1494
		public enum eCrypt
		{
			// Token: 0x04001BE4 RID: 7140
			code = 650780000
		}
	}
}
