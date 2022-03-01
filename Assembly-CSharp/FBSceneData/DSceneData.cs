using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B15 RID: 19221
	public sealed class DSceneData : Table
	{
		// Token: 0x0601BFF2 RID: 114674 RVA: 0x0088E75E File Offset: 0x0088CB5E
		public static DSceneData GetRootAsDSceneData(ByteBuffer _bb)
		{
			return DSceneData.GetRootAsDSceneData(_bb, new DSceneData());
		}

		// Token: 0x0601BFF3 RID: 114675 RVA: 0x0088E76B File Offset: 0x0088CB6B
		public static DSceneData GetRootAsDSceneData(ByteBuffer _bb, DSceneData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BFF4 RID: 114676 RVA: 0x0088E787 File Offset: 0x0088CB87
		public static bool DSceneDataBufferHasIdentifier(ByteBuffer _bb)
		{
			return Table.__has_identifier(_bb, "SCEN");
		}

		// Token: 0x0601BFF5 RID: 114677 RVA: 0x0088E794 File Offset: 0x0088CB94
		public DSceneData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002646 RID: 9798
		// (get) Token: 0x0601BFF6 RID: 114678 RVA: 0x0088E7A8 File Offset: 0x0088CBA8
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002647 RID: 9799
		// (get) Token: 0x0601BFF7 RID: 114679 RVA: 0x0088E7D8 File Offset: 0x0088CBD8
		public int Id
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002648 RID: 9800
		// (get) Token: 0x0601BFF8 RID: 114680 RVA: 0x0088E80C File Offset: 0x0088CC0C
		public string Prefabpath
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002649 RID: 9801
		// (get) Token: 0x0601BFF9 RID: 114681 RVA: 0x0088E83C File Offset: 0x0088CC3C
		public float CameraLookHeight
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 1f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264A RID: 9802
		// (get) Token: 0x0601BFFA RID: 114682 RVA: 0x0088E878 File Offset: 0x0088CC78
		public float CameraDistance
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 10f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264B RID: 9803
		// (get) Token: 0x0601BFFB RID: 114683 RVA: 0x0088E8B4 File Offset: 0x0088CCB4
		public float CameraAngle
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 20f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264C RID: 9804
		// (get) Token: 0x0601BFFC RID: 114684 RVA: 0x0088E8F0 File Offset: 0x0088CCF0
		public float CameraNearClip
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0.3f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264D RID: 9805
		// (get) Token: 0x0601BFFD RID: 114685 RVA: 0x0088E92C File Offset: 0x0088CD2C
		public float CameraFarClip
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 50f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264E RID: 9806
		// (get) Token: 0x0601BFFE RID: 114686 RVA: 0x0088E968 File Offset: 0x0088CD68
		public float CameraSize
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 3.3f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700264F RID: 9807
		// (get) Token: 0x0601BFFF RID: 114687 RVA: 0x0088E9A1 File Offset: 0x0088CDA1
		public Vector2 CameraZRange
		{
			get
			{
				return this.GetCameraZRange(new Vector2());
			}
		}

		// Token: 0x0601C000 RID: 114688 RVA: 0x0088E9B0 File Offset: 0x0088CDB0
		public Vector2 GetCameraZRange(Vector2 obj)
		{
			int num = base.__offset(22);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002650 RID: 9808
		// (get) Token: 0x0601C001 RID: 114689 RVA: 0x0088E9E6 File Offset: 0x0088CDE6
		public Vector2 CameraXRange
		{
			get
			{
				return this.GetCameraXRange(new Vector2());
			}
		}

		// Token: 0x0601C002 RID: 114690 RVA: 0x0088E9F4 File Offset: 0x0088CDF4
		public Vector2 GetCameraXRange(Vector2 obj)
		{
			int num = base.__offset(24);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002651 RID: 9809
		// (get) Token: 0x0601C003 RID: 114691 RVA: 0x0088EA2C File Offset: 0x0088CE2C
		public bool CameraPersp
		{
			get
			{
				int num = base.__offset(26);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002652 RID: 9810
		// (get) Token: 0x0601C004 RID: 114692 RVA: 0x0088EA67 File Offset: 0x0088CE67
		public Vector3 CenterPostionNew
		{
			get
			{
				return this.GetCenterPostionNew(new Vector3());
			}
		}

		// Token: 0x0601C005 RID: 114693 RVA: 0x0088EA74 File Offset: 0x0088CE74
		public Vector3 GetCenterPostionNew(Vector3 obj)
		{
			int num = base.__offset(28);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002653 RID: 9811
		// (get) Token: 0x0601C006 RID: 114694 RVA: 0x0088EAAA File Offset: 0x0088CEAA
		public Vector3 ScenePostion
		{
			get
			{
				return this.GetScenePostion(new Vector3());
			}
		}

		// Token: 0x0601C007 RID: 114695 RVA: 0x0088EAB8 File Offset: 0x0088CEB8
		public Vector3 GetScenePostion(Vector3 obj)
		{
			int num = base.__offset(30);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002654 RID: 9812
		// (get) Token: 0x0601C008 RID: 114696 RVA: 0x0088EAF0 File Offset: 0x0088CEF0
		public float SceneUScale
		{
			get
			{
				int num = base.__offset(32);
				return (num == 0) ? 1f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002655 RID: 9813
		// (get) Token: 0x0601C009 RID: 114697 RVA: 0x0088EB29 File Offset: 0x0088CF29
		public Vector2 GridSize
		{
			get
			{
				return this.GetGridSize(new Vector2());
			}
		}

		// Token: 0x0601C00A RID: 114698 RVA: 0x0088EB38 File Offset: 0x0088CF38
		public Vector2 GetGridSize(Vector2 obj)
		{
			int num = base.__offset(34);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002656 RID: 9814
		// (get) Token: 0x0601C00B RID: 114699 RVA: 0x0088EB6E File Offset: 0x0088CF6E
		public Vector2 LogicXSize
		{
			get
			{
				return this.GetLogicXSize(new Vector2());
			}
		}

		// Token: 0x0601C00C RID: 114700 RVA: 0x0088EB7C File Offset: 0x0088CF7C
		public Vector2 GetLogicXSize(Vector2 obj)
		{
			int num = base.__offset(36);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002657 RID: 9815
		// (get) Token: 0x0601C00D RID: 114701 RVA: 0x0088EBB2 File Offset: 0x0088CFB2
		public Vector2 LogicZSize
		{
			get
			{
				return this.GetLogicZSize(new Vector2());
			}
		}

		// Token: 0x0601C00E RID: 114702 RVA: 0x0088EBC0 File Offset: 0x0088CFC0
		public Vector2 GetLogicZSize(Vector2 obj)
		{
			int num = base.__offset(38);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002658 RID: 9816
		// (get) Token: 0x0601C00F RID: 114703 RVA: 0x0088EBF6 File Offset: 0x0088CFF6
		public Color ObjectDyeColor
		{
			get
			{
				return this.GetObjectDyeColor(new Color());
			}
		}

		// Token: 0x0601C010 RID: 114704 RVA: 0x0088EC04 File Offset: 0x0088D004
		public Color GetObjectDyeColor(Color obj)
		{
			int num = base.__offset(40);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002659 RID: 9817
		// (get) Token: 0x0601C011 RID: 114705 RVA: 0x0088EC3A File Offset: 0x0088D03A
		public Vector3 LogicPos
		{
			get
			{
				return this.GetLogicPos(new Vector3());
			}
		}

		// Token: 0x0601C012 RID: 114706 RVA: 0x0088EC48 File Offset: 0x0088D048
		public Vector3 GetLogicPos(Vector3 obj)
		{
			int num = base.__offset(42);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700265A RID: 9818
		// (get) Token: 0x0601C013 RID: 114707 RVA: 0x0088EC80 File Offset: 0x0088D080
		public EWeatherMode WeatherMode
		{
			get
			{
				int num = base.__offset(44);
				return (EWeatherMode)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x1700265B RID: 9819
		// (get) Token: 0x0601C014 RID: 114708 RVA: 0x0088ECB8 File Offset: 0x0088D0B8
		public int TipsID
		{
			get
			{
				int num = base.__offset(46);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700265C RID: 9820
		// (get) Token: 0x0601C015 RID: 114709 RVA: 0x0088ECF0 File Offset: 0x0088D0F0
		public string LightmapsettingsPath
		{
			get
			{
				int num = base.__offset(48);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700265D RID: 9821
		// (get) Token: 0x0601C016 RID: 114710 RVA: 0x0088ED20 File Offset: 0x0088D120
		public int LogicXmin
		{
			get
			{
				int num = base.__offset(50);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700265E RID: 9822
		// (get) Token: 0x0601C017 RID: 114711 RVA: 0x0088ED58 File Offset: 0x0088D158
		public int LogicXmax
		{
			get
			{
				int num = base.__offset(52);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700265F RID: 9823
		// (get) Token: 0x0601C018 RID: 114712 RVA: 0x0088ED90 File Offset: 0x0088D190
		public int LogicZmin
		{
			get
			{
				int num = base.__offset(54);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002660 RID: 9824
		// (get) Token: 0x0601C019 RID: 114713 RVA: 0x0088EDC8 File Offset: 0x0088D1C8
		public int LogicZmax
		{
			get
			{
				int num = base.__offset(56);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C01A RID: 114714 RVA: 0x0088EDFD File Offset: 0x0088D1FD
		public DEntityInfo GetEntityinfo(int j)
		{
			return this.GetEntityinfo(new DEntityInfo(), j);
		}

		// Token: 0x0601C01B RID: 114715 RVA: 0x0088EE0C File Offset: 0x0088D20C
		public DEntityInfo GetEntityinfo(DEntityInfo obj, int j)
		{
			int num = base.__offset(58);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002661 RID: 9825
		// (get) Token: 0x0601C01C RID: 114716 RVA: 0x0088EE4C File Offset: 0x0088D24C
		public int EntityinfoLength
		{
			get
			{
				int num = base.__offset(58);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C01D RID: 114717 RVA: 0x0088EE78 File Offset: 0x0088D278
		public byte GetBlocklayer(int j)
		{
			int num = base.__offset(60);
			return (num == 0) ? 0 : this.bb.Get(base.__vector(num) + j);
		}

		// Token: 0x17002662 RID: 9826
		// (get) Token: 0x0601C01E RID: 114718 RVA: 0x0088EEB0 File Offset: 0x0088D2B0
		public int BlocklayerLength
		{
			get
			{
				int num = base.__offset(60);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C01F RID: 114719 RVA: 0x0088EED9 File Offset: 0x0088D2D9
		public DNPCInfo GetNpcinfo(int j)
		{
			return this.GetNpcinfo(new DNPCInfo(), j);
		}

		// Token: 0x0601C020 RID: 114720 RVA: 0x0088EEE8 File Offset: 0x0088D2E8
		public DNPCInfo GetNpcinfo(DNPCInfo obj, int j)
		{
			int num = base.__offset(62);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002663 RID: 9827
		// (get) Token: 0x0601C021 RID: 114721 RVA: 0x0088EF28 File Offset: 0x0088D328
		public int NpcinfoLength
		{
			get
			{
				int num = base.__offset(62);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C022 RID: 114722 RVA: 0x0088EF51 File Offset: 0x0088D351
		public DMonsterInfo GetMonsterinfo(int j)
		{
			return this.GetMonsterinfo(new DMonsterInfo(), j);
		}

		// Token: 0x0601C023 RID: 114723 RVA: 0x0088EF60 File Offset: 0x0088D360
		public DMonsterInfo GetMonsterinfo(DMonsterInfo obj, int j)
		{
			int num = base.__offset(64);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002664 RID: 9828
		// (get) Token: 0x0601C024 RID: 114724 RVA: 0x0088EFA0 File Offset: 0x0088D3A0
		public int MonsterinfoLength
		{
			get
			{
				int num = base.__offset(64);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C025 RID: 114725 RVA: 0x0088EFC9 File Offset: 0x0088D3C9
		public DDecoratorInfo GetDecoratorinfo(int j)
		{
			return this.GetDecoratorinfo(new DDecoratorInfo(), j);
		}

		// Token: 0x0601C026 RID: 114726 RVA: 0x0088EFD8 File Offset: 0x0088D3D8
		public DDecoratorInfo GetDecoratorinfo(DDecoratorInfo obj, int j)
		{
			int num = base.__offset(66);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002665 RID: 9829
		// (get) Token: 0x0601C027 RID: 114727 RVA: 0x0088F018 File Offset: 0x0088D418
		public int DecoratorinfoLength
		{
			get
			{
				int num = base.__offset(66);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C028 RID: 114728 RVA: 0x0088F041 File Offset: 0x0088D441
		public DDestructibleInfo GetDesructibleinfo(int j)
		{
			return this.GetDesructibleinfo(new DDestructibleInfo(), j);
		}

		// Token: 0x0601C029 RID: 114729 RVA: 0x0088F050 File Offset: 0x0088D450
		public DDestructibleInfo GetDesructibleinfo(DDestructibleInfo obj, int j)
		{
			int num = base.__offset(68);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002666 RID: 9830
		// (get) Token: 0x0601C02A RID: 114730 RVA: 0x0088F090 File Offset: 0x0088D490
		public int DesructibleinfoLength
		{
			get
			{
				int num = base.__offset(68);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C02B RID: 114731 RVA: 0x0088F0B9 File Offset: 0x0088D4B9
		public DRegionInfo GetRegioninfo(int j)
		{
			return this.GetRegioninfo(new DRegionInfo(), j);
		}

		// Token: 0x0601C02C RID: 114732 RVA: 0x0088F0C8 File Offset: 0x0088D4C8
		public DRegionInfo GetRegioninfo(DRegionInfo obj, int j)
		{
			int num = base.__offset(70);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002667 RID: 9831
		// (get) Token: 0x0601C02D RID: 114733 RVA: 0x0088F108 File Offset: 0x0088D508
		public int RegioninfoLength
		{
			get
			{
				int num = base.__offset(70);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C02E RID: 114734 RVA: 0x0088F131 File Offset: 0x0088D531
		public DTransportDoor GetTransportdoor(int j)
		{
			return this.GetTransportdoor(new DTransportDoor(), j);
		}

		// Token: 0x0601C02F RID: 114735 RVA: 0x0088F140 File Offset: 0x0088D540
		public DTransportDoor GetTransportdoor(DTransportDoor obj, int j)
		{
			int num = base.__offset(72);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002668 RID: 9832
		// (get) Token: 0x0601C030 RID: 114736 RVA: 0x0088F180 File Offset: 0x0088D580
		public int TransportdoorLength
		{
			get
			{
				int num = base.__offset(72);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C031 RID: 114737 RVA: 0x0088F1A9 File Offset: 0x0088D5A9
		public DTransferInfo GetFighterBornPosition(int j)
		{
			return this.GetFighterBornPosition(new DTransferInfo(), j);
		}

		// Token: 0x0601C032 RID: 114738 RVA: 0x0088F1B8 File Offset: 0x0088D5B8
		public DTransferInfo GetFighterBornPosition(DTransferInfo obj, int j)
		{
			int num = base.__offset(74);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002669 RID: 9833
		// (get) Token: 0x0601C033 RID: 114739 RVA: 0x0088F1F8 File Offset: 0x0088D5F8
		public int FighterBornPositionLength
		{
			get
			{
				int num = base.__offset(74);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x1700266A RID: 9834
		// (get) Token: 0x0601C034 RID: 114740 RVA: 0x0088F221 File Offset: 0x0088D621
		public DEntityInfo Birthposition
		{
			get
			{
				return this.GetBirthposition(new DEntityInfo());
			}
		}

		// Token: 0x0601C035 RID: 114741 RVA: 0x0088F230 File Offset: 0x0088D630
		public DEntityInfo GetBirthposition(DEntityInfo obj)
		{
			int num = base.__offset(76);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x1700266B RID: 9835
		// (get) Token: 0x0601C036 RID: 114742 RVA: 0x0088F26C File Offset: 0x0088D66C
		public DEntityInfo Hellbirthposition
		{
			get
			{
				return this.GetHellbirthposition(new DEntityInfo());
			}
		}

		// Token: 0x0601C037 RID: 114743 RVA: 0x0088F27C File Offset: 0x0088D67C
		public DEntityInfo GetHellbirthposition(DEntityInfo obj)
		{
			int num = base.__offset(78);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x0601C038 RID: 114744 RVA: 0x0088F2B8 File Offset: 0x0088D6B8
		public DTownDoor GetTownDoor(int j)
		{
			return this.GetTownDoor(new DTownDoor(), j);
		}

		// Token: 0x0601C039 RID: 114745 RVA: 0x0088F2C8 File Offset: 0x0088D6C8
		public DTownDoor GetTownDoor(DTownDoor obj, int j)
		{
			int num = base.__offset(80);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x1700266C RID: 9836
		// (get) Token: 0x0601C03A RID: 114746 RVA: 0x0088F308 File Offset: 0x0088D708
		public int TownDoorLength
		{
			get
			{
				int num = base.__offset(80);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C03B RID: 114747 RVA: 0x0088F331 File Offset: 0x0088D731
		public FunctionPrefab GetFunctionPrefab(int j)
		{
			return this.GetFunctionPrefab(new FunctionPrefab(), j);
		}

		// Token: 0x0601C03C RID: 114748 RVA: 0x0088F340 File Offset: 0x0088D740
		public FunctionPrefab GetFunctionPrefab(FunctionPrefab obj, int j)
		{
			int num = base.__offset(82);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x1700266D RID: 9837
		// (get) Token: 0x0601C03D RID: 114749 RVA: 0x0088F380 File Offset: 0x0088D780
		public int FunctionPrefabLength
		{
			get
			{
				int num = base.__offset(82);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C03E RID: 114750 RVA: 0x0088F3A9 File Offset: 0x0088D7A9
		public static void StartDSceneData(FlatBufferBuilder builder)
		{
			builder.StartObject(40);
		}

		// Token: 0x0601C03F RID: 114751 RVA: 0x0088F3B3 File Offset: 0x0088D7B3
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C040 RID: 114752 RVA: 0x0088F3C4 File Offset: 0x0088D7C4
		public static void AddId(FlatBufferBuilder builder, int id)
		{
			builder.AddInt(1, id, 0);
		}

		// Token: 0x0601C041 RID: 114753 RVA: 0x0088F3CF File Offset: 0x0088D7CF
		public static void AddPrefabpath(FlatBufferBuilder builder, StringOffset prefabpathOffset)
		{
			builder.AddOffset(2, prefabpathOffset.Value, 0);
		}

		// Token: 0x0601C042 RID: 114754 RVA: 0x0088F3E0 File Offset: 0x0088D7E0
		public static void AddCameraLookHeight(FlatBufferBuilder builder, float CameraLookHeight)
		{
			builder.AddFloat(3, CameraLookHeight, 1.0);
		}

		// Token: 0x0601C043 RID: 114755 RVA: 0x0088F3F3 File Offset: 0x0088D7F3
		public static void AddCameraDistance(FlatBufferBuilder builder, float CameraDistance)
		{
			builder.AddFloat(4, CameraDistance, 10.0);
		}

		// Token: 0x0601C044 RID: 114756 RVA: 0x0088F406 File Offset: 0x0088D806
		public static void AddCameraAngle(FlatBufferBuilder builder, float CameraAngle)
		{
			builder.AddFloat(5, CameraAngle, 20.0);
		}

		// Token: 0x0601C045 RID: 114757 RVA: 0x0088F419 File Offset: 0x0088D819
		public static void AddCameraNearClip(FlatBufferBuilder builder, float CameraNearClip)
		{
			builder.AddFloat(6, CameraNearClip, 0.3);
		}

		// Token: 0x0601C046 RID: 114758 RVA: 0x0088F42C File Offset: 0x0088D82C
		public static void AddCameraFarClip(FlatBufferBuilder builder, float CameraFarClip)
		{
			builder.AddFloat(7, CameraFarClip, 50.0);
		}

		// Token: 0x0601C047 RID: 114759 RVA: 0x0088F43F File Offset: 0x0088D83F
		public static void AddCameraSize(FlatBufferBuilder builder, float CameraSize)
		{
			builder.AddFloat(8, CameraSize, 3.3);
		}

		// Token: 0x0601C048 RID: 114760 RVA: 0x0088F452 File Offset: 0x0088D852
		public static void AddCameraZRange(FlatBufferBuilder builder, Offset<Vector2> CameraZRangeOffset)
		{
			builder.AddStruct(9, CameraZRangeOffset.Value, 0);
		}

		// Token: 0x0601C049 RID: 114761 RVA: 0x0088F464 File Offset: 0x0088D864
		public static void AddCameraXRange(FlatBufferBuilder builder, Offset<Vector2> CameraXRangeOffset)
		{
			builder.AddStruct(10, CameraXRangeOffset.Value, 0);
		}

		// Token: 0x0601C04A RID: 114762 RVA: 0x0088F476 File Offset: 0x0088D876
		public static void AddCameraPersp(FlatBufferBuilder builder, bool CameraPersp)
		{
			builder.AddBool(11, CameraPersp, false);
		}

		// Token: 0x0601C04B RID: 114763 RVA: 0x0088F482 File Offset: 0x0088D882
		public static void AddCenterPostionNew(FlatBufferBuilder builder, Offset<Vector3> CenterPostionNewOffset)
		{
			builder.AddStruct(12, CenterPostionNewOffset.Value, 0);
		}

		// Token: 0x0601C04C RID: 114764 RVA: 0x0088F494 File Offset: 0x0088D894
		public static void AddScenePostion(FlatBufferBuilder builder, Offset<Vector3> ScenePostionOffset)
		{
			builder.AddStruct(13, ScenePostionOffset.Value, 0);
		}

		// Token: 0x0601C04D RID: 114765 RVA: 0x0088F4A6 File Offset: 0x0088D8A6
		public static void AddSceneUScale(FlatBufferBuilder builder, float SceneUScale)
		{
			builder.AddFloat(14, SceneUScale, 1.0);
		}

		// Token: 0x0601C04E RID: 114766 RVA: 0x0088F4BA File Offset: 0x0088D8BA
		public static void AddGridSize(FlatBufferBuilder builder, Offset<Vector2> GridSizeOffset)
		{
			builder.AddStruct(15, GridSizeOffset.Value, 0);
		}

		// Token: 0x0601C04F RID: 114767 RVA: 0x0088F4CC File Offset: 0x0088D8CC
		public static void AddLogicXSize(FlatBufferBuilder builder, Offset<Vector2> LogicXSizeOffset)
		{
			builder.AddStruct(16, LogicXSizeOffset.Value, 0);
		}

		// Token: 0x0601C050 RID: 114768 RVA: 0x0088F4DE File Offset: 0x0088D8DE
		public static void AddLogicZSize(FlatBufferBuilder builder, Offset<Vector2> LogicZSizeOffset)
		{
			builder.AddStruct(17, LogicZSizeOffset.Value, 0);
		}

		// Token: 0x0601C051 RID: 114769 RVA: 0x0088F4F0 File Offset: 0x0088D8F0
		public static void AddObjectDyeColor(FlatBufferBuilder builder, Offset<Color> ObjectDyeColorOffset)
		{
			builder.AddStruct(18, ObjectDyeColorOffset.Value, 0);
		}

		// Token: 0x0601C052 RID: 114770 RVA: 0x0088F502 File Offset: 0x0088D902
		public static void AddLogicPos(FlatBufferBuilder builder, Offset<Vector3> LogicPosOffset)
		{
			builder.AddStruct(19, LogicPosOffset.Value, 0);
		}

		// Token: 0x0601C053 RID: 114771 RVA: 0x0088F514 File Offset: 0x0088D914
		public static void AddWeatherMode(FlatBufferBuilder builder, EWeatherMode WeatherMode)
		{
			builder.AddSbyte(20, (sbyte)WeatherMode, 0);
		}

		// Token: 0x0601C054 RID: 114772 RVA: 0x0088F520 File Offset: 0x0088D920
		public static void AddTipsID(FlatBufferBuilder builder, int TipsID)
		{
			builder.AddInt(21, TipsID, 0);
		}

		// Token: 0x0601C055 RID: 114773 RVA: 0x0088F52C File Offset: 0x0088D92C
		public static void AddLightmapsettingsPath(FlatBufferBuilder builder, StringOffset LightmapsettingsPathOffset)
		{
			builder.AddOffset(22, LightmapsettingsPathOffset.Value, 0);
		}

		// Token: 0x0601C056 RID: 114774 RVA: 0x0088F53E File Offset: 0x0088D93E
		public static void AddLogicXmin(FlatBufferBuilder builder, int LogicXmin)
		{
			builder.AddInt(23, LogicXmin, 0);
		}

		// Token: 0x0601C057 RID: 114775 RVA: 0x0088F54A File Offset: 0x0088D94A
		public static void AddLogicXmax(FlatBufferBuilder builder, int LogicXmax)
		{
			builder.AddInt(24, LogicXmax, 0);
		}

		// Token: 0x0601C058 RID: 114776 RVA: 0x0088F556 File Offset: 0x0088D956
		public static void AddLogicZmin(FlatBufferBuilder builder, int LogicZmin)
		{
			builder.AddInt(25, LogicZmin, 0);
		}

		// Token: 0x0601C059 RID: 114777 RVA: 0x0088F562 File Offset: 0x0088D962
		public static void AddLogicZmax(FlatBufferBuilder builder, int LogicZmax)
		{
			builder.AddInt(26, LogicZmax, 0);
		}

		// Token: 0x0601C05A RID: 114778 RVA: 0x0088F56E File Offset: 0x0088D96E
		public static void AddEntityinfo(FlatBufferBuilder builder, VectorOffset entityinfoOffset)
		{
			builder.AddOffset(27, entityinfoOffset.Value, 0);
		}

		// Token: 0x0601C05B RID: 114779 RVA: 0x0088F580 File Offset: 0x0088D980
		public static VectorOffset CreateEntityinfoVector(FlatBufferBuilder builder, Offset<DEntityInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C05C RID: 114780 RVA: 0x0088F5C6 File Offset: 0x0088D9C6
		public static void StartEntityinfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C05D RID: 114781 RVA: 0x0088F5D1 File Offset: 0x0088D9D1
		public static void AddBlocklayer(FlatBufferBuilder builder, VectorOffset blocklayerOffset)
		{
			builder.AddOffset(28, blocklayerOffset.Value, 0);
		}

		// Token: 0x0601C05E RID: 114782 RVA: 0x0088F5E4 File Offset: 0x0088D9E4
		public static VectorOffset CreateBlocklayerVector(FlatBufferBuilder builder, byte[] data)
		{
			builder.StartVector(1, data.Length, 1);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddByte(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C05F RID: 114783 RVA: 0x0088F621 File Offset: 0x0088DA21
		public static void StartBlocklayerVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(1, numElems, 1);
		}

		// Token: 0x0601C060 RID: 114784 RVA: 0x0088F62C File Offset: 0x0088DA2C
		public static void AddNpcinfo(FlatBufferBuilder builder, VectorOffset npcinfoOffset)
		{
			builder.AddOffset(29, npcinfoOffset.Value, 0);
		}

		// Token: 0x0601C061 RID: 114785 RVA: 0x0088F640 File Offset: 0x0088DA40
		public static VectorOffset CreateNpcinfoVector(FlatBufferBuilder builder, Offset<DNPCInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C062 RID: 114786 RVA: 0x0088F686 File Offset: 0x0088DA86
		public static void StartNpcinfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C063 RID: 114787 RVA: 0x0088F691 File Offset: 0x0088DA91
		public static void AddMonsterinfo(FlatBufferBuilder builder, VectorOffset monsterinfoOffset)
		{
			builder.AddOffset(30, monsterinfoOffset.Value, 0);
		}

		// Token: 0x0601C064 RID: 114788 RVA: 0x0088F6A4 File Offset: 0x0088DAA4
		public static VectorOffset CreateMonsterinfoVector(FlatBufferBuilder builder, Offset<DMonsterInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C065 RID: 114789 RVA: 0x0088F6EA File Offset: 0x0088DAEA
		public static void StartMonsterinfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C066 RID: 114790 RVA: 0x0088F6F5 File Offset: 0x0088DAF5
		public static void AddDecoratorinfo(FlatBufferBuilder builder, VectorOffset decoratorinfoOffset)
		{
			builder.AddOffset(31, decoratorinfoOffset.Value, 0);
		}

		// Token: 0x0601C067 RID: 114791 RVA: 0x0088F708 File Offset: 0x0088DB08
		public static VectorOffset CreateDecoratorinfoVector(FlatBufferBuilder builder, Offset<DDecoratorInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C068 RID: 114792 RVA: 0x0088F74E File Offset: 0x0088DB4E
		public static void StartDecoratorinfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C069 RID: 114793 RVA: 0x0088F759 File Offset: 0x0088DB59
		public static void AddDesructibleinfo(FlatBufferBuilder builder, VectorOffset desructibleinfoOffset)
		{
			builder.AddOffset(32, desructibleinfoOffset.Value, 0);
		}

		// Token: 0x0601C06A RID: 114794 RVA: 0x0088F76C File Offset: 0x0088DB6C
		public static VectorOffset CreateDesructibleinfoVector(FlatBufferBuilder builder, Offset<DDestructibleInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C06B RID: 114795 RVA: 0x0088F7B2 File Offset: 0x0088DBB2
		public static void StartDesructibleinfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C06C RID: 114796 RVA: 0x0088F7BD File Offset: 0x0088DBBD
		public static void AddRegioninfo(FlatBufferBuilder builder, VectorOffset regioninfoOffset)
		{
			builder.AddOffset(33, regioninfoOffset.Value, 0);
		}

		// Token: 0x0601C06D RID: 114797 RVA: 0x0088F7D0 File Offset: 0x0088DBD0
		public static VectorOffset CreateRegioninfoVector(FlatBufferBuilder builder, Offset<DRegionInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C06E RID: 114798 RVA: 0x0088F816 File Offset: 0x0088DC16
		public static void StartRegioninfoVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C06F RID: 114799 RVA: 0x0088F821 File Offset: 0x0088DC21
		public static void AddTransportdoor(FlatBufferBuilder builder, VectorOffset transportdoorOffset)
		{
			builder.AddOffset(34, transportdoorOffset.Value, 0);
		}

		// Token: 0x0601C070 RID: 114800 RVA: 0x0088F834 File Offset: 0x0088DC34
		public static VectorOffset CreateTransportdoorVector(FlatBufferBuilder builder, Offset<DTransportDoor>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C071 RID: 114801 RVA: 0x0088F87A File Offset: 0x0088DC7A
		public static void StartTransportdoorVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C072 RID: 114802 RVA: 0x0088F885 File Offset: 0x0088DC85
		public static void AddFighterBornPosition(FlatBufferBuilder builder, VectorOffset fighterBornPositionOffset)
		{
			builder.AddOffset(35, fighterBornPositionOffset.Value, 0);
		}

		// Token: 0x0601C073 RID: 114803 RVA: 0x0088F898 File Offset: 0x0088DC98
		public static VectorOffset CreateFighterBornPositionVector(FlatBufferBuilder builder, Offset<DTransferInfo>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C074 RID: 114804 RVA: 0x0088F8DE File Offset: 0x0088DCDE
		public static void StartFighterBornPositionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C075 RID: 114805 RVA: 0x0088F8E9 File Offset: 0x0088DCE9
		public static void AddBirthposition(FlatBufferBuilder builder, Offset<DEntityInfo> birthpositionOffset)
		{
			builder.AddOffset(36, birthpositionOffset.Value, 0);
		}

		// Token: 0x0601C076 RID: 114806 RVA: 0x0088F8FB File Offset: 0x0088DCFB
		public static void AddHellbirthposition(FlatBufferBuilder builder, Offset<DEntityInfo> hellbirthpositionOffset)
		{
			builder.AddOffset(37, hellbirthpositionOffset.Value, 0);
		}

		// Token: 0x0601C077 RID: 114807 RVA: 0x0088F90D File Offset: 0x0088DD0D
		public static void AddTownDoor(FlatBufferBuilder builder, VectorOffset townDoorOffset)
		{
			builder.AddOffset(38, townDoorOffset.Value, 0);
		}

		// Token: 0x0601C078 RID: 114808 RVA: 0x0088F920 File Offset: 0x0088DD20
		public static VectorOffset CreateTownDoorVector(FlatBufferBuilder builder, Offset<DTownDoor>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C079 RID: 114809 RVA: 0x0088F966 File Offset: 0x0088DD66
		public static void StartTownDoorVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C07A RID: 114810 RVA: 0x0088F971 File Offset: 0x0088DD71
		public static void AddFunctionPrefab(FlatBufferBuilder builder, VectorOffset FunctionPrefabOffset)
		{
			builder.AddOffset(39, FunctionPrefabOffset.Value, 0);
		}

		// Token: 0x0601C07B RID: 114811 RVA: 0x0088F984 File Offset: 0x0088DD84
		public static VectorOffset CreateFunctionPrefabVector(FlatBufferBuilder builder, Offset<FunctionPrefab>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C07C RID: 114812 RVA: 0x0088F9CA File Offset: 0x0088DDCA
		public static void StartFunctionPrefabVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C07D RID: 114813 RVA: 0x0088F9D8 File Offset: 0x0088DDD8
		public static Offset<DSceneData> EndDSceneData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSceneData>(value);
		}

		// Token: 0x0601C07E RID: 114814 RVA: 0x0088F9F2 File Offset: 0x0088DDF2
		public static void FinishDSceneDataBuffer(FlatBufferBuilder builder, Offset<DSceneData> offset)
		{
			builder.Finish(offset.Value, "SCEN");
		}
	}
}
