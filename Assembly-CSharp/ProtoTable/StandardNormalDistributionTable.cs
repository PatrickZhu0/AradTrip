using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005CD RID: 1485
	public class StandardNormalDistributionTable : IFlatbufferObject
	{
		// Token: 0x170015B5 RID: 5557
		// (get) Token: 0x06004EDF RID: 20191 RVA: 0x000F5574 File Offset: 0x000F3974
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004EE0 RID: 20192 RVA: 0x000F5581 File Offset: 0x000F3981
		public static StandardNormalDistributionTable GetRootAsStandardNormalDistributionTable(ByteBuffer _bb)
		{
			return StandardNormalDistributionTable.GetRootAsStandardNormalDistributionTable(_bb, new StandardNormalDistributionTable());
		}

		// Token: 0x06004EE1 RID: 20193 RVA: 0x000F558E File Offset: 0x000F398E
		public static StandardNormalDistributionTable GetRootAsStandardNormalDistributionTable(ByteBuffer _bb, StandardNormalDistributionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004EE2 RID: 20194 RVA: 0x000F55AA File Offset: 0x000F39AA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004EE3 RID: 20195 RVA: 0x000F55C4 File Offset: 0x000F39C4
		public StandardNormalDistributionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015B6 RID: 5558
		// (get) Token: 0x06004EE4 RID: 20196 RVA: 0x000F55D0 File Offset: 0x000F39D0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1196071976 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015B7 RID: 5559
		// (get) Token: 0x06004EE5 RID: 20197 RVA: 0x000F561C File Offset: 0x000F3A1C
		public int InputValue
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1196071976 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015B8 RID: 5560
		// (get) Token: 0x06004EE6 RID: 20198 RVA: 0x000F5668 File Offset: 0x000F3A68
		public int OutputValue
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1196071976 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004EE7 RID: 20199 RVA: 0x000F56B1 File Offset: 0x000F3AB1
		public static Offset<StandardNormalDistributionTable> CreateStandardNormalDistributionTable(FlatBufferBuilder builder, int ID = 0, int InputValue = 0, int OutputValue = 0)
		{
			builder.StartObject(3);
			StandardNormalDistributionTable.AddOutputValue(builder, OutputValue);
			StandardNormalDistributionTable.AddInputValue(builder, InputValue);
			StandardNormalDistributionTable.AddID(builder, ID);
			return StandardNormalDistributionTable.EndStandardNormalDistributionTable(builder);
		}

		// Token: 0x06004EE8 RID: 20200 RVA: 0x000F56D5 File Offset: 0x000F3AD5
		public static void StartStandardNormalDistributionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004EE9 RID: 20201 RVA: 0x000F56DE File Offset: 0x000F3ADE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004EEA RID: 20202 RVA: 0x000F56E9 File Offset: 0x000F3AE9
		public static void AddInputValue(FlatBufferBuilder builder, int InputValue)
		{
			builder.AddInt(1, InputValue, 0);
		}

		// Token: 0x06004EEB RID: 20203 RVA: 0x000F56F4 File Offset: 0x000F3AF4
		public static void AddOutputValue(FlatBufferBuilder builder, int OutputValue)
		{
			builder.AddInt(2, OutputValue, 0);
		}

		// Token: 0x06004EEC RID: 20204 RVA: 0x000F5700 File Offset: 0x000F3B00
		public static Offset<StandardNormalDistributionTable> EndStandardNormalDistributionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StandardNormalDistributionTable>(value);
		}

		// Token: 0x06004EED RID: 20205 RVA: 0x000F571A File Offset: 0x000F3B1A
		public static void FinishStandardNormalDistributionTableBuffer(FlatBufferBuilder builder, Offset<StandardNormalDistributionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BD5 RID: 7125
		private Table __p = new Table();

		// Token: 0x020005CE RID: 1486
		public enum eCrypt
		{
			// Token: 0x04001BD7 RID: 7127
			code = -1196071976
		}
	}
}
