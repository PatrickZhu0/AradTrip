using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002A1 RID: 673
	public class AntiAddictTimeTable : IFlatbufferObject
	{
		// Token: 0x1700037C RID: 892
		// (get) Token: 0x060017F9 RID: 6137 RVA: 0x00072908 File Offset: 0x00070D08
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x00072915 File Offset: 0x00070D15
		public static AntiAddictTimeTable GetRootAsAntiAddictTimeTable(ByteBuffer _bb)
		{
			return AntiAddictTimeTable.GetRootAsAntiAddictTimeTable(_bb, new AntiAddictTimeTable());
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x00072922 File Offset: 0x00070D22
		public static AntiAddictTimeTable GetRootAsAntiAddictTimeTable(ByteBuffer _bb, AntiAddictTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0007293E File Offset: 0x00070D3E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x00072958 File Offset: 0x00070D58
		public AntiAddictTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x060017FE RID: 6142 RVA: 0x00072964 File Offset: 0x00070D64
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2080035546 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060017FF RID: 6143 RVA: 0x000729B0 File Offset: 0x00070DB0
		public int IsHoliday
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2080035546 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06001800 RID: 6144 RVA: 0x000729FC File Offset: 0x00070DFC
		public int Age
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2080035546 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06001801 RID: 6145 RVA: 0x00072A48 File Offset: 0x00070E48
		public int GameTime
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2080035546 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x00072A92 File Offset: 0x00070E92
		public static Offset<AntiAddictTimeTable> CreateAntiAddictTimeTable(FlatBufferBuilder builder, int ID = 0, int IsHoliday = 0, int Age = 0, int GameTime = 0)
		{
			builder.StartObject(4);
			AntiAddictTimeTable.AddGameTime(builder, GameTime);
			AntiAddictTimeTable.AddAge(builder, Age);
			AntiAddictTimeTable.AddIsHoliday(builder, IsHoliday);
			AntiAddictTimeTable.AddID(builder, ID);
			return AntiAddictTimeTable.EndAntiAddictTimeTable(builder);
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x00072ABE File Offset: 0x00070EBE
		public static void StartAntiAddictTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x00072AC7 File Offset: 0x00070EC7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x00072AD2 File Offset: 0x00070ED2
		public static void AddIsHoliday(FlatBufferBuilder builder, int IsHoliday)
		{
			builder.AddInt(1, IsHoliday, 0);
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x00072ADD File Offset: 0x00070EDD
		public static void AddAge(FlatBufferBuilder builder, int Age)
		{
			builder.AddInt(2, Age, 0);
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x00072AE8 File Offset: 0x00070EE8
		public static void AddGameTime(FlatBufferBuilder builder, int GameTime)
		{
			builder.AddInt(3, GameTime, 0);
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x00072AF4 File Offset: 0x00070EF4
		public static Offset<AntiAddictTimeTable> EndAntiAddictTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AntiAddictTimeTable>(value);
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x00072B0E File Offset: 0x00070F0E
		public static void FinishAntiAddictTimeTableBuffer(FlatBufferBuilder builder, Offset<AntiAddictTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DEB RID: 3563
		private Table __p = new Table();

		// Token: 0x020002A2 RID: 674
		public enum eCrypt
		{
			// Token: 0x04000DED RID: 3565
			code = -2080035546
		}
	}
}
