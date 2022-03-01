using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000272 RID: 626
	public class ActiveMainTable : IFlatbufferObject
	{
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x0006BDDC File Offset: 0x0006A1DC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0006BDE9 File Offset: 0x0006A1E9
		public static ActiveMainTable GetRootAsActiveMainTable(ByteBuffer _bb)
		{
			return ActiveMainTable.GetRootAsActiveMainTable(_bb, new ActiveMainTable());
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x0006BDF6 File Offset: 0x0006A1F6
		public static ActiveMainTable GetRootAsActiveMainTable(ByteBuffer _bb, ActiveMainTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060014F6 RID: 5366 RVA: 0x0006BE12 File Offset: 0x0006A212
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0006BE2C File Offset: 0x0006A22C
		public ActiveMainTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060014F8 RID: 5368 RVA: 0x0006BE38 File Offset: 0x0006A238
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1839457437 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060014F9 RID: 5369 RVA: 0x0006BE84 File Offset: 0x0006A284
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1839457437 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060014FA RID: 5370 RVA: 0x0006BED0 File Offset: 0x0006A2D0
		public ActiveMainTable.eActivityType ActivityType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ActiveMainTable.eActivityType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060014FB RID: 5371 RVA: 0x0006BF14 File Offset: 0x0006A314
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0006BF57 File Offset: 0x0006A357
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060014FD RID: 5373 RVA: 0x0006BF68 File Offset: 0x0006A368
		public string RedPointPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060014FE RID: 5374 RVA: 0x0006BFAB File Offset: 0x0006A3AB
		public ArraySegment<byte>? GetRedPointPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060014FF RID: 5375 RVA: 0x0006BFBC File Offset: 0x0006A3BC
		public string RedPointLocalPath
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001500 RID: 5376 RVA: 0x0006BFFF File Offset: 0x0006A3FF
		public ArraySegment<byte>? GetRedPointLocalPathBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x0006C010 File Offset: 0x0006A410
		public string UpdateMainKeys
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001502 RID: 5378 RVA: 0x0006C053 File Offset: 0x0006A453
		public ArraySegment<byte>? GetUpdateMainKeysBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06001503 RID: 5379 RVA: 0x0006C064 File Offset: 0x0006A464
		public string TabInitDesc
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001504 RID: 5380 RVA: 0x0006C0A7 File Offset: 0x0006A4A7
		public ArraySegment<byte>? GetTabInitDescBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06001505 RID: 5381 RVA: 0x0006C0B8 File Offset: 0x0006A4B8
		public string FrameTemplate
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001506 RID: 5382 RVA: 0x0006C0FB File Offset: 0x0006A4FB
		public ArraySegment<byte>? GetFrameTemplateBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06001507 RID: 5383 RVA: 0x0006C10C File Offset: 0x0006A50C
		public string PurDesc
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001508 RID: 5384 RVA: 0x0006C14F File Offset: 0x0006A54F
		public ArraySegment<byte>? GetPurDescBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06001509 RID: 5385 RVA: 0x0006C160 File Offset: 0x0006A560
		public string ParticularDesc
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600150A RID: 5386 RVA: 0x0006C1A3 File Offset: 0x0006A5A3
		public ArraySegment<byte>? GetParticularDescBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600150B RID: 5387 RVA: 0x0006C1B4 File Offset: 0x0006A5B4
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x0006C1F7 File Offset: 0x0006A5F7
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x0600150D RID: 5389 RVA: 0x0006C208 File Offset: 0x0006A608
		public string prefabDesc
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x0006C24B File Offset: 0x0006A64B
		public ArraySegment<byte>? GetPrefabDescBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x0600150F RID: 5391 RVA: 0x0006C25C File Offset: 0x0006A65C
		public string awardparent
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001510 RID: 5392 RVA: 0x0006C29F File Offset: 0x0006A69F
		public ArraySegment<byte>? GetAwardparentBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x06001511 RID: 5393 RVA: 0x0006C2B0 File Offset: 0x0006A6B0
		public string templateName
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001512 RID: 5394 RVA: 0x0006C2F3 File Offset: 0x0006A6F3
		public ArraySegment<byte>? GetTemplateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06001513 RID: 5395 RVA: 0x0006C304 File Offset: 0x0006A704
		public int bUseTemplate
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1839457437 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06001514 RID: 5396 RVA: 0x0006C350 File Offset: 0x0006A750
		public string MainStatusDesc
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x0006C393 File Offset: 0x0006A793
		public ArraySegment<byte>? GetMainStatusDescBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06001516 RID: 5398 RVA: 0x0006C3A4 File Offset: 0x0006A7A4
		public string PrefabStatusDesc
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x0006C3E7 File Offset: 0x0006A7E7
		public ArraySegment<byte>? GetPrefabStatusDescBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x0006C3F8 File Offset: 0x0006A7F8
		public int PrefabStatusShowDescArray(int j)
		{
			int num = this.__p.__offset(40);
			return (num == 0) ? 0 : (1839457437 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06001519 RID: 5401 RVA: 0x0006C448 File Offset: 0x0006A848
		public int PrefabStatusShowDescLength
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x0006C47B File Offset: 0x0006A87B
		public ArraySegment<byte>? GetPrefabStatusShowDescBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x0600151B RID: 5403 RVA: 0x0006C48A File Offset: 0x0006A88A
		public FlatBufferArray<int> PrefabStatusShowDesc
		{
			get
			{
				if (this.PrefabStatusShowDescValue == null)
				{
					this.PrefabStatusShowDescValue = new FlatBufferArray<int>(new Func<int, int>(this.PrefabStatusShowDescArray), this.PrefabStatusShowDescLength);
				}
				return this.PrefabStatusShowDescValue;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x0600151C RID: 5404 RVA: 0x0006C4BC File Offset: 0x0006A8BC
		public string MainInitDesc
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0006C4FF File Offset: 0x0006A8FF
		public ArraySegment<byte>? GetMainInitDescBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x0600151E RID: 5406 RVA: 0x0006C510 File Offset: 0x0006A910
		public string FunctionParse
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0006C553 File Offset: 0x0006A953
		public ArraySegment<byte>? GetFunctionParseBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06001520 RID: 5408 RVA: 0x0006C564 File Offset: 0x0006A964
		public string ActiveFrame
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x0006C5A7 File Offset: 0x0006A9A7
		public ArraySegment<byte>? GetActiveFrameBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06001522 RID: 5410 RVA: 0x0006C5B8 File Offset: 0x0006A9B8
		public string ActiveFrameTabPath
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x0006C5FB File Offset: 0x0006A9FB
		public ArraySegment<byte>? GetActiveFrameTabPathBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06001524 RID: 5412 RVA: 0x0006C60C File Offset: 0x0006AA0C
		public int ActiveTypeID
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (1839457437 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06001525 RID: 5413 RVA: 0x0006C658 File Offset: 0x0006AA58
		public string BossId
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x0006C69B File Offset: 0x0006AA9B
		public ArraySegment<byte>? GetBossIdBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06001527 RID: 5415 RVA: 0x0006C6AC File Offset: 0x0006AAAC
		public string BgPath
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001528 RID: 5416 RVA: 0x0006C6EF File Offset: 0x0006AAEF
		public ArraySegment<byte>? GetBgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06001529 RID: 5417 RVA: 0x0006C700 File Offset: 0x0006AB00
		public string TownBtIconPath
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600152A RID: 5418 RVA: 0x0006C743 File Offset: 0x0006AB43
		public ArraySegment<byte>? GetTownBtIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x0600152B RID: 5419 RVA: 0x0006C754 File Offset: 0x0006AB54
		public string TownBtText
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x0006C797 File Offset: 0x0006AB97
		public ArraySegment<byte>? GetTownBtTextBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x0006C7A8 File Offset: 0x0006ABA8
		public static Offset<ActiveMainTable> CreateActiveMainTable(FlatBufferBuilder builder, int ID = 0, int SortID = 0, ActiveMainTable.eActivityType ActivityType = ActiveMainTable.eActivityType.None, StringOffset NameOffset = default(StringOffset), StringOffset RedPointPathOffset = default(StringOffset), StringOffset RedPointLocalPathOffset = default(StringOffset), StringOffset UpdateMainKeysOffset = default(StringOffset), StringOffset TabInitDescOffset = default(StringOffset), StringOffset FrameTemplateOffset = default(StringOffset), StringOffset PurDescOffset = default(StringOffset), StringOffset ParticularDescOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), StringOffset prefabDescOffset = default(StringOffset), StringOffset awardparentOffset = default(StringOffset), StringOffset templateNameOffset = default(StringOffset), int bUseTemplate = 0, StringOffset MainStatusDescOffset = default(StringOffset), StringOffset PrefabStatusDescOffset = default(StringOffset), VectorOffset PrefabStatusShowDescOffset = default(VectorOffset), StringOffset MainInitDescOffset = default(StringOffset), StringOffset FunctionParseOffset = default(StringOffset), StringOffset ActiveFrameOffset = default(StringOffset), StringOffset ActiveFrameTabPathOffset = default(StringOffset), int ActiveTypeID = 0, StringOffset BossIdOffset = default(StringOffset), StringOffset BgPathOffset = default(StringOffset), StringOffset TownBtIconPathOffset = default(StringOffset), StringOffset TownBtTextOffset = default(StringOffset))
		{
			builder.StartObject(28);
			ActiveMainTable.AddTownBtText(builder, TownBtTextOffset);
			ActiveMainTable.AddTownBtIconPath(builder, TownBtIconPathOffset);
			ActiveMainTable.AddBgPath(builder, BgPathOffset);
			ActiveMainTable.AddBossId(builder, BossIdOffset);
			ActiveMainTable.AddActiveTypeID(builder, ActiveTypeID);
			ActiveMainTable.AddActiveFrameTabPath(builder, ActiveFrameTabPathOffset);
			ActiveMainTable.AddActiveFrame(builder, ActiveFrameOffset);
			ActiveMainTable.AddFunctionParse(builder, FunctionParseOffset);
			ActiveMainTable.AddMainInitDesc(builder, MainInitDescOffset);
			ActiveMainTable.AddPrefabStatusShowDesc(builder, PrefabStatusShowDescOffset);
			ActiveMainTable.AddPrefabStatusDesc(builder, PrefabStatusDescOffset);
			ActiveMainTable.AddMainStatusDesc(builder, MainStatusDescOffset);
			ActiveMainTable.AddBUseTemplate(builder, bUseTemplate);
			ActiveMainTable.AddTemplateName(builder, templateNameOffset);
			ActiveMainTable.AddAwardparent(builder, awardparentOffset);
			ActiveMainTable.AddPrefabDesc(builder, prefabDescOffset);
			ActiveMainTable.AddDesc(builder, DescOffset);
			ActiveMainTable.AddParticularDesc(builder, ParticularDescOffset);
			ActiveMainTable.AddPurDesc(builder, PurDescOffset);
			ActiveMainTable.AddFrameTemplate(builder, FrameTemplateOffset);
			ActiveMainTable.AddTabInitDesc(builder, TabInitDescOffset);
			ActiveMainTable.AddUpdateMainKeys(builder, UpdateMainKeysOffset);
			ActiveMainTable.AddRedPointLocalPath(builder, RedPointLocalPathOffset);
			ActiveMainTable.AddRedPointPath(builder, RedPointPathOffset);
			ActiveMainTable.AddName(builder, NameOffset);
			ActiveMainTable.AddActivityType(builder, ActivityType);
			ActiveMainTable.AddSortID(builder, SortID);
			ActiveMainTable.AddID(builder, ID);
			return ActiveMainTable.EndActiveMainTable(builder);
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x0006C8A0 File Offset: 0x0006ACA0
		public static void StartActiveMainTable(FlatBufferBuilder builder)
		{
			builder.StartObject(28);
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x0006C8AA File Offset: 0x0006ACAA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001530 RID: 5424 RVA: 0x0006C8B5 File Offset: 0x0006ACB5
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(1, SortID, 0);
		}

		// Token: 0x06001531 RID: 5425 RVA: 0x0006C8C0 File Offset: 0x0006ACC0
		public static void AddActivityType(FlatBufferBuilder builder, ActiveMainTable.eActivityType ActivityType)
		{
			builder.AddInt(2, (int)ActivityType, 0);
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x0006C8CB File Offset: 0x0006ACCB
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x06001533 RID: 5427 RVA: 0x0006C8DC File Offset: 0x0006ACDC
		public static void AddRedPointPath(FlatBufferBuilder builder, StringOffset RedPointPathOffset)
		{
			builder.AddOffset(4, RedPointPathOffset.Value, 0);
		}

		// Token: 0x06001534 RID: 5428 RVA: 0x0006C8ED File Offset: 0x0006ACED
		public static void AddRedPointLocalPath(FlatBufferBuilder builder, StringOffset RedPointLocalPathOffset)
		{
			builder.AddOffset(5, RedPointLocalPathOffset.Value, 0);
		}

		// Token: 0x06001535 RID: 5429 RVA: 0x0006C8FE File Offset: 0x0006ACFE
		public static void AddUpdateMainKeys(FlatBufferBuilder builder, StringOffset UpdateMainKeysOffset)
		{
			builder.AddOffset(6, UpdateMainKeysOffset.Value, 0);
		}

		// Token: 0x06001536 RID: 5430 RVA: 0x0006C90F File Offset: 0x0006AD0F
		public static void AddTabInitDesc(FlatBufferBuilder builder, StringOffset TabInitDescOffset)
		{
			builder.AddOffset(7, TabInitDescOffset.Value, 0);
		}

		// Token: 0x06001537 RID: 5431 RVA: 0x0006C920 File Offset: 0x0006AD20
		public static void AddFrameTemplate(FlatBufferBuilder builder, StringOffset FrameTemplateOffset)
		{
			builder.AddOffset(8, FrameTemplateOffset.Value, 0);
		}

		// Token: 0x06001538 RID: 5432 RVA: 0x0006C931 File Offset: 0x0006AD31
		public static void AddPurDesc(FlatBufferBuilder builder, StringOffset PurDescOffset)
		{
			builder.AddOffset(9, PurDescOffset.Value, 0);
		}

		// Token: 0x06001539 RID: 5433 RVA: 0x0006C943 File Offset: 0x0006AD43
		public static void AddParticularDesc(FlatBufferBuilder builder, StringOffset ParticularDescOffset)
		{
			builder.AddOffset(10, ParticularDescOffset.Value, 0);
		}

		// Token: 0x0600153A RID: 5434 RVA: 0x0006C955 File Offset: 0x0006AD55
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(11, DescOffset.Value, 0);
		}

		// Token: 0x0600153B RID: 5435 RVA: 0x0006C967 File Offset: 0x0006AD67
		public static void AddPrefabDesc(FlatBufferBuilder builder, StringOffset prefabDescOffset)
		{
			builder.AddOffset(12, prefabDescOffset.Value, 0);
		}

		// Token: 0x0600153C RID: 5436 RVA: 0x0006C979 File Offset: 0x0006AD79
		public static void AddAwardparent(FlatBufferBuilder builder, StringOffset awardparentOffset)
		{
			builder.AddOffset(13, awardparentOffset.Value, 0);
		}

		// Token: 0x0600153D RID: 5437 RVA: 0x0006C98B File Offset: 0x0006AD8B
		public static void AddTemplateName(FlatBufferBuilder builder, StringOffset templateNameOffset)
		{
			builder.AddOffset(14, templateNameOffset.Value, 0);
		}

		// Token: 0x0600153E RID: 5438 RVA: 0x0006C99D File Offset: 0x0006AD9D
		public static void AddBUseTemplate(FlatBufferBuilder builder, int bUseTemplate)
		{
			builder.AddInt(15, bUseTemplate, 0);
		}

		// Token: 0x0600153F RID: 5439 RVA: 0x0006C9A9 File Offset: 0x0006ADA9
		public static void AddMainStatusDesc(FlatBufferBuilder builder, StringOffset MainStatusDescOffset)
		{
			builder.AddOffset(16, MainStatusDescOffset.Value, 0);
		}

		// Token: 0x06001540 RID: 5440 RVA: 0x0006C9BB File Offset: 0x0006ADBB
		public static void AddPrefabStatusDesc(FlatBufferBuilder builder, StringOffset PrefabStatusDescOffset)
		{
			builder.AddOffset(17, PrefabStatusDescOffset.Value, 0);
		}

		// Token: 0x06001541 RID: 5441 RVA: 0x0006C9CD File Offset: 0x0006ADCD
		public static void AddPrefabStatusShowDesc(FlatBufferBuilder builder, VectorOffset PrefabStatusShowDescOffset)
		{
			builder.AddOffset(18, PrefabStatusShowDescOffset.Value, 0);
		}

		// Token: 0x06001542 RID: 5442 RVA: 0x0006C9E0 File Offset: 0x0006ADE0
		public static VectorOffset CreatePrefabStatusShowDescVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001543 RID: 5443 RVA: 0x0006CA1D File Offset: 0x0006AE1D
		public static void StartPrefabStatusShowDescVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001544 RID: 5444 RVA: 0x0006CA28 File Offset: 0x0006AE28
		public static void AddMainInitDesc(FlatBufferBuilder builder, StringOffset MainInitDescOffset)
		{
			builder.AddOffset(19, MainInitDescOffset.Value, 0);
		}

		// Token: 0x06001545 RID: 5445 RVA: 0x0006CA3A File Offset: 0x0006AE3A
		public static void AddFunctionParse(FlatBufferBuilder builder, StringOffset FunctionParseOffset)
		{
			builder.AddOffset(20, FunctionParseOffset.Value, 0);
		}

		// Token: 0x06001546 RID: 5446 RVA: 0x0006CA4C File Offset: 0x0006AE4C
		public static void AddActiveFrame(FlatBufferBuilder builder, StringOffset ActiveFrameOffset)
		{
			builder.AddOffset(21, ActiveFrameOffset.Value, 0);
		}

		// Token: 0x06001547 RID: 5447 RVA: 0x0006CA5E File Offset: 0x0006AE5E
		public static void AddActiveFrameTabPath(FlatBufferBuilder builder, StringOffset ActiveFrameTabPathOffset)
		{
			builder.AddOffset(22, ActiveFrameTabPathOffset.Value, 0);
		}

		// Token: 0x06001548 RID: 5448 RVA: 0x0006CA70 File Offset: 0x0006AE70
		public static void AddActiveTypeID(FlatBufferBuilder builder, int ActiveTypeID)
		{
			builder.AddInt(23, ActiveTypeID, 0);
		}

		// Token: 0x06001549 RID: 5449 RVA: 0x0006CA7C File Offset: 0x0006AE7C
		public static void AddBossId(FlatBufferBuilder builder, StringOffset BossIdOffset)
		{
			builder.AddOffset(24, BossIdOffset.Value, 0);
		}

		// Token: 0x0600154A RID: 5450 RVA: 0x0006CA8E File Offset: 0x0006AE8E
		public static void AddBgPath(FlatBufferBuilder builder, StringOffset BgPathOffset)
		{
			builder.AddOffset(25, BgPathOffset.Value, 0);
		}

		// Token: 0x0600154B RID: 5451 RVA: 0x0006CAA0 File Offset: 0x0006AEA0
		public static void AddTownBtIconPath(FlatBufferBuilder builder, StringOffset TownBtIconPathOffset)
		{
			builder.AddOffset(26, TownBtIconPathOffset.Value, 0);
		}

		// Token: 0x0600154C RID: 5452 RVA: 0x0006CAB2 File Offset: 0x0006AEB2
		public static void AddTownBtText(FlatBufferBuilder builder, StringOffset TownBtTextOffset)
		{
			builder.AddOffset(27, TownBtTextOffset.Value, 0);
		}

		// Token: 0x0600154D RID: 5453 RVA: 0x0006CAC4 File Offset: 0x0006AEC4
		public static Offset<ActiveMainTable> EndActiveMainTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActiveMainTable>(value);
		}

		// Token: 0x0600154E RID: 5454 RVA: 0x0006CADE File Offset: 0x0006AEDE
		public static void FinishActiveMainTableBuffer(FlatBufferBuilder builder, Offset<ActiveMainTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D76 RID: 3446
		private Table __p = new Table();

		// Token: 0x04000D77 RID: 3447
		private FlatBufferArray<int> PrefabStatusShowDescValue;

		// Token: 0x02000273 RID: 627
		public enum eActivityType
		{
			// Token: 0x04000D79 RID: 3449
			None,
			// Token: 0x04000D7A RID: 3450
			ExchangeActivity,
			// Token: 0x04000D7B RID: 3451
			KillBossActivity,
			// Token: 0x04000D7C RID: 3452
			QuestActivity,
			// Token: 0x04000D7D RID: 3453
			SpecialExchangeActivity
		}

		// Token: 0x02000274 RID: 628
		public enum eCrypt
		{
			// Token: 0x04000D7F RID: 3455
			code = 1839457437
		}
	}
}
