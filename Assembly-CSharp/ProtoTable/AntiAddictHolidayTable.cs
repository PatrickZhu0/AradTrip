using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200029F RID: 671
	public class AntiAddictHolidayTable : IFlatbufferObject
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x060017EB RID: 6123 RVA: 0x0007279C File Offset: 0x00070B9C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x000727A9 File Offset: 0x00070BA9
		public static AntiAddictHolidayTable GetRootAsAntiAddictHolidayTable(ByteBuffer _bb)
		{
			return AntiAddictHolidayTable.GetRootAsAntiAddictHolidayTable(_bb, new AntiAddictHolidayTable());
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x000727B6 File Offset: 0x00070BB6
		public static AntiAddictHolidayTable GetRootAsAntiAddictHolidayTable(ByteBuffer _bb, AntiAddictHolidayTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x000727D2 File Offset: 0x00070BD2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x000727EC File Offset: 0x00070BEC
		public AntiAddictHolidayTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000727F8 File Offset: 0x00070BF8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-491144707 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x060017F1 RID: 6129 RVA: 0x00072844 File Offset: 0x00070C44
		public int HolidayDate
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-491144707 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x0007288D File Offset: 0x00070C8D
		public static Offset<AntiAddictHolidayTable> CreateAntiAddictHolidayTable(FlatBufferBuilder builder, int ID = 0, int HolidayDate = 0)
		{
			builder.StartObject(2);
			AntiAddictHolidayTable.AddHolidayDate(builder, HolidayDate);
			AntiAddictHolidayTable.AddID(builder, ID);
			return AntiAddictHolidayTable.EndAntiAddictHolidayTable(builder);
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x000728AA File Offset: 0x00070CAA
		public static void StartAntiAddictHolidayTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x000728B3 File Offset: 0x00070CB3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x000728BE File Offset: 0x00070CBE
		public static void AddHolidayDate(FlatBufferBuilder builder, int HolidayDate)
		{
			builder.AddInt(1, HolidayDate, 0);
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x000728CC File Offset: 0x00070CCC
		public static Offset<AntiAddictHolidayTable> EndAntiAddictHolidayTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AntiAddictHolidayTable>(value);
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x000728E6 File Offset: 0x00070CE6
		public static void FinishAntiAddictHolidayTableBuffer(FlatBufferBuilder builder, Offset<AntiAddictHolidayTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DE8 RID: 3560
		private Table __p = new Table();

		// Token: 0x020002A0 RID: 672
		public enum eCrypt
		{
			// Token: 0x04000DEA RID: 3562
			code = -491144707
		}
	}
}
