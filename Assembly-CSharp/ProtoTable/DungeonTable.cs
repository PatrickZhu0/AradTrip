using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003AA RID: 938
	public class DungeonTable : IFlatbufferObject
	{
		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x060028FD RID: 10493 RVA: 0x0009B45C File Offset: 0x0009985C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060028FE RID: 10494 RVA: 0x0009B469 File Offset: 0x00099869
		public static DungeonTable GetRootAsDungeonTable(ByteBuffer _bb)
		{
			return DungeonTable.GetRootAsDungeonTable(_bb, new DungeonTable());
		}

		// Token: 0x060028FF RID: 10495 RVA: 0x0009B476 File Offset: 0x00099876
		public static DungeonTable GetRootAsDungeonTable(ByteBuffer _bb, DungeonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002900 RID: 10496 RVA: 0x0009B492 File Offset: 0x00099892
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002901 RID: 10497 RVA: 0x0009B4AC File Offset: 0x000998AC
		public DungeonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x0009B4B8 File Offset: 0x000998B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x06002903 RID: 10499 RVA: 0x0009B504 File Offset: 0x00099904
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002904 RID: 10500 RVA: 0x0009B546 File Offset: 0x00099946
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x06002905 RID: 10501 RVA: 0x0009B554 File Offset: 0x00099954
		public string Oldname
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002906 RID: 10502 RVA: 0x0009B596 File Offset: 0x00099996
		public ArraySegment<byte>? GetOldnameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x06002907 RID: 10503 RVA: 0x0009B5A4 File Offset: 0x000999A4
		public string TumbPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002908 RID: 10504 RVA: 0x0009B5E7 File Offset: 0x000999E7
		public ArraySegment<byte>? GetTumbPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06002909 RID: 10505 RVA: 0x0009B5F8 File Offset: 0x000999F8
		public string TumbChPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600290A RID: 10506 RVA: 0x0009B63B File Offset: 0x00099A3B
		public ArraySegment<byte>? GetTumbChPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x0600290B RID: 10507 RVA: 0x0009B64C File Offset: 0x00099A4C
		public string LoadingBgPath
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600290C RID: 10508 RVA: 0x0009B68F File Offset: 0x00099A8F
		public ArraySegment<byte>? GetLoadingBgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x0600290D RID: 10509 RVA: 0x0009B6A0 File Offset: 0x00099AA0
		public string Description
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600290E RID: 10510 RVA: 0x0009B6E3 File Offset: 0x00099AE3
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x0600290F RID: 10511 RVA: 0x0009B6F4 File Offset: 0x00099AF4
		public string HardDescription
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002910 RID: 10512 RVA: 0x0009B737 File Offset: 0x00099B37
		public ArraySegment<byte>? GetHardDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x06002911 RID: 10513 RVA: 0x0009B748 File Offset: 0x00099B48
		public int Level
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x06002912 RID: 10514 RVA: 0x0009B794 File Offset: 0x00099B94
		public DungeonTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(22);
				return (DungeonTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x06002913 RID: 10515 RVA: 0x0009B7D8 File Offset: 0x00099BD8
		public DungeonTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(24);
				return (DungeonTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000949 RID: 2377
		// (get) Token: 0x06002914 RID: 10516 RVA: 0x0009B81C File Offset: 0x00099C1C
		public DungeonTable.eThreeType ThreeType
		{
			get
			{
				int num = this.__p.__offset(26);
				return (DungeonTable.eThreeType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06002915 RID: 10517 RVA: 0x0009B860 File Offset: 0x00099C60
		public DungeonTable.eCardType CardType
		{
			get
			{
				int num = this.__p.__offset(28);
				return (DungeonTable.eCardType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06002916 RID: 10518 RVA: 0x0009B8A4 File Offset: 0x00099CA4
		public DungeonTable.eHard Hard
		{
			get
			{
				int num = this.__p.__offset(30);
				return (DungeonTable.eHard)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x06002917 RID: 10519 RVA: 0x0009B8E8 File Offset: 0x00099CE8
		public int Tag
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x06002918 RID: 10520 RVA: 0x0009B934 File Offset: 0x00099D34
		public int ResistMagic
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06002919 RID: 10521 RVA: 0x0009B980 File Offset: 0x00099D80
		public string RecommendLevel
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600291A RID: 10522 RVA: 0x0009B9C3 File Offset: 0x00099DC3
		public ArraySegment<byte>? GetRecommendLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x0600291B RID: 10523 RVA: 0x0009B9D4 File Offset: 0x00099DD4
		public int HardAdaptType
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x0600291C RID: 10524 RVA: 0x0009BA20 File Offset: 0x00099E20
		public int MaxHardAdaptLevel
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x0600291D RID: 10525 RVA: 0x0009BA6C File Offset: 0x00099E6C
		public int SingleBarValue
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600291E RID: 10526 RVA: 0x0009BAB8 File Offset: 0x00099EB8
		public int DropItemsArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x0600291F RID: 10527 RVA: 0x0009BB08 File Offset: 0x00099F08
		public int DropItemsLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002920 RID: 10528 RVA: 0x0009BB3B File Offset: 0x00099F3B
		public ArraySegment<byte>? GetDropItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06002921 RID: 10529 RVA: 0x0009BB4A File Offset: 0x00099F4A
		public FlatBufferArray<int> DropItems
		{
			get
			{
				if (this.DropItemsValue == null)
				{
					this.DropItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.DropItemsArray), this.DropItemsLength);
				}
				return this.DropItemsValue;
			}
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x0009BB7C File Offset: 0x00099F7C
		public int HellDropItemsArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06002923 RID: 10531 RVA: 0x0009BBCC File Offset: 0x00099FCC
		public int HellDropItemsLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x0009BBFF File Offset: 0x00099FFF
		public ArraySegment<byte>? GetHellDropItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06002925 RID: 10533 RVA: 0x0009BC0E File Offset: 0x0009A00E
		public FlatBufferArray<int> HellDropItems
		{
			get
			{
				if (this.HellDropItemsValue == null)
				{
					this.HellDropItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.HellDropItemsArray), this.HellDropItemsLength);
				}
				return this.HellDropItemsValue;
			}
		}

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06002926 RID: 10534 RVA: 0x0009BC40 File Offset: 0x0009A040
		public int MinLevel
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06002927 RID: 10535 RVA: 0x0009BC8C File Offset: 0x0009A08C
		public int storyTaskID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06002928 RID: 10536 RVA: 0x0009BCD8 File Offset: 0x0009A0D8
		public int PreTaskID
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002929 RID: 10537 RVA: 0x0009BD24 File Offset: 0x0009A124
		public int storyDungeonIDsArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x0600292A RID: 10538 RVA: 0x0009BD74 File Offset: 0x0009A174
		public int storyDungeonIDsLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600292B RID: 10539 RVA: 0x0009BDA7 File Offset: 0x0009A1A7
		public ArraySegment<byte>? GetStoryDungeonIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x0600292C RID: 10540 RVA: 0x0009BDB6 File Offset: 0x0009A1B6
		public FlatBufferArray<int> storyDungeonIDs
		{
			get
			{
				if (this.storyDungeonIDsValue == null)
				{
					this.storyDungeonIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.storyDungeonIDsArray), this.storyDungeonIDsLength);
				}
				return this.storyDungeonIDsValue;
			}
		}

		// Token: 0x0600292D RID: 10541 RVA: 0x0009BDE8 File Offset: 0x0009A1E8
		public int PreDungeonIDsArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x0600292E RID: 10542 RVA: 0x0009BE38 File Offset: 0x0009A238
		public int PreDungeonIDsLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x0009BE6B File Offset: 0x0009A26B
		public ArraySegment<byte>? GetPreDungeonIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x06002930 RID: 10544 RVA: 0x0009BE7A File Offset: 0x0009A27A
		public FlatBufferArray<int> PreDungeonIDs
		{
			get
			{
				if (this.PreDungeonIDsValue == null)
				{
					this.PreDungeonIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.PreDungeonIDsArray), this.PreDungeonIDsLength);
				}
				return this.PreDungeonIDsValue;
			}
		}

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x06002931 RID: 10545 RVA: 0x0009BEAC File Offset: 0x0009A2AC
		public string DungeonLoadingConfig
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002932 RID: 10546 RVA: 0x0009BEEF File Offset: 0x0009A2EF
		public ArraySegment<byte>? GetDungeonLoadingConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x06002933 RID: 10547 RVA: 0x0009BF00 File Offset: 0x0009A300
		public string DungeonConfig
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x0009BF43 File Offset: 0x0009A343
		public ArraySegment<byte>? GetDungeonConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x06002935 RID: 10549 RVA: 0x0009BF54 File Offset: 0x0009A354
		public int IsExpAdapt
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x06002936 RID: 10550 RVA: 0x0009BFA0 File Offset: 0x0009A3A0
		public int ExpReward
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000961 RID: 2401
		// (get) Token: 0x06002937 RID: 10551 RVA: 0x0009BFEC File Offset: 0x0009A3EC
		public UnionCell TimeSplitArg
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06002938 RID: 10552 RVA: 0x0009C044 File Offset: 0x0009A444
		public UnionCell RebornSplitArg
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x06002939 RID: 10553 RVA: 0x0009C09C File Offset: 0x0009A49C
		public UnionCell HitSplitArg
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x0600293A RID: 10554 RVA: 0x0009C0F4 File Offset: 0x0009A4F4
		public int TimeArg
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x0600293B RID: 10555 RVA: 0x0009C140 File Offset: 0x0009A540
		public int BackHitArg
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x0009C18C File Offset: 0x0009A58C
		public int NormalMonsterDropArray(int j)
		{
			int num = this.__p.__offset(76);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x0600293D RID: 10557 RVA: 0x0009C1DC File Offset: 0x0009A5DC
		public int NormalMonsterDropLength
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600293E RID: 10558 RVA: 0x0009C20F File Offset: 0x0009A60F
		public ArraySegment<byte>? GetNormalMonsterDropBytes()
		{
			return this.__p.__vector_as_arraysegment(76);
		}

		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x0600293F RID: 10559 RVA: 0x0009C21E File Offset: 0x0009A61E
		public FlatBufferArray<int> NormalMonsterDrop
		{
			get
			{
				if (this.NormalMonsterDropValue == null)
				{
					this.NormalMonsterDropValue = new FlatBufferArray<int>(new Func<int, int>(this.NormalMonsterDropArray), this.NormalMonsterDropLength);
				}
				return this.NormalMonsterDropValue;
			}
		}

		// Token: 0x06002940 RID: 10560 RVA: 0x0009C250 File Offset: 0x0009A650
		public int EliteMonsterDropArray(int j)
		{
			int num = this.__p.__offset(78);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06002941 RID: 10561 RVA: 0x0009C2A0 File Offset: 0x0009A6A0
		public int EliteMonsterDropLength
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002942 RID: 10562 RVA: 0x0009C2D3 File Offset: 0x0009A6D3
		public ArraySegment<byte>? GetEliteMonsterDropBytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06002943 RID: 10563 RVA: 0x0009C2E2 File Offset: 0x0009A6E2
		public FlatBufferArray<int> EliteMonsterDrop
		{
			get
			{
				if (this.EliteMonsterDropValue == null)
				{
					this.EliteMonsterDropValue = new FlatBufferArray<int>(new Func<int, int>(this.EliteMonsterDropArray), this.EliteMonsterDropLength);
				}
				return this.EliteMonsterDropValue;
			}
		}

		// Token: 0x06002944 RID: 10564 RVA: 0x0009C314 File Offset: 0x0009A714
		public int BossMonsterDropArray(int j)
		{
			int num = this.__p.__offset(80);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06002945 RID: 10565 RVA: 0x0009C364 File Offset: 0x0009A764
		public int BossMonsterDropLength
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002946 RID: 10566 RVA: 0x0009C397 File Offset: 0x0009A797
		public ArraySegment<byte>? GetBossMonsterDropBytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06002947 RID: 10567 RVA: 0x0009C3A6 File Offset: 0x0009A7A6
		public FlatBufferArray<int> BossMonsterDrop
		{
			get
			{
				if (this.BossMonsterDropValue == null)
				{
					this.BossMonsterDropValue = new FlatBufferArray<int>(new Func<int, int>(this.BossMonsterDropArray), this.BossMonsterDropLength);
				}
				return this.BossMonsterDropValue;
			}
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x0009C3D8 File Offset: 0x0009A7D8
		public int DungeonDropArray(int j)
		{
			int num = this.__p.__offset(82);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06002949 RID: 10569 RVA: 0x0009C428 File Offset: 0x0009A828
		public int DungeonDropLength
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x0009C45B File Offset: 0x0009A85B
		public ArraySegment<byte>? GetDungeonDropBytes()
		{
			return this.__p.__vector_as_arraysegment(82);
		}

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x0600294B RID: 10571 RVA: 0x0009C46A File Offset: 0x0009A86A
		public FlatBufferArray<int> DungeonDrop
		{
			get
			{
				if (this.DungeonDropValue == null)
				{
					this.DungeonDropValue = new FlatBufferArray<int>(new Func<int, int>(this.DungeonDropArray), this.DungeonDropLength);
				}
				return this.DungeonDropValue;
			}
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x0009C49C File Offset: 0x0009A89C
		public int ActivityDropArray(int j)
		{
			int num = this.__p.__offset(84);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x0600294D RID: 10573 RVA: 0x0009C4EC File Offset: 0x0009A8EC
		public int ActivityDropLength
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x0009C51F File Offset: 0x0009A91F
		public ArraySegment<byte>? GetActivityDropBytes()
		{
			return this.__p.__vector_as_arraysegment(84);
		}

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x0600294F RID: 10575 RVA: 0x0009C52E File Offset: 0x0009A92E
		public FlatBufferArray<int> ActivityDrop
		{
			get
			{
				if (this.ActivityDropValue == null)
				{
					this.ActivityDropValue = new FlatBufferArray<int>(new Func<int, int>(this.ActivityDropArray), this.ActivityDropLength);
				}
				return this.ActivityDropValue;
			}
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x0009C560 File Offset: 0x0009A960
		public int DungeonFirstDropArray(int j)
		{
			int num = this.__p.__offset(86);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06002951 RID: 10577 RVA: 0x0009C5B0 File Offset: 0x0009A9B0
		public int DungeonFirstDropLength
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x0009C5E3 File Offset: 0x0009A9E3
		public ArraySegment<byte>? GetDungeonFirstDropBytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06002953 RID: 10579 RVA: 0x0009C5F2 File Offset: 0x0009A9F2
		public FlatBufferArray<int> DungeonFirstDrop
		{
			get
			{
				if (this.DungeonFirstDropValue == null)
				{
					this.DungeonFirstDropValue = new FlatBufferArray<int>(new Func<int, int>(this.DungeonFirstDropArray), this.DungeonFirstDropLength);
				}
				return this.DungeonFirstDropValue;
			}
		}

		// Token: 0x06002954 RID: 10580 RVA: 0x0009C624 File Offset: 0x0009AA24
		public int DestructionDropArray(int j)
		{
			int num = this.__p.__offset(88);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06002955 RID: 10581 RVA: 0x0009C674 File Offset: 0x0009AA74
		public int DestructionDropLength
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002956 RID: 10582 RVA: 0x0009C6A7 File Offset: 0x0009AAA7
		public ArraySegment<byte>? GetDestructionDropBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06002957 RID: 10583 RVA: 0x0009C6B6 File Offset: 0x0009AAB6
		public FlatBufferArray<int> DestructionDrop
		{
			get
			{
				if (this.DestructionDropValue == null)
				{
					this.DestructionDropValue = new FlatBufferArray<int>(new Func<int, int>(this.DestructionDropArray), this.DestructionDropLength);
				}
				return this.DestructionDropValue;
			}
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x0009C6E8 File Offset: 0x0009AAE8
		public int EasterEggDropArray(int j)
		{
			int num = this.__p.__offset(90);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06002959 RID: 10585 RVA: 0x0009C738 File Offset: 0x0009AB38
		public int EasterEggDropLength
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x0009C76B File Offset: 0x0009AB6B
		public ArraySegment<byte>? GetEasterEggDropBytes()
		{
			return this.__p.__vector_as_arraysegment(90);
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x0600295B RID: 10587 RVA: 0x0009C77A File Offset: 0x0009AB7A
		public FlatBufferArray<int> EasterEggDrop
		{
			get
			{
				if (this.EasterEggDropValue == null)
				{
					this.EasterEggDropValue = new FlatBufferArray<int>(new Func<int, int>(this.EasterEggDropArray), this.EasterEggDropLength);
				}
				return this.EasterEggDropValue;
			}
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x0009C7AC File Offset: 0x0009ABAC
		public int TaskDropArray(int j)
		{
			int num = this.__p.__offset(92);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x0600295D RID: 10589 RVA: 0x0009C7FC File Offset: 0x0009ABFC
		public int TaskDropLength
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x0009C82F File Offset: 0x0009AC2F
		public ArraySegment<byte>? GetTaskDropBytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x0600295F RID: 10591 RVA: 0x0009C83E File Offset: 0x0009AC3E
		public FlatBufferArray<int> TaskDrop
		{
			get
			{
				if (this.TaskDropValue == null)
				{
					this.TaskDropValue = new FlatBufferArray<int>(new Func<int, int>(this.TaskDropArray), this.TaskDropLength);
				}
				return this.TaskDropValue;
			}
		}

		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06002960 RID: 10592 RVA: 0x0009C870 File Offset: 0x0009AC70
		public int RollDropId
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x06002961 RID: 10593 RVA: 0x0009C8BC File Offset: 0x0009ACBC
		public int CostFatiguePerArea
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x06002962 RID: 10594 RVA: 0x0009C908 File Offset: 0x0009AD08
		public int TicketID
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06002963 RID: 10595 RVA: 0x0009C954 File Offset: 0x0009AD54
		public int TicketNum
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06002964 RID: 10596 RVA: 0x0009C9A0 File Offset: 0x0009ADA0
		public int HellTicketNum
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06002965 RID: 10597 RVA: 0x0009C9EC File Offset: 0x0009ADEC
		public int HellTask
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x0009CA38 File Offset: 0x0009AE38
		public int HellDrop1Array(int j)
		{
			int num = this.__p.__offset(106);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06002967 RID: 10599 RVA: 0x0009CA88 File Offset: 0x0009AE88
		public int HellDrop1Length
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x0009CABB File Offset: 0x0009AEBB
		public ArraySegment<byte>? GetHellDrop1Bytes()
		{
			return this.__p.__vector_as_arraysegment(106);
		}

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06002969 RID: 10601 RVA: 0x0009CACA File Offset: 0x0009AECA
		public FlatBufferArray<int> HellDrop1
		{
			get
			{
				if (this.HellDrop1Value == null)
				{
					this.HellDrop1Value = new FlatBufferArray<int>(new Func<int, int>(this.HellDrop1Array), this.HellDrop1Length);
				}
				return this.HellDrop1Value;
			}
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x0009CAFC File Offset: 0x0009AEFC
		public int HellDrop2Array(int j)
		{
			int num = this.__p.__offset(108);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x0600296B RID: 10603 RVA: 0x0009CB4C File Offset: 0x0009AF4C
		public int HellDrop2Length
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0009CB7F File Offset: 0x0009AF7F
		public ArraySegment<byte>? GetHellDrop2Bytes()
		{
			return this.__p.__vector_as_arraysegment(108);
		}

		// Token: 0x17000981 RID: 2433
		// (get) Token: 0x0600296D RID: 10605 RVA: 0x0009CB8E File Offset: 0x0009AF8E
		public FlatBufferArray<int> HellDrop2
		{
			get
			{
				if (this.HellDrop2Value == null)
				{
					this.HellDrop2Value = new FlatBufferArray<int>(new Func<int, int>(this.HellDrop2Array), this.HellDrop2Length);
				}
				return this.HellDrop2Value;
			}
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x0009CBC0 File Offset: 0x0009AFC0
		public int HellDrop3Array(int j)
		{
			int num = this.__p.__offset(110);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000982 RID: 2434
		// (get) Token: 0x0600296F RID: 10607 RVA: 0x0009CC10 File Offset: 0x0009B010
		public int HellDrop3Length
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x0009CC43 File Offset: 0x0009B043
		public ArraySegment<byte>? GetHellDrop3Bytes()
		{
			return this.__p.__vector_as_arraysegment(110);
		}

		// Token: 0x17000983 RID: 2435
		// (get) Token: 0x06002971 RID: 10609 RVA: 0x0009CC52 File Offset: 0x0009B052
		public FlatBufferArray<int> HellDrop3
		{
			get
			{
				if (this.HellDrop3Value == null)
				{
					this.HellDrop3Value = new FlatBufferArray<int>(new Func<int, int>(this.HellDrop3Array), this.HellDrop3Length);
				}
				return this.HellDrop3Value;
			}
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x0009CC84 File Offset: 0x0009B084
		public int HellActivityDropArray(int j)
		{
			int num = this.__p.__offset(112);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000984 RID: 2436
		// (get) Token: 0x06002973 RID: 10611 RVA: 0x0009CCD4 File Offset: 0x0009B0D4
		public int HellActivityDropLength
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x0009CD07 File Offset: 0x0009B107
		public ArraySegment<byte>? GetHellActivityDropBytes()
		{
			return this.__p.__vector_as_arraysegment(112);
		}

		// Token: 0x17000985 RID: 2437
		// (get) Token: 0x06002975 RID: 10613 RVA: 0x0009CD16 File Offset: 0x0009B116
		public FlatBufferArray<int> HellActivityDrop
		{
			get
			{
				if (this.HellActivityDropValue == null)
				{
					this.HellActivityDropValue = new FlatBufferArray<int>(new Func<int, int>(this.HellActivityDropArray), this.HellActivityDropLength);
				}
				return this.HellActivityDropValue;
			}
		}

		// Token: 0x17000986 RID: 2438
		// (get) Token: 0x06002976 RID: 10614 RVA: 0x0009CD48 File Offset: 0x0009B148
		public int RebornCount
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000987 RID: 2439
		// (get) Token: 0x06002977 RID: 10615 RVA: 0x0009CD94 File Offset: 0x0009B194
		public int TotalRebornCount
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000988 RID: 2440
		// (get) Token: 0x06002978 RID: 10616 RVA: 0x0009CDE0 File Offset: 0x0009B1E0
		public string BGMPath
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x0009CE23 File Offset: 0x0009B223
		public ArraySegment<byte>? GetBGMPathBytes()
		{
			return this.__p.__vector_as_arraysegment(118);
		}

		// Token: 0x17000989 RID: 2441
		// (get) Token: 0x0600297A RID: 10618 RVA: 0x0009CE34 File Offset: 0x0009B234
		public string HellHardBGMPath
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x0009CE77 File Offset: 0x0009B277
		public ArraySegment<byte>? GetHellHardBGMPathBytes()
		{
			return this.__p.__vector_as_arraysegment(120);
		}

		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x0600297C RID: 10620 RVA: 0x0009CE88 File Offset: 0x0009B288
		public string HellDamnHardBGMPath
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x0009CECB File Offset: 0x0009B2CB
		public ArraySegment<byte>? GetHellDamnHardBGMPathBytes()
		{
			return this.__p.__vector_as_arraysegment(122);
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x0009CEDC File Offset: 0x0009B2DC
		public int RaceEndDropBaseMultiArray(int j)
		{
			int num = this.__p.__offset(124);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x0600297F RID: 10623 RVA: 0x0009CF2C File Offset: 0x0009B32C
		public int RaceEndDropBaseMultiLength
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002980 RID: 10624 RVA: 0x0009CF5F File Offset: 0x0009B35F
		public ArraySegment<byte>? GetRaceEndDropBaseMultiBytes()
		{
			return this.__p.__vector_as_arraysegment(124);
		}

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x06002981 RID: 10625 RVA: 0x0009CF6E File Offset: 0x0009B36E
		public FlatBufferArray<int> RaceEndDropBaseMulti
		{
			get
			{
				if (this.RaceEndDropBaseMultiValue == null)
				{
					this.RaceEndDropBaseMultiValue = new FlatBufferArray<int>(new Func<int, int>(this.RaceEndDropBaseMultiArray), this.RaceEndDropBaseMultiLength);
				}
				return this.RaceEndDropBaseMultiValue;
			}
		}

		// Token: 0x06002982 RID: 10626 RVA: 0x0009CFA0 File Offset: 0x0009B3A0
		public string RaceEndDropMultiCostArray(int j)
		{
			int num = this.__p.__offset(126);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x06002983 RID: 10627 RVA: 0x0009CFE8 File Offset: 0x0009B3E8
		public int RaceEndDropMultiCostLength
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x06002984 RID: 10628 RVA: 0x0009D01B File Offset: 0x0009B41B
		public FlatBufferArray<string> RaceEndDropMultiCost
		{
			get
			{
				if (this.RaceEndDropMultiCostValue == null)
				{
					this.RaceEndDropMultiCostValue = new FlatBufferArray<string>(new Func<int, string>(this.RaceEndDropMultiCostArray), this.RaceEndDropMultiCostLength);
				}
				return this.RaceEndDropMultiCostValue;
			}
		}

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x06002985 RID: 10629 RVA: 0x0009D04C File Offset: 0x0009B44C
		public int ActivityID
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x06002986 RID: 10630 RVA: 0x0009D09C File Offset: 0x0009B49C
		public int DailyMaxTime
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x0009D0EC File Offset: 0x0009B4EC
		public int BuffDrugConfigArray(int j)
		{
			int num = this.__p.__offset(132);
			return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x06002988 RID: 10632 RVA: 0x0009D13C File Offset: 0x0009B53C
		public int BuffDrugConfigLength
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x0009D172 File Offset: 0x0009B572
		public ArraySegment<byte>? GetBuffDrugConfigBytes()
		{
			return this.__p.__vector_as_arraysegment(132);
		}

		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x0600298A RID: 10634 RVA: 0x0009D184 File Offset: 0x0009B584
		public FlatBufferArray<int> BuffDrugConfig
		{
			get
			{
				if (this.BuffDrugConfigValue == null)
				{
					this.BuffDrugConfigValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffDrugConfigArray), this.BuffDrugConfigLength);
				}
				return this.BuffDrugConfigValue;
			}
		}

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x0600298B RID: 10635 RVA: 0x0009D1B4 File Offset: 0x0009B5B4
		public int MostCostStamina
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000994 RID: 2452
		// (get) Token: 0x0600298C RID: 10636 RVA: 0x0009D204 File Offset: 0x0009B604
		public int HellSplitLevel
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000995 RID: 2453
		// (get) Token: 0x0600298D RID: 10637 RVA: 0x0009D254 File Offset: 0x0009B654
		public int HellSplitLevelWeight
		{
			get
			{
				int num = this.__p.__offset(138);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000996 RID: 2454
		// (get) Token: 0x0600298E RID: 10638 RVA: 0x0009D2A4 File Offset: 0x0009B6A4
		public int OpenAutoFight
		{
			get
			{
				int num = this.__p.__offset(140);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000997 RID: 2455
		// (get) Token: 0x0600298F RID: 10639 RVA: 0x0009D2F4 File Offset: 0x0009B6F4
		public int OnlyRaceEndProfit
		{
			get
			{
				int num = this.__p.__offset(142);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000998 RID: 2456
		// (get) Token: 0x06002990 RID: 10640 RVA: 0x0009D344 File Offset: 0x0009B744
		public int HasMasterExpAddition
		{
			get
			{
				int num = this.__p.__offset(144);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000999 RID: 2457
		// (get) Token: 0x06002991 RID: 10641 RVA: 0x0009D394 File Offset: 0x0009B794
		public string dungeonLevelPath
		{
			get
			{
				int num = this.__p.__offset(146);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x0009D3DA File Offset: 0x0009B7DA
		public ArraySegment<byte>? GetDungeonLevelPathBytes()
		{
			return this.__p.__vector_as_arraysegment(146);
		}

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x06002993 RID: 10643 RVA: 0x0009D3EC File Offset: 0x0009B7EC
		public string GuideTasks
		{
			get
			{
				int num = this.__p.__offset(148);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x0009D432 File Offset: 0x0009B832
		public ArraySegment<byte>? GetGuideTasksBytes()
		{
			return this.__p.__vector_as_arraysegment(148);
		}

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x06002995 RID: 10645 RVA: 0x0009D444 File Offset: 0x0009B844
		public bool NeedForceGC
		{
			get
			{
				int num = this.__p.__offset(150);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x06002996 RID: 10646 RVA: 0x0009D494 File Offset: 0x0009B894
		public int IsSingle
		{
			get
			{
				int num = this.__p.__offset(152);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700099D RID: 2461
		// (get) Token: 0x06002997 RID: 10647 RVA: 0x0009D4E4 File Offset: 0x0009B8E4
		public int onlyRaceEndSettlement
		{
			get
			{
				int num = this.__p.__offset(154);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700099E RID: 2462
		// (get) Token: 0x06002998 RID: 10648 RVA: 0x0009D534 File Offset: 0x0009B934
		public int ownerEntryId
		{
			get
			{
				int num = this.__p.__offset(156);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x06002999 RID: 10649 RVA: 0x0009D584 File Offset: 0x0009B984
		public int weightEntry
		{
			get
			{
				int num = this.__p.__offset(158);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x0600299A RID: 10650 RVA: 0x0009D5D4 File Offset: 0x0009B9D4
		public string PlayingDescription
		{
			get
			{
				int num = this.__p.__offset(160);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600299B RID: 10651 RVA: 0x0009D61A File Offset: 0x0009BA1A
		public ArraySegment<byte>? GetPlayingDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(160);
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x0600299C RID: 10652 RVA: 0x0009D62C File Offset: 0x0009BA2C
		public string ExchangeStoreEntrance
		{
			get
			{
				int num = this.__p.__offset(162);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600299D RID: 10653 RVA: 0x0009D672 File Offset: 0x0009BA72
		public ArraySegment<byte>? GetExchangeStoreEntranceBytes()
		{
			return this.__p.__vector_as_arraysegment(162);
		}

		// Token: 0x0600299E RID: 10654 RVA: 0x0009D684 File Offset: 0x0009BA84
		public string EliteDungeonPrevChapterArray(int j)
		{
			int num = this.__p.__offset(164);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x0600299F RID: 10655 RVA: 0x0009D6D0 File Offset: 0x0009BAD0
		public int EliteDungeonPrevChapterLength
		{
			get
			{
				int num = this.__p.__offset(164);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170009A3 RID: 2467
		// (get) Token: 0x060029A0 RID: 10656 RVA: 0x0009D706 File Offset: 0x0009BB06
		public FlatBufferArray<string> EliteDungeonPrevChapter
		{
			get
			{
				if (this.EliteDungeonPrevChapterValue == null)
				{
					this.EliteDungeonPrevChapterValue = new FlatBufferArray<string>(new Func<int, string>(this.EliteDungeonPrevChapterArray), this.EliteDungeonPrevChapterLength);
				}
				return this.EliteDungeonPrevChapterValue;
			}
		}

		// Token: 0x170009A4 RID: 2468
		// (get) Token: 0x060029A1 RID: 10657 RVA: 0x0009D738 File Offset: 0x0009BB38
		public int LimitTime
		{
			get
			{
				int num = this.__p.__offset(166);
				return (num == 0) ? 0 : (-265276654 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060029A2 RID: 10658 RVA: 0x0009D788 File Offset: 0x0009BB88
		public static Offset<DungeonTable> CreateDungeonTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset OldnameOffset = default(StringOffset), StringOffset TumbPathOffset = default(StringOffset), StringOffset TumbChPathOffset = default(StringOffset), StringOffset LoadingBgPathOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), StringOffset HardDescriptionOffset = default(StringOffset), int Level = 0, DungeonTable.eType Type = DungeonTable.eType.L_NORMAL, DungeonTable.eSubType SubType = DungeonTable.eSubType.S_NORMAL, DungeonTable.eThreeType ThreeType = DungeonTable.eThreeType.T_NORMAL, DungeonTable.eCardType CardType = DungeonTable.eCardType.None, DungeonTable.eHard Hard = DungeonTable.eHard.NORMAL, int Tag = 0, int ResistMagic = 0, StringOffset RecommendLevelOffset = default(StringOffset), int HardAdaptType = 0, int MaxHardAdaptLevel = 0, int SingleBarValue = 0, VectorOffset DropItemsOffset = default(VectorOffset), VectorOffset HellDropItemsOffset = default(VectorOffset), int MinLevel = 0, int storyTaskID = 0, int PreTaskID = 0, VectorOffset storyDungeonIDsOffset = default(VectorOffset), VectorOffset PreDungeonIDsOffset = default(VectorOffset), StringOffset DungeonLoadingConfigOffset = default(StringOffset), StringOffset DungeonConfigOffset = default(StringOffset), int IsExpAdapt = 0, int ExpReward = 0, Offset<UnionCell> TimeSplitArgOffset = default(Offset<UnionCell>), Offset<UnionCell> RebornSplitArgOffset = default(Offset<UnionCell>), Offset<UnionCell> HitSplitArgOffset = default(Offset<UnionCell>), int TimeArg = 0, int BackHitArg = 0, VectorOffset NormalMonsterDropOffset = default(VectorOffset), VectorOffset EliteMonsterDropOffset = default(VectorOffset), VectorOffset BossMonsterDropOffset = default(VectorOffset), VectorOffset DungeonDropOffset = default(VectorOffset), VectorOffset ActivityDropOffset = default(VectorOffset), VectorOffset DungeonFirstDropOffset = default(VectorOffset), VectorOffset DestructionDropOffset = default(VectorOffset), VectorOffset EasterEggDropOffset = default(VectorOffset), VectorOffset TaskDropOffset = default(VectorOffset), int RollDropId = 0, int CostFatiguePerArea = 0, int TicketID = 0, int TicketNum = 0, int HellTicketNum = 0, int HellTask = 0, VectorOffset HellDrop1Offset = default(VectorOffset), VectorOffset HellDrop2Offset = default(VectorOffset), VectorOffset HellDrop3Offset = default(VectorOffset), VectorOffset HellActivityDropOffset = default(VectorOffset), int RebornCount = 0, int TotalRebornCount = 0, StringOffset BGMPathOffset = default(StringOffset), StringOffset HellHardBGMPathOffset = default(StringOffset), StringOffset HellDamnHardBGMPathOffset = default(StringOffset), VectorOffset RaceEndDropBaseMultiOffset = default(VectorOffset), VectorOffset RaceEndDropMultiCostOffset = default(VectorOffset), int ActivityID = 0, int DailyMaxTime = 0, VectorOffset BuffDrugConfigOffset = default(VectorOffset), int MostCostStamina = 0, int HellSplitLevel = 0, int HellSplitLevelWeight = 0, int OpenAutoFight = 0, int OnlyRaceEndProfit = 0, int HasMasterExpAddition = 0, StringOffset dungeonLevelPathOffset = default(StringOffset), StringOffset GuideTasksOffset = default(StringOffset), bool NeedForceGC = false, int IsSingle = 0, int onlyRaceEndSettlement = 0, int ownerEntryId = 0, int weightEntry = 0, StringOffset PlayingDescriptionOffset = default(StringOffset), StringOffset ExchangeStoreEntranceOffset = default(StringOffset), VectorOffset EliteDungeonPrevChapterOffset = default(VectorOffset), int LimitTime = 0)
		{
			builder.StartObject(82);
			DungeonTable.AddLimitTime(builder, LimitTime);
			DungeonTable.AddEliteDungeonPrevChapter(builder, EliteDungeonPrevChapterOffset);
			DungeonTable.AddExchangeStoreEntrance(builder, ExchangeStoreEntranceOffset);
			DungeonTable.AddPlayingDescription(builder, PlayingDescriptionOffset);
			DungeonTable.AddWeightEntry(builder, weightEntry);
			DungeonTable.AddOwnerEntryId(builder, ownerEntryId);
			DungeonTable.AddOnlyRaceEndSettlement(builder, onlyRaceEndSettlement);
			DungeonTable.AddIsSingle(builder, IsSingle);
			DungeonTable.AddGuideTasks(builder, GuideTasksOffset);
			DungeonTable.AddDungeonLevelPath(builder, dungeonLevelPathOffset);
			DungeonTable.AddHasMasterExpAddition(builder, HasMasterExpAddition);
			DungeonTable.AddOnlyRaceEndProfit(builder, OnlyRaceEndProfit);
			DungeonTable.AddOpenAutoFight(builder, OpenAutoFight);
			DungeonTable.AddHellSplitLevelWeight(builder, HellSplitLevelWeight);
			DungeonTable.AddHellSplitLevel(builder, HellSplitLevel);
			DungeonTable.AddMostCostStamina(builder, MostCostStamina);
			DungeonTable.AddBuffDrugConfig(builder, BuffDrugConfigOffset);
			DungeonTable.AddDailyMaxTime(builder, DailyMaxTime);
			DungeonTable.AddActivityID(builder, ActivityID);
			DungeonTable.AddRaceEndDropMultiCost(builder, RaceEndDropMultiCostOffset);
			DungeonTable.AddRaceEndDropBaseMulti(builder, RaceEndDropBaseMultiOffset);
			DungeonTable.AddHellDamnHardBGMPath(builder, HellDamnHardBGMPathOffset);
			DungeonTable.AddHellHardBGMPath(builder, HellHardBGMPathOffset);
			DungeonTable.AddBGMPath(builder, BGMPathOffset);
			DungeonTable.AddTotalRebornCount(builder, TotalRebornCount);
			DungeonTable.AddRebornCount(builder, RebornCount);
			DungeonTable.AddHellActivityDrop(builder, HellActivityDropOffset);
			DungeonTable.AddHellDrop3(builder, HellDrop3Offset);
			DungeonTable.AddHellDrop2(builder, HellDrop2Offset);
			DungeonTable.AddHellDrop1(builder, HellDrop1Offset);
			DungeonTable.AddHellTask(builder, HellTask);
			DungeonTable.AddHellTicketNum(builder, HellTicketNum);
			DungeonTable.AddTicketNum(builder, TicketNum);
			DungeonTable.AddTicketID(builder, TicketID);
			DungeonTable.AddCostFatiguePerArea(builder, CostFatiguePerArea);
			DungeonTable.AddRollDropId(builder, RollDropId);
			DungeonTable.AddTaskDrop(builder, TaskDropOffset);
			DungeonTable.AddEasterEggDrop(builder, EasterEggDropOffset);
			DungeonTable.AddDestructionDrop(builder, DestructionDropOffset);
			DungeonTable.AddDungeonFirstDrop(builder, DungeonFirstDropOffset);
			DungeonTable.AddActivityDrop(builder, ActivityDropOffset);
			DungeonTable.AddDungeonDrop(builder, DungeonDropOffset);
			DungeonTable.AddBossMonsterDrop(builder, BossMonsterDropOffset);
			DungeonTable.AddEliteMonsterDrop(builder, EliteMonsterDropOffset);
			DungeonTable.AddNormalMonsterDrop(builder, NormalMonsterDropOffset);
			DungeonTable.AddBackHitArg(builder, BackHitArg);
			DungeonTable.AddTimeArg(builder, TimeArg);
			DungeonTable.AddHitSplitArg(builder, HitSplitArgOffset);
			DungeonTable.AddRebornSplitArg(builder, RebornSplitArgOffset);
			DungeonTable.AddTimeSplitArg(builder, TimeSplitArgOffset);
			DungeonTable.AddExpReward(builder, ExpReward);
			DungeonTable.AddIsExpAdapt(builder, IsExpAdapt);
			DungeonTable.AddDungeonConfig(builder, DungeonConfigOffset);
			DungeonTable.AddDungeonLoadingConfig(builder, DungeonLoadingConfigOffset);
			DungeonTable.AddPreDungeonIDs(builder, PreDungeonIDsOffset);
			DungeonTable.AddStoryDungeonIDs(builder, storyDungeonIDsOffset);
			DungeonTable.AddPreTaskID(builder, PreTaskID);
			DungeonTable.AddStoryTaskID(builder, storyTaskID);
			DungeonTable.AddMinLevel(builder, MinLevel);
			DungeonTable.AddHellDropItems(builder, HellDropItemsOffset);
			DungeonTable.AddDropItems(builder, DropItemsOffset);
			DungeonTable.AddSingleBarValue(builder, SingleBarValue);
			DungeonTable.AddMaxHardAdaptLevel(builder, MaxHardAdaptLevel);
			DungeonTable.AddHardAdaptType(builder, HardAdaptType);
			DungeonTable.AddRecommendLevel(builder, RecommendLevelOffset);
			DungeonTable.AddResistMagic(builder, ResistMagic);
			DungeonTable.AddTag(builder, Tag);
			DungeonTable.AddHard(builder, Hard);
			DungeonTable.AddCardType(builder, CardType);
			DungeonTable.AddThreeType(builder, ThreeType);
			DungeonTable.AddSubType(builder, SubType);
			DungeonTable.AddType(builder, Type);
			DungeonTable.AddLevel(builder, Level);
			DungeonTable.AddHardDescription(builder, HardDescriptionOffset);
			DungeonTable.AddDescription(builder, DescriptionOffset);
			DungeonTable.AddLoadingBgPath(builder, LoadingBgPathOffset);
			DungeonTable.AddTumbChPath(builder, TumbChPathOffset);
			DungeonTable.AddTumbPath(builder, TumbPathOffset);
			DungeonTable.AddOldname(builder, OldnameOffset);
			DungeonTable.AddName(builder, NameOffset);
			DungeonTable.AddID(builder, ID);
			DungeonTable.AddNeedForceGC(builder, NeedForceGC);
			return DungeonTable.EndDungeonTable(builder);
		}

		// Token: 0x060029A3 RID: 10659 RVA: 0x0009DA30 File Offset: 0x0009BE30
		public static void StartDungeonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(82);
		}

		// Token: 0x060029A4 RID: 10660 RVA: 0x0009DA3A File Offset: 0x0009BE3A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060029A5 RID: 10661 RVA: 0x0009DA45 File Offset: 0x0009BE45
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060029A6 RID: 10662 RVA: 0x0009DA56 File Offset: 0x0009BE56
		public static void AddOldname(FlatBufferBuilder builder, StringOffset OldnameOffset)
		{
			builder.AddOffset(2, OldnameOffset.Value, 0);
		}

		// Token: 0x060029A7 RID: 10663 RVA: 0x0009DA67 File Offset: 0x0009BE67
		public static void AddTumbPath(FlatBufferBuilder builder, StringOffset TumbPathOffset)
		{
			builder.AddOffset(3, TumbPathOffset.Value, 0);
		}

		// Token: 0x060029A8 RID: 10664 RVA: 0x0009DA78 File Offset: 0x0009BE78
		public static void AddTumbChPath(FlatBufferBuilder builder, StringOffset TumbChPathOffset)
		{
			builder.AddOffset(4, TumbChPathOffset.Value, 0);
		}

		// Token: 0x060029A9 RID: 10665 RVA: 0x0009DA89 File Offset: 0x0009BE89
		public static void AddLoadingBgPath(FlatBufferBuilder builder, StringOffset LoadingBgPathOffset)
		{
			builder.AddOffset(5, LoadingBgPathOffset.Value, 0);
		}

		// Token: 0x060029AA RID: 10666 RVA: 0x0009DA9A File Offset: 0x0009BE9A
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(6, DescriptionOffset.Value, 0);
		}

		// Token: 0x060029AB RID: 10667 RVA: 0x0009DAAB File Offset: 0x0009BEAB
		public static void AddHardDescription(FlatBufferBuilder builder, StringOffset HardDescriptionOffset)
		{
			builder.AddOffset(7, HardDescriptionOffset.Value, 0);
		}

		// Token: 0x060029AC RID: 10668 RVA: 0x0009DABC File Offset: 0x0009BEBC
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(8, Level, 0);
		}

		// Token: 0x060029AD RID: 10669 RVA: 0x0009DAC7 File Offset: 0x0009BEC7
		public static void AddType(FlatBufferBuilder builder, DungeonTable.eType Type)
		{
			builder.AddInt(9, (int)Type, 0);
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x0009DAD3 File Offset: 0x0009BED3
		public static void AddSubType(FlatBufferBuilder builder, DungeonTable.eSubType SubType)
		{
			builder.AddInt(10, (int)SubType, 0);
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x0009DADF File Offset: 0x0009BEDF
		public static void AddThreeType(FlatBufferBuilder builder, DungeonTable.eThreeType ThreeType)
		{
			builder.AddInt(11, (int)ThreeType, 0);
		}

		// Token: 0x060029B0 RID: 10672 RVA: 0x0009DAEB File Offset: 0x0009BEEB
		public static void AddCardType(FlatBufferBuilder builder, DungeonTable.eCardType CardType)
		{
			builder.AddInt(12, (int)CardType, 0);
		}

		// Token: 0x060029B1 RID: 10673 RVA: 0x0009DAF7 File Offset: 0x0009BEF7
		public static void AddHard(FlatBufferBuilder builder, DungeonTable.eHard Hard)
		{
			builder.AddInt(13, (int)Hard, 0);
		}

		// Token: 0x060029B2 RID: 10674 RVA: 0x0009DB03 File Offset: 0x0009BF03
		public static void AddTag(FlatBufferBuilder builder, int Tag)
		{
			builder.AddInt(14, Tag, 0);
		}

		// Token: 0x060029B3 RID: 10675 RVA: 0x0009DB0F File Offset: 0x0009BF0F
		public static void AddResistMagic(FlatBufferBuilder builder, int ResistMagic)
		{
			builder.AddInt(15, ResistMagic, 0);
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x0009DB1B File Offset: 0x0009BF1B
		public static void AddRecommendLevel(FlatBufferBuilder builder, StringOffset RecommendLevelOffset)
		{
			builder.AddOffset(16, RecommendLevelOffset.Value, 0);
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x0009DB2D File Offset: 0x0009BF2D
		public static void AddHardAdaptType(FlatBufferBuilder builder, int HardAdaptType)
		{
			builder.AddInt(17, HardAdaptType, 0);
		}

		// Token: 0x060029B6 RID: 10678 RVA: 0x0009DB39 File Offset: 0x0009BF39
		public static void AddMaxHardAdaptLevel(FlatBufferBuilder builder, int MaxHardAdaptLevel)
		{
			builder.AddInt(18, MaxHardAdaptLevel, 0);
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x0009DB45 File Offset: 0x0009BF45
		public static void AddSingleBarValue(FlatBufferBuilder builder, int SingleBarValue)
		{
			builder.AddInt(19, SingleBarValue, 0);
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x0009DB51 File Offset: 0x0009BF51
		public static void AddDropItems(FlatBufferBuilder builder, VectorOffset DropItemsOffset)
		{
			builder.AddOffset(20, DropItemsOffset.Value, 0);
		}

		// Token: 0x060029B9 RID: 10681 RVA: 0x0009DB64 File Offset: 0x0009BF64
		public static VectorOffset CreateDropItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029BA RID: 10682 RVA: 0x0009DBA1 File Offset: 0x0009BFA1
		public static void StartDropItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x0009DBAC File Offset: 0x0009BFAC
		public static void AddHellDropItems(FlatBufferBuilder builder, VectorOffset HellDropItemsOffset)
		{
			builder.AddOffset(21, HellDropItemsOffset.Value, 0);
		}

		// Token: 0x060029BC RID: 10684 RVA: 0x0009DBC0 File Offset: 0x0009BFC0
		public static VectorOffset CreateHellDropItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x0009DBFD File Offset: 0x0009BFFD
		public static void StartHellDropItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x0009DC08 File Offset: 0x0009C008
		public static void AddMinLevel(FlatBufferBuilder builder, int MinLevel)
		{
			builder.AddInt(22, MinLevel, 0);
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x0009DC14 File Offset: 0x0009C014
		public static void AddStoryTaskID(FlatBufferBuilder builder, int storyTaskID)
		{
			builder.AddInt(23, storyTaskID, 0);
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x0009DC20 File Offset: 0x0009C020
		public static void AddPreTaskID(FlatBufferBuilder builder, int PreTaskID)
		{
			builder.AddInt(24, PreTaskID, 0);
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x0009DC2C File Offset: 0x0009C02C
		public static void AddStoryDungeonIDs(FlatBufferBuilder builder, VectorOffset storyDungeonIDsOffset)
		{
			builder.AddOffset(25, storyDungeonIDsOffset.Value, 0);
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x0009DC40 File Offset: 0x0009C040
		public static VectorOffset CreateStoryDungeonIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029C3 RID: 10691 RVA: 0x0009DC7D File Offset: 0x0009C07D
		public static void StartStoryDungeonIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029C4 RID: 10692 RVA: 0x0009DC88 File Offset: 0x0009C088
		public static void AddPreDungeonIDs(FlatBufferBuilder builder, VectorOffset PreDungeonIDsOffset)
		{
			builder.AddOffset(26, PreDungeonIDsOffset.Value, 0);
		}

		// Token: 0x060029C5 RID: 10693 RVA: 0x0009DC9C File Offset: 0x0009C09C
		public static VectorOffset CreatePreDungeonIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029C6 RID: 10694 RVA: 0x0009DCD9 File Offset: 0x0009C0D9
		public static void StartPreDungeonIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029C7 RID: 10695 RVA: 0x0009DCE4 File Offset: 0x0009C0E4
		public static void AddDungeonLoadingConfig(FlatBufferBuilder builder, StringOffset DungeonLoadingConfigOffset)
		{
			builder.AddOffset(27, DungeonLoadingConfigOffset.Value, 0);
		}

		// Token: 0x060029C8 RID: 10696 RVA: 0x0009DCF6 File Offset: 0x0009C0F6
		public static void AddDungeonConfig(FlatBufferBuilder builder, StringOffset DungeonConfigOffset)
		{
			builder.AddOffset(28, DungeonConfigOffset.Value, 0);
		}

		// Token: 0x060029C9 RID: 10697 RVA: 0x0009DD08 File Offset: 0x0009C108
		public static void AddIsExpAdapt(FlatBufferBuilder builder, int IsExpAdapt)
		{
			builder.AddInt(29, IsExpAdapt, 0);
		}

		// Token: 0x060029CA RID: 10698 RVA: 0x0009DD14 File Offset: 0x0009C114
		public static void AddExpReward(FlatBufferBuilder builder, int ExpReward)
		{
			builder.AddInt(30, ExpReward, 0);
		}

		// Token: 0x060029CB RID: 10699 RVA: 0x0009DD20 File Offset: 0x0009C120
		public static void AddTimeSplitArg(FlatBufferBuilder builder, Offset<UnionCell> TimeSplitArgOffset)
		{
			builder.AddOffset(31, TimeSplitArgOffset.Value, 0);
		}

		// Token: 0x060029CC RID: 10700 RVA: 0x0009DD32 File Offset: 0x0009C132
		public static void AddRebornSplitArg(FlatBufferBuilder builder, Offset<UnionCell> RebornSplitArgOffset)
		{
			builder.AddOffset(32, RebornSplitArgOffset.Value, 0);
		}

		// Token: 0x060029CD RID: 10701 RVA: 0x0009DD44 File Offset: 0x0009C144
		public static void AddHitSplitArg(FlatBufferBuilder builder, Offset<UnionCell> HitSplitArgOffset)
		{
			builder.AddOffset(33, HitSplitArgOffset.Value, 0);
		}

		// Token: 0x060029CE RID: 10702 RVA: 0x0009DD56 File Offset: 0x0009C156
		public static void AddTimeArg(FlatBufferBuilder builder, int TimeArg)
		{
			builder.AddInt(34, TimeArg, 0);
		}

		// Token: 0x060029CF RID: 10703 RVA: 0x0009DD62 File Offset: 0x0009C162
		public static void AddBackHitArg(FlatBufferBuilder builder, int BackHitArg)
		{
			builder.AddInt(35, BackHitArg, 0);
		}

		// Token: 0x060029D0 RID: 10704 RVA: 0x0009DD6E File Offset: 0x0009C16E
		public static void AddNormalMonsterDrop(FlatBufferBuilder builder, VectorOffset NormalMonsterDropOffset)
		{
			builder.AddOffset(36, NormalMonsterDropOffset.Value, 0);
		}

		// Token: 0x060029D1 RID: 10705 RVA: 0x0009DD80 File Offset: 0x0009C180
		public static VectorOffset CreateNormalMonsterDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029D2 RID: 10706 RVA: 0x0009DDBD File Offset: 0x0009C1BD
		public static void StartNormalMonsterDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029D3 RID: 10707 RVA: 0x0009DDC8 File Offset: 0x0009C1C8
		public static void AddEliteMonsterDrop(FlatBufferBuilder builder, VectorOffset EliteMonsterDropOffset)
		{
			builder.AddOffset(37, EliteMonsterDropOffset.Value, 0);
		}

		// Token: 0x060029D4 RID: 10708 RVA: 0x0009DDDC File Offset: 0x0009C1DC
		public static VectorOffset CreateEliteMonsterDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029D5 RID: 10709 RVA: 0x0009DE19 File Offset: 0x0009C219
		public static void StartEliteMonsterDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029D6 RID: 10710 RVA: 0x0009DE24 File Offset: 0x0009C224
		public static void AddBossMonsterDrop(FlatBufferBuilder builder, VectorOffset BossMonsterDropOffset)
		{
			builder.AddOffset(38, BossMonsterDropOffset.Value, 0);
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x0009DE38 File Offset: 0x0009C238
		public static VectorOffset CreateBossMonsterDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029D8 RID: 10712 RVA: 0x0009DE75 File Offset: 0x0009C275
		public static void StartBossMonsterDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029D9 RID: 10713 RVA: 0x0009DE80 File Offset: 0x0009C280
		public static void AddDungeonDrop(FlatBufferBuilder builder, VectorOffset DungeonDropOffset)
		{
			builder.AddOffset(39, DungeonDropOffset.Value, 0);
		}

		// Token: 0x060029DA RID: 10714 RVA: 0x0009DE94 File Offset: 0x0009C294
		public static VectorOffset CreateDungeonDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029DB RID: 10715 RVA: 0x0009DED1 File Offset: 0x0009C2D1
		public static void StartDungeonDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029DC RID: 10716 RVA: 0x0009DEDC File Offset: 0x0009C2DC
		public static void AddActivityDrop(FlatBufferBuilder builder, VectorOffset ActivityDropOffset)
		{
			builder.AddOffset(40, ActivityDropOffset.Value, 0);
		}

		// Token: 0x060029DD RID: 10717 RVA: 0x0009DEF0 File Offset: 0x0009C2F0
		public static VectorOffset CreateActivityDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029DE RID: 10718 RVA: 0x0009DF2D File Offset: 0x0009C32D
		public static void StartActivityDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029DF RID: 10719 RVA: 0x0009DF38 File Offset: 0x0009C338
		public static void AddDungeonFirstDrop(FlatBufferBuilder builder, VectorOffset DungeonFirstDropOffset)
		{
			builder.AddOffset(41, DungeonFirstDropOffset.Value, 0);
		}

		// Token: 0x060029E0 RID: 10720 RVA: 0x0009DF4C File Offset: 0x0009C34C
		public static VectorOffset CreateDungeonFirstDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029E1 RID: 10721 RVA: 0x0009DF89 File Offset: 0x0009C389
		public static void StartDungeonFirstDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029E2 RID: 10722 RVA: 0x0009DF94 File Offset: 0x0009C394
		public static void AddDestructionDrop(FlatBufferBuilder builder, VectorOffset DestructionDropOffset)
		{
			builder.AddOffset(42, DestructionDropOffset.Value, 0);
		}

		// Token: 0x060029E3 RID: 10723 RVA: 0x0009DFA8 File Offset: 0x0009C3A8
		public static VectorOffset CreateDestructionDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029E4 RID: 10724 RVA: 0x0009DFE5 File Offset: 0x0009C3E5
		public static void StartDestructionDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029E5 RID: 10725 RVA: 0x0009DFF0 File Offset: 0x0009C3F0
		public static void AddEasterEggDrop(FlatBufferBuilder builder, VectorOffset EasterEggDropOffset)
		{
			builder.AddOffset(43, EasterEggDropOffset.Value, 0);
		}

		// Token: 0x060029E6 RID: 10726 RVA: 0x0009E004 File Offset: 0x0009C404
		public static VectorOffset CreateEasterEggDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029E7 RID: 10727 RVA: 0x0009E041 File Offset: 0x0009C441
		public static void StartEasterEggDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029E8 RID: 10728 RVA: 0x0009E04C File Offset: 0x0009C44C
		public static void AddTaskDrop(FlatBufferBuilder builder, VectorOffset TaskDropOffset)
		{
			builder.AddOffset(44, TaskDropOffset.Value, 0);
		}

		// Token: 0x060029E9 RID: 10729 RVA: 0x0009E060 File Offset: 0x0009C460
		public static VectorOffset CreateTaskDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029EA RID: 10730 RVA: 0x0009E09D File Offset: 0x0009C49D
		public static void StartTaskDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029EB RID: 10731 RVA: 0x0009E0A8 File Offset: 0x0009C4A8
		public static void AddRollDropId(FlatBufferBuilder builder, int RollDropId)
		{
			builder.AddInt(45, RollDropId, 0);
		}

		// Token: 0x060029EC RID: 10732 RVA: 0x0009E0B4 File Offset: 0x0009C4B4
		public static void AddCostFatiguePerArea(FlatBufferBuilder builder, int CostFatiguePerArea)
		{
			builder.AddInt(46, CostFatiguePerArea, 0);
		}

		// Token: 0x060029ED RID: 10733 RVA: 0x0009E0C0 File Offset: 0x0009C4C0
		public static void AddTicketID(FlatBufferBuilder builder, int TicketID)
		{
			builder.AddInt(47, TicketID, 0);
		}

		// Token: 0x060029EE RID: 10734 RVA: 0x0009E0CC File Offset: 0x0009C4CC
		public static void AddTicketNum(FlatBufferBuilder builder, int TicketNum)
		{
			builder.AddInt(48, TicketNum, 0);
		}

		// Token: 0x060029EF RID: 10735 RVA: 0x0009E0D8 File Offset: 0x0009C4D8
		public static void AddHellTicketNum(FlatBufferBuilder builder, int HellTicketNum)
		{
			builder.AddInt(49, HellTicketNum, 0);
		}

		// Token: 0x060029F0 RID: 10736 RVA: 0x0009E0E4 File Offset: 0x0009C4E4
		public static void AddHellTask(FlatBufferBuilder builder, int HellTask)
		{
			builder.AddInt(50, HellTask, 0);
		}

		// Token: 0x060029F1 RID: 10737 RVA: 0x0009E0F0 File Offset: 0x0009C4F0
		public static void AddHellDrop1(FlatBufferBuilder builder, VectorOffset HellDrop1Offset)
		{
			builder.AddOffset(51, HellDrop1Offset.Value, 0);
		}

		// Token: 0x060029F2 RID: 10738 RVA: 0x0009E104 File Offset: 0x0009C504
		public static VectorOffset CreateHellDrop1Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029F3 RID: 10739 RVA: 0x0009E141 File Offset: 0x0009C541
		public static void StartHellDrop1Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x0009E14C File Offset: 0x0009C54C
		public static void AddHellDrop2(FlatBufferBuilder builder, VectorOffset HellDrop2Offset)
		{
			builder.AddOffset(52, HellDrop2Offset.Value, 0);
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x0009E160 File Offset: 0x0009C560
		public static VectorOffset CreateHellDrop2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x0009E19D File Offset: 0x0009C59D
		public static void StartHellDrop2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029F7 RID: 10743 RVA: 0x0009E1A8 File Offset: 0x0009C5A8
		public static void AddHellDrop3(FlatBufferBuilder builder, VectorOffset HellDrop3Offset)
		{
			builder.AddOffset(53, HellDrop3Offset.Value, 0);
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x0009E1BC File Offset: 0x0009C5BC
		public static VectorOffset CreateHellDrop3Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029F9 RID: 10745 RVA: 0x0009E1F9 File Offset: 0x0009C5F9
		public static void StartHellDrop3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029FA RID: 10746 RVA: 0x0009E204 File Offset: 0x0009C604
		public static void AddHellActivityDrop(FlatBufferBuilder builder, VectorOffset HellActivityDropOffset)
		{
			builder.AddOffset(54, HellActivityDropOffset.Value, 0);
		}

		// Token: 0x060029FB RID: 10747 RVA: 0x0009E218 File Offset: 0x0009C618
		public static VectorOffset CreateHellActivityDropVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060029FC RID: 10748 RVA: 0x0009E255 File Offset: 0x0009C655
		public static void StartHellActivityDropVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060029FD RID: 10749 RVA: 0x0009E260 File Offset: 0x0009C660
		public static void AddRebornCount(FlatBufferBuilder builder, int RebornCount)
		{
			builder.AddInt(55, RebornCount, 0);
		}

		// Token: 0x060029FE RID: 10750 RVA: 0x0009E26C File Offset: 0x0009C66C
		public static void AddTotalRebornCount(FlatBufferBuilder builder, int TotalRebornCount)
		{
			builder.AddInt(56, TotalRebornCount, 0);
		}

		// Token: 0x060029FF RID: 10751 RVA: 0x0009E278 File Offset: 0x0009C678
		public static void AddBGMPath(FlatBufferBuilder builder, StringOffset BGMPathOffset)
		{
			builder.AddOffset(57, BGMPathOffset.Value, 0);
		}

		// Token: 0x06002A00 RID: 10752 RVA: 0x0009E28A File Offset: 0x0009C68A
		public static void AddHellHardBGMPath(FlatBufferBuilder builder, StringOffset HellHardBGMPathOffset)
		{
			builder.AddOffset(58, HellHardBGMPathOffset.Value, 0);
		}

		// Token: 0x06002A01 RID: 10753 RVA: 0x0009E29C File Offset: 0x0009C69C
		public static void AddHellDamnHardBGMPath(FlatBufferBuilder builder, StringOffset HellDamnHardBGMPathOffset)
		{
			builder.AddOffset(59, HellDamnHardBGMPathOffset.Value, 0);
		}

		// Token: 0x06002A02 RID: 10754 RVA: 0x0009E2AE File Offset: 0x0009C6AE
		public static void AddRaceEndDropBaseMulti(FlatBufferBuilder builder, VectorOffset RaceEndDropBaseMultiOffset)
		{
			builder.AddOffset(60, RaceEndDropBaseMultiOffset.Value, 0);
		}

		// Token: 0x06002A03 RID: 10755 RVA: 0x0009E2C0 File Offset: 0x0009C6C0
		public static VectorOffset CreateRaceEndDropBaseMultiVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A04 RID: 10756 RVA: 0x0009E2FD File Offset: 0x0009C6FD
		public static void StartRaceEndDropBaseMultiVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A05 RID: 10757 RVA: 0x0009E308 File Offset: 0x0009C708
		public static void AddRaceEndDropMultiCost(FlatBufferBuilder builder, VectorOffset RaceEndDropMultiCostOffset)
		{
			builder.AddOffset(61, RaceEndDropMultiCostOffset.Value, 0);
		}

		// Token: 0x06002A06 RID: 10758 RVA: 0x0009E31C File Offset: 0x0009C71C
		public static VectorOffset CreateRaceEndDropMultiCostVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A07 RID: 10759 RVA: 0x0009E362 File Offset: 0x0009C762
		public static void StartRaceEndDropMultiCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A08 RID: 10760 RVA: 0x0009E36D File Offset: 0x0009C76D
		public static void AddActivityID(FlatBufferBuilder builder, int ActivityID)
		{
			builder.AddInt(62, ActivityID, 0);
		}

		// Token: 0x06002A09 RID: 10761 RVA: 0x0009E379 File Offset: 0x0009C779
		public static void AddDailyMaxTime(FlatBufferBuilder builder, int DailyMaxTime)
		{
			builder.AddInt(63, DailyMaxTime, 0);
		}

		// Token: 0x06002A0A RID: 10762 RVA: 0x0009E385 File Offset: 0x0009C785
		public static void AddBuffDrugConfig(FlatBufferBuilder builder, VectorOffset BuffDrugConfigOffset)
		{
			builder.AddOffset(64, BuffDrugConfigOffset.Value, 0);
		}

		// Token: 0x06002A0B RID: 10763 RVA: 0x0009E398 File Offset: 0x0009C798
		public static VectorOffset CreateBuffDrugConfigVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x0009E3D5 File Offset: 0x0009C7D5
		public static void StartBuffDrugConfigVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x0009E3E0 File Offset: 0x0009C7E0
		public static void AddMostCostStamina(FlatBufferBuilder builder, int MostCostStamina)
		{
			builder.AddInt(65, MostCostStamina, 0);
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x0009E3EC File Offset: 0x0009C7EC
		public static void AddHellSplitLevel(FlatBufferBuilder builder, int HellSplitLevel)
		{
			builder.AddInt(66, HellSplitLevel, 0);
		}

		// Token: 0x06002A0F RID: 10767 RVA: 0x0009E3F8 File Offset: 0x0009C7F8
		public static void AddHellSplitLevelWeight(FlatBufferBuilder builder, int HellSplitLevelWeight)
		{
			builder.AddInt(67, HellSplitLevelWeight, 0);
		}

		// Token: 0x06002A10 RID: 10768 RVA: 0x0009E404 File Offset: 0x0009C804
		public static void AddOpenAutoFight(FlatBufferBuilder builder, int OpenAutoFight)
		{
			builder.AddInt(68, OpenAutoFight, 0);
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x0009E410 File Offset: 0x0009C810
		public static void AddOnlyRaceEndProfit(FlatBufferBuilder builder, int OnlyRaceEndProfit)
		{
			builder.AddInt(69, OnlyRaceEndProfit, 0);
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x0009E41C File Offset: 0x0009C81C
		public static void AddHasMasterExpAddition(FlatBufferBuilder builder, int HasMasterExpAddition)
		{
			builder.AddInt(70, HasMasterExpAddition, 0);
		}

		// Token: 0x06002A13 RID: 10771 RVA: 0x0009E428 File Offset: 0x0009C828
		public static void AddDungeonLevelPath(FlatBufferBuilder builder, StringOffset dungeonLevelPathOffset)
		{
			builder.AddOffset(71, dungeonLevelPathOffset.Value, 0);
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x0009E43A File Offset: 0x0009C83A
		public static void AddGuideTasks(FlatBufferBuilder builder, StringOffset GuideTasksOffset)
		{
			builder.AddOffset(72, GuideTasksOffset.Value, 0);
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x0009E44C File Offset: 0x0009C84C
		public static void AddNeedForceGC(FlatBufferBuilder builder, bool NeedForceGC)
		{
			builder.AddBool(73, NeedForceGC, false);
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x0009E458 File Offset: 0x0009C858
		public static void AddIsSingle(FlatBufferBuilder builder, int IsSingle)
		{
			builder.AddInt(74, IsSingle, 0);
		}

		// Token: 0x06002A17 RID: 10775 RVA: 0x0009E464 File Offset: 0x0009C864
		public static void AddOnlyRaceEndSettlement(FlatBufferBuilder builder, int onlyRaceEndSettlement)
		{
			builder.AddInt(75, onlyRaceEndSettlement, 0);
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x0009E470 File Offset: 0x0009C870
		public static void AddOwnerEntryId(FlatBufferBuilder builder, int ownerEntryId)
		{
			builder.AddInt(76, ownerEntryId, 0);
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x0009E47C File Offset: 0x0009C87C
		public static void AddWeightEntry(FlatBufferBuilder builder, int weightEntry)
		{
			builder.AddInt(77, weightEntry, 0);
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x0009E488 File Offset: 0x0009C888
		public static void AddPlayingDescription(FlatBufferBuilder builder, StringOffset PlayingDescriptionOffset)
		{
			builder.AddOffset(78, PlayingDescriptionOffset.Value, 0);
		}

		// Token: 0x06002A1B RID: 10779 RVA: 0x0009E49A File Offset: 0x0009C89A
		public static void AddExchangeStoreEntrance(FlatBufferBuilder builder, StringOffset ExchangeStoreEntranceOffset)
		{
			builder.AddOffset(79, ExchangeStoreEntranceOffset.Value, 0);
		}

		// Token: 0x06002A1C RID: 10780 RVA: 0x0009E4AC File Offset: 0x0009C8AC
		public static void AddEliteDungeonPrevChapter(FlatBufferBuilder builder, VectorOffset EliteDungeonPrevChapterOffset)
		{
			builder.AddOffset(80, EliteDungeonPrevChapterOffset.Value, 0);
		}

		// Token: 0x06002A1D RID: 10781 RVA: 0x0009E4C0 File Offset: 0x0009C8C0
		public static VectorOffset CreateEliteDungeonPrevChapterVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x0009E506 File Offset: 0x0009C906
		public static void StartEliteDungeonPrevChapterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A1F RID: 10783 RVA: 0x0009E511 File Offset: 0x0009C911
		public static void AddLimitTime(FlatBufferBuilder builder, int LimitTime)
		{
			builder.AddInt(81, LimitTime, 0);
		}

		// Token: 0x06002A20 RID: 10784 RVA: 0x0009E520 File Offset: 0x0009C920
		public static Offset<DungeonTable> EndDungeonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonTable>(value);
		}

		// Token: 0x06002A21 RID: 10785 RVA: 0x0009E53A File Offset: 0x0009C93A
		public static void FinishDungeonTableBuffer(FlatBufferBuilder builder, Offset<DungeonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011FE RID: 4606
		private Table __p = new Table();

		// Token: 0x040011FF RID: 4607
		private FlatBufferArray<int> DropItemsValue;

		// Token: 0x04001200 RID: 4608
		private FlatBufferArray<int> HellDropItemsValue;

		// Token: 0x04001201 RID: 4609
		private FlatBufferArray<int> storyDungeonIDsValue;

		// Token: 0x04001202 RID: 4610
		private FlatBufferArray<int> PreDungeonIDsValue;

		// Token: 0x04001203 RID: 4611
		private FlatBufferArray<int> NormalMonsterDropValue;

		// Token: 0x04001204 RID: 4612
		private FlatBufferArray<int> EliteMonsterDropValue;

		// Token: 0x04001205 RID: 4613
		private FlatBufferArray<int> BossMonsterDropValue;

		// Token: 0x04001206 RID: 4614
		private FlatBufferArray<int> DungeonDropValue;

		// Token: 0x04001207 RID: 4615
		private FlatBufferArray<int> ActivityDropValue;

		// Token: 0x04001208 RID: 4616
		private FlatBufferArray<int> DungeonFirstDropValue;

		// Token: 0x04001209 RID: 4617
		private FlatBufferArray<int> DestructionDropValue;

		// Token: 0x0400120A RID: 4618
		private FlatBufferArray<int> EasterEggDropValue;

		// Token: 0x0400120B RID: 4619
		private FlatBufferArray<int> TaskDropValue;

		// Token: 0x0400120C RID: 4620
		private FlatBufferArray<int> HellDrop1Value;

		// Token: 0x0400120D RID: 4621
		private FlatBufferArray<int> HellDrop2Value;

		// Token: 0x0400120E RID: 4622
		private FlatBufferArray<int> HellDrop3Value;

		// Token: 0x0400120F RID: 4623
		private FlatBufferArray<int> HellActivityDropValue;

		// Token: 0x04001210 RID: 4624
		private FlatBufferArray<int> RaceEndDropBaseMultiValue;

		// Token: 0x04001211 RID: 4625
		private FlatBufferArray<string> RaceEndDropMultiCostValue;

		// Token: 0x04001212 RID: 4626
		private FlatBufferArray<int> BuffDrugConfigValue;

		// Token: 0x04001213 RID: 4627
		private FlatBufferArray<string> EliteDungeonPrevChapterValue;

		// Token: 0x020003AB RID: 939
		public enum eType
		{
			// Token: 0x04001215 RID: 4629
			L_NORMAL,
			// Token: 0x04001216 RID: 4630
			L_STORY,
			// Token: 0x04001217 RID: 4631
			L_ACTIVITY,
			// Token: 0x04001218 RID: 4632
			L_DEADTOWER
		}

		// Token: 0x020003AC RID: 940
		public enum eSubType
		{
			// Token: 0x0400121A RID: 4634
			S_NORMAL,
			// Token: 0x0400121B RID: 4635
			S_YUANGU,
			// Token: 0x0400121C RID: 4636
			S_NIUTOUGUAI,
			// Token: 0x0400121D RID: 4637
			S_NANBUXIGU,
			// Token: 0x0400121E RID: 4638
			S_SIWANGZHITA,
			// Token: 0x0400121F RID: 4639
			S_NEWBIEGUIDE,
			// Token: 0x04001220 RID: 4640
			S_PK,
			// Token: 0x04001221 RID: 4641
			S_JINBI,
			// Token: 0x04001222 RID: 4642
			S_HELL,
			// Token: 0x04001223 RID: 4643
			S_GUILDPK,
			// Token: 0x04001224 RID: 4644
			S_HELL_ENTRY,
			// Token: 0x04001225 RID: 4645
			S_TEAM_BOSS,
			// Token: 0x04001226 RID: 4646
			S_MONEYREWARDS_PVP,
			// Token: 0x04001227 RID: 4647
			S_WUDAOHUI,
			// Token: 0x04001228 RID: 4648
			S_JUEWANGZHITA,
			// Token: 0x04001229 RID: 4649
			S_COMBOTRAINING,
			// Token: 0x0400122A RID: 4650
			S_CITYMONSTER,
			// Token: 0x0400122B RID: 4651
			S_DEVILDDOM,
			// Token: 0x0400122C RID: 4652
			S_GUILD_DUNGEON,
			// Token: 0x0400122D RID: 4653
			S_LIMIT_TIME_HELL,
			// Token: 0x0400122E RID: 4654
			S_WEEK_HELL,
			// Token: 0x0400122F RID: 4655
			S_WEEK_HELL_ENTRY = 22,
			// Token: 0x04001230 RID: 4656
			S_WEEK_HELL_PER,
			// Token: 0x04001231 RID: 4657
			S_FINALTEST_PVE,
			// Token: 0x04001232 RID: 4658
			S_RAID_DUNGEON,
			// Token: 0x04001233 RID: 4659
			S_ANNIVERSARY_NORMAL,
			// Token: 0x04001234 RID: 4660
			S_ANNIVERSARY_HARD,
			// Token: 0x04001235 RID: 4661
			S_TREASUREMAP,
			// Token: 0x04001236 RID: 4662
			S_LIMIT_TIME__FREE_HELL = 31,
			// Token: 0x04001237 RID: 4663
			S_PLAYGAME
		}

		// Token: 0x020003AD RID: 941
		public enum eThreeType
		{
			// Token: 0x04001239 RID: 4665
			T_NORMAL,
			// Token: 0x0400123A RID: 4666
			T_T_TEAM_ELITE,
			// Token: 0x0400123B RID: 4667
			T_CHIJI_PK,
			// Token: 0x0400123C RID: 4668
			T_RACECAR
		}

		// Token: 0x020003AE RID: 942
		public enum eCardType
		{
			// Token: 0x0400123E RID: 4670
			None,
			// Token: 0x0400123F RID: 4671
			Golden_Card,
			// Token: 0x04001240 RID: 4672
			Yijie_Card,
			// Token: 0x04001241 RID: 4673
			Hundun_Card
		}

		// Token: 0x020003AF RID: 943
		public enum eHard
		{
			// Token: 0x04001243 RID: 4675
			NORMAL,
			// Token: 0x04001244 RID: 4676
			RISK,
			// Token: 0x04001245 RID: 4677
			WARRIOR,
			// Token: 0x04001246 RID: 4678
			KING
		}

		// Token: 0x020003B0 RID: 944
		public enum eCrypt
		{
			// Token: 0x04001248 RID: 4680
			code = -265276654
		}
	}
}
