using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000432 RID: 1074
	public class FashionComposeTable : IFlatbufferObject
	{
		// Token: 0x17000C83 RID: 3203
		// (get) Token: 0x0600332A RID: 13098 RVA: 0x000B3EC4 File Offset: 0x000B22C4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600332B RID: 13099 RVA: 0x000B3ED1 File Offset: 0x000B22D1
		public static FashionComposeTable GetRootAsFashionComposeTable(ByteBuffer _bb)
		{
			return FashionComposeTable.GetRootAsFashionComposeTable(_bb, new FashionComposeTable());
		}

		// Token: 0x0600332C RID: 13100 RVA: 0x000B3EDE File Offset: 0x000B22DE
		public static FashionComposeTable GetRootAsFashionComposeTable(ByteBuffer _bb, FashionComposeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600332D RID: 13101 RVA: 0x000B3EFA File Offset: 0x000B22FA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600332E RID: 13102 RVA: 0x000B3F14 File Offset: 0x000B2314
		public FashionComposeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C84 RID: 3204
		// (get) Token: 0x0600332F RID: 13103 RVA: 0x000B3F20 File Offset: 0x000B2320
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C85 RID: 3205
		// (get) Token: 0x06003330 RID: 13104 RVA: 0x000B3F6C File Offset: 0x000B236C
		public int Occu
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C86 RID: 3206
		// (get) Token: 0x06003331 RID: 13105 RVA: 0x000B3FB8 File Offset: 0x000B23B8
		public int SuitID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C87 RID: 3207
		// (get) Token: 0x06003332 RID: 13106 RVA: 0x000B4004 File Offset: 0x000B2404
		public int Color
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C88 RID: 3208
		// (get) Token: 0x06003333 RID: 13107 RVA: 0x000B4050 File Offset: 0x000B2450
		public int Part
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C89 RID: 3209
		// (get) Token: 0x06003334 RID: 13108 RVA: 0x000B409C File Offset: 0x000B249C
		public int ComposeColor
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C8A RID: 3210
		// (get) Token: 0x06003335 RID: 13109 RVA: 0x000B40E8 File Offset: 0x000B24E8
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C8B RID: 3211
		// (get) Token: 0x06003336 RID: 13110 RVA: 0x000B4134 File Offset: 0x000B2534
		public int AvatarType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C8C RID: 3212
		// (get) Token: 0x06003337 RID: 13111 RVA: 0x000B4180 File Offset: 0x000B2580
		public int DefaultAvatar
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-263444806 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003338 RID: 13112 RVA: 0x000B41CC File Offset: 0x000B25CC
		public static Offset<FashionComposeTable> CreateFashionComposeTable(FlatBufferBuilder builder, int ID = 0, int Occu = 0, int SuitID = 0, int Color = 0, int Part = 0, int ComposeColor = 0, int Weight = 0, int AvatarType = 0, int DefaultAvatar = 0)
		{
			builder.StartObject(9);
			FashionComposeTable.AddDefaultAvatar(builder, DefaultAvatar);
			FashionComposeTable.AddAvatarType(builder, AvatarType);
			FashionComposeTable.AddWeight(builder, Weight);
			FashionComposeTable.AddComposeColor(builder, ComposeColor);
			FashionComposeTable.AddPart(builder, Part);
			FashionComposeTable.AddColor(builder, Color);
			FashionComposeTable.AddSuitID(builder, SuitID);
			FashionComposeTable.AddOccu(builder, Occu);
			FashionComposeTable.AddID(builder, ID);
			return FashionComposeTable.EndFashionComposeTable(builder);
		}

		// Token: 0x06003339 RID: 13113 RVA: 0x000B422C File Offset: 0x000B262C
		public static void StartFashionComposeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x0600333A RID: 13114 RVA: 0x000B4236 File Offset: 0x000B2636
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600333B RID: 13115 RVA: 0x000B4241 File Offset: 0x000B2641
		public static void AddOccu(FlatBufferBuilder builder, int Occu)
		{
			builder.AddInt(1, Occu, 0);
		}

		// Token: 0x0600333C RID: 13116 RVA: 0x000B424C File Offset: 0x000B264C
		public static void AddSuitID(FlatBufferBuilder builder, int SuitID)
		{
			builder.AddInt(2, SuitID, 0);
		}

		// Token: 0x0600333D RID: 13117 RVA: 0x000B4257 File Offset: 0x000B2657
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(3, Color, 0);
		}

		// Token: 0x0600333E RID: 13118 RVA: 0x000B4262 File Offset: 0x000B2662
		public static void AddPart(FlatBufferBuilder builder, int Part)
		{
			builder.AddInt(4, Part, 0);
		}

		// Token: 0x0600333F RID: 13119 RVA: 0x000B426D File Offset: 0x000B266D
		public static void AddComposeColor(FlatBufferBuilder builder, int ComposeColor)
		{
			builder.AddInt(5, ComposeColor, 0);
		}

		// Token: 0x06003340 RID: 13120 RVA: 0x000B4278 File Offset: 0x000B2678
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(6, Weight, 0);
		}

		// Token: 0x06003341 RID: 13121 RVA: 0x000B4283 File Offset: 0x000B2683
		public static void AddAvatarType(FlatBufferBuilder builder, int AvatarType)
		{
			builder.AddInt(7, AvatarType, 0);
		}

		// Token: 0x06003342 RID: 13122 RVA: 0x000B428E File Offset: 0x000B268E
		public static void AddDefaultAvatar(FlatBufferBuilder builder, int DefaultAvatar)
		{
			builder.AddInt(8, DefaultAvatar, 0);
		}

		// Token: 0x06003343 RID: 13123 RVA: 0x000B429C File Offset: 0x000B269C
		public static Offset<FashionComposeTable> EndFashionComposeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionComposeTable>(value);
		}

		// Token: 0x06003344 RID: 13124 RVA: 0x000B42B6 File Offset: 0x000B26B6
		public static void FinishFashionComposeTableBuffer(FlatBufferBuilder builder, Offset<FashionComposeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014E3 RID: 5347
		private Table __p = new Table();

		// Token: 0x02000433 RID: 1075
		public enum eCrypt
		{
			// Token: 0x040014E5 RID: 5349
			code = -263444806
		}
	}
}
