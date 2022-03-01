using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004E3 RID: 1251
	public class MagicCardTable : IFlatbufferObject
	{
		// Token: 0x1700108A RID: 4234
		// (get) Token: 0x06003F33 RID: 16179 RVA: 0x000D0770 File Offset: 0x000CEB70
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x000D077D File Offset: 0x000CEB7D
		public static MagicCardTable GetRootAsMagicCardTable(ByteBuffer _bb)
		{
			return MagicCardTable.GetRootAsMagicCardTable(_bb, new MagicCardTable());
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x000D078A File Offset: 0x000CEB8A
		public static MagicCardTable GetRootAsMagicCardTable(ByteBuffer _bb, MagicCardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003F36 RID: 16182 RVA: 0x000D07A6 File Offset: 0x000CEBA6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003F37 RID: 16183 RVA: 0x000D07C0 File Offset: 0x000CEBC0
		public MagicCardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700108B RID: 4235
		// (get) Token: 0x06003F38 RID: 16184 RVA: 0x000D07CC File Offset: 0x000CEBCC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700108C RID: 4236
		// (get) Token: 0x06003F39 RID: 16185 RVA: 0x000D0818 File Offset: 0x000CEC18
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x000D085A File Offset: 0x000CEC5A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700108D RID: 4237
		// (get) Token: 0x06003F3B RID: 16187 RVA: 0x000D0868 File Offset: 0x000CEC68
		public int Color
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700108E RID: 4238
		// (get) Token: 0x06003F3C RID: 16188 RVA: 0x000D08B4 File Offset: 0x000CECB4
		public int Stage
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003F3D RID: 16189 RVA: 0x000D0900 File Offset: 0x000CED00
		public int PartsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700108F RID: 4239
		// (get) Token: 0x06003F3E RID: 16190 RVA: 0x000D0950 File Offset: 0x000CED50
		public int PartsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F3F RID: 16191 RVA: 0x000D0983 File Offset: 0x000CED83
		public ArraySegment<byte>? GetPartsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001090 RID: 4240
		// (get) Token: 0x06003F40 RID: 16192 RVA: 0x000D0992 File Offset: 0x000CED92
		public FlatBufferArray<int> Parts
		{
			get
			{
				if (this.PartsValue == null)
				{
					this.PartsValue = new FlatBufferArray<int>(new Func<int, int>(this.PartsArray), this.PartsLength);
				}
				return this.PartsValue;
			}
		}

		// Token: 0x06003F41 RID: 16193 RVA: 0x000D09C4 File Offset: 0x000CEDC4
		public int PropTypeArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001091 RID: 4241
		// (get) Token: 0x06003F42 RID: 16194 RVA: 0x000D0A14 File Offset: 0x000CEE14
		public int PropTypeLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F43 RID: 16195 RVA: 0x000D0A47 File Offset: 0x000CEE47
		public ArraySegment<byte>? GetPropTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001092 RID: 4242
		// (get) Token: 0x06003F44 RID: 16196 RVA: 0x000D0A56 File Offset: 0x000CEE56
		public FlatBufferArray<int> PropType
		{
			get
			{
				if (this.PropTypeValue == null)
				{
					this.PropTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.PropTypeArray), this.PropTypeLength);
				}
				return this.PropTypeValue;
			}
		}

		// Token: 0x06003F45 RID: 16197 RVA: 0x000D0A88 File Offset: 0x000CEE88
		public int PropValueArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001093 RID: 4243
		// (get) Token: 0x06003F46 RID: 16198 RVA: 0x000D0AD8 File Offset: 0x000CEED8
		public int PropValueLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F47 RID: 16199 RVA: 0x000D0B0B File Offset: 0x000CEF0B
		public ArraySegment<byte>? GetPropValueBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001094 RID: 4244
		// (get) Token: 0x06003F48 RID: 16200 RVA: 0x000D0B1A File Offset: 0x000CEF1A
		public FlatBufferArray<int> PropValue
		{
			get
			{
				if (this.PropValueValue == null)
				{
					this.PropValueValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValueArray), this.PropValueLength);
				}
				return this.PropValueValue;
			}
		}

		// Token: 0x06003F49 RID: 16201 RVA: 0x000D0B4C File Offset: 0x000CEF4C
		public int PropValue_PVPArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001095 RID: 4245
		// (get) Token: 0x06003F4A RID: 16202 RVA: 0x000D0B9C File Offset: 0x000CEF9C
		public int PropValue_PVPLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F4B RID: 16203 RVA: 0x000D0BCF File Offset: 0x000CEFCF
		public ArraySegment<byte>? GetPropValuePVPBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x06003F4C RID: 16204 RVA: 0x000D0BDE File Offset: 0x000CEFDE
		public FlatBufferArray<int> PropValue_PVP
		{
			get
			{
				if (this.PropValue_PVPValue == null)
				{
					this.PropValue_PVPValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValue_PVPArray), this.PropValue_PVPLength);
				}
				return this.PropValue_PVPValue;
			}
		}

		// Token: 0x06003F4D RID: 16205 RVA: 0x000D0C10 File Offset: 0x000CF010
		public int BuffIDArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x06003F4E RID: 16206 RVA: 0x000D0C60 File Offset: 0x000CF060
		public int BuffIDLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F4F RID: 16207 RVA: 0x000D0C93 File Offset: 0x000CF093
		public ArraySegment<byte>? GetBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x06003F50 RID: 16208 RVA: 0x000D0CA2 File Offset: 0x000CF0A2
		public FlatBufferArray<int> BuffID
		{
			get
			{
				if (this.BuffIDValue == null)
				{
					this.BuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffIDArray), this.BuffIDLength);
				}
				return this.BuffIDValue;
			}
		}

		// Token: 0x06003F51 RID: 16209 RVA: 0x000D0CD4 File Offset: 0x000CF0D4
		public int BuffID_PVPArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x06003F52 RID: 16210 RVA: 0x000D0D24 File Offset: 0x000CF124
		public int BuffID_PVPLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F53 RID: 16211 RVA: 0x000D0D57 File Offset: 0x000CF157
		public ArraySegment<byte>? GetBuffIDPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06003F54 RID: 16212 RVA: 0x000D0D66 File Offset: 0x000CF166
		public FlatBufferArray<int> BuffID_PVP
		{
			get
			{
				if (this.BuffID_PVPValue == null)
				{
					this.BuffID_PVPValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffID_PVPArray), this.BuffID_PVPLength);
				}
				return this.BuffID_PVPValue;
			}
		}

		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06003F55 RID: 16213 RVA: 0x000D0D98 File Offset: 0x000CF198
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x000D0DE4 File Offset: 0x000CF1E4
		public int UpValueArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06003F57 RID: 16215 RVA: 0x000D0E34 File Offset: 0x000CF234
		public int UpValueLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F58 RID: 16216 RVA: 0x000D0E67 File Offset: 0x000CF267
		public ArraySegment<byte>? GetUpValueBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06003F59 RID: 16217 RVA: 0x000D0E76 File Offset: 0x000CF276
		public FlatBufferArray<int> UpValue
		{
			get
			{
				if (this.UpValueValue == null)
				{
					this.UpValueValue = new FlatBufferArray<int>(new Func<int, int>(this.UpValueArray), this.UpValueLength);
				}
				return this.UpValueValue;
			}
		}

		// Token: 0x06003F5A RID: 16218 RVA: 0x000D0EA8 File Offset: 0x000CF2A8
		public int UpValue_PVPArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x06003F5B RID: 16219 RVA: 0x000D0EF8 File Offset: 0x000CF2F8
		public int UpValue_PVPLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F5C RID: 16220 RVA: 0x000D0F2B File Offset: 0x000CF32B
		public ArraySegment<byte>? GetUpValuePVPBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x06003F5D RID: 16221 RVA: 0x000D0F3A File Offset: 0x000CF33A
		public FlatBufferArray<int> UpValue_PVP
		{
			get
			{
				if (this.UpValue_PVPValue == null)
				{
					this.UpValue_PVPValue = new FlatBufferArray<int>(new Func<int, int>(this.UpValue_PVPArray), this.UpValue_PVPLength);
				}
				return this.UpValue_PVPValue;
			}
		}

		// Token: 0x06003F5E RID: 16222 RVA: 0x000D0F6C File Offset: 0x000CF36C
		public int UpBuffIDArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06003F5F RID: 16223 RVA: 0x000D0FBC File Offset: 0x000CF3BC
		public int UpBuffIDLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F60 RID: 16224 RVA: 0x000D0FEF File Offset: 0x000CF3EF
		public ArraySegment<byte>? GetUpBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06003F61 RID: 16225 RVA: 0x000D0FFE File Offset: 0x000CF3FE
		public FlatBufferArray<int> UpBuffID
		{
			get
			{
				if (this.UpBuffIDValue == null)
				{
					this.UpBuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.UpBuffIDArray), this.UpBuffIDLength);
				}
				return this.UpBuffIDValue;
			}
		}

		// Token: 0x06003F62 RID: 16226 RVA: 0x000D1030 File Offset: 0x000CF430
		public int UpBuffID_PVPArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06003F63 RID: 16227 RVA: 0x000D1080 File Offset: 0x000CF480
		public int UpBuffID_PVPLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003F64 RID: 16228 RVA: 0x000D10B3 File Offset: 0x000CF4B3
		public ArraySegment<byte>? GetUpBuffIDPVPBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x06003F65 RID: 16229 RVA: 0x000D10C2 File Offset: 0x000CF4C2
		public FlatBufferArray<int> UpBuffID_PVP
		{
			get
			{
				if (this.UpBuffID_PVPValue == null)
				{
					this.UpBuffID_PVPValue = new FlatBufferArray<int>(new Func<int, int>(this.UpBuffID_PVPArray), this.UpBuffID_PVPLength);
				}
				return this.UpBuffID_PVPValue;
			}
		}

		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x06003F66 RID: 16230 RVA: 0x000D10F4 File Offset: 0x000CF4F4
		public string BuffDescribe
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F67 RID: 16231 RVA: 0x000D1137 File Offset: 0x000CF537
		public ArraySegment<byte>? GetBuffDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x06003F68 RID: 16232 RVA: 0x000D1148 File Offset: 0x000CF548
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x06003F69 RID: 16233 RVA: 0x000D1194 File Offset: 0x000CF594
		public int Rate
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x06003F6A RID: 16234 RVA: 0x000D11E0 File Offset: 0x000CF5E0
		public string SkillAttributes
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003F6B RID: 16235 RVA: 0x000D1223 File Offset: 0x000CF623
		public ArraySegment<byte>? GetSkillAttributesBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x06003F6C RID: 16236 RVA: 0x000D1234 File Offset: 0x000CF634
		public int CostItemId
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x06003F6D RID: 16237 RVA: 0x000D1280 File Offset: 0x000CF680
		public int CostNum
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06003F6E RID: 16238 RVA: 0x000D12CC File Offset: 0x000CF6CC
		public int Score
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06003F6F RID: 16239 RVA: 0x000D1318 File Offset: 0x000CF718
		public int UpAddScore
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (1085107691 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003F70 RID: 16240 RVA: 0x000D1364 File Offset: 0x000CF764
		public static Offset<MagicCardTable> CreateMagicCardTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Color = 0, int Stage = 0, VectorOffset PartsOffset = default(VectorOffset), VectorOffset PropTypeOffset = default(VectorOffset), VectorOffset PropValueOffset = default(VectorOffset), VectorOffset PropValue_PVPOffset = default(VectorOffset), VectorOffset BuffIDOffset = default(VectorOffset), VectorOffset BuffID_PVPOffset = default(VectorOffset), int MaxLevel = 0, VectorOffset UpValueOffset = default(VectorOffset), VectorOffset UpValue_PVPOffset = default(VectorOffset), VectorOffset UpBuffIDOffset = default(VectorOffset), VectorOffset UpBuffID_PVPOffset = default(VectorOffset), StringOffset BuffDescribeOffset = default(StringOffset), int Weight = 0, int Rate = 0, StringOffset SkillAttributesOffset = default(StringOffset), int CostItemId = 0, int CostNum = 0, int Score = 0, int UpAddScore = 0)
		{
			builder.StartObject(23);
			MagicCardTable.AddUpAddScore(builder, UpAddScore);
			MagicCardTable.AddScore(builder, Score);
			MagicCardTable.AddCostNum(builder, CostNum);
			MagicCardTable.AddCostItemId(builder, CostItemId);
			MagicCardTable.AddSkillAttributes(builder, SkillAttributesOffset);
			MagicCardTable.AddRate(builder, Rate);
			MagicCardTable.AddWeight(builder, Weight);
			MagicCardTable.AddBuffDescribe(builder, BuffDescribeOffset);
			MagicCardTable.AddUpBuffIDPVP(builder, UpBuffID_PVPOffset);
			MagicCardTable.AddUpBuffID(builder, UpBuffIDOffset);
			MagicCardTable.AddUpValuePVP(builder, UpValue_PVPOffset);
			MagicCardTable.AddUpValue(builder, UpValueOffset);
			MagicCardTable.AddMaxLevel(builder, MaxLevel);
			MagicCardTable.AddBuffIDPVP(builder, BuffID_PVPOffset);
			MagicCardTable.AddBuffID(builder, BuffIDOffset);
			MagicCardTable.AddPropValuePVP(builder, PropValue_PVPOffset);
			MagicCardTable.AddPropValue(builder, PropValueOffset);
			MagicCardTable.AddPropType(builder, PropTypeOffset);
			MagicCardTable.AddParts(builder, PartsOffset);
			MagicCardTable.AddStage(builder, Stage);
			MagicCardTable.AddColor(builder, Color);
			MagicCardTable.AddName(builder, NameOffset);
			MagicCardTable.AddID(builder, ID);
			return MagicCardTable.EndMagicCardTable(builder);
		}

		// Token: 0x06003F71 RID: 16241 RVA: 0x000D1434 File Offset: 0x000CF834
		public static void StartMagicCardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(23);
		}

		// Token: 0x06003F72 RID: 16242 RVA: 0x000D143E File Offset: 0x000CF83E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003F73 RID: 16243 RVA: 0x000D1449 File Offset: 0x000CF849
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003F74 RID: 16244 RVA: 0x000D145A File Offset: 0x000CF85A
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(2, Color, 0);
		}

		// Token: 0x06003F75 RID: 16245 RVA: 0x000D1465 File Offset: 0x000CF865
		public static void AddStage(FlatBufferBuilder builder, int Stage)
		{
			builder.AddInt(3, Stage, 0);
		}

		// Token: 0x06003F76 RID: 16246 RVA: 0x000D1470 File Offset: 0x000CF870
		public static void AddParts(FlatBufferBuilder builder, VectorOffset PartsOffset)
		{
			builder.AddOffset(4, PartsOffset.Value, 0);
		}

		// Token: 0x06003F77 RID: 16247 RVA: 0x000D1484 File Offset: 0x000CF884
		public static VectorOffset CreatePartsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F78 RID: 16248 RVA: 0x000D14C1 File Offset: 0x000CF8C1
		public static void StartPartsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F79 RID: 16249 RVA: 0x000D14CC File Offset: 0x000CF8CC
		public static void AddPropType(FlatBufferBuilder builder, VectorOffset PropTypeOffset)
		{
			builder.AddOffset(5, PropTypeOffset.Value, 0);
		}

		// Token: 0x06003F7A RID: 16250 RVA: 0x000D14E0 File Offset: 0x000CF8E0
		public static VectorOffset CreatePropTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F7B RID: 16251 RVA: 0x000D151D File Offset: 0x000CF91D
		public static void StartPropTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F7C RID: 16252 RVA: 0x000D1528 File Offset: 0x000CF928
		public static void AddPropValue(FlatBufferBuilder builder, VectorOffset PropValueOffset)
		{
			builder.AddOffset(6, PropValueOffset.Value, 0);
		}

		// Token: 0x06003F7D RID: 16253 RVA: 0x000D153C File Offset: 0x000CF93C
		public static VectorOffset CreatePropValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F7E RID: 16254 RVA: 0x000D1579 File Offset: 0x000CF979
		public static void StartPropValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F7F RID: 16255 RVA: 0x000D1584 File Offset: 0x000CF984
		public static void AddPropValuePVP(FlatBufferBuilder builder, VectorOffset PropValuePVPOffset)
		{
			builder.AddOffset(7, PropValuePVPOffset.Value, 0);
		}

		// Token: 0x06003F80 RID: 16256 RVA: 0x000D1598 File Offset: 0x000CF998
		public static VectorOffset CreatePropValuePVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F81 RID: 16257 RVA: 0x000D15D5 File Offset: 0x000CF9D5
		public static void StartPropValuePVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F82 RID: 16258 RVA: 0x000D15E0 File Offset: 0x000CF9E0
		public static void AddBuffID(FlatBufferBuilder builder, VectorOffset BuffIDOffset)
		{
			builder.AddOffset(8, BuffIDOffset.Value, 0);
		}

		// Token: 0x06003F83 RID: 16259 RVA: 0x000D15F4 File Offset: 0x000CF9F4
		public static VectorOffset CreateBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F84 RID: 16260 RVA: 0x000D1631 File Offset: 0x000CFA31
		public static void StartBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F85 RID: 16261 RVA: 0x000D163C File Offset: 0x000CFA3C
		public static void AddBuffIDPVP(FlatBufferBuilder builder, VectorOffset BuffIDPVPOffset)
		{
			builder.AddOffset(9, BuffIDPVPOffset.Value, 0);
		}

		// Token: 0x06003F86 RID: 16262 RVA: 0x000D1650 File Offset: 0x000CFA50
		public static VectorOffset CreateBuffIDPVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F87 RID: 16263 RVA: 0x000D168D File Offset: 0x000CFA8D
		public static void StartBuffIDPVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F88 RID: 16264 RVA: 0x000D1698 File Offset: 0x000CFA98
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(10, MaxLevel, 0);
		}

		// Token: 0x06003F89 RID: 16265 RVA: 0x000D16A4 File Offset: 0x000CFAA4
		public static void AddUpValue(FlatBufferBuilder builder, VectorOffset UpValueOffset)
		{
			builder.AddOffset(11, UpValueOffset.Value, 0);
		}

		// Token: 0x06003F8A RID: 16266 RVA: 0x000D16B8 File Offset: 0x000CFAB8
		public static VectorOffset CreateUpValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F8B RID: 16267 RVA: 0x000D16F5 File Offset: 0x000CFAF5
		public static void StartUpValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F8C RID: 16268 RVA: 0x000D1700 File Offset: 0x000CFB00
		public static void AddUpValuePVP(FlatBufferBuilder builder, VectorOffset UpValuePVPOffset)
		{
			builder.AddOffset(12, UpValuePVPOffset.Value, 0);
		}

		// Token: 0x06003F8D RID: 16269 RVA: 0x000D1714 File Offset: 0x000CFB14
		public static VectorOffset CreateUpValuePVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F8E RID: 16270 RVA: 0x000D1751 File Offset: 0x000CFB51
		public static void StartUpValuePVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F8F RID: 16271 RVA: 0x000D175C File Offset: 0x000CFB5C
		public static void AddUpBuffID(FlatBufferBuilder builder, VectorOffset UpBuffIDOffset)
		{
			builder.AddOffset(13, UpBuffIDOffset.Value, 0);
		}

		// Token: 0x06003F90 RID: 16272 RVA: 0x000D1770 File Offset: 0x000CFB70
		public static VectorOffset CreateUpBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F91 RID: 16273 RVA: 0x000D17AD File Offset: 0x000CFBAD
		public static void StartUpBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F92 RID: 16274 RVA: 0x000D17B8 File Offset: 0x000CFBB8
		public static void AddUpBuffIDPVP(FlatBufferBuilder builder, VectorOffset UpBuffIDPVPOffset)
		{
			builder.AddOffset(14, UpBuffIDPVPOffset.Value, 0);
		}

		// Token: 0x06003F93 RID: 16275 RVA: 0x000D17CC File Offset: 0x000CFBCC
		public static VectorOffset CreateUpBuffIDPVPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003F94 RID: 16276 RVA: 0x000D1809 File Offset: 0x000CFC09
		public static void StartUpBuffIDPVPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003F95 RID: 16277 RVA: 0x000D1814 File Offset: 0x000CFC14
		public static void AddBuffDescribe(FlatBufferBuilder builder, StringOffset BuffDescribeOffset)
		{
			builder.AddOffset(15, BuffDescribeOffset.Value, 0);
		}

		// Token: 0x06003F96 RID: 16278 RVA: 0x000D1826 File Offset: 0x000CFC26
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(16, Weight, 0);
		}

		// Token: 0x06003F97 RID: 16279 RVA: 0x000D1832 File Offset: 0x000CFC32
		public static void AddRate(FlatBufferBuilder builder, int Rate)
		{
			builder.AddInt(17, Rate, 0);
		}

		// Token: 0x06003F98 RID: 16280 RVA: 0x000D183E File Offset: 0x000CFC3E
		public static void AddSkillAttributes(FlatBufferBuilder builder, StringOffset SkillAttributesOffset)
		{
			builder.AddOffset(18, SkillAttributesOffset.Value, 0);
		}

		// Token: 0x06003F99 RID: 16281 RVA: 0x000D1850 File Offset: 0x000CFC50
		public static void AddCostItemId(FlatBufferBuilder builder, int CostItemId)
		{
			builder.AddInt(19, CostItemId, 0);
		}

		// Token: 0x06003F9A RID: 16282 RVA: 0x000D185C File Offset: 0x000CFC5C
		public static void AddCostNum(FlatBufferBuilder builder, int CostNum)
		{
			builder.AddInt(20, CostNum, 0);
		}

		// Token: 0x06003F9B RID: 16283 RVA: 0x000D1868 File Offset: 0x000CFC68
		public static void AddScore(FlatBufferBuilder builder, int Score)
		{
			builder.AddInt(21, Score, 0);
		}

		// Token: 0x06003F9C RID: 16284 RVA: 0x000D1874 File Offset: 0x000CFC74
		public static void AddUpAddScore(FlatBufferBuilder builder, int UpAddScore)
		{
			builder.AddInt(22, UpAddScore, 0);
		}

		// Token: 0x06003F9D RID: 16285 RVA: 0x000D1880 File Offset: 0x000CFC80
		public static Offset<MagicCardTable> EndMagicCardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MagicCardTable>(value);
		}

		// Token: 0x06003F9E RID: 16286 RVA: 0x000D189A File Offset: 0x000CFC9A
		public static void FinishMagicCardTableBuffer(FlatBufferBuilder builder, Offset<MagicCardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001800 RID: 6144
		private Table __p = new Table();

		// Token: 0x04001801 RID: 6145
		private FlatBufferArray<int> PartsValue;

		// Token: 0x04001802 RID: 6146
		private FlatBufferArray<int> PropTypeValue;

		// Token: 0x04001803 RID: 6147
		private FlatBufferArray<int> PropValueValue;

		// Token: 0x04001804 RID: 6148
		private FlatBufferArray<int> PropValue_PVPValue;

		// Token: 0x04001805 RID: 6149
		private FlatBufferArray<int> BuffIDValue;

		// Token: 0x04001806 RID: 6150
		private FlatBufferArray<int> BuffID_PVPValue;

		// Token: 0x04001807 RID: 6151
		private FlatBufferArray<int> UpValueValue;

		// Token: 0x04001808 RID: 6152
		private FlatBufferArray<int> UpValue_PVPValue;

		// Token: 0x04001809 RID: 6153
		private FlatBufferArray<int> UpBuffIDValue;

		// Token: 0x0400180A RID: 6154
		private FlatBufferArray<int> UpBuffID_PVPValue;

		// Token: 0x020004E4 RID: 1252
		public enum eCrypt
		{
			// Token: 0x0400180C RID: 6156
			code = 1085107691
		}
	}
}
