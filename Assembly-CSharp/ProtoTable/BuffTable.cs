using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002F3 RID: 755
	public class BuffTable : IFlatbufferObject
	{
		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001C03 RID: 7171 RVA: 0x0007B7B8 File Offset: 0x00079BB8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001C04 RID: 7172 RVA: 0x0007B7C5 File Offset: 0x00079BC5
		public static BuffTable GetRootAsBuffTable(ByteBuffer _bb)
		{
			return BuffTable.GetRootAsBuffTable(_bb, new BuffTable());
		}

		// Token: 0x06001C05 RID: 7173 RVA: 0x0007B7D2 File Offset: 0x00079BD2
		public static BuffTable GetRootAsBuffTable(ByteBuffer _bb, BuffTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001C06 RID: 7174 RVA: 0x0007B7EE File Offset: 0x00079BEE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001C07 RID: 7175 RVA: 0x0007B808 File Offset: 0x00079C08
		public BuffTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06001C08 RID: 7176 RVA: 0x0007B814 File Offset: 0x00079C14
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06001C09 RID: 7177 RVA: 0x0007B860 File Offset: 0x00079C60
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C0A RID: 7178 RVA: 0x0007B8A2 File Offset: 0x00079CA2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06001C0B RID: 7179 RVA: 0x0007B8B0 File Offset: 0x00079CB0
		public string Description
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C0C RID: 7180 RVA: 0x0007B8F2 File Offset: 0x00079CF2
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06001C0D RID: 7181 RVA: 0x0007B900 File Offset: 0x00079D00
		public int IconSortOrder
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001C0E RID: 7182 RVA: 0x0007B94C File Offset: 0x00079D4C
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C0F RID: 7183 RVA: 0x0007B98F File Offset: 0x00079D8F
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001C10 RID: 7184 RVA: 0x0007B9A0 File Offset: 0x00079DA0
		public int Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001C11 RID: 7185 RVA: 0x0007B9EC File Offset: 0x00079DEC
		public int IsDelete
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06001C12 RID: 7186 RVA: 0x0007BA38 File Offset: 0x00079E38
		public int WorkType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06001C13 RID: 7187 RVA: 0x0007BA84 File Offset: 0x00079E84
		public int DispelType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06001C14 RID: 7188 RVA: 0x0007BAD0 File Offset: 0x00079ED0
		public int IsQuickPressSupport
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06001C15 RID: 7189 RVA: 0x0007BB1C File Offset: 0x00079F1C
		public string EffectShaderName
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x0007BB5F File Offset: 0x00079F5F
		public ArraySegment<byte>? GetEffectShaderNameBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x0007BB70 File Offset: 0x00079F70
		public string HeadName
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x0007BBB3 File Offset: 0x00079FB3
		public ArraySegment<byte>? GetHeadNameBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06001C19 RID: 7193 RVA: 0x0007BBC4 File Offset: 0x00079FC4
		public string HpBarName
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C1A RID: 7194 RVA: 0x0007BC07 File Offset: 0x0007A007
		public ArraySegment<byte>? GetHpBarNameBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06001C1B RID: 7195 RVA: 0x0007BC18 File Offset: 0x0007A018
		public bool IsShowSpell
		{
			get
			{
				int num = this.__p.__offset(30);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06001C1C RID: 7196 RVA: 0x0007BC64 File Offset: 0x0007A064
		public bool IsLowLevelShow
		{
			get
			{
				int num = this.__p.__offset(32);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06001C1D RID: 7197 RVA: 0x0007BCB0 File Offset: 0x0007A0B0
		public string BirthEffect
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x0007BCF3 File Offset: 0x0007A0F3
		public ArraySegment<byte>? GetBirthEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06001C1F RID: 7199 RVA: 0x0007BD04 File Offset: 0x0007A104
		public string BirthEffectLocate
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x0007BD47 File Offset: 0x0007A147
		public ArraySegment<byte>? GetBirthEffectLocateBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06001C21 RID: 7201 RVA: 0x0007BD58 File Offset: 0x0007A158
		public string EffectName
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x0007BD9B File Offset: 0x0007A19B
		public ArraySegment<byte>? GetEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06001C23 RID: 7203 RVA: 0x0007BDAC File Offset: 0x0007A1AC
		public string EffectLocateName
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x0007BDEF File Offset: 0x0007A1EF
		public ArraySegment<byte>? GetEffectLocateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001C25 RID: 7205 RVA: 0x0007BE00 File Offset: 0x0007A200
		public bool EffectLoop
		{
			get
			{
				int num = this.__p.__offset(42);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001C26 RID: 7206 RVA: 0x0007BE4C File Offset: 0x0007A24C
		public string EndEffect
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x0007BE8F File Offset: 0x0007A28F
		public ArraySegment<byte>? GetEndEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001C28 RID: 7208 RVA: 0x0007BEA0 File Offset: 0x0007A2A0
		public string EndEffectLocate
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x0007BEE3 File Offset: 0x0007A2E3
		public ArraySegment<byte>? GetEndEffectLocateBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001C2A RID: 7210 RVA: 0x0007BEF4 File Offset: 0x0007A2F4
		public string EffectConfigPath
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x0007BF37 File Offset: 0x0007A337
		public ArraySegment<byte>? GetEffectConfigPathBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001C2C RID: 7212 RVA: 0x0007BF48 File Offset: 0x0007A348
		public string HurtEffectName
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x0007BF8B File Offset: 0x0007A38B
		public ArraySegment<byte>? GetHurtEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001C2E RID: 7214 RVA: 0x0007BF9C File Offset: 0x0007A39C
		public string HurtEffectLocateName
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x0007BFDF File Offset: 0x0007A3DF
		public ArraySegment<byte>? GetHurtEffectLocateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06001C30 RID: 7216 RVA: 0x0007BFF0 File Offset: 0x0007A3F0
		public int SfxID
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06001C31 RID: 7217 RVA: 0x0007C03C File Offset: 0x0007A43C
		public string BuffAIPath
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x0007C07F File Offset: 0x0007A47F
		public ArraySegment<byte>? GetBuffAIPathBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x0007C090 File Offset: 0x0007A490
		public int TargetStateArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06001C34 RID: 7220 RVA: 0x0007C0E0 File Offset: 0x0007A4E0
		public int TargetStateLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x0007C113 File Offset: 0x0007A513
		public ArraySegment<byte>? GetTargetStateBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001C36 RID: 7222 RVA: 0x0007C122 File Offset: 0x0007A522
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

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06001C37 RID: 7223 RVA: 0x0007C154 File Offset: 0x0007A554
		public int Overlay
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06001C38 RID: 7224 RVA: 0x0007C1A0 File Offset: 0x0007A5A0
		public int OverlayLimit
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06001C39 RID: 7225 RVA: 0x0007C1EC File Offset: 0x0007A5EC
		public int EffectDisOverlay
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06001C3A RID: 7226 RVA: 0x0007C238 File Offset: 0x0007A638
		public int TriggerInterval
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x0007C284 File Offset: 0x0007A684
		public int StateChangeArray(int j)
		{
			int num = this.__p.__offset(68);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06001C3C RID: 7228 RVA: 0x0007C2D4 File Offset: 0x0007A6D4
		public int StateChangeLength
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x0007C307 File Offset: 0x0007A707
		public ArraySegment<byte>? GetStateChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001C3E RID: 7230 RVA: 0x0007C316 File Offset: 0x0007A716
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

		// Token: 0x06001C3F RID: 7231 RVA: 0x0007C348 File Offset: 0x0007A748
		public int AbilityChangeArray(int j)
		{
			int num = this.__p.__offset(70);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001C40 RID: 7232 RVA: 0x0007C398 File Offset: 0x0007A798
		public int AbilityChangeLength
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x0007C3CB File Offset: 0x0007A7CB
		public ArraySegment<byte>? GetAbilityChangeBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001C42 RID: 7234 RVA: 0x0007C3DA File Offset: 0x0007A7DA
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

		// Token: 0x06001C43 RID: 7235 RVA: 0x0007C40C File Offset: 0x0007A80C
		public int ElementsArray(int j)
		{
			int num = this.__p.__offset(72);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001C44 RID: 7236 RVA: 0x0007C45C File Offset: 0x0007A85C
		public int ElementsLength
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x0007C48F File Offset: 0x0007A88F
		public ArraySegment<byte>? GetElementsBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06001C46 RID: 7238 RVA: 0x0007C49E File Offset: 0x0007A89E
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

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06001C47 RID: 7239 RVA: 0x0007C4D0 File Offset: 0x0007A8D0
		public UnionCell LightAttack
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001C48 RID: 7240 RVA: 0x0007C528 File Offset: 0x0007A928
		public UnionCell FireAttack
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001C49 RID: 7241 RVA: 0x0007C580 File Offset: 0x0007A980
		public UnionCell IceAttack
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001C4A RID: 7242 RVA: 0x0007C5D8 File Offset: 0x0007A9D8
		public UnionCell DarkAttack
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001C4B RID: 7243 RVA: 0x0007C630 File Offset: 0x0007AA30
		public UnionCell LightDefence
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001C4C RID: 7244 RVA: 0x0007C688 File Offset: 0x0007AA88
		public UnionCell FireDefence
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001C4D RID: 7245 RVA: 0x0007C6E0 File Offset: 0x0007AAE0
		public UnionCell IceDefence
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001C4E RID: 7246 RVA: 0x0007C738 File Offset: 0x0007AB38
		public UnionCell DarkDefence
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x0007C790 File Offset: 0x0007AB90
		public int UseSkillIDsArray(int j)
		{
			int num = this.__p.__offset(90);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001C50 RID: 7248 RVA: 0x0007C7E0 File Offset: 0x0007ABE0
		public int UseSkillIDsLength
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C51 RID: 7249 RVA: 0x0007C813 File Offset: 0x0007AC13
		public ArraySegment<byte>? GetUseSkillIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001C52 RID: 7250 RVA: 0x0007C822 File Offset: 0x0007AC22
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

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001C53 RID: 7251 RVA: 0x0007C854 File Offset: 0x0007AC54
		public int DispelBuffType
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001C54 RID: 7252 RVA: 0x0007C8A0 File Offset: 0x0007ACA0
		public int TriggerBuffInfoIDsArray(int j)
		{
			int num = this.__p.__offset(94);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001C55 RID: 7253 RVA: 0x0007C8F0 File Offset: 0x0007ACF0
		public int TriggerBuffInfoIDsLength
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C56 RID: 7254 RVA: 0x0007C923 File Offset: 0x0007AD23
		public ArraySegment<byte>? GetTriggerBuffInfoIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(94);
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001C57 RID: 7255 RVA: 0x0007C932 File Offset: 0x0007AD32
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

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06001C58 RID: 7256 RVA: 0x0007C964 File Offset: 0x0007AD64
		public int ExitRemoveTrigger
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001C59 RID: 7257 RVA: 0x0007C9B0 File Offset: 0x0007ADB0
		public int MechanismIDArray(int j)
		{
			int num = this.__p.__offset(98);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06001C5A RID: 7258 RVA: 0x0007CA00 File Offset: 0x0007AE00
		public int MechanismIDLength
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001C5B RID: 7259 RVA: 0x0007CA33 File Offset: 0x0007AE33
		public ArraySegment<byte>? GetMechanismIDBytes()
		{
			return this.__p.__vector_as_arraysegment(98);
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06001C5C RID: 7260 RVA: 0x0007CA42 File Offset: 0x0007AE42
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

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001C5D RID: 7261 RVA: 0x0007CA74 File Offset: 0x0007AE74
		public UnionCell hp
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001C5E RID: 7262 RVA: 0x0007CACC File Offset: 0x0007AECC
		public UnionCell mp
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001C5F RID: 7263 RVA: 0x0007CB24 File Offset: 0x0007AF24
		public UnionCell hpRate
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06001C60 RID: 7264 RVA: 0x0007CB7C File Offset: 0x0007AF7C
		public UnionCell mpRate
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06001C61 RID: 7265 RVA: 0x0007CBD4 File Offset: 0x0007AFD4
		public UnionCell currentHpRate
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06001C62 RID: 7266 RVA: 0x0007CC2C File Offset: 0x0007B02C
		public int currentHpRateControl
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06001C63 RID: 7267 RVA: 0x0007CC78 File Offset: 0x0007B078
		public UnionCell baseAtk
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06001C64 RID: 7268 RVA: 0x0007CCD0 File Offset: 0x0007B0D0
		public UnionCell baseInt
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06001C65 RID: 7269 RVA: 0x0007CD28 File Offset: 0x0007B128
		public UnionCell sta
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06001C66 RID: 7270 RVA: 0x0007CD80 File Offset: 0x0007B180
		public UnionCell spr
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06001C67 RID: 7271 RVA: 0x0007CDD8 File Offset: 0x0007B1D8
		public UnionCell baseIndependent
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06001C68 RID: 7272 RVA: 0x0007CE30 File Offset: 0x0007B230
		public UnionCell atkAddRate
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06001C69 RID: 7273 RVA: 0x0007CE88 File Offset: 0x0007B288
		public UnionCell intAddRate
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06001C6A RID: 7274 RVA: 0x0007CEE0 File Offset: 0x0007B2E0
		public UnionCell staAddRate
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06001C6B RID: 7275 RVA: 0x0007CF38 File Offset: 0x0007B338
		public UnionCell sprAddRate
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06001C6C RID: 7276 RVA: 0x0007CF94 File Offset: 0x0007B394
		public UnionCell independentAddRate
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06001C6D RID: 7277 RVA: 0x0007CFF0 File Offset: 0x0007B3F0
		public UnionCell maxHp
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x0007D04C File Offset: 0x0007B44C
		public UnionCell maxMp
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06001C6F RID: 7279 RVA: 0x0007D0A8 File Offset: 0x0007B4A8
		public UnionCell maxHpAddRate
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x0007D104 File Offset: 0x0007B504
		public UnionCell maxMpAddRate
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06001C71 RID: 7281 RVA: 0x0007D160 File Offset: 0x0007B560
		public UnionCell hpRecover
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06001C72 RID: 7282 RVA: 0x0007D1BC File Offset: 0x0007B5BC
		public UnionCell mpRecover
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06001C73 RID: 7283 RVA: 0x0007D218 File Offset: 0x0007B618
		public UnionCell attack
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06001C74 RID: 7284 RVA: 0x0007D274 File Offset: 0x0007B674
		public UnionCell magicAttack
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06001C75 RID: 7285 RVA: 0x0007D2D0 File Offset: 0x0007B6D0
		public UnionCell defence
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06001C76 RID: 7286 RVA: 0x0007D32C File Offset: 0x0007B72C
		public UnionCell magicDefence
		{
			get
			{
				int num = this.__p.__offset(150);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06001C77 RID: 7287 RVA: 0x0007D388 File Offset: 0x0007B788
		public UnionCell attackSpeed
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06001C78 RID: 7288 RVA: 0x0007D3E4 File Offset: 0x0007B7E4
		public UnionCell spellSpeed
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06001C79 RID: 7289 RVA: 0x0007D440 File Offset: 0x0007B840
		public UnionCell moveSpeed
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06001C7A RID: 7290 RVA: 0x0007D49C File Offset: 0x0007B89C
		public UnionCell ciriticalAttack
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06001C7B RID: 7291 RVA: 0x0007D4F8 File Offset: 0x0007B8F8
		public UnionCell ciriticalMagicAttack
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06001C7C RID: 7292 RVA: 0x0007D554 File Offset: 0x0007B954
		public UnionCell dex
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06001C7D RID: 7293 RVA: 0x0007D5B0 File Offset: 0x0007B9B0
		public UnionCell dodge
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06001C7E RID: 7294 RVA: 0x0007D60C File Offset: 0x0007BA0C
		public UnionCell frozen
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06001C7F RID: 7295 RVA: 0x0007D668 File Offset: 0x0007BA68
		public UnionCell hard
		{
			get
			{
				int num = this.__p.__offset(168);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06001C80 RID: 7296 RVA: 0x0007D6C4 File Offset: 0x0007BAC4
		public UnionCell abnormalResist
		{
			get
			{
				int num = this.__p.__offset(170);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06001C81 RID: 7297 RVA: 0x0007D720 File Offset: 0x0007BB20
		public UnionCell abnormalResist1
		{
			get
			{
				int num = this.__p.__offset(172);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06001C82 RID: 7298 RVA: 0x0007D77C File Offset: 0x0007BB7C
		public UnionCell abnormalResist2
		{
			get
			{
				int num = this.__p.__offset(174);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06001C83 RID: 7299 RVA: 0x0007D7D8 File Offset: 0x0007BBD8
		public UnionCell abnormalResist3
		{
			get
			{
				int num = this.__p.__offset(176);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06001C84 RID: 7300 RVA: 0x0007D834 File Offset: 0x0007BC34
		public UnionCell abnormalResist4
		{
			get
			{
				int num = this.__p.__offset(178);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06001C85 RID: 7301 RVA: 0x0007D890 File Offset: 0x0007BC90
		public UnionCell abnormalResist5
		{
			get
			{
				int num = this.__p.__offset(180);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06001C86 RID: 7302 RVA: 0x0007D8EC File Offset: 0x0007BCEC
		public UnionCell abnormalResist6
		{
			get
			{
				int num = this.__p.__offset(182);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06001C87 RID: 7303 RVA: 0x0007D948 File Offset: 0x0007BD48
		public UnionCell abnormalResist7
		{
			get
			{
				int num = this.__p.__offset(184);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06001C88 RID: 7304 RVA: 0x0007D9A4 File Offset: 0x0007BDA4
		public UnionCell abnormalResist8
		{
			get
			{
				int num = this.__p.__offset(186);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06001C89 RID: 7305 RVA: 0x0007DA00 File Offset: 0x0007BE00
		public UnionCell abnormalResist9
		{
			get
			{
				int num = this.__p.__offset(188);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06001C8A RID: 7306 RVA: 0x0007DA5C File Offset: 0x0007BE5C
		public UnionCell abnormalResist10
		{
			get
			{
				int num = this.__p.__offset(190);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06001C8B RID: 7307 RVA: 0x0007DAB8 File Offset: 0x0007BEB8
		public UnionCell abnormalResist11
		{
			get
			{
				int num = this.__p.__offset(192);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06001C8C RID: 7308 RVA: 0x0007DB14 File Offset: 0x0007BF14
		public UnionCell abnormalResist12
		{
			get
			{
				int num = this.__p.__offset(194);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06001C8D RID: 7309 RVA: 0x0007DB70 File Offset: 0x0007BF70
		public UnionCell abnormalResist13
		{
			get
			{
				int num = this.__p.__offset(196);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06001C8E RID: 7310 RVA: 0x0007DBCC File Offset: 0x0007BFCC
		public UnionCell criticalPercent
		{
			get
			{
				int num = this.__p.__offset(198);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06001C8F RID: 7311 RVA: 0x0007DC28 File Offset: 0x0007C028
		public UnionCell cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(200);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06001C90 RID: 7312 RVA: 0x0007DC84 File Offset: 0x0007C084
		public UnionCell attackAddRate
		{
			get
			{
				int num = this.__p.__offset(202);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06001C91 RID: 7313 RVA: 0x0007DCE0 File Offset: 0x0007C0E0
		public UnionCell magicAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(204);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06001C92 RID: 7314 RVA: 0x0007DD3C File Offset: 0x0007C13C
		public UnionCell defenceAddRate
		{
			get
			{
				int num = this.__p.__offset(206);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06001C93 RID: 7315 RVA: 0x0007DD98 File Offset: 0x0007C198
		public UnionCell magicDefenceAddRate
		{
			get
			{
				int num = this.__p.__offset(208);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06001C94 RID: 7316 RVA: 0x0007DDF4 File Offset: 0x0007C1F4
		public UnionCell ingnoreDefRate
		{
			get
			{
				int num = this.__p.__offset(210);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06001C95 RID: 7317 RVA: 0x0007DE50 File Offset: 0x0007C250
		public UnionCell ingnoreMagicDefRate
		{
			get
			{
				int num = this.__p.__offset(212);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06001C96 RID: 7318 RVA: 0x0007DEAC File Offset: 0x0007C2AC
		public UnionCell ignoreDefAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(214);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06001C97 RID: 7319 RVA: 0x0007DF08 File Offset: 0x0007C308
		public UnionCell ignoreDefMagicAttackAddRate
		{
			get
			{
				int num = this.__p.__offset(216);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001C98 RID: 7320 RVA: 0x0007DF64 File Offset: 0x0007C364
		public UnionCell attachAddDamageFix
		{
			get
			{
				int num = this.__p.__offset(218);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06001C99 RID: 7321 RVA: 0x0007DFC0 File Offset: 0x0007C3C0
		public UnionCell attachAddDamagePercent
		{
			get
			{
				int num = this.__p.__offset(220);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06001C9A RID: 7322 RVA: 0x0007E01C File Offset: 0x0007C41C
		public UnionCell addDamageFix
		{
			get
			{
				int num = this.__p.__offset(222);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06001C9B RID: 7323 RVA: 0x0007E078 File Offset: 0x0007C478
		public UnionCell addDamagePercent
		{
			get
			{
				int num = this.__p.__offset(224);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06001C9C RID: 7324 RVA: 0x0007E0D4 File Offset: 0x0007C4D4
		public UnionCell skilladdDamagePercent
		{
			get
			{
				int num = this.__p.__offset(226);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06001C9D RID: 7325 RVA: 0x0007E130 File Offset: 0x0007C530
		public UnionCell skilladdMagicDamagePercent
		{
			get
			{
				int num = this.__p.__offset(228);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06001C9E RID: 7326 RVA: 0x0007E18C File Offset: 0x0007C58C
		public UnionCell reduceDamageFix
		{
			get
			{
				int num = this.__p.__offset(230);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06001C9F RID: 7327 RVA: 0x0007E1E8 File Offset: 0x0007C5E8
		public int reduceDamageFixType
		{
			get
			{
				int num = this.__p.__offset(232);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06001CA0 RID: 7328 RVA: 0x0007E238 File Offset: 0x0007C638
		public UnionCell reduceDamagePercent
		{
			get
			{
				int num = this.__p.__offset(234);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06001CA1 RID: 7329 RVA: 0x0007E294 File Offset: 0x0007C694
		public int reduceDamagePercentType
		{
			get
			{
				int num = this.__p.__offset(236);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06001CA2 RID: 7330 RVA: 0x0007E2E4 File Offset: 0x0007C6E4
		public UnionCell extrareduceDamgePercent
		{
			get
			{
				int num = this.__p.__offset(238);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06001CA3 RID: 7331 RVA: 0x0007E340 File Offset: 0x0007C740
		public int extrareduceDamagePercentType
		{
			get
			{
				int num = this.__p.__offset(240);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06001CA4 RID: 7332 RVA: 0x0007E390 File Offset: 0x0007C790
		public UnionCell reflectDamageFix
		{
			get
			{
				int num = this.__p.__offset(242);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06001CA5 RID: 7333 RVA: 0x0007E3EC File Offset: 0x0007C7EC
		public int reflectDamageFixType
		{
			get
			{
				int num = this.__p.__offset(244);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06001CA6 RID: 7334 RVA: 0x0007E43C File Offset: 0x0007C83C
		public UnionCell reflectDamagePercent
		{
			get
			{
				int num = this.__p.__offset(246);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06001CA7 RID: 7335 RVA: 0x0007E498 File Offset: 0x0007C898
		public int reflectDamagePercentType
		{
			get
			{
				int num = this.__p.__offset(248);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06001CA8 RID: 7336 RVA: 0x0007E4E8 File Offset: 0x0007C8E8
		public UnionCell level
		{
			get
			{
				int num = this.__p.__offset(250);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06001CA9 RID: 7337 RVA: 0x0007E544 File Offset: 0x0007C944
		public UnionCell skill_mpCostReduceRate
		{
			get
			{
				int num = this.__p.__offset(252);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06001CAA RID: 7338 RVA: 0x0007E5A0 File Offset: 0x0007C9A0
		public UnionCell skill_cdReduceRate
		{
			get
			{
				int num = this.__p.__offset(254);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06001CAB RID: 7339 RVA: 0x0007E5FC File Offset: 0x0007C9FC
		public UnionCell skill_cdReduceValue
		{
			get
			{
				int num = this.__p.__offset(256);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06001CAC RID: 7340 RVA: 0x0007E658 File Offset: 0x0007CA58
		public UnionCell skill_speedAddFactor
		{
			get
			{
				int num = this.__p.__offset(258);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06001CAD RID: 7341 RVA: 0x0007E6B4 File Offset: 0x0007CAB4
		public UnionCell skill_hitRateAdd
		{
			get
			{
				int num = this.__p.__offset(260);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06001CAE RID: 7342 RVA: 0x0007E710 File Offset: 0x0007CB10
		public UnionCell skill_criticalHitRateAdd
		{
			get
			{
				int num = this.__p.__offset(262);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06001CAF RID: 7343 RVA: 0x0007E76C File Offset: 0x0007CB6C
		public UnionCell skill_attackAddRate
		{
			get
			{
				int num = this.__p.__offset(264);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06001CB0 RID: 7344 RVA: 0x0007E7C8 File Offset: 0x0007CBC8
		public UnionCell skill_attackAdd
		{
			get
			{
				int num = this.__p.__offset(266);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06001CB1 RID: 7345 RVA: 0x0007E824 File Offset: 0x0007CC24
		public UnionCell skill_attackAddFix
		{
			get
			{
				int num = this.__p.__offset(268);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06001CB2 RID: 7346 RVA: 0x0007E880 File Offset: 0x0007CC80
		public UnionCell skill_hardAddRate
		{
			get
			{
				int num = this.__p.__offset(270);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06001CB3 RID: 7347 RVA: 0x0007E8DC File Offset: 0x0007CCDC
		public UnionCell skill_chargeReduceRate
		{
			get
			{
				int num = this.__p.__offset(272);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06001CB4 RID: 7348 RVA: 0x0007E938 File Offset: 0x0007CD38
		public UnionCell ResistMagic
		{
			get
			{
				int num = this.__p.__offset(274);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001CB5 RID: 7349 RVA: 0x0007E994 File Offset: 0x0007CD94
		public UnionCell ai_warlike
		{
			get
			{
				int num = this.__p.__offset(276);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06001CB6 RID: 7350 RVA: 0x0007E9F0 File Offset: 0x0007CDF0
		public UnionCell ai_sight
		{
			get
			{
				int num = this.__p.__offset(278);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001CB7 RID: 7351 RVA: 0x0007EA4C File Offset: 0x0007CE4C
		public UnionCell ai_attackProb
		{
			get
			{
				int num = this.__p.__offset(280);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06001CB8 RID: 7352 RVA: 0x0007EAA8 File Offset: 0x0007CEA8
		public int summon_monsterID
		{
			get
			{
				int num = this.__p.__offset(282);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001CB9 RID: 7353 RVA: 0x0007EAF8 File Offset: 0x0007CEF8
		public UnionCell summon_monsterLevel
		{
			get
			{
				int num = this.__p.__offset(284);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06001CBA RID: 7354 RVA: 0x0007EB54 File Offset: 0x0007CF54
		public int summon_existTime
		{
			get
			{
				int num = this.__p.__offset(286);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06001CBB RID: 7355 RVA: 0x0007EBA4 File Offset: 0x0007CFA4
		public int summon_posType
		{
			get
			{
				int num = this.__p.__offset(288);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001CBC RID: 7356 RVA: 0x0007EBF4 File Offset: 0x0007CFF4
		public int summon_posType2Array(int j)
		{
			int num = this.__p.__offset(290);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001CBD RID: 7357 RVA: 0x0007EC44 File Offset: 0x0007D044
		public int summon_posType2Length
		{
			get
			{
				int num = this.__p.__offset(290);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001CBE RID: 7358 RVA: 0x0007EC7A File Offset: 0x0007D07A
		public ArraySegment<byte>? GetSummonPosType2Bytes()
		{
			return this.__p.__vector_as_arraysegment(290);
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06001CBF RID: 7359 RVA: 0x0007EC8C File Offset: 0x0007D08C
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

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001CC0 RID: 7360 RVA: 0x0007ECBC File Offset: 0x0007D0BC
		public int summon_display
		{
			get
			{
				int num = this.__p.__offset(292);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06001CC1 RID: 7361 RVA: 0x0007ED0C File Offset: 0x0007D10C
		public int summon_num
		{
			get
			{
				int num = this.__p.__offset(294);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001CC2 RID: 7362 RVA: 0x0007ED5C File Offset: 0x0007D15C
		public int summon_relation
		{
			get
			{
				int num = this.__p.__offset(296);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001CC3 RID: 7363 RVA: 0x0007EDAC File Offset: 0x0007D1AC
		public int summon_numLimit
		{
			get
			{
				int num = this.__p.__offset(298);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x0007EDFC File Offset: 0x0007D1FC
		public int summon_entityArray(int j)
		{
			int num = this.__p.__offset(300);
			return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06001CC5 RID: 7365 RVA: 0x0007EE4C File Offset: 0x0007D24C
		public int summon_entityLength
		{
			get
			{
				int num = this.__p.__offset(300);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x0007EE82 File Offset: 0x0007D282
		public ArraySegment<byte>? GetSummonEntityBytes()
		{
			return this.__p.__vector_as_arraysegment(300);
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06001CC7 RID: 7367 RVA: 0x0007EE94 File Offset: 0x0007D294
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

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06001CC8 RID: 7368 RVA: 0x0007EEC4 File Offset: 0x0007D2C4
		public int duplicate_percent
		{
			get
			{
				int num = this.__p.__offset(302);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06001CC9 RID: 7369 RVA: 0x0007EF14 File Offset: 0x0007D314
		public int duplicate_max
		{
			get
			{
				int num = this.__p.__offset(304);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06001CCA RID: 7370 RVA: 0x0007EF64 File Offset: 0x0007D364
		public UnionCell expAddRate
		{
			get
			{
				int num = this.__p.__offset(306);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06001CCB RID: 7371 RVA: 0x0007EFC0 File Offset: 0x0007D3C0
		public UnionCell goldAddRate
		{
			get
			{
				int num = this.__p.__offset(308);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06001CCC RID: 7372 RVA: 0x0007F01C File Offset: 0x0007D41C
		public int taskDropAddRate
		{
			get
			{
				int num = this.__p.__offset(310);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06001CCD RID: 7373 RVA: 0x0007F06C File Offset: 0x0007D46C
		public int PinkDropAddRate
		{
			get
			{
				int num = this.__p.__offset(312);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06001CCE RID: 7374 RVA: 0x0007F0BC File Offset: 0x0007D4BC
		public int ChestDropAddRate
		{
			get
			{
				int num = this.__p.__offset(314);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06001CCF RID: 7375 RVA: 0x0007F10C File Offset: 0x0007D50C
		public int durationType
		{
			get
			{
				int num = this.__p.__offset(316);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06001CD0 RID: 7376 RVA: 0x0007F15C File Offset: 0x0007D55C
		public int duration
		{
			get
			{
				int num = this.__p.__offset(318);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06001CD1 RID: 7377 RVA: 0x0007F1AC File Offset: 0x0007D5AC
		public string DescriptionA
		{
			get
			{
				int num = this.__p.__offset(320);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CD2 RID: 7378 RVA: 0x0007F1F2 File Offset: 0x0007D5F2
		public ArraySegment<byte>? GetDescriptionABytes()
		{
			return this.__p.__vector_as_arraysegment(320);
		}

		// Token: 0x06001CD3 RID: 7379 RVA: 0x0007F204 File Offset: 0x0007D604
		public UnionCell ValueAArray(int j)
		{
			int num = this.__p.__offset(322);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001CD4 RID: 7380 RVA: 0x0007F264 File Offset: 0x0007D664
		public int ValueALength
		{
			get
			{
				int num = this.__p.__offset(322);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001CD5 RID: 7381 RVA: 0x0007F29A File Offset: 0x0007D69A
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

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06001CD6 RID: 7382 RVA: 0x0007F2CC File Offset: 0x0007D6CC
		public string DescriptionB
		{
			get
			{
				int num = this.__p.__offset(324);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CD7 RID: 7383 RVA: 0x0007F312 File Offset: 0x0007D712
		public ArraySegment<byte>? GetDescriptionBBytes()
		{
			return this.__p.__vector_as_arraysegment(324);
		}

		// Token: 0x06001CD8 RID: 7384 RVA: 0x0007F324 File Offset: 0x0007D724
		public UnionCell ValueBArray(int j)
		{
			int num = this.__p.__offset(326);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06001CD9 RID: 7385 RVA: 0x0007F384 File Offset: 0x0007D784
		public int ValueBLength
		{
			get
			{
				int num = this.__p.__offset(326);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06001CDA RID: 7386 RVA: 0x0007F3BA File Offset: 0x0007D7BA
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

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06001CDB RID: 7387 RVA: 0x0007F3EC File Offset: 0x0007D7EC
		public string DescriptionC
		{
			get
			{
				int num = this.__p.__offset(328);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CDC RID: 7388 RVA: 0x0007F432 File Offset: 0x0007D832
		public ArraySegment<byte>? GetDescriptionCBytes()
		{
			return this.__p.__vector_as_arraysegment(328);
		}

		// Token: 0x06001CDD RID: 7389 RVA: 0x0007F444 File Offset: 0x0007D844
		public UnionCell ValueCArray(int j)
		{
			int num = this.__p.__offset(330);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06001CDE RID: 7390 RVA: 0x0007F4A4 File Offset: 0x0007D8A4
		public int ValueCLength
		{
			get
			{
				int num = this.__p.__offset(330);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06001CDF RID: 7391 RVA: 0x0007F4DA File Offset: 0x0007D8DA
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

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06001CE0 RID: 7392 RVA: 0x0007F50C File Offset: 0x0007D90C
		public string DescriptionD
		{
			get
			{
				int num = this.__p.__offset(332);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CE1 RID: 7393 RVA: 0x0007F552 File Offset: 0x0007D952
		public ArraySegment<byte>? GetDescriptionDBytes()
		{
			return this.__p.__vector_as_arraysegment(332);
		}

		// Token: 0x06001CE2 RID: 7394 RVA: 0x0007F564 File Offset: 0x0007D964
		public UnionCell ValueDArray(int j)
		{
			int num = this.__p.__offset(334);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06001CE3 RID: 7395 RVA: 0x0007F5C4 File Offset: 0x0007D9C4
		public int ValueDLength
		{
			get
			{
				int num = this.__p.__offset(334);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06001CE4 RID: 7396 RVA: 0x0007F5FA File Offset: 0x0007D9FA
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

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06001CE5 RID: 7397 RVA: 0x0007F62C File Offset: 0x0007DA2C
		public string DescriptionE
		{
			get
			{
				int num = this.__p.__offset(336);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x0007F672 File Offset: 0x0007DA72
		public ArraySegment<byte>? GetDescriptionEBytes()
		{
			return this.__p.__vector_as_arraysegment(336);
		}

		// Token: 0x06001CE7 RID: 7399 RVA: 0x0007F684 File Offset: 0x0007DA84
		public UnionCell ValueEArray(int j)
		{
			int num = this.__p.__offset(338);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06001CE8 RID: 7400 RVA: 0x0007F6E4 File Offset: 0x0007DAE4
		public int ValueELength
		{
			get
			{
				int num = this.__p.__offset(338);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06001CE9 RID: 7401 RVA: 0x0007F71A File Offset: 0x0007DB1A
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

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06001CEA RID: 7402 RVA: 0x0007F74C File Offset: 0x0007DB4C
		public string DescriptionF
		{
			get
			{
				int num = this.__p.__offset(340);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x0007F792 File Offset: 0x0007DB92
		public ArraySegment<byte>? GetDescriptionFBytes()
		{
			return this.__p.__vector_as_arraysegment(340);
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x0007F7A4 File Offset: 0x0007DBA4
		public UnionCell ValueFArray(int j)
		{
			int num = this.__p.__offset(342);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06001CED RID: 7405 RVA: 0x0007F804 File Offset: 0x0007DC04
		public int ValueFLength
		{
			get
			{
				int num = this.__p.__offset(342);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06001CEE RID: 7406 RVA: 0x0007F83A File Offset: 0x0007DC3A
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

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001CEF RID: 7407 RVA: 0x0007F86C File Offset: 0x0007DC6C
		public string DescriptionG
		{
			get
			{
				int num = this.__p.__offset(344);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CF0 RID: 7408 RVA: 0x0007F8B2 File Offset: 0x0007DCB2
		public ArraySegment<byte>? GetDescriptionGBytes()
		{
			return this.__p.__vector_as_arraysegment(344);
		}

		// Token: 0x06001CF1 RID: 7409 RVA: 0x0007F8C4 File Offset: 0x0007DCC4
		public UnionCell ValueGArray(int j)
		{
			int num = this.__p.__offset(346);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06001CF2 RID: 7410 RVA: 0x0007F924 File Offset: 0x0007DD24
		public int ValueGLength
		{
			get
			{
				int num = this.__p.__offset(346);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06001CF3 RID: 7411 RVA: 0x0007F95A File Offset: 0x0007DD5A
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

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06001CF4 RID: 7412 RVA: 0x0007F98C File Offset: 0x0007DD8C
		public int EffectTimes
		{
			get
			{
				int num = this.__p.__offset(348);
				return (num == 0) ? 0 : (136068113 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06001CF5 RID: 7413 RVA: 0x0007F9DC File Offset: 0x0007DDDC
		public string ApplyDungeon
		{
			get
			{
				int num = this.__p.__offset(350);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CF6 RID: 7414 RVA: 0x0007FA22 File Offset: 0x0007DE22
		public ArraySegment<byte>? GetApplyDungeonBytes()
		{
			return this.__p.__vector_as_arraysegment(350);
		}

		// Token: 0x06001CF7 RID: 7415 RVA: 0x0007FA34 File Offset: 0x0007DE34
		public BuffTable.eBuffType BuffTypeArray(int j)
		{
			int num = this.__p.__offset(352);
			return (BuffTable.eBuffType)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06001CF8 RID: 7416 RVA: 0x0007FA80 File Offset: 0x0007DE80
		public int BuffTypeLength
		{
			get
			{
				int num = this.__p.__offset(352);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001CF9 RID: 7417 RVA: 0x0007FAB6 File Offset: 0x0007DEB6
		public ArraySegment<byte>? GetBuffTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(352);
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06001CFA RID: 7418 RVA: 0x0007FAC8 File Offset: 0x0007DEC8
		public FlatBufferArray<BuffTable.eBuffType> BuffType
		{
			get
			{
				if (this.BuffTypeValue == null)
				{
					this.BuffTypeValue = new FlatBufferArray<BuffTable.eBuffType>(new Func<int, BuffTable.eBuffType>(this.BuffTypeArray), this.BuffTypeLength);
				}
				return this.BuffTypeValue;
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06001CFB RID: 7419 RVA: 0x0007FAF8 File Offset: 0x0007DEF8
		public string BuffDisName
		{
			get
			{
				int num = this.__p.__offset(354);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001CFC RID: 7420 RVA: 0x0007FB3E File Offset: 0x0007DF3E
		public ArraySegment<byte>? GetBuffDisNameBytes()
		{
			return this.__p.__vector_as_arraysegment(354);
		}

		// Token: 0x06001CFD RID: 7421 RVA: 0x0007FB50 File Offset: 0x0007DF50
		public static void StartBuffTable(FlatBufferBuilder builder)
		{
			builder.StartObject(176);
		}

		// Token: 0x06001CFE RID: 7422 RVA: 0x0007FB5D File Offset: 0x0007DF5D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001CFF RID: 7423 RVA: 0x0007FB68 File Offset: 0x0007DF68
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001D00 RID: 7424 RVA: 0x0007FB79 File Offset: 0x0007DF79
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(2, DescriptionOffset.Value, 0);
		}

		// Token: 0x06001D01 RID: 7425 RVA: 0x0007FB8A File Offset: 0x0007DF8A
		public static void AddIconSortOrder(FlatBufferBuilder builder, int IconSortOrder)
		{
			builder.AddInt(3, IconSortOrder, 0);
		}

		// Token: 0x06001D02 RID: 7426 RVA: 0x0007FB95 File Offset: 0x0007DF95
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(4, IconOffset.Value, 0);
		}

		// Token: 0x06001D03 RID: 7427 RVA: 0x0007FBA6 File Offset: 0x0007DFA6
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(5, Type, 0);
		}

		// Token: 0x06001D04 RID: 7428 RVA: 0x0007FBB1 File Offset: 0x0007DFB1
		public static void AddIsDelete(FlatBufferBuilder builder, int IsDelete)
		{
			builder.AddInt(6, IsDelete, 0);
		}

		// Token: 0x06001D05 RID: 7429 RVA: 0x0007FBBC File Offset: 0x0007DFBC
		public static void AddWorkType(FlatBufferBuilder builder, int WorkType)
		{
			builder.AddInt(7, WorkType, 0);
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x0007FBC7 File Offset: 0x0007DFC7
		public static void AddDispelType(FlatBufferBuilder builder, int DispelType)
		{
			builder.AddInt(8, DispelType, 0);
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x0007FBD2 File Offset: 0x0007DFD2
		public static void AddIsQuickPressSupport(FlatBufferBuilder builder, int IsQuickPressSupport)
		{
			builder.AddInt(9, IsQuickPressSupport, 0);
		}

		// Token: 0x06001D08 RID: 7432 RVA: 0x0007FBDE File Offset: 0x0007DFDE
		public static void AddEffectShaderName(FlatBufferBuilder builder, StringOffset EffectShaderNameOffset)
		{
			builder.AddOffset(10, EffectShaderNameOffset.Value, 0);
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x0007FBF0 File Offset: 0x0007DFF0
		public static void AddHeadName(FlatBufferBuilder builder, StringOffset HeadNameOffset)
		{
			builder.AddOffset(11, HeadNameOffset.Value, 0);
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x0007FC02 File Offset: 0x0007E002
		public static void AddHpBarName(FlatBufferBuilder builder, StringOffset HpBarNameOffset)
		{
			builder.AddOffset(12, HpBarNameOffset.Value, 0);
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x0007FC14 File Offset: 0x0007E014
		public static void AddIsShowSpell(FlatBufferBuilder builder, bool IsShowSpell)
		{
			builder.AddBool(13, IsShowSpell, false);
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x0007FC20 File Offset: 0x0007E020
		public static void AddIsLowLevelShow(FlatBufferBuilder builder, bool IsLowLevelShow)
		{
			builder.AddBool(14, IsLowLevelShow, false);
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x0007FC2C File Offset: 0x0007E02C
		public static void AddBirthEffect(FlatBufferBuilder builder, StringOffset BirthEffectOffset)
		{
			builder.AddOffset(15, BirthEffectOffset.Value, 0);
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x0007FC3E File Offset: 0x0007E03E
		public static void AddBirthEffectLocate(FlatBufferBuilder builder, StringOffset BirthEffectLocateOffset)
		{
			builder.AddOffset(16, BirthEffectLocateOffset.Value, 0);
		}

		// Token: 0x06001D0F RID: 7439 RVA: 0x0007FC50 File Offset: 0x0007E050
		public static void AddEffectName(FlatBufferBuilder builder, StringOffset EffectNameOffset)
		{
			builder.AddOffset(17, EffectNameOffset.Value, 0);
		}

		// Token: 0x06001D10 RID: 7440 RVA: 0x0007FC62 File Offset: 0x0007E062
		public static void AddEffectLocateName(FlatBufferBuilder builder, StringOffset EffectLocateNameOffset)
		{
			builder.AddOffset(18, EffectLocateNameOffset.Value, 0);
		}

		// Token: 0x06001D11 RID: 7441 RVA: 0x0007FC74 File Offset: 0x0007E074
		public static void AddEffectLoop(FlatBufferBuilder builder, bool EffectLoop)
		{
			builder.AddBool(19, EffectLoop, false);
		}

		// Token: 0x06001D12 RID: 7442 RVA: 0x0007FC80 File Offset: 0x0007E080
		public static void AddEndEffect(FlatBufferBuilder builder, StringOffset EndEffectOffset)
		{
			builder.AddOffset(20, EndEffectOffset.Value, 0);
		}

		// Token: 0x06001D13 RID: 7443 RVA: 0x0007FC92 File Offset: 0x0007E092
		public static void AddEndEffectLocate(FlatBufferBuilder builder, StringOffset EndEffectLocateOffset)
		{
			builder.AddOffset(21, EndEffectLocateOffset.Value, 0);
		}

		// Token: 0x06001D14 RID: 7444 RVA: 0x0007FCA4 File Offset: 0x0007E0A4
		public static void AddEffectConfigPath(FlatBufferBuilder builder, StringOffset EffectConfigPathOffset)
		{
			builder.AddOffset(22, EffectConfigPathOffset.Value, 0);
		}

		// Token: 0x06001D15 RID: 7445 RVA: 0x0007FCB6 File Offset: 0x0007E0B6
		public static void AddHurtEffectName(FlatBufferBuilder builder, StringOffset HurtEffectNameOffset)
		{
			builder.AddOffset(23, HurtEffectNameOffset.Value, 0);
		}

		// Token: 0x06001D16 RID: 7446 RVA: 0x0007FCC8 File Offset: 0x0007E0C8
		public static void AddHurtEffectLocateName(FlatBufferBuilder builder, StringOffset HurtEffectLocateNameOffset)
		{
			builder.AddOffset(24, HurtEffectLocateNameOffset.Value, 0);
		}

		// Token: 0x06001D17 RID: 7447 RVA: 0x0007FCDA File Offset: 0x0007E0DA
		public static void AddSfxID(FlatBufferBuilder builder, int SfxID)
		{
			builder.AddInt(25, SfxID, 0);
		}

		// Token: 0x06001D18 RID: 7448 RVA: 0x0007FCE6 File Offset: 0x0007E0E6
		public static void AddBuffAIPath(FlatBufferBuilder builder, StringOffset BuffAIPathOffset)
		{
			builder.AddOffset(26, BuffAIPathOffset.Value, 0);
		}

		// Token: 0x06001D19 RID: 7449 RVA: 0x0007FCF8 File Offset: 0x0007E0F8
		public static void AddTargetState(FlatBufferBuilder builder, VectorOffset TargetStateOffset)
		{
			builder.AddOffset(27, TargetStateOffset.Value, 0);
		}

		// Token: 0x06001D1A RID: 7450 RVA: 0x0007FD0C File Offset: 0x0007E10C
		public static VectorOffset CreateTargetStateVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D1B RID: 7451 RVA: 0x0007FD49 File Offset: 0x0007E149
		public static void StartTargetStateVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D1C RID: 7452 RVA: 0x0007FD54 File Offset: 0x0007E154
		public static void AddOverlay(FlatBufferBuilder builder, int Overlay)
		{
			builder.AddInt(28, Overlay, 0);
		}

		// Token: 0x06001D1D RID: 7453 RVA: 0x0007FD60 File Offset: 0x0007E160
		public static void AddOverlayLimit(FlatBufferBuilder builder, int OverlayLimit)
		{
			builder.AddInt(29, OverlayLimit, 0);
		}

		// Token: 0x06001D1E RID: 7454 RVA: 0x0007FD6C File Offset: 0x0007E16C
		public static void AddEffectDisOverlay(FlatBufferBuilder builder, int EffectDisOverlay)
		{
			builder.AddInt(30, EffectDisOverlay, 0);
		}

		// Token: 0x06001D1F RID: 7455 RVA: 0x0007FD78 File Offset: 0x0007E178
		public static void AddTriggerInterval(FlatBufferBuilder builder, int TriggerInterval)
		{
			builder.AddInt(31, TriggerInterval, 0);
		}

		// Token: 0x06001D20 RID: 7456 RVA: 0x0007FD84 File Offset: 0x0007E184
		public static void AddStateChange(FlatBufferBuilder builder, VectorOffset StateChangeOffset)
		{
			builder.AddOffset(32, StateChangeOffset.Value, 0);
		}

		// Token: 0x06001D21 RID: 7457 RVA: 0x0007FD98 File Offset: 0x0007E198
		public static VectorOffset CreateStateChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D22 RID: 7458 RVA: 0x0007FDD5 File Offset: 0x0007E1D5
		public static void StartStateChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D23 RID: 7459 RVA: 0x0007FDE0 File Offset: 0x0007E1E0
		public static void AddAbilityChange(FlatBufferBuilder builder, VectorOffset AbilityChangeOffset)
		{
			builder.AddOffset(33, AbilityChangeOffset.Value, 0);
		}

		// Token: 0x06001D24 RID: 7460 RVA: 0x0007FDF4 File Offset: 0x0007E1F4
		public static VectorOffset CreateAbilityChangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D25 RID: 7461 RVA: 0x0007FE31 File Offset: 0x0007E231
		public static void StartAbilityChangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D26 RID: 7462 RVA: 0x0007FE3C File Offset: 0x0007E23C
		public static void AddElements(FlatBufferBuilder builder, VectorOffset ElementsOffset)
		{
			builder.AddOffset(34, ElementsOffset.Value, 0);
		}

		// Token: 0x06001D27 RID: 7463 RVA: 0x0007FE50 File Offset: 0x0007E250
		public static VectorOffset CreateElementsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D28 RID: 7464 RVA: 0x0007FE8D File Offset: 0x0007E28D
		public static void StartElementsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D29 RID: 7465 RVA: 0x0007FE98 File Offset: 0x0007E298
		public static void AddLightAttack(FlatBufferBuilder builder, Offset<UnionCell> LightAttackOffset)
		{
			builder.AddOffset(35, LightAttackOffset.Value, 0);
		}

		// Token: 0x06001D2A RID: 7466 RVA: 0x0007FEAA File Offset: 0x0007E2AA
		public static void AddFireAttack(FlatBufferBuilder builder, Offset<UnionCell> FireAttackOffset)
		{
			builder.AddOffset(36, FireAttackOffset.Value, 0);
		}

		// Token: 0x06001D2B RID: 7467 RVA: 0x0007FEBC File Offset: 0x0007E2BC
		public static void AddIceAttack(FlatBufferBuilder builder, Offset<UnionCell> IceAttackOffset)
		{
			builder.AddOffset(37, IceAttackOffset.Value, 0);
		}

		// Token: 0x06001D2C RID: 7468 RVA: 0x0007FECE File Offset: 0x0007E2CE
		public static void AddDarkAttack(FlatBufferBuilder builder, Offset<UnionCell> DarkAttackOffset)
		{
			builder.AddOffset(38, DarkAttackOffset.Value, 0);
		}

		// Token: 0x06001D2D RID: 7469 RVA: 0x0007FEE0 File Offset: 0x0007E2E0
		public static void AddLightDefence(FlatBufferBuilder builder, Offset<UnionCell> LightDefenceOffset)
		{
			builder.AddOffset(39, LightDefenceOffset.Value, 0);
		}

		// Token: 0x06001D2E RID: 7470 RVA: 0x0007FEF2 File Offset: 0x0007E2F2
		public static void AddFireDefence(FlatBufferBuilder builder, Offset<UnionCell> FireDefenceOffset)
		{
			builder.AddOffset(40, FireDefenceOffset.Value, 0);
		}

		// Token: 0x06001D2F RID: 7471 RVA: 0x0007FF04 File Offset: 0x0007E304
		public static void AddIceDefence(FlatBufferBuilder builder, Offset<UnionCell> IceDefenceOffset)
		{
			builder.AddOffset(41, IceDefenceOffset.Value, 0);
		}

		// Token: 0x06001D30 RID: 7472 RVA: 0x0007FF16 File Offset: 0x0007E316
		public static void AddDarkDefence(FlatBufferBuilder builder, Offset<UnionCell> DarkDefenceOffset)
		{
			builder.AddOffset(42, DarkDefenceOffset.Value, 0);
		}

		// Token: 0x06001D31 RID: 7473 RVA: 0x0007FF28 File Offset: 0x0007E328
		public static void AddUseSkillIDs(FlatBufferBuilder builder, VectorOffset UseSkillIDsOffset)
		{
			builder.AddOffset(43, UseSkillIDsOffset.Value, 0);
		}

		// Token: 0x06001D32 RID: 7474 RVA: 0x0007FF3C File Offset: 0x0007E33C
		public static VectorOffset CreateUseSkillIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D33 RID: 7475 RVA: 0x0007FF79 File Offset: 0x0007E379
		public static void StartUseSkillIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D34 RID: 7476 RVA: 0x0007FF84 File Offset: 0x0007E384
		public static void AddDispelBuffType(FlatBufferBuilder builder, int DispelBuffType)
		{
			builder.AddInt(44, DispelBuffType, 0);
		}

		// Token: 0x06001D35 RID: 7477 RVA: 0x0007FF90 File Offset: 0x0007E390
		public static void AddTriggerBuffInfoIDs(FlatBufferBuilder builder, VectorOffset TriggerBuffInfoIDsOffset)
		{
			builder.AddOffset(45, TriggerBuffInfoIDsOffset.Value, 0);
		}

		// Token: 0x06001D36 RID: 7478 RVA: 0x0007FFA4 File Offset: 0x0007E3A4
		public static VectorOffset CreateTriggerBuffInfoIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D37 RID: 7479 RVA: 0x0007FFE1 File Offset: 0x0007E3E1
		public static void StartTriggerBuffInfoIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D38 RID: 7480 RVA: 0x0007FFEC File Offset: 0x0007E3EC
		public static void AddExitRemoveTrigger(FlatBufferBuilder builder, int ExitRemoveTrigger)
		{
			builder.AddInt(46, ExitRemoveTrigger, 0);
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x0007FFF8 File Offset: 0x0007E3F8
		public static void AddMechanismID(FlatBufferBuilder builder, VectorOffset MechanismIDOffset)
		{
			builder.AddOffset(47, MechanismIDOffset.Value, 0);
		}

		// Token: 0x06001D3A RID: 7482 RVA: 0x0008000C File Offset: 0x0007E40C
		public static VectorOffset CreateMechanismIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D3B RID: 7483 RVA: 0x00080049 File Offset: 0x0007E449
		public static void StartMechanismIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D3C RID: 7484 RVA: 0x00080054 File Offset: 0x0007E454
		public static void AddHp(FlatBufferBuilder builder, Offset<UnionCell> hpOffset)
		{
			builder.AddOffset(48, hpOffset.Value, 0);
		}

		// Token: 0x06001D3D RID: 7485 RVA: 0x00080066 File Offset: 0x0007E466
		public static void AddMp(FlatBufferBuilder builder, Offset<UnionCell> mpOffset)
		{
			builder.AddOffset(49, mpOffset.Value, 0);
		}

		// Token: 0x06001D3E RID: 7486 RVA: 0x00080078 File Offset: 0x0007E478
		public static void AddHpRate(FlatBufferBuilder builder, Offset<UnionCell> hpRateOffset)
		{
			builder.AddOffset(50, hpRateOffset.Value, 0);
		}

		// Token: 0x06001D3F RID: 7487 RVA: 0x0008008A File Offset: 0x0007E48A
		public static void AddMpRate(FlatBufferBuilder builder, Offset<UnionCell> mpRateOffset)
		{
			builder.AddOffset(51, mpRateOffset.Value, 0);
		}

		// Token: 0x06001D40 RID: 7488 RVA: 0x0008009C File Offset: 0x0007E49C
		public static void AddCurrentHpRate(FlatBufferBuilder builder, Offset<UnionCell> currentHpRateOffset)
		{
			builder.AddOffset(52, currentHpRateOffset.Value, 0);
		}

		// Token: 0x06001D41 RID: 7489 RVA: 0x000800AE File Offset: 0x0007E4AE
		public static void AddCurrentHpRateControl(FlatBufferBuilder builder, int currentHpRateControl)
		{
			builder.AddInt(53, currentHpRateControl, 0);
		}

		// Token: 0x06001D42 RID: 7490 RVA: 0x000800BA File Offset: 0x0007E4BA
		public static void AddBaseAtk(FlatBufferBuilder builder, Offset<UnionCell> baseAtkOffset)
		{
			builder.AddOffset(54, baseAtkOffset.Value, 0);
		}

		// Token: 0x06001D43 RID: 7491 RVA: 0x000800CC File Offset: 0x0007E4CC
		public static void AddBaseInt(FlatBufferBuilder builder, Offset<UnionCell> baseIntOffset)
		{
			builder.AddOffset(55, baseIntOffset.Value, 0);
		}

		// Token: 0x06001D44 RID: 7492 RVA: 0x000800DE File Offset: 0x0007E4DE
		public static void AddSta(FlatBufferBuilder builder, Offset<UnionCell> staOffset)
		{
			builder.AddOffset(56, staOffset.Value, 0);
		}

		// Token: 0x06001D45 RID: 7493 RVA: 0x000800F0 File Offset: 0x0007E4F0
		public static void AddSpr(FlatBufferBuilder builder, Offset<UnionCell> sprOffset)
		{
			builder.AddOffset(57, sprOffset.Value, 0);
		}

		// Token: 0x06001D46 RID: 7494 RVA: 0x00080102 File Offset: 0x0007E502
		public static void AddBaseIndependent(FlatBufferBuilder builder, Offset<UnionCell> baseIndependentOffset)
		{
			builder.AddOffset(58, baseIndependentOffset.Value, 0);
		}

		// Token: 0x06001D47 RID: 7495 RVA: 0x00080114 File Offset: 0x0007E514
		public static void AddAtkAddRate(FlatBufferBuilder builder, Offset<UnionCell> atkAddRateOffset)
		{
			builder.AddOffset(59, atkAddRateOffset.Value, 0);
		}

		// Token: 0x06001D48 RID: 7496 RVA: 0x00080126 File Offset: 0x0007E526
		public static void AddIntAddRate(FlatBufferBuilder builder, Offset<UnionCell> intAddRateOffset)
		{
			builder.AddOffset(60, intAddRateOffset.Value, 0);
		}

		// Token: 0x06001D49 RID: 7497 RVA: 0x00080138 File Offset: 0x0007E538
		public static void AddStaAddRate(FlatBufferBuilder builder, Offset<UnionCell> staAddRateOffset)
		{
			builder.AddOffset(61, staAddRateOffset.Value, 0);
		}

		// Token: 0x06001D4A RID: 7498 RVA: 0x0008014A File Offset: 0x0007E54A
		public static void AddSprAddRate(FlatBufferBuilder builder, Offset<UnionCell> sprAddRateOffset)
		{
			builder.AddOffset(62, sprAddRateOffset.Value, 0);
		}

		// Token: 0x06001D4B RID: 7499 RVA: 0x0008015C File Offset: 0x0007E55C
		public static void AddIndependentAddRate(FlatBufferBuilder builder, Offset<UnionCell> independentAddRateOffset)
		{
			builder.AddOffset(63, independentAddRateOffset.Value, 0);
		}

		// Token: 0x06001D4C RID: 7500 RVA: 0x0008016E File Offset: 0x0007E56E
		public static void AddMaxHp(FlatBufferBuilder builder, Offset<UnionCell> maxHpOffset)
		{
			builder.AddOffset(64, maxHpOffset.Value, 0);
		}

		// Token: 0x06001D4D RID: 7501 RVA: 0x00080180 File Offset: 0x0007E580
		public static void AddMaxMp(FlatBufferBuilder builder, Offset<UnionCell> maxMpOffset)
		{
			builder.AddOffset(65, maxMpOffset.Value, 0);
		}

		// Token: 0x06001D4E RID: 7502 RVA: 0x00080192 File Offset: 0x0007E592
		public static void AddMaxHpAddRate(FlatBufferBuilder builder, Offset<UnionCell> maxHpAddRateOffset)
		{
			builder.AddOffset(66, maxHpAddRateOffset.Value, 0);
		}

		// Token: 0x06001D4F RID: 7503 RVA: 0x000801A4 File Offset: 0x0007E5A4
		public static void AddMaxMpAddRate(FlatBufferBuilder builder, Offset<UnionCell> maxMpAddRateOffset)
		{
			builder.AddOffset(67, maxMpAddRateOffset.Value, 0);
		}

		// Token: 0x06001D50 RID: 7504 RVA: 0x000801B6 File Offset: 0x0007E5B6
		public static void AddHpRecover(FlatBufferBuilder builder, Offset<UnionCell> hpRecoverOffset)
		{
			builder.AddOffset(68, hpRecoverOffset.Value, 0);
		}

		// Token: 0x06001D51 RID: 7505 RVA: 0x000801C8 File Offset: 0x0007E5C8
		public static void AddMpRecover(FlatBufferBuilder builder, Offset<UnionCell> mpRecoverOffset)
		{
			builder.AddOffset(69, mpRecoverOffset.Value, 0);
		}

		// Token: 0x06001D52 RID: 7506 RVA: 0x000801DA File Offset: 0x0007E5DA
		public static void AddAttack(FlatBufferBuilder builder, Offset<UnionCell> attackOffset)
		{
			builder.AddOffset(70, attackOffset.Value, 0);
		}

		// Token: 0x06001D53 RID: 7507 RVA: 0x000801EC File Offset: 0x0007E5EC
		public static void AddMagicAttack(FlatBufferBuilder builder, Offset<UnionCell> magicAttackOffset)
		{
			builder.AddOffset(71, magicAttackOffset.Value, 0);
		}

		// Token: 0x06001D54 RID: 7508 RVA: 0x000801FE File Offset: 0x0007E5FE
		public static void AddDefence(FlatBufferBuilder builder, Offset<UnionCell> defenceOffset)
		{
			builder.AddOffset(72, defenceOffset.Value, 0);
		}

		// Token: 0x06001D55 RID: 7509 RVA: 0x00080210 File Offset: 0x0007E610
		public static void AddMagicDefence(FlatBufferBuilder builder, Offset<UnionCell> magicDefenceOffset)
		{
			builder.AddOffset(73, magicDefenceOffset.Value, 0);
		}

		// Token: 0x06001D56 RID: 7510 RVA: 0x00080222 File Offset: 0x0007E622
		public static void AddAttackSpeed(FlatBufferBuilder builder, Offset<UnionCell> attackSpeedOffset)
		{
			builder.AddOffset(74, attackSpeedOffset.Value, 0);
		}

		// Token: 0x06001D57 RID: 7511 RVA: 0x00080234 File Offset: 0x0007E634
		public static void AddSpellSpeed(FlatBufferBuilder builder, Offset<UnionCell> spellSpeedOffset)
		{
			builder.AddOffset(75, spellSpeedOffset.Value, 0);
		}

		// Token: 0x06001D58 RID: 7512 RVA: 0x00080246 File Offset: 0x0007E646
		public static void AddMoveSpeed(FlatBufferBuilder builder, Offset<UnionCell> moveSpeedOffset)
		{
			builder.AddOffset(76, moveSpeedOffset.Value, 0);
		}

		// Token: 0x06001D59 RID: 7513 RVA: 0x00080258 File Offset: 0x0007E658
		public static void AddCiriticalAttack(FlatBufferBuilder builder, Offset<UnionCell> ciriticalAttackOffset)
		{
			builder.AddOffset(77, ciriticalAttackOffset.Value, 0);
		}

		// Token: 0x06001D5A RID: 7514 RVA: 0x0008026A File Offset: 0x0007E66A
		public static void AddCiriticalMagicAttack(FlatBufferBuilder builder, Offset<UnionCell> ciriticalMagicAttackOffset)
		{
			builder.AddOffset(78, ciriticalMagicAttackOffset.Value, 0);
		}

		// Token: 0x06001D5B RID: 7515 RVA: 0x0008027C File Offset: 0x0007E67C
		public static void AddDex(FlatBufferBuilder builder, Offset<UnionCell> dexOffset)
		{
			builder.AddOffset(79, dexOffset.Value, 0);
		}

		// Token: 0x06001D5C RID: 7516 RVA: 0x0008028E File Offset: 0x0007E68E
		public static void AddDodge(FlatBufferBuilder builder, Offset<UnionCell> dodgeOffset)
		{
			builder.AddOffset(80, dodgeOffset.Value, 0);
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x000802A0 File Offset: 0x0007E6A0
		public static void AddFrozen(FlatBufferBuilder builder, Offset<UnionCell> frozenOffset)
		{
			builder.AddOffset(81, frozenOffset.Value, 0);
		}

		// Token: 0x06001D5E RID: 7518 RVA: 0x000802B2 File Offset: 0x0007E6B2
		public static void AddHard(FlatBufferBuilder builder, Offset<UnionCell> hardOffset)
		{
			builder.AddOffset(82, hardOffset.Value, 0);
		}

		// Token: 0x06001D5F RID: 7519 RVA: 0x000802C4 File Offset: 0x0007E6C4
		public static void AddAbnormalResist(FlatBufferBuilder builder, Offset<UnionCell> abnormalResistOffset)
		{
			builder.AddOffset(83, abnormalResistOffset.Value, 0);
		}

		// Token: 0x06001D60 RID: 7520 RVA: 0x000802D6 File Offset: 0x0007E6D6
		public static void AddAbnormalResist1(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist1Offset)
		{
			builder.AddOffset(84, abnormalResist1Offset.Value, 0);
		}

		// Token: 0x06001D61 RID: 7521 RVA: 0x000802E8 File Offset: 0x0007E6E8
		public static void AddAbnormalResist2(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist2Offset)
		{
			builder.AddOffset(85, abnormalResist2Offset.Value, 0);
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x000802FA File Offset: 0x0007E6FA
		public static void AddAbnormalResist3(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist3Offset)
		{
			builder.AddOffset(86, abnormalResist3Offset.Value, 0);
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x0008030C File Offset: 0x0007E70C
		public static void AddAbnormalResist4(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist4Offset)
		{
			builder.AddOffset(87, abnormalResist4Offset.Value, 0);
		}

		// Token: 0x06001D64 RID: 7524 RVA: 0x0008031E File Offset: 0x0007E71E
		public static void AddAbnormalResist5(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist5Offset)
		{
			builder.AddOffset(88, abnormalResist5Offset.Value, 0);
		}

		// Token: 0x06001D65 RID: 7525 RVA: 0x00080330 File Offset: 0x0007E730
		public static void AddAbnormalResist6(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist6Offset)
		{
			builder.AddOffset(89, abnormalResist6Offset.Value, 0);
		}

		// Token: 0x06001D66 RID: 7526 RVA: 0x00080342 File Offset: 0x0007E742
		public static void AddAbnormalResist7(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist7Offset)
		{
			builder.AddOffset(90, abnormalResist7Offset.Value, 0);
		}

		// Token: 0x06001D67 RID: 7527 RVA: 0x00080354 File Offset: 0x0007E754
		public static void AddAbnormalResist8(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist8Offset)
		{
			builder.AddOffset(91, abnormalResist8Offset.Value, 0);
		}

		// Token: 0x06001D68 RID: 7528 RVA: 0x00080366 File Offset: 0x0007E766
		public static void AddAbnormalResist9(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist9Offset)
		{
			builder.AddOffset(92, abnormalResist9Offset.Value, 0);
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x00080378 File Offset: 0x0007E778
		public static void AddAbnormalResist10(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist10Offset)
		{
			builder.AddOffset(93, abnormalResist10Offset.Value, 0);
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x0008038A File Offset: 0x0007E78A
		public static void AddAbnormalResist11(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist11Offset)
		{
			builder.AddOffset(94, abnormalResist11Offset.Value, 0);
		}

		// Token: 0x06001D6B RID: 7531 RVA: 0x0008039C File Offset: 0x0007E79C
		public static void AddAbnormalResist12(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist12Offset)
		{
			builder.AddOffset(95, abnormalResist12Offset.Value, 0);
		}

		// Token: 0x06001D6C RID: 7532 RVA: 0x000803AE File Offset: 0x0007E7AE
		public static void AddAbnormalResist13(FlatBufferBuilder builder, Offset<UnionCell> abnormalResist13Offset)
		{
			builder.AddOffset(96, abnormalResist13Offset.Value, 0);
		}

		// Token: 0x06001D6D RID: 7533 RVA: 0x000803C0 File Offset: 0x0007E7C0
		public static void AddCriticalPercent(FlatBufferBuilder builder, Offset<UnionCell> criticalPercentOffset)
		{
			builder.AddOffset(97, criticalPercentOffset.Value, 0);
		}

		// Token: 0x06001D6E RID: 7534 RVA: 0x000803D2 File Offset: 0x0007E7D2
		public static void AddCdReduceRate(FlatBufferBuilder builder, Offset<UnionCell> cdReduceRateOffset)
		{
			builder.AddOffset(98, cdReduceRateOffset.Value, 0);
		}

		// Token: 0x06001D6F RID: 7535 RVA: 0x000803E4 File Offset: 0x0007E7E4
		public static void AddAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> attackAddRateOffset)
		{
			builder.AddOffset(99, attackAddRateOffset.Value, 0);
		}

		// Token: 0x06001D70 RID: 7536 RVA: 0x000803F6 File Offset: 0x0007E7F6
		public static void AddMagicAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> magicAttackAddRateOffset)
		{
			builder.AddOffset(100, magicAttackAddRateOffset.Value, 0);
		}

		// Token: 0x06001D71 RID: 7537 RVA: 0x00080408 File Offset: 0x0007E808
		public static void AddDefenceAddRate(FlatBufferBuilder builder, Offset<UnionCell> defenceAddRateOffset)
		{
			builder.AddOffset(101, defenceAddRateOffset.Value, 0);
		}

		// Token: 0x06001D72 RID: 7538 RVA: 0x0008041A File Offset: 0x0007E81A
		public static void AddMagicDefenceAddRate(FlatBufferBuilder builder, Offset<UnionCell> magicDefenceAddRateOffset)
		{
			builder.AddOffset(102, magicDefenceAddRateOffset.Value, 0);
		}

		// Token: 0x06001D73 RID: 7539 RVA: 0x0008042C File Offset: 0x0007E82C
		public static void AddIngnoreDefRate(FlatBufferBuilder builder, Offset<UnionCell> ingnoreDefRateOffset)
		{
			builder.AddOffset(103, ingnoreDefRateOffset.Value, 0);
		}

		// Token: 0x06001D74 RID: 7540 RVA: 0x0008043E File Offset: 0x0007E83E
		public static void AddIngnoreMagicDefRate(FlatBufferBuilder builder, Offset<UnionCell> ingnoreMagicDefRateOffset)
		{
			builder.AddOffset(104, ingnoreMagicDefRateOffset.Value, 0);
		}

		// Token: 0x06001D75 RID: 7541 RVA: 0x00080450 File Offset: 0x0007E850
		public static void AddIgnoreDefAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> ignoreDefAttackAddRateOffset)
		{
			builder.AddOffset(105, ignoreDefAttackAddRateOffset.Value, 0);
		}

		// Token: 0x06001D76 RID: 7542 RVA: 0x00080462 File Offset: 0x0007E862
		public static void AddIgnoreDefMagicAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> ignoreDefMagicAttackAddRateOffset)
		{
			builder.AddOffset(106, ignoreDefMagicAttackAddRateOffset.Value, 0);
		}

		// Token: 0x06001D77 RID: 7543 RVA: 0x00080474 File Offset: 0x0007E874
		public static void AddAttachAddDamageFix(FlatBufferBuilder builder, Offset<UnionCell> attachAddDamageFixOffset)
		{
			builder.AddOffset(107, attachAddDamageFixOffset.Value, 0);
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x00080486 File Offset: 0x0007E886
		public static void AddAttachAddDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> attachAddDamagePercentOffset)
		{
			builder.AddOffset(108, attachAddDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D79 RID: 7545 RVA: 0x00080498 File Offset: 0x0007E898
		public static void AddAddDamageFix(FlatBufferBuilder builder, Offset<UnionCell> addDamageFixOffset)
		{
			builder.AddOffset(109, addDamageFixOffset.Value, 0);
		}

		// Token: 0x06001D7A RID: 7546 RVA: 0x000804AA File Offset: 0x0007E8AA
		public static void AddAddDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> addDamagePercentOffset)
		{
			builder.AddOffset(110, addDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D7B RID: 7547 RVA: 0x000804BC File Offset: 0x0007E8BC
		public static void AddSkilladdDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> skilladdDamagePercentOffset)
		{
			builder.AddOffset(111, skilladdDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D7C RID: 7548 RVA: 0x000804CE File Offset: 0x0007E8CE
		public static void AddSkilladdMagicDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> skilladdMagicDamagePercentOffset)
		{
			builder.AddOffset(112, skilladdMagicDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D7D RID: 7549 RVA: 0x000804E0 File Offset: 0x0007E8E0
		public static void AddReduceDamageFix(FlatBufferBuilder builder, Offset<UnionCell> reduceDamageFixOffset)
		{
			builder.AddOffset(113, reduceDamageFixOffset.Value, 0);
		}

		// Token: 0x06001D7E RID: 7550 RVA: 0x000804F2 File Offset: 0x0007E8F2
		public static void AddReduceDamageFixType(FlatBufferBuilder builder, int reduceDamageFixType)
		{
			builder.AddInt(114, reduceDamageFixType, 0);
		}

		// Token: 0x06001D7F RID: 7551 RVA: 0x000804FE File Offset: 0x0007E8FE
		public static void AddReduceDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> reduceDamagePercentOffset)
		{
			builder.AddOffset(115, reduceDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D80 RID: 7552 RVA: 0x00080510 File Offset: 0x0007E910
		public static void AddReduceDamagePercentType(FlatBufferBuilder builder, int reduceDamagePercentType)
		{
			builder.AddInt(116, reduceDamagePercentType, 0);
		}

		// Token: 0x06001D81 RID: 7553 RVA: 0x0008051C File Offset: 0x0007E91C
		public static void AddExtrareduceDamgePercent(FlatBufferBuilder builder, Offset<UnionCell> extrareduceDamgePercentOffset)
		{
			builder.AddOffset(117, extrareduceDamgePercentOffset.Value, 0);
		}

		// Token: 0x06001D82 RID: 7554 RVA: 0x0008052E File Offset: 0x0007E92E
		public static void AddExtrareduceDamagePercentType(FlatBufferBuilder builder, int extrareduceDamagePercentType)
		{
			builder.AddInt(118, extrareduceDamagePercentType, 0);
		}

		// Token: 0x06001D83 RID: 7555 RVA: 0x0008053A File Offset: 0x0007E93A
		public static void AddReflectDamageFix(FlatBufferBuilder builder, Offset<UnionCell> reflectDamageFixOffset)
		{
			builder.AddOffset(119, reflectDamageFixOffset.Value, 0);
		}

		// Token: 0x06001D84 RID: 7556 RVA: 0x0008054C File Offset: 0x0007E94C
		public static void AddReflectDamageFixType(FlatBufferBuilder builder, int reflectDamageFixType)
		{
			builder.AddInt(120, reflectDamageFixType, 0);
		}

		// Token: 0x06001D85 RID: 7557 RVA: 0x00080558 File Offset: 0x0007E958
		public static void AddReflectDamagePercent(FlatBufferBuilder builder, Offset<UnionCell> reflectDamagePercentOffset)
		{
			builder.AddOffset(121, reflectDamagePercentOffset.Value, 0);
		}

		// Token: 0x06001D86 RID: 7558 RVA: 0x0008056A File Offset: 0x0007E96A
		public static void AddReflectDamagePercentType(FlatBufferBuilder builder, int reflectDamagePercentType)
		{
			builder.AddInt(122, reflectDamagePercentType, 0);
		}

		// Token: 0x06001D87 RID: 7559 RVA: 0x00080576 File Offset: 0x0007E976
		public static void AddLevel(FlatBufferBuilder builder, Offset<UnionCell> levelOffset)
		{
			builder.AddOffset(123, levelOffset.Value, 0);
		}

		// Token: 0x06001D88 RID: 7560 RVA: 0x00080588 File Offset: 0x0007E988
		public static void AddSkillMpCostReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillMpCostReduceRateOffset)
		{
			builder.AddOffset(124, skillMpCostReduceRateOffset.Value, 0);
		}

		// Token: 0x06001D89 RID: 7561 RVA: 0x0008059A File Offset: 0x0007E99A
		public static void AddSkillCdReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillCdReduceRateOffset)
		{
			builder.AddOffset(125, skillCdReduceRateOffset.Value, 0);
		}

		// Token: 0x06001D8A RID: 7562 RVA: 0x000805AC File Offset: 0x0007E9AC
		public static void AddSkillCdReduceValue(FlatBufferBuilder builder, Offset<UnionCell> skillCdReduceValueOffset)
		{
			builder.AddOffset(126, skillCdReduceValueOffset.Value, 0);
		}

		// Token: 0x06001D8B RID: 7563 RVA: 0x000805BE File Offset: 0x0007E9BE
		public static void AddSkillSpeedAddFactor(FlatBufferBuilder builder, Offset<UnionCell> skillSpeedAddFactorOffset)
		{
			builder.AddOffset(127, skillSpeedAddFactorOffset.Value, 0);
		}

		// Token: 0x06001D8C RID: 7564 RVA: 0x000805D0 File Offset: 0x0007E9D0
		public static void AddSkillHitRateAdd(FlatBufferBuilder builder, Offset<UnionCell> skillHitRateAddOffset)
		{
			builder.AddOffset(128, skillHitRateAddOffset.Value, 0);
		}

		// Token: 0x06001D8D RID: 7565 RVA: 0x000805E5 File Offset: 0x0007E9E5
		public static void AddSkillCriticalHitRateAdd(FlatBufferBuilder builder, Offset<UnionCell> skillCriticalHitRateAddOffset)
		{
			builder.AddOffset(129, skillCriticalHitRateAddOffset.Value, 0);
		}

		// Token: 0x06001D8E RID: 7566 RVA: 0x000805FA File Offset: 0x0007E9FA
		public static void AddSkillAttackAddRate(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddRateOffset)
		{
			builder.AddOffset(130, skillAttackAddRateOffset.Value, 0);
		}

		// Token: 0x06001D8F RID: 7567 RVA: 0x0008060F File Offset: 0x0007EA0F
		public static void AddSkillAttackAdd(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddOffset)
		{
			builder.AddOffset(131, skillAttackAddOffset.Value, 0);
		}

		// Token: 0x06001D90 RID: 7568 RVA: 0x00080624 File Offset: 0x0007EA24
		public static void AddSkillAttackAddFix(FlatBufferBuilder builder, Offset<UnionCell> skillAttackAddFixOffset)
		{
			builder.AddOffset(132, skillAttackAddFixOffset.Value, 0);
		}

		// Token: 0x06001D91 RID: 7569 RVA: 0x00080639 File Offset: 0x0007EA39
		public static void AddSkillHardAddRate(FlatBufferBuilder builder, Offset<UnionCell> skillHardAddRateOffset)
		{
			builder.AddOffset(133, skillHardAddRateOffset.Value, 0);
		}

		// Token: 0x06001D92 RID: 7570 RVA: 0x0008064E File Offset: 0x0007EA4E
		public static void AddSkillChargeReduceRate(FlatBufferBuilder builder, Offset<UnionCell> skillChargeReduceRateOffset)
		{
			builder.AddOffset(134, skillChargeReduceRateOffset.Value, 0);
		}

		// Token: 0x06001D93 RID: 7571 RVA: 0x00080663 File Offset: 0x0007EA63
		public static void AddResistMagic(FlatBufferBuilder builder, Offset<UnionCell> ResistMagicOffset)
		{
			builder.AddOffset(135, ResistMagicOffset.Value, 0);
		}

		// Token: 0x06001D94 RID: 7572 RVA: 0x00080678 File Offset: 0x0007EA78
		public static void AddAiWarlike(FlatBufferBuilder builder, Offset<UnionCell> aiWarlikeOffset)
		{
			builder.AddOffset(136, aiWarlikeOffset.Value, 0);
		}

		// Token: 0x06001D95 RID: 7573 RVA: 0x0008068D File Offset: 0x0007EA8D
		public static void AddAiSight(FlatBufferBuilder builder, Offset<UnionCell> aiSightOffset)
		{
			builder.AddOffset(137, aiSightOffset.Value, 0);
		}

		// Token: 0x06001D96 RID: 7574 RVA: 0x000806A2 File Offset: 0x0007EAA2
		public static void AddAiAttackProb(FlatBufferBuilder builder, Offset<UnionCell> aiAttackProbOffset)
		{
			builder.AddOffset(138, aiAttackProbOffset.Value, 0);
		}

		// Token: 0x06001D97 RID: 7575 RVA: 0x000806B7 File Offset: 0x0007EAB7
		public static void AddSummonMonsterID(FlatBufferBuilder builder, int summonMonsterID)
		{
			builder.AddInt(139, summonMonsterID, 0);
		}

		// Token: 0x06001D98 RID: 7576 RVA: 0x000806C6 File Offset: 0x0007EAC6
		public static void AddSummonMonsterLevel(FlatBufferBuilder builder, Offset<UnionCell> summonMonsterLevelOffset)
		{
			builder.AddOffset(140, summonMonsterLevelOffset.Value, 0);
		}

		// Token: 0x06001D99 RID: 7577 RVA: 0x000806DB File Offset: 0x0007EADB
		public static void AddSummonExistTime(FlatBufferBuilder builder, int summonExistTime)
		{
			builder.AddInt(141, summonExistTime, 0);
		}

		// Token: 0x06001D9A RID: 7578 RVA: 0x000806EA File Offset: 0x0007EAEA
		public static void AddSummonPosType(FlatBufferBuilder builder, int summonPosType)
		{
			builder.AddInt(142, summonPosType, 0);
		}

		// Token: 0x06001D9B RID: 7579 RVA: 0x000806F9 File Offset: 0x0007EAF9
		public static void AddSummonPosType2(FlatBufferBuilder builder, VectorOffset summonPosType2Offset)
		{
			builder.AddOffset(143, summonPosType2Offset.Value, 0);
		}

		// Token: 0x06001D9C RID: 7580 RVA: 0x00080710 File Offset: 0x0007EB10
		public static VectorOffset CreateSummonPosType2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001D9D RID: 7581 RVA: 0x0008074D File Offset: 0x0007EB4D
		public static void StartSummonPosType2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001D9E RID: 7582 RVA: 0x00080758 File Offset: 0x0007EB58
		public static void AddSummonDisplay(FlatBufferBuilder builder, int summonDisplay)
		{
			builder.AddInt(144, summonDisplay, 0);
		}

		// Token: 0x06001D9F RID: 7583 RVA: 0x00080767 File Offset: 0x0007EB67
		public static void AddSummonNum(FlatBufferBuilder builder, int summonNum)
		{
			builder.AddInt(145, summonNum, 0);
		}

		// Token: 0x06001DA0 RID: 7584 RVA: 0x00080776 File Offset: 0x0007EB76
		public static void AddSummonRelation(FlatBufferBuilder builder, int summonRelation)
		{
			builder.AddInt(146, summonRelation, 0);
		}

		// Token: 0x06001DA1 RID: 7585 RVA: 0x00080785 File Offset: 0x0007EB85
		public static void AddSummonNumLimit(FlatBufferBuilder builder, int summonNumLimit)
		{
			builder.AddInt(147, summonNumLimit, 0);
		}

		// Token: 0x06001DA2 RID: 7586 RVA: 0x00080794 File Offset: 0x0007EB94
		public static void AddSummonEntity(FlatBufferBuilder builder, VectorOffset summonEntityOffset)
		{
			builder.AddOffset(148, summonEntityOffset.Value, 0);
		}

		// Token: 0x06001DA3 RID: 7587 RVA: 0x000807AC File Offset: 0x0007EBAC
		public static VectorOffset CreateSummonEntityVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DA4 RID: 7588 RVA: 0x000807E9 File Offset: 0x0007EBE9
		public static void StartSummonEntityVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DA5 RID: 7589 RVA: 0x000807F4 File Offset: 0x0007EBF4
		public static void AddDuplicatePercent(FlatBufferBuilder builder, int duplicatePercent)
		{
			builder.AddInt(149, duplicatePercent, 0);
		}

		// Token: 0x06001DA6 RID: 7590 RVA: 0x00080803 File Offset: 0x0007EC03
		public static void AddDuplicateMax(FlatBufferBuilder builder, int duplicateMax)
		{
			builder.AddInt(150, duplicateMax, 0);
		}

		// Token: 0x06001DA7 RID: 7591 RVA: 0x00080812 File Offset: 0x0007EC12
		public static void AddExpAddRate(FlatBufferBuilder builder, Offset<UnionCell> expAddRateOffset)
		{
			builder.AddOffset(151, expAddRateOffset.Value, 0);
		}

		// Token: 0x06001DA8 RID: 7592 RVA: 0x00080827 File Offset: 0x0007EC27
		public static void AddGoldAddRate(FlatBufferBuilder builder, Offset<UnionCell> goldAddRateOffset)
		{
			builder.AddOffset(152, goldAddRateOffset.Value, 0);
		}

		// Token: 0x06001DA9 RID: 7593 RVA: 0x0008083C File Offset: 0x0007EC3C
		public static void AddTaskDropAddRate(FlatBufferBuilder builder, int taskDropAddRate)
		{
			builder.AddInt(153, taskDropAddRate, 0);
		}

		// Token: 0x06001DAA RID: 7594 RVA: 0x0008084B File Offset: 0x0007EC4B
		public static void AddPinkDropAddRate(FlatBufferBuilder builder, int PinkDropAddRate)
		{
			builder.AddInt(154, PinkDropAddRate, 0);
		}

		// Token: 0x06001DAB RID: 7595 RVA: 0x0008085A File Offset: 0x0007EC5A
		public static void AddChestDropAddRate(FlatBufferBuilder builder, int ChestDropAddRate)
		{
			builder.AddInt(155, ChestDropAddRate, 0);
		}

		// Token: 0x06001DAC RID: 7596 RVA: 0x00080869 File Offset: 0x0007EC69
		public static void AddDurationType(FlatBufferBuilder builder, int durationType)
		{
			builder.AddInt(156, durationType, 0);
		}

		// Token: 0x06001DAD RID: 7597 RVA: 0x00080878 File Offset: 0x0007EC78
		public static void AddDuration(FlatBufferBuilder builder, int duration)
		{
			builder.AddInt(157, duration, 0);
		}

		// Token: 0x06001DAE RID: 7598 RVA: 0x00080887 File Offset: 0x0007EC87
		public static void AddDescriptionA(FlatBufferBuilder builder, StringOffset DescriptionAOffset)
		{
			builder.AddOffset(158, DescriptionAOffset.Value, 0);
		}

		// Token: 0x06001DAF RID: 7599 RVA: 0x0008089C File Offset: 0x0007EC9C
		public static void AddValueA(FlatBufferBuilder builder, VectorOffset ValueAOffset)
		{
			builder.AddOffset(159, ValueAOffset.Value, 0);
		}

		// Token: 0x06001DB0 RID: 7600 RVA: 0x000808B4 File Offset: 0x0007ECB4
		public static VectorOffset CreateValueAVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DB1 RID: 7601 RVA: 0x000808FA File Offset: 0x0007ECFA
		public static void StartValueAVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DB2 RID: 7602 RVA: 0x00080905 File Offset: 0x0007ED05
		public static void AddDescriptionB(FlatBufferBuilder builder, StringOffset DescriptionBOffset)
		{
			builder.AddOffset(160, DescriptionBOffset.Value, 0);
		}

		// Token: 0x06001DB3 RID: 7603 RVA: 0x0008091A File Offset: 0x0007ED1A
		public static void AddValueB(FlatBufferBuilder builder, VectorOffset ValueBOffset)
		{
			builder.AddOffset(161, ValueBOffset.Value, 0);
		}

		// Token: 0x06001DB4 RID: 7604 RVA: 0x00080930 File Offset: 0x0007ED30
		public static VectorOffset CreateValueBVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DB5 RID: 7605 RVA: 0x00080976 File Offset: 0x0007ED76
		public static void StartValueBVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DB6 RID: 7606 RVA: 0x00080981 File Offset: 0x0007ED81
		public static void AddDescriptionC(FlatBufferBuilder builder, StringOffset DescriptionCOffset)
		{
			builder.AddOffset(162, DescriptionCOffset.Value, 0);
		}

		// Token: 0x06001DB7 RID: 7607 RVA: 0x00080996 File Offset: 0x0007ED96
		public static void AddValueC(FlatBufferBuilder builder, VectorOffset ValueCOffset)
		{
			builder.AddOffset(163, ValueCOffset.Value, 0);
		}

		// Token: 0x06001DB8 RID: 7608 RVA: 0x000809AC File Offset: 0x0007EDAC
		public static VectorOffset CreateValueCVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DB9 RID: 7609 RVA: 0x000809F2 File Offset: 0x0007EDF2
		public static void StartValueCVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DBA RID: 7610 RVA: 0x000809FD File Offset: 0x0007EDFD
		public static void AddDescriptionD(FlatBufferBuilder builder, StringOffset DescriptionDOffset)
		{
			builder.AddOffset(164, DescriptionDOffset.Value, 0);
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x00080A12 File Offset: 0x0007EE12
		public static void AddValueD(FlatBufferBuilder builder, VectorOffset ValueDOffset)
		{
			builder.AddOffset(165, ValueDOffset.Value, 0);
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x00080A28 File Offset: 0x0007EE28
		public static VectorOffset CreateValueDVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DBD RID: 7613 RVA: 0x00080A6E File Offset: 0x0007EE6E
		public static void StartValueDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x00080A79 File Offset: 0x0007EE79
		public static void AddDescriptionE(FlatBufferBuilder builder, StringOffset DescriptionEOffset)
		{
			builder.AddOffset(166, DescriptionEOffset.Value, 0);
		}

		// Token: 0x06001DBF RID: 7615 RVA: 0x00080A8E File Offset: 0x0007EE8E
		public static void AddValueE(FlatBufferBuilder builder, VectorOffset ValueEOffset)
		{
			builder.AddOffset(167, ValueEOffset.Value, 0);
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x00080AA4 File Offset: 0x0007EEA4
		public static VectorOffset CreateValueEVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x00080AEA File Offset: 0x0007EEEA
		public static void StartValueEVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x00080AF5 File Offset: 0x0007EEF5
		public static void AddDescriptionF(FlatBufferBuilder builder, StringOffset DescriptionFOffset)
		{
			builder.AddOffset(168, DescriptionFOffset.Value, 0);
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x00080B0A File Offset: 0x0007EF0A
		public static void AddValueF(FlatBufferBuilder builder, VectorOffset ValueFOffset)
		{
			builder.AddOffset(169, ValueFOffset.Value, 0);
		}

		// Token: 0x06001DC4 RID: 7620 RVA: 0x00080B20 File Offset: 0x0007EF20
		public static VectorOffset CreateValueFVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DC5 RID: 7621 RVA: 0x00080B66 File Offset: 0x0007EF66
		public static void StartValueFVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DC6 RID: 7622 RVA: 0x00080B71 File Offset: 0x0007EF71
		public static void AddDescriptionG(FlatBufferBuilder builder, StringOffset DescriptionGOffset)
		{
			builder.AddOffset(170, DescriptionGOffset.Value, 0);
		}

		// Token: 0x06001DC7 RID: 7623 RVA: 0x00080B86 File Offset: 0x0007EF86
		public static void AddValueG(FlatBufferBuilder builder, VectorOffset ValueGOffset)
		{
			builder.AddOffset(171, ValueGOffset.Value, 0);
		}

		// Token: 0x06001DC8 RID: 7624 RVA: 0x00080B9C File Offset: 0x0007EF9C
		public static VectorOffset CreateValueGVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DC9 RID: 7625 RVA: 0x00080BE2 File Offset: 0x0007EFE2
		public static void StartValueGVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DCA RID: 7626 RVA: 0x00080BED File Offset: 0x0007EFED
		public static void AddEffectTimes(FlatBufferBuilder builder, int EffectTimes)
		{
			builder.AddInt(172, EffectTimes, 0);
		}

		// Token: 0x06001DCB RID: 7627 RVA: 0x00080BFC File Offset: 0x0007EFFC
		public static void AddApplyDungeon(FlatBufferBuilder builder, StringOffset ApplyDungeonOffset)
		{
			builder.AddOffset(173, ApplyDungeonOffset.Value, 0);
		}

		// Token: 0x06001DCC RID: 7628 RVA: 0x00080C11 File Offset: 0x0007F011
		public static void AddBuffType(FlatBufferBuilder builder, VectorOffset BuffTypeOffset)
		{
			builder.AddOffset(174, BuffTypeOffset.Value, 0);
		}

		// Token: 0x06001DCD RID: 7629 RVA: 0x00080C28 File Offset: 0x0007F028
		public static VectorOffset CreateBuffTypeVector(FlatBufferBuilder builder, BuffTable.eBuffType[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001DCE RID: 7630 RVA: 0x00080C65 File Offset: 0x0007F065
		public static void StartBuffTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001DCF RID: 7631 RVA: 0x00080C70 File Offset: 0x0007F070
		public static void AddBuffDisName(FlatBufferBuilder builder, StringOffset BuffDisNameOffset)
		{
			builder.AddOffset(175, BuffDisNameOffset.Value, 0);
		}

		// Token: 0x06001DD0 RID: 7632 RVA: 0x00080C88 File Offset: 0x0007F088
		public static Offset<BuffTable> EndBuffTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BuffTable>(value);
		}

		// Token: 0x06001DD1 RID: 7633 RVA: 0x00080CA2 File Offset: 0x0007F0A2
		public static void FinishBuffTableBuffer(FlatBufferBuilder builder, Offset<BuffTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EE1 RID: 3809
		private Table __p = new Table();

		// Token: 0x04000EE2 RID: 3810
		private FlatBufferArray<int> TargetStateValue;

		// Token: 0x04000EE3 RID: 3811
		private FlatBufferArray<int> StateChangeValue;

		// Token: 0x04000EE4 RID: 3812
		private FlatBufferArray<int> AbilityChangeValue;

		// Token: 0x04000EE5 RID: 3813
		private FlatBufferArray<int> ElementsValue;

		// Token: 0x04000EE6 RID: 3814
		private FlatBufferArray<int> UseSkillIDsValue;

		// Token: 0x04000EE7 RID: 3815
		private FlatBufferArray<int> TriggerBuffInfoIDsValue;

		// Token: 0x04000EE8 RID: 3816
		private FlatBufferArray<int> MechanismIDValue;

		// Token: 0x04000EE9 RID: 3817
		private FlatBufferArray<int> summon_posType2Value;

		// Token: 0x04000EEA RID: 3818
		private FlatBufferArray<int> summon_entityValue;

		// Token: 0x04000EEB RID: 3819
		private FlatBufferArray<UnionCell> ValueAValue;

		// Token: 0x04000EEC RID: 3820
		private FlatBufferArray<UnionCell> ValueBValue;

		// Token: 0x04000EED RID: 3821
		private FlatBufferArray<UnionCell> ValueCValue;

		// Token: 0x04000EEE RID: 3822
		private FlatBufferArray<UnionCell> ValueDValue;

		// Token: 0x04000EEF RID: 3823
		private FlatBufferArray<UnionCell> ValueEValue;

		// Token: 0x04000EF0 RID: 3824
		private FlatBufferArray<UnionCell> ValueFValue;

		// Token: 0x04000EF1 RID: 3825
		private FlatBufferArray<UnionCell> ValueGValue;

		// Token: 0x04000EF2 RID: 3826
		private FlatBufferArray<BuffTable.eBuffType> BuffTypeValue;

		// Token: 0x020002F4 RID: 756
		public enum eBuffType
		{
			// Token: 0x04000EF4 RID: 3828
			HP_MAX,
			// Token: 0x04000EF5 RID: 3829
			MP_MAX,
			// Token: 0x04000EF6 RID: 3830
			BASE_ATK,
			// Token: 0x04000EF7 RID: 3831
			BASE_INT,
			// Token: 0x04000EF8 RID: 3832
			STA,
			// Token: 0x04000EF9 RID: 3833
			SPR,
			// Token: 0x04000EFA RID: 3834
			ATTACK,
			// Token: 0x04000EFB RID: 3835
			MAGIC_ATTACK,
			// Token: 0x04000EFC RID: 3836
			DEFENCE,
			// Token: 0x04000EFD RID: 3837
			MAGIC_DEFENCE,
			// Token: 0x04000EFE RID: 3838
			CIRITICAL_ATTACK,
			// Token: 0x04000EFF RID: 3839
			CIRITICAL_MAGIC_ATTACK,
			// Token: 0x04000F00 RID: 3840
			ATTACK_SPEED,
			// Token: 0x04000F01 RID: 3841
			SPELL_SPEED,
			// Token: 0x04000F02 RID: 3842
			MOVE_SPEED,
			// Token: 0x04000F03 RID: 3843
			DODGE,
			// Token: 0x04000F04 RID: 3844
			DEX,
			// Token: 0x04000F05 RID: 3845
			HP_RECOVER,
			// Token: 0x04000F06 RID: 3846
			MP_RECOVER,
			// Token: 0x04000F07 RID: 3847
			HARD,
			// Token: 0x04000F08 RID: 3848
			ADD_DAMAGE_PERCENT,
			// Token: 0x04000F09 RID: 3849
			ATTACK_ADD_RATE,
			// Token: 0x04000F0A RID: 3850
			MAGIC_ATTACK_ADD_RATE
		}

		// Token: 0x020002F5 RID: 757
		public enum eCrypt
		{
			// Token: 0x04000F0C RID: 3852
			code = 136068113
		}
	}
}
