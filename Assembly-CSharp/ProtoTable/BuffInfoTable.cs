using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002ED RID: 749
	public class BuffInfoTable : IFlatbufferObject
	{
		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06001B8B RID: 7051 RVA: 0x0007A41C File Offset: 0x0007881C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B8C RID: 7052 RVA: 0x0007A429 File Offset: 0x00078829
		public static BuffInfoTable GetRootAsBuffInfoTable(ByteBuffer _bb)
		{
			return BuffInfoTable.GetRootAsBuffInfoTable(_bb, new BuffInfoTable());
		}

		// Token: 0x06001B8D RID: 7053 RVA: 0x0007A436 File Offset: 0x00078836
		public static BuffInfoTable GetRootAsBuffInfoTable(ByteBuffer _bb, BuffInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x0007A452 File Offset: 0x00078852
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x0007A46C File Offset: 0x0007886C
		public BuffInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06001B90 RID: 7056 RVA: 0x0007A478 File Offset: 0x00078878
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x0007A4C4 File Offset: 0x000788C4
		public string NameArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06001B92 RID: 7058 RVA: 0x0007A50C File Offset: 0x0007890C
		public int NameLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06001B93 RID: 7059 RVA: 0x0007A53E File Offset: 0x0007893E
		public FlatBufferArray<string> Name
		{
			get
			{
				if (this.NameValue == null)
				{
					this.NameValue = new FlatBufferArray<string>(new Func<int, string>(this.NameArray), this.NameLength);
				}
				return this.NameValue;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06001B94 RID: 7060 RVA: 0x0007A570 File Offset: 0x00078970
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x0007A5B2 File Offset: 0x000789B2
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x0007A5C0 File Offset: 0x000789C0
		public string DescriptionArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06001B97 RID: 7063 RVA: 0x0007A608 File Offset: 0x00078A08
		public int DescriptionLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06001B98 RID: 7064 RVA: 0x0007A63B File Offset: 0x00078A3B
		public FlatBufferArray<string> Description
		{
			get
			{
				if (this.DescriptionValue == null)
				{
					this.DescriptionValue = new FlatBufferArray<string>(new Func<int, string>(this.DescriptionArray), this.DescriptionLength);
				}
				return this.DescriptionValue;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06001B99 RID: 7065 RVA: 0x0007A66C File Offset: 0x00078A6C
		public BuffInfoTable.eDescType DescType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (BuffInfoTable.eDescType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x0007A6B0 File Offset: 0x00078AB0
		public string DetailDescriptionArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06001B9B RID: 7067 RVA: 0x0007A6F8 File Offset: 0x00078AF8
		public int DetailDescriptionLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06001B9C RID: 7068 RVA: 0x0007A72B File Offset: 0x00078B2B
		public FlatBufferArray<string> DetailDescription
		{
			get
			{
				if (this.DetailDescriptionValue == null)
				{
					this.DetailDescriptionValue = new FlatBufferArray<string>(new Func<int, string>(this.DetailDescriptionArray), this.DetailDescriptionLength);
				}
				return this.DetailDescriptionValue;
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06001B9D RID: 7069 RVA: 0x0007A75C File Offset: 0x00078B5C
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06001B9E RID: 7070 RVA: 0x0007A7A8 File Offset: 0x00078BA8
		public BuffInfoTable.eBufferType BufferType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (BuffInfoTable.eBufferType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06001B9F RID: 7071 RVA: 0x0007A7EC File Offset: 0x00078BEC
		public int NeedHint
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06001BA0 RID: 7072 RVA: 0x0007A838 File Offset: 0x00078C38
		public int BuffID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001BA1 RID: 7073 RVA: 0x0007A884 File Offset: 0x00078C84
		public UnionCell MonsterTypeMapArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06001BA2 RID: 7074 RVA: 0x0007A8E0 File Offset: 0x00078CE0
		public int MonsterTypeMapLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06001BA3 RID: 7075 RVA: 0x0007A913 File Offset: 0x00078D13
		public FlatBufferArray<UnionCell> MonsterTypeMap
		{
			get
			{
				if (this.MonsterTypeMapValue == null)
				{
					this.MonsterTypeMapValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.MonsterTypeMapArray), this.MonsterTypeMapLength);
				}
				return this.MonsterTypeMapValue;
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06001BA4 RID: 7076 RVA: 0x0007A944 File Offset: 0x00078D44
		public UnionCell BuffLevel
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06001BA5 RID: 7077 RVA: 0x0007A99C File Offset: 0x00078D9C
		public int BuffTarget
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001BA6 RID: 7078 RVA: 0x0007A9E8 File Offset: 0x00078DE8
		public int BuffTargetRadius
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001BA7 RID: 7079 RVA: 0x0007AA34 File Offset: 0x00078E34
		public int SkillIDArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06001BA8 RID: 7080 RVA: 0x0007AA84 File Offset: 0x00078E84
		public int SkillIDLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001BA9 RID: 7081 RVA: 0x0007AAB7 File Offset: 0x00078EB7
		public ArraySegment<byte>? GetSkillIDBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06001BAA RID: 7082 RVA: 0x0007AAC6 File Offset: 0x00078EC6
		public FlatBufferArray<int> SkillID
		{
			get
			{
				if (this.SkillIDValue == null)
				{
					this.SkillIDValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillIDArray), this.SkillIDLength);
				}
				return this.SkillIDValue;
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06001BAB RID: 7083 RVA: 0x0007AAF8 File Offset: 0x00078EF8
		public int monsterModeType
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06001BAC RID: 7084 RVA: 0x0007AB44 File Offset: 0x00078F44
		public UnionCell AttachBuffRate
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06001BAD RID: 7085 RVA: 0x0007AB9C File Offset: 0x00078F9C
		public UnionCell AttachBuffTime
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06001BAE RID: 7086 RVA: 0x0007ABF4 File Offset: 0x00078FF4
		public UnionCell BuffInfoStartCD
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06001BAF RID: 7087 RVA: 0x0007AC4C File Offset: 0x0007904C
		public UnionCell BuffInfoCD
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06001BB0 RID: 7088 RVA: 0x0007ACA4 File Offset: 0x000790A4
		public UnionCell BuffAttack
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06001BB1 RID: 7089 RVA: 0x0007ACFC File Offset: 0x000790FC
		public int BuffCondition
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06001BB2 RID: 7090 RVA: 0x0007AD48 File Offset: 0x00079148
		public int BuffDelay
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06001BB3 RID: 7091 RVA: 0x0007AD94 File Offset: 0x00079194
		public UnionCell BuffRangeRadius
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06001BB4 RID: 7092 RVA: 0x0007ADEC File Offset: 0x000791EC
		public int BuffRangeCheckInterval
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001BB5 RID: 7093 RVA: 0x0007AE38 File Offset: 0x00079238
		public int ConditionSkillIDArray(int j)
		{
			int num = this.__p.__offset(54);
			return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06001BB6 RID: 7094 RVA: 0x0007AE88 File Offset: 0x00079288
		public int ConditionSkillIDLength
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001BB7 RID: 7095 RVA: 0x0007AEBB File Offset: 0x000792BB
		public ArraySegment<byte>? GetConditionSkillIDBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001BB8 RID: 7096 RVA: 0x0007AECA File Offset: 0x000792CA
		public FlatBufferArray<int> ConditionSkillID
		{
			get
			{
				if (this.ConditionSkillIDValue == null)
				{
					this.ConditionSkillIDValue = new FlatBufferArray<int>(new Func<int, int>(this.ConditionSkillIDArray), this.ConditionSkillIDLength);
				}
				return this.ConditionSkillIDValue;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x0007AEFC File Offset: 0x000792FC
		public int RelatedSkillID
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06001BBA RID: 7098 RVA: 0x0007AF48 File Offset: 0x00079348
		public string EffectName
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001BBB RID: 7099 RVA: 0x0007AF8B File Offset: 0x0007938B
		public ArraySegment<byte>? GetEffectNameBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06001BBC RID: 7100 RVA: 0x0007AF9C File Offset: 0x0007939C
		public string EffectLocateName
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001BBD RID: 7101 RVA: 0x0007AFDF File Offset: 0x000793DF
		public ArraySegment<byte>? GetEffectLocateNameBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x06001BBE RID: 7102 RVA: 0x0007AFF0 File Offset: 0x000793F0
		public int RelatedSkillLVArray(int j)
		{
			int num = this.__p.__offset(62);
			return (num == 0) ? 0 : (-337940933 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06001BBF RID: 7103 RVA: 0x0007B040 File Offset: 0x00079440
		public int RelatedSkillLVLength
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001BC0 RID: 7104 RVA: 0x0007B073 File Offset: 0x00079473
		public ArraySegment<byte>? GetRelatedSkillLVBytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06001BC1 RID: 7105 RVA: 0x0007B082 File Offset: 0x00079482
		public FlatBufferArray<int> RelatedSkillLV
		{
			get
			{
				if (this.RelatedSkillLVValue == null)
				{
					this.RelatedSkillLVValue = new FlatBufferArray<int>(new Func<int, int>(this.RelatedSkillLVArray), this.RelatedSkillLVLength);
				}
				return this.RelatedSkillLVValue;
			}
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x0007B0B4 File Offset: 0x000794B4
		public static Offset<BuffInfoTable> CreateBuffInfoTable(FlatBufferBuilder builder, int ID = 0, VectorOffset NameOffset = default(VectorOffset), StringOffset IconOffset = default(StringOffset), VectorOffset DescriptionOffset = default(VectorOffset), BuffInfoTable.eDescType DescType = BuffInfoTable.eDescType.Common, VectorOffset DetailDescriptionOffset = default(VectorOffset), int SortID = 0, BuffInfoTable.eBufferType BufferType = BuffInfoTable.eBufferType.BTR_LV, int NeedHint = 0, int BuffID = 0, VectorOffset MonsterTypeMapOffset = default(VectorOffset), Offset<UnionCell> BuffLevelOffset = default(Offset<UnionCell>), int BuffTarget = 0, int BuffTargetRadius = 0, VectorOffset SkillIDOffset = default(VectorOffset), int monsterModeType = 0, Offset<UnionCell> AttachBuffRateOffset = default(Offset<UnionCell>), Offset<UnionCell> AttachBuffTimeOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffInfoStartCDOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffInfoCDOffset = default(Offset<UnionCell>), Offset<UnionCell> BuffAttackOffset = default(Offset<UnionCell>), int BuffCondition = 0, int BuffDelay = 0, Offset<UnionCell> BuffRangeRadiusOffset = default(Offset<UnionCell>), int BuffRangeCheckInterval = 0, VectorOffset ConditionSkillIDOffset = default(VectorOffset), int RelatedSkillID = 0, StringOffset EffectNameOffset = default(StringOffset), StringOffset EffectLocateNameOffset = default(StringOffset), VectorOffset RelatedSkillLVOffset = default(VectorOffset))
		{
			builder.StartObject(30);
			BuffInfoTable.AddRelatedSkillLV(builder, RelatedSkillLVOffset);
			BuffInfoTable.AddEffectLocateName(builder, EffectLocateNameOffset);
			BuffInfoTable.AddEffectName(builder, EffectNameOffset);
			BuffInfoTable.AddRelatedSkillID(builder, RelatedSkillID);
			BuffInfoTable.AddConditionSkillID(builder, ConditionSkillIDOffset);
			BuffInfoTable.AddBuffRangeCheckInterval(builder, BuffRangeCheckInterval);
			BuffInfoTable.AddBuffRangeRadius(builder, BuffRangeRadiusOffset);
			BuffInfoTable.AddBuffDelay(builder, BuffDelay);
			BuffInfoTable.AddBuffCondition(builder, BuffCondition);
			BuffInfoTable.AddBuffAttack(builder, BuffAttackOffset);
			BuffInfoTable.AddBuffInfoCD(builder, BuffInfoCDOffset);
			BuffInfoTable.AddBuffInfoStartCD(builder, BuffInfoStartCDOffset);
			BuffInfoTable.AddAttachBuffTime(builder, AttachBuffTimeOffset);
			BuffInfoTable.AddAttachBuffRate(builder, AttachBuffRateOffset);
			BuffInfoTable.AddMonsterModeType(builder, monsterModeType);
			BuffInfoTable.AddSkillID(builder, SkillIDOffset);
			BuffInfoTable.AddBuffTargetRadius(builder, BuffTargetRadius);
			BuffInfoTable.AddBuffTarget(builder, BuffTarget);
			BuffInfoTable.AddBuffLevel(builder, BuffLevelOffset);
			BuffInfoTable.AddMonsterTypeMap(builder, MonsterTypeMapOffset);
			BuffInfoTable.AddBuffID(builder, BuffID);
			BuffInfoTable.AddNeedHint(builder, NeedHint);
			BuffInfoTable.AddBufferType(builder, BufferType);
			BuffInfoTable.AddSortID(builder, SortID);
			BuffInfoTable.AddDetailDescription(builder, DetailDescriptionOffset);
			BuffInfoTable.AddDescType(builder, DescType);
			BuffInfoTable.AddDescription(builder, DescriptionOffset);
			BuffInfoTable.AddIcon(builder, IconOffset);
			BuffInfoTable.AddName(builder, NameOffset);
			BuffInfoTable.AddID(builder, ID);
			return BuffInfoTable.EndBuffInfoTable(builder);
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x0007B1BC File Offset: 0x000795BC
		public static void StartBuffInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(30);
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x0007B1C6 File Offset: 0x000795C6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x0007B1D1 File Offset: 0x000795D1
		public static void AddName(FlatBufferBuilder builder, VectorOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x0007B1E4 File Offset: 0x000795E4
		public static VectorOffset CreateNameVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x0007B22A File Offset: 0x0007962A
		public static void StartNameVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x0007B235 File Offset: 0x00079635
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(2, IconOffset.Value, 0);
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x0007B246 File Offset: 0x00079646
		public static void AddDescription(FlatBufferBuilder builder, VectorOffset DescriptionOffset)
		{
			builder.AddOffset(3, DescriptionOffset.Value, 0);
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x0007B258 File Offset: 0x00079658
		public static VectorOffset CreateDescriptionVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x0007B29E File Offset: 0x0007969E
		public static void StartDescriptionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x0007B2A9 File Offset: 0x000796A9
		public static void AddDescType(FlatBufferBuilder builder, BuffInfoTable.eDescType DescType)
		{
			builder.AddInt(4, (int)DescType, 0);
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x0007B2B4 File Offset: 0x000796B4
		public static void AddDetailDescription(FlatBufferBuilder builder, VectorOffset DetailDescriptionOffset)
		{
			builder.AddOffset(5, DetailDescriptionOffset.Value, 0);
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x0007B2C8 File Offset: 0x000796C8
		public static VectorOffset CreateDetailDescriptionVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x0007B30E File Offset: 0x0007970E
		public static void StartDetailDescriptionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BD0 RID: 7120 RVA: 0x0007B319 File Offset: 0x00079719
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(6, SortID, 0);
		}

		// Token: 0x06001BD1 RID: 7121 RVA: 0x0007B324 File Offset: 0x00079724
		public static void AddBufferType(FlatBufferBuilder builder, BuffInfoTable.eBufferType BufferType)
		{
			builder.AddInt(7, (int)BufferType, 0);
		}

		// Token: 0x06001BD2 RID: 7122 RVA: 0x0007B32F File Offset: 0x0007972F
		public static void AddNeedHint(FlatBufferBuilder builder, int NeedHint)
		{
			builder.AddInt(8, NeedHint, 0);
		}

		// Token: 0x06001BD3 RID: 7123 RVA: 0x0007B33A File Offset: 0x0007973A
		public static void AddBuffID(FlatBufferBuilder builder, int BuffID)
		{
			builder.AddInt(9, BuffID, 0);
		}

		// Token: 0x06001BD4 RID: 7124 RVA: 0x0007B346 File Offset: 0x00079746
		public static void AddMonsterTypeMap(FlatBufferBuilder builder, VectorOffset MonsterTypeMapOffset)
		{
			builder.AddOffset(10, MonsterTypeMapOffset.Value, 0);
		}

		// Token: 0x06001BD5 RID: 7125 RVA: 0x0007B358 File Offset: 0x00079758
		public static VectorOffset CreateMonsterTypeMapVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BD6 RID: 7126 RVA: 0x0007B39E File Offset: 0x0007979E
		public static void StartMonsterTypeMapVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BD7 RID: 7127 RVA: 0x0007B3A9 File Offset: 0x000797A9
		public static void AddBuffLevel(FlatBufferBuilder builder, Offset<UnionCell> BuffLevelOffset)
		{
			builder.AddOffset(11, BuffLevelOffset.Value, 0);
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x0007B3BB File Offset: 0x000797BB
		public static void AddBuffTarget(FlatBufferBuilder builder, int BuffTarget)
		{
			builder.AddInt(12, BuffTarget, 0);
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x0007B3C7 File Offset: 0x000797C7
		public static void AddBuffTargetRadius(FlatBufferBuilder builder, int BuffTargetRadius)
		{
			builder.AddInt(13, BuffTargetRadius, 0);
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x0007B3D3 File Offset: 0x000797D3
		public static void AddSkillID(FlatBufferBuilder builder, VectorOffset SkillIDOffset)
		{
			builder.AddOffset(14, SkillIDOffset.Value, 0);
		}

		// Token: 0x06001BDB RID: 7131 RVA: 0x0007B3E8 File Offset: 0x000797E8
		public static VectorOffset CreateSkillIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BDC RID: 7132 RVA: 0x0007B425 File Offset: 0x00079825
		public static void StartSkillIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BDD RID: 7133 RVA: 0x0007B430 File Offset: 0x00079830
		public static void AddMonsterModeType(FlatBufferBuilder builder, int monsterModeType)
		{
			builder.AddInt(15, monsterModeType, 0);
		}

		// Token: 0x06001BDE RID: 7134 RVA: 0x0007B43C File Offset: 0x0007983C
		public static void AddAttachBuffRate(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffRateOffset)
		{
			builder.AddOffset(16, AttachBuffRateOffset.Value, 0);
		}

		// Token: 0x06001BDF RID: 7135 RVA: 0x0007B44E File Offset: 0x0007984E
		public static void AddAttachBuffTime(FlatBufferBuilder builder, Offset<UnionCell> AttachBuffTimeOffset)
		{
			builder.AddOffset(17, AttachBuffTimeOffset.Value, 0);
		}

		// Token: 0x06001BE0 RID: 7136 RVA: 0x0007B460 File Offset: 0x00079860
		public static void AddBuffInfoStartCD(FlatBufferBuilder builder, Offset<UnionCell> BuffInfoStartCDOffset)
		{
			builder.AddOffset(18, BuffInfoStartCDOffset.Value, 0);
		}

		// Token: 0x06001BE1 RID: 7137 RVA: 0x0007B472 File Offset: 0x00079872
		public static void AddBuffInfoCD(FlatBufferBuilder builder, Offset<UnionCell> BuffInfoCDOffset)
		{
			builder.AddOffset(19, BuffInfoCDOffset.Value, 0);
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x0007B484 File Offset: 0x00079884
		public static void AddBuffAttack(FlatBufferBuilder builder, Offset<UnionCell> BuffAttackOffset)
		{
			builder.AddOffset(20, BuffAttackOffset.Value, 0);
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x0007B496 File Offset: 0x00079896
		public static void AddBuffCondition(FlatBufferBuilder builder, int BuffCondition)
		{
			builder.AddInt(21, BuffCondition, 0);
		}

		// Token: 0x06001BE4 RID: 7140 RVA: 0x0007B4A2 File Offset: 0x000798A2
		public static void AddBuffDelay(FlatBufferBuilder builder, int BuffDelay)
		{
			builder.AddInt(22, BuffDelay, 0);
		}

		// Token: 0x06001BE5 RID: 7141 RVA: 0x0007B4AE File Offset: 0x000798AE
		public static void AddBuffRangeRadius(FlatBufferBuilder builder, Offset<UnionCell> BuffRangeRadiusOffset)
		{
			builder.AddOffset(23, BuffRangeRadiusOffset.Value, 0);
		}

		// Token: 0x06001BE6 RID: 7142 RVA: 0x0007B4C0 File Offset: 0x000798C0
		public static void AddBuffRangeCheckInterval(FlatBufferBuilder builder, int BuffRangeCheckInterval)
		{
			builder.AddInt(24, BuffRangeCheckInterval, 0);
		}

		// Token: 0x06001BE7 RID: 7143 RVA: 0x0007B4CC File Offset: 0x000798CC
		public static void AddConditionSkillID(FlatBufferBuilder builder, VectorOffset ConditionSkillIDOffset)
		{
			builder.AddOffset(25, ConditionSkillIDOffset.Value, 0);
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x0007B4E0 File Offset: 0x000798E0
		public static VectorOffset CreateConditionSkillIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x0007B51D File Offset: 0x0007991D
		public static void StartConditionSkillIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x0007B528 File Offset: 0x00079928
		public static void AddRelatedSkillID(FlatBufferBuilder builder, int RelatedSkillID)
		{
			builder.AddInt(26, RelatedSkillID, 0);
		}

		// Token: 0x06001BEB RID: 7147 RVA: 0x0007B534 File Offset: 0x00079934
		public static void AddEffectName(FlatBufferBuilder builder, StringOffset EffectNameOffset)
		{
			builder.AddOffset(27, EffectNameOffset.Value, 0);
		}

		// Token: 0x06001BEC RID: 7148 RVA: 0x0007B546 File Offset: 0x00079946
		public static void AddEffectLocateName(FlatBufferBuilder builder, StringOffset EffectLocateNameOffset)
		{
			builder.AddOffset(28, EffectLocateNameOffset.Value, 0);
		}

		// Token: 0x06001BED RID: 7149 RVA: 0x0007B558 File Offset: 0x00079958
		public static void AddRelatedSkillLV(FlatBufferBuilder builder, VectorOffset RelatedSkillLVOffset)
		{
			builder.AddOffset(29, RelatedSkillLVOffset.Value, 0);
		}

		// Token: 0x06001BEE RID: 7150 RVA: 0x0007B56C File Offset: 0x0007996C
		public static VectorOffset CreateRelatedSkillLVVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001BEF RID: 7151 RVA: 0x0007B5A9 File Offset: 0x000799A9
		public static void StartRelatedSkillLVVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001BF0 RID: 7152 RVA: 0x0007B5B4 File Offset: 0x000799B4
		public static Offset<BuffInfoTable> EndBuffInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BuffInfoTable>(value);
		}

		// Token: 0x06001BF1 RID: 7153 RVA: 0x0007B5CE File Offset: 0x000799CE
		public static void FinishBuffInfoTableBuffer(FlatBufferBuilder builder, Offset<BuffInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000ECE RID: 3790
		private Table __p = new Table();

		// Token: 0x04000ECF RID: 3791
		private FlatBufferArray<string> NameValue;

		// Token: 0x04000ED0 RID: 3792
		private FlatBufferArray<string> DescriptionValue;

		// Token: 0x04000ED1 RID: 3793
		private FlatBufferArray<string> DetailDescriptionValue;

		// Token: 0x04000ED2 RID: 3794
		private FlatBufferArray<UnionCell> MonsterTypeMapValue;

		// Token: 0x04000ED3 RID: 3795
		private FlatBufferArray<int> SkillIDValue;

		// Token: 0x04000ED4 RID: 3796
		private FlatBufferArray<int> ConditionSkillIDValue;

		// Token: 0x04000ED5 RID: 3797
		private FlatBufferArray<int> RelatedSkillLVValue;

		// Token: 0x020002EE RID: 750
		public enum eDescType
		{
			// Token: 0x04000ED7 RID: 3799
			Common,
			// Token: 0x04000ED8 RID: 3800
			SkillLevel
		}

		// Token: 0x020002EF RID: 751
		public enum eBufferType
		{
			// Token: 0x04000EDA RID: 3802
			BTR_LV,
			// Token: 0x04000EDB RID: 3803
			BTR_ATTR
		}

		// Token: 0x020002F0 RID: 752
		public enum eCrypt
		{
			// Token: 0x04000EDD RID: 3805
			code = -337940933
		}
	}
}
