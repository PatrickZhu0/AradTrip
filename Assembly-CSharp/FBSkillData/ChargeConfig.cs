using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B25 RID: 19237
	public sealed class ChargeConfig : Table
	{
		// Token: 0x0601C1B7 RID: 115127 RVA: 0x008927B2 File Offset: 0x00890BB2
		public static ChargeConfig GetRootAsChargeConfig(ByteBuffer _bb)
		{
			return ChargeConfig.GetRootAsChargeConfig(_bb, new ChargeConfig());
		}

		// Token: 0x0601C1B8 RID: 115128 RVA: 0x008927BF File Offset: 0x00890BBF
		public static ChargeConfig GetRootAsChargeConfig(ByteBuffer _bb, ChargeConfig obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C1B9 RID: 115129 RVA: 0x008927DB File Offset: 0x00890BDB
		public ChargeConfig __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026DD RID: 9949
		// (get) Token: 0x0601C1BA RID: 115130 RVA: 0x008927EC File Offset: 0x00890BEC
		public int RepeatPhase
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026DE RID: 9950
		// (get) Token: 0x0601C1BB RID: 115131 RVA: 0x00892820 File Offset: 0x00890C20
		public int ChangePhase
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026DF RID: 9951
		// (get) Token: 0x0601C1BC RID: 115132 RVA: 0x00892854 File Offset: 0x00890C54
		public int SwitchPhaseID
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026E0 RID: 9952
		// (get) Token: 0x0601C1BD RID: 115133 RVA: 0x00892888 File Offset: 0x00890C88
		public float ChargeDuration
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026E1 RID: 9953
		// (get) Token: 0x0601C1BE RID: 115134 RVA: 0x008928C4 File Offset: 0x00890CC4
		public float ChargeMinDuration
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026E2 RID: 9954
		// (get) Token: 0x0601C1BF RID: 115135 RVA: 0x00892900 File Offset: 0x00890D00
		public string Effect
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026E3 RID: 9955
		// (get) Token: 0x0601C1C0 RID: 115136 RVA: 0x00892930 File Offset: 0x00890D30
		public string Locator
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026E4 RID: 9956
		// (get) Token: 0x0601C1C1 RID: 115137 RVA: 0x00892960 File Offset: 0x00890D60
		public int BuffInfo
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026E5 RID: 9957
		// (get) Token: 0x0601C1C2 RID: 115138 RVA: 0x00892998 File Offset: 0x00890D98
		public bool PlayBuffAni
		{
			get
			{
				int num = base.__offset(20);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C1C3 RID: 115139 RVA: 0x008929D4 File Offset: 0x00890DD4
		public static Offset<ChargeConfig> CreateChargeConfig(FlatBufferBuilder builder, int repeatPhase = 0, int changePhase = 0, int switchPhaseID = 0, float chargeDuration = 0f, float chargeMinDuration = 0f, StringOffset effect = default(StringOffset), StringOffset locator = default(StringOffset), int buffInfo = 0, bool playBuffAni = false)
		{
			builder.StartObject(9);
			ChargeConfig.AddBuffInfo(builder, buffInfo);
			ChargeConfig.AddLocator(builder, locator);
			ChargeConfig.AddEffect(builder, effect);
			ChargeConfig.AddChargeMinDuration(builder, chargeMinDuration);
			ChargeConfig.AddChargeDuration(builder, chargeDuration);
			ChargeConfig.AddSwitchPhaseID(builder, switchPhaseID);
			ChargeConfig.AddChangePhase(builder, changePhase);
			ChargeConfig.AddRepeatPhase(builder, repeatPhase);
			ChargeConfig.AddPlayBuffAni(builder, playBuffAni);
			return ChargeConfig.EndChargeConfig(builder);
		}

		// Token: 0x0601C1C4 RID: 115140 RVA: 0x00892A34 File Offset: 0x00890E34
		public static void StartChargeConfig(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x0601C1C5 RID: 115141 RVA: 0x00892A3E File Offset: 0x00890E3E
		public static void AddRepeatPhase(FlatBufferBuilder builder, int repeatPhase)
		{
			builder.AddInt(0, repeatPhase, 0);
		}

		// Token: 0x0601C1C6 RID: 115142 RVA: 0x00892A49 File Offset: 0x00890E49
		public static void AddChangePhase(FlatBufferBuilder builder, int changePhase)
		{
			builder.AddInt(1, changePhase, 0);
		}

		// Token: 0x0601C1C7 RID: 115143 RVA: 0x00892A54 File Offset: 0x00890E54
		public static void AddSwitchPhaseID(FlatBufferBuilder builder, int switchPhaseID)
		{
			builder.AddInt(2, switchPhaseID, 0);
		}

		// Token: 0x0601C1C8 RID: 115144 RVA: 0x00892A5F File Offset: 0x00890E5F
		public static void AddChargeDuration(FlatBufferBuilder builder, float chargeDuration)
		{
			builder.AddFloat(3, chargeDuration, 0.0);
		}

		// Token: 0x0601C1C9 RID: 115145 RVA: 0x00892A72 File Offset: 0x00890E72
		public static void AddChargeMinDuration(FlatBufferBuilder builder, float chargeMinDuration)
		{
			builder.AddFloat(4, chargeMinDuration, 0.0);
		}

		// Token: 0x0601C1CA RID: 115146 RVA: 0x00892A85 File Offset: 0x00890E85
		public static void AddEffect(FlatBufferBuilder builder, StringOffset effectOffset)
		{
			builder.AddOffset(5, effectOffset.Value, 0);
		}

		// Token: 0x0601C1CB RID: 115147 RVA: 0x00892A96 File Offset: 0x00890E96
		public static void AddLocator(FlatBufferBuilder builder, StringOffset locatorOffset)
		{
			builder.AddOffset(6, locatorOffset.Value, 0);
		}

		// Token: 0x0601C1CC RID: 115148 RVA: 0x00892AA7 File Offset: 0x00890EA7
		public static void AddBuffInfo(FlatBufferBuilder builder, int buffInfo)
		{
			builder.AddInt(7, buffInfo, 0);
		}

		// Token: 0x0601C1CD RID: 115149 RVA: 0x00892AB2 File Offset: 0x00890EB2
		public static void AddPlayBuffAni(FlatBufferBuilder builder, bool playBuffAni)
		{
			builder.AddBool(8, playBuffAni, false);
		}

		// Token: 0x0601C1CE RID: 115150 RVA: 0x00892AC0 File Offset: 0x00890EC0
		public static Offset<ChargeConfig> EndChargeConfig(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChargeConfig>(value);
		}
	}
}
