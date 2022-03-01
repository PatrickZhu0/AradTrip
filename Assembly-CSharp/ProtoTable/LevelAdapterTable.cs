using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004D5 RID: 1237
	public class LevelAdapterTable : IFlatbufferObject
	{
		// Token: 0x17001028 RID: 4136
		// (get) Token: 0x06003E36 RID: 15926 RVA: 0x000CE034 File Offset: 0x000CC434
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003E37 RID: 15927 RVA: 0x000CE041 File Offset: 0x000CC441
		public static LevelAdapterTable GetRootAsLevelAdapterTable(ByteBuffer _bb)
		{
			return LevelAdapterTable.GetRootAsLevelAdapterTable(_bb, new LevelAdapterTable());
		}

		// Token: 0x06003E38 RID: 15928 RVA: 0x000CE04E File Offset: 0x000CC44E
		public static LevelAdapterTable GetRootAsLevelAdapterTable(ByteBuffer _bb, LevelAdapterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003E39 RID: 15929 RVA: 0x000CE06A File Offset: 0x000CC46A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003E3A RID: 15930 RVA: 0x000CE084 File Offset: 0x000CC484
		public LevelAdapterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001029 RID: 4137
		// (get) Token: 0x06003E3B RID: 15931 RVA: 0x000CE090 File Offset: 0x000CC490
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700102A RID: 4138
		// (get) Token: 0x06003E3C RID: 15932 RVA: 0x000CE0DC File Offset: 0x000CC4DC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003E3D RID: 15933 RVA: 0x000CE11E File Offset: 0x000CC51E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700102B RID: 4139
		// (get) Token: 0x06003E3E RID: 15934 RVA: 0x000CE12C File Offset: 0x000CC52C
		public int Level1
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700102C RID: 4140
		// (get) Token: 0x06003E3F RID: 15935 RVA: 0x000CE178 File Offset: 0x000CC578
		public int Level2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700102D RID: 4141
		// (get) Token: 0x06003E40 RID: 15936 RVA: 0x000CE1C4 File Offset: 0x000CC5C4
		public int Level3
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700102E RID: 4142
		// (get) Token: 0x06003E41 RID: 15937 RVA: 0x000CE210 File Offset: 0x000CC610
		public int Level4
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700102F RID: 4143
		// (get) Token: 0x06003E42 RID: 15938 RVA: 0x000CE25C File Offset: 0x000CC65C
		public int Level5
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001030 RID: 4144
		// (get) Token: 0x06003E43 RID: 15939 RVA: 0x000CE2A8 File Offset: 0x000CC6A8
		public int Level6
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001031 RID: 4145
		// (get) Token: 0x06003E44 RID: 15940 RVA: 0x000CE2F4 File Offset: 0x000CC6F4
		public int Level7
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001032 RID: 4146
		// (get) Token: 0x06003E45 RID: 15941 RVA: 0x000CE340 File Offset: 0x000CC740
		public int Level8
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001033 RID: 4147
		// (get) Token: 0x06003E46 RID: 15942 RVA: 0x000CE38C File Offset: 0x000CC78C
		public int Level9
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001034 RID: 4148
		// (get) Token: 0x06003E47 RID: 15943 RVA: 0x000CE3D8 File Offset: 0x000CC7D8
		public int Level10
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001035 RID: 4149
		// (get) Token: 0x06003E48 RID: 15944 RVA: 0x000CE424 File Offset: 0x000CC824
		public int Level11
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001036 RID: 4150
		// (get) Token: 0x06003E49 RID: 15945 RVA: 0x000CE470 File Offset: 0x000CC870
		public int Level12
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001037 RID: 4151
		// (get) Token: 0x06003E4A RID: 15946 RVA: 0x000CE4BC File Offset: 0x000CC8BC
		public int Level13
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001038 RID: 4152
		// (get) Token: 0x06003E4B RID: 15947 RVA: 0x000CE508 File Offset: 0x000CC908
		public int Level14
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001039 RID: 4153
		// (get) Token: 0x06003E4C RID: 15948 RVA: 0x000CE554 File Offset: 0x000CC954
		public int Level15
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103A RID: 4154
		// (get) Token: 0x06003E4D RID: 15949 RVA: 0x000CE5A0 File Offset: 0x000CC9A0
		public int Level16
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103B RID: 4155
		// (get) Token: 0x06003E4E RID: 15950 RVA: 0x000CE5EC File Offset: 0x000CC9EC
		public int Level17
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103C RID: 4156
		// (get) Token: 0x06003E4F RID: 15951 RVA: 0x000CE638 File Offset: 0x000CCA38
		public int Level18
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103D RID: 4157
		// (get) Token: 0x06003E50 RID: 15952 RVA: 0x000CE684 File Offset: 0x000CCA84
		public int Level19
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103E RID: 4158
		// (get) Token: 0x06003E51 RID: 15953 RVA: 0x000CE6D0 File Offset: 0x000CCAD0
		public int Level20
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700103F RID: 4159
		// (get) Token: 0x06003E52 RID: 15954 RVA: 0x000CE71C File Offset: 0x000CCB1C
		public int Level21
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001040 RID: 4160
		// (get) Token: 0x06003E53 RID: 15955 RVA: 0x000CE768 File Offset: 0x000CCB68
		public int Level22
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001041 RID: 4161
		// (get) Token: 0x06003E54 RID: 15956 RVA: 0x000CE7B4 File Offset: 0x000CCBB4
		public int Level23
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001042 RID: 4162
		// (get) Token: 0x06003E55 RID: 15957 RVA: 0x000CE800 File Offset: 0x000CCC00
		public int Level24
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001043 RID: 4163
		// (get) Token: 0x06003E56 RID: 15958 RVA: 0x000CE84C File Offset: 0x000CCC4C
		public int Level25
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001044 RID: 4164
		// (get) Token: 0x06003E57 RID: 15959 RVA: 0x000CE898 File Offset: 0x000CCC98
		public int Level26
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001045 RID: 4165
		// (get) Token: 0x06003E58 RID: 15960 RVA: 0x000CE8E4 File Offset: 0x000CCCE4
		public int Level27
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001046 RID: 4166
		// (get) Token: 0x06003E59 RID: 15961 RVA: 0x000CE930 File Offset: 0x000CCD30
		public int Level28
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001047 RID: 4167
		// (get) Token: 0x06003E5A RID: 15962 RVA: 0x000CE97C File Offset: 0x000CCD7C
		public int Level29
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001048 RID: 4168
		// (get) Token: 0x06003E5B RID: 15963 RVA: 0x000CE9C8 File Offset: 0x000CCDC8
		public int Level30
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001049 RID: 4169
		// (get) Token: 0x06003E5C RID: 15964 RVA: 0x000CEA14 File Offset: 0x000CCE14
		public int Level31
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104A RID: 4170
		// (get) Token: 0x06003E5D RID: 15965 RVA: 0x000CEA60 File Offset: 0x000CCE60
		public int Level32
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104B RID: 4171
		// (get) Token: 0x06003E5E RID: 15966 RVA: 0x000CEAAC File Offset: 0x000CCEAC
		public int Level33
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104C RID: 4172
		// (get) Token: 0x06003E5F RID: 15967 RVA: 0x000CEAF8 File Offset: 0x000CCEF8
		public int Level34
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104D RID: 4173
		// (get) Token: 0x06003E60 RID: 15968 RVA: 0x000CEB44 File Offset: 0x000CCF44
		public int Level35
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104E RID: 4174
		// (get) Token: 0x06003E61 RID: 15969 RVA: 0x000CEB90 File Offset: 0x000CCF90
		public int Level36
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700104F RID: 4175
		// (get) Token: 0x06003E62 RID: 15970 RVA: 0x000CEBDC File Offset: 0x000CCFDC
		public int Level37
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001050 RID: 4176
		// (get) Token: 0x06003E63 RID: 15971 RVA: 0x000CEC28 File Offset: 0x000CD028
		public int Level38
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001051 RID: 4177
		// (get) Token: 0x06003E64 RID: 15972 RVA: 0x000CEC74 File Offset: 0x000CD074
		public int Level39
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001052 RID: 4178
		// (get) Token: 0x06003E65 RID: 15973 RVA: 0x000CECC0 File Offset: 0x000CD0C0
		public int Level40
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001053 RID: 4179
		// (get) Token: 0x06003E66 RID: 15974 RVA: 0x000CED0C File Offset: 0x000CD10C
		public int Level41
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001054 RID: 4180
		// (get) Token: 0x06003E67 RID: 15975 RVA: 0x000CED58 File Offset: 0x000CD158
		public int Level42
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001055 RID: 4181
		// (get) Token: 0x06003E68 RID: 15976 RVA: 0x000CEDA4 File Offset: 0x000CD1A4
		public int Level43
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001056 RID: 4182
		// (get) Token: 0x06003E69 RID: 15977 RVA: 0x000CEDF0 File Offset: 0x000CD1F0
		public int Level44
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001057 RID: 4183
		// (get) Token: 0x06003E6A RID: 15978 RVA: 0x000CEE3C File Offset: 0x000CD23C
		public int Level45
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001058 RID: 4184
		// (get) Token: 0x06003E6B RID: 15979 RVA: 0x000CEE88 File Offset: 0x000CD288
		public int Level46
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001059 RID: 4185
		// (get) Token: 0x06003E6C RID: 15980 RVA: 0x000CEED4 File Offset: 0x000CD2D4
		public int Level47
		{
			get
			{
				int num = this.__p.__offset(100);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105A RID: 4186
		// (get) Token: 0x06003E6D RID: 15981 RVA: 0x000CEF20 File Offset: 0x000CD320
		public int Level48
		{
			get
			{
				int num = this.__p.__offset(102);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105B RID: 4187
		// (get) Token: 0x06003E6E RID: 15982 RVA: 0x000CEF6C File Offset: 0x000CD36C
		public int Level49
		{
			get
			{
				int num = this.__p.__offset(104);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105C RID: 4188
		// (get) Token: 0x06003E6F RID: 15983 RVA: 0x000CEFB8 File Offset: 0x000CD3B8
		public int Level50
		{
			get
			{
				int num = this.__p.__offset(106);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105D RID: 4189
		// (get) Token: 0x06003E70 RID: 15984 RVA: 0x000CF004 File Offset: 0x000CD404
		public int Level51
		{
			get
			{
				int num = this.__p.__offset(108);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105E RID: 4190
		// (get) Token: 0x06003E71 RID: 15985 RVA: 0x000CF050 File Offset: 0x000CD450
		public int Level52
		{
			get
			{
				int num = this.__p.__offset(110);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700105F RID: 4191
		// (get) Token: 0x06003E72 RID: 15986 RVA: 0x000CF09C File Offset: 0x000CD49C
		public int Level53
		{
			get
			{
				int num = this.__p.__offset(112);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001060 RID: 4192
		// (get) Token: 0x06003E73 RID: 15987 RVA: 0x000CF0E8 File Offset: 0x000CD4E8
		public int Level54
		{
			get
			{
				int num = this.__p.__offset(114);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001061 RID: 4193
		// (get) Token: 0x06003E74 RID: 15988 RVA: 0x000CF134 File Offset: 0x000CD534
		public int Level55
		{
			get
			{
				int num = this.__p.__offset(116);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001062 RID: 4194
		// (get) Token: 0x06003E75 RID: 15989 RVA: 0x000CF180 File Offset: 0x000CD580
		public int Level56
		{
			get
			{
				int num = this.__p.__offset(118);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001063 RID: 4195
		// (get) Token: 0x06003E76 RID: 15990 RVA: 0x000CF1CC File Offset: 0x000CD5CC
		public int Level57
		{
			get
			{
				int num = this.__p.__offset(120);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001064 RID: 4196
		// (get) Token: 0x06003E77 RID: 15991 RVA: 0x000CF218 File Offset: 0x000CD618
		public int Level58
		{
			get
			{
				int num = this.__p.__offset(122);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001065 RID: 4197
		// (get) Token: 0x06003E78 RID: 15992 RVA: 0x000CF264 File Offset: 0x000CD664
		public int Level59
		{
			get
			{
				int num = this.__p.__offset(124);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001066 RID: 4198
		// (get) Token: 0x06003E79 RID: 15993 RVA: 0x000CF2B0 File Offset: 0x000CD6B0
		public int Level60
		{
			get
			{
				int num = this.__p.__offset(126);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001067 RID: 4199
		// (get) Token: 0x06003E7A RID: 15994 RVA: 0x000CF2FC File Offset: 0x000CD6FC
		public int Level61
		{
			get
			{
				int num = this.__p.__offset(128);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001068 RID: 4200
		// (get) Token: 0x06003E7B RID: 15995 RVA: 0x000CF34C File Offset: 0x000CD74C
		public int Level62
		{
			get
			{
				int num = this.__p.__offset(130);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001069 RID: 4201
		// (get) Token: 0x06003E7C RID: 15996 RVA: 0x000CF39C File Offset: 0x000CD79C
		public int Level63
		{
			get
			{
				int num = this.__p.__offset(132);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700106A RID: 4202
		// (get) Token: 0x06003E7D RID: 15997 RVA: 0x000CF3EC File Offset: 0x000CD7EC
		public int Level64
		{
			get
			{
				int num = this.__p.__offset(134);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700106B RID: 4203
		// (get) Token: 0x06003E7E RID: 15998 RVA: 0x000CF43C File Offset: 0x000CD83C
		public int Level65
		{
			get
			{
				int num = this.__p.__offset(136);
				return (num == 0) ? 0 : (-815458749 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003E7F RID: 15999 RVA: 0x000CF48C File Offset: 0x000CD88C
		public static Offset<LevelAdapterTable> CreateLevelAdapterTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Level1 = 0, int Level2 = 0, int Level3 = 0, int Level4 = 0, int Level5 = 0, int Level6 = 0, int Level7 = 0, int Level8 = 0, int Level9 = 0, int Level10 = 0, int Level11 = 0, int Level12 = 0, int Level13 = 0, int Level14 = 0, int Level15 = 0, int Level16 = 0, int Level17 = 0, int Level18 = 0, int Level19 = 0, int Level20 = 0, int Level21 = 0, int Level22 = 0, int Level23 = 0, int Level24 = 0, int Level25 = 0, int Level26 = 0, int Level27 = 0, int Level28 = 0, int Level29 = 0, int Level30 = 0, int Level31 = 0, int Level32 = 0, int Level33 = 0, int Level34 = 0, int Level35 = 0, int Level36 = 0, int Level37 = 0, int Level38 = 0, int Level39 = 0, int Level40 = 0, int Level41 = 0, int Level42 = 0, int Level43 = 0, int Level44 = 0, int Level45 = 0, int Level46 = 0, int Level47 = 0, int Level48 = 0, int Level49 = 0, int Level50 = 0, int Level51 = 0, int Level52 = 0, int Level53 = 0, int Level54 = 0, int Level55 = 0, int Level56 = 0, int Level57 = 0, int Level58 = 0, int Level59 = 0, int Level60 = 0, int Level61 = 0, int Level62 = 0, int Level63 = 0, int Level64 = 0, int Level65 = 0)
		{
			builder.StartObject(67);
			LevelAdapterTable.AddLevel65(builder, Level65);
			LevelAdapterTable.AddLevel64(builder, Level64);
			LevelAdapterTable.AddLevel63(builder, Level63);
			LevelAdapterTable.AddLevel62(builder, Level62);
			LevelAdapterTable.AddLevel61(builder, Level61);
			LevelAdapterTable.AddLevel60(builder, Level60);
			LevelAdapterTable.AddLevel59(builder, Level59);
			LevelAdapterTable.AddLevel58(builder, Level58);
			LevelAdapterTable.AddLevel57(builder, Level57);
			LevelAdapterTable.AddLevel56(builder, Level56);
			LevelAdapterTable.AddLevel55(builder, Level55);
			LevelAdapterTable.AddLevel54(builder, Level54);
			LevelAdapterTable.AddLevel53(builder, Level53);
			LevelAdapterTable.AddLevel52(builder, Level52);
			LevelAdapterTable.AddLevel51(builder, Level51);
			LevelAdapterTable.AddLevel50(builder, Level50);
			LevelAdapterTable.AddLevel49(builder, Level49);
			LevelAdapterTable.AddLevel48(builder, Level48);
			LevelAdapterTable.AddLevel47(builder, Level47);
			LevelAdapterTable.AddLevel46(builder, Level46);
			LevelAdapterTable.AddLevel45(builder, Level45);
			LevelAdapterTable.AddLevel44(builder, Level44);
			LevelAdapterTable.AddLevel43(builder, Level43);
			LevelAdapterTable.AddLevel42(builder, Level42);
			LevelAdapterTable.AddLevel41(builder, Level41);
			LevelAdapterTable.AddLevel40(builder, Level40);
			LevelAdapterTable.AddLevel39(builder, Level39);
			LevelAdapterTable.AddLevel38(builder, Level38);
			LevelAdapterTable.AddLevel37(builder, Level37);
			LevelAdapterTable.AddLevel36(builder, Level36);
			LevelAdapterTable.AddLevel35(builder, Level35);
			LevelAdapterTable.AddLevel34(builder, Level34);
			LevelAdapterTable.AddLevel33(builder, Level33);
			LevelAdapterTable.AddLevel32(builder, Level32);
			LevelAdapterTable.AddLevel31(builder, Level31);
			LevelAdapterTable.AddLevel30(builder, Level30);
			LevelAdapterTable.AddLevel29(builder, Level29);
			LevelAdapterTable.AddLevel28(builder, Level28);
			LevelAdapterTable.AddLevel27(builder, Level27);
			LevelAdapterTable.AddLevel26(builder, Level26);
			LevelAdapterTable.AddLevel25(builder, Level25);
			LevelAdapterTable.AddLevel24(builder, Level24);
			LevelAdapterTable.AddLevel23(builder, Level23);
			LevelAdapterTable.AddLevel22(builder, Level22);
			LevelAdapterTable.AddLevel21(builder, Level21);
			LevelAdapterTable.AddLevel20(builder, Level20);
			LevelAdapterTable.AddLevel19(builder, Level19);
			LevelAdapterTable.AddLevel18(builder, Level18);
			LevelAdapterTable.AddLevel17(builder, Level17);
			LevelAdapterTable.AddLevel16(builder, Level16);
			LevelAdapterTable.AddLevel15(builder, Level15);
			LevelAdapterTable.AddLevel14(builder, Level14);
			LevelAdapterTable.AddLevel13(builder, Level13);
			LevelAdapterTable.AddLevel12(builder, Level12);
			LevelAdapterTable.AddLevel11(builder, Level11);
			LevelAdapterTable.AddLevel10(builder, Level10);
			LevelAdapterTable.AddLevel9(builder, Level9);
			LevelAdapterTable.AddLevel8(builder, Level8);
			LevelAdapterTable.AddLevel7(builder, Level7);
			LevelAdapterTable.AddLevel6(builder, Level6);
			LevelAdapterTable.AddLevel5(builder, Level5);
			LevelAdapterTable.AddLevel4(builder, Level4);
			LevelAdapterTable.AddLevel3(builder, Level3);
			LevelAdapterTable.AddLevel2(builder, Level2);
			LevelAdapterTable.AddLevel1(builder, Level1);
			LevelAdapterTable.AddName(builder, NameOffset);
			LevelAdapterTable.AddID(builder, ID);
			return LevelAdapterTable.EndLevelAdapterTable(builder);
		}

		// Token: 0x06003E80 RID: 16000 RVA: 0x000CF6BC File Offset: 0x000CDABC
		public static void StartLevelAdapterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(67);
		}

		// Token: 0x06003E81 RID: 16001 RVA: 0x000CF6C6 File Offset: 0x000CDAC6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003E82 RID: 16002 RVA: 0x000CF6D1 File Offset: 0x000CDAD1
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003E83 RID: 16003 RVA: 0x000CF6E2 File Offset: 0x000CDAE2
		public static void AddLevel1(FlatBufferBuilder builder, int Level1)
		{
			builder.AddInt(2, Level1, 0);
		}

		// Token: 0x06003E84 RID: 16004 RVA: 0x000CF6ED File Offset: 0x000CDAED
		public static void AddLevel2(FlatBufferBuilder builder, int Level2)
		{
			builder.AddInt(3, Level2, 0);
		}

		// Token: 0x06003E85 RID: 16005 RVA: 0x000CF6F8 File Offset: 0x000CDAF8
		public static void AddLevel3(FlatBufferBuilder builder, int Level3)
		{
			builder.AddInt(4, Level3, 0);
		}

		// Token: 0x06003E86 RID: 16006 RVA: 0x000CF703 File Offset: 0x000CDB03
		public static void AddLevel4(FlatBufferBuilder builder, int Level4)
		{
			builder.AddInt(5, Level4, 0);
		}

		// Token: 0x06003E87 RID: 16007 RVA: 0x000CF70E File Offset: 0x000CDB0E
		public static void AddLevel5(FlatBufferBuilder builder, int Level5)
		{
			builder.AddInt(6, Level5, 0);
		}

		// Token: 0x06003E88 RID: 16008 RVA: 0x000CF719 File Offset: 0x000CDB19
		public static void AddLevel6(FlatBufferBuilder builder, int Level6)
		{
			builder.AddInt(7, Level6, 0);
		}

		// Token: 0x06003E89 RID: 16009 RVA: 0x000CF724 File Offset: 0x000CDB24
		public static void AddLevel7(FlatBufferBuilder builder, int Level7)
		{
			builder.AddInt(8, Level7, 0);
		}

		// Token: 0x06003E8A RID: 16010 RVA: 0x000CF72F File Offset: 0x000CDB2F
		public static void AddLevel8(FlatBufferBuilder builder, int Level8)
		{
			builder.AddInt(9, Level8, 0);
		}

		// Token: 0x06003E8B RID: 16011 RVA: 0x000CF73B File Offset: 0x000CDB3B
		public static void AddLevel9(FlatBufferBuilder builder, int Level9)
		{
			builder.AddInt(10, Level9, 0);
		}

		// Token: 0x06003E8C RID: 16012 RVA: 0x000CF747 File Offset: 0x000CDB47
		public static void AddLevel10(FlatBufferBuilder builder, int Level10)
		{
			builder.AddInt(11, Level10, 0);
		}

		// Token: 0x06003E8D RID: 16013 RVA: 0x000CF753 File Offset: 0x000CDB53
		public static void AddLevel11(FlatBufferBuilder builder, int Level11)
		{
			builder.AddInt(12, Level11, 0);
		}

		// Token: 0x06003E8E RID: 16014 RVA: 0x000CF75F File Offset: 0x000CDB5F
		public static void AddLevel12(FlatBufferBuilder builder, int Level12)
		{
			builder.AddInt(13, Level12, 0);
		}

		// Token: 0x06003E8F RID: 16015 RVA: 0x000CF76B File Offset: 0x000CDB6B
		public static void AddLevel13(FlatBufferBuilder builder, int Level13)
		{
			builder.AddInt(14, Level13, 0);
		}

		// Token: 0x06003E90 RID: 16016 RVA: 0x000CF777 File Offset: 0x000CDB77
		public static void AddLevel14(FlatBufferBuilder builder, int Level14)
		{
			builder.AddInt(15, Level14, 0);
		}

		// Token: 0x06003E91 RID: 16017 RVA: 0x000CF783 File Offset: 0x000CDB83
		public static void AddLevel15(FlatBufferBuilder builder, int Level15)
		{
			builder.AddInt(16, Level15, 0);
		}

		// Token: 0x06003E92 RID: 16018 RVA: 0x000CF78F File Offset: 0x000CDB8F
		public static void AddLevel16(FlatBufferBuilder builder, int Level16)
		{
			builder.AddInt(17, Level16, 0);
		}

		// Token: 0x06003E93 RID: 16019 RVA: 0x000CF79B File Offset: 0x000CDB9B
		public static void AddLevel17(FlatBufferBuilder builder, int Level17)
		{
			builder.AddInt(18, Level17, 0);
		}

		// Token: 0x06003E94 RID: 16020 RVA: 0x000CF7A7 File Offset: 0x000CDBA7
		public static void AddLevel18(FlatBufferBuilder builder, int Level18)
		{
			builder.AddInt(19, Level18, 0);
		}

		// Token: 0x06003E95 RID: 16021 RVA: 0x000CF7B3 File Offset: 0x000CDBB3
		public static void AddLevel19(FlatBufferBuilder builder, int Level19)
		{
			builder.AddInt(20, Level19, 0);
		}

		// Token: 0x06003E96 RID: 16022 RVA: 0x000CF7BF File Offset: 0x000CDBBF
		public static void AddLevel20(FlatBufferBuilder builder, int Level20)
		{
			builder.AddInt(21, Level20, 0);
		}

		// Token: 0x06003E97 RID: 16023 RVA: 0x000CF7CB File Offset: 0x000CDBCB
		public static void AddLevel21(FlatBufferBuilder builder, int Level21)
		{
			builder.AddInt(22, Level21, 0);
		}

		// Token: 0x06003E98 RID: 16024 RVA: 0x000CF7D7 File Offset: 0x000CDBD7
		public static void AddLevel22(FlatBufferBuilder builder, int Level22)
		{
			builder.AddInt(23, Level22, 0);
		}

		// Token: 0x06003E99 RID: 16025 RVA: 0x000CF7E3 File Offset: 0x000CDBE3
		public static void AddLevel23(FlatBufferBuilder builder, int Level23)
		{
			builder.AddInt(24, Level23, 0);
		}

		// Token: 0x06003E9A RID: 16026 RVA: 0x000CF7EF File Offset: 0x000CDBEF
		public static void AddLevel24(FlatBufferBuilder builder, int Level24)
		{
			builder.AddInt(25, Level24, 0);
		}

		// Token: 0x06003E9B RID: 16027 RVA: 0x000CF7FB File Offset: 0x000CDBFB
		public static void AddLevel25(FlatBufferBuilder builder, int Level25)
		{
			builder.AddInt(26, Level25, 0);
		}

		// Token: 0x06003E9C RID: 16028 RVA: 0x000CF807 File Offset: 0x000CDC07
		public static void AddLevel26(FlatBufferBuilder builder, int Level26)
		{
			builder.AddInt(27, Level26, 0);
		}

		// Token: 0x06003E9D RID: 16029 RVA: 0x000CF813 File Offset: 0x000CDC13
		public static void AddLevel27(FlatBufferBuilder builder, int Level27)
		{
			builder.AddInt(28, Level27, 0);
		}

		// Token: 0x06003E9E RID: 16030 RVA: 0x000CF81F File Offset: 0x000CDC1F
		public static void AddLevel28(FlatBufferBuilder builder, int Level28)
		{
			builder.AddInt(29, Level28, 0);
		}

		// Token: 0x06003E9F RID: 16031 RVA: 0x000CF82B File Offset: 0x000CDC2B
		public static void AddLevel29(FlatBufferBuilder builder, int Level29)
		{
			builder.AddInt(30, Level29, 0);
		}

		// Token: 0x06003EA0 RID: 16032 RVA: 0x000CF837 File Offset: 0x000CDC37
		public static void AddLevel30(FlatBufferBuilder builder, int Level30)
		{
			builder.AddInt(31, Level30, 0);
		}

		// Token: 0x06003EA1 RID: 16033 RVA: 0x000CF843 File Offset: 0x000CDC43
		public static void AddLevel31(FlatBufferBuilder builder, int Level31)
		{
			builder.AddInt(32, Level31, 0);
		}

		// Token: 0x06003EA2 RID: 16034 RVA: 0x000CF84F File Offset: 0x000CDC4F
		public static void AddLevel32(FlatBufferBuilder builder, int Level32)
		{
			builder.AddInt(33, Level32, 0);
		}

		// Token: 0x06003EA3 RID: 16035 RVA: 0x000CF85B File Offset: 0x000CDC5B
		public static void AddLevel33(FlatBufferBuilder builder, int Level33)
		{
			builder.AddInt(34, Level33, 0);
		}

		// Token: 0x06003EA4 RID: 16036 RVA: 0x000CF867 File Offset: 0x000CDC67
		public static void AddLevel34(FlatBufferBuilder builder, int Level34)
		{
			builder.AddInt(35, Level34, 0);
		}

		// Token: 0x06003EA5 RID: 16037 RVA: 0x000CF873 File Offset: 0x000CDC73
		public static void AddLevel35(FlatBufferBuilder builder, int Level35)
		{
			builder.AddInt(36, Level35, 0);
		}

		// Token: 0x06003EA6 RID: 16038 RVA: 0x000CF87F File Offset: 0x000CDC7F
		public static void AddLevel36(FlatBufferBuilder builder, int Level36)
		{
			builder.AddInt(37, Level36, 0);
		}

		// Token: 0x06003EA7 RID: 16039 RVA: 0x000CF88B File Offset: 0x000CDC8B
		public static void AddLevel37(FlatBufferBuilder builder, int Level37)
		{
			builder.AddInt(38, Level37, 0);
		}

		// Token: 0x06003EA8 RID: 16040 RVA: 0x000CF897 File Offset: 0x000CDC97
		public static void AddLevel38(FlatBufferBuilder builder, int Level38)
		{
			builder.AddInt(39, Level38, 0);
		}

		// Token: 0x06003EA9 RID: 16041 RVA: 0x000CF8A3 File Offset: 0x000CDCA3
		public static void AddLevel39(FlatBufferBuilder builder, int Level39)
		{
			builder.AddInt(40, Level39, 0);
		}

		// Token: 0x06003EAA RID: 16042 RVA: 0x000CF8AF File Offset: 0x000CDCAF
		public static void AddLevel40(FlatBufferBuilder builder, int Level40)
		{
			builder.AddInt(41, Level40, 0);
		}

		// Token: 0x06003EAB RID: 16043 RVA: 0x000CF8BB File Offset: 0x000CDCBB
		public static void AddLevel41(FlatBufferBuilder builder, int Level41)
		{
			builder.AddInt(42, Level41, 0);
		}

		// Token: 0x06003EAC RID: 16044 RVA: 0x000CF8C7 File Offset: 0x000CDCC7
		public static void AddLevel42(FlatBufferBuilder builder, int Level42)
		{
			builder.AddInt(43, Level42, 0);
		}

		// Token: 0x06003EAD RID: 16045 RVA: 0x000CF8D3 File Offset: 0x000CDCD3
		public static void AddLevel43(FlatBufferBuilder builder, int Level43)
		{
			builder.AddInt(44, Level43, 0);
		}

		// Token: 0x06003EAE RID: 16046 RVA: 0x000CF8DF File Offset: 0x000CDCDF
		public static void AddLevel44(FlatBufferBuilder builder, int Level44)
		{
			builder.AddInt(45, Level44, 0);
		}

		// Token: 0x06003EAF RID: 16047 RVA: 0x000CF8EB File Offset: 0x000CDCEB
		public static void AddLevel45(FlatBufferBuilder builder, int Level45)
		{
			builder.AddInt(46, Level45, 0);
		}

		// Token: 0x06003EB0 RID: 16048 RVA: 0x000CF8F7 File Offset: 0x000CDCF7
		public static void AddLevel46(FlatBufferBuilder builder, int Level46)
		{
			builder.AddInt(47, Level46, 0);
		}

		// Token: 0x06003EB1 RID: 16049 RVA: 0x000CF903 File Offset: 0x000CDD03
		public static void AddLevel47(FlatBufferBuilder builder, int Level47)
		{
			builder.AddInt(48, Level47, 0);
		}

		// Token: 0x06003EB2 RID: 16050 RVA: 0x000CF90F File Offset: 0x000CDD0F
		public static void AddLevel48(FlatBufferBuilder builder, int Level48)
		{
			builder.AddInt(49, Level48, 0);
		}

		// Token: 0x06003EB3 RID: 16051 RVA: 0x000CF91B File Offset: 0x000CDD1B
		public static void AddLevel49(FlatBufferBuilder builder, int Level49)
		{
			builder.AddInt(50, Level49, 0);
		}

		// Token: 0x06003EB4 RID: 16052 RVA: 0x000CF927 File Offset: 0x000CDD27
		public static void AddLevel50(FlatBufferBuilder builder, int Level50)
		{
			builder.AddInt(51, Level50, 0);
		}

		// Token: 0x06003EB5 RID: 16053 RVA: 0x000CF933 File Offset: 0x000CDD33
		public static void AddLevel51(FlatBufferBuilder builder, int Level51)
		{
			builder.AddInt(52, Level51, 0);
		}

		// Token: 0x06003EB6 RID: 16054 RVA: 0x000CF93F File Offset: 0x000CDD3F
		public static void AddLevel52(FlatBufferBuilder builder, int Level52)
		{
			builder.AddInt(53, Level52, 0);
		}

		// Token: 0x06003EB7 RID: 16055 RVA: 0x000CF94B File Offset: 0x000CDD4B
		public static void AddLevel53(FlatBufferBuilder builder, int Level53)
		{
			builder.AddInt(54, Level53, 0);
		}

		// Token: 0x06003EB8 RID: 16056 RVA: 0x000CF957 File Offset: 0x000CDD57
		public static void AddLevel54(FlatBufferBuilder builder, int Level54)
		{
			builder.AddInt(55, Level54, 0);
		}

		// Token: 0x06003EB9 RID: 16057 RVA: 0x000CF963 File Offset: 0x000CDD63
		public static void AddLevel55(FlatBufferBuilder builder, int Level55)
		{
			builder.AddInt(56, Level55, 0);
		}

		// Token: 0x06003EBA RID: 16058 RVA: 0x000CF96F File Offset: 0x000CDD6F
		public static void AddLevel56(FlatBufferBuilder builder, int Level56)
		{
			builder.AddInt(57, Level56, 0);
		}

		// Token: 0x06003EBB RID: 16059 RVA: 0x000CF97B File Offset: 0x000CDD7B
		public static void AddLevel57(FlatBufferBuilder builder, int Level57)
		{
			builder.AddInt(58, Level57, 0);
		}

		// Token: 0x06003EBC RID: 16060 RVA: 0x000CF987 File Offset: 0x000CDD87
		public static void AddLevel58(FlatBufferBuilder builder, int Level58)
		{
			builder.AddInt(59, Level58, 0);
		}

		// Token: 0x06003EBD RID: 16061 RVA: 0x000CF993 File Offset: 0x000CDD93
		public static void AddLevel59(FlatBufferBuilder builder, int Level59)
		{
			builder.AddInt(60, Level59, 0);
		}

		// Token: 0x06003EBE RID: 16062 RVA: 0x000CF99F File Offset: 0x000CDD9F
		public static void AddLevel60(FlatBufferBuilder builder, int Level60)
		{
			builder.AddInt(61, Level60, 0);
		}

		// Token: 0x06003EBF RID: 16063 RVA: 0x000CF9AB File Offset: 0x000CDDAB
		public static void AddLevel61(FlatBufferBuilder builder, int Level61)
		{
			builder.AddInt(62, Level61, 0);
		}

		// Token: 0x06003EC0 RID: 16064 RVA: 0x000CF9B7 File Offset: 0x000CDDB7
		public static void AddLevel62(FlatBufferBuilder builder, int Level62)
		{
			builder.AddInt(63, Level62, 0);
		}

		// Token: 0x06003EC1 RID: 16065 RVA: 0x000CF9C3 File Offset: 0x000CDDC3
		public static void AddLevel63(FlatBufferBuilder builder, int Level63)
		{
			builder.AddInt(64, Level63, 0);
		}

		// Token: 0x06003EC2 RID: 16066 RVA: 0x000CF9CF File Offset: 0x000CDDCF
		public static void AddLevel64(FlatBufferBuilder builder, int Level64)
		{
			builder.AddInt(65, Level64, 0);
		}

		// Token: 0x06003EC3 RID: 16067 RVA: 0x000CF9DB File Offset: 0x000CDDDB
		public static void AddLevel65(FlatBufferBuilder builder, int Level65)
		{
			builder.AddInt(66, Level65, 0);
		}

		// Token: 0x06003EC4 RID: 16068 RVA: 0x000CF9E8 File Offset: 0x000CDDE8
		public static Offset<LevelAdapterTable> EndLevelAdapterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LevelAdapterTable>(value);
		}

		// Token: 0x06003EC5 RID: 16069 RVA: 0x000CFA02 File Offset: 0x000CDE02
		public static void FinishLevelAdapterTableBuffer(FlatBufferBuilder builder, Offset<LevelAdapterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017E6 RID: 6118
		private Table __p = new Table();

		// Token: 0x020004D6 RID: 1238
		public enum eCrypt
		{
			// Token: 0x040017E8 RID: 6120
			code = -815458749
		}
	}
}
