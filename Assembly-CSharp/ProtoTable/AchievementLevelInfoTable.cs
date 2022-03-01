using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200026E RID: 622
	public class AchievementLevelInfoTable : IFlatbufferObject
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x0006B234 File Offset: 0x00069634
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0006B241 File Offset: 0x00069641
		public static AchievementLevelInfoTable GetRootAsAchievementLevelInfoTable(ByteBuffer _bb)
		{
			return AchievementLevelInfoTable.GetRootAsAchievementLevelInfoTable(_bb, new AchievementLevelInfoTable());
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0006B24E File Offset: 0x0006964E
		public static AchievementLevelInfoTable GetRootAsAchievementLevelInfoTable(ByteBuffer _bb, AchievementLevelInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0006B26A File Offset: 0x0006966A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0006B284 File Offset: 0x00069684
		public AchievementLevelInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060014A4 RID: 5284 RVA: 0x0006B290 File Offset: 0x00069690
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060014A5 RID: 5285 RVA: 0x0006B2DC File Offset: 0x000696DC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014A6 RID: 5286 RVA: 0x0006B31E File Offset: 0x0006971E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x0006B32C File Offset: 0x0006972C
		public string Title
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x0006B36E File Offset: 0x0006976E
		public ArraySegment<byte>? GetTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x0006B37C File Offset: 0x0006977C
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x0006B3BF File Offset: 0x000697BF
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x0006B3D0 File Offset: 0x000697D0
		public string TextIcon
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x0006B413 File Offset: 0x00069813
		public ArraySegment<byte>? GetTextIconBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060014AD RID: 5293 RVA: 0x0006B424 File Offset: 0x00069824
		public int Min
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x0006B470 File Offset: 0x00069870
		public int Max
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060014AF RID: 5295 RVA: 0x0006B4BC File Offset: 0x000698BC
		public int Level
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x0006B508 File Offset: 0x00069908
		public int AwardIDArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060014B1 RID: 5297 RVA: 0x0006B558 File Offset: 0x00069958
		public int AwardIDLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x0006B58B File Offset: 0x0006998B
		public ArraySegment<byte>? GetAwardIDBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060014B3 RID: 5299 RVA: 0x0006B59A File Offset: 0x0006999A
		public FlatBufferArray<int> AwardID
		{
			get
			{
				if (this.AwardIDValue == null)
				{
					this.AwardIDValue = new FlatBufferArray<int>(new Func<int, int>(this.AwardIDArray), this.AwardIDLength);
				}
				return this.AwardIDValue;
			}
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0006B5CC File Offset: 0x000699CC
		public int AwardCountArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (182075077 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060014B5 RID: 5301 RVA: 0x0006B61C File Offset: 0x00069A1C
		public int AwardCountLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060014B6 RID: 5302 RVA: 0x0006B64F File Offset: 0x00069A4F
		public ArraySegment<byte>? GetAwardCountBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060014B7 RID: 5303 RVA: 0x0006B65E File Offset: 0x00069A5E
		public FlatBufferArray<int> AwardCount
		{
			get
			{
				if (this.AwardCountValue == null)
				{
					this.AwardCountValue = new FlatBufferArray<int>(new Func<int, int>(this.AwardCountArray), this.AwardCountLength);
				}
				return this.AwardCountValue;
			}
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x0006B690 File Offset: 0x00069A90
		public static Offset<AchievementLevelInfoTable> CreateAchievementLevelInfoTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset TitleOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset), StringOffset TextIconOffset = default(StringOffset), int Min = 0, int Max = 0, int Level = 0, VectorOffset AwardIDOffset = default(VectorOffset), VectorOffset AwardCountOffset = default(VectorOffset))
		{
			builder.StartObject(10);
			AchievementLevelInfoTable.AddAwardCount(builder, AwardCountOffset);
			AchievementLevelInfoTable.AddAwardID(builder, AwardIDOffset);
			AchievementLevelInfoTable.AddLevel(builder, Level);
			AchievementLevelInfoTable.AddMax(builder, Max);
			AchievementLevelInfoTable.AddMin(builder, Min);
			AchievementLevelInfoTable.AddTextIcon(builder, TextIconOffset);
			AchievementLevelInfoTable.AddIcon(builder, IconOffset);
			AchievementLevelInfoTable.AddTitle(builder, TitleOffset);
			AchievementLevelInfoTable.AddName(builder, NameOffset);
			AchievementLevelInfoTable.AddID(builder, ID);
			return AchievementLevelInfoTable.EndAchievementLevelInfoTable(builder);
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x0006B6F8 File Offset: 0x00069AF8
		public static void StartAchievementLevelInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0006B702 File Offset: 0x00069B02
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x0006B70D File Offset: 0x00069B0D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x0006B71E File Offset: 0x00069B1E
		public static void AddTitle(FlatBufferBuilder builder, StringOffset TitleOffset)
		{
			builder.AddOffset(2, TitleOffset.Value, 0);
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x0006B72F File Offset: 0x00069B2F
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(3, IconOffset.Value, 0);
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x0006B740 File Offset: 0x00069B40
		public static void AddTextIcon(FlatBufferBuilder builder, StringOffset TextIconOffset)
		{
			builder.AddOffset(4, TextIconOffset.Value, 0);
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x0006B751 File Offset: 0x00069B51
		public static void AddMin(FlatBufferBuilder builder, int Min)
		{
			builder.AddInt(5, Min, 0);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0006B75C File Offset: 0x00069B5C
		public static void AddMax(FlatBufferBuilder builder, int Max)
		{
			builder.AddInt(6, Max, 0);
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x0006B767 File Offset: 0x00069B67
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(7, Level, 0);
		}

		// Token: 0x060014C2 RID: 5314 RVA: 0x0006B772 File Offset: 0x00069B72
		public static void AddAwardID(FlatBufferBuilder builder, VectorOffset AwardIDOffset)
		{
			builder.AddOffset(8, AwardIDOffset.Value, 0);
		}

		// Token: 0x060014C3 RID: 5315 RVA: 0x0006B784 File Offset: 0x00069B84
		public static VectorOffset CreateAwardIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060014C4 RID: 5316 RVA: 0x0006B7C1 File Offset: 0x00069BC1
		public static void StartAwardIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060014C5 RID: 5317 RVA: 0x0006B7CC File Offset: 0x00069BCC
		public static void AddAwardCount(FlatBufferBuilder builder, VectorOffset AwardCountOffset)
		{
			builder.AddOffset(9, AwardCountOffset.Value, 0);
		}

		// Token: 0x060014C6 RID: 5318 RVA: 0x0006B7E0 File Offset: 0x00069BE0
		public static VectorOffset CreateAwardCountVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060014C7 RID: 5319 RVA: 0x0006B81D File Offset: 0x00069C1D
		public static void StartAwardCountVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060014C8 RID: 5320 RVA: 0x0006B828 File Offset: 0x00069C28
		public static Offset<AchievementLevelInfoTable> EndAchievementLevelInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AchievementLevelInfoTable>(value);
		}

		// Token: 0x060014C9 RID: 5321 RVA: 0x0006B842 File Offset: 0x00069C42
		public static void FinishAchievementLevelInfoTableBuffer(FlatBufferBuilder builder, Offset<AchievementLevelInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D6D RID: 3437
		private Table __p = new Table();

		// Token: 0x04000D6E RID: 3438
		private FlatBufferArray<int> AwardIDValue;

		// Token: 0x04000D6F RID: 3439
		private FlatBufferArray<int> AwardCountValue;

		// Token: 0x0200026F RID: 623
		public enum eCrypt
		{
			// Token: 0x04000D71 RID: 3441
			code = 182075077
		}
	}
}
