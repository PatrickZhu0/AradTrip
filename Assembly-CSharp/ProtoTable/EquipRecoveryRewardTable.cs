using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000403 RID: 1027
	public class EquipRecoveryRewardTable : IFlatbufferObject
	{
		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x06002F4E RID: 12110 RVA: 0x000AACC8 File Offset: 0x000A90C8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x000AACD5 File Offset: 0x000A90D5
		public static EquipRecoveryRewardTable GetRootAsEquipRecoveryRewardTable(ByteBuffer _bb)
		{
			return EquipRecoveryRewardTable.GetRootAsEquipRecoveryRewardTable(_bb, new EquipRecoveryRewardTable());
		}

		// Token: 0x06002F50 RID: 12112 RVA: 0x000AACE2 File Offset: 0x000A90E2
		public static EquipRecoveryRewardTable GetRootAsEquipRecoveryRewardTable(ByteBuffer _bb, EquipRecoveryRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002F51 RID: 12113 RVA: 0x000AACFE File Offset: 0x000A90FE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002F52 RID: 12114 RVA: 0x000AAD18 File Offset: 0x000A9118
		public EquipRecoveryRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x06002F53 RID: 12115 RVA: 0x000AAD24 File Offset: 0x000A9124
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1145868590 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x06002F54 RID: 12116 RVA: 0x000AAD70 File Offset: 0x000A9170
		public int Integral
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1145868590 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B5D RID: 2909
		// (get) Token: 0x06002F55 RID: 12117 RVA: 0x000AADBC File Offset: 0x000A91BC
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F56 RID: 12118 RVA: 0x000AADFE File Offset: 0x000A91FE
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000B5E RID: 2910
		// (get) Token: 0x06002F57 RID: 12119 RVA: 0x000AAE0C File Offset: 0x000A920C
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F58 RID: 12120 RVA: 0x000AAE4F File Offset: 0x000A924F
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000B5F RID: 2911
		// (get) Token: 0x06002F59 RID: 12121 RVA: 0x000AAE60 File Offset: 0x000A9260
		public string SpecialEffects
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F5A RID: 12122 RVA: 0x000AAEA3 File Offset: 0x000A92A3
		public ArraySegment<byte>? GetSpecialEffectsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000B60 RID: 2912
		// (get) Token: 0x06002F5B RID: 12123 RVA: 0x000AAEB4 File Offset: 0x000A92B4
		public string Reward
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F5C RID: 12124 RVA: 0x000AAEF7 File Offset: 0x000A92F7
		public ArraySegment<byte>? GetRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000B61 RID: 2913
		// (get) Token: 0x06002F5D RID: 12125 RVA: 0x000AAF08 File Offset: 0x000A9308
		public int JarID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1145868590 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x06002F5E RID: 12126 RVA: 0x000AAF54 File Offset: 0x000A9354
		public int ShowID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1145868590 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x06002F5F RID: 12127 RVA: 0x000AAFA0 File Offset: 0x000A93A0
		public string IconPath2
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002F60 RID: 12128 RVA: 0x000AAFE3 File Offset: 0x000A93E3
		public ArraySegment<byte>? GetIconPath2Bytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06002F61 RID: 12129 RVA: 0x000AAFF4 File Offset: 0x000A93F4
		public static Offset<EquipRecoveryRewardTable> CreateEquipRecoveryRewardTable(FlatBufferBuilder builder, int ID = 0, int Integral = 0, StringOffset IconPathOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), StringOffset SpecialEffectsOffset = default(StringOffset), StringOffset RewardOffset = default(StringOffset), int JarID = 0, int ShowID = 0, StringOffset IconPath2Offset = default(StringOffset))
		{
			builder.StartObject(9);
			EquipRecoveryRewardTable.AddIconPath2(builder, IconPath2Offset);
			EquipRecoveryRewardTable.AddShowID(builder, ShowID);
			EquipRecoveryRewardTable.AddJarID(builder, JarID);
			EquipRecoveryRewardTable.AddReward(builder, RewardOffset);
			EquipRecoveryRewardTable.AddSpecialEffects(builder, SpecialEffectsOffset);
			EquipRecoveryRewardTable.AddDesc(builder, DescOffset);
			EquipRecoveryRewardTable.AddIconPath(builder, IconPathOffset);
			EquipRecoveryRewardTable.AddIntegral(builder, Integral);
			EquipRecoveryRewardTable.AddID(builder, ID);
			return EquipRecoveryRewardTable.EndEquipRecoveryRewardTable(builder);
		}

		// Token: 0x06002F62 RID: 12130 RVA: 0x000AB054 File Offset: 0x000A9454
		public static void StartEquipRecoveryRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06002F63 RID: 12131 RVA: 0x000AB05E File Offset: 0x000A945E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002F64 RID: 12132 RVA: 0x000AB069 File Offset: 0x000A9469
		public static void AddIntegral(FlatBufferBuilder builder, int Integral)
		{
			builder.AddInt(1, Integral, 0);
		}

		// Token: 0x06002F65 RID: 12133 RVA: 0x000AB074 File Offset: 0x000A9474
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(2, IconPathOffset.Value, 0);
		}

		// Token: 0x06002F66 RID: 12134 RVA: 0x000AB085 File Offset: 0x000A9485
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(3, DescOffset.Value, 0);
		}

		// Token: 0x06002F67 RID: 12135 RVA: 0x000AB096 File Offset: 0x000A9496
		public static void AddSpecialEffects(FlatBufferBuilder builder, StringOffset SpecialEffectsOffset)
		{
			builder.AddOffset(4, SpecialEffectsOffset.Value, 0);
		}

		// Token: 0x06002F68 RID: 12136 RVA: 0x000AB0A7 File Offset: 0x000A94A7
		public static void AddReward(FlatBufferBuilder builder, StringOffset RewardOffset)
		{
			builder.AddOffset(5, RewardOffset.Value, 0);
		}

		// Token: 0x06002F69 RID: 12137 RVA: 0x000AB0B8 File Offset: 0x000A94B8
		public static void AddJarID(FlatBufferBuilder builder, int JarID)
		{
			builder.AddInt(6, JarID, 0);
		}

		// Token: 0x06002F6A RID: 12138 RVA: 0x000AB0C3 File Offset: 0x000A94C3
		public static void AddShowID(FlatBufferBuilder builder, int ShowID)
		{
			builder.AddInt(7, ShowID, 0);
		}

		// Token: 0x06002F6B RID: 12139 RVA: 0x000AB0CE File Offset: 0x000A94CE
		public static void AddIconPath2(FlatBufferBuilder builder, StringOffset IconPath2Offset)
		{
			builder.AddOffset(8, IconPath2Offset.Value, 0);
		}

		// Token: 0x06002F6C RID: 12140 RVA: 0x000AB0E0 File Offset: 0x000A94E0
		public static Offset<EquipRecoveryRewardTable> EndEquipRecoveryRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipRecoveryRewardTable>(value);
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x000AB0FA File Offset: 0x000A94FA
		public static void FinishEquipRecoveryRewardTableBuffer(FlatBufferBuilder builder, Offset<EquipRecoveryRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040013B9 RID: 5049
		private Table __p = new Table();

		// Token: 0x02000404 RID: 1028
		public enum eCrypt
		{
			// Token: 0x040013BB RID: 5051
			code = 1145868590
		}
	}
}
