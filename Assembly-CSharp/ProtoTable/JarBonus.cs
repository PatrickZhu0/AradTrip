using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004C5 RID: 1221
	public class JarBonus : IFlatbufferObject
	{
		// Token: 0x17000F58 RID: 3928
		// (get) Token: 0x06003BE7 RID: 15335 RVA: 0x000C8340 File Offset: 0x000C6740
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003BE8 RID: 15336 RVA: 0x000C834D File Offset: 0x000C674D
		public static JarBonus GetRootAsJarBonus(ByteBuffer _bb)
		{
			return JarBonus.GetRootAsJarBonus(_bb, new JarBonus());
		}

		// Token: 0x06003BE9 RID: 15337 RVA: 0x000C835A File Offset: 0x000C675A
		public static JarBonus GetRootAsJarBonus(ByteBuffer _bb, JarBonus obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003BEA RID: 15338 RVA: 0x000C8376 File Offset: 0x000C6776
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003BEB RID: 15339 RVA: 0x000C8390 File Offset: 0x000C6790
		public JarBonus __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000F59 RID: 3929
		// (get) Token: 0x06003BEC RID: 15340 RVA: 0x000C839C File Offset: 0x000C679C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F5A RID: 3930
		// (get) Token: 0x06003BED RID: 15341 RVA: 0x000C83E8 File Offset: 0x000C67E8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x000C842A File Offset: 0x000C682A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000F5B RID: 3931
		// (get) Token: 0x06003BEF RID: 15343 RVA: 0x000C8438 File Offset: 0x000C6838
		public JarBonus.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (JarBonus.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003BF0 RID: 15344 RVA: 0x000C847C File Offset: 0x000C687C
		public int FilterArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000F5C RID: 3932
		// (get) Token: 0x06003BF1 RID: 15345 RVA: 0x000C84CC File Offset: 0x000C68CC
		public int FilterLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003BF2 RID: 15346 RVA: 0x000C84FF File Offset: 0x000C68FF
		public ArraySegment<byte>? GetFilterBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000F5D RID: 3933
		// (get) Token: 0x06003BF3 RID: 15347 RVA: 0x000C850E File Offset: 0x000C690E
		public FlatBufferArray<int> Filter
		{
			get
			{
				if (this.FilterValue == null)
				{
					this.FilterValue = new FlatBufferArray<int>(new Func<int, int>(this.FilterArray), this.FilterLength);
				}
				return this.FilterValue;
			}
		}

		// Token: 0x17000F5E RID: 3934
		// (get) Token: 0x06003BF4 RID: 15348 RVA: 0x000C8540 File Offset: 0x000C6940
		public string JarImage
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003BF5 RID: 15349 RVA: 0x000C8583 File Offset: 0x000C6983
		public ArraySegment<byte>? GetJarImageBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000F5F RID: 3935
		// (get) Token: 0x06003BF6 RID: 15350 RVA: 0x000C8594 File Offset: 0x000C6994
		public string JarEffect
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003BF7 RID: 15351 RVA: 0x000C85D7 File Offset: 0x000C69D7
		public ArraySegment<byte>? GetJarEffectBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000F60 RID: 3936
		// (get) Token: 0x06003BF8 RID: 15352 RVA: 0x000C85E8 File Offset: 0x000C69E8
		public int ExBonusNum_1
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F61 RID: 3937
		// (get) Token: 0x06003BF9 RID: 15353 RVA: 0x000C8634 File Offset: 0x000C6A34
		public int ExBonusJarID_1
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F62 RID: 3938
		// (get) Token: 0x06003BFA RID: 15354 RVA: 0x000C8680 File Offset: 0x000C6A80
		public int ExBonusNum_2
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F63 RID: 3939
		// (get) Token: 0x06003BFB RID: 15355 RVA: 0x000C86CC File Offset: 0x000C6ACC
		public int ExBonusJarID_2
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003BFC RID: 15356 RVA: 0x000C8718 File Offset: 0x000C6B18
		public string GetItemsAndNumArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000F64 RID: 3940
		// (get) Token: 0x06003BFD RID: 15357 RVA: 0x000C8760 File Offset: 0x000C6B60
		public int GetItemsAndNumLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000F65 RID: 3941
		// (get) Token: 0x06003BFE RID: 15358 RVA: 0x000C8793 File Offset: 0x000C6B93
		public FlatBufferArray<string> GetItemsAndNum
		{
			get
			{
				if (this.GetItemsAndNumValue == null)
				{
					this.GetItemsAndNumValue = new FlatBufferArray<string>(new Func<int, string>(this.GetItemsAndNumArray), this.GetItemsAndNumLength);
				}
				return this.GetItemsAndNumValue;
			}
		}

		// Token: 0x17000F66 RID: 3942
		// (get) Token: 0x06003BFF RID: 15359 RVA: 0x000C87C4 File Offset: 0x000C6BC4
		public int BuyMoneyType
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x06003C00 RID: 15360 RVA: 0x000C8810 File Offset: 0x000C6C10
		public int MoneyValue
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x06003C01 RID: 15361 RVA: 0x000C885C File Offset: 0x000C6C5C
		public int DayBuyLimite
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x06003C02 RID: 15362 RVA: 0x000C88A8 File Offset: 0x000C6CA8
		public string BuyLimitKey
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C03 RID: 15363 RVA: 0x000C88EB File Offset: 0x000C6CEB
		public ArraySegment<byte>? GetBuyLimitKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x06003C04 RID: 15364 RVA: 0x000C88FC File Offset: 0x000C6CFC
		public int NeedExItem
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F6B RID: 3947
		// (get) Token: 0x06003C05 RID: 15365 RVA: 0x000C8948 File Offset: 0x000C6D48
		public int ExItemID
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F6C RID: 3948
		// (get) Token: 0x06003C06 RID: 15366 RVA: 0x000C8994 File Offset: 0x000C6D94
		public int ExItemCostNum
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F6D RID: 3949
		// (get) Token: 0x06003C07 RID: 15367 RVA: 0x000C89E0 File Offset: 0x000C6DE0
		public int ComboBuyNum
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F6E RID: 3950
		// (get) Token: 0x06003C08 RID: 15368 RVA: 0x000C8A2C File Offset: 0x000C6E2C
		public int SingleBuyDiscount
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F6F RID: 3951
		// (get) Token: 0x06003C09 RID: 15369 RVA: 0x000C8A78 File Offset: 0x000C6E78
		public int ComboBuyDiscount
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F70 RID: 3952
		// (get) Token: 0x06003C0A RID: 15370 RVA: 0x000C8AC4 File Offset: 0x000C6EC4
		public string CounterKey
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C0B RID: 15371 RVA: 0x000C8B07 File Offset: 0x000C6F07
		public ArraySegment<byte>? GetCounterKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000F71 RID: 3953
		// (get) Token: 0x06003C0C RID: 15372 RVA: 0x000C8B18 File Offset: 0x000C6F18
		public int GetPointType
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F72 RID: 3954
		// (get) Token: 0x06003C0D RID: 15373 RVA: 0x000C8B64 File Offset: 0x000C6F64
		public int GetPointNum
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F73 RID: 3955
		// (get) Token: 0x06003C0E RID: 15374 RVA: 0x000C8BB0 File Offset: 0x000C6FB0
		public string GetPointCrit
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C0F RID: 15375 RVA: 0x000C8BF3 File Offset: 0x000C6FF3
		public ArraySegment<byte>? GetGetPointCritBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17000F74 RID: 3956
		// (get) Token: 0x06003C10 RID: 15376 RVA: 0x000C8C04 File Offset: 0x000C7004
		public int MaxFreeCount
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F75 RID: 3957
		// (get) Token: 0x06003C11 RID: 15377 RVA: 0x000C8C50 File Offset: 0x000C7050
		public int FreeCD
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F76 RID: 3958
		// (get) Token: 0x06003C12 RID: 15378 RVA: 0x000C8C9C File Offset: 0x000C709C
		public string FreeNumCounterKey
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C13 RID: 15379 RVA: 0x000C8CDF File Offset: 0x000C70DF
		public ArraySegment<byte>? GetFreeNumCounterKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17000F77 RID: 3959
		// (get) Token: 0x06003C14 RID: 15380 RVA: 0x000C8CF0 File Offset: 0x000C70F0
		public string NextFreeTimeCounterKey
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C15 RID: 15381 RVA: 0x000C8D33 File Offset: 0x000C7133
		public ArraySegment<byte>? GetNextFreeTimeCounterKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x17000F78 RID: 3960
		// (get) Token: 0x06003C16 RID: 15382 RVA: 0x000C8D44 File Offset: 0x000C7144
		public int NeedRecord
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x06003C17 RID: 15383 RVA: 0x000C8D90 File Offset: 0x000C7190
		public int ActJarDisMaxNum
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F7A RID: 3962
		// (get) Token: 0x06003C18 RID: 15384 RVA: 0x000C8DDC File Offset: 0x000C71DC
		public int ActJarDisReset
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F7B RID: 3963
		// (get) Token: 0x06003C19 RID: 15385 RVA: 0x000C8E28 File Offset: 0x000C7228
		public int ActifactJarRewardTime
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F7C RID: 3964
		// (get) Token: 0x06003C1A RID: 15386 RVA: 0x000C8E74 File Offset: 0x000C7274
		public int JarGiftMustOutNum
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F7D RID: 3965
		// (get) Token: 0x06003C1B RID: 15387 RVA: 0x000C8EC0 File Offset: 0x000C72C0
		public string CurCycleIsOutTreasKey
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003C1C RID: 15388 RVA: 0x000C8F03 File Offset: 0x000C7303
		public ArraySegment<byte>? GetCurCycleIsOutTreasKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x17000F7E RID: 3966
		// (get) Token: 0x06003C1D RID: 15389 RVA: 0x000C8F14 File Offset: 0x000C7314
		public int jarGiftOutJarId
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000F7F RID: 3967
		// (get) Token: 0x06003C1E RID: 15390 RVA: 0x000C8F60 File Offset: 0x000C7360
		public int SmellType
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (484252340 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003C1F RID: 15391 RVA: 0x000C8FAC File Offset: 0x000C73AC
		public static Offset<JarBonus> CreateJarBonus(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), JarBonus.eType Type = JarBonus.eType.NoneJar, VectorOffset FilterOffset = default(VectorOffset), StringOffset JarImageOffset = default(StringOffset), StringOffset JarEffectOffset = default(StringOffset), int ExBonusNum_1 = 0, int ExBonusJarID_1 = 0, int ExBonusNum_2 = 0, int ExBonusJarID_2 = 0, VectorOffset GetItemsAndNumOffset = default(VectorOffset), int BuyMoneyType = 0, int MoneyValue = 0, int DayBuyLimite = 0, StringOffset BuyLimitKeyOffset = default(StringOffset), int NeedExItem = 0, int ExItemID = 0, int ExItemCostNum = 0, int ComboBuyNum = 0, int SingleBuyDiscount = 0, int ComboBuyDiscount = 0, StringOffset CounterKeyOffset = default(StringOffset), int GetPointType = 0, int GetPointNum = 0, StringOffset GetPointCritOffset = default(StringOffset), int MaxFreeCount = 0, int FreeCD = 0, StringOffset FreeNumCounterKeyOffset = default(StringOffset), StringOffset NextFreeTimeCounterKeyOffset = default(StringOffset), int NeedRecord = 0, int ActJarDisMaxNum = 0, int ActJarDisReset = 0, int ActifactJarRewardTime = 0, int JarGiftMustOutNum = 0, StringOffset CurCycleIsOutTreasKeyOffset = default(StringOffset), int jarGiftOutJarId = 0, int SmellType = 0)
		{
			builder.StartObject(37);
			JarBonus.AddSmellType(builder, SmellType);
			JarBonus.AddJarGiftOutJarId(builder, jarGiftOutJarId);
			JarBonus.AddCurCycleIsOutTreasKey(builder, CurCycleIsOutTreasKeyOffset);
			JarBonus.AddJarGiftMustOutNum(builder, JarGiftMustOutNum);
			JarBonus.AddActifactJarRewardTime(builder, ActifactJarRewardTime);
			JarBonus.AddActJarDisReset(builder, ActJarDisReset);
			JarBonus.AddActJarDisMaxNum(builder, ActJarDisMaxNum);
			JarBonus.AddNeedRecord(builder, NeedRecord);
			JarBonus.AddNextFreeTimeCounterKey(builder, NextFreeTimeCounterKeyOffset);
			JarBonus.AddFreeNumCounterKey(builder, FreeNumCounterKeyOffset);
			JarBonus.AddFreeCD(builder, FreeCD);
			JarBonus.AddMaxFreeCount(builder, MaxFreeCount);
			JarBonus.AddGetPointCrit(builder, GetPointCritOffset);
			JarBonus.AddGetPointNum(builder, GetPointNum);
			JarBonus.AddGetPointType(builder, GetPointType);
			JarBonus.AddCounterKey(builder, CounterKeyOffset);
			JarBonus.AddComboBuyDiscount(builder, ComboBuyDiscount);
			JarBonus.AddSingleBuyDiscount(builder, SingleBuyDiscount);
			JarBonus.AddComboBuyNum(builder, ComboBuyNum);
			JarBonus.AddExItemCostNum(builder, ExItemCostNum);
			JarBonus.AddExItemID(builder, ExItemID);
			JarBonus.AddNeedExItem(builder, NeedExItem);
			JarBonus.AddBuyLimitKey(builder, BuyLimitKeyOffset);
			JarBonus.AddDayBuyLimite(builder, DayBuyLimite);
			JarBonus.AddMoneyValue(builder, MoneyValue);
			JarBonus.AddBuyMoneyType(builder, BuyMoneyType);
			JarBonus.AddGetItemsAndNum(builder, GetItemsAndNumOffset);
			JarBonus.AddExBonusJarID2(builder, ExBonusJarID_2);
			JarBonus.AddExBonusNum2(builder, ExBonusNum_2);
			JarBonus.AddExBonusJarID1(builder, ExBonusJarID_1);
			JarBonus.AddExBonusNum1(builder, ExBonusNum_1);
			JarBonus.AddJarEffect(builder, JarEffectOffset);
			JarBonus.AddJarImage(builder, JarImageOffset);
			JarBonus.AddFilter(builder, FilterOffset);
			JarBonus.AddType(builder, Type);
			JarBonus.AddName(builder, NameOffset);
			JarBonus.AddID(builder, ID);
			return JarBonus.EndJarBonus(builder);
		}

		// Token: 0x06003C20 RID: 15392 RVA: 0x000C90EC File Offset: 0x000C74EC
		public static void StartJarBonus(FlatBufferBuilder builder)
		{
			builder.StartObject(37);
		}

		// Token: 0x06003C21 RID: 15393 RVA: 0x000C90F6 File Offset: 0x000C74F6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003C22 RID: 15394 RVA: 0x000C9101 File Offset: 0x000C7501
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003C23 RID: 15395 RVA: 0x000C9112 File Offset: 0x000C7512
		public static void AddType(FlatBufferBuilder builder, JarBonus.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003C24 RID: 15396 RVA: 0x000C911D File Offset: 0x000C751D
		public static void AddFilter(FlatBufferBuilder builder, VectorOffset FilterOffset)
		{
			builder.AddOffset(3, FilterOffset.Value, 0);
		}

		// Token: 0x06003C25 RID: 15397 RVA: 0x000C9130 File Offset: 0x000C7530
		public static VectorOffset CreateFilterVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003C26 RID: 15398 RVA: 0x000C916D File Offset: 0x000C756D
		public static void StartFilterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003C27 RID: 15399 RVA: 0x000C9178 File Offset: 0x000C7578
		public static void AddJarImage(FlatBufferBuilder builder, StringOffset JarImageOffset)
		{
			builder.AddOffset(4, JarImageOffset.Value, 0);
		}

		// Token: 0x06003C28 RID: 15400 RVA: 0x000C9189 File Offset: 0x000C7589
		public static void AddJarEffect(FlatBufferBuilder builder, StringOffset JarEffectOffset)
		{
			builder.AddOffset(5, JarEffectOffset.Value, 0);
		}

		// Token: 0x06003C29 RID: 15401 RVA: 0x000C919A File Offset: 0x000C759A
		public static void AddExBonusNum1(FlatBufferBuilder builder, int ExBonusNum1)
		{
			builder.AddInt(6, ExBonusNum1, 0);
		}

		// Token: 0x06003C2A RID: 15402 RVA: 0x000C91A5 File Offset: 0x000C75A5
		public static void AddExBonusJarID1(FlatBufferBuilder builder, int ExBonusJarID1)
		{
			builder.AddInt(7, ExBonusJarID1, 0);
		}

		// Token: 0x06003C2B RID: 15403 RVA: 0x000C91B0 File Offset: 0x000C75B0
		public static void AddExBonusNum2(FlatBufferBuilder builder, int ExBonusNum2)
		{
			builder.AddInt(8, ExBonusNum2, 0);
		}

		// Token: 0x06003C2C RID: 15404 RVA: 0x000C91BB File Offset: 0x000C75BB
		public static void AddExBonusJarID2(FlatBufferBuilder builder, int ExBonusJarID2)
		{
			builder.AddInt(9, ExBonusJarID2, 0);
		}

		// Token: 0x06003C2D RID: 15405 RVA: 0x000C91C7 File Offset: 0x000C75C7
		public static void AddGetItemsAndNum(FlatBufferBuilder builder, VectorOffset GetItemsAndNumOffset)
		{
			builder.AddOffset(10, GetItemsAndNumOffset.Value, 0);
		}

		// Token: 0x06003C2E RID: 15406 RVA: 0x000C91DC File Offset: 0x000C75DC
		public static VectorOffset CreateGetItemsAndNumVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003C2F RID: 15407 RVA: 0x000C9222 File Offset: 0x000C7622
		public static void StartGetItemsAndNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003C30 RID: 15408 RVA: 0x000C922D File Offset: 0x000C762D
		public static void AddBuyMoneyType(FlatBufferBuilder builder, int BuyMoneyType)
		{
			builder.AddInt(11, BuyMoneyType, 0);
		}

		// Token: 0x06003C31 RID: 15409 RVA: 0x000C9239 File Offset: 0x000C7639
		public static void AddMoneyValue(FlatBufferBuilder builder, int MoneyValue)
		{
			builder.AddInt(12, MoneyValue, 0);
		}

		// Token: 0x06003C32 RID: 15410 RVA: 0x000C9245 File Offset: 0x000C7645
		public static void AddDayBuyLimite(FlatBufferBuilder builder, int DayBuyLimite)
		{
			builder.AddInt(13, DayBuyLimite, 0);
		}

		// Token: 0x06003C33 RID: 15411 RVA: 0x000C9251 File Offset: 0x000C7651
		public static void AddBuyLimitKey(FlatBufferBuilder builder, StringOffset BuyLimitKeyOffset)
		{
			builder.AddOffset(14, BuyLimitKeyOffset.Value, 0);
		}

		// Token: 0x06003C34 RID: 15412 RVA: 0x000C9263 File Offset: 0x000C7663
		public static void AddNeedExItem(FlatBufferBuilder builder, int NeedExItem)
		{
			builder.AddInt(15, NeedExItem, 0);
		}

		// Token: 0x06003C35 RID: 15413 RVA: 0x000C926F File Offset: 0x000C766F
		public static void AddExItemID(FlatBufferBuilder builder, int ExItemID)
		{
			builder.AddInt(16, ExItemID, 0);
		}

		// Token: 0x06003C36 RID: 15414 RVA: 0x000C927B File Offset: 0x000C767B
		public static void AddExItemCostNum(FlatBufferBuilder builder, int ExItemCostNum)
		{
			builder.AddInt(17, ExItemCostNum, 0);
		}

		// Token: 0x06003C37 RID: 15415 RVA: 0x000C9287 File Offset: 0x000C7687
		public static void AddComboBuyNum(FlatBufferBuilder builder, int ComboBuyNum)
		{
			builder.AddInt(18, ComboBuyNum, 0);
		}

		// Token: 0x06003C38 RID: 15416 RVA: 0x000C9293 File Offset: 0x000C7693
		public static void AddSingleBuyDiscount(FlatBufferBuilder builder, int SingleBuyDiscount)
		{
			builder.AddInt(19, SingleBuyDiscount, 0);
		}

		// Token: 0x06003C39 RID: 15417 RVA: 0x000C929F File Offset: 0x000C769F
		public static void AddComboBuyDiscount(FlatBufferBuilder builder, int ComboBuyDiscount)
		{
			builder.AddInt(20, ComboBuyDiscount, 0);
		}

		// Token: 0x06003C3A RID: 15418 RVA: 0x000C92AB File Offset: 0x000C76AB
		public static void AddCounterKey(FlatBufferBuilder builder, StringOffset CounterKeyOffset)
		{
			builder.AddOffset(21, CounterKeyOffset.Value, 0);
		}

		// Token: 0x06003C3B RID: 15419 RVA: 0x000C92BD File Offset: 0x000C76BD
		public static void AddGetPointType(FlatBufferBuilder builder, int GetPointType)
		{
			builder.AddInt(22, GetPointType, 0);
		}

		// Token: 0x06003C3C RID: 15420 RVA: 0x000C92C9 File Offset: 0x000C76C9
		public static void AddGetPointNum(FlatBufferBuilder builder, int GetPointNum)
		{
			builder.AddInt(23, GetPointNum, 0);
		}

		// Token: 0x06003C3D RID: 15421 RVA: 0x000C92D5 File Offset: 0x000C76D5
		public static void AddGetPointCrit(FlatBufferBuilder builder, StringOffset GetPointCritOffset)
		{
			builder.AddOffset(24, GetPointCritOffset.Value, 0);
		}

		// Token: 0x06003C3E RID: 15422 RVA: 0x000C92E7 File Offset: 0x000C76E7
		public static void AddMaxFreeCount(FlatBufferBuilder builder, int MaxFreeCount)
		{
			builder.AddInt(25, MaxFreeCount, 0);
		}

		// Token: 0x06003C3F RID: 15423 RVA: 0x000C92F3 File Offset: 0x000C76F3
		public static void AddFreeCD(FlatBufferBuilder builder, int FreeCD)
		{
			builder.AddInt(26, FreeCD, 0);
		}

		// Token: 0x06003C40 RID: 15424 RVA: 0x000C92FF File Offset: 0x000C76FF
		public static void AddFreeNumCounterKey(FlatBufferBuilder builder, StringOffset FreeNumCounterKeyOffset)
		{
			builder.AddOffset(27, FreeNumCounterKeyOffset.Value, 0);
		}

		// Token: 0x06003C41 RID: 15425 RVA: 0x000C9311 File Offset: 0x000C7711
		public static void AddNextFreeTimeCounterKey(FlatBufferBuilder builder, StringOffset NextFreeTimeCounterKeyOffset)
		{
			builder.AddOffset(28, NextFreeTimeCounterKeyOffset.Value, 0);
		}

		// Token: 0x06003C42 RID: 15426 RVA: 0x000C9323 File Offset: 0x000C7723
		public static void AddNeedRecord(FlatBufferBuilder builder, int NeedRecord)
		{
			builder.AddInt(29, NeedRecord, 0);
		}

		// Token: 0x06003C43 RID: 15427 RVA: 0x000C932F File Offset: 0x000C772F
		public static void AddActJarDisMaxNum(FlatBufferBuilder builder, int ActJarDisMaxNum)
		{
			builder.AddInt(30, ActJarDisMaxNum, 0);
		}

		// Token: 0x06003C44 RID: 15428 RVA: 0x000C933B File Offset: 0x000C773B
		public static void AddActJarDisReset(FlatBufferBuilder builder, int ActJarDisReset)
		{
			builder.AddInt(31, ActJarDisReset, 0);
		}

		// Token: 0x06003C45 RID: 15429 RVA: 0x000C9347 File Offset: 0x000C7747
		public static void AddActifactJarRewardTime(FlatBufferBuilder builder, int ActifactJarRewardTime)
		{
			builder.AddInt(32, ActifactJarRewardTime, 0);
		}

		// Token: 0x06003C46 RID: 15430 RVA: 0x000C9353 File Offset: 0x000C7753
		public static void AddJarGiftMustOutNum(FlatBufferBuilder builder, int JarGiftMustOutNum)
		{
			builder.AddInt(33, JarGiftMustOutNum, 0);
		}

		// Token: 0x06003C47 RID: 15431 RVA: 0x000C935F File Offset: 0x000C775F
		public static void AddCurCycleIsOutTreasKey(FlatBufferBuilder builder, StringOffset CurCycleIsOutTreasKeyOffset)
		{
			builder.AddOffset(34, CurCycleIsOutTreasKeyOffset.Value, 0);
		}

		// Token: 0x06003C48 RID: 15432 RVA: 0x000C9371 File Offset: 0x000C7771
		public static void AddJarGiftOutJarId(FlatBufferBuilder builder, int jarGiftOutJarId)
		{
			builder.AddInt(35, jarGiftOutJarId, 0);
		}

		// Token: 0x06003C49 RID: 15433 RVA: 0x000C937D File Offset: 0x000C777D
		public static void AddSmellType(FlatBufferBuilder builder, int SmellType)
		{
			builder.AddInt(36, SmellType, 0);
		}

		// Token: 0x06003C4A RID: 15434 RVA: 0x000C938C File Offset: 0x000C778C
		public static Offset<JarBonus> EndJarBonus(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<JarBonus>(value);
		}

		// Token: 0x06003C4B RID: 15435 RVA: 0x000C93A6 File Offset: 0x000C77A6
		public static void FinishJarBonusBuffer(FlatBufferBuilder builder, Offset<JarBonus> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017AB RID: 6059
		private Table __p = new Table();

		// Token: 0x040017AC RID: 6060
		private FlatBufferArray<int> FilterValue;

		// Token: 0x040017AD RID: 6061
		private FlatBufferArray<string> GetItemsAndNumValue;

		// Token: 0x020004C6 RID: 1222
		public enum eType
		{
			// Token: 0x040017AF RID: 6063
			NoneJar,
			// Token: 0x040017B0 RID: 6064
			MagicJar,
			// Token: 0x040017B1 RID: 6065
			MagicJar_Lv55 = 4,
			// Token: 0x040017B2 RID: 6066
			GoldJar = 2,
			// Token: 0x040017B3 RID: 6067
			BudoJar,
			// Token: 0x040017B4 RID: 6068
			EqrecoJar = 5,
			// Token: 0x040017B5 RID: 6069
			WingJar = 101,
			// Token: 0x040017B6 RID: 6070
			FashionJar,
			// Token: 0x040017B7 RID: 6071
			EquipJar
		}

		// Token: 0x020004C7 RID: 1223
		public enum eCrypt
		{
			// Token: 0x040017B9 RID: 6073
			code = 484252340
		}
	}
}
