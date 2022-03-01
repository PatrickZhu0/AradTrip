using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000526 RID: 1318
	public class NewBieGuideJobData : IFlatbufferObject
	{
		// Token: 0x17001200 RID: 4608
		// (get) Token: 0x0600439C RID: 17308 RVA: 0x000DAE28 File Offset: 0x000D9228
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600439D RID: 17309 RVA: 0x000DAE35 File Offset: 0x000D9235
		public static NewBieGuideJobData GetRootAsNewBieGuideJobData(ByteBuffer _bb)
		{
			return NewBieGuideJobData.GetRootAsNewBieGuideJobData(_bb, new NewBieGuideJobData());
		}

		// Token: 0x0600439E RID: 17310 RVA: 0x000DAE42 File Offset: 0x000D9242
		public static NewBieGuideJobData GetRootAsNewBieGuideJobData(ByteBuffer _bb, NewBieGuideJobData obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600439F RID: 17311 RVA: 0x000DAE5E File Offset: 0x000D925E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060043A0 RID: 17312 RVA: 0x000DAE78 File Offset: 0x000D9278
		public NewBieGuideJobData __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001201 RID: 4609
		// (get) Token: 0x060043A1 RID: 17313 RVA: 0x000DAE84 File Offset: 0x000D9284
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001202 RID: 4610
		// (get) Token: 0x060043A2 RID: 17314 RVA: 0x000DAED0 File Offset: 0x000D92D0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043A3 RID: 17315 RVA: 0x000DAF12 File Offset: 0x000D9312
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001203 RID: 4611
		// (get) Token: 0x060043A4 RID: 17316 RVA: 0x000DAF20 File Offset: 0x000D9320
		public int CDReduceRate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001204 RID: 4612
		// (get) Token: 0x060043A5 RID: 17317 RVA: 0x000DAF6C File Offset: 0x000D936C
		public int AttackSpped
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001205 RID: 4613
		// (get) Token: 0x060043A6 RID: 17318 RVA: 0x000DAFB8 File Offset: 0x000D93B8
		public int SpellSpeed
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001206 RID: 4614
		// (get) Token: 0x060043A7 RID: 17319 RVA: 0x000DB004 File Offset: 0x000D9404
		public int WalkSpeed
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001207 RID: 4615
		// (get) Token: 0x060043A8 RID: 17320 RVA: 0x000DB050 File Offset: 0x000D9450
		public int SkillLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060043A9 RID: 17321 RVA: 0x000DB09C File Offset: 0x000D949C
		public int SkillListArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001208 RID: 4616
		// (get) Token: 0x060043AA RID: 17322 RVA: 0x000DB0EC File Offset: 0x000D94EC
		public int SkillListLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060043AB RID: 17323 RVA: 0x000DB11F File Offset: 0x000D951F
		public ArraySegment<byte>? GetSkillListBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17001209 RID: 4617
		// (get) Token: 0x060043AC RID: 17324 RVA: 0x000DB12E File Offset: 0x000D952E
		public FlatBufferArray<int> SkillList
		{
			get
			{
				if (this.SkillListValue == null)
				{
					this.SkillListValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillListArray), this.SkillListLength);
				}
				return this.SkillListValue;
			}
		}

		// Token: 0x060043AD RID: 17325 RVA: 0x000DB160 File Offset: 0x000D9560
		public int EquipmentIDArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700120A RID: 4618
		// (get) Token: 0x060043AE RID: 17326 RVA: 0x000DB1B0 File Offset: 0x000D95B0
		public int EquipmentIDLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060043AF RID: 17327 RVA: 0x000DB1E3 File Offset: 0x000D95E3
		public ArraySegment<byte>? GetEquipmentIDBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700120B RID: 4619
		// (get) Token: 0x060043B0 RID: 17328 RVA: 0x000DB1F2 File Offset: 0x000D95F2
		public FlatBufferArray<int> EquipmentID
		{
			get
			{
				if (this.EquipmentIDValue == null)
				{
					this.EquipmentIDValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipmentIDArray), this.EquipmentIDLength);
				}
				return this.EquipmentIDValue;
			}
		}

		// Token: 0x060043B1 RID: 17329 RVA: 0x000DB224 File Offset: 0x000D9624
		public int SecondComboSkillArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700120C RID: 4620
		// (get) Token: 0x060043B2 RID: 17330 RVA: 0x000DB274 File Offset: 0x000D9674
		public int SecondComboSkillLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060043B3 RID: 17331 RVA: 0x000DB2A7 File Offset: 0x000D96A7
		public ArraySegment<byte>? GetSecondComboSkillBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700120D RID: 4621
		// (get) Token: 0x060043B4 RID: 17332 RVA: 0x000DB2B6 File Offset: 0x000D96B6
		public FlatBufferArray<int> SecondComboSkill
		{
			get
			{
				if (this.SecondComboSkillValue == null)
				{
					this.SecondComboSkillValue = new FlatBufferArray<int>(new Func<int, int>(this.SecondComboSkillArray), this.SecondComboSkillLength);
				}
				return this.SecondComboSkillValue;
			}
		}

		// Token: 0x060043B5 RID: 17333 RVA: 0x000DB2E8 File Offset: 0x000D96E8
		public int ThirdComboSkillArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (1083542827 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700120E RID: 4622
		// (get) Token: 0x060043B6 RID: 17334 RVA: 0x000DB338 File Offset: 0x000D9738
		public int ThirdComboSkillLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060043B7 RID: 17335 RVA: 0x000DB36B File Offset: 0x000D976B
		public ArraySegment<byte>? GetThirdComboSkillBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700120F RID: 4623
		// (get) Token: 0x060043B8 RID: 17336 RVA: 0x000DB37A File Offset: 0x000D977A
		public FlatBufferArray<int> ThirdComboSkill
		{
			get
			{
				if (this.ThirdComboSkillValue == null)
				{
					this.ThirdComboSkillValue = new FlatBufferArray<int>(new Func<int, int>(this.ThirdComboSkillArray), this.ThirdComboSkillLength);
				}
				return this.ThirdComboSkillValue;
			}
		}

		// Token: 0x060043B9 RID: 17337 RVA: 0x000DB3AC File Offset: 0x000D97AC
		public static Offset<NewBieGuideJobData> CreateNewBieGuideJobData(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int CDReduceRate = 0, int AttackSpped = 0, int SpellSpeed = 0, int WalkSpeed = 0, int SkillLevel = 0, VectorOffset SkillListOffset = default(VectorOffset), VectorOffset EquipmentIDOffset = default(VectorOffset), VectorOffset SecondComboSkillOffset = default(VectorOffset), VectorOffset ThirdComboSkillOffset = default(VectorOffset))
		{
			builder.StartObject(11);
			NewBieGuideJobData.AddThirdComboSkill(builder, ThirdComboSkillOffset);
			NewBieGuideJobData.AddSecondComboSkill(builder, SecondComboSkillOffset);
			NewBieGuideJobData.AddEquipmentID(builder, EquipmentIDOffset);
			NewBieGuideJobData.AddSkillList(builder, SkillListOffset);
			NewBieGuideJobData.AddSkillLevel(builder, SkillLevel);
			NewBieGuideJobData.AddWalkSpeed(builder, WalkSpeed);
			NewBieGuideJobData.AddSpellSpeed(builder, SpellSpeed);
			NewBieGuideJobData.AddAttackSpped(builder, AttackSpped);
			NewBieGuideJobData.AddCDReduceRate(builder, CDReduceRate);
			NewBieGuideJobData.AddName(builder, NameOffset);
			NewBieGuideJobData.AddID(builder, ID);
			return NewBieGuideJobData.EndNewBieGuideJobData(builder);
		}

		// Token: 0x060043BA RID: 17338 RVA: 0x000DB41C File Offset: 0x000D981C
		public static void StartNewBieGuideJobData(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x060043BB RID: 17339 RVA: 0x000DB426 File Offset: 0x000D9826
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060043BC RID: 17340 RVA: 0x000DB431 File Offset: 0x000D9831
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060043BD RID: 17341 RVA: 0x000DB442 File Offset: 0x000D9842
		public static void AddCDReduceRate(FlatBufferBuilder builder, int CDReduceRate)
		{
			builder.AddInt(2, CDReduceRate, 0);
		}

		// Token: 0x060043BE RID: 17342 RVA: 0x000DB44D File Offset: 0x000D984D
		public static void AddAttackSpped(FlatBufferBuilder builder, int AttackSpped)
		{
			builder.AddInt(3, AttackSpped, 0);
		}

		// Token: 0x060043BF RID: 17343 RVA: 0x000DB458 File Offset: 0x000D9858
		public static void AddSpellSpeed(FlatBufferBuilder builder, int SpellSpeed)
		{
			builder.AddInt(4, SpellSpeed, 0);
		}

		// Token: 0x060043C0 RID: 17344 RVA: 0x000DB463 File Offset: 0x000D9863
		public static void AddWalkSpeed(FlatBufferBuilder builder, int WalkSpeed)
		{
			builder.AddInt(5, WalkSpeed, 0);
		}

		// Token: 0x060043C1 RID: 17345 RVA: 0x000DB46E File Offset: 0x000D986E
		public static void AddSkillLevel(FlatBufferBuilder builder, int SkillLevel)
		{
			builder.AddInt(6, SkillLevel, 0);
		}

		// Token: 0x060043C2 RID: 17346 RVA: 0x000DB479 File Offset: 0x000D9879
		public static void AddSkillList(FlatBufferBuilder builder, VectorOffset SkillListOffset)
		{
			builder.AddOffset(7, SkillListOffset.Value, 0);
		}

		// Token: 0x060043C3 RID: 17347 RVA: 0x000DB48C File Offset: 0x000D988C
		public static VectorOffset CreateSkillListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060043C4 RID: 17348 RVA: 0x000DB4C9 File Offset: 0x000D98C9
		public static void StartSkillListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060043C5 RID: 17349 RVA: 0x000DB4D4 File Offset: 0x000D98D4
		public static void AddEquipmentID(FlatBufferBuilder builder, VectorOffset EquipmentIDOffset)
		{
			builder.AddOffset(8, EquipmentIDOffset.Value, 0);
		}

		// Token: 0x060043C6 RID: 17350 RVA: 0x000DB4E8 File Offset: 0x000D98E8
		public static VectorOffset CreateEquipmentIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060043C7 RID: 17351 RVA: 0x000DB525 File Offset: 0x000D9925
		public static void StartEquipmentIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060043C8 RID: 17352 RVA: 0x000DB530 File Offset: 0x000D9930
		public static void AddSecondComboSkill(FlatBufferBuilder builder, VectorOffset SecondComboSkillOffset)
		{
			builder.AddOffset(9, SecondComboSkillOffset.Value, 0);
		}

		// Token: 0x060043C9 RID: 17353 RVA: 0x000DB544 File Offset: 0x000D9944
		public static VectorOffset CreateSecondComboSkillVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060043CA RID: 17354 RVA: 0x000DB581 File Offset: 0x000D9981
		public static void StartSecondComboSkillVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060043CB RID: 17355 RVA: 0x000DB58C File Offset: 0x000D998C
		public static void AddThirdComboSkill(FlatBufferBuilder builder, VectorOffset ThirdComboSkillOffset)
		{
			builder.AddOffset(10, ThirdComboSkillOffset.Value, 0);
		}

		// Token: 0x060043CC RID: 17356 RVA: 0x000DB5A0 File Offset: 0x000D99A0
		public static VectorOffset CreateThirdComboSkillVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060043CD RID: 17357 RVA: 0x000DB5DD File Offset: 0x000D99DD
		public static void StartThirdComboSkillVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060043CE RID: 17358 RVA: 0x000DB5E8 File Offset: 0x000D99E8
		public static Offset<NewBieGuideJobData> EndNewBieGuideJobData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NewBieGuideJobData>(value);
		}

		// Token: 0x060043CF RID: 17359 RVA: 0x000DB602 File Offset: 0x000D9A02
		public static void FinishNewBieGuideJobDataBuffer(FlatBufferBuilder builder, Offset<NewBieGuideJobData> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018F6 RID: 6390
		private Table __p = new Table();

		// Token: 0x040018F7 RID: 6391
		private FlatBufferArray<int> SkillListValue;

		// Token: 0x040018F8 RID: 6392
		private FlatBufferArray<int> EquipmentIDValue;

		// Token: 0x040018F9 RID: 6393
		private FlatBufferArray<int> SecondComboSkillValue;

		// Token: 0x040018FA RID: 6394
		private FlatBufferArray<int> ThirdComboSkillValue;

		// Token: 0x02000527 RID: 1319
		public enum eCrypt
		{
			// Token: 0x040018FC RID: 6396
			code = 1083542827
		}
	}
}
