using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200028B RID: 651
	public class AdventurePassActivityTable : IFlatbufferObject
	{
		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06001703 RID: 5891 RVA: 0x00070A50 File Offset: 0x0006EE50
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001704 RID: 5892 RVA: 0x00070A5D File Offset: 0x0006EE5D
		public static AdventurePassActivityTable GetRootAsAdventurePassActivityTable(ByteBuffer _bb)
		{
			return AdventurePassActivityTable.GetRootAsAdventurePassActivityTable(_bb, new AdventurePassActivityTable());
		}

		// Token: 0x06001705 RID: 5893 RVA: 0x00070A6A File Offset: 0x0006EE6A
		public static AdventurePassActivityTable GetRootAsAdventurePassActivityTable(ByteBuffer _bb, AdventurePassActivityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001706 RID: 5894 RVA: 0x00070A86 File Offset: 0x0006EE86
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x00070AA0 File Offset: 0x0006EEA0
		public AdventurePassActivityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x00070AAC File Offset: 0x0006EEAC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-68319084 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06001709 RID: 5897 RVA: 0x00070AF8 File Offset: 0x0006EEF8
		public int Activity
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-68319084 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x00070B44 File Offset: 0x0006EF44
		public int Exp
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-68319084 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600170B RID: 5899 RVA: 0x00070B8D File Offset: 0x0006EF8D
		public static Offset<AdventurePassActivityTable> CreateAdventurePassActivityTable(FlatBufferBuilder builder, int ID = 0, int Activity = 0, int Exp = 0)
		{
			builder.StartObject(3);
			AdventurePassActivityTable.AddExp(builder, Exp);
			AdventurePassActivityTable.AddActivity(builder, Activity);
			AdventurePassActivityTable.AddID(builder, ID);
			return AdventurePassActivityTable.EndAdventurePassActivityTable(builder);
		}

		// Token: 0x0600170C RID: 5900 RVA: 0x00070BB1 File Offset: 0x0006EFB1
		public static void StartAdventurePassActivityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600170D RID: 5901 RVA: 0x00070BBA File Offset: 0x0006EFBA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600170E RID: 5902 RVA: 0x00070BC5 File Offset: 0x0006EFC5
		public static void AddActivity(FlatBufferBuilder builder, int Activity)
		{
			builder.AddInt(1, Activity, 0);
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x00070BD0 File Offset: 0x0006EFD0
		public static void AddExp(FlatBufferBuilder builder, int Exp)
		{
			builder.AddInt(2, Exp, 0);
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x00070BDC File Offset: 0x0006EFDC
		public static Offset<AdventurePassActivityTable> EndAdventurePassActivityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventurePassActivityTable>(value);
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x00070BF6 File Offset: 0x0006EFF6
		public static void FinishAdventurePassActivityTableBuffer(FlatBufferBuilder builder, Offset<AdventurePassActivityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DC2 RID: 3522
		private Table __p = new Table();

		// Token: 0x0200028C RID: 652
		public enum eCrypt
		{
			// Token: 0x04000DC4 RID: 3524
			code = -68319084
		}
	}
}
