using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200048E RID: 1166
	public class HireTask : IFlatbufferObject
	{
		// Token: 0x17000E48 RID: 3656
		// (get) Token: 0x06003897 RID: 14487 RVA: 0x000C075C File Offset: 0x000BEB5C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003898 RID: 14488 RVA: 0x000C0769 File Offset: 0x000BEB69
		public static HireTask GetRootAsHireTask(ByteBuffer _bb)
		{
			return HireTask.GetRootAsHireTask(_bb, new HireTask());
		}

		// Token: 0x06003899 RID: 14489 RVA: 0x000C0776 File Offset: 0x000BEB76
		public static HireTask GetRootAsHireTask(ByteBuffer _bb, HireTask obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600389A RID: 14490 RVA: 0x000C0792 File Offset: 0x000BEB92
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600389B RID: 14491 RVA: 0x000C07AC File Offset: 0x000BEBAC
		public HireTask __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E49 RID: 3657
		// (get) Token: 0x0600389C RID: 14492 RVA: 0x000C07B8 File Offset: 0x000BEBB8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E4A RID: 3658
		// (get) Token: 0x0600389D RID: 14493 RVA: 0x000C0804 File Offset: 0x000BEC04
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E4B RID: 3659
		// (get) Token: 0x0600389E RID: 14494 RVA: 0x000C0850 File Offset: 0x000BEC50
		public int FullCnt
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E4C RID: 3660
		// (get) Token: 0x0600389F RID: 14495 RVA: 0x000C089C File Offset: 0x000BEC9C
		public string Rewards
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060038A0 RID: 14496 RVA: 0x000C08DF File Offset: 0x000BECDF
		public ArraySegment<byte>? GetRewardsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000E4D RID: 3661
		// (get) Token: 0x060038A1 RID: 14497 RVA: 0x000C08F0 File Offset: 0x000BECF0
		public int RefreshType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E4E RID: 3662
		// (get) Token: 0x060038A2 RID: 14498 RVA: 0x000C093C File Offset: 0x000BED3C
		public int Identify
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060038A3 RID: 14499 RVA: 0x000C0988 File Offset: 0x000BED88
		public int ParamArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x060038A4 RID: 14500 RVA: 0x000C09D8 File Offset: 0x000BEDD8
		public int ParamLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038A5 RID: 14501 RVA: 0x000C0A0B File Offset: 0x000BEE0B
		public ArraySegment<byte>? GetParamBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000E50 RID: 3664
		// (get) Token: 0x060038A6 RID: 14502 RVA: 0x000C0A1A File Offset: 0x000BEE1A
		public FlatBufferArray<int> Param
		{
			get
			{
				if (this.ParamValue == null)
				{
					this.ParamValue = new FlatBufferArray<int>(new Func<int, int>(this.ParamArray), this.ParamLength);
				}
				return this.ParamValue;
			}
		}

		// Token: 0x17000E51 RID: 3665
		// (get) Token: 0x060038A7 RID: 14503 RVA: 0x000C0A4C File Offset: 0x000BEE4C
		public string Describe
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060038A8 RID: 14504 RVA: 0x000C0A8F File Offset: 0x000BEE8F
		public ArraySegment<byte>? GetDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000E52 RID: 3666
		// (get) Token: 0x060038A9 RID: 14505 RVA: 0x000C0AA0 File Offset: 0x000BEEA0
		public int Link
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (486286475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060038AA RID: 14506 RVA: 0x000C0AEC File Offset: 0x000BEEEC
		public static Offset<HireTask> CreateHireTask(FlatBufferBuilder builder, int ID = 0, int Type = 0, int FullCnt = 0, StringOffset RewardsOffset = default(StringOffset), int RefreshType = 0, int Identify = 0, VectorOffset ParamOffset = default(VectorOffset), StringOffset DescribeOffset = default(StringOffset), int Link = 0)
		{
			builder.StartObject(9);
			HireTask.AddLink(builder, Link);
			HireTask.AddDescribe(builder, DescribeOffset);
			HireTask.AddParam(builder, ParamOffset);
			HireTask.AddIdentify(builder, Identify);
			HireTask.AddRefreshType(builder, RefreshType);
			HireTask.AddRewards(builder, RewardsOffset);
			HireTask.AddFullCnt(builder, FullCnt);
			HireTask.AddType(builder, Type);
			HireTask.AddID(builder, ID);
			return HireTask.EndHireTask(builder);
		}

		// Token: 0x060038AB RID: 14507 RVA: 0x000C0B4C File Offset: 0x000BEF4C
		public static void StartHireTask(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060038AC RID: 14508 RVA: 0x000C0B56 File Offset: 0x000BEF56
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060038AD RID: 14509 RVA: 0x000C0B61 File Offset: 0x000BEF61
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060038AE RID: 14510 RVA: 0x000C0B6C File Offset: 0x000BEF6C
		public static void AddFullCnt(FlatBufferBuilder builder, int FullCnt)
		{
			builder.AddInt(2, FullCnt, 0);
		}

		// Token: 0x060038AF RID: 14511 RVA: 0x000C0B77 File Offset: 0x000BEF77
		public static void AddRewards(FlatBufferBuilder builder, StringOffset RewardsOffset)
		{
			builder.AddOffset(3, RewardsOffset.Value, 0);
		}

		// Token: 0x060038B0 RID: 14512 RVA: 0x000C0B88 File Offset: 0x000BEF88
		public static void AddRefreshType(FlatBufferBuilder builder, int RefreshType)
		{
			builder.AddInt(4, RefreshType, 0);
		}

		// Token: 0x060038B1 RID: 14513 RVA: 0x000C0B93 File Offset: 0x000BEF93
		public static void AddIdentify(FlatBufferBuilder builder, int Identify)
		{
			builder.AddInt(5, Identify, 0);
		}

		// Token: 0x060038B2 RID: 14514 RVA: 0x000C0B9E File Offset: 0x000BEF9E
		public static void AddParam(FlatBufferBuilder builder, VectorOffset ParamOffset)
		{
			builder.AddOffset(6, ParamOffset.Value, 0);
		}

		// Token: 0x060038B3 RID: 14515 RVA: 0x000C0BB0 File Offset: 0x000BEFB0
		public static VectorOffset CreateParamVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038B4 RID: 14516 RVA: 0x000C0BED File Offset: 0x000BEFED
		public static void StartParamVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038B5 RID: 14517 RVA: 0x000C0BF8 File Offset: 0x000BEFF8
		public static void AddDescribe(FlatBufferBuilder builder, StringOffset DescribeOffset)
		{
			builder.AddOffset(7, DescribeOffset.Value, 0);
		}

		// Token: 0x060038B6 RID: 14518 RVA: 0x000C0C09 File Offset: 0x000BF009
		public static void AddLink(FlatBufferBuilder builder, int Link)
		{
			builder.AddInt(8, Link, 0);
		}

		// Token: 0x060038B7 RID: 14519 RVA: 0x000C0C14 File Offset: 0x000BF014
		public static Offset<HireTask> EndHireTask(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HireTask>(value);
		}

		// Token: 0x060038B8 RID: 14520 RVA: 0x000C0C2E File Offset: 0x000BF02E
		public static void FinishHireTaskBuffer(FlatBufferBuilder builder, Offset<HireTask> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400160B RID: 5643
		private Table __p = new Table();

		// Token: 0x0400160C RID: 5644
		private FlatBufferArray<int> ParamValue;

		// Token: 0x0200048F RID: 1167
		public enum eCrypt
		{
			// Token: 0x0400160E RID: 5646
			code = 486286475
		}
	}
}
