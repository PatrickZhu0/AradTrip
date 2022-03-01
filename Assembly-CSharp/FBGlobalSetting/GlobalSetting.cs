using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000128 RID: 296
	public sealed class GlobalSetting : Table
	{
		// Token: 0x060006F1 RID: 1777 RVA: 0x00028733 File Offset: 0x00026B33
		public static GlobalSetting GetRootAsGlobalSetting(ByteBuffer _bb)
		{
			return GlobalSetting.GetRootAsGlobalSetting(_bb, new GlobalSetting());
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00028740 File Offset: 0x00026B40
		public static GlobalSetting GetRootAsGlobalSetting(ByteBuffer _bb, GlobalSetting obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0002875C File Offset: 0x00026B5C
		public GlobalSetting __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00028770 File Offset: 0x00026B70
		public bool IsTestTeam
		{
			get
			{
				int num = base.__offset(4);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x000287AC File Offset: 0x00026BAC
		public bool IsPaySDKDebug
		{
			get
			{
				int num = base.__offset(6);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x000287E8 File Offset: 0x00026BE8
		public int SdkChannel
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0002881C File Offset: 0x00026C1C
		public bool IsBanShuVersion
		{
			get
			{
				int num = base.__offset(10);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00028858 File Offset: 0x00026C58
		public bool IsDebug
		{
			get
			{
				int num = base.__offset(12);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x00028894 File Offset: 0x00026C94
		public bool IsLogRecord
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x000288D0 File Offset: 0x00026CD0
		public bool IsRecordPVP
		{
			get
			{
				int num = base.__offset(16);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x0002890C File Offset: 0x00026D0C
		public bool ShowDebugBox
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x00028948 File Offset: 0x00026D48
		public int FrameLock
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00028980 File Offset: 0x00026D80
		public float FallgroundHitFactor
		{
			get
			{
				int num = base.__offset(22);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x000289BC File Offset: 0x00026DBC
		public float HitTime
		{
			get
			{
				int num = base.__offset(24);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x000289F8 File Offset: 0x00026DF8
		public float DeadWhiteTime
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x00028A34 File Offset: 0x00026E34
		public string DefaultHitEffect
		{
			get
			{
				int num = base.__offset(28);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00028A64 File Offset: 0x00026E64
		public string DefaultProjectileHitEffect
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000702 RID: 1794 RVA: 0x00028A94 File Offset: 0x00026E94
		public string DefualtHitSfx
		{
			get
			{
				int num = base.__offset(32);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00028AC4 File Offset: 0x00026EC4
		public Vector3 _walkSpeed
		{
			get
			{
				return this.Get_walkSpeed(new Vector3());
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00028AD4 File Offset: 0x00026ED4
		public Vector3 Get_walkSpeed(Vector3 obj)
		{
			int num = base.__offset(34);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x00028B0A File Offset: 0x00026F0A
		public Vector3 _runSpeed
		{
			get
			{
				return this.Get_runSpeed(new Vector3());
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x00028B18 File Offset: 0x00026F18
		public Vector3 Get_runSpeed(Vector3 obj)
		{
			int num = base.__offset(36);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000707 RID: 1799 RVA: 0x00028B4E File Offset: 0x00026F4E
		public Vector3 TownWalkSpeed
		{
			get
			{
				return this.GetTownWalkSpeed(new Vector3());
			}
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x00028B5C File Offset: 0x00026F5C
		public Vector3 GetTownWalkSpeed(Vector3 obj)
		{
			int num = base.__offset(38);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x00028B92 File Offset: 0x00026F92
		public Vector3 TownRunSpeed
		{
			get
			{
				return this.GetTownRunSpeed(new Vector3());
			}
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x00028BA0 File Offset: 0x00026FA0
		public Vector3 GetTownRunSpeed(Vector3 obj)
		{
			int num = base.__offset(40);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00028BD8 File Offset: 0x00026FD8
		public float TownActionSpeed
		{
			get
			{
				int num = base.__offset(42);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600070C RID: 1804 RVA: 0x00028C14 File Offset: 0x00027014
		public bool TownPlayerRun
		{
			get
			{
				int num = base.__offset(44);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00028C50 File Offset: 0x00027050
		public int MinHurtTime
		{
			get
			{
				int num = base.__offset(46);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x00028C88 File Offset: 0x00027088
		public int MaxHurtTime
		{
			get
			{
				int num = base.__offset(48);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00028CC0 File Offset: 0x000270C0
		public float FrozenPercent
		{
			get
			{
				int num = base.__offset(50);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x00028CF9 File Offset: 0x000270F9
		public Vector2 JumpBackSpeed
		{
			get
			{
				return this.GetJumpBackSpeed(new Vector2());
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00028D08 File Offset: 0x00027108
		public Vector2 GetJumpBackSpeed(Vector2 obj)
		{
			int num = base.__offset(52);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x00028D40 File Offset: 0x00027140
		public float JumpForce
		{
			get
			{
				int num = base.__offset(54);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x00028D7C File Offset: 0x0002717C
		public float ClickForce
		{
			get
			{
				int num = base.__offset(56);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x00028DB8 File Offset: 0x000271B8
		public float SnapDuration
		{
			get
			{
				int num = base.__offset(58);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000715 RID: 1813 RVA: 0x00028DF4 File Offset: 0x000271F4
		public float _dunFuTime
		{
			get
			{
				int num = base.__offset(60);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x00028E30 File Offset: 0x00027230
		public float _pvpDunFuTime
		{
			get
			{
				int num = base.__offset(62);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x00028E6C File Offset: 0x0002726C
		public int PVPHPScale
		{
			get
			{
				int num = base.__offset(64);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00028EA4 File Offset: 0x000272A4
		public int TestLevel
		{
			get
			{
				int num = base.__offset(66);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000719 RID: 1817 RVA: 0x00028EDC File Offset: 0x000272DC
		public int TestPlayerNum
		{
			get
			{
				int num = base.__offset(68);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x00028F14 File Offset: 0x00027314
		public bool ShowBattleInfoPanel
		{
			get
			{
				int num = base.__offset(70);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600071B RID: 1819 RVA: 0x00028F50 File Offset: 0x00027350
		public int DefaultMonsterID
		{
			get
			{
				int num = base.__offset(72);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00028F88 File Offset: 0x00027388
		public float _monsterWalkSpeedFactor
		{
			get
			{
				int num = base.__offset(74);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600071D RID: 1821 RVA: 0x00028FC4 File Offset: 0x000273C4
		public float _monsterSightFactor
		{
			get
			{
				int num = base.__offset(76);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00029000 File Offset: 0x00027400
		public bool EnableAssetInstPool
		{
			get
			{
				int num = base.__offset(78);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600071F RID: 1823 RVA: 0x0002903C File Offset: 0x0002743C
		public bool EnemyHasAI
		{
			get
			{
				int num = base.__offset(80);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00029078 File Offset: 0x00027478
		public bool IsCreateMonsterLocal
		{
			get
			{
				int num = base.__offset(82);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x000290B4 File Offset: 0x000274B4
		public bool IsGiveEquips
		{
			get
			{
				int num = base.__offset(84);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x000290F0 File Offset: 0x000274F0
		public string EquipList
		{
			get
			{
				int num = base.__offset(86);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000723 RID: 1827 RVA: 0x00029120 File Offset: 0x00027520
		public bool IsGuide
		{
			get
			{
				int num = base.__offset(88);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x0002915C File Offset: 0x0002755C
		public bool DisplayHUD
		{
			get
			{
				int num = base.__offset(90);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x00029198 File Offset: 0x00027598
		public bool CloseTeamCondition
		{
			get
			{
				int num = base.__offset(92);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x000291D4 File Offset: 0x000275D4
		public bool IsLocalDungeon
		{
			get
			{
				int num = base.__offset(94);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00029210 File Offset: 0x00027610
		public int LocalDungeonID
		{
			get
			{
				int num = base.__offset(96);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00029248 File Offset: 0x00027648
		public bool RecordResFile
		{
			get
			{
				int num = base.__offset(98);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x00029284 File Offset: 0x00027684
		public bool ProfileAssetLoad
		{
			get
			{
				int num = base.__offset(100);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x000292C0 File Offset: 0x000276C0
		public float _gravity
		{
			get
			{
				int num = base.__offset(102);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x000292FC File Offset: 0x000276FC
		public float _fallGravityReduceFactor
		{
			get
			{
				int num = base.__offset(104);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x00029338 File Offset: 0x00027738
		public bool SkillHasCooldown
		{
			get
			{
				int num = base.__offset(106);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00029374 File Offset: 0x00027774
		public string ScenePath
		{
			get
			{
				int num = base.__offset(108);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x000293A4 File Offset: 0x000277A4
		public int IpSelectedIndex
		{
			get
			{
				int num = base.__offset(110);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x000293DC File Offset: 0x000277DC
		public int ISingleCharactorID
		{
			get
			{
				int num = base.__offset(112);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x00029411 File Offset: 0x00027811
		public Vector2 CameraInRange
		{
			get
			{
				return this.GetCameraInRange(new Vector2());
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x00029420 File Offset: 0x00027820
		public Vector2 GetCameraInRange(Vector2 obj)
		{
			int num = base.__offset(114);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00029458 File Offset: 0x00027858
		public int ButtonType
		{
			get
			{
				int num = base.__offset(116);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x00029490 File Offset: 0x00027890
		public float _defaultFloatHurt
		{
			get
			{
				int num = base.__offset(118);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x000294CC File Offset: 0x000278CC
		public float _defaultFloatLevelHurat
		{
			get
			{
				int num = base.__offset(120);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00029508 File Offset: 0x00027908
		public float _defaultGroundHurt
		{
			get
			{
				int num = base.__offset(122);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00029544 File Offset: 0x00027944
		public float _defaultStandHurt
		{
			get
			{
				int num = base.__offset(124);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x00029580 File Offset: 0x00027980
		public float _fallProtectGravityAddFactor
		{
			get
			{
				int num = base.__offset(126);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x000295BC File Offset: 0x000279BC
		public int _protectClearDuration
		{
			get
			{
				int num = base.__offset(128);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x000295F4 File Offset: 0x000279F4
		public float BgmStart
		{
			get
			{
				int num = base.__offset(130);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x00029630 File Offset: 0x00027A30
		public float BgmTown
		{
			get
			{
				int num = base.__offset(132);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0002966C File Offset: 0x00027A6C
		public float BgmBattle
		{
			get
			{
				int num = base.__offset(134);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600073C RID: 1852 RVA: 0x000296A8 File Offset: 0x00027AA8
		public float _zDimFactor
		{
			get
			{
				int num = base.__offset(136);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x000296E4 File Offset: 0x00027AE4
		public float BullteScale
		{
			get
			{
				int num = base.__offset(138);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00029720 File Offset: 0x00027B20
		public int BullteTime
		{
			get
			{
				int num = base.__offset(140);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x00029758 File Offset: 0x00027B58
		public int StartSystem
		{
			get
			{
				int num = base.__offset(142);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00029790 File Offset: 0x00027B90
		public string GetLoggerFilter(int j)
		{
			int num = base.__offset(144);
			return (num == 0) ? null : base.__string(base.__vector(num) + j * 4);
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x000297C8 File Offset: 0x00027BC8
		public int LoggerFilterLength
		{
			get
			{
				int num = base.__offset(144);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x000297F4 File Offset: 0x00027BF4
		public bool ShowDialog
		{
			get
			{
				int num = base.__offset(146);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00029832 File Offset: 0x00027C32
		public Vector3 AvatarLightDir
		{
			get
			{
				return this.GetAvatarLightDir(new Vector3());
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00029840 File Offset: 0x00027C40
		public Vector3 GetAvatarLightDir(Vector3 obj)
		{
			int num = base.__offset(148);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00029879 File Offset: 0x00027C79
		public Vector3 ShadowLightDir
		{
			get
			{
				return this.GetShadowLightDir(new Vector3());
			}
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00029888 File Offset: 0x00027C88
		public Vector3 GetShadowLightDir(Vector3 obj)
		{
			int num = base.__offset(150);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x000298C1 File Offset: 0x00027CC1
		public Vector3 StartVel
		{
			get
			{
				return this.GetStartVel(new Vector3());
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000298D0 File Offset: 0x00027CD0
		public Vector3 GetStartVel(Vector3 obj)
		{
			int num = base.__offset(152);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x00029909 File Offset: 0x00027D09
		public Vector3 EndVel
		{
			get
			{
				return this.GetEndVel(new Vector3());
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00029918 File Offset: 0x00027D18
		public Vector3 GetEndVel(Vector3 obj)
		{
			int num = base.__offset(154);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x00029951 File Offset: 0x00027D51
		public Vector3 Offset
		{
			get
			{
				return this.GetOffset(new Vector3());
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00029960 File Offset: 0x00027D60
		public Vector3 GetOffset(Vector3 obj)
		{
			int num = base.__offset(156);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0002999C File Offset: 0x00027D9C
		public float TimeAccerlate
		{
			get
			{
				int num = base.__offset(158);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600074E RID: 1870 RVA: 0x000299D8 File Offset: 0x00027DD8
		public int TotalTime
		{
			get
			{
				int num = base.__offset(160);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600074F RID: 1871 RVA: 0x00029A10 File Offset: 0x00027E10
		public int TotalDist
		{
			get
			{
				int num = base.__offset(162);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00029A48 File Offset: 0x00027E48
		public bool HeightAdoption
		{
			get
			{
				int num = base.__offset(164);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x00029A88 File Offset: 0x00027E88
		public bool DebugDrawBlock
		{
			get
			{
				int num = base.__offset(166);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x00029AC8 File Offset: 0x00027EC8
		public bool LoadFromPackage
		{
			get
			{
				int num = base.__offset(168);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x00029B08 File Offset: 0x00027F08
		public bool EnableHotFix
		{
			get
			{
				int num = base.__offset(170);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00029B48 File Offset: 0x00027F48
		public bool HotFixUrlDebug
		{
			get
			{
				int num = base.__offset(172);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000755 RID: 1877 RVA: 0x00029B88 File Offset: 0x00027F88
		public int REVIVESHOCKSKILLID
		{
			get
			{
				int num = base.__offset(174);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x00029BC0 File Offset: 0x00027FC0
		public Vector2 RollSpeed
		{
			get
			{
				return this.GetRollSpeed(new Vector2());
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00029BD0 File Offset: 0x00027FD0
		public Vector2 GetRollSpeed(Vector2 obj)
		{
			int num = base.__offset(176);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x00029C0C File Offset: 0x0002800C
		public float RollRand
		{
			get
			{
				int num = base.__offset(178);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00029C48 File Offset: 0x00028048
		public float NormalRollRand
		{
			get
			{
				int num = base.__offset(180);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600075A RID: 1882 RVA: 0x00029C84 File Offset: 0x00028084
		public float _pkDamageAdjustFactor
		{
			get
			{
				int num = base.__offset(182);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x00029CC0 File Offset: 0x000280C0
		public float _pkHPAdjustFactor
		{
			get
			{
				int num = base.__offset(184);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00029CFC File Offset: 0x000280FC
		public bool PkUseMaxLevel
		{
			get
			{
				int num = base.__offset(186);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x00029D3C File Offset: 0x0002813C
		public int BattleRunMode
		{
			get
			{
				int num = base.__offset(188);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600075E RID: 1886 RVA: 0x00029D74 File Offset: 0x00028174
		public bool HasDoubleRun
		{
			get
			{
				int num = base.__offset(190);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00029DB4 File Offset: 0x000281B4
		public int PlayerHP
		{
			get
			{
				int num = base.__offset(192);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x00029DEC File Offset: 0x000281EC
		public int PlayerRebornHP
		{
			get
			{
				int num = base.__offset(194);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00029E24 File Offset: 0x00028224
		public int MonsterHP
		{
			get
			{
				int num = base.__offset(196);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x00029E5C File Offset: 0x0002825C
		public Vector3 PlayerPos
		{
			get
			{
				return this.GetPlayerPos(new Vector3());
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00029E6C File Offset: 0x0002826C
		public Vector3 GetPlayerPos(Vector3 obj)
		{
			int num = base.__offset(198);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00029EA8 File Offset: 0x000282A8
		public float TransportDoorRadius
		{
			get
			{
				int num = base.__offset(200);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x00029EE4 File Offset: 0x000282E4
		public float PetXMovingDis
		{
			get
			{
				int num = base.__offset(202);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00029F20 File Offset: 0x00028320
		public float PetXMovingv1
		{
			get
			{
				int num = base.__offset(204);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000767 RID: 1895 RVA: 0x00029F5C File Offset: 0x0002835C
		public float PetXMovingv2
		{
			get
			{
				int num = base.__offset(206);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00029F98 File Offset: 0x00028398
		public float PetYMovingDis
		{
			get
			{
				int num = base.__offset(208);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00029FD4 File Offset: 0x000283D4
		public float PetYMovingv1
		{
			get
			{
				int num = base.__offset(210);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0002A010 File Offset: 0x00028410
		public float PetYMovingv2
		{
			get
			{
				int num = base.__offset(212);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0002A04C File Offset: 0x0002844C
		public string ServerListUrl
		{
			get
			{
				int num = base.__offset(214);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x0002A07F File Offset: 0x0002847F
		public Address GetServerList(int j)
		{
			return this.GetServerList(new Address(), j);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0002A090 File Offset: 0x00028490
		public Address GetServerList(Address obj, int j)
		{
			int num = base.__offset(216);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x0002A0D4 File Offset: 0x000284D4
		public int ServerListLength
		{
			get
			{
				int num = base.__offset(216);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x0002A100 File Offset: 0x00028500
		public bool DebugNewAutofightAI
		{
			get
			{
				int num = base.__offset(218);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0002A140 File Offset: 0x00028540
		public float CharScale
		{
			get
			{
				int num = base.__offset(220);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x0002A17C File Offset: 0x0002857C
		public ShockData MonsterBeHitShockData
		{
			get
			{
				return this.GetMonsterBeHitShockData(new ShockData());
			}
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0002A18C File Offset: 0x0002858C
		public ShockData GetMonsterBeHitShockData(ShockData obj)
		{
			int num = base.__offset(222);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x0002A1C5 File Offset: 0x000285C5
		public ShockData PlayerBeHitShockData
		{
			get
			{
				return this.GetPlayerBeHitShockData(new ShockData());
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0002A1D4 File Offset: 0x000285D4
		public ShockData GetPlayerBeHitShockData(ShockData obj)
		{
			int num = base.__offset(224);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0002A20D File Offset: 0x0002860D
		public ShockData PlayerSkillCDShockData
		{
			get
			{
				return this.GetPlayerSkillCDShockData(new ShockData());
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0002A21C File Offset: 0x0002861C
		public ShockData GetPlayerSkillCDShockData(ShockData obj)
		{
			int num = base.__offset(226);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x0002A255 File Offset: 0x00028655
		public ShockData PlayerHighFallTouchGroundShockData
		{
			get
			{
				return this.GetPlayerHighFallTouchGroundShockData(new ShockData());
			}
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0002A264 File Offset: 0x00028664
		public ShockData GetPlayerHighFallTouchGroundShockData(ShockData obj)
		{
			int num = base.__offset(228);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0002A2A0 File Offset: 0x000286A0
		public float HighFallHight
		{
			get
			{
				int num = base.__offset(230);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0002A2DC File Offset: 0x000286DC
		public string CritialDeadEffect
		{
			get
			{
				int num = base.__offset(232);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0002A310 File Offset: 0x00028710
		public string ImmediateDeadEffect
		{
			get
			{
				int num = base.__offset(234);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x0002A344 File Offset: 0x00028744
		public string NormalDeadEffect
		{
			get
			{
				int num = base.__offset(236);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x0002A378 File Offset: 0x00028778
		public bool EnableEffectLimit
		{
			get
			{
				int num = base.__offset(238);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0002A3B8 File Offset: 0x000287B8
		public int EffectLimitCount
		{
			get
			{
				int num = base.__offset(240);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x0002A3F0 File Offset: 0x000287F0
		public int ImmediateDeadHPPercent
		{
			get
			{
				int num = base.__offset(242);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x0002A428 File Offset: 0x00028828
		public bool OpenBossShow
		{
			get
			{
				int num = base.__offset(244);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0002A468 File Offset: 0x00028868
		public float ShooterFitPercent
		{
			get
			{
				int num = base.__offset(246);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x0002A4A4 File Offset: 0x000288A4
		public Vector3 DisappearDis
		{
			get
			{
				return this.GetDisappearDis(new Vector3());
			}
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0002A4B4 File Offset: 0x000288B4
		public Vector3 GetDisappearDis(Vector3 obj)
		{
			int num = base.__offset(248);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0002A4F0 File Offset: 0x000288F0
		public float KeepDis
		{
			get
			{
				int num = base.__offset(250);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x0002A52C File Offset: 0x0002892C
		public float AccompanyRunTime
		{
			get
			{
				int num = base.__offset(252);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0002A568 File Offset: 0x00028968
		public int _aiWanderRange
		{
			get
			{
				int num = base.__offset(254);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0002A5A0 File Offset: 0x000289A0
		public int _aiWAlkBackRange
		{
			get
			{
				int num = base.__offset(256);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0002A5D8 File Offset: 0x000289D8
		public int _aiMaxWalkCmdCount
		{
			get
			{
				int num = base.__offset(258);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0002A610 File Offset: 0x00028A10
		public int _aiMaxWalkCmdCountRANGED
		{
			get
			{
				int num = base.__offset(260);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0002A648 File Offset: 0x00028A48
		public int _aiMaxIdleCmdcount
		{
			get
			{
				int num = base.__offset(262);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x0002A680 File Offset: 0x00028A80
		public int _aiSkillAttackPassive
		{
			get
			{
				int num = base.__offset(264);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0002A6B8 File Offset: 0x00028AB8
		public float _monsterGetupBatiFactor
		{
			get
			{
				int num = base.__offset(266);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600078D RID: 1933 RVA: 0x0002A6F4 File Offset: 0x00028AF4
		public float _degangBackDistance
		{
			get
			{
				int num = base.__offset(268);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x0002A730 File Offset: 0x00028B30
		public int _afThinkTerm
		{
			get
			{
				int num = base.__offset(270);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0002A768 File Offset: 0x00028B68
		public int _afFindTargetTerm
		{
			get
			{
				int num = base.__offset(272);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x0002A7A0 File Offset: 0x00028BA0
		public int _afChangeDestinationTerm
		{
			get
			{
				int num = base.__offset(274);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0002A7D8 File Offset: 0x00028BD8
		public int _autoCheckRestoreInterval
		{
			get
			{
				int num = base.__offset(276);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0002A810 File Offset: 0x00028C10
		public bool ForceUseAutoFight
		{
			get
			{
				int num = base.__offset(278);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x0002A850 File Offset: 0x00028C50
		public bool CanUseAutoFight
		{
			get
			{
				int num = base.__offset(280);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0002A890 File Offset: 0x00028C90
		public bool CanUseAutoFightFirstPass
		{
			get
			{
				int num = base.__offset(282);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x0002A8D0 File Offset: 0x00028CD0
		public bool LoadAutoFight
		{
			get
			{
				int num = base.__offset(284);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x0002A910 File Offset: 0x00028D10
		public float JumpAttackLimitHeight
		{
			get
			{
				int num = base.__offset(286);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x0002A94C File Offset: 0x00028D4C
		public float SkillCancelLimitTime
		{
			get
			{
				int num = base.__offset(288);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x0002A988 File Offset: 0x00028D88
		public int DoublePressCheckDuration
		{
			get
			{
				int num = base.__offset(290);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x0002A9C0 File Offset: 0x00028DC0
		public int WalkAction
		{
			get
			{
				int num = base.__offset(292);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x0002A9F8 File Offset: 0x00028DF8
		public int RunAction
		{
			get
			{
				int num = base.__offset(294);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0002AA30 File Offset: 0x00028E30
		public float WalkAniFactor
		{
			get
			{
				int num = base.__offset(296);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600079C RID: 1948 RVA: 0x0002AA6C File Offset: 0x00028E6C
		public float RunAniFactor
		{
			get
			{
				int num = base.__offset(298);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x0002AAA8 File Offset: 0x00028EA8
		public bool ChangeFaceStop
		{
			get
			{
				int num = base.__offset(300);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x0002AAE6 File Offset: 0x00028EE6
		public Vector3 _monsterWalkSpeed
		{
			get
			{
				return this.Get_monsterWalkSpeed(new Vector3());
			}
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x0002AAF4 File Offset: 0x00028EF4
		public Vector3 Get_monsterWalkSpeed(Vector3 obj)
		{
			int num = base.__offset(302);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0002AB2D File Offset: 0x00028F2D
		public Vector3 _monsterRunSpeed
		{
			get
			{
				return this.Get_monsterRunSpeed(new Vector3());
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x0002AB3C File Offset: 0x00028F3C
		public Vector3 Get_monsterRunSpeed(Vector3 obj)
		{
			int num = base.__offset(304);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x0002AB78 File Offset: 0x00028F78
		public int TableLoadStep
		{
			get
			{
				int num = base.__offset(306);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0002ABB0 File Offset: 0x00028FB0
		public int LoadingProgressStepInEditor
		{
			get
			{
				int num = base.__offset(308);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0002ABE8 File Offset: 0x00028FE8
		public int LoadingProgressStep
		{
			get
			{
				int num = base.__offset(310);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060007A5 RID: 1957 RVA: 0x0002AC20 File Offset: 0x00029020
		public string PvpDefaultSesstionID
		{
			get
			{
				int num = base.__offset(312);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0002AC54 File Offset: 0x00029054
		public int PetID
		{
			get
			{
				int num = base.__offset(314);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0002AC8C File Offset: 0x0002908C
		public int PetLevel
		{
			get
			{
				int num = base.__offset(316);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060007A8 RID: 1960 RVA: 0x0002ACC4 File Offset: 0x000290C4
		public int PetHunger
		{
			get
			{
				int num = base.__offset(318);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x0002ACFC File Offset: 0x000290FC
		public int PetSkillIndex
		{
			get
			{
				int num = base.__offset(320);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x0002AD34 File Offset: 0x00029134
		public bool TestFashionEquip
		{
			get
			{
				int num = base.__offset(322);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0002AD74 File Offset: 0x00029174
		public string GetEquipPropFactorsKey(int j)
		{
			int num = base.__offset(324);
			return (num == 0) ? null : base.__string(base.__vector(num) + j * 4);
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060007AC RID: 1964 RVA: 0x0002ADAC File Offset: 0x000291AC
		public int EquipPropFactorsKeyLength
		{
			get
			{
				int num = base.__offset(324);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0002ADD8 File Offset: 0x000291D8
		public float GetEquipPropFactorsValue(int j)
		{
			int num = base.__offset(326);
			return (num == 0) ? 0f : this.bb.GetFloat(base.__vector(num) + j * 4);
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060007AE RID: 1966 RVA: 0x0002AE18 File Offset: 0x00029218
		public int EquipPropFactorsValueLength
		{
			get
			{
				int num = base.__offset(326);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0002AE44 File Offset: 0x00029244
		public float GetEquipPropFactorValues(int j)
		{
			int num = base.__offset(328);
			return (num == 0) ? 0f : this.bb.GetFloat(base.__vector(num) + j * 4);
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0002AE84 File Offset: 0x00029284
		public int EquipPropFactorValuesLength
		{
			get
			{
				int num = base.__offset(328);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0002AEB0 File Offset: 0x000292B0
		public string GetQuipThirdTypeFactorsKey(int j)
		{
			int num = base.__offset(330);
			return (num == 0) ? null : base.__string(base.__vector(num) + j * 4);
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0002AEE8 File Offset: 0x000292E8
		public int QuipThirdTypeFactorsKeyLength
		{
			get
			{
				int num = base.__offset(330);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0002AF14 File Offset: 0x00029314
		public float GetQuipThirdTypeFactorsValue(int j)
		{
			int num = base.__offset(332);
			return (num == 0) ? 0f : this.bb.GetFloat(base.__vector(num) + j * 4);
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0002AF54 File Offset: 0x00029354
		public int QuipThirdTypeFactorsValueLength
		{
			get
			{
				int num = base.__offset(332);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0002AF80 File Offset: 0x00029380
		public float GetQuipThirdTypeFactorValues(int j)
		{
			int num = base.__offset(334);
			return (num == 0) ? 0f : this.bb.GetFloat(base.__vector(num) + j * 4);
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0002AFC0 File Offset: 0x000293C0
		public int QuipThirdTypeFactorValuesLength
		{
			get
			{
				int num = base.__offset(334);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0002AFEC File Offset: 0x000293EC
		public QualityAdjust QualityAdjust
		{
			get
			{
				return this.GetQualityAdjust(new QualityAdjust());
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x0002AFFC File Offset: 0x000293FC
		public QualityAdjust GetQualityAdjust(QualityAdjust obj)
		{
			int num = base.__offset(336);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0002B038 File Offset: 0x00029438
		public float PetDialogLife
		{
			get
			{
				int num = base.__offset(338);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0002B074 File Offset: 0x00029474
		public float PetDialogShowInterval
		{
			get
			{
				int num = base.__offset(340);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0002B0B0 File Offset: 0x000294B0
		public float PetSpecialIdleInterval
		{
			get
			{
				int num = base.__offset(342);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x0002B0EC File Offset: 0x000294EC
		public int NotifyItemTimeLess
		{
			get
			{
				int num = base.__offset(344);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x0002B124 File Offset: 0x00029524
		public static void StartGlobalSetting(FlatBufferBuilder builder)
		{
			builder.StartObject(171);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0002B131 File Offset: 0x00029531
		public static void AddIsTestTeam(FlatBufferBuilder builder, bool isTestTeam)
		{
			builder.AddBool(0, isTestTeam, false);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0002B13C File Offset: 0x0002953C
		public static void AddIsPaySDKDebug(FlatBufferBuilder builder, bool isPaySDKDebug)
		{
			builder.AddBool(1, isPaySDKDebug, false);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0002B147 File Offset: 0x00029547
		public static void AddSdkChannel(FlatBufferBuilder builder, int sdkChannel)
		{
			builder.AddInt(2, sdkChannel, 0);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x0002B152 File Offset: 0x00029552
		public static void AddIsBanShuVersion(FlatBufferBuilder builder, bool isBanShuVersion)
		{
			builder.AddBool(3, isBanShuVersion, false);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0002B15D File Offset: 0x0002955D
		public static void AddIsDebug(FlatBufferBuilder builder, bool isDebug)
		{
			builder.AddBool(4, isDebug, false);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0002B168 File Offset: 0x00029568
		public static void AddIsLogRecord(FlatBufferBuilder builder, bool isLogRecord)
		{
			builder.AddBool(5, isLogRecord, false);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0002B173 File Offset: 0x00029573
		public static void AddIsRecordPVP(FlatBufferBuilder builder, bool isRecordPVP)
		{
			builder.AddBool(6, isRecordPVP, false);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0002B17E File Offset: 0x0002957E
		public static void AddShowDebugBox(FlatBufferBuilder builder, bool showDebugBox)
		{
			builder.AddBool(7, showDebugBox, false);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x0002B189 File Offset: 0x00029589
		public static void AddFrameLock(FlatBufferBuilder builder, int frameLock)
		{
			builder.AddInt(8, frameLock, 0);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x0002B194 File Offset: 0x00029594
		public static void AddFallgroundHitFactor(FlatBufferBuilder builder, float fallgroundHitFactor)
		{
			builder.AddFloat(9, fallgroundHitFactor, 0.0);
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0002B1A8 File Offset: 0x000295A8
		public static void AddHitTime(FlatBufferBuilder builder, float hitTime)
		{
			builder.AddFloat(10, hitTime, 0.0);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0002B1BC File Offset: 0x000295BC
		public static void AddDeadWhiteTime(FlatBufferBuilder builder, float deadWhiteTime)
		{
			builder.AddFloat(11, deadWhiteTime, 0.0);
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0002B1D0 File Offset: 0x000295D0
		public static void AddDefaultHitEffect(FlatBufferBuilder builder, StringOffset defaultHitEffectOffset)
		{
			builder.AddOffset(12, defaultHitEffectOffset.Value, 0);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0002B1E2 File Offset: 0x000295E2
		public static void AddDefaultProjectileHitEffect(FlatBufferBuilder builder, StringOffset defaultProjectileHitEffectOffset)
		{
			builder.AddOffset(13, defaultProjectileHitEffectOffset.Value, 0);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x0002B1F4 File Offset: 0x000295F4
		public static void AddDefualtHitSfx(FlatBufferBuilder builder, StringOffset defualtHitSfxOffset)
		{
			builder.AddOffset(14, defualtHitSfxOffset.Value, 0);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0002B206 File Offset: 0x00029606
		public static void Add_walkSpeed(FlatBufferBuilder builder, Offset<Vector3> WalkSpeedOffset)
		{
			builder.AddStruct(15, WalkSpeedOffset.Value, 0);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x0002B218 File Offset: 0x00029618
		public static void Add_runSpeed(FlatBufferBuilder builder, Offset<Vector3> RunSpeedOffset)
		{
			builder.AddStruct(16, RunSpeedOffset.Value, 0);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x0002B22A File Offset: 0x0002962A
		public static void AddTownWalkSpeed(FlatBufferBuilder builder, Offset<Vector3> townWalkSpeedOffset)
		{
			builder.AddStruct(17, townWalkSpeedOffset.Value, 0);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0002B23C File Offset: 0x0002963C
		public static void AddTownRunSpeed(FlatBufferBuilder builder, Offset<Vector3> townRunSpeedOffset)
		{
			builder.AddStruct(18, townRunSpeedOffset.Value, 0);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0002B24E File Offset: 0x0002964E
		public static void AddTownActionSpeed(FlatBufferBuilder builder, float townActionSpeed)
		{
			builder.AddFloat(19, townActionSpeed, 0.0);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0002B262 File Offset: 0x00029662
		public static void AddTownPlayerRun(FlatBufferBuilder builder, bool townPlayerRun)
		{
			builder.AddBool(20, townPlayerRun, false);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0002B26E File Offset: 0x0002966E
		public static void AddMinHurtTime(FlatBufferBuilder builder, int minHurtTime)
		{
			builder.AddInt(21, minHurtTime, 0);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x0002B27A File Offset: 0x0002967A
		public static void AddMaxHurtTime(FlatBufferBuilder builder, int maxHurtTime)
		{
			builder.AddInt(22, maxHurtTime, 0);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x0002B286 File Offset: 0x00029686
		public static void AddFrozenPercent(FlatBufferBuilder builder, float frozenPercent)
		{
			builder.AddFloat(23, frozenPercent, 0.0);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0002B29A File Offset: 0x0002969A
		public static void AddJumpBackSpeed(FlatBufferBuilder builder, Offset<Vector2> jumpBackSpeedOffset)
		{
			builder.AddStruct(24, jumpBackSpeedOffset.Value, 0);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0002B2AC File Offset: 0x000296AC
		public static void AddJumpForce(FlatBufferBuilder builder, float jumpForce)
		{
			builder.AddFloat(25, jumpForce, 0.0);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0002B2C0 File Offset: 0x000296C0
		public static void AddClickForce(FlatBufferBuilder builder, float clickForce)
		{
			builder.AddFloat(26, clickForce, 0.0);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0002B2D4 File Offset: 0x000296D4
		public static void AddSnapDuration(FlatBufferBuilder builder, float snapDuration)
		{
			builder.AddFloat(27, snapDuration, 0.0);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x0002B2E8 File Offset: 0x000296E8
		public static void Add_dunFuTime(FlatBufferBuilder builder, float DunFuTime)
		{
			builder.AddFloat(28, DunFuTime, 0.0);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0002B2FC File Offset: 0x000296FC
		public static void Add_pvpDunFuTime(FlatBufferBuilder builder, float PvpDunFuTime)
		{
			builder.AddFloat(29, PvpDunFuTime, 0.0);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0002B310 File Offset: 0x00029710
		public static void AddPVPHPScale(FlatBufferBuilder builder, int PVPHPScale)
		{
			builder.AddInt(30, PVPHPScale, 0);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0002B31C File Offset: 0x0002971C
		public static void AddTestLevel(FlatBufferBuilder builder, int TestLevel)
		{
			builder.AddInt(31, TestLevel, 0);
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0002B328 File Offset: 0x00029728
		public static void AddTestPlayerNum(FlatBufferBuilder builder, int testPlayerNum)
		{
			builder.AddInt(32, testPlayerNum, 0);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x0002B334 File Offset: 0x00029734
		public static void AddShowBattleInfoPanel(FlatBufferBuilder builder, bool showBattleInfoPanel)
		{
			builder.AddBool(33, showBattleInfoPanel, false);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x0002B340 File Offset: 0x00029740
		public static void AddDefaultMonsterID(FlatBufferBuilder builder, int defaultMonsterID)
		{
			builder.AddInt(34, defaultMonsterID, 0);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0002B34C File Offset: 0x0002974C
		public static void Add_monsterWalkSpeedFactor(FlatBufferBuilder builder, float MonsterWalkSpeedFactor)
		{
			builder.AddFloat(35, MonsterWalkSpeedFactor, 0.0);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002B360 File Offset: 0x00029760
		public static void Add_monsterSightFactor(FlatBufferBuilder builder, float MonsterSightFactor)
		{
			builder.AddFloat(36, MonsterSightFactor, 0.0);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0002B374 File Offset: 0x00029774
		public static void AddEnableAssetInstPool(FlatBufferBuilder builder, bool enableAssetInstPool)
		{
			builder.AddBool(37, enableAssetInstPool, false);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x0002B380 File Offset: 0x00029780
		public static void AddEnemyHasAI(FlatBufferBuilder builder, bool enemyHasAI)
		{
			builder.AddBool(38, enemyHasAI, false);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0002B38C File Offset: 0x0002978C
		public static void AddIsCreateMonsterLocal(FlatBufferBuilder builder, bool isCreateMonsterLocal)
		{
			builder.AddBool(39, isCreateMonsterLocal, false);
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0002B398 File Offset: 0x00029798
		public static void AddIsGiveEquips(FlatBufferBuilder builder, bool isGiveEquips)
		{
			builder.AddBool(40, isGiveEquips, false);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x0002B3A4 File Offset: 0x000297A4
		public static void AddEquipList(FlatBufferBuilder builder, StringOffset equipListOffset)
		{
			builder.AddOffset(41, equipListOffset.Value, 0);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0002B3B6 File Offset: 0x000297B6
		public static void AddIsGuide(FlatBufferBuilder builder, bool isGuide)
		{
			builder.AddBool(42, isGuide, false);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0002B3C2 File Offset: 0x000297C2
		public static void AddDisplayHUD(FlatBufferBuilder builder, bool displayHUD)
		{
			builder.AddBool(43, displayHUD, false);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0002B3CE File Offset: 0x000297CE
		public static void AddCloseTeamCondition(FlatBufferBuilder builder, bool CloseTeamCondition)
		{
			builder.AddBool(44, CloseTeamCondition, false);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0002B3DA File Offset: 0x000297DA
		public static void AddIsLocalDungeon(FlatBufferBuilder builder, bool isLocalDungeon)
		{
			builder.AddBool(45, isLocalDungeon, false);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0002B3E6 File Offset: 0x000297E6
		public static void AddLocalDungeonID(FlatBufferBuilder builder, int localDungeonID)
		{
			builder.AddInt(46, localDungeonID, 0);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002B3F2 File Offset: 0x000297F2
		public static void AddRecordResFile(FlatBufferBuilder builder, bool recordResFile)
		{
			builder.AddBool(47, recordResFile, false);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002B3FE File Offset: 0x000297FE
		public static void AddProfileAssetLoad(FlatBufferBuilder builder, bool profileAssetLoad)
		{
			builder.AddBool(48, profileAssetLoad, false);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0002B40A File Offset: 0x0002980A
		public static void Add_gravity(FlatBufferBuilder builder, float Gravity)
		{
			builder.AddFloat(49, Gravity, 0.0);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0002B41E File Offset: 0x0002981E
		public static void Add_fallGravityReduceFactor(FlatBufferBuilder builder, float FallGravityReduceFactor)
		{
			builder.AddFloat(50, FallGravityReduceFactor, 0.0);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0002B432 File Offset: 0x00029832
		public static void AddSkillHasCooldown(FlatBufferBuilder builder, bool skillHasCooldown)
		{
			builder.AddBool(51, skillHasCooldown, false);
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0002B43E File Offset: 0x0002983E
		public static void AddScenePath(FlatBufferBuilder builder, StringOffset scenePathOffset)
		{
			builder.AddOffset(52, scenePathOffset.Value, 0);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0002B450 File Offset: 0x00029850
		public static void AddIpSelectedIndex(FlatBufferBuilder builder, int ipSelectedIndex)
		{
			builder.AddInt(53, ipSelectedIndex, 0);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x0002B45C File Offset: 0x0002985C
		public static void AddISingleCharactorID(FlatBufferBuilder builder, int iSingleCharactorID)
		{
			builder.AddInt(54, iSingleCharactorID, 0);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x0002B468 File Offset: 0x00029868
		public static void AddCameraInRange(FlatBufferBuilder builder, Offset<Vector2> cameraInRangeOffset)
		{
			builder.AddStruct(55, cameraInRangeOffset.Value, 0);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x0002B47A File Offset: 0x0002987A
		public static void AddButtonType(FlatBufferBuilder builder, int buttonType)
		{
			builder.AddInt(56, buttonType, 0);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0002B486 File Offset: 0x00029886
		public static void Add_defaultFloatHurt(FlatBufferBuilder builder, float DefaultFloatHurt)
		{
			builder.AddFloat(57, DefaultFloatHurt, 0.0);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0002B49A File Offset: 0x0002989A
		public static void Add_defaultFloatLevelHurat(FlatBufferBuilder builder, float DefaultFloatLevelHurat)
		{
			builder.AddFloat(58, DefaultFloatLevelHurat, 0.0);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0002B4AE File Offset: 0x000298AE
		public static void Add_defaultGroundHurt(FlatBufferBuilder builder, float DefaultGroundHurt)
		{
			builder.AddFloat(59, DefaultGroundHurt, 0.0);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0002B4C2 File Offset: 0x000298C2
		public static void Add_defaultStandHurt(FlatBufferBuilder builder, float DefaultStandHurt)
		{
			builder.AddFloat(60, DefaultStandHurt, 0.0);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0002B4D6 File Offset: 0x000298D6
		public static void Add_fallProtectGravityAddFactor(FlatBufferBuilder builder, float FallProtectGravityAddFactor)
		{
			builder.AddFloat(61, FallProtectGravityAddFactor, 0.0);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0002B4EA File Offset: 0x000298EA
		public static void Add_protectClearDuration(FlatBufferBuilder builder, int ProtectClearDuration)
		{
			builder.AddInt(62, ProtectClearDuration, 0);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002B4F6 File Offset: 0x000298F6
		public static void AddBgmStart(FlatBufferBuilder builder, float bgmStart)
		{
			builder.AddFloat(63, bgmStart, 0.0);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0002B50A File Offset: 0x0002990A
		public static void AddBgmTown(FlatBufferBuilder builder, float bgmTown)
		{
			builder.AddFloat(64, bgmTown, 0.0);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x0002B51E File Offset: 0x0002991E
		public static void AddBgmBattle(FlatBufferBuilder builder, float bgmBattle)
		{
			builder.AddFloat(65, bgmBattle, 0.0);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x0002B532 File Offset: 0x00029932
		public static void Add_zDimFactor(FlatBufferBuilder builder, float ZDimFactor)
		{
			builder.AddFloat(66, ZDimFactor, 0.0);
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0002B546 File Offset: 0x00029946
		public static void AddBullteScale(FlatBufferBuilder builder, float bullteScale)
		{
			builder.AddFloat(67, bullteScale, 0.0);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0002B55A File Offset: 0x0002995A
		public static void AddBullteTime(FlatBufferBuilder builder, int bullteTime)
		{
			builder.AddInt(68, bullteTime, 0);
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x0002B566 File Offset: 0x00029966
		public static void AddStartSystem(FlatBufferBuilder builder, int startSystem)
		{
			builder.AddInt(69, startSystem, 0);
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x0002B572 File Offset: 0x00029972
		public static void AddLoggerFilter(FlatBufferBuilder builder, VectorOffset loggerFilterOffset)
		{
			builder.AddOffset(70, loggerFilterOffset.Value, 0);
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x0002B584 File Offset: 0x00029984
		public static VectorOffset CreateLoggerFilterVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0002B5CA File Offset: 0x000299CA
		public static void StartLoggerFilterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0002B5D5 File Offset: 0x000299D5
		public static void AddShowDialog(FlatBufferBuilder builder, bool showDialog)
		{
			builder.AddBool(71, showDialog, false);
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0002B5E1 File Offset: 0x000299E1
		public static void AddAvatarLightDir(FlatBufferBuilder builder, Offset<Vector3> avatarLightDirOffset)
		{
			builder.AddStruct(72, avatarLightDirOffset.Value, 0);
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0002B5F3 File Offset: 0x000299F3
		public static void AddShadowLightDir(FlatBufferBuilder builder, Offset<Vector3> shadowLightDirOffset)
		{
			builder.AddStruct(73, shadowLightDirOffset.Value, 0);
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0002B605 File Offset: 0x00029A05
		public static void AddStartVel(FlatBufferBuilder builder, Offset<Vector3> startVelOffset)
		{
			builder.AddStruct(74, startVelOffset.Value, 0);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0002B617 File Offset: 0x00029A17
		public static void AddEndVel(FlatBufferBuilder builder, Offset<Vector3> endVelOffset)
		{
			builder.AddStruct(75, endVelOffset.Value, 0);
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0002B629 File Offset: 0x00029A29
		public static void AddOffset(FlatBufferBuilder builder, Offset<Vector3> offsetOffset)
		{
			builder.AddStruct(76, offsetOffset.Value, 0);
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x0002B63B File Offset: 0x00029A3B
		public static void AddTimeAccerlate(FlatBufferBuilder builder, float TimeAccerlate)
		{
			builder.AddFloat(77, TimeAccerlate, 0.0);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0002B64F File Offset: 0x00029A4F
		public static void AddTotalTime(FlatBufferBuilder builder, int TotalTime)
		{
			builder.AddInt(78, TotalTime, 0);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0002B65B File Offset: 0x00029A5B
		public static void AddTotalDist(FlatBufferBuilder builder, int TotalDist)
		{
			builder.AddInt(79, TotalDist, 0);
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x0002B667 File Offset: 0x00029A67
		public static void AddHeightAdoption(FlatBufferBuilder builder, bool heightAdoption)
		{
			builder.AddBool(80, heightAdoption, false);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x0002B673 File Offset: 0x00029A73
		public static void AddDebugDrawBlock(FlatBufferBuilder builder, bool debugDrawBlock)
		{
			builder.AddBool(81, debugDrawBlock, false);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0002B67F File Offset: 0x00029A7F
		public static void AddLoadFromPackage(FlatBufferBuilder builder, bool loadFromPackage)
		{
			builder.AddBool(82, loadFromPackage, false);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0002B68B File Offset: 0x00029A8B
		public static void AddEnableHotFix(FlatBufferBuilder builder, bool enableHotFix)
		{
			builder.AddBool(83, enableHotFix, false);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x0002B697 File Offset: 0x00029A97
		public static void AddHotFixUrlDebug(FlatBufferBuilder builder, bool hotFixUrlDebug)
		{
			builder.AddBool(84, hotFixUrlDebug, false);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0002B6A3 File Offset: 0x00029AA3
		public static void AddREVIVESHOCKSKILLID(FlatBufferBuilder builder, int REVIVESHOCKSKILLID)
		{
			builder.AddInt(85, REVIVESHOCKSKILLID, 0);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0002B6AF File Offset: 0x00029AAF
		public static void AddRollSpeed(FlatBufferBuilder builder, Offset<Vector2> rollSpeedOffset)
		{
			builder.AddStruct(86, rollSpeedOffset.Value, 0);
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x0002B6C1 File Offset: 0x00029AC1
		public static void AddRollRand(FlatBufferBuilder builder, float rollRand)
		{
			builder.AddFloat(87, rollRand, 0.0);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x0002B6D5 File Offset: 0x00029AD5
		public static void AddNormalRollRand(FlatBufferBuilder builder, float normalRollRand)
		{
			builder.AddFloat(88, normalRollRand, 0.0);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x0002B6E9 File Offset: 0x00029AE9
		public static void Add_pkDamageAdjustFactor(FlatBufferBuilder builder, float PkDamageAdjustFactor)
		{
			builder.AddFloat(89, PkDamageAdjustFactor, 0.0);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x0002B6FD File Offset: 0x00029AFD
		public static void Add_pkHPAdjustFactor(FlatBufferBuilder builder, float PkHPAdjustFactor)
		{
			builder.AddFloat(90, PkHPAdjustFactor, 0.0);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x0002B711 File Offset: 0x00029B11
		public static void AddPkUseMaxLevel(FlatBufferBuilder builder, bool pkUseMaxLevel)
		{
			builder.AddBool(91, pkUseMaxLevel, false);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x0002B71D File Offset: 0x00029B1D
		public static void AddBattleRunMode(FlatBufferBuilder builder, int battleRunMode)
		{
			builder.AddInt(92, battleRunMode, 0);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x0002B729 File Offset: 0x00029B29
		public static void AddHasDoubleRun(FlatBufferBuilder builder, bool hasDoubleRun)
		{
			builder.AddBool(93, hasDoubleRun, false);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0002B735 File Offset: 0x00029B35
		public static void AddPlayerHP(FlatBufferBuilder builder, int playerHP)
		{
			builder.AddInt(94, playerHP, 0);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0002B741 File Offset: 0x00029B41
		public static void AddPlayerRebornHP(FlatBufferBuilder builder, int playerRebornHP)
		{
			builder.AddInt(95, playerRebornHP, 0);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0002B74D File Offset: 0x00029B4D
		public static void AddMonsterHP(FlatBufferBuilder builder, int monsterHP)
		{
			builder.AddInt(96, monsterHP, 0);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0002B759 File Offset: 0x00029B59
		public static void AddPlayerPos(FlatBufferBuilder builder, Offset<Vector3> playerPosOffset)
		{
			builder.AddStruct(97, playerPosOffset.Value, 0);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x0002B76B File Offset: 0x00029B6B
		public static void AddTransportDoorRadius(FlatBufferBuilder builder, float transportDoorRadius)
		{
			builder.AddFloat(98, transportDoorRadius, 0.0);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x0002B77F File Offset: 0x00029B7F
		public static void AddPetXMovingDis(FlatBufferBuilder builder, float petXMovingDis)
		{
			builder.AddFloat(99, petXMovingDis, 0.0);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0002B793 File Offset: 0x00029B93
		public static void AddPetXMovingv1(FlatBufferBuilder builder, float petXMovingv1)
		{
			builder.AddFloat(100, petXMovingv1, 0.0);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002B7A7 File Offset: 0x00029BA7
		public static void AddPetXMovingv2(FlatBufferBuilder builder, float petXMovingv2)
		{
			builder.AddFloat(101, petXMovingv2, 0.0);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0002B7BB File Offset: 0x00029BBB
		public static void AddPetYMovingDis(FlatBufferBuilder builder, float petYMovingDis)
		{
			builder.AddFloat(102, petYMovingDis, 0.0);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0002B7CF File Offset: 0x00029BCF
		public static void AddPetYMovingv1(FlatBufferBuilder builder, float petYMovingv1)
		{
			builder.AddFloat(103, petYMovingv1, 0.0);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0002B7E3 File Offset: 0x00029BE3
		public static void AddPetYMovingv2(FlatBufferBuilder builder, float petYMovingv2)
		{
			builder.AddFloat(104, petYMovingv2, 0.0);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0002B7F7 File Offset: 0x00029BF7
		public static void AddServerListUrl(FlatBufferBuilder builder, StringOffset serverListUrlOffset)
		{
			builder.AddOffset(105, serverListUrlOffset.Value, 0);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0002B809 File Offset: 0x00029C09
		public static void AddServerList(FlatBufferBuilder builder, VectorOffset serverListOffset)
		{
			builder.AddOffset(106, serverListOffset.Value, 0);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0002B81C File Offset: 0x00029C1C
		public static VectorOffset CreateServerListVector(FlatBufferBuilder builder, Offset<Address>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0002B862 File Offset: 0x00029C62
		public static void StartServerListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0002B86D File Offset: 0x00029C6D
		public static void AddDebugNewAutofightAI(FlatBufferBuilder builder, bool debugNewAutofightAI)
		{
			builder.AddBool(107, debugNewAutofightAI, false);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0002B879 File Offset: 0x00029C79
		public static void AddCharScale(FlatBufferBuilder builder, float charScale)
		{
			builder.AddFloat(108, charScale, 0.0);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0002B88D File Offset: 0x00029C8D
		public static void AddMonsterBeHitShockData(FlatBufferBuilder builder, Offset<ShockData> monsterBeHitShockDataOffset)
		{
			builder.AddStruct(109, monsterBeHitShockDataOffset.Value, 0);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0002B89F File Offset: 0x00029C9F
		public static void AddPlayerBeHitShockData(FlatBufferBuilder builder, Offset<ShockData> playerBeHitShockDataOffset)
		{
			builder.AddStruct(110, playerBeHitShockDataOffset.Value, 0);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0002B8B1 File Offset: 0x00029CB1
		public static void AddPlayerSkillCDShockData(FlatBufferBuilder builder, Offset<ShockData> playerSkillCDShockDataOffset)
		{
			builder.AddStruct(111, playerSkillCDShockDataOffset.Value, 0);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0002B8C3 File Offset: 0x00029CC3
		public static void AddPlayerHighFallTouchGroundShockData(FlatBufferBuilder builder, Offset<ShockData> playerHighFallTouchGroundShockDataOffset)
		{
			builder.AddStruct(112, playerHighFallTouchGroundShockDataOffset.Value, 0);
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0002B8D5 File Offset: 0x00029CD5
		public static void AddHighFallHight(FlatBufferBuilder builder, float highFallHight)
		{
			builder.AddFloat(113, highFallHight, 0.0);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0002B8E9 File Offset: 0x00029CE9
		public static void AddCritialDeadEffect(FlatBufferBuilder builder, StringOffset critialDeadEffectOffset)
		{
			builder.AddOffset(114, critialDeadEffectOffset.Value, 0);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0002B8FB File Offset: 0x00029CFB
		public static void AddImmediateDeadEffect(FlatBufferBuilder builder, StringOffset immediateDeadEffectOffset)
		{
			builder.AddOffset(115, immediateDeadEffectOffset.Value, 0);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002B90D File Offset: 0x00029D0D
		public static void AddNormalDeadEffect(FlatBufferBuilder builder, StringOffset normalDeadEffectOffset)
		{
			builder.AddOffset(116, normalDeadEffectOffset.Value, 0);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0002B91F File Offset: 0x00029D1F
		public static void AddEnableEffectLimit(FlatBufferBuilder builder, bool enableEffectLimit)
		{
			builder.AddBool(117, enableEffectLimit, false);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0002B92B File Offset: 0x00029D2B
		public static void AddEffectLimitCount(FlatBufferBuilder builder, int effectLimitCount)
		{
			builder.AddInt(118, effectLimitCount, 0);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0002B937 File Offset: 0x00029D37
		public static void AddImmediateDeadHPPercent(FlatBufferBuilder builder, int immediateDeadHPPercent)
		{
			builder.AddInt(119, immediateDeadHPPercent, 0);
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0002B943 File Offset: 0x00029D43
		public static void AddOpenBossShow(FlatBufferBuilder builder, bool openBossShow)
		{
			builder.AddBool(120, openBossShow, false);
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0002B94F File Offset: 0x00029D4F
		public static void AddShooterFitPercent(FlatBufferBuilder builder, float shooterFitPercent)
		{
			builder.AddFloat(121, shooterFitPercent, 0.0);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0002B963 File Offset: 0x00029D63
		public static void AddDisappearDis(FlatBufferBuilder builder, Offset<Vector3> disappearDisOffset)
		{
			builder.AddStruct(122, disappearDisOffset.Value, 0);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0002B975 File Offset: 0x00029D75
		public static void AddKeepDis(FlatBufferBuilder builder, float keepDis)
		{
			builder.AddFloat(123, keepDis, 0.0);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0002B989 File Offset: 0x00029D89
		public static void AddAccompanyRunTime(FlatBufferBuilder builder, float accompanyRunTime)
		{
			builder.AddFloat(124, accompanyRunTime, 0.0);
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0002B99D File Offset: 0x00029D9D
		public static void Add_aiWanderRange(FlatBufferBuilder builder, int AiWanderRange)
		{
			builder.AddInt(125, AiWanderRange, 0);
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0002B9A9 File Offset: 0x00029DA9
		public static void Add_aiWAlkBackRange(FlatBufferBuilder builder, int AiWAlkBackRange)
		{
			builder.AddInt(126, AiWAlkBackRange, 0);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0002B9B5 File Offset: 0x00029DB5
		public static void Add_aiMaxWalkCmdCount(FlatBufferBuilder builder, int AiMaxWalkCmdCount)
		{
			builder.AddInt(127, AiMaxWalkCmdCount, 0);
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0002B9C1 File Offset: 0x00029DC1
		public static void Add_aiMaxWalkCmdCountRANGED(FlatBufferBuilder builder, int AiMaxWalkCmdCountRANGED)
		{
			builder.AddInt(128, AiMaxWalkCmdCountRANGED, 0);
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0002B9D0 File Offset: 0x00029DD0
		public static void Add_aiMaxIdleCmdcount(FlatBufferBuilder builder, int AiMaxIdleCmdcount)
		{
			builder.AddInt(129, AiMaxIdleCmdcount, 0);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0002B9DF File Offset: 0x00029DDF
		public static void Add_aiSkillAttackPassive(FlatBufferBuilder builder, int AiSkillAttackPassive)
		{
			builder.AddInt(130, AiSkillAttackPassive, 0);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0002B9EE File Offset: 0x00029DEE
		public static void Add_monsterGetupBatiFactor(FlatBufferBuilder builder, float MonsterGetupBatiFactor)
		{
			builder.AddFloat(131, MonsterGetupBatiFactor, 0.0);
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0002BA05 File Offset: 0x00029E05
		public static void Add_degangBackDistance(FlatBufferBuilder builder, float DegangBackDistance)
		{
			builder.AddFloat(132, DegangBackDistance, 0.0);
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0002BA1C File Offset: 0x00029E1C
		public static void Add_afThinkTerm(FlatBufferBuilder builder, int AfThinkTerm)
		{
			builder.AddInt(133, AfThinkTerm, 0);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0002BA2B File Offset: 0x00029E2B
		public static void Add_afFindTargetTerm(FlatBufferBuilder builder, int AfFindTargetTerm)
		{
			builder.AddInt(134, AfFindTargetTerm, 0);
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0002BA3A File Offset: 0x00029E3A
		public static void Add_afChangeDestinationTerm(FlatBufferBuilder builder, int AfChangeDestinationTerm)
		{
			builder.AddInt(135, AfChangeDestinationTerm, 0);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0002BA49 File Offset: 0x00029E49
		public static void Add_autoCheckRestoreInterval(FlatBufferBuilder builder, int AutoCheckRestoreInterval)
		{
			builder.AddInt(136, AutoCheckRestoreInterval, 0);
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0002BA58 File Offset: 0x00029E58
		public static void AddForceUseAutoFight(FlatBufferBuilder builder, bool forceUseAutoFight)
		{
			builder.AddBool(137, forceUseAutoFight, false);
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0002BA67 File Offset: 0x00029E67
		public static void AddCanUseAutoFight(FlatBufferBuilder builder, bool canUseAutoFight)
		{
			builder.AddBool(138, canUseAutoFight, false);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0002BA76 File Offset: 0x00029E76
		public static void AddCanUseAutoFightFirstPass(FlatBufferBuilder builder, bool canUseAutoFightFirstPass)
		{
			builder.AddBool(139, canUseAutoFightFirstPass, false);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0002BA85 File Offset: 0x00029E85
		public static void AddLoadAutoFight(FlatBufferBuilder builder, bool loadAutoFight)
		{
			builder.AddBool(140, loadAutoFight, false);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0002BA94 File Offset: 0x00029E94
		public static void AddJumpAttackLimitHeight(FlatBufferBuilder builder, float jumpAttackLimitHeight)
		{
			builder.AddFloat(141, jumpAttackLimitHeight, 0.0);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0002BAAB File Offset: 0x00029EAB
		public static void AddSkillCancelLimitTime(FlatBufferBuilder builder, float skillCancelLimitTime)
		{
			builder.AddFloat(142, skillCancelLimitTime, 0.0);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0002BAC2 File Offset: 0x00029EC2
		public static void AddDoublePressCheckDuration(FlatBufferBuilder builder, int doublePressCheckDuration)
		{
			builder.AddInt(143, doublePressCheckDuration, 0);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0002BAD1 File Offset: 0x00029ED1
		public static void AddWalkAction(FlatBufferBuilder builder, int walkAction)
		{
			builder.AddInt(144, walkAction, 0);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0002BAE0 File Offset: 0x00029EE0
		public static void AddRunAction(FlatBufferBuilder builder, int runAction)
		{
			builder.AddInt(145, runAction, 0);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0002BAEF File Offset: 0x00029EEF
		public static void AddWalkAniFactor(FlatBufferBuilder builder, float walkAniFactor)
		{
			builder.AddFloat(146, walkAniFactor, 0.0);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0002BB06 File Offset: 0x00029F06
		public static void AddRunAniFactor(FlatBufferBuilder builder, float runAniFactor)
		{
			builder.AddFloat(147, runAniFactor, 0.0);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0002BB1D File Offset: 0x00029F1D
		public static void AddChangeFaceStop(FlatBufferBuilder builder, bool changeFaceStop)
		{
			builder.AddBool(148, changeFaceStop, false);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0002BB2C File Offset: 0x00029F2C
		public static void Add_monsterWalkSpeed(FlatBufferBuilder builder, Offset<Vector3> MonsterWalkSpeedOffset)
		{
			builder.AddStruct(149, MonsterWalkSpeedOffset.Value, 0);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0002BB41 File Offset: 0x00029F41
		public static void Add_monsterRunSpeed(FlatBufferBuilder builder, Offset<Vector3> MonsterRunSpeedOffset)
		{
			builder.AddStruct(150, MonsterRunSpeedOffset.Value, 0);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0002BB56 File Offset: 0x00029F56
		public static void AddTableLoadStep(FlatBufferBuilder builder, int tableLoadStep)
		{
			builder.AddInt(151, tableLoadStep, 0);
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0002BB65 File Offset: 0x00029F65
		public static void AddLoadingProgressStepInEditor(FlatBufferBuilder builder, int loadingProgressStepInEditor)
		{
			builder.AddInt(152, loadingProgressStepInEditor, 0);
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0002BB74 File Offset: 0x00029F74
		public static void AddLoadingProgressStep(FlatBufferBuilder builder, int loadingProgressStep)
		{
			builder.AddInt(153, loadingProgressStep, 0);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0002BB83 File Offset: 0x00029F83
		public static void AddPvpDefaultSesstionID(FlatBufferBuilder builder, StringOffset pvpDefaultSesstionIDOffset)
		{
			builder.AddOffset(154, pvpDefaultSesstionIDOffset.Value, 0);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0002BB98 File Offset: 0x00029F98
		public static void AddPetID(FlatBufferBuilder builder, int petID)
		{
			builder.AddInt(155, petID, 0);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0002BBA7 File Offset: 0x00029FA7
		public static void AddPetLevel(FlatBufferBuilder builder, int petLevel)
		{
			builder.AddInt(156, petLevel, 0);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0002BBB6 File Offset: 0x00029FB6
		public static void AddPetHunger(FlatBufferBuilder builder, int petHunger)
		{
			builder.AddInt(157, petHunger, 0);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0002BBC5 File Offset: 0x00029FC5
		public static void AddPetSkillIndex(FlatBufferBuilder builder, int petSkillIndex)
		{
			builder.AddInt(158, petSkillIndex, 0);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0002BBD4 File Offset: 0x00029FD4
		public static void AddTestFashionEquip(FlatBufferBuilder builder, bool testFashionEquip)
		{
			builder.AddBool(159, testFashionEquip, false);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0002BBE3 File Offset: 0x00029FE3
		public static void AddEquipPropFactorsKey(FlatBufferBuilder builder, VectorOffset equipPropFactorsKeyOffset)
		{
			builder.AddOffset(160, equipPropFactorsKeyOffset.Value, 0);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002BBF8 File Offset: 0x00029FF8
		public static VectorOffset CreateEquipPropFactorsKeyVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0002BC3E File Offset: 0x0002A03E
		public static void StartEquipPropFactorsKeyVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0002BC49 File Offset: 0x0002A049
		public static void AddEquipPropFactorsValue(FlatBufferBuilder builder, VectorOffset equipPropFactorsValueOffset)
		{
			builder.AddOffset(161, equipPropFactorsValueOffset.Value, 0);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0002BC60 File Offset: 0x0002A060
		public static VectorOffset CreateEquipPropFactorsValueVector(FlatBufferBuilder builder, float[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddFloat(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0002BC9D File Offset: 0x0002A09D
		public static void StartEquipPropFactorsValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0002BCA8 File Offset: 0x0002A0A8
		public static void AddEquipPropFactorValues(FlatBufferBuilder builder, VectorOffset equipPropFactorValuesOffset)
		{
			builder.AddOffset(162, equipPropFactorValuesOffset.Value, 0);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0002BCC0 File Offset: 0x0002A0C0
		public static VectorOffset CreateEquipPropFactorValuesVector(FlatBufferBuilder builder, float[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddFloat(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0002BCFD File Offset: 0x0002A0FD
		public static void StartEquipPropFactorValuesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0002BD08 File Offset: 0x0002A108
		public static void AddQuipThirdTypeFactorsKey(FlatBufferBuilder builder, VectorOffset quipThirdTypeFactorsKeyOffset)
		{
			builder.AddOffset(163, quipThirdTypeFactorsKeyOffset.Value, 0);
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0002BD20 File Offset: 0x0002A120
		public static VectorOffset CreateQuipThirdTypeFactorsKeyVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0002BD66 File Offset: 0x0002A166
		public static void StartQuipThirdTypeFactorsKeyVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0002BD71 File Offset: 0x0002A171
		public static void AddQuipThirdTypeFactorsValue(FlatBufferBuilder builder, VectorOffset quipThirdTypeFactorsValueOffset)
		{
			builder.AddOffset(164, quipThirdTypeFactorsValueOffset.Value, 0);
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0002BD88 File Offset: 0x0002A188
		public static VectorOffset CreateQuipThirdTypeFactorsValueVector(FlatBufferBuilder builder, float[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddFloat(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0002BDC5 File Offset: 0x0002A1C5
		public static void StartQuipThirdTypeFactorsValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0002BDD0 File Offset: 0x0002A1D0
		public static void AddQuipThirdTypeFactorValues(FlatBufferBuilder builder, VectorOffset quipThirdTypeFactorValuesOffset)
		{
			builder.AddOffset(165, quipThirdTypeFactorValuesOffset.Value, 0);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0002BDE8 File Offset: 0x0002A1E8
		public static VectorOffset CreateQuipThirdTypeFactorValuesVector(FlatBufferBuilder builder, float[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddFloat(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0002BE25 File Offset: 0x0002A225
		public static void StartQuipThirdTypeFactorValuesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0002BE30 File Offset: 0x0002A230
		public static void AddQualityAdjust(FlatBufferBuilder builder, Offset<QualityAdjust> qualityAdjustOffset)
		{
			builder.AddStruct(166, qualityAdjustOffset.Value, 0);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0002BE45 File Offset: 0x0002A245
		public static void AddPetDialogLife(FlatBufferBuilder builder, float petDialogLife)
		{
			builder.AddFloat(167, petDialogLife, 0.0);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0002BE5C File Offset: 0x0002A25C
		public static void AddPetDialogShowInterval(FlatBufferBuilder builder, float petDialogShowInterval)
		{
			builder.AddFloat(168, petDialogShowInterval, 0.0);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0002BE73 File Offset: 0x0002A273
		public static void AddPetSpecialIdleInterval(FlatBufferBuilder builder, float petSpecialIdleInterval)
		{
			builder.AddFloat(169, petSpecialIdleInterval, 0.0);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0002BE8A File Offset: 0x0002A28A
		public static void AddNotifyItemTimeLess(FlatBufferBuilder builder, int notifyItemTimeLess)
		{
			builder.AddInt(170, notifyItemTimeLess, 0);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0002BE9C File Offset: 0x0002A29C
		public static Offset<GlobalSetting> EndGlobalSetting(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GlobalSetting>(value);
		}
	}
}
