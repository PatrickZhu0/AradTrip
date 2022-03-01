using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2F RID: 19247
	public sealed class DSkillPropertyModify : Table
	{
		// Token: 0x0601C233 RID: 115251 RVA: 0x008933F6 File Offset: 0x008917F6
		public static DSkillPropertyModify GetRootAsDSkillPropertyModify(ByteBuffer _bb)
		{
			return DSkillPropertyModify.GetRootAsDSkillPropertyModify(_bb, new DSkillPropertyModify());
		}

		// Token: 0x0601C234 RID: 115252 RVA: 0x00893403 File Offset: 0x00891803
		public static DSkillPropertyModify GetRootAsDSkillPropertyModify(ByteBuffer _bb, DSkillPropertyModify obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C235 RID: 115253 RVA: 0x0089341F File Offset: 0x0089181F
		public DSkillPropertyModify __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F6 RID: 9974
		// (get) Token: 0x0601C236 RID: 115254 RVA: 0x00893430 File Offset: 0x00891830
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170026F7 RID: 9975
		// (get) Token: 0x0601C237 RID: 115255 RVA: 0x00893460 File Offset: 0x00891860
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026F8 RID: 9976
		// (get) Token: 0x0601C238 RID: 115256 RVA: 0x00893494 File Offset: 0x00891894
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026F9 RID: 9977
		// (get) Token: 0x0601C239 RID: 115257 RVA: 0x008934C8 File Offset: 0x008918C8
		public int Tag
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026FA RID: 9978
		// (get) Token: 0x0601C23A RID: 115258 RVA: 0x00893500 File Offset: 0x00891900
		public int Modifyfliter
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x170026FB RID: 9979
		// (get) Token: 0x0601C23B RID: 115259 RVA: 0x00893538 File Offset: 0x00891938
		public float Value
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026FC RID: 9980
		// (get) Token: 0x0601C23C RID: 115260 RVA: 0x00893574 File Offset: 0x00891974
		public float MovedValue
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x170026FD RID: 9981
		// (get) Token: 0x0601C23D RID: 115261 RVA: 0x008935B0 File Offset: 0x008919B0
		public WeaponClassesOrWhatever SvalueType
		{
			get
			{
				int num = base.__offset(18);
				return (WeaponClassesOrWhatever)((num == 0) ? 0 : this.bb.Get(num + this.bb_pos));
			}
		}

		// Token: 0x170026FE RID: 9982
		// (get) Token: 0x0601C23E RID: 115262 RVA: 0x008935E8 File Offset: 0x008919E8
		public bool JumpToTargetPos
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170026FF RID: 9983
		// (get) Token: 0x0601C23F RID: 115263 RVA: 0x00893624 File Offset: 0x00891A24
		public bool JoystickControl
		{
			get
			{
				int num = base.__offset(24);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002700 RID: 9984
		// (get) Token: 0x0601C240 RID: 115264 RVA: 0x00893660 File Offset: 0x00891A60
		public float ValueAcc
		{
			get
			{
				int num = base.__offset(26);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002701 RID: 9985
		// (get) Token: 0x0601C241 RID: 115265 RVA: 0x0089369C File Offset: 0x00891A9C
		public float MovedValueAcc
		{
			get
			{
				int num = base.__offset(28);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002702 RID: 9986
		// (get) Token: 0x0601C242 RID: 115266 RVA: 0x008936D8 File Offset: 0x00891AD8
		public int ModifyXBackward
		{
			get
			{
				int num = base.__offset(30);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002703 RID: 9987
		// (get) Token: 0x0601C243 RID: 115267 RVA: 0x00893710 File Offset: 0x00891B10
		public float MovedYValue
		{
			get
			{
				int num = base.__offset(32);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002704 RID: 9988
		// (get) Token: 0x0601C244 RID: 115268 RVA: 0x0089374C File Offset: 0x00891B4C
		public float MovedYValueAcc
		{
			get
			{
				int num = base.__offset(34);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002705 RID: 9989
		// (get) Token: 0x0601C245 RID: 115269 RVA: 0x00893788 File Offset: 0x00891B88
		public bool EachFrameModify
		{
			get
			{
				int num = base.__offset(36);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002706 RID: 9990
		// (get) Token: 0x0601C246 RID: 115270 RVA: 0x008937C4 File Offset: 0x00891BC4
		public bool UseMovedYValue
		{
			get
			{
				int num = base.__offset(38);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C247 RID: 115271 RVA: 0x00893800 File Offset: 0x00891C00
		public static Offset<DSkillPropertyModify> CreateDSkillPropertyModify(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int tag = 0, int modifyfliter = 0, float value = 0f, float movedValue = 0f, WeaponClassesOrWhatever svalue_type = WeaponClassesOrWhatever.NONE, int svalue = 0, bool jumpToTargetPos = false, bool joystickControl = false, float valueAcc = 0f, float movedValueAcc = 0f, int modifyXBackward = 0, float movedYValue = 0f, float movedYValueAcc = 0f, bool eachFrameModify = false, bool useMovedYValue = false)
		{
			builder.StartObject(18);
			DSkillPropertyModify.AddMovedYValueAcc(builder, movedYValueAcc);
			DSkillPropertyModify.AddMovedYValue(builder, movedYValue);
			DSkillPropertyModify.AddModifyXBackward(builder, modifyXBackward);
			DSkillPropertyModify.AddMovedValueAcc(builder, movedValueAcc);
			DSkillPropertyModify.AddValueAcc(builder, valueAcc);
			DSkillPropertyModify.AddSvalue(builder, svalue);
			DSkillPropertyModify.AddMovedValue(builder, movedValue);
			DSkillPropertyModify.AddValue(builder, value);
			DSkillPropertyModify.AddModifyfliter(builder, modifyfliter);
			DSkillPropertyModify.AddTag(builder, tag);
			DSkillPropertyModify.AddLength(builder, length);
			DSkillPropertyModify.AddStartframe(builder, startframe);
			DSkillPropertyModify.AddName(builder, name);
			DSkillPropertyModify.AddUseMovedYValue(builder, useMovedYValue);
			DSkillPropertyModify.AddEachFrameModify(builder, eachFrameModify);
			DSkillPropertyModify.AddJoystickControl(builder, joystickControl);
			DSkillPropertyModify.AddJumpToTargetPos(builder, jumpToTargetPos);
			DSkillPropertyModify.AddSvalueType(builder, svalue_type);
			return DSkillPropertyModify.EndDSkillPropertyModify(builder);
		}

		// Token: 0x0601C248 RID: 115272 RVA: 0x008938A8 File Offset: 0x00891CA8
		public static void StartDSkillPropertyModify(FlatBufferBuilder builder)
		{
			builder.StartObject(18);
		}

		// Token: 0x0601C249 RID: 115273 RVA: 0x008938B2 File Offset: 0x00891CB2
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C24A RID: 115274 RVA: 0x008938C3 File Offset: 0x00891CC3
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C24B RID: 115275 RVA: 0x008938CE File Offset: 0x00891CCE
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C24C RID: 115276 RVA: 0x008938D9 File Offset: 0x00891CD9
		public static void AddTag(FlatBufferBuilder builder, int tag)
		{
			builder.AddInt(3, tag, 0);
		}

		// Token: 0x0601C24D RID: 115277 RVA: 0x008938E4 File Offset: 0x00891CE4
		public static void AddModifyfliter(FlatBufferBuilder builder, int modifyfliter)
		{
			builder.AddInt(4, modifyfliter, 0);
		}

		// Token: 0x0601C24E RID: 115278 RVA: 0x008938EF File Offset: 0x00891CEF
		public static void AddValue(FlatBufferBuilder builder, float value)
		{
			builder.AddFloat(5, value, 0.0);
		}

		// Token: 0x0601C24F RID: 115279 RVA: 0x00893902 File Offset: 0x00891D02
		public static void AddMovedValue(FlatBufferBuilder builder, float movedValue)
		{
			builder.AddFloat(6, movedValue, 0.0);
		}

		// Token: 0x0601C250 RID: 115280 RVA: 0x00893915 File Offset: 0x00891D15
		public static void AddSvalueType(FlatBufferBuilder builder, WeaponClassesOrWhatever svalueType)
		{
			builder.AddByte(7, (byte)svalueType, 0);
		}

		// Token: 0x0601C251 RID: 115281 RVA: 0x00893920 File Offset: 0x00891D20
		public static void AddSvalue(FlatBufferBuilder builder, int svalueOffset)
		{
			builder.AddOffset(8, svalueOffset, 0);
		}

		// Token: 0x0601C252 RID: 115282 RVA: 0x0089392B File Offset: 0x00891D2B
		public static void AddJumpToTargetPos(FlatBufferBuilder builder, bool jumpToTargetPos)
		{
			builder.AddBool(9, jumpToTargetPos, false);
		}

		// Token: 0x0601C253 RID: 115283 RVA: 0x00893937 File Offset: 0x00891D37
		public static void AddJoystickControl(FlatBufferBuilder builder, bool joystickControl)
		{
			builder.AddBool(10, joystickControl, false);
		}

		// Token: 0x0601C254 RID: 115284 RVA: 0x00893943 File Offset: 0x00891D43
		public static void AddValueAcc(FlatBufferBuilder builder, float valueAcc)
		{
			builder.AddFloat(11, valueAcc, 0.0);
		}

		// Token: 0x0601C255 RID: 115285 RVA: 0x00893957 File Offset: 0x00891D57
		public static void AddMovedValueAcc(FlatBufferBuilder builder, float movedValueAcc)
		{
			builder.AddFloat(12, movedValueAcc, 0.0);
		}

		// Token: 0x0601C256 RID: 115286 RVA: 0x0089396B File Offset: 0x00891D6B
		public static void AddModifyXBackward(FlatBufferBuilder builder, int modifyXBackward)
		{
			builder.AddInt(13, modifyXBackward, 0);
		}

		// Token: 0x0601C257 RID: 115287 RVA: 0x00893977 File Offset: 0x00891D77
		public static void AddMovedYValue(FlatBufferBuilder builder, float movedYValue)
		{
			builder.AddFloat(14, movedYValue, 0.0);
		}

		// Token: 0x0601C258 RID: 115288 RVA: 0x0089398B File Offset: 0x00891D8B
		public static void AddMovedYValueAcc(FlatBufferBuilder builder, float movedYValueAcc)
		{
			builder.AddFloat(15, movedYValueAcc, 0.0);
		}

		// Token: 0x0601C259 RID: 115289 RVA: 0x0089399F File Offset: 0x00891D9F
		public static void AddEachFrameModify(FlatBufferBuilder builder, bool eachFrameModify)
		{
			builder.AddBool(16, eachFrameModify, false);
		}

		// Token: 0x0601C25A RID: 115290 RVA: 0x008939AB File Offset: 0x00891DAB
		public static void AddUseMovedYValue(FlatBufferBuilder builder, bool useMovedYValue)
		{
			builder.AddBool(17, useMovedYValue, false);
		}

		// Token: 0x0601C25B RID: 115291 RVA: 0x008939B8 File Offset: 0x00891DB8
		public static Offset<DSkillPropertyModify> EndDSkillPropertyModify(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillPropertyModify>(value);
		}
	}
}
