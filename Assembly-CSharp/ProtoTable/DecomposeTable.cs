using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000373 RID: 883
	public class DecomposeTable : IFlatbufferObject
	{
		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x060025A0 RID: 9632 RVA: 0x0009388C File Offset: 0x00091C8C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060025A1 RID: 9633 RVA: 0x00093899 File Offset: 0x00091C99
		public static DecomposeTable GetRootAsDecomposeTable(ByteBuffer _bb)
		{
			return DecomposeTable.GetRootAsDecomposeTable(_bb, new DecomposeTable());
		}

		// Token: 0x060025A2 RID: 9634 RVA: 0x000938A6 File Offset: 0x00091CA6
		public static DecomposeTable GetRootAsDecomposeTable(ByteBuffer _bb, DecomposeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060025A3 RID: 9635 RVA: 0x000938C2 File Offset: 0x00091CC2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060025A4 RID: 9636 RVA: 0x000938DC File Offset: 0x00091CDC
		public DecomposeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x060025A5 RID: 9637 RVA: 0x000938E8 File Offset: 0x00091CE8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x060025A6 RID: 9638 RVA: 0x00093934 File Offset: 0x00091D34
		public DecomposeTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (DecomposeTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x060025A7 RID: 9639 RVA: 0x00093978 File Offset: 0x00091D78
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025A8 RID: 9640 RVA: 0x000939C4 File Offset: 0x00091DC4
		public int LvArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x060025A9 RID: 9641 RVA: 0x00093A14 File Offset: 0x00091E14
		public int LvLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060025AA RID: 9642 RVA: 0x00093A47 File Offset: 0x00091E47
		public ArraySegment<byte>? GetLvBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x060025AB RID: 9643 RVA: 0x00093A56 File Offset: 0x00091E56
		public FlatBufferArray<int> Lv
		{
			get
			{
				if (this.LvValue == null)
				{
					this.LvValue = new FlatBufferArray<int>(new Func<int, int>(this.LvArray), this.LvLength);
				}
				return this.LvValue;
			}
		}

		// Token: 0x060025AC RID: 9644 RVA: 0x00093A88 File Offset: 0x00091E88
		public int ColorMatNumArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x060025AD RID: 9645 RVA: 0x00093AD8 File Offset: 0x00091ED8
		public int ColorMatNumLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060025AE RID: 9646 RVA: 0x00093B0B File Offset: 0x00091F0B
		public ArraySegment<byte>? GetColorMatNumBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x060025AF RID: 9647 RVA: 0x00093B1A File Offset: 0x00091F1A
		public FlatBufferArray<int> ColorMatNum
		{
			get
			{
				if (this.ColorMatNumValue == null)
				{
					this.ColorMatNumValue = new FlatBufferArray<int>(new Func<int, int>(this.ColorMatNumArray), this.ColorMatNumLength);
				}
				return this.ColorMatNumValue;
			}
		}

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x060025B0 RID: 9648 RVA: 0x00093B4C File Offset: 0x00091F4C
		public int ColorMatId
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025B1 RID: 9649 RVA: 0x00093B98 File Offset: 0x00091F98
		public int ColorLessMatNumArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x060025B2 RID: 9650 RVA: 0x00093BE8 File Offset: 0x00091FE8
		public int ColorLessMatNumLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060025B3 RID: 9651 RVA: 0x00093C1B File Offset: 0x0009201B
		public ArraySegment<byte>? GetColorLessMatNumBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x060025B4 RID: 9652 RVA: 0x00093C2A File Offset: 0x0009202A
		public FlatBufferArray<int> ColorLessMatNum
		{
			get
			{
				if (this.ColorLessMatNumValue == null)
				{
					this.ColorLessMatNumValue = new FlatBufferArray<int>(new Func<int, int>(this.ColorLessMatNumArray), this.ColorLessMatNumLength);
				}
				return this.ColorLessMatNumValue;
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x060025B5 RID: 9653 RVA: 0x00093C5C File Offset: 0x0009205C
		public int ColorLessMatId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025B6 RID: 9654 RVA: 0x00093CA8 File Offset: 0x000920A8
		public int DogEyeNumArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x060025B7 RID: 9655 RVA: 0x00093CF8 File Offset: 0x000920F8
		public int DogEyeNumLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060025B8 RID: 9656 RVA: 0x00093D2B File Offset: 0x0009212B
		public ArraySegment<byte>? GetDogEyeNumBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x060025B9 RID: 9657 RVA: 0x00093D3A File Offset: 0x0009213A
		public FlatBufferArray<int> DogEyeNum
		{
			get
			{
				if (this.DogEyeNumValue == null)
				{
					this.DogEyeNumValue = new FlatBufferArray<int>(new Func<int, int>(this.DogEyeNumArray), this.DogEyeNumLength);
				}
				return this.DogEyeNumValue;
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x060025BA RID: 9658 RVA: 0x00093D6C File Offset: 0x0009216C
		public int DogEyeId
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025BB RID: 9659 RVA: 0x00093DB8 File Offset: 0x000921B8
		public string MagicItemNumArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x060025BC RID: 9660 RVA: 0x00093E00 File Offset: 0x00092200
		public int MagicItemNumLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x060025BD RID: 9661 RVA: 0x00093E33 File Offset: 0x00092233
		public FlatBufferArray<string> MagicItemNum
		{
			get
			{
				if (this.MagicItemNumValue == null)
				{
					this.MagicItemNumValue = new FlatBufferArray<string>(new Func<int, string>(this.MagicItemNumArray), this.MagicItemNumLength);
				}
				return this.MagicItemNumValue;
			}
		}

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x060025BE RID: 9662 RVA: 0x00093E64 File Offset: 0x00092264
		public int MagicItemId
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x060025BF RID: 9663 RVA: 0x00093EB0 File Offset: 0x000922B0
		public string PinkItemNum
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060025C0 RID: 9664 RVA: 0x00093EF3 File Offset: 0x000922F3
		public ArraySegment<byte>? GetPinkItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x060025C1 RID: 9665 RVA: 0x00093F04 File Offset: 0x00092304
		public int PinkItemId
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x060025C2 RID: 9666 RVA: 0x00093F50 File Offset: 0x00092350
		public string RedItemNum
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060025C3 RID: 9667 RVA: 0x00093F93 File Offset: 0x00092393
		public ArraySegment<byte>? GetRedItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x060025C4 RID: 9668 RVA: 0x00093FA4 File Offset: 0x000923A4
		public int RedItemId
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-477481969 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060025C5 RID: 9669 RVA: 0x00093FF0 File Offset: 0x000923F0
		public static Offset<DecomposeTable> CreateDecomposeTable(FlatBufferBuilder builder, int ID = 0, DecomposeTable.eColor Color = DecomposeTable.eColor.Color_None, int Color2 = 0, VectorOffset LvOffset = default(VectorOffset), VectorOffset ColorMatNumOffset = default(VectorOffset), int ColorMatId = 0, VectorOffset ColorLessMatNumOffset = default(VectorOffset), int ColorLessMatId = 0, VectorOffset DogEyeNumOffset = default(VectorOffset), int DogEyeId = 0, VectorOffset MagicItemNumOffset = default(VectorOffset), int MagicItemId = 0, StringOffset PinkItemNumOffset = default(StringOffset), int PinkItemId = 0, StringOffset RedItemNumOffset = default(StringOffset), int RedItemId = 0)
		{
			builder.StartObject(16);
			DecomposeTable.AddRedItemId(builder, RedItemId);
			DecomposeTable.AddRedItemNum(builder, RedItemNumOffset);
			DecomposeTable.AddPinkItemId(builder, PinkItemId);
			DecomposeTable.AddPinkItemNum(builder, PinkItemNumOffset);
			DecomposeTable.AddMagicItemId(builder, MagicItemId);
			DecomposeTable.AddMagicItemNum(builder, MagicItemNumOffset);
			DecomposeTable.AddDogEyeId(builder, DogEyeId);
			DecomposeTable.AddDogEyeNum(builder, DogEyeNumOffset);
			DecomposeTable.AddColorLessMatId(builder, ColorLessMatId);
			DecomposeTable.AddColorLessMatNum(builder, ColorLessMatNumOffset);
			DecomposeTable.AddColorMatId(builder, ColorMatId);
			DecomposeTable.AddColorMatNum(builder, ColorMatNumOffset);
			DecomposeTable.AddLv(builder, LvOffset);
			DecomposeTable.AddColor2(builder, Color2);
			DecomposeTable.AddColor(builder, Color);
			DecomposeTable.AddID(builder, ID);
			return DecomposeTable.EndDecomposeTable(builder);
		}

		// Token: 0x060025C6 RID: 9670 RVA: 0x00094088 File Offset: 0x00092488
		public static void StartDecomposeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(16);
		}

		// Token: 0x060025C7 RID: 9671 RVA: 0x00094092 File Offset: 0x00092492
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060025C8 RID: 9672 RVA: 0x0009409D File Offset: 0x0009249D
		public static void AddColor(FlatBufferBuilder builder, DecomposeTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x060025C9 RID: 9673 RVA: 0x000940A8 File Offset: 0x000924A8
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(2, Color2, 0);
		}

		// Token: 0x060025CA RID: 9674 RVA: 0x000940B3 File Offset: 0x000924B3
		public static void AddLv(FlatBufferBuilder builder, VectorOffset LvOffset)
		{
			builder.AddOffset(3, LvOffset.Value, 0);
		}

		// Token: 0x060025CB RID: 9675 RVA: 0x000940C4 File Offset: 0x000924C4
		public static VectorOffset CreateLvVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060025CC RID: 9676 RVA: 0x00094101 File Offset: 0x00092501
		public static void StartLvVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060025CD RID: 9677 RVA: 0x0009410C File Offset: 0x0009250C
		public static void AddColorMatNum(FlatBufferBuilder builder, VectorOffset ColorMatNumOffset)
		{
			builder.AddOffset(4, ColorMatNumOffset.Value, 0);
		}

		// Token: 0x060025CE RID: 9678 RVA: 0x00094120 File Offset: 0x00092520
		public static VectorOffset CreateColorMatNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060025CF RID: 9679 RVA: 0x0009415D File Offset: 0x0009255D
		public static void StartColorMatNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060025D0 RID: 9680 RVA: 0x00094168 File Offset: 0x00092568
		public static void AddColorMatId(FlatBufferBuilder builder, int ColorMatId)
		{
			builder.AddInt(5, ColorMatId, 0);
		}

		// Token: 0x060025D1 RID: 9681 RVA: 0x00094173 File Offset: 0x00092573
		public static void AddColorLessMatNum(FlatBufferBuilder builder, VectorOffset ColorLessMatNumOffset)
		{
			builder.AddOffset(6, ColorLessMatNumOffset.Value, 0);
		}

		// Token: 0x060025D2 RID: 9682 RVA: 0x00094184 File Offset: 0x00092584
		public static VectorOffset CreateColorLessMatNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060025D3 RID: 9683 RVA: 0x000941C1 File Offset: 0x000925C1
		public static void StartColorLessMatNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060025D4 RID: 9684 RVA: 0x000941CC File Offset: 0x000925CC
		public static void AddColorLessMatId(FlatBufferBuilder builder, int ColorLessMatId)
		{
			builder.AddInt(7, ColorLessMatId, 0);
		}

		// Token: 0x060025D5 RID: 9685 RVA: 0x000941D7 File Offset: 0x000925D7
		public static void AddDogEyeNum(FlatBufferBuilder builder, VectorOffset DogEyeNumOffset)
		{
			builder.AddOffset(8, DogEyeNumOffset.Value, 0);
		}

		// Token: 0x060025D6 RID: 9686 RVA: 0x000941E8 File Offset: 0x000925E8
		public static VectorOffset CreateDogEyeNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060025D7 RID: 9687 RVA: 0x00094225 File Offset: 0x00092625
		public static void StartDogEyeNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060025D8 RID: 9688 RVA: 0x00094230 File Offset: 0x00092630
		public static void AddDogEyeId(FlatBufferBuilder builder, int DogEyeId)
		{
			builder.AddInt(9, DogEyeId, 0);
		}

		// Token: 0x060025D9 RID: 9689 RVA: 0x0009423C File Offset: 0x0009263C
		public static void AddMagicItemNum(FlatBufferBuilder builder, VectorOffset MagicItemNumOffset)
		{
			builder.AddOffset(10, MagicItemNumOffset.Value, 0);
		}

		// Token: 0x060025DA RID: 9690 RVA: 0x00094250 File Offset: 0x00092650
		public static VectorOffset CreateMagicItemNumVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060025DB RID: 9691 RVA: 0x00094296 File Offset: 0x00092696
		public static void StartMagicItemNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x000942A1 File Offset: 0x000926A1
		public static void AddMagicItemId(FlatBufferBuilder builder, int MagicItemId)
		{
			builder.AddInt(11, MagicItemId, 0);
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x000942AD File Offset: 0x000926AD
		public static void AddPinkItemNum(FlatBufferBuilder builder, StringOffset PinkItemNumOffset)
		{
			builder.AddOffset(12, PinkItemNumOffset.Value, 0);
		}

		// Token: 0x060025DE RID: 9694 RVA: 0x000942BF File Offset: 0x000926BF
		public static void AddPinkItemId(FlatBufferBuilder builder, int PinkItemId)
		{
			builder.AddInt(13, PinkItemId, 0);
		}

		// Token: 0x060025DF RID: 9695 RVA: 0x000942CB File Offset: 0x000926CB
		public static void AddRedItemNum(FlatBufferBuilder builder, StringOffset RedItemNumOffset)
		{
			builder.AddOffset(14, RedItemNumOffset.Value, 0);
		}

		// Token: 0x060025E0 RID: 9696 RVA: 0x000942DD File Offset: 0x000926DD
		public static void AddRedItemId(FlatBufferBuilder builder, int RedItemId)
		{
			builder.AddInt(15, RedItemId, 0);
		}

		// Token: 0x060025E1 RID: 9697 RVA: 0x000942EC File Offset: 0x000926EC
		public static Offset<DecomposeTable> EndDecomposeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DecomposeTable>(value);
		}

		// Token: 0x060025E2 RID: 9698 RVA: 0x00094306 File Offset: 0x00092706
		public static void FinishDecomposeTableBuffer(FlatBufferBuilder builder, Offset<DecomposeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001178 RID: 4472
		private Table __p = new Table();

		// Token: 0x04001179 RID: 4473
		private FlatBufferArray<int> LvValue;

		// Token: 0x0400117A RID: 4474
		private FlatBufferArray<int> ColorMatNumValue;

		// Token: 0x0400117B RID: 4475
		private FlatBufferArray<int> ColorLessMatNumValue;

		// Token: 0x0400117C RID: 4476
		private FlatBufferArray<int> DogEyeNumValue;

		// Token: 0x0400117D RID: 4477
		private FlatBufferArray<string> MagicItemNumValue;

		// Token: 0x02000374 RID: 884
		public enum eColor
		{
			// Token: 0x0400117F RID: 4479
			Color_None,
			// Token: 0x04001180 RID: 4480
			WHITE,
			// Token: 0x04001181 RID: 4481
			BLUE,
			// Token: 0x04001182 RID: 4482
			PURPLE,
			// Token: 0x04001183 RID: 4483
			GREEN,
			// Token: 0x04001184 RID: 4484
			PINK,
			// Token: 0x04001185 RID: 4485
			YELLOW
		}

		// Token: 0x02000375 RID: 885
		public enum eCrypt
		{
			// Token: 0x04001187 RID: 4487
			code = -477481969
		}
	}
}
