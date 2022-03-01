using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200050C RID: 1292
	public class MoneyManageTable : IFlatbufferObject
	{
		// Token: 0x1700119B RID: 4507
		// (get) Token: 0x06004255 RID: 16981 RVA: 0x000D8278 File Offset: 0x000D6678
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004256 RID: 16982 RVA: 0x000D8285 File Offset: 0x000D6685
		public static MoneyManageTable GetRootAsMoneyManageTable(ByteBuffer _bb)
		{
			return MoneyManageTable.GetRootAsMoneyManageTable(_bb, new MoneyManageTable());
		}

		// Token: 0x06004257 RID: 16983 RVA: 0x000D8292 File Offset: 0x000D6692
		public static MoneyManageTable GetRootAsMoneyManageTable(ByteBuffer _bb, MoneyManageTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004258 RID: 16984 RVA: 0x000D82AE File Offset: 0x000D66AE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004259 RID: 16985 RVA: 0x000D82C8 File Offset: 0x000D66C8
		public MoneyManageTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700119C RID: 4508
		// (get) Token: 0x0600425A RID: 16986 RVA: 0x000D82D4 File Offset: 0x000D66D4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-877491173 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700119D RID: 4509
		// (get) Token: 0x0600425B RID: 16987 RVA: 0x000D8320 File Offset: 0x000D6720
		public int Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-877491173 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600425C RID: 16988 RVA: 0x000D836C File Offset: 0x000D676C
		public string ItemRewardArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700119E RID: 4510
		// (get) Token: 0x0600425D RID: 16989 RVA: 0x000D83B4 File Offset: 0x000D67B4
		public int ItemRewardLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700119F RID: 4511
		// (get) Token: 0x0600425E RID: 16990 RVA: 0x000D83E6 File Offset: 0x000D67E6
		public FlatBufferArray<string> ItemReward
		{
			get
			{
				if (this.ItemRewardValue == null)
				{
					this.ItemRewardValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemRewardArray), this.ItemRewardLength);
				}
				return this.ItemRewardValue;
			}
		}

		// Token: 0x0600425F RID: 16991 RVA: 0x000D8416 File Offset: 0x000D6816
		public static Offset<MoneyManageTable> CreateMoneyManageTable(FlatBufferBuilder builder, int ID = 0, int Level = 0, VectorOffset ItemRewardOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			MoneyManageTable.AddItemReward(builder, ItemRewardOffset);
			MoneyManageTable.AddLevel(builder, Level);
			MoneyManageTable.AddID(builder, ID);
			return MoneyManageTable.EndMoneyManageTable(builder);
		}

		// Token: 0x06004260 RID: 16992 RVA: 0x000D843A File Offset: 0x000D683A
		public static void StartMoneyManageTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004261 RID: 16993 RVA: 0x000D8443 File Offset: 0x000D6843
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004262 RID: 16994 RVA: 0x000D844E File Offset: 0x000D684E
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(1, Level, 0);
		}

		// Token: 0x06004263 RID: 16995 RVA: 0x000D8459 File Offset: 0x000D6859
		public static void AddItemReward(FlatBufferBuilder builder, VectorOffset ItemRewardOffset)
		{
			builder.AddOffset(2, ItemRewardOffset.Value, 0);
		}

		// Token: 0x06004264 RID: 16996 RVA: 0x000D846C File Offset: 0x000D686C
		public static VectorOffset CreateItemRewardVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004265 RID: 16997 RVA: 0x000D84B2 File Offset: 0x000D68B2
		public static void StartItemRewardVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004266 RID: 16998 RVA: 0x000D84C0 File Offset: 0x000D68C0
		public static Offset<MoneyManageTable> EndMoneyManageTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MoneyManageTable>(value);
		}

		// Token: 0x06004267 RID: 16999 RVA: 0x000D84DA File Offset: 0x000D68DA
		public static void FinishMoneyManageTableBuffer(FlatBufferBuilder builder, Offset<MoneyManageTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018CB RID: 6347
		private Table __p = new Table();

		// Token: 0x040018CC RID: 6348
		private FlatBufferArray<string> ItemRewardValue;

		// Token: 0x0200050D RID: 1293
		public enum eCrypt
		{
			// Token: 0x040018CE RID: 6350
			code = -877491173
		}
	}
}
