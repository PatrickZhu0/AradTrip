using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004ED RID: 1261
	public class MallLimitTimeActivity : IFlatbufferObject
	{
		// Token: 0x17001101 RID: 4353
		// (get) Token: 0x06004090 RID: 16528 RVA: 0x000D3E30 File Offset: 0x000D2230
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004091 RID: 16529 RVA: 0x000D3E3D File Offset: 0x000D223D
		public static MallLimitTimeActivity GetRootAsMallLimitTimeActivity(ByteBuffer _bb)
		{
			return MallLimitTimeActivity.GetRootAsMallLimitTimeActivity(_bb, new MallLimitTimeActivity());
		}

		// Token: 0x06004092 RID: 16530 RVA: 0x000D3E4A File Offset: 0x000D224A
		public static MallLimitTimeActivity GetRootAsMallLimitTimeActivity(ByteBuffer _bb, MallLimitTimeActivity obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004093 RID: 16531 RVA: 0x000D3E66 File Offset: 0x000D2266
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004094 RID: 16532 RVA: 0x000D3E80 File Offset: 0x000D2280
		public MallLimitTimeActivity __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001102 RID: 4354
		// (get) Token: 0x06004095 RID: 16533 RVA: 0x000D3E8C File Offset: 0x000D228C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2057469539 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001103 RID: 4355
		// (get) Token: 0x06004096 RID: 16534 RVA: 0x000D3ED8 File Offset: 0x000D22D8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004097 RID: 16535 RVA: 0x000D3F1A File Offset: 0x000D231A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001104 RID: 4356
		// (get) Token: 0x06004098 RID: 16536 RVA: 0x000D3F28 File Offset: 0x000D2328
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004099 RID: 16537 RVA: 0x000D3F6A File Offset: 0x000D236A
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001105 RID: 4357
		// (get) Token: 0x0600409A RID: 16538 RVA: 0x000D3F78 File Offset: 0x000D2378
		public string BackgroundImgPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600409B RID: 16539 RVA: 0x000D3FBB File Offset: 0x000D23BB
		public ArraySegment<byte>? GetBackgroundImgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001106 RID: 4358
		// (get) Token: 0x0600409C RID: 16540 RVA: 0x000D3FCC File Offset: 0x000D23CC
		public MallLimitTimeActivity.eActivityType ActivityType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (MallLimitTimeActivity.eActivityType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001107 RID: 4359
		// (get) Token: 0x0600409D RID: 16541 RVA: 0x000D4010 File Offset: 0x000D2410
		public string DateTimePath
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600409E RID: 16542 RVA: 0x000D4053 File Offset: 0x000D2453
		public ArraySegment<byte>? GetDateTimePathBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001108 RID: 4360
		// (get) Token: 0x0600409F RID: 16543 RVA: 0x000D4064 File Offset: 0x000D2464
		public int IconPosX
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2057469539 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001109 RID: 4361
		// (get) Token: 0x060040A0 RID: 16544 RVA: 0x000D40B0 File Offset: 0x000D24B0
		public int IconPosY
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-2057469539 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700110A RID: 4362
		// (get) Token: 0x060040A1 RID: 16545 RVA: 0x000D40FC File Offset: 0x000D24FC
		public string ToggleName
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040A2 RID: 16546 RVA: 0x000D413F File Offset: 0x000D253F
		public ArraySegment<byte>? GetToggleNameBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700110B RID: 4363
		// (get) Token: 0x060040A3 RID: 16547 RVA: 0x000D4150 File Offset: 0x000D2550
		public string ToggleIconPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040A4 RID: 16548 RVA: 0x000D4193 File Offset: 0x000D2593
		public ArraySegment<byte>? GetToggleIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700110C RID: 4364
		// (get) Token: 0x060040A5 RID: 16549 RVA: 0x000D41A4 File Offset: 0x000D25A4
		public string ToggleIconPathIsOn
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040A6 RID: 16550 RVA: 0x000D41E7 File Offset: 0x000D25E7
		public ArraySegment<byte>? GetToggleIconPathIsOnBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700110D RID: 4365
		// (get) Token: 0x060040A7 RID: 16551 RVA: 0x000D41F8 File Offset: 0x000D25F8
		public string ToggleHotIcon
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040A8 RID: 16552 RVA: 0x000D423B File Offset: 0x000D263B
		public ArraySegment<byte>? GetToggleHotIconBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700110E RID: 4366
		// (get) Token: 0x060040A9 RID: 16553 RVA: 0x000D424C File Offset: 0x000D264C
		public string TimeTips
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040AA RID: 16554 RVA: 0x000D428F File Offset: 0x000D268F
		public ArraySegment<byte>? GetTimeTipsBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700110F RID: 4367
		// (get) Token: 0x060040AB RID: 16555 RVA: 0x000D42A0 File Offset: 0x000D26A0
		public string BGPath
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040AC RID: 16556 RVA: 0x000D42E3 File Offset: 0x000D26E3
		public ArraySegment<byte>? GetBGPathBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17001110 RID: 4368
		// (get) Token: 0x060040AD RID: 16557 RVA: 0x000D42F4 File Offset: 0x000D26F4
		public string PricePath
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040AE RID: 16558 RVA: 0x000D4337 File Offset: 0x000D2737
		public ArraySegment<byte>? GetPricePathBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17001111 RID: 4369
		// (get) Token: 0x060040AF RID: 16559 RVA: 0x000D4348 File Offset: 0x000D2748
		public MallLimitTimeActivity.eActivityMode ActivityMode
		{
			get
			{
				int num = this.__p.__offset(34);
				return (MallLimitTimeActivity.eActivityMode)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001112 RID: 4370
		// (get) Token: 0x060040B0 RID: 16560 RVA: 0x000D438C File Offset: 0x000D278C
		public string ModePrefabIcon
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040B1 RID: 16561 RVA: 0x000D43CF File Offset: 0x000D27CF
		public ArraySegment<byte>? GetModePrefabIconBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17001113 RID: 4371
		// (get) Token: 0x060040B2 RID: 16562 RVA: 0x000D43E0 File Offset: 0x000D27E0
		public string FashionTips
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040B3 RID: 16563 RVA: 0x000D4423 File Offset: 0x000D2823
		public ArraySegment<byte>? GetFashionTipsBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17001114 RID: 4372
		// (get) Token: 0x060040B4 RID: 16564 RVA: 0x000D4434 File Offset: 0x000D2834
		public string FashionName
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040B5 RID: 16565 RVA: 0x000D4477 File Offset: 0x000D2877
		public ArraySegment<byte>? GetFashionNameBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17001115 RID: 4373
		// (get) Token: 0x060040B6 RID: 16566 RVA: 0x000D4488 File Offset: 0x000D2888
		public MallLimitTimeActivity.eBuyLink BuyLink
		{
			get
			{
				int num = this.__p.__offset(42);
				return (MallLimitTimeActivity.eBuyLink)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001116 RID: 4374
		// (get) Token: 0x060040B7 RID: 16567 RVA: 0x000D44CC File Offset: 0x000D28CC
		public int IsExhanged
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-2057469539 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060040B8 RID: 16568 RVA: 0x000D4518 File Offset: 0x000D2918
		public static Offset<MallLimitTimeActivity> CreateMallLimitTimeActivity(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset IconPathOffset = default(StringOffset), StringOffset BackgroundImgPathOffset = default(StringOffset), MallLimitTimeActivity.eActivityType ActivityType = MallLimitTimeActivity.eActivityType.ActivityType_None, StringOffset DateTimePathOffset = default(StringOffset), int IconPosX = 0, int IconPosY = 0, StringOffset ToggleNameOffset = default(StringOffset), StringOffset ToggleIconPathOffset = default(StringOffset), StringOffset ToggleIconPathIsOnOffset = default(StringOffset), StringOffset ToggleHotIconOffset = default(StringOffset), StringOffset TimeTipsOffset = default(StringOffset), StringOffset BGPathOffset = default(StringOffset), StringOffset PricePathOffset = default(StringOffset), MallLimitTimeActivity.eActivityMode ActivityMode = MallLimitTimeActivity.eActivityMode.ActivityMode_None, StringOffset ModePrefabIconOffset = default(StringOffset), StringOffset FashionTipsOffset = default(StringOffset), StringOffset FashionNameOffset = default(StringOffset), MallLimitTimeActivity.eBuyLink BuyLink = MallLimitTimeActivity.eBuyLink.Direct_Buy, int IsExhanged = 0)
		{
			builder.StartObject(21);
			MallLimitTimeActivity.AddIsExhanged(builder, IsExhanged);
			MallLimitTimeActivity.AddBuyLink(builder, BuyLink);
			MallLimitTimeActivity.AddFashionName(builder, FashionNameOffset);
			MallLimitTimeActivity.AddFashionTips(builder, FashionTipsOffset);
			MallLimitTimeActivity.AddModePrefabIcon(builder, ModePrefabIconOffset);
			MallLimitTimeActivity.AddActivityMode(builder, ActivityMode);
			MallLimitTimeActivity.AddPricePath(builder, PricePathOffset);
			MallLimitTimeActivity.AddBGPath(builder, BGPathOffset);
			MallLimitTimeActivity.AddTimeTips(builder, TimeTipsOffset);
			MallLimitTimeActivity.AddToggleHotIcon(builder, ToggleHotIconOffset);
			MallLimitTimeActivity.AddToggleIconPathIsOn(builder, ToggleIconPathIsOnOffset);
			MallLimitTimeActivity.AddToggleIconPath(builder, ToggleIconPathOffset);
			MallLimitTimeActivity.AddToggleName(builder, ToggleNameOffset);
			MallLimitTimeActivity.AddIconPosY(builder, IconPosY);
			MallLimitTimeActivity.AddIconPosX(builder, IconPosX);
			MallLimitTimeActivity.AddDateTimePath(builder, DateTimePathOffset);
			MallLimitTimeActivity.AddActivityType(builder, ActivityType);
			MallLimitTimeActivity.AddBackgroundImgPath(builder, BackgroundImgPathOffset);
			MallLimitTimeActivity.AddIconPath(builder, IconPathOffset);
			MallLimitTimeActivity.AddName(builder, NameOffset);
			MallLimitTimeActivity.AddID(builder, ID);
			return MallLimitTimeActivity.EndMallLimitTimeActivity(builder);
		}

		// Token: 0x060040B9 RID: 16569 RVA: 0x000D45D8 File Offset: 0x000D29D8
		public static void StartMallLimitTimeActivity(FlatBufferBuilder builder)
		{
			builder.StartObject(21);
		}

		// Token: 0x060040BA RID: 16570 RVA: 0x000D45E2 File Offset: 0x000D29E2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060040BB RID: 16571 RVA: 0x000D45ED File Offset: 0x000D29ED
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060040BC RID: 16572 RVA: 0x000D45FE File Offset: 0x000D29FE
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(2, IconPathOffset.Value, 0);
		}

		// Token: 0x060040BD RID: 16573 RVA: 0x000D460F File Offset: 0x000D2A0F
		public static void AddBackgroundImgPath(FlatBufferBuilder builder, StringOffset BackgroundImgPathOffset)
		{
			builder.AddOffset(3, BackgroundImgPathOffset.Value, 0);
		}

		// Token: 0x060040BE RID: 16574 RVA: 0x000D4620 File Offset: 0x000D2A20
		public static void AddActivityType(FlatBufferBuilder builder, MallLimitTimeActivity.eActivityType ActivityType)
		{
			builder.AddInt(4, (int)ActivityType, 0);
		}

		// Token: 0x060040BF RID: 16575 RVA: 0x000D462B File Offset: 0x000D2A2B
		public static void AddDateTimePath(FlatBufferBuilder builder, StringOffset DateTimePathOffset)
		{
			builder.AddOffset(5, DateTimePathOffset.Value, 0);
		}

		// Token: 0x060040C0 RID: 16576 RVA: 0x000D463C File Offset: 0x000D2A3C
		public static void AddIconPosX(FlatBufferBuilder builder, int IconPosX)
		{
			builder.AddInt(6, IconPosX, 0);
		}

		// Token: 0x060040C1 RID: 16577 RVA: 0x000D4647 File Offset: 0x000D2A47
		public static void AddIconPosY(FlatBufferBuilder builder, int IconPosY)
		{
			builder.AddInt(7, IconPosY, 0);
		}

		// Token: 0x060040C2 RID: 16578 RVA: 0x000D4652 File Offset: 0x000D2A52
		public static void AddToggleName(FlatBufferBuilder builder, StringOffset ToggleNameOffset)
		{
			builder.AddOffset(8, ToggleNameOffset.Value, 0);
		}

		// Token: 0x060040C3 RID: 16579 RVA: 0x000D4663 File Offset: 0x000D2A63
		public static void AddToggleIconPath(FlatBufferBuilder builder, StringOffset ToggleIconPathOffset)
		{
			builder.AddOffset(9, ToggleIconPathOffset.Value, 0);
		}

		// Token: 0x060040C4 RID: 16580 RVA: 0x000D4675 File Offset: 0x000D2A75
		public static void AddToggleIconPathIsOn(FlatBufferBuilder builder, StringOffset ToggleIconPathIsOnOffset)
		{
			builder.AddOffset(10, ToggleIconPathIsOnOffset.Value, 0);
		}

		// Token: 0x060040C5 RID: 16581 RVA: 0x000D4687 File Offset: 0x000D2A87
		public static void AddToggleHotIcon(FlatBufferBuilder builder, StringOffset ToggleHotIconOffset)
		{
			builder.AddOffset(11, ToggleHotIconOffset.Value, 0);
		}

		// Token: 0x060040C6 RID: 16582 RVA: 0x000D4699 File Offset: 0x000D2A99
		public static void AddTimeTips(FlatBufferBuilder builder, StringOffset TimeTipsOffset)
		{
			builder.AddOffset(12, TimeTipsOffset.Value, 0);
		}

		// Token: 0x060040C7 RID: 16583 RVA: 0x000D46AB File Offset: 0x000D2AAB
		public static void AddBGPath(FlatBufferBuilder builder, StringOffset BGPathOffset)
		{
			builder.AddOffset(13, BGPathOffset.Value, 0);
		}

		// Token: 0x060040C8 RID: 16584 RVA: 0x000D46BD File Offset: 0x000D2ABD
		public static void AddPricePath(FlatBufferBuilder builder, StringOffset PricePathOffset)
		{
			builder.AddOffset(14, PricePathOffset.Value, 0);
		}

		// Token: 0x060040C9 RID: 16585 RVA: 0x000D46CF File Offset: 0x000D2ACF
		public static void AddActivityMode(FlatBufferBuilder builder, MallLimitTimeActivity.eActivityMode ActivityMode)
		{
			builder.AddInt(15, (int)ActivityMode, 0);
		}

		// Token: 0x060040CA RID: 16586 RVA: 0x000D46DB File Offset: 0x000D2ADB
		public static void AddModePrefabIcon(FlatBufferBuilder builder, StringOffset ModePrefabIconOffset)
		{
			builder.AddOffset(16, ModePrefabIconOffset.Value, 0);
		}

		// Token: 0x060040CB RID: 16587 RVA: 0x000D46ED File Offset: 0x000D2AED
		public static void AddFashionTips(FlatBufferBuilder builder, StringOffset FashionTipsOffset)
		{
			builder.AddOffset(17, FashionTipsOffset.Value, 0);
		}

		// Token: 0x060040CC RID: 16588 RVA: 0x000D46FF File Offset: 0x000D2AFF
		public static void AddFashionName(FlatBufferBuilder builder, StringOffset FashionNameOffset)
		{
			builder.AddOffset(18, FashionNameOffset.Value, 0);
		}

		// Token: 0x060040CD RID: 16589 RVA: 0x000D4711 File Offset: 0x000D2B11
		public static void AddBuyLink(FlatBufferBuilder builder, MallLimitTimeActivity.eBuyLink BuyLink)
		{
			builder.AddInt(19, (int)BuyLink, 0);
		}

		// Token: 0x060040CE RID: 16590 RVA: 0x000D471D File Offset: 0x000D2B1D
		public static void AddIsExhanged(FlatBufferBuilder builder, int IsExhanged)
		{
			builder.AddInt(20, IsExhanged, 0);
		}

		// Token: 0x060040CF RID: 16591 RVA: 0x000D472C File Offset: 0x000D2B2C
		public static Offset<MallLimitTimeActivity> EndMallLimitTimeActivity(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MallLimitTimeActivity>(value);
		}

		// Token: 0x060040D0 RID: 16592 RVA: 0x000D4746 File Offset: 0x000D2B46
		public static void FinishMallLimitTimeActivityBuffer(FlatBufferBuilder builder, Offset<MallLimitTimeActivity> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001823 RID: 6179
		private Table __p = new Table();

		// Token: 0x020004EE RID: 1262
		public enum eActivityType
		{
			// Token: 0x04001825 RID: 6181
			ActivityType_None,
			// Token: 0x04001826 RID: 6182
			One_Act_Pet = 70000,
			// Token: 0x04001827 RID: 6183
			One_Act_MagicCard,
			// Token: 0x04001828 RID: 6184
			Two_Act_Guoqing,
			// Token: 0x04001829 RID: 6185
			Two_Act_feiying,
			// Token: 0x0400182A RID: 6186
			Two_Act_zhanhun,
			// Token: 0x0400182B RID: 6187
			Two_Act_jiguang
		}

		// Token: 0x020004EF RID: 1263
		public enum eActivityMode
		{
			// Token: 0x0400182D RID: 6189
			ActivityMode_None,
			// Token: 0x0400182E RID: 6190
			Fashion,
			// Token: 0x0400182F RID: 6191
			Pet
		}

		// Token: 0x020004F0 RID: 1264
		public enum eBuyLink
		{
			// Token: 0x04001831 RID: 6193
			Direct_Buy,
			// Token: 0x04001832 RID: 6194
			Go_To_Mall_Limit_Buy,
			// Token: 0x04001833 RID: 6195
			Go_To_Prop_Mall_Limit,
			// Token: 0x04001834 RID: 6196
			Go_To_Dungeon
		}

		// Token: 0x020004F1 RID: 1265
		public enum eCrypt
		{
			// Token: 0x04001836 RID: 6198
			code = -2057469539
		}
	}
}
