using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000399 RID: 921
	public class DungeonDifficultyAdjustTable : IFlatbufferObject
	{
		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x0600280B RID: 10251 RVA: 0x00099254 File Offset: 0x00097654
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600280C RID: 10252 RVA: 0x00099261 File Offset: 0x00097661
		public static DungeonDifficultyAdjustTable GetRootAsDungeonDifficultyAdjustTable(ByteBuffer _bb)
		{
			return DungeonDifficultyAdjustTable.GetRootAsDungeonDifficultyAdjustTable(_bb, new DungeonDifficultyAdjustTable());
		}

		// Token: 0x0600280D RID: 10253 RVA: 0x0009926E File Offset: 0x0009766E
		public static DungeonDifficultyAdjustTable GetRootAsDungeonDifficultyAdjustTable(ByteBuffer _bb, DungeonDifficultyAdjustTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600280E RID: 10254 RVA: 0x0009928A File Offset: 0x0009768A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600280F RID: 10255 RVA: 0x000992A4 File Offset: 0x000976A4
		public DungeonDifficultyAdjustTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x06002810 RID: 10256 RVA: 0x000992B0 File Offset: 0x000976B0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x06002811 RID: 10257 RVA: 0x000992FC File Offset: 0x000976FC
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x06002812 RID: 10258 RVA: 0x00099348 File Offset: 0x00097748
		public int PlayerNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x06002813 RID: 10259 RVA: 0x00099394 File Offset: 0x00097794
		public int MonsterHPFactor
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06002814 RID: 10260 RVA: 0x000993E0 File Offset: 0x000977E0
		public int MonsterAttackFactor
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x06002815 RID: 10261 RVA: 0x0009942C File Offset: 0x0009782C
		public int BossHPFactor
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x06002816 RID: 10262 RVA: 0x00099478 File Offset: 0x00097878
		public int BossAttackFactor
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (255282508 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002817 RID: 10263 RVA: 0x000994C4 File Offset: 0x000978C4
		public static Offset<DungeonDifficultyAdjustTable> CreateDungeonDifficultyAdjustTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, int PlayerNum = 0, int MonsterHPFactor = 0, int MonsterAttackFactor = 0, int BossHPFactor = 0, int BossAttackFactor = 0)
		{
			builder.StartObject(7);
			DungeonDifficultyAdjustTable.AddBossAttackFactor(builder, BossAttackFactor);
			DungeonDifficultyAdjustTable.AddBossHPFactor(builder, BossHPFactor);
			DungeonDifficultyAdjustTable.AddMonsterAttackFactor(builder, MonsterAttackFactor);
			DungeonDifficultyAdjustTable.AddMonsterHPFactor(builder, MonsterHPFactor);
			DungeonDifficultyAdjustTable.AddPlayerNum(builder, PlayerNum);
			DungeonDifficultyAdjustTable.AddDungeonID(builder, DungeonID);
			DungeonDifficultyAdjustTable.AddID(builder, ID);
			return DungeonDifficultyAdjustTable.EndDungeonDifficultyAdjustTable(builder);
		}

		// Token: 0x06002818 RID: 10264 RVA: 0x00099513 File Offset: 0x00097913
		public static void StartDungeonDifficultyAdjustTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002819 RID: 10265 RVA: 0x0009951C File Offset: 0x0009791C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600281A RID: 10266 RVA: 0x00099527 File Offset: 0x00097927
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x0600281B RID: 10267 RVA: 0x00099532 File Offset: 0x00097932
		public static void AddPlayerNum(FlatBufferBuilder builder, int PlayerNum)
		{
			builder.AddInt(2, PlayerNum, 0);
		}

		// Token: 0x0600281C RID: 10268 RVA: 0x0009953D File Offset: 0x0009793D
		public static void AddMonsterHPFactor(FlatBufferBuilder builder, int MonsterHPFactor)
		{
			builder.AddInt(3, MonsterHPFactor, 0);
		}

		// Token: 0x0600281D RID: 10269 RVA: 0x00099548 File Offset: 0x00097948
		public static void AddMonsterAttackFactor(FlatBufferBuilder builder, int MonsterAttackFactor)
		{
			builder.AddInt(4, MonsterAttackFactor, 0);
		}

		// Token: 0x0600281E RID: 10270 RVA: 0x00099553 File Offset: 0x00097953
		public static void AddBossHPFactor(FlatBufferBuilder builder, int BossHPFactor)
		{
			builder.AddInt(5, BossHPFactor, 0);
		}

		// Token: 0x0600281F RID: 10271 RVA: 0x0009955E File Offset: 0x0009795E
		public static void AddBossAttackFactor(FlatBufferBuilder builder, int BossAttackFactor)
		{
			builder.AddInt(6, BossAttackFactor, 0);
		}

		// Token: 0x06002820 RID: 10272 RVA: 0x0009956C File Offset: 0x0009796C
		public static Offset<DungeonDifficultyAdjustTable> EndDungeonDifficultyAdjustTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonDifficultyAdjustTable>(value);
		}

		// Token: 0x06002821 RID: 10273 RVA: 0x00099586 File Offset: 0x00097986
		public static void FinishDungeonDifficultyAdjustTableBuffer(FlatBufferBuilder builder, Offset<DungeonDifficultyAdjustTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011D7 RID: 4567
		private Table __p = new Table();

		// Token: 0x0200039A RID: 922
		public enum eCrypt
		{
			// Token: 0x040011D9 RID: 4569
			code = 255282508
		}
	}
}
