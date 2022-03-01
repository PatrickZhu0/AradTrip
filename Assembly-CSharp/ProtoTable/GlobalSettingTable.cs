using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200044F RID: 1103
	public class GlobalSettingTable : IFlatbufferObject
	{
		// Token: 0x17000D10 RID: 3344
		// (get) Token: 0x060034B0 RID: 13488 RVA: 0x000B7958 File Offset: 0x000B5D58
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060034B1 RID: 13489 RVA: 0x000B7965 File Offset: 0x000B5D65
		public static GlobalSettingTable GetRootAsGlobalSettingTable(ByteBuffer _bb)
		{
			return GlobalSettingTable.GetRootAsGlobalSettingTable(_bb, new GlobalSettingTable());
		}

		// Token: 0x060034B2 RID: 13490 RVA: 0x000B7972 File Offset: 0x000B5D72
		public static GlobalSettingTable GetRootAsGlobalSettingTable(ByteBuffer _bb, GlobalSettingTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060034B3 RID: 13491 RVA: 0x000B798E File Offset: 0x000B5D8E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060034B4 RID: 13492 RVA: 0x000B79A8 File Offset: 0x000B5DA8
		public GlobalSettingTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D11 RID: 3345
		// (get) Token: 0x060034B5 RID: 13493 RVA: 0x000B79B4 File Offset: 0x000B5DB4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060034B6 RID: 13494 RVA: 0x000B7A00 File Offset: 0x000B5E00
		public int walkSpeedArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D12 RID: 3346
		// (get) Token: 0x060034B7 RID: 13495 RVA: 0x000B7A4C File Offset: 0x000B5E4C
		public int walkSpeedLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034B8 RID: 13496 RVA: 0x000B7A7E File Offset: 0x000B5E7E
		public ArraySegment<byte>? GetWalkSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D13 RID: 3347
		// (get) Token: 0x060034B9 RID: 13497 RVA: 0x000B7A8C File Offset: 0x000B5E8C
		public FlatBufferArray<int> walkSpeed
		{
			get
			{
				if (this.walkSpeedValue == null)
				{
					this.walkSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.walkSpeedArray), this.walkSpeedLength);
				}
				return this.walkSpeedValue;
			}
		}

		// Token: 0x060034BA RID: 13498 RVA: 0x000B7ABC File Offset: 0x000B5EBC
		public int runSpeedArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D14 RID: 3348
		// (get) Token: 0x060034BB RID: 13499 RVA: 0x000B7B08 File Offset: 0x000B5F08
		public int runSpeedLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034BC RID: 13500 RVA: 0x000B7B3A File Offset: 0x000B5F3A
		public ArraySegment<byte>? GetRunSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D15 RID: 3349
		// (get) Token: 0x060034BD RID: 13501 RVA: 0x000B7B48 File Offset: 0x000B5F48
		public FlatBufferArray<int> runSpeed
		{
			get
			{
				if (this.runSpeedValue == null)
				{
					this.runSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.runSpeedArray), this.runSpeedLength);
				}
				return this.runSpeedValue;
			}
		}

		// Token: 0x060034BE RID: 13502 RVA: 0x000B7B78 File Offset: 0x000B5F78
		public int townWalkSpeedArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D16 RID: 3350
		// (get) Token: 0x060034BF RID: 13503 RVA: 0x000B7BC8 File Offset: 0x000B5FC8
		public int townWalkSpeedLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034C0 RID: 13504 RVA: 0x000B7BFB File Offset: 0x000B5FFB
		public ArraySegment<byte>? GetTownWalkSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000D17 RID: 3351
		// (get) Token: 0x060034C1 RID: 13505 RVA: 0x000B7C0A File Offset: 0x000B600A
		public FlatBufferArray<int> townWalkSpeed
		{
			get
			{
				if (this.townWalkSpeedValue == null)
				{
					this.townWalkSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.townWalkSpeedArray), this.townWalkSpeedLength);
				}
				return this.townWalkSpeedValue;
			}
		}

		// Token: 0x060034C2 RID: 13506 RVA: 0x000B7C3C File Offset: 0x000B603C
		public int townRunSpeedArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D18 RID: 3352
		// (get) Token: 0x060034C3 RID: 13507 RVA: 0x000B7C8C File Offset: 0x000B608C
		public int townRunSpeedLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034C4 RID: 13508 RVA: 0x000B7CBF File Offset: 0x000B60BF
		public ArraySegment<byte>? GetTownRunSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000D19 RID: 3353
		// (get) Token: 0x060034C5 RID: 13509 RVA: 0x000B7CCE File Offset: 0x000B60CE
		public FlatBufferArray<int> townRunSpeed
		{
			get
			{
				if (this.townRunSpeedValue == null)
				{
					this.townRunSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.townRunSpeedArray), this.townRunSpeedLength);
				}
				return this.townRunSpeedValue;
			}
		}

		// Token: 0x060034C6 RID: 13510 RVA: 0x000B7D00 File Offset: 0x000B6100
		public int hurtTimeArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D1A RID: 3354
		// (get) Token: 0x060034C7 RID: 13511 RVA: 0x000B7D50 File Offset: 0x000B6150
		public int hurtTimeLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034C8 RID: 13512 RVA: 0x000B7D83 File Offset: 0x000B6183
		public ArraySegment<byte>? GetHurtTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000D1B RID: 3355
		// (get) Token: 0x060034C9 RID: 13513 RVA: 0x000B7D92 File Offset: 0x000B6192
		public FlatBufferArray<int> hurtTime
		{
			get
			{
				if (this.hurtTimeValue == null)
				{
					this.hurtTimeValue = new FlatBufferArray<int>(new Func<int, int>(this.hurtTimeArray), this.hurtTimeLength);
				}
				return this.hurtTimeValue;
			}
		}

		// Token: 0x17000D1C RID: 3356
		// (get) Token: 0x060034CA RID: 13514 RVA: 0x000B7DC4 File Offset: 0x000B61C4
		public int frozenPercent
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060034CB RID: 13515 RVA: 0x000B7E10 File Offset: 0x000B6210
		public int jumpBackSpeedArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D1D RID: 3357
		// (get) Token: 0x060034CC RID: 13516 RVA: 0x000B7E60 File Offset: 0x000B6260
		public int jumpBackSpeedLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034CD RID: 13517 RVA: 0x000B7E93 File Offset: 0x000B6293
		public ArraySegment<byte>? GetJumpBackSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000D1E RID: 3358
		// (get) Token: 0x060034CE RID: 13518 RVA: 0x000B7EA2 File Offset: 0x000B62A2
		public FlatBufferArray<int> jumpBackSpeed
		{
			get
			{
				if (this.jumpBackSpeedValue == null)
				{
					this.jumpBackSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.jumpBackSpeedArray), this.jumpBackSpeedLength);
				}
				return this.jumpBackSpeedValue;
			}
		}

		// Token: 0x17000D1F RID: 3359
		// (get) Token: 0x060034CF RID: 13519 RVA: 0x000B7ED4 File Offset: 0x000B62D4
		public int gravity
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D20 RID: 3360
		// (get) Token: 0x060034D0 RID: 13520 RVA: 0x000B7F20 File Offset: 0x000B6320
		public int fallGravityReduceFactor
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D21 RID: 3361
		// (get) Token: 0x060034D1 RID: 13521 RVA: 0x000B7F6C File Offset: 0x000B636C
		public int defaultFloatHurt
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D22 RID: 3362
		// (get) Token: 0x060034D2 RID: 13522 RVA: 0x000B7FB8 File Offset: 0x000B63B8
		public int defaultFloatLevelHurat
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D23 RID: 3363
		// (get) Token: 0x060034D3 RID: 13523 RVA: 0x000B8004 File Offset: 0x000B6404
		public int defaultGroundHurt
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D24 RID: 3364
		// (get) Token: 0x060034D4 RID: 13524 RVA: 0x000B8050 File Offset: 0x000B6450
		public int defaultStandHurt
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D25 RID: 3365
		// (get) Token: 0x060034D5 RID: 13525 RVA: 0x000B809C File Offset: 0x000B649C
		public int fallProtectGravityAddFactor
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D26 RID: 3366
		// (get) Token: 0x060034D6 RID: 13526 RVA: 0x000B80E8 File Offset: 0x000B64E8
		public int protectClearDuration
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D27 RID: 3367
		// (get) Token: 0x060034D7 RID: 13527 RVA: 0x000B8134 File Offset: 0x000B6534
		public int zDimFactor
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D28 RID: 3368
		// (get) Token: 0x060034D8 RID: 13528 RVA: 0x000B8180 File Offset: 0x000B6580
		public int aiWanderRange
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D29 RID: 3369
		// (get) Token: 0x060034D9 RID: 13529 RVA: 0x000B81CC File Offset: 0x000B65CC
		public int aiWAlkBackRange
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2A RID: 3370
		// (get) Token: 0x060034DA RID: 13530 RVA: 0x000B8218 File Offset: 0x000B6618
		public int aiMaxWalkCmdCount
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2B RID: 3371
		// (get) Token: 0x060034DB RID: 13531 RVA: 0x000B8264 File Offset: 0x000B6664
		public int aiMaxWalkCmdCount_RANGED
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2C RID: 3372
		// (get) Token: 0x060034DC RID: 13532 RVA: 0x000B82B0 File Offset: 0x000B66B0
		public int aiMaxIdleCmdcount
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2D RID: 3373
		// (get) Token: 0x060034DD RID: 13533 RVA: 0x000B82FC File Offset: 0x000B66FC
		public int aiSkillAttackPassive
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2E RID: 3374
		// (get) Token: 0x060034DE RID: 13534 RVA: 0x000B8348 File Offset: 0x000B6748
		public int monsterGetupBatiFactor
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D2F RID: 3375
		// (get) Token: 0x060034DF RID: 13535 RVA: 0x000B8394 File Offset: 0x000B6794
		public int degangBackDistance
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060034E0 RID: 13536 RVA: 0x000B83E0 File Offset: 0x000B67E0
		public int monsterWalkSpeedArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D30 RID: 3376
		// (get) Token: 0x060034E1 RID: 13537 RVA: 0x000B8430 File Offset: 0x000B6830
		public int monsterWalkSpeedLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034E2 RID: 13538 RVA: 0x000B8463 File Offset: 0x000B6863
		public ArraySegment<byte>? GetMonsterWalkSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17000D31 RID: 3377
		// (get) Token: 0x060034E3 RID: 13539 RVA: 0x000B8472 File Offset: 0x000B6872
		public FlatBufferArray<int> monsterWalkSpeed
		{
			get
			{
				if (this.monsterWalkSpeedValue == null)
				{
					this.monsterWalkSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.monsterWalkSpeedArray), this.monsterWalkSpeedLength);
				}
				return this.monsterWalkSpeedValue;
			}
		}

		// Token: 0x060034E4 RID: 13540 RVA: 0x000B84A4 File Offset: 0x000B68A4
		public int monsterRunSpeedArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D32 RID: 3378
		// (get) Token: 0x060034E5 RID: 13541 RVA: 0x000B84F4 File Offset: 0x000B68F4
		public int monsterRunSpeedLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060034E6 RID: 13542 RVA: 0x000B8527 File Offset: 0x000B6927
		public ArraySegment<byte>? GetMonsterRunSpeedBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17000D33 RID: 3379
		// (get) Token: 0x060034E7 RID: 13543 RVA: 0x000B8536 File Offset: 0x000B6936
		public FlatBufferArray<int> monsterRunSpeed
		{
			get
			{
				if (this.monsterRunSpeedValue == null)
				{
					this.monsterRunSpeedValue = new FlatBufferArray<int>(new Func<int, int>(this.monsterRunSpeedArray), this.monsterRunSpeedLength);
				}
				return this.monsterRunSpeedValue;
			}
		}

		// Token: 0x17000D34 RID: 3380
		// (get) Token: 0x060034E8 RID: 13544 RVA: 0x000B8568 File Offset: 0x000B6968
		public bool forceUseAutoFight
		{
			get
			{
				int num = this.__p.__offset(58);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000D35 RID: 3381
		// (get) Token: 0x060034E9 RID: 13545 RVA: 0x000B85B4 File Offset: 0x000B69B4
		public int afThinkTerm
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D36 RID: 3382
		// (get) Token: 0x060034EA RID: 13546 RVA: 0x000B8600 File Offset: 0x000B6A00
		public int afFindTargetTerm
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D37 RID: 3383
		// (get) Token: 0x060034EB RID: 13547 RVA: 0x000B864C File Offset: 0x000B6A4C
		public int afChangeDestinationTerm
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D38 RID: 3384
		// (get) Token: 0x060034EC RID: 13548 RVA: 0x000B8698 File Offset: 0x000B6A98
		public int autoCheckRestoreInterval
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D39 RID: 3385
		// (get) Token: 0x060034ED RID: 13549 RVA: 0x000B86E4 File Offset: 0x000B6AE4
		public int monsterWalkSpeedFactor
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3A RID: 3386
		// (get) Token: 0x060034EE RID: 13550 RVA: 0x000B8730 File Offset: 0x000B6B30
		public int monsterSightFactor
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3B RID: 3387
		// (get) Token: 0x060034EF RID: 13551 RVA: 0x000B877C File Offset: 0x000B6B7C
		public int dunFuTime
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3C RID: 3388
		// (get) Token: 0x060034F0 RID: 13552 RVA: 0x000B87C8 File Offset: 0x000B6BC8
		public int pvpDunFuTime
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3D RID: 3389
		// (get) Token: 0x060034F1 RID: 13553 RVA: 0x000B8814 File Offset: 0x000B6C14
		public int pkDamageAdjustFactor
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3E RID: 3390
		// (get) Token: 0x060034F2 RID: 13554 RVA: 0x000B8860 File Offset: 0x000B6C60
		public int pkHPAdjustFactor
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D3F RID: 3391
		// (get) Token: 0x060034F3 RID: 13555 RVA: 0x000B88AC File Offset: 0x000B6CAC
		public bool pkUseMaxLevel
		{
			get
			{
				int num = this.__p.__offset(80);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000D40 RID: 3392
		// (get) Token: 0x060034F4 RID: 13556 RVA: 0x000B88F8 File Offset: 0x000B6CF8
		public int pkHitRateAdd
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D41 RID: 3393
		// (get) Token: 0x060034F5 RID: 13557 RVA: 0x000B8944 File Offset: 0x000B6D44
		public int SwitchWeaponCD
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-1582321333 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060034F6 RID: 13558 RVA: 0x000B8990 File Offset: 0x000B6D90
		public static Offset<GlobalSettingTable> CreateGlobalSettingTable(FlatBufferBuilder builder, int ID = 0, VectorOffset walkSpeedOffset = default(VectorOffset), VectorOffset runSpeedOffset = default(VectorOffset), VectorOffset townWalkSpeedOffset = default(VectorOffset), VectorOffset townRunSpeedOffset = default(VectorOffset), VectorOffset hurtTimeOffset = default(VectorOffset), int frozenPercent = 0, VectorOffset jumpBackSpeedOffset = default(VectorOffset), int gravity = 0, int fallGravityReduceFactor = 0, int defaultFloatHurt = 0, int defaultFloatLevelHurat = 0, int defaultGroundHurt = 0, int defaultStandHurt = 0, int fallProtectGravityAddFactor = 0, int protectClearDuration = 0, int zDimFactor = 0, int aiWanderRange = 0, int aiWAlkBackRange = 0, int aiMaxWalkCmdCount = 0, int aiMaxWalkCmdCount_RANGED = 0, int aiMaxIdleCmdcount = 0, int aiSkillAttackPassive = 0, int monsterGetupBatiFactor = 0, int degangBackDistance = 0, VectorOffset monsterWalkSpeedOffset = default(VectorOffset), VectorOffset monsterRunSpeedOffset = default(VectorOffset), bool forceUseAutoFight = false, int afThinkTerm = 0, int afFindTargetTerm = 0, int afChangeDestinationTerm = 0, int autoCheckRestoreInterval = 0, int monsterWalkSpeedFactor = 0, int monsterSightFactor = 0, int dunFuTime = 0, int pvpDunFuTime = 0, int pkDamageAdjustFactor = 0, int pkHPAdjustFactor = 0, bool pkUseMaxLevel = false, int pkHitRateAdd = 0, int SwitchWeaponCD = 0)
		{
			builder.StartObject(41);
			GlobalSettingTable.AddSwitchWeaponCD(builder, SwitchWeaponCD);
			GlobalSettingTable.AddPkHitRateAdd(builder, pkHitRateAdd);
			GlobalSettingTable.AddPkHPAdjustFactor(builder, pkHPAdjustFactor);
			GlobalSettingTable.AddPkDamageAdjustFactor(builder, pkDamageAdjustFactor);
			GlobalSettingTable.AddPvpDunFuTime(builder, pvpDunFuTime);
			GlobalSettingTable.AddDunFuTime(builder, dunFuTime);
			GlobalSettingTable.AddMonsterSightFactor(builder, monsterSightFactor);
			GlobalSettingTable.AddMonsterWalkSpeedFactor(builder, monsterWalkSpeedFactor);
			GlobalSettingTable.AddAutoCheckRestoreInterval(builder, autoCheckRestoreInterval);
			GlobalSettingTable.AddAfChangeDestinationTerm(builder, afChangeDestinationTerm);
			GlobalSettingTable.AddAfFindTargetTerm(builder, afFindTargetTerm);
			GlobalSettingTable.AddAfThinkTerm(builder, afThinkTerm);
			GlobalSettingTable.AddMonsterRunSpeed(builder, monsterRunSpeedOffset);
			GlobalSettingTable.AddMonsterWalkSpeed(builder, monsterWalkSpeedOffset);
			GlobalSettingTable.AddDegangBackDistance(builder, degangBackDistance);
			GlobalSettingTable.AddMonsterGetupBatiFactor(builder, monsterGetupBatiFactor);
			GlobalSettingTable.AddAiSkillAttackPassive(builder, aiSkillAttackPassive);
			GlobalSettingTable.AddAiMaxIdleCmdcount(builder, aiMaxIdleCmdcount);
			GlobalSettingTable.AddAiMaxWalkCmdCountRANGED(builder, aiMaxWalkCmdCount_RANGED);
			GlobalSettingTable.AddAiMaxWalkCmdCount(builder, aiMaxWalkCmdCount);
			GlobalSettingTable.AddAiWAlkBackRange(builder, aiWAlkBackRange);
			GlobalSettingTable.AddAiWanderRange(builder, aiWanderRange);
			GlobalSettingTable.AddZDimFactor(builder, zDimFactor);
			GlobalSettingTable.AddProtectClearDuration(builder, protectClearDuration);
			GlobalSettingTable.AddFallProtectGravityAddFactor(builder, fallProtectGravityAddFactor);
			GlobalSettingTable.AddDefaultStandHurt(builder, defaultStandHurt);
			GlobalSettingTable.AddDefaultGroundHurt(builder, defaultGroundHurt);
			GlobalSettingTable.AddDefaultFloatLevelHurat(builder, defaultFloatLevelHurat);
			GlobalSettingTable.AddDefaultFloatHurt(builder, defaultFloatHurt);
			GlobalSettingTable.AddFallGravityReduceFactor(builder, fallGravityReduceFactor);
			GlobalSettingTable.AddGravity(builder, gravity);
			GlobalSettingTable.AddJumpBackSpeed(builder, jumpBackSpeedOffset);
			GlobalSettingTable.AddFrozenPercent(builder, frozenPercent);
			GlobalSettingTable.AddHurtTime(builder, hurtTimeOffset);
			GlobalSettingTable.AddTownRunSpeed(builder, townRunSpeedOffset);
			GlobalSettingTable.AddTownWalkSpeed(builder, townWalkSpeedOffset);
			GlobalSettingTable.AddRunSpeed(builder, runSpeedOffset);
			GlobalSettingTable.AddWalkSpeed(builder, walkSpeedOffset);
			GlobalSettingTable.AddID(builder, ID);
			GlobalSettingTable.AddPkUseMaxLevel(builder, pkUseMaxLevel);
			GlobalSettingTable.AddForceUseAutoFight(builder, forceUseAutoFight);
			return GlobalSettingTable.EndGlobalSettingTable(builder);
		}

		// Token: 0x060034F7 RID: 13559 RVA: 0x000B8AF0 File Offset: 0x000B6EF0
		public static void StartGlobalSettingTable(FlatBufferBuilder builder)
		{
			builder.StartObject(41);
		}

		// Token: 0x060034F8 RID: 13560 RVA: 0x000B8AFA File Offset: 0x000B6EFA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060034F9 RID: 13561 RVA: 0x000B8B05 File Offset: 0x000B6F05
		public static void AddWalkSpeed(FlatBufferBuilder builder, VectorOffset walkSpeedOffset)
		{
			builder.AddOffset(1, walkSpeedOffset.Value, 0);
		}

		// Token: 0x060034FA RID: 13562 RVA: 0x000B8B18 File Offset: 0x000B6F18
		public static VectorOffset CreateWalkSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060034FB RID: 13563 RVA: 0x000B8B55 File Offset: 0x000B6F55
		public static void StartWalkSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060034FC RID: 13564 RVA: 0x000B8B60 File Offset: 0x000B6F60
		public static void AddRunSpeed(FlatBufferBuilder builder, VectorOffset runSpeedOffset)
		{
			builder.AddOffset(2, runSpeedOffset.Value, 0);
		}

		// Token: 0x060034FD RID: 13565 RVA: 0x000B8B74 File Offset: 0x000B6F74
		public static VectorOffset CreateRunSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060034FE RID: 13566 RVA: 0x000B8BB1 File Offset: 0x000B6FB1
		public static void StartRunSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060034FF RID: 13567 RVA: 0x000B8BBC File Offset: 0x000B6FBC
		public static void AddTownWalkSpeed(FlatBufferBuilder builder, VectorOffset townWalkSpeedOffset)
		{
			builder.AddOffset(3, townWalkSpeedOffset.Value, 0);
		}

		// Token: 0x06003500 RID: 13568 RVA: 0x000B8BD0 File Offset: 0x000B6FD0
		public static VectorOffset CreateTownWalkSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003501 RID: 13569 RVA: 0x000B8C0D File Offset: 0x000B700D
		public static void StartTownWalkSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003502 RID: 13570 RVA: 0x000B8C18 File Offset: 0x000B7018
		public static void AddTownRunSpeed(FlatBufferBuilder builder, VectorOffset townRunSpeedOffset)
		{
			builder.AddOffset(4, townRunSpeedOffset.Value, 0);
		}

		// Token: 0x06003503 RID: 13571 RVA: 0x000B8C2C File Offset: 0x000B702C
		public static VectorOffset CreateTownRunSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003504 RID: 13572 RVA: 0x000B8C69 File Offset: 0x000B7069
		public static void StartTownRunSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003505 RID: 13573 RVA: 0x000B8C74 File Offset: 0x000B7074
		public static void AddHurtTime(FlatBufferBuilder builder, VectorOffset hurtTimeOffset)
		{
			builder.AddOffset(5, hurtTimeOffset.Value, 0);
		}

		// Token: 0x06003506 RID: 13574 RVA: 0x000B8C88 File Offset: 0x000B7088
		public static VectorOffset CreateHurtTimeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003507 RID: 13575 RVA: 0x000B8CC5 File Offset: 0x000B70C5
		public static void StartHurtTimeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003508 RID: 13576 RVA: 0x000B8CD0 File Offset: 0x000B70D0
		public static void AddFrozenPercent(FlatBufferBuilder builder, int frozenPercent)
		{
			builder.AddInt(6, frozenPercent, 0);
		}

		// Token: 0x06003509 RID: 13577 RVA: 0x000B8CDB File Offset: 0x000B70DB
		public static void AddJumpBackSpeed(FlatBufferBuilder builder, VectorOffset jumpBackSpeedOffset)
		{
			builder.AddOffset(7, jumpBackSpeedOffset.Value, 0);
		}

		// Token: 0x0600350A RID: 13578 RVA: 0x000B8CEC File Offset: 0x000B70EC
		public static VectorOffset CreateJumpBackSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600350B RID: 13579 RVA: 0x000B8D29 File Offset: 0x000B7129
		public static void StartJumpBackSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600350C RID: 13580 RVA: 0x000B8D34 File Offset: 0x000B7134
		public static void AddGravity(FlatBufferBuilder builder, int gravity)
		{
			builder.AddInt(8, gravity, 0);
		}

		// Token: 0x0600350D RID: 13581 RVA: 0x000B8D3F File Offset: 0x000B713F
		public static void AddFallGravityReduceFactor(FlatBufferBuilder builder, int fallGravityReduceFactor)
		{
			builder.AddInt(9, fallGravityReduceFactor, 0);
		}

		// Token: 0x0600350E RID: 13582 RVA: 0x000B8D4B File Offset: 0x000B714B
		public static void AddDefaultFloatHurt(FlatBufferBuilder builder, int defaultFloatHurt)
		{
			builder.AddInt(10, defaultFloatHurt, 0);
		}

		// Token: 0x0600350F RID: 13583 RVA: 0x000B8D57 File Offset: 0x000B7157
		public static void AddDefaultFloatLevelHurat(FlatBufferBuilder builder, int defaultFloatLevelHurat)
		{
			builder.AddInt(11, defaultFloatLevelHurat, 0);
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x000B8D63 File Offset: 0x000B7163
		public static void AddDefaultGroundHurt(FlatBufferBuilder builder, int defaultGroundHurt)
		{
			builder.AddInt(12, defaultGroundHurt, 0);
		}

		// Token: 0x06003511 RID: 13585 RVA: 0x000B8D6F File Offset: 0x000B716F
		public static void AddDefaultStandHurt(FlatBufferBuilder builder, int defaultStandHurt)
		{
			builder.AddInt(13, defaultStandHurt, 0);
		}

		// Token: 0x06003512 RID: 13586 RVA: 0x000B8D7B File Offset: 0x000B717B
		public static void AddFallProtectGravityAddFactor(FlatBufferBuilder builder, int fallProtectGravityAddFactor)
		{
			builder.AddInt(14, fallProtectGravityAddFactor, 0);
		}

		// Token: 0x06003513 RID: 13587 RVA: 0x000B8D87 File Offset: 0x000B7187
		public static void AddProtectClearDuration(FlatBufferBuilder builder, int protectClearDuration)
		{
			builder.AddInt(15, protectClearDuration, 0);
		}

		// Token: 0x06003514 RID: 13588 RVA: 0x000B8D93 File Offset: 0x000B7193
		public static void AddZDimFactor(FlatBufferBuilder builder, int zDimFactor)
		{
			builder.AddInt(16, zDimFactor, 0);
		}

		// Token: 0x06003515 RID: 13589 RVA: 0x000B8D9F File Offset: 0x000B719F
		public static void AddAiWanderRange(FlatBufferBuilder builder, int aiWanderRange)
		{
			builder.AddInt(17, aiWanderRange, 0);
		}

		// Token: 0x06003516 RID: 13590 RVA: 0x000B8DAB File Offset: 0x000B71AB
		public static void AddAiWAlkBackRange(FlatBufferBuilder builder, int aiWAlkBackRange)
		{
			builder.AddInt(18, aiWAlkBackRange, 0);
		}

		// Token: 0x06003517 RID: 13591 RVA: 0x000B8DB7 File Offset: 0x000B71B7
		public static void AddAiMaxWalkCmdCount(FlatBufferBuilder builder, int aiMaxWalkCmdCount)
		{
			builder.AddInt(19, aiMaxWalkCmdCount, 0);
		}

		// Token: 0x06003518 RID: 13592 RVA: 0x000B8DC3 File Offset: 0x000B71C3
		public static void AddAiMaxWalkCmdCountRANGED(FlatBufferBuilder builder, int aiMaxWalkCmdCountRANGED)
		{
			builder.AddInt(20, aiMaxWalkCmdCountRANGED, 0);
		}

		// Token: 0x06003519 RID: 13593 RVA: 0x000B8DCF File Offset: 0x000B71CF
		public static void AddAiMaxIdleCmdcount(FlatBufferBuilder builder, int aiMaxIdleCmdcount)
		{
			builder.AddInt(21, aiMaxIdleCmdcount, 0);
		}

		// Token: 0x0600351A RID: 13594 RVA: 0x000B8DDB File Offset: 0x000B71DB
		public static void AddAiSkillAttackPassive(FlatBufferBuilder builder, int aiSkillAttackPassive)
		{
			builder.AddInt(22, aiSkillAttackPassive, 0);
		}

		// Token: 0x0600351B RID: 13595 RVA: 0x000B8DE7 File Offset: 0x000B71E7
		public static void AddMonsterGetupBatiFactor(FlatBufferBuilder builder, int monsterGetupBatiFactor)
		{
			builder.AddInt(23, monsterGetupBatiFactor, 0);
		}

		// Token: 0x0600351C RID: 13596 RVA: 0x000B8DF3 File Offset: 0x000B71F3
		public static void AddDegangBackDistance(FlatBufferBuilder builder, int degangBackDistance)
		{
			builder.AddInt(24, degangBackDistance, 0);
		}

		// Token: 0x0600351D RID: 13597 RVA: 0x000B8DFF File Offset: 0x000B71FF
		public static void AddMonsterWalkSpeed(FlatBufferBuilder builder, VectorOffset monsterWalkSpeedOffset)
		{
			builder.AddOffset(25, monsterWalkSpeedOffset.Value, 0);
		}

		// Token: 0x0600351E RID: 13598 RVA: 0x000B8E14 File Offset: 0x000B7214
		public static VectorOffset CreateMonsterWalkSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600351F RID: 13599 RVA: 0x000B8E51 File Offset: 0x000B7251
		public static void StartMonsterWalkSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003520 RID: 13600 RVA: 0x000B8E5C File Offset: 0x000B725C
		public static void AddMonsterRunSpeed(FlatBufferBuilder builder, VectorOffset monsterRunSpeedOffset)
		{
			builder.AddOffset(26, monsterRunSpeedOffset.Value, 0);
		}

		// Token: 0x06003521 RID: 13601 RVA: 0x000B8E70 File Offset: 0x000B7270
		public static VectorOffset CreateMonsterRunSpeedVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x000B8EAD File Offset: 0x000B72AD
		public static void StartMonsterRunSpeedVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003523 RID: 13603 RVA: 0x000B8EB8 File Offset: 0x000B72B8
		public static void AddForceUseAutoFight(FlatBufferBuilder builder, bool forceUseAutoFight)
		{
			builder.AddBool(27, forceUseAutoFight, false);
		}

		// Token: 0x06003524 RID: 13604 RVA: 0x000B8EC4 File Offset: 0x000B72C4
		public static void AddAfThinkTerm(FlatBufferBuilder builder, int afThinkTerm)
		{
			builder.AddInt(28, afThinkTerm, 0);
		}

		// Token: 0x06003525 RID: 13605 RVA: 0x000B8ED0 File Offset: 0x000B72D0
		public static void AddAfFindTargetTerm(FlatBufferBuilder builder, int afFindTargetTerm)
		{
			builder.AddInt(29, afFindTargetTerm, 0);
		}

		// Token: 0x06003526 RID: 13606 RVA: 0x000B8EDC File Offset: 0x000B72DC
		public static void AddAfChangeDestinationTerm(FlatBufferBuilder builder, int afChangeDestinationTerm)
		{
			builder.AddInt(30, afChangeDestinationTerm, 0);
		}

		// Token: 0x06003527 RID: 13607 RVA: 0x000B8EE8 File Offset: 0x000B72E8
		public static void AddAutoCheckRestoreInterval(FlatBufferBuilder builder, int autoCheckRestoreInterval)
		{
			builder.AddInt(31, autoCheckRestoreInterval, 0);
		}

		// Token: 0x06003528 RID: 13608 RVA: 0x000B8EF4 File Offset: 0x000B72F4
		public static void AddMonsterWalkSpeedFactor(FlatBufferBuilder builder, int monsterWalkSpeedFactor)
		{
			builder.AddInt(32, monsterWalkSpeedFactor, 0);
		}

		// Token: 0x06003529 RID: 13609 RVA: 0x000B8F00 File Offset: 0x000B7300
		public static void AddMonsterSightFactor(FlatBufferBuilder builder, int monsterSightFactor)
		{
			builder.AddInt(33, monsterSightFactor, 0);
		}

		// Token: 0x0600352A RID: 13610 RVA: 0x000B8F0C File Offset: 0x000B730C
		public static void AddDunFuTime(FlatBufferBuilder builder, int dunFuTime)
		{
			builder.AddInt(34, dunFuTime, 0);
		}

		// Token: 0x0600352B RID: 13611 RVA: 0x000B8F18 File Offset: 0x000B7318
		public static void AddPvpDunFuTime(FlatBufferBuilder builder, int pvpDunFuTime)
		{
			builder.AddInt(35, pvpDunFuTime, 0);
		}

		// Token: 0x0600352C RID: 13612 RVA: 0x000B8F24 File Offset: 0x000B7324
		public static void AddPkDamageAdjustFactor(FlatBufferBuilder builder, int pkDamageAdjustFactor)
		{
			builder.AddInt(36, pkDamageAdjustFactor, 0);
		}

		// Token: 0x0600352D RID: 13613 RVA: 0x000B8F30 File Offset: 0x000B7330
		public static void AddPkHPAdjustFactor(FlatBufferBuilder builder, int pkHPAdjustFactor)
		{
			builder.AddInt(37, pkHPAdjustFactor, 0);
		}

		// Token: 0x0600352E RID: 13614 RVA: 0x000B8F3C File Offset: 0x000B733C
		public static void AddPkUseMaxLevel(FlatBufferBuilder builder, bool pkUseMaxLevel)
		{
			builder.AddBool(38, pkUseMaxLevel, false);
		}

		// Token: 0x0600352F RID: 13615 RVA: 0x000B8F48 File Offset: 0x000B7348
		public static void AddPkHitRateAdd(FlatBufferBuilder builder, int pkHitRateAdd)
		{
			builder.AddInt(39, pkHitRateAdd, 0);
		}

		// Token: 0x06003530 RID: 13616 RVA: 0x000B8F54 File Offset: 0x000B7354
		public static void AddSwitchWeaponCD(FlatBufferBuilder builder, int SwitchWeaponCD)
		{
			builder.AddInt(40, SwitchWeaponCD, 0);
		}

		// Token: 0x06003531 RID: 13617 RVA: 0x000B8F60 File Offset: 0x000B7360
		public static Offset<GlobalSettingTable> EndGlobalSettingTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GlobalSettingTable>(value);
		}

		// Token: 0x06003532 RID: 13618 RVA: 0x000B8F7A File Offset: 0x000B737A
		public static void FinishGlobalSettingTableBuffer(FlatBufferBuilder builder, Offset<GlobalSettingTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001578 RID: 5496
		private Table __p = new Table();

		// Token: 0x04001579 RID: 5497
		private FlatBufferArray<int> walkSpeedValue;

		// Token: 0x0400157A RID: 5498
		private FlatBufferArray<int> runSpeedValue;

		// Token: 0x0400157B RID: 5499
		private FlatBufferArray<int> townWalkSpeedValue;

		// Token: 0x0400157C RID: 5500
		private FlatBufferArray<int> townRunSpeedValue;

		// Token: 0x0400157D RID: 5501
		private FlatBufferArray<int> hurtTimeValue;

		// Token: 0x0400157E RID: 5502
		private FlatBufferArray<int> jumpBackSpeedValue;

		// Token: 0x0400157F RID: 5503
		private FlatBufferArray<int> monsterWalkSpeedValue;

		// Token: 0x04001580 RID: 5504
		private FlatBufferArray<int> monsterRunSpeedValue;

		// Token: 0x02000450 RID: 1104
		public enum eCrypt
		{
			// Token: 0x04001582 RID: 5506
			code = -1582321333
		}
	}
}
