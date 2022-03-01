using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200059F RID: 1439
	public class ScreenShakeTable : IFlatbufferObject
	{
		// Token: 0x17001433 RID: 5171
		// (get) Token: 0x06004A6A RID: 19050 RVA: 0x000EA43C File Offset: 0x000E883C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004A6B RID: 19051 RVA: 0x000EA449 File Offset: 0x000E8849
		public static ScreenShakeTable GetRootAsScreenShakeTable(ByteBuffer _bb)
		{
			return ScreenShakeTable.GetRootAsScreenShakeTable(_bb, new ScreenShakeTable());
		}

		// Token: 0x06004A6C RID: 19052 RVA: 0x000EA456 File Offset: 0x000E8856
		public static ScreenShakeTable GetRootAsScreenShakeTable(ByteBuffer _bb, ScreenShakeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004A6D RID: 19053 RVA: 0x000EA472 File Offset: 0x000E8872
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004A6E RID: 19054 RVA: 0x000EA48C File Offset: 0x000E888C
		public ScreenShakeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001434 RID: 5172
		// (get) Token: 0x06004A6F RID: 19055 RVA: 0x000EA498 File Offset: 0x000E8898
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001435 RID: 5173
		// (get) Token: 0x06004A70 RID: 19056 RVA: 0x000EA4E4 File Offset: 0x000E88E4
		public int Mode
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001436 RID: 5174
		// (get) Token: 0x06004A71 RID: 19057 RVA: 0x000EA530 File Offset: 0x000E8930
		public int Radius
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001437 RID: 5175
		// (get) Token: 0x06004A72 RID: 19058 RVA: 0x000EA57C File Offset: 0x000E897C
		public int TotalTime
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001438 RID: 5176
		// (get) Token: 0x06004A73 RID: 19059 RVA: 0x000EA5C8 File Offset: 0x000E89C8
		public int Num
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001439 RID: 5177
		// (get) Token: 0x06004A74 RID: 19060 RVA: 0x000EA614 File Offset: 0x000E8A14
		public int Xrange
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700143A RID: 5178
		// (get) Token: 0x06004A75 RID: 19061 RVA: 0x000EA660 File Offset: 0x000E8A60
		public int Yrange
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700143B RID: 5179
		// (get) Token: 0x06004A76 RID: 19062 RVA: 0x000EA6AC File Offset: 0x000E8AAC
		public int Decelerate
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700143C RID: 5180
		// (get) Token: 0x06004A77 RID: 19063 RVA: 0x000EA6F8 File Offset: 0x000E8AF8
		public int Xreduce
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700143D RID: 5181
		// (get) Token: 0x06004A78 RID: 19064 RVA: 0x000EA744 File Offset: 0x000E8B44
		public int Yreduce
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700143E RID: 5182
		// (get) Token: 0x06004A79 RID: 19065 RVA: 0x000EA790 File Offset: 0x000E8B90
		public int CDTime
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-612408714 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004A7A RID: 19066 RVA: 0x000EA7DC File Offset: 0x000E8BDC
		public static Offset<ScreenShakeTable> CreateScreenShakeTable(FlatBufferBuilder builder, int ID = 0, int Mode = 0, int Radius = 0, int TotalTime = 0, int Num = 0, int Xrange = 0, int Yrange = 0, int Decelerate = 0, int Xreduce = 0, int Yreduce = 0, int CDTime = 0)
		{
			builder.StartObject(11);
			ScreenShakeTable.AddCDTime(builder, CDTime);
			ScreenShakeTable.AddYreduce(builder, Yreduce);
			ScreenShakeTable.AddXreduce(builder, Xreduce);
			ScreenShakeTable.AddDecelerate(builder, Decelerate);
			ScreenShakeTable.AddYrange(builder, Yrange);
			ScreenShakeTable.AddXrange(builder, Xrange);
			ScreenShakeTable.AddNum(builder, Num);
			ScreenShakeTable.AddTotalTime(builder, TotalTime);
			ScreenShakeTable.AddRadius(builder, Radius);
			ScreenShakeTable.AddMode(builder, Mode);
			ScreenShakeTable.AddID(builder, ID);
			return ScreenShakeTable.EndScreenShakeTable(builder);
		}

		// Token: 0x06004A7B RID: 19067 RVA: 0x000EA84C File Offset: 0x000E8C4C
		public static void StartScreenShakeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06004A7C RID: 19068 RVA: 0x000EA856 File Offset: 0x000E8C56
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004A7D RID: 19069 RVA: 0x000EA861 File Offset: 0x000E8C61
		public static void AddMode(FlatBufferBuilder builder, int Mode)
		{
			builder.AddInt(1, Mode, 0);
		}

		// Token: 0x06004A7E RID: 19070 RVA: 0x000EA86C File Offset: 0x000E8C6C
		public static void AddRadius(FlatBufferBuilder builder, int Radius)
		{
			builder.AddInt(2, Radius, 0);
		}

		// Token: 0x06004A7F RID: 19071 RVA: 0x000EA877 File Offset: 0x000E8C77
		public static void AddTotalTime(FlatBufferBuilder builder, int TotalTime)
		{
			builder.AddInt(3, TotalTime, 0);
		}

		// Token: 0x06004A80 RID: 19072 RVA: 0x000EA882 File Offset: 0x000E8C82
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(4, Num, 0);
		}

		// Token: 0x06004A81 RID: 19073 RVA: 0x000EA88D File Offset: 0x000E8C8D
		public static void AddXrange(FlatBufferBuilder builder, int Xrange)
		{
			builder.AddInt(5, Xrange, 0);
		}

		// Token: 0x06004A82 RID: 19074 RVA: 0x000EA898 File Offset: 0x000E8C98
		public static void AddYrange(FlatBufferBuilder builder, int Yrange)
		{
			builder.AddInt(6, Yrange, 0);
		}

		// Token: 0x06004A83 RID: 19075 RVA: 0x000EA8A3 File Offset: 0x000E8CA3
		public static void AddDecelerate(FlatBufferBuilder builder, int Decelerate)
		{
			builder.AddInt(7, Decelerate, 0);
		}

		// Token: 0x06004A84 RID: 19076 RVA: 0x000EA8AE File Offset: 0x000E8CAE
		public static void AddXreduce(FlatBufferBuilder builder, int Xreduce)
		{
			builder.AddInt(8, Xreduce, 0);
		}

		// Token: 0x06004A85 RID: 19077 RVA: 0x000EA8B9 File Offset: 0x000E8CB9
		public static void AddYreduce(FlatBufferBuilder builder, int Yreduce)
		{
			builder.AddInt(9, Yreduce, 0);
		}

		// Token: 0x06004A86 RID: 19078 RVA: 0x000EA8C5 File Offset: 0x000E8CC5
		public static void AddCDTime(FlatBufferBuilder builder, int CDTime)
		{
			builder.AddInt(10, CDTime, 0);
		}

		// Token: 0x06004A87 RID: 19079 RVA: 0x000EA8D4 File Offset: 0x000E8CD4
		public static Offset<ScreenShakeTable> EndScreenShakeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ScreenShakeTable>(value);
		}

		// Token: 0x06004A88 RID: 19080 RVA: 0x000EA8EE File Offset: 0x000E8CEE
		public static void FinishScreenShakeTableBuffer(FlatBufferBuilder builder, Offset<ScreenShakeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AF2 RID: 6898
		private Table __p = new Table();

		// Token: 0x020005A0 RID: 1440
		public enum eCrypt
		{
			// Token: 0x04001AF4 RID: 6900
			code = -612408714
		}
	}
}
